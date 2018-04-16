using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uranus.Data;

namespace Uranus.Utilities
{
    class JGDecoder
    {
        private enum status
        {
            kStatus_Idle,
            kStatus_Hdr,
            kStatus_Data,
            kStatus_Chksum
        };

        private const int DataLen = 4;
        static private status state = status.kStatus_Idle;
        static List<byte> list = new List<byte>();

        static int count = 0;

        public static IMUData Decode(byte[] buf)
        {
            IMUData imu = new IMUData();
            foreach (byte data in buf)
            {
                switch (state)
                {
                    case status.kStatus_Idle:
                        if (data == 0xAA)
                        {
                            state = status.kStatus_Hdr;
                        }
                        break;
                    case status.kStatus_Hdr:
                        if (data == 0x55)
                        {
                            state = status.kStatus_Data;
                            count = 0;
                            list.Clear();
                        }
                        break;
                    case status.kStatus_Data:
                        if (count == DataLen)
                        {
                            state = status.kStatus_Idle;

                            byte[] ctx = list.ToArray();
                            byte checkSumRecv = ctx[3];
                            byte checkSumCal = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                checkSumCal += ctx[i];
                            }
                            checkSumCal += 0xAA;
                            checkSumCal += 0x55;

                            if (checkSumCal == checkSumRecv)
                            {
                                imu.GyoRaw = new Int16[3];

                                imu.GyoRaw[0] = 0;
                                imu.GyoRaw[1] = 0;
                                Int32 tem = (Int32)((ctx[0] << 16) + (ctx[1] << 8) + (ctx[2] << 0));     
                                tem -= 0x800000;
                                tem /= 100;
                                imu.GyoRaw[2] = (Int16)(tem);

                                imu.AvailableItem = new byte[1];
                                imu.AvailableItem[0] = 0xB0;

                                imu.StringData += string.Format("角速度:").PadRight(11) + imu.GyoRaw[0].ToString("0").PadLeft(5, ' ') + " " + imu.GyoRaw[1].ToString("0").PadLeft(5, ' ') + " " + imu.GyoRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                                return imu;
                            }

                        }
                        list.Add(data);
                        count++;
                        break;

                }
            }
            return null;
        }
    }
}
