namespace Uranus.DialogsAndWindows
{
    partial class FormFrimwareUpdater
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_UseReset = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox_ExecAfterDownload = new System.Windows.Forms.CheckBox();
            this.checkBox_UseAppReset = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxStartAddr = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem1.Text = "Clear";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_UseReset);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox_ExecAfterDownload);
            this.groupBox2.Controls.Add(this.checkBox_UseAppReset);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 64);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高级选项";
            // 
            // checkBox_UseReset
            // 
            this.checkBox_UseReset.AutoSize = true;
            this.checkBox_UseReset.Checked = true;
            this.checkBox_UseReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_UseReset.Location = new System.Drawing.Point(132, 20);
            this.checkBox_UseReset.Name = "checkBox_UseReset";
            this.checkBox_UseReset.Size = new System.Drawing.Size(84, 16);
            this.checkBox_UseReset.TabIndex = 1;
            this.checkBox_UseReset.Text = "编程后复位";
            this.checkBox_UseReset.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(132, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "编程后校验";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox_ExecAfterDownload
            // 
            this.checkBox_ExecAfterDownload.AutoSize = true;
            this.checkBox_ExecAfterDownload.Checked = true;
            this.checkBox_ExecAfterDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ExecAfterDownload.Location = new System.Drawing.Point(6, 42);
            this.checkBox_ExecAfterDownload.Name = "checkBox_ExecAfterDownload";
            this.checkBox_ExecAfterDownload.Size = new System.Drawing.Size(84, 16);
            this.checkBox_ExecAfterDownload.TabIndex = 6;
            this.checkBox_ExecAfterDownload.Text = "编程后执行";
            this.checkBox_ExecAfterDownload.UseVisualStyleBackColor = true;
            // 
            // checkBox_UseAppReset
            // 
            this.checkBox_UseAppReset.AutoSize = true;
            this.checkBox_UseAppReset.Checked = true;
            this.checkBox_UseAppReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_UseAppReset.Location = new System.Drawing.Point(6, 20);
            this.checkBox_UseAppReset.Name = "checkBox_UseAppReset";
            this.checkBox_UseAppReset.Size = new System.Drawing.Size(84, 16);
            this.checkBox_UseAppReset.TabIndex = 5;
            this.checkBox_UseAppReset.Text = "连接前复位";
            this.checkBox_UseAppReset.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "复位";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxLog);
            this.groupBox1.Location = new System.Drawing.Point(265, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 125);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息";
            // 
            // listBoxLog
            // 
            this.listBoxLog.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Items.AddRange(new object[] {
            "建议使用超核专用USB转串口测试版来进行固件升级",
            "升级时，上位机 下位机必须切换回115200波特率"});
            this.listBoxLog.Location = new System.Drawing.Point(3, 17);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(280, 105);
            this.listBoxLog.TabIndex = 0;
            this.listBoxLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxLog_MouseUp);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxStartAddr);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.buttonConnect);
            this.groupBox5.Controls.Add(this.buttonSelectFile);
            this.groupBox5.Location = new System.Drawing.Point(12, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(247, 77);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "设置";
            // 
            // textBoxStartAddr
            // 
            this.textBoxStartAddr.Location = new System.Drawing.Point(141, 50);
            this.textBoxStartAddr.Name = "textBoxStartAddr";
            this.textBoxStartAddr.Size = new System.Drawing.Size(67, 21);
            this.textBoxStartAddr.TabIndex = 1;
            this.textBoxStartAddr.Text = "0x00000000";
            this.textBoxStartAddr.Visible = false;
            this.textBoxStartAddr.TextChanged += new System.EventHandler(this.textBoxStartAddr_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始地址";
            this.label2.Visible = false;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 47);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(70, 25);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSelectFile.Location = new System.Drawing.Point(210, 16);
            this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(34, 21);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "...";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonUpdate);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(12, 90);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 47);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "下载";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(6, 16);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(70, 25);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "开始编程";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 139);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(539, 6);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // FormFrimwareUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 152);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFrimwareUpdater";
            this.Text = "固件升级";
            this.Load += new System.EventHandler(this.FormBootloader_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxStartAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.CheckBox checkBox_UseAppReset;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_ExecAfterDownload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox_UseReset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
    }
}