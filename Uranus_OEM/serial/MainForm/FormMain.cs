using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

using Uranus.bootloader;
using Uranus.PacketDecoder;
using Utilities;

namespace Uranus
{
    public partial class Main : Form
    {

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

        public Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
        }

        #region Variables and objects

        private System.Windows.Forms.Timer timerCal = new System.Windows.Forms.Timer();
        private SerialPort serialPort = new SerialPort();

        private KbootPacketDecoder kpd = new KbootPacketDecoder();
        private FormIMU fmIMU = null;
        private FormBootloader fmBootloader = null;
        private FormTerminal fmTerminal = null;

        #endregion

        #region Form load and close

        //在选项卡中生成窗体
        private Form DockForm(Form fm, TabPage Page)
        {
            //设置窗体没有边框 加入到选项卡中
            fm.Text = "";
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.TopLevel = false;
            fm.Parent = Page;
            fm.ControlBox = false;
            fm.Dock = DockStyle.Fill;
            fm.Show();
            return fm;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            fmIMU = new FormIMU();
            DockForm(fmIMU, TabPageIMU);

            fmTerminal = new FormTerminal();
            DockForm(fmTerminal, tabPageTerminal);

            fmBootloader = new FormBootloader();
            DockForm(fmBootloader, tabPageKboot);

            this.Text = Assembly.GetExecutingAssembly().GetName().Name + " (Port Closed)" + " V" + Assembly.GetExecutingAssembly().GetName().Version;

            RefreshSerialPortList();
           
            // load baudrate
            foreach (ToolStripMenuItem toolStripMenuItem in ((ToolStripMenuItem)toolStripMenuItemBaudRate).DropDownItems)
            {
                    try
                    {
                        Int32 baud = Convert.ToInt32(iniFile.Read("SerialPort", "BaudRate"));
                        Int32 baudRate = Convert.ToInt32((new Regex("[^0-9]")).Replace(toolStripMenuItem.Text, ""));  // convert text to int ignoring all non-numerical characters
                        if (baud == baudRate)
                        {
                            toolStripMenuItem.Checked = true;
                            break;
                        }
                    }
                    catch
                    {
                    }
            }

            kpd.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(fmIMU.OnKbootDecoderDataReceived);
            fmTerminal.OnDataSend += new FormTerminal.SendDataHandler(SendSerialPort);
            fmBootloader.OnDataSend += new FormBootloader.BootloaderSendDataHandler(SendSerialPort);
            fmIMU.OnDataSend += new FormIMU.SendDataHandler(SendSerialPort);

            serialPort.WriteTimeout = 1000;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSerialPort();
            fmIMU.Close();
            fmTerminal.Close();
            fmBootloader.Close();
        }

        #endregion

        #region Serial port

        private void RefreshSerialPortList()
        {
            ToolStripItemCollection toolStripItemCollection = toolStripMenuItemSerialPort.DropDownItems;
            toolStripItemCollection.Clear();
            toolStripItemCollection.Add("刷新串口");
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                {
                    toolStripItemCollection.Add("COM" + Regex.Replace(portName.Substring("COM".Length, portName.Length - "COM".Length), "[^.0-9]", "\0"));
                }
            }
        }



        private string GetPortName()
        {
            string portName = null;
            // Get selected port name
            foreach (ToolStripMenuItem toolStripMenuItem in ((ToolStripMenuItem)toolStripMenuItemSerialPort).DropDownItems)
            {
                if (toolStripMenuItem.Checked)
                {
                    portName = toolStripMenuItem.Text;
                    break;
                }
            }
            return portName;
        }

        private int GetBaudRate()
        {
            int baudRate = 0;
            foreach (ToolStripMenuItem toolStripMenuItem in ((ToolStripMenuItem)toolStripMenuItemBaudRate).DropDownItems)
            {
                if (toolStripMenuItem.Checked)
                {
                    try
                    {
                        baudRate = Convert.ToInt32((new Regex("[^0-9]")).Replace(toolStripMenuItem.Text, ""));  // convert text to int ignoring all non-numerical characters
                    }
                    catch
                    {
                        baudRate = 0;
                    }
                    break;
                }
            }
            iniFile.Write("SerialPort", "BaudRate", baudRate.ToString());
            return baudRate;
        }

        private bool OpenSerialPort(string portName, int baudRate)
        {
            // Open serial port
            CloseSerialPort();
            try
            {
                serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort.Open();
                this.Text = Assembly.GetExecutingAssembly().GetName().Name + " (" + portName.Replace("\0", "") + ", " + baudRate.ToString() + ")" + " V" + Assembly.GetExecutingAssembly().GetName().Version;
                //sampleCounter.Reset();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public void SendSerialPort(char c)
        {
            try
            {
                serialPort.Write(new char[] { c }, 0, 1);
            }
            catch { }
        }
        public bool SendSerialPort(byte[] buffer, int offset, int count)
        {
            bool ret = true;
            try
            {
                serialPort.Write(buffer, offset, count);
            }
            catch ( Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ret = false;
                return ret;
            }
            return ret;
        }

        /// <summary>
        /// Closes serial port.
        /// </summary>
        private void CloseSerialPort()
        {
            try
            {
                serialPort.Close();
            }
            catch { }
            this.Text = Assembly.GetExecutingAssembly().GetName().Name + " (Port Closed)";
        }

        /// <summary>
        /// serialPort DataReceived event to print characters to terminal and process bytes through serialDecoder.
        /// </summary>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
                // Get bytes from serial port
            if (serialPort.IsOpen)
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] readBuffer = new byte[bytesToRead];
                serialPort.Read(readBuffer, 0, bytesToRead);

                kpd.Input(readBuffer);
                fmIMU.Input(readBuffer);
                fmBootloader.Input(readBuffer);
                fmTerminal.Input(readBuffer);
            }
        }

        #endregion

        #region Menu strip

        private void toolStripMenuItemSerialPort_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Close serial port and 刷新串口 is refresh item clicked
            if (e.ClickedItem.Text == "刷新串口")
            {
                CloseSerialPort();
                RefreshSerialPortList();
                return;
            }

            // Close serial port if checked port name clicked
            if (((ToolStripMenuItem)e.ClickedItem).Checked)
            {
                CloseSerialPort();
                ((ToolStripMenuItem)e.ClickedItem).Checked = false;
                return;
            }

            // Check only selected item
            foreach (ToolStripMenuItem toolStripMenuItem in ((ToolStripMenuItem)toolStripMenuItemSerialPort).DropDownItems)
            {
                toolStripMenuItem.Checked = false;
            }
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;

            // Open serial port
            if (!OpenSerialPort(GetPortName(), GetBaudRate()))
            {
                ((ToolStripMenuItem)e.ClickedItem).Checked = false;     // uncheck serial port if open fails
            }
        }
        
        /// <summary>
        /// toolStripMenuItemAbout Click event to display version details.
        /// </summary>
        private void toolStripMenuItemAbout0_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        /// <summary>
        /// toolStripMenuItemSerialPort DropDownItemClicke event to select baud rate.
        /// </summary>
        private void toolStripMenuItemBaudRate_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ((ToolStripMenuItem)e.ClickedItem == toolStripMenuItemOther)
            {
                FormGetValue formGetValue = new FormGetValue();
                formGetValue.ShowDialog();
                ((ToolStripMenuItem)e.ClickedItem).Text = "Other (" + formGetValue.value + ")";
                ((ToolStripMenuItem)e.ClickedItem).Checked = false;
            }

            // Do nothing if baud already selected
            if (((ToolStripMenuItem)e.ClickedItem).Checked)
            {
                return;
            }

            // Check only selected item
            foreach (ToolStripMenuItem toolStripMenuItem in ((ToolStripMenuItem)toolStripMenuItemBaudRate).DropDownItems)
            {
                toolStripMenuItem.Checked = false;
            }
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;

            // Open serial port
            if (!OpenSerialPort(GetPortName(), GetBaudRate()))
            {
                RefreshSerialPortList();    // refresh port list if open fails, this also ensures port object is closed
            }
        }

        private void toolStripMenuItemGuide_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Diagnostics.Process.Start("iexplore.exe", "https://upcmcu.taobao.com");
            //}
            //catch { }
            System.Diagnostics.Process.Start("https://upcmcu.taobao.com");
        }

        private void toolStripMenuItemUpgrade_Click(object sender, EventArgs e)
        {
            
            //try
            //{
            //    System.Diagnostics.Process.Start("iexplore.exe", "https://pan.baidu.com/s/1c2LpoWg");
            //}
            //catch { }
            System.Diagnostics.Process.Start("https://pan.baidu.com/s/1c2LpoWg");
            System.Diagnostics.Process.Start("http://www.beyondcore.net/forum.php?mod=attachment&aid=MTA2NXw1MGYwYTFhZXwxNDcxNDQzMjM5fDF8Mjc4Ng%3D%3D");
        }

        #endregion




      

    }
}
