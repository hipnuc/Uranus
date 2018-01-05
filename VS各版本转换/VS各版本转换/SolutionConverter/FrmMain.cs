namespace SolutionConverter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using SolutionConverterLib;

    /// <summary>
    /// FrmMain 类。
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 参考当前加载的解决方案。
        /// </summary>
        private SolutionConverter solutionConverter;

        /// <summary>
        /// 解决该问题的途径。
        /// </summary>
        private string solutionPath;

        /// <summary>
        /// 一个新实例初始化<see cref="FrmMain"/> 类。
        /// </summary>
        public FrmMain()
        {
            this.InitializeComponent();
            this.solutionConverter = null;
            this.solutionPath = null;
            this.ResetForm();
        }

        /// <summary>
        /// 一个新实例初始化<see cref="FrmMain"/> 类。
        /// </summary>
        /// <param name="solutionPath">解决的路径。</param>
        public FrmMain(string solutionPath) : this()
        {
            this.solutionPath = solutionPath;
        }

        /// <summary>
        /// 加载方案。
        /// </summary>
        /// <param name="solutionPath">解决的路径。</param>
        private void LoadSolution(string solutionPath)
        {
            if (solutionPath != null)
            {
                foreach (Control chkBox in this.panel1.Controls)
                {
                    (chkBox as CheckBox).Checked = false;
                }
                this.solutionConverter = new SolutionConverter(solutionPath);
                if (this.solutionConverter.IsReady)
                {
                    this.Text = "VS版本转换器 - " + this.solutionConverter.Name;
                    this.SolutionPathLbl.Text = this.solutionConverter.Name + " (" + solutionPath + ")";
                    this.SolutionPathLbl.Enabled = true;
                    this.CurrentSolutionLbl.Enabled = true;
                    switch (this.solutionConverter.VisualStudioVersion)
                    {
                        case VisualStudioVersion.VisualStudio2002:
                            this.chkVS2002.Checked = true;
                            break;
                        case VisualStudioVersion.VisualStudio2003:
                            this.chkVS2003.Checked = true;
                            break;
                        case VisualStudioVersion.VisualStudio2005:
                            this.chkVS2005.Checked = true;
                            this.ConvertBtn.Enabled = true;
                            break;
                        case VisualStudioVersion.VisualStudio2008:
                            this.chkVS2008.Checked = true;
                            this.ConvertBtn.Enabled = true;
                            break;
                        case VisualStudioVersion.VisualStudio2010:
                            this.chkVS2010.Checked = true;
                            this.ConvertBtn.Enabled = true;
                            break;
                        case VisualStudioVersion.VisualStudio2012:
                            this.chkVS2012.Checked = true;
                            this.ConvertBtn.Enabled = true;
                            break;
                        case VisualStudioVersion.VisualStudio2013:
                            this.chkVS2013.Checked = true;
                            this.ConvertBtn.Enabled = true;
                            break;
                        case VisualStudioVersion.VisualStudio14:
                            this.chkVS2015.Checked = true;
                            this.ConvertBtn.Enabled = true;
                            break;
                    }

                    switch (this.solutionConverter.IdeVersion)
                    {
                        case IdeVersion.VisualStudio:
                            this.chkVS.Checked = true;
                            break;
                        case IdeVersion.CSExpress:
                            this.chkCsExp.Checked = true;
                            break;
                        case IdeVersion.VBExpress:
                            this.chkVbExp.Checked = true;
                            break;
                    }                    
                }
            }
        }

        /// <summary>
        /// 将重置表单。
        /// </summary>
        private void ResetForm()
        {
            this.Text = "VS版本转换器";

            foreach (Control chkBox in this.panel1.Controls)
            {
                (chkBox as CheckBox).Checked = false;
            }

            this.SolutionPathLbl.Text = "不可用/不适用";
            this.SolutionPathLbl.Enabled = false;
            this.CurrentSolutionLbl.Enabled = false;
            this.ConvertBtn.Enabled = false;
            this.solutionPath = null;
            this.solutionConverter = null;
        }

        /// <summary>
        /// 处理OpenSolution控件的Click事件。
        /// </summary>
        /// <param name="sender">事件源。</param>
        /// <param name="e">这 <see cref="System.EventArgs"/> 包含事件数据实例。</param>
        private void OpenSolution_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.solutionPath = this.openFileDialog1.FileName;
                this.LoadSolution(this.solutionPath);
            }
        }

        /// <summary>
        /// 处理的ConvertBtn控件的Click事件。
        /// </summary>
        /// <param name="sender">事件源。</param>
        /// <param name="e">这 <see cref="System.EventArgs"/> 包含事件数据实例。</param>
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            VisualStudioVersion solVer = VisualStudioVersion.Unknown;
            IdeVersion ideVer = IdeVersion.Default;

            if (this.rdoCsExp.Checked == true)
            {
                ideVer = IdeVersion.CSExpress;
            }
            else if (this.rdoVbExp.Checked == true)
            {
                ideVer = IdeVersion.VBExpress;
            }
            else if (this.rdoVS.Checked == true)
            {
                ideVer = IdeVersion.VisualStudio;
            }

            if (this.rdoVS2002.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2002;
            }
            else if (this.rdoVS2003.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2003;
            }
            else if (this.rdoVS2005.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2005;
            }
            else if (this.rdoVS2008.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2008;
            }
            else if (this.rdoVS2010.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2010;
            }
            else if (this.rdoVS2012.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2012;
            }
            else if (this.rdoVS2013.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio2013;
            }
            else if (this.rdoVS2015.Checked == true)
            {
                solVer = VisualStudioVersion.VisualStudio14;
            }

            ConversionResult result = this.solutionConverter.ConvertTo(solVer, ideVer);
            if (result.ConversionStatus == ConversionStatus.Succeeded)
            {
                MessageBox.Show(ConversionStatus.Succeeded.GetStringValue(), "成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ResetForm();
            }
            else if (result.ConversionStatus == ConversionStatus.Partial)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine(ConversionStatus.Partial.GetStringValue());
                this.solutionConverter.ProjectConversionResults.ForEach(delegate(ConversionResult conversionResult)
                {
                    message.AppendLine(conversionResult.ConverterReference.Name + ": " + conversionResult.ConversionStatus.GetStringValue());
                });
                MessageBox.Show(message.ToString(), "部分成功！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(ConversionStatus.Failed.GetStringValue(), "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 窗体的FrmMain_Load事件控制。
        /// </summary>
        /// <param name="sender">事件源。</param>
        /// <param name="e">这 <see cref="System.EventArgs"/> 包含事件数据实例。</param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (this.solutionPath != null)
            {
                this.LoadSolution(this.solutionPath);
            }
        }
    }
}
