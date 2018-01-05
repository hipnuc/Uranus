using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;

namespace serial
{
    public partial class Form1 : Form
    {

        int tickStart = 0;
        int aa=120;
        static int cnt;
        static int temp1;
        static int temp2;

        static int temp3;
        static int temp4;

        RollingPointPairList list1 = new RollingPointPairList(20000000);
        RollingPointPairList list2 = new RollingPointPairList(20000);
        RollingPointPairList list3 = new RollingPointPairList(20000);
        RollingPointPairList list4 = new RollingPointPairList(20000);
        RollingPointPairList list5 = new RollingPointPairList(20000);

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load( object sender, EventArgs e )
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";

 //           timer1.Interval = 100;        //设置timer控件的间隔为50毫秒

            myPane.YAxis.Scale.Min = 0;     //X轴最小值0
            myPane.XAxis.Scale.Min = 0;     //X轴最小值0
            myPane.XAxis.Scale.Max = 120;    //X轴最大60
            myPane.XAxis.Scale.MinorStep = 1;//X轴小步长1,也就是小间隔
            myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            //改变轴的刻度
            zedGraphControl1.AxisChange();

            tickStart = Environment.TickCount;



            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);


        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            LineItem curve1 = zedGraphControl1.GraphPane.AddCurve("", list1, Color.Blue, SymbolType.None);
            LineItem curve2 = zedGraphControl1.GraphPane.AddCurve("", list3, Color.Red, SymbolType.None);
            LineItem curve3 = zedGraphControl1.GraphPane.AddCurve("", list4, Color.Crimson, SymbolType.None);
            LineItem curve4 = zedGraphControl1.GraphPane.AddCurve("", list5, Color.Black, SymbolType.None);

            double time = ( Environment.TickCount - tickStart ) / 1000.0;

            list1.Add( time, temp1 );
            list3.Add(time, temp2);
            list4.Add(time, temp3);
            list5.Add(time, temp4);

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if ( time > xScale.Max - xScale.MajorStep )
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - aa;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void cOM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked =true ;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen) 
                MessageBox.Show("请先关闭串口1");
            else
            serialPort1.PortName = "COM1";


        }

        private void cOM2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = false;
            cOM2ToolStripMenuItem.Checked = true;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
            serialPort1.PortName = "COM2";
        }

        private void cOM3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = false;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = true;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
            serialPort1.PortName = "COM3";
        }

        private void cOM4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = false;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = true;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
            serialPort1.PortName = "COM4";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
            serialPort1.BaudRate = 19200;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
            serialPort1.BaudRate = 9600;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
            serialPort1.BaudRate = 4800;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
            serialPort1.BaudRate = 2400;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about aa = new about();
            aa.Show();
        }

        private void 打开串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) ;
            else
            {
                serialPort1.Open();
            }
            this.Text = "SERIAL     串口已打开";
        }

        private void 关闭串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            this.Text = "SERIAL     串口已关闭";
        }

        private List<byte> buffer = new List<byte>();
        byte[] data = new byte[7];
        private  void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int n = sp.BytesToRead;                    
            byte[] buf = new byte[n];
            sp.Read(buf, 0, n);
            buffer.AddRange(buf);
            while (buffer.Count >= 2)
            {
                if (buffer[0] == 0XAA)
                {
                    if (buffer.Count < 7)
                    {
                        break;
                    }
                    else
                    {
                        buffer.CopyTo(0, data, 0, 7);
                        buffer.RemoveRange(0, 7);
                        //temp = (data[1] * 100 + data[2]*10+data[3])/10;
                        //当前值ToolStripMenuItem.Text = "DIS: " + Convert.ToString(temp) + "CM";
                        switch (data[1])
                        {
                            case 0xa1:
                                temp1 = (data[2] * 1000 + data[3] * 100 + data[4] * 10 + data[5]);
                                当前值ToolStripMenuItem.Text = "AD1: " + Convert.ToString(temp1) + "MV";
                                break;
                            case 0xa2:
                                temp2 = (data[2] * 1000 + data[3] * 100 + data[4] * 10 + data[5]);
                                toolStripMenuItem1.Text = "AD2: " + Convert.ToString(temp2) + "MV";
                                break;
                            case 0xa3:
                                temp3 = (data[2] * 1000 + data[3] * 100 + data[4] * 10 + data[5]);
                                toolStripMenuItem7.Text = "AD3: " + Convert.ToString(temp3) + "MV";
                                break;
                            case 0xa4:
                                temp4 = (data[2] * 1000 + data[3] * 100 + data[4] * 10 + data[5]);
                                toolStripMenuItem8.Text = "AD4: " + Convert.ToString(temp4) + "MV";
                                break;
                            default: break;
                        }
                    }
                }
                else
                {
                    buffer.Remove(0);
                    continue;
                }
            }

        }

        private void 开始绘图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list1.Clear();
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 120;    //X轴最大60
            
            
            timer1.Enabled = true;    //timer可用
            timer1.Start();
            timer2.Stop();
            tickStart = Environment.TickCount;
            this.Text = "SERIAL     正在绘图";
        }

        private void 停止绘图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false ;    //timer可用
            timer1.Stop();
            this.Text = "SERIAL     停止绘图";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Rectangle formRect = this.ClientRectangle;
            formRect.Inflate(-10, -30);
            if (zedGraphControl1.Size != formRect.Size)
            {
                zedGraphControl1.Location = formRect.Location;
                zedGraphControl1.Size = formRect.Size;
            }
        }

        private void x时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aa = Convert.ToInt32(toolStripTextBox1.Text);

            GraphPane myPane = zedGraphControl1.GraphPane;

            myPane.XAxis.Scale.Max = 120;    //X轴最大60
            zedGraphControl1.GraphPane.XAxis.Scale.Max = aa;
            zedGraphControl1.Refresh();
            zedGraphControl1.AxisChange();

        }

        private void 恢复默认状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear(); 

            zedGraphControl1.Refresh();
            timer2.Stop();
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 120;    //X轴最大60
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.YAxis.Scale.Min = 0;     //X轴最小值0
            myPane.XAxis.Scale.Min = 0;     //X轴最小值0
            myPane.XAxis.Scale.Max = 120;    //X轴最大60
            myPane.XAxis.Scale.MinorStep = 1;//X轴小步长1,也就是小间隔
            myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            //改变轴的刻度
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            LineItem curve = zedGraphControl1.GraphPane.AddCurve("", list2, Color.Crimson, SymbolType.None);
            IPointListEdit list = curve.Points as IPointListEdit;
            double time = (Environment.TickCount - tickStart) / 1000.0;

            list2.Add(time, Math.Sin(2.0 * Math.PI * time / 5.0)*20+50);

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 20;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void 示例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear(); 
            zedGraphControl1.Refresh();
            list2.Clear();
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 20;    //X轴最大60
            tickStart = Environment.TickCount;
            timer1.Enabled = false;
            timer2.Enabled = true;
            timer2.Start();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
                serialPort1.BaudRate = 115200;
        }

        private void cOM6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = false;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = true;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
                serialPort1.PortName = "COM6";
        }

        private void cOM7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = false;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = true;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口");
            else
                serialPort1.PortName = "COM7";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void cOM8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = true;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
                serialPort1.PortName = "COM8";
        }

        private void cOM9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = true;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
                serialPort1.PortName = "COM9";
        }

        private void cOM10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = true;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
                serialPort1.PortName = "COM10";
        }

        private void cOM5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = true;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
                serialPort1.PortName = "COM5";
        }

        private void cOM13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = true;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
                serialPort1.PortName = "COM13";
        }

        private void cOM14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOM1ToolStripMenuItem.Checked = true;
            cOM2ToolStripMenuItem.Checked = false;
            cOM3ToolStripMenuItem.Checked = false;
            cOM4ToolStripMenuItem.Checked = false;
            if (serialPort1.IsOpen)
                MessageBox.Show("请先关闭串口1");
            else
                serialPort1.PortName = "COM14";
        }

        private void 当前值ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }


   


    }
}
