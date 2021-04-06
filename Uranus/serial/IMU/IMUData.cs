using System;
using System.Collections.Generic;

namespace Uranus.Data
{
    public class IMUData
    {

        public struct GWINFO
        {
            public byte gwid;
            public byte node_num;
        }

        public struct Node
        {
            public byte ID;
            public UInt32 TS;
            public float[] Quat;
            public float[] Eul; /* In Roll Pitch Yaw Sequence */
            public float[] Acc;
            public float[] Gyr;
            public float[] Mag;
            public float Temperature;
            public float Prs;
        }

        /* legcy 0x71 0x72 0x75 data tag support */
        public float[,] RFQuat;
        public Int16[,] RFAcc;
        public Int16[,] RFGyr;
        public float[,] RFEul;


        public float[] Test8F;
        public List<string> CSVHeaders = new List<string>();
        public List<string> CSVData = new List<string>();
        public List<Node> RFNodeList = new List<Node>();

        /* HI226 HI229 information */
        public Node SingleNode;

        /* HI221GW information */
        public GWINFO GW; 
        public string ToStringData;

        public IMUData()
        {
        }

        public enum ItemID
        {
            kItemTest8F = 0x60,
            kItemGWSOL = 0x62, /* new packet */
            kItemID = 0x90,
            kItemIMUSOL = 0x91, /* new packet */
            kItemAccRaw = 0xA0,
            kItemGyrRaw = 0xB0,
            kItemGyrCal = 0xB1,
            kItemMagRaw = 0xC0,
            kItemRotationEular = 0xD0,
            kItemRotationQuat = 0xD1,
            kItemTemperature = 0xE0,
            kItemPressure = 0xF0,
            kItemRFQuat = 0x71,   /* 4*16 float quat */
            kItemRFEul = 0x72,
            kItemRFAcc = 0x75,
            kItemRFGyr = 0x78,
            kItemEnd = 0x00,
        };


        public override string ToString()
        {
            return ToStringData;
        }


        #region Decode 

        static public IMUData Decode(byte[] buf, int len)
        {
            IMUData imuData = new IMUData();
            imuData.GW.node_num = 8;

            imuData.ToStringData = "";
            string _CSVHeader = "";
            string _CSVData = "";

            imuData.CSVHeaders.Add("Time");
            imuData.CSVData.Add(DateTime.Now.ToString("HH-mm-ss.fff"));

            int offset = 0;
            while (offset < len)
            {
                byte cmd = buf[offset];
                switch (cmd)
                {
                    case (byte)ItemID.kItemID:
                        imuData.SingleNode.ID = buf[offset + 1];
                        offset += 2;
                        imuData.CSVHeaders.Add("ID");
                        imuData.CSVData.Add(imuData.SingleNode.ID.ToString());
                        imuData.ToStringData += string.Format("ID:{0}\r\n", imuData.SingleNode.ID.ToString());
                        break;
                    case (byte)ItemID.kItemTest8F:
                        imuData.Test8F = new float[8];
                        imuData.Test8F[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                        imuData.Test8F[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                        imuData.Test8F[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                        imuData.Test8F[3] = BitConverter.ToSingle(buf, offset + 1 + 3 * 4);
                        imuData.Test8F[4] = BitConverter.ToSingle(buf, offset + 1 + 4 * 4);
                        imuData.Test8F[5] = BitConverter.ToSingle(buf, offset + 1 + 5 * 4);
                        imuData.Test8F[6] = BitConverter.ToSingle(buf, offset + 1 + 6 * 4);
                        imuData.Test8F[7] = BitConverter.ToSingle(buf, offset + 1 + 7 * 4);

                        offset += 8 * 4 + 1;
                        imuData.ToStringData += string.Format("{8,-11}{0,5:f3},{1,5:f3},{2,5:f3},{3,5:f3}\r\n{4,16:f3},{5,5:f3},{6,5:f3},{7,5:f3}", imuData.Test8F[0], imuData.Test8F[1], imuData.Test8F[2], imuData.Test8F[3], imuData.Test8F[4], imuData.Test8F[5], imuData.Test8F[6], imuData.Test8F[7], "Test8F:");
                        break;
                    case (byte)ItemID.kItemAccRaw:
                        imuData.SingleNode.Acc = new float[3];

                        imuData.SingleNode.Acc[0] = (float)BitConverter.ToInt16(buf, offset + 1) / 1000;
                        imuData.SingleNode.Acc[1] = (float)BitConverter.ToInt16(buf, offset + 3) / 1000;
                        imuData.SingleNode.Acc[2] = (float)BitConverter.ToInt16(buf, offset + 5) / 1000;
                        offset += 7;
                        imuData.CSVHeaders.Add("AccX(G), AccY, AccZ");
                        imuData.CSVData.Add(imuData.SingleNode.Acc[0].ToString() + ',' + imuData.SingleNode.Acc[1].ToString() + ',' + imuData.SingleNode.Acc[2].ToString());
                        imuData.ToStringData += string.Format("{0,-14}{1,7:f3}{2,7:f3}{3,7:f3}\r\n", "加速度(G):", imuData.SingleNode.Acc[0], imuData.SingleNode.Acc[1], imuData.SingleNode.Acc[2]);
                        break;

                    case (byte)ItemID.kItemGyrRaw:
                    case (byte)ItemID.kItemGyrCal:
                        imuData.SingleNode.Gyr = new float[3];
                        imuData.SingleNode.Gyr[0] = (float)BitConverter.ToInt16(buf, offset + 1) / 10;
                        imuData.SingleNode.Gyr[1] = (float)BitConverter.ToInt16(buf, offset + 3) / 10;
                        imuData.SingleNode.Gyr[2] = (float)BitConverter.ToInt16(buf, offset + 5) / 10;

                        offset += 7;
                        imuData.CSVHeaders.Add("GyrX(dps), GyrY, GyrZ");
                        imuData.CSVData.Add(imuData.SingleNode.Gyr[0].ToString() + ',' + imuData.SingleNode.Gyr[1].ToString() + ',' + imuData.SingleNode.Gyr[2].ToString());
                        imuData.ToStringData += string.Format("{0,-14}{1,7:f2}{2,7:f2}{3,7:f2}\r\n", "角速度(dps):", imuData.SingleNode.Gyr[0], imuData.SingleNode.Gyr[1], imuData.SingleNode.Gyr[2]);
                        break;

                    case (byte)ItemID.kItemMagRaw:
                        imuData.SingleNode.Mag = new float[3];

                        imuData.SingleNode.Mag[0] = (float)BitConverter.ToInt16(buf, offset + 1) / 10;
                        imuData.SingleNode.Mag[1] = (float)BitConverter.ToInt16(buf, offset + 3) / 10;
                        imuData.SingleNode.Mag[2] = (float)BitConverter.ToInt16(buf, offset + 5) / 10;
                        offset += 7;
                        imuData.CSVHeaders.Add("MagX(uT), MagY, MagZ");
                        imuData.CSVData.Add(imuData.SingleNode.Mag[0].ToString() + ',' + imuData.SingleNode.Mag[1].ToString() + ',' + imuData.SingleNode.Mag[2].ToString());
                        imuData.ToStringData += string.Format("{0,-15}{1,7:f1}{2,7:f1}{3,7:f1}\r\n", "磁场(uT):", imuData.SingleNode.Mag[0], imuData.SingleNode.Mag[1], imuData.SingleNode.Mag[2]);
                        break;
                    case (byte)ItemID.kItemRotationEular:
                        imuData.SingleNode.Eul = new float[3];
                        imuData.SingleNode.Eul[1] = (float)BitConverter.ToInt16(buf, offset + 1) / 100;
                        imuData.SingleNode.Eul[0] = (float)BitConverter.ToInt16(buf, offset + 3) / 100;
                        imuData.SingleNode.Eul[2] = (float)BitConverter.ToInt16(buf, offset + 5) / 10;
                        offset += 7;
                        imuData.CSVHeaders.Add("Roll(deg), Pitch, Yaw");
                        imuData.CSVData.Add(imuData.SingleNode.Eul[0].ToString() + ',' + imuData.SingleNode.Eul[1].ToString() + ',' + imuData.SingleNode.Eul[2].ToString());
                        imuData.ToStringData += string.Format("{0,-14}{1,7:f2}{2,7:f2}{3,7:f2}\r\n", "欧拉角RPY(deg):", imuData.SingleNode.Eul[0], imuData.SingleNode.Eul[1], imuData.SingleNode.Eul[2]);
                        break;
                    case (byte)ItemID.kItemRotationQuat:
                        imuData.SingleNode.Quat = new float[4];
                        imuData.SingleNode.Quat[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                        imuData.SingleNode.Quat[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                        imuData.SingleNode.Quat[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                        imuData.SingleNode.Quat[3] = BitConverter.ToSingle(buf, offset + 1 + 3 * 4);
                        offset += 17;
                        imuData.CSVHeaders.Add("Q(W), Q(X), Q(Y), Q(Z)");
                        imuData.CSVData.Add(imuData.SingleNode.Quat[0].ToString() + ',' + imuData.SingleNode.Quat[1].ToString() + ',' + imuData.SingleNode.Quat[2].ToString() + ',' + imuData.SingleNode.Quat[3].ToString());
                        imuData.ToStringData += string.Format("Q(WXYZ):").PadRight(10) + imuData.SingleNode.Quat[0].ToString("f3").PadLeft(5, ' ') + " " + imuData.SingleNode.Quat[1].ToString("f3").PadLeft(5, ' ') + " " + imuData.SingleNode.Quat[2].ToString("f3").PadLeft(5, ' ') + " " + imuData.SingleNode.Quat[3].ToString("f3").PadLeft(5, ' ') + "\r\n";
                        break;

                    case (byte)ItemID.kItemPressure:
                        imuData.SingleNode.Prs = BitConverter.ToSingle(buf, offset + 1);
                        offset += 5;
                        imuData.CSVHeaders.Add("Pressure");
                        imuData.CSVData.Add(imuData.SingleNode.Prs.ToString());
                        imuData.ToStringData += string.Format("{0,-14}{1,6:f3}\r\n", "大气压:", imuData.SingleNode.Prs);
                        break;
                    case (byte)ItemID.kItemTemperature:
                        imuData.SingleNode.Temperature = BitConverter.ToSingle(buf, offset + 1);
                        offset += 5;
                        imuData.CSVHeaders.Add("Temperature");
                        imuData.CSVData.Add(imuData.SingleNode.Temperature.ToString());
                        imuData.ToStringData += string.Format("{0,-14}{1,6:f3}\r\n", "温度:", imuData.SingleNode.Temperature);
                        break;
                    case (byte)ItemID.kItemRFQuat:
                        imuData.RFQuat = new float[imuData.GW.node_num, 4];
                        imuData.ToStringData += string.Format("RFQuat: W X Y Z\r\n");
                        _CSVHeader = "";
                        _CSVData = "";
                        for (int i = 0; i < imuData.GW.node_num; i++)
                        {
                            imuData.RFQuat[i, 0] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 0 * 4);
                            imuData.RFQuat[i, 1] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 1 * 4);
                            imuData.RFQuat[i, 2] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 2 * 4);
                            imuData.RFQuat[i, 3] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 3 * 4);
                            imuData.ToStringData += "[" + i.ToString("d2") + "]:" + imuData.RFQuat[i, 0].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFQuat[i, 1].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFQuat[i, 2].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFQuat[i, 3].ToString("f3").PadLeft(5, ' ') + "\r\n";

                            _CSVHeader += string.Format("W{0}, X{0}, Y{0}, Z{0},", i);
                            _CSVData += imuData.RFQuat[i, 0].ToString("f3") + "," + imuData.RFQuat[i, 1].ToString("f3") + "," + imuData.RFQuat[i, 2].ToString("f3") + "," + imuData.RFQuat[i, 3].ToString("f3") + ",";
                        }

                        offset += 1 + 16 * imuData.GW.node_num;
                        imuData.CSVHeaders.Add(_CSVHeader);
                        imuData.CSVData.Add(_CSVData);
                        break;
                    case (byte)ItemID.kItemRFAcc:
                        imuData.RFAcc = new Int16[imuData.GW.node_num, 3];
                        imuData.ToStringData += string.Format("RFAcc: X Y Z\r\n");
                        _CSVHeader = "";
                        _CSVData = "";

                        for (int i = 0; i < imuData.GW.node_num; i++)
                        {
                            imuData.RFAcc[i, 0] = (Int16)(buf[offset + 1 + 6 * i] + (buf[offset + 2 + 6 * i] << 8));
                            imuData.RFAcc[i, 1] = (Int16)(buf[offset + 3 + 6 * i] + (buf[offset + 4 + 6 * i] << 8));
                            imuData.RFAcc[i, 2] = (Int16)(buf[offset + 5 + 6 * i] + (buf[offset + 6 + 6 * i] << 8));

                            _CSVHeader += string.Format("X{0}, Y{0}, Z{0},", i);
                            _CSVData += imuData.RFAcc[i, 0].ToString("0") + "," + imuData.RFAcc[i, 1].ToString("0") + "," + imuData.RFAcc[i, 2].ToString("0") + ",";

                            imuData.ToStringData += "[" + i.ToString("d2") + "]:" + imuData.RFAcc[i, 0].ToString("0").PadLeft(5, ' ') + " " + imuData.RFAcc[i, 1].ToString("0").PadLeft(5, ' ') + " " + imuData.RFAcc[i, 2].ToString("0").PadLeft(5, ' ') + " " + "\r\n";
                        }
                        imuData.CSVHeaders.Add(_CSVHeader);
                        imuData.CSVData.Add(_CSVData);
                        offset += 1 + 6 * imuData.GW.node_num;
                        break;
                    case (byte)ItemID.kItemRFGyr:
                        imuData.RFGyr = new Int16[imuData.GW.node_num, 3];
                        imuData.ToStringData += string.Format("RFGyrCalibrated: X Y Z\r\n");
                        _CSVHeader = "";
                        _CSVData = "";

                        for (int i = 0; i < imuData.GW.node_num; i++)
                        {
                            imuData.RFGyr[i, 0] = (Int16)(buf[offset + 1 + 6 * i] + (buf[offset + 2 + 6 * i] << 8));
                            imuData.RFGyr[i, 1] = (Int16)(buf[offset + 3 + 6 * i] + (buf[offset + 4 + 6 * i] << 8));
                            imuData.RFGyr[i, 2] = (Int16)(buf[offset + 5 + 6 * i] + (buf[offset + 6 + 6 * i] << 8));

                            _CSVHeader += string.Format("X{0}, Y{0}, Z{0},", i);
                            _CSVData += imuData.RFGyr[i, 0].ToString("0") + "," + imuData.RFGyr[i, 1].ToString("0") + "," + imuData.RFGyr[i, 2].ToString("0") + ",";

                            imuData.ToStringData += "[" + i.ToString("d2") + "]:" + imuData.RFGyr[i, 0].ToString("0").PadLeft(5, ' ') + " " + imuData.RFGyr[i, 1].ToString("0").PadLeft(5, ' ') + " " + imuData.RFGyr[i, 2].ToString("0").PadLeft(5, ' ') + " " + "\r\n";
                        }
                        imuData.CSVHeaders.Add(_CSVHeader);
                        imuData.CSVData.Add(_CSVData);
                        offset += 1 + 6 * imuData.GW.node_num;
                        break;
                    case (byte)ItemID.kItemRFEul:
                        imuData.RFEul = new float[imuData.GW.node_num, 3];
                        imuData.ToStringData += string.Format("RFEul: P R Y\r\n");
                        _CSVHeader = "";
                        _CSVData = "";

                        for (int i = 0; i < imuData.GW.node_num; i++)
                        {

                            imuData.RFEul[i, 0] = (float)(Int16)(buf[6 * i + offset + 1] + (buf[6 * i + offset + 2] << 8)) / 100;
                            imuData.RFEul[i, 1] = (float)(Int16)(buf[6 * i + offset + 3] + (buf[6 * i + offset + 4] << 8)) / 100;
                            imuData.RFEul[i, 2] = (float)(Int16)(buf[6 * i + offset + 5] + (buf[6 * i + offset + 6] << 8)) / 10;

                            imuData.ToStringData += "[" + i.ToString("d2") + "]:" + imuData.RFEul[i, 0].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFEul[i, 1].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFEul[i, 2].ToString("f3").PadLeft(5, ' ') + "\r\n";

                            _CSVHeader += string.Format("P{0}, R{0}, Y{0},", i);
                            _CSVData += imuData.RFEul[i, 0].ToString("f3") + "," + imuData.RFEul[i, 1].ToString("f3") + "," + imuData.RFEul[i, 2].ToString("f3") + ",";
                        }

                        offset += 1 + 6 * imuData.GW.node_num;
                        imuData.CSVHeaders.Add(_CSVHeader);
                        imuData.CSVData.Add(_CSVData);
                        break;
                    case (byte)ItemID.kItemIMUSOL: /* new data */
                        imuData.SingleNode.Acc = new float[3];
                        imuData.SingleNode.Gyr = new float[3];
                        imuData.SingleNode.Mag = new float[3];
                        imuData.SingleNode.Quat = new float[4];
                        imuData.SingleNode.Eul = new float[3];

                        imuData.SingleNode.ID = buf[offset + 1];
                        imuData.SingleNode.TS = BitConverter.ToUInt32(buf, offset + 8);

                        imuData.SingleNode.Acc[0] = (float)BitConverter.ToSingle(buf, offset + 12 + 0 * 4);
                        imuData.SingleNode.Acc[1] = (float)BitConverter.ToSingle(buf, offset + 12 + 1 * 4);
                        imuData.SingleNode.Acc[2] = (float)BitConverter.ToSingle(buf, offset + 12 + 2 * 4);
                        imuData.SingleNode.Gyr[0] = (float)BitConverter.ToSingle(buf, offset + 24 + 0 * 4);
                        imuData.SingleNode.Gyr[1] = (float)BitConverter.ToSingle(buf, offset + 24 + 1 * 4);
                        imuData.SingleNode.Gyr[2] = (float)BitConverter.ToSingle(buf, offset + 24 + 2 * 4);
                        imuData.SingleNode.Mag[0] = (float)BitConverter.ToSingle(buf, offset + 36 + 0 * 4);
                        imuData.SingleNode.Mag[1] = (float)BitConverter.ToSingle(buf, offset + 36 + 1 * 4);
                        imuData.SingleNode.Mag[2] = (float)BitConverter.ToSingle(buf, offset + 36 + 2 * 4);
                        imuData.SingleNode.Eul[0] = (float)BitConverter.ToSingle(buf, offset + 48 + 0 * 4);
                        imuData.SingleNode.Eul[1] = (float)BitConverter.ToSingle(buf, offset + 48 + 1 * 4);
                        imuData.SingleNode.Eul[2] = (float)BitConverter.ToSingle(buf, offset + 48 + 2 * 4);
                        imuData.SingleNode.Quat[0] = (float)BitConverter.ToSingle(buf, offset + 60 + 0 * 4);
                        imuData.SingleNode.Quat[1] = (float)BitConverter.ToSingle(buf, offset + 60 + 1 * 4);
                        imuData.SingleNode.Quat[2] = (float)BitConverter.ToSingle(buf, offset + 60 + 2 * 4);
                        imuData.SingleNode.Quat[3] = (float)BitConverter.ToSingle(buf, offset + 60 + 3 * 4);

                        imuData.ToStringData += string.Format("ID:{0}\r\n", imuData.SingleNode.ID);
                        imuData.ToStringData += string.Format("TimeStamp:{0}\r\n", imuData.SingleNode.TS);
                        imuData.ToStringData += string.Format("{0,-8}{1,7:f3}{2,7:f3}{3,7:f3}\r\n", "Acc:     ", imuData.SingleNode.Acc[0], imuData.SingleNode.Acc[1], imuData.SingleNode.Acc[2]);
                        imuData.ToStringData += string.Format("{0,-8}{1,7:f2}{2,7:f2}{3,7:f2}\r\n", "Gyr:     ", imuData.SingleNode.Gyr[0], imuData.SingleNode.Gyr[1], imuData.SingleNode.Gyr[2]);
                        imuData.ToStringData += string.Format("{0,-8}{1,7:f2}{2,7:f2}{3,7:f2}\r\n", "Mag:     ", imuData.SingleNode.Mag[0], imuData.SingleNode.Mag[1], imuData.SingleNode.Mag[2]);
                        imuData.ToStringData += string.Format("{0,-8}{1,7:f2}{2,7:f2}{3,7:f2}\r\n", "Eul(RPY):", imuData.SingleNode.Eul[0], imuData.SingleNode.Eul[1], imuData.SingleNode.Eul[2]);
                        imuData.ToStringData += string.Format("{0,-8}{1,7:f3}{2,7:f3}{3,7:f3}{4,7:f3}\r\n", "Quat:", imuData.SingleNode.Quat[0], imuData.SingleNode.Quat[1], imuData.SingleNode.Quat[2], imuData.SingleNode.Quat[3]);

                        _CSVHeader += string.Format("TimeStamp, AccX, AccY, AccZ, GyrX, GyrY, GyrZ, MagX, MagY, MagZ, Roll, Pitch, Yaw, Qw, Qx, Qy, Qz\r\n");
                        _CSVData += string.Format("{0}, {1:f3}, {2:f3}, {3:f3}, {4:f2}, {5:f2}, {6:f2}, {7:f3}, {8:f3}, {9:f3}, {10:f2}, {11:f2}, {12:f2}, {13:f3}, {14:f3}, {15:f3}, {16:f3}", imuData.SingleNode.TS, imuData.SingleNode.Acc[0], imuData.SingleNode.Acc[1], imuData.SingleNode.Acc[2], imuData.SingleNode.Gyr[0], imuData.SingleNode.Gyr[1], imuData.SingleNode.Gyr[2], imuData.SingleNode.Mag[0], imuData.SingleNode.Mag[1], imuData.SingleNode.Mag[2], imuData.SingleNode.Eul[0], imuData.SingleNode.Eul[1], imuData.SingleNode.Eul[2], imuData.SingleNode.Quat[0], imuData.SingleNode.Quat[1], imuData.SingleNode.Quat[2], imuData.SingleNode.Quat[3]);
                        imuData.CSVHeaders.Add(_CSVHeader);
                        imuData.CSVData.Add(_CSVData);
                        offset += 76;
                        break;
                    case (byte)ItemID.kItemGWSOL: /* new data */
                        imuData.GW.gwid = buf[1];
                        imuData.GW.node_num = buf[2];

                        imuData.ToStringData += string.Format("GATEWAY:{0} CONNECTED:{1}\r\n", imuData.GW.gwid, imuData.GW.node_num);

                        for (int i = 0; i < imuData.GW.node_num; i++)
                        {
                            Node n = new Node();
                            n.Quat = new float[4];
                            n.Gyr = new float[3];
                            n.Mag = new float[3];
                            n.Acc = new float[3];
                            n.Eul = new float[3];

                            n.ID = buf[9 + i * 76];
                            n.Acc[0] = BitConverter.ToSingle(buf, 20 + 76 * i + 0 * 4);
                            n.Acc[1] = BitConverter.ToSingle(buf, 20 + 76 * i + 1 * 4);
                            n.Acc[2] = BitConverter.ToSingle(buf, 20 + 76 * i + 2 * 4);

                            n.Gyr[0] = BitConverter.ToSingle(buf, 32 + 76 * i + 0 * 4);
                            n.Gyr[1] = BitConverter.ToSingle(buf, 32 + 76 * i + 1 * 4);
                            n.Gyr[2] = BitConverter.ToSingle(buf, 32 + 76 * i + 2 * 4);

                            n.Mag[0] = BitConverter.ToSingle(buf, 44 + 76 * i + 0 * 4);
                            n.Mag[1] = BitConverter.ToSingle(buf, 44 + 76 * i + 1 * 4);
                            n.Mag[2] = BitConverter.ToSingle(buf, 44 + 76 * i + 2 * 4);

                            n.Eul[0] = BitConverter.ToSingle(buf, 56 + 76 * i + 0 * 4);
                            n.Eul[1] = BitConverter.ToSingle(buf, 56 + 76 * i + 1 * 4);
                            n.Eul[2] = BitConverter.ToSingle(buf, 56 + 76 * i + 2 * 4);

                            n.Quat[0] = BitConverter.ToSingle(buf, 68 + 76 * i + 0 * 4);
                            n.Quat[1] = BitConverter.ToSingle(buf, 68 + 76 * i + 1 * 4);
                            n.Quat[2] = BitConverter.ToSingle(buf, 68 + 76 * i + 2 * 4);
                            n.Quat[3] = BitConverter.ToSingle(buf, 68 + 76 * i + 3 * 4);

                            n.Prs = 0;
                            n.TS = 0;

                            imuData.ToStringData += string.Format("Node[{0}]:  ", n.ID);
                            imuData.ToStringData += string.Format("{0,0}{1,5:f2} {2,5:f2} {3,5:f2}\r\n", "Eul:", n.Eul[0], n.Eul[1], n.Eul[2]);
                            imuData.ToStringData += string.Format("{0,14}{1,5:f3} {2,5:f3} {3,5:f3} {4,5:f3}\r\n", "Quat:", n.Quat[0], n.Quat[1], n.Quat[2], n.Quat[3]);

                            _CSVHeader += string.Format("Roll{0}, Pitch{0}, Yaw{0}, W{0}, X{0}, Y{0}, Z{0}, AccX{0}, AccY{0}, AccZ{0}, GyrX{0}, GyrY{0}, GyrZ{0}, MagX{0}, MagY{0}, MagZ{0}", n.ID);
                            _CSVData += string.Format("{0:f2}, {1:f2}, {2:f2}, {3:f3}, {4:f3}, {5:f3}, {6:f3}, {7:f3}, {8:f3}, {9:f3}, {10:f3}, {11:f3}, {12:f3}, {13:f3}, {14:f3}, {15:f3},", n.Eul[0], n.Eul[1], n.Eul[2], n.Quat[0], n.Quat[1], n.Quat[2], n.Quat[3], n.Acc[0], n.Acc[1], n.Acc[2], n.Gyr[0], n.Gyr[1], n.Gyr[2], n.Mag[0], n.Mag[1], n.Mag[2]);

                            imuData.RFNodeList.Add(n);
                        }

                        imuData.CSVHeaders.Add(_CSVHeader);
                        imuData.CSVData.Add(_CSVData);
                        offset += 8 + 76 * imuData.GW.node_num;
                        break;
                    default:
                        // error has been occured. may be a unspported Items
                        offset++;
                        break;
                }
            }

            return imuData;
        }

        #endregion

    }
}
