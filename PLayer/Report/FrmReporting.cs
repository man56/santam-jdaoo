using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using STM.BLayer.Configurations;
using STM.BLayer.Reporting;
using STM.Extensions;
using STM.PLayer.UI;
using STM.BLayer;

namespace STM.PLayer.Report
{
    public partial class FrmReporting : Form
    {
        bool toVisible;

        bool fromVisible;
        bool editMode;
        DataGridViewColumn editDeleteCol;
        private Point colHeaderClickedPoint;
        private bool shift;
        private bool userClicked;

        public ReportingParameters MouseClickPoint
        {
            set;
            get;
        }



        public FrmReporting()
        {
            InitializeComponent();
 
            var rcm = new ComponentResourceManager(typeof(FrmReporting));
            var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            SetCulture(Controls, rcm, cultureInfo);
            SetMenuCulture(menuPreview, rcm, cultureInfo);
            
            pnlAdvanced.Collapse = true;
        
            cbPointType.ValueMember = "Key";
            cbPointType.DisplayMember = "Value";
            cbPointType.DataSource = BLayer.Reporting.ReportingParameters.ReportPointAbbrev.ToList();


            cbProperty.ValueMember = "Key";
            cbProperty.DisplayMember = "Value";
            cbProperty.DataSource = BLayer.Reporting.ReportingParameters.ReportPropertyAbbrev.ToList();

            label9.BringToFront();
            tabControl1.SelectedTab = tpDefination;
            LoadDefaults();
        }

        private void SetCulture(Control.ControlCollection controls, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                {
                    rcm.ApplyResources(control, control.Name, cultureInfo);
                    SetCulture(control.Controls, rcm, cultureInfo);
                }
                else
                {
                    rcm.ApplyResources(control, control.Name, cultureInfo);
                }
            }
        }
       

        private void SetMenuCulture(ContextMenuStrip menuItem, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            if (menuItem.Items.Count > 0)
                foreach (ToolStripItem toolStripMenuItem in menuItem.Items)
                {
                    if (toolStripMenuItem.GetType() == typeof(ToolStripMenuItem))
                    {
                        rcm.ApplyResources(toolStripMenuItem, toolStripMenuItem.Name, cultureInfo);
                    }

                }
        }

        private void FrmReporting_Load(object sender, EventArgs e)
        {
            cbPointType_SelectedIndexChanged(this, EventArgs.Empty);
            cbProperty_SelectedIndexChanged(this, EventArgs.Empty);
            if (userClicked) return;
        }

        #region Points

        private void cbPointType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPointName.Text = cbPointType.Text;
            var pType = (PointType)cbPointType.SelectedValue;// BLayer.Reporting.ReportingParameters.AbbrevToPoints(cbPointType.SelectedValue as string);
            toVisible = false;
            fromVisible = false;

            switch (pType)
            {
	            case PointType.YieldOffset:
		            lbPointAtFromUnit.Text = @"%";
		            fromVisible = true;
		            break;

	            case PointType.ExtenLimit:
	            case PointType.Extension:
		            lbPointAtFromUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.ExtensionUnit);
		            lbPointToUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.ExtensionUnit);
		            fromVisible = true;
		            toVisible = pType == PointType.ExtenLimit;
		            break;

	            case PointType.Force:
		            lbPointAtFromUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.ForceUnit);
		            lbPointToUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.ForceUnit);
		            fromVisible = true;
		            break;

	            case PointType.Strain:
	            case PointType.StrainLimit:
	            case PointType.TrueStrain:
		            lbPointAtFromUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.StrainUnit);
		            lbPointToUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.StrainUnit);
		            fromVisible = true;
		            toVisible = pType == PointType.StrainLimit;
		            break;

	            case PointType.Stress:
	            case PointType.TrueStress:
		            lbPointAtFromUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.StressUnit);
		            lbPointToUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.StressUnit);
		            fromVisible = true;
		            break;

	            case PointType.MassStress:
		            lbPointAtFromUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.MassStressUnit);
		            lbPointToUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.MassStressUnit);
		            fromVisible = true;
		            break;

	            case PointType.Time:
	            case PointType.TimeLimit:
		            lbPointAtFromUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.TimeUnit);
		            lbPointToUnit.Text = UnitManager.TranslateUnitTitle(UnitManager.TimeUnit);
		            fromVisible = true;
		            toVisible = pType == PointType.TimeLimit;
		            txtCycle.Text = "-1";
		            break;

	            case PointType.Click:
		            userClicked = true;
		            OnClickingCmd();
		            Close();
		            return;
            }

            if (LanguageFrm.IsPersian)
                lbAtFrom.Text = !toVisible ? "در:" : "از:";
            else
                lbAtFrom.Text = !toVisible ? "At" : "From";
            pnlToSection.Visible = toVisible;
            pnlAtSection.Visible = fromVisible;

        }

        public List<ReportingParameters> ReportingParameters
        {
            get { return GetPrintOrder(); }
            set { LoadDefaults(value.ToList()); }
        }

        private List<ReportingParameters> GetPrintOrder()
        {
            var retVal = new List<ReportingParameters>();
            try
            {
                var col = dgvPreview.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                retVal.Add((ReportingParameters)col.Tag);
                while (true)
                {
                    try
                    {
                        col = dgvPreview.Columns.GetNextColumn(col, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                        retVal.Add((ReportingParameters)col.Tag);
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            catch
            {
            }
            return retVal;
        }

        private void llAddPoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (editMode)
                return;
            DataGridViewColumn column = new DataGridViewTextBoxColumn { SortMode = DataGridViewColumnSortMode.NotSortable };
            SetColHeader(column, cbPointType.Text, cbProperty.Text);
            editMode = false;
            llDeletePoint.Visible = false;
            llCancelEditPoint.Visible = false;
            llAddPoint.Visible = pnlAdvanced.Collapse;
            llAdvancedAddPoint.Visible = !pnlAdvanced.Collapse;
        }

        private void llUpdatePoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetColHeader(editDeleteCol, cbPointType.Text, cbProperty.Text);
            editMode = false;
            llDeletePoint.Visible = false;
            llCancelEditPoint.Visible = false;
            llUpdatePoint.Visible = false;
           
            llAddPoint.Visible = pnlAdvanced.Collapse;
            llAdvancedAddPoint.Visible = !pnlAdvanced.Collapse;
        }

        private void SetColHeader(DataGridViewColumn column, string pointType, string pointProperty)
        {
            if (pnlFormula.Visible)
                if (!CheckFormula())
                {
                    txtFormula.ForeColor = Color.Red;
                    return;
                }
            txtFormula.ForeColor = Color.Black;

            var offsetYield = BLayer.Reporting.ReportingParameters.AbbrevToPoints(pointType) == PointType.YieldOffset;

            var reportingParams = new ReportingParameters
            {
                Name = txtPointName.Text,
                Label = txtlabel.Text,
                StepOrCycle = txtCycle.ValueInInt,
                
                PointType = BLayer.Reporting.ReportingParameters.AbbrevToPoints(pointType),
                PointProperty = BLayer.Reporting.ReportingParameters.AbbrevToPointProperty(pointProperty),
                Attribute1 = fromVisible ? (offsetYield ? txtPointAtFrom.ValueInDouble : (double?)UnitManager.ConvertToBase(txtPointAtFrom.Text, lbPointAtFromUnit.Text)) : null,
                Attribute2 = toVisible ? (double?)UnitManager.ConvertToBase(txtPointTo.Text, lbPointAtFromUnit.Text) : null,
                Formula = txtFormula.Text,
                ExpectedRangeA = cbAdvancedEnabled.Checked ? (double?)UnitManager.ConvertToBase(txtExpected1.Text, llAdvancedUnit2.Text) : null,
                ExpectedRangeB = cbAdvancedEnabled.Checked ? (double?)UnitManager.ConvertToBase(txtExpected2.Text, llAdvancedUnit2.Text) : null,
                ResultYellowRangeA = cbAdvancedEnabled.Checked ? (double?)UnitManager.ConvertToBase(txtAcceptable1.Text, llAdvancedUnit2.Text) : null,
                ResultYellowRangeB = cbAdvancedEnabled.Checked ? (double?)UnitManager.ConvertToBase(txtAcceptable2.Text, llAdvancedUnit2.Text) : null,
                ResultRedRangeA = cbAdvancedEnabled.Checked ? (double?)UnitManager.ConvertToBase(txtReject1.Text, llAdvancedUnit2.Text) : null,
                ResultRedRangeB = cbAdvancedEnabled.Checked ? (double?)UnitManager.ConvertToBase(txtReject2.Text, llAdvancedUnit2.Text) : null,
                EnableAnalysing = cbAdvancedEnabled.Checked
            };

            if (!editMode)
            {
                if (dgvPreview.Columns.Cast<DataGridViewTextBoxColumn>().Select(p => p.Tag).Cast<ReportingParameters>().Contains(reportingParams))
                    return;
            }

            dgvPreview.SetCols(column, reportingParams, editMode);
            column.Tag = reportingParams;
        }

        private bool CheckFormula()
        {
            var input = txtFormula.Text;
            input = input.Replace(" ", "");
            input = input.Replace("TrueStrain", " 1 ");
            input = input.Replace("TrueStress", " 1 ");
            input = input.Replace("Strain", " 1 ");
            input = input.Replace("Stress", " 1 ");
            input = input.Replace("Force", " 1 ");
            input = input.Replace("Extension", " 1 ");
            try
            {
                Calculator.GetValue(input);
                return true;
            }
            catch (Exception exception)
            {
                exception.ToString();
                return false;
            }
        }


        private void txtPointName_Enter(object sender, EventArgs e)
        {
            txtPointName.BackColor = Color.White;
        }


        #endregion

        private void dgvPreview_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editDeleteCol = dgvPreview.Columns[e.ColumnIndex];
            GoEditMode();
        }

        private void GoEditMode()
        {
            editMode = true;
            llAddPoint.Visible = false;
            llAdvancedAddPoint.Visible = false;
            llCancelEditPoint.Visible = true;
            llDeletePoint.Visible = true;
            llUpdatePoint.Visible = true;
            LoadEditValues();
        }

        private void LoadEditValues()
        {
            var rParam = (ReportingParameters)editDeleteCol.Tag;
            cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[rParam.PointType];
            cbProperty.Text = BLayer.Reporting.ReportingParameters.ReportPropertyAbbrev[rParam.PointProperty];
            txtPointName.Text = rParam.Name;
            txtlabel.Text = rParam.Label;
            txtCycle.Text = rParam.StepOrCycle.ToString();
            txtPointAtFrom.Text = rParam.Attribute1.HasValue ? (rParam.PointType == PointType.YieldOffset ? rParam.Attribute1.Value.ToString() :
                                      UnitManager.ConvertToCurrent(rParam.Attribute1.Value.ToString(), lbPointAtFromUnit.Text).ToString()
                                      ) : "0";
            txtPointTo.Text = rParam.Attribute2.HasValue
                                      ? UnitManager.ConvertToCurrent(rParam.Attribute2.Value.ToString(), lbPointAtFromUnit.Text).ToString()
                                      : "0";
            txtFormula.Text = rParam.Formula;
            txtExpected1.Text = rParam.ExpectedRangeA.HasValue
                                    ? UnitManager.ConvertToCurrent(rParam.ExpectedRangeA.Value.ToString(), llAdvancedUnit2.Text).ToString()
                                    : "0";
            txtExpected2.Text = rParam.ExpectedRangeB.HasValue
                                    ? UnitManager.ConvertToCurrent(rParam.ExpectedRangeB.Value.ToString(), llAdvancedUnit2.Text).ToString()
                                    : "0";
            txtAcceptable1.Text = rParam.ResultYellowRangeA.HasValue
                                    ? UnitManager.ConvertToCurrent(rParam.ResultYellowRangeA.Value.ToString(), llAdvancedUnit2.Text).ToString()
                                    : "0";
            txtAcceptable2.Text = rParam.ResultYellowRangeB.HasValue
                                    ? UnitManager.ConvertToCurrent(rParam.ResultYellowRangeB.Value.ToString(), llAdvancedUnit2.Text).ToString()
                                    : "0";
            txtReject1.Text = rParam.ResultRedRangeA.HasValue
                                    ? UnitManager.ConvertToCurrent(rParam.ResultRedRangeA.Value.ToString(), llAdvancedUnit2.Text).ToString()
                                    : "0";
            txtReject2.Text = rParam.ResultRedRangeB.HasValue
                                    ? UnitManager.ConvertToCurrent(rParam.ResultRedRangeB.Value.ToString(), llAdvancedUnit2.Text).ToString()
                                    : "0";
            cbAdvancedEnabled.Checked = rParam.EnableAnalysing;
        }


        private void llCancelEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editMode = false;
            llCancelEditPoint.Visible = false;
            llDeletePoint.Visible = false;
            llUpdatePoint.Visible = false;
            llAddPoint.Visible = pnlAdvanced.Collapse;
            llAdvancedAddPoint.Visible = !pnlAdvanced.Collapse;
        }

        private void llDeleteCol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoDeleteMode();
        }

        private void GoDeleteMode()
        {
            dgvPreview.Columns.Remove(editDeleteCol);
            editMode = false;
            llCancelEditPoint.Visible = false;
            llDeletePoint.Visible = false;
            llUpdatePoint.Visible = false;
            llAddPoint.Visible = pnlAdvanced.Collapse;
            llAdvancedAddPoint.Visible = !pnlAdvanced.Collapse;
        }

        #region events


        private void cbProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtlabel.Text = cbProperty.Text;
            var property = BLayer.Reporting.ReportingParameters.AbbrevToPointProperty(cbProperty.Text);
            var mtype = BLayer.Reporting.ReportingParameters.PointPropertyToMeasureType[property];
            string unit;
            pnlFormulaKeyBoard.Visible = false;
            pnlFormula.Visible = false;

            if (property == PointProperty.Formula)
            {
                pnlFormulaKeyBoard.Visible = true;
                pnlFormula.Visible = true;
                unit = "";
            }
            else if (mtype == (MeasureType)(-1))
            {
                double m;
                unit = UnitManager.GetSpecialUnits(property, out m);
            }
            else
                unit = MeasureTool.GetUnit(mtype).Abbreviation;

            SetAdvancedSectionUnits(unit);
        }

        private void SetAdvancedSectionUnits(string unit)
        {
            llAdvancedUnit2.Text = unit;
            llAdvancedUnit4.Text = unit;
            llAdvancedUnit6.Text = unit;
        }

        private void llOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userClicked = false;
            SetGeneralOptions();

            DialogResult = DialogResult.OK;
            HideForm();
        }

        private void SetGeneralOptions()
        {
            BLayer.Reporting.ReportingParameters.ElasticModuleMaxPercent = txtElasticEnd.ValueInDouble;
            BLayer.Reporting.ReportingParameters.ElasticModuleMinPercent = txtElasticStart.ValueInDouble;
            BLayer.Reporting.ReportingParameters.ShowElasticModule = cbShowElastic.Checked;
            BLayer.Reporting.ReportingParameters.ShowAcceptableRange = cbShowAcceptRange.Checked;
            BLayer.Reporting.ReportingParameters.ShowMeanRMS = cbShowMeanRms.Checked;
            BLayer.Reporting.ReportingParameters.ShowUtYield = cbShowUtYield.Checked;
            BLayer.Reporting.ReportingParameters.UseRegression = cbElsticMode.SelectedIndex == 0;
        }

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            HideForm();
        }

        private void CalcKeyClicked(object sender, EventArgs e)
        {
            txtFormula.Text += ((Button)sender).Text;
            txtFormula.SelectionStart = txtFormula.Text.Length;
        }

        private void bttnShift_Click(object sender, EventArgs e)
        {
            if (shift)
            {
                shift = false;
                bttnStrainTrueStrain.Text = @"Strain";
                bttnStressTrusStress.Text = @"Stress";
            }
            else
            {
                shift = true;
                bttnStrainTrueStrain.Text = @"True Strain";
                bttnStressTrusStress.Text = @"True Stress";
            }
        }

        private void dgvPreview_MouseClick(object sender, MouseEventArgs e)
        {
            colHeaderClickedPoint = e.Location;
        }

        private void dgvPreview_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                editDeleteCol = dgvPreview.Columns[e.ColumnIndex];
                menuPreview.Show(dgvPreview, new Point(colHeaderClickedPoint.X, e.Location.Y));
            }
        }

        private void menuEditPreview_Click(object sender, EventArgs e)
        {
            GoEditMode();
        }

        private void menuDeletePreview_Click(object sender, EventArgs e)
        {
            GoDeleteMode();
        }

        public void SetClickedPoint(double value, MeasureType measureType)
        {
            switch (measureType)
            {
                case MeasureType.Force:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.Force];
                    break;
                case MeasureType.Extension:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.Extension];
                    break;
                case MeasureType.Stress:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.Stress];
                    break;
                case MeasureType.MassStress:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.MassStress];
                    break;

                    case MeasureType.LengthStress:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.LengthStress];
                    break;

                case MeasureType.Strain:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.Strain];
                    break;
                case MeasureType.TrueStrain:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.TrueStrain];
                    break;
                case MeasureType.TrueStress:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.TrueStress];
                    break;
                case MeasureType.Time:
                    cbPointType.Text = BLayer.Reporting.ReportingParameters.ReportPointAbbrev[PointType.Time];
                    break;

                default:
                    return;
            }

            txtPointAtFrom.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), lbPointAtFromUnit.Text));
        }

        #endregion


        private void pnlAdvanced_SizeChanged(object sender, EventArgs e)
        {
            Height = pnlDefination.Height + pnlPreview.Height + pnlAdvanced.Height + 45;
            
            llAddPoint.Visible = pnlAdvanced.Collapse;
            llAdvancedAddPoint.Visible = (!pnlAdvanced.Collapse) && (!llUpdatePoint.Visible);
        }

        private void llGeneral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tpOptions;
            CheckLinkLableGroup((IDisposable)sender);
        }

        private void lbPointDef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tpDefination;
            CheckLinkLableGroup((IDisposable)sender);
        }

        private void CheckLinkLableGroup(IDisposable control)
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

        private void llSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetGeneralOptions();
            SettingLoader.Current.SaveReportingTableColumns(GetPrintOrder());
            SettingLoader.Current.SaveReportingTableOptions();
        }

        private void llLoad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvPreview.Columns.Clear();
            LoadDefaults();
        }

        private void LoadDefaults(List<ReportingParameters> reportingParametereses = null)
        {
            if (reportingParametereses == null)
            {
                reportingParametereses = SettingLoader.Current.LoadReportingTableColumns();
                SettingLoader.Current.LoadReportingTableOptions();
            }
            dgvPreview.Columns.Clear();
            foreach (var parameter in reportingParametereses)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable };
                dgvPreview.SetCols(column, parameter, false);
                column.Tag = parameter;
            }

            txtElasticEnd.Text = BLayer.Reporting.ReportingParameters.ElasticModuleMaxPercent.ToString();
            txtElasticStart.Text = BLayer.Reporting.ReportingParameters.ElasticModuleMinPercent.ToString();
            cbShowElastic.Checked = BLayer.Reporting.ReportingParameters.ShowElasticModule;
            cbElsticMode.SelectedIndex = BLayer.Reporting.ReportingParameters.UseRegression ? 0 : 1;
            cbShowAcceptRange.Checked = BLayer.Reporting.ReportingParameters.ShowAcceptableRange;
            cbShowMeanRms.Checked = BLayer.Reporting.ReportingParameters.ShowMeanRMS;
            cbShowUtYield.Checked = BLayer.Reporting.ReportingParameters.ShowUtYield;

        }

        private void llExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sfd.InitialDirectory = Application.StartupPath + "\\Report Settings";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            var path = sfd.FileName;
            var xml = new XDocument(new XElement("root"))
                                {
                                    Declaration = new XDeclaration("1.0", "utf-8", "true")
                                };


            xml.Descendants("root").First().Add(new XElement("TableColumns"));
            var reportingParameteres = GetPrintOrder();


            foreach (var parametere in reportingParameteres)
            {
                xml.Descendants("root").Descendants("TableColumns").First().Add(
                    new XElement("col",
                                 new XAttribute("PointType", parametere.PointType),
                                 new XAttribute("PointProperty", parametere.PointProperty),
                                 new XAttribute("Name", parametere.Name ?? "n/a"),
                                 new XAttribute("Label", parametere.Label ?? "n/a"),
                                 new XAttribute("StepOrCycle", parametere.StepOrCycle),
                                 new XAttribute("Attribute1", parametere.Attribute1.HasValue ? parametere.Attribute1.Value.ToString() : "n/a"),
                                 new XAttribute("Attribute2", parametere.Attribute2.HasValue ? parametere.Attribute2.Value.ToString() : "n/a"),
                                 new XAttribute("Attribute3", parametere.Attribute3.HasValue ? parametere.Attribute3.Value.ToString() : "n/a"),
                                 new XAttribute("Formula", parametere.Formula.Length > 0 ? parametere.Formula : "n/a"),
                                 new XAttribute("ExpectedRangeA", parametere.ExpectedRangeA.HasValue ? parametere.ExpectedRangeA.Value.ToString() : "n/a"),
                                 new XAttribute("ExpectedRangeB", parametere.ExpectedRangeB.HasValue ? parametere.ExpectedRangeB.Value.ToString() : "n/a"),
                                 new XAttribute("ResultYellowRangeA", parametere.ResultYellowRangeA.HasValue ? parametere.ResultYellowRangeA.Value.ToString() : "n/a"),
                                 new XAttribute("ResultYellowRangeB", parametere.ResultYellowRangeB.HasValue ? parametere.ResultYellowRangeB.Value.ToString() : "n/a"),
                                 new XAttribute("ResultRedRangeA", parametere.ResultRedRangeA.HasValue ? parametere.ResultRedRangeA.Value.ToString() : "n/a"),
                                 new XAttribute("ResultRedRangeB", parametere.ResultRedRangeB.HasValue ? parametere.ResultRedRangeB.Value.ToString() : "n/a"),
                                 new XAttribute("EnableAnalysing", parametere.EnableAnalysing)
                        ));
            }
            xml.Save(path);
        }

        private void llImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofd.InitialDirectory = Application.StartupPath + "\\Report Settings";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var fileName = ofd.FileName;
            var cols = ReportingDataSource.LoadReport(fileName);
            LoadDefaults(cols);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideForm();
        }
        private void HideForm()
        {
            Hide();
            if (OnOperationDone != null)
                OnOperationDone(this, EventArgs.Empty);
        }
    }
}
