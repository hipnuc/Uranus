using System;
using System.Windows.Forms;
using System.Collections;

using Uranus.DialogsAndWindows;

namespace Uranus.DialogsAndWindows
{
    public partial class TerminalForm : BaseForm
    {
        private Queue TextQueue = new Queue();

        public TerminalForm():base("TerminalForm")
        {
            InitializeComponent();
        }

        public void Input(string Text)
        {
            TextQueue.Enqueue(Text);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            string Text = "";
            Queue mySyncdQ = Queue.Synchronized(TextQueue);
            int count = mySyncdQ.Count;
            for (int i = 0; i < count; i++)
            {
                Text += mySyncdQ.Dequeue();
            }

            TextQueue.Clear();
            textBox.AppendText(Text);
            if (textBox.Text.Length > textBox.MaxLength)    // discard first half of textBox when number of characters exceeds length
            {
                textBox.Text = textBox.Text.Substring(textBox.Text.Length / 2, textBox.Text.Length - textBox.Text.Length / 2);
            }
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            timerUpdate.Enabled = !timerUpdate.Enabled;
        }

        private void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            timerUpdate.Enabled = !timerUpdate.Enabled;
        }

    }
}
