namespace RobotVision_Release
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myStatusS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.frameNumToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.originImageBox = new Emgu.CV.UI.ImageBox();
            this.processImageBox = new Emgu.CV.UI.ImageBox();
            this.yGoal = new System.Windows.Forms.TextBox();
            this.xGoal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.autoBtn = new System.Windows.Forms.Button();
            this.lineNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.whiteNum = new System.Windows.Forms.TextBox();
            this.yLocation = new System.Windows.Forms.TextBox();
            this.xLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.releaseBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.rightBtn = new System.Windows.Forms.Button();
            this.upBtn = new System.Windows.Forms.Button();
            this.comTextBox = new System.Windows.Forms.TextBox();
            this.baudTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.setSPBtn = new System.Windows.Forms.Button();
            this.openSPBtn = new System.Windows.Forms.Button();
            this.openCameraBtn = new System.Windows.Forms.Button();
            this.mySP = new System.IO.Ports.SerialPort(this.components);
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.myStatusS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // myStatusS
            // 
            this.myStatusS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.frameNumToolStripStatusLabel,
            this.toolStripStatusLabel2});
            this.myStatusS.Location = new System.Drawing.Point(0, 557);
            this.myStatusS.Name = "myStatusS";
            this.myStatusS.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.myStatusS.Size = new System.Drawing.Size(923, 25);
            this.myStatusS.TabIndex = 0;
            this.myStatusS.Text = "statusStrip1";
            this.myStatusS.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.myStatusS_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 20);
            this.toolStripStatusLabel1.Text = "一秒钟处理 ";
            // 
            // frameNumToolStripStatusLabel
            // 
            this.frameNumToolStripStatusLabel.Name = "frameNumToolStripStatusLabel";
            this.frameNumToolStripStatusLabel.Size = new System.Drawing.Size(30, 20);
            this.frameNumToolStripStatusLabel.Text = "   0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(24, 20);
            this.toolStripStatusLabel2.Text = "帧";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.yGoal);
            this.splitContainer1.Panel2.Controls.Add(this.xGoal);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.stateTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.searchBtn);
            this.splitContainer1.Panel2.Controls.Add(this.stopBtn);
            this.splitContainer1.Panel2.Controls.Add(this.autoBtn);
            this.splitContainer1.Panel2.Controls.Add(this.lineNum);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.whiteNum);
            this.splitContainer1.Panel2.Controls.Add(this.yLocation);
            this.splitContainer1.Panel2.Controls.Add(this.xLocation);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.releaseBtn);
            this.splitContainer1.Panel2.Controls.Add(this.downBtn);
            this.splitContainer1.Panel2.Controls.Add(this.leftBtn);
            this.splitContainer1.Panel2.Controls.Add(this.rightBtn);
            this.splitContainer1.Panel2.Controls.Add(this.upBtn);
            this.splitContainer1.Panel2.Controls.Add(this.comTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.baudTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.setSPBtn);
            this.splitContainer1.Panel2.Controls.Add(this.openSPBtn);
            this.splitContainer1.Panel2.Controls.Add(this.openCameraBtn);
            this.splitContainer1.Size = new System.Drawing.Size(923, 557);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.originImageBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.processImageBox);
            this.splitContainer2.Size = new System.Drawing.Size(921, 351);
            this.splitContainer2.SplitterDistance = 460;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // originImageBox
            // 
            this.originImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.originImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originImageBox.Location = new System.Drawing.Point(0, 0);
            this.originImageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.originImageBox.Name = "originImageBox";
            this.originImageBox.Size = new System.Drawing.Size(456, 347);
            this.originImageBox.TabIndex = 2;
            this.originImageBox.TabStop = false;
            this.originImageBox.Click += new System.EventHandler(this.originImageBox_Click);
            // 
            // processImageBox
            // 
            this.processImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processImageBox.Location = new System.Drawing.Point(0, 0);
            this.processImageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.processImageBox.Name = "processImageBox";
            this.processImageBox.Size = new System.Drawing.Size(452, 347);
            this.processImageBox.TabIndex = 2;
            this.processImageBox.TabStop = false;
            // 
            // yGoal
            // 
            this.yGoal.Location = new System.Drawing.Point(560, 61);
            this.yGoal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yGoal.Name = "yGoal";
            this.yGoal.Size = new System.Drawing.Size(45, 25);
            this.yGoal.TabIndex = 29;
            this.yGoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xGoal
            // 
            this.xGoal.Location = new System.Drawing.Point(503, 61);
            this.xGoal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xGoal.Name = "xGoal";
            this.xGoal.Size = new System.Drawing.Size(48, 25);
            this.xGoal.TabIndex = 28;
            this.xGoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "目标中心位置";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(232, 32);
            this.stateTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(79, 25);
            this.stateTextBox.TabIndex = 26;
            this.stateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "状态";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(659, 146);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(56, 29);
            this.searchBtn.TabIndex = 24;
            this.searchBtn.Text = "搜";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(729, 146);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(61, 29);
            this.stopBtn.TabIndex = 23;
            this.stopBtn.Text = "停";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // autoBtn
            // 
            this.autoBtn.Location = new System.Drawing.Point(723, 60);
            this.autoBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.autoBtn.Name = "autoBtn";
            this.autoBtn.Size = new System.Drawing.Size(68, 29);
            this.autoBtn.TabIndex = 22;
            this.autoBtn.Text = "手动";
            this.autoBtn.UseVisualStyleBackColor = true;
            this.autoBtn.Click += new System.EventHandler(this.autoBtn_Click);
            // 
            // lineNum
            // 
            this.lineNum.Location = new System.Drawing.Point(487, 145);
            this.lineNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lineNum.Name = "lineNum";
            this.lineNum.Size = new System.Drawing.Size(132, 25);
            this.lineNum.TabIndex = 20;
            this.lineNum.Text = "0";
            this.lineNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "直线长度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "图像差";
            // 
            // whiteNum
            // 
            this.whiteNum.Location = new System.Drawing.Point(487, 101);
            this.whiteNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.whiteNum.Name = "whiteNum";
            this.whiteNum.Size = new System.Drawing.Size(132, 25);
            this.whiteNum.TabIndex = 17;
            this.whiteNum.Text = "0";
            this.whiteNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yLocation
            // 
            this.yLocation.Location = new System.Drawing.Point(560, 24);
            this.yLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yLocation.Name = "yLocation";
            this.yLocation.Size = new System.Drawing.Size(45, 25);
            this.yLocation.TabIndex = 14;
            this.yLocation.Text = "10";
            this.yLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLocation
            // 
            this.xLocation.Location = new System.Drawing.Point(503, 24);
            this.xLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xLocation.Name = "xLocation";
            this.xLocation.Size = new System.Drawing.Size(48, 25);
            this.xLocation.TabIndex = 13;
            this.xLocation.Text = "10";
            this.xLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "识别中心位置";
            // 
            // releaseBtn
            // 
            this.releaseBtn.Location = new System.Drawing.Point(803, 146);
            this.releaseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.releaseBtn.Name = "releaseBtn";
            this.releaseBtn.Size = new System.Drawing.Size(56, 29);
            this.releaseBtn.TabIndex = 11;
            this.releaseBtn.Text = "放";
            this.releaseBtn.UseVisualStyleBackColor = true;
            this.releaseBtn.Click += new System.EventHandler(this.releaseBtn_Click);
            // 
            // downBtn
            // 
            this.downBtn.Location = new System.Drawing.Point(729, 110);
            this.downBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(61, 29);
            this.downBtn.TabIndex = 10;
            this.downBtn.Text = "↓";
            this.downBtn.UseVisualStyleBackColor = true;
            this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
            // 
            // leftBtn
            // 
            this.leftBtn.Location = new System.Drawing.Point(659, 61);
            this.leftBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(56, 29);
            this.leftBtn.TabIndex = 9;
            this.leftBtn.Text = "←";
            this.leftBtn.UseVisualStyleBackColor = true;
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // rightBtn
            // 
            this.rightBtn.Location = new System.Drawing.Point(799, 61);
            this.rightBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(60, 29);
            this.rightBtn.TabIndex = 8;
            this.rightBtn.Text = "→";
            this.rightBtn.UseVisualStyleBackColor = true;
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            // 
            // upBtn
            // 
            this.upBtn.Location = new System.Drawing.Point(729, 14);
            this.upBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(61, 29);
            this.upBtn.TabIndex = 7;
            this.upBtn.Text = "↑";
            this.upBtn.UseVisualStyleBackColor = true;
            this.upBtn.Click += new System.EventHandler(this.upBtn_Click);
            // 
            // comTextBox
            // 
            this.comTextBox.Location = new System.Drawing.Point(232, 142);
            this.comTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comTextBox.Name = "comTextBox";
            this.comTextBox.Size = new System.Drawing.Size(79, 25);
            this.comTextBox.TabIndex = 6;
            this.comTextBox.Text = "1";
            this.comTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // baudTextBox
            // 
            this.baudTextBox.Location = new System.Drawing.Point(232, 86);
            this.baudTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.baudTextBox.Name = "baudTextBox";
            this.baudTextBox.Size = new System.Drawing.Size(79, 25);
            this.baudTextBox.TabIndex = 5;
            this.baudTextBox.Text = "9600";
            this.baudTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "波特率";
            // 
            // setSPBtn
            // 
            this.setSPBtn.Location = new System.Drawing.Point(40, 140);
            this.setSPBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.setSPBtn.Name = "setSPBtn";
            this.setSPBtn.Size = new System.Drawing.Size(100, 29);
            this.setSPBtn.TabIndex = 2;
            this.setSPBtn.Text = "修改串口";
            this.setSPBtn.UseVisualStyleBackColor = true;
            // 
            // openSPBtn
            // 
            this.openSPBtn.Location = new System.Drawing.Point(40, 86);
            this.openSPBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openSPBtn.Name = "openSPBtn";
            this.openSPBtn.Size = new System.Drawing.Size(100, 29);
            this.openSPBtn.TabIndex = 1;
            this.openSPBtn.Text = "打开串口";
            this.openSPBtn.UseVisualStyleBackColor = true;
            this.openSPBtn.Click += new System.EventHandler(this.openSPBtn_Click);
            // 
            // openCameraBtn
            // 
            this.openCameraBtn.Location = new System.Drawing.Point(40, 30);
            this.openCameraBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openCameraBtn.Name = "openCameraBtn";
            this.openCameraBtn.Size = new System.Drawing.Size(100, 29);
            this.openCameraBtn.TabIndex = 0;
            this.openCameraBtn.Text = "打开摄像头";
            this.openCameraBtn.UseVisualStyleBackColor = true;
            this.openCameraBtn.Click += new System.EventHandler(this.openCameraBtn_Click);
            // 
            // mySP
            // 
            this.mySP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mySP_DataReceived);
            // 
            // myTimer
            // 
            this.myTimer.Interval = 1000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 582);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.myStatusS);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Robot Vision";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.myStatusS.ResumeLayout(false);
            this.myStatusS.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip myStatusS;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Emgu.CV.UI.ImageBox originImageBox;
        private Emgu.CV.UI.ImageBox processImageBox;
        private System.Windows.Forms.Button openSPBtn;
        private System.Windows.Forms.Button openCameraBtn;
        private System.IO.Ports.SerialPort mySP;
        private System.Windows.Forms.TextBox comTextBox;
        private System.Windows.Forms.TextBox baudTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button releaseBtn;
        private System.Windows.Forms.Button downBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.Button upBtn;
        private System.Windows.Forms.TextBox xLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button autoBtn;
        private System.Windows.Forms.TextBox lineNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox whiteNum;
        private System.Windows.Forms.TextBox yLocation;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel frameNumToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button setSPBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox yGoal;
        private System.Windows.Forms.TextBox xGoal;
        private System.Windows.Forms.Label label4;
    }
}

