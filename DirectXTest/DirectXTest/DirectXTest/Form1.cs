using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Media.Media3D;
using System.Windows.Forms.Integration;

using QuaternionView;

namespace DirectXTest
{
    public partial class Form1 : Form
    {

        private View3D view3D;

        public Form1()
        {
            InitializeComponent();
            view3D = new View3D();
            
            view3D.Model3DPath = @"Model\PilotFish_UAV.obj";
            elementHost1.Child = view3D;
            Timer time1 = new Timer();
            time1.Interval = 20;
            time1.Tick += time1_Tick;
            time1.Start();
        }

        private double angle = 0;

        public Quaternion ZRotation(double angleInRadians)
        {
            double halfAngleInRadians = (angleInRadians * 0.5);
            Quaternion q = new Quaternion(0, 0, Math.Sin(halfAngleInRadians), Math.Cos(halfAngleInRadians));
            q = new Quaternion(new Vector3D(0, 1, 0), angle);

    //       q = Quaternion.Multiply(q, new Quaternion(new Vector3D(1, 0, 0), angle));
      //     q = Quaternion.Multiply(q, new Quaternion(new Vector3D(0, 0,1), angle));
            return q;
        }

        void time1_Tick(object sender, EventArgs e)
        {
            angle += 1;
            Quaternion q = ZRotation(angle * Math.PI / 180.0);
            AxisAngleRotation3D ddd = new AxisAngleRotation3D();
            
            view3D.SetQuaternion(q.X, q.Y, q.Z, q.W);
        }
    }
}
