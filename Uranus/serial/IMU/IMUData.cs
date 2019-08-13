using System;
using System.Collections.Generic;

namespace Uranus.Data
{

    public class IMUData
    {
        public byte ID;
        public UInt32 UID;
        public Int16[] AccRaw;
        public Int16[] AccCalibrated;
        public Int16[] AccFiltered;
        public Int16[] AccLinear;
        public Int16[] AccGravity;
        public float[,] RFQuat;
        public Int16[,] RFAccCalibrated;
        public Int16[,] RFGyrGCalibrated;
        public float[] RFTemperature;
        public float[,] RFEul;

        public Int16[] GyoRaw;
        public Int16[] GyoCalibrated;
        public Int16[] GyoFiltered;

        public Int16[] MagRaw;
        public Int16[] MagCalibrated;
        public Int16[] MagFiltered;

        public float[] EulerAngles;
        public float[] Quaternion;
        public float[] Test8F;
        public float[] FloatIMUData;
        public float Pressure;
        public float MagNorm;
        public float Temperature;
        public byte[] AvailableItem;
        public string[] CsvHeader;
        public string[] CsvData;
        public string StringData;

        

        public IMUData()
        {
        }

        public  enum ItemID
        {
            kItemTest8F = 0x60,
            kItemIMU = 0x70,   /* 3 x 3 x sizeof(float) */
            kItemRFQuat = 0x71,   /* 4*16 float quat */
            kItemRFEul = 0x72,
            kItemRFAccCalibrated = 0x75,
            kItemRFGyrCalibrated = 0x78,
            kItemRFMagCalibrated = 0x7A,
            kItemRFTemperature = 0x7C,
            kItemExtend = 0x61,   /* extend data */
            kItemCPUTimeStamp = 0x8A,   /* uint32_t x 1  time stamp CPU tick time in ms */
            kItemID = 0x90,   /* user programed ID    size: 1 */
            kItemAccRaw = 0xA0,   /* raw acc              size: 3x2 */
            kItemAccCalibrated = 0xA1,
            kItemAccFiltered = 0xA2,
            kItemAccLinear = 0xA5,
            kItemAccGravity = 0xA6,
            kItemAccNorm = 0xA8,
            kItemGyrRaw = 0xB0,   /* raw gyro             size: 3x2 */
            kItemGyrCalibrated = 0xB1,
            kItemGyrFiltered = 0xB2,
            kItemGyrNorm = 0xB8,
            kItemMagRaw = 0xC0,   /* raw mag              size: 3x2 */
            kItemMagCalibrated = 0xC1,
            kItemMagFiltered = 0xC2,
            kItemRotationEular = 0xD0,   /* eular angle          size:3x2 */
            kItemRotationEular2 = 0xD9,   /* new eular angle      size:3x4 */
            kItemRotationQuat = 0xD1,   /* att q,               size:4x4 */
            kItemTemperature = 0xE0,
            kItemPressure = 0xF0,   /* pressure             size:1x4 */
            kItemEnd = 0x00,
        };

        public override string ToString()
        {
            return StringData;
        } 


#region Decode 

    static public IMUData Decode(byte[] buf, int len)
    {
        int rf_cnt = 8; /* default RF device cnt */
        IMUData imuData = new IMUData();
        List<byte> AvailableItem = new List<byte>();
        List<string> csv_headers = new List<string>();
        List<string> csv_data = new List<string>();
        string string_data = string.Empty;

        string _csv_header = "";
        string _csv_data = "";

        csv_headers.Add("Time");
        csv_data.Add(DateTime.Now.ToString("HH-mm-ss.fff"));

        int offset = 0;
        while (offset < len)
        {
            byte cmd = buf[offset];
            switch (cmd)
            {
                case (byte)ItemID.kItemID:
                    imuData.ID = buf[offset + 1];
                    offset += 2;
                    AvailableItem.Add( cmd);
                    csv_headers.Add("ID");
                    csv_data.Add(imuData.ID.ToString());
                    string_data += string.Format("ID:{0}\r\n", imuData.ID.ToString());
                    break;

                case (byte)ItemID.kItemExtend:
                    rf_cnt = buf[2 + 1];
                    offset += 3 + 1;
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

                    offset += 8*4 + 1;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Test8F[0], Test8F[1], Test8F[2], Test8F[3], Test8F[4], Test8F[5], Test8F[6], Test8F[7]");
                    csv_data.Add(imuData.Test8F[0].ToString() + ',' + imuData.Test8F[1].ToString() + ',' + imuData.Test8F[2].ToString() + ',' + imuData.Test8F[3].ToString() +  ',' + imuData.Test8F[4].ToString() +  ',' + imuData.Test8F[5].ToString() + ',' +  imuData.Test8F[6].ToString() +  ',' + imuData.Test8F[7].ToString());

                    string_data += string.Format("Test8F").PadRight(10) + imuData.Test8F[0].ToString("f3").PadLeft(5, ' ') + " " + imuData.Test8F[1].ToString("f3").PadLeft(5, ' ') + " " + imuData.Test8F[2].ToString("f3").PadLeft(5, ' ') + " " + imuData.Test8F[3].ToString("f3").PadLeft(5, ' ') + "\r\n" + imuData.Test8F[4].ToString("f3").PadLeft(15, ' ') + " " + imuData.Test8F[5].ToString("f3").PadLeft(5, ' ') + " " + imuData.Test8F[6].ToString("f3").PadLeft(5, ' ') +" " +  imuData.Test8F[7].ToString("f3").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemIMU:
                    imuData.FloatIMUData = new float[3*3];
                    imuData.FloatIMUData[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                    imuData.FloatIMUData[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                    imuData.FloatIMUData[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                    imuData.FloatIMUData[3] = BitConverter.ToSingle(buf, offset + 1 + 3 * 4);
                    imuData.FloatIMUData[4] = BitConverter.ToSingle(buf, offset + 1 + 4 * 4);
                    imuData.FloatIMUData[5] = BitConverter.ToSingle(buf, offset + 1 + 5 * 4);
                    imuData.FloatIMUData[6] = BitConverter.ToSingle(buf, offset + 1 + 6 * 4);
                    imuData.FloatIMUData[7] = BitConverter.ToSingle(buf, offset + 1 + 7 * 4);
                    imuData.FloatIMUData[8] = BitConverter.ToSingle(buf, offset + 1 + 8 * 4);
                    offset += 3 * 3 * 4 + 1;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccX,Y,Z,GyoX,Y,Z,MagX,Y,Z");
                    csv_data.Add(imuData.FloatIMUData[0].ToString() + ',' + imuData.FloatIMUData[1].ToString() + ',' + imuData.FloatIMUData[2].ToString() + ',' + imuData.FloatIMUData[3].ToString() + ',' + imuData.FloatIMUData[4].ToString() + ',' + imuData.FloatIMUData[5].ToString() + ',' + imuData.FloatIMUData[6].ToString() + ',' + imuData.FloatIMUData[7].ToString() + ',' + imuData.FloatIMUData[8].ToString());
                    string_data += string.Format("Acc:").PadRight(10) + imuData.FloatIMUData[0].ToString("f3").PadLeft(8, ' ') + " " + imuData.FloatIMUData[1].ToString("f3").PadLeft(8, ' ') + " " + imuData.FloatIMUData[2].ToString("f3").PadLeft(8, ' ') + "\r\n" +
                                              string.Format("Gyo:").PadRight(10) + imuData.FloatIMUData[3].ToString("f3").PadLeft(8, ' ') + " " + imuData.FloatIMUData[4].ToString("f3").PadLeft(8, ' ') + " " + imuData.FloatIMUData[5].ToString("f3").PadLeft(8, ' ') + "\r\n" +
                                              string.Format("Mag:").PadRight(10) + imuData.FloatIMUData[6].ToString("f3").PadLeft(8, ' ') + " " + imuData.FloatIMUData[7].ToString("f3").PadLeft(8, ' ') + " " + imuData.FloatIMUData[8].ToString("f3").PadLeft(8, ' ') + "\r\n";
                    break;


                case (byte)ItemID.kItemAccRaw:
                    imuData.AccRaw = new Int16[3];
                    imuData.AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccRawX, AccRawY, AccRawZ");
                    csv_data.Add(imuData.AccRaw[0].ToString() + ',' + imuData.AccRaw[1].ToString() + ',' + imuData.AccRaw[2].ToString());
                    string_data += string.Format("加速度:").PadRight(11) + imuData.AccRaw[0].ToString("0").PadLeft(5, ' ') + " " + imuData.AccRaw[1].ToString("0").PadLeft(5, ' ') + " " + imuData.AccRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemAccCalibrated:
                    imuData.AccCalibrated = new Int16[3];
                    imuData.AccCalibrated[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccCalibrated[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccCalibrated[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccCalibratedX, AccCalibratedY, AccCalibratedZ");
                    csv_data.Add(imuData.AccCalibrated[0].ToString() + ',' + imuData.AccCalibrated[1].ToString() + ',' + imuData.AccCalibrated[2].ToString());
                    string_data += string.Format("AccCalibrated:").PadRight(14) + imuData.AccCalibrated[0].ToString("0").PadLeft(5, ' ') + " " + imuData.AccCalibrated[1].ToString("0").PadLeft(5, ' ') + " " + imuData.AccCalibrated[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemAccFiltered:
                    imuData.AccFiltered = new Int16[3];
                    imuData.AccFiltered[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccFiltered[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccFiltered[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccFilteredX, AccFilteredY, AccFilteredZ");
                    csv_data.Add(imuData.AccFiltered[0].ToString() + ',' + imuData.AccFiltered[1].ToString() + ',' + imuData.AccFiltered[2].ToString());
                    string_data += string.Format("AccFiltered:").PadRight(14) + imuData.AccFiltered[0].ToString("0").PadLeft(5, ' ') + " " + imuData.AccFiltered[1].ToString("0").PadLeft(5, ' ') + " " + imuData.AccFiltered[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemAccLinear:
                    imuData.AccLinear = new Int16[3];
                    imuData.AccLinear[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccLinear[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccLinear[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccLinearX, AccLinearY, AccLinearZ");
                    csv_data.Add(imuData.AccLinear[0].ToString() + ',' + imuData.AccLinear[1].ToString() + ',' + imuData.AccLinear[2].ToString());
                    string_data += string.Format("AccLinear:").PadRight(14) + imuData.AccLinear[0].ToString("0").PadLeft(5, ' ') + " " + imuData.AccLinear[1].ToString("0").PadLeft(5, ' ') + " " + imuData.AccLinear[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemAccGravity:
                    imuData.AccGravity = new Int16[3];
                    imuData.AccGravity[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccGravity[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccGravity[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccGravityX, AccGravityY, AccGravityZ");
                    csv_data.Add(imuData.AccGravity[0].ToString() + ',' + imuData.AccGravity[1].ToString() + ',' + imuData.AccGravity[2].ToString());
                    string_data += string.Format("AccGravity:").PadRight(14) + imuData.AccGravity[0].ToString("0").PadLeft(5, ' ') + " " + imuData.AccGravity[1].ToString("0").PadLeft(5, ' ') + " " + imuData.AccGravity[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemGyrRaw:
                    imuData.GyoRaw = new Int16[3];
                    imuData.GyoRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.GyoRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.GyoRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("GyoRawX, GyoRawY, GyoRawZ");
                    csv_data.Add(imuData.GyoRaw[0].ToString() + ',' + imuData.GyoRaw[1].ToString() + ',' + imuData.GyoRaw[2].ToString());
                    string_data += string.Format("角速度:").PadRight(11) + imuData.GyoRaw[0].ToString("0").PadLeft(5, ' ') + " " + imuData.GyoRaw[1].ToString("0").PadLeft(5, ' ') + " " + imuData.GyoRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemGyrCalibrated:
                    imuData.GyoCalibrated = new Int16[3];
                    imuData.GyoCalibrated[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.GyoCalibrated[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.GyoCalibrated[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("GyoCalibratedX, GyoCalibratedY, GyoCalibratedZ");
                    csv_data.Add(imuData.GyoCalibrated[0].ToString() + ',' + imuData.GyoCalibrated[1].ToString() + ',' + imuData.GyoCalibrated[2].ToString());
                    string_data += string.Format("GyoCalibrated:").PadRight(14) + imuData.GyoCalibrated[0].ToString("0").PadLeft(5, ' ') + " " + imuData.GyoCalibrated[1].ToString("0").PadLeft(5, ' ') + " " + imuData.GyoCalibrated[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemGyrFiltered:
                    imuData.GyoFiltered = new Int16[3];
                    imuData.GyoFiltered[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.GyoFiltered[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.GyoFiltered[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("GyoFilteredX, GyoFilteredY, GyoFilteredZ");
                    csv_data.Add(imuData.GyoFiltered[0].ToString() + ',' + imuData.GyoFiltered[1].ToString() + ',' + imuData.GyoFiltered[2].ToString());
                    string_data += string.Format("GyoFiltered:").PadRight(14) + imuData.GyoFiltered[0].ToString("0").PadLeft(5, ' ') + " " + imuData.GyoFiltered[1].ToString("0").PadLeft(5, ' ') + " " + imuData.GyoFiltered[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemMagRaw:
                    imuData.MagRaw = new Int16[3];
                    imuData.MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("MagRawX, MagRawY, MagRawZ");
                    csv_data.Add(imuData.MagRaw[0].ToString() + ',' + imuData.MagRaw[1].ToString() + ',' + imuData.MagRaw[2].ToString());
                    string_data += string.Format("地磁场:").PadRight(11) + imuData.MagRaw[0].ToString("0").PadLeft(5, ' ') + " " + imuData.MagRaw[1].ToString("0").PadLeft(5, ' ') + " " + imuData.MagRaw[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemMagCalibrated:
                    imuData.MagCalibrated = new Int16[3];
                    imuData.MagCalibrated[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.MagCalibrated[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.MagCalibrated[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("MagCalibratedX, MagCalibratedY, MagCalibratedZ");
                    csv_data.Add(imuData.MagCalibrated[0].ToString() + ',' + imuData.MagCalibrated[1].ToString() + ',' + imuData.MagCalibrated[2].ToString());
                    string_data += string.Format("MagCalibrated:").PadRight(14) + imuData.MagCalibrated[0].ToString("0").PadLeft(5, ' ') + " " + imuData.MagCalibrated[1].ToString("0").PadLeft(5, ' ') + " " + imuData.MagCalibrated[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemMagFiltered:
                    imuData.MagFiltered = new Int16[3];
                    imuData.MagFiltered[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.MagFiltered[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.MagFiltered[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("MagFilteredX, MagFilteredY, MagFilteredZ");
                    csv_data.Add(imuData.MagFiltered[0].ToString() + ',' + imuData.MagFiltered[1].ToString() + ',' + imuData.MagFiltered[2].ToString());
                    string_data += string.Format("MagFiltered:").PadRight(14) + imuData.MagFiltered[0].ToString("0").PadLeft(5, ' ') + " " + imuData.MagFiltered[1].ToString("0").PadLeft(5, ' ') + " " + imuData.MagFiltered[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemRotationEular:
                    imuData.EulerAngles = new float[3];
                    imuData.EulerAngles[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                    imuData.EulerAngles[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                    imuData.EulerAngles[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Pitch, Roll, Yaw");
                    csv_data.Add(imuData.EulerAngles[0].ToString() + ',' + imuData.EulerAngles[1].ToString() + ',' + imuData.EulerAngles[2].ToString());
                    string_data += string.Format("Angles(PRY):").PadRight(14) + imuData.EulerAngles[0].ToString("f2").PadLeft(5, ' ') + " " + imuData.EulerAngles[1].ToString("f2").PadLeft(5, ' ') + " " + imuData.EulerAngles[2].ToString("f2").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemRotationEular2:
                    imuData.EulerAngles = new float[3];
                    imuData.EulerAngles[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                    imuData.EulerAngles[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                    imuData.EulerAngles[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                    offset += 13;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Pitch, Roll, Yaw");
                    csv_data.Add(imuData.EulerAngles[0].ToString() + ',' + imuData.EulerAngles[1].ToString() + ',' + imuData.EulerAngles[2].ToString());
                    string_data += string.Format("Angles2(PRY):").PadRight(14) + imuData.EulerAngles[0].ToString("f3").PadLeft(5, ' ') + " " + imuData.EulerAngles[1].ToString("f3").PadLeft(5, ' ') + " " + imuData.EulerAngles[2].ToString("f3").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemRotationQuat:
                    imuData.Quaternion = new float[4];
                    imuData.Quaternion[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                    imuData.Quaternion[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                    imuData.Quaternion[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                    imuData.Quaternion[3] = BitConverter.ToSingle(buf, offset + 1 + 3 * 4);
                    offset += 17;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Q(w), Q(x), Q(y), Q(z)");
                    csv_data.Add(imuData.Quaternion[0].ToString() + ',' + imuData.Quaternion[1].ToString() + ',' + imuData.Quaternion[2].ToString() + ',' + imuData.Quaternion[3].ToString());
                    string_data += string.Format("Q(WXYZ):").PadRight(10) + imuData.Quaternion[0].ToString("f3").PadLeft(5, ' ') + " " + imuData.Quaternion[1].ToString("f3").PadLeft(5, ' ') + " " + imuData.Quaternion[2].ToString("f3").PadLeft(5, ' ') + " " + imuData.Quaternion[3].ToString("f3").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemTemperature:
                    imuData.Temperature = BitConverter.ToSingle(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Temperature");
                    csv_data.Add(imuData.Temperature.ToString());
                    string_data += string.Format("Temperature:").PadRight(14) + imuData.Temperature.ToString("f3").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemPressure:
                    imuData.Pressure = BitConverter.ToSingle(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Pressure");
                    csv_data.Add(imuData.Pressure.ToString());
                    string_data += string.Format("Pressure:").PadRight(14) + imuData.Pressure.ToString("f3").PadLeft(5, ' ') + "\r\n";
                    break;
                //case (byte)ItemID.kItemKey32:
                //    imuData.Key32 = BitConverter.ToUInt32(buf, offset + 1);
                //    offset += 5;
                //    AvailableItem.Add(cmd);
                //    csv_headers.Add("Key32");
                //    csv_data.Add(imuData.Key32.ToString());
                //    string_data += string.Format("Key32:").PadRight(14) + "0x" + imuData.Key32.ToString("X").PadLeft(5, ' ') + "\r\n";
                //    break;
                case (byte)ItemID.kItemRFQuat:
                    imuData.RFQuat = new float[rf_cnt, 4];
                    string_data += string.Format("RFQuat: W X Y Z\r\n");
                    _csv_header = "";
                    _csv_data = "";
                    for (int i = 0; i < rf_cnt; i++)
                    {
                        imuData.RFQuat[i, 0] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 0 * 4);
                        imuData.RFQuat[i, 1] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 1 * 4);
                        imuData.RFQuat[i, 2] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 2 * 4);
                        imuData.RFQuat[i, 3] = BitConverter.ToSingle(buf, offset + 1 + 16 * i + 3 * 4);
                        string_data += "[" + i.ToString("d2") + "]:" + imuData.RFQuat[i, 0].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFQuat[i,1].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFQuat[i,2].ToString("f3").PadLeft(5, ' ') + " " + imuData.RFQuat[i,3].ToString("f3").PadLeft(5, ' ') + "\r\n";

                        _csv_header += string.Format("W{0}, X{0}, Y{0}, Z{0},", i);
                        _csv_data += imuData.RFQuat[i, 0].ToString("f2") + "," + imuData.RFQuat[i, 1].ToString("f2") + "," + imuData.RFQuat[i, 2].ToString("f2") + "," + imuData.RFQuat[i, 3].ToString("f2") + ",";
                    }

                    offset += 1 + 16* rf_cnt;
                    AvailableItem.Add(cmd);
                    csv_headers.Add(_csv_header);
                    csv_data.Add(_csv_data);
                    break;
                case (byte)ItemID.kItemRFAccCalibrated:
                    imuData.RFAccCalibrated = new Int16[rf_cnt, 3];
                    string_data += string.Format("RFAccCalibrated: X Y Z\r\n");
                    _csv_header = "";
                    _csv_data = "";

                    for (int i = 0; i < rf_cnt; i++)
                    {
                        imuData.RFAccCalibrated[i, 0] = (Int16)(buf[offset + 1 + 6 * i] + (buf[offset + 2 + 6 * i] << 8));
                        imuData.RFAccCalibrated[i, 1] = (Int16)(buf[offset + 3 + 6 * i] + (buf[offset + 4 + 6 * i] << 8));
                        imuData.RFAccCalibrated[i, 2] = (Int16)(buf[offset + 5 + 6 * i] + (buf[offset + 6 + 6 * i] << 8));

                        _csv_header += string.Format("X{0}, Y{0}, Z{0},", i);
                        _csv_data += imuData.RFAccCalibrated[i, 0].ToString("0") + "," + imuData.RFAccCalibrated[i, 1].ToString("0") + "," + imuData.RFAccCalibrated[i, 2].ToString("0") + ",";

                        string_data += "[" + i.ToString("d2") + "]:" + imuData.RFAccCalibrated[i, 0].ToString("0").PadLeft(5, ' ') + " " + imuData.RFAccCalibrated[i, 1].ToString("0").PadLeft(5, ' ') + " " + imuData.RFAccCalibrated[i, 2].ToString("0").PadLeft(5, ' ') + " " + "\r\n";
                    }
                    csv_headers.Add(_csv_header);
                    csv_data.Add(_csv_data);
                    offset += 1 + 6* rf_cnt;
                    AvailableItem.Add(cmd);
                    break;
                    case (byte)ItemID.kItemRFGyrCalibrated:
                        imuData.RFGyrGCalibrated = new Int16[rf_cnt, 3];
                        string_data += string.Format("RFGyrCalibrated: X Y Z\r\n");
                        _csv_header = "";
                        _csv_data = "";

                        for (int i = 0; i < rf_cnt; i++)
                        {
                            imuData.RFGyrGCalibrated[i, 0] = (Int16)(buf[offset + 1 + 6 * i] + (buf[offset + 2 + 6 * i] << 8));
                            imuData.RFGyrGCalibrated[i, 1] = (Int16)(buf[offset + 3 + 6 * i] + (buf[offset + 4 + 6 * i] << 8));
                            imuData.RFGyrGCalibrated[i, 2] = (Int16)(buf[offset + 5 + 6 * i] + (buf[offset + 6 + 6 * i] << 8));

                            _csv_header += string.Format("X{0}, Y{0}, Z{0},", i);
                            _csv_data += imuData.RFGyrGCalibrated[i, 0].ToString("0") + "," + imuData.RFGyrGCalibrated[i, 1].ToString("0") + "," + imuData.RFGyrGCalibrated[i, 2].ToString("0") + ",";

                            string_data += "[" + i.ToString("d2") + "]:" + imuData.RFGyrGCalibrated[i, 0].ToString("0").PadLeft(5, ' ') + " " + imuData.RFGyrGCalibrated[i, 1].ToString("0").PadLeft(5, ' ') + " " + imuData.RFGyrGCalibrated[i, 2].ToString("0").PadLeft(5, ' ') + " " + "\r\n";
                        }
                        csv_headers.Add(_csv_header);
                        csv_data.Add(_csv_data);
                        offset += 1 + 6 * rf_cnt;
                        AvailableItem.Add(cmd);
                        break;
                    case (byte)ItemID.kItemRFTemperature:
                        imuData.RFTemperature = new float[len];
                        string_data += string.Format("RFTemperature\r\n");
                        _csv_header = "";
                        _csv_data = "";

                        for (int i = 0; i < (len / 4); i++)
                        {
                            imuData.RFTemperature[i] = BitConverter.ToSingle(buf, offset + 1 + 4 * i);

                                _csv_header += string.Format("T{0},", i); 
                                _csv_data += imuData.RFTemperature[i].ToString("f3") + ",";

                                string_data += "[" + i.ToString("d2") + "]:" + imuData.RFTemperature[i].ToString("f3").PadLeft(5, ' ')  + "\r\n";
                            }
                            csv_headers.Add(_csv_header);
                            csv_data.Add(_csv_data);
                            offset += 1 + len;
                        AvailableItem.Add(cmd);
                        break;
                    case (byte)ItemID.kItemRFEul:
                    imuData.RFEul = new float[rf_cnt, 3];
                    string_data += string.Format("RFEul: P R Y\r\n");
                    _csv_header = "";
                    _csv_data = "";

                    for (int i = 0; i < rf_cnt; i++)
                    {
                        
                        imuData.RFEul[i, 0] = (float)(Int16)(buf[6 * i + offset + 1] + (buf[6 * i + offset + 2] << 8)) / 100;
                        imuData.RFEul[i, 1] = (float)(Int16)(buf[6 * i + offset + 3] + (buf[6 * i + offset + 4] << 8)) / 100;
                        imuData.RFEul[i, 2] = (float)(Int16)(buf[6 * i + offset + 5] + (buf[6 * i + offset + 6] << 8)) / 10;

                        string_data += "[" + i.ToString("d2") + "]:" + imuData.RFEul[i,0].ToString("f2").PadLeft(5, ' ') + " " + imuData.RFEul[i,1].ToString("f2").PadLeft(5, ' ') + " " + imuData.RFEul[i,2].ToString("f2").PadLeft(5, ' ') + "\r\n";

                        _csv_header += string.Format("P{0}, R{0}, Y{0},", i);
                        _csv_data += imuData.RFEul[i, 0].ToString("f2") + "," + imuData.RFEul[i, 1].ToString("f2") + "," + imuData.RFEul[i, 2].ToString("f2") + ",";
                    }

                    offset += 1 + 6* rf_cnt;
                    AvailableItem.Add(cmd);
                    csv_headers.Add(_csv_header);
                    csv_data.Add(_csv_data);
                    break;
                default:
                    // error has been occured. may be a unspported Items
                    //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                    offset++;
                    break;
            }
        }

        imuData.StringData = string_data;
        imuData.AvailableItem = AvailableItem.ToArray();
        imuData.CsvHeader = csv_headers.ToArray();
        imuData.CsvData = csv_data.ToArray();

        return imuData;
    }

        #endregion

    }
}
