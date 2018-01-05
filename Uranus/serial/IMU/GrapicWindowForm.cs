using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rug.LiteGL.Controls;

namespace Uranus.DialogsAndWindows
{
    public partial class GrapicWindowForm : BaseForm
    {

        private void SetVerticalAutoscaleIndex(int index, bool @override)
        {
            graph.TrackVerticalTraceIndex = index;
            graph.TrackVerticalTrace = index >= 0;
        }

        private void SetHorizontalAutoscaleIndex(int index, bool @override)
        {
            graph.TrackHorizontalTrace = index >= 0;
            graph.TrackHorizontalTraceIndex = index;
        }

        public GrapicWindowForm(GraphSettings Settings):base(Settings.Title)
        {
            InitializeComponent();

            Name = Settings.Title;
            Text = Settings.Title;

            graph.ShowLegend = Settings.ShowLegend;
            graph.AxesRange = Settings.AxesRange;
            graph.YAxisLabel = Settings.YAxisLabel;
            graph.Rolling = Settings.RollMode;

            graph.Traces.AddRange(Settings.Traces);
            graph.Rolling = horizontalRollToolStripMenuItem.Checked;
            SetVerticalAutoscaleIndex(int.MaxValue, true);
        }

        public void AddData(DateTime timestamp, int index, float value)
        {
            graph.AddScopeData(timestamp, index, value);
        }

        public void AddData(DateTime timestamp, params float[] values)
        {
            graph.AddScopeData(timestamp, values);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.Clear();
        }

        private void allToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                SetHorizontalAutoscaleIndex(int.MaxValue, false);
            }
            else
            {
                SetHorizontalAutoscaleIndex(-1, false);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (((ToolStripMenuItem)sender).Checked)
            {
                SetVerticalAutoscaleIndex(int.MaxValue, false);
            }
            else
            {
                SetVerticalAutoscaleIndex(-1, false);
            }
                
        }

        private void horizontalRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.Rolling = horizontalRollToolStripMenuItem.Checked;
            graph.Clear();
        }

        private void graph_UserChangedViewport(GraphBase graph, bool xChanged, bool yChanged)
        {
            if (yChanged == true)
            {
                SetVerticalAutoscaleIndex(-1, true);
            }

            if (xChanged == true)
            {
                SetHorizontalAutoscaleIndex(-1, true);
            }
        }

        private void CenterOnTrace(int index)
        {
            SetVerticalAutoscaleIndex(-1, false);
            graph.CenterOnTrace(index);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Control) == Keys.Control && (keyData & Keys.Alt) == Keys.Alt)
            {
                keyData = keyData & ~(Keys.Control | Keys.Alt);

                for (int i = 0; i < graph.Traces.Count + 1; i++)
                {
                    if ((keyData & (Keys)((int)Keys.D0 + i)) == (Keys)((int)Keys.D0 + i))
                    {
                        CenterOnTrace(i - 1);
                    }
                }
            }
            else if ((keyData & Keys.Control) == Keys.Control)
            {
                keyData = keyData & ~(Keys.Control | Keys.Alt);

                if (keyData == Keys.Back)
                {
                    graph.ResetView();
                }

                if (keyData == Keys.L)
                {
                    graph.Clear();
                }

                for (int i = 0; i < graph.Traces.Count + 1; i++)
                {
                    if (keyData == (Keys)((int)Keys.D0 + i))
                    {
                        SetVerticalAutoscaleIndex(i - 1, false);
                    }
                }
            }
            else if ((keyData & Keys.Alt) == Keys.Alt)
            {
                keyData = keyData & ~(Keys.Control | Keys.Alt);

                for (int i = 0; i < graph.Traces.Count + 1; i++)
                {
                    if (keyData == (Keys)((int)Keys.D0 + i))
                    {
                        SetHorizontalAutoscaleIndex(i - 1, false);
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void horizonatalZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            graph.ZoomGraph(0.1f, 0);
        }

        private void horizonatalZoomInMenuItem_Click(object sender, EventArgs e)
        {
            graph.ZoomGraph(-0.1f, 0);
        }

        private void verticalZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            graph.ZoomGraph(0, 0.1f);
        }

        private void verticalZoomInMenuItem_Click(object sender, EventArgs e)
        {
            graph.ZoomGraph(0, -0.1f);
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CenterOnTrace(int.MaxValue);
        }

    }
}
