using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Uranus
{
    public partial class FormGraphic : Form
    {
        public FormGraphic()
        {
            InitializeComponent();
        }
        private IMUData sData;

        Double tickStart = 0;
        Double TimeNow;


        RollingPointPairList listAccX = new RollingPointPairList(5000);
        RollingPointPairList listAccY = new RollingPointPairList(5000);
        RollingPointPairList listAccZ = new RollingPointPairList(5000);

        RollingPointPairList listGyoX = new RollingPointPairList(5000);
        RollingPointPairList listGyoY = new RollingPointPairList(5000);
        RollingPointPairList listGyoZ = new RollingPointPairList(5000);

        LineItem[] curveAcc = new LineItem[3];
        LineItem[] curveGyo = new LineItem[3];

        //public void Input(IMUData data)
        //{
        //    sData = data;

        //    TimeNow = (Environment.TickCount - tickStart) / 1000.0;
        //    listAccX.Add(TimeNow, sData.ra[0]);
        //    listAccY.Add(TimeNow, sData.ra[1]);
        //    listAccZ.Add(TimeNow, sData.ra[2]);

        //    listGyoX.Add(TimeNow, sData.rg[0]);
        //    listGyoY.Add(TimeNow, sData.rg[1]);
        //    listGyoZ.Add(TimeNow, sData.rg[2]);
        //}

        private void FormGraphic_Load(object sender, EventArgs e)
        {
            tickStart = Environment.TickCount;
            SetSize();

            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.IsShowHScrollBar = true;
            zedGraphControl1.IsShowVScrollBar = true;
            zedGraphControl1.IsShowPointValues = true;


            myPane.Title.Text = "Uranus Graphic";
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            myPane.CurveList.Clear();

            //myPane.Legend.IsVisible = false;
            
            Axis myAxis = zedGraphControl1.GraphPane.XAxis;
            myAxis.Title.Text = "Time(s)";
            myAxis.Type = AxisType.Linear;
            myAxis.Title.Text = "Value";
            myAxis.MajorGrid.IsVisible = true;
            myAxis.MinorGrid.IsVisible = true;
            myAxis.Scale.MaxAuto = false;
            myAxis.Scale.MinAuto = false;

            myAxis = zedGraphControl1.GraphPane.YAxis;
            myAxis.Title.Text = "Value";
            myAxis.MajorGrid.IsVisible = true;
            myAxis.Title.FontSpec.FontColor = Color.Red;
            myAxis.Scale.FontSpec.FontColor = Color.Red;

            curveAcc[0] =  AddCurve("AccX", listAccX, Color.Red);
            curveAcc[1] = AddCurve("AccY", listAccY, Color.DarkRed);
            curveAcc[2] = AddCurve("AccZ", listAccZ, Color.OrangeRed);

             curveGyo[0] = AddCurve("GyroX", listGyoX, Color.Black);
             curveGyo[1] = AddCurve("GyroY", listGyoY, Color.Red);
             curveGyo[2] = AddCurve("GyroZ", listGyoZ, Color.Blue);
        }

        private LineItem AddCurve(string name, IPointList points, Color color)
        {
            LineItem line = zedGraphControl1.GraphPane.AddCurve(name, points, color, SymbolType.None);
            line.Line.IsAntiAlias = true;
            return line;
        }

        private void 波形ToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ToolStripMenuItem)e.ClickedItem).Checked = !((ToolStripMenuItem)e.ClickedItem).Checked;


            if (e.ClickedItem == ToolStripMenuItem_Acc)
            {
                curveAcc[0].IsVisible = ((ToolStripMenuItem)e.ClickedItem).Checked;
                curveAcc[1].IsVisible = ((ToolStripMenuItem)e.ClickedItem).Checked;
                curveAcc[2].IsVisible = ((ToolStripMenuItem)e.ClickedItem).Checked;
            }

            if (e.ClickedItem == ToolStripMenuItem_Gyro)
            {
                curveGyo[0].IsVisible = ((ToolStripMenuItem)e.ClickedItem).Checked;
                curveGyo[1].IsVisible = ((ToolStripMenuItem)e.ClickedItem).Checked;
                curveGyo[2].IsVisible = ((ToolStripMenuItem)e.ClickedItem).Checked;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.XAxis.Scale.Max *= 2;
        }

        private void timer_Reflash_Tick(object sender, EventArgs e)
        {
            if (TimeNow >= zedGraphControl1.GraphPane.XAxis.Scale.Max)
            {
                curveAcc[0].Clear();
                curveAcc[1].Clear();
                curveAcc[2].Clear();

                curveGyo[0].Clear();
                curveGyo[1].Clear();
                curveGyo[2].Clear();
                tickStart = Environment.TickCount;
            }

            //if (zedGraphControl1.GraphPane.XAxis.Scale.Min < 0)
            //{
            //    zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
            //}
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.XAxis.Scale.Max /= 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.YAxis.Scale.Max += zedGraphControl1.GraphPane.YAxis.Scale.MajorStep;
            zedGraphControl1.GraphPane.YAxis.Scale.Min -= zedGraphControl1.GraphPane.YAxis.Scale.MajorStep;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.YAxis.Scale.Max -= zedGraphControl1.GraphPane.YAxis.Scale.MajorStep;
            zedGraphControl1.GraphPane.YAxis.Scale.Min += zedGraphControl1.GraphPane.YAxis.Scale.MajorStep;
        }


        private void SetSize()
        {
            zedGraphControl1.Location = new Point(100, 30);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(this.ClientRectangle.Width - 120, this.ClientRectangle.Height - 30);
                   
        }

        private void FormGraphic_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "暂停")
            {
                timer_Reflash.Stop();
                buttonPause.Text = "捕捉";
            }
            else
            {
                timer_Reflash.Start();
                buttonPause.Text = "暂停";
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {

            zedGraphControl1.GraphPane.YAxis.Scale.Max += zedGraphControl1.GraphPane.YAxis.Scale.MinorStep;
            zedGraphControl1.GraphPane.YAxis.Scale.Min += zedGraphControl1.GraphPane.YAxis.Scale.MinorStep;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.YAxis.Scale.Max -= zedGraphControl1.GraphPane.YAxis.Scale.MinorStep;
            zedGraphControl1.GraphPane.YAxis.Scale.Min -= zedGraphControl1.GraphPane.YAxis.Scale.MinorStep;
        }



    }
}
