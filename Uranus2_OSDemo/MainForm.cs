using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Diagnostics;
using Uranus.Data;
using Uranus.Utilities;

namespace Uranus
{
    public partial class MainForm : Form
    {

        private IMUData imuData;
        private SampleCounter counter = new SampleCounter();
        
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComPort(null, null);
            Baund = 115200;            
            SetBaudrate(Baund);
            KbootDecoder.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived);
        }

        private bool bListening = false;
    //    private bool bClosing = false;
        private Int32 Baund=115200;
        KbootPacketDecoder KbootDecoder = new KbootPacketDecoder();
        IMUData UranusData = new IMUData();

        #region COM port operation

        private void SetBaudrate(int iBaund)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem11.Checked = false;
            switch (iBaund)
            {
                case 2400: toolStripMenuItem2.Checked = true; break;
                case 4800: toolStripMenuItem3.Checked = true; break;
                case 9600: toolStripMenuItem4.Checked = true; break;
                case 19200: toolStripMenuItem5.Checked = true; break;
                case 38400: toolStripMenuItem6.Checked = true; break;
                case 57600: toolStripMenuItem7.Checked = true; break;
                case 115200: toolStripMenuItem8.Checked = true; break;
                case 230400: toolStripMenuItem9.Checked = true; break;
                case 460800: toolStripMenuItem10.Checked = true; break;
                case 921600: toolStripMenuItem11.Checked = true; break;
            }
            spSerialPort.BaudRate = iBaund;
        }

        private void RefreshComPort(object sender, EventArgs e)
        {
            toolStripComSet.DropDownItems.Clear();
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                toolStripComSet.DropDownItems.Add(portName, null, PortSelect);

                if ((spSerialPort.IsOpen) & (spSerialPort.PortName == portName))
                {
                    ToolStripMenuItem menu = (ToolStripMenuItem)toolStripComSet.DropDownItems[toolStripComSet.DropDownItems.Count - 1];
                    menu.Checked = true;
                }
            }
            toolStripComSet.DropDownItems.Add(new ToolStripSeparator());
            toolStripComSet.DropDownItems.Add("Close", null, PortClose);
        }

        private void PortSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            try
            {
                PortClose(null, null);
                spSerialPort.PortName = menu.Text;
                spSerialPort.BaudRate = Baund;                
                spSerialPort.Open();
                menu.Checked = true;
            //    bClosing = false;
                timer3.Start();
            }
            catch (Exception ex)
            {
                menu.Checked = false;
            }  

        }
        private void PortClose(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStripComSet.DropDownItems.Count-2; i++)
            {
                ToolStripMenuItem tempMenu = (ToolStripMenuItem)toolStripComSet.DropDownItems[i];
                tempMenu.Checked = false;
            }
            if (spSerialPort.IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents(); 
                spSerialPort.Dispose(); 
                spSerialPort.Close();
                timer3.Stop();
            }
        }
        #endregion


        #region data processing

        public void OnKbootDecoderDataReceived(object sender, byte[] buf, int len)
        {
            imuData = IMUData.Decode(buf, len);
            counter.Increment(1);
        }

        private void DisplayRefresh(object sender, EventArgs e)
        {
            double Pa = 0;
            Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(UranusData.Pressure) / (double)101325), 0.190295));
            if (imuData != null)
            {
                labelRawData.Text = imuData.ToString();
                label2.Text = "接受速率: " + counter.SampleRate.ToString() + "f/s";
            }
            
        }

        #endregion 

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // Get bytes from serial port

            int bytesToRead = spSerialPort.BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            spSerialPort.Read(readBuffer, 0, bytesToRead);
            KbootDecoder.Input(readBuffer);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PortClose(null, null);
            }
            catch { }
           
        }
        #region UI choose baud
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Baund = 2400;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Baund = 4800;
            SetBaudrate(Baund);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Baund = 9600;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Baund = 19200;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Baund = 38400;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Baund = 57600;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Baund = 115200;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Baund = 230400;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Baund = 460800;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Baund = 921600;
            SetBaudrate(Baund);
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }


    }
}
