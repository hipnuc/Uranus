namespace Uranus.DialogsAndWindows
{
    partial class FormGetSerialValue
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
            this.m_RtsCtsEnabled = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.ComboBoxPortName = new System.Windows.Forms.ComboBox();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_RtsCtsEnabled
            // 
            this.m_RtsCtsEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_RtsCtsEnabled.FormattingEnabled = true;
            this.m_RtsCtsEnabled.Items.AddRange(new object[] {
            "Disabled",
            "Enabled"});
            this.m_RtsCtsEnabled.Location = new System.Drawing.Point(108, 74);
            this.m_RtsCtsEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.m_RtsCtsEnabled.Name = "m_RtsCtsEnabled";
            this.m_RtsCtsEnabled.Size = new System.Drawing.Size(93, 23);
            this.m_RtsCtsEnabled.TabIndex = 17;
            this.m_RtsCtsEnabled.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "RTS / CTS:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Serial Port:";
            // 
            // ComboBoxBaudrate
            // 
            this.ComboBoxBaudrate.FormattingEnabled = true;
            this.ComboBoxBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.ComboBoxBaudrate.Location = new System.Drawing.Point(126, 42);
            this.ComboBoxBaudrate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComboBoxBaudrate.Name = "ComboBoxBaudrate";
            this.ComboBoxBaudrate.Size = new System.Drawing.Size(359, 23);
            this.ComboBoxBaudrate.TabIndex = 16;
            // 
            // ComboBoxPortName
            // 
            this.ComboBoxPortName.FormattingEnabled = true;
            this.ComboBoxPortName.Location = new System.Drawing.Point(126, 10);
            this.ComboBoxPortName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComboBoxPortName.Name = "ComboBoxPortName";
            this.ComboBoxPortName.Size = new System.Drawing.Size(359, 23);
            this.ComboBoxPortName.TabIndex = 15;
            // 
            // m_OKButton
            // 
            this.m_OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_OKButton.Location = new System.Drawing.Point(277, 75);
            this.m_OKButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(100, 27);
            this.m_OKButton.TabIndex = 18;
            this.m_OKButton.Text = "OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // m_Cancel
            // 
            this.m_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_Cancel.Location = new System.Drawing.Point(387, 75);
            this.m_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.m_Cancel.Name = "m_Cancel";
            this.m_Cancel.Size = new System.Drawing.Size(100, 27);
            this.m_Cancel.TabIndex = 19;
            this.m_Cancel.Text = "Cancel";
            this.m_Cancel.UseVisualStyleBackColor = true;
            this.m_Cancel.Click += new System.EventHandler(this.m_Cancel_Click);
            // 
            // FormGetSerialValue
            // 
            this.AcceptButton = this.m_OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 110);
            this.Controls.Add(this.m_RtsCtsEnabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxBaudrate);
            this.Controls.Add(this.ComboBoxPortName);
            this.Controls.Add(this.m_OKButton);
            this.Controls.Add(this.m_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGetSerialValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置串口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGetValue_FormClosing);
            this.Load += new System.EventHandler(this.FormGetValue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_RtsCtsEnabled;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxBaudrate;
        private System.Windows.Forms.ComboBox ComboBoxPortName;
        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.Button m_Cancel;
    }
}