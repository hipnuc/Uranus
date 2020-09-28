using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using Uranus.Utilities;

namespace Uranus.DialogsAndWindows
{
    public partial class FormFrimwareUpdater : BaseForm
    {
        public Connection connection;
        bool IsBootInProgress = false;
        BinReader ImagReader = new BinReader();

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
        

        #region Bootloader protocol

        private Queue<byte> RxFIFO = new Queue<byte>();
        private bool IsConnected = false;
        private int  MaxPacketSize;

        private enum FramePacketType
        {
            kFramingPacketType_Ack = 0xA1,
            kFramingPacketType_Nak = 0xA2,
            kFramingPacketType_AckAbort = 0xA3,
            kFramingPacketType_Command = 0xA4,
            kFramingPacketType_Data = 0xA5,
            kFramingPacketType_Ping = 0xA6,
            kFramingPacketType_PingResponse = 0xA7,
        };

        private enum CommandTag
        {
            FlashEraseAll = 0x01,
            FlashEraseRegion = 0x02,
            ReadMemory = 0x03,
            WriteMemory = 0x04,
            FlashSecurityDisable = 0x06,
            GetProperty = 0x07,
            Execute = 0x09,
            Reset = 0x0B,
            SetProperty = 0x0C,
            FlashEraseAllUnsecure = 0x0D,
        };

        private ushort crc16(byte[] data, int start, int length, ushort poly)
        {
            ushort crc = 0;
            while (length-- > 0)
            {
                byte bt = data[start++];
                for (int i = 0; i < 8; i++)
                {
                    bool b1 = (crc & 0x8000U) != 0;
                    bool b2 = (bt & 0x80U) != 0;
                    if (b1 != b2) crc = (ushort)((crc << 1) ^ poly);
                    else crc <<= 1;
                    bt <<= 1;
                }
            }
            return crc;
        }

        // encode raw data into a framing packet
        private byte[] WarpFramePacket(FramePacketType type, byte[] payload)
        {
            List<byte> Data = new List<byte>();
            Data.Add(0x5A);
            Data.Add((byte)type);

            if (type == FramePacketType.kFramingPacketType_Ping)
            {
                return Data.ToArray();
            }

            if (type == FramePacketType.kFramingPacketType_Ack)
            {
                return Data.ToArray();
            }
            Data.Add((byte)(payload.Length & 0xFF));
            Data.Add((byte)((payload.Length >> 8) & 0xFF));
            foreach (byte d in payload)
            {
                Data.Add(d);
            }
            byte[] crc = BitConverter.GetBytes(crc16(Data.ToArray(), 0, Data.Count, 0x1021));
            Data.Insert(4, crc[0]);
            Data.Insert(5, crc[1]);
            return Data.ToArray();
        }

        // send data
        private bool InjectCommand(byte[] cmd)
        {
            bool ret;
            RxFIFO.Clear();
            ret = OnDataSend(cmd, 0, cmd.Length);
            string a = "->  ";
            for (int i = 0; i < cmd.Length; i++)
            {
                a += "0x" + Convert.ToString(cmd[i], 16) + " ";
            }
            //Console.Write(a);
           
            return ret;
        }

        private void SendAck()
        {
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Ack, new byte[0]));
        }

        // waiting to recevie data
        private byte[] WaitData(int size, int TimeOut)
        {
            string a = "<-  ";
            int tm = 0;
            while (RxFIFO.Count != size)
            {
                tm++;
                Thread.Sleep(1);
                Application.DoEvents();
                if (tm == TimeOut)
                {
                    break;
                }
            }
            for (int i = 0; i < RxFIFO.Count; i++)
            {
                a += "0x" + Convert.ToString(RxFIFO.ToArray()[i], 16) + " ";
            }
            //Console.Write(a);
            return RxFIFO.ToArray();
        }

        private bool CmdFlashEraseAll()
        {
            bool ret = false;
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, new byte[4] { (byte)CommandTag.FlashEraseAll, 0x00, 0x00, 0x00 }));
            byte[] Resp = WaitData(20, 2500);
            if (Resp.Length == 20)
            {

                Resp = Resp.Skip(2).ToArray();
                Resp = Resp.Skip(6).ToArray();
                ret = true;
            }
            SendAck();
            return ret;
        }

        private bool CmdReset()
        {
            bool ret = false;
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, new byte[4] { (byte)CommandTag.Reset, 0x00, 0x00, 0x00 }));
            byte[] Resp = WaitData(20, 100);
            if (Resp.Length == 20)
            {
                Resp = Resp.Skip(2).ToArray();
                Resp = Resp.Skip(6).ToArray();
                ret = true;
            }
            SendAck();
            return ret;
        }

        private bool CmdUnsecure()
        {
            bool ret = false;
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, new byte[4] { (byte)CommandTag.FlashEraseAllUnsecure, 0x00, 0x00, 0x00 }));
            byte[] Resp = WaitData(20, 100);
            if (Resp.Length == 20)
            {
                Resp = Resp.Skip(2).ToArray();
                Resp = Resp.Skip(6).ToArray();
                ret = true;
            }
            SendAck();
            return ret;
        }

        private bool CmdFlashEraseRegion(int addr, int len)
        {
            bool ret = false;
            List<byte> Data = new List<byte>();
            Data.Add((byte)CommandTag.FlashEraseRegion);
            Data.Add(0x00);
            Data.Add(0x00);
            Data.Add(0x02);
            Data.AddRange(BitConverter.GetBytes(addr));
            Data.AddRange(BitConverter.GetBytes(len));
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, Data.ToArray()));
            byte[] Resp = WaitData(20, (len > 8000)?(8000):(len)); // the more len , the more time 
            if (Resp.Length == 20)
            {
                    ret = true;
            }
            SendAck();
            return ret;
        }

        private bool CmdExecute(int sp, int pc, int arg)
        {
            bool ret = false;
            List<byte> Data = new List<byte>();
            Data.Add((byte)CommandTag.Execute);
            Data.Add(0x00);
            Data.Add(0x00);
            Data.Add(0x03);
            Data.AddRange(BitConverter.GetBytes(pc));
            Data.AddRange(BitConverter.GetBytes(arg));
            Data.AddRange(BitConverter.GetBytes(sp));
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, Data.ToArray()));
            byte[] Resp = WaitData(20, 30); // the more len , the more time 
            if (Resp.Length == 20)
            {
                ret = true;
            }
            SendAck();
            return ret;
        }


        private bool CmdFlashWriteMemory(int addr, int len)
        {
            bool ret = false;
            List<byte> Data = new List<byte>();
            Data.Add((byte)CommandTag.WriteMemory);
            Data.Add(0x00);
            Data.Add(0x00);
            Data.Add(0x02);
            Data.AddRange(BitConverter.GetBytes(addr));
            Data.AddRange(BitConverter.GetBytes(len));
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, Data.ToArray()));
            byte[] Resp = WaitData(20, 100);
            if (Resp.Length == 20)
            {
                    ret = true;
            }
            SendAck();
            return ret;
        }

        private bool CmdWriteData(byte[] payload, bool IsLastPacket)
        {
            bool ret = false;
            int ExpectedDataCount = (IsLastPacket == true) ? (20) : (2);
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Data, payload));
            byte[] Resp = WaitData(ExpectedDataCount, 200);
            if (Resp.Length == ExpectedDataCount)
            {
                ret = true;
            }
            else
            {
                Console.WriteLine("CmdWriteData error:" + Resp.Length.ToString("X8"));
            }
            return ret;
        }

        private byte[] CmdGetProperty(int tag)
        {
            InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Command, new byte[] { (byte)CommandTag.GetProperty, 0x00, 0x00, 0x01, (byte)tag, 0x00, 0x00, 0x00 }));
           byte [] Resp = WaitData(20, 200);
            if (Resp.Length == 20)
            {
                Resp = Resp.Skip(8).ToArray();
                if (Resp[0] == 0xA7)  //Respond Packet
                {
                    Resp = Resp.Skip(8).ToArray();
                }
            }
            SendAck();
            return Resp;
        }

        #endregion


        public FormFrimwareUpdater(Connection c)
        {
            InitializeComponent();
            connection = c;
            if (connection != null)
            {
                connection.OnReceviedData += new Connection.ReceivedDataEventHandler(Input);
            }
        }

        private void Input(byte[] buffer, int index, int count)
        {
            if (RxFIFO.Count < 4096)
            {
                foreach (byte c in buffer)
                {
                    RxFIFO.Enqueue(c);
                }
            }
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "bin|*.bin|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "bin文件(*.bin;*.hex)|*.bin;*.hex";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                textBox1.Select(this.textBox1.TextLength, 0);
                FileInfo f = new FileInfo(openFileDialog.FileName);
                Console.WriteLine( openFileDialog.FileName);

                iniFile.Write("Bootloader", "AppPath", openFileDialog.FileName);
                ImagReader.GetDataFromFile(textBox1.Text);
                if (ImagReader.IsStartAddrGet == true)
                {
                    textBoxStartAddr.Text = "0x" + ImagReader.StartAddr.ToString("X8");
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            bool ret;

            if (IsConnected == false)
            {
                buttonConnect_Click(sender, e);
            }

            if (IsConnected == false)
            {
                Console.WriteLine("尚未连接或连接失败");
                return;
            }

            buttonUpdate.Enabled = false;

            byte[] FileData = ImagReader.GetDataFromFile(textBox1.Text);

            if (FileData == null || FileData.Length == 0 || (FileData.Length > 4*1024*1024))
            {
                Console.WriteLine("读取镜像文件失败!");
                buttonUpdate.Enabled = true;
                return;
            }

            Console.WriteLine("SP: 0x" + ImagReader.SP.ToString("X8"));
            Console.WriteLine("PC: 0x" + ImagReader.PC.ToString("X8"));

            Console.WriteLine("文件大小:" + FileData.Length);

            int StartAddr = 0;
            // erase flash
            try
            {
                StartAddr = Convert.ToInt32(textBoxStartAddr.Text, 16);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                buttonUpdate.Enabled = true;
                return;
            }

            Console.WriteLine("镜像起始地址: 0x" + StartAddr.ToString("X"));

            // check if start addr is OK
            if (StartAddr > ImagReader.PC)
            {
                MessageBox.Show("Image PC= " + string.Format("0x{0:X8}", ImagReader.PC) + "\r\nStart Address =" + string.Format("0x{0:X8}", StartAddr) + "\r\n program will run fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                buttonUpdate.Enabled = true;
                return;
            }
            
            ret = CmdFlashEraseRegion(StartAddr, FileData.Length);
            if (ret == false)
            {
                Console.WriteLine("CmdFlashErasrRegion Failed!");
                buttonUpdate.Enabled = true;
                return;
            }

            // send write memory command 
            ret = CmdFlashWriteMemory(StartAddr, (int)FileData.Length);
            if (ret == false)
            {
                Console.WriteLine("CmdFlashWriteMemory Failed!");
                buttonUpdate.Enabled = true;
                return;
            }

            // send data packet
            int ReadPointer = 0;
            int Reamin = (int)FileData.Length;
            int Precent = 0;
            int LastPrecent = 0;
            int PayloadSize;
            int retry;

            IsBootInProgress = true;
            progressBar1.Visible = true;

            while (Reamin > 0)
            {
                PayloadSize = (Reamin > MaxPacketSize) ? (MaxPacketSize) : (Reamin);

                retry = 5;
                ret = false;
                while (retry > 0 && (ret == false))
                {
                    ret = CmdWriteData(FileData.Skip((int)ReadPointer).Take((int)PayloadSize).ToArray(), (Reamin > MaxPacketSize) ? (false) : (true));
                    retry--;
                    if (retry < 4)
                    {
                        Console.WriteLine("Retry: " + retry.ToString());
                    }
                }
                if (ret == false)
                {
                    Console.WriteLine("Write Memory Failed! address: 0x" + (ReadPointer + StartAddr).ToString("X8"));
                    SendAck();
                    buttonUpdate.Enabled = true;
                    IsBootInProgress = false;
                    return;
                }

                ReadPointer += PayloadSize;
                Reamin -= PayloadSize;

                Precent = ((ReadPointer * 100) / FileData.Length);
                Application.DoEvents();
                if (LastPrecent != Precent)
                {
                    //Console.WriteLine(Precent.ToString() + "% complete");
                    progressBar1.Value = Precent;
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    LastPrecent = Precent;
                }
                Application.DoEvents();
            }
            
            SendAck();
            Console.WriteLine("编程完成");

            if (checkBox_UseReset.Checked == true)
            {
                ret = CmdReset();
                Console.WriteLine("复位" + ((ret == true) ? ("成功") : ("失败")));
                IsConnected = false;

            }

            //if (checkBox_ExecAfterDownload.Checked == true)
            //{
            //    ret = CmdExecute(ImagReader.SP, ImagReader.PC, 0);
            //    Console.WriteLine("烧录成功， 从0x" + StartAddr.ToString("X8") + "处执行" + ((ret == true) ? ("成功") : ("失败")), "升级状态");
            //    IsConnected = false;
            //}

            Application.DoEvents();
            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            buttonUpdate.Enabled = true;
            IsBootInProgress = false;
            progressBar1.Visible = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
            if (IsBootInProgress == true)
            {
                return;
            }

            bool ret = false;
            
            buttonConnect.Enabled = false;
            Application.DoEvents();

            byte[] Resp;

            ret = InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Ping, new byte[0]));
            if (ret == false)
            {
                Console.WriteLine("Serial IO Error");
                buttonConnect.Enabled = true;
                return;
            }

            Resp = WaitData(10, 20);
            if (Resp.Length == 10)
            {
                if ((Resp[0] == 0x5A) && (Resp[1] == 0xA7))
                {
                    ret = true;
                    Console.WriteLine("协议版本： " + Convert.ToChar( Resp[5]) + Resp[4].ToString() + "." + Resp[3].ToString() + "." + Resp[2].ToString());
                }
            }
            else
            {
                if (checkBox_UseAppReset.Checked == true)
                {
                    // Try AT RST
                    byte[] AppRst = System.Text.Encoding.ASCII.GetBytes("AT+RST\r\n");
                    OnDataSend(AppRst, 0, AppRst.Length);
                }

                Thread.Sleep(20);

                //  PING
                    ret = InjectCommand(WarpFramePacket(FramePacketType.kFramingPacketType_Ping, new byte[0]));
                    Resp = WaitData(10, 20);
                    if (Resp.Length == 10)
                    {
                        if ((Resp[0] == 0x5A) && (Resp[1] == 0xA7))
                        {
                            Console.WriteLine("协议版本： " + Convert.ToChar(Resp[5]) + Resp[4].ToString() + "." + Resp[3].ToString() + "." + Resp[2].ToString());
                        }
                    }
                    else
                    {
                        ret = false;
                        Console.WriteLine("Error: Connect device failed");
                    }
            }

            if (ret == true)
            {
                // get property
                Resp = CmdGetProperty(1);
                if (Resp.Length == 4)
                {
                    Console.WriteLine("程序版本:" + System.Text.Encoding.Default.GetString(Resp, 3, 1) + Resp[2].ToString() + "." + Resp[1].ToString() + "." + Resp[0].ToString());
                }

                //get max packet size
                Resp = CmdGetProperty(0x0B);
                if (Resp.Length == 4)
                {
                    MaxPacketSize =  BitConverter.ToInt32(Resp, 0);
                    Console.WriteLine("最大包长:" + MaxPacketSize.ToString());
                }


                // Flash Size
                Resp = CmdGetProperty(0x04);
                if (Resp.Length == 4)
                {
                    Console.WriteLine("Flash大小: "+ (BitConverter.ToUInt32(Resp, 0) / 1024).ToString() + "KB");
                }

                //SDID
                Resp = CmdGetProperty(0x10);
                if (Resp.Length == 4)
                {
                    Console.WriteLine("DeviceID: " + "0x" + BitConverter.ToUInt32(Resp, 0).ToString("X4"));
                }

                //Flash Sector Size
                Resp = CmdGetProperty(0x05);
                if (Resp.Length == 4)
                {
                    Console.WriteLine("Flash扇区: " + BitConverter.ToUInt32(Resp, 0).ToString());
                    ret = true;
                }
            }

            IsConnected = ret;
            Console.WriteLine("连接 " + ((ret == true)?("成功"):("失败")));
            buttonConnect.Enabled = true;
        }

        private void FormBootloader_Load(object sender, EventArgs e)
        {
            textBox1.Text = iniFile.Read("Bootloader", "AppPath");
            string StartAddr = iniFile.Read("Bootloader", "AppStartAddr");
            if (StartAddr == null || StartAddr.Length == 0)
            {
                textBoxStartAddr.Text = "0x00008000";
                iniFile.Write("Bootloader", "AppStartAddr", textBoxStartAddr.Text);
            }
            else
            {
                textBoxStartAddr.Text = StartAddr;
            }
            
            Console.SetOut(new ConsoleWriter(listBoxLog));
        }

        private void textBoxStartAddr_TextChanged(object sender, EventArgs e)
        {
            iniFile.Write("Bootloader", "AppStartAddr", textBoxStartAddr.Text);
        }



        private void listBoxLog_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                    contextMenuStrip1.Show(listBoxLog, new Point(e.X, e.Y));
            }
            listBoxLog.Refresh();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem menu = e.ClickedItem;
            if (menu.Text == "Clear")
            {
                listBoxLog.Items.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             bool ret = CmdReset();
             Console.WriteLine("复位" + ((ret == true) ? ("成功") : ("失败")));
        }

        private void buttonUnSecure_Click(object sender, EventArgs e)
        {
            bool ret = CmdUnsecure();
            Console.WriteLine("芯片解锁" + ((ret == true) ? ("成功") : ("失败")));
            ret = CmdReset();
            Console.WriteLine("复位" + ((ret == true) ? ("成功") : ("失败")));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
