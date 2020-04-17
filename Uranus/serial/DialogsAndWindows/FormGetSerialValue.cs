using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Uranus.DialogsAndWindows
{
    /// <summary>
    /// Dialog form to get text value from user.
    /// </summary>
    public partial class FormGetSerialValue : Form
    {
        public string PortName { get; private set; }
        public int Baudrate { get; private set; }

        public FormGetSerialValue()
        {
            InitializeComponent();
        }

        private void m_OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void FormGetValue_Load(object sender, EventArgs e)
        {
            if (ComboBoxBaudrate.Items.Count > 0)
            {
                ComboBoxBaudrate.SelectedIndex = 4;
            }
            else
            {
                ComboBoxBaudrate.Text = "请输入波特率";
            }

            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComboBoxPortName.Items.Add("COM" +  Regex.Replace(portName.Substring("COM".Length, portName.Length - "COM".Length), "[^.0-9]", "\0"));
            }

            if (ComboBoxPortName.Items.Count > 0)
            {
                ComboBoxPortName.SelectedIndex = 0;
            }
            else
            {
                ComboBoxPortName.Text = "No serial ports available";
            }

        }

        private void FormGetValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Baudrate = Convert.ToInt32(ComboBoxBaudrate.Text);
            this.PortName = ComboBoxPortName.Text;
        }

        private void m_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
