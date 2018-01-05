using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uranus
{
    class KbootPacketDecoder
    {
        public delegate void KBootDecoderDataReceivedEventHandler(object sender, byte[] data, int len);
        public event KBootDecoderDataReceivedEventHandler OnPacketRecieved;

        private UInt16 MAX_PACKET_LEN = 128;
        private UInt16 DataPacketLen;
        private status state = status.kStatus_Idle;
        private byte cmd;
        private int DataCounter = 0;
        private byte[] DataPacketBuffer = new byte[256];
        private Queue<byte> RxQueue = new Queue<byte>();
        private UInt16 CRCReceived;
        private UInt16 CRCCalculated;

        private enum status
        {
            kStatus_Idle,
            kStatus_Cmd,
            kStatus_LenLow,
            kStatus_LenHigh,
            kStatus_CRCLow,
            kStatus_CRCHigh,
            kStatus_Data,
        };

        private void KbootDecodeThread()
        {
            while (true )
            {
                    lock (RxQueue)
                    {
                        for (int i = 0; i < RxQueue.Count; i++)
                        {
                            PacketDecode((byte)RxQueue.Dequeue());
                        }
                    }
                    Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Get Data.
        /// </summary>
    public void Input(byte[] buffer)
    {
        foreach (byte c in buffer)
        {
            lock (RxQueue)
            {
                RxQueue.Enqueue(c);
            }
        }
    }

        /// <summary>
        /// Constructor.
        /// </summary>
        public KbootPacketDecoder()
        {
            RxQueue.Clear();
            Thread tDecode = new Thread(new ThreadStart(KbootDecodeThread));
            tDecode.IsBackground = true;
            tDecode.Start();
        }

        private ushort crc16(ushort crc, byte[] data, int start, int length, ushort poly)
        {
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

        private void PacketDecode(byte c)
        {
            //Console.WriteLine(c.ToString("X"));
            switch (state)
            {
                case status.kStatus_Idle:
                    if (c == 0x5A)
                    {
                        state = status.kStatus_Cmd;
                    }
                    break;
                case status.kStatus_Cmd:
                    cmd = c;
                    if(cmd == 0xA5)
                    {
                        state = status.kStatus_LenLow;
                    }
                    else
                    {
                        state = status.kStatus_Idle;
                    }
                    break;
                case status.kStatus_LenLow:
                    DataPacketLen = c;
                    state = status.kStatus_LenHigh;
                    break;
                case status.kStatus_LenHigh:
                    DataPacketLen += (UInt16)(c << 8);

                    if (DataPacketLen > MAX_PACKET_LEN)
                    {
                        state = status.kStatus_Idle;
                    }
                    else
                    {
                        state = status.kStatus_CRCLow;
                    }
                    break;
                case status.kStatus_CRCLow:
                    CRCReceived = c;
                    state = status.kStatus_CRCHigh;
                    break;
                case status.kStatus_CRCHigh:
                    CRCReceived += (UInt16)(c << 8);
                    DataCounter = 0;
                    state = status.kStatus_Data;
                    break;
                case status.kStatus_Data:
                    DataPacketBuffer[DataCounter++] = c;

                    if (DataCounter >= DataPacketLen)
                    {
                        List<byte> header = new List<byte>();
                        header.Add(0x5A);
                        header.Add(0xA5);
                        header.AddRange(BitConverter.GetBytes(DataPacketLen));
                        CRCCalculated = crc16(0, header.ToArray(), 0, header.Count, 0x1021);
                        CRCCalculated = crc16(CRCCalculated, DataPacketBuffer, 0, DataPacketLen, 0x1021);

                        // CRC match, Kboot suffucally received a packet
                        if (CRCCalculated == CRCReceived)
                        {
                            if (OnPacketRecieved != null)
                            {
                                OnPacketRecieved(this, DataPacketBuffer, DataPacketLen);
                            }
                        }
                        state = status.kStatus_Idle;
                    }
                    break;
            }
        }

    }
}
