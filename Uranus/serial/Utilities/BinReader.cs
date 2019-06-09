using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Uranus.Utilities
{
    class BinReader
    {

        private int _SP;
        private int _PC;
        private int _StartAddr = int.MaxValue;
        private bool _IsStartAddrGet = false;

        public int StartAddr
        {
            get { return _StartAddr; }
        }

        public bool IsStartAddrGet
        {
            get { return _IsStartAddrGet; }
        }

        public int SP
        {
            get { return _SP; }
        }

        public int PC
        {
            get { return _PC; }
        }

        private byte[] GetFromBin(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] Data = new byte[(fs.Length & 0x03) > 0 ? (fs.Length / 4 + 1) << 2 : fs.Length];
            fs.Read(Data, 0, (int)fs.Length);
            fs.Close();
            return Data;
        }

        private byte[] GetFromHex(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            int offset = 0;
            int lineAddr = 0;
            int base_offset = 0;
            string hexLine;
            int LineCount = 0;

            byte[] Data = new byte[1024*1024];
            while (true)
            {
                hexLine = sr.ReadLine();

                if (hexLine == null)
                {
                    break;
                }

                //每行开头都必须是“：”
                if (hexLine.Substring(0, 1).Equals(":"))
                {
                    //碰到结束符
                    if (hexLine.Substring(1, 8).Equals("00000001"))
                    {
                        Data = Data.Take(lineAddr + offset).ToArray();
                        break;
                    }
                    int lineLength = int.Parse(hexLine.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
                    int lineType = int.Parse(hexLine.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);
                    if (lineType == 0)
                    {
                        lineAddr = int.Parse(hexLine.Substring(3, 4), System.Globalization.NumberStyles.HexNumber) + base_offset;
                    }

                    if (_IsStartAddrGet == false && lineType == 0)
                    {
                        _StartAddr = lineAddr;
                        _IsStartAddrGet = true;
                    }

                    switch (lineType)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            base_offset = int.Parse(hexLine.Substring(9, 4), System.Globalization.NumberStyles.HexNumber);
                            base_offset <<= 16;
                            break;
                        case 5:
                            break;
                    }
                   

                    if (lineType == 0)
                    {
                        lineAddr -= _StartAddr;
                        offset = 0;
                        //Console.WriteLine(lineAddr.ToString());
                        for (int i = 0; i < (lineLength << 1); i += 2)
                        {
                            Data[lineAddr + offset] = Byte.Parse(hexLine.Substring(9 + i, 2), System.Globalization.NumberStyles.HexNumber);
                            offset++;
                        }
                    }
                    LineCount++;
                }
                else
                {
                    break;
                }
            }

            sr.Close();

            //给不满足4的补全0，凑成4的倍数
            //if (offset > 0)
            //{
            //    uint mod = offset & 0x03;

            //    for (int i = 0; i < mod; i++)
            //    {
            //        Data[offset++] = 0x00;
            //    }
            //}
           // byte[] bin = new byte[lineAddr + offset];
          //  Array.Copy(Data.Skip(_StartAddr).ToArray(), bin, lineAddr + offset);

            return Data;
        }

        public byte[] GetDataFromFile(string fileName)
        {
            if (File.Exists(fileName) == false)
            {
                return null;
            }
            _IsStartAddrGet = false;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            byte[] Data = null;
            switch (fileExtension)
            {
                case ".bin":
                    Data = GetFromBin(fileName);
                    break;
                case ".hex":
                    Data = GetFromHex(fileName);
                    break;
                default:
                    break;
            }

            if (Data != null && Data.Length != 0)
            {
                for (int i = 4; i > 0; i--)
                {
                    _SP <<= 8;
                    _SP |= Data[i - 1];
                }

                for (int i = 8; i > 4; i--)
                {
                    _PC <<= 8;
                    _PC |= Data[i - 1];
                }
            }

            return Data;
        }

    }
}
