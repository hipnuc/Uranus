using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using System.Windows.Media.Media3D;
using QuaternionView;
using Uranus.Data;

namespace Uranus
{
    public partial class Display : Form
    {
    
        private View3D view3D;
        private Quaternion qRotation= new Quaternion();

        static void WriteBinaryFile(string FileName, byte[] bytes, FileMode mode)
        {
            string path = System.IO.Path.GetDirectoryName(FileName);

            System.IO.Directory.CreateDirectory(path);
            System.IO.FileStream fs = new System.IO.FileStream(FileName, mode);
            fs.Flush();
            fs.Write(bytes, 0, bytes.Length);

            fs.Flush();
            fs.Close();

        }

        public Display()
        {
            InitializeComponent();

            // relase 3D resources 
            WriteBinaryFile(Application.StartupPath + @"\Model\PilotFish_UAV.obj", global::Uranus.Properties.Resources.PilotFish_UAV1, FileMode.Create);
            WriteBinaryFile(Application.StartupPath + @"\Model\PilotFish_UAV.mtl", global::Uranus.Properties.Resources.PilotFish_UAV, FileMode.Create);
            Bitmap bm = global::Uranus.Properties.Resources.PilotFish_UAV_P01;

            if (File.Exists(@"Model\PilotFish_UAV_P01.png") == false)
            {
                bm.Save(@"Model\PilotFish_UAV_P01.png");
            }
            

            view3D = new View3D();
            label2.Text = @"Model\PilotFish_UAV.obj";
            view3D.Model3DPath = label2.Text;
            elementHost1.Child = view3D;


            Timer time1 = new Timer();
            time1.Interval = 20;
            time1.Tick += time1_Tick;
            time1.Start();
        }


        /// <summary>
        /// 设置偏转角，公共类型，外部的类可调用它来设置偏转角，如果想更改偏转角的方向，在相应变量前加-号即可。
        /// </summary>
        public void SetPitchRollYaw(float Pitch, float Roll, float Yaw)
        {
            qRotation = new Quaternion(new Vector3D(0, 0, -1), Yaw+180);
            qRotation =  Quaternion.Multiply(qRotation, new Quaternion( new Vector3D(0, -1, 0), Pitch));
            qRotation = Quaternion.Multiply(qRotation, new Quaternion(new Vector3D(-1, 0, 0), Roll));
        }

        public void SetFromIMUData(IMUData Data)
        {
            if (radioButton1.Checked == true)
            {
                this.SetQuaternion(Data.Quaternion[1], Data.Quaternion[2], Data.Quaternion[3], Data.Quaternion[0]);
            }
            if (radioButton2.Checked == true)
            {
                this.SetPitchRollYaw(Data.EularAngles[0], Data.EularAngles[1], Data.EularAngles[2]);
            }
        }

        public void SetQuaternion(float x, float y, float z, float w)
        {
            qRotation.X = x;
            qRotation.Y= y;
            qRotation.Z = z;
            qRotation.W = w;
        }

        void time1_Tick(object sender, EventArgs e)
        {
            view3D.SetQuaternion(qRotation.X, qRotation.Y, qRotation.Z, qRotation.W);
            label1.Text = "四元数 w x y z:     " + qRotation.W.ToString("f3") + "  " + qRotation.X.ToString("f3") + "  " + qRotation.Y.ToString("f3") + "  " + qRotation.Z.ToString("f3");
        }

    }
}
