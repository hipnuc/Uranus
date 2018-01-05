namespace Uranus
{
    partial class FormGraphic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphic));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.波形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Angle = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Acc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Gyro = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Mag = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.timer_Reflash = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.buttonPause = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 波形ToolStripMenuItem
            // 
            this.波形ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Angle,
            this.ToolStripMenuItem_Acc,
            this.ToolStripMenuItem_Gyro,
            this.ToolStripMenuItem_Mag});
            this.波形ToolStripMenuItem.Name = "波形ToolStripMenuItem";
            this.波形ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.波形ToolStripMenuItem.Text = "波形";
            this.波形ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.波形ToolStripMenuItem_DropDownItemClicked);
            // 
            // ToolStripMenuItem_Angle
            // 
            this.ToolStripMenuItem_Angle.Name = "ToolStripMenuItem_Angle";
            this.ToolStripMenuItem_Angle.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItem_Angle.Text = "姿态角";
            // 
            // ToolStripMenuItem_Acc
            // 
            this.ToolStripMenuItem_Acc.Checked = true;
            this.ToolStripMenuItem_Acc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Acc.Name = "ToolStripMenuItem_Acc";
            this.ToolStripMenuItem_Acc.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItem_Acc.Text = "加速度";
            // 
            // ToolStripMenuItem_Gyro
            // 
            this.ToolStripMenuItem_Gyro.Name = "ToolStripMenuItem_Gyro";
            this.ToolStripMenuItem_Gyro.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItem_Gyro.Text = "角速度";
            // 
            // ToolStripMenuItem_Mag
            // 
            this.ToolStripMenuItem_Mag.Name = "ToolStripMenuItem_Mag";
            this.ToolStripMenuItem_Mag.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItem_Mag.Text = "地磁场";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "→";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer_Reflash
            // 
            this.timer_Reflash.Enabled = true;
            this.timer_Reflash.Interval = 5;
            this.timer_Reflash.Tick += new System.EventHandler(this.timer_Reflash_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 27);
            this.button2.TabIndex = 7;
            this.button2.Text = "←";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 43);
            this.button3.TabIndex = 8;
            this.button3.Text = "↓";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 43);
            this.button4.TabIndex = 9;
            this.button4.Text = "↑";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(99, 33);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(627, 363);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(8, 219);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(78, 36);
            this.buttonPause.TabIndex = 10;
            this.buttonPause.Text = "暂停";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 43);
            this.button5.TabIndex = 12;
            this.button5.Text = "↑";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 43);
            this.button6.TabIndex = 13;
            this.button6.Text = "↓";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(4, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 53);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(50, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(43, 118);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "位置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(4, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(48, 120);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "范围";
            // 
            // FormGraphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGraphic";
            this.Text = "波形显示";
            this.Load += new System.EventHandler(this.FormGraphic_Load);
            this.Resize += new System.EventHandler(this.FormGraphic_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 波形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Angle;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Acc;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Gyro;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Mag;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_Reflash;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}