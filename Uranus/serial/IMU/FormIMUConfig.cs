using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using ZedGraph;

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
        private System.Windows.Forms.Timer UpdateTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer TextUpdateTimer = new System.Windows.Forms.Timer();

        PointPairList list = new PointPairList();
        private bool IsUpdated = false;

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
            IsUpdated = true;
            this.imuData = imuData;
        }

        private void IMUConfig_Load(object sender, EventArgs e)
        {
            bool ret;
            ret = SendATCmd("AT+EOUT=0");
            Thread.Sleep(10);

            zedGraphControl1.GraphPane.Title.FontSpec.Size = 24;
            zedGraphControl1.GraphPane.Title.Text = "地磁校准";
            zedGraphControl1.GraphPane.Title.IsVisible = false;
            zedGraphControl1.GraphPane.XAxis.IsVisible = false;
            zedGraphControl1.GraphPane.YAxis.IsVisible = false;

            zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.Legend.IsVisible = false;

            list.Clear();
            LineItem myCurve = zedGraphControl1.GraphPane.AddCurve("Mag Data", list, Color.Red, SymbolType.Diamond);
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve.Line.IsVisible = false;

            textBoxTerminal.Clear();
            TextQueue.Clear();

            UpdateTimer.Interval = 20;
            UpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            UpdateTimer.Start();

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



        void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (IsUpdated == true)
            {
                if (imuData.MagRaw != null)
                {
                    list.Add(imuData.MagRaw[0], imuData.MagRaw[1]);
                    this.zedGraphControl1.AxisChange();
                    this.zedGraphControl1.Refresh();
                    IsUpdated = false;
                }
            }
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
            SendATCmd("AT+ODR=60");
        }

        private void buttonMCal_Click(object sender, EventArgs e)
        {
            if (buttonMCal.Text == "开始校准")
            {
                buttonMCal.Text = "停止校准";
                list.Clear();
                SendATCmd("AT+MCAL=1");
                Thread.Sleep(20);
                SendATCmd("AT+EOUT=1");
                return;
            }

            if (buttonMCal.Text == "停止校准")
            {
                buttonMCal.Text = "开始校准";
                SendATCmd("AT+MCAL=0");
                Thread.Sleep(100);
                SendATCmd("AT+EOUT=0");
                Thread.Sleep(100);
                textBoxTerminal.Clear();
                SendATCmd("AT+INFO=L");
                return;
            }

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
            int type_len = 0;
            string protocol_description = "协议说明:\r\n5A +A5+<长度(2字节)>+<CRC(2字节)>";

            if (checkBoxID.Checked == true)
            {
                protocol_type[type_len++] = 0x90;
                protocol_description += "+90+<ID(1字节)>";
            }

            if (checkBoxAcc.Checked == true)
            {
                protocol_type[type_len++] = 0xA0;
                protocol_description += "+A0+<加速度(6字节)>";
            }

            if (checkBoxGyo.Checked  == true)
            {
                protocol_type[type_len++] = 0xB0;
                protocol_description += "+B0+<角速度(6字节)>";
            }

            if (checkBoxMag.Checked == true)
            {
                protocol_type[type_len++] = 0xC0;
                protocol_description += "+C0+<地磁(6字节)>";
            }

            if (checkBoxAtdE.Checked == true)
            {
                protocol_type[type_len++] = 0xD0;
                protocol_description += "+D0+<欧拉角(6字节)>";
            }
            if (checkBoxAtdQ.Checked == true)
            {
                protocol_type[type_len++] = 0xD1;
                protocol_description += "+D1+<四元数(16字节)>";
            }

            if (checkBoxPressure.Checked == true)
            {
                protocol_type[type_len++] = 0xF0;
                protocol_description += "+F0+<气压(4字节)>";
            }

            string cmd = "AT+SETPTL=";
            for (int i = 0; i < type_len; i++)
            {
                cmd += protocol_type[i].ToString("X") + ",";
            }
            if (cmd[cmd.Length - 1] == ',')
            {
                cmd = cmd.Substring(0, cmd.Length - 1);
            }
            SendATCmd(cmd);
            labelProtocol.Text = protocol_description;
        }





    }

}
