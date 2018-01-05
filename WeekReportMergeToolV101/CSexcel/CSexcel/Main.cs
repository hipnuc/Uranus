using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

using NPOI.SS.UserModel; 
using NPOI.XSSF.UserModel;
using System.IO;


namespace CSexcel
{

    
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string SheetName = "";
        private BackgroundWorker m_BackgroundWorker;// 申明后台对象

        private void log(string log)
        {
            listBox1.Items.Add(log);
        }

        void CopySheet(ISheet sSheet, ISheet dSheet)
        {
            int LastdSheetRowNum = dSheet.LastRowNum;
            for (int i = sSheet.FirstRowNum+1; i <= sSheet.LastRowNum; i++)
            {
                //log("copying Row:" + i);
                //Application.DoEvents();
                CopyRow(sSheet.GetRow(i), dSheet.CreateRow(i + LastdSheetRowNum));
            }
        }


        void CopyRow(IRow sRow, IRow dRow)
        {
            if (sRow == null)
            {
                return;
            }

            if (sRow.GetCell(0) == null || sRow.GetCell(1) == null || sRow.GetCell(2) == null)
            {
                return;
            }

            switch (sRow.GetCell(2).CellType)
            {
                case CellType.String:
                    if (sRow.GetCell(2).StringCellValue == "")
                    {
                        return;
                    }
                    break;
                case CellType.Blank:
                    return;
                case CellType.Error:
                    return;
                case CellType.Unknown:
                    return;
                default:
                    break;
            }


           for (int i = sRow.FirstCellNum; i < sRow.LastCellNum; i++)
            {
                ICell sCell = sRow.GetCell(i);
                if (sCell == null)
                {
                    continue;
                }
                else
                {
                    ICell dCell = dRow.CreateCell(i);
                    CopyCell(sCell, dCell);
                }
             }
        }

        void CopyCell(ICell sCell, ICell dCell)
        {
            switch (sCell.CellType)
            {
                case CellType.String:
                    dCell.SetCellValue(sCell.StringCellValue);
                    break;
                case CellType.Numeric:
                    if (sCell.NumericCellValue < 100)
                    {
                        dCell.SetCellValue(sCell.NumericCellValue);
                    }
                    else
                    {
                        dCell.SetCellValue(sCell.DateCellValue.ToShortDateString());
                    }
                    break;
                case CellType.Boolean:
                    dCell.SetCellValue(sCell.BooleanCellValue);
                    break;
                default:
                    break;
            }
        }

        void ProcessingExcelFile(FileInfo fi, ISheet dSheet)
        {
            
            IWorkbook book = new XSSFWorkbook(fi);
           
            ISheet sSheet = book.GetSheet(SheetName);
            if (sSheet == null)
            {
                log(" 没有在" + fi.Name + " 中找到 " + SheetName);
                return;
            }

            CopySheet(sSheet, dSheet);
        }

        string DirPath;

        private void button3_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                log("已选择文件夹:" + foldPath);
                DirPath = foldPath;
            }
        }


        void DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            BackgroundWorker bw = sender as BackgroundWorker;
            //MainWindow win = e.Argument as MainWindow;
            IWorkbook dBook = new XSSFWorkbook("template.xlsx");
            ISheet dSheet = dBook.GetSheet(SheetName);
            if (dSheet == null)
            {
                dSheet = dBook.CreateSheet(SheetName);
            }

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(DirPath);
            FileInfo[] ff = di.GetFiles("*.xlsx");
            foreach (FileInfo temp in ff)
            {
                bw.ReportProgress(i++, temp.Name);
                //log(temp.Name);
                ProcessingExcelFile(temp, dSheet);
            }

            if (File.Exists("Merged_" + SheetName + ".xlsx"))
            {
                File.Delete("Merged_" + SheetName + ".xlsx");
            }
            FileStream sw = File.Create("Merged_" + SheetName + ".xlsx");
            dBook.Write(sw);
            sw.Close();

        }

        void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            log(progress + "  -  " + e.UserState + "sheet complate  ");
        }

        void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }
            else
            {
                MessageBox.Show("Completed");
                string path = System.Environment.CurrentDirectory;
                System.Diagnostics.Process.Start("explorer.exe", path);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SheetName = textBox1.Text;
            m_BackgroundWorker = new BackgroundWorker(); // 实例化后台对象

            m_BackgroundWorker.WorkerReportsProgress = true; // 设置可以通告进度
            m_BackgroundWorker.WorkerSupportsCancellation = true; // 设置可以取消

            m_BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            m_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
            m_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);

            m_BackgroundWorker.RunWorkerAsync(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}



