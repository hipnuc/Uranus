using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Ports;
using Uranus.DialogsAndWindows;
using Uranus.Utilities;
using Uranus.Data;

namespace Uranus
{
    public partial class Main : Form
    {

        FormIMU fmIMU;
        TerminalForm fmTermial;
        IMUData device_data;

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

        private SerialPort serialPort = new SerialPort();
        private Connection m_connection = new Connection();
        private KbootPacketDecoder KbootDecoder = new KbootPacketDecoder();

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
            fmIMU = new FormIMU(m_connection);
            DockForm(fmIMU, TabPageIMUUI);

            fmTermial = new TerminalForm();
            DockForm(fmTermial, tabPageMessage);

            this.Text = Assembly.GetExecutingAssembly().GetName().Name + " (Port Closed)" + " V" + Assembly.GetExecutingAssembly().GetName().Version;

            Int32 baud = Convert.ToInt32(iniFile.Read("SerialPort", "Baudrate"));
            if (baud == 0)
            {
                iniFile.Write("SerialPort", "Baudrate", "115200");
            }
            RefreshSerialPortList(toolStripMenuItemSerial);

            m_connection.OnSendData += new Connection.SendDataEventHandler(SendSerialPort);
            KbootDecoder.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived);
            serialPort.WriteTimeout = 1000;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSerialPort();
        }

        #endregion

        private void OnKbootDecoderDataReceived(object sender, byte[] buf, int len)
        {
            device_data = IMUData.Decode(buf, len);
            fmTermial.Input(device_data.ToString());
        }

        #region Serial port

        private void RefreshSerialPortList(ToolStripMenuItem item)
        {
            Int32 last_baud = Convert.ToInt32(iniFile.Read("SerialPort", "Baudrate"));

            ToolStripItemCollection DropDownCollection = item.DropDownItems;
            DropDownCollection.Clear();

            DropDownCollection.Add("刷新串口");
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                DropDownCollection.Add("COM" + Regex.Replace(portName.Substring("COM".Length, portName.Length - "COM".Length), "[^.0-9]", "\0") + ", " + 115200.ToString());
            }
            DropDownCollection.Add(toolStripMenuItemOpenSerialConnectionDialog);
        }

        private string GetPortName(ToolStripMenuItem item)
        {
            string portName = null;
            // Get selected port name
            foreach (ToolStripMenuItem toolStripMenuItem in item.DropDownItems)
            {
                if (toolStripMenuItem.Checked)
                {
                    string text = toolStripMenuItem.Text;
                    portName = text.Substring(0, text.IndexOf(',')).Trim();
                    break;
                }
            }
            return portName;
        }

        private int GetBaudrate(ToolStripMenuItem item)
        {
            int Baudrate = 0;
            // Get selected port name
            foreach (ToolStripMenuItem toolStripMenuItem in item.DropDownItems)
            {
                if (toolStripMenuItem.Checked)
                {
                    string text = toolStripMenuItem.Text;
                    text = text.Substring(text.IndexOf(',') + 1).Trim();
                    Baudrate = Convert.ToInt32(text);
                    break;
                }
            }
            return Baudrate;
        }

        private bool OpenSerialPort(string Name, int Baudrate)
        {
            // Open serial port
            CloseSerialPort();
            try
            {
                serialPort = new SerialPort(Name, Baudrate, Parity.None, 8, StopBits.One);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort.Open();
                this.Text = Assembly.GetExecutingAssembly().GetName().Name + " (" + Name.Replace("\0", "") + ", " + Baudrate.ToString() + ")" + " V" + Assembly.GetExecutingAssembly().GetName().Version;
                //sampleCounter.Reset();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public bool SendSerialPort(byte[] buffer, int offset, int count)
        {
            bool ret = true;
            try
            {
                serialPort.Write(buffer, offset, count);
            }
            catch (Exception e)
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
                if (serialPort.IsOpen)
                {
                    serialPort.Read(readBuffer, 0, bytesToRead);
                }

                m_connection.Input(readBuffer);
                KbootDecoder.Input(readBuffer);
            }
        }



        private void toolStripMenuItemSerialPort_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            // Close serial port and 刷新串口 is refresh item clicked
            if (e.ClickedItem.Text == "刷新串口")
            {
                CloseSerialPort();
                RefreshSerialPortList(toolStripMenuItemSerial);
                return;
            }

            if (e.ClickedItem.Text == "...")
            {
                FormGetSerialValue fmGetValue = new FormGetSerialValue();
                if (fmGetValue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (OpenSerialPort(fmGetValue.PortName, fmGetValue.Baudrate))
                    {
                        // record successful port
                        iniFile.Write("SerialPort", "Baudrate", fmGetValue.Baudrate.ToString());
                        iniFile.Write("SerialPort", "Name", fmGetValue.PortName);
                    }
                }
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
            foreach (ToolStripMenuItem toolStripMenuItem in item.DropDownItems)
            {
                toolStripMenuItem.Checked = false;
            }
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;

            // Open serial port
            if (!OpenSerialPort(GetPortName(item), GetBaudrate(item)))
            {
                // uncheck serial port if open fails
                ((ToolStripMenuItem)e.ClickedItem).Checked = false;
            }
            else
            {
                // record successful port
                iniFile.Write("SerialPort", "Baudrate", GetBaudrate(item).ToString());
                iniFile.Write("SerialPort", "Name", GetPortName(item));
            }
        }


        #endregion

        #region  HelpMenu
        private void toolStripMenuItemGuide_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.hipnuc.com");
        }


        private void toolStripMenuItemAbout0_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        #endregion

        #region ToolMenu
        private void toolStripMenuItemUpdater_Click(object sender, EventArgs e)
        {
            FormFrimwareUpdater fmBootloader = new FormFrimwareUpdater(m_connection);
            fmBootloader.ShowDialog();
        }

        private void toolStripMenuItemSerialTerminal_Click(object sender, EventArgs e)
        {
            SerialTerminalForm fmTerminal = new SerialTerminalForm(m_connection);
            if (fmTerminal.IsDisposed == true)
            {
                fmTerminal = new SerialTerminalForm(m_connection);
            }
            fmTerminal.Show();
        }

        private void toolStripMenuItemRegsConfig_Click(object sender, EventArgs e)
        {
            FormRegsConfig fmRegsConfig = new FormRegsConfig(m_connection);
            if (fmRegsConfig.IsDisposed == true)
            {
                fmRegsConfig = new FormRegsConfig(m_connection);
            }
            fmRegsConfig.Show();
        }

        #endregion

        #region DataLoggerMenu
        private void toolStripMenuItemDataLogger_Click(object sender, EventArgs e)
        {
            FormDataLogger fmDataLogger = new FormDataLogger(m_connection);
            fmDataLogger.ShowDialog();
        }
        #endregion

        #region GraphMenu

        private void toolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item.Checked)
            {
                fmIMU.OpenGraph(item.Tag.ToString());
            }
            else
            {
                fmIMU.CloseGraph(item.Tag.ToString());
            }
        }

        private void toolStripMenuItemGraph_DropDownOpening(object sender, EventArgs e)
        {
            // 当弹出下拉菜单时候，把已经关闭的波形显示对应的Checked状态也取消
            ToolStripMenuItem GraphItem = sender as ToolStripMenuItem;

            foreach (object obj in this.toolStripMenuItemGraph.DropDownItems)
            {
                if (obj.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem item = obj as ToolStripMenuItem;
                    if (item.Tag != null && item.Tag.ToString() != "")
                    {
                        item.Checked = fmIMU.IsGraphActive(item.Tag.ToString());
                    }
                }
            }


        }
        #endregion

        private void toolStripMenuItem3DView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item.Checked == true)
            {
                fmIMU.Open3DView();
            }
            else
            {
                fmIMU.Close3DView();
            }
        }

        private void toolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            fmIMU.OpenConfigurationDialog();
        }

        private void 购买ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://upcmcu.taobao.com");
        }
    }
}
