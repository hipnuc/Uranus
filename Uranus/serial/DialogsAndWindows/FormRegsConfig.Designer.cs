namespace Uranus.DialogsAndWindows
{
    partial class FormRegsConfig
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
            this.buttonRead = new System.Windows.Forms.Button();
            this.textBoxReadAddr = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxReadSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxWriteAddr = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWriteSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.textBoxWriteAddr.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(199, 70);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(70, 25);
            this.buttonRead.TabIndex = 0;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // textBoxReadAddr
            // 
            this.textBoxReadAddr.Location = new System.Drawing.Point(73, 24);
            this.textBoxReadAddr.Name = "textBoxReadAddr";
            this.textBoxReadAddr.Size = new System.Drawing.Size(43, 25);
            this.textBoxReadAddr.TabIndex = 1;
            this.textBoxReadAddr.Text = "0000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxReadSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonRead);
            this.groupBox1.Controls.Add(this.textBoxReadAddr);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读寄存器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "寄存器个数";
            // 
            // textBoxReadSize
            // 
            this.textBoxReadSize.Location = new System.Drawing.Point(210, 24);
            this.textBoxReadSize.Name = "textBoxReadSize";
            this.textBoxReadSize.Size = new System.Drawing.Size(59, 25);
            this.textBoxReadSize.TabIndex = 3;
            this.textBoxReadSize.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "地址:0x";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("SimSun", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 128);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 264);
            this.listBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxWriteAddr
            // 
            this.textBoxWriteAddr.Controls.Add(this.label5);
            this.textBoxWriteAddr.Controls.Add(this.textBoxData);
            this.textBoxWriteAddr.Controls.Add(this.label3);
            this.textBoxWriteAddr.Controls.Add(this.textBoxWriteSize);
            this.textBoxWriteAddr.Controls.Add(this.label4);
            this.textBoxWriteAddr.Controls.Add(this.buttonWrite);
            this.textBoxWriteAddr.Controls.Add(this.textBox2);
            this.textBoxWriteAddr.Location = new System.Drawing.Point(302, 15);
            this.textBoxWriteAddr.Name = "textBoxWriteAddr";
            this.textBoxWriteAddr.Size = new System.Drawing.Size(460, 98);
            this.textBoxWriteAddr.TabIndex = 5;
            this.textBoxWriteAddr.TabStop = false;
            this.textBoxWriteAddr.Text = "写寄存器";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "数据:0x";
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(342, 24);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(80, 25);
            this.textBoxData.TabIndex = 5;
            this.textBoxData.Text = "00000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "寄存器个数";
            // 
            // textBoxWriteSize
            // 
            this.textBoxWriteSize.Enabled = false;
            this.textBoxWriteSize.Location = new System.Drawing.Point(210, 24);
            this.textBoxWriteSize.Name = "textBoxWriteSize";
            this.textBoxWriteSize.Size = new System.Drawing.Size(59, 25);
            this.textBoxWriteSize.TabIndex = 3;
            this.textBoxWriteSize.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "地址:0x";
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(342, 61);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(80, 25);
            this.buttonWrite.TabIndex = 0;
            this.buttonWrite.Text = "Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(73, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(43, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "0000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(718, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRegsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxWriteAddr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRegsConfig";
            this.Text = "寄存器配置(测试功能,未开放)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.textBoxWriteAddr.ResumeLayout(false);
            this.textBoxWriteAddr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.TextBox textBoxReadAddr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxReadSize;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox textBoxWriteAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWriteSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}