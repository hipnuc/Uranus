using System;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

using Uranus.Data;
using Uranus.DialogsAndWindows;
namespace Uranus.DialogsAndWindows
{
    public partial class FormIMUConfig : BaseForm
    {
        public delegate bool SendDataHandler(byte[] buffer, int index, int count);
        public event SendDataHandler OnDataSend;
        private Queue TextQueue = new Queue();

        IMUData imuData;
        private System.Windows.Forms.Timer TextUpdateTimer = new System.Windows.Forms.Timer();


        public FormIMUConfig()
        {
            InitializeComponent();
        }

        public void PutRawData(byte[] buffer)
        {
            if (this.Visible == true)
            {
                foreach (byte b in buffer)
                {
                    TextQueue.Enqueue(((char)b).ToString());
                }
            }
        }

        public void PutPacket(object sender, IMUData imuData)
        {
            this.imuData = imuData;
        }

        private void IMUConfig_Load(object sender, EventArgs e)
        {
            bool ret;
            ret = SendATCmd("AT+EOUT=0");
            Thread.Sleep(10);

            textBoxTerminal.Clear();
            TextQueue.Clear();

            TextUpdateTimer.Interval = 20;
            TextUpdateTimer.Tick += new EventHandler(TextUpdateTimer_Tick);
            TextUpdateTimer.Start();
        }

        private bool SendATCmd(string cmd)
        {
            textBoxCmd.Text = cmd;
            cmd += "\r\n";
            byte[] data = System.Text.Encoding.ASCII.GetBytes(cmd);

            // 在提示是否更改波特率
            if (cmd.Contains("BAUD"))
            {
                if (MessageBox.Show(cmd, "确认更改波特率!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
                {
                    return false;
                }
            }

            return OnDataSend(data, 0, data.Length);
        }



        void TextUpdateTimer_Tick(object sender, EventArgs e)
        {
            string Text = "";
            Queue mySyncdQ = Queue.Synchronized(TextQueue);
            int count = mySyncdQ.Count;
            for (int i = 0; i < count; i++)
            {
                Text += mySyncdQ.Dequeue();
            }
            TextQueue.Clear();
            textBoxTerminal.AppendText(Text);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            textBoxTerminal.Clear();
        }

        private void buttonRST_Click(object sender, EventArgs e)
        {
            SendATCmd("AT+RST");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendATCmd(textBoxCmd.Text);
        }

        private void buttonINFO_Click(object sender, EventArgs e)
        {
            SendATCmd("AT+INFO=L");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendATCmd("AT+ODR=50");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SendATCmd("AT+EOUT=1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendATCmd("AT+EOUT=0");
        }

        private void radioButtonMode_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (sender == radioButtonMode6A && rb.Checked)
            {
                SendATCmd("AT+MODE=0");
            }
            if (sender == radioButtonMode9A && rb.Checked)
            {
                SendATCmd("AT+MODE=1");
            }
        }

        private void FormIMUConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendATCmd("AT+EOUT=1");

            /* fix the bug that when entering this windows, sometime, will cause hardfault */
            TextUpdateTimer.Dispose();
        }

        private void buttonProtocol_Click(object sender, EventArgs e)
        {
            byte[] protocol_type = new byte[8];
            int cnt = 0;

            if (checkBoxID.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0x90;
            }

            if (checkBoxAcc.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0xA0;
            }

            if (checkBoxGyo.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0xB0;
            }

            if (checkBoxMag.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0xC0;
            }

            if (checkBoxAtdE.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0xD0;
            }
            if (checkBoxAtdQ.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0xD1;
            }

            if (checkBoxPressure.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0xF0;
            }

            if (checkBox0x91.Checked == true)
            {
                checkBox0x91.Checked = false;
                protocol_type[cnt++] = 0x91;
            }

            string cmd = "AT+SETPTL=";
            for (int i = 0; i < cnt; i++)
            {
                cmd += protocol_type[i].ToString("X") + ",";
            }
            if (cmd[cmd.Length - 1] == ',')
            {
                cmd = cmd.Substring(0, cmd.Length - 1);
            }
            SendATCmd(cmd);
        }

        private void checkBox0x91_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox0x91.Checked == true)
            {
                checkBoxID.Checked = false;
                checkBoxAcc.Checked = false;
                checkBoxAtdE.Checked = false;
                checkBoxAtdQ.Checked = false;
                checkBoxGyo.Checked = false;
                checkBoxMag.Checked = false;
                checkBoxPressure.Checked = false;
            }

        }
    }

}
