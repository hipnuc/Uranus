using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uranus.Data;

namespace Uranus.Utilities
{
    static class SxDecode
    {
        private enum status
        {
            kStatus_Idle,
            kStatus_Hdr,
            kStatus_Data,
            kStatus_Chksum
        };

        private const int DATA_LEN = 17;
        static private status state = status.kStatus_Idle;
        static List<byte> list = new List<byte>();

        public static IMUData Decode(byte[] buf)
        {
            IMUData imu = null;
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
                        if (data == 0xAA)
                        {
                            state = status.kStatus_Data;
                            list.Clear();
                        }
                        break;
                    case status.kStatus_Data:
                        list.Add(data);

                        if (list.Count == DATA_LEN)
                        {
                            state = status.kStatus_Idle;

                            byte[] ctx = list.ToArray();
                            byte checkSumRecv = ctx[16];
                            byte checkSumCal = 0;

                            for (int i = 0; i < 16; i++)
                            {
                                checkSumCal += ctx[i];
                            }

                            if (checkSumCal == checkSumRecv)
                            {
                                imu = new IMUData();

                                imu.EulerAngles = new float[3];
                                imu.EulerAngles[0] = (float)(Int16)(ctx[3] + (ctx[4] << 8)) / 100;
                                imu.EulerAngles[1] = (float)(Int16)(ctx[5] + (ctx[6] << 8)) / 100;
                                imu.EulerAngles[2] = (float)(Int16)(ctx[1] + (ctx[2] << 8)) / 100;

                                imu.AccRaw = new Int16[3];
                                imu.AccRaw[0] = (Int16)(ctx[7]  + (ctx[8]  << 8));
                                imu.AccRaw[1] = (Int16)(ctx[9]  + (ctx[10] << 8));
                                imu.AccRaw[2] = (Int16)(ctx[11] + (ctx[12] << 8));

                                if (imu.AccRaw[0] < 2000 && imu.AccRaw[0] > -2000 && imu.AccRaw[1] < 2000 && imu.AccRaw[1] > -2000 && imu.AccRaw[2] < 2000 && imu.AccRaw[2] > -2000)
                                {
                                    imu.AvailableItem = new byte[2];
                                    imu.AvailableItem[0] = 0xD0;
                                    imu.AvailableItem[1] = 0xA0;
                                    imu.StringData = string.Format("Angles(PRY):").PadRight(14) + imu.EulerAngles[0].ToString("f2").PadLeft(5, ' ') + " " + imu.EulerAngles[1].ToString("f2").PadLeft(5, ' ') + " " + imu.EulerAngles[2].ToString("f2").PadLeft(5, ' ') + "\r\n";

                                    imu.StringData += string.Format("加速度:").PadRight(11) + imu.AccRaw[0].ToString("0").PadLeft(5, ' ') + " " + imu.AccRaw[1].ToString("0").PadLeft(5, ' ') + " " + imu.AccRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                                }

                            }
                        }

                        
                        break;
                    default:
                        break;
                    
                }
            }
            return imu;
        }

    }
}
