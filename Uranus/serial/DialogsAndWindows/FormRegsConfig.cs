using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using Uranus.Utilities;

namespace Uranus.DialogsAndWindows
{
    public partial class FormRegsConfig : BaseForm
    {
        public Connection connection;
        private Queue<byte> RxFIFO = new Queue<byte>();


        public FormRegsConfig(Connection c)
        {
            InitializeComponent();
            connection = c;
            if (connection != null)
            {
                connection.OnReceviedData += new Connection.ReceivedDataEventHandler(Input);
            }
        }

        #region data procssing 
        void debug_msg(string hdr, byte[] data)
        {
            string debug_msg = hdr;
            for (int i = 0; i < data.Length; i++)
            {
                debug_msg += data[i].ToString("X2") + " ";
            }
            listBox1.Items.Add(debug_msg);
        }

        // waiting to recevie data
        byte[] WaitData(int size, int TimeOut)
        {
            int time_out = 0;
            while (RxFIFO.Count < size)
            {
                time_out++;
                Thread.Sleep(1);
                Application.DoEvents();
                if (time_out == TimeOut)
                {
                    break;
                }
            }
            debug_msg("< ", RxFIFO.ToArray());
            return RxFIFO.ToArray();
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

        void Input(byte[] buffer, int index, int count)
        {
            if (RxFIFO.Count < 4096)
            {
                foreach (byte c in buffer)
                {
                    RxFIFO.Enqueue(c);
                }
            }
        }

        enum FramePacketType
        {
            kFramingPacketType_Ack = 0xA1,
            kFramingPacketType_Nak = 0xA2,
            kFramingPacketType_AckAbort = 0xA3,
            kFramingPacketType_Command = 0xA4,
            kFramingPacketType_Data = 0xA5,
            kFramingPacketType_Ping = 0xA6,
            kFramingPacketType_PingResponse = 0xA7,
        };


        ushort crc16(byte[] data, int start, int length, ushort poly)
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

        // send data
        bool InjectCommand(byte[] cmd)
        {
            bool ret;
            RxFIFO.Clear();
            ret = OnDataSend(cmd, 0, cmd.Length);
            debug_msg("> ", cmd);

            return ret;
        }

        // encode raw data into a framing packet
        byte[] CreateReadRegsPacket(UInt16 addr, int size)
        {
            List<byte> Data = new List<byte>();
            Data.Add(0x5A);
            Data.Add((byte)FramePacketType.kFramingPacketType_Command);

            byte[] hdr = new byte[4];
            hdr[0] = 0x80;
            hdr[1] = ((byte)((addr >> 0) & 0xFF));
            hdr[2] = ((byte)((addr >> 8) & 0xFF));
            hdr[3] = (byte)size;

            Data.Add((byte)((hdr.Length >> 0) & 0xFF));
            Data.Add((byte)((hdr.Length >> 8) & 0xFF));
            foreach (byte d in hdr)
            {
                Data.Add(d);
            }
            byte[] crc = BitConverter.GetBytes(crc16(Data.ToArray(), 0, Data.Count, 0x1021));
            Data.Insert(4, crc[0]);
            Data.Insert(5, crc[1]);
            return Data.ToArray();
        }

        // encode raw data into a framing packet
        byte[] CreateWriteRegsPacket(UInt16 addr, int size, byte[] buf)
        {
            List<byte> Data = new List<byte>();
            Data.Add(0x5A);
            Data.Add((byte)FramePacketType.kFramingPacketType_Command);

            byte[] hdr = new byte[4];
            hdr[0] = 0x00;
            hdr[1] = ((byte)((addr >> 0) & 0xFF));
            hdr[2] = ((byte)((addr >> 8) & 0xFF));
            hdr[3] = (byte)size;


            Data.Add((byte)(((hdr.Length + buf.Length) >> 0) & 0xFF));
            Data.Add((byte)(((hdr.Length + buf.Length) >> 8) & 0xFF));
            foreach (byte d in hdr)
            {
                Data.Add(d);
            }

            foreach (byte d in buf)
            {
                Data.Add(d);
            }

            byte[] crc = BitConverter.GetBytes(crc16(Data.ToArray(), 0, Data.Count, 0x1021));
            Data.Insert(4, crc[0]);
            Data.Insert(5, crc[1]);
            return Data.ToArray();
        }
        #endregion

        private void buttonRead_Click(object sender, EventArgs e)
        {
            bool ret;
            UInt16 addr = Convert.ToUInt16(textBoxReadAddr.Text, 16);
            UInt16 size = Convert.ToUInt16(textBoxReadSize.Text);

            ret = InjectCommand(CreateReadRegsPacket(addr, size));
            if (ret == false)
            {
                Console.WriteLine("Serial IO Error");
                return;
            }

            byte[] Resp = WaitData(6 + size*4, 50);
            uint reg_data = 0;
            Single freg_data = 0;
            if (Resp.Length == (6 + size * 4) && Resp[0] == 0x5A)
            {
                for (int i = 0; i < size; i++)
                {
                    
                    reg_data = BitConverter.ToUInt32(Resp, 6 + i * 4);
                    freg_data = BitConverter.ToSingle(Resp, 6 + i * 4);
                    listBox1.Items.Add(reg_data.ToString() + "(0x" + reg_data.ToString("X8") + ")" + "(" + freg_data.ToString() + ")" );

                }
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            bool ret;
            UInt16 addr = Convert.ToUInt16(textBoxReadAddr.Text, 16);
            UInt16 size = Convert.ToUInt16(textBoxReadSize.Text);
            UInt32 data = Convert.ToUInt32(textBoxData.Text, 16);

            ret = InjectCommand(CreateWriteRegsPacket(addr, size, BitConverter.GetBytes(data)));
            if (ret == false)
            {
                Console.WriteLine("Serial IO Error");
                return;
            }

            byte[] Resp = WaitData(2, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
