using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Uranus
{
    public partial class FormTerminal : Form
    {
        public delegate bool SendDataHandler(byte[] buffer, int index, int count);
        public event SendDataHandler OnDataSend;

     //   private TextBoxBuffer textBoxBuffer = new TextBoxBuffer(4096);
        private Queue TextQueue = new Queue();

        private System.Windows.Forms.Timer UpdateTimer = new System.Windows.Forms.Timer();

        private SampleCounter TxCounter = new SampleCounter();
        private SampleCounter RxCounter = new SampleCounter();

        public FormTerminal()
        {
            InitializeComponent();
        }

        private void SendData(byte[] buffer, int index, int count)
        {
            if (OnDataSend != null)
            {
                OnDataSend(buffer, index, count);
                TxCounter.Increment(count);
            }
        }

        private void FormTerminal_Load(object sender, EventArgs e)
        {
            UpdateTimer.Interval = 20;
            UpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            UpdateTimer.Start();
        }


        void formUpdateTimer_Tick(object sender, EventArgs e)
        {

            if (textBox.Enabled && (TextQueue.Count != 0))
            {
                    string Text = "";
                     Queue  mySyncdQ = Queue.Synchronized(TextQueue);
                     int count = mySyncdQ.Count;
                     for (int i = 0; i < count; i++)
                     {
                         Text += mySyncdQ.Dequeue();
                     }

                TextQueue.Clear();

                if (Text.IndexOf("\b \b") >= 0)
                {
                    Text = Text.Remove(Text.IndexOf("\b \b"), 3);
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length -1 , 1);
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.ScrollToCaret();
                }

                textBox.AppendText(Text);
                if (textBox.Text.Length > textBox.MaxLength)    // discard first half of textBox when number of characters exceeds length
                {
                    textBox.Text = textBox.Text.Substring(textBox.Text.Length / 2, textBox.Text.Length - textBox.Text.Length / 2);
                }
            }

            // Update sample counter values
            toolStripStatusLabelSamplesReceived.Text = "Rx: " + RxCounter.SamplesReceived.ToString() + " | " + (((Single)RxCounter.SampleRate)/1000).ToString("0.00") + "KB/s";
            toolStripStatusLabelSampleRate.Text = "Tx: " + TxCounter.SamplesReceived.ToString() + " | " + (((Single)TxCounter.SampleRate) / 1000).ToString("0.00") + "KB/s";
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendData(new byte[] { (byte)(e.KeyChar) }, 0, 1);
            e.Handled = true;   // don't print character
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                SendData(new byte[] { Convert.ToByte('\t') }, 0, 1);
            }
            //如果想要焦点保持在原控件则返回true
            return false;
        }

        
        public void Input(byte[] buffer)
        {
            // if current window is not active, just ignore data 
            if (this.Visible == true)
            {
                RxCounter.Increment(buffer.Length);

                foreach (byte b in buffer)
                {
                    // Parse character to textBoxBuffer
                    if ((b < 0x20 || b > 0x7F) && (b != '\n') && (b != '\r') && (b != '\b'))    // replace non-printable characters with '.'
                    {
                        //textBoxBuffer.Put("");
                    }
                    else if (b == '\n')     // replace carriage return with '↵' and valid new line
                    {
                        TextQueue.Enqueue(Environment.NewLine);
                        //textBoxBuffer.Put(Environment.NewLine);
                    }
                    else
                    {
                        TextQueue.Enqueue(((char)b).ToString());
                       // textBoxBuffer.Put(((char)b).ToString());
                    }
                }
            }
        }

        private void toolStripMenuItemEnabled_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripMenuItemEnabled.Checked)
                textBox.Enabled = true;
            else
                textBox.Enabled = false;
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            TxCounter.Reset();
            RxCounter.Reset();
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateTimer.Enabled = !UpdateTimer.Enabled;
        }

        private void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTimer.Enabled = !UpdateTimer.Enabled;
        }

    }
}
