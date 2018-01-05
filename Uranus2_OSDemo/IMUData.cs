using System;
using System.Collections.Generic;

namespace Uranus.Data
{

    public class IMUData
    {
        public byte ID;
        public UInt32 UID;
        public UInt32 Key32;
        public Int16[] AccRaw;
        public Int16[] AccCalibrated;
        public Int16[] AccFiltered;
        public Int16[] AccLinear;
        public Int16[] AccGravity;

        public Int16[] GyoRaw;
        public Int16[] GyoCalibrated;
        public Int16[] GyoFiltered;

        public Int16[] MagRaw;
        public Int16[] MagCalibrated;
        public Int16[] MagFiltered;

        public float[] EulerAngles;
        public float[] Quaternion;
        public float Pressure;
        public float Temperature;
        public byte[] AvailableItem;
        public string[] CsvHeader;
        public string[] CsvData;
        private string StringData;

        public IMUData()
        {
        }

        public  enum ItemID
        {
            kItemKey32 = 0x80,   /* key status           size: 4 */
            kItemID = 0x90,   /* user programed ID    size: 1 */
            kItemUID = 0x91,   /* Unique ID            size: 4 */
            kItemIPAdress = 0x92,   /* ip address           size: 4 */
            kItemAccRaw = 0xA0,   /* raw acc              size: 3x2 */
            kItemAccCalibrated = 0xA1,
            kItemAccFiltered = 0xA2,
            kItemAccLinear = 0xA5,
            kItemAccGravity = 0xA6,
            kItemGyoRaw = 0xB0,   /* raw gyro             size: 3x2 */
            kItemGyoCalibrated = 0xB1,
            kItemGyoFiltered = 0xB2,
            kItemMagRaw = 0xC0,   /* raw mag              size: 3x2 */
            kItemMagCalibrated = 0xC1,
            kItemMagFiltered = 0xC2,
            kItemRotationEuler = 0xD0,   /* Euler angle          size:3x2 */
            kItemRotationEuler2 = 0xD9,   /* Euler angle2          size:3x4 */
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
        IMUData imuData = new IMUData();
        List<byte> AvailableItem = new List<byte>();
        List<string> csv_headers = new List<string>();
        List<string> csv_data = new List<string>();
        string string_data = "";

        csv_headers.Add("Time");
        csv_data.Add(System.DateTime.Now.ToString() + " " + System.DateTime.Now.Millisecond.ToString());

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
                    string_data = "ID:" + imuData.ID.ToString() + "\r\n";
                    break;

                case (byte)ItemID.kItemUID:
                    imuData.UID = BitConverter.ToUInt32(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("UID");
                    csv_data.Add(imuData.UID.ToString());
                    string_data += "UID:" + "0x" + imuData.UID.ToString("X") + "\r\n";
                    break;

                case (byte)ItemID.kItemAccRaw:
                    imuData.AccRaw = new Int16[3];
                    imuData.AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("AccRaw, AccRawY, AccRawZ");
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
                    csv_data.Add(imuData.AccLinear[0].ToString() + ',' + imuData.AccLinear[1].ToString() + ',' + imuData.AccLinear[2].ToString());
                    string_data += string.Format("AccGravity:").PadRight(14) + imuData.AccGravity[0].ToString("0").PadLeft(5, ' ') + " " + imuData.AccGravity[1].ToString("0").PadLeft(5, ' ') + " " + imuData.AccGravity[2].ToString("0").PadLeft(5, ' ') + "\r\n";
                    break;

                case (byte)ItemID.kItemGyoRaw:
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

                case (byte)ItemID.kItemGyoCalibrated:
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

                case (byte)ItemID.kItemGyoFiltered:
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

                case (byte)ItemID.kItemRotationEuler:
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
                case (byte)ItemID.kItemRotationEuler2:
                    imuData.EulerAngles = new float[3];
                    imuData.EulerAngles[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                    imuData.EulerAngles[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                    imuData.EulerAngles[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                    offset += 13;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Pitch, Roll, Yaw");
                    csv_data.Add(imuData.EulerAngles[0].ToString() + ',' + imuData.EulerAngles[1].ToString() + ',' + imuData.EulerAngles[2].ToString());
                    string_data += string.Format("Angles2(PRY):").PadRight(14) + imuData.EulerAngles[0].ToString("f2").PadLeft(5, ' ') + " " + imuData.EulerAngles[1].ToString("f2").PadLeft(5, ' ') + " " + imuData.EulerAngles[2].ToString("f2").PadLeft(5, ' ') + "\r\n";
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
                case (byte)ItemID.kItemKey32:
                    imuData.Key32 = BitConverter.ToUInt32(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    csv_headers.Add("Key32");
                    csv_data.Add(imuData.Key32.ToString());
                    string_data += string.Format("Key32:").PadRight(14) + "0x" + imuData.Key32.ToString("X").PadLeft(5, ' ') + "\r\n";
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
