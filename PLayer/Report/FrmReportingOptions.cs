using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using STM.BLayer.Configurations;
using STM.BLayer.StmTest;

namespace STM.PLayer.Report
{
    public partial class FrmReportingOptions : Form
    {
        public event EventHandler<EventArgs> DialogOk;

        private ColorSection colorSection;
        private Color selectedColor;
        public FrmReportingOptions()
        {
            InitializeComponent();
            LoadSetting();

            var rcm = new ComponentResourceManager(typeof(FrmReportingOptions));
            var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            SetCulture(Controls, rcm, cultureInfo);
            TopMost = true;
        }

        private void SetCulture(Control.ControlCollection controls, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                    SetCulture(control.Controls, rcm, cultureInfo);
                else
                {
                    rcm.ApplyResources(control, control.Name, cultureInfo);
                }
            }
        }

        #region General

        private void lbBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGeneralOutputDirectory.Text = fbd.SelectedPath ?? txtGeneralOutputDirectory.Text;
                }
            }
        }

        #endregion

        #region Colors

        private void txtColorsPageSpace_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.PageSpac;
            SetColor(sender);
        }

        private void txtColorsBackground_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.Background;
            SetColor(sender);
        }

        private void txtColorsDiagram_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.Diagram;
            SetColor(sender);
        }

        private void txtColorsLable_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.Lable;
            SetColor(sender);
        }

        private void txtColorsScale_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.Scale;
            SetColor(sender);
        }

        private void txtColorsTitle_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.Title;
            SetColor(sender);
        }

        private void txtColorsGrid_Click(object sender, EventArgs e)
        {
            colorSection = ColorSection.Grid;
            SetColor(sender);
        }

        private void SetColor(object sender)
        {
            if (!(sender is TextBox)) return;
            using (var cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    (sender as TextBox).BackColor = cd.Color;
                    selectedColor = cd.Color;
                }
            }
        }

        private void llColorPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnColorPreview == null) return;
            SetColors();
            OnColorPreview(this, new ColorPreviewEventArgs {SectionName = colorSection , Color= selectedColor, });
        }

        #endregion
 
        #region Load Save

        public void LoadSetting()
        {
            using (var sl = SettingLoader.Current)
            {
                sl.LoadColors();
                sl.LoadOption();
            }
            LoadOptions();
            LoadColors();
            logoTool1.Load();
        }

        private void LoadColors()
        {
           if(Colors.SucceedLoadOrSave)
           {
                txtColorsPageSpace.BackColor = Colors.PageSpace;
                txtColorsBackground.BackColor = Colors.Background;
                txtColorsDiagram.BackColor = Colors.Diagram;
				txtColorsDiagram2.BackColor = Colors.Diagram2;
				txtColorsLable.BackColor = Colors.Lable;
                txtColorsScale.BackColor = Colors.Scale;
                txtColorsTitle.BackColor = Colors.Title;
                txtColorsGrid.BackColor = Colors.Grid;
            }
           else
            {
                txtColorsBackground.BackColor = Color.White;
                txtColorsBackground.BackColor = Color.White;
                txtColorsDiagram.BackColor = Color.White;
				txtColorsDiagram2.BackColor = Color.White;
				txtColorsLable.BackColor = Color.White;
                txtColorsScale.BackColor = Color.White;
                txtColorsTitle.BackColor = Color.White;
                txtColorsGrid.BackColor = Color.White;
            }
        }

        private void LoadOptions()
        {
            txtGeneralOutputDirectory.Text = Options.OutputPath;
            txtGeneralMaxRcFiles.Text = Options.MaxRecentFiles.ToString();
            cbPlotGridLines.Checked = Options.ShowGridLines;
            cbGeneralShowLanguage.Checked = Options.ShowLanguageForm;

            cbPrintLogo.Checked = Options.PrintLogo;
            cbPrintPlot.Checked = Options.PrintPlot;
            cbPrintTestsResults.Checked = Options.PrintTestResults;
            cbPrintTestsSpec.Checked = Options.PrintTestsSpec;
            cbResetMeasures.Checked = Options.ResetMeasuresAtStart;

            nrMaxAutoScaleSampleCount.Text = Options.HugeSampleCount.ToString();
        }

        private void SaveSettings()
        {
            SetOptions();
            SetColors();
            if (!Options.ShowLanguageForm)
                SettingLoader.Current.SetLanguge(LanguageFrm.LanguageName);

            SettingLoader.Current.SaveColors();
            SettingLoader.Current.SaveOption();
        }
        private void SetColors()
        {
            Colors.PageSpace = txtColorsPageSpace.BackColor;
            Colors.Background = txtColorsBackground.BackColor;
            Colors.Diagram = txtColorsDiagram.BackColor;
			Colors.Diagram2 = txtColorsDiagram2.BackColor;
			Colors.Lable = txtColorsLable.BackColor;
            Colors.Scale = txtColorsScale.BackColor;
            Colors.Title = txtColorsTitle.BackColor;
            Colors.Grid = txtColorsGrid.BackColor;
        }
        private void SetOptions()
        {
            Options.OutputPath = txtGeneralOutputDirectory.Text;
            Options.MaxRecentFiles = txtGeneralMaxRcFiles.ValueInInt;
            Options.ShowGridLines = cbPlotGridLines.Checked;
            Options.ShowLanguageForm = cbGeneralShowLanguage.Checked;

            Options.PrintLogo = cbPrintLogo.Checked;
            Options.PrintPlot = cbPrintPlot.Checked;
            Options.PrintTestResults = cbPrintTestsResults.Checked;
            Options.PrintTestsSpec = cbPrintTestsSpec.Checked;

            Options.ResetMeasuresAtStart = cbResetMeasures.Checked;
            Options.HugeSampleCount = nrMaxAutoScaleSampleCount.ValueInInt;
        }

        #endregion

       
        private void llGeneral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabOption.SelectedTab = tpGeneral;
            CheckLinkLableGroup(sender as LinkLabel);
        }

        private void lbColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabOption.SelectedTab = tpColors;
            CheckLinkLableGroup(sender as LinkLabel);
        }

        private void llLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabOption.SelectedTab = tpLogo;
            CheckLinkLableGroup(sender as LinkLabel);
        }

        private void llPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabOption.SelectedTab = tpPrint;
            CheckLinkLableGroup(sender as LinkLabel);
        }

        private void CheckLinkLableGroup(Control control)
        {
            foreach (Control ctrl in pnlNavigation.Controls)
                if (ctrl is LinkLabel)
                {
                    if (ctrl.Equals(control))
                    {
                        ctrl.Font = new Font(ctrl.Font.Name, ctrl.Font.Size, FontStyle.Bold);
                    }
                    else
                        ctrl.Font = new Font(ctrl.Font.Name, ctrl.Font.Size, FontStyle.Regular);
                }
        }

        private void llApply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveSettings();
            DialogOk(this, EventArgs.Empty);
            Hide();

    }

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetOptions();
            SetColors();
            DialogOk(this, EventArgs.Empty);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadSetting();
            DialogOk(this, EventArgs.Empty);
            Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

		private void txtColorsDiagram2_Click(object sender, EventArgs e)
		{
			colorSection = ColorSection.Diagram2;
			SetColor(sender);
		}
	}
}
