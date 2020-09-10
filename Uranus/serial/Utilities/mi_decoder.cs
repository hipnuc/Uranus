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

        static private status state = status.kStatus_Idle;
        static List<byte> list = new List<byte>();
        static bool isR6082 = false;
        static int DATA_LEN = 0;
        public static IMUData Decode(byte[] buf)
        {
            IMUData imu = null;
            
            foreach (byte data in buf)
            {
                switch (state)
                {
                    case status.kStatus_Idle:
                        if (data == 0xA6 || data == 0xAA)
                        {
                            if(data == 0xA6)
                            {
                                isR6082 = false;
                            }

                            if (data == 0xAA)
                            {
                                isR6082 = true;
                            }
                            state = status.kStatus_Hdr;
                        }
                        break;
                    case status.kStatus_Hdr:
                        if (data == 0xA6 && isR6082 == false)
                        {
                            DATA_LEN = 24;
                            state = status.kStatus_Data;
                        }
                        else if (data == 0x00 && isR6082 == true)
                        {
                            DATA_LEN = 13;
                            state = status.kStatus_Data;
                        }
                        else
                        {
                            state = status.kStatus_Idle;
                        }

                        list.Clear();
                        break;
                    case status.kStatus_Data:
                        list.Add(data);

                        if (list.Count == DATA_LEN)
                        {
                            state = status.kStatus_Idle;

                            byte[] ctx = list.ToArray();
                            byte checkSumRecv = ctx[DATA_LEN-1];
                            byte checkSumCal = 0;

                            for (int i = 0; i < DATA_LEN-1; i++)
                            {
                                checkSumCal += ctx[i];
                            }

                            if (checkSumCal == checkSumRecv)
                            {
                                imu = new IMUData();

                                if (isR6082 == false)
                                {
                                    imu.SingleNode.Eul = new float[3];
                                    imu.SingleNode.Eul[0] = (float)(Int16)(ctx[1] + (ctx[2] << 8));
                                    imu.SingleNode.Eul[1] = (float)(Int16)(ctx[3] + (ctx[4] << 8));
                                    imu.SingleNode.Eul[2] = (float)(Int16)(ctx[5] + (ctx[6] << 8));
                                    imu.SingleNode.Eul[0] /= 100;
                                    imu.SingleNode.Eul[1] /= 100;
                                    imu.SingleNode.Eul[2] /= 100;

                                    imu.SingleNode.Gyr = new float[3];
                                    imu.SingleNode.Gyr[0] = (float)BitConverter.ToInt16(ctx, 7) / 100;
                                    imu.SingleNode.Gyr[1] = (float)BitConverter.ToInt16(ctx, 9) / 100;
                                    imu.SingleNode.Gyr[2] = (float)BitConverter.ToInt16(ctx, 11) / 100;

                                    imu.SingleNode.Acc = new float[3];
                                    imu.SingleNode.Acc[0] = (float)BitConverter.ToInt16(ctx, 13);
                                    imu.SingleNode.Acc[1] = (float)BitConverter.ToInt16(ctx, 15);
                                    imu.SingleNode.Acc[2] = (float)BitConverter.ToInt16(ctx, 17);

                                    imu.ToStringData = string.Format("Angles(PRY):").PadRight(14) + imu.SingleNode.Eul[0].ToString("f2").PadLeft(5, ' ') + " " + imu.SingleNode.Eul[1].ToString("f2").PadLeft(5, ' ') + " " + imu.SingleNode.Eul[2].ToString("f2").PadLeft(5, ' ') + "\r\n";
                                    imu.ToStringData += string.Format("加速度:").PadRight(11) + imu.SingleNode.Acc[0].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Acc[1].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Acc[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                                    imu.ToStringData += string.Format("角速度:").PadRight(11) + imu.SingleNode.Gyr[0].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Gyr[1].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Gyr[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                                }
                                else
                                {
                                    imu.SingleNode.Eul = new float[3];
                                    imu.SingleNode.Eul[0] = 0;
                                    imu.SingleNode.Eul[1] = 0;
                                    imu.SingleNode.Eul[2] = (float)(Int16)(ctx[1] + (ctx[2] << 8));
                                    imu.SingleNode.Eul[2] /= 100;

                                    imu.SingleNode.Gyr = new float[3];
                                    imu.SingleNode.Gyr[0] = 0;
                                    imu.SingleNode.Gyr[1] = 0;
                                    imu.SingleNode.Gyr[2] = (float)BitConverter.ToInt16(ctx, 3) / 100;

                                    imu.SingleNode.Acc = new float[3];
                                    imu.SingleNode.Acc[0] = (float)BitConverter.ToInt16(ctx, 5);
                                    imu.SingleNode.Acc[1] = (float)BitConverter.ToInt16(ctx, 7);
                                    imu.SingleNode.Acc[2] = (float)BitConverter.ToInt16(ctx, 9);

                                    imu.ToStringData = string.Format("Angles(PRY):").PadRight(14) + imu.SingleNode.Eul[0].ToString("f2").PadLeft(5, ' ') + " " + imu.SingleNode.Eul[1].ToString("f2").PadLeft(5, ' ') + " " + imu.SingleNode.Eul[2].ToString("f2").PadLeft(5, ' ') + "\r\n";
                                    imu.ToStringData += string.Format("加速度:").PadRight(11) + imu.SingleNode.Acc[0].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Acc[1].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Acc[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                                    imu.ToStringData += string.Format("角速度:").PadRight(11) + imu.SingleNode.Gyr[0].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Gyr[1].ToString("0").PadLeft(5, ' ') + " " + imu.SingleNode.Gyr[2].ToString("0").PadLeft(5, ' ') + "\r\n";
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
