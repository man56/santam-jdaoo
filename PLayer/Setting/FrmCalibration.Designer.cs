using System;

namespace STM.PLayer.Setting
{
    partial class FrmCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalibration));
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.lkTemperature = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.llSave = new System.Windows.Forms.LinkLabel();
            this.llLoadcell = new System.Windows.Forms.LinkLabel();
            this.llLongExten = new System.Windows.Forms.LinkLabel();
            this.llShortExten = new System.Windows.Forms.LinkLabel();
            this.tcCalibration = new System.Windows.Forms.TabControl();
            this.tpLoadcell = new System.Windows.Forms.TabPage();
            this.pnlLoadcellCalibration = new System.Windows.Forms.Panel();
            this.txtStartForce = new STM.PLayer.NRTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStopForce = new STM.PLayer.NRTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.llCalibrateForce = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurForceRO = new STM.PLayer.NRTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.llSetForceStart = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.txtLoadCellMaXCap = new STM.PLayer.NRTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtLoadCellRO = new STM.PLayer.NRTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.rbLoadcellDirectCalibration = new System.Windows.Forms.RadioButton();
            this.llSaveForceRO = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tpShortExten = new System.Windows.Forms.TabPage();
            this.pnlShortTravelCalibration = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.llSetShortExtenStart = new System.Windows.Forms.LinkLabel();
            this.llCaribrateShortExten = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCurShortExtenRo = new STM.PLayer.NRTextBox();
            this.txtStopShortExtension = new STM.PLayer.NRTextBox();
            this.txtStartShortExtension = new STM.PLayer.NRTextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.rbShortExtenDirectCalibration = new System.Windows.Forms.RadioButton();
            this.llSaveShortExtenRO = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtShortExtenRO = new STM.PLayer.NRTextBox();
            this.txtShortExtenMaXCap = new STM.PLayer.NRTextBox();
            this.tpLongExten = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.llSetLongExtenStart = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.llSaveLongExtenGain = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.llCaribrateLongExten = new System.Windows.Forms.LinkLabel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLongExtensionCap = new STM.PLayer.NRTextBox();
            this.txtLongExtenGain = new STM.PLayer.NRTextBox();
            this.txtStartLongExtension = new STM.PLayer.NRTextBox();
            this.txtStopLongExtension = new STM.PLayer.NRTextBox();
            this.tbpTemperature = new System.Windows.Forms.TabPage();
            this.nrTemperatureGain2 = new STM.PLayer.NRTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.nrTemperatureGain1 = new STM.PLayer.NRTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.panelNavigation.SuspendLayout();
            this.tcCalibration.SuspendLayout();
            this.tpLoadcell.SuspendLayout();
            this.pnlLoadcellCalibration.SuspendLayout();
            this.tpShortExten.SuspendLayout();
            this.pnlShortTravelCalibration.SuspendLayout();
            this.tpLongExten.SuspendLayout();
            this.tbpTemperature.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavigation
            // 
            resources.ApplyResources(this.panelNavigation, "panelNavigation");
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavigation.Controls.Add(this.lkTemperature);
            this.panelNavigation.Controls.Add(this.linkLabel1);
            this.panelNavigation.Controls.Add(this.llSave);
            this.panelNavigation.Controls.Add(this.llLoadcell);
            this.panelNavigation.Controls.Add(this.llLongExten);
            this.panelNavigation.Controls.Add(this.llShortExten);
            this.panelNavigation.Name = "panelNavigation";
            // 
            // lkTemperature
            // 
            resources.ApplyResources(this.lkTemperature, "lkTemperature");
            this.lkTemperature.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkTemperature.Name = "lkTemperature";
            this.lkTemperature.TabStop = true;
            this.lkTemperature.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkTemperature_LinkClicked);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // llSave
            // 
            resources.ApplyResources(this.llSave, "llSave");
            this.llSave.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSave.Name = "llSave";
            this.llSave.TabStop = true;
            this.llSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSave_LinkClicked);
            // 
            // llLoadcell
            // 
            resources.ApplyResources(this.llLoadcell, "llLoadcell");
            this.llLoadcell.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llLoadcell.Name = "llLoadcell";
            this.llLoadcell.TabStop = true;
            this.llLoadcell.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llLoadcell.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSample_LinkClicked);
            // 
            // llLongExten
            // 
            resources.ApplyResources(this.llLongExten, "llLongExten");
            this.llLongExten.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llLongExten.Name = "llLongExten";
            this.llLongExten.TabStop = true;
            this.llLongExten.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // llShortExten
            // 
            resources.ApplyResources(this.llShortExten, "llShortExten");
            this.llShortExten.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llShortExten.Name = "llShortExten";
            this.llShortExten.TabStop = true;
            this.llShortExten.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llShortExten.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llInformation_LinkClicked);
            // 
            // tcCalibration
            // 
            resources.ApplyResources(this.tcCalibration, "tcCalibration");
            this.tcCalibration.Controls.Add(this.tpLoadcell);
            this.tcCalibration.Controls.Add(this.tpShortExten);
            this.tcCalibration.Controls.Add(this.tpLongExten);
            this.tcCalibration.Controls.Add(this.tbpTemperature);
            this.tcCalibration.Name = "tcCalibration";
            this.tcCalibration.SelectedIndex = 0;
            // 
            // tpLoadcell
            // 
            resources.ApplyResources(this.tpLoadcell, "tpLoadcell");
            this.tpLoadcell.BackColor = System.Drawing.Color.White;
            this.tpLoadcell.Controls.Add(this.pnlLoadcellCalibration);
            this.tpLoadcell.Controls.Add(this.radioButton2);
            this.tpLoadcell.Controls.Add(this.label17);
            this.tpLoadcell.Controls.Add(this.txtLoadCellMaXCap);
            this.tpLoadcell.Controls.Add(this.label22);
            this.tpLoadcell.Controls.Add(this.txtLoadCellRO);
            this.tpLoadcell.Controls.Add(this.label23);
            this.tpLoadcell.Controls.Add(this.label24);
            this.tpLoadcell.Controls.Add(this.rbLoadcellDirectCalibration);
            this.tpLoadcell.Controls.Add(this.llSaveForceRO);
            this.tpLoadcell.Controls.Add(this.label1);
            this.tpLoadcell.Name = "tpLoadcell";
            // 
            // pnlLoadcellCalibration
            // 
            resources.ApplyResources(this.pnlLoadcellCalibration, "pnlLoadcellCalibration");
            this.pnlLoadcellCalibration.Controls.Add(this.txtStartForce);
            this.pnlLoadcellCalibration.Controls.Add(this.label2);
            this.pnlLoadcellCalibration.Controls.Add(this.label3);
            this.pnlLoadcellCalibration.Controls.Add(this.txtStopForce);
            this.pnlLoadcellCalibration.Controls.Add(this.label4);
            this.pnlLoadcellCalibration.Controls.Add(this.llCalibrateForce);
            this.pnlLoadcellCalibration.Controls.Add(this.label6);
            this.pnlLoadcellCalibration.Controls.Add(this.txtCurForceRO);
            this.pnlLoadcellCalibration.Controls.Add(this.label7);
            this.pnlLoadcellCalibration.Controls.Add(this.llSetForceStart);
            this.pnlLoadcellCalibration.Controls.Add(this.label15);
            this.pnlLoadcellCalibration.Name = "pnlLoadcellCalibration";
            // 
            // txtStartForce
            // 
            resources.ApplyResources(this.txtStartForce, "txtStartForce");
            this.txtStartForce.BackColor = System.Drawing.Color.White;
            this.txtStartForce.CheckInRange = false;
            this.txtStartForce.DataType = STM.DLayer.DataType.Double;
            this.txtStartForce.DefaultValue = "0";
            this.txtStartForce.FractionalDigits = 4;
            this.txtStartForce.MaxValue = "0";
            this.txtStartForce.MinValue = "0";
            this.txtStartForce.Name = "txtStartForce";
            this.txtStartForce.Resolution = 0D;
            this.txtStartForce.Text = "1";
            this.txtStartForce.Tip = null;
            this.txtStartForce.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtStopForce
            // 
            resources.ApplyResources(this.txtStopForce, "txtStopForce");
            this.txtStopForce.BackColor = System.Drawing.Color.White;
            this.txtStopForce.CheckInRange = false;
            this.txtStopForce.DataType = STM.DLayer.DataType.Double;
            this.txtStopForce.DefaultValue = "0";
            this.txtStopForce.FractionalDigits = 4;
            this.txtStopForce.MaxValue = "0";
            this.txtStopForce.MinValue = "0";
            this.txtStopForce.Name = "txtStopForce";
            this.txtStopForce.Resolution = 0D;
            this.txtStopForce.Text = "2";
            this.txtStopForce.Tip = null;
            this.txtStopForce.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // llCalibrateForce
            // 
            resources.ApplyResources(this.llCalibrateForce, "llCalibrateForce");
            this.llCalibrateForce.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCalibrateForce.Name = "llCalibrateForce";
            this.llCalibrateForce.TabStop = true;
            this.llCalibrateForce.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCalibrateForce_LinkClicked);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtCurForceRO
            // 
            resources.ApplyResources(this.txtCurForceRO, "txtCurForceRO");
            this.txtCurForceRO.BackColor = System.Drawing.Color.White;
            this.txtCurForceRO.CheckInRange = false;
            this.txtCurForceRO.DataType = STM.DLayer.DataType.Double;
            this.txtCurForceRO.DefaultValue = "0";
            this.txtCurForceRO.FractionalDigits = 8;
            this.txtCurForceRO.MaxValue = "0";
            this.txtCurForceRO.MinValue = "0";
            this.txtCurForceRO.Name = "txtCurForceRO";
            this.txtCurForceRO.Resolution = 0D;
            this.txtCurForceRO.Text = "3";
            this.txtCurForceRO.Tip = null;
            this.txtCurForceRO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // llSetForceStart
            // 
            resources.ApplyResources(this.llSetForceStart, "llSetForceStart");
            this.llSetForceStart.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSetForceStart.Name = "llSetForceStart";
            this.llSetForceStart.TabStop = true;
            this.llSetForceStart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetForceStart_LinkClicked);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // txtLoadCellMaXCap
            // 
            resources.ApplyResources(this.txtLoadCellMaXCap, "txtLoadCellMaXCap");
            this.txtLoadCellMaXCap.BackColor = System.Drawing.Color.White;
            this.txtLoadCellMaXCap.CheckInRange = false;
            this.txtLoadCellMaXCap.DataType = STM.DLayer.DataType.Double;
            this.txtLoadCellMaXCap.DefaultValue = "0";
            this.txtLoadCellMaXCap.FractionalDigits = 4;
            this.txtLoadCellMaXCap.MaxValue = "0";
            this.txtLoadCellMaXCap.MinValue = "0";
            this.txtLoadCellMaXCap.Name = "txtLoadCellMaXCap";
            this.txtLoadCellMaXCap.Resolution = 0D;
            this.txtLoadCellMaXCap.Text = "0";
            this.txtLoadCellMaXCap.Tip = new string[] {
        "ali",
        "razmkhah shendi"};
            this.txtLoadCellMaXCap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // txtLoadCellRO
            // 
            resources.ApplyResources(this.txtLoadCellRO, "txtLoadCellRO");
            this.txtLoadCellRO.BackColor = System.Drawing.Color.White;
            this.txtLoadCellRO.CheckInRange = false;
            this.txtLoadCellRO.DataType = STM.DLayer.DataType.Double;
            this.txtLoadCellRO.DefaultValue = "0";
            this.txtLoadCellRO.FractionalDigits = 8;
            this.txtLoadCellRO.MaxValue = "0";
            this.txtLoadCellRO.MinValue = "0";
            this.txtLoadCellRO.Name = "txtLoadCellRO";
            this.txtLoadCellRO.Resolution = 0D;
            this.txtLoadCellRO.Text = "0";
            this.txtLoadCellRO.Tip = null;
            this.txtLoadCellRO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // rbLoadcellDirectCalibration
            // 
            resources.ApplyResources(this.rbLoadcellDirectCalibration, "rbLoadcellDirectCalibration");
            this.rbLoadcellDirectCalibration.Checked = true;
            this.rbLoadcellDirectCalibration.Name = "rbLoadcellDirectCalibration";
            this.rbLoadcellDirectCalibration.TabStop = true;
            this.rbLoadcellDirectCalibration.UseVisualStyleBackColor = true;
            this.rbLoadcellDirectCalibration.CheckedChanged += new System.EventHandler(this.rbLoadcellDirectCalibration_CheckedChanged);
            // 
            // llSaveForceRO
            // 
            resources.ApplyResources(this.llSaveForceRO, "llSaveForceRO");
            this.llSaveForceRO.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSaveForceRO.Name = "llSaveForceRO";
            this.llSaveForceRO.TabStop = true;
            this.llSaveForceRO.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSaveForceRO_LinkClicked);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tpShortExten
            // 
            resources.ApplyResources(this.tpShortExten, "tpShortExten");
            this.tpShortExten.BackColor = System.Drawing.Color.White;
            this.tpShortExten.Controls.Add(this.pnlShortTravelCalibration);
            this.tpShortExten.Controls.Add(this.radioButton3);
            this.tpShortExten.Controls.Add(this.label25);
            this.tpShortExten.Controls.Add(this.label26);
            this.tpShortExten.Controls.Add(this.label27);
            this.tpShortExten.Controls.Add(this.label28);
            this.tpShortExten.Controls.Add(this.rbShortExtenDirectCalibration);
            this.tpShortExten.Controls.Add(this.llSaveShortExtenRO);
            this.tpShortExten.Controls.Add(this.label14);
            this.tpShortExten.Controls.Add(this.txtShortExtenRO);
            this.tpShortExten.Controls.Add(this.txtShortExtenMaXCap);
            this.tpShortExten.Name = "tpShortExten";
            // 
            // pnlShortTravelCalibration
            // 
            resources.ApplyResources(this.pnlShortTravelCalibration, "pnlShortTravelCalibration");
            this.pnlShortTravelCalibration.Controls.Add(this.llCaribrateShortExten);
            this.pnlShortTravelCalibration.Controls.Add(this.label13);
            this.pnlShortTravelCalibration.Controls.Add(this.label9);
            this.pnlShortTravelCalibration.Controls.Add(this.label12);
            this.pnlShortTravelCalibration.Controls.Add(this.label11);
            this.pnlShortTravelCalibration.Controls.Add(this.llSetShortExtenStart);
            this.pnlShortTravelCalibration.Controls.Add(this.label5);
            this.pnlShortTravelCalibration.Controls.Add(this.label8);
            this.pnlShortTravelCalibration.Controls.Add(this.txtCurShortExtenRo);
            this.pnlShortTravelCalibration.Controls.Add(this.txtStopShortExtension);
            this.pnlShortTravelCalibration.Controls.Add(this.txtStartShortExtension);
            this.pnlShortTravelCalibration.Name = "pnlShortTravelCalibration";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // llSetShortExtenStart
            // 
            resources.ApplyResources(this.llSetShortExtenStart, "llSetShortExtenStart");
            this.llSetShortExtenStart.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSetShortExtenStart.Name = "llSetShortExtenStart";
            this.llSetShortExtenStart.TabStop = true;
            this.llSetShortExtenStart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetShortExtenStart_LinkClicked);
            // 
            // llCaribrateShortExten
            // 
            resources.ApplyResources(this.llCaribrateShortExten, "llCaribrateShortExten");
            this.llCaribrateShortExten.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCaribrateShortExten.Name = "llCaribrateShortExten";
            this.llCaribrateShortExten.TabStop = true;
            this.llCaribrateShortExten.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCaribrateShortExten_LinkClicked);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtCurShortExtenRo
            // 
            resources.ApplyResources(this.txtCurShortExtenRo, "txtCurShortExtenRo");
            this.txtCurShortExtenRo.BackColor = System.Drawing.Color.White;
            this.txtCurShortExtenRo.CheckInRange = false;
            this.txtCurShortExtenRo.DataType = STM.DLayer.DataType.Double;
            this.txtCurShortExtenRo.DefaultValue = "0";
            this.txtCurShortExtenRo.FractionalDigits = 8;
            this.txtCurShortExtenRo.MaxValue = "0";
            this.txtCurShortExtenRo.MinValue = "0";
            this.txtCurShortExtenRo.Name = "txtCurShortExtenRo";
            this.txtCurShortExtenRo.Resolution = 0D;
            this.txtCurShortExtenRo.Text = "0";
            this.txtCurShortExtenRo.Tip = null;
            // 
            // txtStopShortExtension
            // 
            resources.ApplyResources(this.txtStopShortExtension, "txtStopShortExtension");
            this.txtStopShortExtension.BackColor = System.Drawing.Color.White;
            this.txtStopShortExtension.CheckInRange = false;
            this.txtStopShortExtension.DataType = STM.DLayer.DataType.Double;
            this.txtStopShortExtension.DefaultValue = "0";
            this.txtStopShortExtension.FractionalDigits = 4;
            this.txtStopShortExtension.MaxValue = "0";
            this.txtStopShortExtension.MinValue = "0";
            this.txtStopShortExtension.Name = "txtStopShortExtension";
            this.txtStopShortExtension.Resolution = 0D;
            this.txtStopShortExtension.Text = "0";
            this.txtStopShortExtension.Tip = null;
            // 
            // txtStartShortExtension
            // 
            resources.ApplyResources(this.txtStartShortExtension, "txtStartShortExtension");
            this.txtStartShortExtension.BackColor = System.Drawing.Color.White;
            this.txtStartShortExtension.CheckInRange = false;
            this.txtStartShortExtension.DataType = STM.DLayer.DataType.Double;
            this.txtStartShortExtension.DefaultValue = "0";
            this.txtStartShortExtension.FractionalDigits = 4;
            this.txtStartShortExtension.MaxValue = "0";
            this.txtStartShortExtension.MinValue = "0";
            this.txtStartShortExtension.Name = "txtStartShortExtension";
            this.txtStartShortExtension.Resolution = 0D;
            this.txtStartShortExtension.Text = "0";
            this.txtStartShortExtension.Tip = null;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
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
            // rbShortExtenDirectCalibration
            // 
            resources.ApplyResources(this.rbShortExtenDirectCalibration, "rbShortExtenDirectCalibration");
            this.rbShortExtenDirectCalibration.Checked = true;
            this.rbShortExtenDirectCalibration.Name = "rbShortExtenDirectCalibration";
            this.rbShortExtenDirectCalibration.TabStop = true;
            this.rbShortExtenDirectCalibration.UseVisualStyleBackColor = true;
            this.rbShortExtenDirectCalibration.CheckedChanged += new System.EventHandler(this.rbShortExtenDirectCalibration_CheckedChanged);
            // 
            // llSaveShortExtenRO
            // 
            resources.ApplyResources(this.llSaveShortExtenRO, "llSaveShortExtenRO");
            this.llSaveShortExtenRO.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSaveShortExtenRO.Name = "llSaveShortExtenRO";
            this.llSaveShortExtenRO.TabStop = true;
            this.llSaveShortExtenRO.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSaveShortExtenRO_LinkClicked);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtShortExtenRO
            // 
            resources.ApplyResources(this.txtShortExtenRO, "txtShortExtenRO");
            this.txtShortExtenRO.BackColor = System.Drawing.Color.White;
            this.txtShortExtenRO.CheckInRange = false;
            this.txtShortExtenRO.DataType = STM.DLayer.DataType.Double;
            this.txtShortExtenRO.DefaultValue = "0";
            this.txtShortExtenRO.FractionalDigits = 8;
            this.txtShortExtenRO.MaxValue = "0";
            this.txtShortExtenRO.MinValue = "0";
            this.txtShortExtenRO.Name = "txtShortExtenRO";
            this.txtShortExtenRO.Resolution = 0D;
            this.txtShortExtenRO.Text = "0";
            this.txtShortExtenRO.Tip = null;
            this.txtShortExtenRO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtShortExtenMaXCap
            // 
            resources.ApplyResources(this.txtShortExtenMaXCap, "txtShortExtenMaXCap");
            this.txtShortExtenMaXCap.BackColor = System.Drawing.Color.White;
            this.txtShortExtenMaXCap.CheckInRange = false;
            this.txtShortExtenMaXCap.DataType = STM.DLayer.DataType.Double;
            this.txtShortExtenMaXCap.DefaultValue = "0";
            this.txtShortExtenMaXCap.FractionalDigits = 4;
            this.txtShortExtenMaXCap.MaxValue = "0";
            this.txtShortExtenMaXCap.MinValue = "0";
            this.txtShortExtenMaXCap.Name = "txtShortExtenMaXCap";
            this.txtShortExtenMaXCap.Resolution = 0D;
            this.txtShortExtenMaXCap.Text = "0";
            this.txtShortExtenMaXCap.Tip = new string[] {
        "ali",
        "razmkhah shendi"};
            this.txtShortExtenMaXCap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // tpLongExten
            // 
            resources.ApplyResources(this.tpLongExten, "tpLongExten");
            this.tpLongExten.BackColor = System.Drawing.Color.White;
            this.tpLongExten.Controls.Add(this.label30);
            this.tpLongExten.Controls.Add(this.label29);
            this.tpLongExten.Controls.Add(this.llSetLongExtenStart);
            this.tpLongExten.Controls.Add(this.label10);
            this.tpLongExten.Controls.Add(this.llSaveLongExtenGain);
            this.tpLongExten.Controls.Add(this.label16);
            this.tpLongExten.Controls.Add(this.llCaribrateLongExten);
            this.tpLongExten.Controls.Add(this.label18);
            this.tpLongExten.Controls.Add(this.label19);
            this.tpLongExten.Controls.Add(this.label20);
            this.tpLongExten.Controls.Add(this.label21);
            this.tpLongExten.Controls.Add(this.txtLongExtensionCap);
            this.tpLongExten.Controls.Add(this.txtLongExtenGain);
            this.tpLongExten.Controls.Add(this.txtStartLongExtension);
            this.tpLongExten.Controls.Add(this.txtStopLongExtension);
            this.tpLongExten.Name = "tpLongExten";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // llSetLongExtenStart
            // 
            resources.ApplyResources(this.llSetLongExtenStart, "llSetLongExtenStart");
            this.llSetLongExtenStart.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSetLongExtenStart.Name = "llSetLongExtenStart";
            this.llSetLongExtenStart.TabStop = true;
            this.llSetLongExtenStart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetLongExtenStart_LinkClicked);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // llSaveLongExtenGain
            // 
            resources.ApplyResources(this.llSaveLongExtenGain, "llSaveLongExtenGain");
            this.llSaveLongExtenGain.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSaveLongExtenGain.Name = "llSaveLongExtenGain";
            this.llSaveLongExtenGain.TabStop = true;
            this.llSaveLongExtenGain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSaveLongExtenGain_LinkClicked);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // llCaribrateLongExten
            // 
            resources.ApplyResources(this.llCaribrateLongExten, "llCaribrateLongExten");
            this.llCaribrateLongExten.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCaribrateLongExten.Name = "llCaribrateLongExten";
            this.llCaribrateLongExten.TabStop = true;
            this.llCaribrateLongExten.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCaribrateLongExten_LinkClicked);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
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
            // txtLongExtensionCap
            // 
            resources.ApplyResources(this.txtLongExtensionCap, "txtLongExtensionCap");
            this.txtLongExtensionCap.BackColor = System.Drawing.Color.White;
            this.txtLongExtensionCap.CheckInRange = false;
            this.txtLongExtensionCap.DataType = STM.DLayer.DataType.Double;
            this.txtLongExtensionCap.DefaultValue = "0";
            this.txtLongExtensionCap.FractionalDigits = 4;
            this.txtLongExtensionCap.MaxValue = "0";
            this.txtLongExtensionCap.MinValue = "0";
            this.txtLongExtensionCap.Name = "txtLongExtensionCap";
            this.txtLongExtensionCap.Resolution = 0D;
            this.txtLongExtensionCap.Text = "0";
            this.txtLongExtensionCap.Tip = null;
            // 
            // txtLongExtenGain
            // 
            resources.ApplyResources(this.txtLongExtenGain, "txtLongExtenGain");
            this.txtLongExtenGain.BackColor = System.Drawing.Color.White;
            this.txtLongExtenGain.CheckInRange = false;
            this.txtLongExtenGain.DataType = STM.DLayer.DataType.Double;
            this.txtLongExtenGain.DefaultValue = "0";
            this.txtLongExtenGain.FractionalDigits = 8;
            this.txtLongExtenGain.MaxValue = "0";
            this.txtLongExtenGain.MinValue = "0";
            this.txtLongExtenGain.Name = "txtLongExtenGain";
            this.txtLongExtenGain.Resolution = 0D;
            this.txtLongExtenGain.Text = "0";
            this.txtLongExtenGain.Tip = null;
            // 
            // txtStartLongExtension
            // 
            resources.ApplyResources(this.txtStartLongExtension, "txtStartLongExtension");
            this.txtStartLongExtension.BackColor = System.Drawing.Color.White;
            this.txtStartLongExtension.CheckInRange = false;
            this.txtStartLongExtension.DataType = STM.DLayer.DataType.Double;
            this.txtStartLongExtension.DefaultValue = "0";
            this.txtStartLongExtension.FractionalDigits = 4;
            this.txtStartLongExtension.MaxValue = "0";
            this.txtStartLongExtension.MinValue = "0";
            this.txtStartLongExtension.Name = "txtStartLongExtension";
            this.txtStartLongExtension.Resolution = 0D;
            this.txtStartLongExtension.Text = "0";
            this.txtStartLongExtension.Tip = null;
            // 
            // txtStopLongExtension
            // 
            resources.ApplyResources(this.txtStopLongExtension, "txtStopLongExtension");
            this.txtStopLongExtension.BackColor = System.Drawing.Color.White;
            this.txtStopLongExtension.CheckInRange = false;
            this.txtStopLongExtension.DataType = STM.DLayer.DataType.Double;
            this.txtStopLongExtension.DefaultValue = "0";
            this.txtStopLongExtension.FractionalDigits = 4;
            this.txtStopLongExtension.MaxValue = "0";
            this.txtStopLongExtension.MinValue = "0";
            this.txtStopLongExtension.Name = "txtStopLongExtension";
            this.txtStopLongExtension.Resolution = 0D;
            this.txtStopLongExtension.Text = "0";
            this.txtStopLongExtension.Tip = null;
            // 
            // tbpTemperature
            // 
            resources.ApplyResources(this.tbpTemperature, "tbpTemperature");
            this.tbpTemperature.BackColor = System.Drawing.Color.White;
            this.tbpTemperature.Controls.Add(this.nrTemperatureGain2);
            this.tbpTemperature.Controls.Add(this.label31);
            this.tbpTemperature.Controls.Add(this.nrTemperatureGain1);
            this.tbpTemperature.Controls.Add(this.label33);
            this.tbpTemperature.Name = "tbpTemperature";
            // 
            // nrTemperatureGain2
            // 
            resources.ApplyResources(this.nrTemperatureGain2, "nrTemperatureGain2");
            this.nrTemperatureGain2.BackColor = System.Drawing.Color.White;
            this.nrTemperatureGain2.CheckInRange = false;
            this.nrTemperatureGain2.DataType = STM.DLayer.DataType.Double;
            this.nrTemperatureGain2.DefaultValue = "0";
            this.nrTemperatureGain2.FractionalDigits = 8;
            this.nrTemperatureGain2.MaxValue = "0";
            this.nrTemperatureGain2.MinValue = "0";
            this.nrTemperatureGain2.Name = "nrTemperatureGain2";
            this.nrTemperatureGain2.Resolution = 0D;
            this.nrTemperatureGain2.Text = "0";
            this.nrTemperatureGain2.Tip = null;
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // nrTemperatureGain1
            // 
            resources.ApplyResources(this.nrTemperatureGain1, "nrTemperatureGain1");
            this.nrTemperatureGain1.BackColor = System.Drawing.Color.White;
            this.nrTemperatureGain1.CheckInRange = false;
            this.nrTemperatureGain1.DataType = STM.DLayer.DataType.Double;
            this.nrTemperatureGain1.DefaultValue = "0";
            this.nrTemperatureGain1.FractionalDigits = 8;
            this.nrTemperatureGain1.MaxValue = "0";
            this.nrTemperatureGain1.MinValue = "0";
            this.nrTemperatureGain1.Name = "nrTemperatureGain1";
            this.nrTemperatureGain1.Resolution = 0D;
            this.nrTemperatureGain1.Text = "0";
            this.nrTemperatureGain1.Tip = null;
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // FrmCalibration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.tcCalibration);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCalibration";
            this.Tag = "523, 340";
            this.Load += new System.EventHandler(this.FrmCalibration_Load);
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            this.tcCalibration.ResumeLayout(false);
            this.tpLoadcell.ResumeLayout(false);
            this.tpLoadcell.PerformLayout();
            this.pnlLoadcellCalibration.ResumeLayout(false);
            this.pnlLoadcellCalibration.PerformLayout();
            this.tpShortExten.ResumeLayout(false);
            this.tpShortExten.PerformLayout();
            this.pnlShortTravelCalibration.ResumeLayout(false);
            this.pnlShortTravelCalibration.PerformLayout();
            this.tpLongExten.ResumeLayout(false);
            this.tpLongExten.PerformLayout();
            this.tbpTemperature.ResumeLayout(false);
            this.tbpTemperature.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.LinkLabel llLoadcell;
        private System.Windows.Forms.LinkLabel llLongExten;
        private System.Windows.Forms.LinkLabel llShortExten;
        private System.Windows.Forms.TabControl tcCalibration;
        private System.Windows.Forms.TabPage tpLoadcell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpShortExten;
        private System.Windows.Forms.LinkLabel llSaveForceRO;
        private System.Windows.Forms.Label label7;
        private NRTextBox txtCurForceRO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel llCalibrateForce;
        private System.Windows.Forms.Label label4;
        private NRTextBox txtStopForce;
        private System.Windows.Forms.LinkLabel llSaveShortExtenRO;
        private System.Windows.Forms.Label label8;
        private NRTextBox txtCurShortExtenRo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel llCaribrateShortExten;
        private System.Windows.Forms.Label label11;
        private NRTextBox txtStopShortExtension;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tpLongExten;
        private System.Windows.Forms.LinkLabel llSaveLongExtenGain;
        private NRTextBox txtLongExtenGain;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel llCaribrateLongExten;
        private System.Windows.Forms.Label label18;
        private NRTextBox txtStopLongExtension;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private NRTextBox txtStartForce;
        private System.Windows.Forms.Label label5;
        private NRTextBox txtStartShortExtension;
        private System.Windows.Forms.Label label10;
        private NRTextBox txtStartLongExtension;
        private System.Windows.Forms.LinkLabel llSetForceStart;
        private System.Windows.Forms.LinkLabel llSetShortExtenStart;
        private System.Windows.Forms.LinkLabel llSetLongExtenStart;
        private System.Windows.Forms.RadioButton rbLoadcellDirectCalibration;
        private System.Windows.Forms.Label label17;
        private NRTextBox txtLoadCellMaXCap;
        private System.Windows.Forms.Label label22;
        private NRTextBox txtLoadCellRO;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rbShortExtenDirectCalibration;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label25;
        private NRTextBox txtShortExtenMaXCap;
        private System.Windows.Forms.Label label26;
        private NRTextBox txtShortExtenRO;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel pnlLoadcellCalibration;
        private System.Windows.Forms.Panel pnlShortTravelCalibration;
        private System.Windows.Forms.LinkLabel llSave;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private NRTextBox txtLongExtensionCap;
		private System.Windows.Forms.TabPage tbpTemperature;
		private System.Windows.Forms.LinkLabel lkTemperature;
        private NRTextBox nrTemperatureGain1;
        private System.Windows.Forms.Label label33;
        private NRTextBox nrTemperatureGain2;
        private System.Windows.Forms.Label label31;

        public event EventHandler<EventArgs> OnOperationDone;
    }
}