using System;
using System.Windows.Forms;
using System.IO;
using Uranus.Utilities;
using Uranus.Data;

namespace Uranus.DialogsAndWindows
{
    public partial class FormDataLogger : BaseForm
    {
        private Connection connection;
        private KbootPacketDecoder kbootDecoder = new KbootPacketDecoder();
        private IMUData imuData;
        private bool hasStarted = false;
        private DateTime LogStartTime;
        private CsvFileWriter csvFileWriter = new CsvFileWriter(string.Empty);
        private bool isInCSVTitle = true;

        public FormDataLogger(Connection c)
        {
            InitializeComponent();
            connection = c;
            if (connection != null)
            {
                connection.OnReceviedData += new Connection.ReceivedDataEventHandler(Input);
            }
            kbootDecoder.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnDecoded);
        }

        private void CSV_PutLine(IMUData data)
        {
                if (isInCSVTitle == true)
                {
                    csvFileWriter.WriteCSVline(imuData.CSVHeaders.ToArray());
                    isInCSVTitle = false;
                }
                csvFileWriter.WriteCSVline(imuData.CSVData.ToArray());
        }

        void OnDecoded(object sender, byte[] data, int len)
        {
            if (hasStarted)
            {
                imuData = IMUData.Decode(data, len);
                CSV_PutLine(imuData);
            }

        }

        public void Input(byte[] buffer, int index, int count)
        {
            kbootDecoder.Input(buffer);
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

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select filelocation";
            sfd.Filter = "csv files (*.csv)|*.csv";
            sfd.OverwritePrompt = false;
            sfd.FileName = "UranusData";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = sfd.FileName;
                iniFile.Write("DataLogger", "FilePath", sfd.FileName);
                buttonStart.Enabled = true;
            }
        }

        private void StateChange(bool hasStarted)
        {
                buttonStop.Enabled = hasStarted;
                buttonStart.Enabled = !hasStarted;
                numericUpDown1.Enabled = !hasStarted;
                textBox1.Enabled = !hasStarted;
                buttonSelectFile.Enabled = !hasStarted;
                timer1.Enabled = hasStarted;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            if (FileInUsed(textBox1.Text) == true && textBox1.Text != string.Empty)
            {
                csvFileWriter.FilePath = textBox1.Text;
            }
            else
            {
                MessageBox.Show("文件路径不存在 或 已被其他程序使用");
                return;
            }

            csvFileWriter.Start();
            hasStarted = true;
            StateChange(hasStarted);

            LogStartTime = DateTime.Now;
            
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            hasStarted = false;
            StateChange(hasStarted);

            string text = "共保存:" + csvFileWriter.Row.ToString() + "条记录\r\n" + "保存路径: " + csvFileWriter.FilePath.ToString();
            MessageBox.Show(text, "保存完成");

            csvFileWriter.Stop();
            isInCSVTitle = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks - LogStartTime.Ticks);
            if (span.TotalSeconds >= Convert.ToDouble(numericUpDown1.Value))
            {
                buttonStop_Click(sender, e);
            }

            labelTime.Text = span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + " :" + span.Milliseconds.ToString("000");
        }

        private void FormDataLogger_Load(object sender, EventArgs e)
        {
            textBox1.Text = iniFile.Read("DataLogger", "FilePath");
            numericUpDown1.Value = Convert.ToDecimal(iniFile.Read("DataLogger", "Time"));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            iniFile.Write("DataLogger", "Time", numericUpDown1.Value.ToString());
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "暂停")
            {
                hasStarted = false;
                timer1.Enabled = false;
                buttonPause.Text = "继续";
            }
            else
            {
                hasStarted = true;
                timer1.Enabled = true;
                buttonPause.Text = "暂停";
            }
        }


    }
}
