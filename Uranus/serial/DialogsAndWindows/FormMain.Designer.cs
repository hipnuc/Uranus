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
            this.toolStripMenuItemConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenSerialConnectionDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3DView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemGyro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAcc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMag = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEuler = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUpdater = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDataLogger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSerialTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout0 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageIMUUI = new System.Windows.Forms.TabPage();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.购买ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConnection,
            this.toolStripMenuItemGraph,
            this.toolStripMenuItemTools,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(919, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemConnection
            // 
            this.toolStripMenuItemConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSerial});
            this.toolStripMenuItemConnection.Name = "toolStripMenuItemConnection";
            this.toolStripMenuItemConnection.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItemConnection.Text = "连接";
            // 
            // toolStripMenuItemSerial
            // 
            this.toolStripMenuItemSerial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenSerialConnectionDialog});
            this.toolStripMenuItemSerial.Name = "toolStripMenuItemSerial";
            this.toolStripMenuItemSerial.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItemSerial.Text = "串口";
            this.toolStripMenuItemSerial.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItemSerialPort_DropDownItemClicked);
            // 
            // toolStripMenuItemOpenSerialConnectionDialog
            // 
            this.toolStripMenuItemOpenSerialConnectionDialog.Name = "toolStripMenuItemOpenSerialConnectionDialog";
            this.toolStripMenuItemOpenSerialConnectionDialog.Size = new System.Drawing.Size(101, 26);
            this.toolStripMenuItemOpenSerialConnectionDialog.Text = "...";
            // 
            // toolStripMenuItemGraph
            // 
            this.toolStripMenuItemGraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3DView,
            this.toolStripSeparator1,
            this.toolStripMenuItemGyro,
            this.toolStripMenuItemAcc,
            this.toolStripMenuItemMag,
            this.toolStripMenuItemEuler});
            this.toolStripMenuItemGraph.Name = "toolStripMenuItemGraph";
            this.toolStripMenuItemGraph.Size = new System.Drawing.Size(87, 24);
            this.toolStripMenuItemGraph.Text = "图形显示";
            this.toolStripMenuItemGraph.DropDownOpening += new System.EventHandler(this.toolStripMenuItemGraph_DropDownOpening);
            // 
            // toolStripMenuItem3DView
            // 
            this.toolStripMenuItem3DView.CheckOnClick = true;
            this.toolStripMenuItem3DView.Name = "toolStripMenuItem3DView";
            this.toolStripMenuItem3DView.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItem3DView.Text = "3D显示";
            this.toolStripMenuItem3DView.Click += new System.EventHandler(this.toolStripMenuItem3DView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // toolStripMenuItemGyro
            // 
            this.toolStripMenuItemGyro.CheckOnClick = true;
            this.toolStripMenuItemGyro.Name = "toolStripMenuItemGyro";
            this.toolStripMenuItemGyro.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItemGyro.Tag = "Gyroscope";
            this.toolStripMenuItemGyro.Text = "角速度";
            this.toolStripMenuItemGyro.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_CheckStateChanged);
            // 
            // toolStripMenuItemAcc
            // 
            this.toolStripMenuItemAcc.CheckOnClick = true;
            this.toolStripMenuItemAcc.Name = "toolStripMenuItemAcc";
            this.toolStripMenuItemAcc.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItemAcc.Tag = "Accelerometer";
            this.toolStripMenuItemAcc.Text = "加速度";
            this.toolStripMenuItemAcc.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_CheckStateChanged);
            // 
            // toolStripMenuItemMag
            // 
            this.toolStripMenuItemMag.CheckOnClick = true;
            this.toolStripMenuItemMag.Name = "toolStripMenuItemMag";
            this.toolStripMenuItemMag.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItemMag.Tag = "Magnetometer";
            this.toolStripMenuItemMag.Text = "磁场";
            this.toolStripMenuItemMag.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_CheckStateChanged);
            // 
            // toolStripMenuItemEuler
            // 
            this.toolStripMenuItemEuler.CheckOnClick = true;
            this.toolStripMenuItemEuler.Name = "toolStripMenuItemEuler";
            this.toolStripMenuItemEuler.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItemEuler.Tag = "Euler Angles";
            this.toolStripMenuItemEuler.Text = "欧拉角";
            this.toolStripMenuItemEuler.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_CheckStateChanged);
            // 
            // toolStripMenuItemTools
            // 
            this.toolStripMenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConfig,
            this.toolStripMenuItemUpdater,
            this.toolStripMenuItemDataLogger,
            this.toolStripMenuItemSerialTerminal});
            this.toolStripMenuItemTools.Name = "toolStripMenuItemTools";
            this.toolStripMenuItemTools.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItemTools.Text = "工具";
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            this.toolStripMenuItemConfig.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemConfig.Text = "配置模块";
            this.toolStripMenuItemConfig.Click += new System.EventHandler(this.toolStripMenuItemConfig_Click);
            // 
            // toolStripMenuItemUpdater
            // 
            this.toolStripMenuItemUpdater.Name = "toolStripMenuItemUpdater";
            this.toolStripMenuItemUpdater.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemUpdater.Text = "固件升级";
            this.toolStripMenuItemUpdater.Click += new System.EventHandler(this.toolStripMenuItemUpdater_Click);
            // 
            // toolStripMenuItemDataLogger
            // 
            this.toolStripMenuItemDataLogger.Name = "toolStripMenuItemDataLogger";
            this.toolStripMenuItemDataLogger.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemDataLogger.Text = "数据记录";
            this.toolStripMenuItemDataLogger.Click += new System.EventHandler(this.toolStripMenuItemDataLogger_Click);
            // 
            // toolStripMenuItemSerialTerminal
            // 
            this.toolStripMenuItemSerialTerminal.Name = "toolStripMenuItemSerialTerminal";
            this.toolStripMenuItemSerialTerminal.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemSerialTerminal.Text = "串口助手";
            this.toolStripMenuItemSerialTerminal.Click += new System.EventHandler(this.toolStripMenuItemSerialTerminal_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout0,
            this.toolStripMenuItemGuide,
            this.购买ToolStripMenuItem});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItemHelp.Text = "帮助";
            // 
            // toolStripMenuItemAbout0
            // 
            this.toolStripMenuItemAbout0.Name = "toolStripMenuItemAbout0";
            this.toolStripMenuItemAbout0.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemAbout0.Text = "版本";
            this.toolStripMenuItemAbout0.Click += new System.EventHandler(this.toolStripMenuItemAbout0_Click);
            // 
            // toolStripMenuItemGuide
            // 
            this.toolStripMenuItemGuide.Name = "toolStripMenuItemGuide";
            this.toolStripMenuItemGuide.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemGuide.Text = "关于我们";
            this.toolStripMenuItemGuide.Click += new System.EventHandler(this.toolStripMenuItemGuide_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageIMUUI);
            this.tabControl1.Controls.Add(this.tabPageMessage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 537);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.TabStop = false;
            // 
            // TabPageIMUUI
            // 
            this.TabPageIMUUI.Location = new System.Drawing.Point(4, 25);
            this.TabPageIMUUI.Margin = new System.Windows.Forms.Padding(4);
            this.TabPageIMUUI.Name = "TabPageIMUUI";
            this.TabPageIMUUI.Size = new System.Drawing.Size(911, 508);
            this.TabPageIMUUI.TabIndex = 3;
            this.TabPageIMUUI.Text = "姿态显示";
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.Location = new System.Drawing.Point(4, 25);
            this.tabPageMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Size = new System.Drawing.Size(911, 508);
            this.tabPageMessage.TabIndex = 4;
            this.tabPageMessage.Text = "消息";
            // 
            // 购买ToolStripMenuItem
            // 
            this.购买ToolStripMenuItem.Name = "购买ToolStripMenuItem";
            this.购买ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.购买ToolStripMenuItem.Text = "购买";
            this.购买ToolStripMenuItem.Click += new System.EventHandler(this.购买ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(919, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout0;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGuide;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageIMUUI;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTools;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSerialTerminal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdater;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDataLogger;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGraph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGyro;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3DView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAcc;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMag;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEuler;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSerial;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenSerialConnectionDialog;
        private System.Windows.Forms.ToolStripMenuItem 购买ToolStripMenuItem;
    }
}

