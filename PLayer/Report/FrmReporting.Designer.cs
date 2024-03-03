using System;
using STM.PLayer.Other.CollapsiblePanel;

namespace STM.PLayer.Report
{
    partial class FrmReporting
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporting));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbPointType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPointName = new System.Windows.Forms.TextBox();
			this.lbAtFrom = new System.Windows.Forms.Label();
			this.lbPointAtFromUnit = new System.Windows.Forms.Label();
			this.lbPointToUnit = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dgvPreview = new System.Windows.Forms.DataGridView();
			this.txtlabel = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbProperty = new System.Windows.Forms.ComboBox();
			this.llOk = new System.Windows.Forms.LinkLabel();
			this.pnlDefination = new System.Windows.Forms.Panel();
			this.llAddPoint = new System.Windows.Forms.LinkLabel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pnlFormula = new System.Windows.Forms.Panel();
			this.txtFormula = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pnlToSection = new System.Windows.Forms.Panel();
			this.txtPointTo = new STM.PLayer.NRTextBox();
			this.lbAtTo = new System.Windows.Forms.Label();
			this.pnlAtSection = new System.Windows.Forms.Panel();
			this.txtPointAtFrom = new STM.PLayer.NRTextBox();
			this.pnlFormulaKeyBoard = new System.Windows.Forms.Panel();
			this.bttnShift = new System.Windows.Forms.Button();
			this.bttnStressTrusStress = new System.Windows.Forms.Button();
			this.bttnStrainTrueStrain = new System.Windows.Forms.Button();
			this.button23 = new System.Windows.Forms.Button();
			this.button22 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.llUpdatePoint = new System.Windows.Forms.LinkLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.llCancelEditPoint = new System.Windows.Forms.LinkLabel();
			this.llDeletePoint = new System.Windows.Forms.LinkLabel();
			this.llCancel = new System.Windows.Forms.LinkLabel();
			this.cbElsticMode = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.cbShowElastic = new System.Windows.Forms.CheckBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpOptions = new System.Windows.Forms.TabPage();
			this.cbShowUtYield = new System.Windows.Forms.CheckBox();
			this.cbShowMeanRms = new System.Windows.Forms.CheckBox();
			this.cbShowAcceptRange = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtElasticEnd = new STM.PLayer.NRTextBox();
			this.txtElasticStart = new STM.PLayer.NRTextBox();
			this.tpDefination = new System.Windows.Forms.TabPage();
			this.pnlAdvanced = new STM.PLayer.Other.CollapsiblePanel.CollapsiblePanel();
			this.label9 = new System.Windows.Forms.Label();
			this.txtReject2 = new STM.PLayer.NRTextBox();
			this.llAdvancedUnit6 = new System.Windows.Forms.Label();
			this.llAdvancedAddPoint = new System.Windows.Forms.LinkLabel();
			this.txtAcceptable2 = new STM.PLayer.NRTextBox();
			this.txtReject1 = new STM.PLayer.NRTextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.llAdvancedUnit4 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAcceptable1 = new STM.PLayer.NRTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.llAdvancedUnit2 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtExpected2 = new STM.PLayer.NRTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtExpected1 = new STM.PLayer.NRTextBox();
			this.cbAdvancedEnabled = new System.Windows.Forms.CheckBox();
			this.txtCycle = new STM.PLayer.NRTextBox();
			this.pnlNavigation = new System.Windows.Forms.Panel();
			this.llExport = new System.Windows.Forms.LinkLabel();
			this.llImport = new System.Windows.Forms.LinkLabel();
			this.llLoad = new System.Windows.Forms.LinkLabel();
			this.llSave = new System.Windows.Forms.LinkLabel();
			this.llGeneral = new System.Windows.Forms.LinkLabel();
			this.lbPointDef = new System.Windows.Forms.LinkLabel();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.menuPreview = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuEditPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDeletePreview = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
			this.pnlDefination.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlFormula.SuspendLayout();
			this.pnlToSection.SuspendLayout();
			this.pnlAtSection.SuspendLayout();
			this.pnlFormulaKeyBoard.SuspendLayout();
			this.pnlPreview.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpOptions.SuspendLayout();
			this.tpDefination.SuspendLayout();
			this.pnlAdvanced.SuspendLayout();
			this.pnlNavigation.SuspendLayout();
			this.menuPreview.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// cbPointType
			// 
			resources.ApplyResources(this.cbPointType, "cbPointType");
			this.cbPointType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbPointType.FormattingEnabled = true;
			this.cbPointType.Name = "cbPointType";
			this.cbPointType.SelectedIndexChanged += new System.EventHandler(this.cbPointType_SelectedIndexChanged);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// txtPointName
			// 
			resources.ApplyResources(this.txtPointName, "txtPointName");
			this.txtPointName.Name = "txtPointName";
			this.txtPointName.Enter += new System.EventHandler(this.txtPointName_Enter);
			// 
			// lbAtFrom
			// 
			resources.ApplyResources(this.lbAtFrom, "lbAtFrom");
			this.lbAtFrom.Name = "lbAtFrom";
			// 
			// lbPointAtFromUnit
			// 
			resources.ApplyResources(this.lbPointAtFromUnit, "lbPointAtFromUnit");
			this.lbPointAtFromUnit.Name = "lbPointAtFromUnit";
			// 
			// lbPointToUnit
			// 
			resources.ApplyResources(this.lbPointToUnit, "lbPointToUnit");
			this.lbPointToUnit.Name = "lbPointToUnit";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// dgvPreview
			// 
			resources.ApplyResources(this.dgvPreview, "dgvPreview");
			this.dgvPreview.AllowUserToAddRows = false;
			this.dgvPreview.AllowUserToDeleteRows = false;
			this.dgvPreview.AllowUserToOrderColumns = true;
			this.dgvPreview.AllowUserToResizeColumns = false;
			this.dgvPreview.AllowUserToResizeRows = false;
			this.dgvPreview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPreview.MultiSelect = false;
			this.dgvPreview.Name = "dgvPreview";
			this.dgvPreview.ReadOnly = true;
			this.dgvPreview.RowHeadersVisible = false;
			this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvPreview.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPreview_ColumnHeaderMouseClick);
			this.dgvPreview.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPreview_ColumnHeaderMouseDoubleClick);
			this.dgvPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPreview_MouseClick);
			// 
			// txtlabel
			// 
			resources.ApplyResources(this.txtlabel, "txtlabel");
			this.txtlabel.Name = "txtlabel";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// cbProperty
			// 
			resources.ApplyResources(this.cbProperty, "cbProperty");
			this.cbProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbProperty.FormattingEnabled = true;
			this.cbProperty.Name = "cbProperty";
			this.cbProperty.SelectedIndexChanged += new System.EventHandler(this.cbProperty_SelectedIndexChanged);
			// 
			// llOk
			// 
			resources.ApplyResources(this.llOk, "llOk");
			this.llOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llOk.Name = "llOk";
			this.llOk.TabStop = true;
			this.llOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOk_LinkClicked);
			// 
			// pnlDefination
			// 
			resources.ApplyResources(this.pnlDefination, "pnlDefination");
			this.pnlDefination.Controls.Add(this.llAddPoint);
			this.pnlDefination.Controls.Add(this.cbProperty);
			this.pnlDefination.Controls.Add(this.panel3);
			this.pnlDefination.Controls.Add(this.label2);
			this.pnlDefination.Controls.Add(this.label4);
			this.pnlDefination.Controls.Add(this.label1);
			this.pnlDefination.Controls.Add(this.txtlabel);
			this.pnlDefination.Controls.Add(this.cbPointType);
			this.pnlDefination.Controls.Add(this.label8);
			this.pnlDefination.Controls.Add(this.txtPointName);
			this.pnlDefination.Controls.Add(this.label3);
			this.pnlDefination.Controls.Add(this.pnlFormulaKeyBoard);
			this.pnlDefination.Name = "pnlDefination";
			// 
			// llAddPoint
			// 
			resources.ApplyResources(this.llAddPoint, "llAddPoint");
			this.llAddPoint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llAddPoint.Name = "llAddPoint";
			this.llAddPoint.TabStop = true;
			this.llAddPoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddPoint_LinkClicked);
			// 
			// panel3
			// 
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.Controls.Add(this.pnlFormula);
			this.panel3.Controls.Add(this.pnlToSection);
			this.panel3.Controls.Add(this.pnlAtSection);
			this.panel3.Name = "panel3";
			// 
			// pnlFormula
			// 
			resources.ApplyResources(this.pnlFormula, "pnlFormula");
			this.pnlFormula.Controls.Add(this.txtFormula);
			this.pnlFormula.Controls.Add(this.label5);
			this.pnlFormula.Name = "pnlFormula";
			// 
			// txtFormula
			// 
			resources.ApplyResources(this.txtFormula, "txtFormula");
			this.txtFormula.Name = "txtFormula";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// pnlToSection
			// 
			resources.ApplyResources(this.pnlToSection, "pnlToSection");
			this.pnlToSection.Controls.Add(this.txtPointTo);
			this.pnlToSection.Controls.Add(this.lbAtTo);
			this.pnlToSection.Controls.Add(this.lbPointToUnit);
			this.pnlToSection.Name = "pnlToSection";
			// 
			// txtPointTo
			// 
			resources.ApplyResources(this.txtPointTo, "txtPointTo");
			this.txtPointTo.BackColor = System.Drawing.Color.White;
			this.txtPointTo.CheckInRange = false;
			this.txtPointTo.DataType = STM.DLayer.DataType.Double;
			this.txtPointTo.DefaultValue = "0";
			this.txtPointTo.FractionalDigits = 0;
			this.txtPointTo.MaxValue = "0";
			this.txtPointTo.MinValue = "0";
			this.txtPointTo.Name = "txtPointTo";
			this.txtPointTo.Resolution = 0D;
			this.txtPointTo.Text = "0";
			this.txtPointTo.Tip = null;
			// 
			// lbAtTo
			// 
			resources.ApplyResources(this.lbAtTo, "lbAtTo");
			this.lbAtTo.Name = "lbAtTo";
			// 
			// pnlAtSection
			// 
			resources.ApplyResources(this.pnlAtSection, "pnlAtSection");
			this.pnlAtSection.Controls.Add(this.txtPointAtFrom);
			this.pnlAtSection.Controls.Add(this.lbAtFrom);
			this.pnlAtSection.Controls.Add(this.lbPointAtFromUnit);
			this.pnlAtSection.Name = "pnlAtSection";
			// 
			// txtPointAtFrom
			// 
			resources.ApplyResources(this.txtPointAtFrom, "txtPointAtFrom");
			this.txtPointAtFrom.BackColor = System.Drawing.Color.White;
			this.txtPointAtFrom.CheckInRange = false;
			this.txtPointAtFrom.DataType = STM.DLayer.DataType.Double;
			this.txtPointAtFrom.DefaultValue = "0";
			this.txtPointAtFrom.FractionalDigits = 0;
			this.txtPointAtFrom.MaxValue = "0";
			this.txtPointAtFrom.MinValue = "0";
			this.txtPointAtFrom.Name = "txtPointAtFrom";
			this.txtPointAtFrom.Resolution = 0D;
			this.txtPointAtFrom.Text = "0";
			this.txtPointAtFrom.Tip = null;
			// 
			// pnlFormulaKeyBoard
			// 
			resources.ApplyResources(this.pnlFormulaKeyBoard, "pnlFormulaKeyBoard");
			this.pnlFormulaKeyBoard.Controls.Add(this.bttnShift);
			this.pnlFormulaKeyBoard.Controls.Add(this.bttnStressTrusStress);
			this.pnlFormulaKeyBoard.Controls.Add(this.bttnStrainTrueStrain);
			this.pnlFormulaKeyBoard.Controls.Add(this.button23);
			this.pnlFormulaKeyBoard.Controls.Add(this.button22);
			this.pnlFormulaKeyBoard.Controls.Add(this.button18);
			this.pnlFormulaKeyBoard.Controls.Add(this.button19);
			this.pnlFormulaKeyBoard.Controls.Add(this.button17);
			this.pnlFormulaKeyBoard.Controls.Add(this.button16);
			this.pnlFormulaKeyBoard.Controls.Add(this.button13);
			this.pnlFormulaKeyBoard.Controls.Add(this.button14);
			this.pnlFormulaKeyBoard.Controls.Add(this.button15);
			this.pnlFormulaKeyBoard.Controls.Add(this.button10);
			this.pnlFormulaKeyBoard.Controls.Add(this.button11);
			this.pnlFormulaKeyBoard.Controls.Add(this.button12);
			this.pnlFormulaKeyBoard.Controls.Add(this.button7);
			this.pnlFormulaKeyBoard.Controls.Add(this.button8);
			this.pnlFormulaKeyBoard.Controls.Add(this.button9);
			this.pnlFormulaKeyBoard.Controls.Add(this.button4);
			this.pnlFormulaKeyBoard.Controls.Add(this.button5);
			this.pnlFormulaKeyBoard.Controls.Add(this.button6);
			this.pnlFormulaKeyBoard.Controls.Add(this.button3);
			this.pnlFormulaKeyBoard.Controls.Add(this.button2);
			this.pnlFormulaKeyBoard.Controls.Add(this.button1);
			this.pnlFormulaKeyBoard.Name = "pnlFormulaKeyBoard";
			// 
			// bttnShift
			// 
			resources.ApplyResources(this.bttnShift, "bttnShift");
			this.bttnShift.ForeColor = System.Drawing.Color.Blue;
			this.bttnShift.Name = "bttnShift";
			this.bttnShift.UseVisualStyleBackColor = true;
			this.bttnShift.Click += new System.EventHandler(this.bttnShift_Click);
			// 
			// bttnStressTrusStress
			// 
			resources.ApplyResources(this.bttnStressTrusStress, "bttnStressTrusStress");
			this.bttnStressTrusStress.Name = "bttnStressTrusStress";
			this.bttnStressTrusStress.Tag = "Se";
			this.bttnStressTrusStress.UseVisualStyleBackColor = true;
			this.bttnStressTrusStress.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// bttnStrainTrueStrain
			// 
			resources.ApplyResources(this.bttnStrainTrueStrain, "bttnStrainTrueStrain");
			this.bttnStrainTrueStrain.Name = "bttnStrainTrueStrain";
			this.bttnStrainTrueStrain.Tag = "Sa";
			this.bttnStrainTrueStrain.UseVisualStyleBackColor = true;
			this.bttnStrainTrueStrain.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button23
			// 
			resources.ApplyResources(this.button23, "button23");
			this.button23.Name = "button23";
			this.button23.Tag = "E";
			this.button23.UseVisualStyleBackColor = true;
			this.button23.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button22
			// 
			resources.ApplyResources(this.button22, "button22");
			this.button22.Name = "button22";
			this.button22.Tag = "F";
			this.button22.UseVisualStyleBackColor = true;
			this.button22.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button18
			// 
			resources.ApplyResources(this.button18, "button18");
			this.button18.Name = "button18";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button19
			// 
			resources.ApplyResources(this.button19, "button19");
			this.button19.Name = "button19";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button17
			// 
			resources.ApplyResources(this.button17, "button17");
			this.button17.Name = "button17";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button16
			// 
			resources.ApplyResources(this.button16, "button16");
			this.button16.Name = "button16";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button13
			// 
			resources.ApplyResources(this.button13, "button13");
			this.button13.Name = "button13";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button14
			// 
			resources.ApplyResources(this.button14, "button14");
			this.button14.Name = "button14";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button15
			// 
			resources.ApplyResources(this.button15, "button15");
			this.button15.Name = "button15";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button10
			// 
			resources.ApplyResources(this.button10, "button10");
			this.button10.Name = "button10";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button11
			// 
			resources.ApplyResources(this.button11, "button11");
			this.button11.Name = "button11";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button12
			// 
			resources.ApplyResources(this.button12, "button12");
			this.button12.Name = "button12";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button7
			// 
			resources.ApplyResources(this.button7, "button7");
			this.button7.Name = "button7";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button8
			// 
			resources.ApplyResources(this.button8, "button8");
			this.button8.Name = "button8";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button9
			// 
			resources.ApplyResources(this.button9, "button9");
			this.button9.Name = "button9";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button4
			// 
			resources.ApplyResources(this.button4, "button4");
			this.button4.Name = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button5
			// 
			resources.ApplyResources(this.button5, "button5");
			this.button5.Name = "button5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button6
			// 
			resources.ApplyResources(this.button6, "button6");
			this.button6.Name = "button6";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button3
			// 
			resources.ApplyResources(this.button3, "button3");
			this.button3.Name = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.CalcKeyClicked);
			// 
			// pnlPreview
			// 
			resources.ApplyResources(this.pnlPreview, "pnlPreview");
			this.pnlPreview.Controls.Add(this.dgvPreview);
			this.pnlPreview.Controls.Add(this.llUpdatePoint);
			this.pnlPreview.Controls.Add(this.label6);
			this.pnlPreview.Controls.Add(this.llCancelEditPoint);
			this.pnlPreview.Controls.Add(this.llDeletePoint);
			this.pnlPreview.Name = "pnlPreview";
			// 
			// llUpdatePoint
			// 
			resources.ApplyResources(this.llUpdatePoint, "llUpdatePoint");
			this.llUpdatePoint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llUpdatePoint.Name = "llUpdatePoint";
			this.llUpdatePoint.TabStop = true;
			this.llUpdatePoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llUpdatePoint_LinkClicked);
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// llCancelEditPoint
			// 
			resources.ApplyResources(this.llCancelEditPoint, "llCancelEditPoint");
			this.llCancelEditPoint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llCancelEditPoint.Name = "llCancelEditPoint";
			this.llCancelEditPoint.TabStop = true;
			this.llCancelEditPoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCancelEdit_LinkClicked);
			// 
			// llDeletePoint
			// 
			resources.ApplyResources(this.llDeletePoint, "llDeletePoint");
			this.llDeletePoint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llDeletePoint.LinkColor = System.Drawing.Color.Red;
			this.llDeletePoint.Name = "llDeletePoint";
			this.llDeletePoint.TabStop = true;
			this.llDeletePoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDeleteCol_LinkClicked);
			// 
			// llCancel
			// 
			resources.ApplyResources(this.llCancel, "llCancel");
			this.llCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llCancel.Name = "llCancel";
			this.llCancel.TabStop = true;
			this.llCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCancel_LinkClicked);
			// 
			// cbElsticMode
			// 
			resources.ApplyResources(this.cbElsticMode, "cbElsticMode");
			this.cbElsticMode.FormattingEnabled = true;
			this.cbElsticMode.Items.AddRange(new object[] {
            resources.GetString("cbElsticMode.Items"),
            resources.GetString("cbElsticMode.Items1")});
			this.cbElsticMode.Name = "cbElsticMode";
			// 
			// label14
			// 
			resources.ApplyResources(this.label14, "label14");
			this.label14.Name = "label14";
			// 
			// cbShowElastic
			// 
			resources.ApplyResources(this.cbShowElastic, "cbShowElastic");
			this.cbShowElastic.Name = "cbShowElastic";
			this.cbShowElastic.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			resources.ApplyResources(this.label17, "label17");
			this.label17.Name = "label17";
			// 
			// label15
			// 
			resources.ApplyResources(this.label15, "label15");
			this.label15.Name = "label15";
			// 
			// tabControl1
			// 
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Controls.Add(this.tpOptions);
			this.tabControl1.Controls.Add(this.tpDefination);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tpOptions
			// 
			resources.ApplyResources(this.tpOptions, "tpOptions");
			this.tpOptions.Controls.Add(this.cbShowUtYield);
			this.tpOptions.Controls.Add(this.cbShowMeanRms);
			this.tpOptions.Controls.Add(this.cbShowAcceptRange);
			this.tpOptions.Controls.Add(this.label12);
			this.tpOptions.Controls.Add(this.txtElasticEnd);
			this.tpOptions.Controls.Add(this.cbShowElastic);
			this.tpOptions.Controls.Add(this.txtElasticStart);
			this.tpOptions.Controls.Add(this.cbElsticMode);
			this.tpOptions.Controls.Add(this.label15);
			this.tpOptions.Controls.Add(this.label14);
			this.tpOptions.Controls.Add(this.label17);
			this.tpOptions.Name = "tpOptions";
			this.tpOptions.UseVisualStyleBackColor = true;
			// 
			// cbShowUtYield
			// 
			resources.ApplyResources(this.cbShowUtYield, "cbShowUtYield");
			this.cbShowUtYield.Name = "cbShowUtYield";
			this.cbShowUtYield.UseVisualStyleBackColor = true;
			// 
			// cbShowMeanRms
			// 
			resources.ApplyResources(this.cbShowMeanRms, "cbShowMeanRms");
			this.cbShowMeanRms.Name = "cbShowMeanRms";
			this.cbShowMeanRms.UseVisualStyleBackColor = true;
			// 
			// cbShowAcceptRange
			// 
			resources.ApplyResources(this.cbShowAcceptRange, "cbShowAcceptRange");
			this.cbShowAcceptRange.Name = "cbShowAcceptRange";
			this.cbShowAcceptRange.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// txtElasticEnd
			// 
			resources.ApplyResources(this.txtElasticEnd, "txtElasticEnd");
			this.txtElasticEnd.BackColor = System.Drawing.Color.White;
			this.txtElasticEnd.CheckInRange = false;
			this.txtElasticEnd.DataType = STM.DLayer.DataType.Double;
			this.txtElasticEnd.DefaultValue = "0";
			this.txtElasticEnd.FractionalDigits = 0;
			this.txtElasticEnd.MaxValue = "0";
			this.txtElasticEnd.MinValue = "0";
			this.txtElasticEnd.Name = "txtElasticEnd";
			this.txtElasticEnd.Resolution = 0D;
			this.txtElasticEnd.Text = "0";
			this.txtElasticEnd.Tip = null;
			// 
			// txtElasticStart
			// 
			resources.ApplyResources(this.txtElasticStart, "txtElasticStart");
			this.txtElasticStart.BackColor = System.Drawing.Color.White;
			this.txtElasticStart.CheckInRange = false;
			this.txtElasticStart.DataType = STM.DLayer.DataType.Double;
			this.txtElasticStart.DefaultValue = "0";
			this.txtElasticStart.FractionalDigits = 0;
			this.txtElasticStart.MaxValue = "0";
			this.txtElasticStart.MinValue = "0";
			this.txtElasticStart.Name = "txtElasticStart";
			this.txtElasticStart.Resolution = 0D;
			this.txtElasticStart.Text = "0";
			this.txtElasticStart.Tip = null;
			// 
			// tpDefination
			// 
			resources.ApplyResources(this.tpDefination, "tpDefination");
			this.tpDefination.Controls.Add(this.pnlPreview);
			this.tpDefination.Controls.Add(this.pnlAdvanced);
			this.tpDefination.Controls.Add(this.pnlDefination);
			this.tpDefination.Name = "tpDefination";
			this.tpDefination.UseVisualStyleBackColor = true;
			// 
			// pnlAdvanced
			// 
			resources.ApplyResources(this.pnlAdvanced, "pnlAdvanced");
			this.pnlAdvanced.BackColor = System.Drawing.Color.Transparent;
			this.pnlAdvanced.Controls.Add(this.label9);
			this.pnlAdvanced.Controls.Add(this.txtReject2);
			this.pnlAdvanced.Controls.Add(this.llAdvancedUnit6);
			this.pnlAdvanced.Controls.Add(this.llAdvancedAddPoint);
			this.pnlAdvanced.Controls.Add(this.txtAcceptable2);
			this.pnlAdvanced.Controls.Add(this.txtReject1);
			this.pnlAdvanced.Controls.Add(this.label20);
			this.pnlAdvanced.Controls.Add(this.llAdvancedUnit4);
			this.pnlAdvanced.Controls.Add(this.label22);
			this.pnlAdvanced.Controls.Add(this.label7);
			this.pnlAdvanced.Controls.Add(this.txtAcceptable1);
			this.pnlAdvanced.Controls.Add(this.label16);
			this.pnlAdvanced.Controls.Add(this.llAdvancedUnit2);
			this.pnlAdvanced.Controls.Add(this.label18);
			this.pnlAdvanced.Controls.Add(this.txtExpected2);
			this.pnlAdvanced.Controls.Add(this.label13);
			this.pnlAdvanced.Controls.Add(this.label11);
			this.pnlAdvanced.Controls.Add(this.txtExpected1);
			this.pnlAdvanced.Controls.Add(this.cbAdvancedEnabled);
			this.pnlAdvanced.Controls.Add(this.txtCycle);
			this.pnlAdvanced.HeaderBackColor = System.Drawing.Color.White;
			this.pnlAdvanced.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.pnlAdvanced.HeaderImage = null;
			this.pnlAdvanced.HeaderText = " ";
			this.pnlAdvanced.HeaderTextColor = System.Drawing.Color.Black;
			this.pnlAdvanced.Name = "pnlAdvanced";
			this.pnlAdvanced.SizeChanged += new System.EventHandler(this.pnlAdvanced_SizeChanged);
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// txtReject2
			// 
			resources.ApplyResources(this.txtReject2, "txtReject2");
			this.txtReject2.BackColor = System.Drawing.Color.White;
			this.txtReject2.CheckInRange = false;
			this.txtReject2.DataType = STM.DLayer.DataType.Double;
			this.txtReject2.DefaultValue = "0";
			this.txtReject2.FractionalDigits = 0;
			this.txtReject2.MaxValue = "0";
			this.txtReject2.MinValue = "0";
			this.txtReject2.Name = "txtReject2";
			this.txtReject2.Resolution = 0D;
			this.txtReject2.Text = "0";
			this.txtReject2.Tip = null;
			// 
			// llAdvancedUnit6
			// 
			resources.ApplyResources(this.llAdvancedUnit6, "llAdvancedUnit6");
			this.llAdvancedUnit6.Name = "llAdvancedUnit6";
			// 
			// llAdvancedAddPoint
			// 
			resources.ApplyResources(this.llAdvancedAddPoint, "llAdvancedAddPoint");
			this.llAdvancedAddPoint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llAdvancedAddPoint.Name = "llAdvancedAddPoint";
			this.llAdvancedAddPoint.TabStop = true;
			this.llAdvancedAddPoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddPoint_LinkClicked);
			// 
			// txtAcceptable2
			// 
			resources.ApplyResources(this.txtAcceptable2, "txtAcceptable2");
			this.txtAcceptable2.BackColor = System.Drawing.Color.White;
			this.txtAcceptable2.CheckInRange = false;
			this.txtAcceptable2.DataType = STM.DLayer.DataType.Double;
			this.txtAcceptable2.DefaultValue = "0";
			this.txtAcceptable2.FractionalDigits = 0;
			this.txtAcceptable2.MaxValue = "0";
			this.txtAcceptable2.MinValue = "0";
			this.txtAcceptable2.Name = "txtAcceptable2";
			this.txtAcceptable2.Resolution = 0D;
			this.txtAcceptable2.Text = "0";
			this.txtAcceptable2.Tip = null;
			// 
			// txtReject1
			// 
			resources.ApplyResources(this.txtReject1, "txtReject1");
			this.txtReject1.BackColor = System.Drawing.Color.White;
			this.txtReject1.CheckInRange = false;
			this.txtReject1.DataType = STM.DLayer.DataType.Double;
			this.txtReject1.DefaultValue = "0";
			this.txtReject1.FractionalDigits = 0;
			this.txtReject1.MaxValue = "0";
			this.txtReject1.MinValue = "0";
			this.txtReject1.Name = "txtReject1";
			this.txtReject1.Resolution = 0D;
			this.txtReject1.Text = "0";
			this.txtReject1.Tip = null;
			// 
			// label20
			// 
			resources.ApplyResources(this.label20, "label20");
			this.label20.Name = "label20";
			// 
			// llAdvancedUnit4
			// 
			resources.ApplyResources(this.llAdvancedUnit4, "llAdvancedUnit4");
			this.llAdvancedUnit4.Name = "llAdvancedUnit4";
			// 
			// label22
			// 
			resources.ApplyResources(this.label22, "label22");
			this.label22.Name = "label22";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// txtAcceptable1
			// 
			resources.ApplyResources(this.txtAcceptable1, "txtAcceptable1");
			this.txtAcceptable1.BackColor = System.Drawing.Color.White;
			this.txtAcceptable1.CheckInRange = false;
			this.txtAcceptable1.DataType = STM.DLayer.DataType.Double;
			this.txtAcceptable1.DefaultValue = "0";
			this.txtAcceptable1.FractionalDigits = 0;
			this.txtAcceptable1.MaxValue = "0";
			this.txtAcceptable1.MinValue = "0";
			this.txtAcceptable1.Name = "txtAcceptable1";
			this.txtAcceptable1.Resolution = 0D;
			this.txtAcceptable1.Text = "0";
			this.txtAcceptable1.Tip = null;
			// 
			// label16
			// 
			resources.ApplyResources(this.label16, "label16");
			this.label16.Name = "label16";
			// 
			// llAdvancedUnit2
			// 
			resources.ApplyResources(this.llAdvancedUnit2, "llAdvancedUnit2");
			this.llAdvancedUnit2.Name = "llAdvancedUnit2";
			// 
			// label18
			// 
			resources.ApplyResources(this.label18, "label18");
			this.label18.Name = "label18";
			// 
			// txtExpected2
			// 
			resources.ApplyResources(this.txtExpected2, "txtExpected2");
			this.txtExpected2.BackColor = System.Drawing.Color.White;
			this.txtExpected2.CheckInRange = false;
			this.txtExpected2.DataType = STM.DLayer.DataType.Double;
			this.txtExpected2.DefaultValue = "0";
			this.txtExpected2.FractionalDigits = 0;
			this.txtExpected2.MaxValue = "0";
			this.txtExpected2.MinValue = "0";
			this.txtExpected2.Name = "txtExpected2";
			this.txtExpected2.Resolution = 0D;
			this.txtExpected2.Text = "0";
			this.txtExpected2.Tip = null;
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// txtExpected1
			// 
			resources.ApplyResources(this.txtExpected1, "txtExpected1");
			this.txtExpected1.BackColor = System.Drawing.Color.White;
			this.txtExpected1.CheckInRange = false;
			this.txtExpected1.DataType = STM.DLayer.DataType.Double;
			this.txtExpected1.DefaultValue = "0";
			this.txtExpected1.FractionalDigits = 0;
			this.txtExpected1.MaxValue = "0";
			this.txtExpected1.MinValue = "0";
			this.txtExpected1.Name = "txtExpected1";
			this.txtExpected1.Resolution = 0D;
			this.txtExpected1.Text = "0";
			this.txtExpected1.Tip = null;
			// 
			// cbAdvancedEnabled
			// 
			resources.ApplyResources(this.cbAdvancedEnabled, "cbAdvancedEnabled");
			this.cbAdvancedEnabled.Name = "cbAdvancedEnabled";
			this.cbAdvancedEnabled.UseVisualStyleBackColor = true;
			// 
			// txtCycle
			// 
			resources.ApplyResources(this.txtCycle, "txtCycle");
			this.txtCycle.BackColor = System.Drawing.Color.White;
			this.txtCycle.CheckInRange = true;
			this.txtCycle.DataType = STM.DLayer.DataType.Int;
			this.txtCycle.DefaultValue = "0";
			this.txtCycle.FractionalDigits = 0;
			this.txtCycle.MaxValue = "2000";
			this.txtCycle.MinValue = "-1";
			this.txtCycle.Name = "txtCycle";
			this.txtCycle.Resolution = 0D;
			this.txtCycle.Text = "1";
			this.txtCycle.Tip = null;
			// 
			// pnlNavigation
			// 
			resources.ApplyResources(this.pnlNavigation, "pnlNavigation");
			this.pnlNavigation.BackColor = System.Drawing.Color.White;
			this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlNavigation.Controls.Add(this.llExport);
			this.pnlNavigation.Controls.Add(this.llImport);
			this.pnlNavigation.Controls.Add(this.llLoad);
			this.pnlNavigation.Controls.Add(this.llSave);
			this.pnlNavigation.Controls.Add(this.llGeneral);
			this.pnlNavigation.Controls.Add(this.llCancel);
			this.pnlNavigation.Controls.Add(this.lbPointDef);
			this.pnlNavigation.Controls.Add(this.llOk);
			this.pnlNavigation.Name = "pnlNavigation";
			// 
			// llExport
			// 
			resources.ApplyResources(this.llExport, "llExport");
			this.llExport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llExport.Name = "llExport";
			this.llExport.TabStop = true;
			this.llExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llExport_LinkClicked);
			// 
			// llImport
			// 
			resources.ApplyResources(this.llImport, "llImport");
			this.llImport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llImport.Name = "llImport";
			this.llImport.TabStop = true;
			this.llImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llImport_LinkClicked);
			// 
			// llLoad
			// 
			resources.ApplyResources(this.llLoad, "llLoad");
			this.llLoad.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llLoad.Name = "llLoad";
			this.llLoad.TabStop = true;
			this.llLoad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLoad_LinkClicked);
			// 
			// llSave
			// 
			resources.ApplyResources(this.llSave, "llSave");
			this.llSave.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llSave.Name = "llSave";
			this.llSave.TabStop = true;
			this.llSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSave_LinkClicked);
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
			// lbPointDef
			// 
			resources.ApplyResources(this.lbPointDef, "lbPointDef");
			this.lbPointDef.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lbPointDef.Name = "lbPointDef";
			this.lbPointDef.TabStop = true;
			this.lbPointDef.VisitedLinkColor = System.Drawing.Color.Blue;
			this.lbPointDef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbPointDef_LinkClicked);
			// 
			// sfd
			// 
			this.sfd.DefaultExt = "trsx";
			this.sfd.DereferenceLinks = false;
			resources.ApplyResources(this.sfd, "sfd");
			this.sfd.InitialDirectory = "Report Settings";
			// 
			// ofd
			// 
			this.ofd.DefaultExt = "trsx";
			resources.ApplyResources(this.ofd, "ofd");
			this.ofd.InitialDirectory = "\\\\Report Settings";
			// 
			// menuPreview
			// 
			resources.ApplyResources(this.menuPreview, "menuPreview");
			this.menuPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditPreview,
            this.menuDeletePreview});
			this.menuPreview.Name = "menuPreview";
			// 
			// menuEditPreview
			// 
			resources.ApplyResources(this.menuEditPreview, "menuEditPreview");
			this.menuEditPreview.Name = "menuEditPreview";
			this.menuEditPreview.Click += new System.EventHandler(this.menuEditPreview_Click);
			// 
			// menuDeletePreview
			// 
			resources.ApplyResources(this.menuDeletePreview, "menuDeletePreview");
			this.menuDeletePreview.Name = "menuDeletePreview";
			this.menuDeletePreview.Click += new System.EventHandler(this.menuDeletePreview_Click);
			// 
			// FrmReporting
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.pnlNavigation);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmReporting";
			this.Load += new System.EventHandler(this.FrmReporting_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
			this.pnlDefination.ResumeLayout(false);
			this.pnlDefination.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.pnlFormula.ResumeLayout(false);
			this.pnlFormula.PerformLayout();
			this.pnlToSection.ResumeLayout(false);
			this.pnlToSection.PerformLayout();
			this.pnlAtSection.ResumeLayout(false);
			this.pnlAtSection.PerformLayout();
			this.pnlFormulaKeyBoard.ResumeLayout(false);
			this.pnlPreview.ResumeLayout(false);
			this.pnlPreview.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tpOptions.ResumeLayout(false);
			this.tpOptions.PerformLayout();
			this.tpDefination.ResumeLayout(false);
			this.pnlAdvanced.ResumeLayout(false);
			this.pnlAdvanced.PerformLayout();
			this.pnlNavigation.ResumeLayout(false);
			this.pnlNavigation.PerformLayout();
			this.menuPreview.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPointType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPointName;
        private System.Windows.Forms.Label lbAtFrom;
        private System.Windows.Forms.Label lbPointAtFromUnit;
        private System.Windows.Forms.Label lbPointToUnit;
        private NRTextBox txtPointAtFrom;
        private System.Windows.Forms.LinkLabel llAddPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llOk;
        private System.Windows.Forms.Label label7;
        private NRTextBox txtCycle;
        private System.Windows.Forms.LinkLabel llCancelEditPoint;
        private System.Windows.Forms.ComboBox cbProperty;
        private System.Windows.Forms.TextBox txtlabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.LinkLabel llDeletePoint;
        private System.Windows.Forms.Panel pnlDefination;
        private CollapsiblePanel pnlAdvanced;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label llAdvancedUnit6;
        private NRTextBox txtReject2;
        private System.Windows.Forms.Label label20;
        private NRTextBox txtReject1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label llAdvancedUnit4;
        private NRTextBox txtAcceptable2;
        private System.Windows.Forms.Label label16;
        private NRTextBox txtAcceptable1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label llAdvancedUnit2;
        private NRTextBox txtExpected2;
        private System.Windows.Forms.Label label13;
        NRTextBox txtExpected1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbAdvancedEnabled;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.LinkLabel llCancel;
        private System.Windows.Forms.Panel pnlFormulaKeyBoard;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button bttnShift;
        private System.Windows.Forms.Button bttnStressTrusStress;
        private System.Windows.Forms.Button bttnStrainTrueStrain;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button17;
        public delegate void ClickingCmd();

        public ClickingCmd OnClickingCmd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel llUpdatePoint;
        private System.Windows.Forms.LinkLabel llAdvancedAddPoint;
        private System.Windows.Forms.ComboBox cbElsticMode;
        private System.Windows.Forms.Label label14;
        private NRTextBox txtElasticEnd;
        private System.Windows.Forms.Label label15;
        private NRTextBox txtElasticStart;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbShowElastic;
        private NRTextBox txtPointTo;
        private System.Windows.Forms.Label lbAtTo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlFormula;
        private System.Windows.Forms.Panel pnlToSection;
        private System.Windows.Forms.Panel pnlAtSection;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOptions;
        private System.Windows.Forms.TabPage tpDefination;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.LinkLabel llGeneral;
        private System.Windows.Forms.LinkLabel lbPointDef;
        private System.Windows.Forms.CheckBox cbShowMeanRms;
        private System.Windows.Forms.CheckBox cbShowAcceptRange;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel llSave;
        private System.Windows.Forms.LinkLabel llLoad;
        private System.Windows.Forms.LinkLabel llExport;
        private System.Windows.Forms.LinkLabel llImport;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ContextMenuStrip menuPreview;
        private System.Windows.Forms.ToolStripMenuItem menuEditPreview;
        private System.Windows.Forms.ToolStripMenuItem menuDeletePreview;
        private System.Windows.Forms.CheckBox cbShowUtYield;

        public event EventHandler<EventArgs> OnOperationDone;
    }
}