using System.Windows.Forms;
using STM.BLayer;
using System.Collections.Generic;
using STM.PLayer.Other.CollapsiblePanel;
using STM.PLayer.UI;

namespace STM
{
    partial class MainFrm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStandard = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuNewTest = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenTest = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCreateGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.menuRecentTests = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRecentGroups = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxCbRecentGroups = new System.Windows.Forms.ToolStripComboBox();
			this.menuOpenGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAddToGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.menuCloseTest = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuTest = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuNewTest = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.subMenuTestReportPoints = new System.Windows.Forms.ToolStripMenuItem();
			this.testTimeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menTools = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuToolsStandard = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuToolsStatusBar = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuToolsMeasures = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.menuToolsZoomIn = new System.Windows.Forms.ToolStripMenuItem();
			this.menuToolsZoomOut = new System.Windows.Forms.ToolStripMenuItem();
			this.menuToolsFit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuToolsPan = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuPlotPoints = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowReportPoints = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowReportLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowReportLines = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.subMenuUnits = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuSI = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuBS = new System.Windows.Forms.ToolStripMenuItem();
			this.subMenuMKS = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.subMenuMeasures = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMachineSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCalibration = new System.Windows.Forms.ToolStripMenuItem();
			this.menuInstrument = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.subMenuOptionSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.temperatureControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pointSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.standardToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.measuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tlsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlCtrl = new System.Windows.Forms.Panel();
			this.tbOnlineInfo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.bttnReturnToZero = new System.Windows.Forms.Button();
			this.bttnStrainToExten = new System.Windows.Forms.Button();
			this.bttnStopTest = new System.Windows.Forms.Button();
			this.bttnStartTest = new System.Windows.Forms.Button();
			this.bttnJogDown = new System.Windows.Forms.Button();
			this.bttnJogUp = new System.Windows.Forms.Button();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.plotReportPanel = new System.Windows.Forms.Panel();
			this.pnlContainer = new System.Windows.Forms.Panel();
			this.collapsiblePanel3 = new STM.PLayer.Other.CollapsiblePanel.CollapsiblePanel();
			this.dgvReportingResults = new System.Windows.Forms.DataGridView();
			this.lbSpacer = new System.Windows.Forms.Label();
			this.testsPanel = new STM.PLayer.Other.CollapsiblePanel.CollapsiblePanel();
			this.tcTestsTab = new System.Windows.Forms.TabControl();
			this.tpTestSpec = new System.Windows.Forms.TabPage();
			this.ucSpec = new STM.UcSpec();
			this.tpTestProgress = new System.Windows.Forms.TabPage();
			this.rtbTestProgress = new System.Windows.Forms.RichTextBox();
			this.plotPanel = new STM.PLayer.Other.CollapsiblePanel.CollapsiblePanel();
			this.nrMinTemperature = new STM.PLayer.NRTextBox();
			this.nrMaxTemperature = new STM.PLayer.NRTextBox();
			this.plot = new STM.PLayer.UI.Plot();
			this.lbCaption = new System.Windows.Forms.Label();
			this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvTestNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ctxMenuTestProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuCurrentTest = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSetAsDefualt = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDrawingParams = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExportAsExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.closeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStandard = new System.Windows.Forms.StatusStrip();
			this.tslEncoderSpeed = new System.Windows.Forms.ToolStripStatusLabel();
			this.ctxMenuDiagram = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctxMenuDiagramType = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuForceExtension = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuStressStrain = new System.Windows.Forms.ToolStripMenuItem();
			this.massStressStarinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lengthStressStarinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuForceTime = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuExtensionTime = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuStressTime = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuStrainTime = new System.Windows.Forms.ToolStripMenuItem();
			this.relaxLost = new System.Windows.Forms.ToolStripMenuItem();
			this.forceLost = new System.Windows.Forms.ToolStripMenuItem();
			this.stressLost = new System.Windows.Forms.ToolStripMenuItem();
			this.customeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuXType = new System.Windows.Forms.ToolStripComboBox();
			this.ctxMenuYType = new System.Windows.Forms.ToolStripComboBox();
			this.ctxMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.temperatureDiagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.temperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.specTempUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.specTempCNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.specTempDNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoneTempUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoneTempCNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoneTempDNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ambientTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuXUnit = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuYUnit = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuFixedScale = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuXOffset = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxNoXOffset = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxXOffset = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuReportPoints = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuShowReportPoints = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuShowReportLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuShowReportLines = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.tsbNewTest = new System.Windows.Forms.ToolStripButton();
			this.tsbOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbPrintPreview = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbZoom = new System.Windows.Forms.ToolStripButton();
			this.tsbUndo = new System.Windows.Forms.ToolStripButton();
			this.tsbFit = new System.Windows.Forms.ToolStripButton();
			this.tsbIndicator = new System.Windows.Forms.ToolStripButton();
			this.tsbPan = new System.Windows.Forms.ToolStripButton();
			this.closeTs = new System.Windows.Forms.ToolStrip();
			this.measureMonitors = new STM.PLayer.UI.MeasurementMonitors();
			this.timer = new STM.Timer.AccurateTimer(this.components);
			this.images1 = new STM.DLayer.Images(this.components);
			this.printting = new STM.PLayer.Print.Printting();
			this.menuStandard.SuspendLayout();
			this.pnlCtrl.SuspendLayout();
			this.plotReportPanel.SuspendLayout();
			this.pnlContainer.SuspendLayout();
			this.collapsiblePanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReportingResults)).BeginInit();
			this.testsPanel.SuspendLayout();
			this.tcTestsTab.SuspendLayout();
			this.tpTestSpec.SuspendLayout();
			this.tpTestProgress.SuspendLayout();
			this.plotPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.plot)).BeginInit();
			this.ctxMenuTestProperties.SuspendLayout();
			this.statusStandard.SuspendLayout();
			this.ctxMenuDiagram.SuspendLayout();
			this.closeTs.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStandard
			// 
			resources.ApplyResources(this.menuStandard, "menuStandard");
			this.menuStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.menuTest,
            this.menTools,
            this.menuSetting,
            this.helpToolStripMenuItem});
			this.menuStandard.Name = "menuStandard";
			// 
			// fileToolStripMenuItem1
			// 
			resources.ApplyResources(this.fileToolStripMenuItem1, "fileToolStripMenuItem1");
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewTest,
            this.menuOpenTest,
            this.toolStripSeparator5,
            this.menuSave,
            this.menuSaveAs,
            this.menuCreateGroup,
            this.toolStripSeparator15,
            this.menuRecentTests,
            this.menuRecentGroups,
            this.menuAddToGroup,
            this.toolStripSeparator6,
            this.menuPrint,
            this.menuPrintPreview,
            this.toolStripSeparator7,
            this.menuCloseTest,
            this.exitToolStripMenuItem1});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			// 
			// menuNewTest
			// 
			resources.ApplyResources(this.menuNewTest, "menuNewTest");
			this.menuNewTest.Name = "menuNewTest";
			this.menuNewTest.Click += new System.EventHandler(this.NewTest_Click);
			// 
			// menuOpenTest
			// 
			resources.ApplyResources(this.menuOpenTest, "menuOpenTest");
			this.menuOpenTest.Name = "menuOpenTest";
			this.menuOpenTest.Click += new System.EventHandler(this.menuOpenTest_Click);
			// 
			// toolStripSeparator5
			// 
			resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			// 
			// menuSave
			// 
			resources.ApplyResources(this.menuSave, "menuSave");
			this.menuSave.Name = "menuSave";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuSaveAs
			// 
			resources.ApplyResources(this.menuSaveAs, "menuSaveAs");
			this.menuSaveAs.Name = "menuSaveAs";
			this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
			// 
			// menuCreateGroup
			// 
			resources.ApplyResources(this.menuCreateGroup, "menuCreateGroup");
			this.menuCreateGroup.Name = "menuCreateGroup";
			this.menuCreateGroup.Click += new System.EventHandler(this.menuCreateGroup_Click);
			// 
			// toolStripSeparator15
			// 
			resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			// 
			// menuRecentTests
			// 
			resources.ApplyResources(this.menuRecentTests, "menuRecentTests");
			this.menuRecentTests.Name = "menuRecentTests";
			// 
			// menuRecentGroups
			// 
			resources.ApplyResources(this.menuRecentGroups, "menuRecentGroups");
			this.menuRecentGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxCbRecentGroups,
            this.menuOpenGroup,
            this.menuDeleteGroup});
			this.menuRecentGroups.Name = "menuRecentGroups";
			// 
			// ctxCbRecentGroups
			// 
			resources.ApplyResources(this.ctxCbRecentGroups, "ctxCbRecentGroups");
			this.ctxCbRecentGroups.Name = "ctxCbRecentGroups";
			// 
			// menuOpenGroup
			// 
			resources.ApplyResources(this.menuOpenGroup, "menuOpenGroup");
			this.menuOpenGroup.Name = "menuOpenGroup";
			this.menuOpenGroup.Click += new System.EventHandler(this.menuOpenGroup_Click);
			// 
			// menuDeleteGroup
			// 
			resources.ApplyResources(this.menuDeleteGroup, "menuDeleteGroup");
			this.menuDeleteGroup.ForeColor = System.Drawing.Color.Red;
			this.menuDeleteGroup.Name = "menuDeleteGroup";
			this.menuDeleteGroup.Click += new System.EventHandler(this.menuDeleteGroup_Click);
			// 
			// menuAddToGroup
			// 
			resources.ApplyResources(this.menuAddToGroup, "menuAddToGroup");
			this.menuAddToGroup.Name = "menuAddToGroup";
			// 
			// toolStripSeparator6
			// 
			resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			// 
			// menuPrint
			// 
			resources.ApplyResources(this.menuPrint, "menuPrint");
			this.menuPrint.Name = "menuPrint";
			this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
			// 
			// menuPrintPreview
			// 
			resources.ApplyResources(this.menuPrintPreview, "menuPrintPreview");
			this.menuPrintPreview.Name = "menuPrintPreview";
			this.menuPrintPreview.Click += new System.EventHandler(this.menuPrintPreview_Click);
			// 
			// toolStripSeparator7
			// 
			resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			// 
			// menuCloseTest
			// 
			resources.ApplyResources(this.menuCloseTest, "menuCloseTest");
			this.menuCloseTest.Name = "menuCloseTest";
			this.menuCloseTest.Click += new System.EventHandler(this.menuCloseTest_Click);
			// 
			// exitToolStripMenuItem1
			// 
			resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
			// 
			// menuTest
			// 
			resources.ApplyResources(this.menuTest, "menuTest");
			this.menuTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuNewTest,
            this.toolStripSeparator13,
            this.subMenuTestReportPoints,
            this.testTimeReportToolStripMenuItem});
			this.menuTest.Name = "menuTest";
			// 
			// subMenuNewTest
			// 
			resources.ApplyResources(this.subMenuNewTest, "subMenuNewTest");
			this.subMenuNewTest.Name = "subMenuNewTest";
			this.subMenuNewTest.Click += new System.EventHandler(this.NewTest_Click);
			// 
			// toolStripSeparator13
			// 
			resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			// 
			// subMenuTestReportPoints
			// 
			resources.ApplyResources(this.subMenuTestReportPoints, "subMenuTestReportPoints");
			this.subMenuTestReportPoints.Name = "subMenuTestReportPoints";
			this.subMenuTestReportPoints.Click += new System.EventHandler(this.subMenuTestReportPoints_Click);
			// 
			// testTimeReportToolStripMenuItem
			// 
			resources.ApplyResources(this.testTimeReportToolStripMenuItem, "testTimeReportToolStripMenuItem");
			this.testTimeReportToolStripMenuItem.Name = "testTimeReportToolStripMenuItem";
			this.testTimeReportToolStripMenuItem.Click += new System.EventHandler(this.testTimeReportToolStripMenuItem_Click);
			// 
			// menTools
			// 
			resources.ApplyResources(this.menTools, "menTools");
			this.menTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuToolsStandard,
            this.subMenuToolsStatusBar,
            this.subMenuToolsMeasures,
            this.toolStripSeparator10,
            this.menuToolsZoomIn,
            this.menuToolsZoomOut,
            this.menuToolsFit,
            this.menuToolsPan,
            this.subMenuPlotPoints,
            this.toolStripSeparator9,
            this.subMenuUnits});
			this.menTools.Name = "menTools";
			// 
			// subMenuToolsStandard
			// 
			resources.ApplyResources(this.subMenuToolsStandard, "subMenuToolsStandard");
			this.subMenuToolsStandard.Checked = true;
			this.subMenuToolsStandard.CheckState = System.Windows.Forms.CheckState.Checked;
			this.subMenuToolsStandard.Name = "subMenuToolsStandard";
			this.subMenuToolsStandard.Click += new System.EventHandler(this.subMenuToolsStandard_Click);
			// 
			// subMenuToolsStatusBar
			// 
			resources.ApplyResources(this.subMenuToolsStatusBar, "subMenuToolsStatusBar");
			this.subMenuToolsStatusBar.Checked = true;
			this.subMenuToolsStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.subMenuToolsStatusBar.Name = "subMenuToolsStatusBar";
			this.subMenuToolsStatusBar.Click += new System.EventHandler(this.subMenuToolsStatusBar_Click);
			// 
			// subMenuToolsMeasures
			// 
			resources.ApplyResources(this.subMenuToolsMeasures, "subMenuToolsMeasures");
			this.subMenuToolsMeasures.Checked = true;
			this.subMenuToolsMeasures.CheckState = System.Windows.Forms.CheckState.Checked;
			this.subMenuToolsMeasures.Name = "subMenuToolsMeasures";
			this.subMenuToolsMeasures.Click += new System.EventHandler(this.subMenuToolsMeasures_Click);
			// 
			// toolStripSeparator10
			// 
			resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			// 
			// menuToolsZoomIn
			// 
			resources.ApplyResources(this.menuToolsZoomIn, "menuToolsZoomIn");
			this.menuToolsZoomIn.Name = "menuToolsZoomIn";
			this.menuToolsZoomIn.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// menuToolsZoomOut
			// 
			resources.ApplyResources(this.menuToolsZoomOut, "menuToolsZoomOut");
			this.menuToolsZoomOut.Name = "menuToolsZoomOut";
			this.menuToolsZoomOut.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// menuToolsFit
			// 
			resources.ApplyResources(this.menuToolsFit, "menuToolsFit");
			this.menuToolsFit.Name = "menuToolsFit";
			this.menuToolsFit.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// menuToolsPan
			// 
			resources.ApplyResources(this.menuToolsPan, "menuToolsPan");
			this.menuToolsPan.Name = "menuToolsPan";
			this.menuToolsPan.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// subMenuPlotPoints
			// 
			resources.ApplyResources(this.subMenuPlotPoints, "subMenuPlotPoints");
			this.subMenuPlotPoints.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowReportPoints,
            this.menuShowReportLabels,
            this.menuShowReportLines});
			this.subMenuPlotPoints.Name = "subMenuPlotPoints";
			// 
			// menuShowReportPoints
			// 
			resources.ApplyResources(this.menuShowReportPoints, "menuShowReportPoints");
			this.menuShowReportPoints.Name = "menuShowReportPoints";
			this.menuShowReportPoints.Click += new System.EventHandler(this.onMenuShowReportPoints_Click);
			// 
			// menuShowReportLabels
			// 
			resources.ApplyResources(this.menuShowReportLabels, "menuShowReportLabels");
			this.menuShowReportLabels.Name = "menuShowReportLabels";
			this.menuShowReportLabels.Click += new System.EventHandler(this.onMenuShowReportLabels_Click);
			// 
			// menuShowReportLines
			// 
			resources.ApplyResources(this.menuShowReportLines, "menuShowReportLines");
			this.menuShowReportLines.Name = "menuShowReportLines";
			this.menuShowReportLines.Click += new System.EventHandler(this.onMenuShowReportLines_Click);
			// 
			// toolStripSeparator9
			// 
			resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			// 
			// subMenuUnits
			// 
			resources.ApplyResources(this.subMenuUnits, "subMenuUnits");
			this.subMenuUnits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuSI,
            this.subMenuBS,
            this.subMenuMKS,
            this.toolStripSeparator12,
            this.subMenuMeasures});
			this.subMenuUnits.Name = "subMenuUnits";
			// 
			// subMenuSI
			// 
			resources.ApplyResources(this.subMenuSI, "subMenuSI");
			this.subMenuSI.Name = "subMenuSI";
			this.subMenuSI.Click += new System.EventHandler(this.unitMenu_Click);
			// 
			// subMenuBS
			// 
			resources.ApplyResources(this.subMenuBS, "subMenuBS");
			this.subMenuBS.Name = "subMenuBS";
			this.subMenuBS.Click += new System.EventHandler(this.unitMenu_Click);
			// 
			// subMenuMKS
			// 
			resources.ApplyResources(this.subMenuMKS, "subMenuMKS");
			this.subMenuMKS.Name = "subMenuMKS";
			this.subMenuMKS.Click += new System.EventHandler(this.unitMenu_Click);
			// 
			// toolStripSeparator12
			// 
			resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			// 
			// subMenuMeasures
			// 
			resources.ApplyResources(this.subMenuMeasures, "subMenuMeasures");
			this.subMenuMeasures.Name = "subMenuMeasures";
			this.subMenuMeasures.Click += new System.EventHandler(this.subMenuMeasures_Click);
			// 
			// menuSetting
			// 
			resources.ApplyResources(this.menuSetting, "menuSetting");
			this.menuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMachineSetting,
            this.menuCalibration,
            this.menuInstrument,
            this.toolStripSeparator8,
            this.subMenuOptionSetting,
            this.toolStripMenuItem5,
            this.temperatureControlToolStripMenuItem});
			this.menuSetting.Name = "menuSetting";
			// 
			// menuMachineSetting
			// 
			resources.ApplyResources(this.menuMachineSetting, "menuMachineSetting");
			this.menuMachineSetting.Name = "menuMachineSetting";
			this.menuMachineSetting.Click += new System.EventHandler(this.subMenuMachineSetting_Click);
			// 
			// menuCalibration
			// 
			resources.ApplyResources(this.menuCalibration, "menuCalibration");
			this.menuCalibration.Name = "menuCalibration";
			this.menuCalibration.Click += new System.EventHandler(this.subMenuCalibration_Click);
			// 
			// menuInstrument
			// 
			resources.ApplyResources(this.menuInstrument, "menuInstrument");
			this.menuInstrument.Name = "menuInstrument";
			this.menuInstrument.Click += new System.EventHandler(this.subMenuInstrument_Click);
			// 
			// toolStripSeparator8
			// 
			resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			// 
			// subMenuOptionSetting
			// 
			resources.ApplyResources(this.subMenuOptionSetting, "subMenuOptionSetting");
			this.subMenuOptionSetting.Name = "subMenuOptionSetting";
			this.subMenuOptionSetting.Click += new System.EventHandler(this.subMenuOptionSetting_Click);
			// 
			// toolStripMenuItem5
			// 
			resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			// 
			// temperatureControlToolStripMenuItem
			// 
			resources.ApplyResources(this.temperatureControlToolStripMenuItem, "temperatureControlToolStripMenuItem");
			this.temperatureControlToolStripMenuItem.Name = "temperatureControlToolStripMenuItem";
			this.temperatureControlToolStripMenuItem.Click += new System.EventHandler(this.temperatureControlToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			// 
			// aboutToolStripMenuItem
			// 
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// fileToolStripMenuItem
			// 
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			// 
			// newToolStripMenuItem
			// 
			resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			// 
			// openToolStripMenuItem
			// 
			resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// saveToolStripMenuItem
			// 
			resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			// 
			// saveAsToolStripMenuItem
			// 
			resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			// 
			// toolStripMenuItem1
			// 
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			// 
			// toolStripSeparator4
			// 
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			// 
			// toolStripMenuItem3
			// 
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			// 
			// toolStripMenuItem2
			// 
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			// 
			// toolStripSeparator2
			// 
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			// 
			// recentFilesToolStripMenuItem
			// 
			resources.ApplyResources(this.recentFilesToolStripMenuItem, "recentFilesToolStripMenuItem");
			this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
			// 
			// toolStripSeparator3
			// 
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			// 
			// exitToolStripMenuItem
			// 
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			// 
			// viewToolsToolStripMenuItem
			// 
			resources.ApplyResources(this.viewToolsToolStripMenuItem, "viewToolsToolStripMenuItem");
			this.viewToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.fitToolStripMenuItem,
            this.panToolStripMenuItem,
            this.pointSelectionToolStripMenuItem});
			this.viewToolsToolStripMenuItem.Name = "viewToolsToolStripMenuItem";
			// 
			// zoomToolStripMenuItem
			// 
			resources.ApplyResources(this.zoomToolStripMenuItem, "zoomToolStripMenuItem");
			this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
			// 
			// zoomOutToolStripMenuItem
			// 
			resources.ApplyResources(this.zoomOutToolStripMenuItem, "zoomOutToolStripMenuItem");
			this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
			// 
			// fitToolStripMenuItem
			// 
			resources.ApplyResources(this.fitToolStripMenuItem, "fitToolStripMenuItem");
			this.fitToolStripMenuItem.Name = "fitToolStripMenuItem";
			// 
			// panToolStripMenuItem
			// 
			resources.ApplyResources(this.panToolStripMenuItem, "panToolStripMenuItem");
			this.panToolStripMenuItem.Name = "panToolStripMenuItem";
			// 
			// pointSelectionToolStripMenuItem
			// 
			resources.ApplyResources(this.pointSelectionToolStripMenuItem, "pointSelectionToolStripMenuItem");
			this.pointSelectionToolStripMenuItem.Name = "pointSelectionToolStripMenuItem";
			// 
			// toolsToolStripMenuItem
			// 
			resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolbarToolStripMenuItem,
            this.measuresToolStripMenuItem,
            this.statusbarToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			// 
			// standardToolbarToolStripMenuItem
			// 
			resources.ApplyResources(this.standardToolbarToolStripMenuItem, "standardToolbarToolStripMenuItem");
			this.standardToolbarToolStripMenuItem.Name = "standardToolbarToolStripMenuItem";
			// 
			// measuresToolStripMenuItem
			// 
			resources.ApplyResources(this.measuresToolStripMenuItem, "measuresToolStripMenuItem");
			this.measuresToolStripMenuItem.Name = "measuresToolStripMenuItem";
			// 
			// statusbarToolStripMenuItem
			// 
			resources.ApplyResources(this.statusbarToolStripMenuItem, "statusbarToolStripMenuItem");
			this.statusbarToolStripMenuItem.Name = "statusbarToolStripMenuItem";
			// 
			// fullScreenToolStripMenuItem
			// 
			resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
			this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
			// 
			// tlsStatusLabel
			// 
			resources.ApplyResources(this.tlsStatusLabel, "tlsStatusLabel");
			this.tlsStatusLabel.Name = "tlsStatusLabel";
			// 
			// pnlCtrl
			// 
			resources.ApplyResources(this.pnlCtrl, "pnlCtrl");
			this.pnlCtrl.BackColor = System.Drawing.SystemColors.Control;
			this.pnlCtrl.Controls.Add(this.tbOnlineInfo);
			this.pnlCtrl.Controls.Add(this.label3);
			this.pnlCtrl.Controls.Add(this.label2);
			this.pnlCtrl.Controls.Add(this.label1);
			this.pnlCtrl.Controls.Add(this.bttnReturnToZero);
			this.pnlCtrl.Controls.Add(this.bttnStrainToExten);
			this.pnlCtrl.Controls.Add(this.bttnStopTest);
			this.pnlCtrl.Controls.Add(this.bttnStartTest);
			this.pnlCtrl.Controls.Add(this.bttnJogDown);
			this.pnlCtrl.Controls.Add(this.bttnJogUp);
			this.pnlCtrl.Name = "pnlCtrl";
			// 
			// tbOnlineInfo
			// 
			resources.ApplyResources(this.tbOnlineInfo, "tbOnlineInfo");
			this.tbOnlineInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbOnlineInfo.Name = "tbOnlineInfo";
			this.tbOnlineInfo.ReadOnly = true;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.AutoEllipsis = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Name = "label3";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.AutoEllipsis = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.AutoEllipsis = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Name = "label1";
			// 
			// bttnReturnToZero
			// 
			resources.ApplyResources(this.bttnReturnToZero, "bttnReturnToZero");
			this.bttnReturnToZero.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bttnReturnToZero.Name = "bttnReturnToZero";
			this.bttnReturnToZero.Tag = "Retuen Extension (Force by Ctrl Down) To Zero";
			this.bttnReturnToZero.UseVisualStyleBackColor = true;
			this.bttnReturnToZero.Click += new System.EventHandler(this.bttnReturnToZero_Click);
			this.bttnReturnToZero.MouseHover += new System.EventHandler(this.bttnStartTest_MouseHover);
			// 
			// bttnStrainToExten
			// 
			resources.ApplyResources(this.bttnStrainToExten, "bttnStrainToExten");
			this.bttnStrainToExten.BackgroundImage = global::STM.Properties.Resources.SE;
			this.bttnStrainToExten.Name = "bttnStrainToExten";
			this.bttnStrainToExten.Tag = "Starin To Extension Switching";
			this.bttnStrainToExten.UseVisualStyleBackColor = true;
			this.bttnStrainToExten.Click += new System.EventHandler(this.bttnStrainToExten_Click);
			this.bttnStrainToExten.MouseHover += new System.EventHandler(this.bttnStartTest_MouseHover);
			// 
			// bttnStopTest
			// 
			resources.ApplyResources(this.bttnStopTest, "bttnStopTest");
			this.bttnStopTest.BackgroundImage = global::STM.Properties.Resources.Stop;
			this.bttnStopTest.Name = "bttnStopTest";
			this.bttnStopTest.Tag = "Stop Test";
			this.bttnStopTest.UseVisualStyleBackColor = true;
			this.bttnStopTest.Click += new System.EventHandler(this.bttnStopTest_Click);
			this.bttnStopTest.MouseHover += new System.EventHandler(this.bttnStartTest_MouseHover);
			// 
			// bttnStartTest
			// 
			resources.ApplyResources(this.bttnStartTest, "bttnStartTest");
			this.bttnStartTest.BackgroundImage = global::STM.Properties.Resources.Start;
			this.bttnStartTest.Name = "bttnStartTest";
			this.bttnStartTest.Tag = "Start Test";
			this.bttnStartTest.UseVisualStyleBackColor = true;
			this.bttnStartTest.Click += new System.EventHandler(this.bttnStartTest_Click);
			this.bttnStartTest.MouseHover += new System.EventHandler(this.bttnStartTest_MouseHover);
			// 
			// bttnJogDown
			// 
			resources.ApplyResources(this.bttnJogDown, "bttnJogDown");
			this.bttnJogDown.BackgroundImage = global::STM.Properties.Resources.fb;
			this.bttnJogDown.Name = "bttnJogDown";
			this.bttnJogDown.Tag = "Cross Head Down";
			this.bttnJogDown.UseVisualStyleBackColor = true;
			this.bttnJogDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttnJogDown_MouseDown);
			this.bttnJogDown.MouseHover += new System.EventHandler(this.bttnStartTest_MouseHover);
			this.bttnJogDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogSpeedMouseUp);
			// 
			// bttnJogUp
			// 
			resources.ApplyResources(this.bttnJogUp, "bttnJogUp");
			this.bttnJogUp.BackgroundImage = global::STM.Properties.Resources.fup;
			this.bttnJogUp.Name = "bttnJogUp";
			this.bttnJogUp.Tag = "Cross Head Up";
			this.bttnJogUp.UseVisualStyleBackColor = true;
			this.bttnJogUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttnJogUp_MouseDown);
			this.bttnJogUp.MouseHover += new System.EventHandler(this.bttnStartTest_MouseHover);
			this.bttnJogUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogSpeedMouseUp);
			// 
			// toolStripSeparator
			// 
			resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
			this.toolStripSeparator.Name = "toolStripSeparator";
			// 
			// plotReportPanel
			// 
			resources.ApplyResources(this.plotReportPanel, "plotReportPanel");
			this.plotReportPanel.BackColor = System.Drawing.Color.White;
			this.plotReportPanel.Controls.Add(this.pnlContainer);
			this.plotReportPanel.Name = "plotReportPanel";
			// 
			// pnlContainer
			// 
			resources.ApplyResources(this.pnlContainer, "pnlContainer");
			this.pnlContainer.Controls.Add(this.collapsiblePanel3);
			this.pnlContainer.Controls.Add(this.testsPanel);
			this.pnlContainer.Controls.Add(this.plotPanel);
			this.pnlContainer.Name = "pnlContainer";
			// 
			// collapsiblePanel3
			// 
			resources.ApplyResources(this.collapsiblePanel3, "collapsiblePanel3");
			this.collapsiblePanel3.BackColor = System.Drawing.Color.Transparent;
			this.collapsiblePanel3.Controls.Add(this.dgvReportingResults);
			this.collapsiblePanel3.Controls.Add(this.lbSpacer);
			this.collapsiblePanel3.HeaderBackColor = System.Drawing.SystemColors.ControlDark;
			this.collapsiblePanel3.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.collapsiblePanel3.HeaderImage = null;
			this.collapsiblePanel3.HeaderText = "Отчеты";
			this.collapsiblePanel3.HeaderTextColor = System.Drawing.Color.Black;
			this.collapsiblePanel3.Name = "collapsiblePanel3";
			// 
			// dgvReportingResults
			// 
			resources.ApplyResources(this.dgvReportingResults, "dgvReportingResults");
			this.dgvReportingResults.AllowUserToAddRows = false;
			this.dgvReportingResults.AllowUserToDeleteRows = false;
			this.dgvReportingResults.AllowUserToOrderColumns = true;
			this.dgvReportingResults.AllowUserToResizeColumns = false;
			this.dgvReportingResults.AllowUserToResizeRows = false;
			this.dgvReportingResults.BackgroundColor = System.Drawing.Color.White;
			this.dgvReportingResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvReportingResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvReportingResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReportingResults.MultiSelect = false;
			this.dgvReportingResults.Name = "dgvReportingResults";
			this.dgvReportingResults.ReadOnly = true;
			this.dgvReportingResults.RowHeadersVisible = false;
			this.dgvReportingResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvReportingResults.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReportingResults_CellMouseUp);
			this.dgvReportingResults.SelectionChanged += new System.EventHandler(this.dgvReportingResults_SelectionChanged);
			this.dgvReportingResults.Sorted += new System.EventHandler(this.dgvReportingResults_Sorted);
			this.dgvReportingResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvReportingResults_MouseClick);
			// 
			// lbSpacer
			// 
			resources.ApplyResources(this.lbSpacer, "lbSpacer");
			this.lbSpacer.Name = "lbSpacer";
			// 
			// testsPanel
			// 
			resources.ApplyResources(this.testsPanel, "testsPanel");
			this.testsPanel.BackColor = System.Drawing.Color.Transparent;
			this.testsPanel.Controls.Add(this.tcTestsTab);
			this.testsPanel.HeaderBackColor = System.Drawing.SystemColors.ControlDark;
			this.testsPanel.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.testsPanel.HeaderImage = null;
			this.testsPanel.HeaderText = "Спецификации испытаний";
			this.testsPanel.HeaderTextColor = System.Drawing.Color.Black;
			this.testsPanel.Name = "testsPanel";
			// 
			// tcTestsTab
			// 
			resources.ApplyResources(this.tcTestsTab, "tcTestsTab");
			this.tcTestsTab.Controls.Add(this.tpTestSpec);
			this.tcTestsTab.Controls.Add(this.tpTestProgress);
			this.tcTestsTab.Name = "tcTestsTab";
			this.tcTestsTab.SelectedIndex = 0;
			// 
			// tpTestSpec
			// 
			resources.ApplyResources(this.tpTestSpec, "tpTestSpec");
			this.tpTestSpec.Controls.Add(this.ucSpec);
			this.tpTestSpec.Name = "tpTestSpec";
			this.tpTestSpec.UseVisualStyleBackColor = true;
			// 
			// ucSpec
			// 
			resources.ApplyResources(this.ucSpec, "ucSpec");
			this.ucSpec.Name = "ucSpec";
			// 
			// tpTestProgress
			// 
			resources.ApplyResources(this.tpTestProgress, "tpTestProgress");
			this.tpTestProgress.Controls.Add(this.rtbTestProgress);
			this.tpTestProgress.Name = "tpTestProgress";
			this.tpTestProgress.UseVisualStyleBackColor = true;
			// 
			// rtbTestProgress
			// 
			resources.ApplyResources(this.rtbTestProgress, "rtbTestProgress");
			this.rtbTestProgress.BackColor = System.Drawing.Color.Silver;
			this.rtbTestProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbTestProgress.Name = "rtbTestProgress";
			// 
			// plotPanel
			// 
			resources.ApplyResources(this.plotPanel, "plotPanel");
			this.plotPanel.BackColor = System.Drawing.Color.Transparent;
			this.plotPanel.Controls.Add(this.nrMinTemperature);
			this.plotPanel.Controls.Add(this.nrMaxTemperature);
			this.plotPanel.Controls.Add(this.plot);
			this.plotPanel.Controls.Add(this.lbCaption);
			this.plotPanel.HeaderBackColor = System.Drawing.SystemColors.ControlDark;
			this.plotPanel.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.plotPanel.HeaderImage = null;
			this.plotPanel.HeaderText = "график";
			this.plotPanel.HeaderTextColor = System.Drawing.Color.Black;
			this.plotPanel.Name = "plotPanel";
			// 
			// nrMinTemperature
			// 
			resources.ApplyResources(this.nrMinTemperature, "nrMinTemperature");
			this.nrMinTemperature.BackColor = System.Drawing.Color.White;
			this.nrMinTemperature.CheckInRange = false;
			this.nrMinTemperature.DataType = STM.DLayer.DataType.Int;
			this.nrMinTemperature.DefaultValue = "0";
			this.nrMinTemperature.FractionalDigits = 0;
			this.nrMinTemperature.MaxValue = "2000";
			this.nrMinTemperature.MinValue = "0";
			this.nrMinTemperature.Name = "nrMinTemperature";
			this.nrMinTemperature.Resolution = 0D;
			this.nrMinTemperature.Text = "0";
			this.nrMinTemperature.Tip = null;
			this.nrMinTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nrTemperatureRange_KeyPress);
			// 
			// nrMaxTemperature
			// 
			resources.ApplyResources(this.nrMaxTemperature, "nrMaxTemperature");
			this.nrMaxTemperature.BackColor = System.Drawing.Color.White;
			this.nrMaxTemperature.CheckInRange = false;
			this.nrMaxTemperature.DataType = STM.DLayer.DataType.Int;
			this.nrMaxTemperature.DefaultValue = "0";
			this.nrMaxTemperature.FractionalDigits = 0;
			this.nrMaxTemperature.MaxValue = "2000";
			this.nrMaxTemperature.MinValue = "0";
			this.nrMaxTemperature.Name = "nrMaxTemperature";
			this.nrMaxTemperature.Resolution = 0D;
			this.nrMaxTemperature.Text = "0";
			this.nrMaxTemperature.Tip = null;
			this.nrMaxTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nrTemperatureRange_KeyPress);
			// 
			// plot
			// 
			resources.ApplyResources(this.plot, "plot");
			this.plot.BackColor = System.Drawing.Color.White;
			this.plot.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.plot.BaseMarginLeft = 60;
			this.plot.DrawRect = false;
			this.plot.GridColor = System.Drawing.Color.Black;
			this.plot.LabelColor = System.Drawing.Color.Black;
			this.plot.MarginBottom = 30;
			this.plot.MarginColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.plot.MarginLeft = 60;
			this.plot.MarginRight = 60;
			this.plot.MarginTop = 200;
			this.plot.MaxDataCount = 0;
			this.plot.Name = "plot";
			this.plot.ReportPoints = null;
			this.plot.ScaleColor = System.Drawing.Color.Black;
			this.plot.ShowMousePointLocation = false;
			this.plot.ShowReportLabels = false;
			this.plot.ShowReportLines = false;
			this.plot.ShowReportPoints = false;
			this.plot.TabStop = false;
			this.plot.TestValidData = false;
			this.plot.XOffset = false;
			this.plot.OnPointClick += new System.EventHandler<STM.PLayer.UI.PointEventArgs>(this.plot_OnPointClick);
			this.plot.OnPlotResize += new System.EventHandler<System.EventArgs>(this.plot_OnPlotResize);
			this.plot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.plot_MouseClick);
			// 
			// lbCaption
			// 
			resources.ApplyResources(this.lbCaption, "lbCaption");
			this.lbCaption.Name = "lbCaption";
			// 
			// Column0
			// 
			resources.ApplyResources(this.Column0, "Column0");
			this.Column0.Name = "Column0";
			this.Column0.ReadOnly = true;
			this.Column0.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dgvTestNameCol
			// 
			resources.ApplyResources(this.dgvTestNameCol, "dgvTestNameCol");
			this.dgvTestNameCol.Name = "dgvTestNameCol";
			this.dgvTestNameCol.ReadOnly = true;
			this.dgvTestNameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column2
			// 
			resources.ApplyResources(this.Column2, "Column2");
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column3
			// 
			resources.ApplyResources(this.Column3, "Column3");
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			resources.ApplyResources(this.Column4, "Column4");
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// Column5
			// 
			resources.ApplyResources(this.Column5, "Column5");
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ctxMenuTestProperties
			// 
			resources.ApplyResources(this.ctxMenuTestProperties, "ctxMenuTestProperties");
			this.ctxMenuTestProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripSeparator16,
            this.ctxMenuCurrentTest,
            this.menuSetAsDefualt,
            this.menuDrawingParams,
            this.menuExportAsExcel,
            this.toolStripSeparator19,
            this.closeTestToolStripMenuItem});
			this.ctxMenuTestProperties.Name = "menuGrid";
			// 
			// toolStripMenuItem4
			// 
			resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.subMenuTestReportPoints_Click);
			// 
			// toolStripSeparator16
			// 
			resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			// 
			// ctxMenuCurrentTest
			// 
			resources.ApplyResources(this.ctxMenuCurrentTest, "ctxMenuCurrentTest");
			this.ctxMenuCurrentTest.Name = "ctxMenuCurrentTest";
			this.ctxMenuCurrentTest.Click += new System.EventHandler(this.ctxMenuCurrentTest_Click);
			// 
			// menuSetAsDefualt
			// 
			resources.ApplyResources(this.menuSetAsDefualt, "menuSetAsDefualt");
			this.menuSetAsDefualt.Name = "menuSetAsDefualt";
			this.menuSetAsDefualt.Click += new System.EventHandler(this.subMenuDefaultTest_Click);
			// 
			// menuDrawingParams
			// 
			resources.ApplyResources(this.menuDrawingParams, "menuDrawingParams");
			this.menuDrawingParams.Name = "menuDrawingParams";
			this.menuDrawingParams.Click += new System.EventHandler(this.subMenuDrawParams_Click);
			// 
			// menuExportAsExcel
			// 
			resources.ApplyResources(this.menuExportAsExcel, "menuExportAsExcel");
			this.menuExportAsExcel.Name = "menuExportAsExcel";
			this.menuExportAsExcel.Click += new System.EventHandler(this.menuExportAsExcel_Click);
			// 
			// toolStripSeparator19
			// 
			resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			// 
			// closeTestToolStripMenuItem
			// 
			resources.ApplyResources(this.closeTestToolStripMenuItem, "closeTestToolStripMenuItem");
			this.closeTestToolStripMenuItem.Name = "closeTestToolStripMenuItem";
			this.closeTestToolStripMenuItem.Click += new System.EventHandler(this.closeTestToolStripMenuItem_Click);
			// 
			// toolStripStatusLabel1
			// 
			resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			// 
			// statusStandard
			// 
			resources.ApplyResources(this.statusStandard, "statusStandard");
			this.statusStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEncoderSpeed});
			this.statusStandard.Name = "statusStandard";
			// 
			// tslEncoderSpeed
			// 
			resources.ApplyResources(this.tslEncoderSpeed, "tslEncoderSpeed");
			this.tslEncoderSpeed.Name = "tslEncoderSpeed";
			// 
			// ctxMenuDiagram
			// 
			resources.ApplyResources(this.ctxMenuDiagram, "ctxMenuDiagram");
			this.ctxMenuDiagram.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuDiagramType,
            this.ctxMenuXUnit,
            this.ctxMenuYUnit,
            this.ctxMenuFixedScale,
            this.ctxMenuXOffset,
            this.toolStripSeparator17,
            this.ctxMenuReportPoints,
            this.ctxMenuShowReportPoints,
            this.ctxMenuShowReportLabels,
            this.ctxMenuShowReportLines});
			this.ctxMenuDiagram.Name = "menuDiagram";
			this.ctxMenuDiagram.Opened += new System.EventHandler(this.ctxMenuDiagram_Opened);
			// 
			// ctxMenuDiagramType
			// 
			resources.ApplyResources(this.ctxMenuDiagramType, "ctxMenuDiagramType");
			this.ctxMenuDiagramType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuForceExtension,
            this.ctxMenuStressStrain,
            this.massStressStarinToolStripMenuItem,
            this.lengthStressStarinToolStripMenuItem,
            this.ctxMenuForceTime,
            this.ctxMenuExtensionTime,
            this.ctxMenuStressTime,
            this.ctxMenuStrainTime,
            this.relaxLost,
            this.forceLost,
            this.stressLost,
            this.customeToolStripMenuItem,
            this.toolStripMenuItem6,
            this.temperatureDiagramToolStripMenuItem});
			this.ctxMenuDiagramType.Name = "ctxMenuDiagramType";
			// 
			// ctxMenuForceExtension
			// 
			resources.ApplyResources(this.ctxMenuForceExtension, "ctxMenuForceExtension");
			this.ctxMenuForceExtension.Checked = true;
			this.ctxMenuForceExtension.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ctxMenuForceExtension.Name = "ctxMenuForceExtension";
			this.ctxMenuForceExtension.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// ctxMenuStressStrain
			// 
			resources.ApplyResources(this.ctxMenuStressStrain, "ctxMenuStressStrain");
			this.ctxMenuStressStrain.Name = "ctxMenuStressStrain";
			this.ctxMenuStressStrain.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// massStressStarinToolStripMenuItem
			// 
			resources.ApplyResources(this.massStressStarinToolStripMenuItem, "massStressStarinToolStripMenuItem");
			this.massStressStarinToolStripMenuItem.Name = "massStressStarinToolStripMenuItem";
			this.massStressStarinToolStripMenuItem.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// lengthStressStarinToolStripMenuItem
			// 
			resources.ApplyResources(this.lengthStressStarinToolStripMenuItem, "lengthStressStarinToolStripMenuItem");
			this.lengthStressStarinToolStripMenuItem.Name = "lengthStressStarinToolStripMenuItem";
			this.lengthStressStarinToolStripMenuItem.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// ctxMenuForceTime
			// 
			resources.ApplyResources(this.ctxMenuForceTime, "ctxMenuForceTime");
			this.ctxMenuForceTime.Name = "ctxMenuForceTime";
			this.ctxMenuForceTime.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// ctxMenuExtensionTime
			// 
			resources.ApplyResources(this.ctxMenuExtensionTime, "ctxMenuExtensionTime");
			this.ctxMenuExtensionTime.Name = "ctxMenuExtensionTime";
			this.ctxMenuExtensionTime.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// ctxMenuStressTime
			// 
			resources.ApplyResources(this.ctxMenuStressTime, "ctxMenuStressTime");
			this.ctxMenuStressTime.Name = "ctxMenuStressTime";
			this.ctxMenuStressTime.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// ctxMenuStrainTime
			// 
			resources.ApplyResources(this.ctxMenuStrainTime, "ctxMenuStrainTime");
			this.ctxMenuStrainTime.Name = "ctxMenuStrainTime";
			this.ctxMenuStrainTime.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// relaxLost
			// 
			resources.ApplyResources(this.relaxLost, "relaxLost");
			this.relaxLost.Name = "relaxLost";
			this.relaxLost.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// forceLost
			// 
			resources.ApplyResources(this.forceLost, "forceLost");
			this.forceLost.Name = "forceLost";
			this.forceLost.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// stressLost
			// 
			resources.ApplyResources(this.stressLost, "stressLost");
			this.stressLost.Name = "stressLost";
			this.stressLost.Click += new System.EventHandler(this.SetDiagramType);
			// 
			// customeToolStripMenuItem
			// 
			resources.ApplyResources(this.customeToolStripMenuItem, "customeToolStripMenuItem");
			this.customeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuXType,
            this.ctxMenuYType,
            this.ctxMenuUpdate});
			this.customeToolStripMenuItem.Name = "customeToolStripMenuItem";
			// 
			// ctxMenuXType
			// 
			resources.ApplyResources(this.ctxMenuXType, "ctxMenuXType");
			this.ctxMenuXType.Name = "ctxMenuXType";
			// 
			// ctxMenuYType
			// 
			resources.ApplyResources(this.ctxMenuYType, "ctxMenuYType");
			this.ctxMenuYType.Name = "ctxMenuYType";
			// 
			// ctxMenuUpdate
			// 
			resources.ApplyResources(this.ctxMenuUpdate, "ctxMenuUpdate");
			this.ctxMenuUpdate.Name = "ctxMenuUpdate";
			this.ctxMenuUpdate.Click += new System.EventHandler(this.ctxMenuUpdate_Click);
			// 
			// toolStripMenuItem6
			// 
			resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			// 
			// temperatureDiagramToolStripMenuItem
			// 
			resources.ApplyResources(this.temperatureDiagramToolStripMenuItem, "temperatureDiagramToolStripMenuItem");
			this.temperatureDiagramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temperatureToolStripMenuItem,
            this.specTempUPToolStripMenuItem,
            this.specTempCNTToolStripMenuItem,
            this.specTempDNToolStripMenuItem,
            this.zoneTempUPToolStripMenuItem,
            this.zoneTempCNTToolStripMenuItem,
            this.zoneTempDNToolStripMenuItem,
            this.ambientTempToolStripMenuItem});
			this.temperatureDiagramToolStripMenuItem.Name = "temperatureDiagramToolStripMenuItem";
			// 
			// temperatureToolStripMenuItem
			// 
			resources.ApplyResources(this.temperatureToolStripMenuItem, "temperatureToolStripMenuItem");
			this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
			this.temperatureToolStripMenuItem.Click += new System.EventHandler(this.temperatureToolStripMenuItem_Click);
			// 
			// specTempUPToolStripMenuItem
			// 
			resources.ApplyResources(this.specTempUPToolStripMenuItem, "specTempUPToolStripMenuItem");
			this.specTempUPToolStripMenuItem.Name = "specTempUPToolStripMenuItem";
			this.specTempUPToolStripMenuItem.Click += new System.EventHandler(this.specTempUPToolStripMenuItem_Click);
			// 
			// specTempCNTToolStripMenuItem
			// 
			resources.ApplyResources(this.specTempCNTToolStripMenuItem, "specTempCNTToolStripMenuItem");
			this.specTempCNTToolStripMenuItem.Name = "specTempCNTToolStripMenuItem";
			this.specTempCNTToolStripMenuItem.Click += new System.EventHandler(this.specTempCNTToolStripMenuItem_Click);
			// 
			// specTempDNToolStripMenuItem
			// 
			resources.ApplyResources(this.specTempDNToolStripMenuItem, "specTempDNToolStripMenuItem");
			this.specTempDNToolStripMenuItem.Name = "specTempDNToolStripMenuItem";
			this.specTempDNToolStripMenuItem.Click += new System.EventHandler(this.specTempDNToolStripMenuItem_Click);
			// 
			// zoneTempUPToolStripMenuItem
			// 
			resources.ApplyResources(this.zoneTempUPToolStripMenuItem, "zoneTempUPToolStripMenuItem");
			this.zoneTempUPToolStripMenuItem.Name = "zoneTempUPToolStripMenuItem";
			this.zoneTempUPToolStripMenuItem.Click += new System.EventHandler(this.zoneTempUPToolStripMenuItem_Click);
			// 
			// zoneTempCNTToolStripMenuItem
			// 
			resources.ApplyResources(this.zoneTempCNTToolStripMenuItem, "zoneTempCNTToolStripMenuItem");
			this.zoneTempCNTToolStripMenuItem.Name = "zoneTempCNTToolStripMenuItem";
			this.zoneTempCNTToolStripMenuItem.Click += new System.EventHandler(this.zoneTempCNTToolStripMenuItem_Click);
			// 
			// zoneTempDNToolStripMenuItem
			// 
			resources.ApplyResources(this.zoneTempDNToolStripMenuItem, "zoneTempDNToolStripMenuItem");
			this.zoneTempDNToolStripMenuItem.Name = "zoneTempDNToolStripMenuItem";
			this.zoneTempDNToolStripMenuItem.Click += new System.EventHandler(this.zoneTempDNToolStripMenuItem_Click);
			// 
			// ambientTempToolStripMenuItem
			// 
			resources.ApplyResources(this.ambientTempToolStripMenuItem, "ambientTempToolStripMenuItem");
			this.ambientTempToolStripMenuItem.Name = "ambientTempToolStripMenuItem";
			this.ambientTempToolStripMenuItem.Click += new System.EventHandler(this.ambientTempToolStripMenuItem_Click);
			// 
			// ctxMenuXUnit
			// 
			resources.ApplyResources(this.ctxMenuXUnit, "ctxMenuXUnit");
			this.ctxMenuXUnit.Name = "ctxMenuXUnit";
			// 
			// ctxMenuYUnit
			// 
			resources.ApplyResources(this.ctxMenuYUnit, "ctxMenuYUnit");
			this.ctxMenuYUnit.Name = "ctxMenuYUnit";
			// 
			// ctxMenuFixedScale
			// 
			resources.ApplyResources(this.ctxMenuFixedScale, "ctxMenuFixedScale");
			this.ctxMenuFixedScale.Name = "ctxMenuFixedScale";
			this.ctxMenuFixedScale.Click += new System.EventHandler(this.subMenuFixedScale_Click);
			// 
			// ctxMenuXOffset
			// 
			resources.ApplyResources(this.ctxMenuXOffset, "ctxMenuXOffset");
			this.ctxMenuXOffset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNoXOffset,
            this.ctxXOffset});
			this.ctxMenuXOffset.Name = "ctxMenuXOffset";
			// 
			// ctxNoXOffset
			// 
			resources.ApplyResources(this.ctxNoXOffset, "ctxNoXOffset");
			this.ctxNoXOffset.Checked = true;
			this.ctxNoXOffset.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ctxNoXOffset.Name = "ctxNoXOffset";
			this.ctxNoXOffset.Click += new System.EventHandler(this.menuXpxOffset_Click);
			// 
			// ctxXOffset
			// 
			resources.ApplyResources(this.ctxXOffset, "ctxXOffset");
			this.ctxXOffset.Name = "ctxXOffset";
			this.ctxXOffset.Click += new System.EventHandler(this.menuXpxOffset_Click);
			// 
			// toolStripSeparator17
			// 
			resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			// 
			// ctxMenuReportPoints
			// 
			resources.ApplyResources(this.ctxMenuReportPoints, "ctxMenuReportPoints");
			this.ctxMenuReportPoints.Name = "ctxMenuReportPoints";
			this.ctxMenuReportPoints.Click += new System.EventHandler(this.subMenuTestReportPoints_Click);
			// 
			// ctxMenuShowReportPoints
			// 
			resources.ApplyResources(this.ctxMenuShowReportPoints, "ctxMenuShowReportPoints");
			this.ctxMenuShowReportPoints.Name = "ctxMenuShowReportPoints";
			this.ctxMenuShowReportPoints.Click += new System.EventHandler(this.onMenuShowReportPoints_Click);
			// 
			// ctxMenuShowReportLabels
			// 
			resources.ApplyResources(this.ctxMenuShowReportLabels, "ctxMenuShowReportLabels");
			this.ctxMenuShowReportLabels.Name = "ctxMenuShowReportLabels";
			this.ctxMenuShowReportLabels.Click += new System.EventHandler(this.onMenuShowReportLabels_Click);
			// 
			// ctxMenuShowReportLines
			// 
			resources.ApplyResources(this.ctxMenuShowReportLines, "ctxMenuShowReportLines");
			this.ctxMenuShowReportLines.Name = "ctxMenuShowReportLines";
			this.ctxMenuShowReportLines.Click += new System.EventHandler(this.onMenuShowReportLines_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.ForeColor = System.Drawing.Color.Red;
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.menuCloseTest_Click);
			// 
			// tsbNewTest
			// 
			resources.ApplyResources(this.tsbNewTest, "tsbNewTest");
			this.tsbNewTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbNewTest.Name = "tsbNewTest";
			this.tsbNewTest.Click += new System.EventHandler(this.NewTest_Click);
			// 
			// tsbOpen
			// 
			resources.ApplyResources(this.tsbOpen, "tsbOpen");
			this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOpen.Image = global::STM.Properties.Resources.open;
			this.tsbOpen.Name = "tsbOpen";
			this.tsbOpen.Click += new System.EventHandler(this.menuOpenTest_Click);
			// 
			// tsbSave
			// 
			resources.ApplyResources(this.tsbSave, "tsbSave");
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Image = global::STM.Properties.Resources.svae;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// toolStripSeparator18
			// 
			resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			// 
			// tsbPrintPreview
			// 
			resources.ApplyResources(this.tsbPrintPreview, "tsbPrintPreview");
			this.tsbPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPrintPreview.Image = global::STM.Properties.Resources.pp;
			this.tsbPrintPreview.Name = "tsbPrintPreview";
			this.tsbPrintPreview.Click += new System.EventHandler(this.menuPrintPreview_Click);
			// 
			// printToolStripButton1
			// 
			resources.ApplyResources(this.printToolStripButton1, "printToolStripButton1");
			this.printToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton1.Image = global::STM.Properties.Resources.print;
			this.printToolStripButton1.Name = "printToolStripButton1";
			this.printToolStripButton1.Click += new System.EventHandler(this.menuPrint_Click);
			// 
			// toolStripSeparator11
			// 
			resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			// 
			// tsbZoom
			// 
			resources.ApplyResources(this.tsbZoom, "tsbZoom");
			this.tsbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbZoom.Image = global::STM.Properties.Resources.zoom;
			this.tsbZoom.Name = "tsbZoom";
			this.tsbZoom.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// tsbUndo
			// 
			resources.ApplyResources(this.tsbUndo, "tsbUndo");
			this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUndo.Image = global::STM.Properties.Resources.undo;
			this.tsbUndo.Name = "tsbUndo";
			this.tsbUndo.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// tsbFit
			// 
			resources.ApplyResources(this.tsbFit, "tsbFit");
			this.tsbFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFit.Image = global::STM.Properties.Resources.fit;
			this.tsbFit.Name = "tsbFit";
			this.tsbFit.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// tsbIndicator
			// 
			resources.ApplyResources(this.tsbIndicator, "tsbIndicator");
			this.tsbIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbIndicator.Image = global::STM.Properties.Resources.Info;
			this.tsbIndicator.Name = "tsbIndicator";
			this.tsbIndicator.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// tsbPan
			// 
			resources.ApplyResources(this.tsbPan, "tsbPan");
			this.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPan.Image = global::STM.Properties.Resources.Pan;
			this.tsbPan.Name = "tsbPan";
			this.tsbPan.Click += new System.EventHandler(this.onPlotToolbarsClick);
			// 
			// closeTs
			// 
			resources.ApplyResources(this.closeTs, "closeTs");
			this.closeTs.BackColor = System.Drawing.SystemColors.Control;
			this.closeTs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.closeTs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewTest,
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator18,
            this.tsbPrintPreview,
            this.printToolStripButton1,
            this.toolStripSeparator11,
            this.tsbZoom,
            this.tsbUndo,
            this.tsbFit,
            this.tsbIndicator,
            this.tsbPan});
			this.closeTs.Name = "closeTs";
			// 
			// measureMonitors
			// 
			resources.ApplyResources(this.measureMonitors, "measureMonitors");
			this.measureMonitors.BackColor = System.Drawing.Color.White;
			this.measureMonitors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.measureMonitors.Name = "measureMonitors";
			this.measureMonitors.OnUnitChanges += new System.EventHandler<STM.PLayer.UI.UnitChangeEventArgs>(this.UpdateUnit);
			this.measureMonitors.OnZeroForce += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroForce);
			this.measureMonitors.OnZeroExten += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroExten);
			this.measureMonitors.OnZeroStrain += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroStrain);
			this.measureMonitors.OnUnitSystems += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnUnitSystems);
			this.measureMonitors.OnZeroTemperature += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroTemperature);
			this.measureMonitors.OnZeroTemperatureUp += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroTemperatureUp);
			this.measureMonitors.OnZeroTemperatureCenter += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroTemperatureCenter);
			this.measureMonitors.OnZeroTemperatureDown += new System.EventHandler<System.EventArgs>(this.measureMonitors_OnZeroTemperatureDown);
			// 
			// timer
			// 
			this.timer.Mode = STM.Timer.TimerMode.Periodic;
			this.timer.Period = 10;
			this.timer.Resolution = 1;
			this.timer.SynchronizingObject = null;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// images1
			// 
			this.images1.E0 = ((System.Drawing.Image)(resources.GetObject("images1.E0")));
			this.images1.F0 = ((System.Drawing.Image)(resources.GetObject("images1.F0")));
			this.images1.FastDown = global::STM.Properties.Resources.fb;
			this.images1.FastUp = global::STM.Properties.Resources.fup;
			this.images1.SlowDown = global::STM.Properties.Resources.sb;
			this.images1.SlowUp = global::STM.Properties.Resources.sup;
			this.images1.StartTest = global::STM.Properties.Resources.Start;
			this.images1.StopTest = global::STM.Properties.Resources.Stop;
			// 
			// MainFrm
			// 
			resources.ApplyResources(this, "$this");
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
			this.Controls.Add(this.button1);
			this.Controls.Add(this.plotReportPanel);
			this.Controls.Add(this.pnlCtrl);
			this.Controls.Add(this.statusStandard);
			this.Controls.Add(this.measureMonitors);
			this.Controls.Add(this.closeTs);
			this.Controls.Add(this.menuStandard);
			this.MainMenuStrip = this.menuStandard;
			this.Name = "MainFrm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
			this.Load += new System.EventHandler(this.MainFrm_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFrm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainFrm_DragEnter);
			this.menuStandard.ResumeLayout(false);
			this.menuStandard.PerformLayout();
			this.pnlCtrl.ResumeLayout(false);
			this.pnlCtrl.PerformLayout();
			this.plotReportPanel.ResumeLayout(false);
			this.pnlContainer.ResumeLayout(false);
			this.collapsiblePanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvReportingResults)).EndInit();
			this.testsPanel.ResumeLayout(false);
			this.tcTestsTab.ResumeLayout(false);
			this.tpTestSpec.ResumeLayout(false);
			this.tpTestProgress.ResumeLayout(false);
			this.plotPanel.ResumeLayout(false);
			this.plotPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.plot)).EndInit();
			this.ctxMenuTestProperties.ResumeLayout(false);
			this.statusStandard.ResumeLayout(false);
			this.statusStandard.PerformLayout();
			this.ctxMenuDiagram.ResumeLayout(false);
			this.closeTs.ResumeLayout(false);
			this.closeTs.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Timer.AccurateTimer timer;
        private System.Windows.Forms.MenuStrip menuStandard;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem viewToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointSelectionToolStripMenuItem;
        private STM.PLayer.UI.MeasurementMonitors measureMonitors;
        private System.Windows.Forms.Button bttnJogDown;
        private System.Windows.Forms.Button bttnJogUp;
        private System.Windows.Forms.Button bttnStopTest;
        private System.Windows.Forms.Button bttnStartTest;
  
        private System.Windows.Forms.ToolStripStatusLabel tlsStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuNewTest;
        private System.Windows.Forms.ToolStripMenuItem menuOpenTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripMenuItem menuPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuSetting;
        private System.Windows.Forms.ToolStripMenuItem menuMachineSetting;
        private System.Windows.Forms.ToolStripMenuItem menuInstrument;
        private System.Windows.Forms.ToolStripMenuItem subMenuOptionSetting;
        private System.Windows.Forms.ToolStripMenuItem menuTest;
        private System.Windows.Forms.ToolStripMenuItem subMenuNewTest;
        private System.Windows.Forms.ToolStripMenuItem menTools;
        private System.Windows.Forms.ToolStripMenuItem subMenuToolsStandard;
        private System.Windows.Forms.ToolStripMenuItem subMenuToolsStatusBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuToolsZoomIn;
        private System.Windows.Forms.ToolStripMenuItem menuToolsZoomOut;
        private System.Windows.Forms.ToolStripMenuItem menuToolsFit;
        private System.Windows.Forms.ToolStripMenuItem menuToolsPan;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subMenuToolsMeasures;
        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.ToolStripMenuItem menuCalibration;
        private System.Windows.Forms.Panel plotReportPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStandard;
        private System.Windows.Forms.ToolStripMenuItem subMenuTestReportPoints;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ContextMenuStrip ctxMenuDiagram;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuDiagramType;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuXUnit;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuYUnit;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuFixedScale;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuForceExtension;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuStressStrain;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuForceTime;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuExtensionTime;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuReportPoints;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuStressTime;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuStrainTime;
        private System.Windows.Forms.ToolStripMenuItem menuRecentTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem menuRecentGroups;
        private System.Windows.Forms.Button bttnStrainToExten;
        private System.Windows.Forms.ToolStripMenuItem subMenuUnits;
        private System.Windows.Forms.ToolStripMenuItem subMenuSI;
        private System.Windows.Forms.ToolStripMenuItem subMenuBS;
        private System.Windows.Forms.ToolStripMenuItem subMenuMKS;
        private System.Windows.Forms.ToolStripMenuItem menuAddToGroup;
        private DLayer.Images images1;
        private System.Windows.Forms.Button bttnReturnToZero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem menuCloseTest;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTestProperties;
        private System.Windows.Forms.ToolStripMenuItem menuSetAsDefualt;
        private System.Windows.Forms.ToolStripMenuItem menuDrawingParams;
        private System.Windows.Forms.Panel pnlContainer;
        private CollapsiblePanel plotPanel;
        private Plot plot;
        private CollapsiblePanel collapsiblePanel3;
        private CollapsiblePanel testsPanel;
        private UcSpec ucSpec;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuShowReportPoints;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuShowReportLabels;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuShowReportLines;
        private System.Windows.Forms.DataGridView dgvReportingResults;
        private System.Windows.Forms.ToolStripMenuItem menuCreateGroup;
        private System.Windows.Forms.ToolStripComboBox ctxCbRecentGroups;
        private System.Windows.Forms.ToolStripMenuItem menuOpenGroup;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem menuExportAsExcel;
        private PLayer.Print.Printting printting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuXOffset;
        private System.Windows.Forms.ToolStripMenuItem ctxXOffset;
        private System.Windows.Forms.ToolStripMenuItem ctxNoXOffset;
        private System.Windows.Forms.ToolStripMenuItem subMenuPlotPoints;
        private System.Windows.Forms.ToolStripMenuItem menuShowReportPoints;
        private System.Windows.Forms.ToolStripMenuItem menuShowReportLabels;
        private System.Windows.Forms.ToolStripMenuItem menuShowReportLines;
        private System.Windows.Forms.ToolStripMenuItem customeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ctxMenuXType;
        private System.Windows.Forms.ToolStripComboBox ctxMenuYType;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem subMenuMeasures;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.TabControl tcTestsTab;
        private System.Windows.Forms.TabPage tpTestSpec;
        private System.Windows.Forms.TabPage tpTestProgress;
        private System.Windows.Forms.RichTextBox rtbTestProgress;
        private System.Windows.Forms.ToolStripStatusLabel tslEncoderSpeed;
        private ToolTip bttnTip;
        private Button button1;
        private ToolStripButton tsbNewTest;
        private ToolStripButton tsbOpen;
        private ToolStripButton tsbSave;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripButton tsbPrintPreview;
        private ToolStripButton printToolStripButton1;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton tsbZoom;
        private ToolStripButton tsbUndo;
        private ToolStripButton tsbFit;
        private ToolStripButton tsbIndicator;
        private ToolStripButton tsbPan;
        private ToolStrip closeTs;
        private ToolStripMenuItem massStressStarinToolStripMenuItem;
        private ToolStripMenuItem lengthStressStarinToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripMenuItem closeTestToolStripMenuItem;
        private ToolStripMenuItem relaxLost;
        private ToolStripMenuItem forceLost;
        private ToolStripMenuItem stressLost;
        private Label lbCaption;
        private ToolStripMenuItem ctxMenuCurrentTest;
        private Label lbSpacer;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem temperatureControlToolStripMenuItem;
        private TextBox tbOnlineInfo;
        private ToolStripMenuItem testTimeReportToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem temperatureDiagramToolStripMenuItem;
        private ToolStripMenuItem specTempUPToolStripMenuItem;
        private ToolStripMenuItem specTempCNTToolStripMenuItem;
        private ToolStripMenuItem specTempDNToolStripMenuItem;
        private ToolStripMenuItem ambientTempToolStripMenuItem;
        private PLayer.NRTextBox nrMinTemperature;
        private PLayer.NRTextBox nrMaxTemperature;
        private ToolStripMenuItem temperatureToolStripMenuItem;
        private ToolStripMenuItem zoneTempUPToolStripMenuItem;
        private ToolStripMenuItem zoneTempCNTToolStripMenuItem;
        private ToolStripMenuItem zoneTempDNToolStripMenuItem;

        public delegate void MonitorInvokeDelegate(MeasuredParams measuredParams);
        public delegate void PlotUpdateDelagte(/*List<DataSample> measuredParams*/);
        public delegate void TestStop();

        private delegate void SetStageDescriptionText(int id, string description);
    }
}

