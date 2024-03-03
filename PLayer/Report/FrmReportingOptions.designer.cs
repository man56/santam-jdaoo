using System;
using System.Windows.Forms;

namespace STM.PLayer.Report
{
    partial class FrmReportingOptions
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportingOptions));
			STM.PLayer.Report.Logo logo1 = new STM.PLayer.Report.Logo();
			this.llGeneral = new System.Windows.Forms.LinkLabel();
			this.lbColors = new System.Windows.Forms.LinkLabel();
			this.pnlNavigation = new System.Windows.Forms.Panel();
			this.llPrint = new System.Windows.Forms.LinkLabel();
			this.llLogo = new System.Windows.Forms.LinkLabel();
			this.llApply = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tabOption = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.nrMaxAutoScaleSampleCount = new STM.PLayer.NRTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbResetMeasures = new System.Windows.Forms.CheckBox();
			this.cbGeneralShowLanguage = new System.Windows.Forms.CheckBox();
			this.label71 = new System.Windows.Forms.Label();
			this.lbBrowse = new System.Windows.Forms.LinkLabel();
			this.txtGeneralOutputDirectory = new System.Windows.Forms.TextBox();
			this.lbSampleDim1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cbPlotGridLines = new System.Windows.Forms.CheckBox();
			this.txtGeneralMaxRcFiles = new STM.PLayer.NRTextBox();
			this.tpLogo = new System.Windows.Forms.TabPage();
			this.logoTool1 = new STM.PLayer.Report.LogoTool();
			this.tpColors = new System.Windows.Forms.TabPage();
			this.label200 = new System.Windows.Forms.Label();
			this.llColorPreview = new System.Windows.Forms.LinkLabel();
			this.label10 = new System.Windows.Forms.Label();
			this.txtColorsGrid = new System.Windows.Forms.TextBox();
			this.txtColorsTitle = new System.Windows.Forms.TextBox();
			this.txtColorsScale = new System.Windows.Forms.TextBox();
			this.label102 = new System.Windows.Forms.Label();
			this.label100 = new System.Windows.Forms.Label();
			this.txtColorsLable = new System.Windows.Forms.TextBox();
			this.txtColorsDiagram2 = new System.Windows.Forms.TextBox();
			this.txtColorsDiagram = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtColorsBackground = new System.Windows.Forms.TextBox();
			this.txtColorsPageSpace = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tpPrint = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.cbPrintTestsResults = new System.Windows.Forms.CheckBox();
			this.cbPrintTestsSpec = new System.Windows.Forms.CheckBox();
			this.cbPrintPlot = new System.Windows.Forms.CheckBox();
			this.cbPrintLogo = new System.Windows.Forms.CheckBox();
			this.pnlNavigation.SuspendLayout();
			this.tabOption.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.tpLogo.SuspendLayout();
			this.tpColors.SuspendLayout();
			this.tpPrint.SuspendLayout();
			this.SuspendLayout();
			// 
			// llGeneral
			// 
			resources.ApplyResources(this.llGeneral, "llGeneral");
			this.llGeneral.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llGeneral.Name = "llGeneral";
			this.llGeneral.TabStop = true;
			this.llGeneral.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llGeneral.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGeneral_LinkClicked);
			// 
			// lbColors
			// 
			resources.ApplyResources(this.lbColors, "lbColors");
			this.lbColors.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lbColors.Name = "lbColors";
			this.lbColors.TabStop = true;
			this.lbColors.VisitedLinkColor = System.Drawing.Color.Blue;
			this.lbColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbColors_LinkClicked);
			// 
			// pnlNavigation
			// 
			this.pnlNavigation.BackColor = System.Drawing.Color.White;
			this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlNavigation.Controls.Add(this.llPrint);
			this.pnlNavigation.Controls.Add(this.llLogo);
			this.pnlNavigation.Controls.Add(this.llApply);
			this.pnlNavigation.Controls.Add(this.linkLabel1);
			this.pnlNavigation.Controls.Add(this.llGeneral);
			this.pnlNavigation.Controls.Add(this.lbColors);
			resources.ApplyResources(this.pnlNavigation, "pnlNavigation");
			this.pnlNavigation.Name = "pnlNavigation";
			// 
			// llPrint
			// 
			resources.ApplyResources(this.llPrint, "llPrint");
			this.llPrint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llPrint.Name = "llPrint";
			this.llPrint.TabStop = true;
			this.llPrint.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPrint_LinkClicked);
			// 
			// llLogo
			// 
			resources.ApplyResources(this.llLogo, "llLogo");
			this.llLogo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llLogo.Name = "llLogo";
			this.llLogo.TabStop = true;
			this.llLogo.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llLogo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLogo_LinkClicked);
			// 
			// llApply
			// 
			resources.ApplyResources(this.llApply, "llApply");
			this.llApply.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llApply.Name = "llApply";
			this.llApply.TabStop = true;
			this.llApply.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llApply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llApply_LinkClicked);
			// 
			// linkLabel1
			// 
			resources.ApplyResources(this.linkLabel1, "linkLabel1");
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabStop = true;
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// tabOption
			// 
			resources.ApplyResources(this.tabOption, "tabOption");
			this.tabOption.Controls.Add(this.tpGeneral);
			this.tabOption.Controls.Add(this.tpLogo);
			this.tabOption.Controls.Add(this.tpColors);
			this.tabOption.Controls.Add(this.tpPrint);
			this.tabOption.Multiline = true;
			this.tabOption.Name = "tabOption";
			this.tabOption.SelectedIndex = 0;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.label1);
			this.tpGeneral.Controls.Add(this.nrMaxAutoScaleSampleCount);
			this.tpGeneral.Controls.Add(this.cbResetMeasures);
			this.tpGeneral.Controls.Add(this.cbGeneralShowLanguage);
			this.tpGeneral.Controls.Add(this.label71);
			this.tpGeneral.Controls.Add(this.lbBrowse);
			this.tpGeneral.Controls.Add(this.txtGeneralOutputDirectory);
			this.tpGeneral.Controls.Add(this.lbSampleDim1);
			this.tpGeneral.Controls.Add(this.label5);
			this.tpGeneral.Controls.Add(this.cbPlotGridLines);
			this.tpGeneral.Controls.Add(this.txtGeneralMaxRcFiles);
			resources.ApplyResources(this.tpGeneral, "tpGeneral");
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// nrMaxAutoScaleSampleCount
			// 
			this.nrMaxAutoScaleSampleCount.BackColor = System.Drawing.Color.White;
			this.nrMaxAutoScaleSampleCount.CheckInRange = false;
			this.nrMaxAutoScaleSampleCount.DataType = STM.DLayer.DataType.Int;
			this.nrMaxAutoScaleSampleCount.DefaultValue = "0";
			resources.ApplyResources(this.nrMaxAutoScaleSampleCount, "nrMaxAutoScaleSampleCount");
			this.nrMaxAutoScaleSampleCount.FractionalDigits = 0;
			this.nrMaxAutoScaleSampleCount.MaxValue = "0";
			this.nrMaxAutoScaleSampleCount.MinValue = "0";
			this.nrMaxAutoScaleSampleCount.Name = "nrMaxAutoScaleSampleCount";
			this.nrMaxAutoScaleSampleCount.Resolution = 0D;
			this.nrMaxAutoScaleSampleCount.Text = "0";
			this.nrMaxAutoScaleSampleCount.Tip = null;
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// cbResetMeasures
			// 
			resources.ApplyResources(this.cbResetMeasures, "cbResetMeasures");
			this.cbResetMeasures.Name = "cbResetMeasures";
			this.cbResetMeasures.UseVisualStyleBackColor = true;
			// 
			// cbGeneralShowLanguage
			// 
			resources.ApplyResources(this.cbGeneralShowLanguage, "cbGeneralShowLanguage");
			this.cbGeneralShowLanguage.Name = "cbGeneralShowLanguage";
			this.cbGeneralShowLanguage.UseVisualStyleBackColor = true;
			// 
			// label71
			// 
			resources.ApplyResources(this.label71, "label71");
			this.label71.Name = "label71";
			// 
			// lbBrowse
			// 
			resources.ApplyResources(this.lbBrowse, "lbBrowse");
			this.lbBrowse.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lbBrowse.Name = "lbBrowse";
			this.lbBrowse.TabStop = true;
			this.lbBrowse.VisitedLinkColor = System.Drawing.Color.Blue;
			this.lbBrowse.Click += new System.EventHandler(this.lbBrowse_Click);
			// 
			// txtGeneralOutputDirectory
			// 
			resources.ApplyResources(this.txtGeneralOutputDirectory, "txtGeneralOutputDirectory");
			this.txtGeneralOutputDirectory.Name = "txtGeneralOutputDirectory";
			// 
			// lbSampleDim1
			// 
			resources.ApplyResources(this.lbSampleDim1, "lbSampleDim1");
			this.lbSampleDim1.Name = "lbSampleDim1";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// cbPlotGridLines
			// 
			resources.ApplyResources(this.cbPlotGridLines, "cbPlotGridLines");
			this.cbPlotGridLines.Name = "cbPlotGridLines";
			this.cbPlotGridLines.UseVisualStyleBackColor = true;
			// 
			// txtGeneralMaxRcFiles
			// 
			this.txtGeneralMaxRcFiles.BackColor = System.Drawing.Color.White;
			this.txtGeneralMaxRcFiles.CheckInRange = false;
			this.txtGeneralMaxRcFiles.DataType = STM.DLayer.DataType.Int;
			this.txtGeneralMaxRcFiles.DefaultValue = "0";
			resources.ApplyResources(this.txtGeneralMaxRcFiles, "txtGeneralMaxRcFiles");
			this.txtGeneralMaxRcFiles.FractionalDigits = 2;
			this.txtGeneralMaxRcFiles.MaxValue = "30";
			this.txtGeneralMaxRcFiles.MinValue = "1";
			this.txtGeneralMaxRcFiles.Name = "txtGeneralMaxRcFiles";
			this.txtGeneralMaxRcFiles.Resolution = 0D;
			this.txtGeneralMaxRcFiles.Text = "4";
			this.txtGeneralMaxRcFiles.Tip = null;
			// 
			// tpLogo
			// 
			this.tpLogo.Controls.Add(this.logoTool1);
			resources.ApplyResources(this.tpLogo, "tpLogo");
			this.tpLogo.Name = "tpLogo";
			this.tpLogo.UseVisualStyleBackColor = true;
			// 
			// logoTool1
			// 
			this.logoTool1.BackColor = System.Drawing.Color.White;
			this.logoTool1.Changed = false;
			this.logoTool1.Description = "";
			this.logoTool1.Detail = "";
			resources.ApplyResources(this.logoTool1, "logoTool1");
			this.logoTool1.FontCompany = null;
			this.logoTool1.FontDetail = null;
			this.logoTool1.FontDiscription = null;
			logo1.CompanyName = "";
			logo1.Detail = "";
			logo1.Discription = "";
			logo1.FontCompanyName = null;
			logo1.FontDetail = null;
			logo1.FontDiscription = null;
			logo1.ForeColor = System.Drawing.Color.Black;
			logo1.Height = 81;
			logo1.LogoBmp = null;
			logo1.LogoPath = null;
			logo1.LTR = true;
			logo1.Width = 463;
			this.logoTool1.Logo = logo1;
			this.logoTool1.LogoPath = null;
			this.logoTool1.Name = "logoTool1";
			// 
			// tpColors
			// 
			this.tpColors.BackColor = System.Drawing.Color.White;
			this.tpColors.Controls.Add(this.label200);
			this.tpColors.Controls.Add(this.llColorPreview);
			this.tpColors.Controls.Add(this.label10);
			this.tpColors.Controls.Add(this.txtColorsGrid);
			this.tpColors.Controls.Add(this.txtColorsTitle);
			this.tpColors.Controls.Add(this.txtColorsScale);
			this.tpColors.Controls.Add(this.label102);
			this.tpColors.Controls.Add(this.label100);
			this.tpColors.Controls.Add(this.txtColorsLable);
			this.tpColors.Controls.Add(this.txtColorsDiagram2);
			this.tpColors.Controls.Add(this.txtColorsDiagram);
			this.tpColors.Controls.Add(this.label9);
			this.tpColors.Controls.Add(this.label8);
			this.tpColors.Controls.Add(this.label3);
			this.tpColors.Controls.Add(this.txtColorsBackground);
			this.tpColors.Controls.Add(this.txtColorsPageSpace);
			this.tpColors.Controls.Add(this.label6);
			this.tpColors.Controls.Add(this.label7);
			resources.ApplyResources(this.tpColors, "tpColors");
			this.tpColors.Name = "tpColors";
			// 
			// label200
			// 
			resources.ApplyResources(this.label200, "label200");
			this.label200.Name = "label200";
			// 
			// llColorPreview
			// 
			resources.ApplyResources(this.llColorPreview, "llColorPreview");
			this.llColorPreview.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llColorPreview.Name = "llColorPreview";
			this.llColorPreview.TabStop = true;
			this.llColorPreview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llColorPreview_LinkClicked);
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// txtColorsGrid
			// 
			this.txtColorsGrid.BackColor = System.Drawing.Color.White;
			this.txtColorsGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsGrid, "txtColorsGrid");
			this.txtColorsGrid.Name = "txtColorsGrid";
			this.txtColorsGrid.ReadOnly = true;
			this.txtColorsGrid.Click += new System.EventHandler(this.txtColorsGrid_Click);
			// 
			// txtColorsTitle
			// 
			this.txtColorsTitle.BackColor = System.Drawing.Color.White;
			this.txtColorsTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsTitle, "txtColorsTitle");
			this.txtColorsTitle.Name = "txtColorsTitle";
			this.txtColorsTitle.ReadOnly = true;
			this.txtColorsTitle.Click += new System.EventHandler(this.txtColorsTitle_Click);
			// 
			// txtColorsScale
			// 
			this.txtColorsScale.BackColor = System.Drawing.Color.White;
			this.txtColorsScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsScale, "txtColorsScale");
			this.txtColorsScale.Name = "txtColorsScale";
			this.txtColorsScale.ReadOnly = true;
			this.txtColorsScale.Click += new System.EventHandler(this.txtColorsScale_Click);
			// 
			// label102
			// 
			resources.ApplyResources(this.label102, "label102");
			this.label102.Name = "label102";
			// 
			// label100
			// 
			resources.ApplyResources(this.label100, "label100");
			this.label100.Name = "label100";
			// 
			// txtColorsLable
			// 
			this.txtColorsLable.BackColor = System.Drawing.Color.White;
			this.txtColorsLable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsLable, "txtColorsLable");
			this.txtColorsLable.Name = "txtColorsLable";
			this.txtColorsLable.ReadOnly = true;
			this.txtColorsLable.Click += new System.EventHandler(this.txtColorsLable_Click);
			// 
			// txtColorsDiagram2
			// 
			this.txtColorsDiagram2.BackColor = System.Drawing.Color.White;
			this.txtColorsDiagram2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsDiagram2, "txtColorsDiagram2");
			this.txtColorsDiagram2.Name = "txtColorsDiagram2";
			this.txtColorsDiagram2.ReadOnly = true;
			this.txtColorsDiagram2.Click += new System.EventHandler(this.txtColorsDiagram2_Click);
			// 
			// txtColorsDiagram
			// 
			this.txtColorsDiagram.BackColor = System.Drawing.Color.White;
			this.txtColorsDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsDiagram, "txtColorsDiagram");
			this.txtColorsDiagram.Name = "txtColorsDiagram";
			this.txtColorsDiagram.ReadOnly = true;
			this.txtColorsDiagram.Click += new System.EventHandler(this.txtColorsDiagram_Click);
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// txtColorsBackground
			// 
			this.txtColorsBackground.BackColor = System.Drawing.Color.White;
			this.txtColorsBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsBackground, "txtColorsBackground");
			this.txtColorsBackground.Name = "txtColorsBackground";
			this.txtColorsBackground.ReadOnly = true;
			this.txtColorsBackground.Click += new System.EventHandler(this.txtColorsBackground_Click);
			// 
			// txtColorsPageSpace
			// 
			this.txtColorsPageSpace.BackColor = System.Drawing.Color.White;
			this.txtColorsPageSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtColorsPageSpace, "txtColorsPageSpace");
			this.txtColorsPageSpace.Name = "txtColorsPageSpace";
			this.txtColorsPageSpace.ReadOnly = true;
			this.txtColorsPageSpace.Click += new System.EventHandler(this.txtColorsPageSpace_Click);
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
			// tpPrint
			// 
			this.tpPrint.Controls.Add(this.label11);
			this.tpPrint.Controls.Add(this.cbPrintTestsResults);
			this.tpPrint.Controls.Add(this.cbPrintTestsSpec);
			this.tpPrint.Controls.Add(this.cbPrintPlot);
			this.tpPrint.Controls.Add(this.cbPrintLogo);
			resources.ApplyResources(this.tpPrint, "tpPrint");
			this.tpPrint.Name = "tpPrint";
			this.tpPrint.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// cbPrintTestsResults
			// 
			resources.ApplyResources(this.cbPrintTestsResults, "cbPrintTestsResults");
			this.cbPrintTestsResults.Name = "cbPrintTestsResults";
			this.cbPrintTestsResults.UseVisualStyleBackColor = true;
			// 
			// cbPrintTestsSpec
			// 
			resources.ApplyResources(this.cbPrintTestsSpec, "cbPrintTestsSpec");
			this.cbPrintTestsSpec.Name = "cbPrintTestsSpec";
			this.cbPrintTestsSpec.UseVisualStyleBackColor = true;
			// 
			// cbPrintPlot
			// 
			resources.ApplyResources(this.cbPrintPlot, "cbPrintPlot");
			this.cbPrintPlot.Name = "cbPrintPlot";
			this.cbPrintPlot.UseVisualStyleBackColor = true;
			// 
			// cbPrintLogo
			// 
			resources.ApplyResources(this.cbPrintLogo, "cbPrintLogo");
			this.cbPrintLogo.Name = "cbPrintLogo";
			this.cbPrintLogo.UseVisualStyleBackColor = true;
			// 
			// FrmReportingOptions
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabOption);
			this.Controls.Add(this.pnlNavigation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmReportingOptions";
			this.pnlNavigation.ResumeLayout(false);
			this.pnlNavigation.PerformLayout();
			this.tabOption.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.tpGeneral.PerformLayout();
			this.tpLogo.ResumeLayout(false);
			this.tpColors.ResumeLayout(false);
			this.tpColors.PerformLayout();
			this.tpPrint.ResumeLayout(false);
			this.tpPrint.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel llGeneral;
        private System.Windows.Forms.LinkLabel lbColors;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.TabControl tabOption;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpColors;
        private System.Windows.Forms.Label lbSampleDim1;
        private NRTextBox txtGeneralMaxRcFiles;
        private System.Windows.Forms.TextBox txtGeneralOutputDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.TextBox txtColorsBackground;
        private System.Windows.Forms.TextBox txtColorsPageSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel lbBrowse;
        private System.Windows.Forms.TextBox txtColorsGrid;
        private System.Windows.Forms.TextBox txtColorsTitle;
        private System.Windows.Forms.TextBox txtColorsScale;
        private System.Windows.Forms.TextBox txtColorsLable;
        private System.Windows.Forms.TextBox txtColorsDiagram;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private Label label71;
        private Label label10;
        private CheckBox cbGeneralShowLanguage;
        private LinkLabel llColorPreview;
        private LinkLabel llApply;
        private LinkLabel linkLabel1;
        private CheckBox cbPlotGridLines;
        private TabPage tpLogo;
        private LogoTool logoTool1;
        private LinkLabel llLogo;
        private LinkLabel llPrint;
        private TabPage tpPrint;
        private Label label11;
        private CheckBox cbPrintTestsResults;
        private CheckBox cbPrintTestsSpec;
        private CheckBox cbPrintPlot;
        private CheckBox cbPrintLogo;
        private CheckBox cbResetMeasures;
		private Label label102;
		private TextBox txtColorsDiagram2;
        private Label label1;
        private NRTextBox nrMaxAutoScaleSampleCount;

        public event EventHandler<ColorPreviewEventArgs> OnColorPreview;
    }
}