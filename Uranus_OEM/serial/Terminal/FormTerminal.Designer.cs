namespace Uranus
{
    partial class FormTerminal
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSamplesReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSampleRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStopLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSamplesReceived,
            this.toolStripStatusLabelSampleRate});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 266);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSamplesReceived
            // 
            this.toolStripStatusLabelSamplesReceived.Name = "toolStripStatusLabelSamplesReceived";
            this.toolStripStatusLabelSamplesReceived.Size = new System.Drawing.Size(225, 17);
            this.toolStripStatusLabelSamplesReceived.Text = "toolStripStatusLabelSamplesReceived";
            // 
            // toolStripStatusLabelSampleRate
            // 
            this.toolStripStatusLabelSampleRate.Name = "toolStripStatusLabelSampleRate";
            this.toolStripStatusLabelSampleRate.Size = new System.Drawing.Size(193, 17);
            this.toolStripStatusLabelSampleRate.Text = "toolStripStatusLabelSampleRate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Controls.Add(this.menuStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 266);
            this.panel1.TabIndex = 5;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.Black;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox.Location = new System.Drawing.Point(0, 25);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(584, 241);
            this.textBox.TabIndex = 6;
            this.textBox.Tag = " n";
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            this.textBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseUp);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTerminal,
            this.toolStripMenuItemClear});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(584, 25);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemTerminal
            // 
            this.toolStripMenuItemTerminal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnabled});
            this.toolStripMenuItemTerminal.Name = "toolStripMenuItemTerminal";
            this.toolStripMenuItemTerminal.Size = new System.Drawing.Size(59, 21);
            this.toolStripMenuItemTerminal.Text = "终端(&T)";
            // 
            // toolStripMenuItemEnabled
            // 
            this.toolStripMenuItemEnabled.Checked = true;
            this.toolStripMenuItemEnabled.CheckOnClick = true;
            this.toolStripMenuItemEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemEnabled.Name = "toolStripMenuItemEnabled";
            this.toolStripMenuItemEnabled.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItemEnabled.Text = "使能(&E)";
            this.toolStripMenuItemEnabled.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemEnabled_CheckStateChanged);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItemClear.Text = "清除";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // toolStripMenuItemStartLogging
            // 
            this.toolStripMenuItemStartLogging.Name = "toolStripMenuItemStartLogging";
            this.toolStripMenuItemStartLogging.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemStartLogging.Text = "开始记录";
            // 
            // toolStripMenuItemStopLogging
            // 
            this.toolStripMenuItemStopLogging.Enabled = false;
            this.toolStripMenuItemStopLogging.Name = "toolStripMenuItemStopLogging";
            this.toolStripMenuItemStopLogging.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemStopLogging.Text = "停止记录";
            // 
            // FormTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 288);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTerminal";
            this.Load += new System.EventHandler(this.FormTerminal_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSamplesReceived;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSampleRate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartLogging;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStopLogging;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTerminal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnabled;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}