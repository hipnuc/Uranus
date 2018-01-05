using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Uranus.DialogsAndWindows
{

    public partial class BaseForm : Form
    {
        public readonly string ID;

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(string windowID)
        {
            this.ID = windowID;

            InitializeComponent();
        }

    }
}
