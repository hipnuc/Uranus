namespace Uranus
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemSerialPort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBaudRate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9600 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38400 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem57600 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem115200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem230400 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem460800 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem921600 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOther = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout0 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageIMU = new System.Windows.Forms.TabPage();
            this.tabPageTerminal = new System.Windows.Forms.TabPage();
            this.tabPageKboot = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSerialPort,
            this.toolStripMenuItemBaudRate,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(629, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemSerialPort
            // 
            this.toolStripMenuItemSerialPort.Name = "toolStripMenuItemSerialPort";
            this.toolStripMenuItemSerialPort.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItemSerialPort.Text = "串口";
            this.toolStripMenuItemSerialPort.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItemSerialPort_DropDownItemClicked);
            // 
            // toolStripMenuItemBaudRate
            // 
            this.toolStripMenuItemBaudRate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9600,
            this.toolStripMenuItem19200,
            this.toolStripMenuItem38400,
            this.toolStripMenuItem57600,
            this.toolStripMenuItem115200,
            this.toolStripMenuItem230400,
            this.toolStripMenuItem460800,
            this.toolStripMenuItem921600,
            this.toolStripMenuItemOther});
            this.toolStripMenuItemBaudRate.Name = "toolStripMenuItemBaudRate";
            this.toolStripMenuItemBaudRate.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItemBaudRate.Text = "波特率";
            this.toolStripMenuItemBaudRate.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItemBaudRate_DropDownItemClicked);
            // 
            // toolStripMenuItem9600
            // 
            this.toolStripMenuItem9600.Name = "toolStripMenuItem9600";
            this.toolStripMenuItem9600.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem9600.Text = "9600";
            // 
            // toolStripMenuItem19200
            // 
            this.toolStripMenuItem19200.Name = "toolStripMenuItem19200";
            this.toolStripMenuItem19200.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem19200.Text = "19200";
            // 
            // toolStripMenuItem38400
            // 
            this.toolStripMenuItem38400.Name = "toolStripMenuItem38400";
            this.toolStripMenuItem38400.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem38400.Text = "38400";
            // 
            // toolStripMenuItem57600
            // 
            this.toolStripMenuItem57600.Name = "toolStripMenuItem57600";
            this.toolStripMenuItem57600.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem57600.Text = "57600";
            // 
            // toolStripMenuItem115200
            // 
            this.toolStripMenuItem115200.Name = "toolStripMenuItem115200";
            this.toolStripMenuItem115200.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem115200.Text = "115200";
            // 
            // toolStripMenuItem230400
            // 
            this.toolStripMenuItem230400.Name = "toolStripMenuItem230400";
            this.toolStripMenuItem230400.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem230400.Text = "230400";
            // 
            // toolStripMenuItem460800
            // 
            this.toolStripMenuItem460800.Name = "toolStripMenuItem460800";
            this.toolStripMenuItem460800.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem460800.Text = "460800";
            // 
            // toolStripMenuItem921600
            // 
            this.toolStripMenuItem921600.Name = "toolStripMenuItem921600";
            this.toolStripMenuItem921600.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem921600.Text = "921600";
            // 
            // toolStripMenuItemOther
            // 
            this.toolStripMenuItemOther.Name = "toolStripMenuItemOther";
            this.toolStripMenuItemOther.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItemOther.Text = "Other";
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout0,
            this.toolStripMenuItemGuide,
            this.toolStripMenuItemUpgrade});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItemHelp.Text = "帮助";
            this.toolStripMenuItemHelp.Visible = false;
            // 
            // toolStripMenuItemAbout0
            // 
            this.toolStripMenuItemAbout0.Name = "toolStripMenuItemAbout0";
            this.toolStripMenuItemAbout0.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAbout0.Text = "版本";
            this.toolStripMenuItemAbout0.Click += new System.EventHandler(this.toolStripMenuItemAbout0_Click);
            // 
            // toolStripMenuItemGuide
            // 
            this.toolStripMenuItemGuide.Name = "toolStripMenuItemGuide";
            this.toolStripMenuItemGuide.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemGuide.Text = "关于我们";
            this.toolStripMenuItemGuide.Click += new System.EventHandler(this.toolStripMenuItemGuide_Click);
            // 
            // toolStripMenuItemUpgrade
            // 
            this.toolStripMenuItemUpgrade.Name = "toolStripMenuItemUpgrade";
            this.toolStripMenuItemUpgrade.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemUpgrade.Text = "软件升级";
            this.toolStripMenuItemUpgrade.Click += new System.EventHandler(this.toolStripMenuItemUpgrade_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageIMU);
            this.tabControl1.Controls.Add(this.tabPageTerminal);
            this.tabControl1.Controls.Add(this.tabPageKboot);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 423);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.TabStop = false;
            // 
            // TabPageIMU
            // 
            this.TabPageIMU.Location = new System.Drawing.Point(4, 22);
            this.TabPageIMU.Name = "TabPageIMU";
            this.TabPageIMU.Size = new System.Drawing.Size(621, 397);
            this.TabPageIMU.TabIndex = 3;
            this.TabPageIMU.Text = "姿态模块";
            this.TabPageIMU.UseVisualStyleBackColor = true;
            // 
            // tabPageTerminal
            // 
            this.tabPageTerminal.Location = new System.Drawing.Point(4, 22);
            this.tabPageTerminal.Name = "tabPageTerminal";
            this.tabPageTerminal.Size = new System.Drawing.Size(621, 397);
            this.tabPageTerminal.TabIndex = 4;
            this.tabPageTerminal.Text = "终端";
            this.tabPageTerminal.UseVisualStyleBackColor = true;
            // 
            // tabPageKboot
            // 
            this.tabPageKboot.Location = new System.Drawing.Point(4, 22);
            this.tabPageKboot.Name = "tabPageKboot";
            this.tabPageKboot.Size = new System.Drawing.Size(621, 397);
            this.tabPageKboot.TabIndex = 5;
            this.tabPageKboot.Text = "固件升级";
            this.tabPageKboot.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(629, 447);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSerialPort;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBaudRate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9600;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem38400;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem57600;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem115200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem230400;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem460800;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem921600;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOther;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout0;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGuide;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpgrade;
        private System.Windows.Forms.TabPage tabPageTerminal;
        private System.Windows.Forms.TabPage tabPageKboot;
        private System.Windows.Forms.TabPage TabPageIMU;

    }
}

