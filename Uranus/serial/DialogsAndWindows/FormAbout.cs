using System;
using System.Reflection;
using Uranus.DialogsAndWindows;

namespace Uranus
{
    public partial class FormAbout : BaseForm
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::Uranus.Properties.Resources.favicon.ToBitmap();
            labelName.Text = Assembly.GetExecutingAssembly().GetName().Name + "   V" + Assembly.GetExecutingAssembly().GetName().Version;
            this.textBox1.Text = global::Uranus.Properties.Resources.updatelog;
            label2.Text = "dNET版本: " + Environment.Version.ToString();
            
            Assembly asm = Assembly.GetExecutingAssembly();//如果是当前程序集

            AssemblyDescriptionAttribute asmdis = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyDescriptionAttribute));
            AssemblyCopyrightAttribute asmcpr = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            AssemblyCompanyAttribute asmcpn = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCompanyAttribute));
            string s = string.Format("{0}  \r\n{1}", asmcpr.Copyright, asmcpn.Company);
            label1.Text = s;

        }

    }
}
