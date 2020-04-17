using System;
using System.Windows.Forms;
using Uranus.DialogsAndWindows;

namespace Uranus.Utilities
{
    public partial class SerialTerminalForm : TerminalForm
    {
        Connection connection;

        private System.Windows.Forms.Timer UpdateTimer = new System.Windows.Forms.Timer();

        private SampleCounter TxCounter = new SampleCounter();
        private SampleCounter RxCounter = new SampleCounter();

        public SerialTerminalForm(Connection c)
        {
            InitializeComponent();
            connection = c;
            if (connection != null)
            {
                connection.OnReceviedData += new Connection.ReceivedDataEventHandler(Input);
            }
        }

        private void SendData(byte[] buffer, int index, int count)
        {
                connection.Send(buffer, index, count);
                TxCounter.Increment(count);
        }

        private void FormTerminal_Load(object sender, EventArgs e)
        {
            UpdateTimer.Interval = 20;
            UpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            UpdateTimer.Start();
        }

        void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Update sample counter values
            toolStripStatusLabelSamplesReceived.Text = "Rx: " + RxCounter.SamplesReceived.ToString() + " | " + (((Single)RxCounter.SampleRate)/1000).ToString("0.00") + "KB/s";
            toolStripStatusLabelSampleRate.Text = "Tx: " + TxCounter.SamplesReceived.ToString() + " | " + (((Single)TxCounter.SampleRate) / 1000).ToString("0.00") + "KB/s";
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

        
        private void Input(byte[] buffer, int index, int count)
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
                        base.Input(Environment.NewLine);
                    }
                    else
                    {
                        base.Input(Convert.ToChar(b).ToString());
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

    }
}
