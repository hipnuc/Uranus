using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Reflection;

namespace AutoUpdate
{
    public partial class AutoUpdate : Form
    {
        public AutoUpdate()
        {
            InitializeComponent();
        }

        XmlFiles updaterXmlFiles = null;
        private string updateUrl = string.Empty;
        private string tempUpdatePath = string.Empty;
        private int availableUpdate = 0;

        # region 通用子API
        //复制文件;
        private void CopyFile(string sourcePath, string objPath)
        {
            //			char[] split = @"\".ToCharArray();
            if (!Directory.Exists(objPath))
            {
                Directory.CreateDirectory(objPath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] childfile = files[i].Split('\\');
                File.Copy(files[i], objPath + @"\" + childfile[childfile.Length - 1], true);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], objPath + @"\" + childdir[childdir.Length - 1]);
            }
        }

        //判断主应用程序是否正在运行
        private bool IsMainAppRun()
        {
            string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");

            //去掉拓展名
            mainAppExe = mainAppExe.Substring(0, mainAppExe.LastIndexOf("."));

            bool isRun = false;
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower().Contains(mainAppExe.ToLower()))
                {
                    isRun = true;
                    //break;
                }
            }
            return isRun;
        }

        private bool CloseMainAppRun()//关闭主程序
        {
            string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");

            //去掉拓展名
            mainAppExe = mainAppExe.Substring(0, mainAppExe.LastIndexOf("."));

            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower().Contains(mainAppExe.ToLower()))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    //break;
                }
            }
            return true;
        }
        #endregion

        private void AutoUpdate_Load(object sender, EventArgs e)
        {

            panel2.Visible = false;
            btnFinish.Visible = false;

            string localXmlFile = Application.StartupPath + "\\AutoUpdate.xml";
            string serverXmlFile = string.Empty;

            #region 读取本地xml文件
            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                MessageBox.Show("配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            #endregion

            #region 获得服务器 xml 文件
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");
            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "/AutoUpdate.xml";//服务器上 xml地址

            //与服务器连接,下载更新配置文件-------------------------------------------------------------------------------------从服务器上把XML下载到本地
            try
            {
                tempUpdatePath = Application.StartupPath + "\\AutoUpdate";//\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value;//+ "_" + "y" + "_" + "x" + "_" + "m" + "_";//+ "\\";
                appUpdater.DownAutoUpdateFile(tempUpdatePath);//创建一个下载文件的文件夹

                string bddz = tempUpdatePath + "\\AutoUpdate.xml";
                WebClient client1 = new WebClient();//下载服务器上的xml
                client1.DownloadFile(appUpdater.UpdaterUrl, bddz);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败,操作超时!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;

            }
            #endregion

            #region 获取需要升级的文件列表
            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath + "\\AutoUpdate.xml";
            if (!File.Exists(serverXmlFile))
            {
                return;
            }

            availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
            if (availableUpdate > 0)
            {
                for (int i = 0; i < htUpdateFile.Count; i++)
                {
                    string[] fileArray = (string[])htUpdateFile[i];
                    lvUpdateList.Items.Add(new ListViewItem(fileArray));
                }
                // CloseMainAppRun();//关闭主程序
            }
            else
            {
                MessageBox.Show("您已是最新版本!\r\n", "恭喜");
                Application.Exit();
            }

            #endregion
        }

        #region 下载升级文件

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (availableUpdate > 0)
            {
                Thread threadDown = new Thread(new ThreadStart(DownUpdateFile));
                threadDown.IsBackground = true;
                threadDown.Start();
            }
            else
            {
                MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void DownUpdateFile()//-------------------------------------------------------下载文件
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Cursor = Cursors.WaitCursor;

            //mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");//----------------------关闭主程序
            //Process[] allProcess = Process.GetProcesses();
            //foreach (Process p in allProcess)
            //{

            //    if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
            //    {
            //        for (int i = 0; i < p.Threads.Count; i++)
            //            p.Threads[i].Dispose();
            //        p.Kill();
            //        isRun = true;
            //        //break;
            //    }
            //}
            WebClient wcClient = new WebClient();
            for (int i = 0; i < this.lvUpdateList.Items.Count; i++)
            {

                string UpdateFile = lvUpdateList.Items[i].Text.Trim();
                string updateFileUrl = updateUrl + lvUpdateList.Items[i].Text.Trim();//服务器上的 新文件地址
                long fileLength = 0;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                lbState.Text = "正在下载更新文件,请稍后...";
                pbDownFile.Value = 0;
                pbDownFile.Maximum = (int)fileLength;

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        Application.DoEvents();
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        pbDownFile.Value += downByte;

                        float part = (float)startByte / 1024;
                        float total = (float)bufferbyte.Length / 1024;
                        int percent = Convert.ToInt32((part / total) * 100);

                        this.lvUpdateList.Items[i].SubItems[2].Text = percent.ToString() + "%";

                    }
                    //--------------------------------------------------------------------------------------下载文件
                    string newfile = UpdateFile.Substring(UpdateFile.IndexOf('/') + 1);
                    newfile = "\\" + newfile;
                    wcClient.DownloadFile(updateFileUrl, tempUpdatePath + newfile);//tempUpdatePath下载到文件夹

                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            InvalidateControl();
            this.Cursor = Cursors.Default;
        }

        //重新绘制窗体部分控件属性
        private void InvalidateControl()
        {
            panel2.Location = panel1.Location;
            panel2.Size = panel1.Size;
            panel1.Visible = false;
            panel2.Visible = true;

            btnNext.Visible = false;
            btnCancel.Visible = false;
            btnFinish.Location = btnCancel.Location;
            btnFinish.Visible = true;
        }
        #endregion

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
            if (IsMainAppRun() == true)
            {
                CloseMainAppRun();
            }
            Thread.Sleep(100);
            try
            {
                CopyFile(tempUpdatePath, Directory.GetCurrentDirectory());
                System.IO.Directory.Delete(tempUpdatePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Process.Start(mainAppExe);
            this.Close();
            this.Dispose();
        }

    }
}
