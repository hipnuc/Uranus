using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Resources;
using System.Reflection;


namespace IFR_GUI
{
    public partial class Form1 : Form
    {

        const string IFR_CORE_TOOL_PATH = "RMP_L5K.exe";

        Log logger = new Log(Environment.CurrentDirectory + "\\log.txt");

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
                int val = String.Compare(pro[i].ProcessName.ToString(), 0, "RMP_L5K", 0, 5);
                if (val == 0)
                {
                    Console.WriteLine(pro[i].ProcessName.ToString());
                    pro[i].Kill();//结束进程
                }
            }
        }

        public static bool HandlerRoutine(int CtrlType)
        {
            killProcess();
            return true;
        }
        #endregion


        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool exist = (File.Exists(IFR_CORE_TOOL_PATH) && true);
            if(exist == false)
            {
                  logger.log(IFR_CORE_TOOL_PATH + " does not exist!");
                  Environment.Exit(0);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_ReadIFR_Click(object sender, EventArgs e)
        {
            Button self = (Button)sender;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(IFR_CORE_TOOL_PATH);
            p.StartInfo.Arguments = "";
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            self.Enabled = false;
            p.WaitForExit();
            self.Enabled = true;

        }
    }
}
