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
using Uranus.Utilities;
using Uranus.Data;
using Uranus.DialogsAndWindows;

namespace Uranus.DialogsAndWindows
{
    public partial class FormIMU : BaseForm
    {
        Connection connection;
        private KbootPacketDecoder KbootDecoder = new KbootPacketDecoder();
        private IMUData imuData = new IMUData();
        private SampleCounter SampleCounter = new SampleCounter();
        private FormIMUConfig fmConfig = new FormIMUConfig();
        private Dictionary<string, GrapicWindowForm> Active_GraphWindows = new Dictionary<string, GrapicWindowForm>();

        Thread Thread3D;
        Form3DView Form3DDisplay = null;
        private System.Windows.Forms.Timer formUpdateTimer = new System.Windows.Forms.Timer();

        public FormIMU(Connection c)
        {
            InitializeComponent();
            connection = c;
            if (connection != null)
            {
                connection.OnReceviedData += new Connection.ReceivedDataEventHandler(ConnectionDataReceived);
                KbootDecoder.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(KootPacketReceived);
            }
        }

        bool OnDataSend(byte[] buffer, int index, int count)
        {
            if (connection != null)
            {
                return connection.Send(buffer, index, count);
            }
            else
            {
                return false;
            }
        }

        private void ConnectionDataReceived(byte[] buffer, int index, int count)
        {
            fmConfig.PutRawData(buffer);
            KbootDecoder.Input(buffer);
        }

        private void FormIMU_Load(object sender, EventArgs e)
        {
            formUpdateTimer.Interval = 25;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();
        }


        private void ReflashData(IMUData data)
        {
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

                labelRawData.Text = imuData.ToString();
                if (imuData.EulerAngles != null)
                {
                    attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(-(double)imuData.EulerAngles[0], (double)imuData.EulerAngles[1]);

                    int aircraftHeading = 0;
                    try
                    {
                         aircraftHeading = Convert.ToInt16(imuData.EulerAngles[2]);
                    }
                    catch
                    {
                    }

                    if (aircraftHeading < 0)
                    {
                        aircraftHeading += 360;
                    }
                    headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(aircraftHeading);
                }

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
            if (Form3DDisplay != null)
            {
                Form3DDisplay.SetIMUData(data);
            }

            fmConfig.PutPacket(this, data);
            if (data.GyoRaw != null)
            {
                AddGraphData("Gyroscope", DateTime.Now, 0, data.GyoRaw[0]);
                AddGraphData("Gyroscope", DateTime.Now, 1, data.GyoRaw[1]);
                AddGraphData("Gyroscope", DateTime.Now, 2, data.GyoRaw[2]);
            }

            if (data.AccRaw != null)
            {
                AddGraphData("Accelerometer", DateTime.Now, 0, data.AccRaw[0]);
                AddGraphData("Accelerometer", DateTime.Now, 1, data.AccRaw[1]);
                AddGraphData("Accelerometer", DateTime.Now, 2, data.AccRaw[2]);
            }

            if (data.MagRaw != null)
            {
                AddGraphData("Magnetometer", DateTime.Now, 0, data.MagRaw[0]);
                AddGraphData("Magnetometer", DateTime.Now, 1, data.MagRaw[1]);
                AddGraphData("Magnetometer", DateTime.Now, 2, data.MagRaw[2]);
            }

            if (data.EulerAngles != null)
            {
                AddGraphData("Euler Angles", DateTime.Now, 0, data.EulerAngles[0]);
                AddGraphData("Euler Angles", DateTime.Now, 1, data.EulerAngles[1]);
                AddGraphData("Euler Angles", DateTime.Now, 2, data.EulerAngles[2]);
            }

        }

        private void KootPacketReceived(object sender, byte[] buf, int len)
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

        #region Graph
        private void Graph_FormClosed(object sender, FormClosedEventArgs e)
        {
            GrapicWindowForm graph = sender as GrapicWindowForm;
            Active_GraphWindows.Remove(graph.ID);
        }

        public void OpenGraph(string name)
        {
            if (DefaultGraphSettings.GetSettings(name) == null)
            {
                return;
            }

            GrapicWindowForm graph = new GrapicWindowForm(DefaultGraphSettings.GetSettings(name));
            Active_GraphWindows.Add(name, graph);

            Active_GraphWindows[name].FormClosed += Graph_FormClosed;
            Active_GraphWindows[name].Show();
        }

        public bool IsGraphActive(string name)
        {
            return Active_GraphWindows.ContainsKey(name);
        }

        public void CloseGraph(string name)
        {
            if (Active_GraphWindows.ContainsKey(name) == false)
            {
                return;
            }

            Active_GraphWindows[name].Close();
            Active_GraphWindows.Remove(name);
        }

        #endregion

        public void OpenConfigurationDialog()
        {
            // 先取消订阅，以避免多次订阅OnDataSend事件
            fmConfig.OnDataSend -= new FormIMUConfig.SendDataHandler(OnDataSend);
            fmConfig.OnDataSend += new FormIMUConfig.SendDataHandler(OnDataSend);
            fmConfig.ShowDialog();
        }


        #region 3DView
        private void thread3D()
        {
            Form3DDisplay = new Form3DView();
            Application.Run((Form)Form3DDisplay);
        } 

        public void Open3DView()
        {
                Thread3D = new Thread(thread3D);//创建新线程  
                Thread3D.SetApartmentState(ApartmentState.STA);
                Thread3D.Start();
        }

        public void Close3DView()
        {
                Thread3D.Abort();
        }
        #endregion



    }
}
