using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace barcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap KiRotate(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;
            
            PixelFormat pf;

            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }

            Bitmap tmp = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);

            Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
            g = Graphics.FromImage(dst);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();

            tmp.Dispose();

            return dst;
        }

        int getPixelGary(Bitmap bm, int x, int y)
        {
            Color color = bm.GetPixel(x, y);
            int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
            return gray;
        }

       void  RotFind(Bitmap bm)
        {
            int w = bm.Width;
            int h = bm.Height;
            // find the angle 

            int[] Density = new int[360];

            int R = 30;
            int CenterX = w / 2;
            int CenterY = h / 2;
            // fine a black bar
            for (int x = w / 2; x < w / 2 + 50; x++)
            {
                int gray1 = getPixelGary(bm, x, CenterY);
                int gray2 = getPixelGary(bm, x + 1, CenterY);
                int gray3 = getPixelGary(bm, x + 2, CenterY);
                if (gray1 > 240 && gray2 > 240 && gray2 > 240)
                {
                    CenterX = x + 1;
                    Console.WriteLine(CenterX.ToString() + "   " + CenterY.ToString());
                    break;
                }
            }

            for (float i = 90 - 20; i < 90 + 20; i++)
            {
                Density[(int)i] = 0;
                for (int x = 0; x < R; x++)
                {
                    int gray = getPixelGary(bm, CenterX + (int)(R * Math.Cos(i / 57.3)), CenterY + (int)(R * Math.Sin(i / 57.3)));
                    Density[(int)i] += gray;
                }

                Density[(int)i] /= R;

                //       Console.WriteLine(Math.Sin(i).ToString());
             //   chart1.Series[1].Points.AddXY(i, Density[(int)i]);
           //     g1.DrawLine(new Pen(Color.Red, 1), new Point(CenterX, CenterY), new Point(CenterX + (int)(R * Math.Cos(i / 57.3)), CenterY + (int)(R * Math.Sin(i / 57.3))));
            }
        }

       bool UJFind(Bitmap bm, int x, int y, int size)
       {
           int i = 0, j = 0;

           float[] edge = new float[4];
           bool[] IsBlack = new bool[4];
           int[] gray = new int[4];

           for (i = 0; i < 4; i++)
           {
               edge[i] = 0;
               IsBlack[i] = false;
               gray[i] = 0;
           }

               for (i = 0; i < size * 2; i++)
               {
                   // horizatial 
                   gray[0] = getPixelGary(bm, x - size + i, y);
                   gray[1] = getPixelGary(bm, x, y - size + i);
                   gray[2] = getPixelGary(bm, x - size + i, y - size + i);
                   gray[3] = getPixelGary(bm, x - size + i, y + size - i);

                   for (j = 0; j < 4; j++)
                   {
                       if (gray[j] > 128)
                           IsBlack[j] = true;
                       else
                       {
                           if (IsBlack[j] == true)
                               edge[j]++;

                           IsBlack[j] = false;
                       }
                   }

                          bm.SetPixel(x - size + i, y, Color.Red);
                          bm.SetPixel(x, y - size + i, Color.Red);
                          bm.SetPixel(x - size + i, y - size + i, Color.Red);
                         bm.SetPixel(x - size + i, y + size - i, Color.Red);
               }

           edge[0] /= size;
           edge[1] /= size;
           edge[2] /= size;
           edge[3] /= size;



           textBox1.Text += x.ToString() + "," + y.ToString() + "  " + edge[0].ToString("0.00") + "  " + edge[1].ToString("0.00") + "  " + edge[2].ToString("0.00") + "  " + edge[3].ToString("0.00") + "\r\n";

           if (edge[0] >0.15 && edge[1] <0.11 && Math.Abs(edge[2] - edge[3]) < 0.10 && edge[2]> 0.1)
           {
               bm.SetPixel(x, y, Color.Red);
               bm.SetPixel(x - 1, y, Color.Red);
               bm.SetPixel(x + 1, y, Color.Red);
               bm.SetPixel(x, y - 1, Color.Red);
               bm.SetPixel(x, y + 1, Color.Red);
               return true;
           }
           return false;

       }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File Location";
            saveFileDialog.Filter = "bmp files (*.bmp)|*.bmp";
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.FileName = "a.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                Bitmap src;
                // Retrieve the image.
                src = new Bitmap(saveFileDialog.FileName);

                this.Text = src.Width + "   " + src.Height + src.PixelFormat.ToString();
                int x, y;

                Graphics g1 = panel1.CreateGraphics();
                Graphics g2 = panel2.CreateGraphics();
                Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                //using (Graphics gfx = Graphics.FromImage(newBmp))
                //{
                //    gfx.DrawImage(src, 0, 0);
                //}

            //    Pen mypen = new Pen();
                int[] YHist = new int[240];
                int[] YHist1st = new int[240];

                int MinLine = 0, MaxLine= src.Width;

                // Loop through the images pixels to reset color.
                for (x = 0; x < src.Width; x++)
                {
                    for (y = 0; y < src.Height; y++)
                    {
                        //获取该点的像素的RGB的颜色 
                        Color color = src.GetPixel(x, y);
                        //利用公式计算灰度值 
                        int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        Color newColor = Color.FromArgb(gray, gray, gray);
                        newBmp.SetPixel(x, y, newColor); 

                    }
                }

                // get THist
                for (y = 0; y < src.Height; y++)
                {
                    YHist[y] = 0;
                    for (x = 0; x < src.Width; x++)
                    {
                        Color color = src.GetPixel(x, y);
                        int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        if (gray > 128)
                        {
                            YHist[y]++;
                        }
                       
                    }
                 //   YHist[y] /= src.Width;
                }

                // get YHist 1st
                for (y =1; y < src.Height; y++)
                {
                    YHist1st[y] = Math.Abs(YHist[y] - YHist[y - 1]);
       //             chart1.Series[1].Points.AddY(YHist1st[y]);
                }

                // find the edge
                for (y = (src.Height) / 2; y < src.Height; y++)
                {
                    if (YHist1st[y] > 10)
                    {
                        MaxLine = y;
                        break;
                    }
                }

                for (y = src.Height / 2; y >0 ; y--)
                {
                    if (YHist1st[y] > 10)
                    {
                        MinLine = y;
                        break;
                    }
                }

                this.Text += MaxLine + "    " + MinLine;

            //    newBmp = KiRotate(newBmp, 20.0F, Color.White);
                g1.DrawImage(src, 0, 0);
                g1.DrawLine(new Pen(Color.Red, 1), new Point(0, MinLine), new Point(320, MinLine));
                g1.DrawLine(new Pen(Color.Red, 1), new Point(0, MaxLine), new Point(320, MaxLine));


               // RotFind(newBmp);

                for (y= 0; y < 11; y++)
                {
                    for (x= 0; x < 15;x++)
                    {
                        int px = 20 + x * 20;
                        int py = 20 + y * 20;
                        bool ret = UJFind(newBmp, px, py, 10);
                        if (ret)
                        {
                            g1.DrawRectangle(new Pen(Color.Red, 5), px, py, 5, 5);

                        }
                    }
                    
                }
                   
                g2.DrawImage(newBmp, 0, 0);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
