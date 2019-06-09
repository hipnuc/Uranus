using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Uranus.Utilities
{
    static class iniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            
        private static string Path;

        static iniFile() 
        {
            Path = Directory.GetCurrentDirectory();
        }

        //section=配置组，key=键名，value=键值
        public static void Write(string section, string key, string value)
        {
            string FileName = Path + "\\params.ini";
            if (!File.Exists(FileName))
            {
             //   File.Create(FileName);
            }
            // section=配置节，key=键名，value=键值，path=路径
             WritePrivateProfileString(section, key, value, FileName);
        }
        public static string Read(string section, string key)
        {
            string FileName = Path + "\\params.ini";
            if (!File.Exists(FileName))
            {
                return null;
            }
            // 每次从ini中读取多少字节
            System.Text.StringBuilder temp = new System.Text.StringBuilder(1024);

            // section=配置节，key=键名，"":无法读取时候的缺省数值 temp=上面，path=路径
            GetPrivateProfileString(section, key, "", temp, 1024, FileName);
            return temp.ToString();
        }
        //检测是否存在ini 文件
        public static  bool ExistINIFile()
        {
            string FileName = Path + "\\params.ini";
            return File.Exists(FileName);
        } 

    }
}
