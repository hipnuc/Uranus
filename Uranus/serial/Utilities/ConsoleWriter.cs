using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Uranus.Utilities
{
        public class ConsoleWriter : System.IO.TextWriter
        {
            
            ListBox lstBox;
            delegate void VoidAction();

            public ConsoleWriter(ListBox box)
            {
                lstBox = box;
            }

            public override void Write(string value)
            {
                VoidAction action = delegate
                {
                    //lstBox.Items.Insert(0, string.Format("[{0:HH:mm:ss}]{1}", DateTime.Now, value));
                    lstBox.TopIndex = lstBox.Items.Count - 1;
                    lstBox.Items.Add(value);
                };
                lstBox.BeginInvoke(action);
            }

            public override void WriteLine(string value)
            {
                VoidAction action = delegate
                {
                   // lstBox.Items.Insert(0, string.Format("[{0:HH:mm:ss}]{1}", DateTime.Now, value));
                    lstBox.Items.Add(value);
                };
                lstBox.BeginInvoke(action);
            }

            public override System.Text.Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }
        }

}
