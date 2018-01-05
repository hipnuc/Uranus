using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IFR_GUI
{
    class Log
    {
            private string logFile;
            private StreamWriter writer;
            private FileStream fileStream = null;

            public Log(string fileName)
            {
                logFile = fileName;
                CreateDirectory(logFile);
            }

            public void log(string info)
            {

                try
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(logFile);
                    if (!fileInfo.Exists)
                    {
                        fileStream = fileInfo.Create();
                        writer = new StreamWriter(fileStream);
                    }
                    else
                    {
                        fileStream = fileInfo.Open(FileMode.Append, FileAccess.Write);
                        writer = new StreamWriter(fileStream);
                    }
                    writer.WriteLine(DateTime.Now + ": " + info);

                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
            }

            public void CreateDirectory(string infoPath)
            {
                DirectoryInfo directoryInfo = Directory.GetParent(infoPath);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                else
                {
                    // 清空文件
                    FileStream stream = File.Create(infoPath);
                    stream.Close();
                }
            }
        }  

}
