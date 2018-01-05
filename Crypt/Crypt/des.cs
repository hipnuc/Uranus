using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;

namespace DES
{
    class des
    {
        public static string EncryptString(string sInputString, string sKey, string sIV)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(sInputString);

                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);

                DES.IV = ASCIIEncoding.ASCII.GetBytes(sIV);

                ICryptoTransform desencrypt = DES.CreateEncryptor();

                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);

                return BitConverter.ToString(result);
            }
            catch { }

            return "转换出错！";
        }

        public static string DecryptString(string sInputString, string sKey, string sIV)
        {
            try
            {
                string[] sInput = sInputString.Split("-".ToCharArray());

                byte[] data = new byte[sInput.Length];

                for (int i = 0; i < sInput.Length; i++)
                {
                    data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
                }

                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);

                DES.IV = ASCIIEncoding.ASCII.GetBytes(sIV);

                ICryptoTransform desencrypt = DES.CreateDecryptor();

                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);

                return Encoding.UTF8.GetString(result);
            }
            catch { }

            return "解密出错！";
        }  

    }
}
