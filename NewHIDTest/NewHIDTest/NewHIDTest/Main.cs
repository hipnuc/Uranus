using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using HidLibrary;

namespace NewHIDTest
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private HidDevice[] _deviceList;
        HidDevice SelectedDevice;
        public delegate void ReadHandlerDelegate(HidReport report);

        private void button_Scan_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SelectedDevice = null;

            _deviceList = HidDevices.Enumerate().ToArray();
            foreach (HidDevice device in _deviceList)
            {
                listBox1.Items.Add(device.Description + "  VID:" + device.Attributes.VendorHexId + "  PID:" + device.Attributes.ProductHexId);
            }
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            UInt16 myVendorID, myProductID;
            myVendorID = UInt16.Parse(txtVendorID.Text, NumberStyles.AllowHexSpecifier);
            myProductID = UInt16.Parse(txtProductID.Text, NumberStyles.AllowHexSpecifier);

            if (listBox1.SelectedIndex < _deviceList.Length && listBox1.SelectedIndex >=0 && SelectedDevice == null)
            {
                SelectedDevice = _deviceList[listBox1.SelectedIndex];
                listBox1.Items.Clear();



                string info = " VID:" + SelectedDevice.Attributes.VendorHexId + "  PID:" + SelectedDevice.Attributes.ProductHexId + " " + SelectedDevice.Description + " " + " IN len" + SelectedDevice.Capabilities.InputReportByteLength.ToString() + " OUT len: " + SelectedDevice.Capabilities.OutputReportByteLength.ToString();
                listBox1.Items.Add(info);
                this.Text = info;
                SelectedDevice.OpenDevice();
                SelectedDevice.MonitorDeviceEvents = true;
                SelectedDevice.Inserted += Device_Inserted;
                SelectedDevice.Removed += Device_Removed;
                SelectedDevice.ReadReport(ReadcallBack);
            }
            else
            {
                listBox1.Items.Add("No Device Selected\r\n");
            }

        }

        private void Device_Inserted()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Device_Inserted));
                return;
            }
           toolStripStatusLabel1.Text = "Connected";
        }

        private void Device_Removed()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Device_Removed));
                return;
            }
            toolStripStatusLabel1.Text = "Disconnected";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ret = false;

            HidReport  outData = SelectedDevice.CreateReport();
            outData.ReportId = Convert.ToByte(textBox2.Text);
            outData.Data = System.Text.Encoding.Default.GetBytes(textBox1.Text);

            ret = SelectedDevice.WriteReport(outData);

            toolStripStatusLabel1.Text = "Send " + outData.Data.Length + "bytes  "+ ret.ToString();
        }

        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InByte);
            }
            return StringOut;
        }


        private void ReadHandler(HidReport report)
        {
            listBox1.Items.Add ("In Report Received: " + ByteToString(report.Data));
            if (SelectedDevice != null && SelectedDevice.IsConnected == true)
            {
                SelectedDevice.ReadReport(ReadcallBack);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        void ReadcallBack(HidReport report)
        {
            BeginInvoke(new ReadHandlerDelegate(ReadHandler), new object[] { report });
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button_Connect_Click(sender, e);
        }


    }
}
