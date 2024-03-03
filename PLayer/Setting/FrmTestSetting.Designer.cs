using System;
using System.Drawing;

namespace STM.PLayer.Setting
{
    partial class FrmTestSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestSetting));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.llSample = new System.Windows.Forms.LinkLabel();
			this.llInformation = new System.Windows.Forms.LinkLabel();
			this.llMethod = new System.Windows.Forms.LinkLabel();
			this.llExport = new System.Windows.Forms.LinkLabel();
			this.panelNavigation = new System.Windows.Forms.Panel();
			this.llStopCondition = new System.Windows.Forms.LinkLabel();
			this.llcancel = new System.Windows.Forms.LinkLabel();
			this.llSaveDefulat = new System.Windows.Forms.LinkLabel();
			this.llCtr = new System.Windows.Forms.LinkLabel();
			this.llImport = new System.Windows.Forms.LinkLabel();
			this.llOk = new System.Windows.Forms.LinkLabel();
			this.llReporting = new System.Windows.Forms.LinkLabel();
			this.llmeasures = new System.Windows.Forms.LinkLabel();
			this.llLoadDefault = new System.Windows.Forms.LinkLabel();
			this.tcSetting = new System.Windows.Forms.TabControl();
			this.tpMethod = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label74 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.txtCurPosition = new STM.PLayer.NRTextBox();
			this.label62 = new System.Windows.Forms.Label();
			this.cbMethodTestMethod = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.pnlSpeed = new System.Windows.Forms.Panel();
			this.cbSpeedUnits = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtMethodSpeed = new STM.PLayer.NRTextBox();
			this.tbTestMethods = new System.Windows.Forms.TabControl();
			this.tpTensile = new System.Windows.Forms.TabPage();
			this.collapsiblePanel1 = new STM.PLayer.Other.CollapsiblePanel.CollapsiblePanel();
			this.lbAdvanced = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtBreakCounter = new STM.PLayer.NRTextBox();
			this.txtBreakForceOver = new STM.PLayer.NRTextBox();
			this.cbTensilePreLoad = new System.Windows.Forms.CheckBox();
			this.label69 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.cbTensileStoEType = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cbTensileStoEChangeMode = new System.Windows.Forms.ComboBox();
			this.cbTensilePreLoadType = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.txtTensilePreLoadSetPoint = new STM.PLayer.NRTextBox();
			this.txtTensilePreLoadWait = new STM.PLayer.NRTextBox();
			this.txtTensileSecondSpeed = new STM.PLayer.NRTextBox();
			this.cbTensileEnableStoE = new System.Windows.Forms.CheckBox();
			this.cbTensileSecSpeedTypeUnit = new System.Windows.Forms.ComboBox();
			this.lbTensileSpeedUnit = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.cbTensilePreLoadSetZero = new System.Windows.Forms.ComboBox();
			this.txtTensileSecSpeedSetPoint = new STM.PLayer.NRTextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.cbTensileSecSpeedType = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.cbTensileStoEUnit = new System.Windows.Forms.ComboBox();
			this.lbTensileS2E = new System.Windows.Forms.Label();
			this.txtTensileStoESetPoint = new STM.PLayer.NRTextBox();
			this.cbPreLoadUnits = new System.Windows.Forms.ComboBox();
			this.cbTensileEnableSecondSpeed = new System.Windows.Forms.CheckBox();
			this.tpCompressive = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.txtCyclicCount = new STM.PLayer.NRTextBox();
			this.txtCyclicDelay = new STM.PLayer.NRTextBox();
			this.label79 = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.lbCyclicLimit2Unit = new System.Windows.Forms.Label();
			this.lbCyclicLimit1Unit = new System.Windows.Forms.Label();
			this.lbCyclicLimit2 = new System.Windows.Forms.Label();
			this.lbCyclicLimit1 = new System.Windows.Forms.Label();
			this.cbCyclicLimitType = new System.Windows.Forms.ComboBox();
			this.label39 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.cbCyclicRateUnit = new System.Windows.Forms.ComboBox();
			this.label35 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.cbCyclicRateControl = new System.Windows.Forms.ComboBox();
			this.txtCyclicLimit2 = new STM.PLayer.NRTextBox();
			this.txtCyclicLimit1 = new STM.PLayer.NRTextBox();
			this.txtCyclicRate = new STM.PLayer.NRTextBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.txtStepRate = new STM.PLayer.NRTextBox();
			this.lbStepSetExtensionUbit = new System.Windows.Forms.Label();
			this.lbStepForceUnit = new System.Windows.Forms.Label();
			this.cbStepSetForce = new System.Windows.Forms.CheckBox();
			this.label53 = new System.Windows.Forms.Label();
			this.cbSetPointAction = new System.Windows.Forms.ComboBox();
			this.llStepUpdate = new System.Windows.Forms.LinkLabel();
			this.dgvStep = new System.Windows.Forms.DataGridView();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label13 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.llStepAdd = new System.Windows.Forms.LinkLabel();
			this.llStepCancel = new System.Windows.Forms.LinkLabel();
			this.lbStepSetPointUnit = new System.Windows.Forms.Label();
			this.label92 = new System.Windows.Forms.Label();
			this.cbStepSetPointType = new System.Windows.Forms.ComboBox();
			this.label93 = new System.Windows.Forms.Label();
			this.cbStepRateUnit = new System.Windows.Forms.ComboBox();
			this.label94 = new System.Windows.Forms.Label();
			this.label95 = new System.Windows.Forms.Label();
			this.cbStepSetPointRateControl = new System.Windows.Forms.ComboBox();
			this.txtStepSetExtension = new STM.PLayer.NRTextBox();
			this.txtStepSetForce = new STM.PLayer.NRTextBox();
			this.txtStepSetPointAction = new STM.PLayer.NRTextBox();
			this.txtStepSetPoint = new STM.PLayer.NRTextBox();
			this.cbStepSetExtension = new System.Windows.Forms.CheckBox();
			this.tpCreep = new System.Windows.Forms.TabPage();
			this.gbCreepTemperature = new System.Windows.Forms.Panel();
			this.label67 = new System.Windows.Forms.Label();
			this.txtCreepTemperatureOffsetValue = new STM.PLayer.NRTextBox();
			this.btnCreepApplyTemperature = new System.Windows.Forms.Button();
			this.label59 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.lblCreepTemperatuerUnit = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.nrPreHeatTimeH = new STM.PLayer.NRTextBox();
			this.nrPreHeatTime = new STM.PLayer.NRTextBox();
			this.txtCreepTemperatureValue = new STM.PLayer.NRTextBox();
			this.gbCreepPreload = new System.Windows.Forms.Panel();
			this.chkResetExtension = new System.Windows.Forms.CheckBox();
			this.label64 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.lblCreep1 = new System.Windows.Forms.Label();
			this.lblCreepPreloadUnit = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.cbCreepPreloadType = new System.Windows.Forms.ComboBox();
			this.txtCreepPreloadTimeH = new STM.PLayer.NRTextBox();
			this.txtCreepPreloadTime = new STM.PLayer.NRTextBox();
			this.txtCreepPreload = new STM.PLayer.NRTextBox();
			this.cboDecimationUnit = new System.Windows.Forms.ComboBox();
			this.label82 = new System.Windows.Forms.Label();
			this.label81 = new System.Windows.Forms.Label();
			this.txtCreepTestTimeH = new STM.PLayer.NRTextBox();
			this.txtCreepStablizeTimeH = new STM.PLayer.NRTextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.txtCreepSampleDecimation = new STM.PLayer.NRTextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.lbCreepSetPointUnit = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.cbCreepRateUnit = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.cbCreepSetPointType = new System.Windows.Forms.ComboBox();
			this.cbCreepSetPointRateControl = new System.Windows.Forms.ComboBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.cbCreepPlotAll = new System.Windows.Forms.CheckBox();
			this.txtCreepRate = new STM.PLayer.NRTextBox();
			this.txtCreepSetPoint = new STM.PLayer.NRTextBox();
			this.txtCreepStablizeTime = new STM.PLayer.NRTextBox();
			this.txtCreepTestTime = new STM.PLayer.NRTextBox();
			this.tpRelaxation = new System.Windows.Forms.TabPage();
			this.label43 = new System.Windows.Forms.Label();
			this.txtRelaxationSampleDecimation = new STM.PLayer.NRTextBox();
			this.lbRelaxSetPointUnit = new System.Windows.Forms.Label();
			this.label90 = new System.Windows.Forms.Label();
			this.cbRelaxRateUnit = new System.Windows.Forms.ComboBox();
			this.label89 = new System.Windows.Forms.Label();
			this.cbRelaxSetPointType = new System.Windows.Forms.ComboBox();
			this.cbRelaxSetPointRateControl = new System.Windows.Forms.ComboBox();
			this.label75 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lbRelaxCm = new System.Windows.Forms.Label();
			this.cbRelaxPlotAll = new System.Windows.Forms.CheckBox();
			this.label77 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.txtRelaxationTestDuration = new System.Windows.Forms.Label();
			this.txtRelaxRate = new STM.PLayer.NRTextBox();
			this.txtRelaxSetPoint = new STM.PLayer.NRTextBox();
			this.txtRelaxStablizeTime = new STM.PLayer.NRTextBox();
			this.txtRelaxTestTime = new STM.PLayer.NRTextBox();
			this.tpSample = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.cbTestingSampleType = new System.Windows.Forms.ComboBox();
			this.label71 = new System.Windows.Forms.Label();
			this.txtSampleGP = new STM.PLayer.NRTextBox();
			this.lbSampleGP = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.lbSampleUnit3 = new System.Windows.Forms.Label();
			this.cbSampleType = new System.Windows.Forms.ComboBox();
			this.lbSampleDim3 = new System.Windows.Forms.Label();
			this.lbSampleUnit2 = new System.Windows.Forms.Label();
			this.txtSampleId = new System.Windows.Forms.TextBox();
			this.lbSampleUnit1 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.lbSampleDim2 = new System.Windows.Forms.Label();
			this.lbAreaInertiaUnit = new System.Windows.Forms.Label();
			this.lbSampleDim1 = new System.Windows.Forms.Label();
			this.txtSampleGS = new STM.PLayer.NRTextBox();
			this.txtSampleDim3 = new System.Windows.Forms.TextBox();
			this.lbAreaInertia = new System.Windows.Forms.Label();
			this.txtSampleDim2 = new System.Windows.Forms.TextBox();
			this.txtSampleDim1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSampleAreaInertia = new STM.PLayer.NRTextBox();
			this.lbSampleGS = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tpInformation = new System.Windows.Forms.TabPage();
			this.cboDateCultureFormat = new System.Windows.Forms.ComboBox();
			this.label72 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtInfomationTestDiscription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtInfomationTestDate = new System.Windows.Forms.TextBox();
			this.txtInfomationOperator = new System.Windows.Forms.TextBox();
			this.txtInfomationCustomer = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tpMeasures = new System.Windows.Forms.TabPage();
			this.label52 = new System.Windows.Forms.Label();
			this.label99 = new System.Windows.Forms.Label();
			this.label98 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.cbM7Tool = new System.Windows.Forms.ComboBox();
			this.cbM6Tool = new System.Windows.Forms.ComboBox();
			this.cbM5Tool = new System.Windows.Forms.ComboBox();
			this.cbM4Tool = new System.Windows.Forms.ComboBox();
			this.cbM3Tool = new System.Windows.Forms.ComboBox();
			this.cbM2Tool = new System.Windows.Forms.ComboBox();
			this.cbM1Tool = new System.Windows.Forms.ComboBox();
			this.llMeasuresOk = new System.Windows.Forms.LinkLabel();
			this.txtMeasure7Label = new System.Windows.Forms.TextBox();
			this.txtMeasure6Label = new System.Windows.Forms.TextBox();
			this.txtMeasure5Label = new System.Windows.Forms.TextBox();
			this.txtMeasure4Label = new System.Windows.Forms.TextBox();
			this.txtMeasure3Label = new System.Windows.Forms.TextBox();
			this.txtMeasure2Label = new System.Windows.Forms.TextBox();
			this.txtMeasure1Label = new System.Windows.Forms.TextBox();
			this.cbMeasureType7 = new System.Windows.Forms.ComboBox();
			this.cbMeasureType6 = new System.Windows.Forms.ComboBox();
			this.cbMeasureType5 = new System.Windows.Forms.ComboBox();
			this.cbMeasureType4 = new System.Windows.Forms.ComboBox();
			this.cbMeasureType3 = new System.Windows.Forms.ComboBox();
			this.cbMeasureType2 = new System.Windows.Forms.ComboBox();
			this.cbMeasureType1 = new System.Windows.Forms.ComboBox();
			this.label51 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.tpDiagram = new System.Windows.Forms.TabPage();
			this.lbDiagramYUnit = new System.Windows.Forms.Label();
			this.lbDiagramXUnit = new System.Windows.Forms.Label();
			this.txtDiagramYStop = new STM.PLayer.NRTextBox();
			this.txtDiagramXStop = new STM.PLayer.NRTextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.cbReportFiles = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbDefaultReport = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.label88 = new System.Windows.Forms.Label();
			this.cbDiagramY2Axis = new System.Windows.Forms.ComboBox();
			this.cbDiagramYAxis = new System.Windows.Forms.ComboBox();
			this.cbDiagramXAxis = new System.Windows.Forms.ComboBox();
			this.label32 = new System.Windows.Forms.Label();
			this.cbDiagramStartUp = new System.Windows.Forms.CheckBox();
			this.tpCtrl = new System.Windows.Forms.TabPage();
			this.panleSpeedSettingSelector = new System.Windows.Forms.Panel();
			this.llSpdctrlDefault = new System.Windows.Forms.LinkLabel();
			this.cbSpeed = new System.Windows.Forms.ComboBox();
			this.label96 = new System.Windows.Forms.Label();
			this.label97 = new System.Windows.Forms.Label();
			this.tcSpeedControl = new System.Windows.Forms.TabControl();
			this.tpExtenCtrl = new System.Windows.Forms.TabPage();
			this.label101 = new System.Windows.Forms.Label();
			this.txtExtenTor = new STM.PLayer.NRTextBox();
			this.txtKed = new STM.PLayer.NRTextBox();
			this.txtKei = new STM.PLayer.NRTextBox();
			this.txtKep = new STM.PLayer.NRTextBox();
			this.label102 = new System.Windows.Forms.Label();
			this.label103 = new System.Windows.Forms.Label();
			this.label104 = new System.Windows.Forms.Label();
			this.label105 = new System.Windows.Forms.Label();
			this.tpForceCtrl = new System.Windows.Forms.TabPage();
			this.label106 = new System.Windows.Forms.Label();
			this.label107 = new System.Windows.Forms.Label();
			this.label108 = new System.Windows.Forms.Label();
			this.label109 = new System.Windows.Forms.Label();
			this.label110 = new System.Windows.Forms.Label();
			this.txtForceTor = new STM.PLayer.NRTextBox();
			this.txtKfd = new STM.PLayer.NRTextBox();
			this.txtKfi = new STM.PLayer.NRTextBox();
			this.txtKfp = new STM.PLayer.NRTextBox();
			this.tpStrainCtrl = new System.Windows.Forms.TabPage();
			this.label111 = new System.Windows.Forms.Label();
			this.label112 = new System.Windows.Forms.Label();
			this.label113 = new System.Windows.Forms.Label();
			this.label114 = new System.Windows.Forms.Label();
			this.label115 = new System.Windows.Forms.Label();
			this.txtStrainTor = new STM.PLayer.NRTextBox();
			this.txtKsd = new STM.PLayer.NRTextBox();
			this.txtKsi = new STM.PLayer.NRTextBox();
			this.txtKsp = new STM.PLayer.NRTextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lbConditionUbit = new System.Windows.Forms.Label();
			this.txtConditionValue = new STM.PLayer.NRTextBox();
			this.cbConditionType = new System.Windows.Forms.ComboBox();
			this.label54 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.cbStopCondition = new System.Windows.Forms.CheckBox();
			this.panelNavigation.SuspendLayout();
			this.tcSetting.SuspendLayout();
			this.tpMethod.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlSpeed.SuspendLayout();
			this.tbTestMethods.SuspendLayout();
			this.tpTensile.SuspendLayout();
			this.collapsiblePanel1.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStep)).BeginInit();
			this.tpCreep.SuspendLayout();
			this.gbCreepTemperature.SuspendLayout();
			this.gbCreepPreload.SuspendLayout();
			this.tpRelaxation.SuspendLayout();
			this.tpSample.SuspendLayout();
			this.tpInformation.SuspendLayout();
			this.tpMeasures.SuspendLayout();
			this.tpDiagram.SuspendLayout();
			this.tpCtrl.SuspendLayout();
			this.panleSpeedSettingSelector.SuspendLayout();
			this.tcSpeedControl.SuspendLayout();
			this.tpExtenCtrl.SuspendLayout();
			this.tpForceCtrl.SuspendLayout();
			this.tpStrainCtrl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// llSample
			// 
			resources.ApplyResources(this.llSample, "llSample");
			this.llSample.AutoEllipsis = true;
			this.llSample.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llSample.Name = "llSample";
			this.llSample.TabStop = true;
			this.llSample.Tag = "Group";
			this.llSample.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llSample.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSample_LinkClicked);
			// 
			// llInformation
			// 
			resources.ApplyResources(this.llInformation, "llInformation");
			this.llInformation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llInformation.Name = "llInformation";
			this.llInformation.TabStop = true;
			this.llInformation.Tag = "Group";
			this.llInformation.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llInformation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llInformation_LinkClicked);
			// 
			// llMethod
			// 
			resources.ApplyResources(this.llMethod, "llMethod");
			this.llMethod.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llMethod.Name = "llMethod";
			this.llMethod.TabStop = true;
			this.llMethod.Tag = "Group";
			this.llMethod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
			// 
			// llExport
			// 
			resources.ApplyResources(this.llExport, "llExport");
			this.llExport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llExport.Name = "llExport";
			this.llExport.TabStop = true;
			this.llExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llExport_LinkClicked);
			// 
			// panelNavigation
			// 
			resources.ApplyResources(this.panelNavigation, "panelNavigation");
			this.panelNavigation.BackColor = System.Drawing.Color.White;
			this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelNavigation.Controls.Add(this.llStopCondition);
			this.panelNavigation.Controls.Add(this.llcancel);
			this.panelNavigation.Controls.Add(this.llSaveDefulat);
			this.panelNavigation.Controls.Add(this.llCtr);
			this.panelNavigation.Controls.Add(this.llImport);
			this.panelNavigation.Controls.Add(this.llOk);
			this.panelNavigation.Controls.Add(this.llReporting);
			this.panelNavigation.Controls.Add(this.llmeasures);
			this.panelNavigation.Controls.Add(this.llExport);
			this.panelNavigation.Controls.Add(this.llSample);
			this.panelNavigation.Controls.Add(this.llMethod);
			this.panelNavigation.Controls.Add(this.llInformation);
			this.panelNavigation.Controls.Add(this.llLoadDefault);
			this.panelNavigation.Name = "panelNavigation";
			// 
			// llStopCondition
			// 
			resources.ApplyResources(this.llStopCondition, "llStopCondition");
			this.llStopCondition.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llStopCondition.Name = "llStopCondition";
			this.llStopCondition.TabStop = true;
			this.llStopCondition.Tag = "Group";
			this.llStopCondition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStopCondition_LinkClicked);
			// 
			// llcancel
			// 
			resources.ApplyResources(this.llcancel, "llcancel");
			this.llcancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llcancel.Name = "llcancel";
			this.llcancel.TabStop = true;
			this.llcancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llcancel_LinkClicked);
			// 
			// llSaveDefulat
			// 
			resources.ApplyResources(this.llSaveDefulat, "llSaveDefulat");
			this.llSaveDefulat.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llSaveDefulat.Name = "llSaveDefulat";
			this.llSaveDefulat.TabStop = true;
			this.llSaveDefulat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSaveDefulat_LinkClicked);
			// 
			// llCtr
			// 
			resources.ApplyResources(this.llCtr, "llCtr");
			this.llCtr.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llCtr.Name = "llCtr";
			this.llCtr.TabStop = true;
			this.llCtr.Tag = "Group";
			this.llCtr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCtrl_LinkClicked);
			// 
			// llImport
			// 
			resources.ApplyResources(this.llImport, "llImport");
			this.llImport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llImport.Name = "llImport";
			this.llImport.TabStop = true;
			this.llImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llImport_LinkClicked);
			// 
			// llOk
			// 
			resources.ApplyResources(this.llOk, "llOk");
			this.llOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llOk.Name = "llOk";
			this.llOk.TabStop = true;
			this.llOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOk_LinkClicked);
			// 
			// llReporting
			// 
			resources.ApplyResources(this.llReporting, "llReporting");
			this.llReporting.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llReporting.Name = "llReporting";
			this.llReporting.TabStop = true;
			this.llReporting.Tag = "Group";
			this.llReporting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDiagram_LinkClicked);
			// 
			// llmeasures
			// 
			resources.ApplyResources(this.llmeasures, "llmeasures");
			this.llmeasures.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llmeasures.Name = "llmeasures";
			this.llmeasures.TabStop = true;
			this.llmeasures.Tag = "Group";
			this.llmeasures.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llmeasures_LinkClicked);
			// 
			// llLoadDefault
			// 
			resources.ApplyResources(this.llLoadDefault, "llLoadDefault");
			this.llLoadDefault.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llLoadDefault.Name = "llLoadDefault";
			this.llLoadDefault.TabStop = true;
			this.llLoadDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLoadDefault_LinkClicked);
			// 
			// tcSetting
			// 
			resources.ApplyResources(this.tcSetting, "tcSetting");
			this.tcSetting.Controls.Add(this.tpMethod);
			this.tcSetting.Controls.Add(this.tpSample);
			this.tcSetting.Controls.Add(this.tpInformation);
			this.tcSetting.Controls.Add(this.tpMeasures);
			this.tcSetting.Controls.Add(this.tpDiagram);
			this.tcSetting.Controls.Add(this.tpCtrl);
			this.tcSetting.Controls.Add(this.tabPage1);
			this.tcSetting.Multiline = true;
			this.tcSetting.Name = "tcSetting";
			this.tcSetting.SelectedIndex = 0;
			// 
			// tpMethod
			// 
			resources.ApplyResources(this.tpMethod, "tpMethod");
			this.tpMethod.Controls.Add(this.panel1);
			this.tpMethod.Controls.Add(this.tbTestMethods);
			this.tpMethod.Name = "tpMethod";
			this.tpMethod.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label74);
			this.panel1.Controls.Add(this.label63);
			this.panel1.Controls.Add(this.txtCurPosition);
			this.panel1.Controls.Add(this.label62);
			this.panel1.Controls.Add(this.cbMethodTestMethod);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.pnlSpeed);
			this.panel1.Name = "panel1";
			// 
			// label74
			// 
			resources.ApplyResources(this.label74, "label74");
			this.label74.Name = "label74";
			// 
			// label63
			// 
			resources.ApplyResources(this.label63, "label63");
			this.label63.Name = "label63";
			// 
			// txtCurPosition
			// 
			resources.ApplyResources(this.txtCurPosition, "txtCurPosition");
			this.txtCurPosition.BackColor = System.Drawing.Color.White;
			this.txtCurPosition.CheckInRange = false;
			this.txtCurPosition.DataType = STM.DLayer.DataType.Double;
			this.txtCurPosition.DefaultValue = "0";
			this.txtCurPosition.FractionalDigits = 0;
			this.txtCurPosition.MaxValue = "0";
			this.txtCurPosition.MinValue = "0";
			this.txtCurPosition.Name = "txtCurPosition";
			this.txtCurPosition.Resolution = 0D;
			this.txtCurPosition.Text = "0";
			this.txtCurPosition.Tip = null;
			this.txtCurPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// label62
			// 
			resources.ApplyResources(this.label62, "label62");
			this.label62.Name = "label62";
			// 
			// cbMethodTestMethod
			// 
			resources.ApplyResources(this.cbMethodTestMethod, "cbMethodTestMethod");
			this.cbMethodTestMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMethodTestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMethodTestMethod.FormattingEnabled = true;
			this.cbMethodTestMethod.Items.AddRange(new object[] {
            resources.GetString("cbMethodTestMethod.Items"),
            resources.GetString("cbMethodTestMethod.Items1"),
            resources.GetString("cbMethodTestMethod.Items2"),
            resources.GetString("cbMethodTestMethod.Items3"),
            resources.GetString("cbMethodTestMethod.Items4"),
            resources.GetString("cbMethodTestMethod.Items5")});
			this.cbMethodTestMethod.Name = "cbMethodTestMethod";
			this.cbMethodTestMethod.SelectedIndexChanged += new System.EventHandler(this.cbMethodTestMethod_SelectedIndexChanged);
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// pnlSpeed
			// 
			resources.ApplyResources(this.pnlSpeed, "pnlSpeed");
			this.pnlSpeed.Controls.Add(this.cbSpeedUnits);
			this.pnlSpeed.Controls.Add(this.label12);
			this.pnlSpeed.Controls.Add(this.txtMethodSpeed);
			this.pnlSpeed.Name = "pnlSpeed";
			// 
			// cbSpeedUnits
			// 
			resources.ApplyResources(this.cbSpeedUnits, "cbSpeedUnits");
			this.cbSpeedUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbSpeedUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSpeedUnits.FormattingEnabled = true;
			this.cbSpeedUnits.Items.AddRange(new object[] {
            resources.GetString("cbSpeedUnits.Items"),
            resources.GetString("cbSpeedUnits.Items1"),
            resources.GetString("cbSpeedUnits.Items2"),
            resources.GetString("cbSpeedUnits.Items3"),
            resources.GetString("cbSpeedUnits.Items4"),
            resources.GetString("cbSpeedUnits.Items5")});
			this.cbSpeedUnits.Name = "cbSpeedUnits";
			this.cbSpeedUnits.SelectedIndexChanged += new System.EventHandler(this.cbTensileSpeedUnits_SelectedIndexChanged);
			this.cbSpeedUnits.Enter += new System.EventHandler(this.cbSpeedUnits_Enter);
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// txtMethodSpeed
			// 
			resources.ApplyResources(this.txtMethodSpeed, "txtMethodSpeed");
			this.txtMethodSpeed.BackColor = System.Drawing.Color.White;
			this.txtMethodSpeed.CheckInRange = false;
			this.txtMethodSpeed.DataType = STM.DLayer.DataType.Double;
			this.txtMethodSpeed.DefaultValue = "0";
			this.txtMethodSpeed.FractionalDigits = 0;
			this.txtMethodSpeed.MaxValue = "0";
			this.txtMethodSpeed.MinValue = "0";
			this.txtMethodSpeed.Name = "txtMethodSpeed";
			this.txtMethodSpeed.Resolution = 0D;
			this.txtMethodSpeed.Text = "0";
			this.txtMethodSpeed.Tip = null;
			this.txtMethodSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// tbTestMethods
			// 
			resources.ApplyResources(this.tbTestMethods, "tbTestMethods");
			this.tbTestMethods.Controls.Add(this.tpTensile);
			this.tbTestMethods.Controls.Add(this.tpCompressive);
			this.tbTestMethods.Controls.Add(this.tabPage5);
			this.tbTestMethods.Controls.Add(this.tabPage6);
			this.tbTestMethods.Controls.Add(this.tpCreep);
			this.tbTestMethods.Controls.Add(this.tpRelaxation);
			this.tbTestMethods.Multiline = true;
			this.tbTestMethods.Name = "tbTestMethods";
			this.tbTestMethods.SelectedIndex = 0;
			// 
			// tpTensile
			// 
			resources.ApplyResources(this.tpTensile, "tpTensile");
			this.tpTensile.BackColor = System.Drawing.Color.White;
			this.tpTensile.Controls.Add(this.collapsiblePanel1);
			this.tpTensile.Name = "tpTensile";
			// 
			// collapsiblePanel1
			// 
			resources.ApplyResources(this.collapsiblePanel1, "collapsiblePanel1");
			this.collapsiblePanel1.BackColor = System.Drawing.Color.Transparent;
			this.collapsiblePanel1.Controls.Add(this.lbAdvanced);
			this.collapsiblePanel1.Controls.Add(this.label23);
			this.collapsiblePanel1.Controls.Add(this.txtBreakCounter);
			this.collapsiblePanel1.Controls.Add(this.txtBreakForceOver);
			this.collapsiblePanel1.Controls.Add(this.cbTensilePreLoad);
			this.collapsiblePanel1.Controls.Add(this.label69);
			this.collapsiblePanel1.Controls.Add(this.label14);
			this.collapsiblePanel1.Controls.Add(this.label68);
			this.collapsiblePanel1.Controls.Add(this.label41);
			this.collapsiblePanel1.Controls.Add(this.label40);
			this.collapsiblePanel1.Controls.Add(this.label18);
			this.collapsiblePanel1.Controls.Add(this.cbTensileStoEType);
			this.collapsiblePanel1.Controls.Add(this.label11);
			this.collapsiblePanel1.Controls.Add(this.cbTensileStoEChangeMode);
			this.collapsiblePanel1.Controls.Add(this.cbTensilePreLoadType);
			this.collapsiblePanel1.Controls.Add(this.label19);
			this.collapsiblePanel1.Controls.Add(this.label16);
			this.collapsiblePanel1.Controls.Add(this.txtTensilePreLoadSetPoint);
			this.collapsiblePanel1.Controls.Add(this.txtTensilePreLoadWait);
			this.collapsiblePanel1.Controls.Add(this.txtTensileSecondSpeed);
			this.collapsiblePanel1.Controls.Add(this.cbTensileEnableStoE);
			this.collapsiblePanel1.Controls.Add(this.cbTensileSecSpeedTypeUnit);
			this.collapsiblePanel1.Controls.Add(this.lbTensileSpeedUnit);
			this.collapsiblePanel1.Controls.Add(this.label21);
			this.collapsiblePanel1.Controls.Add(this.label15);
			this.collapsiblePanel1.Controls.Add(this.cbTensilePreLoadSetZero);
			this.collapsiblePanel1.Controls.Add(this.txtTensileSecSpeedSetPoint);
			this.collapsiblePanel1.Controls.Add(this.label30);
			this.collapsiblePanel1.Controls.Add(this.cbTensileSecSpeedType);
			this.collapsiblePanel1.Controls.Add(this.label17);
			this.collapsiblePanel1.Controls.Add(this.cbTensileStoEUnit);
			this.collapsiblePanel1.Controls.Add(this.lbTensileS2E);
			this.collapsiblePanel1.Controls.Add(this.txtTensileStoESetPoint);
			this.collapsiblePanel1.Controls.Add(this.cbPreLoadUnits);
			this.collapsiblePanel1.Controls.Add(this.cbTensileEnableSecondSpeed);
			this.collapsiblePanel1.HeaderBackColor = System.Drawing.Color.White;
			this.collapsiblePanel1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.collapsiblePanel1.HeaderImage = null;
			this.collapsiblePanel1.HeaderText = "  ";
			this.collapsiblePanel1.HeaderTextColor = System.Drawing.Color.Black;
			this.collapsiblePanel1.Name = "collapsiblePanel1";
			// 
			// lbAdvanced
			// 
			resources.ApplyResources(this.lbAdvanced, "lbAdvanced");
			this.lbAdvanced.Name = "lbAdvanced";
			// 
			// label23
			// 
			resources.ApplyResources(this.label23, "label23");
			this.label23.Name = "label23";
			// 
			// txtBreakCounter
			// 
			resources.ApplyResources(this.txtBreakCounter, "txtBreakCounter");
			this.txtBreakCounter.BackColor = System.Drawing.Color.White;
			this.txtBreakCounter.CheckInRange = true;
			this.txtBreakCounter.DataType = STM.DLayer.DataType.Double;
			this.txtBreakCounter.DefaultValue = "20";
			this.txtBreakCounter.FractionalDigits = 2;
			this.txtBreakCounter.MaxValue = "250";
			this.txtBreakCounter.MinValue = "0";
			this.txtBreakCounter.Name = "txtBreakCounter";
			this.txtBreakCounter.Resolution = 0D;
			this.txtBreakCounter.Text = "0";
			this.txtBreakCounter.Tip = null;
			// 
			// txtBreakForceOver
			// 
			resources.ApplyResources(this.txtBreakForceOver, "txtBreakForceOver");
			this.txtBreakForceOver.BackColor = System.Drawing.Color.White;
			this.txtBreakForceOver.CheckInRange = true;
			this.txtBreakForceOver.DataType = STM.DLayer.DataType.Double;
			this.txtBreakForceOver.DefaultValue = "20";
			this.txtBreakForceOver.FractionalDigits = 2;
			this.txtBreakForceOver.MaxValue = "80";
			this.txtBreakForceOver.MinValue = "5";
			this.txtBreakForceOver.Name = "txtBreakForceOver";
			this.txtBreakForceOver.Resolution = 0D;
			this.txtBreakForceOver.Text = "20";
			this.txtBreakForceOver.Tip = null;
			// 
			// cbTensilePreLoad
			// 
			resources.ApplyResources(this.cbTensilePreLoad, "cbTensilePreLoad");
			this.cbTensilePreLoad.Name = "cbTensilePreLoad";
			this.cbTensilePreLoad.UseVisualStyleBackColor = true;
			this.cbTensilePreLoad.CheckedChanged += new System.EventHandler(this.cbTensilePreLoad_CheckedChanged);
			// 
			// label69
			// 
			resources.ApplyResources(this.label69, "label69");
			this.label69.Name = "label69";
			// 
			// label14
			// 
			resources.ApplyResources(this.label14, "label14");
			this.label14.Name = "label14";
			// 
			// label68
			// 
			resources.ApplyResources(this.label68, "label68");
			this.label68.Name = "label68";
			// 
			// label41
			// 
			resources.ApplyResources(this.label41, "label41");
			this.label41.Name = "label41";
			// 
			// label40
			// 
			resources.ApplyResources(this.label40, "label40");
			this.label40.Name = "label40";
			// 
			// label18
			// 
			resources.ApplyResources(this.label18, "label18");
			this.label18.Name = "label18";
			// 
			// cbTensileStoEType
			// 
			resources.ApplyResources(this.cbTensileStoEType, "cbTensileStoEType");
			this.cbTensileStoEType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensileStoEType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensileStoEType.FormattingEnabled = true;
			this.cbTensileStoEType.Items.AddRange(new object[] {
            resources.GetString("cbTensileStoEType.Items"),
            resources.GetString("cbTensileStoEType.Items1")});
			this.cbTensileStoEType.Name = "cbTensileStoEType";
			this.cbTensileStoEType.SelectedIndexChanged += new System.EventHandler(this.TensileControlStrainToExten_SelectedIndexChanged);
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// cbTensileStoEChangeMode
			// 
			resources.ApplyResources(this.cbTensileStoEChangeMode, "cbTensileStoEChangeMode");
			this.cbTensileStoEChangeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensileStoEChangeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensileStoEChangeMode.FormattingEnabled = true;
			this.cbTensileStoEChangeMode.Items.AddRange(new object[] {
            resources.GetString("cbTensileStoEChangeMode.Items"),
            resources.GetString("cbTensileStoEChangeMode.Items1")});
			this.cbTensileStoEChangeMode.Name = "cbTensileStoEChangeMode";
			// 
			// cbTensilePreLoadType
			// 
			resources.ApplyResources(this.cbTensilePreLoadType, "cbTensilePreLoadType");
			this.cbTensilePreLoadType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensilePreLoadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensilePreLoadType.FormattingEnabled = true;
			this.cbTensilePreLoadType.Items.AddRange(new object[] {
            resources.GetString("cbTensilePreLoadType.Items"),
            resources.GetString("cbTensilePreLoadType.Items1")});
			this.cbTensilePreLoadType.Name = "cbTensilePreLoadType";
			this.cbTensilePreLoadType.SelectedIndexChanged += new System.EventHandler(this.TensileControlTypeChanges_SelectedIndexChanged);
			// 
			// label19
			// 
			resources.ApplyResources(this.label19, "label19");
			this.label19.Name = "label19";
			// 
			// label16
			// 
			resources.ApplyResources(this.label16, "label16");
			this.label16.Name = "label16";
			// 
			// txtTensilePreLoadSetPoint
			// 
			resources.ApplyResources(this.txtTensilePreLoadSetPoint, "txtTensilePreLoadSetPoint");
			this.txtTensilePreLoadSetPoint.BackColor = System.Drawing.Color.White;
			this.txtTensilePreLoadSetPoint.CheckInRange = false;
			this.txtTensilePreLoadSetPoint.DataType = STM.DLayer.DataType.Double;
			this.txtTensilePreLoadSetPoint.DefaultValue = "0.0";
			this.txtTensilePreLoadSetPoint.FractionalDigits = 2;
			this.txtTensilePreLoadSetPoint.MaxValue = "0";
			this.txtTensilePreLoadSetPoint.MinValue = "0";
			this.txtTensilePreLoadSetPoint.Name = "txtTensilePreLoadSetPoint";
			this.txtTensilePreLoadSetPoint.Resolution = 0D;
			this.txtTensilePreLoadSetPoint.Text = "0.0";
			this.txtTensilePreLoadSetPoint.Tip = null;
			// 
			// txtTensilePreLoadWait
			// 
			resources.ApplyResources(this.txtTensilePreLoadWait, "txtTensilePreLoadWait");
			this.txtTensilePreLoadWait.BackColor = System.Drawing.Color.White;
			this.txtTensilePreLoadWait.CheckInRange = false;
			this.txtTensilePreLoadWait.DataType = STM.DLayer.DataType.Double;
			this.txtTensilePreLoadWait.DefaultValue = "0.0";
			this.txtTensilePreLoadWait.FractionalDigits = 2;
			this.txtTensilePreLoadWait.MaxValue = "0";
			this.txtTensilePreLoadWait.MinValue = "0";
			this.txtTensilePreLoadWait.Name = "txtTensilePreLoadWait";
			this.txtTensilePreLoadWait.Resolution = 0D;
			this.txtTensilePreLoadWait.Text = "0.0";
			this.txtTensilePreLoadWait.Tip = null;
			// 
			// txtTensileSecondSpeed
			// 
			resources.ApplyResources(this.txtTensileSecondSpeed, "txtTensileSecondSpeed");
			this.txtTensileSecondSpeed.BackColor = System.Drawing.Color.White;
			this.txtTensileSecondSpeed.CheckInRange = false;
			this.txtTensileSecondSpeed.DataType = STM.DLayer.DataType.Double;
			this.txtTensileSecondSpeed.DefaultValue = "0.0";
			this.txtTensileSecondSpeed.FractionalDigits = 2;
			this.txtTensileSecondSpeed.MaxValue = "0";
			this.txtTensileSecondSpeed.MinValue = "0";
			this.txtTensileSecondSpeed.Name = "txtTensileSecondSpeed";
			this.txtTensileSecondSpeed.Resolution = 0D;
			this.txtTensileSecondSpeed.Text = "0.0";
			this.txtTensileSecondSpeed.Tip = null;
			// 
			// cbTensileEnableStoE
			// 
			resources.ApplyResources(this.cbTensileEnableStoE, "cbTensileEnableStoE");
			this.cbTensileEnableStoE.Name = "cbTensileEnableStoE";
			this.cbTensileEnableStoE.UseVisualStyleBackColor = true;
			this.cbTensileEnableStoE.CheckedChanged += new System.EventHandler(this.cbTensileEnableStoE_CheckedChanged);
			// 
			// cbTensileSecSpeedTypeUnit
			// 
			resources.ApplyResources(this.cbTensileSecSpeedTypeUnit, "cbTensileSecSpeedTypeUnit");
			this.cbTensileSecSpeedTypeUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensileSecSpeedTypeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensileSecSpeedTypeUnit.FormattingEnabled = true;
			this.cbTensileSecSpeedTypeUnit.Items.AddRange(new object[] {
            resources.GetString("cbTensileSecSpeedTypeUnit.Items"),
            resources.GetString("cbTensileSecSpeedTypeUnit.Items1")});
			this.cbTensileSecSpeedTypeUnit.Name = "cbTensileSecSpeedTypeUnit";
			this.cbTensileSecSpeedTypeUnit.SelectedIndexChanged += new System.EventHandler(this.cbTensileSecSpeedTypeUnit_SelectedIndexChanged);
			this.cbTensileSecSpeedTypeUnit.Enter += new System.EventHandler(this.cbTensileSecSpeedTypeUnit_Enter);
			// 
			// lbTensileSpeedUnit
			// 
			resources.ApplyResources(this.lbTensileSpeedUnit, "lbTensileSpeedUnit");
			this.lbTensileSpeedUnit.Name = "lbTensileSpeedUnit";
			// 
			// label21
			// 
			resources.ApplyResources(this.label21, "label21");
			this.label21.Name = "label21";
			// 
			// label15
			// 
			resources.ApplyResources(this.label15, "label15");
			this.label15.Name = "label15";
			// 
			// cbTensilePreLoadSetZero
			// 
			resources.ApplyResources(this.cbTensilePreLoadSetZero, "cbTensilePreLoadSetZero");
			this.cbTensilePreLoadSetZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensilePreLoadSetZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensilePreLoadSetZero.FormattingEnabled = true;
			this.cbTensilePreLoadSetZero.Items.AddRange(new object[] {
            resources.GetString("cbTensilePreLoadSetZero.Items"),
            resources.GetString("cbTensilePreLoadSetZero.Items1"),
            resources.GetString("cbTensilePreLoadSetZero.Items2"),
            resources.GetString("cbTensilePreLoadSetZero.Items3"),
            resources.GetString("cbTensilePreLoadSetZero.Items4"),
            resources.GetString("cbTensilePreLoadSetZero.Items5")});
			this.cbTensilePreLoadSetZero.Name = "cbTensilePreLoadSetZero";
			// 
			// txtTensileSecSpeedSetPoint
			// 
			resources.ApplyResources(this.txtTensileSecSpeedSetPoint, "txtTensileSecSpeedSetPoint");
			this.txtTensileSecSpeedSetPoint.BackColor = System.Drawing.Color.White;
			this.txtTensileSecSpeedSetPoint.CheckInRange = false;
			this.txtTensileSecSpeedSetPoint.DataType = STM.DLayer.DataType.Double;
			this.txtTensileSecSpeedSetPoint.DefaultValue = "0.0";
			this.txtTensileSecSpeedSetPoint.FractionalDigits = 2;
			this.txtTensileSecSpeedSetPoint.MaxValue = "0";
			this.txtTensileSecSpeedSetPoint.MinValue = "0";
			this.txtTensileSecSpeedSetPoint.Name = "txtTensileSecSpeedSetPoint";
			this.txtTensileSecSpeedSetPoint.Resolution = 0D;
			this.txtTensileSecSpeedSetPoint.Text = "0.0";
			this.txtTensileSecSpeedSetPoint.Tip = null;
			// 
			// label30
			// 
			resources.ApplyResources(this.label30, "label30");
			this.label30.Name = "label30";
			// 
			// cbTensileSecSpeedType
			// 
			resources.ApplyResources(this.cbTensileSecSpeedType, "cbTensileSecSpeedType");
			this.cbTensileSecSpeedType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensileSecSpeedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensileSecSpeedType.FormattingEnabled = true;
			this.cbTensileSecSpeedType.Items.AddRange(new object[] {
            resources.GetString("cbTensileSecSpeedType.Items"),
            resources.GetString("cbTensileSecSpeedType.Items1")});
			this.cbTensileSecSpeedType.Name = "cbTensileSecSpeedType";
			this.cbTensileSecSpeedType.SelectedIndexChanged += new System.EventHandler(this.TensileControlTypeChanges_SelectedIndexChanged);
			// 
			// label17
			// 
			resources.ApplyResources(this.label17, "label17");
			this.label17.Name = "label17";
			// 
			// cbTensileStoEUnit
			// 
			resources.ApplyResources(this.cbTensileStoEUnit, "cbTensileStoEUnit");
			this.cbTensileStoEUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTensileStoEUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTensileStoEUnit.FormattingEnabled = true;
			this.cbTensileStoEUnit.Items.AddRange(new object[] {
            resources.GetString("cbTensileStoEUnit.Items"),
            resources.GetString("cbTensileStoEUnit.Items1")});
			this.cbTensileStoEUnit.Name = "cbTensileStoEUnit";
			this.cbTensileStoEUnit.SelectedIndexChanged += new System.EventHandler(this.cbTensileStoEUnit_SelectedIndexChanged);
			this.cbTensileStoEUnit.Enter += new System.EventHandler(this.cbTensileStoEUnit_Enter);
			// 
			// lbTensileS2E
			// 
			resources.ApplyResources(this.lbTensileS2E, "lbTensileS2E");
			this.lbTensileS2E.Name = "lbTensileS2E";
			// 
			// txtTensileStoESetPoint
			// 
			resources.ApplyResources(this.txtTensileStoESetPoint, "txtTensileStoESetPoint");
			this.txtTensileStoESetPoint.BackColor = System.Drawing.Color.White;
			this.txtTensileStoESetPoint.CheckInRange = false;
			this.txtTensileStoESetPoint.DataType = STM.DLayer.DataType.Double;
			this.txtTensileStoESetPoint.DefaultValue = "0.0";
			this.txtTensileStoESetPoint.FractionalDigits = 2;
			this.txtTensileStoESetPoint.MaxValue = "0";
			this.txtTensileStoESetPoint.MinValue = "0";
			this.txtTensileStoESetPoint.Name = "txtTensileStoESetPoint";
			this.txtTensileStoESetPoint.Resolution = 0D;
			this.txtTensileStoESetPoint.Text = "0.0";
			this.txtTensileStoESetPoint.Tip = null;
			// 
			// cbPreLoadUnits
			// 
			resources.ApplyResources(this.cbPreLoadUnits, "cbPreLoadUnits");
			this.cbPreLoadUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbPreLoadUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPreLoadUnits.FormattingEnabled = true;
			this.cbPreLoadUnits.Items.AddRange(new object[] {
            resources.GetString("cbPreLoadUnits.Items"),
            resources.GetString("cbPreLoadUnits.Items1")});
			this.cbPreLoadUnits.Name = "cbPreLoadUnits";
			this.cbPreLoadUnits.SelectedIndexChanged += new System.EventHandler(this.cbPreLoadUnits_SelectedIndexChanged);
			this.cbPreLoadUnits.Enter += new System.EventHandler(this.cbPreLoadUnits_Enter);
			// 
			// cbTensileEnableSecondSpeed
			// 
			resources.ApplyResources(this.cbTensileEnableSecondSpeed, "cbTensileEnableSecondSpeed");
			this.cbTensileEnableSecondSpeed.Name = "cbTensileEnableSecondSpeed";
			this.cbTensileEnableSecondSpeed.UseVisualStyleBackColor = true;
			this.cbTensileEnableSecondSpeed.CheckedChanged += new System.EventHandler(this.cbTensileEnableSecondSpeed_CheckedChanged);
			// 
			// tpCompressive
			// 
			resources.ApplyResources(this.tpCompressive, "tpCompressive");
			this.tpCompressive.BackColor = System.Drawing.Color.White;
			this.tpCompressive.Name = "tpCompressive";
			// 
			// tabPage5
			// 
			resources.ApplyResources(this.tabPage5, "tabPage5");
			this.tabPage5.BackColor = System.Drawing.Color.White;
			this.tabPage5.Controls.Add(this.txtCyclicCount);
			this.tabPage5.Controls.Add(this.txtCyclicDelay);
			this.tabPage5.Controls.Add(this.label79);
			this.tabPage5.Controls.Add(this.label78);
			this.tabPage5.Controls.Add(this.lbCyclicLimit2Unit);
			this.tabPage5.Controls.Add(this.lbCyclicLimit1Unit);
			this.tabPage5.Controls.Add(this.lbCyclicLimit2);
			this.tabPage5.Controls.Add(this.lbCyclicLimit1);
			this.tabPage5.Controls.Add(this.cbCyclicLimitType);
			this.tabPage5.Controls.Add(this.label39);
			this.tabPage5.Controls.Add(this.label38);
			this.tabPage5.Controls.Add(this.cbCyclicRateUnit);
			this.tabPage5.Controls.Add(this.label35);
			this.tabPage5.Controls.Add(this.label37);
			this.tabPage5.Controls.Add(this.cbCyclicRateControl);
			this.tabPage5.Controls.Add(this.txtCyclicLimit2);
			this.tabPage5.Controls.Add(this.txtCyclicLimit1);
			this.tabPage5.Controls.Add(this.txtCyclicRate);
			this.tabPage5.Name = "tabPage5";
			// 
			// txtCyclicCount
			// 
			resources.ApplyResources(this.txtCyclicCount, "txtCyclicCount");
			this.txtCyclicCount.BackColor = System.Drawing.Color.White;
			this.txtCyclicCount.CheckInRange = false;
			this.txtCyclicCount.DataType = STM.DLayer.DataType.Int;
			this.txtCyclicCount.DefaultValue = "0.0";
			this.txtCyclicCount.FractionalDigits = 2;
			this.txtCyclicCount.MaxValue = "0";
			this.txtCyclicCount.MinValue = "0";
			this.txtCyclicCount.Name = "txtCyclicCount";
			this.txtCyclicCount.Resolution = 0D;
			this.txtCyclicCount.Text = "0";
			this.txtCyclicCount.Tip = null;
			// 
			// txtCyclicDelay
			// 
			resources.ApplyResources(this.txtCyclicDelay, "txtCyclicDelay");
			this.txtCyclicDelay.BackColor = System.Drawing.Color.White;
			this.txtCyclicDelay.CheckInRange = false;
			this.txtCyclicDelay.DataType = STM.DLayer.DataType.Double;
			this.txtCyclicDelay.DefaultValue = "0";
			this.txtCyclicDelay.FractionalDigits = 0;
			this.txtCyclicDelay.MaxValue = "0";
			this.txtCyclicDelay.MinValue = "0";
			this.txtCyclicDelay.Name = "txtCyclicDelay";
			this.txtCyclicDelay.Resolution = 0D;
			this.txtCyclicDelay.Text = "0";
			this.txtCyclicDelay.Tip = null;
			this.txtCyclicDelay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// label79
			// 
			resources.ApplyResources(this.label79, "label79");
			this.label79.Name = "label79";
			// 
			// label78
			// 
			resources.ApplyResources(this.label78, "label78");
			this.label78.Name = "label78";
			// 
			// lbCyclicLimit2Unit
			// 
			resources.ApplyResources(this.lbCyclicLimit2Unit, "lbCyclicLimit2Unit");
			this.lbCyclicLimit2Unit.Name = "lbCyclicLimit2Unit";
			// 
			// lbCyclicLimit1Unit
			// 
			resources.ApplyResources(this.lbCyclicLimit1Unit, "lbCyclicLimit1Unit");
			this.lbCyclicLimit1Unit.Name = "lbCyclicLimit1Unit";
			// 
			// lbCyclicLimit2
			// 
			resources.ApplyResources(this.lbCyclicLimit2, "lbCyclicLimit2");
			this.lbCyclicLimit2.Name = "lbCyclicLimit2";
			// 
			// lbCyclicLimit1
			// 
			resources.ApplyResources(this.lbCyclicLimit1, "lbCyclicLimit1");
			this.lbCyclicLimit1.Name = "lbCyclicLimit1";
			// 
			// cbCyclicLimitType
			// 
			resources.ApplyResources(this.cbCyclicLimitType, "cbCyclicLimitType");
			this.cbCyclicLimitType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCyclicLimitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCyclicLimitType.FormattingEnabled = true;
			this.cbCyclicLimitType.Items.AddRange(new object[] {
            resources.GetString("cbCyclicLimitType.Items"),
            resources.GetString("cbCyclicLimitType.Items1")});
			this.cbCyclicLimitType.Name = "cbCyclicLimitType";
			this.cbCyclicLimitType.SelectedIndexChanged += new System.EventHandler(this.cbCycleLimitType_SelectedIndexChanged);
			// 
			// label39
			// 
			resources.ApplyResources(this.label39, "label39");
			this.label39.Name = "label39";
			// 
			// label38
			// 
			resources.ApplyResources(this.label38, "label38");
			this.label38.Name = "label38";
			// 
			// cbCyclicRateUnit
			// 
			resources.ApplyResources(this.cbCyclicRateUnit, "cbCyclicRateUnit");
			this.cbCyclicRateUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCyclicRateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCyclicRateUnit.FormattingEnabled = true;
			this.cbCyclicRateUnit.Items.AddRange(new object[] {
            resources.GetString("cbCyclicRateUnit.Items"),
            resources.GetString("cbCyclicRateUnit.Items1")});
			this.cbCyclicRateUnit.Name = "cbCyclicRateUnit";
			this.cbCyclicRateUnit.SelectedIndexChanged += new System.EventHandler(this.cbCyclicRateUnit_SelectedIndexChanged);
			this.cbCyclicRateUnit.Enter += new System.EventHandler(this.cbCyclicRateUnit_Enter);
			// 
			// label35
			// 
			resources.ApplyResources(this.label35, "label35");
			this.label35.Name = "label35";
			// 
			// label37
			// 
			resources.ApplyResources(this.label37, "label37");
			this.label37.Name = "label37";
			// 
			// cbCyclicRateControl
			// 
			resources.ApplyResources(this.cbCyclicRateControl, "cbCyclicRateControl");
			this.cbCyclicRateControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCyclicRateControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCyclicRateControl.FormattingEnabled = true;
			this.cbCyclicRateControl.Items.AddRange(new object[] {
            resources.GetString("cbCyclicRateControl.Items"),
            resources.GetString("cbCyclicRateControl.Items1")});
			this.cbCyclicRateControl.Name = "cbCyclicRateControl";
			this.cbCyclicRateControl.SelectedIndexChanged += new System.EventHandler(this.RateContolChanged);
			// 
			// txtCyclicLimit2
			// 
			resources.ApplyResources(this.txtCyclicLimit2, "txtCyclicLimit2");
			this.txtCyclicLimit2.BackColor = System.Drawing.Color.White;
			this.txtCyclicLimit2.CheckInRange = false;
			this.txtCyclicLimit2.DataType = STM.DLayer.DataType.Double;
			this.txtCyclicLimit2.DefaultValue = "0.0";
			this.txtCyclicLimit2.FractionalDigits = 2;
			this.txtCyclicLimit2.MaxValue = "0";
			this.txtCyclicLimit2.MinValue = "0";
			this.txtCyclicLimit2.Name = "txtCyclicLimit2";
			this.txtCyclicLimit2.Resolution = 0D;
			this.txtCyclicLimit2.Text = "0.0";
			this.txtCyclicLimit2.Tip = null;
			this.txtCyclicLimit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtCyclicLimit1
			// 
			resources.ApplyResources(this.txtCyclicLimit1, "txtCyclicLimit1");
			this.txtCyclicLimit1.BackColor = System.Drawing.Color.White;
			this.txtCyclicLimit1.CheckInRange = false;
			this.txtCyclicLimit1.DataType = STM.DLayer.DataType.Double;
			this.txtCyclicLimit1.DefaultValue = "0.0";
			this.txtCyclicLimit1.FractionalDigits = 2;
			this.txtCyclicLimit1.MaxValue = "0";
			this.txtCyclicLimit1.MinValue = "0";
			this.txtCyclicLimit1.Name = "txtCyclicLimit1";
			this.txtCyclicLimit1.Resolution = 0D;
			this.txtCyclicLimit1.Text = "0.0";
			this.txtCyclicLimit1.Tip = null;
			this.txtCyclicLimit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtCyclicRate
			// 
			resources.ApplyResources(this.txtCyclicRate, "txtCyclicRate");
			this.txtCyclicRate.BackColor = System.Drawing.Color.White;
			this.txtCyclicRate.CheckInRange = false;
			this.txtCyclicRate.DataType = STM.DLayer.DataType.Double;
			this.txtCyclicRate.DefaultValue = "0.0";
			this.txtCyclicRate.FractionalDigits = 2;
			this.txtCyclicRate.MaxValue = "0";
			this.txtCyclicRate.MinValue = "0";
			this.txtCyclicRate.Name = "txtCyclicRate";
			this.txtCyclicRate.Resolution = 0D;
			this.txtCyclicRate.Text = "0.0";
			this.txtCyclicRate.Tip = null;
			// 
			// tabPage6
			// 
			resources.ApplyResources(this.tabPage6, "tabPage6");
			this.tabPage6.BackColor = System.Drawing.Color.White;
			this.tabPage6.Controls.Add(this.txtStepRate);
			this.tabPage6.Controls.Add(this.lbStepSetExtensionUbit);
			this.tabPage6.Controls.Add(this.lbStepForceUnit);
			this.tabPage6.Controls.Add(this.cbStepSetForce);
			this.tabPage6.Controls.Add(this.label53);
			this.tabPage6.Controls.Add(this.cbSetPointAction);
			this.tabPage6.Controls.Add(this.llStepUpdate);
			this.tabPage6.Controls.Add(this.dgvStep);
			this.tabPage6.Controls.Add(this.label13);
			this.tabPage6.Controls.Add(this.label83);
			this.tabPage6.Controls.Add(this.llStepAdd);
			this.tabPage6.Controls.Add(this.llStepCancel);
			this.tabPage6.Controls.Add(this.lbStepSetPointUnit);
			this.tabPage6.Controls.Add(this.label92);
			this.tabPage6.Controls.Add(this.cbStepSetPointType);
			this.tabPage6.Controls.Add(this.label93);
			this.tabPage6.Controls.Add(this.cbStepRateUnit);
			this.tabPage6.Controls.Add(this.label94);
			this.tabPage6.Controls.Add(this.label95);
			this.tabPage6.Controls.Add(this.cbStepSetPointRateControl);
			this.tabPage6.Controls.Add(this.txtStepSetExtension);
			this.tabPage6.Controls.Add(this.txtStepSetForce);
			this.tabPage6.Controls.Add(this.txtStepSetPointAction);
			this.tabPage6.Controls.Add(this.txtStepSetPoint);
			this.tabPage6.Controls.Add(this.cbStepSetExtension);
			this.tabPage6.Name = "tabPage6";
			// 
			// txtStepRate
			// 
			resources.ApplyResources(this.txtStepRate, "txtStepRate");
			this.txtStepRate.BackColor = System.Drawing.Color.White;
			this.txtStepRate.CheckInRange = false;
			this.txtStepRate.DataType = STM.DLayer.DataType.Double;
			this.txtStepRate.DefaultValue = "0.0";
			this.txtStepRate.FractionalDigits = 2;
			this.txtStepRate.MaxValue = "0";
			this.txtStepRate.MinValue = "0";
			this.txtStepRate.Name = "txtStepRate";
			this.txtStepRate.Resolution = 0D;
			this.txtStepRate.Text = "0.0";
			this.txtStepRate.Tip = null;
			// 
			// lbStepSetExtensionUbit
			// 
			resources.ApplyResources(this.lbStepSetExtensionUbit, "lbStepSetExtensionUbit");
			this.lbStepSetExtensionUbit.Name = "lbStepSetExtensionUbit";
			// 
			// lbStepForceUnit
			// 
			resources.ApplyResources(this.lbStepForceUnit, "lbStepForceUnit");
			this.lbStepForceUnit.Name = "lbStepForceUnit";
			// 
			// cbStepSetForce
			// 
			resources.ApplyResources(this.cbStepSetForce, "cbStepSetForce");
			this.cbStepSetForce.Name = "cbStepSetForce";
			this.cbStepSetForce.UseVisualStyleBackColor = true;
			// 
			// label53
			// 
			resources.ApplyResources(this.label53, "label53");
			this.label53.Name = "label53";
			// 
			// cbSetPointAction
			// 
			resources.ApplyResources(this.cbSetPointAction, "cbSetPointAction");
			this.cbSetPointAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbSetPointAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSetPointAction.FormattingEnabled = true;
			this.cbSetPointAction.Items.AddRange(new object[] {
            resources.GetString("cbSetPointAction.Items"),
            resources.GetString("cbSetPointAction.Items1"),
            resources.GetString("cbSetPointAction.Items2")});
			this.cbSetPointAction.Name = "cbSetPointAction";
			this.cbSetPointAction.SelectedIndexChanged += new System.EventHandler(this.cbSetPointAction_SelectedIndexChanged);
			// 
			// llStepUpdate
			// 
			resources.ApplyResources(this.llStepUpdate, "llStepUpdate");
			this.llStepUpdate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llStepUpdate.Name = "llStepUpdate";
			this.llStepUpdate.TabStop = true;
			this.llStepUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStpUpdate_LinkClicked);
			// 
			// dgvStep
			// 
			resources.ApplyResources(this.dgvStep, "dgvStep");
			this.dgvStep.AllowUserToAddRows = false;
			this.dgvStep.AllowUserToResizeColumns = false;
			this.dgvStep.AllowUserToResizeRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvStep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvStep.BackgroundColor = System.Drawing.Color.White;
			this.dgvStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvStep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column7,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
			this.dgvStep.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvStep.Name = "dgvStep";
			this.dgvStep.RowHeadersVisible = false;
			this.dgvStep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStep.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStep_CellMouseDoubleClick);
			this.dgvStep.SelectionChanged += new System.EventHandler(this.dgvStep_SelectionChanged);
			// 
			// Column9
			// 
			resources.ApplyResources(this.Column9, "Column9");
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Column1
			// 
			resources.ApplyResources(this.Column1, "Column1");
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			resources.ApplyResources(this.Column2, "Column2");
			this.Column2.Name = "Column2";
			// 
			// Column3
			// 
			resources.ApplyResources(this.Column3, "Column3");
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			resources.ApplyResources(this.Column4, "Column4");
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			resources.ApplyResources(this.Column5, "Column5");
			this.Column5.Name = "Column5";
			// 
			// Column6
			// 
			resources.ApplyResources(this.Column6, "Column6");
			this.Column6.Name = "Column6";
			// 
			// Column8
			// 
			resources.ApplyResources(this.Column8, "Column8");
			this.Column8.Name = "Column8";
			// 
			// Column7
			// 
			resources.ApplyResources(this.Column7, "Column7");
			this.Column7.Name = "Column7";
			// 
			// Column10
			// 
			resources.ApplyResources(this.Column10, "Column10");
			this.Column10.Name = "Column10";
			// 
			// Column11
			// 
			resources.ApplyResources(this.Column11, "Column11");
			this.Column11.Name = "Column11";
			// 
			// Column12
			// 
			resources.ApplyResources(this.Column12, "Column12");
			this.Column12.Name = "Column12";
			// 
			// Column13
			// 
			resources.ApplyResources(this.Column13, "Column13");
			this.Column13.Name = "Column13";
			// 
			// Column14
			// 
			resources.ApplyResources(this.Column14, "Column14");
			this.Column14.Name = "Column14";
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// label83
			// 
			resources.ApplyResources(this.label83, "label83");
			this.label83.Name = "label83";
			// 
			// llStepAdd
			// 
			resources.ApplyResources(this.llStepAdd, "llStepAdd");
			this.llStepAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llStepAdd.Name = "llStepAdd";
			this.llStepAdd.TabStop = true;
			this.llStepAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStepAdd_LinkClicked);
			// 
			// llStepCancel
			// 
			resources.ApplyResources(this.llStepCancel, "llStepCancel");
			this.llStepCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llStepCancel.Name = "llStepCancel";
			this.llStepCancel.TabStop = true;
			this.llStepCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStepCancel_LinkClicked);
			// 
			// lbStepSetPointUnit
			// 
			resources.ApplyResources(this.lbStepSetPointUnit, "lbStepSetPointUnit");
			this.lbStepSetPointUnit.Name = "lbStepSetPointUnit";
			// 
			// label92
			// 
			resources.ApplyResources(this.label92, "label92");
			this.label92.Name = "label92";
			// 
			// cbStepSetPointType
			// 
			resources.ApplyResources(this.cbStepSetPointType, "cbStepSetPointType");
			this.cbStepSetPointType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbStepSetPointType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStepSetPointType.FormattingEnabled = true;
			this.cbStepSetPointType.Items.AddRange(new object[] {
            resources.GetString("cbStepSetPointType.Items"),
            resources.GetString("cbStepSetPointType.Items1")});
			this.cbStepSetPointType.Name = "cbStepSetPointType";
			this.cbStepSetPointType.SelectedIndexChanged += new System.EventHandler(this.cbStepSetPointType_SelectedIndexChanged);
			// 
			// label93
			// 
			resources.ApplyResources(this.label93, "label93");
			this.label93.Name = "label93";
			// 
			// cbStepRateUnit
			// 
			resources.ApplyResources(this.cbStepRateUnit, "cbStepRateUnit");
			this.cbStepRateUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbStepRateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStepRateUnit.FormattingEnabled = true;
			this.cbStepRateUnit.Items.AddRange(new object[] {
            resources.GetString("cbStepRateUnit.Items"),
            resources.GetString("cbStepRateUnit.Items1")});
			this.cbStepRateUnit.Name = "cbStepRateUnit";
			this.cbStepRateUnit.SelectedIndexChanged += new System.EventHandler(this.cbStepRateUnit_SelectedIndexChanged);
			this.cbStepRateUnit.Enter += new System.EventHandler(this.cbStepRateUnit_Enter);
			// 
			// label94
			// 
			resources.ApplyResources(this.label94, "label94");
			this.label94.Name = "label94";
			// 
			// label95
			// 
			resources.ApplyResources(this.label95, "label95");
			this.label95.Name = "label95";
			// 
			// cbStepSetPointRateControl
			// 
			resources.ApplyResources(this.cbStepSetPointRateControl, "cbStepSetPointRateControl");
			this.cbStepSetPointRateControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbStepSetPointRateControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStepSetPointRateControl.FormattingEnabled = true;
			this.cbStepSetPointRateControl.Items.AddRange(new object[] {
            resources.GetString("cbStepSetPointRateControl.Items"),
            resources.GetString("cbStepSetPointRateControl.Items1")});
			this.cbStepSetPointRateControl.Name = "cbStepSetPointRateControl";
			this.cbStepSetPointRateControl.SelectedIndexChanged += new System.EventHandler(this.RateContolChanged);
			// 
			// txtStepSetExtension
			// 
			resources.ApplyResources(this.txtStepSetExtension, "txtStepSetExtension");
			this.txtStepSetExtension.BackColor = System.Drawing.Color.White;
			this.txtStepSetExtension.CheckInRange = false;
			this.txtStepSetExtension.DataType = STM.DLayer.DataType.Double;
			this.txtStepSetExtension.DefaultValue = "0.0";
			this.txtStepSetExtension.FractionalDigits = 2;
			this.txtStepSetExtension.MaxValue = "0";
			this.txtStepSetExtension.MinValue = "0";
			this.txtStepSetExtension.Name = "txtStepSetExtension";
			this.txtStepSetExtension.Resolution = 0D;
			this.txtStepSetExtension.Text = "0.0";
			this.txtStepSetExtension.Tip = null;
			// 
			// txtStepSetForce
			// 
			resources.ApplyResources(this.txtStepSetForce, "txtStepSetForce");
			this.txtStepSetForce.BackColor = System.Drawing.Color.White;
			this.txtStepSetForce.CheckInRange = false;
			this.txtStepSetForce.DataType = STM.DLayer.DataType.Double;
			this.txtStepSetForce.DefaultValue = "0.0";
			this.txtStepSetForce.FractionalDigits = 2;
			this.txtStepSetForce.MaxValue = "0";
			this.txtStepSetForce.MinValue = "0";
			this.txtStepSetForce.Name = "txtStepSetForce";
			this.txtStepSetForce.Resolution = 0D;
			this.txtStepSetForce.Text = "0.0";
			this.txtStepSetForce.Tip = null;
			// 
			// txtStepSetPointAction
			// 
			resources.ApplyResources(this.txtStepSetPointAction, "txtStepSetPointAction");
			this.txtStepSetPointAction.BackColor = System.Drawing.Color.White;
			this.txtStepSetPointAction.CheckInRange = false;
			this.txtStepSetPointAction.DataType = STM.DLayer.DataType.Double;
			this.txtStepSetPointAction.DefaultValue = "0.0";
			this.txtStepSetPointAction.FractionalDigits = 2;
			this.txtStepSetPointAction.MaxValue = "0";
			this.txtStepSetPointAction.MinValue = "0";
			this.txtStepSetPointAction.Name = "txtStepSetPointAction";
			this.txtStepSetPointAction.Resolution = 0D;
			this.txtStepSetPointAction.Text = "0.0";
			this.txtStepSetPointAction.Tip = null;
			// 
			// txtStepSetPoint
			// 
			resources.ApplyResources(this.txtStepSetPoint, "txtStepSetPoint");
			this.txtStepSetPoint.BackColor = System.Drawing.Color.White;
			this.txtStepSetPoint.CheckInRange = false;
			this.txtStepSetPoint.DataType = STM.DLayer.DataType.Double;
			this.txtStepSetPoint.DefaultValue = "0.0";
			this.txtStepSetPoint.FractionalDigits = 2;
			this.txtStepSetPoint.MaxValue = "0";
			this.txtStepSetPoint.MinValue = "0";
			this.txtStepSetPoint.Name = "txtStepSetPoint";
			this.txtStepSetPoint.Resolution = 0D;
			this.txtStepSetPoint.Text = "0.0";
			this.txtStepSetPoint.Tip = null;
			// 
			// cbStepSetExtension
			// 
			resources.ApplyResources(this.cbStepSetExtension, "cbStepSetExtension");
			this.cbStepSetExtension.Name = "cbStepSetExtension";
			this.cbStepSetExtension.UseVisualStyleBackColor = true;
			// 
			// tpCreep
			// 
			resources.ApplyResources(this.tpCreep, "tpCreep");
			this.tpCreep.BackColor = System.Drawing.Color.White;
			this.tpCreep.Controls.Add(this.gbCreepTemperature);
			this.tpCreep.Controls.Add(this.gbCreepPreload);
			this.tpCreep.Controls.Add(this.cboDecimationUnit);
			this.tpCreep.Controls.Add(this.label82);
			this.tpCreep.Controls.Add(this.label81);
			this.tpCreep.Controls.Add(this.txtCreepTestTimeH);
			this.tpCreep.Controls.Add(this.txtCreepStablizeTimeH);
			this.tpCreep.Controls.Add(this.label44);
			this.tpCreep.Controls.Add(this.txtCreepSampleDecimation);
			this.tpCreep.Controls.Add(this.label27);
			this.tpCreep.Controls.Add(this.label28);
			this.tpCreep.Controls.Add(this.label29);
			this.tpCreep.Controls.Add(this.label33);
			this.tpCreep.Controls.Add(this.lbCreepSetPointUnit);
			this.tpCreep.Controls.Add(this.label25);
			this.tpCreep.Controls.Add(this.cbCreepRateUnit);
			this.tpCreep.Controls.Add(this.label26);
			this.tpCreep.Controls.Add(this.cbCreepSetPointType);
			this.tpCreep.Controls.Add(this.cbCreepSetPointRateControl);
			this.tpCreep.Controls.Add(this.label31);
			this.tpCreep.Controls.Add(this.label34);
			this.tpCreep.Controls.Add(this.cbCreepPlotAll);
			this.tpCreep.Controls.Add(this.txtCreepRate);
			this.tpCreep.Controls.Add(this.txtCreepSetPoint);
			this.tpCreep.Controls.Add(this.txtCreepStablizeTime);
			this.tpCreep.Controls.Add(this.txtCreepTestTime);
			this.tpCreep.Name = "tpCreep";
			// 
			// gbCreepTemperature
			// 
			resources.ApplyResources(this.gbCreepTemperature, "gbCreepTemperature");
			this.gbCreepTemperature.Controls.Add(this.label67);
			this.gbCreepTemperature.Controls.Add(this.txtCreepTemperatureOffsetValue);
			this.gbCreepTemperature.Controls.Add(this.btnCreepApplyTemperature);
			this.gbCreepTemperature.Controls.Add(this.label59);
			this.gbCreepTemperature.Controls.Add(this.label66);
			this.gbCreepTemperature.Controls.Add(this.lblCreepTemperatuerUnit);
			this.gbCreepTemperature.Controls.Add(this.label70);
			this.gbCreepTemperature.Controls.Add(this.label65);
			this.gbCreepTemperature.Controls.Add(this.nrPreHeatTimeH);
			this.gbCreepTemperature.Controls.Add(this.nrPreHeatTime);
			this.gbCreepTemperature.Controls.Add(this.txtCreepTemperatureValue);
			this.gbCreepTemperature.Name = "gbCreepTemperature";
			// 
			// label67
			// 
			resources.ApplyResources(this.label67, "label67");
			this.label67.Name = "label67";
			// 
			// txtCreepTemperatureOffsetValue
			// 
			resources.ApplyResources(this.txtCreepTemperatureOffsetValue, "txtCreepTemperatureOffsetValue");
			this.txtCreepTemperatureOffsetValue.BackColor = System.Drawing.Color.White;
			this.txtCreepTemperatureOffsetValue.CheckInRange = true;
			this.txtCreepTemperatureOffsetValue.DataType = STM.DLayer.DataType.Double;
			this.txtCreepTemperatureOffsetValue.DefaultValue = "0.0";
			this.txtCreepTemperatureOffsetValue.FractionalDigits = 0;
			this.txtCreepTemperatureOffsetValue.MaxValue = "100";
			this.txtCreepTemperatureOffsetValue.MinValue = "-100";
			this.txtCreepTemperatureOffsetValue.Name = "txtCreepTemperatureOffsetValue";
			this.txtCreepTemperatureOffsetValue.Resolution = 0D;
			this.txtCreepTemperatureOffsetValue.Text = "0.0";
			this.txtCreepTemperatureOffsetValue.Tip = null;
			// 
			// btnCreepApplyTemperature
			// 
			resources.ApplyResources(this.btnCreepApplyTemperature, "btnCreepApplyTemperature");
			this.btnCreepApplyTemperature.Name = "btnCreepApplyTemperature";
			this.btnCreepApplyTemperature.Tag = "Apply Temperature Set Point";
			this.btnCreepApplyTemperature.UseVisualStyleBackColor = true;
			this.btnCreepApplyTemperature.Click += new System.EventHandler(this.btnCreepApplyTemperature_Click);
			// 
			// label59
			// 
			resources.ApplyResources(this.label59, "label59");
			this.label59.Name = "label59";
			// 
			// label66
			// 
			resources.ApplyResources(this.label66, "label66");
			this.label66.Name = "label66";
			// 
			// lblCreepTemperatuerUnit
			// 
			resources.ApplyResources(this.lblCreepTemperatuerUnit, "lblCreepTemperatuerUnit");
			this.lblCreepTemperatuerUnit.Name = "lblCreepTemperatuerUnit";
			// 
			// label70
			// 
			resources.ApplyResources(this.label70, "label70");
			this.label70.Name = "label70";
			// 
			// label65
			// 
			resources.ApplyResources(this.label65, "label65");
			this.label65.Name = "label65";
			// 
			// nrPreHeatTimeH
			// 
			resources.ApplyResources(this.nrPreHeatTimeH, "nrPreHeatTimeH");
			this.nrPreHeatTimeH.BackColor = System.Drawing.Color.White;
			this.nrPreHeatTimeH.CheckInRange = false;
			this.nrPreHeatTimeH.DataType = STM.DLayer.DataType.Double;
			this.nrPreHeatTimeH.DefaultValue = "0.0";
			this.nrPreHeatTimeH.FractionalDigits = 0;
			this.nrPreHeatTimeH.MaxValue = "0";
			this.nrPreHeatTimeH.MinValue = "0";
			this.nrPreHeatTimeH.Name = "nrPreHeatTimeH";
			this.nrPreHeatTimeH.Resolution = 0D;
			this.nrPreHeatTimeH.Text = "0.0";
			this.nrPreHeatTimeH.Tip = null;
			// 
			// nrPreHeatTime
			// 
			resources.ApplyResources(this.nrPreHeatTime, "nrPreHeatTime");
			this.nrPreHeatTime.BackColor = System.Drawing.Color.White;
			this.nrPreHeatTime.CheckInRange = false;
			this.nrPreHeatTime.DataType = STM.DLayer.DataType.Double;
			this.nrPreHeatTime.DefaultValue = "0.0";
			this.nrPreHeatTime.FractionalDigits = 0;
			this.nrPreHeatTime.MaxValue = "0";
			this.nrPreHeatTime.MinValue = "0";
			this.nrPreHeatTime.Name = "nrPreHeatTime";
			this.nrPreHeatTime.Resolution = 0D;
			this.nrPreHeatTime.Text = "0.0";
			this.nrPreHeatTime.Tip = null;
			// 
			// txtCreepTemperatureValue
			// 
			resources.ApplyResources(this.txtCreepTemperatureValue, "txtCreepTemperatureValue");
			this.txtCreepTemperatureValue.BackColor = System.Drawing.Color.White;
			this.txtCreepTemperatureValue.CheckInRange = true;
			this.txtCreepTemperatureValue.DataType = STM.DLayer.DataType.Double;
			this.txtCreepTemperatureValue.DefaultValue = "0.0";
			this.txtCreepTemperatureValue.FractionalDigits = 0;
			this.txtCreepTemperatureValue.MaxValue = "2000";
			this.txtCreepTemperatureValue.MinValue = "0";
			this.txtCreepTemperatureValue.Name = "txtCreepTemperatureValue";
			this.txtCreepTemperatureValue.Resolution = 0D;
			this.txtCreepTemperatureValue.Text = "0.0";
			this.txtCreepTemperatureValue.Tip = null;
			// 
			// gbCreepPreload
			// 
			resources.ApplyResources(this.gbCreepPreload, "gbCreepPreload");
			this.gbCreepPreload.Controls.Add(this.chkResetExtension);
			this.gbCreepPreload.Controls.Add(this.label64);
			this.gbCreepPreload.Controls.Add(this.label57);
			this.gbCreepPreload.Controls.Add(this.label73);
			this.gbCreepPreload.Controls.Add(this.lblCreep1);
			this.gbCreepPreload.Controls.Add(this.lblCreepPreloadUnit);
			this.gbCreepPreload.Controls.Add(this.label60);
			this.gbCreepPreload.Controls.Add(this.cbCreepPreloadType);
			this.gbCreepPreload.Controls.Add(this.txtCreepPreloadTimeH);
			this.gbCreepPreload.Controls.Add(this.txtCreepPreloadTime);
			this.gbCreepPreload.Controls.Add(this.txtCreepPreload);
			this.gbCreepPreload.Name = "gbCreepPreload";
			// 
			// chkResetExtension
			// 
			resources.ApplyResources(this.chkResetExtension, "chkResetExtension");
			this.chkResetExtension.Name = "chkResetExtension";
			this.chkResetExtension.UseVisualStyleBackColor = true;
			// 
			// label64
			// 
			resources.ApplyResources(this.label64, "label64");
			this.label64.Name = "label64";
			// 
			// label57
			// 
			resources.ApplyResources(this.label57, "label57");
			this.label57.Name = "label57";
			// 
			// label73
			// 
			resources.ApplyResources(this.label73, "label73");
			this.label73.Name = "label73";
			// 
			// lblCreep1
			// 
			resources.ApplyResources(this.lblCreep1, "lblCreep1");
			this.lblCreep1.Name = "lblCreep1";
			// 
			// lblCreepPreloadUnit
			// 
			resources.ApplyResources(this.lblCreepPreloadUnit, "lblCreepPreloadUnit");
			this.lblCreepPreloadUnit.Name = "lblCreepPreloadUnit";
			// 
			// label60
			// 
			resources.ApplyResources(this.label60, "label60");
			this.label60.Name = "label60";
			// 
			// cbCreepPreloadType
			// 
			resources.ApplyResources(this.cbCreepPreloadType, "cbCreepPreloadType");
			this.cbCreepPreloadType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCreepPreloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCreepPreloadType.FormattingEnabled = true;
			this.cbCreepPreloadType.Items.AddRange(new object[] {
            resources.GetString("cbCreepPreloadType.Items"),
            resources.GetString("cbCreepPreloadType.Items1")});
			this.cbCreepPreloadType.Name = "cbCreepPreloadType";
			this.cbCreepPreloadType.SelectedIndexChanged += new System.EventHandler(this.cbCreepPreloadType_SelectedIndexChanged);
			// 
			// txtCreepPreloadTimeH
			// 
			resources.ApplyResources(this.txtCreepPreloadTimeH, "txtCreepPreloadTimeH");
			this.txtCreepPreloadTimeH.BackColor = System.Drawing.Color.White;
			this.txtCreepPreloadTimeH.CheckInRange = false;
			this.txtCreepPreloadTimeH.DataType = STM.DLayer.DataType.Double;
			this.txtCreepPreloadTimeH.DefaultValue = "0.0";
			this.txtCreepPreloadTimeH.FractionalDigits = 0;
			this.txtCreepPreloadTimeH.MaxValue = "0";
			this.txtCreepPreloadTimeH.MinValue = "0";
			this.txtCreepPreloadTimeH.Name = "txtCreepPreloadTimeH";
			this.txtCreepPreloadTimeH.Resolution = 0D;
			this.txtCreepPreloadTimeH.Text = "0.0";
			this.txtCreepPreloadTimeH.Tip = null;
			// 
			// txtCreepPreloadTime
			// 
			resources.ApplyResources(this.txtCreepPreloadTime, "txtCreepPreloadTime");
			this.txtCreepPreloadTime.BackColor = System.Drawing.Color.White;
			this.txtCreepPreloadTime.CheckInRange = false;
			this.txtCreepPreloadTime.DataType = STM.DLayer.DataType.Double;
			this.txtCreepPreloadTime.DefaultValue = "0.0";
			this.txtCreepPreloadTime.FractionalDigits = 0;
			this.txtCreepPreloadTime.MaxValue = "0";
			this.txtCreepPreloadTime.MinValue = "0";
			this.txtCreepPreloadTime.Name = "txtCreepPreloadTime";
			this.txtCreepPreloadTime.Resolution = 0D;
			this.txtCreepPreloadTime.Text = "0.0";
			this.txtCreepPreloadTime.Tip = null;
			// 
			// txtCreepPreload
			// 
			resources.ApplyResources(this.txtCreepPreload, "txtCreepPreload");
			this.txtCreepPreload.BackColor = System.Drawing.Color.White;
			this.txtCreepPreload.CheckInRange = false;
			this.txtCreepPreload.DataType = STM.DLayer.DataType.Double;
			this.txtCreepPreload.DefaultValue = "0.0";
			this.txtCreepPreload.FractionalDigits = 0;
			this.txtCreepPreload.MaxValue = "0";
			this.txtCreepPreload.MinValue = "0";
			this.txtCreepPreload.Name = "txtCreepPreload";
			this.txtCreepPreload.Resolution = 0D;
			this.txtCreepPreload.Text = "0.0";
			this.txtCreepPreload.Tip = null;
			this.txtCreepPreload.Enter += new System.EventHandler(this.txtCreepPreload_Enter);
			// 
			// cboDecimationUnit
			// 
			resources.ApplyResources(this.cboDecimationUnit, "cboDecimationUnit");
			this.cboDecimationUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDecimationUnit.FormattingEnabled = true;
			this.cboDecimationUnit.Items.AddRange(new object[] {
            resources.GetString("cboDecimationUnit.Items"),
            resources.GetString("cboDecimationUnit.Items1"),
            resources.GetString("cboDecimationUnit.Items2"),
            resources.GetString("cboDecimationUnit.Items3")});
			this.cboDecimationUnit.Name = "cboDecimationUnit";
			this.cboDecimationUnit.SelectedIndexChanged += new System.EventHandler(this.cboDecimationUnit_SelectedIndexChanged);
			// 
			// label82
			// 
			resources.ApplyResources(this.label82, "label82");
			this.label82.Name = "label82";
			// 
			// label81
			// 
			resources.ApplyResources(this.label81, "label81");
			this.label81.Name = "label81";
			// 
			// txtCreepTestTimeH
			// 
			resources.ApplyResources(this.txtCreepTestTimeH, "txtCreepTestTimeH");
			this.txtCreepTestTimeH.BackColor = System.Drawing.Color.White;
			this.txtCreepTestTimeH.CheckInRange = false;
			this.txtCreepTestTimeH.DataType = STM.DLayer.DataType.Double;
			this.txtCreepTestTimeH.DefaultValue = "0.0";
			this.txtCreepTestTimeH.FractionalDigits = 0;
			this.txtCreepTestTimeH.MaxValue = "0";
			this.txtCreepTestTimeH.MinValue = "0";
			this.txtCreepTestTimeH.Name = "txtCreepTestTimeH";
			this.txtCreepTestTimeH.Resolution = 0D;
			this.txtCreepTestTimeH.Text = "0.0";
			this.txtCreepTestTimeH.Tip = null;
			// 
			// txtCreepStablizeTimeH
			// 
			resources.ApplyResources(this.txtCreepStablizeTimeH, "txtCreepStablizeTimeH");
			this.txtCreepStablizeTimeH.BackColor = System.Drawing.Color.White;
			this.txtCreepStablizeTimeH.CheckInRange = false;
			this.txtCreepStablizeTimeH.DataType = STM.DLayer.DataType.Double;
			this.txtCreepStablizeTimeH.DefaultValue = "0.0";
			this.txtCreepStablizeTimeH.FractionalDigits = 0;
			this.txtCreepStablizeTimeH.MaxValue = "0";
			this.txtCreepStablizeTimeH.MinValue = "0";
			this.txtCreepStablizeTimeH.Name = "txtCreepStablizeTimeH";
			this.txtCreepStablizeTimeH.Resolution = 0D;
			this.txtCreepStablizeTimeH.Text = "0.0";
			this.txtCreepStablizeTimeH.Tip = null;
			// 
			// label44
			// 
			resources.ApplyResources(this.label44, "label44");
			this.label44.Name = "label44";
			// 
			// txtCreepSampleDecimation
			// 
			resources.ApplyResources(this.txtCreepSampleDecimation, "txtCreepSampleDecimation");
			this.txtCreepSampleDecimation.BackColor = System.Drawing.Color.White;
			this.txtCreepSampleDecimation.CheckInRange = true;
			this.txtCreepSampleDecimation.DataType = STM.DLayer.DataType.Int;
			this.txtCreepSampleDecimation.DefaultValue = "100";
			this.txtCreepSampleDecimation.FractionalDigits = 2;
			this.txtCreepSampleDecimation.MaxValue = "3600000";
			this.txtCreepSampleDecimation.MinValue = "0";
			this.txtCreepSampleDecimation.Name = "txtCreepSampleDecimation";
			this.txtCreepSampleDecimation.Resolution = 0D;
			this.txtCreepSampleDecimation.Text = "100";
			this.txtCreepSampleDecimation.Tip = null;
			// 
			// label27
			// 
			resources.ApplyResources(this.label27, "label27");
			this.label27.Name = "label27";
			// 
			// label28
			// 
			resources.ApplyResources(this.label28, "label28");
			this.label28.Name = "label28";
			// 
			// label29
			// 
			resources.ApplyResources(this.label29, "label29");
			this.label29.Name = "label29";
			// 
			// label33
			// 
			resources.ApplyResources(this.label33, "label33");
			this.label33.Name = "label33";
			// 
			// lbCreepSetPointUnit
			// 
			resources.ApplyResources(this.lbCreepSetPointUnit, "lbCreepSetPointUnit");
			this.lbCreepSetPointUnit.Name = "lbCreepSetPointUnit";
			// 
			// label25
			// 
			resources.ApplyResources(this.label25, "label25");
			this.label25.Name = "label25";
			// 
			// cbCreepRateUnit
			// 
			resources.ApplyResources(this.cbCreepRateUnit, "cbCreepRateUnit");
			this.cbCreepRateUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCreepRateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCreepRateUnit.FormattingEnabled = true;
			this.cbCreepRateUnit.Items.AddRange(new object[] {
            resources.GetString("cbCreepRateUnit.Items"),
            resources.GetString("cbCreepRateUnit.Items1")});
			this.cbCreepRateUnit.Name = "cbCreepRateUnit";
			this.cbCreepRateUnit.SelectedIndexChanged += new System.EventHandler(this.cbCreepRateUnit_SelectedIndexChanged);
			this.cbCreepRateUnit.Enter += new System.EventHandler(this.cbCreepRateUnit_Enter);
			// 
			// label26
			// 
			resources.ApplyResources(this.label26, "label26");
			this.label26.Name = "label26";
			// 
			// cbCreepSetPointType
			// 
			resources.ApplyResources(this.cbCreepSetPointType, "cbCreepSetPointType");
			this.cbCreepSetPointType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCreepSetPointType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCreepSetPointType.FormattingEnabled = true;
			this.cbCreepSetPointType.Items.AddRange(new object[] {
            resources.GetString("cbCreepSetPointType.Items"),
            resources.GetString("cbCreepSetPointType.Items1")});
			this.cbCreepSetPointType.Name = "cbCreepSetPointType";
			this.cbCreepSetPointType.SelectedIndexChanged += new System.EventHandler(this.cbCreepSetPointType_SelectedIndexChanged);
			// 
			// cbCreepSetPointRateControl
			// 
			resources.ApplyResources(this.cbCreepSetPointRateControl, "cbCreepSetPointRateControl");
			this.cbCreepSetPointRateControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbCreepSetPointRateControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCreepSetPointRateControl.FormattingEnabled = true;
			this.cbCreepSetPointRateControl.Items.AddRange(new object[] {
            resources.GetString("cbCreepSetPointRateControl.Items"),
            resources.GetString("cbCreepSetPointRateControl.Items1")});
			this.cbCreepSetPointRateControl.Name = "cbCreepSetPointRateControl";
			this.cbCreepSetPointRateControl.SelectedIndexChanged += new System.EventHandler(this.RateContolChanged);
			// 
			// label31
			// 
			resources.ApplyResources(this.label31, "label31");
			this.label31.Name = "label31";
			// 
			// label34
			// 
			resources.ApplyResources(this.label34, "label34");
			this.label34.Name = "label34";
			// 
			// cbCreepPlotAll
			// 
			resources.ApplyResources(this.cbCreepPlotAll, "cbCreepPlotAll");
			this.cbCreepPlotAll.Name = "cbCreepPlotAll";
			this.cbCreepPlotAll.UseVisualStyleBackColor = true;
			// 
			// txtCreepRate
			// 
			resources.ApplyResources(this.txtCreepRate, "txtCreepRate");
			this.txtCreepRate.BackColor = System.Drawing.Color.White;
			this.txtCreepRate.CheckInRange = false;
			this.txtCreepRate.DataType = STM.DLayer.DataType.Double;
			this.txtCreepRate.DefaultValue = "0.0";
			this.txtCreepRate.FractionalDigits = 0;
			this.txtCreepRate.MaxValue = "0";
			this.txtCreepRate.MinValue = "0";
			this.txtCreepRate.Name = "txtCreepRate";
			this.txtCreepRate.Resolution = 0D;
			this.txtCreepRate.Text = "0.0";
			this.txtCreepRate.Tip = null;
			// 
			// txtCreepSetPoint
			// 
			resources.ApplyResources(this.txtCreepSetPoint, "txtCreepSetPoint");
			this.txtCreepSetPoint.BackColor = System.Drawing.Color.White;
			this.txtCreepSetPoint.CheckInRange = false;
			this.txtCreepSetPoint.DataType = STM.DLayer.DataType.Double;
			this.txtCreepSetPoint.DefaultValue = "0.0";
			this.txtCreepSetPoint.FractionalDigits = 0;
			this.txtCreepSetPoint.MaxValue = "0";
			this.txtCreepSetPoint.MinValue = "0";
			this.txtCreepSetPoint.Name = "txtCreepSetPoint";
			this.txtCreepSetPoint.Resolution = 0D;
			this.txtCreepSetPoint.Text = "0.0";
			this.txtCreepSetPoint.Tip = null;
			this.txtCreepSetPoint.Enter += new System.EventHandler(this.txtCreepSetPoint_Enter);
			this.txtCreepSetPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtCreepStablizeTime
			// 
			resources.ApplyResources(this.txtCreepStablizeTime, "txtCreepStablizeTime");
			this.txtCreepStablizeTime.BackColor = System.Drawing.Color.White;
			this.txtCreepStablizeTime.CheckInRange = false;
			this.txtCreepStablizeTime.DataType = STM.DLayer.DataType.Double;
			this.txtCreepStablizeTime.DefaultValue = "0.0";
			this.txtCreepStablizeTime.FractionalDigits = 2;
			this.txtCreepStablizeTime.MaxValue = "0";
			this.txtCreepStablizeTime.MinValue = "0";
			this.txtCreepStablizeTime.Name = "txtCreepStablizeTime";
			this.txtCreepStablizeTime.Resolution = 0D;
			this.txtCreepStablizeTime.Text = "0.0";
			this.txtCreepStablizeTime.Tip = null;
			this.txtCreepStablizeTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtCreepTestTime
			// 
			resources.ApplyResources(this.txtCreepTestTime, "txtCreepTestTime");
			this.txtCreepTestTime.BackColor = System.Drawing.Color.White;
			this.txtCreepTestTime.CheckInRange = false;
			this.txtCreepTestTime.DataType = STM.DLayer.DataType.Double;
			this.txtCreepTestTime.DefaultValue = "0.0";
			this.txtCreepTestTime.FractionalDigits = 2;
			this.txtCreepTestTime.MaxValue = "0";
			this.txtCreepTestTime.MinValue = "0";
			this.txtCreepTestTime.Name = "txtCreepTestTime";
			this.txtCreepTestTime.Resolution = 0D;
			this.txtCreepTestTime.Text = "0.0";
			this.txtCreepTestTime.Tip = null;
			this.txtCreepTestTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// tpRelaxation
			// 
			resources.ApplyResources(this.tpRelaxation, "tpRelaxation");
			this.tpRelaxation.BackColor = System.Drawing.Color.White;
			this.tpRelaxation.Controls.Add(this.label43);
			this.tpRelaxation.Controls.Add(this.txtRelaxationSampleDecimation);
			this.tpRelaxation.Controls.Add(this.lbRelaxSetPointUnit);
			this.tpRelaxation.Controls.Add(this.label90);
			this.tpRelaxation.Controls.Add(this.cbRelaxRateUnit);
			this.tpRelaxation.Controls.Add(this.label89);
			this.tpRelaxation.Controls.Add(this.cbRelaxSetPointType);
			this.tpRelaxation.Controls.Add(this.cbRelaxSetPointRateControl);
			this.tpRelaxation.Controls.Add(this.label75);
			this.tpRelaxation.Controls.Add(this.label22);
			this.tpRelaxation.Controls.Add(this.lbRelaxCm);
			this.tpRelaxation.Controls.Add(this.cbRelaxPlotAll);
			this.tpRelaxation.Controls.Add(this.label77);
			this.tpRelaxation.Controls.Add(this.label80);
			this.tpRelaxation.Controls.Add(this.label76);
			this.tpRelaxation.Controls.Add(this.txtRelaxationTestDuration);
			this.tpRelaxation.Controls.Add(this.txtRelaxRate);
			this.tpRelaxation.Controls.Add(this.txtRelaxSetPoint);
			this.tpRelaxation.Controls.Add(this.txtRelaxStablizeTime);
			this.tpRelaxation.Controls.Add(this.txtRelaxTestTime);
			this.tpRelaxation.Name = "tpRelaxation";
			// 
			// label43
			// 
			resources.ApplyResources(this.label43, "label43");
			this.label43.Name = "label43";
			// 
			// txtRelaxationSampleDecimation
			// 
			resources.ApplyResources(this.txtRelaxationSampleDecimation, "txtRelaxationSampleDecimation");
			this.txtRelaxationSampleDecimation.BackColor = System.Drawing.Color.White;
			this.txtRelaxationSampleDecimation.CheckInRange = true;
			this.txtRelaxationSampleDecimation.DataType = STM.DLayer.DataType.Int;
			this.txtRelaxationSampleDecimation.DefaultValue = "100";
			this.txtRelaxationSampleDecimation.FractionalDigits = 2;
			this.txtRelaxationSampleDecimation.MaxValue = "3600000";
			this.txtRelaxationSampleDecimation.MinValue = "10";
			this.txtRelaxationSampleDecimation.Name = "txtRelaxationSampleDecimation";
			this.txtRelaxationSampleDecimation.Resolution = 0D;
			this.txtRelaxationSampleDecimation.Text = "100";
			this.txtRelaxationSampleDecimation.Tip = null;
			// 
			// lbRelaxSetPointUnit
			// 
			resources.ApplyResources(this.lbRelaxSetPointUnit, "lbRelaxSetPointUnit");
			this.lbRelaxSetPointUnit.Name = "lbRelaxSetPointUnit";
			// 
			// label90
			// 
			resources.ApplyResources(this.label90, "label90");
			this.label90.Name = "label90";
			// 
			// cbRelaxRateUnit
			// 
			resources.ApplyResources(this.cbRelaxRateUnit, "cbRelaxRateUnit");
			this.cbRelaxRateUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbRelaxRateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRelaxRateUnit.FormattingEnabled = true;
			this.cbRelaxRateUnit.Items.AddRange(new object[] {
            resources.GetString("cbRelaxRateUnit.Items"),
            resources.GetString("cbRelaxRateUnit.Items1")});
			this.cbRelaxRateUnit.Name = "cbRelaxRateUnit";
			this.cbRelaxRateUnit.SelectedIndexChanged += new System.EventHandler(this.cbRelaxRateUnit_SelectedIndexChanged);
			this.cbRelaxRateUnit.Enter += new System.EventHandler(this.cbRelaxRateUnit_Enter);
			// 
			// label89
			// 
			resources.ApplyResources(this.label89, "label89");
			this.label89.Name = "label89";
			// 
			// cbRelaxSetPointType
			// 
			resources.ApplyResources(this.cbRelaxSetPointType, "cbRelaxSetPointType");
			this.cbRelaxSetPointType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbRelaxSetPointType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRelaxSetPointType.FormattingEnabled = true;
			this.cbRelaxSetPointType.Items.AddRange(new object[] {
            resources.GetString("cbRelaxSetPointType.Items"),
            resources.GetString("cbRelaxSetPointType.Items1")});
			this.cbRelaxSetPointType.Name = "cbRelaxSetPointType";
			this.cbRelaxSetPointType.SelectedIndexChanged += new System.EventHandler(this.cbRelaxationSetPoint_SelectedIndexChanged);
			// 
			// cbRelaxSetPointRateControl
			// 
			resources.ApplyResources(this.cbRelaxSetPointRateControl, "cbRelaxSetPointRateControl");
			this.cbRelaxSetPointRateControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbRelaxSetPointRateControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRelaxSetPointRateControl.FormattingEnabled = true;
			this.cbRelaxSetPointRateControl.Items.AddRange(new object[] {
            resources.GetString("cbRelaxSetPointRateControl.Items"),
            resources.GetString("cbRelaxSetPointRateControl.Items1")});
			this.cbRelaxSetPointRateControl.Name = "cbRelaxSetPointRateControl";
			this.cbRelaxSetPointRateControl.SelectedIndexChanged += new System.EventHandler(this.RateContolChanged);
			// 
			// label75
			// 
			resources.ApplyResources(this.label75, "label75");
			this.label75.Name = "label75";
			// 
			// label22
			// 
			resources.ApplyResources(this.label22, "label22");
			this.label22.Name = "label22";
			// 
			// lbRelaxCm
			// 
			resources.ApplyResources(this.lbRelaxCm, "lbRelaxCm");
			this.lbRelaxCm.ForeColor = System.Drawing.Color.Green;
			this.lbRelaxCm.Name = "lbRelaxCm";
			// 
			// cbRelaxPlotAll
			// 
			resources.ApplyResources(this.cbRelaxPlotAll, "cbRelaxPlotAll");
			this.cbRelaxPlotAll.Name = "cbRelaxPlotAll";
			this.cbRelaxPlotAll.UseVisualStyleBackColor = true;
			// 
			// label77
			// 
			resources.ApplyResources(this.label77, "label77");
			this.label77.Name = "label77";
			// 
			// label80
			// 
			resources.ApplyResources(this.label80, "label80");
			this.label80.Name = "label80";
			// 
			// label76
			// 
			resources.ApplyResources(this.label76, "label76");
			this.label76.Name = "label76";
			// 
			// txtRelaxationTestDuration
			// 
			resources.ApplyResources(this.txtRelaxationTestDuration, "txtRelaxationTestDuration");
			this.txtRelaxationTestDuration.Name = "txtRelaxationTestDuration";
			// 
			// txtRelaxRate
			// 
			resources.ApplyResources(this.txtRelaxRate, "txtRelaxRate");
			this.txtRelaxRate.BackColor = System.Drawing.Color.White;
			this.txtRelaxRate.CheckInRange = false;
			this.txtRelaxRate.DataType = STM.DLayer.DataType.Double;
			this.txtRelaxRate.DefaultValue = "0.0";
			this.txtRelaxRate.FractionalDigits = 0;
			this.txtRelaxRate.MaxValue = "0";
			this.txtRelaxRate.MinValue = "0";
			this.txtRelaxRate.Name = "txtRelaxRate";
			this.txtRelaxRate.Resolution = 0D;
			this.txtRelaxRate.Text = "0.0";
			this.txtRelaxRate.Tip = null;
			// 
			// txtRelaxSetPoint
			// 
			resources.ApplyResources(this.txtRelaxSetPoint, "txtRelaxSetPoint");
			this.txtRelaxSetPoint.BackColor = System.Drawing.Color.White;
			this.txtRelaxSetPoint.CheckInRange = false;
			this.txtRelaxSetPoint.DataType = STM.DLayer.DataType.Double;
			this.txtRelaxSetPoint.DefaultValue = "0.0";
			this.txtRelaxSetPoint.FractionalDigits = 0;
			this.txtRelaxSetPoint.MaxValue = "0";
			this.txtRelaxSetPoint.MinValue = "0";
			this.txtRelaxSetPoint.Name = "txtRelaxSetPoint";
			this.txtRelaxSetPoint.Resolution = 0D;
			this.txtRelaxSetPoint.Text = "0.0";
			this.txtRelaxSetPoint.Tip = null;
			this.txtRelaxSetPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtRelaxStablizeTime
			// 
			resources.ApplyResources(this.txtRelaxStablizeTime, "txtRelaxStablizeTime");
			this.txtRelaxStablizeTime.BackColor = System.Drawing.Color.White;
			this.txtRelaxStablizeTime.CheckInRange = false;
			this.txtRelaxStablizeTime.DataType = STM.DLayer.DataType.Double;
			this.txtRelaxStablizeTime.DefaultValue = "0.0";
			this.txtRelaxStablizeTime.FractionalDigits = 2;
			this.txtRelaxStablizeTime.MaxValue = "0";
			this.txtRelaxStablizeTime.MinValue = "0";
			this.txtRelaxStablizeTime.Name = "txtRelaxStablizeTime";
			this.txtRelaxStablizeTime.Resolution = 0D;
			this.txtRelaxStablizeTime.Text = "0.0";
			this.txtRelaxStablizeTime.Tip = null;
			this.txtRelaxStablizeTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtRelaxTestTime
			// 
			resources.ApplyResources(this.txtRelaxTestTime, "txtRelaxTestTime");
			this.txtRelaxTestTime.BackColor = System.Drawing.Color.White;
			this.txtRelaxTestTime.CheckInRange = false;
			this.txtRelaxTestTime.DataType = STM.DLayer.DataType.Double;
			this.txtRelaxTestTime.DefaultValue = "0.0";
			this.txtRelaxTestTime.FractionalDigits = 2;
			this.txtRelaxTestTime.MaxValue = "0";
			this.txtRelaxTestTime.MinValue = "0";
			this.txtRelaxTestTime.Name = "txtRelaxTestTime";
			this.txtRelaxTestTime.Resolution = 0D;
			this.txtRelaxTestTime.Text = "0.0";
			this.txtRelaxTestTime.Tip = null;
			this.txtRelaxTestTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// tpSample
			// 
			resources.ApplyResources(this.tpSample, "tpSample");
			this.tpSample.BackColor = System.Drawing.Color.White;
			this.tpSample.Controls.Add(this.label3);
			this.tpSample.Controls.Add(this.cbTestingSampleType);
			this.tpSample.Controls.Add(this.label71);
			this.tpSample.Controls.Add(this.txtSampleGP);
			this.tpSample.Controls.Add(this.lbSampleGP);
			this.tpSample.Controls.Add(this.label61);
			this.tpSample.Controls.Add(this.lbSampleUnit3);
			this.tpSample.Controls.Add(this.cbSampleType);
			this.tpSample.Controls.Add(this.lbSampleDim3);
			this.tpSample.Controls.Add(this.lbSampleUnit2);
			this.tpSample.Controls.Add(this.txtSampleId);
			this.tpSample.Controls.Add(this.lbSampleUnit1);
			this.tpSample.Controls.Add(this.label20);
			this.tpSample.Controls.Add(this.lbSampleDim2);
			this.tpSample.Controls.Add(this.lbAreaInertiaUnit);
			this.tpSample.Controls.Add(this.lbSampleDim1);
			this.tpSample.Controls.Add(this.txtSampleGS);
			this.tpSample.Controls.Add(this.txtSampleDim3);
			this.tpSample.Controls.Add(this.lbAreaInertia);
			this.tpSample.Controls.Add(this.txtSampleDim2);
			this.tpSample.Controls.Add(this.txtSampleDim1);
			this.tpSample.Controls.Add(this.label5);
			this.tpSample.Controls.Add(this.txtSampleAreaInertia);
			this.tpSample.Controls.Add(this.lbSampleGS);
			this.tpSample.Controls.Add(this.label9);
			this.tpSample.Name = "tpSample";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// cbTestingSampleType
			// 
			resources.ApplyResources(this.cbTestingSampleType, "cbTestingSampleType");
			this.cbTestingSampleType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbTestingSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTestingSampleType.FormattingEnabled = true;
			this.cbTestingSampleType.Name = "cbTestingSampleType";
			this.cbTestingSampleType.SelectedIndexChanged += new System.EventHandler(this.cbTestingSampleType_SelectedIndexChanged);
			// 
			// label71
			// 
			resources.ApplyResources(this.label71, "label71");
			this.label71.Name = "label71";
			// 
			// txtSampleGP
			// 
			resources.ApplyResources(this.txtSampleGP, "txtSampleGP");
			this.txtSampleGP.BackColor = System.Drawing.Color.White;
			this.txtSampleGP.CheckInRange = false;
			this.txtSampleGP.DataType = STM.DLayer.DataType.Double;
			this.txtSampleGP.DefaultValue = "0";
			this.txtSampleGP.FractionalDigits = 0;
			this.txtSampleGP.MaxValue = "0";
			this.txtSampleGP.MinValue = "0";
			this.txtSampleGP.Name = "txtSampleGP";
			this.txtSampleGP.Resolution = 0D;
			this.txtSampleGP.Text = "20";
			this.txtSampleGP.Tip = null;
			this.txtSampleGP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// lbSampleGP
			// 
			resources.ApplyResources(this.lbSampleGP, "lbSampleGP");
			this.lbSampleGP.Name = "lbSampleGP";
			// 
			// label61
			// 
			resources.ApplyResources(this.label61, "label61");
			this.label61.Name = "label61";
			// 
			// lbSampleUnit3
			// 
			resources.ApplyResources(this.lbSampleUnit3, "lbSampleUnit3");
			this.lbSampleUnit3.Name = "lbSampleUnit3";
			// 
			// cbSampleType
			// 
			resources.ApplyResources(this.cbSampleType, "cbSampleType");
			this.cbSampleType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbSampleType.FormattingEnabled = true;
			this.cbSampleType.Name = "cbSampleType";
			this.cbSampleType.SelectedIndexChanged += new System.EventHandler(this.cbSampleType_SelectedIndexChanged);
			// 
			// lbSampleDim3
			// 
			resources.ApplyResources(this.lbSampleDim3, "lbSampleDim3");
			this.lbSampleDim3.Name = "lbSampleDim3";
			// 
			// lbSampleUnit2
			// 
			resources.ApplyResources(this.lbSampleUnit2, "lbSampleUnit2");
			this.lbSampleUnit2.Name = "lbSampleUnit2";
			// 
			// txtSampleId
			// 
			resources.ApplyResources(this.txtSampleId, "txtSampleId");
			this.txtSampleId.Name = "txtSampleId";
			this.txtSampleId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// lbSampleUnit1
			// 
			resources.ApplyResources(this.lbSampleUnit1, "lbSampleUnit1");
			this.lbSampleUnit1.Name = "lbSampleUnit1";
			// 
			// label20
			// 
			resources.ApplyResources(this.label20, "label20");
			this.label20.Name = "label20";
			// 
			// lbSampleDim2
			// 
			resources.ApplyResources(this.lbSampleDim2, "lbSampleDim2");
			this.lbSampleDim2.Name = "lbSampleDim2";
			// 
			// lbAreaInertiaUnit
			// 
			resources.ApplyResources(this.lbAreaInertiaUnit, "lbAreaInertiaUnit");
			this.lbAreaInertiaUnit.Name = "lbAreaInertiaUnit";
			// 
			// lbSampleDim1
			// 
			resources.ApplyResources(this.lbSampleDim1, "lbSampleDim1");
			this.lbSampleDim1.Name = "lbSampleDim1";
			// 
			// txtSampleGS
			// 
			resources.ApplyResources(this.txtSampleGS, "txtSampleGS");
			this.txtSampleGS.BackColor = System.Drawing.Color.White;
			this.txtSampleGS.CheckInRange = false;
			this.txtSampleGS.DataType = STM.DLayer.DataType.Double;
			this.txtSampleGS.DefaultValue = "0";
			this.txtSampleGS.FractionalDigits = 0;
			this.txtSampleGS.MaxValue = "0";
			this.txtSampleGS.MinValue = "0";
			this.txtSampleGS.Name = "txtSampleGS";
			this.txtSampleGS.Resolution = 0D;
			this.txtSampleGS.Text = "100";
			this.txtSampleGS.Tip = null;
			this.txtSampleGS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtSampleDim3
			// 
			resources.ApplyResources(this.txtSampleDim3, "txtSampleDim3");
			this.txtSampleDim3.BackColor = System.Drawing.Color.White;
			this.txtSampleDim3.Name = "txtSampleDim3";
			this.txtSampleDim3.TextChanged += new System.EventHandler(this.ComputeAreaInertia);
			this.txtSampleDim3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// lbAreaInertia
			// 
			resources.ApplyResources(this.lbAreaInertia, "lbAreaInertia");
			this.lbAreaInertia.Name = "lbAreaInertia";
			// 
			// txtSampleDim2
			// 
			resources.ApplyResources(this.txtSampleDim2, "txtSampleDim2");
			this.txtSampleDim2.BackColor = System.Drawing.Color.White;
			this.txtSampleDim2.Name = "txtSampleDim2";
			this.txtSampleDim2.TextChanged += new System.EventHandler(this.ComputeAreaInertia);
			this.txtSampleDim2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtSampleDim1
			// 
			resources.ApplyResources(this.txtSampleDim1, "txtSampleDim1");
			this.txtSampleDim1.BackColor = System.Drawing.Color.White;
			this.txtSampleDim1.Name = "txtSampleDim1";
			this.txtSampleDim1.TextChanged += new System.EventHandler(this.ComputeAreaInertia);
			this.txtSampleDim1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// txtSampleAreaInertia
			// 
			resources.ApplyResources(this.txtSampleAreaInertia, "txtSampleAreaInertia");
			this.txtSampleAreaInertia.BackColor = System.Drawing.Color.White;
			this.txtSampleAreaInertia.CheckInRange = false;
			this.txtSampleAreaInertia.DataType = STM.DLayer.DataType.Double;
			this.txtSampleAreaInertia.DefaultValue = "";
			this.txtSampleAreaInertia.FractionalDigits = 0;
			this.txtSampleAreaInertia.MaxValue = "0";
			this.txtSampleAreaInertia.MinValue = "0";
			this.txtSampleAreaInertia.Name = "txtSampleAreaInertia";
			this.txtSampleAreaInertia.ReadOnly = true;
			this.txtSampleAreaInertia.Resolution = 0D;
			this.txtSampleAreaInertia.Text = "0";
			this.txtSampleAreaInertia.Tip = null;
			this.txtSampleAreaInertia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// lbSampleGS
			// 
			resources.ApplyResources(this.lbSampleGS, "lbSampleGS");
			this.lbSampleGS.Name = "lbSampleGS";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// tpInformation
			// 
			resources.ApplyResources(this.tpInformation, "tpInformation");
			this.tpInformation.BackColor = System.Drawing.Color.White;
			this.tpInformation.Controls.Add(this.cboDateCultureFormat);
			this.tpInformation.Controls.Add(this.label72);
			this.tpInformation.Controls.Add(this.label2);
			this.tpInformation.Controls.Add(this.txtInfomationTestDiscription);
			this.tpInformation.Controls.Add(this.label1);
			this.tpInformation.Controls.Add(this.txtInfomationTestDate);
			this.tpInformation.Controls.Add(this.txtInfomationOperator);
			this.tpInformation.Controls.Add(this.txtInfomationCustomer);
			this.tpInformation.Controls.Add(this.label6);
			this.tpInformation.Controls.Add(this.label7);
			this.tpInformation.Name = "tpInformation";
			// 
			// cboDateCultureFormat
			// 
			resources.ApplyResources(this.cboDateCultureFormat, "cboDateCultureFormat");
			this.cboDateCultureFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDateCultureFormat.FormattingEnabled = true;
			this.cboDateCultureFormat.Items.AddRange(new object[] {
            resources.GetString("cboDateCultureFormat.Items"),
            resources.GetString("cboDateCultureFormat.Items1"),
            resources.GetString("cboDateCultureFormat.Items2")});
			this.cboDateCultureFormat.Name = "cboDateCultureFormat";
			this.cboDateCultureFormat.SelectedIndexChanged += new System.EventHandler(this.cboDateCultureFormat_SelectedIndexChanged);
			// 
			// label72
			// 
			resources.ApplyResources(this.label72, "label72");
			this.label72.Name = "label72";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// txtInfomationTestDiscription
			// 
			resources.ApplyResources(this.txtInfomationTestDiscription, "txtInfomationTestDiscription");
			this.txtInfomationTestDiscription.Name = "txtInfomationTestDiscription";
			this.txtInfomationTestDiscription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// txtInfomationTestDate
			// 
			resources.ApplyResources(this.txtInfomationTestDate, "txtInfomationTestDate");
			this.txtInfomationTestDate.Name = "txtInfomationTestDate";
			this.txtInfomationTestDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtInfomationOperator
			// 
			resources.ApplyResources(this.txtInfomationOperator, "txtInfomationOperator");
			this.txtInfomationOperator.Name = "txtInfomationOperator";
			this.txtInfomationOperator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// txtInfomationCustomer
			// 
			resources.ApplyResources(this.txtInfomationCustomer, "txtInfomationCustomer");
			this.txtInfomationCustomer.Name = "txtInfomationCustomer";
			this.txtInfomationCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// tpMeasures
			// 
			resources.ApplyResources(this.tpMeasures, "tpMeasures");
			this.tpMeasures.BackColor = System.Drawing.Color.White;
			this.tpMeasures.Controls.Add(this.label52);
			this.tpMeasures.Controls.Add(this.label99);
			this.tpMeasures.Controls.Add(this.label98);
			this.tpMeasures.Controls.Add(this.label24);
			this.tpMeasures.Controls.Add(this.cbM7Tool);
			this.tpMeasures.Controls.Add(this.cbM6Tool);
			this.tpMeasures.Controls.Add(this.cbM5Tool);
			this.tpMeasures.Controls.Add(this.cbM4Tool);
			this.tpMeasures.Controls.Add(this.cbM3Tool);
			this.tpMeasures.Controls.Add(this.cbM2Tool);
			this.tpMeasures.Controls.Add(this.cbM1Tool);
			this.tpMeasures.Controls.Add(this.llMeasuresOk);
			this.tpMeasures.Controls.Add(this.txtMeasure7Label);
			this.tpMeasures.Controls.Add(this.txtMeasure6Label);
			this.tpMeasures.Controls.Add(this.txtMeasure5Label);
			this.tpMeasures.Controls.Add(this.txtMeasure4Label);
			this.tpMeasures.Controls.Add(this.txtMeasure3Label);
			this.tpMeasures.Controls.Add(this.txtMeasure2Label);
			this.tpMeasures.Controls.Add(this.txtMeasure1Label);
			this.tpMeasures.Controls.Add(this.cbMeasureType7);
			this.tpMeasures.Controls.Add(this.cbMeasureType6);
			this.tpMeasures.Controls.Add(this.cbMeasureType5);
			this.tpMeasures.Controls.Add(this.cbMeasureType4);
			this.tpMeasures.Controls.Add(this.cbMeasureType3);
			this.tpMeasures.Controls.Add(this.cbMeasureType2);
			this.tpMeasures.Controls.Add(this.cbMeasureType1);
			this.tpMeasures.Controls.Add(this.label51);
			this.tpMeasures.Controls.Add(this.label50);
			this.tpMeasures.Controls.Add(this.label49);
			this.tpMeasures.Controls.Add(this.label48);
			this.tpMeasures.Controls.Add(this.label47);
			this.tpMeasures.Controls.Add(this.label46);
			this.tpMeasures.Controls.Add(this.label45);
			this.tpMeasures.Name = "tpMeasures";
			// 
			// label52
			// 
			resources.ApplyResources(this.label52, "label52");
			this.label52.Name = "label52";
			// 
			// label99
			// 
			resources.ApplyResources(this.label99, "label99");
			this.label99.Name = "label99";
			// 
			// label98
			// 
			resources.ApplyResources(this.label98, "label98");
			this.label98.Name = "label98";
			// 
			// label24
			// 
			resources.ApplyResources(this.label24, "label24");
			this.label24.Name = "label24";
			// 
			// cbM7Tool
			// 
			resources.ApplyResources(this.cbM7Tool, "cbM7Tool");
			this.cbM7Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM7Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM7Tool.FormattingEnabled = true;
			this.cbM7Tool.Items.AddRange(new object[] {
            resources.GetString("cbM7Tool.Items"),
            resources.GetString("cbM7Tool.Items1"),
            resources.GetString("cbM7Tool.Items2"),
            resources.GetString("cbM7Tool.Items3")});
			this.cbM7Tool.Name = "cbM7Tool";
			// 
			// cbM6Tool
			// 
			resources.ApplyResources(this.cbM6Tool, "cbM6Tool");
			this.cbM6Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM6Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM6Tool.FormattingEnabled = true;
			this.cbM6Tool.Items.AddRange(new object[] {
            resources.GetString("cbM6Tool.Items"),
            resources.GetString("cbM6Tool.Items1"),
            resources.GetString("cbM6Tool.Items2"),
            resources.GetString("cbM6Tool.Items3")});
			this.cbM6Tool.Name = "cbM6Tool";
			// 
			// cbM5Tool
			// 
			resources.ApplyResources(this.cbM5Tool, "cbM5Tool");
			this.cbM5Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM5Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM5Tool.FormattingEnabled = true;
			this.cbM5Tool.Items.AddRange(new object[] {
            resources.GetString("cbM5Tool.Items"),
            resources.GetString("cbM5Tool.Items1"),
            resources.GetString("cbM5Tool.Items2"),
            resources.GetString("cbM5Tool.Items3")});
			this.cbM5Tool.Name = "cbM5Tool";
			// 
			// cbM4Tool
			// 
			resources.ApplyResources(this.cbM4Tool, "cbM4Tool");
			this.cbM4Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM4Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM4Tool.FormattingEnabled = true;
			this.cbM4Tool.Items.AddRange(new object[] {
            resources.GetString("cbM4Tool.Items"),
            resources.GetString("cbM4Tool.Items1"),
            resources.GetString("cbM4Tool.Items2"),
            resources.GetString("cbM4Tool.Items3")});
			this.cbM4Tool.Name = "cbM4Tool";
			// 
			// cbM3Tool
			// 
			resources.ApplyResources(this.cbM3Tool, "cbM3Tool");
			this.cbM3Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM3Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM3Tool.FormattingEnabled = true;
			this.cbM3Tool.Items.AddRange(new object[] {
            resources.GetString("cbM3Tool.Items"),
            resources.GetString("cbM3Tool.Items1"),
            resources.GetString("cbM3Tool.Items2"),
            resources.GetString("cbM3Tool.Items3")});
			this.cbM3Tool.Name = "cbM3Tool";
			// 
			// cbM2Tool
			// 
			resources.ApplyResources(this.cbM2Tool, "cbM2Tool");
			this.cbM2Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM2Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM2Tool.FormattingEnabled = true;
			this.cbM2Tool.Items.AddRange(new object[] {
            resources.GetString("cbM2Tool.Items"),
            resources.GetString("cbM2Tool.Items1"),
            resources.GetString("cbM2Tool.Items2"),
            resources.GetString("cbM2Tool.Items3")});
			this.cbM2Tool.Name = "cbM2Tool";
			// 
			// cbM1Tool
			// 
			resources.ApplyResources(this.cbM1Tool, "cbM1Tool");
			this.cbM1Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbM1Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbM1Tool.FormattingEnabled = true;
			this.cbM1Tool.Items.AddRange(new object[] {
            resources.GetString("cbM1Tool.Items"),
            resources.GetString("cbM1Tool.Items1"),
            resources.GetString("cbM1Tool.Items2"),
            resources.GetString("cbM1Tool.Items3")});
			this.cbM1Tool.Name = "cbM1Tool";
			// 
			// llMeasuresOk
			// 
			resources.ApplyResources(this.llMeasuresOk, "llMeasuresOk");
			this.llMeasuresOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llMeasuresOk.Name = "llMeasuresOk";
			this.llMeasuresOk.TabStop = true;
			this.llMeasuresOk.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llMeasuresOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMeasuresOk_LinkClicked);
			// 
			// txtMeasure7Label
			// 
			resources.ApplyResources(this.txtMeasure7Label, "txtMeasure7Label");
			this.txtMeasure7Label.Name = "txtMeasure7Label";
			// 
			// txtMeasure6Label
			// 
			resources.ApplyResources(this.txtMeasure6Label, "txtMeasure6Label");
			this.txtMeasure6Label.Name = "txtMeasure6Label";
			// 
			// txtMeasure5Label
			// 
			resources.ApplyResources(this.txtMeasure5Label, "txtMeasure5Label");
			this.txtMeasure5Label.Name = "txtMeasure5Label";
			// 
			// txtMeasure4Label
			// 
			resources.ApplyResources(this.txtMeasure4Label, "txtMeasure4Label");
			this.txtMeasure4Label.Name = "txtMeasure4Label";
			// 
			// txtMeasure3Label
			// 
			resources.ApplyResources(this.txtMeasure3Label, "txtMeasure3Label");
			this.txtMeasure3Label.Name = "txtMeasure3Label";
			// 
			// txtMeasure2Label
			// 
			resources.ApplyResources(this.txtMeasure2Label, "txtMeasure2Label");
			this.txtMeasure2Label.Name = "txtMeasure2Label";
			// 
			// txtMeasure1Label
			// 
			resources.ApplyResources(this.txtMeasure1Label, "txtMeasure1Label");
			this.txtMeasure1Label.Name = "txtMeasure1Label";
			// 
			// cbMeasureType7
			// 
			resources.ApplyResources(this.cbMeasureType7, "cbMeasureType7");
			this.cbMeasureType7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType7.FormattingEnabled = true;
			this.cbMeasureType7.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType7.Items"),
            resources.GetString("cbMeasureType7.Items1"),
            resources.GetString("cbMeasureType7.Items2"),
            resources.GetString("cbMeasureType7.Items3")});
			this.cbMeasureType7.Name = "cbMeasureType7";
			this.cbMeasureType7.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType7_SelectedIndexChanged);
			// 
			// cbMeasureType6
			// 
			resources.ApplyResources(this.cbMeasureType6, "cbMeasureType6");
			this.cbMeasureType6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType6.FormattingEnabled = true;
			this.cbMeasureType6.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType6.Items"),
            resources.GetString("cbMeasureType6.Items1"),
            resources.GetString("cbMeasureType6.Items2"),
            resources.GetString("cbMeasureType6.Items3")});
			this.cbMeasureType6.Name = "cbMeasureType6";
			this.cbMeasureType6.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType6_SelectedIndexChanged);
			// 
			// cbMeasureType5
			// 
			resources.ApplyResources(this.cbMeasureType5, "cbMeasureType5");
			this.cbMeasureType5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType5.FormattingEnabled = true;
			this.cbMeasureType5.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType5.Items"),
            resources.GetString("cbMeasureType5.Items1"),
            resources.GetString("cbMeasureType5.Items2"),
            resources.GetString("cbMeasureType5.Items3")});
			this.cbMeasureType5.Name = "cbMeasureType5";
			this.cbMeasureType5.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType5_SelectedIndexChanged);
			// 
			// cbMeasureType4
			// 
			resources.ApplyResources(this.cbMeasureType4, "cbMeasureType4");
			this.cbMeasureType4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType4.FormattingEnabled = true;
			this.cbMeasureType4.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType4.Items"),
            resources.GetString("cbMeasureType4.Items1"),
            resources.GetString("cbMeasureType4.Items2"),
            resources.GetString("cbMeasureType4.Items3")});
			this.cbMeasureType4.Name = "cbMeasureType4";
			this.cbMeasureType4.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType4_SelectedIndexChanged);
			// 
			// cbMeasureType3
			// 
			resources.ApplyResources(this.cbMeasureType3, "cbMeasureType3");
			this.cbMeasureType3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType3.FormattingEnabled = true;
			this.cbMeasureType3.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType3.Items"),
            resources.GetString("cbMeasureType3.Items1"),
            resources.GetString("cbMeasureType3.Items2"),
            resources.GetString("cbMeasureType3.Items3")});
			this.cbMeasureType3.Name = "cbMeasureType3";
			this.cbMeasureType3.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType3_SelectedIndexChanged);
			// 
			// cbMeasureType2
			// 
			resources.ApplyResources(this.cbMeasureType2, "cbMeasureType2");
			this.cbMeasureType2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType2.FormattingEnabled = true;
			this.cbMeasureType2.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType2.Items"),
            resources.GetString("cbMeasureType2.Items1"),
            resources.GetString("cbMeasureType2.Items2"),
            resources.GetString("cbMeasureType2.Items3")});
			this.cbMeasureType2.Name = "cbMeasureType2";
			this.cbMeasureType2.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType2_SelectedIndexChanged);
			// 
			// cbMeasureType1
			// 
			resources.ApplyResources(this.cbMeasureType1, "cbMeasureType1");
			this.cbMeasureType1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbMeasureType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureType1.FormattingEnabled = true;
			this.cbMeasureType1.Items.AddRange(new object[] {
            resources.GetString("cbMeasureType1.Items"),
            resources.GetString("cbMeasureType1.Items1"),
            resources.GetString("cbMeasureType1.Items2"),
            resources.GetString("cbMeasureType1.Items3")});
			this.cbMeasureType1.Name = "cbMeasureType1";
			this.cbMeasureType1.SelectedIndexChanged += new System.EventHandler(this.cbMeasureType1_SelectedIndexChanged);
			// 
			// label51
			// 
			resources.ApplyResources(this.label51, "label51");
			this.label51.Name = "label51";
			// 
			// label50
			// 
			resources.ApplyResources(this.label50, "label50");
			this.label50.Name = "label50";
			// 
			// label49
			// 
			resources.ApplyResources(this.label49, "label49");
			this.label49.Name = "label49";
			// 
			// label48
			// 
			resources.ApplyResources(this.label48, "label48");
			this.label48.Name = "label48";
			// 
			// label47
			// 
			resources.ApplyResources(this.label47, "label47");
			this.label47.Name = "label47";
			// 
			// label46
			// 
			resources.ApplyResources(this.label46, "label46");
			this.label46.Name = "label46";
			// 
			// label45
			// 
			resources.ApplyResources(this.label45, "label45");
			this.label45.Name = "label45";
			// 
			// tpDiagram
			// 
			resources.ApplyResources(this.tpDiagram, "tpDiagram");
			this.tpDiagram.BackColor = System.Drawing.Color.White;
			this.tpDiagram.Controls.Add(this.lbDiagramYUnit);
			this.tpDiagram.Controls.Add(this.lbDiagramXUnit);
			this.tpDiagram.Controls.Add(this.txtDiagramYStop);
			this.tpDiagram.Controls.Add(this.txtDiagramXStop);
			this.tpDiagram.Controls.Add(this.label36);
			this.tpDiagram.Controls.Add(this.label42);
			this.tpDiagram.Controls.Add(this.cbReportFiles);
			this.tpDiagram.Controls.Add(this.label8);
			this.tpDiagram.Controls.Add(this.cbDefaultReport);
			this.tpDiagram.Controls.Add(this.label4);
			this.tpDiagram.Controls.Add(this.label55);
			this.tpDiagram.Controls.Add(this.label87);
			this.tpDiagram.Controls.Add(this.label88);
			this.tpDiagram.Controls.Add(this.cbDiagramY2Axis);
			this.tpDiagram.Controls.Add(this.cbDiagramYAxis);
			this.tpDiagram.Controls.Add(this.cbDiagramXAxis);
			this.tpDiagram.Controls.Add(this.label32);
			this.tpDiagram.Controls.Add(this.cbDiagramStartUp);
			this.tpDiagram.Name = "tpDiagram";
			// 
			// lbDiagramYUnit
			// 
			resources.ApplyResources(this.lbDiagramYUnit, "lbDiagramYUnit");
			this.lbDiagramYUnit.Name = "lbDiagramYUnit";
			// 
			// lbDiagramXUnit
			// 
			resources.ApplyResources(this.lbDiagramXUnit, "lbDiagramXUnit");
			this.lbDiagramXUnit.Name = "lbDiagramXUnit";
			// 
			// txtDiagramYStop
			// 
			resources.ApplyResources(this.txtDiagramYStop, "txtDiagramYStop");
			this.txtDiagramYStop.BackColor = System.Drawing.Color.White;
			this.txtDiagramYStop.CheckInRange = true;
			this.txtDiagramYStop.DataType = STM.DLayer.DataType.Double;
			this.txtDiagramYStop.DefaultValue = "0.5";
			this.txtDiagramYStop.FractionalDigits = 0;
			this.txtDiagramYStop.MaxValue = "2000";
			this.txtDiagramYStop.MinValue = "0.05";
			this.txtDiagramYStop.Name = "txtDiagramYStop";
			this.txtDiagramYStop.Resolution = 0D;
			this.txtDiagramYStop.Text = "0.5";
			this.txtDiagramYStop.Tip = null;
			// 
			// txtDiagramXStop
			// 
			resources.ApplyResources(this.txtDiagramXStop, "txtDiagramXStop");
			this.txtDiagramXStop.BackColor = System.Drawing.Color.White;
			this.txtDiagramXStop.CheckInRange = true;
			this.txtDiagramXStop.DataType = STM.DLayer.DataType.Double;
			this.txtDiagramXStop.DefaultValue = "0.5";
			this.txtDiagramXStop.FractionalDigits = 0;
			this.txtDiagramXStop.MaxValue = "2000";
			this.txtDiagramXStop.MinValue = "0.05";
			this.txtDiagramXStop.Name = "txtDiagramXStop";
			this.txtDiagramXStop.Resolution = 0D;
			this.txtDiagramXStop.Text = "0.5";
			this.txtDiagramXStop.Tip = null;
			// 
			// label36
			// 
			resources.ApplyResources(this.label36, "label36");
			this.label36.Name = "label36";
			// 
			// label42
			// 
			resources.ApplyResources(this.label42, "label42");
			this.label42.Name = "label42";
			// 
			// cbReportFiles
			// 
			resources.ApplyResources(this.cbReportFiles, "cbReportFiles");
			this.cbReportFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			this.cbReportFiles.FormattingEnabled = true;
			this.cbReportFiles.Name = "cbReportFiles";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// cbDefaultReport
			// 
			resources.ApplyResources(this.cbDefaultReport, "cbDefaultReport");
			this.cbDefaultReport.Name = "cbDefaultReport";
			this.cbDefaultReport.UseVisualStyleBackColor = true;
			this.cbDefaultReport.CheckedChanged += new System.EventHandler(this.cbDefaultReport_CheckedChanged);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label55
			// 
			resources.ApplyResources(this.label55, "label55");
			this.label55.Name = "label55";
			// 
			// label87
			// 
			resources.ApplyResources(this.label87, "label87");
			this.label87.Name = "label87";
			// 
			// label88
			// 
			resources.ApplyResources(this.label88, "label88");
			this.label88.Name = "label88";
			// 
			// cbDiagramY2Axis
			// 
			resources.ApplyResources(this.cbDiagramY2Axis, "cbDiagramY2Axis");
			this.cbDiagramY2Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbDiagramY2Axis.FormattingEnabled = true;
			this.cbDiagramY2Axis.Items.AddRange(new object[] {
            resources.GetString("cbDiagramY2Axis.Items"),
            resources.GetString("cbDiagramY2Axis.Items1")});
			this.cbDiagramY2Axis.Name = "cbDiagramY2Axis";
			this.cbDiagramY2Axis.SelectedIndexChanged += new System.EventHandler(this.cbDiagramY2Axis_SelectedIndexChanged);
			// 
			// cbDiagramYAxis
			// 
			resources.ApplyResources(this.cbDiagramYAxis, "cbDiagramYAxis");
			this.cbDiagramYAxis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbDiagramYAxis.FormattingEnabled = true;
			this.cbDiagramYAxis.Items.AddRange(new object[] {
            resources.GetString("cbDiagramYAxis.Items"),
            resources.GetString("cbDiagramYAxis.Items1")});
			this.cbDiagramYAxis.Name = "cbDiagramYAxis";
			this.cbDiagramYAxis.SelectedIndexChanged += new System.EventHandler(this.cbDiagramYAxis_SelectedIndexChanged);
			// 
			// cbDiagramXAxis
			// 
			resources.ApplyResources(this.cbDiagramXAxis, "cbDiagramXAxis");
			this.cbDiagramXAxis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbDiagramXAxis.FormattingEnabled = true;
			this.cbDiagramXAxis.Name = "cbDiagramXAxis";
			this.cbDiagramXAxis.SelectedIndexChanged += new System.EventHandler(this.cbDiagramXAxis_SelectedIndexChanged);
			// 
			// label32
			// 
			resources.ApplyResources(this.label32, "label32");
			this.label32.Name = "label32";
			// 
			// cbDiagramStartUp
			// 
			resources.ApplyResources(this.cbDiagramStartUp, "cbDiagramStartUp");
			this.cbDiagramStartUp.Name = "cbDiagramStartUp";
			this.cbDiagramStartUp.UseVisualStyleBackColor = true;
			// 
			// tpCtrl
			// 
			resources.ApplyResources(this.tpCtrl, "tpCtrl");
			this.tpCtrl.Controls.Add(this.panleSpeedSettingSelector);
			this.tpCtrl.Controls.Add(this.tcSpeedControl);
			this.tpCtrl.Name = "tpCtrl";
			this.tpCtrl.UseVisualStyleBackColor = true;
			// 
			// panleSpeedSettingSelector
			// 
			resources.ApplyResources(this.panleSpeedSettingSelector, "panleSpeedSettingSelector");
			this.panleSpeedSettingSelector.BackColor = System.Drawing.Color.White;
			this.panleSpeedSettingSelector.Controls.Add(this.llSpdctrlDefault);
			this.panleSpeedSettingSelector.Controls.Add(this.cbSpeed);
			this.panleSpeedSettingSelector.Controls.Add(this.label96);
			this.panleSpeedSettingSelector.Controls.Add(this.label97);
			this.panleSpeedSettingSelector.Name = "panleSpeedSettingSelector";
			// 
			// llSpdctrlDefault
			// 
			resources.ApplyResources(this.llSpdctrlDefault, "llSpdctrlDefault");
			this.llSpdctrlDefault.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llSpdctrlDefault.Name = "llSpdctrlDefault";
			this.llSpdctrlDefault.TabStop = true;
			this.llSpdctrlDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSpdctrlDefault_LinkClicked);
			// 
			// cbSpeed
			// 
			resources.ApplyResources(this.cbSpeed, "cbSpeed");
			this.cbSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSpeed.FormattingEnabled = true;
			this.cbSpeed.Items.AddRange(new object[] {
            resources.GetString("cbSpeed.Items"),
            resources.GetString("cbSpeed.Items1"),
            resources.GetString("cbSpeed.Items2")});
			this.cbSpeed.Name = "cbSpeed";
			this.cbSpeed.SelectedIndexChanged += new System.EventHandler(this.cbSpeed_SelectedIndexChanged);
			// 
			// label96
			// 
			resources.ApplyResources(this.label96, "label96");
			this.label96.Name = "label96";
			// 
			// label97
			// 
			resources.ApplyResources(this.label97, "label97");
			this.label97.Name = "label97";
			// 
			// tcSpeedControl
			// 
			resources.ApplyResources(this.tcSpeedControl, "tcSpeedControl");
			this.tcSpeedControl.Controls.Add(this.tpExtenCtrl);
			this.tcSpeedControl.Controls.Add(this.tpForceCtrl);
			this.tcSpeedControl.Controls.Add(this.tpStrainCtrl);
			this.tcSpeedControl.Multiline = true;
			this.tcSpeedControl.Name = "tcSpeedControl";
			this.tcSpeedControl.SelectedIndex = 0;
			// 
			// tpExtenCtrl
			// 
			resources.ApplyResources(this.tpExtenCtrl, "tpExtenCtrl");
			this.tpExtenCtrl.BackColor = System.Drawing.Color.White;
			this.tpExtenCtrl.Controls.Add(this.label101);
			this.tpExtenCtrl.Controls.Add(this.txtExtenTor);
			this.tpExtenCtrl.Controls.Add(this.txtKed);
			this.tpExtenCtrl.Controls.Add(this.txtKei);
			this.tpExtenCtrl.Controls.Add(this.txtKep);
			this.tpExtenCtrl.Controls.Add(this.label102);
			this.tpExtenCtrl.Controls.Add(this.label103);
			this.tpExtenCtrl.Controls.Add(this.label104);
			this.tpExtenCtrl.Controls.Add(this.label105);
			this.tpExtenCtrl.Name = "tpExtenCtrl";
			// 
			// label101
			// 
			resources.ApplyResources(this.label101, "label101");
			this.label101.Name = "label101";
			// 
			// txtExtenTor
			// 
			resources.ApplyResources(this.txtExtenTor, "txtExtenTor");
			this.txtExtenTor.BackColor = System.Drawing.Color.White;
			this.txtExtenTor.CheckInRange = false;
			this.txtExtenTor.DataType = STM.DLayer.DataType.Double;
			this.txtExtenTor.DefaultValue = "0";
			this.txtExtenTor.FractionalDigits = 0;
			this.txtExtenTor.MaxValue = "0";
			this.txtExtenTor.MinValue = "0";
			this.txtExtenTor.Name = "txtExtenTor";
			this.txtExtenTor.Resolution = 0D;
			this.txtExtenTor.Text = "0";
			this.txtExtenTor.Tip = null;
			// 
			// txtKed
			// 
			resources.ApplyResources(this.txtKed, "txtKed");
			this.txtKed.BackColor = System.Drawing.Color.White;
			this.txtKed.CheckInRange = false;
			this.txtKed.DataType = STM.DLayer.DataType.Double;
			this.txtKed.DefaultValue = "0";
			this.txtKed.FractionalDigits = 0;
			this.txtKed.MaxValue = "0";
			this.txtKed.MinValue = "0";
			this.txtKed.Name = "txtKed";
			this.txtKed.Resolution = 0D;
			this.txtKed.Text = "0";
			this.txtKed.Tip = null;
			// 
			// txtKei
			// 
			resources.ApplyResources(this.txtKei, "txtKei");
			this.txtKei.BackColor = System.Drawing.Color.White;
			this.txtKei.CheckInRange = false;
			this.txtKei.DataType = STM.DLayer.DataType.Double;
			this.txtKei.DefaultValue = "0";
			this.txtKei.FractionalDigits = 0;
			this.txtKei.MaxValue = "0";
			this.txtKei.MinValue = "0";
			this.txtKei.Name = "txtKei";
			this.txtKei.Resolution = 0D;
			this.txtKei.Text = "0";
			this.txtKei.Tip = null;
			// 
			// txtKep
			// 
			resources.ApplyResources(this.txtKep, "txtKep");
			this.txtKep.BackColor = System.Drawing.Color.White;
			this.txtKep.CheckInRange = false;
			this.txtKep.DataType = STM.DLayer.DataType.Double;
			this.txtKep.DefaultValue = "0";
			this.txtKep.FractionalDigits = 0;
			this.txtKep.MaxValue = "0";
			this.txtKep.MinValue = "0";
			this.txtKep.Name = "txtKep";
			this.txtKep.Resolution = 0D;
			this.txtKep.Text = "0";
			this.txtKep.Tip = null;
			// 
			// label102
			// 
			resources.ApplyResources(this.label102, "label102");
			this.label102.Name = "label102";
			// 
			// label103
			// 
			resources.ApplyResources(this.label103, "label103");
			this.label103.Name = "label103";
			// 
			// label104
			// 
			resources.ApplyResources(this.label104, "label104");
			this.label104.Name = "label104";
			// 
			// label105
			// 
			resources.ApplyResources(this.label105, "label105");
			this.label105.Name = "label105";
			// 
			// tpForceCtrl
			// 
			resources.ApplyResources(this.tpForceCtrl, "tpForceCtrl");
			this.tpForceCtrl.BackColor = System.Drawing.Color.White;
			this.tpForceCtrl.Controls.Add(this.label106);
			this.tpForceCtrl.Controls.Add(this.label107);
			this.tpForceCtrl.Controls.Add(this.label108);
			this.tpForceCtrl.Controls.Add(this.label109);
			this.tpForceCtrl.Controls.Add(this.label110);
			this.tpForceCtrl.Controls.Add(this.txtForceTor);
			this.tpForceCtrl.Controls.Add(this.txtKfd);
			this.tpForceCtrl.Controls.Add(this.txtKfi);
			this.tpForceCtrl.Controls.Add(this.txtKfp);
			this.tpForceCtrl.Name = "tpForceCtrl";
			// 
			// label106
			// 
			resources.ApplyResources(this.label106, "label106");
			this.label106.Name = "label106";
			// 
			// label107
			// 
			resources.ApplyResources(this.label107, "label107");
			this.label107.Name = "label107";
			// 
			// label108
			// 
			resources.ApplyResources(this.label108, "label108");
			this.label108.Name = "label108";
			// 
			// label109
			// 
			resources.ApplyResources(this.label109, "label109");
			this.label109.Name = "label109";
			// 
			// label110
			// 
			resources.ApplyResources(this.label110, "label110");
			this.label110.Name = "label110";
			// 
			// txtForceTor
			// 
			resources.ApplyResources(this.txtForceTor, "txtForceTor");
			this.txtForceTor.BackColor = System.Drawing.Color.White;
			this.txtForceTor.CheckInRange = false;
			this.txtForceTor.DataType = STM.DLayer.DataType.Double;
			this.txtForceTor.DefaultValue = "0";
			this.txtForceTor.FractionalDigits = 0;
			this.txtForceTor.MaxValue = "0";
			this.txtForceTor.MinValue = "0";
			this.txtForceTor.Name = "txtForceTor";
			this.txtForceTor.Resolution = 0D;
			this.txtForceTor.Text = "0";
			this.txtForceTor.Tip = null;
			// 
			// txtKfd
			// 
			resources.ApplyResources(this.txtKfd, "txtKfd");
			this.txtKfd.BackColor = System.Drawing.Color.White;
			this.txtKfd.CheckInRange = false;
			this.txtKfd.DataType = STM.DLayer.DataType.Double;
			this.txtKfd.DefaultValue = "0";
			this.txtKfd.FractionalDigits = 0;
			this.txtKfd.MaxValue = "0";
			this.txtKfd.MinValue = "0";
			this.txtKfd.Name = "txtKfd";
			this.txtKfd.Resolution = 0D;
			this.txtKfd.Text = "0";
			this.txtKfd.Tip = null;
			// 
			// txtKfi
			// 
			resources.ApplyResources(this.txtKfi, "txtKfi");
			this.txtKfi.BackColor = System.Drawing.Color.White;
			this.txtKfi.CheckInRange = false;
			this.txtKfi.DataType = STM.DLayer.DataType.Double;
			this.txtKfi.DefaultValue = "0";
			this.txtKfi.FractionalDigits = 0;
			this.txtKfi.MaxValue = "0";
			this.txtKfi.MinValue = "0";
			this.txtKfi.Name = "txtKfi";
			this.txtKfi.Resolution = 0D;
			this.txtKfi.Text = "0";
			this.txtKfi.Tip = null;
			// 
			// txtKfp
			// 
			resources.ApplyResources(this.txtKfp, "txtKfp");
			this.txtKfp.BackColor = System.Drawing.Color.White;
			this.txtKfp.CheckInRange = false;
			this.txtKfp.DataType = STM.DLayer.DataType.Double;
			this.txtKfp.DefaultValue = "0";
			this.txtKfp.FractionalDigits = 0;
			this.txtKfp.MaxValue = "0";
			this.txtKfp.MinValue = "0";
			this.txtKfp.Name = "txtKfp";
			this.txtKfp.Resolution = 0D;
			this.txtKfp.Text = "0";
			this.txtKfp.Tip = null;
			// 
			// tpStrainCtrl
			// 
			resources.ApplyResources(this.tpStrainCtrl, "tpStrainCtrl");
			this.tpStrainCtrl.BackColor = System.Drawing.Color.White;
			this.tpStrainCtrl.Controls.Add(this.label111);
			this.tpStrainCtrl.Controls.Add(this.label112);
			this.tpStrainCtrl.Controls.Add(this.label113);
			this.tpStrainCtrl.Controls.Add(this.label114);
			this.tpStrainCtrl.Controls.Add(this.label115);
			this.tpStrainCtrl.Controls.Add(this.txtStrainTor);
			this.tpStrainCtrl.Controls.Add(this.txtKsd);
			this.tpStrainCtrl.Controls.Add(this.txtKsi);
			this.tpStrainCtrl.Controls.Add(this.txtKsp);
			this.tpStrainCtrl.Name = "tpStrainCtrl";
			// 
			// label111
			// 
			resources.ApplyResources(this.label111, "label111");
			this.label111.Name = "label111";
			// 
			// label112
			// 
			resources.ApplyResources(this.label112, "label112");
			this.label112.Name = "label112";
			// 
			// label113
			// 
			resources.ApplyResources(this.label113, "label113");
			this.label113.Name = "label113";
			// 
			// label114
			// 
			resources.ApplyResources(this.label114, "label114");
			this.label114.Name = "label114";
			// 
			// label115
			// 
			resources.ApplyResources(this.label115, "label115");
			this.label115.Name = "label115";
			// 
			// txtStrainTor
			// 
			resources.ApplyResources(this.txtStrainTor, "txtStrainTor");
			this.txtStrainTor.BackColor = System.Drawing.Color.White;
			this.txtStrainTor.CheckInRange = false;
			this.txtStrainTor.DataType = STM.DLayer.DataType.Double;
			this.txtStrainTor.DefaultValue = "0";
			this.txtStrainTor.FractionalDigits = 0;
			this.txtStrainTor.MaxValue = "0";
			this.txtStrainTor.MinValue = "0";
			this.txtStrainTor.Name = "txtStrainTor";
			this.txtStrainTor.Resolution = 0D;
			this.txtStrainTor.Text = "0";
			this.txtStrainTor.Tip = null;
			// 
			// txtKsd
			// 
			resources.ApplyResources(this.txtKsd, "txtKsd");
			this.txtKsd.BackColor = System.Drawing.Color.White;
			this.txtKsd.CheckInRange = false;
			this.txtKsd.DataType = STM.DLayer.DataType.Double;
			this.txtKsd.DefaultValue = "0";
			this.txtKsd.FractionalDigits = 0;
			this.txtKsd.MaxValue = "0";
			this.txtKsd.MinValue = "0";
			this.txtKsd.Name = "txtKsd";
			this.txtKsd.Resolution = 0D;
			this.txtKsd.Text = "0";
			this.txtKsd.Tip = null;
			// 
			// txtKsi
			// 
			resources.ApplyResources(this.txtKsi, "txtKsi");
			this.txtKsi.BackColor = System.Drawing.Color.White;
			this.txtKsi.CheckInRange = false;
			this.txtKsi.DataType = STM.DLayer.DataType.Double;
			this.txtKsi.DefaultValue = "0";
			this.txtKsi.FractionalDigits = 0;
			this.txtKsi.MaxValue = "0";
			this.txtKsi.MinValue = "0";
			this.txtKsi.Name = "txtKsi";
			this.txtKsi.Resolution = 0D;
			this.txtKsi.Text = "0";
			this.txtKsi.Tip = null;
			// 
			// txtKsp
			// 
			resources.ApplyResources(this.txtKsp, "txtKsp");
			this.txtKsp.BackColor = System.Drawing.Color.White;
			this.txtKsp.CheckInRange = false;
			this.txtKsp.DataType = STM.DLayer.DataType.Double;
			this.txtKsp.DefaultValue = "0";
			this.txtKsp.FractionalDigits = 0;
			this.txtKsp.MaxValue = "0";
			this.txtKsp.MinValue = "0";
			this.txtKsp.Name = "txtKsp";
			this.txtKsp.Resolution = 0D;
			this.txtKsp.Text = "0";
			this.txtKsp.Tip = null;
			// 
			// tabPage1
			// 
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Controls.Add(this.lbConditionUbit);
			this.tabPage1.Controls.Add(this.txtConditionValue);
			this.tabPage1.Controls.Add(this.cbConditionType);
			this.tabPage1.Controls.Add(this.label54);
			this.tabPage1.Controls.Add(this.label56);
			this.tabPage1.Controls.Add(this.label58);
			this.tabPage1.Controls.Add(this.cbStopCondition);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lbConditionUbit
			// 
			resources.ApplyResources(this.lbConditionUbit, "lbConditionUbit");
			this.lbConditionUbit.Name = "lbConditionUbit";
			// 
			// txtConditionValue
			// 
			resources.ApplyResources(this.txtConditionValue, "txtConditionValue");
			this.txtConditionValue.BackColor = System.Drawing.Color.White;
			this.txtConditionValue.CheckInRange = false;
			this.txtConditionValue.DataType = STM.DLayer.DataType.Double;
			this.txtConditionValue.DefaultValue = "0";
			this.txtConditionValue.FractionalDigits = 0;
			this.txtConditionValue.MaxValue = "0";
			this.txtConditionValue.MinValue = "0";
			this.txtConditionValue.Name = "txtConditionValue";
			this.txtConditionValue.Resolution = 0D;
			this.txtConditionValue.Text = "0";
			this.txtConditionValue.Tip = null;
			// 
			// cbConditionType
			// 
			resources.ApplyResources(this.cbConditionType, "cbConditionType");
			this.cbConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbConditionType.FormattingEnabled = true;
			this.cbConditionType.Name = "cbConditionType";
			this.cbConditionType.SelectedIndexChanged += new System.EventHandler(this.cbConditionType_SelectedIndexChanged);
			// 
			// label54
			// 
			resources.ApplyResources(this.label54, "label54");
			this.label54.Name = "label54";
			// 
			// label56
			// 
			resources.ApplyResources(this.label56, "label56");
			this.label56.Name = "label56";
			// 
			// label58
			// 
			resources.ApplyResources(this.label58, "label58");
			this.label58.Name = "label58";
			// 
			// cbStopCondition
			// 
			resources.ApplyResources(this.cbStopCondition, "cbStopCondition");
			this.cbStopCondition.Name = "cbStopCondition";
			this.cbStopCondition.UseVisualStyleBackColor = true;
			this.cbStopCondition.CheckedChanged += new System.EventHandler(this.cbStopCondition_CheckedChanged);
			// 
			// FrmTestSetting
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelNavigation);
			this.Controls.Add(this.tcSetting);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmTestSetting";
			this.Load += new System.EventHandler(this.FrmTestSetting_Load);
			this.VisibleChanged += new System.EventHandler(this.FrmTestSetting_VisibleChanged);
			this.panelNavigation.ResumeLayout(false);
			this.panelNavigation.PerformLayout();
			this.tcSetting.ResumeLayout(false);
			this.tpMethod.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlSpeed.ResumeLayout(false);
			this.pnlSpeed.PerformLayout();
			this.tbTestMethods.ResumeLayout(false);
			this.tpTensile.ResumeLayout(false);
			this.collapsiblePanel1.ResumeLayout(false);
			this.collapsiblePanel1.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStep)).EndInit();
			this.tpCreep.ResumeLayout(false);
			this.tpCreep.PerformLayout();
			this.gbCreepTemperature.ResumeLayout(false);
			this.gbCreepTemperature.PerformLayout();
			this.gbCreepPreload.ResumeLayout(false);
			this.gbCreepPreload.PerformLayout();
			this.tpRelaxation.ResumeLayout(false);
			this.tpRelaxation.PerformLayout();
			this.tpSample.ResumeLayout(false);
			this.tpSample.PerformLayout();
			this.tpInformation.ResumeLayout(false);
			this.tpInformation.PerformLayout();
			this.tpMeasures.ResumeLayout(false);
			this.tpMeasures.PerformLayout();
			this.tpDiagram.ResumeLayout(false);
			this.tpDiagram.PerformLayout();
			this.tpCtrl.ResumeLayout(false);
			this.panleSpeedSettingSelector.ResumeLayout(false);
			this.panleSpeedSettingSelector.PerformLayout();
			this.tcSpeedControl.ResumeLayout(false);
			this.tpExtenCtrl.ResumeLayout(false);
			this.tpExtenCtrl.PerformLayout();
			this.tpForceCtrl.ResumeLayout(false);
			this.tpForceCtrl.PerformLayout();
			this.tpStrainCtrl.ResumeLayout(false);
			this.tpStrainCtrl.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel llSample;
        private System.Windows.Forms.LinkLabel llInformation;
        private System.Windows.Forms.LinkLabel llMethod;
        private System.Windows.Forms.LinkLabel llExport;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.TabControl tcSetting;
        private System.Windows.Forms.TabPage tpSample;
        private System.Windows.Forms.TabPage tpInformation;
        private System.Windows.Forms.Label lbSampleUnit3;
        private System.Windows.Forms.Label lbSampleDim3;
        private System.Windows.Forms.Label lbSampleUnit2;
        private System.Windows.Forms.Label lbSampleUnit1;
        private System.Windows.Forms.Label lbSampleDim2;
        private System.Windows.Forms.Label lbSampleDim1;
        private System.Windows.Forms.TextBox txtSampleDim3;
        private System.Windows.Forms.TextBox txtSampleDim2;
        private System.Windows.Forms.TextBox txtSampleDim1;
        private System.Windows.Forms.Label lbAreaInertiaUnit;
        private System.Windows.Forms.Label lbAreaInertia;
        private NRTextBox txtSampleAreaInertia;
        private System.Windows.Forms.ComboBox cbSampleType;
        private System.Windows.Forms.TextBox txtSampleId;
        private System.Windows.Forms.Label label20;
        private NRTextBox txtSampleGS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSampleGS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInfomationTestDiscription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfomationTestDate;
        private System.Windows.Forms.TextBox txtInfomationOperator;
        private System.Windows.Forms.TextBox txtInfomationCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tpMethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMethodTestMethod;
        private NRTextBox txtMethodSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTensileSpeedUnit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tbTestMethods;
        private System.Windows.Forms.TabPage tpTensile;
        private System.Windows.Forms.TabPage tpCompressive;
        private System.Windows.Forms.TabPage tpRelaxation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label txtRelaxationTestDuration;
        private NRTextBox txtRelaxTestTime;
        private System.Windows.Forms.TabPage tpCreep;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbTensilePreLoadSetZero;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbTensileEnableStoE;
        private NRTextBox txtTensilePreLoadWait;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbTensileEnableSecondSpeed;
        private NRTextBox txtTensilePreLoadSetPoint;
        private System.Windows.Forms.ComboBox cbTensilePreLoadType;
        private System.Windows.Forms.CheckBox cbTensilePreLoad;
        private System.Windows.Forms.LinkLabel llmeasures;
        private System.Windows.Forms.TabPage tpMeasures;
        private System.Windows.Forms.TextBox txtMeasure7Label;
        private System.Windows.Forms.TextBox txtMeasure6Label;
        private System.Windows.Forms.TextBox txtMeasure5Label;
        private System.Windows.Forms.TextBox txtMeasure4Label;
        private System.Windows.Forms.TextBox txtMeasure3Label;
        private System.Windows.Forms.TextBox txtMeasure2Label;
        private System.Windows.Forms.TextBox txtMeasure1Label;
        private System.Windows.Forms.ComboBox cbMeasureType7;
        private System.Windows.Forms.ComboBox cbMeasureType6;
        private System.Windows.Forms.ComboBox cbMeasureType5;
        private System.Windows.Forms.ComboBox cbMeasureType4;
        private System.Windows.Forms.ComboBox cbMeasureType3;
        private System.Windows.Forms.ComboBox cbMeasureType2;
        private System.Windows.Forms.ComboBox cbMeasureType1;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cbPreLoadUnits;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbTensileSecSpeedTypeUnit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private NRTextBox txtTensileSecSpeedSetPoint;
        private System.Windows.Forms.ComboBox cbTensileSecSpeedType;
        private System.Windows.Forms.ComboBox cbTensileStoEUnit;
        private System.Windows.Forms.Label lbTensileS2E;
        private System.Windows.Forms.Label label14;
        private NRTextBox txtTensileStoESetPoint;
        private System.Windows.Forms.ComboBox cbTensileStoEType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbSpeedUnits;
        private NRTextBox txtTensileSecondSpeed;
        private System.Windows.Forms.LinkLabel llMeasuresOk;
        private System.Windows.Forms.ComboBox cbTensileStoEChangeMode;
        private System.Windows.Forms.Label label11;
        private NRTextBox txtSampleGP;
        private System.Windows.Forms.Label lbSampleGP;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label63;
        private NRTextBox txtCurPosition;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox cbM7Tool;
        private System.Windows.Forms.ComboBox cbM6Tool;
        private System.Windows.Forms.ComboBox cbM5Tool;
        private System.Windows.Forms.ComboBox cbM4Tool;
        private System.Windows.Forms.ComboBox cbM3Tool;
        private System.Windows.Forms.ComboBox cbM2Tool;
        private System.Windows.Forms.ComboBox cbM1Tool;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.ComboBox cbRelaxSetPointType;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label80;
        private NRTextBox txtRelaxSetPoint;
        private System.Windows.Forms.ComboBox cbRelaxSetPointRateControl;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private NRTextBox txtRelaxStablizeTime;
        private System.Windows.Forms.TabPage tpDiagram;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.ComboBox cbDiagramYAxis;
        private System.Windows.Forms.ComboBox cbDiagramXAxis;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cbRelaxRateUnit;
        private System.Windows.Forms.Label label89;
        private NRTextBox txtRelaxRate;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label lbRelaxSetPointUnit;
        private System.Windows.Forms.CheckBox cbRelaxPlotAll;
        private System.Windows.Forms.CheckBox cbCreepPlotAll;
        private System.Windows.Forms.Label lbCreepSetPointUnit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbCreepRateUnit;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cbCreepSetPointType;
        private System.Windows.Forms.ComboBox cbCreepSetPointRateControl;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label34;
        private NRTextBox txtCreepRate;
        private NRTextBox txtCreepSetPoint;
        private NRTextBox txtCreepStablizeTime;
        private NRTextBox txtCreepTestTime;
        private System.Windows.Forms.LinkLabel llReporting;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbCyclicRateUnit;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label37;
        private NRTextBox txtCyclicRate;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private NRTextBox txtCyclicCount;
        private System.Windows.Forms.DataGridView dgvStep;
        private System.Windows.Forms.ComboBox cbCyclicLimitType;
        private System.Windows.Forms.ComboBox cbCyclicRateControl;
        private System.Windows.Forms.Label lbCyclicLimit2Unit;
        private System.Windows.Forms.Label lbCyclicLimit1Unit;
        private NRTextBox txtCyclicLimit2;
        private NRTextBox txtCyclicLimit1;
        private System.Windows.Forms.Label lbCyclicLimit2;
        private System.Windows.Forms.Label lbCyclicLimit1;
        private System.Windows.Forms.LinkLabel llOk;
        private System.Windows.Forms.Label lbRelaxCm;
        private System.Windows.Forms.Label lbStepSetPointUnit;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.ComboBox cbStepSetPointType;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.ComboBox cbStepRateUnit;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.ComboBox cbStepSetPointRateControl;
        private NRTextBox txtStepSetPoint;
        private NRTextBox txtStepRate;
        private System.Windows.Forms.LinkLabel llStepCancel;
        private System.Windows.Forms.LinkLabel llStepAdd;
        private System.Windows.Forms.LinkLabel llImport;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label83;
        private NRTextBox txtStepSetPointAction;
        private System.Windows.Forms.LinkLabel llStepUpdate;
        private System.Windows.Forms.TabPage tpCtrl;
        private System.Windows.Forms.Panel panleSpeedSettingSelector;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TabControl tcSpeedControl;
        private System.Windows.Forms.TabPage tpExtenCtrl;
        private System.Windows.Forms.Label label101;
        private NRTextBox txtExtenTor;
        private NRTextBox txtKed;
        private NRTextBox txtKei;
        private NRTextBox txtKep;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.TabPage tpForceCtrl;
        private System.Windows.Forms.Label label106;
        private NRTextBox txtForceTor;
        private NRTextBox txtKfd;
        private NRTextBox txtKfi;
        private NRTextBox txtKfp;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.TabPage tpStrainCtrl;
        private System.Windows.Forms.Label label111;
        private NRTextBox txtStrainTor;
        private NRTextBox txtKsd;
        private NRTextBox txtKsi;
        private NRTextBox txtKsp;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.LinkLabel llSpdctrlDefault;
        private System.Windows.Forms.LinkLabel llCtr;
        private NRTextBox txtCyclicDelay;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.LinkLabel llLoadDefault;
        private System.Windows.Forms.ComboBox cbSetPointAction;
        private System.Windows.Forms.Label label40;
        private NRTextBox txtBreakForceOver;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox cbStepSetForce;
        private System.Windows.Forms.Label lbStepForceUnit;
        private NRTextBox txtStepSetForce;
        private System.Windows.Forms.Label lbStepSetExtensionUbit;
        private NRTextBox txtStepSetExtension;
        private System.Windows.Forms.CheckBox cbStepSetExtension;
        private System.Windows.Forms.ComboBox cbTestingSampleType;
        private Point s2eTxtBoxLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llSaveDefulat;
        private Other.CollapsiblePanel.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.Label lbAdvanced;
        private System.Windows.Forms.Panel pnlSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.LinkLabel llcancel;
        private System.Windows.Forms.ComboBox cbReportFiles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbDefaultReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbDiagramYUnit;
        private System.Windows.Forms.Label lbDiagramXUnit;
        private NRTextBox txtDiagramYStop;
        private NRTextBox txtDiagramXStop;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox cbDiagramStartUp;
        private System.Windows.Forms.Label label44;
        private NRTextBox txtCreepSampleDecimation;
        private System.Windows.Forms.Label label43;
        private NRTextBox txtRelaxationSampleDecimation;
        private System.Windows.Forms.TabPage tabPage1;
        private NRTextBox txtConditionValue;
        private System.Windows.Forms.ComboBox cbConditionType;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.CheckBox cbStopCondition;
        private System.Windows.Forms.Label lbConditionUbit;
        private System.Windows.Forms.LinkLabel llStopCondition;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.ComboBox cbDiagramY2Axis;
        private NRTextBox txtBreakCounter;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private NRTextBox txtCreepTestTimeH;
        private NRTextBox txtCreepStablizeTimeH;
        private System.Windows.Forms.ComboBox cboDecimationUnit;
        private System.Windows.Forms.Panel gbCreepPreload;
        private System.Windows.Forms.CheckBox chkResetExtension;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lblCreep1;
        private System.Windows.Forms.Label lblCreepPreloadUnit;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.ComboBox cbCreepPreloadType;
        private NRTextBox txtCreepPreloadTimeH;
        private NRTextBox txtCreepPreloadTime;
        private NRTextBox txtCreepPreload;
        private System.Windows.Forms.Panel gbCreepTemperature;
        private System.Windows.Forms.Label label67;
        private NRTextBox txtCreepTemperatureOffsetValue;
        private System.Windows.Forms.Button btnCreepApplyTemperature;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label lblCreepTemperatuerUnit;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label65;
        private NRTextBox nrPreHeatTimeH;
        private NRTextBox nrPreHeatTime;
        private NRTextBox txtCreepTemperatureValue;
        private System.Windows.Forms.ComboBox cboDateCultureFormat;

        public event EventHandler<EventArgs> OnOperationDone;
    }
}