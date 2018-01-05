using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uranus.Data
{

    public class IMUData
    {
        public IMUData() {}
        public byte ID;
        public UInt32 UID;
        public Int16[] AccRaw = new Int16[3];
        public Int16[] AccCalibrated = new Int16[3];
        public Int16[] AccFiltered = new Int16[3];
        public Int16[] AccLinear = new Int16[3];

        public Int16[] GyoRaw = new Int16[3];
        public Int16[] GyoCalibrated = new Int16[3];
        public Int16[] GyoFiltered = new Int16[3];

        public Int16[] MagRaw = new Int16[3];
        public Int16[] MagCalibrated = new Int16[3];
        public Int16[] MagFiltered = new Int16[3];

        public float[] EularAngles = new float[3];
        public float[] Quaternion = new float[4];
        public float Pressure;
        public float Temperature;
        public byte[] AvailableItem;
        public string[] CsvHeader;
        public string[] CsvData;

        public  enum ItemID
        {
            kItemKeyStatus = 0x80,   /* key status           size: 4 */
            kItemID = 0x90,   /* user programed ID    size: 1 */
            kItemUID = 0x91,   /* Unique ID            size: 4 */
            kItemIPAdress = 0x92,   /* ip address           size: 4 */
            kItemAccRaw = 0xA0,   /* raw acc              size: 3x2 */
            kItemAccCalibrated = 0xA1,
            kItemAccFiltered = 0xA2,
            kItemAccLinear = 0xA5,
            kItemGyoRaw = 0xB0,   /* raw gyro             size: 3x2 */
            kItemGyoCalibrated = 0xB1,
            kItemGyoFiltered = 0xB2,
            kItemMagRaw = 0xC0,   /* raw mag              size: 3x2 */
            kItemMagCalibrated = 0xC1,
            kItemMagFiltered = 0xC2,
            kItemRotationEular = 0xD0,   /* eular angle          size:3x2 */
            kItemRotationQuat = 0xD1,   /* att q,               size:4x4 */
            kItemTemperature = 0xE0,
            kItemPressure = 0xF0,   /* pressure             size:1x4 */
            kItemEnd = 0x00,   
        };


#region Decode 
    static public IMUData Decode(byte[] buf, int len)
    {
        IMUData imuData = new IMUData();
        List<byte> AvailableItem = new List<byte>();
        List<string> StringNames = new List<string>();
        List<string> StringData = new List<string>();

        StringNames.Add("Time");
        StringData.Add(System.DateTime.Now.ToString() + " " + System.DateTime.Now.Millisecond.ToString());

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
                    StringNames.Add("ID");
                    StringData.Add(imuData.ID.ToString());
                    break;

                case (byte)ItemID.kItemUID:
                    imuData.UID = BitConverter.ToUInt32(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    StringNames.Add("UID");
                    StringData.Add(imuData.UID.ToString());
                    break;

                case (byte)ItemID.kItemAccRaw:
                    imuData.AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("AccRaw, AccRawY, AccRawZ");
                    StringData.Add(imuData.AccRaw[0].ToString() + ',' + imuData.AccRaw[1].ToString() + ',' + imuData.AccRaw[2].ToString());
                    break;

                case (byte)ItemID.kItemAccCalibrated:
                    imuData.AccCalibrated[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccCalibrated[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccCalibrated[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("AccCalibratedX, AccCalibratedY, AccCalibratedZ");
                    StringData.Add(imuData.AccCalibrated[0].ToString() + ',' + imuData.AccCalibrated[1].ToString() + ',' + imuData.AccCalibrated[2].ToString());
                    break;

                case (byte)ItemID.kItemAccFiltered:
                    imuData.AccFiltered[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccFiltered[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccFiltered[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("AccFilteredX, AccFilteredY, AccFilteredZ");
                    StringData.Add(imuData.AccFiltered[0].ToString() + ',' + imuData.AccFiltered[1].ToString() + ',' + imuData.AccFiltered[2].ToString());
                    break;

                case (byte)ItemID.kItemAccLinear:
                    imuData.AccLinear[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.AccLinear[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.AccLinear[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("AccLinearX, AccLinearY, AccLinearZ");
                    StringData.Add(imuData.AccLinear[0].ToString() + ',' + imuData.AccLinear[1].ToString() + ',' + imuData.AccLinear[2].ToString());
                    break;

                case (byte)ItemID.kItemGyoRaw:
                    imuData.GyoRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.GyoRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.GyoRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("GyoRawX, GyoRawY, GyoRawZ");
                    StringData.Add(imuData.GyoRaw[0].ToString() + ',' + imuData.GyoRaw[1].ToString() + ',' + imuData.GyoRaw[2].ToString());
                    break;

                case (byte)ItemID.kItemGyoCalibrated:
                    imuData.GyoCalibrated[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.GyoCalibrated[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.GyoCalibrated[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("GyoCalibratedX, GyoCalibratedY, GyoCalibratedZ");
                    StringData.Add(imuData.GyoCalibrated[0].ToString() + ',' + imuData.GyoCalibrated[1].ToString() + ',' + imuData.GyoCalibrated[2].ToString());
                    break;

                case (byte)ItemID.kItemGyoFiltered:
                    imuData.GyoFiltered[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.GyoFiltered[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.GyoFiltered[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("GyoFilteredX, GyoFilteredY, GyoFilteredZ");
                    StringData.Add(imuData.GyoFiltered[0].ToString() + ',' + imuData.GyoFiltered[1].ToString() + ',' + imuData.GyoFiltered[2].ToString());
                    break;

                case (byte)ItemID.kItemMagRaw:
                    imuData.MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("MagRawX, MagRawY, MagRawZ");
                    StringData.Add(imuData.MagRaw[0].ToString() + ',' + imuData.MagRaw[1].ToString() + ',' + imuData.MagRaw[2].ToString());
                    break;

                case (byte)ItemID.kItemMagCalibrated:
                    imuData.MagCalibrated[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.MagCalibrated[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.MagCalibrated[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("MagCalibratedX, MagCalibratedY, MagCalibratedZ");
                    StringData.Add(imuData.MagCalibrated[0].ToString() + ',' + imuData.MagCalibrated[1].ToString() + ',' + imuData.MagCalibrated[2].ToString());
                    break;

                case (byte)ItemID.kItemMagFiltered:
                    imuData.MagFiltered[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                    imuData.MagFiltered[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                    imuData.MagFiltered[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("MagFilteredX, MagFilteredY, MagFilteredZ");
                    StringData.Add(imuData.MagFiltered[0].ToString() + ',' + imuData.MagFiltered[1].ToString() + ',' + imuData.MagFiltered[2].ToString());
                    break;

                case (byte)ItemID.kItemRotationEular:
                    imuData.EularAngles[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                    imuData.EularAngles[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                    imuData.EularAngles[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                    offset += 7;
                    AvailableItem.Add(cmd);
                    StringNames.Add("Pitch, Roll, Yaw");
                    StringData.Add(imuData.EularAngles[0].ToString() + ',' + imuData.EularAngles[1].ToString() + ',' + imuData.EularAngles[2].ToString());
                    break;

                case (byte)ItemID.kItemRotationQuat:
                    imuData.Quaternion[0] = BitConverter.ToSingle(buf, offset + 1 + 0 * 4);
                    imuData.Quaternion[1] = BitConverter.ToSingle(buf, offset + 1 + 1 * 4);
                    imuData.Quaternion[2] = BitConverter.ToSingle(buf, offset + 1 + 2 * 4);
                    imuData.Quaternion[3] = BitConverter.ToSingle(buf, offset + 1 + 3 * 4);
                    offset += 17;
                    AvailableItem.Add(cmd);
                    StringNames.Add("Q(w), Q(x), Q(y), Q(z)");
                    StringData.Add(imuData.Quaternion[0].ToString() + ',' + imuData.Quaternion[1].ToString() + ',' + imuData.Quaternion[2].ToString() + ',' + imuData.Quaternion[3].ToString());
                    break;

                case (byte)ItemID.kItemTemperature:
                    imuData.Temperature = BitConverter.ToSingle(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    StringNames.Add("Temperature");
                    StringData.Add(imuData.Temperature.ToString());
                    break;

                case (byte)ItemID.kItemPressure:
                    imuData.Pressure = BitConverter.ToSingle(buf, offset + 1);
                    offset += 5;
                    AvailableItem.Add(cmd);
                    StringNames.Add("Pressure");
                    StringData.Add(imuData.Pressure.ToString());
                    break;

                default:
                    // error has been occured. may be a unspported Items
                    //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                    break;
            }
        }
        imuData.AvailableItem = AvailableItem.ToArray();
        imuData.CsvHeader = StringNames.ToArray();
        imuData.CsvData = StringData.ToArray();

        return imuData;
    }

        #endregion

    }
}
