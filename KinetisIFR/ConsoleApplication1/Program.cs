using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Resources;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ConsoleApplication1
{

    class Program
    {
        const int KL28_PFSIZE_ADDR = 0x0040;
        const int KL28_PMC_ADDR = 0x004f;
        const string IFR_TOOL_PATH = "RMP_L5K.exe";

    private static bool IsNum(string s)
        {
            return Regex.IsMatch(s, @"^\d+");
        } 

        const string Welcome = "This script will do the following:\r\n "+ 
        "1. Change KL28 Flash to 512K size(PFSIZE = 0xF).\r\n" +
    //    " 2. Clear PMC REFRESHSEL bit\r\n" +
        " 2. set XRDCEN = 1'b0 (disable XRDC and SEMA42 if target is Single Core)\r\n" + 
        "Note: Do not use the on board K20 openSDA/JLINK debugger or any other Jlink lite\r\n" + 
        "B51439@freescale.com\r\n";

        #region Exit Hook
        public delegate bool ControlCtrlDelegate(int CtrlType);
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ControlCtrlDelegate HandlerRoutine, bool Add);
        private static ControlCtrlDelegate cancelHandler = new ControlCtrlDelegate(HandlerRoutine);


        static void killProcess()
        {
            Process[] pro = Process.GetProcesses();//获取已开启的所有进程
            //遍历所有查找到的进程
            for (int i = 0; i < pro.Length; i++)
            {
               
                //判断此进程是否是要查找的进程
                int val  = String.Compare(pro[i].ProcessName.ToString(), 0, "RMP_L5K", 0, 5);
               if(val == 0)
                {
                    Console.WriteLine(pro[i].ProcessName.ToString());
                    pro[i].Kill();//结束进程
                }
            }
        }
 
        public static bool HandlerRoutine(int CtrlType)
        {
            Console.WriteLine("Kill all RMP_L5K\r\n");
            killProcess();
            return true;
        }
        #endregion


        #region file paramer operation

        static int ReadVal(string text, int addr)
        {
            string str_addr = "0x" + addr.ToString("x4");
            int index = text.IndexOf(str_addr);
            if (index == -1)
            {
                return index;
            }
            string s1 = text.Substring(index+str_addr.Length+4, 4);
            return Convert.ToInt32(s1, 16);
        }

        static bool WriteVal(ref  string text, int addr, int val)
        {
            int old = ReadVal(text, addr);
            if (old == -1)
            {
                return false;
            }
            text = text.Replace(old.ToString("x4"), val.ToString("x4"));
            return true;
        }


        #endregion

        static private void ExecuteCmd(string file, string command)
        {

            Process p = new Process();

            p.StartInfo.FileName = file;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine(command);

            p.StandardInput.WriteLine("exit");
            string str = p.StandardOutput.ReadToEnd();
            Console.WriteLine(str);
            p.WaitForExit();

            p.Close();
            p.Dispose();
        }


        static void Main(string[] args)
        {
            // install exit handler, for must kill RMP_L5K.exe thread.
            SetConsoleCtrlHandler(cancelHandler, true);
           
            Console.WriteLine(Welcome);
            Console.WriteLine("PSIZE FIELD SELECT: 0-15");

            string a = "";
            a = Console.ReadLine();
            while (!IsNum(a) || (Convert.ToInt16(a) > 15))
            {
                Console.WriteLine("WRONG INPUT!");
                a = Console.ReadLine();
            }

            Console.WriteLine("PFSIZE will set to:0x" + Convert.ToInt16(a).ToString("x"));

            string NewFilePath = "modify.txt";
            string FilePath = "t0s2_out.txt";

            Console.WriteLine("Read T0 S2...");
            ExecuteCmd("cmd.exe", "RMP_L5K.exe -B 1 -S 2 -O t0s2_out.txt -T 1 -K 1");
            string AllText = File.ReadAllText(FilePath);

            Console.WriteLine("Read T2 S2...");
            ExecuteCmd("cmd.exe", "RMP_L5K.exe -B 4 -S 2 -O t2s2_out.txt -T 1 -K 1");
            string T2S2 = File.ReadAllText("t2s2_out.txt");
            if (T2S2 == null)
            {
                Console.WriteLine("Reading T2S2 failed!");
            }

            int val;

            // change to 512K
            //= 0xc8ff;
            int NewValToChange384to512;
            NewValToChange384to512 = ReadVal( AllText, KL28_PFSIZE_ADDR);
            if (NewValToChange384to512 < 8)
            {
                Console.WriteLine("PSIZE word read error!!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            NewValToChange384to512 &=~ 0x07;
            NewValToChange384to512 |= Convert.ToInt16(a) & 0x07;

            Console.WriteLine("write addr 0x" + KL28_PFSIZE_ADDR.ToString("x4") + " value 0x" + NewValToChange384to512.ToString("x4") + " ...");
            WriteVal(ref AllText, KL28_PFSIZE_ADDR, NewValToChange384to512);
            val = ReadVal(AllText, KL28_PFSIZE_ADDR);
            if (val != NewValToChange384to512)
            {
                Console.WriteLine("falied!");
            }
            else
            {
                Console.WriteLine("succ!");
            }
                


                //// modify PMC values
                //int NewValToPMC0;
                //NewValToPMC0 = ReadVal(AllText, KL28_PMC_ADDR);
                //NewValToPMC0 &= ~(1 << 5);
                //WriteVal(ref AllText, KL28_PMC_ADDR, NewValToPMC0);
                //val = ReadVal(AllText, KL28_PMC_ADDR);
                //if (val != NewValToPMC0)
                //    Console.WriteLine("write 0x" + KL28_PMC_ADDR.ToString("x4") + " to 0x" + NewValToPMC0.ToString("x4") + " falied!");


            // check Single/Dual core
            val = ReadVal(T2S2, 0x0041);
            if ((val & (1 << 5)) > 0)
            {
                Console.WriteLine("Target is Kl28T(Dual)");
            }
            else
            {
                Console.WriteLine("Target is Kl28Z(Single)");
                Console.WriteLine("set XRDCEN = 1'b0 (disable XRDC and SEMA42)");
                val &= ~(1 << 0);
                WriteVal(ref T2S2, 0x0041, val);
                int varify = ReadVal(T2S2, 0x0041);
               if (varify != val)
                    Console.WriteLine("write 0x" +"0041" + " to 0x" + val.ToString("x4") + " falied!");

               Console.WriteLine("Write T2 S2...");
               File.WriteAllText("t2s2_out.txt", T2S2);
               ExecuteCmd("cmd.exe", "RMP_L5K.exe -B 4 -S 2 -I t2s2_out.txt -T 1 -K 1");
            }

            // write IFR to target 
            File.WriteAllText(NewFilePath, AllText);
            Console.WriteLine("Write T0 S2...");
            ExecuteCmd("cmd.exe", "RMP_L5K.exe -B 1 -S 2 -I modify.txt -T 1 -K 1");

            //read back
            Console.WriteLine("Read T0 S2...");
            ExecuteCmd("cmd.exe", "RMP_L5K.exe -B 1 -S 2 -O t0s2_out.txt -T 1 -K 1");

            // compare
            AllText = File.ReadAllText(NewFilePath);
            string oldText = File.ReadAllText(FilePath);

            if (oldText.Length == 0)
            {
                Console.WriteLine("read " + FilePath + " failed\r\n");
                Console.WriteLine("Pree any key to end...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            int index = AllText.IndexOf("# TBlk, SBlk");

            if (index <= 0)
            {
                Console.WriteLine("the IFR data file is bad!");
                Console.WriteLine("Pree any key to end...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("compare start from: " + index.ToString());
            val = String.Compare(AllText, index, oldText, index, AllText.Length - index);

            if (val != 0)
                Console.WriteLine("Write IFR value to target failed!\r\n");
            else
                Console.WriteLine("Write IFR value to target succ!\r\n");

            Console.WriteLine("Pree any key to end...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
