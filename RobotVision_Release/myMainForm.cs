//#define Debug

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace RobotVision_Release
{
    public struct MaxValue
    {
        public int Value;
        public int Dist;
        public int AngleNumber;
    };

    public partial class MainForm : Form
    {
        private void openSP(string baud, string num)
        {
            if(mySP.IsOpen)
            {
                mySP.Close();
                return;
            }
            mySP.BaudRate = System.Convert.ToInt32(baud);
            mySP.PortName = "COM" + num;            
            #region 打开串口，如果出现错误显示
            try
            {
                mySP.Open();
            }
            catch (Exception excpt)
            {
                MessageBox.Show(excpt.Message);                
            }
            #endregion
            if (mySP.IsOpen)
            {
                openSPBtn.Text = "关闭串口";
            }
            else
            {
                openSPBtn.Text = "打开串口";
            }
        }
        private void openCamera()
        {
            #region  如果摄像头没有打开，打开串口，如果出现错误显示
            if (_capture == null)
            {
                try
                {
                    #if Debug
                        _capture = new Capture(1);
                    #else
                        _capture = new Capture(0);
                    #endif
                }
                catch (NullReferenceException excpt)
                {                    
                  MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (_capture != null)
            {
                Application.Idle += ProcessFrame;
            }
            myTimer.Enabled = true;
        }
        private Bitmap myIdentification(Bitmap curBitmap)
        {
            if (curBitmap == null)
            {
                return null;
            }
            Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);

            System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = curBitmap.Width * curBitmap.Height;

            byte[] grayValues = new byte[bytes];
            byte[] grayValues2 = new byte[bytes];

            bytes *= 3;

            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            long maxGray = 0;
            long tmpGray = 0;
            long tmpColor = 0;
            long[] sum = new long[3] { 0, 0, 0 };
            int tmp_location;
            int width = 0, height = 0;
            mapHeight = curBitmap.Height;
            mapWidth = curBitmap.Width;
            //判别颜色加二值化
            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                tmpGray = (rgbValues[i + 2] + rgbValues[i + 1] + rgbValues[i]);
                grayValues2[i / 3] = (byte)(tmpGray / 3);
                if (tmpGray > maxGray)
                {
                    maxGray = tmpGray;
                }
                tmpColor = Math.Abs(rgbValues[i + 2] - rgbValues[i + 1]);
                tmpColor += Math.Abs(rgbValues[i] - rgbValues[i + 1]);
                tmpColor += Math.Abs(rgbValues[i + 2] - rgbValues[i]);
                if (tmpColor < 150 && tmpGray > 600)
                {
                    //rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)255;
                    grayValues[i / 3] = (byte)255;
                    tmp_location = i / 3;
                    sum[0] += width;
                    sum[1] += height;
                    sum[2]++;

                }
                else
                {
                    //rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)0;                        
                }
                if ((++width) == mapWidth)
                {
                    width = 0;
                    height++;
                }
            }
            
            coordinate[0] = (short)(sum[0] / sum[2]);
            coordinate[1] = (short)(sum[1] / sum[2]);
            coordinate[1] = (short)(mapHeight - coordinate[1]);
            
            int[] window = new int[5] { 0, 0, 0, 0, 0 };
            window[4] = 50;

            window[0] = coordinate[0] - window[4];
            if (window[0] < 10)
            {
                window[0] = 10;
            }

            window[1] = coordinate[0] + window[4];
            if (window[1] > mapWidth - 10)
            {
                window[1] = mapWidth - 10;
            }

            window[2] = coordinate[1] - window[4];
            if (window[2] < 10)
            {
                window[2] = 10;
            }

            window[3] = coordinate[1] + window[4];
            if (window[3] > mapHeight - 10)
            {
                window[3] = mapHeight - 10;
            }
            
            //Rectangle ROI = new Rectangle(window[0], window[2], (window[1] - window[0]), (window[3] - window[2]));           
            Rectangle ROI = new Rectangle(10, 10, mapWidth - 20, mapHeight - 20);

            Mem_SobelDIB_ROI(grayValues, mapWidth, mapHeight, ROI);//修改函数，使得不需要二值化
            //Mem_mannal_ThresholdDIB_ROI(grayValues, curBitmap.Width, curBitmap.Height, 1, ROI, 125);
            Mem_Hough(grayValues, mapWidth, mapHeight, ROI);
            Mem_cal(grayValues, mapWidth, mapHeight, ROI, coordinate);

            for (int i = 0; i < grayValues.Length; i++)
            {
                rgbValues[3 * i + 2] = grayValues[i];
                rgbValues[3 * i + 1] = grayValues[i];
                rgbValues[3 * i] = grayValues[i];
            }



            drawPoint(rgbValues, coordinate[0], coordinate[1], mapWidth, mapHeight);
            int distancePoint = 20;
            int errorMax = 0;
            int errorTmpX = 0;
            int errorTmpY = 0;
            drawPoint(rgbValues, coordinate[0] - distancePoint, coordinate[1], mapWidth, mapHeight);
            drawPoint(rgbValues, coordinate[0] + distancePoint, coordinate[1], mapWidth, mapHeight);
            drawPoint(rgbValues, coordinate[0], coordinate[1] - distancePoint, mapWidth, mapHeight);
            drawPoint(rgbValues, coordinate[0], coordinate[1] + distancePoint, mapWidth, mapHeight);

            errorTmpX = calPointGrayError(grayValues2, coordinate[0] - distancePoint, coordinate[1], coordinate[0] + distancePoint, coordinate[1], mapWidth, mapHeight);
            errorTmpY = calPointGrayError(grayValues2, coordinate[0], coordinate[1] - distancePoint, coordinate[0], coordinate[1] + distancePoint, mapWidth, mapHeight);

            if (errorTmpX > errorTmpY)
            {
                errorMax = errorTmpX;
            }
            else
            {
                errorMax = errorTmpY;
            }
            numError = errorMax;
            whiteNum.Text = errorMax.ToString();

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            curBitmap.UnlockBits(bmpData);
            return curBitmap;
        }

        private int calPointGrayError(byte[] gray, int x1, int y1, int x2, int y2, int myMapWidth, int myMapHeight)
        {
            int tmp1 = 0;
            //tmp1 = gray[(y1 - 1) * myMapWidth + x1 - 1] + gray[(y1 - 1) * myMapWidth + x1] + gray[(y1 - 1) * myMapWidth + x1 + 1]
            //    + gray[y1 * myMapWidth + x1 - 1] + gray[y1 * myMapWidth + x1] + gray[y1 * myMapWidth + x1 + 1]
            //    + gray[(y1 + 1) * myMapWidth + x1 - 1] + gray[(y1 + 1) * myMapWidth + x1] + gray[(y1 + 1) * myMapWidth + x1 + 1];
            tmp1 = gray[y1 * myMapWidth + x1];

            int tmp2 = 0;
            //tmp2 = gray[(y2 - 2) * myMapWidth + x2 - 2] + gray[(y2 - 2) * myMapWidth + x2] + gray[(y2 - 2) * myMapWidth + x2 + 2]
            //    + gray[y2 * myMapWidth + x2 - 2] + gray[y2 * myMapWidth + x2] + gray[y2 * myMapWidth + x2 + 2]
            //    + gray[(y2 + 2) * myMapWidth + x2 - 2] + gray[(y2 + 2) * myMapWidth + x2] + gray[(y2 + 2) * myMapWidth + x2 + 2];
            tmp2 = gray[y2 * myMapWidth + x2];

            return System.Math.Abs(tmp1 - tmp2);
        }

        private void drawPoint(byte[] myrgbValue, int x, int y, int myMapWidth, int myMapHeight)
        {
            int start = 5;
            for (int i = x - start; i < x + start; i++)
            {
                myrgbValue[3 * (y * myMapWidth + i) + 2] = 0;
                myrgbValue[3 * (y * myMapWidth + i) + 1] = 0;
            }

            for (int i = y - start; i < y + start; i++)
            {
                myrgbValue[3 * (i * myMapWidth + x) + 2] = 0;
                myrgbValue[3 * (i * myMapWidth + x) + 1] = 0;
            }

        }

        private void Mem_cal(byte[] pNewBits, int width, int height, Rectangle ROI, short[] coordinate)
        {
            byte pixel;
            long x = 0;
            long y = 0;
            int i, j, num;
            num = 0;
            for (i = ROI.Left; i < ROI.Right; i++)
            {
                for (j = height - 1 - ROI.Bottom; j < height - 1 - ROI.Top; j++)
                {
                    pixel = pNewBits[width * j + i];
                    if (pixel == 0)
                    {
                        num++;
                        x += i;
                        y += j;
                    }
                }
            }
            //求质心
            if (num == 0)
            {
                coordinate[0] = 800;
                coordinate[1] = 800;
            }
            else
            {
                coordinate[0] = (short)(x / num);
                coordinate[1] = (short)(y / num);
            }
            foundCentre[0] = coordinate[0];
            foundCentre[1] = coordinate[1];
            xLocation.Text = coordinate[0].ToString();
            yLocation.Text = coordinate[1].ToString();
            numLine = num;
            lineNum.Text = numLine.ToString();//直线数目

            //发送
            //byte[] send_x = BitConverter.GetBytes((short)coordinate[0]);
            //byte[] send_y = BitConverter.GetBytes((short)coordinate[1]);
            //sendByte[1] = send_x[0];
            //sendByte[2] = send_x[1];
            //sendByte[3] = send_y[0];
            //sendByte[4] = send_y[1];
            //try
            //{
            //    mySP.Write(sendByte, 0, 5);
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }
        private void Mem_SobelDIB_ROI(byte[] imagedata, int width, int height, Rectangle ROI)
        {
            //循环变量
            long i;
            long j;
            float dx;
            float dy;
            double sobel = 0.0;
            byte[] pNewBits = new byte[width * height];
            for (j = ROI.Top; j <= ROI.Bottom; j++)
            {
                for (i = ROI.Left; i <= ROI.Right; i++)
                {
                    dx = (-2) * imagedata[width * (height - 1 - j) + i - 1] + 2 * imagedata[width * (height - 1 - j) + i + 1]
                          - imagedata[width * (height - j) + i - 1] + imagedata[width * (height - j) + i + 1]
                          - imagedata[width * (height - j - 2) + i - 1] + imagedata[width * (height - j - 2) + i + 1];
                    dy = imagedata[width * (height - 2 - j) + i - 1] + 2 * imagedata[width * (height - 2 - j) + i] + imagedata[width * (height - 2 - j) + i + 1]
                         - imagedata[width * (height - j) + i - 1] - 2 * imagedata[width * (height - j) + i] - imagedata[width * (height - j) + i + 1];
                    sobel = System.Math.Sqrt(dx * dx + dy * dy);
                    if (sobel > 255)
                    {
                        pNewBits[width * (height - j - 1) + i] = 0;
                    }
                    else
                    {
                        pNewBits[width * (height - j - 1) + i] = 255;
                    }
                }
            }

            memcpy(imagedata, pNewBits);
        }
        private bool memcpy(byte[] BitsTo, byte[] BitsFrom)
        {
            if (BitsTo.Length < BitsFrom.Length)
            {
                return false;
            }
            int j = 0;
            foreach (byte i in BitsFrom)
            {
                BitsTo[j++] = i;
            }
            return true;
        }
        private void Mem_Hough(byte[] pNewBits, int width, int height, Rectangle ROI)
        {
            byte[] pNewBits2 = new byte[width * height];//初始化为255
            for (int ii = 0; ii < pNewBits2.Length; ii++)
            {
                pNewBits2[ii] = 255;
            }
            // 指向变换域的指针  
            byte[] lpTrans;
            //变换域的尺寸
            int iMaxDist;
            int iMaxAngleNumber;
            //变换域的坐标
            int iDist;
            int iAngleNumber;
            //循环变量
            long i;
            long j;
            //像素值
            byte pixel;
            //存储变换域中的最大值
            MaxValue MaxValue1;
            //计算变换域的尺寸
            //最大距离
            iMaxDist = (int)System.Math.Sqrt(width * width + height * height);
            //角度从0－180，每格2度
            iMaxAngleNumber = 90;
            int precsion = 2;
            //为变换域分配内存
            lpTrans = new byte[iMaxDist * iMaxAngleNumber];//初始化为0
            // 初始化新分配的内存，设定初始值为0
            for (j = ROI.Top; j < ROI.Bottom; j++)
            {
                for (i = ROI.Left; i < ROI.Right; i++)
                {
                    //取得当前指针处的像素值，注意要转换为unsigned char型
                    pixel = pNewBits[width * (height - 1 - j) + i];

                    //如果是黑点，则在变换域的对应各点上加1
                    if (pixel == 0)
                    {
                        //注意步长是2度
                        for (iAngleNumber = 0; iAngleNumber < iMaxAngleNumber; iAngleNumber++)
                        {
                            iDist = (int)System.Math.Abs(i * Math.Cos(iAngleNumber * precsion * Math
                            .PI / 180.0) + j * Math.Sin(iAngleNumber * precsion * Math.PI / 180.0));
                            lpTrans[iDist * iMaxAngleNumber + iAngleNumber]++;
                        }

                    }
                }
            }
            //找到变换域中的最大值点
            MaxValue1.Value = 0;
            MaxValue1.Dist = 0;
            MaxValue1.AngleNumber = 0;
            //找到最大值点
            for (iDist = 0; iDist < iMaxDist; iDist++)
            {
                for (iAngleNumber = 0; iAngleNumber < iMaxAngleNumber; iAngleNumber++)
                {
                    if (lpTrans[iDist * iMaxAngleNumber + iAngleNumber] > MaxValue1.Value)
                    {
                        MaxValue1.Value = lpTrans[iDist * iMaxAngleNumber + iAngleNumber];
                        MaxValue1.Dist = iDist;
                        MaxValue1.AngleNumber = iAngleNumber;
                    }

                }
            }
            //在缓存图像中重绘这条直线
            for (j = ROI.Top; j < ROI.Bottom; j++)
            {
                for (i = ROI.Left; i < ROI.Right; i++)
                {
                    if (pNewBits[width * (height - 1 - j) + i] == 0)
                    {
                        //如果该点在直线上，则在缓存图像上将该点赋为黑
                        iDist = (int)System.Math.Abs(i * Math.Cos(MaxValue1.AngleNumber * precsion * Math.PI / 180.0) +
                                    j * Math.Sin(MaxValue1.AngleNumber * precsion * Math.PI / 180.0));
                        if (iDist == MaxValue1.Dist)
                        {
                            pNewBits2[width * (height - 1 - j) + i] = 0;
                        }
                    }
                }
            }
            memcpy(pNewBits, pNewBits2);
        }
        private void controlSmall()
        {
            if (isAuto == false)
            {
                return;
            }//是否自动

            if (myCS != ControlStep.Wait)
            {
                waitTime = 0;
            }
            
            if (myCS != ControlStep.FineTuning)
            {
                foundTime = 0;
                if (inFrame > 0)
                {
                    inFrame--;
                }
            }

            if (myCS == ControlStep.Search)
            {
                if (numLine > 70 && numError > pointGrayError)
                {
                    stopSearch();
                    myCS = ControlStep.Wait;
                    return;
                }
            }            
            //发现的是错误
            if (numLine < 50 || numError < pointGrayError)
            {                
                //if (inFrame > 0)
                //{
                //    inFrame -= 2;
                //    return;
                //}
                myCS = ControlStep.Wait;                
                if (waitTime > 12)
                {
                    waitTime = 0;
                    myCS = ControlStep.Search;
                    searchGlobe();
                    return;
                }
                waitTime++;
                return;
            }            
            
            //分情况
            if (myCS == ControlStep.Wait)
            {                
                stopSearch();
                if (numLine > 50)
                {
                    myCS = ControlStep.FineTuning;                    
                }
                waitTime++;
                if (waitTime > 15)
                {
                    waitTime = 0;
                    myCS = ControlStep.Search;
                    searchGlobe();
                    return; 
                }                        
            }

            if (myCS == ControlStep.FineTuning)
            {
                //从第一次发现到释放延时3秒钟
                isFound = true;
                if (delayTime > 35)
                {
                    releaseGoal();//分段赛打开
                }
                inFrame++;
                //主要调节函数
                stopSearch();
                if (foundCentre[0] < 5 || foundCentre[0] > 155)
                {
                    myCS = ControlStep.Wait;
                    return;
                }

                if (foundCentre[1] < 5 || foundCentre[1] > 115)
                {
                    myCS = ControlStep.Wait;
                    return;
                }//出界重新等待

                int dx = foundCentre[0] - centre[0];    //大于0在右边
                int dy = foundCentre[1] - centre[1];    //大于0在下边
                if (dx * dx + dy * dy < 120)//60
                {
                    foundTime++;
                    if ((inFrame / 15  + foundTime) > 2)
                    {
                        foundTime = 0;
                        inFrame = 0;
                        releaseGoal();
                        return;
                    }
                    //慢动
                    if (System.Math.Abs(dx) > System.Math.Abs(dy))
                    {
                        if (dx > 0)
                        {
                            sender(0xB3); //左
                            return;
                        }
                        else
                        {
                            sender(0xB4); //右
                            return;
                        }
                    }
                    else
                    {
                        if (dy > 0)
                        {
                            sender(0xB1);
                            return;
                        }
                        else
                        {
                            sender(0xB2);
                            return;
                        }
                    }
                }
                //foundTime = 0;
                //快动
                if (System.Math.Abs(dx) > System.Math.Abs(dy))
                {
                    if (dx > 0)
                    {
                        leftSearch();
                        return;
                    }
                    else
                    {
                        rightSearch();
                        return;
                    }
                }
                else
                {
                    if (dy > 0)
                    {
                        upSearch();
                        return;
                    }
                    else
                    {
                        downSearch();
                        return;
                    }
                }

            }//微调结束

        }
        private void sender(byte data)
        {
            sendByte[1] = (byte)(data);
            try
            {
                mySP.Write(sendByte, 0, 2);
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
        }
        private void upSearch()
        {
            sender(0xA1);            
        }
        private void downSearch()
        {
            sender(0xA2);
        }
        private void leftSearch()
        {
            sender(0xA3);            
        }
        private void rightSearch()
        {
            sender(0xA4);
        }
        private void searchGlobe()
        {
            sender(0xA0);
        }
        private void stopSearch()
        {
            sender(0xA6);
        }
        private void releaseGoal()
        {
            sender(0xA5);
        }
        private void initialization()
        {
            #if Debug
                comTextBox.Text = "5";
            #endif
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
