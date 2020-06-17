namespace Uranus.DialogsAndWindows
{
    partial class FormIMUConfig
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMode9A = new System.Windows.Forms.RadioButton();
            this.radioButtonMode6A = new System.Windows.Forms.RadioButton();
            this.buttonRST = new System.Windows.Forms.Button();
            this.textBoxTerminal = new System.Windows.Forms.TextBox();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonINFO = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox0x91 = new System.Windows.Forms.CheckBox();
            this.checkBoxAtdQ = new System.Windows.Forms.CheckBox();
            this.checkBoxPressure = new System.Windows.Forms.CheckBox();
            this.checkBoxID = new System.Windows.Forms.CheckBox();
            this.checkBoxAtdE = new System.Windows.Forms.CheckBox();
            this.buttonProtocol = new System.Windows.Forms.Button();
            this.checkBoxMag = new System.Windows.Forms.CheckBox();
            this.checkBoxGyo = new System.Windows.Forms.CheckBox();
            this.checkBoxAcc = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(731, 535);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(145, 30);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "退出配置模式";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMode9A);
            this.groupBox1.Controls.Add(this.radioButtonMode6A);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(172, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式";
            // 
            // radioButtonMode9A
            // 
            this.radioButtonMode9A.AutoSize = true;
            this.radioButtonMode9A.Location = new System.Drawing.Point(8, 53);
            this.radioButtonMode9A.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonMode9A.Name = "radioButtonMode9A";
            this.radioButtonMode9A.Size = new System.Drawing.Size(81, 19);
            this.radioButtonMode9A.TabIndex = 2;
            this.radioButtonMode9A.Text = "9轴模式";
            this.radioButtonMode9A.UseVisualStyleBackColor = true;
            this.radioButtonMode9A.Click += new System.EventHandler(this.radioButtonMode_Click);
            // 
            // radioButtonMode6A
            // 
            this.radioButtonMode6A.AutoSize = true;
            this.radioButtonMode6A.Checked = true;
            this.radioButtonMode6A.Location = new System.Drawing.Point(8, 25);
            this.radioButtonMode6A.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonMode6A.Name = "radioButtonMode6A";
            this.radioButtonMode6A.Size = new System.Drawing.Size(81, 19);
            this.radioButtonMode6A.TabIndex = 2;
            this.radioButtonMode6A.TabStop = true;
            this.radioButtonMode6A.Text = "6轴模式";
            this.radioButtonMode6A.UseVisualStyleBackColor = true;
            this.radioButtonMode6A.Click += new System.EventHandler(this.radioButtonMode_Click);
            // 
            // buttonRST
            // 
            this.buttonRST.Location = new System.Drawing.Point(8, 57);
            this.buttonRST.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRST.Name = "buttonRST";
            this.buttonRST.Size = new System.Drawing.Size(133, 29);
            this.buttonRST.TabIndex = 2;
            this.buttonRST.Text = "复位";
            this.buttonRST.UseVisualStyleBackColor = true;
            this.buttonRST.Click += new System.EventHandler(this.buttonRST_Click);
            // 
            // textBoxTerminal
            // 
            this.textBoxTerminal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxTerminal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTerminal.Location = new System.Drawing.Point(8, 25);
            this.textBoxTerminal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxTerminal.Multiline = true;
            this.textBoxTerminal.Name = "textBoxTerminal";
            this.textBoxTerminal.ReadOnly = true;
            this.textBoxTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTerminal.Size = new System.Drawing.Size(664, 274);
            this.textBoxTerminal.TabIndex = 3;
            this.textBoxTerminal.Text = "欢迎来到IMU配置界面";
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Location = new System.Drawing.Point(15, 25);
            this.textBoxCmd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.Size = new System.Drawing.Size(637, 25);
            this.textBoxCmd.TabIndex = 4;
            this.textBoxCmd.Text = "AT+?";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Controls.Add(this.textBoxTerminal);
            this.groupBox2.Location = new System.Drawing.Point(199, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(677, 354);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(585, 320);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(67, 25);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "清除";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(585, 56);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(67, 25);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "写入";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.buttonINFO);
            this.groupBox4.Controls.Add(this.buttonRST);
            this.groupBox4.Location = new System.Drawing.Point(16, 103);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(172, 201);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "快捷按钮";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 164);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "关闭数据输出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 128);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "开启数据输出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 92);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "输出速率为50Hz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonINFO
            // 
            this.buttonINFO.Location = new System.Drawing.Point(8, 25);
            this.buttonINFO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonINFO.Name = "buttonINFO";
            this.buttonINFO.Size = new System.Drawing.Size(133, 29);
            this.buttonINFO.TabIndex = 3;
            this.buttonINFO.Text = "模块信息";
            this.buttonINFO.UseVisualStyleBackColor = true;
            this.buttonINFO.Click += new System.EventHandler(this.buttonINFO_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxCmd);
            this.groupBox5.Controls.Add(this.buttonSend);
            this.groupBox5.Location = new System.Drawing.Point(199, 375);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(677, 87);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送AT指令";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.checkBox0x91);
            this.groupBox6.Controls.Add(this.checkBoxAtdQ);
            this.groupBox6.Controls.Add(this.checkBoxPressure);
            this.groupBox6.Controls.Add(this.checkBoxID);
            this.groupBox6.Controls.Add(this.checkBoxAtdE);
            this.groupBox6.Controls.Add(this.buttonProtocol);
            this.groupBox6.Controls.Add(this.checkBoxMag);
            this.groupBox6.Controls.Add(this.checkBoxGyo);
            this.groupBox6.Controls.Add(this.checkBoxAcc);
            this.groupBox6.Location = new System.Drawing.Point(16, 301);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(172, 264);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "协议配置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "老协议";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "新协议";
            // 
            // checkBox0x91
            // 
            this.checkBox0x91.AutoSize = true;
            this.checkBox0x91.Location = new System.Drawing.Point(8, 203);
            this.checkBox0x91.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox0x91.Name = "checkBox0x91";
            this.checkBox0x91.Size = new System.Drawing.Size(145, 19);
            this.checkBox0x91.TabIndex = 19;
            this.checkBox0x91.Text = "IMU数据集合(91)";
            this.checkBox0x91.UseVisualStyleBackColor = true;
            this.checkBox0x91.CheckedChanged += new System.EventHandler(this.checkBox0x91_CheckedChanged);
            // 
            // checkBoxAtdQ
            // 
            this.checkBoxAtdQ.AutoSize = true;
            this.checkBoxAtdQ.Location = new System.Drawing.Point(8, 158);
            this.checkBoxAtdQ.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAtdQ.Name = "checkBoxAtdQ";
            this.checkBoxAtdQ.Size = new System.Drawing.Size(106, 19);
            this.checkBoxAtdQ.TabIndex = 18;
            this.checkBoxAtdQ.Text = "四元数(D1)";
            this.checkBoxAtdQ.UseVisualStyleBackColor = true;
            // 
            // checkBoxPressure
            // 
            this.checkBoxPressure.AutoSize = true;
            this.checkBoxPressure.Location = new System.Drawing.Point(8, 139);
            this.checkBoxPressure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxPressure.Name = "checkBoxPressure";
            this.checkBoxPressure.Size = new System.Drawing.Size(91, 19);
            this.checkBoxPressure.TabIndex = 17;
            this.checkBoxPressure.Text = "气压(F0)";
            this.checkBoxPressure.UseVisualStyleBackColor = true;
            // 
            // checkBoxID
            // 
            this.checkBoxID.AutoSize = true;
            this.checkBoxID.Location = new System.Drawing.Point(8, 39);
            this.checkBoxID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxID.Name = "checkBoxID";
            this.checkBoxID.Size = new System.Drawing.Size(107, 19);
            this.checkBoxID.TabIndex = 16;
            this.checkBoxID.Text = "用户ID(90)";
            this.checkBoxID.UseVisualStyleBackColor = true;
            // 
            // checkBoxAtdE
            // 
            this.checkBoxAtdE.AutoSize = true;
            this.checkBoxAtdE.Location = new System.Drawing.Point(8, 119);
            this.checkBoxAtdE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAtdE.Name = "checkBoxAtdE";
            this.checkBoxAtdE.Size = new System.Drawing.Size(106, 19);
            this.checkBoxAtdE.TabIndex = 15;
            this.checkBoxAtdE.Text = "欧拉角(D0)";
            this.checkBoxAtdE.UseVisualStyleBackColor = true;
            // 
            // buttonProtocol
            // 
            this.buttonProtocol.Location = new System.Drawing.Point(76, 228);
            this.buttonProtocol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonProtocol.Name = "buttonProtocol";
            this.buttonProtocol.Size = new System.Drawing.Size(88, 30);
            this.buttonProtocol.TabIndex = 12;
            this.buttonProtocol.Text = "写入配置";
            this.buttonProtocol.UseVisualStyleBackColor = true;
            this.buttonProtocol.Click += new System.EventHandler(this.buttonProtocol_Click);
            // 
            // checkBoxMag
            // 
            this.checkBoxMag.AutoSize = true;
            this.checkBoxMag.Location = new System.Drawing.Point(8, 99);
            this.checkBoxMag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxMag.Name = "checkBoxMag";
            this.checkBoxMag.Size = new System.Drawing.Size(106, 19);
            this.checkBoxMag.TabIndex = 14;
            this.checkBoxMag.Text = "地磁场(C0)";
            this.checkBoxMag.UseVisualStyleBackColor = true;
            // 
            // checkBoxGyo
            // 
            this.checkBoxGyo.AutoSize = true;
            this.checkBoxGyo.Location = new System.Drawing.Point(8, 78);
            this.checkBoxGyo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxGyo.Name = "checkBoxGyo";
            this.checkBoxGyo.Size = new System.Drawing.Size(106, 19);
            this.checkBoxGyo.TabIndex = 13;
            this.checkBoxGyo.Text = "角速度(B0)";
            this.checkBoxGyo.UseVisualStyleBackColor = true;
            // 
            // checkBoxAcc
            // 
            this.checkBoxAcc.AutoSize = true;
            this.checkBoxAcc.Location = new System.Drawing.Point(8, 57);
            this.checkBoxAcc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAcc.Name = "checkBoxAcc";
            this.checkBoxAcc.Size = new System.Drawing.Size(106, 19);
            this.checkBoxAcc.TabIndex = 12;
            this.checkBoxAcc.Text = "加速度(A0)";
            this.checkBoxAcc.UseVisualStyleBackColor = true;
            // 
            // FormIMUConfig
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 568);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIMUConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIMUConfig_FormClosing);
            this.Load += new System.EventHandler(this.IMUConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonMode9A;
        private System.Windows.Forms.RadioButton radioButtonMode6A;
        private System.Windows.Forms.Button buttonRST;
        private System.Windows.Forms.TextBox textBoxTerminal;
        private System.Windows.Forms.TextBox textBoxCmd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonINFO;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonProtocol;
        private System.Windows.Forms.CheckBox checkBoxMag;
        private System.Windows.Forms.CheckBox checkBoxGyo;
        private System.Windows.Forms.CheckBox checkBoxAcc;
        private System.Windows.Forms.CheckBox checkBoxAtdE;
        private System.Windows.Forms.CheckBox checkBoxPressure;
        private System.Windows.Forms.CheckBox checkBoxID;
        private System.Windows.Forms.CheckBox checkBoxAtdQ;
        private System.Windows.Forms.CheckBox checkBox0x91;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}