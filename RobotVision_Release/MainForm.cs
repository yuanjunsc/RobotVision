#define Debug
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
using Emgu.CV.CvEnum;
using Emgu.Util;

namespace RobotVision_Release
{
    public partial class MainForm : Form
    {
        private bool isAuto = false;//是否自动
        private bool _captureInProgress = false;//是否执行操作
        private Capture _capture;//摄像头
        private int frameNum = 0;//记录一秒钟几帧
        public short[] coordinate = new short[2];
        private bool getStart = false;
        private byte[] sendByte = new byte[5] { 0xaa, 0, 0, 0, 0 };
        private int numLine = 0;
        private long numError = 0;
        int mapHeight = 0 ;
        int mapWidth = 0;
        int delayTime = 0;
        bool isFound = false;
        private enum ControlStep
        {
            Wait,
            Search,//全盘搜索
            FineTuning,//微调
            Stop
        };
        ControlStep myCS = ControlStep.Wait;
        int waitTime = 0;

        int foundTime = 0;//记录找到了多少次
        int inFrame = 0; //记录进入了图片多少次

        int[] centre = new int[2] { 61, 66 };//水平
        //int[] centre = new int[2] { 96, 54 };//斜
        int[] centreRedMid = new int[2] { 61, 66 };//红场平 命令
        int[] centreRedTilt = new int[2] { 61, 66 };//红场斜 命令
        int[] centreBlueMid = new int[2] { 61, 66 };//蓝场平 命令
        int[] centreBlueTilt = new int[2] { 61, 66 };//蓝场斜 命令78,74
        int[] foundCentre = new int[2];
        int pointGrayError = 160;//识别点的误差最初为160

        

        public MainForm()
        {
            InitializeComponent();
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frame = _capture.QuerySmallFrame();
            originImageBox.Image = frame;
            if (_captureInProgress)
            {                                
                foundCentre[0] = 0;
                foundCentre[1] = 0;
                numLine = 0;
                numError = 0;
                Bitmap myBitmap = frame.ToBitmap();
                try
                {
                    processImageBox.Image = new Image<Gray, Byte>(myIdentification(myBitmap));
                }
                catch (Exception e)
                { }
                controlSmall();
                if (myCS == ControlStep.Wait)
                {
                    stateTextBox.Text = "Wait";
                }
                else if (myCS == ControlStep.Search)
                {
                    stateTextBox.Text = "Search";
                }
                else if (myCS == ControlStep.FineTuning)
                {
                    stateTextBox.Text = "FineTuning";
                }
                frameNum++;
            }                    
        }

        private void autoBtn_Click(object sender, EventArgs e)
        {//用来修改手动和自动的，其中表现为isAuto已经被修改
            if (isAuto == true)
            {
                isAuto = false;
                autoBtn.Text = "手动";
            }
            else
            {
                isAuto = true;
                autoBtn.Text = "自动";
            }            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //启动设置
            initialization();
            isAuto = true;//手动，比赛时要调成自动的
            autoBtn.Text = "自动";
            openSP(baudTextBox.Text, comTextBox.Text);   //打开串口
            openCamera();//打开摄像头,调试时打开时钟
            _capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 320);
            _capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 240);
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            frameNumToolStripStatusLabel.Text = frameNum.ToString();
            frameNum = 0;
            xGoal.Text = centre[0].ToString();
            yGoal.Text = centre[1].ToString();
            if (isFound)
            {
                delayTime++;
            }
        }

        private void openCameraBtn_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {                
                if (_captureInProgress)
                {  //stop the capture
                    openCameraBtn.Text = "打开摄像头";
                    _captureInProgress = false;
                }
                else
                {
                    //start the capture 
                    openCameraBtn.Text = "关闭摄像头";
                    _captureInProgress = true;
                }                
            }
        }

        private void openSPBtn_Click(object sender, EventArgs e)
        {
            openSP(baudTextBox.Text, comTextBox.Text);   //打开串口
        }

        private void mySP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] readBuffer = new byte[mySP.ReadBufferSize];
            mySP.Read(readBuffer, 0, readBuffer.Length);
            int i = 0;
            while (i < readBuffer.Length)
            {
                if (readBuffer[i] == (byte)0x00)
                {
                    break;
                }

                if (getStart == false && readBuffer[i] == (byte)0xaa)
                {
                    getStart = true;
                }
                else if (getStart == true)
                {
                    getStart = false;
                    if (readBuffer[i] == (byte)0x01)
                    {
                        _captureInProgress = true;
                        delayTime = 0;
                        isFound = false;
                        //openCameraBtn.Text = "关闭摄像头";                        
                        myCS = ControlStep.Search;
                        searchGlobe();
                    }
                    else if (readBuffer[i] == (byte)0x02)
                    {
                        _captureInProgress = false;
                        //openCameraBtn.Text = "打开摄像头";
                    }
                    else if (readBuffer[i] == (byte)0xd0)
                    {
                        //红场水平
                        centre[0] = centreRedMid[0];
                        centre[1] = centreRedMid[1];
                    }
                    else if (readBuffer[i] == (byte)0xd1)
                    {
                        centre[0] = centreRedTilt[0];
                        centre[1] = centreRedTilt[1];
                    }
                    else if (readBuffer[i] == (byte)0xd2)
                    {
                        centre[0] = centreBlueMid[0];
                        centre[1] = centreBlueMid[1];
                    }
                    else if (readBuffer[i] == (byte)0xd3)
                    {
                        centre[0] = centreBlueTilt[0];
                        centre[1] = centreBlueTilt[1];
                    }
                }
                i++;
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            upSearch();
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            downSearch();
        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            leftSearch();
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            rightSearch();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            searchGlobe();
        }

        private void releaseBtn_Click(object sender, EventArgs e)
        {
            releaseGoal();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopSearch();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void myStatusS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void originImageBox_Click(object sender, EventArgs e)
        {

        }
    }
}
