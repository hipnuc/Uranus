namespace Uranus
{
    partial class FormIMU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRawData = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.airSpeedIndicatorInstrumentControl1 = new AvionicsInstrumentControlDemo.AirSpeedIndicatorInstrumentControl();
            this.attitudeIndicatorInstrumentControl1 = new AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl();
            this.altimeterInstrumentControl1 = new AvionicsInstrumentControlDemo.AltimeterInstrumentControl();
            this.headingIndicatorInstrumentControl1 = new AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGyroscope = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLogToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStopLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3D = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAccelerometer = new System.Windows.Forms.ToolStripMenuItem();
            this.磁场ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRawData);
            this.groupBox1.Location = new System.Drawing.Point(5, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 333);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IMU数据";
            // 
            // labelRawData
            // 
            this.labelRawData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRawData.Location = new System.Drawing.Point(6, 16);
            this.labelRawData.Name = "labelRawData";
            this.labelRawData.Size = new System.Drawing.Size(289, 311);
            this.labelRawData.TabIndex = 6;
            this.labelRawData.Text = "未接收到数据 或串口未连接";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.airSpeedIndicatorInstrumentControl1);
            this.groupBox2.Controls.Add(this.attitudeIndicatorInstrumentControl1);
            this.groupBox2.Controls.Add(this.altimeterInstrumentControl1);
            this.groupBox2.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.groupBox2.Location = new System.Drawing.Point(312, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 332);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "仪表";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "接收速率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "压高";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "姿态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "航向";
            // 
            // airSpeedIndicatorInstrumentControl1
            // 
            this.airSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(166, 191);
            this.airSpeedIndicatorInstrumentControl1.Name = "airSpeedIndicatorInstrumentControl1";
            this.airSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(125, 135);
            this.airSpeedIndicatorInstrumentControl1.TabIndex = 5;
            this.airSpeedIndicatorInstrumentControl1.Text = "airSpeedIndicatorInstrumentControl1";
            // 
            // attitudeIndicatorInstrumentControl1
            // 
            this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(165, 37);
            this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(125, 132);
            this.attitudeIndicatorInstrumentControl1.TabIndex = 3;
            this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
            // 
            // altimeterInstrumentControl1
            // 
            this.altimeterInstrumentControl1.Location = new System.Drawing.Point(6, 191);
            this.altimeterInstrumentControl1.Name = "altimeterInstrumentControl1";
            this.altimeterInstrumentControl1.Size = new System.Drawing.Size(125, 125);
            this.altimeterInstrumentControl1.TabIndex = 4;
            this.altimeterInstrumentControl1.Text = "altimeterInstrumentControl1";
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(6, 38);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(125, 135);
            this.headingIndicatorInstrumentControl1.TabIndex = 2;
            this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGraph,
            this.toolStripMenuItemLogToFile,
            this.toolStripMenuItem3D,
            this.toolStripMenuItemConfig,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemGraph
            // 
            this.toolStripMenuItemGraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGyroscope,
            this.toolStripMenuItemAccelerometer,
            this.磁场ToolStripMenuItem});
            this.toolStripMenuItemGraph.Name = "toolStripMenuItemGraph";
            this.toolStripMenuItemGraph.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItemGraph.Text = "波形";
            this.toolStripMenuItemGraph.Click += new System.EventHandler(this.toolStripMenuItemOsciloscope_Click);
            // 
            // toolStripMenuItemGyroscope
            // 
            this.toolStripMenuItemGyroscope.CheckOnClick = true;
            this.toolStripMenuItemGyroscope.Name = "toolStripMenuItemGyroscope";
            this.toolStripMenuItemGyroscope.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemGyroscope.Tag = "Gyroscope";
            this.toolStripMenuItemGyroscope.Text = "角速度";
            this.toolStripMenuItemGyroscope.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemOscilloscope_CheckStateChanged);
            // 
            // toolStripMenuItemLogToFile
            // 
            this.toolStripMenuItemLogToFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStartLogging,
            this.toolStripMenuItemStopLogging});
            this.toolStripMenuItemLogToFile.Name = "toolStripMenuItemLogToFile";
            this.toolStripMenuItemLogToFile.Size = new System.Drawing.Size(69, 20);
            this.toolStripMenuItemLogToFile.Text = "生成excel";
            // 
            // toolStripMenuItemStartLogging
            // 
            this.toolStripMenuItemStartLogging.Name = "toolStripMenuItemStartLogging";
            this.toolStripMenuItemStartLogging.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItemStartLogging.Text = "开始记录";
            this.toolStripMenuItemStartLogging.Click += new System.EventHandler(this.toolStripMenuItemStartLogging_Click);
            // 
            // toolStripMenuItemStopLogging
            // 
            this.toolStripMenuItemStopLogging.Enabled = false;
            this.toolStripMenuItemStopLogging.Name = "toolStripMenuItemStopLogging";
            this.toolStripMenuItemStopLogging.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItemStopLogging.Text = "停止记录";
            this.toolStripMenuItemStopLogging.Click += new System.EventHandler(this.toolStripMenuItemStopLogging_Click);
            // 
            // toolStripMenuItem3D
            // 
            this.toolStripMenuItem3D.Name = "toolStripMenuItem3D";
            this.toolStripMenuItem3D.Size = new System.Drawing.Size(57, 20);
            this.toolStripMenuItem3D.Text = "3D显示";
            this.toolStripMenuItem3D.Click += new System.EventHandler(this.toolStripMenuItem3D_Click);
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            this.toolStripMenuItemConfig.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemConfig.Text = "配置模块";
            this.toolStripMenuItemConfig.Click += new System.EventHandler(this.toolStripMenuItemConfig_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = " ";
            // 
            // toolStripMenuItemAccelerometer
            // 
            this.toolStripMenuItemAccelerometer.CheckOnClick = true;
            this.toolStripMenuItemAccelerometer.Name = "toolStripMenuItemAccelerometer";
            this.toolStripMenuItemAccelerometer.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAccelerometer.Tag = "Accelerometer";
            this.toolStripMenuItemAccelerometer.Text = "加速度";
            this.toolStripMenuItemAccelerometer.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemOscilloscope_CheckStateChanged);
            // 
            // 磁场ToolStripMenuItem
            // 
            this.磁场ToolStripMenuItem.CheckOnClick = true;
            this.磁场ToolStripMenuItem.Name = "磁场ToolStripMenuItem";
            this.磁场ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.磁场ToolStripMenuItem.Tag = "Magnetometer";
            this.磁场ToolStripMenuItem.Text = "磁场";
            this.磁场ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemOscilloscope_CheckStateChanged);
            // 
            // FormIMU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormIMU";
            this.Text = "IMU";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormIMU_FormClosed);
            this.Load += new System.EventHandler(this.FormIMU_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRawData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private AvionicsInstrumentControlDemo.AirSpeedIndicatorInstrumentControl airSpeedIndicatorInstrumentControl1;
        private AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
        private AvionicsInstrumentControlDemo.AltimeterInstrumentControl altimeterInstrumentControl1;
        private AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGraph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLogToFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartLogging;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStopLogging;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3D;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGyroscope;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAccelerometer;
        private System.Windows.Forms.ToolStripMenuItem 磁场ToolStripMenuItem;


    }
}