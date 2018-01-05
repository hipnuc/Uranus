using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Utilities;

using Uranus.Data;
using Uranus.DialogsAndWindows;

namespace Uranus
{
    public partial class FormIMU : Form
    {

        public delegate bool SendDataHandler(byte[] buffer, int index, int count);
        public event SendDataHandler OnDataSend;

        private IMUData imuData = new IMUData();
        private SampleCounter SampleCounter = new SampleCounter();
        private FormIMUConfig fmConfig = new FormIMUConfig();
        private CsvFileWriter csvFileWriter = null;
        private Dictionary<string, GrapicWindowForm> Active_GraphWindows = new Dictionary<string, GrapicWindowForm>();

        bool IsThread3DRunning = false;
       // bool IsThreadGraphicRunning = false;
        object Form3DDisplay = null;
        private System.Windows.Forms.Timer formUpdateTimer = new System.Windows.Forms.Timer();


        void WriteBinaryFile(string FileName, byte[] bytes, FileMode mode)
        {
            string path = System.IO.Path.GetDirectoryName(FileName);

            System.IO.Directory.CreateDirectory(path);
            System.IO.FileStream fs = new System.IO.FileStream(FileName, mode);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

        public FormIMU()
        {

            InitializeComponent();
        }

        private void FormIMU_Load(object sender, EventArgs e)
        {
            formUpdateTimer.Interval = 25;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();


        }

        public void Input(byte[] buffer)
        {
            fmConfig.PutRawData(buffer);
        }
        const float Ascale = 0.001F;
        const float Gscale =0.1F;
        const float Mscale = 1F;

        private void ReflashData(IMUData data)
        {
            int i;
                //double Pa = 0;
                //Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(data.Pressure) / (double)101325), 0.190295));
                if (data.AvailableItem == null)
                {
                    return;
                }
                else
                {
                    labelRawData.Text = "";
                }

                for (i = 0; i < data.AvailableItem.Length; i++)
                {
                    switch (data.AvailableItem[i])
                    {
                        case (byte)IMUData.ItemID.kItemID:
                            labelRawData.Text += string.Format("ID:").PadRight(14) + data.ID.ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemUID:
                            labelRawData.Text += string.Format("UID:").PadRight(14) + "0x" + data.UID.ToString("X").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemAccRaw:
                            labelRawData.Text += string.Format("加速度:").PadRight(11) + data.AccRaw[0].ToString("0").PadLeft(5, ' ') + " " + data.AccRaw[1].ToString("0").PadLeft(5, ' ') + " " + data.AccRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemAccCalibrated:
                            labelRawData.Text += string.Format("AccCalibrated:").PadRight(14) + data.AccCalibrated[0].ToString("0").PadLeft(5, ' ') + " " + data.AccCalibrated[1].ToString("0").PadLeft(5, ' ') + " " + data.AccCalibrated[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemAccFiltered:
                            labelRawData.Text += string.Format("AccFiltered:").PadRight(14) + data.AccFiltered[0].ToString("0").PadLeft(5, ' ') + " " + data.AccFiltered[1].ToString("0").PadLeft(5, ' ') + " " + data.AccFiltered[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemAccLinear:
                            labelRawData.Text += string.Format("AccLinear:").PadRight(14) + data.AccLinear[0].ToString("0").PadLeft(5, ' ') + " " + data.AccLinear[1].ToString("0").PadLeft(5, ' ') + " " + data.AccLinear[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemGyoRaw:
                            labelRawData.Text += string.Format("角速度:").PadRight(11) + data.GyoRaw[0].ToString("0").PadLeft(5, ' ') + " " + data.GyoRaw[1].ToString("0").PadLeft(5, ' ') + " " + data.GyoRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemGyoCalibrated:
                            labelRawData.Text += string.Format("GyoCalibrated:").PadRight(14) + data.GyoCalibrated[0].ToString("0").PadLeft(5, ' ') + " " + data.GyoCalibrated[1].ToString("0").PadLeft(5, ' ') + " " + data.GyoCalibrated[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemGyoFiltered:
                            labelRawData.Text += string.Format("GyoFiltered:").PadRight(14) + data.GyoFiltered[0].ToString("0").PadLeft(5, ' ') + " " + data.GyoFiltered[1].ToString("0").PadLeft(5, ' ') + " " + data.GyoFiltered[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemMagRaw:
                            labelRawData.Text += string.Format("地磁场:").PadRight(11) + data.MagRaw[0].ToString("0").PadLeft(5, ' ') + " " + data.MagRaw[1].ToString("0").PadLeft(5, ' ') + " " + data.MagRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemMagCalibrated:
                            labelRawData.Text += string.Format("MagCalibrated:").PadRight(14) + data.MagCalibrated[0].ToString("0").PadLeft(5, ' ') + " " + data.MagCalibrated[1].ToString("0").PadLeft(5, ' ') + " " + data.MagCalibrated[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemMagFiltered:
                            labelRawData.Text += string.Format("MagFiltered:").PadRight(14) + data.MagFiltered[0].ToString("0").PadLeft(5, ' ') + " " + data.MagFiltered[1].ToString("0").PadLeft(5, ' ') + " " + data.MagFiltered[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemRotationEular:
                            labelRawData.Text += string.Format("Angles(PRY):").PadRight(14) + data.EularAngles[0].ToString("f2").PadLeft(5, ' ') + " " + data.EularAngles[1].ToString("f2").PadLeft(5, ' ') + " " + data.EularAngles[2].ToString("f2").PadLeft(5, ' ') + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemRotationQuat:
                            labelRawData.Text += string.Format("Q(WXYZ):").PadRight(10) + data.Quaternion[0].ToString("f3").PadLeft(5, ' ') + " " + data.Quaternion[1].ToString("f3").PadLeft(5, ' ') + " " + data.Quaternion[2].ToString("f3").PadLeft(5, ' ') + " " + data.Quaternion[3].ToString("f3").PadLeft(5, ' ')+ "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemTemperature:
                            labelRawData.Text += string.Format("Temperature:").PadRight(14) + data.Temperature.ToString("f3").PadLeft(5, ' ')  + "\r\n";
                            break;
                        case (byte)IMUData.ItemID.kItemPressure:
                            labelRawData.Text += string.Format("Pressure:").PadRight(14) + data.Pressure.ToString("f3").PadLeft(5, ' ') + "\r\n";
                            break;
                    }
                }

                attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters((double)imuData.EularAngles[0], (double)imuData.EularAngles[1]);
                headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(Convert.ToInt16(imuData.EularAngles[2]));
                // altimeterInstrumentControl1.SetAlimeterParameters(Convert.ToInt32(Pa));
                airSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(SampleCounter.SampleRate);
                label7.Text = "接受速率: " + SampleCounter.SampleRate.ToString() + "Hz";
        }

        private void AddGraphData(string name, DateTime timestamp, int index, float trace)
        {
            if (Active_GraphWindows.ContainsKey(name) == false)
            {
                return;
            }

            Active_GraphWindows[name].AddData(timestamp, index, trace);
        }

        private void DoOnDataReceived(IMUData data)
        {
            CSV_PutLine(data);

            if (Form3DDisplay != null)
            {
                Display form = (Display)Form3DDisplay;
                form.SetFromIMUData(data);
            }

            fmConfig.PutPacket(this, data);

            AddGraphData("Gyroscope", DateTime.Now, 0, data.GyoRaw[0]);
            AddGraphData("Gyroscope", DateTime.Now, 1, data.GyoRaw[1]);
            AddGraphData("Gyroscope", DateTime.Now, 2, data.GyoRaw[2]);

            AddGraphData("Accelerometer", DateTime.Now, 0, data.AccRaw[0]);
            AddGraphData("Accelerometer", DateTime.Now, 1, data.AccRaw[1]);
            AddGraphData("Accelerometer", DateTime.Now, 2, data.AccRaw[2]);

            AddGraphData("Magnetometer", DateTime.Now, 0, data.MagRaw[0]);
            AddGraphData("Magnetometer", DateTime.Now, 1, data.MagRaw[1]);
            AddGraphData("Magnetometer", DateTime.Now, 2, data.MagRaw[2]);
        }

        public void OnKbootDecoderDataReceived(object sender, byte[] buf, int len)
        {
            SampleCounter.Increment(1);
            imuData = IMUData.Decode(buf, len);
            DoOnDataReceived(imuData);
        }

        void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            // if current window is not active, just ignore data 
            if (this.Visible == false)
            {
                return;
            }

            ReflashData(imuData);
        }

        #region menu

        private void Graph_FormClosed(object sender, FormClosedEventArgs e)
        {
            GrapicWindowForm graph = sender as GrapicWindowForm;

            foreach  (ToolStripMenuItem item in this.toolStripMenuItemGraph.DropDownItems)
            {
                if (item.Tag.ToString() == graph.ID)
                {
                    item.Checked = false;
                }
            }
        }

        private void toolStripMenuItemOscilloscope_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem StripItem = sender as ToolStripMenuItem;

                string name = StripItem.Tag.ToString();

                if (StripItem.Checked)
                {
                    GrapicWindowForm graph = new GrapicWindowForm(DefaultGraphSettings.GetSettings(name));
                    Active_GraphWindows.Add(name, graph);

                    Active_GraphWindows[name].FormClosed += Graph_FormClosed;
                    Active_GraphWindows[name].Show();
                    graph.Show();
                }
                else
                {
                    Active_GraphWindows[name].Close();
                    Active_GraphWindows.Remove(name);
                }

        }
        #endregion

        #region CSV file
        private bool CSVFirstLine = true;

        private void CSV_PutLine(IMUData data)
        {
            if (csvFileWriter != null)
            {
                if (CSVFirstLine == true)
                {
                    csvFileWriter.WriteCSVline(imuData.CsvHeader);
                    CSVFirstLine = false;
                }
                csvFileWriter.WriteCSVline(imuData.CsvData);
            }
        }

        private static bool FileInUsed(string fileName)
        {
            bool inUse = true;
            FileStream fs = null; try
            {
                fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read,
                FileShare.None);
                fs.Close();
            }
            catch
            {
                inUse = false;
            }
            return inUse;//true表示正在使用,false没有使用}
        }

        private void toolStripMenuItemStartLogging_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select File Location";
            sfd.Filter = "csv files (*.csv)|*.csv";
            sfd.OverwritePrompt = false;
            sfd.FileName = "AHRSData";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (FileInUsed(sfd.FileName) == true)
                {
                    csvFileWriter = new CsvFileWriter(sfd.FileName);
                }
                else
                {
                    MessageBox.Show("CSV 文件已经被其他程序使用");
                    return;
                }
                toolStripMenuItemStartLogging.Enabled = false;
                toolStripMenuItemStopLogging.Enabled = true;
            }
        }

        private void toolStripMenuItemStopLogging_Click(object sender, EventArgs e)
        {
            if (csvFileWriter != null)
            {
                string text;
                text = "共保存:" + csvFileWriter.roll.ToString() + "条记录\r\n" + "保存路径: " + csvFileWriter.FilePath.ToString();
                MessageBox.Show(text, "保存完成");

                toolStripMenuItemStopLogging.Enabled = false;
                csvFileWriter.CloseFile();
                csvFileWriter = null;
                CSVFirstLine = true;
            }
            toolStripMenuItemStartLogging.Enabled = true;
            toolStripMenuItemStopLogging.Enabled = false;
        }

        #endregion

        private void FormIMU_FormClosed(object sender, FormClosedEventArgs e)
        {
            toolStripMenuItemStopLogging.PerformClick();
        }

        private void toolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            // 先取消订阅，以避免多次订阅OnDataSend事件
            fmConfig.OnDataSend -= new FormIMUConfig.SendDataHandler(OnDataSend);
            fmConfig.OnDataSend += new FormIMUConfig.SendDataHandler(OnDataSend);
            fmConfig.ShowDialog();
        }

        private void thread3D()
        {
            Form3DDisplay = new Display();
            Application.Run((Form)Form3DDisplay);
            IsThread3DRunning = false;
        } 

        private void toolStripMenuItem3D_Click(object sender, EventArgs e)
        {
            if (IsThread3DRunning == false)
            {
                Thread Thread3D = new Thread(thread3D);//创建新线程  
                Thread3D.SetApartmentState(ApartmentState.STA);
                Thread3D.Start();
                IsThread3DRunning = true;
            }
        }

        private void toolStripMenuItemOsciloscope_Click(object sender, EventArgs e)
        {
            //if (IsThreadGraphicRunning == false)
            //{
            //    Thread t = new Thread(threadGraphic);//创建新线程  
            //    t.Name = "threadGraphic";
            //    t.Start();
            //    IsThreadGraphicRunning = true;
            //}
        }



    }
}
