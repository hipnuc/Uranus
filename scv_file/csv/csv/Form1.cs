using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace csv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File Location";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.FileName = "UranusData";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string source = File.ReadAllText(saveFileDialog.FileName);
           //     textBox1.Text = source;

                StreamReader reader = new StreamReader(saveFileDialog.FileName);
                List<string[]> listStrArr = new List<string[]>();//数组List，相当于可以无限扩大的二维数组。

                textBox1.Text = "";

                string line = "";
                string Result;

               
               do
                {
                    line = reader.ReadLine();//读取一行数据
                    if (line != null)
                    {
                        string[] arrTemp = line.Split(',');
                        Result = "{" + arrTemp[3];
                        line = reader.ReadLine();//读取一行数据
                        arrTemp = line.Split(',');
                        Result += ", " + arrTemp[3]+ "}, \r\n";
                        textBox1.Text += Result;
                    }

                  //  line = reader.ReadLine();
                    Application.DoEvents();
                }while( line != null);

            }
        }
    }
}
