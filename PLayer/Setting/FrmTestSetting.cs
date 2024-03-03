using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.Parameters;
using STM.BLayer.StmTest;
using STM.BLayer.TestSample;
using System.IO;
using System.Xml.Linq;
using STM.BLayer.Configurations;
using STM.PLayer.Other;
using STM.PLayer.UI;
using STM.Properties;
using static STM.BLayer.StmTest.TestInformation;
using static System.Net.Mime.MediaTypeNames;

//modified 90.9.10
namespace STM.PLayer.Setting
{
    public partial class FrmTestSetting : Form
    {
        private const string NoneMeasure = "None";
        private readonly string curTestPath = string.Format("{0}\\CurrentTest.stx", System.Windows.Forms.Application.StartupPath);
        private int lastSelectedIndex = -1;

        public bool ValidSetting { set; get; }
        private bool isTensionCompersionSample;
        private bool threePointBending;
        private TestInformation testInformation;
        private TestingSample sample;

        //private XDocument xDocument = null;

        private int mDecimation1value, mDecimation1time;
        private int mDecimation2value, mDecimation2time;
        private int mDecimation3value, mDecimation3time;
        private int mDecimation = 100;

        public TestingSample Sample
        {
            set
            {
                sample = value;
            }
            get
            {
                ComputeAreaInertia(this, EventArgs.Empty);
                return sample;
            }
        }

        public MeasureType XMeasureType { set; get; }
        public MeasureType YMeasureType { set; get; }
        public MeasureType Y2MeasureType { set; get; }

        public double DiagramXStop
        {
            get
            {
                return UnitManager.ConvertToBase(txtDiagramXStop.Text, lbDiagramXUnit.Text);
            }
        }
        public double DiagramYStop
        {
            get
            {
                return UnitManager.ConvertToBase(txtDiagramYStop.Text, lbDiagramYUnit.Text);
            }
        }
        public bool EnableStartScale { set { cbDiagramStartUp.Checked = value; } get { return cbDiagramStartUp.Checked; } }

        public TestInformation TestInformation
        {
            get
            {
                testInformation = new TestInformation
                {
                    CustomerName = txtInfomationCustomer.Text,
                    OperatorName = txtInfomationOperator.Text,
                    Date = txtInfomationTestDate.Text,
                    TestDate = (DateTime)(txtInfomationTestDate.Tag ?? DateTime.Now),
                    DateCultureFormat = (DateCultureFormats)cboDateCultureFormat.SelectedIndex,
                    Description = txtInfomationTestDiscription.Lines
                };

                return testInformation;
            }
            set
            {
                testInformation = value;
                txtInfomationCustomer.Text = value.CustomerName;
                txtInfomationOperator.Text = value.OperatorName;
                txtInfomationTestDate.Text = value.Date;
                txtInfomationTestDate.Tag = value.TestDate;
                cboDateCultureFormat.SelectedIndex = (int)value.DateCultureFormat;
                txtInfomationTestDiscription.Lines = value.Description;
            }
        }

        public bool MeasureChanged { get; set; }

        public FrmTestSetting()
        {
            InitializeComponent();
            var rcm = new ComponentResourceManager(typeof(FrmTestSetting));
            var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            SetCulture(Controls, rcm, cultureInfo);
            isTensionCompersionSample = true;
            txtInfomationTestDate.Text = TestInformation.CurrentDate;
            cbMethodTestMethod.SelectedIndex = 0;
            var stDic = new Dictionary<string, string>()
            {
	            { TensionCompressionSampleType.Circular.ToString(),Resources.FrmTestSetting_Circular },
	            { TensionCompressionSampleType.Rectangular.ToString(),Resources.FrmTestSetting_Rectangular },
	            { TensionCompressionSampleType.Area.ToString(), Resources.FrmTestSetting_Area},
	            { TensionCompressionSampleType.Weight.ToString(), Resources.FrmTestSetting_Weight },
	            { TensionCompressionSampleType.Pipe.ToString(), Resources.FrmTestSetting_Pipe },
	            { TensionCompressionSampleType.Oring.ToString(),Resources.FrmTestSetting_Oring },
	            { TensionCompressionSampleType.Denier.ToString(), Resources.FrmTestSetting_Denier },
	            { TensionCompressionSampleType.Tex.ToString(), Resources.FrmTestSetting_Tex },
	            { TensionCompressionSampleType.Tear.ToString(), Resources.FrmTestSetting_Tear }
            };
            cbSampleType.ValueMember = "Key";
            cbSampleType.DisplayMember = "Value";
            cbSampleType.DataSource = stDic.ToList();

            var tsDic = new Dictionary<string, string>()
            {
	            { "Tension/Compression", Resources.FrmTestSetting_Tension_Compression },
	            { "3P Bending", Resources.FrmTestSetting__3P_Bending },
	            { "4P Bending", Resources.FrmTestSetting__4P_Bending },
            };
            cbTestingSampleType.ValueMember = "Key";
            cbTestingSampleType.DisplayMember = "Value";
			cbTestingSampleType.DataSource = tsDic.ToList();

			LoadMeasures();
            LoadDiagramAxis();
            InitializeMethodFields();
            UpdateUnit();
            cbSpeed.SelectedIndex = 0;
            lbAdvanced.BringToFront();
            llSpdctrlDefault_LinkClicked(null, null);
            LoadReportSettingsFiles();
        }

        public void LoadDefault()
        {
            LoadDefaultTest();
            //llOk_LinkClicked(this, null);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                Import(curTestPath);
            }
            catch
            {
            }
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

        private void LoadReportSettingsFiles()
        {
            cbReportFiles.DataSource =
                Directory.GetFiles("Report Settings", "*.trsx", SearchOption.TopDirectoryOnly).Select(
                    p => p.Split(@"\".ToCharArray()).Last()).ToList();
        }

        #region link labels

        private void llSample_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tpSample, sender as Control);
        }

        private void llInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tpInformation, sender as Control);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tpMethod, sender as Control);
        }

        private void llmeasures_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tpMeasures, sender as Control);
        }

        private void llDiagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tpDiagram, sender as Control);
        }

        private void llCtrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tpCtrl, sender as Control);
        }

        private void llStopCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GrantAndSwitch(tabPage1, sender as Control);
        }

        private void CheckLinkLableGroup(Control control)
        {
            if (control != null)
                foreach (Control ctrl in panelNavigation.Controls)
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

        private void GrantAndSwitch(TabPage page, Control sender)
        {
            if (Program.GrantAccess(this, "TestSettings." + page.Text))
            {
                tcSetting.SelectedTab = page;
                CheckLinkLableGroup(sender as Control);
            }
        }

        public void SetSpeedCtrlParameters()
        {
            SpeedControlParameters.Ksi = double.Parse(txtKsi.Text);
            SpeedControlParameters.Ksp = double.Parse(txtKsp.Text);
            SpeedControlParameters.Ksd = double.Parse(txtKsd.Text);
            SpeedControlParameters.STorelance = double.Parse(txtStrainTor.Text);

            SpeedControlParameters.Kei = double.Parse(txtKei.Text);
            SpeedControlParameters.Kep = double.Parse(txtKep.Text);
            SpeedControlParameters.Ked = double.Parse(txtKed.Text);
            SpeedControlParameters.Etorelance = double.Parse(txtExtenTor.Text);

            SpeedControlParameters.Kfi = double.Parse(txtKfi.Text);
            SpeedControlParameters.Kfp = double.Parse(txtKfp.Text);
            SpeedControlParameters.Kfd = double.Parse(txtKfd.Text);
            SpeedControlParameters.Ftorelance = double.Parse(txtForceTor.Text);

        }

        private void llOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckXAxis();
            CheckYAxis();
            CheckY2Axis();


            ComputeAreaInertia(this, EventArgs.Empty);

            ValidSetting = true;
            Export(curTestPath);
            DialogResult = DialogResult.OK;
            HideForm();
        }

        private void llImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                ValidSetting = false;
                openFileDialog.Filter = @"Test Setting(STM 2011)|*.stx|Test Setting(Other Versions)|*.stm";
                openFileDialog.InitialDirectory = string.Format("{0}\\{1}", System.Windows.Forms.Application.StartupPath, "Standards");
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                var fInfo = new FileInfo(openFileDialog.FileName);
                if (fInfo.Extension.Equals(".stx"))
                {
                    ValidSetting = Import(openFileDialog.FileName);
                }
                else
                {
                    ValidSetting = ImportAndConvert(openFileDialog.FileName);
                }
            }
        }

        private void llExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Test Setting|*.stx";
                saveFileDialog.InitialDirectory = string.Format("{0}\\{1}", System.Windows.Forms.Application.StartupPath, "Standards");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Export(saveFileDialog.FileName);
                }
            }
        }

        #endregion

        #region Sample Setting

        private void cbTestingSampleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTestingSampleType.SelectedValue)
            {
                case "Tension/Compression":
	                var stDic = new Dictionary<string, string>()
	                {
		                { TensionCompressionSampleType.Circular.ToString(),Resources.FrmTestSetting_Circular },
		                { TensionCompressionSampleType.Rectangular.ToString(),Resources.FrmTestSetting_Rectangular },
		                { TensionCompressionSampleType.Area.ToString(), Resources.FrmTestSetting_Area},
		                { TensionCompressionSampleType.Weight.ToString(), Resources.FrmTestSetting_Weight },
		                { TensionCompressionSampleType.Pipe.ToString(), Resources.FrmTestSetting_Pipe },
		                { TensionCompressionSampleType.Oring.ToString(),Resources.FrmTestSetting_Oring },
		                { TensionCompressionSampleType.Denier.ToString(), Resources.FrmTestSetting_Denier },
		                { TensionCompressionSampleType.Tex.ToString(), Resources.FrmTestSetting_Tex },
		                { TensionCompressionSampleType.Tear.ToString(), Resources.FrmTestSetting_Tear }
	                };
	                cbSampleType.ValueMember = "Key";
	                cbSampleType.DisplayMember = "Value";
	                cbSampleType.DataSource = stDic.ToList();

                    isTensionCompersionSample = true;
                    lbSampleGS.Text =  Resources.FrmTestSetting_Gauge_Length_L__;
                    lbSampleGP.Text = Resources.FrmTestSetting_Grip_Length_gl__;
                    if (LanguageFrm.IsPersian)
                    {
                        lbSampleGS.Location = new Point(683, 108);
                        lbSampleGP.Location = new Point(675, 138);
                    }
                    break;
                case "3P Bending":
                case "4P Bending":
	                var bsDic = new Dictionary<string, string>()
	                {
		                { BendingSampleType.Circular.ToString(),Resources.FrmTestSetting_Circular },
		                { BendingSampleType.Rectangular.ToString(),Resources.FrmTestSetting_Rectangular },
		                { BendingSampleType.Inertia.ToString(), Resources.FrmTestSetting_Inertia_ }
	                };
	                cbSampleType.ValueMember = "Key";
	                cbSampleType.DisplayMember = "Value";
	                cbSampleType.DataSource = bsDic.ToList();

                    isTensionCompersionSample = false;
                    threePointBending = (cbTestingSampleType.SelectedValue as string == Resources.FrmTestSetting_3P_Bending);
                    lbSampleGS.Text =  Resources.FrmTestSetting_Support_Length_L__;
                    lbSampleGP.Text =Resources.FrmTestSetting_Position_Length_gl__;

                    if (LanguageFrm.IsPersian)
                    {
                        lbSampleGS.Location = new Point(660, 108);
                        lbSampleGP.Location = new Point(678, 138);
                    }
                    break;
            }

            lbSampleGS.RightToLeft = lbSampleGP.RightToLeft = (LanguageFrm.IsPersian ? RightToLeft.Yes : RightToLeft.No);

            if (isTensionCompersionSample)
            {
                lbAreaInertia.Text = Resources.FrmTestSetting_Area_;
                lbAreaInertiaUnit.Text = Resources.FrmTestSetting_mm2;
            }
            else
            {
                lbAreaInertia.Text =  Resources.FrmTestSetting_Inertia_;
                lbAreaInertiaUnit.Text = Resources.FrmTestSetting_mm4;
            }

            lbAreaInertia.RightToLeft = lbAreaInertiaUnit.RightToLeft = (LanguageFrm.IsPersian ? RightToLeft.Yes : RightToLeft.No);
        }

        private void cbSampleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSampleDim1.Text = lbSampleDim2.Text = lbSampleDim3.Text = "";
            txtSampleDim1.Text = txtSampleDim2.Text = txtSampleDim3.Text = "";
            lbSampleUnit1.Text = lbSampleUnit2.Text = lbSampleUnit3.Text = "";

            if (isTensionCompersionSample)
                SetTensionCompressionSampleFields();
            else
                SetBendingSampleFields();



            lbSampleDim2.Visible = lbSampleDim2.Text != "";
            txtSampleDim2.Visible = lbSampleUnit2.Text != "";
            lbSampleUnit2.Visible = lbSampleUnit2.Text != "";
            lbSampleDim3.Visible = lbSampleDim3.Text != "";
            txtSampleDim3.Visible = lbSampleDim3.Text != "";
            lbSampleUnit3.Visible = lbSampleUnit3.Text != "";
            lbSampleDim1.Visible = lbSampleDim1.Text != "";
            txtSampleDim1.Visible = lbSampleUnit1.Text != "";
            lbSampleUnit1.Visible = lbSampleUnit1.Text != "";
        }

        private void SetTensionCompressionSampleFields()
        {
            var sampleType = (TensionCompressionSampleType)Enum.Parse(typeof(TensionCompressionSampleType), cbSampleType.SelectedValue as string);
            switch (sampleType)
            {
                case TensionCompressionSampleType.Circular:
                    #region circular
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Diameter_d__;
                        txtSampleDim1.Text = @"10";
                        lbSampleUnit1.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;
                case TensionCompressionSampleType.Pipe:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Diameter_d__;
                        txtSampleDim1.Text = @"15";
                        lbSampleDim2.Text = Resources.FrmTestSetting_Inner_Diameter_di__;
                        txtSampleDim2.Text = @"5";
                        lbSampleUnit1.Text = lbSampleUnit2.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Rectangular:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Width_w__;
                        txtSampleDim1.Text = @"10";
                        lbSampleDim2.Text = Resources.FrmTestSetting_Thickness_t_;
                        txtSampleDim2.Text = @"5";
                        lbSampleUnit1.Text = lbSampleUnit2.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Oring:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Diameter_d__;
                        txtSampleDim1.Text = "15";
                        lbSampleUnit1.Text = Resources.LengthConvertor_UnitSet_mm;
                        txtSampleDim2.Text = "5";
                        lbSampleDim2.Text = Resources.FrmTestSetting_Inner_Diameter_di__;
                        lbSampleUnit2.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Tear:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Width_;
                        txtSampleDim1.Text = "10";
                        lbSampleUnit1.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Weight:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Density_;
                        txtSampleDim1.Text = "7860";
                        lbSampleDim2.Text = Resources.FrmTestSetting_Weight_;
                        txtSampleDim2.Text = "1";
                        lbSampleDim3.Text = Resources.FrmTestSetting_Length_;
                        txtSampleDim3.Text = "10";

                        lbSampleUnit1.Text = Resources.FrmTestSetting_Kg_m3;
                        lbSampleUnit2.Text = Resources.FrmTestSetting_Kg;
                        lbSampleUnit3.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Area:
                    #region
                    {
                        lbSampleDim1.Text = "Area:";
                        txtSampleDim1.Text = "100";
                        lbSampleUnit1.Text = "mm2";
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Denier:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Denier_;
                        txtSampleDim1.Text = "30";
                        lbSampleUnit1.Text = "gr/9000m";
                        lbSampleDim2.Text = Resources.FrmTestSetting_Density_;
                        txtSampleDim2.Text = "30";
                        lbSampleUnit2.Text = Resources.FrmTestSetting_gr_cm3;
                    }
                    #endregion
                    break;

                case TensionCompressionSampleType.Tex:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Tex_;
                        txtSampleDim1.Text = "30";
                        lbSampleUnit1.Text = Resources.FrmTestSetting_gr_1000m;
                        lbSampleDim2.Text = Resources.FrmTestSetting_Density_;
                        txtSampleDim2.Text = "30";
                        lbSampleUnit2.Text = Resources.FrmTestSetting_gr_cm3;
                    }
                    #endregion
                    break;
            }
        }


        private void SetBendingSampleFields()
        {
            var sampleType = (BendingSampleType)Enum.Parse(typeof(BendingSampleType), cbSampleType.SelectedValue as string ?? string.Empty);
            switch (sampleType)
            {
                case BendingSampleType.Circular:
                    #region circular
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Diameter_d__;
                        lbSampleUnit1.Text = Resources.LengthConvertor_UnitSet_mm;
                        txtSampleDim1.Text = "10";
                    }
                    #endregion
                    break;
                //case BendingSampleType.Pipe:
                //    #region
                //    {
                //        lbSampleDim1.Text = @"Diameter(d):";
                //        txtSampleDim1.Text = @"15";
                //        lbSampleDim2.Text = @"Inner Diameter(di):";
                //        txtSampleDim2.Text = @"5";
                //        lbSampleUnit1.Text = lbSampleUnit2.Text = @"mm";
                //    }
                //    #endregion
                //    break;

                case BendingSampleType.Rectangular:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Width_w__;
                        txtSampleDim1.Text = "10";
                        lbSampleDim2.Text = Resources.FrmTestSetting_Thickness_t_;
                        txtSampleDim2.Text = "5";
                        lbSampleUnit1.Text = lbSampleUnit2.Text = Resources.LengthConvertor_UnitSet_mm;
                    }
                    #endregion
                    break;

                case BendingSampleType.Inertia:
                    #region
                    {
                        lbSampleDim1.Text = Resources.FrmTestSetting_Inertia_;
                        lbSampleUnit1.Text = Resources.FrmTestSetting_mm4;
                        txtSampleDim1.Text = "10";
                    }
                    #endregion
                    break;
            }

        }


        private void ComputeAreaInertia(object sender, EventArgs e)
        {
            double dim1, dim2, dim3;
            txtSampleDim1.BackColor = (double.TryParse(txtSampleDim1.Text, out dim1)) ? Color.White : Color.Red;
            txtSampleDim2.BackColor = (double.TryParse(txtSampleDim2.Text, out dim2)) ? Color.White : Color.Red;
            txtSampleDim3.BackColor = (double.TryParse(txtSampleDim3.Text, out dim3)) ? Color.White : Color.Red;

            if (isTensionCompersionSample)
            {
                var sampleType = (TensionCompressionSampleType)Enum.Parse(typeof(TensionCompressionSampleType), cbSampleType.SelectedValue as string);
                sample = new TestingSample(sampleType, txtSampleId.Text, txtSampleGS.ValueInDouble, dim1, dim2, dim3);
                txtSampleAreaInertia.Text = string.Format("{0:0.#####}", sample.Area);
            }
            else
            {
                var sampleType = (BendingSampleType)Enum.Parse(typeof(BendingSampleType), cbSampleType.SelectedValue as string);
                sample = new TestingSample(sampleType, threePointBending, txtSampleId.Text, txtSampleGS.ValueInDouble, txtSampleGP.ValueInDouble, dim1, dim2);
                txtSampleAreaInertia.Text = string.Format("{0:0.#####}", sample.Inertia);
            }
        }

        #endregion

        #region TestMethodType

        private void InitializeMethodFields()
        {
            var mtDictionary = new Dictionary<TestMethodType, string>
            {
                { TestMethodType.Tensile, Resources.FrmTestSetting_Tensile },
                { TestMethodType.Compressive, Resources.FrmTestSetting_Compressive },
                { TestMethodType.Cyclic, Resources.FrmTestSetting_Cyclic },
                { TestMethodType.Step, Resources.FrmTestSetting_Step },
                { TestMethodType.Creep, Resources.FrmTestSetting_Creep },
                { TestMethodType.Relaxation, Resources.FrmTestSetting_Relaxation }
            };

            cbMethodTestMethod.ValueMember = "Key";
            cbMethodTestMethod.DisplayMember = "Value";
            cbMethodTestMethod.DataSource = mtDictionary.ToList();

            var ctrlModes = MeasureTool.MeasurAbbreviations.Where(a => 
                a.Key == "Force" ||
                a.Key == "Extension" ||
                a.Key == "Stress" ||
                a.Key == "TrueStress" ||
                a.Key == "MassStress" ||
                a.Key == "LengthStress" ||
                a.Key == "Strain" ||
                a.Key == "TrueStrain"
                );
            
            cbTensilePreLoadType.ValueMember = "Key";
            cbTensilePreLoadType.DisplayMember = "Value";
            cbTensilePreLoadType.DataSource = ctrlModes.ToList();
            TensileControlTypeChanges_SelectedIndexChanged(cbTensilePreLoadType, EventArgs.Empty);

            cbTensileSecSpeedType.ValueMember = "Key";
            cbTensileSecSpeedType.DisplayMember = "Value";
            cbTensileSecSpeedType.DataSource = ctrlModes.ToList();
            TensileControlTypeChanges_SelectedIndexChanged(cbTensileSecSpeedType, EventArgs.Empty);

            var s2eDictionary = new Dictionary<string, string>
            {
                { StrainToExtenMode.Strain.ToString(), Resources.FrmTestSetting_Strain  },
                { StrainToExtenMode.Extention.ToString(), Resources.FrmTestSetting_Extension },
                { StrainToExtenMode.Peak.ToString(), Resources.FrmTestSetting_Peak },
            };
            cbTensileStoEType.ValueMember = "Key";
            cbTensileStoEType.DisplayMember = "Value";
            cbTensileStoEType.DataSource = s2eDictionary.ToList();
            TensileControlStrainToExten_SelectedIndexChanged(cbTensileStoEType, EventArgs.Empty);

            var srDictionary = new Dictionary<string, string>
            {
                { StrainRemoveOptions.Stop.ToString(), Resources.FrmTestSetting_Stop },
                { StrainRemoveOptions.Continue.ToString(), Resources.FrmTestSetting_Continue },
            };
            cbTensileStoEChangeMode.ValueMember = "Key";
            cbTensileStoEChangeMode.DisplayMember = "Value";
            cbTensileStoEChangeMode.DataSource = srDictionary.ToList();


            var zcDictionary = new Dictionary<string, string>
            {
                { ZeroCode.None.ToString(), "None" },
                { ZeroCode.Strain.ToString(), "Strain" },
                { ZeroCode.Exten.ToString(), "Exten" },
                { ZeroCode.Force.ToString(),"Force" },
                { ZeroCode.SE.ToString(), "SE" },
                { ZeroCode.SEF.ToString(), "SEF" },
            };
            cbTensilePreLoadSetZero.ValueMember = "Key";
            cbTensilePreLoadSetZero.DisplayMember = "Value";
            cbTensilePreLoadSetZero.DataSource = zcDictionary.ToList();

            cbCyclicRateControl.ValueMember = "Key";
            cbCyclicRateControl.DisplayMember = "Value";
            cbCyclicRateControl.DataSource = MeasureTool.MeasurAbbreviations.Where(a =>
                (new[]
                {
                    MeasureType.Force.ToString(),
                    MeasureType.Strain.ToString(),
                    MeasureType.Extension.ToString(),
                }).Contains(a.Key)).ToList();

            cbCyclicLimitType.ValueMember = "Key";
            cbCyclicLimitType.DisplayMember = "Value";
            cbCyclicLimitType.DataSource = MeasureTool.MeasurAbbreviations.Where(a =>
                (new[]
                {
                    MeasureType.Force.ToString(),
                    MeasureType.Strain.ToString(),
                    MeasureType.Extension.ToString(),
                }).Contains(a.Key)).ToList();

            cbConditionType.ValueMember = "Key";
            cbConditionType.DisplayMember = "Value";
            cbConditionType.DataSource = MeasureTool.MeasurAbbreviations.Where(a =>
                (new[]
                {
                    MeasureType.Force.ToString(),
                    MeasureType.Extension.ToString(),
                    MeasureType.Stress.ToString(),
                    MeasureType.Strain.ToString(),
                }).Contains(a.Key)).ToList();

            cbStepSetPointType.ValueMember = "Key";
            cbStepSetPointType.DisplayMember = "Value";
            cbStepSetPointType.DataSource = ctrlModes.ToList();

            ctrlModes = ctrlModes.Where(a => a.Key != "SpecificStress");
            cbStepSetPointRateControl.ValueMember = "Key";
            cbStepSetPointRateControl.DisplayMember = "Value";
            cbStepSetPointRateControl.DataSource = ctrlModes.ToList();


            cbCreepSetPointRateControl.ValueMember = "Key";
            cbCreepSetPointRateControl.DisplayMember = "Value";
            cbCreepSetPointRateControl.DataSource = ctrlModes.ToList();

            cbCreepSetPointType.ValueMember = "Key";
            cbCreepSetPointType.DisplayMember = "Value";
            cbCreepSetPointType.DataSource = MeasureTool.MeasurAbbreviations.Where(a =>
                Enum.GetNames(typeof(CreepSetPoint)).Contains(a.Key)).ToList();

            cbCreepPreloadType.ValueMember = "Key";
            cbCreepPreloadType.DisplayMember = "Value";
            cbCreepPreloadType.DataSource = MeasureTool.MeasurAbbreviations.Where(a =>
                Enum.GetNames(typeof(CreepSetPoint)).Contains(a.Key)).ToList();

            cbRelaxSetPointRateControl.ValueMember = "Key";
            cbRelaxSetPointRateControl.DisplayMember = "Value";
            cbRelaxSetPointRateControl.DataSource = ctrlModes.ToList();

            cbRelaxSetPointType.ValueMember = "Key";
            cbRelaxSetPointType.DisplayMember = "Value";
            cbRelaxSetPointType.DataSource = MeasureTool.MeasurAbbreviations.Where(a =>
                    Enum.GetNames(typeof(RelaxationSetPoint)).Contains(a.Key)).ToList();

            //cboDateCultureFormat.ValueMember = "Key";
            //cboDateCultureFormat.DisplayMember = "Value";
            cboDateCultureFormat.DataSource =
                Enum.GetNames(typeof(TestInformation.DateCultureFormats)).Select(p => p).ToArray();
        }

        public void UpdateUnit()
        {
            cbSpeedUnits.ValueMember = "Key";
            cbSpeedUnits.DisplayMember = "Value";
            cbSpeedUnits.DataSource = UnitManager.ExtenControlUnits.ToArray().ToDictionary().ToList();

			TensileControlTypeChanges_SelectedIndexChanged(cbTensilePreLoadType, EventArgs.Empty);//
            TensileControlTypeChanges_SelectedIndexChanged(cbTensileSecSpeedType, EventArgs.Empty);//
            TensileControlStrainToExten_SelectedIndexChanged(cbTensileStoEType, EventArgs.Empty);//

            RateContolChanged(cbCyclicRateControl, EventArgs.Empty);
            cbCycleLimitType_SelectedIndexChanged(cbCyclicLimitType, EventArgs.Empty);

            RateContolChanged(cbStepSetPointRateControl, EventArgs.Empty);
            cbStepSetPointType_SelectedIndexChanged(cbStepSetPointType, EventArgs.Empty);

            RateContolChanged(cbCreepSetPointRateControl, EventArgs.Empty);
            cbCreepSetPointType_SelectedIndexChanged(cbCreepSetPointType, EventArgs.Empty);
            cbCreepPreloadType_SelectedIndexChanged(cbCreepPreloadType, EventArgs.Empty);

            RateContolChanged(cbRelaxSetPointRateControl, EventArgs.Empty);
            cbRelaxationSetPoint_SelectedIndexChanged(cbRelaxSetPointType, EventArgs.Empty);

            txtCreepSetPoint.Text= UnitManager.ConvertToCurrent(txtCreepSetPoint.Tag?.ToString() ?? "0.0", lbCreepSetPointUnit.Tag as string ?? "").ToString(CultureInfo.InvariantCulture);
            txtCreepPreload.Text = UnitManager.ConvertToCurrent(txtCreepPreload.Tag?.ToString() ?? "0.0", lblCreepPreloadUnit.Tag as string ??"").ToString(CultureInfo.InvariantCulture);

			lbStepForceUnit.Text =UnitManager.TranslateUnitTitle(UnitManager.ForceUnit);
			lbStepForceUnit.Tag = UnitManager.ForceUnit;

            lbStepSetExtensionUbit.Text =UnitManager.TranslateUnitTitle(UnitManager.ExtensionUnit);
            lbStepSetExtensionUbit.Tag  = UnitManager.ExtensionUnit;

		}

		private void cbMethodTestMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbTestMethods.SelectedIndex = cbMethodTestMethod.SelectedIndex;
                pnlSpeed.Visible = cbMethodTestMethod.SelectedIndex < 2;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public TestParameters GetTestParameters()
        {
            Test.StrainToExtenEnabled = false;
            var testMethod = (TestMethodType)cbMethodTestMethod.SelectedValue;
            TestParameters properties = null;
            Test.BreakForceOver = null;
            switch (testMethod)
            {
                case TestMethodType.Compressive:
                    properties = GetCompressiveProperties();
                    break;

                case TestMethodType.Creep:
                    properties = GetCreepProperties();
                    Test.BreakForceOver = txtBreakForceOver.ValueInDouble;
                    break;

                case TestMethodType.Relaxation:
                    properties = GetRelaxationProperties();
                    break;

                case TestMethodType.Cyclic:
                    properties = GetCyclicProperties();
                    break;

                case TestMethodType.Step:
                    properties = GetStepProperties();
                    break;

                case TestMethodType.Tensile:
                    SetS2E();
                    properties = GetTensileProperties();
                    ((TensileTestParameters)properties).StrainToExtenMode = Test.StrainToExtenMode;
                    ((TensileTestParameters)properties).StrainToExtenSetPoint = Test.StrainToExtenSetPoint;

                    Test.BreakForceOver = txtBreakForceOver.ValueInDouble;
                    break;
            }

            Test.CustomeStopType = cbStopCondition.Checked ? (TestControlMode)Enum.Parse(typeof(TestControlMode), cbCreepSetPointType.SelectedValue as string) : 0;
            Test.CustomeStopValue = UnitManager.ConvertToBase(txtConditionValue.Text, lbConditionUbit.Tag as string ?? "");

            return properties;
        }

        private void SetS2E()
        {
            Test.StrainToExtenEnabled = cbTensileEnableStoE.Checked;
            if (cbTensileEnableStoE.Checked)
            {
                Test.StrainToExtenMode = (StrainToExtenMode)Enum.Parse(typeof(StrainToExtenMode), cbTensileStoEType.Text);
                Test.StrainToExtenSetPoint = UnitManager.ConvertToBase(txtTensileStoESetPoint.Text, cbTensileStoEUnit.Text);
                Test.RemoveStarinOptions = (StrainRemoveOptions)Enum.Parse(typeof(StrainRemoveOptions), cbTensileStoEChangeMode.Text);
            }
            else
            {
                Test.StrainToExtenMode = 0;
                Test.StrainToExtenSetPoint = 0;
                Test.RemoveStarinOptions = 0;
            }



        }

        private TestParameters GetStepProperties()  // test  dur sec
        {
            var stepTestProperties = new StepTestParameters();
            try
            {
                foreach (DataGridViewRow row in dgvStep.Rows)
                {
                    var rate = MeasureTool.MeasurAbbreviations.First(p => p.Value.Equals(row.Cells[1].Value.ToString())).Key;
                    var ctrl = MeasureTool.MeasurAbbreviations.First(p => p.Value.Equals(row.Cells[4].Value.ToString())).Key;
                    var rateV = row.Cells[2].Value.ToString().Split(" ".ToCharArray());

                    var dur = 0.0;
                    var tmp = row.Cells[7].Value.ToString().Split(" ".ToCharArray());
                    if (tmp.Length > 1)
                        dur = double.Parse(tmp[1]);

                    double? setForce = null;
                    if (bool.Parse(row.Cells[8].Value.ToString()))
                        setForce = UnitManager.ConvertToBase(row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString());
                    double? setExtension = null;

                    var setPointMode = (SetPointAction)Enum.Parse(typeof(SetPointAction), tmp[0]);

                    if (bool.Parse(row.Cells[11].Value.ToString()))
                        setExtension = UnitManager.ConvertToBase(row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString());

                    stepTestProperties.AddNewStep(
                        (TestControlMode)Enum.Parse(typeof(TestControlMode), rate),
                        UnitManager.ConvertToBase(rateV[0], row.Cells[3].Value.ToString()),
                        (TestControlMode)Enum.Parse(typeof(TestControlMode), ctrl),
                        UnitManager.ConvertToBase(row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString()),
                        setPointMode, dur * 60,
                        setForce,
                        setExtension);
                }
            }
            catch (Exception)
            {
            }
            stepTestProperties.ExtenCurrentPosition = txtCurPosition.ValueInDouble;
            return stepTestProperties;
        }

        private TestParameters GetCyclicProperties()
        {
            TestParameters testProperties = new CyclicTestParameters
            {
                Speed = UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.Text),
                CycleCount = int.Parse(txtCyclicCount.Text),
                RateControlType = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbCyclicRateControl.SelectedValue as string),
                CyclicRate = UnitManager.ConvertToBase(txtCyclicRate.Text, cbCyclicRateUnit.SelectedValue as string),
                SetPointType = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbCyclicLimitType.SelectedValue as string ),
                Limit1 = UnitManager.ConvertToBase(txtCyclicLimit1.Text, lbCyclicLimit1Unit.Text),
                Limit2 = UnitManager.ConvertToBase(txtCyclicLimit2.Text, lbCyclicLimit2Unit.Text),
                KeepTime = txtCyclicDelay.ValueInDouble * 60,
            };
            testProperties.ExtenCurrentPosition = txtCurPosition.ValueInDouble;
            return testProperties;
        }

        private RelaxationTestParameters GetRelaxationProperties()
        {
            var properties = new RelaxationTestParameters
            {
                Speed = UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.Text),
                PlotAllStages = cbRelaxPlotAll.Checked,
                PreSetPointRateType = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbRelaxSetPointRateControl.SelectedValue as string),
                PreSetPointRate = UnitManager.ConvertToBase(txtRelaxRate.ValueInDouble.ToString(),
                                                                   cbRelaxRateUnit.Text),
                StabilizingTime = (txtRelaxStablizeTime.ValueInDouble * 60),
                SetPointType = (RelaxationSetPoint)Enum.Parse(typeof(RelaxationSetPoint), cbRelaxSetPointType.SelectedValue as string),
                SetPointValue = UnitManager.ConvertToBase(txtRelaxSetPoint.ValueInDouble.ToString(),
                                                                   lbRelaxSetPointUnit.Text),
                TestDuration = (txtRelaxTestTime.ValueInDouble * 60),
                ExtenCurrentPosition = txtCurPosition.ValueInDouble,
                Decimation = txtRelaxationSampleDecimation.ValueInInt
            };
            return properties;
        }

        private int CalcPreHeatTime()
        {
            return (int)(nrPreHeatTimeH.ValueInDouble * 3600) + (int)(nrPreHeatTime.ValueInDouble * 60);
        }

        private void SetPreHeatTimes(string value)
        {
            var v = int.Parse(value);
            var h = v / 3600;
            var m = (v % 3600) / 60.0;
            nrPreHeatTimeH.Text = h.ToString();
            nrPreHeatTime.Text = m.ToString();
        }

        private int CalcCreepPreloadTime()
        {
            return (int)(txtCreepPreloadTimeH.ValueInDouble * 3600) + (int)(txtCreepPreloadTime.ValueInDouble * 60);
        }

        private void SetCreepPreloadTimes(string value)
        {
            var v = int.Parse(value);
            var h = v / 3600;
            var m = (v % 3600) / 60.0;
            txtCreepPreloadTimeH.Text = h.ToString();
            txtCreepPreloadTime.Text = m.ToString();
        }

        private int CalcCreepStablizeTime()
        {
            return (int)(txtCreepStablizeTimeH.ValueInDouble * 3600) + (int)(txtCreepStablizeTime.ValueInDouble * 60);
        }

        private void SetCreepStablizeTimes(string value)
        {
            var v = int.Parse(value);
            var h = v / 3600;
            var m = (v % 3600) / 60.0;
            txtCreepStablizeTimeH.Text = h.ToString();
            txtCreepStablizeTime.Text = m.ToString();
        }

        private int CalcCreepTestTime()
        {
            return (int)(txtCreepTestTimeH.ValueInDouble * 3600) + (int)(txtCreepTestTime.ValueInDouble * 60);
        }

        private void SetCreepTestTimes(string value)
        {
            var v = int.Parse(value);
            var h = v / 3600;
            var m = (v % 3600) / 60.0;
            txtCreepTestTimeH.Text = h.ToString();
            txtCreepTestTime.Text = m.ToString();
        }

        private CreepTestParameters GetCreepProperties()
        {
            var properties = new CreepTestParameters
            {
                Speed = UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.SelectedValue as string),
                PlotAllStages = cbCreepPlotAll.Checked,
                PreSetPointRateType = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbCreepSetPointRateControl.SelectedValue as string),
                PreSetPointRate = UnitManager.ConvertToBase(txtCreepRate.ValueInDouble.ToString(), cbCreepRateUnit.SelectedValue as string),
                StabilizingTime = CalcCreepStablizeTime(),
                SetPointType = (CreepSetPoint)Enum.Parse(typeof(CreepSetPoint), cbCreepSetPointType.SelectedValue as string),
                SetPointValue = UnitManager.ConvertToBase(txtCreepSetPoint.ValueInDouble.ToString(), lbCreepSetPointUnit.Tag as string ?? ""),
                TestDuration = CalcCreepTestTime(),
                ExtenCurrentPosition = txtCurPosition.ValueInDouble,
                Decimation = CalculateDecimation() ?? mDecimation,
                // Nazarpour
                PreLoadType = (CreepSetPoint)Enum.Parse(typeof(CreepSetPoint), cbCreepPreloadType.SelectedValue as string),
                PreLoadValue = UnitManager.ConvertToBase(txtCreepPreload.ValueInDouble.ToString(), lblCreepPreloadUnit.Text),
                PreLoadTime = CalcCreepPreloadTime(),
                TemperatureSetPoint = (float)UnitManager.ConvertToBase(txtCreepTemperatureValue.ValueInDouble.ToString(), lblCreepTemperatuerUnit.Text),
                TemperatureSetPointOffset = (float)UnitManager.ConvertToBase(txtCreepTemperatureOffsetValue.ValueInDouble.ToString(), lblCreepTemperatuerUnit.Text),
                PreHeatTime = CalcPreHeatTime(),
                ResetExtension = chkResetExtension.Checked
            };

            properties.PreLoadValue =
	            UnitManager.ConvertToBase(txtCreepPreload.ValueInDouble.ToString(), lblCreepPreloadUnit.Text);


			if (Options.HugeSampleCount > 0)
            {
                var sps = Math.Ceiling((properties.StabilizingTime + properties.TestDuration) * 100.0 / Options.HugeSampleCount);
                if (sps > properties.Decimation)
                {
                    properties.Decimation = (int)sps;
                    txtCreepSampleDecimation.Text = properties.Decimation.ToString();
                }
            }

            return properties;
        }

        private CompressiveTestParameters GetCompressiveProperties()
        {
            var properties = new CompressiveTestParameters
            {
                Speed = UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.SelectedValue as string),
                ExtenCurrentPosition = txtCurPosition.ValueInDouble
            };
            return properties;
        }

        private TensileTestParameters GetTensileProperties()
        {
            var properties = new TensileTestParameters
            {
                Rate = UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.SelectedValue as string),
                PreLoadEnabled = cbTensilePreLoad.Checked,
                PreLoadSetPointType = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbTensilePreLoadType.SelectedValue as string),
                PreLoadSetPoint = UnitManager.ConvertToBase(txtTensilePreLoadSetPoint.Text, cbPreLoadUnits.SelectedValue as string),
                PreLoadWaiting = (int)(txtTensilePreLoadWait.ValueInDouble),
                ZeroingCode = (ZeroCode)Enum.Parse(typeof(ZeroCode), cbTensilePreLoadSetZero.SelectedValue as string),
                SecondSpeedEnabled = cbTensileEnableSecondSpeed.Checked,
                SecondSpeedSetPointType = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbTensileSecSpeedType.SelectedValue as string),
                SecondSpeedSetPoint = UnitManager.ConvertToBase(txtTensileSecSpeedSetPoint.Text, cbTensileSecSpeedTypeUnit.SelectedValue as string),
                SecondRate = UnitManager.ConvertToBase(txtTensileSecondSpeed.Text, cbSpeedUnits.SelectedValue as string),
                BreakForceOver = txtBreakForceOver.ValueInDouble,
                ExtenCurrentPosition = txtCurPosition.ValueInDouble
            };
            Test.BreakForceOver = txtBreakForceOver.ValueInDouble;
            return properties;
        }

        #endregion

        #region Tensile


        private void TensileControlTypeChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = (TestControlMode)Enum.Parse(typeof(TestControlMode), (((ComboBox)sender).SelectedValue) as string);

            ComboBox comboBox = null;
            if (sender.Equals(cbTensilePreLoadType))
                comboBox = cbPreLoadUnits;
            else if (sender.Equals(cbTensileSecSpeedType))
                comboBox = cbTensileSecSpeedTypeUnit;

            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";

            switch (mode)
            {
                case TestControlMode.Force:
                    comboBox.DataSource = UnitManager.ForceUnits.ToDictionary().ToList();
                    comboBox.SelectedValue = UnitManager.ForceUnit;
                    break;

                case TestControlMode.Extension:
                    comboBox.DataSource = UnitManager.ExtensionUnits.ToDictionary().ToList();
                    comboBox.SelectedValue = UnitManager.ExtensionUnit;
                    break;

                case TestControlMode.Stress:
                case TestControlMode.TrueStress:
                    comboBox.DataSource = UnitManager.StressUnits.ToDictionary().ToList();
                    comboBox.SelectedValue = UnitManager.StressUnit;
                    break;

                case TestControlMode.Strain:
                case TestControlMode.TrueStrain:
                    comboBox.DataSource = UnitManager.StrainUnits.ToDictionary().ToList();
                    comboBox.SelectedValue = UnitManager.StrainUnit;
                    break;
            }
        }



        private void TensileControlStrainToExten_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = (StrainToExtenMode)Enum.Parse(typeof(StrainToExtenMode), (((ComboBox)sender).SelectedValue) as string);
            //UnitManager.CurrentUnitCategory = (UnitMainCategories)Enum.Parse(typeof(UnitMainCategories), cbUnitMainCatagories.Text);
            if (s2eTxtBoxLocation.X == 0 && s2eTxtBoxLocation.Y == 0)
                s2eTxtBoxLocation = new Point(txtTensileStoESetPoint.Location.X, txtTensileStoESetPoint.Location.Y);

            switch (mode)
            {
                case StrainToExtenMode.Extention:
                    cbTensileStoEUnit.DataSource = UnitManager.ExtensionUnits;
                    lbTensileS2E.Text = Resources.FrmTestSetting_At_Point_ ;
                    txtTensileStoESetPoint.Width = 96;
                    txtTensileStoESetPoint.Location = s2eTxtBoxLocation;
                    break;

                case StrainToExtenMode.Strain:
                    cbTensileStoEUnit.DataSource = UnitManager.StrainUnits;
                    lbTensileS2E.Text = Resources.FrmTestSetting_At_Point_ ;
                    txtTensileStoESetPoint.Width = 96;
                    txtTensileStoESetPoint.Location = s2eTxtBoxLocation;
                    break;

                case StrainToExtenMode.Peak:
                    cbTensileStoEUnit.DataSource = Resources.StrainConvertor_UnitSet_Percent.ToList();
                    lbTensileS2E.Text = Resources.FrmTestSetting_After_Strain_ ;
                    txtTensileStoESetPoint.Width = 76;
                    txtTensileStoESetPoint.Location = new Point(s2eTxtBoxLocation.X + (LanguageFrm.IsPersian ? 0 : 20), s2eTxtBoxLocation.Y);
                    break;

                default:
                    break;
            }
        }

        private void cbTensileEnableSecondSpeed_CheckedChanged(object sender, EventArgs e)
        {
            cbTensileSecSpeedType.Enabled = cbTensileEnableSecondSpeed.Checked;
            txtTensileSecSpeedSetPoint.Enabled = cbTensileEnableSecondSpeed.Checked;
            cbTensileSecSpeedTypeUnit.Enabled = cbTensileEnableSecondSpeed.Checked;
            txtTensileSecondSpeed.Enabled = cbTensileEnableSecondSpeed.Checked;
        }

        private void cbTensileEnableStoE_CheckedChanged(object sender, EventArgs e)
        {
            cbTensileStoEType.Enabled = cbTensileEnableStoE.Checked;
            txtTensileStoESetPoint.Enabled = cbTensileEnableStoE.Checked;
            cbTensileStoEUnit.Enabled = cbTensileEnableStoE.Checked;
            cbTensileStoEChangeMode.Enabled = cbTensileEnableStoE.Checked;
        }

        private void cbTensilePreLoad_CheckedChanged(object sender, EventArgs e)
        {
            txtTensilePreLoadSetPoint.Enabled = cbTensilePreLoad.Checked;
            cbTensilePreLoadType.Enabled = cbTensilePreLoad.Checked;
            txtTensilePreLoadWait.Enabled = cbTensilePreLoad.Checked;
            cbTensilePreLoadSetZero.Enabled = cbTensilePreLoad.Checked;
            cbPreLoadUnits.Enabled = cbTensilePreLoad.Checked;
        }

        #endregion

        #region Cyclic

        private void cbCycleLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var relaxationSetPoint = (TestControlMode)Enum.Parse(typeof(TestControlMode), (cbCyclicLimitType.SelectedValue) as string);
            var unit = "";
            switch (relaxationSetPoint)
            {
                case TestControlMode.Force:
                    unit = MeasureTool.GetUnit(MeasureType.Force).Abbreviation;
                    lbCyclicLimit1Unit.Text = unit;
                    lbCyclicLimit2Unit.Text = unit;
                    break;

                case TestControlMode.Extension:
                    unit = MeasureTool.GetUnit(MeasureType.Extension).Abbreviation;
                    lbCyclicLimit1Unit.Text = unit;
                    lbCyclicLimit2Unit.Text = unit;
                    break;

                case TestControlMode.Strain:
                    unit = MeasureTool.GetUnit(MeasureType.Strain).Abbreviation;
                    lbCyclicLimit1Unit.Text = unit;
                    lbCyclicLimit2Unit.Text = unit;
                    break;
            }
        }

        #endregion

        #region Creep

        private void cbCreepSetPointType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var creepSetPoint = (CreepSetPoint)Enum.Parse(typeof(CreepSetPoint), cbCreepSetPointType.SelectedValue as string);
            switch (creepSetPoint)
            {
                case CreepSetPoint.Force:
	                lbCreepSetPointUnit.Tag = MeasureTool.GetUnit(MeasureType.Force).Abbreviation;
					lbCreepSetPointUnit.Text = UnitManager.TranslateUnitTitle(MeasureTool.GetUnit(MeasureType.Force).Abbreviation);
                    break;

                case CreepSetPoint.Stress:
	                lbCreepSetPointUnit.Tag = MeasureTool.GetUnit(MeasureType.Stress).Abbreviation;
					lbCreepSetPointUnit.Text =UnitManager.TranslateUnitTitle(  MeasureTool.GetUnit(MeasureType.Stress).Abbreviation);
                    break;

                default:
                    break;
            }
        }

        private void cbCreepPreloadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var creepPreload = (CreepSetPoint)Enum.Parse(typeof(CreepSetPoint), cbCreepPreloadType.SelectedValue as string);
            switch (creepPreload)
            {
                case CreepSetPoint.Force:
	                lblCreepPreloadUnit.Tag = MeasureTool.GetUnit(MeasureType.Force).Abbreviation;
					lblCreepPreloadUnit.Text = UnitManager.TranslateUnitTitle(MeasureTool.GetUnit(MeasureType.Force).Abbreviation);
                    break;

                case CreepSetPoint.Stress:
	                lblCreepPreloadUnit.Tag = MeasureTool.GetUnit(MeasureType.Stress).Abbreviation;
					lblCreepPreloadUnit.Text =
		                UnitManager.TranslateUnitTitle(MeasureTool.GetUnit(MeasureType.Stress).Abbreviation);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region relaxation

        private void cbRelaxationSetPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRelaxSetPointUnit();
        }

        private void SetRelaxSetPointUnit()
        {
            var relaxationSetPoint = (RelaxationSetPoint)Enum.Parse(typeof(RelaxationSetPoint), (cbRelaxSetPointType.SelectedValue) as string);
            switch (relaxationSetPoint)
            {
                case RelaxationSetPoint.Extension:
                    lbRelaxSetPointUnit.Text = MeasureTool.GetUnit(MeasureType.Extension).Abbreviation;
                    lbRelaxCm.Text = "";
                    break;

                case RelaxationSetPoint.Strain:
                    lbRelaxSetPointUnit.Text = MeasureTool.GetUnit(MeasureType.Strain).Abbreviation;
                    lbRelaxCm.Text = "";
                    break;

                case RelaxationSetPoint.Force:
                    lbRelaxSetPointUnit.Text = MeasureTool.GetUnit(MeasureType.Force).Abbreviation;
                    lbRelaxCm.Text = Resources.FrmTestSetting_SetRelaxSetPointUnit___Warning;
                    break;

                case RelaxationSetPoint.Stress:
                    lbRelaxSetPointUnit.Text = MeasureTool.GetUnit(MeasureType.Stress).Abbreviation;
                    lbRelaxCm.Text = Resources.FrmTestSetting_SetRelaxSetPointUnit___Warning;
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region step

        private void cbStepSetPointType_SelectedIndexChanged(object sender, EventArgs e)
        {
	        lbStepSetPointUnit.Tag = MeasureTool.GetUnit((MeasureType)Enum.Parse(typeof(MeasureType), cbStepSetPointType.SelectedValue as string ?? "" )).Abbreviation;
			lbStepSetPointUnit.Text = UnitManager.TranslateUnitTitle(lbStepSetPointUnit.Tag as string);
            txtStepSetPoint.ResetText();
            txtStepSetPoint.Tag = null;
        }

        private void llStepAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var value = txtStepSetPointAction.Enabled ?
                string.Format("{0} {1} min", cbSetPointAction.Text, txtStepSetPointAction.Text) :
                string.Format("{0}", cbSetPointAction.Text);
            txtStepSetPoint.Tag = null;
            dgvStep.Rows.Add(dgvStep.Rows.Count + 1,
                cbStepSetPointRateControl.SelectedValue, txtStepRate.Text,
                cbStepRateUnit.SelectedValue,
                cbStepSetPointType.SelectedValue, txtStepSetPoint.Text, lbStepSetPointUnit.Text, value,
                cbStepSetForce.Checked, txtStepSetForce.Text, lbStepForceUnit.Tag as string ??"",
                cbStepSetExtension.Checked, txtStepSetExtension.Text, lbStepSetExtensionUbit.Tag as string ?? "");
        }

        private void llStpUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var row = dgvStep.SelectedRows[0];
            var value = txtStepSetPointAction.Enabled ?
                string.Format("{0} {1} min", cbSetPointAction.SelectedValue, txtStepSetPointAction.Text) :
                string.Format("{0}", cbSetPointAction.SelectedValue);

            row.SetValues(row.Cells[0].Value, cbStepSetPointRateControl.SelectedValue, txtStepRate.Text,
                             cbStepRateUnit.SelectedValue,
                             cbStepSetPointType.SelectedValue, txtStepSetPoint.Text, lbStepSetPointUnit.Tag as string, value,
                             cbStepSetForce.Checked, txtStepSetForce.Text, lbStepForceUnit.Tag as string ??"",
                             cbStepSetExtension.Checked, txtStepSetExtension.Text, lbStepSetExtensionUbit.Tag as string ??"");

            llStepUpdate.Enabled = false;
        }

        private void llStepCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (var row in dgvStep.SelectedRows)
                {
                    dgvStep.Rows.Remove((DataGridViewRow)row);
                }
            }
            catch
            {
            }
            int index = 1;
            foreach (DataGridViewRow row in dgvStep.Rows)
            {
                row.Cells[0].Value = index++;
            }
        }

        private void dgvStep_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dgvStep.SelectedRows[0];
            cbStepSetPointRateControl.SelectedValue = row.Cells[1].Value.ToString();
            txtStepRate.Text = row.Cells[2].Value.ToString();
            cbStepRateUnit.SelectedValue = row.Cells[3].Value.ToString();
            cbStepSetPointType.SelectedValue = row.Cells[4].Value.ToString();
            txtStepSetPoint.Text = row.Cells[5].Value.ToString();
			lbStepSetPointUnit.Tag = row.Cells[6].Value.ToString();
			lbStepSetPointUnit.Text = UnitManager.TranslateUnitTitle(lbStepSetPointUnit.Tag as string);
			var setPointAction = row.Cells[7].Value.ToString().Split(" ".ToCharArray());
            if (setPointAction.Length == 1)
            {
                cbSetPointAction.SelectedValue = setPointAction[0];
                txtStepSetPointAction.Text = "0";
            }
            else
            {
                cbSetPointAction.SelectedValue = setPointAction[0];
                txtStepSetPointAction.Text = setPointAction[1];
            }
            cbStepSetForce.Checked = bool.Parse(row.Cells[8].Value.ToString());
            txtStepSetForce.Text = row.Cells[9].Value.ToString();
            lbStepForceUnit.Text =UnitManager.TranslateUnitTitle( row.Cells[10].Value.ToString());
            lbStepForceUnit.Tag = row.Cells[10].Value.ToString();
            cbStepSetExtension.Checked = bool.Parse(row.Cells[11].Value.ToString());
            txtStepSetExtension.Text = row.Cells[12].Value.ToString();
            lbStepSetExtensionUbit.Text =UnitManager.TranslateUnitTitle(row.Cells[13].Value.ToString());
            lbStepSetExtensionUbit.Tag = row.Cells[13].Value.ToString();

            llStepUpdate.Enabled = true;
        }

        private void dgvStep_SelectionChanged(object sender, EventArgs e)
        {
            llStepUpdate.Enabled = false;
        }

        #endregion

        #region Apply & Ok

        private void llMeasuresOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MeasureChanged = true;
            SaveMeasures();
        }


        #endregion

        #region Measure tools

        private void cbMeasureType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType1.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType1.SelectedValue.ToString();
            cbM1Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void cbMeasureType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType2.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType2.SelectedValue.ToString();
            cbM2Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void cbMeasureType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType3.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType3.SelectedValue.ToString();
            cbM3Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void cbMeasureType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType4.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType4.SelectedValue.ToString();
            cbM4Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void cbMeasureType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType5.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType5.SelectedValue.ToString();
            cbM5Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void cbMeasureType6_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType6.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType6.SelectedValue.ToString();
            cbM6Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void cbMeasureType7_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbMeasureType7.SelectedValue.Equals(NoneMeasure) ? "0" : cbMeasureType7.SelectedValue.ToString();
            cbM7Tool.DataSource = MeasureTool.GetToolNames(text);
        }

        private void LoadMeasures()
        {
            var mtTypes = new Dictionary<string, string>
            {
                { MeasureType.None.ToString(),       MeasureTool.GetMeasureName(MeasureType.None) },
                { MeasureType.Force.ToString(),      MeasureTool.GetMeasureName(MeasureType.Force)},
                { MeasureType.Extension.ToString(),  MeasureTool.GetMeasureName(MeasureType.Extension)},
                { MeasureType.Stress.ToString(),     MeasureTool.GetMeasureName(MeasureType.Stress)},
                { MeasureType.TrueStress.ToString(), MeasureTool.GetMeasureName(MeasureType.TrueStress)},
                { MeasureType.MassStress.ToString(), MeasureTool.GetMeasureName(MeasureType.MassStress)},
                { MeasureType.LengthStress.ToString(),MeasureTool.GetMeasureName(MeasureType.LengthStress)},
                { MeasureType.Strain.ToString(),     MeasureTool.GetMeasureName(MeasureType.Strain)},
                { MeasureType.TrueStrain.ToString(), MeasureTool.GetMeasureName(MeasureType.TrueStrain)},
                { MeasureType.LStrain.ToString(),    MeasureTool.GetMeasureName(MeasureType.LStrain)},
                { MeasureType.Time.ToString(),       MeasureTool.GetMeasureName(MeasureType.Time) }
            };

            //var mtTypes = MeasureTool.GetMeasureNames();

            cbMeasureType1.ValueMember = "Key";
            cbMeasureType1.DisplayMember = "Value";
            cbMeasureType1.DataSource = mtTypes.ToList();

            cbMeasureType2.ValueMember = "Key";
            cbMeasureType2.DisplayMember = "Value";
            cbMeasureType2.DataSource = mtTypes.ToList();

            cbMeasureType3.ValueMember = "Key";
            cbMeasureType3.DisplayMember = "Value";
            cbMeasureType3.DataSource = mtTypes.ToList();

            cbMeasureType4.ValueMember = "Key";
            cbMeasureType4.DisplayMember = "Value";
            cbMeasureType4.DataSource = mtTypes.ToList();

            cbMeasureType5.ValueMember = "Key";
            cbMeasureType5.DisplayMember = "Value";
            cbMeasureType5.DataSource = mtTypes.ToList();

            cbMeasureType6.ValueMember = "Key";
            cbMeasureType6.DisplayMember = "Value";
            cbMeasureType6.DataSource = mtTypes.ToList();

            cbMeasureType7.ValueMember = "Key";
            cbMeasureType7.DisplayMember = "Value";
            cbMeasureType7.DataSource = mtTypes.ToList();

            Dictionary<int, MeasureTool> measureTools = null;
            using (var sl = SettingLoader.Current)
            {
                measureTools = sl.GetMeasureTools();
            }

            try
            {
                cbMeasureType1.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[0].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[0].MeasureType) ? MeasureType.Temperature : measureTools[0].MeasureType));
                txtMeasure1Label.Text = string.Format("{0}", measureTools[0].MeasureLable);
                cbM1Tool.Text = measureTools[0].Tool;

                cbMeasureType2.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[1].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[1].MeasureType) ? MeasureType.Temperature : measureTools[1].MeasureType));
                txtMeasure2Label.Text = string.Format("{0}", measureTools[1].MeasureLable);
                cbM2Tool.Text = measureTools[1].Tool;

                cbMeasureType3.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[2].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[2].MeasureType) ? MeasureType.Temperature : measureTools[2].MeasureType));
                txtMeasure3Label.Text = string.Format("{0}", measureTools[2].MeasureLable);
                cbM3Tool.Text = measureTools[2].Tool;

                cbMeasureType4.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[3].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[3].MeasureType) ? MeasureType.Temperature : measureTools[3].MeasureType));
                txtMeasure4Label.Text = string.Format("{0}", measureTools[3].MeasureLable);
                cbM4Tool.Text = measureTools[3].Tool;

                cbMeasureType5.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[4].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[4].MeasureType) ? MeasureType.Temperature : measureTools[4].MeasureType));
                txtMeasure5Label.Text = string.Format("{0}", measureTools[4].MeasureLable);
                cbM5Tool.Text = measureTools[4].Tool;

                cbMeasureType6.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[5].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[5].MeasureType) ? MeasureType.Temperature : measureTools[5].MeasureType));
                txtMeasure6Label.Text = string.Format("{0}", measureTools[5].MeasureLable);
                cbM6Tool.Text = measureTools[5].Tool;

                cbMeasureType7.SelectedValue = string.Format("{0}", MeasureTool.IsExtension(measureTools[6].MeasureType) ? MeasureType.Extension : (MeasureTool.IsTemperature(measureTools[6].MeasureType) ? MeasureType.Temperature : measureTools[6].MeasureType));
                txtMeasure7Label.Text = string.Format("{0}", measureTools[6].MeasureLable);
                cbM7Tool.Text = measureTools[6].Tool; 
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveMeasures()
        {
            Dictionary<int, MeasureTool> measureTools = new Dictionary<int, MeasureTool>();
            try
            {
                if (!NoneMeasure.Equals(cbMeasureType1.SelectedValue))
                    measureTools[0] = new MeasureTool
                    {
                        MeasureLable = txtMeasure1Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType1.SelectedValue.ToString()),
                        Order = 0,
                        Tool = cbM1Tool.Text,
                    };

                if (!NoneMeasure.Equals(cbMeasureType2.SelectedValue))
                    measureTools[1] = new MeasureTool
                    {
                        MeasureLable = txtMeasure2Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType2.SelectedValue.ToString()),
                        Order = 1,
                        Tool = cbM2Tool.Text,
                    };

                if (!NoneMeasure.Equals(cbMeasureType3.SelectedValue))
                    measureTools[2] = new MeasureTool
                    {
                        MeasureLable = txtMeasure3Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType3.SelectedValue.ToString()),
                        Order = 2,
                        Tool = cbM3Tool.Text,
                    };

                if (!NoneMeasure.Equals(cbMeasureType4.SelectedValue))
                    measureTools[3] = new MeasureTool
                    {
                        MeasureLable = txtMeasure4Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType4.SelectedValue.ToString()),
                        Order = 3,
                        Tool = cbM4Tool.Text,
                    };

                if (!NoneMeasure.Equals(cbMeasureType5.SelectedValue))
                    measureTools[4] = new MeasureTool
                    {
                        MeasureLable = txtMeasure5Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType5.SelectedValue.ToString()),
                        Order = 4,
                        Tool = cbM5Tool.Text,
                    };

                if (!NoneMeasure.Equals(cbMeasureType6.SelectedValue))
                    measureTools[5] = new MeasureTool
                    {
                        MeasureLable = txtMeasure6Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType6.SelectedValue.ToString()),
                        Order = 5,
                        Tool = cbM6Tool.Text,
                    };

                if (!NoneMeasure.Equals(cbMeasureType7.SelectedValue))
                    measureTools[5] = new MeasureTool
                    {
                        MeasureLable = txtMeasure7Label.Text,
                        MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), cbMeasureType7.SelectedValue.ToString()),
                        Order = 6,
                        Tool = cbM7Tool.Text,
                    };
            }
            catch (Exception)
            {
            }
            var order = 0;
            foreach (var measureTool in measureTools)
            {
                measureTool.Value.Order = order;
                order++;
            }
            using (var sl = SettingLoader.Current)
            {
                sl.SetMeasureTools(measureTools);
            }
        }

        #endregion

        #region Diagram

        private void LoadDiagramAxis()
        {
	        cbDiagramXAxis.ValueMember = "Key";
			cbDiagramXAxis.DisplayMember = "Value";
            cbDiagramXAxis.DataSource = MeasureTool.MeasurAbbreviations.ToList();

            cbDiagramYAxis.ValueMember = "Key";
            cbDiagramYAxis.DisplayMember = "Value";
			cbDiagramYAxis.DataSource = MeasureTool.MeasurAbbreviations.ToList();

			cbDiagramY2Axis.ValueMember = "Key";
			cbDiagramY2Axis.DisplayMember = "Value";
			cbDiagramY2Axis.DataSource = MeasureTool.MeasurAbbreviations.ToList();
        }

        private void cbDiagramXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckXAxis();
        }

        private void CheckXAxis()
        {
            var mtype = MeasureTool.GetMeasureType(cbDiagramXAxis.SelectedValue as string);
            XMeasureType = MeasureTool.IsExtension(mtype) ? MeasureType.Extension : mtype;
            lbDiagramXUnit.Text = MeasureTool.GetUnit(XMeasureType).Abbreviation;
        }

        private void cbDiagramYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckYAxis();
        }

        private void CheckYAxis()
        {
            var mtype = MeasureTool.GetMeasureType(cbDiagramYAxis.SelectedValue as string);
            YMeasureType = MeasureTool.IsExtension(mtype) ? MeasureType.Extension : mtype;
            lbDiagramYUnit.Text = MeasureTool.GetUnit(YMeasureType).Abbreviation;
        }

        private void CheckY2Axis()
        {
            var mtype = MeasureTool.GetMeasureType(cbDiagramY2Axis.SelectedValue as string);
            Y2MeasureType = MeasureTool.IsExtension(mtype) ? MeasureType.Extension : mtype;
            //lbDiagramY2Unit.Text = MeasureTool.GetUnit(Y2MeasureType).Abbreviation;
        }


        #endregion

        #region public

        //private string MeasureToUnit(MeasureType measure)
        //{
        //    var unit = "";
        //    switch (measure)
        //    {
        //        case MeasureType.Extension:
        //        case MeasureType.LFExtension:
        //        case MeasureType.ExtenExtension:
        //            unit = cbUnitLength.Text;
        //            break;

        //        case MeasureType.LStrain:
        //        case MeasureType.Strain:
        //        case MeasureType.TrueStrain:
        //            unit = cbUnitStrain.Text;
        //            break;

        //        case MeasureType.Force:
        //            unit = cbUnitForce.Text;
        //            break;

        //        case MeasureType.Stress:
        //        case MeasureType.TrueStress:
        //            unit = cbUnitStress.Text;
        //            break;

        //        case MeasureType.Time:
        //            unit = cbUnitTime.Text;
        //            break;

        //        default:
        //            break;
        //    }

        //    return unit;
        //}

        private void RateContolChanged(object sender, EventArgs e)
        {
            var rateContorl = (TestControlMode)Enum.Parse(typeof(TestControlMode), ((ComboBox)sender).SelectedValue as string);
            //UnitManager.CurrentUnitCategory = (UnitMainCategories)Enum.Parse(typeof(UnitMainCategories), cbUnitMainCatagories.Text);

            ComboBox cbRateContolUnit = null;
            if (sender.Equals(cbCreepSetPointRateControl))
            {
                cbRateContolUnit = cbCreepRateUnit;
            }
            else if (sender.Equals(cbRelaxSetPointRateControl))
            {
                cbRateContolUnit = cbRelaxRateUnit;
            }
            else if (sender.Equals(cbCyclicRateControl))
            {
                cbRateContolUnit = cbCyclicRateUnit;
            }
            else if (sender.Equals(cbStepSetPointRateControl))
            {
                cbRateContolUnit = cbStepRateUnit;
            }

            cbRateContolUnit.DisplayMember = "Value";
            cbRateContolUnit.ValueMember = "Key";

            switch (rateContorl)
            {
                case TestControlMode.Force:
                    cbRateContolUnit.DataSource = UnitManager.ForceControlUnits.ToDictionary().ToList();
                    cbRateContolUnit.SelectedIndex = 0;
                    break;

                case TestControlMode.Extension:
                    cbRateContolUnit.DataSource = UnitManager.ExtenControlUnits.ToDictionary().ToList();
                    cbRateContolUnit.SelectedIndex = 0;
                    break;

                case TestControlMode.Stress:
                case TestControlMode.TrueStress:
                    cbRateContolUnit.DataSource = UnitManager.StressControlUnits.ToDictionary().ToList();
                    cbRateContolUnit.SelectedIndex = 0;
                    break;

                case TestControlMode.Strain:
                case TestControlMode.TrueStrain:
                    cbRateContolUnit.DataSource = UnitManager.StrainControlUnits.ToDictionary().ToList();
                    cbRateContolUnit.SelectedIndex = 0;
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Export Import

        private void Export(string path)
        {
            Test.BreakCounter = txtBreakCounter.ValueInInt;
            SettingLoader.Current.SaveOption();

            var xmlPath = string.Format("Standards");
            if (!Directory.Exists(xmlPath))
                Directory.CreateDirectory(xmlPath);

            xmlPath = path;

            var xml = GetXml();

            xml.Save(xmlPath);
        }

        private XDocument GetXml()
        {
			var xml = new XDocument(new XElement("root"))
			{
				Declaration = new XDeclaration("1.0", "utf-8", "true")
			};

			xml.Descendants("root").First().Add(new XElement("Sample",
															 new XAttribute("TestingSampleType", cbTestingSampleType.SelectedValue as string),
															 new XAttribute("SampleId", txtSampleId.Text),
															 new XAttribute("SampleGS", txtSampleGS.Text),
															 new XAttribute("SampleGP", txtSampleGP.Text),
															 new XAttribute("Type", cbSampleType.SelectedValue as string),
															 new XAttribute("Dim1", txtSampleDim1.Text),
															 new XAttribute("Dim2", txtSampleDim2.Text),
															 new XAttribute("Dim3", txtSampleDim3.Text),
															 new XAttribute("Area", txtSampleAreaInertia.Text)));

			xml.Descendants("root").First().Add(GetMethodElemnet());
			xml.Descendants("root").First().Add(new XElement("HardwareParams",
															 new XAttribute("Kep", txtKep.Text),
															 new XAttribute("Kei", txtKei.Text),
															 new XAttribute("Ked", txtKed.Text),
															 new XAttribute("Etorelance", txtExtenTor.Text),
															 new XAttribute("Ksi", txtKsi.Text),
															 new XAttribute("Ksp", txtKsp.Text),
															 new XAttribute("Ksd", txtKsd.Text),
															 new XAttribute("Storelance", txtStrainTor.Text),
															 new XAttribute("Kfi", txtKfi.Text),
															 new XAttribute("Kfp", txtKfp.Text),
															 new XAttribute("Kfd", txtKfd.Text),
															 new XAttribute("Ftorelance", txtForceTor.Text)));

			xml.Descendants("root").First().Add(new XElement("Diagram",
															 new XAttribute("X", cbDiagramXAxis.SelectedValue as string),
															 new XAttribute("Y", cbDiagramYAxis.SelectedValue as string),
															 new XAttribute("Y2", cbDiagramY2Axis.SelectedValue as string),
															 new XAttribute("StartScale",
																			cbDiagramStartUp.Checked.ToString()),
															 new XAttribute("MaxX", txtDiagramXStop.Text),
															 new XAttribute("MaxY", txtDiagramYStop.Text),
															 new XAttribute("ReportFilePath",
																			cbDefaultReport.Checked
																				? ""
																				: cbReportFiles.Text)));
			return xml;
        }

        private bool Import(string path)
        {
            if (!File.Exists(path))
                return false;

            var xml = XDocument.Load(path, LoadOptions.None);
            //xDocument = xml;

			return SetXml(xml);
        }

        private bool SetXml(XDocument xml)
        {
	        var retVale = true;

	        try
			{
				var element = xml.Descendants("root").Descendants("Sample").First();
				cbTestingSampleType.SelectedValue = element.Attribute("TestingSampleType").Value;
				txtSampleId.Text = element.Attribute("SampleId").Value;
				txtSampleGS.Text = element.Attribute("SampleGS").Value;
				txtSampleGP.Text = element.Attribute("SampleGP").Value;
				cbSampleType.SelectedValue = element.Attribute("Type").Value;
				txtSampleDim1.Text = element.Attribute("Dim1").Value;
				txtSampleDim2.Text = element.Attribute("Dim2").Value;
				txtSampleDim3.Text = element.Attribute("Dim3").Value;
				txtSampleAreaInertia.Text = element.Attribute("Area").Value;
			}
			catch
			{
				retVale = false;
			}

			try
			{
				var method = xml.Descendants("root").Descendants("GetTestParameters").First();
				SetMethodFields(method);
				var hardwareParams = xml.Descendants("root").Descendants("HardwareParams").First();
				txtKep.Text = hardwareParams.Attribute("Kep").Value;
				txtKei.Text = hardwareParams.Attribute("Kei").Value;
				txtKed.Text = hardwareParams.Attribute("Ked").Value;
				txtExtenTor.Text = hardwareParams.Attribute("Etorelance").Value;

				txtKsi.Text = hardwareParams.Attribute("Ksi").Value;
				txtKsp.Text = hardwareParams.Attribute("Ksp").Value;
				txtKsd.Text = hardwareParams.Attribute("Ksd").Value;
				txtStrainTor.Text = hardwareParams.Attribute("Storelance").Value;

				txtKfi.Text = hardwareParams.Attribute("Kfi").Value;
				txtKfp.Text = hardwareParams.Attribute("Kfp").Value;
				txtKfd.Text = hardwareParams.Attribute("Kfd").Value;
				txtForceTor.Text = hardwareParams.Attribute("Ftorelance").Value;
			}
			catch (Exception)
			{
				retVale = false;
			}


			try
			{
				var diagram = xml.Descendants("root").Descendants("Diagram").First();
				cbDiagramXAxis.SelectedValue = string.IsNullOrWhiteSpace(diagram.Attribute("X").Value) ? "None" : diagram.Attribute("X").Value;
				cbDiagramYAxis.SelectedValue = string.IsNullOrWhiteSpace(diagram.Attribute("Y").Value) ? "None" : diagram.Attribute("Y").Value;
				cbDiagramY2Axis.SelectedValue = string.IsNullOrWhiteSpace(diagram.Attribute("Y2").Value) ? "None" : diagram.Attribute("Y2").Value;

				cbDiagramStartUp.Checked = bool.Parse(diagram.Attribute("StartScale").Value);
				txtDiagramXStop.Text = diagram.Attribute("MaxX").Value;
				txtDiagramYStop.Text = diagram.Attribute("MaxY").Value;
				var reportFile = diagram.Attribute("ReportFilePath").Value;
				if (string.IsNullOrEmpty(reportFile))
					cbDefaultReport.Checked = true;
				else
				{
					if (!cbReportFiles.Items.Contains(reportFile))
					{
						using (var prompter = new Prompter())
						{
							prompter.Text = Resources.FrmTestSetting_SetXml_File_error;
							prompter.Message = Resources.FrmTestSetting_SetXml_Report_files + " " + reportFile +
							                   " " + Resources.FrmTestSetting_SetXml_not_found_;
							prompter.UserCancel = true;
							prompter.ShowDialog();
							cbDefaultReport.Checked = true;
						}
					}
					else
					{
						cbDefaultReport.Checked = false;
						cbReportFiles.Text = reportFile;
					}
				}
			}
			catch
			{
				retVale = false;
			}

			txtBreakCounter.Text = Test.BreakCounter.ToString();

			return retVale;
		}

        private bool ImportAndConvert(string path)
        {
            UnitManager.CurrentUnitCategory = UnitMainCategories.SI;
            InitializeMethodFields();
            UpdateUnit();
            var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var header = reader.ReadLine().Trim().ToUpper();
                if (header.Equals("DATA"))
                    break;

                switch (header)
                {
                    case "[SAMPLE]":
                        #region Sample Settings

                        txtSampleDim1.ResetText();
                        txtSampleDim2.ResetText();
                        txtSampleDim3.ResetText();

                        var sampleType = (TensionCompressionSampleType)0;
                        var secType = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (secType[0].Equals("SecType"))
                        {
                            var Thickness = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var Width = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var Diameter = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var InnerDiam = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var Density = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var Weigh = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var GageLen = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var TotalLen = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var SampleID = reader.ReadLine();
                            txtSampleId.Text = SampleID;
                            switch (secType[1])
                            {
                                case "Rectangular":
                                    {
                                        sampleType = TensionCompressionSampleType.Rectangular;
                                        cbSampleType.SelectedValue= sampleType.ToString();

                                        lbSampleDim1.Text = Resources.FrmTestSetting_ImportAndConvert_Width__w__;
                                        txtSampleDim1.Text = Width[1];
                                        lbSampleUnit1.Text = Resources.LengthConvertor_UnitSet_mm;

                                        lbSampleDim2.Text = Resources.FrmTestSetting_ImportAndConvert_Thickness__t_;
                                        txtSampleDim2.Text = Thickness[1];
                                        lbSampleUnit2.Text = Resources.LengthConvertor_UnitSet_mm;

                                        lbSampleDim3.ResetText();
                                        lbSampleUnit3.ResetText();
                                        lbSampleDim3.ResetText();
                                        lbSampleDim2.Visible = txtSampleDim2.Visible = lbSampleUnit2.Visible = true;
                                        lbSampleDim3.Visible = txtSampleDim3.Visible = lbSampleUnit3.Visible = false;

                                        txtSampleGS.Text = GageLen[1];
                                    }
                                    break;

                                case "Diameter":
                                    {
                                        sampleType = TensionCompressionSampleType.Pipe;
                                        cbSampleType.SelectedValue = sampleType.ToString();

                                        lbSampleDim1.Text = Resources.FrmTestSetting_Diameter_d__;
                                        txtSampleDim1.Text = Diameter[1];
                                        lbSampleUnit1.Text = Resources.LengthConvertor_UnitSet_mm;

                                        lbSampleDim2.Text = Resources.FrmTestSetting_Inner_Diameter_di__;
                                        txtSampleDim2.Text = InnerDiam[1];
                                        lbSampleUnit2.Text = Resources.LengthConvertor_UnitSet_mm;

                                        lbSampleDim3.ResetText();
                                        lbSampleUnit3.ResetText();
                                        lbSampleDim2.Visible = txtSampleDim2.Visible = lbSampleUnit2.Visible = true;
                                        lbSampleDim3.Visible = txtSampleDim3.Visible = lbSampleUnit3.Visible = false;

                                        txtSampleGS.Text = GageLen[1];
                                    }
                                    break;

								case "Weigh":
                                    {
                                        sampleType = TensionCompressionSampleType.Weight;
                                        cbSampleType.SelectedValue = sampleType.ToString();

                                        lbSampleDim1.Text = Resources.FrmTestSetting_Density_;
                                        txtSampleDim1.Text = Density[1];
                                        lbSampleUnit1.Text = Resources.FrmTestSetting_Kg_m3;

                                        lbSampleDim2.Text = Resources.FrmTestSetting_Weight_;
                                        txtSampleDim2.Text = Weigh[1];
                                        lbSampleUnit2.Text = Resources.FrmTestSetting_Kg;

                                        lbSampleDim3.Text = Resources.FrmTestSetting_Length_;
                                        txtSampleDim3.Text = TotalLen[1];
                                        lbSampleUnit3.Text = Resources.LengthConvertor_UnitSet_mm;
                                        lbSampleDim2.Visible = txtSampleDim2.Visible = lbSampleUnit2.Visible = true;
                                        lbSampleDim3.Visible = txtSampleDim3.Visible = lbSampleUnit3.Visible = true;
                                        txtSampleGS.Text = GageLen[1];
                                    }
                                    break;

                                case "Area":
                                    {
                                        sampleType = TensionCompressionSampleType.Area;
                                        cbSampleType.SelectedValue = sampleType.ToString();
                                        txtSampleAreaInertia.Text = Thickness[1];
                                        txtSampleGS.Text = GageLen[1];
                                    }
                                    break;
                            }
                        }
                        #endregion
                        break;

                    case "[Info]":
                        #region information
                        {
                            try
                            {
                                txtInfomationCustomer.Text = reader.ReadLine().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                                txtInfomationOperator.Text = reader.ReadLine().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                                txtInfomationTestDate.Text = reader.ReadLine().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
                                txtInfomationTestDiscription.Text = reader.ReadLine().Split("=".ToCharArray())[1];
                            }
                            catch
                            {
                            }
                        }
                        #endregion
                        break;

                    case "[TEST]":
                        #region Test Setting


                        var mode = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var speed1 = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var speed2 = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var ChangeSpd2ndPos = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var Speed2ndPosMode = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var Speed2ndChk = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var SWStoEMode = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var SWStoEPos = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

                        var SWStoEChk = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var RepeatN = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var Delay = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var CtrlType = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var CMinPos = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var CMaxPos = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var PreLDChk = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var StepList = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var PreLoadVal = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var PreLDCmb = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var PreLDdelay = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

                        var PreLDZero = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var CRKEEPTIME = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var CRTESTTIME = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        var CRFRCSET = reader.ReadLine().Split(new char[] { ',', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

                        switch (mode.ToUpper())
                        {
                            case "TENSILE":
                                #region tensile
                                {
                                    cbMethodTestMethod.Text = Resources.FrmTestSetting_Tensile;
                                    txtMethodSpeed.Text = speed1;
                                    cbSpeedUnits.Text = Resources.LengthConvertor_UnitSet_mm;
                                    txtTensileSecSpeedSetPoint.Text = ChangeSpd2ndPos;

                                    cbTensileSecSpeedType.Text = Speed2ndPosMode.Equals("0") ? Resources.FrmTestSetting_Extension : Resources.FrmTestSetting_Strain;

                                    cbTensileEnableSecondSpeed.Checked = Speed2ndChk.Equals("1");
                                    txtTensileStoESetPoint.Text = SWStoEPos;
                                    txtTensileSecondSpeed.Text = speed2;
                                    cbTensileStoEChangeMode.Text = SWStoEMode.Equals("0") ? Resources.FrmTestSetting_Extension : Resources.FrmTestSetting_Strain;

                                    cbTensileEnableStoE.Checked = SWStoEChk.Equals("1");

                                    cbTensilePreLoad.Checked = PreLDChk.Equals("1");
                                    txtTensilePreLoadSetPoint.Text = PreLoadVal;
                                    cbTensilePreLoadType.Text = PreLDCmb.Equals("0") ? TestControlMode.Force.ToString() : TestControlMode.Stress.ToString();
                                    cbPreLoadUnits.SelectedValue = PreLDCmb.Equals("0")
	                                    ? Resources.ForceConvertor_UnitSet_N
	                                    : Resources.StressConvertor_UnitSet_MPa;

                                    txtTensilePreLoadWait.Text = PreLDdelay;
                                    cbTensilePreLoadSetZero.Text = ((ZeroCode)int.Parse(PreLDZero)).ToString();
                                    txtBreakForceOver.Text = "10";
                                    Test.BreakForceOver = txtBreakForceOver.ValueInDouble;
                                }
                                #endregion
                                break;

                            case "COMPRESSIVE":
                                #region compressive
                                {
                                    cbMethodTestMethod.Text = Resources.FrmTestSetting_Compressive;
                                    txtMethodSpeed.Text = speed1;
                                    cbSpeedUnits.Text = Resources.ExtenControlConvertor_UnitSet_mm_min;
                                }
                                #endregion
                                break;

                            case "RELAXATION":
                                #region Relaxation
                                {
                                    cbMethodTestMethod.Text = Resources.FrmTestSetting_Relaxation;
                                    cbRelaxSetPointRateControl.Text = TestControlMode.Extension.ToString();
                                    txtRelaxRate.Text = speed1;
                                    cbRelaxRateUnit.Text = Resources.ExtenControlConvertor_UnitSet_mm_min;
                                    txtRelaxStablizeTime.Text = CRKEEPTIME;
                                    txtRelaxTestTime.Text = CRTESTTIME;
                                    txtRelaxSetPoint.Text = CRFRCSET;
                                    cbRelaxSetPointType.Text = RelaxationSetPoint.Extension.ToString();
                                    lbRelaxSetPointUnit.Text = Resources.LengthConvertor_UnitSet_mm;
                                }
                                #endregion
                                break;

                            case "CREEP":
                                #region Creep
                                {
                                    cbMethodTestMethod.Text = Resources.FrmTestSetting_Creep;
                                    cbCreepSetPointRateControl.Text = TestControlMode.Extension.ToString();
                                    txtCreepRate.Text = speed1;
                                    cbCreepRateUnit.Text = Resources.ExtenControlConvertor_UnitSet_mm_min;
                                    SetCreepStablizeTimes(CRKEEPTIME);
                                    SetCreepTestTimes(CRTESTTIME);
                                    txtCreepSetPoint.Text = CRFRCSET;
                                    cbCreepSetPointType.SelectedValue = RelaxationSetPoint.Force.ToString();
                                    lbCreepSetPointUnit.Text = Resources.ForceConvertor_UnitSet_N;
                                    cbCreepPreloadType.Text = RelaxationSetPoint.Force.ToString();
                                    lblCreepPreloadUnit.Text = Resources.ForceConvertor_UnitSet_N;
                                }
                                #endregion
                                break;

                            case "CYCLIC":
                                #region Cyclic
                                {
                                    cbMethodTestMethod.Text = Resources.FrmTestSetting_Cyclic;
                                    txtCyclicCount.Text = RepeatN;
                                    cbCyclicRateControl.SelectedValue = TestControlMode.Extension.ToString();
                                    txtCyclicRate.Text = speed1;
                                    cbCyclicRateUnit.Text = Resources.ExtenControlConvertor_UnitSet_mm_min;

                                    cbCyclicLimitType.SelectedValue = CtrlType.Equals("0") ? TestControlMode.Force.ToString() : TestControlMode.Extension.ToString();
                                    txtCyclicLimit1.Text = CMinPos;
                                    txtCyclicLimit2.Text = CMaxPos;
                                    lbCyclicLimit1Unit.Text = lbCyclicLimit2Unit.Text = CtrlType.Equals("0") ? Resources.ForceConvertor_UnitSet_N : Resources.LengthConvertor_UnitSet_mm;
                                    txtCyclicDelay.Text = Delay;
                                }
                                #endregion
                                break;

                            case "STEP":
                                #region Step
                                {
                                    cbMethodTestMethod.Text = Resources.FrmTestSetting_Step;
                                    var n = int.Parse(RepeatN);
                                    var steps = StepList.Split("/".ToCharArray()).Select(p => double.Parse(p)).ToArray();
                                    for (int i = 0; i < n; i++)
                                    {
                                        var speed = speed1;
                                        var rateCtrl = TestControlMode.Extension.ToString();
                                        var rateUnit = Resources.ExtenControlConvertor_UnitSet_mm_min;
                                        var setPointType = CtrlType.Equals("0") ? TestControlMode.Force.ToString() : TestControlMode.Extension.ToString();
                                        var setpointUnit = CtrlType.Equals("0") ? Resources.ForceConvertor_UnitSet_N : Resources.LengthConvertor_UnitSet_mm;
                                        var testDuration = Delay;
                                        dgvStep.Rows.Add(i, rateCtrl, speed, rateUnit, setPointType, steps[i], setpointUnit, 0, testDuration);
                                    }

                                }
                                #endregion
                                break;
                        }

                        #endregion

                        break;
                }
            }

            return true;
        }

        public string GetCurrentTestSetting()
        {
            var path = string.Format("Standards\\{0}", "tmp.stx");

            Export(path);

            var stream = new StreamReader(path);
            var retVal = stream.ReadToEnd();
            stream.Close();
            return retVal;
        }

        public void SetCurrentSetting(string setting)
        {
            var path = string.Format("Standards\\{0}", "tmp.stx");
            StreamWriter stream = null;
            try
            {
                stream = new StreamWriter(path);
                stream.Write(setting);
                stream.Flush();
                stream.Close();
                Import(path);
                Export(Options.DefTestPath);
                File.Delete(path);
            }
            catch (Exception exception)
            {
                if (stream != null)
                    stream.Close();
                exception.ToString();
            }
        }

        private void llLoadDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadDefaultTest();
        }

        private void LoadDefaultTest(bool defaultTest = true)
        {
            ValidSetting = false;
            try
            {
                if (defaultTest)
                {
                    ValidSetting = Import(Options.DefTestPath);
                    Export(curTestPath);
                }
                else
                    ValidSetting = Import(curTestPath);
            }
            catch
            {
                if (defaultTest)
                {
                    var result = MessageBox.Show(
                        Resources.FrmTestSetting_LoadDefaultTest_Fatal_Error,
                        AboutBox.AssemblyTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        LoadDefaultTest(false);
                    }
                }
                else
                    MessageBox.Show(Resources.FrmTestSetting_LoadLastTest_Fatal_Error,
                            AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void llSaveDefulat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Export(Options.DefTestPath);
        }

        #endregion

        #region speed control

        private void cbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcSpeedControl.SelectedIndex = cbSpeed.SelectedIndex;
        }

        private void llSpdctrlDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SettingLoader sl = SettingLoader.Current)
            {
                sl.LoadSpeedCtrlSetting();
            }

            txtKsi.Text = SpeedControlParameters.Ksi.ToString();
            txtKsp.Text = SpeedControlParameters.Ksp.ToString();
            txtKsd.Text = SpeedControlParameters.Ksd.ToString();
            txtStrainTor.Text = SpeedControlParameters.STorelance.ToString();

            txtKei.Text = SpeedControlParameters.Kei.ToString();
            txtKep.Text = SpeedControlParameters.Kep.ToString();
            txtKed.Text = SpeedControlParameters.Ked.ToString();
            txtExtenTor.Text = SpeedControlParameters.Etorelance.ToString();

            txtKfi.Text = SpeedControlParameters.Kfi.ToString();
            txtKfp.Text = SpeedControlParameters.Kfp.ToString();
            txtKfd.Text = SpeedControlParameters.Kfd.ToString();
            txtForceTor.Text = SpeedControlParameters.Ftorelance.ToString();
        }

        #endregion

        private void FrmTestSetting_Load(object sender, EventArgs e)
        {
            cboDecimationUnit.SelectedIndex = 0;
            cbSetPointAction.SelectedIndex = 0;
            
            LoadReportSettingsFiles();
           // Import(curTestPath);

            gbCreepTemperature.Enabled = Program.FullCreepAvailable;
            gbCreepPreload.Enabled = Program.FullCreepAvailable;

            txtCreepSampleDecimation.Enabled = Program.FullCreepAvailable;
            cboDecimationUnit.Enabled = Program.FullCreepAvailable;
        }

        private void TextBoxNext(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ctrl = GetNextControl(sender as Control, true);
                if (ctrl is TextBox)
                    ctrl.Focus();
            }
        }

        private void cbSetPointAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStepSetPointAction.Enabled = cbSetPointAction.SelectedIndex > 0;
        }

        public bool EditMode
        {
            set
            {
                llMethod.Enabled = !value;
                llmeasures.Enabled = !value;
                llCtr.Enabled = !value;
            }
        }

        public string ReportFilePath
        {
            get
            {
                if (cbDefaultReport.Checked)
                    return "";
                return cbReportFiles.Text;
            }
        }

        #region method get set

        public XElement GetMethodElemnet()
        {
            var method = (TestMethodType)cbMethodTestMethod.SelectedValue;
            XElement retVal = null;
            switch (method)
            {
                case TestMethodType.Compressive:
                    retVal = GetCompressiveXml();
                    break;
                case TestMethodType.Creep:
                    retVal = GetCreepXML();
                    break;
                case TestMethodType.Cyclic:
                    retVal = GetCyclicXML();
                    return retVal;
                case TestMethodType.Relaxation:
                    retVal = GetRelaxationXML();
                    break;
                case TestMethodType.Step:
                    retVal = GetStepXML();
                    break;
                case TestMethodType.Tensile:
                    retVal = GetTensileXML();
                    break;
            }
            try
            {
                retVal.Add(new XAttribute("TestStopType", cbStopCondition.Checked ? cbCreepSetPointType.SelectedValue : "0"));
                retVal.Add(new XAttribute("TestStopValue", UnitManager.ConvertToBase(txtConditionValue.Text, lbConditionUbit.Tag as string ?? "")));
            }
            catch
            {
            }
            return retVal;
        }

        public XElement GetSpecimenElement()
        {
            return new XElement("Sample", new XAttribute("TestingSampleType", cbTestingSampleType.SelectedValue as string),
                new XAttribute("SampleId", txtSampleId.Text),
                new XAttribute("SampleGS", txtSampleGS.Text),
                new XAttribute("SampleGP", txtSampleGP.Text),
                new XAttribute("Type", cbSampleType.SelectedValue as string),
                new XAttribute("Dim1", txtSampleDim1.Text),
                new XAttribute("Dim2", txtSampleDim2.Text),
                new XAttribute("Dim3", txtSampleDim3.Text),
                new XAttribute("Area", txtSampleAreaInertia.Text));
        }

        private void SetMethodFields(XElement xElement)
        {
            var method = (TestMethodType)Enum.Parse(typeof(TestMethodType), xElement.Attribute("TestMethodType").Value);

            switch (method)
            {
                case TestMethodType.Compressive:
                    SetCompressiveFields(xElement);
                    break;

                case TestMethodType.Creep:
                    SetCreepFields(xElement);
                    break;

                case TestMethodType.Cyclic:
                    SetCyclicFields(xElement);
                    break;

                case TestMethodType.Relaxation:
                    SetRelaxationFields(xElement);
                    break;

                case TestMethodType.Step:
                    SetStepFields(xElement);
                    break;

                case TestMethodType.Tensile:
                    SetTensileFields(xElement);
                    break;
            }
            try
            {
                cbStopCondition.Checked = xElement.Attribute("TestStopType").Value != "0";
                if (cbStopCondition.Checked)
                {
                    cbCreepSetPointType.SelectedValue = xElement.Attribute("TestStopType").Value;
                    var cond = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbCreepSetPointType.SelectedValue as string);
                    lbConditionUbit.Text =UnitManager.TranslateUnitTitle( UnitManager.GetUnit(cond));
                    lbConditionUbit.Tag = UnitManager.GetUnit(cond);
                    txtConditionValue.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("TestStopValue").Value, lbConditionUbit.Tag as string ??""));
                }
            }
            catch
            {
            }
        }

        private XElement GetTensileXML()
        {
            var xElement = new XElement("GetTestParameters",
                new XAttribute("TestMethodType", cbMethodTestMethod.SelectedValue),
                new XAttribute("CurrentPostions", txtCurPosition.Text),
                new XAttribute("SpeedUnits", cbSpeedUnits.SelectedValue),
                new XAttribute("MethodSpeed", UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.SelectedValue as string)),
                new XAttribute("TensilePreLoad", cbTensilePreLoad.Checked),
                new XAttribute("TensilePreLoadType", cbTensilePreLoadType.SelectedValue),
                new XAttribute("PreLoadUnits", cbPreLoadUnits.SelectedValue as string),
                new XAttribute("TensilePreLoadSetPoint", UnitManager.ConvertToBase(txtTensilePreLoadSetPoint.Text, cbPreLoadUnits.SelectedValue as string)),
                new XAttribute("TensilePreLoadWait", txtTensilePreLoadWait.Text),
                new XAttribute("TensilePreLoadSetZero", cbTensilePreLoadSetZero.SelectedValue),
                new XAttribute("TensileEnableSecondSpeed", cbTensileEnableSecondSpeed.Checked),
                new XAttribute("TensileSecSpeedType", cbTensileSecSpeedType.SelectedValue),
                new XAttribute("TensileSecSpeedSetPoint", UnitManager.ConvertToBase(txtTensileSecSpeedSetPoint.Text, cbTensileSecSpeedTypeUnit.SelectedValue as string)),
                new XAttribute("TensileSecSpeedUnit", cbTensileSecSpeedTypeUnit.Text),
                new XAttribute("TensileSecondSpeed", UnitManager.ConvertToBase(txtTensileSecondSpeed.Text, cbSpeedUnits.SelectedValue as string)),
                new XAttribute("TensileEnableStoE", cbTensileEnableStoE.Checked),
                new XAttribute("TensileStoEType", cbTensileStoEType.SelectedValue),
                new XAttribute("TensileStoESetPoint", UnitManager.ConvertToBase(txtTensileStoESetPoint.Text, cbTensileStoEUnit.SelectedValue as string)),
                new XAttribute("TensileStoEUnit", cbTensileStoEUnit.Text),
                new XAttribute("TensileStoEChangeMode", cbTensileStoEChangeMode.SelectedValue),
                new XAttribute("BreakForceOver", txtBreakForceOver.Text)

            );
            return xElement;
        }
        private void SetTensileFields(XElement xElement)
        {
            cbMethodTestMethod.Text = xElement.Attribute("TestMethodType").Value;
            txtCurPosition.Text = xElement.Attribute("CurrentPostions").Value;
            var xtenRate = cbSpeedUnits.Items.Contains(xElement.Attribute("SpeedUnits").Value) ? xElement.Attribute("SpeedUnits").Value :
                                                                                                  UnitManager.ExtenControlUnits[0];
            cbSpeedUnits.Text = xtenRate;
            txtMethodSpeed.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("MethodSpeed").Value, xtenRate));
            txtMethodSpeed.Tag = xElement.Attribute("MethodSpeed").Value;

            cbTensilePreLoad.Checked = bool.Parse(xElement.Attribute("TensilePreLoad").Value);

            cbTensilePreLoadType.SelectedValue = xElement.Attribute("TensilePreLoadType").Value;
            var preLoadUnit = cbPreLoadUnits.Items.Contains(xElement.Attribute("PreLoadUnits").Value) ? xElement.Attribute("PreLoadUnits").Value : (cbPreLoadUnits.SelectedValue as string) ?? "";
            cbPreLoadUnits.SelectedValue = preLoadUnit;
            txtTensilePreLoadSetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("TensilePreLoadSetPoint").Value, preLoadUnit));
            txtTensilePreLoadSetPoint.Tag = xElement.Attribute("TensilePreLoadSetPoint").Value;
            txtTensilePreLoadWait.Text = xElement.Attribute("TensilePreLoadWait").Value;
            cbTensilePreLoadSetZero.Text = xElement.Attribute("TensilePreLoadSetZero").Value;
            cbTensileEnableSecondSpeed.Checked = bool.Parse(xElement.Attribute("TensileEnableSecondSpeed").Value);
            cbTensileSecSpeedType.SelectedValue = xElement.Attribute("TensileSecSpeedType").Value;

            var secSpeedTypeUnit = cbTensileSecSpeedTypeUnit.Items.Contains(xElement.Attribute("TensileSecSpeedUnit").Value) ? xElement.Attribute("TensileSecSpeedUnit").Value :
                ((cbTensileSecSpeedTypeUnit.DataSource as List<KeyValuePair<string, string>>)[0].Key);
            cbTensileSecSpeedTypeUnit.SelectedValue = secSpeedTypeUnit;
            txtTensileSecSpeedSetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("TensileSecSpeedSetPoint").Value, secSpeedTypeUnit));
            txtTensileSecSpeedSetPoint.Tag = xElement.Attribute("TensileSecSpeedSetPoint").Value;
            txtTensileSecondSpeed.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("TensileSecondSpeed").Value, xtenRate));
            txtTensileSecondSpeed.Tag = xElement.Attribute("TensileSecondSpeed").Value;
            cbTensileEnableStoE.Checked = bool.Parse(xElement.Attribute("TensileEnableStoE").Value);
            cbTensileStoEType.SelectedValue = xElement.Attribute("TensileStoEType").Value;
            var s2eUnit = cbTensileStoEUnit.Items.Contains(xElement.Attribute("TensileStoEUnit").Value) ? xElement.Attribute("TensileStoEUnit").Value : cbTensileStoEUnit.Items[0].ToString();
            cbTensileStoEUnit.Text = s2eUnit;

            txtTensileStoESetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("TensileStoESetPoint").Value, s2eUnit));
            txtTensileStoESetPoint.Tag = xElement.Attribute("TensileStoESetPoint").Value;
            cbTensileStoEChangeMode.SelectedValue = xElement.Attribute("TensileStoEChangeMode").Value;
            txtBreakForceOver.Text = xElement.Attribute("BreakForceOver").Value;
            Test.BreakForceOver = txtBreakForceOver.ValueInDouble;
        }

        private XElement GetCompressiveXml()
        {
            var xElement = new XElement("GetTestParameters",
                new XAttribute("TestMethodType", cbMethodTestMethod.Text),
                new XAttribute("CurrentPostions", txtCurPosition.Text),
                new XAttribute("SpeedUnits", cbSpeedUnits.Text),
                new XAttribute("MethodSpeed", UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.Text))
            );
            return xElement;
        }
        private void SetCompressiveFields(XElement xElement)
        {
            cbMethodTestMethod.Text = xElement.Attribute("TestMethodType").Value;
            txtCurPosition.Text = xElement.Attribute("CurrentPostions").Value;
            var xtenRateUnit = cbSpeedUnits.Items.Contains(xElement.Attribute("SpeedUnits").Value) ? xElement.Attribute("SpeedUnits").Value : UnitManager.ExtenControlUnits[0];
            cbSpeedUnits.Text = xtenRateUnit;
            txtMethodSpeed.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("MethodSpeed").Value, xtenRateUnit));
            txtMethodSpeed.Tag = xElement.Attribute("MethodSpeed").Value;
        }

        private XElement GetCyclicXML()
        {
            var xElement = new XElement("GetTestParameters",
            new XAttribute("TestMethodType", cbMethodTestMethod.Text),
            new XAttribute("CurrentPostions", txtCurPosition.Text),
            new XAttribute("CyclicCount", txtCyclicCount.Text),
            new XAttribute("CyclicRateControl", cbCyclicRateControl.SelectedValue),
            new XAttribute("CyclicRateUnit", cbCyclicRateUnit.Text),
            new XAttribute("CyclcRate", UnitManager.ConvertToBase(txtCyclicRate.Text, cbCyclicRateUnit.Text)),
            new XAttribute("CycleLimitType", cbCyclicLimitType.SelectedValue),
            new XAttribute("CylicLimit1", UnitManager.ConvertToBase(txtCyclicLimit1.Text, lbCyclicLimit1Unit.Text)),
            new XAttribute("CylicLimit2", UnitManager.ConvertToBase(txtCyclicLimit2.Text, lbCyclicLimit1Unit.Text)),
            new XAttribute("KeepTime", UnitManager.ConvertToBase(txtCyclicDelay.Text, "sec"))
            );
            return xElement;
        }
        private void SetCyclicFields(XElement xElement)
        {
            cbMethodTestMethod.Text = xElement.Attribute("TestMethodType").Value;
            txtCurPosition.Text = xElement.Attribute("CurrentPostions").Value;
            txtCyclicCount.Text = xElement.Attribute("CyclicCount").Value;
            cbCyclicRateControl.SelectedValue = xElement.Attribute("CyclicRateControl").Value;
            var rateUnit = cbCyclicRateUnit.Items.Contains(xElement.Attribute("CyclicRateUnit").Value) ? xElement.Attribute("CyclicRateUnit").Value : cbCyclicRateUnit.Text;
            cbCyclicRateUnit.Text = rateUnit;
            txtCyclicRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("CyclcRate").Value, rateUnit));
            txtCyclicRate.Tag = xElement.Attribute("CyclcRate").Value;
            cbCyclicLimitType.SelectedValue = xElement.Attribute("CycleLimitType").Value;
            txtCyclicLimit1.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("CylicLimit1").Value, lbCyclicLimit1Unit.Text));
            txtCyclicLimit2.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("CylicLimit2").Value, lbCyclicLimit1Unit.Text));
            txtCyclicDelay.Text = xElement.Attribute("KeepTime").Value;
        }

        private XElement GetStepXML()
        {
            var xElement = new XElement("GetTestParameters",
                new XAttribute("TestMethodType", cbMethodTestMethod.Text),
                new XAttribute("CurrentPostions", txtCurPosition.Text)
                );
            foreach (DataGridViewRow row in dgvStep.Rows)
            {
                xElement.Add(
                    new XElement("Step",
                        new XAttribute("Ctrl", row.Cells[1].Value.ToString()),
                        new XAttribute("Rate", UnitManager.ConvertToBase(row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString())),
                        new XAttribute("Unit", row.Cells[3].Value.ToString()),
                        new XAttribute("LimitType", row.Cells[4].Value.ToString()),
                        new XAttribute("Limit", UnitManager.ConvertToBase(row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString())),
                        new XAttribute("LUnit", row.Cells[6].Value.ToString()),
                        new XAttribute("Action", row.Cells[7].Value.ToString()),
                        new XAttribute("FA", row.Cells[8].Value.ToString()),
                        new XAttribute("FV", row.Cells[9].Value.ToString()),
                        new XAttribute("FU", row.Cells[10].Value.ToString()),
                        new XAttribute("EA", row.Cells[11].Value.ToString()),
                        new XAttribute("EV", row.Cells[12].Value.ToString()),
                        new XAttribute("EU", row.Cells[13].Value.ToString()))
                        );
            }
            return xElement;
        }
        private void SetStepFields(XElement xElement)
        {
            cbMethodTestMethod.Text = xElement.Attribute("TestMethodType").Value;
            txtCurPosition.Text = xElement.Attribute("CurrentPostions").Value;
            dgvStep.Rows.Clear();
            var rw = 1;
            foreach (var step in xElement.Descendants("Step"))
            {
                cbStepSetPointRateControl.Text = step.Attribute("Ctrl").Value;
                var rateUnit = cbStepRateUnit.Items.Contains(step.Attribute("Unit").Value) ? step.Attribute("Unit").Value : cbStepRateUnit.Items[0].ToString();

                cbStepSetPointType.Text = step.Attribute("LimitType").Value;
                var limitUnit = lbStepSetPointUnit.Tag as string;
                dgvStep.Rows.Add(
                                 rw,
                                 step.Attribute("Ctrl").Value,
                                 UnitManager.ConvertToCurrent(step.Attribute("Rate").Value, rateUnit),
                                 rateUnit,
                                 step.Attribute("LimitType").Value,
                                 UnitManager.ConvertToCurrent(step.Attribute("Limit").Value, limitUnit),
                                 limitUnit,
                                 step.Attribute("Action").Value,
                                 step.Attribute("FA").Value,
                                 step.Attribute("FV").Value,
                                 step.Attribute("FU").Value,
                                 step.Attribute("EA").Value,
                                 step.Attribute("EV").Value,
                                 step.Attribute("EU").Value
                                 );
                rw++;
            }
        }

        private XElement GetCreepXML()
        {
			var xElement = new XElement("GetTestParameters",
                new XAttribute("TestMethodType", cbMethodTestMethod.Text),
                new XAttribute("CurrentPostions", txtCurPosition.Text),
                new XAttribute("CreepSetPointRateControl", cbCreepSetPointRateControl.SelectedValue as string),
                new XAttribute("CreepRate", UnitManager.ConvertToBase(txtCreepRate.Text, cbCreepRateUnit.SelectedValue as string)),
                new XAttribute("CreepRateUnit", cbCreepRateUnit.Text),
                new XAttribute("CreepSetPointType", cbCreepSetPointType.SelectedValue),
                new XAttribute("CreepSetPoint", UnitManager.ConvertToBase(txtCreepSetPoint.Text, lbCreepSetPointUnit.Tag as string ?? "")),
                new XAttribute("CreepStablizeTime", CalcCreepStablizeTime().ToString()),
                new XAttribute("CreepTestTime", CalcCreepTestTime().ToString()),
                new XAttribute("CreepPlotAll", cbCreepPlotAll.Checked),
                new XAttribute("Decimation", CalculateDecimation()?.ToString()),
                // Nazarpour
                new XAttribute("CreepPreloadType", cbCreepPreloadType.Text),
                new XAttribute("CreepPreload", UnitManager.ConvertToBase(txtCreepPreload.Text, lblCreepPreloadUnit.Tag as string ?? "")),
                new XAttribute("CreepPreloadTime", CalcCreepPreloadTime().ToString()),
                new XAttribute("CreepTemperature", txtCreepTemperatureValue.Text),
                new XAttribute("CreepTemperatureOffset", txtCreepTemperatureOffsetValue.Text),
                new XAttribute("CreepPreHeatTime", CalcPreHeatTime().ToString()),
                new XAttribute("ResetExtension", chkResetExtension.Checked)
                );
 
			return xElement;
        }
        private void SetCreepFields(XElement xElement)
        {
            cbMethodTestMethod.Text = xElement.Attribute("TestMethodType").Value;
            txtCurPosition.Text = xElement.Attribute("CurrentPostions").Value;
            cbCreepSetPointRateControl.Text = xElement.Attribute("CreepSetPointRateControl").Value;

            var rateUnit = cbCreepRateUnit.Items.Contains(xElement.Attribute("CreepRateUnit").Value) ? xElement.Attribute("CreepRateUnit").Value : cbCreepRateUnit.Items[0].ToString();
            cbCreepRateUnit.Text = rateUnit;

            txtCreepRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("CreepRate").Value, rateUnit));
            txtCreepRate.Tag = xElement.Attribute("CreepRate").Value;
            cbCreepSetPointType.SelectedValue = xElement.Attribute("CreepSetPointType").Value;
            txtCreepSetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("CreepSetPoint").Value, lbCreepSetPointUnit.Tag as string ?? ""));
            txtCreepSetPoint.Tag = xElement.Attribute("CreepSetPoint").Value.ToString();
            
			SetCreepStablizeTimes(xElement.Attribute("CreepStablizeTime").Value);
            SetCreepTestTimes(xElement.Attribute("CreepTestTime").Value);
            cbCreepPlotAll.Checked = bool.Parse(xElement.Attribute("CreepPlotAll").Value);

            try
            {
                mDecimation = int.Parse(xElement.Attribute("Decimation").Value);
            }
            catch
            {
                mDecimation = 100;
            }
            txtCreepSampleDecimation.Text = mDecimation.ToString();

            try
            {
                mDecimation1value = int.Parse(xElement.Attribute("Decimation1value").Value);
                mDecimation1value = int.Parse(xElement.Attribute("Decimation2value").Value);
                mDecimation1value = int.Parse(xElement.Attribute("Decimation3value").Value);

                mDecimation1time = int.Parse(xElement.Attribute("Decimation1time").Value);
                mDecimation1time = int.Parse(xElement.Attribute("Decimation2time").Value);
                mDecimation1time = int.Parse(xElement.Attribute("Decimation3time").Value);
            }
            catch
            {
            }

            // Nazarpour
            cbCreepPreloadType.Text = xElement.Attribute("CreepPreloadType").Value;
            txtCreepPreload.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("CreepPreload").Value, lblCreepPreloadUnit.Tag as string ?? ""));
            txtCreepPreload.Tag = xElement.Attribute("CreepPreload").Value.ToString();
            SetCreepPreloadTimes(xElement.Attribute("CreepPreloadTime").Value);
            txtCreepTemperatureValue.Text = xElement.Attribute("CreepTemperature").Value;
            txtCreepTemperatureOffsetValue.Text = xElement.Attribute("CreepTemperatureOffset").Value;
            SetPreHeatTimes(xElement.Attribute("CreepPreHeatTime").Value);
            chkResetExtension.Checked = bool.Parse(xElement.Attribute("ResetExtension")?.Value ?? "False");
        }

        private XElement GetRelaxationXML()
        {
            var xElement = new XElement("GetTestParameters",
                new XAttribute("TestMethodType", cbMethodTestMethod.Text),
                new XAttribute("CurrentPostions", txtCurPosition.Text),
                new XAttribute("RelaxSetPointRateControl", cbRelaxSetPointRateControl.Text),
                new XAttribute("RelaxRate", UnitManager.ConvertToBase(txtRelaxRate.Text, cbRelaxRateUnit.Text)),
                new XAttribute("RelaxRateUnit", cbRelaxRateUnit.Text),
                new XAttribute("RelaxSetPointType", cbRelaxSetPointType.Text),
                new XAttribute("RelaxSetPoint", UnitManager.ConvertToBase(txtRelaxSetPoint.Text, lbRelaxSetPointUnit.Text)),
                new XAttribute("RelaxStablizeTime", txtRelaxStablizeTime.Text),
                new XAttribute("RelaxTestTime", txtRelaxTestTime.Text),
                new XAttribute("RelaxPlotAll", cbRelaxPlotAll.Checked),
                new XAttribute("Decimation", txtRelaxationSampleDecimation.Text)
                );

            return xElement;
        }
        private void SetRelaxationFields(XElement xElement)
        {
            cbMethodTestMethod.Text = xElement.Attribute("TestMethodType").Value;
            txtCurPosition.Text = xElement.Attribute("CurrentPostions").Value;
            cbRelaxSetPointRateControl.Text = xElement.Attribute("RelaxSetPointRateControl").Value;

            var rateUnit = cbRelaxRateUnit.Items.Contains(xElement.Attribute("RelaxRateUnit").Value) ? xElement.Attribute("RelaxRateUnit").Value : cbRelaxRateUnit.Items[0].ToString();
            cbRelaxRateUnit.Text = rateUnit;
            txtRelaxRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("RelaxRate").Value, rateUnit));
            txtRelaxRate.Tag = xElement.Attribute("RelaxRate").Value;

            cbRelaxSetPointType.Text = xElement.Attribute("RelaxSetPointType").Value;
            txtRelaxSetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(xElement.Attribute("RelaxSetPoint").Value, lbRelaxSetPointUnit.Text));

            txtRelaxStablizeTime.Text = xElement.Attribute("RelaxStablizeTime").Value;
            txtRelaxTestTime.Text = xElement.Attribute("RelaxTestTime").Value;
            cbRelaxPlotAll.Checked = bool.Parse(xElement.Attribute("RelaxPlotAll").Value);

            try
            {
                txtRelaxationSampleDecimation.Text = int.Parse(xElement.Attribute("Decimation").Value).ToString();
            }
            catch
            {
                txtRelaxationSampleDecimation.Text = "100";
            }
        }

        #endregion

        #region unit val combobox adapting 

        private void cbStepRateUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStepRate.Tag == null) return;
            var value = txtStepRate.Tag ?? 0;
            txtStepRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbStepRateUnit.Text));
        }

        private void cbStepRateUnit_Enter(object sender, EventArgs e)
        {
            if (txtStepRate.Tag != null && Math.Abs(txtStepRate.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtStepRate.Tag = UnitManager.ConvertToBase(txtStepRate.Text, cbStepRateUnit.Text);
        }

        private void cbCreepRateUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCreepRate.Tag == null) return;
            var value = txtCreepRate.Tag;
            txtCreepRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbCreepRateUnit.Text));
        }

        private void cbCreepRateUnit_Enter(object sender, EventArgs e)
        {
            if (txtCreepRate.Tag != null && Math.Abs(txtCreepRate.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtCreepRate.Tag = UnitManager.ConvertToBase(txtCreepRate.Text, cbCreepRateUnit.Text);
        }

        private void cbRelaxRateUnit_Enter(object sender, EventArgs e)
        {
            if (txtRelaxRate.Tag != null && Math.Abs(txtRelaxRate.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtRelaxRate.Tag = UnitManager.ConvertToBase(txtRelaxRate.Text, cbRelaxRateUnit.Text);
        }

        private void cbRelaxRateUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtRelaxRate.Tag == null) return;
            var value = txtRelaxRate.Tag;
            txtRelaxRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbRelaxRateUnit.Text));
        }

        private void cbCyclicRateUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCyclicRate.Tag == null) return;
            var value = txtCyclicRate.Tag;
            txtCyclicRate.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbCyclicRateUnit.Text));
        }

        private void cbCyclicRateUnit_Enter(object sender, EventArgs e)
        {
            if (txtCyclicRate.Tag != null && Math.Abs(txtCyclicRate.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtCyclicRate.Tag = UnitManager.ConvertToBase(txtCyclicRate.Text, cbCyclicRateUnit.Text);
        }

        private void cbPreLoadUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTensilePreLoadSetPoint.Tag == null) return;
            var value = txtTensilePreLoadSetPoint.Tag;
            txtTensilePreLoadSetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbPreLoadUnits.SelectedValue as string));
        }

        private void cbPreLoadUnits_Enter(object sender, EventArgs e)
        {
            if (txtTensilePreLoadSetPoint.Tag != null && Math.Abs(txtTensilePreLoadSetPoint.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtTensilePreLoadSetPoint.Tag = UnitManager.ConvertToBase(txtTensilePreLoadSetPoint.Text, cbPreLoadUnits.SelectedValue as string);
        }

        private void cbTensileSecSpeedTypeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTensileSecSpeedSetPoint.Tag == null) return;
            var value = txtTensileSecSpeedSetPoint.Tag;
            txtTensileSecSpeedSetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbTensileSecSpeedTypeUnit.Text));
        }

        private void cbTensileSecSpeedTypeUnit_Enter(object sender, EventArgs e)
        {
            if (txtTensileSecSpeedSetPoint.Tag != null && Math.Abs(txtTensileSecSpeedSetPoint.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtTensileSecSpeedSetPoint.Tag = UnitManager.ConvertToBase(txtTensileSecSpeedSetPoint.Text, cbTensileSecSpeedTypeUnit.Text);
        }


        private void cbTensileStoEUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTensileStoESetPoint.Tag == null) return;
            var value = txtTensileStoESetPoint.Tag;
            txtTensileStoESetPoint.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbTensileStoEUnit.SelectedValue as string ?? ""));
        }

        private void cbTensileStoEUnit_Enter(object sender, EventArgs e)
        {
            if (txtTensileStoESetPoint.Tag != null && Math.Abs(txtTensileStoESetPoint.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtTensileStoESetPoint.Tag = UnitManager.ConvertToBase(txtTensileStoESetPoint.Text, cbTensileStoEUnit.SelectedValue as string ?? "");
        }

        private void cbTensileSpeedUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMethodSpeed.Tag == null) return;
            var value = txtMethodSpeed.Tag;
            txtMethodSpeed.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbSpeedUnits.SelectedValue as string ?? ""));
            lbTensileSpeedUnit.Text = cbSpeedUnits.Text;
            lbTensileSpeedUnit.Tag = cbSpeedUnits.SelectedValue;
			value = txtTensileSecondSpeed.Tag;
            txtTensileSecondSpeed.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(value.ToString(), cbSpeedUnits.SelectedValue as string ?? ""));
        }

        private void cbSpeedUnits_Enter(object sender, EventArgs e)
        {
            if (txtMethodSpeed.Tag != null && Math.Abs(txtMethodSpeed.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtMethodSpeed.Tag = UnitManager.ConvertToBase(txtMethodSpeed.Text, cbSpeedUnits.SelectedValue as string ?? "");

            if (txtTensileSecondSpeed.Tag != null && Math.Abs(txtTensileSecondSpeed.ValueInDouble - 0.0) <= double.Epsilon) return;
            txtTensileSecondSpeed.Tag = UnitManager.ConvertToBase(txtTensileSecondSpeed.Text, cbSpeedUnits.SelectedValue as string ?? "");
        }
        #endregion

        private void llcancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            HideForm();
        }

        private void cbDefaultReport_CheckedChanged(object sender, EventArgs e)
        {
            cbReportFiles.Enabled = !cbDefaultReport.Checked;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult = DialogResult.Cancel;
            HideForm();
        }
        private void HideForm()
        {
            Hide();
            if (OnOperationDone != null)
                OnOperationDone(this, EventArgs.Empty);
        }

        private void cbStopCondition_CheckedChanged(object sender, EventArgs e)
        {
            cbConditionType.Enabled = txtConditionValue.Enabled = cbStopCondition.Checked;
        }

        private void cbConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cond = (TestControlMode)Enum.Parse(typeof(TestControlMode), (cbConditionType.SelectedValue  as string ?? TestControlMode.None.ToString()));
            lbConditionUbit.Text =UnitManager.TranslateUnitTitle(UnitManager.GetUnit(cond));
            lbConditionUbit.Tag = UnitManager.GetUnit(cond);
        }

        public void SetDefaultSetting(string setting)
        {
            var path = string.Format("Standards\\{0}", "tmp.stx");
            StreamWriter stream = null;
            try
            {
                stream = new StreamWriter(path);
                stream.Write(setting);
                stream.Flush();
                stream.Close();
                Import(path);
                Export(Options.DefTestPath);
                File.Delete(path);

            }
            catch (Exception exception)
            {
                if (stream != null)
                    stream.Close();
                exception.ToString();
            }
        }

        private void cbDiagramY2Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckY2Axis();
        }

        private void btnCreepApplyTemperature_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Resources.FrmTestSetting_btnCreepApplyTemperature_Click_, Resources.FrmTestSetting_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Test.SetTemperature(InstrumentParameters.TemperatureHMI, txtCreepTemperatureValue.ValueInFoalt + txtCreepTemperatureOffsetValue.ValueInFoalt);
            }
        }

        private void FrmTestSetting_VisibleChanged(object sender, EventArgs e)
        {
            if (InstrumentParameters.TemperatureMax > 0)
            {
                txtCreepTemperatureValue.MaxValue = InstrumentParameters.TemperatureMax.ToString();
            }
        }

        //private void FrmTestSetting_Activated(object sender, EventArgs e)
        //{
	       // SetXml(xDocument);
        //}

        //private void FrmTestSetting_Deactivate(object sender, EventArgs e)
        //{
	       // xDocument = GetXml();
        //}

		private void cboDateCultureFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtInfomationTestDate.Tag != null)
                txtInfomationTestDate.Text =
                    TestInformation.GetDate((DateTime)txtInfomationTestDate.Tag,
                        (DateCultureFormats)cboDateCultureFormat.SelectedIndex) ?? txtInfomationTestDate.Text;
            txtInfomationTestDate.Enabled = (cboDateCultureFormat.SelectedIndex == (int)DateCultureFormats.Custom);
        }

		private void txtCreepPreload_Enter(object sender, EventArgs e)
		{
			if (txtCreepPreload.Tag != null && Math.Abs(txtCreepPreload.ValueInDouble - 0.0) <= double.Epsilon) return;
			txtCreepPreload.Tag = UnitManager.ConvertToBase(txtCreepPreload.Text, lblCreepPreloadUnit.Tag as string ?? "");
		}

		private void txtCreepSetPoint_Enter(object sender, EventArgs e)
		{
			if (txtCreepSetPoint.Tag != null && Math.Abs(txtCreepSetPoint.ValueInDouble - 0.0) <= double.Epsilon) return;
			txtCreepSetPoint.Tag = UnitManager.ConvertToBase(txtCreepSetPoint.Text, lbCreepSetPointUnit.Tag as string ?? "");
		}

		private void cboDecimationUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var decimation = CalculateDecimation();
            if (decimation.HasValue) mDecimation = decimation.Value;
            UpdateDecimationValue(mDecimation);
            lastSelectedIndex = cboDecimationUnit.SelectedIndex;
        }

        private int? CalculateDecimation()
        {
            int? decimation = null;
            try
            {
                decimation = int.Parse(txtCreepSampleDecimation.Text);
                if (decimation > 0)
                    switch (lastSelectedIndex)
                    {
                        case 1:
                            decimation = 100 / decimation;
                            break;

                        case 2:
                            decimation = (100 * 60 / decimation);
                            break;

                        case 3:
                            decimation = (100 * 3600 / decimation);
                            break;

                        default:
                            break;

                    }
                else
                    decimation = null;
            }
            catch
            {
                decimation = null;
            }

            return decimation;
        }

        private void UpdateDecimationValue(int? decimation)
        {
            if (decimation.HasValue)
            {
                if (decimation > 0)
                    switch (cboDecimationUnit.SelectedIndex)
                    {
                        case 1:
                            decimation = (100 / decimation);
                            break;

                        case 2:
                            decimation = (100 * 60 / decimation);
                            break;

                        case 3:
                            decimation = (100 * 3600 / decimation);
                            break;

                        default:
                            break;
                    }
                txtCreepSampleDecimation.Text = decimation > 0 ? decimation.ToString() : "";
            }
            else
                txtCreepSampleDecimation.Text = "";
        }
    }
}
