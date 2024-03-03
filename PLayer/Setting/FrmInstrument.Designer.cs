using System;

namespace STM.PLayer.Setting
{
    partial class FrmInstrument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstrument));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.lkTemperature = new System.Windows.Forms.LinkLabel();
            this.llApply = new System.Windows.Forms.LinkLabel();
            this.llStrain2 = new System.Windows.Forms.LinkLabel();
            this.llExtension = new System.Windows.Forms.LinkLabel();
            this.lbExit = new System.Windows.Forms.LinkLabel();
            this.llForce = new System.Windows.Forms.LinkLabel();
            this.llStrain1 = new System.Windows.Forms.LinkLabel();
            this.tbInstrument = new System.Windows.Forms.TabControl();
            this.tpLoadcell = new System.Windows.Forms.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtForceMax = new STM.PLayer.NRTextBox();
            this.txtForceMin = new STM.PLayer.NRTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoadcellPeakNoise = new STM.PLayer.NRTextBox();
            this.txtLoadcellFilter = new STM.PLayer.NRTextBox();
            this.txtLoadcellRes = new STM.PLayer.NRTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNoLoadcell = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.dgvLoadCells = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpLDEncoder = new System.Windows.Forms.TabPage();
            this.label34 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtEncoderGain = new STM.PLayer.NRTextBox();
            this.txtEncoderMax = new STM.PLayer.NRTextBox();
            this.txtEncoderMin = new STM.PLayer.NRTextBox();
            this.txtEncoderPeakNoise = new STM.PLayer.NRTextBox();
            this.txtEncoderFilter = new STM.PLayer.NRTextBox();
            this.txtEncoderRes = new STM.PLayer.NRTextBox();
            this.tpExtensometer = new System.Windows.Forms.TabPage();
            this.cbUseExtensometer = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNoExtensometer = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.dgvExtensometers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label43 = new System.Windows.Forms.Label();
            this.txtExtenGauge = new STM.PLayer.NRTextBox();
            this.txtExtenMax = new STM.PLayer.NRTextBox();
            this.txtExtenMin = new STM.PLayer.NRTextBox();
            this.txtExtenPeakNoise = new STM.PLayer.NRTextBox();
            this.txtExtenFilter = new STM.PLayer.NRTextBox();
            this.txtExtenRes = new STM.PLayer.NRTextBox();
            this.tpStrain2 = new System.Windows.Forms.TabPage();
            this.label36 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLExtenGauge = new STM.PLayer.NRTextBox();
            this.txtLExtenMax = new STM.PLayer.NRTextBox();
            this.txtLExtenMin = new STM.PLayer.NRTextBox();
            this.txtLExtenNoise = new STM.PLayer.NRTextBox();
            this.txtLExtenFilter = new STM.PLayer.NRTextBox();
            this.txtLExtenRes = new STM.PLayer.NRTextBox();
            this.tbpTemperature = new System.Windows.Forms.TabPage();
            this.tmprUseHMI = new System.Windows.Forms.RadioButton();
            this.tmprUseDirect = new System.Windows.Forms.RadioButton();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtDiagramY2ScaleRange = new STM.PLayer.NRTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tmprMaximum = new STM.PLayer.NRTextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tmprResolution = new STM.PLayer.NRTextBox();
            this.pBarPortChanging = new System.Windows.Forms.ProgressBar();
            this.panelNavigation.SuspendLayout();
            this.tbInstrument.SuspendLayout();
            this.tpLoadcell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadCells)).BeginInit();
            this.tpLDEncoder.SuspendLayout();
            this.tpExtensometer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtensometers)).BeginInit();
            this.tpStrain2.SuspendLayout();
            this.tbpTemperature.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavigation
            // 
            resources.ApplyResources(this.panelNavigation, "panelNavigation");
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavigation.Controls.Add(this.lkTemperature);
            this.panelNavigation.Controls.Add(this.llApply);
            this.panelNavigation.Controls.Add(this.llStrain2);
            this.panelNavigation.Controls.Add(this.llExtension);
            this.panelNavigation.Controls.Add(this.lbExit);
            this.panelNavigation.Controls.Add(this.llForce);
            this.panelNavigation.Controls.Add(this.llStrain1);
            this.panelNavigation.Name = "panelNavigation";
            // 
            // lkTemperature
            // 
            resources.ApplyResources(this.lkTemperature, "lkTemperature");
            this.lkTemperature.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkTemperature.Name = "lkTemperature";
            this.lkTemperature.TabStop = true;
            this.lkTemperature.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lkTemperature.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkTemperature_LinkClicked);
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
            // llStrain2
            // 
            resources.ApplyResources(this.llStrain2, "llStrain2");
            this.llStrain2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llStrain2.Name = "llStrain2";
            this.llStrain2.TabStop = true;
            this.llStrain2.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llStrain2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStrain2_LinkClicked);
            // 
            // llExtension
            // 
            resources.ApplyResources(this.llExtension, "llExtension");
            this.llExtension.AutoEllipsis = true;
            this.llExtension.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llExtension.Name = "llExtension";
            this.llExtension.TabStop = true;
            this.llExtension.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llExtension.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llExtension_LinkClicked);
            // 
            // lbExit
            // 
            resources.ApplyResources(this.lbExit, "lbExit");
            this.lbExit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lbExit.Name = "lbExit";
            this.lbExit.TabStop = true;
            this.lbExit.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbExit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbExit_LinkClicked);
            // 
            // llForce
            // 
            resources.ApplyResources(this.llForce, "llForce");
            this.llForce.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llForce.Name = "llForce";
            this.llForce.TabStop = true;
            this.llForce.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llForce.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llForce_LinkClicked);
            // 
            // llStrain1
            // 
            resources.ApplyResources(this.llStrain1, "llStrain1");
            this.llStrain1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llStrain1.Name = "llStrain1";
            this.llStrain1.TabStop = true;
            this.llStrain1.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llStrain1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStrain1_LinkClicked);
            // 
            // tbInstrument
            // 
            resources.ApplyResources(this.tbInstrument, "tbInstrument");
            this.tbInstrument.Controls.Add(this.tpLoadcell);
            this.tbInstrument.Controls.Add(this.tpLDEncoder);
            this.tbInstrument.Controls.Add(this.tpExtensometer);
            this.tbInstrument.Controls.Add(this.tpStrain2);
            this.tbInstrument.Controls.Add(this.tbpTemperature);
            this.tbInstrument.Name = "tbInstrument";
            this.tbInstrument.SelectedIndex = 0;
            // 
            // tpLoadcell
            // 
            resources.ApplyResources(this.tpLoadcell, "tpLoadcell");
            this.tpLoadcell.BackColor = System.Drawing.Color.White;
            this.tpLoadcell.Controls.Add(this.label33);
            this.tpLoadcell.Controls.Add(this.label13);
            this.tpLoadcell.Controls.Add(this.label14);
            this.tpLoadcell.Controls.Add(this.label15);
            this.tpLoadcell.Controls.Add(this.label16);
            this.tpLoadcell.Controls.Add(this.txtForceMax);
            this.tpLoadcell.Controls.Add(this.txtForceMin);
            this.tpLoadcell.Controls.Add(this.label7);
            this.tpLoadcell.Controls.Add(this.label5);
            this.tpLoadcell.Controls.Add(this.label6);
            this.tpLoadcell.Controls.Add(this.txtLoadcellPeakNoise);
            this.tpLoadcell.Controls.Add(this.txtLoadcellFilter);
            this.tpLoadcell.Controls.Add(this.txtLoadcellRes);
            this.tpLoadcell.Controls.Add(this.label2);
            this.tpLoadcell.Controls.Add(this.lbNoLoadcell);
            this.tpLoadcell.Controls.Add(this.label44);
            this.tpLoadcell.Controls.Add(this.dgvLoadCells);
            this.tpLoadcell.Name = "tpLoadcell";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // txtForceMax
            // 
            resources.ApplyResources(this.txtForceMax, "txtForceMax");
            this.txtForceMax.BackColor = System.Drawing.Color.White;
            this.txtForceMax.CheckInRange = false;
            this.txtForceMax.DataType = STM.DLayer.DataType.Int;
            this.txtForceMax.DefaultValue = "0";
            this.txtForceMax.FractionalDigits = 0;
            this.txtForceMax.MaxValue = "0";
            this.txtForceMax.MinValue = "0";
            this.txtForceMax.Name = "txtForceMax";
            this.txtForceMax.Resolution = 0D;
            this.txtForceMax.Text = "0";
            this.txtForceMax.Tip = null;
            this.txtForceMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtForceMin
            // 
            resources.ApplyResources(this.txtForceMin, "txtForceMin");
            this.txtForceMin.BackColor = System.Drawing.Color.White;
            this.txtForceMin.CheckInRange = false;
            this.txtForceMin.DataType = STM.DLayer.DataType.Int;
            this.txtForceMin.DefaultValue = "0";
            this.txtForceMin.FractionalDigits = 0;
            this.txtForceMin.MaxValue = "0";
            this.txtForceMin.MinValue = "0";
            this.txtForceMin.Name = "txtForceMin";
            this.txtForceMin.Resolution = 0D;
            this.txtForceMin.Text = "0";
            this.txtForceMin.Tip = null;
            this.txtForceMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtLoadcellPeakNoise
            // 
            resources.ApplyResources(this.txtLoadcellPeakNoise, "txtLoadcellPeakNoise");
            this.txtLoadcellPeakNoise.BackColor = System.Drawing.Color.White;
            this.txtLoadcellPeakNoise.CheckInRange = false;
            this.txtLoadcellPeakNoise.DataType = STM.DLayer.DataType.Int;
            this.txtLoadcellPeakNoise.DefaultValue = "0";
            this.txtLoadcellPeakNoise.FractionalDigits = 0;
            this.txtLoadcellPeakNoise.MaxValue = "0";
            this.txtLoadcellPeakNoise.MinValue = "0";
            this.txtLoadcellPeakNoise.Name = "txtLoadcellPeakNoise";
            this.txtLoadcellPeakNoise.Resolution = 0D;
            this.txtLoadcellPeakNoise.Text = "0";
            this.txtLoadcellPeakNoise.Tip = null;
            this.txtLoadcellPeakNoise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLoadcellFilter
            // 
            resources.ApplyResources(this.txtLoadcellFilter, "txtLoadcellFilter");
            this.txtLoadcellFilter.BackColor = System.Drawing.Color.White;
            this.txtLoadcellFilter.CheckInRange = false;
            this.txtLoadcellFilter.DataType = STM.DLayer.DataType.Int;
            this.txtLoadcellFilter.DefaultValue = "0";
            this.txtLoadcellFilter.FractionalDigits = 0;
            this.txtLoadcellFilter.MaxValue = "0";
            this.txtLoadcellFilter.MinValue = "0";
            this.txtLoadcellFilter.Name = "txtLoadcellFilter";
            this.txtLoadcellFilter.Resolution = 0D;
            this.txtLoadcellFilter.Text = "0";
            this.txtLoadcellFilter.Tip = null;
            this.txtLoadcellFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLoadcellRes
            // 
            resources.ApplyResources(this.txtLoadcellRes, "txtLoadcellRes");
            this.txtLoadcellRes.BackColor = System.Drawing.Color.White;
            this.txtLoadcellRes.CheckInRange = true;
            this.txtLoadcellRes.DataType = STM.DLayer.DataType.Int;
            this.txtLoadcellRes.DefaultValue = "0";
            this.txtLoadcellRes.FractionalDigits = 0;
            this.txtLoadcellRes.MaxValue = "9";
            this.txtLoadcellRes.MinValue = "0";
            this.txtLoadcellRes.Name = "txtLoadcellRes";
            this.txtLoadcellRes.Resolution = 0D;
            this.txtLoadcellRes.Text = "9";
            this.txtLoadcellRes.Tip = null;
            this.txtLoadcellRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbNoLoadcell
            // 
            resources.ApplyResources(this.lbNoLoadcell, "lbNoLoadcell");
            this.lbNoLoadcell.ForeColor = System.Drawing.Color.Red;
            this.lbNoLoadcell.Name = "lbNoLoadcell";
            // 
            // label44
            // 
            resources.ApplyResources(this.label44, "label44");
            this.label44.Name = "label44";
            // 
            // dgvLoadCells
            // 
            resources.ApplyResources(this.dgvLoadCells, "dgvLoadCells");
            this.dgvLoadCells.AllowUserToAddRows = false;
            this.dgvLoadCells.AllowUserToOrderColumns = true;
            this.dgvLoadCells.AllowUserToResizeColumns = false;
            this.dgvLoadCells.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLoadCells.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoadCells.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoadCells.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoadCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadCells.ColumnHeadersVisible = false;
            this.dgvLoadCells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.cID,
            this.cCapacity,
            this.cRO});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoadCells.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLoadCells.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLoadCells.Name = "dgvLoadCells";
            this.dgvLoadCells.RowHeadersVisible = false;
            this.dgvLoadCells.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoadCells.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLoadCells_RowsRemoved);
            // 
            // type
            // 
            resources.ApplyResources(this.type, "type");
            this.type.Name = "type";
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.cID.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.cID, "cID");
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cCapacity
            // 
            resources.ApplyResources(this.cCapacity, "cCapacity");
            this.cCapacity.Name = "cCapacity";
            // 
            // cRO
            // 
            this.cRO.FillWeight = 120F;
            resources.ApplyResources(this.cRO, "cRO");
            this.cRO.Name = "cRO";
            // 
            // tpLDEncoder
            // 
            resources.ApplyResources(this.tpLDEncoder, "tpLDEncoder");
            this.tpLDEncoder.BackColor = System.Drawing.Color.White;
            this.tpLDEncoder.Controls.Add(this.label34);
            this.tpLDEncoder.Controls.Add(this.label39);
            this.tpLDEncoder.Controls.Add(this.label27);
            this.tpLDEncoder.Controls.Add(this.label28);
            this.tpLDEncoder.Controls.Add(this.label29);
            this.tpLDEncoder.Controls.Add(this.label30);
            this.tpLDEncoder.Controls.Add(this.label31);
            this.tpLDEncoder.Controls.Add(this.label17);
            this.tpLDEncoder.Controls.Add(this.label18);
            this.tpLDEncoder.Controls.Add(this.label24);
            this.tpLDEncoder.Controls.Add(this.txtEncoderGain);
            this.tpLDEncoder.Controls.Add(this.txtEncoderMax);
            this.tpLDEncoder.Controls.Add(this.txtEncoderMin);
            this.tpLDEncoder.Controls.Add(this.txtEncoderPeakNoise);
            this.tpLDEncoder.Controls.Add(this.txtEncoderFilter);
            this.tpLDEncoder.Controls.Add(this.txtEncoderRes);
            this.tpLDEncoder.Name = "tpLDEncoder";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
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
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // txtEncoderGain
            // 
            resources.ApplyResources(this.txtEncoderGain, "txtEncoderGain");
            this.txtEncoderGain.BackColor = System.Drawing.Color.White;
            this.txtEncoderGain.CheckInRange = false;
            this.txtEncoderGain.DataType = STM.DLayer.DataType.Double;
            this.txtEncoderGain.DefaultValue = "0";
            this.txtEncoderGain.FractionalDigits = 10;
            this.txtEncoderGain.MaxValue = "0";
            this.txtEncoderGain.MinValue = "0";
            this.txtEncoderGain.Name = "txtEncoderGain";
            this.txtEncoderGain.Resolution = 0D;
            this.txtEncoderGain.Text = "0";
            this.txtEncoderGain.Tip = null;
            this.txtEncoderGain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtEncoderMax
            // 
            resources.ApplyResources(this.txtEncoderMax, "txtEncoderMax");
            this.txtEncoderMax.BackColor = System.Drawing.Color.White;
            this.txtEncoderMax.CheckInRange = false;
            this.txtEncoderMax.DataType = STM.DLayer.DataType.Double;
            this.txtEncoderMax.DefaultValue = "0";
            this.txtEncoderMax.FractionalDigits = 0;
            this.txtEncoderMax.MaxValue = "0";
            this.txtEncoderMax.MinValue = "0";
            this.txtEncoderMax.Name = "txtEncoderMax";
            this.txtEncoderMax.Resolution = 0D;
            this.txtEncoderMax.Text = "0";
            this.txtEncoderMax.Tip = null;
            this.txtEncoderMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtEncoderMin
            // 
            resources.ApplyResources(this.txtEncoderMin, "txtEncoderMin");
            this.txtEncoderMin.BackColor = System.Drawing.Color.White;
            this.txtEncoderMin.CheckInRange = false;
            this.txtEncoderMin.DataType = STM.DLayer.DataType.Double;
            this.txtEncoderMin.DefaultValue = "0";
            this.txtEncoderMin.FractionalDigits = 0;
            this.txtEncoderMin.MaxValue = "0";
            this.txtEncoderMin.MinValue = "0";
            this.txtEncoderMin.Name = "txtEncoderMin";
            this.txtEncoderMin.Resolution = 0D;
            this.txtEncoderMin.Text = "0";
            this.txtEncoderMin.Tip = null;
            this.txtEncoderMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtEncoderPeakNoise
            // 
            resources.ApplyResources(this.txtEncoderPeakNoise, "txtEncoderPeakNoise");
            this.txtEncoderPeakNoise.BackColor = System.Drawing.Color.White;
            this.txtEncoderPeakNoise.CheckInRange = false;
            this.txtEncoderPeakNoise.DataType = STM.DLayer.DataType.Int;
            this.txtEncoderPeakNoise.DefaultValue = "0";
            this.txtEncoderPeakNoise.FractionalDigits = 0;
            this.txtEncoderPeakNoise.MaxValue = "0";
            this.txtEncoderPeakNoise.MinValue = "0";
            this.txtEncoderPeakNoise.Name = "txtEncoderPeakNoise";
            this.txtEncoderPeakNoise.Resolution = 0D;
            this.txtEncoderPeakNoise.Text = "0";
            this.txtEncoderPeakNoise.Tip = null;
            this.txtEncoderPeakNoise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtEncoderFilter
            // 
            resources.ApplyResources(this.txtEncoderFilter, "txtEncoderFilter");
            this.txtEncoderFilter.BackColor = System.Drawing.Color.White;
            this.txtEncoderFilter.CheckInRange = false;
            this.txtEncoderFilter.DataType = STM.DLayer.DataType.Int;
            this.txtEncoderFilter.DefaultValue = "0";
            this.txtEncoderFilter.FractionalDigits = 0;
            this.txtEncoderFilter.MaxValue = "0";
            this.txtEncoderFilter.MinValue = "0";
            this.txtEncoderFilter.Name = "txtEncoderFilter";
            this.txtEncoderFilter.Resolution = 0D;
            this.txtEncoderFilter.Text = "0";
            this.txtEncoderFilter.Tip = null;
            this.txtEncoderFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtEncoderRes
            // 
            resources.ApplyResources(this.txtEncoderRes, "txtEncoderRes");
            this.txtEncoderRes.BackColor = System.Drawing.Color.White;
            this.txtEncoderRes.CheckInRange = true;
            this.txtEncoderRes.DataType = STM.DLayer.DataType.Int;
            this.txtEncoderRes.DefaultValue = "0";
            this.txtEncoderRes.FractionalDigits = 0;
            this.txtEncoderRes.MaxValue = "9";
            this.txtEncoderRes.MinValue = "0";
            this.txtEncoderRes.Name = "txtEncoderRes";
            this.txtEncoderRes.Resolution = 0D;
            this.txtEncoderRes.Text = "9";
            this.txtEncoderRes.Tip = null;
            this.txtEncoderRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // tpExtensometer
            // 
            resources.ApplyResources(this.tpExtensometer, "tpExtensometer");
            this.tpExtensometer.BackColor = System.Drawing.Color.White;
            this.tpExtensometer.Controls.Add(this.cbUseExtensometer);
            this.tpExtensometer.Controls.Add(this.label35);
            this.tpExtensometer.Controls.Add(this.label42);
            this.tpExtensometer.Controls.Add(this.label3);
            this.tpExtensometer.Controls.Add(this.label4);
            this.tpExtensometer.Controls.Add(this.label8);
            this.tpExtensometer.Controls.Add(this.label9);
            this.tpExtensometer.Controls.Add(this.label10);
            this.tpExtensometer.Controls.Add(this.label11);
            this.tpExtensometer.Controls.Add(this.label12);
            this.tpExtensometer.Controls.Add(this.label1);
            this.tpExtensometer.Controls.Add(this.lbNoExtensometer);
            this.tpExtensometer.Controls.Add(this.label47);
            this.tpExtensometer.Controls.Add(this.dgvExtensometers);
            this.tpExtensometer.Controls.Add(this.label43);
            this.tpExtensometer.Controls.Add(this.txtExtenGauge);
            this.tpExtensometer.Controls.Add(this.txtExtenMax);
            this.tpExtensometer.Controls.Add(this.txtExtenMin);
            this.tpExtensometer.Controls.Add(this.txtExtenPeakNoise);
            this.tpExtensometer.Controls.Add(this.txtExtenFilter);
            this.tpExtensometer.Controls.Add(this.txtExtenRes);
            this.tpExtensometer.Name = "tpExtensometer";
            // 
            // cbUseExtensometer
            // 
            resources.ApplyResources(this.cbUseExtensometer, "cbUseExtensometer");
            this.cbUseExtensometer.Name = "cbUseExtensometer";
            this.cbUseExtensometer.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbNoExtensometer
            // 
            resources.ApplyResources(this.lbNoExtensometer, "lbNoExtensometer");
            this.lbNoExtensometer.ForeColor = System.Drawing.Color.Red;
            this.lbNoExtensometer.Name = "lbNoExtensometer";
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // dgvExtensometers
            // 
            resources.ApplyResources(this.dgvExtensometers, "dgvExtensometers");
            this.dgvExtensometers.AllowUserToAddRows = false;
            this.dgvExtensometers.AllowUserToOrderColumns = true;
            this.dgvExtensometers.AllowUserToResizeColumns = false;
            this.dgvExtensometers.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvExtensometers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExtensometers.BackgroundColor = System.Drawing.Color.White;
            this.dgvExtensometers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExtensometers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtensometers.ColumnHeadersVisible = false;
            this.dgvExtensometers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExtensometers.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExtensometers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvExtensometers.Name = "dgvExtensometers";
            this.dgvExtensometers.RowHeadersVisible = false;
            this.dgvExtensometers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExtensometers.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvExtensometer_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // label43
            // 
            resources.ApplyResources(this.label43, "label43");
            this.label43.Name = "label43";
            // 
            // txtExtenGauge
            // 
            resources.ApplyResources(this.txtExtenGauge, "txtExtenGauge");
            this.txtExtenGauge.BackColor = System.Drawing.Color.White;
            this.txtExtenGauge.CheckInRange = false;
            this.txtExtenGauge.DataType = STM.DLayer.DataType.Double;
            this.txtExtenGauge.DefaultValue = "0";
            this.txtExtenGauge.FractionalDigits = 0;
            this.txtExtenGauge.MaxValue = "0";
            this.txtExtenGauge.MinValue = "0";
            this.txtExtenGauge.Name = "txtExtenGauge";
            this.txtExtenGauge.Resolution = 0D;
            this.txtExtenGauge.Text = "0";
            this.txtExtenGauge.Tip = null;
            this.txtExtenGauge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtExtenMax
            // 
            resources.ApplyResources(this.txtExtenMax, "txtExtenMax");
            this.txtExtenMax.BackColor = System.Drawing.Color.White;
            this.txtExtenMax.CheckInRange = false;
            this.txtExtenMax.DataType = STM.DLayer.DataType.Double;
            this.txtExtenMax.DefaultValue = "0";
            this.txtExtenMax.FractionalDigits = 0;
            this.txtExtenMax.MaxValue = "0";
            this.txtExtenMax.MinValue = "0";
            this.txtExtenMax.Name = "txtExtenMax";
            this.txtExtenMax.Resolution = 0D;
            this.txtExtenMax.Text = "0";
            this.txtExtenMax.Tip = null;
            this.txtExtenMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtExtenMin
            // 
            resources.ApplyResources(this.txtExtenMin, "txtExtenMin");
            this.txtExtenMin.BackColor = System.Drawing.Color.White;
            this.txtExtenMin.CheckInRange = false;
            this.txtExtenMin.DataType = STM.DLayer.DataType.Double;
            this.txtExtenMin.DefaultValue = "0";
            this.txtExtenMin.FractionalDigits = 0;
            this.txtExtenMin.MaxValue = "0";
            this.txtExtenMin.MinValue = "0";
            this.txtExtenMin.Name = "txtExtenMin";
            this.txtExtenMin.Resolution = 0D;
            this.txtExtenMin.Text = "0";
            this.txtExtenMin.Tip = null;
            this.txtExtenMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtExtenPeakNoise
            // 
            resources.ApplyResources(this.txtExtenPeakNoise, "txtExtenPeakNoise");
            this.txtExtenPeakNoise.BackColor = System.Drawing.Color.White;
            this.txtExtenPeakNoise.CheckInRange = false;
            this.txtExtenPeakNoise.DataType = STM.DLayer.DataType.Int;
            this.txtExtenPeakNoise.DefaultValue = "0";
            this.txtExtenPeakNoise.FractionalDigits = 0;
            this.txtExtenPeakNoise.MaxValue = "0";
            this.txtExtenPeakNoise.MinValue = "0";
            this.txtExtenPeakNoise.Name = "txtExtenPeakNoise";
            this.txtExtenPeakNoise.Resolution = 0D;
            this.txtExtenPeakNoise.Text = "0";
            this.txtExtenPeakNoise.Tip = null;
            this.txtExtenPeakNoise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtExtenFilter
            // 
            resources.ApplyResources(this.txtExtenFilter, "txtExtenFilter");
            this.txtExtenFilter.BackColor = System.Drawing.Color.White;
            this.txtExtenFilter.CheckInRange = false;
            this.txtExtenFilter.DataType = STM.DLayer.DataType.Int;
            this.txtExtenFilter.DefaultValue = "0";
            this.txtExtenFilter.FractionalDigits = 0;
            this.txtExtenFilter.MaxValue = "0";
            this.txtExtenFilter.MinValue = "0";
            this.txtExtenFilter.Name = "txtExtenFilter";
            this.txtExtenFilter.Resolution = 0D;
            this.txtExtenFilter.Text = "0";
            this.txtExtenFilter.Tip = null;
            this.txtExtenFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtExtenRes
            // 
            resources.ApplyResources(this.txtExtenRes, "txtExtenRes");
            this.txtExtenRes.BackColor = System.Drawing.Color.White;
            this.txtExtenRes.CheckInRange = true;
            this.txtExtenRes.DataType = STM.DLayer.DataType.Int;
            this.txtExtenRes.DefaultValue = "0";
            this.txtExtenRes.FractionalDigits = 0;
            this.txtExtenRes.MaxValue = "9";
            this.txtExtenRes.MinValue = "0";
            this.txtExtenRes.Name = "txtExtenRes";
            this.txtExtenRes.Resolution = 0D;
            this.txtExtenRes.Text = "9";
            this.txtExtenRes.Tip = null;
            this.txtExtenRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // tpStrain2
            // 
            resources.ApplyResources(this.tpStrain2, "tpStrain2");
            this.tpStrain2.BackColor = System.Drawing.Color.White;
            this.tpStrain2.Controls.Add(this.label36);
            this.tpStrain2.Controls.Add(this.label41);
            this.tpStrain2.Controls.Add(this.label40);
            this.tpStrain2.Controls.Add(this.label32);
            this.tpStrain2.Controls.Add(this.label25);
            this.tpStrain2.Controls.Add(this.label26);
            this.tpStrain2.Controls.Add(this.label19);
            this.tpStrain2.Controls.Add(this.label20);
            this.tpStrain2.Controls.Add(this.label21);
            this.tpStrain2.Controls.Add(this.label22);
            this.tpStrain2.Controls.Add(this.label23);
            this.tpStrain2.Controls.Add(this.txtLExtenGauge);
            this.tpStrain2.Controls.Add(this.txtLExtenMax);
            this.tpStrain2.Controls.Add(this.txtLExtenMin);
            this.tpStrain2.Controls.Add(this.txtLExtenNoise);
            this.tpStrain2.Controls.Add(this.txtLExtenFilter);
            this.tpStrain2.Controls.Add(this.txtLExtenRes);
            this.tpStrain2.Name = "tpStrain2";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
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
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // txtLExtenGauge
            // 
            resources.ApplyResources(this.txtLExtenGauge, "txtLExtenGauge");
            this.txtLExtenGauge.BackColor = System.Drawing.Color.White;
            this.txtLExtenGauge.CheckInRange = false;
            this.txtLExtenGauge.DataType = STM.DLayer.DataType.Double;
            this.txtLExtenGauge.DefaultValue = "0";
            this.txtLExtenGauge.FractionalDigits = 0;
            this.txtLExtenGauge.MaxValue = "0";
            this.txtLExtenGauge.MinValue = "0";
            this.txtLExtenGauge.Name = "txtLExtenGauge";
            this.txtLExtenGauge.Resolution = 0D;
            this.txtLExtenGauge.Text = "0";
            this.txtLExtenGauge.Tip = null;
            this.txtLExtenGauge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLExtenMax
            // 
            resources.ApplyResources(this.txtLExtenMax, "txtLExtenMax");
            this.txtLExtenMax.BackColor = System.Drawing.Color.White;
            this.txtLExtenMax.CheckInRange = false;
            this.txtLExtenMax.DataType = STM.DLayer.DataType.Double;
            this.txtLExtenMax.DefaultValue = "0";
            this.txtLExtenMax.FractionalDigits = 0;
            this.txtLExtenMax.MaxValue = "0";
            this.txtLExtenMax.MinValue = "0";
            this.txtLExtenMax.Name = "txtLExtenMax";
            this.txtLExtenMax.Resolution = 0D;
            this.txtLExtenMax.Text = "0";
            this.txtLExtenMax.Tip = null;
            this.txtLExtenMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLExtenMin
            // 
            resources.ApplyResources(this.txtLExtenMin, "txtLExtenMin");
            this.txtLExtenMin.BackColor = System.Drawing.Color.White;
            this.txtLExtenMin.CheckInRange = false;
            this.txtLExtenMin.DataType = STM.DLayer.DataType.Double;
            this.txtLExtenMin.DefaultValue = "0";
            this.txtLExtenMin.FractionalDigits = 0;
            this.txtLExtenMin.MaxValue = "0";
            this.txtLExtenMin.MinValue = "0";
            this.txtLExtenMin.Name = "txtLExtenMin";
            this.txtLExtenMin.Resolution = 0D;
            this.txtLExtenMin.Text = "0";
            this.txtLExtenMin.Tip = null;
            this.txtLExtenMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLExtenNoise
            // 
            resources.ApplyResources(this.txtLExtenNoise, "txtLExtenNoise");
            this.txtLExtenNoise.BackColor = System.Drawing.Color.White;
            this.txtLExtenNoise.CheckInRange = false;
            this.txtLExtenNoise.DataType = STM.DLayer.DataType.Int;
            this.txtLExtenNoise.DefaultValue = "0";
            this.txtLExtenNoise.FractionalDigits = 0;
            this.txtLExtenNoise.MaxValue = "0";
            this.txtLExtenNoise.MinValue = "0";
            this.txtLExtenNoise.Name = "txtLExtenNoise";
            this.txtLExtenNoise.Resolution = 0D;
            this.txtLExtenNoise.Text = "0";
            this.txtLExtenNoise.Tip = null;
            this.txtLExtenNoise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLExtenFilter
            // 
            resources.ApplyResources(this.txtLExtenFilter, "txtLExtenFilter");
            this.txtLExtenFilter.BackColor = System.Drawing.Color.White;
            this.txtLExtenFilter.CheckInRange = false;
            this.txtLExtenFilter.DataType = STM.DLayer.DataType.Int;
            this.txtLExtenFilter.DefaultValue = "0";
            this.txtLExtenFilter.FractionalDigits = 0;
            this.txtLExtenFilter.MaxValue = "0";
            this.txtLExtenFilter.MinValue = "0";
            this.txtLExtenFilter.Name = "txtLExtenFilter";
            this.txtLExtenFilter.Resolution = 0D;
            this.txtLExtenFilter.Text = "0";
            this.txtLExtenFilter.Tip = null;
            this.txtLExtenFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtLExtenRes
            // 
            resources.ApplyResources(this.txtLExtenRes, "txtLExtenRes");
            this.txtLExtenRes.BackColor = System.Drawing.Color.White;
            this.txtLExtenRes.CheckInRange = true;
            this.txtLExtenRes.DataType = STM.DLayer.DataType.Int;
            this.txtLExtenRes.DefaultValue = "0";
            this.txtLExtenRes.FractionalDigits = 0;
            this.txtLExtenRes.MaxValue = "9";
            this.txtLExtenRes.MinValue = "0";
            this.txtLExtenRes.Name = "txtLExtenRes";
            this.txtLExtenRes.Resolution = 0D;
            this.txtLExtenRes.Text = "9";
            this.txtLExtenRes.Tip = null;
            this.txtLExtenRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // tbpTemperature
            // 
            resources.ApplyResources(this.tbpTemperature, "tbpTemperature");
            this.tbpTemperature.BackColor = System.Drawing.Color.White;
            this.tbpTemperature.Controls.Add(this.tmprUseHMI);
            this.tbpTemperature.Controls.Add(this.tmprUseDirect);
            this.tbpTemperature.Controls.Add(this.label45);
            this.tbpTemperature.Controls.Add(this.label46);
            this.tbpTemperature.Controls.Add(this.txtDiagramY2ScaleRange);
            this.tbpTemperature.Controls.Add(this.label38);
            this.tbpTemperature.Controls.Add(this.tmprMaximum);
            this.tbpTemperature.Controls.Add(this.label37);
            this.tbpTemperature.Controls.Add(this.tmprResolution);
            this.tbpTemperature.Name = "tbpTemperature";
            // 
            // tmprUseHMI
            // 
            resources.ApplyResources(this.tmprUseHMI, "tmprUseHMI");
            this.tmprUseHMI.Name = "tmprUseHMI";
            this.tmprUseHMI.UseVisualStyleBackColor = true;
            // 
            // tmprUseDirect
            // 
            resources.ApplyResources(this.tmprUseDirect, "tmprUseDirect");
            this.tmprUseDirect.Checked = true;
            this.tmprUseDirect.Name = "tmprUseDirect";
            this.tmprUseDirect.TabStop = true;
            this.tmprUseDirect.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // txtDiagramY2ScaleRange
            // 
            resources.ApplyResources(this.txtDiagramY2ScaleRange, "txtDiagramY2ScaleRange");
            this.txtDiagramY2ScaleRange.BackColor = System.Drawing.Color.White;
            this.txtDiagramY2ScaleRange.CheckInRange = false;
            this.txtDiagramY2ScaleRange.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramY2ScaleRange.DefaultValue = "0";
            this.txtDiagramY2ScaleRange.FractionalDigits = 0;
            this.txtDiagramY2ScaleRange.MaxValue = "1000";
            this.txtDiagramY2ScaleRange.MinValue = "5";
            this.txtDiagramY2ScaleRange.Name = "txtDiagramY2ScaleRange";
            this.txtDiagramY2ScaleRange.Resolution = 0D;
            this.txtDiagramY2ScaleRange.Text = "5";
            this.txtDiagramY2ScaleRange.Tip = null;
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // tmprMaximum
            // 
            resources.ApplyResources(this.tmprMaximum, "tmprMaximum");
            this.tmprMaximum.BackColor = System.Drawing.Color.White;
            this.tmprMaximum.CheckInRange = true;
            this.tmprMaximum.DataType = STM.DLayer.DataType.Int;
            this.tmprMaximum.DefaultValue = "0";
            this.tmprMaximum.FractionalDigits = 0;
            this.tmprMaximum.MaxValue = "2000";
            this.tmprMaximum.MinValue = "0";
            this.tmprMaximum.Name = "tmprMaximum";
            this.tmprMaximum.Resolution = 0D;
            this.tmprMaximum.Text = "0";
            this.tmprMaximum.Tip = null;
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // tmprResolution
            // 
            resources.ApplyResources(this.tmprResolution, "tmprResolution");
            this.tmprResolution.BackColor = System.Drawing.Color.White;
            this.tmprResolution.CheckInRange = true;
            this.tmprResolution.DataType = STM.DLayer.DataType.Int;
            this.tmprResolution.DefaultValue = "0";
            this.tmprResolution.FractionalDigits = 0;
            this.tmprResolution.MaxValue = "9";
            this.tmprResolution.MinValue = "0";
            this.tmprResolution.Name = "tmprResolution";
            this.tmprResolution.Resolution = 0D;
            this.tmprResolution.Text = "0";
            this.tmprResolution.Tip = null;
            // 
            // pBarPortChanging
            // 
            resources.ApplyResources(this.pBarPortChanging, "pBarPortChanging");
            this.pBarPortChanging.BackColor = System.Drawing.Color.Silver;
            this.pBarPortChanging.Name = "pBarPortChanging";
            // 
            // FrmInstrument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pBarPortChanging);
            this.Controls.Add(this.tbInstrument);
            this.Controls.Add(this.panelNavigation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInstrument";
            this.Tag = "523, 340";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmInstrument_Load);
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            this.tbInstrument.ResumeLayout(false);
            this.tpLoadcell.ResumeLayout(false);
            this.tpLoadcell.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadCells)).EndInit();
            this.tpLDEncoder.ResumeLayout(false);
            this.tpLDEncoder.PerformLayout();
            this.tpExtensometer.ResumeLayout(false);
            this.tpExtensometer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtensometers)).EndInit();
            this.tpStrain2.ResumeLayout(false);
            this.tpStrain2.PerformLayout();
            this.tbpTemperature.ResumeLayout(false);
            this.tbpTemperature.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.LinkLabel llStrain2;
        private System.Windows.Forms.LinkLabel llExtension;
        private System.Windows.Forms.LinkLabel lbExit;
        private System.Windows.Forms.LinkLabel llForce;
        private System.Windows.Forms.LinkLabel llStrain1;
        private System.Windows.Forms.TabControl tbInstrument;
        private System.Windows.Forms.TabPage tpLoadcell;
        private System.Windows.Forms.TabPage tpExtensometer;
        private System.Windows.Forms.TabPage tpLDEncoder;
        private System.Windows.Forms.TabPage tpStrain2;
        private System.Windows.Forms.Label lbNoLoadcell;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.DataGridView dgvLoadCells;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private NRTextBox txtLoadcellPeakNoise;
        private NRTextBox txtLoadcellFilter;
        private NRTextBox txtLoadcellRes;
        private NRTextBox txtExtenPeakNoise;
        private NRTextBox txtExtenFilter;
        private NRTextBox txtExtenRes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private NRTextBox txtExtenMax;
        private NRTextBox txtExtenMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private NRTextBox txtForceMax;
        private NRTextBox txtForceMin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private NRTextBox txtEncoderMax;
        private NRTextBox txtEncoderMin;
        private NRTextBox txtEncoderPeakNoise;
        private NRTextBox txtEncoderFilter;
        private NRTextBox txtEncoderRes;
        private System.Windows.Forms.Label label24;
        private NRTextBox txtLExtenMax;
        private NRTextBox txtLExtenMin;
        private NRTextBox txtLExtenNoise;
        private NRTextBox txtLExtenFilter;
        private NRTextBox txtLExtenRes;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lbNoExtensometer;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.DataGridView dgvExtensometers;
        private System.Windows.Forms.Label label39;
        private NRTextBox txtEncoderGain;
        private System.Windows.Forms.Label label40;
        private NRTextBox txtLExtenGauge;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private NRTextBox txtExtenGauge;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.LinkLabel llApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ProgressBar pBarPortChanging;
        private System.Windows.Forms.CheckBox cbUseExtensometer;
		private System.Windows.Forms.LinkLabel lkTemperature;
		private System.Windows.Forms.TabPage tbpTemperature;
        private System.Windows.Forms.Label label37;
        private NRTextBox tmprResolution;
        private System.Windows.Forms.Label label38;
        private NRTextBox tmprMaximum;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private NRTextBox txtDiagramY2ScaleRange;
        private System.Windows.Forms.RadioButton tmprUseHMI;
        private System.Windows.Forms.RadioButton tmprUseDirect;

        public event EventHandler<EventArgs> OnUpdateSettings;
        public event EventHandler<EventArgs> OnOperationDone;
        public event EventHandler<EventArgs> OnChangeForceBoundary;
    }
}