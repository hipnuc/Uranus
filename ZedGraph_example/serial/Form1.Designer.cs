namespace serial
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.波特率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复默认状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.x时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.示例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zedGraphControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zedGraphControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zedGraphControl1.IsShowContextMenu = false;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 28);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1141, 596);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.打开串口ToolStripMenuItem,
            this.关闭串口ToolStripMenuItem,
            this.开始绘图ToolStripMenuItem,
            this.停止绘图ToolStripMenuItem,
            this.恢复默认状态ToolStripMenuItem,
            this.toolStripTextBox1,
            this.x时间ToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.示例ToolStripMenuItem,
            this.当前值ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1165, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口ToolStripMenuItem,
            this.波特率ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 串口ToolStripMenuItem
            // 
            this.串口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOM1ToolStripMenuItem,
            this.cOM2ToolStripMenuItem,
            this.cOM3ToolStripMenuItem,
            this.cOM4ToolStripMenuItem,
            this.cOM6ToolStripMenuItem,
            this.cOM7ToolStripMenuItem,
            this.cOM8ToolStripMenuItem,
            this.cOM9ToolStripMenuItem,
            this.cOM10ToolStripMenuItem,
            this.cOM5ToolStripMenuItem,
            this.cOM13ToolStripMenuItem,
            this.cOM14ToolStripMenuItem});
            this.串口ToolStripMenuItem.Name = "串口ToolStripMenuItem";
            this.串口ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.串口ToolStripMenuItem.Text = "串口";
            // 
            // cOM1ToolStripMenuItem
            // 
            this.cOM1ToolStripMenuItem.Checked = true;
            this.cOM1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cOM1ToolStripMenuItem.Name = "cOM1ToolStripMenuItem";
            this.cOM1ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM1ToolStripMenuItem.Text = "COM1";
            this.cOM1ToolStripMenuItem.Click += new System.EventHandler(this.cOM1ToolStripMenuItem_Click);
            // 
            // cOM2ToolStripMenuItem
            // 
            this.cOM2ToolStripMenuItem.Name = "cOM2ToolStripMenuItem";
            this.cOM2ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM2ToolStripMenuItem.Text = "COM2";
            this.cOM2ToolStripMenuItem.Click += new System.EventHandler(this.cOM2ToolStripMenuItem_Click);
            // 
            // cOM3ToolStripMenuItem
            // 
            this.cOM3ToolStripMenuItem.Name = "cOM3ToolStripMenuItem";
            this.cOM3ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM3ToolStripMenuItem.Text = "COM3";
            this.cOM3ToolStripMenuItem.Click += new System.EventHandler(this.cOM3ToolStripMenuItem_Click);
            // 
            // cOM4ToolStripMenuItem
            // 
            this.cOM4ToolStripMenuItem.Name = "cOM4ToolStripMenuItem";
            this.cOM4ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM4ToolStripMenuItem.Text = "COM4";
            this.cOM4ToolStripMenuItem.Click += new System.EventHandler(this.cOM4ToolStripMenuItem_Click);
            // 
            // cOM6ToolStripMenuItem
            // 
            this.cOM6ToolStripMenuItem.Name = "cOM6ToolStripMenuItem";
            this.cOM6ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM6ToolStripMenuItem.Text = "COM6";
            this.cOM6ToolStripMenuItem.Click += new System.EventHandler(this.cOM6ToolStripMenuItem_Click);
            // 
            // cOM7ToolStripMenuItem
            // 
            this.cOM7ToolStripMenuItem.Name = "cOM7ToolStripMenuItem";
            this.cOM7ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM7ToolStripMenuItem.Text = "COM7";
            this.cOM7ToolStripMenuItem.Click += new System.EventHandler(this.cOM7ToolStripMenuItem_Click);
            // 
            // cOM8ToolStripMenuItem
            // 
            this.cOM8ToolStripMenuItem.Name = "cOM8ToolStripMenuItem";
            this.cOM8ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM8ToolStripMenuItem.Text = "COM8";
            this.cOM8ToolStripMenuItem.Click += new System.EventHandler(this.cOM8ToolStripMenuItem_Click);
            // 
            // cOM9ToolStripMenuItem
            // 
            this.cOM9ToolStripMenuItem.Name = "cOM9ToolStripMenuItem";
            this.cOM9ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM9ToolStripMenuItem.Text = "COM9";
            this.cOM9ToolStripMenuItem.Click += new System.EventHandler(this.cOM9ToolStripMenuItem_Click);
            // 
            // cOM10ToolStripMenuItem
            // 
            this.cOM10ToolStripMenuItem.Name = "cOM10ToolStripMenuItem";
            this.cOM10ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM10ToolStripMenuItem.Text = "COM10";
            this.cOM10ToolStripMenuItem.Click += new System.EventHandler(this.cOM10ToolStripMenuItem_Click);
            // 
            // cOM5ToolStripMenuItem
            // 
            this.cOM5ToolStripMenuItem.Name = "cOM5ToolStripMenuItem";
            this.cOM5ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM5ToolStripMenuItem.Text = "COM5";
            this.cOM5ToolStripMenuItem.Click += new System.EventHandler(this.cOM5ToolStripMenuItem_Click);
            // 
            // cOM13ToolStripMenuItem
            // 
            this.cOM13ToolStripMenuItem.Name = "cOM13ToolStripMenuItem";
            this.cOM13ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM13ToolStripMenuItem.Text = "COM13";
            this.cOM13ToolStripMenuItem.Click += new System.EventHandler(this.cOM13ToolStripMenuItem_Click);
            // 
            // cOM14ToolStripMenuItem
            // 
            this.cOM14ToolStripMenuItem.Name = "cOM14ToolStripMenuItem";
            this.cOM14ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cOM14ToolStripMenuItem.Text = "COM14";
            this.cOM14ToolStripMenuItem.Click += new System.EventHandler(this.cOM14ToolStripMenuItem_Click);
            // 
            // 波特率ToolStripMenuItem
            // 
            this.波特率ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.波特率ToolStripMenuItem.Name = "波特率ToolStripMenuItem";
            this.波特率ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.波特率ToolStripMenuItem.Text = "波特率";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem2.Text = "19200";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Checked = true;
            this.toolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem3.Text = "9600";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem4.Text = "4800";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem5.Text = "2400";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem6.Text = "115200";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // 打开串口ToolStripMenuItem
            // 
            this.打开串口ToolStripMenuItem.Name = "打开串口ToolStripMenuItem";
            this.打开串口ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.打开串口ToolStripMenuItem.Text = "打开串口";
            this.打开串口ToolStripMenuItem.Click += new System.EventHandler(this.打开串口ToolStripMenuItem_Click);
            // 
            // 关闭串口ToolStripMenuItem
            // 
            this.关闭串口ToolStripMenuItem.Name = "关闭串口ToolStripMenuItem";
            this.关闭串口ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.关闭串口ToolStripMenuItem.Text = "关闭串口";
            this.关闭串口ToolStripMenuItem.Click += new System.EventHandler(this.关闭串口ToolStripMenuItem_Click);
            // 
            // 开始绘图ToolStripMenuItem
            // 
            this.开始绘图ToolStripMenuItem.Name = "开始绘图ToolStripMenuItem";
            this.开始绘图ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.开始绘图ToolStripMenuItem.Text = "开始绘图";
            this.开始绘图ToolStripMenuItem.Click += new System.EventHandler(this.开始绘图ToolStripMenuItem_Click);
            // 
            // 停止绘图ToolStripMenuItem
            // 
            this.停止绘图ToolStripMenuItem.Name = "停止绘图ToolStripMenuItem";
            this.停止绘图ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.停止绘图ToolStripMenuItem.Text = "停止绘图";
            this.停止绘图ToolStripMenuItem.Click += new System.EventHandler(this.停止绘图ToolStripMenuItem_Click);
            // 
            // 恢复默认状态ToolStripMenuItem
            // 
            this.恢复默认状态ToolStripMenuItem.Name = "恢复默认状态ToolStripMenuItem";
            this.恢复默认状态ToolStripMenuItem.Size = new System.Drawing.Size(92, 23);
            this.恢复默认状态ToolStripMenuItem.Text = "恢复默认状态";
            this.恢复默认状态ToolStripMenuItem.Click += new System.EventHandler(this.恢复默认状态ToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(35, 23);
            this.toolStripTextBox1.Text = "120";
            // 
            // x时间ToolStripMenuItem
            // 
            this.x时间ToolStripMenuItem.Name = "x时间ToolStripMenuItem";
            this.x时间ToolStripMenuItem.Size = new System.Drawing.Size(79, 23);
            this.x时间ToolStripMenuItem.Text = "←X时间(S)";
            this.x时间ToolStripMenuItem.Click += new System.EventHandler(this.x时间ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.aboutToolStripMenuItem.Text = "如何使用";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // 示例ToolStripMenuItem
            // 
            this.示例ToolStripMenuItem.Name = "示例ToolStripMenuItem";
            this.示例ToolStripMenuItem.Size = new System.Drawing.Size(104, 23);
            this.示例ToolStripMenuItem.Text = "示例（正弦波）";
            this.示例ToolStripMenuItem.Click += new System.EventHandler(this.示例ToolStripMenuItem_Click);
            // 
            // 当前值ToolStripMenuItem
            // 
            this.当前值ToolStripMenuItem.Name = "当前值ToolStripMenuItem";
            this.当前值ToolStripMenuItem.Size = new System.Drawing.Size(64, 23);
            this.当前值ToolStripMenuItem.Text = "ADC1：";
            this.当前值ToolStripMenuItem.Click += new System.EventHandler(this.当前值ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 23);
            this.toolStripMenuItem1.Text = "ADC2：";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(64, 23);
            this.toolStripMenuItem7.Text = "ADC3：";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(64, 23);
            this.toolStripMenuItem8.Text = "ADC4：";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // serialPort1
            // 
            this.serialPort1.ReceivedBytesThreshold = 3;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 631);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SERIAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 波特率ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripMenuItem 打开串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始绘图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止绘图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem x时间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 恢复默认状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 示例ToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem 当前值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem cOM6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM13ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM14ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;

    }
}

