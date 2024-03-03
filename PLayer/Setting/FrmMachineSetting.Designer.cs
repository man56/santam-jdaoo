using System;

namespace STM.PLayer.Setting
{
    partial class FrmMachineSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMachineSetting));
            this.tbMachineSetting = new System.Windows.Forms.TabControl();
            this.tpControl = new System.Windows.Forms.TabPage();
            this.panleSpeedSettingSelector = new System.Windows.Forms.Panel();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tcSpeedControl = new System.Windows.Forms.TabControl();
            this.tpPID = new System.Windows.Forms.TabPage();
            this.txtD = new STM.PLayer.NRTextBox();
            this.txtI = new STM.PLayer.NRTextBox();
            this.txtP = new STM.PLayer.NRTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tpExtenCtrl = new System.Windows.Forms.TabPage();
            this.label45 = new System.Windows.Forms.Label();
            this.txtExtenTor = new STM.PLayer.NRTextBox();
            this.txtKed = new STM.PLayer.NRTextBox();
            this.txtKei = new STM.PLayer.NRTextBox();
            this.txtKep = new STM.PLayer.NRTextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tpForceCtrl = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.txtForceTor = new STM.PLayer.NRTextBox();
            this.txtKfd = new STM.PLayer.NRTextBox();
            this.txtKfi = new STM.PLayer.NRTextBox();
            this.txtKfp = new STM.PLayer.NRTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tpStrainCtrl = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.txtStrainTor = new STM.PLayer.NRTextBox();
            this.txtKsd = new STM.PLayer.NRTextBox();
            this.txtKsi = new STM.PLayer.NRTextBox();
            this.txtKsp = new STM.PLayer.NRTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtVel = new STM.PLayer.NRTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtMTimeOut = new STM.PLayer.NRTextBox();
            this.txtMCMD = new STM.PLayer.NRTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtMOffset = new STM.PLayer.NRTextBox();
            this.txtMStep = new STM.PLayer.NRTextBox();
            this.txtMax = new STM.PLayer.NRTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tpCrossHead = new System.Windows.Forms.TabPage();
            this.OptionElectroHydrolic = new System.Windows.Forms.CheckBox();
            this.cbActuator = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCrsMin = new STM.PLayer.NRTextBox();
            this.txtCrsMax = new STM.PLayer.NRTextBox();
            this.txtCrsInc = new STM.PLayer.NRTextBox();
            this.txtCrsLowJog = new STM.PLayer.NRTextBox();
            this.txtCrsHiJog = new STM.PLayer.NRTextBox();
            this.tpHardware = new System.Windows.Forms.TabPage();
            this.pBarPortChanging = new System.Windows.Forms.ProgressBar();
            this.txtPlotDecimationRatio = new STM.PLayer.NRTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.llFds = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtReadInterval = new STM.PLayer.NRTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.llApply = new System.Windows.Forms.LinkLabel();
            this.llCancel = new System.Windows.Forms.LinkLabel();
            this.llCrosshead = new System.Windows.Forms.LinkLabel();
            this.llHardware = new System.Windows.Forms.LinkLabel();
            this.llControl = new System.Windows.Forms.LinkLabel();
            this.tbMachineSetting.SuspendLayout();
            this.tpControl.SuspendLayout();
            this.panleSpeedSettingSelector.SuspendLayout();
            this.tcSpeedControl.SuspendLayout();
            this.tpPID.SuspendLayout();
            this.tpExtenCtrl.SuspendLayout();
            this.tpForceCtrl.SuspendLayout();
            this.tpStrainCtrl.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tpCrossHead.SuspendLayout();
            this.tpHardware.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMachineSetting
            // 
            resources.ApplyResources(this.tbMachineSetting, "tbMachineSetting");
            this.tbMachineSetting.Controls.Add(this.tpControl);
            this.tbMachineSetting.Controls.Add(this.tpCrossHead);
            this.tbMachineSetting.Controls.Add(this.tpHardware);
            this.tbMachineSetting.Multiline = true;
            this.tbMachineSetting.Name = "tbMachineSetting";
            this.tbMachineSetting.SelectedIndex = 0;
            this.tbMachineSetting.SelectedIndexChanged += new System.EventHandler(this.tbMachineSetting_SelectedIndexChanged);
            // 
            // tpControl
            // 
            resources.ApplyResources(this.tpControl, "tpControl");
            this.tpControl.BackColor = System.Drawing.Color.White;
            this.tpControl.Controls.Add(this.panleSpeedSettingSelector);
            this.tpControl.Controls.Add(this.tcSpeedControl);
            this.tpControl.Name = "tpControl";
            // 
            // panleSpeedSettingSelector
            // 
            resources.ApplyResources(this.panleSpeedSettingSelector, "panleSpeedSettingSelector");
            this.panleSpeedSettingSelector.BackColor = System.Drawing.Color.White;
            this.panleSpeedSettingSelector.Controls.Add(this.cbSpeed);
            this.panleSpeedSettingSelector.Controls.Add(this.label38);
            this.panleSpeedSettingSelector.Controls.Add(this.label37);
            this.panleSpeedSettingSelector.Name = "panleSpeedSettingSelector";
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
            resources.GetString("cbSpeed.Items2"),
            resources.GetString("cbSpeed.Items3"),
            resources.GetString("cbSpeed.Items4"),
            resources.GetString("cbSpeed.Items5")});
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.SelectedIndexChanged += new System.EventHandler(this.cbSpeed_SelectedIndexChanged);
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // tcSpeedControl
            // 
            resources.ApplyResources(this.tcSpeedControl, "tcSpeedControl");
            this.tcSpeedControl.Controls.Add(this.tpPID);
            this.tcSpeedControl.Controls.Add(this.tpExtenCtrl);
            this.tcSpeedControl.Controls.Add(this.tpForceCtrl);
            this.tcSpeedControl.Controls.Add(this.tpStrainCtrl);
            this.tcSpeedControl.Controls.Add(this.tabPage5);
            this.tcSpeedControl.Controls.Add(this.tabPage6);
            this.tcSpeedControl.Multiline = true;
            this.tcSpeedControl.Name = "tcSpeedControl";
            this.tcSpeedControl.SelectedIndex = 0;
            // 
            // tpPID
            // 
            resources.ApplyResources(this.tpPID, "tpPID");
            this.tpPID.BackColor = System.Drawing.Color.White;
            this.tpPID.Controls.Add(this.txtD);
            this.tpPID.Controls.Add(this.txtI);
            this.tpPID.Controls.Add(this.txtP);
            this.tpPID.Controls.Add(this.label23);
            this.tpPID.Controls.Add(this.label24);
            this.tpPID.Controls.Add(this.label30);
            this.tpPID.Name = "tpPID";
            // 
            // txtD
            // 
            resources.ApplyResources(this.txtD, "txtD");
            this.txtD.BackColor = System.Drawing.Color.White;
            this.txtD.CheckInRange = false;
            this.txtD.DataType = STM.DLayer.DataType.Double;
            this.txtD.DefaultValue = "0";
            this.txtD.FractionalDigits = 0;
            this.txtD.MaxValue = "0";
            this.txtD.MinValue = "0";
            this.txtD.Name = "txtD";
            this.txtD.Resolution = 0D;
            this.txtD.Text = "0";
            this.txtD.Tip = null;
            this.txtD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtI
            // 
            resources.ApplyResources(this.txtI, "txtI");
            this.txtI.BackColor = System.Drawing.Color.White;
            this.txtI.CheckInRange = false;
            this.txtI.DataType = STM.DLayer.DataType.Double;
            this.txtI.DefaultValue = "0";
            this.txtI.FractionalDigits = 0;
            this.txtI.MaxValue = "0";
            this.txtI.MinValue = "0";
            this.txtI.Name = "txtI";
            this.txtI.Resolution = 0D;
            this.txtI.Text = "0";
            this.txtI.Tip = null;
            this.txtI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtP
            // 
            resources.ApplyResources(this.txtP, "txtP");
            this.txtP.BackColor = System.Drawing.Color.White;
            this.txtP.CheckInRange = false;
            this.txtP.DataType = STM.DLayer.DataType.Double;
            this.txtP.DefaultValue = "0";
            this.txtP.FractionalDigits = 0;
            this.txtP.MaxValue = "0";
            this.txtP.MinValue = "0";
            this.txtP.Name = "txtP";
            this.txtP.Resolution = 0D;
            this.txtP.Text = "0";
            this.txtP.Tip = null;
            this.txtP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // tpExtenCtrl
            // 
            resources.ApplyResources(this.tpExtenCtrl, "tpExtenCtrl");
            this.tpExtenCtrl.BackColor = System.Drawing.Color.White;
            this.tpExtenCtrl.Controls.Add(this.label45);
            this.tpExtenCtrl.Controls.Add(this.txtExtenTor);
            this.tpExtenCtrl.Controls.Add(this.txtKed);
            this.tpExtenCtrl.Controls.Add(this.txtKei);
            this.tpExtenCtrl.Controls.Add(this.txtKep);
            this.tpExtenCtrl.Controls.Add(this.label51);
            this.tpExtenCtrl.Controls.Add(this.label52);
            this.tpExtenCtrl.Controls.Add(this.label53);
            this.tpExtenCtrl.Controls.Add(this.label54);
            this.tpExtenCtrl.Name = "tpExtenCtrl";
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
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
            this.txtExtenTor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKei.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label51
            // 
            resources.ApplyResources(this.label51, "label51");
            this.label51.Name = "label51";
            // 
            // label52
            // 
            resources.ApplyResources(this.label52, "label52");
            this.label52.Name = "label52";
            // 
            // label53
            // 
            resources.ApplyResources(this.label53, "label53");
            this.label53.Name = "label53";
            // 
            // label54
            // 
            resources.ApplyResources(this.label54, "label54");
            this.label54.Name = "label54";
            // 
            // tpForceCtrl
            // 
            resources.ApplyResources(this.tpForceCtrl, "tpForceCtrl");
            this.tpForceCtrl.BackColor = System.Drawing.Color.White;
            this.tpForceCtrl.Controls.Add(this.label15);
            this.tpForceCtrl.Controls.Add(this.txtForceTor);
            this.tpForceCtrl.Controls.Add(this.txtKfd);
            this.tpForceCtrl.Controls.Add(this.txtKfi);
            this.tpForceCtrl.Controls.Add(this.txtKfp);
            this.tpForceCtrl.Controls.Add(this.label16);
            this.tpForceCtrl.Controls.Add(this.label17);
            this.tpForceCtrl.Controls.Add(this.label19);
            this.tpForceCtrl.Controls.Add(this.label20);
            this.tpForceCtrl.Name = "tpForceCtrl";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
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
            this.txtForceTor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKfd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKfi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKfp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
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
            // tpStrainCtrl
            // 
            resources.ApplyResources(this.tpStrainCtrl, "tpStrainCtrl");
            this.tpStrainCtrl.BackColor = System.Drawing.Color.White;
            this.tpStrainCtrl.Controls.Add(this.label21);
            this.tpStrainCtrl.Controls.Add(this.txtStrainTor);
            this.tpStrainCtrl.Controls.Add(this.txtKsd);
            this.tpStrainCtrl.Controls.Add(this.txtKsi);
            this.tpStrainCtrl.Controls.Add(this.txtKsp);
            this.tpStrainCtrl.Controls.Add(this.label22);
            this.tpStrainCtrl.Controls.Add(this.label25);
            this.tpStrainCtrl.Controls.Add(this.label26);
            this.tpStrainCtrl.Controls.Add(this.label27);
            this.tpStrainCtrl.Name = "tpStrainCtrl";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
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
            this.txtStrainTor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKsd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKsi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
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
            this.txtKsp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
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
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.txtVel);
            this.tabPage5.Controls.Add(this.label34);
            this.tabPage5.Controls.Add(this.txtMTimeOut);
            this.tabPage5.Controls.Add(this.txtMCMD);
            this.tabPage5.Controls.Add(this.label31);
            this.tabPage5.Controls.Add(this.label32);
            this.tabPage5.Controls.Add(this.label33);
            this.tabPage5.Name = "tabPage5";
            // 
            // txtVel
            // 
            resources.ApplyResources(this.txtVel, "txtVel");
            this.txtVel.BackColor = System.Drawing.Color.White;
            this.txtVel.CheckInRange = false;
            this.txtVel.DataType = STM.DLayer.DataType.Double;
            this.txtVel.DefaultValue = "0";
            this.txtVel.FractionalDigits = 0;
            this.txtVel.MaxValue = "0";
            this.txtVel.MinValue = "0";
            this.txtVel.Name = "txtVel";
            this.txtVel.Resolution = 0D;
            this.txtVel.Text = "0";
            this.txtVel.Tip = null;
            this.txtVel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // txtMTimeOut
            // 
            resources.ApplyResources(this.txtMTimeOut, "txtMTimeOut");
            this.txtMTimeOut.BackColor = System.Drawing.Color.White;
            this.txtMTimeOut.CheckInRange = false;
            this.txtMTimeOut.DataType = STM.DLayer.DataType.Double;
            this.txtMTimeOut.DefaultValue = "0";
            this.txtMTimeOut.FractionalDigits = 0;
            this.txtMTimeOut.MaxValue = "0";
            this.txtMTimeOut.MinValue = "0";
            this.txtMTimeOut.Name = "txtMTimeOut";
            this.txtMTimeOut.Resolution = 0D;
            this.txtMTimeOut.Text = "0";
            this.txtMTimeOut.Tip = null;
            this.txtMTimeOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtMCMD
            // 
            resources.ApplyResources(this.txtMCMD, "txtMCMD");
            this.txtMCMD.BackColor = System.Drawing.Color.White;
            this.txtMCMD.CheckInRange = false;
            this.txtMCMD.DataType = STM.DLayer.DataType.Double;
            this.txtMCMD.DefaultValue = "0";
            this.txtMCMD.FractionalDigits = 0;
            this.txtMCMD.MaxValue = "0";
            this.txtMCMD.MinValue = "0";
            this.txtMCMD.Name = "txtMCMD";
            this.txtMCMD.Resolution = 0D;
            this.txtMCMD.Text = "0";
            this.txtMCMD.Tip = null;
            this.txtMCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // tabPage6
            // 
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.BackColor = System.Drawing.Color.White;
            this.tabPage6.Controls.Add(this.txtMOffset);
            this.tabPage6.Controls.Add(this.txtMStep);
            this.tabPage6.Controls.Add(this.txtMax);
            this.tabPage6.Controls.Add(this.label29);
            this.tabPage6.Controls.Add(this.label35);
            this.tabPage6.Controls.Add(this.label36);
            this.tabPage6.Name = "tabPage6";
            // 
            // txtMOffset
            // 
            resources.ApplyResources(this.txtMOffset, "txtMOffset");
            this.txtMOffset.BackColor = System.Drawing.Color.White;
            this.txtMOffset.CheckInRange = false;
            this.txtMOffset.DataType = STM.DLayer.DataType.Double;
            this.txtMOffset.DefaultValue = "0";
            this.txtMOffset.FractionalDigits = 0;
            this.txtMOffset.MaxValue = "0";
            this.txtMOffset.MinValue = "0";
            this.txtMOffset.Name = "txtMOffset";
            this.txtMOffset.Resolution = 0D;
            this.txtMOffset.Text = "0";
            this.txtMOffset.Tip = null;
            this.txtMOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtMStep
            // 
            resources.ApplyResources(this.txtMStep, "txtMStep");
            this.txtMStep.BackColor = System.Drawing.Color.White;
            this.txtMStep.CheckInRange = false;
            this.txtMStep.DataType = STM.DLayer.DataType.Double;
            this.txtMStep.DefaultValue = "0";
            this.txtMStep.FractionalDigits = 0;
            this.txtMStep.MaxValue = "0";
            this.txtMStep.MinValue = "0";
            this.txtMStep.Name = "txtMStep";
            this.txtMStep.Resolution = 0D;
            this.txtMStep.Text = "0";
            this.txtMStep.Tip = null;
            this.txtMStep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtMax
            // 
            resources.ApplyResources(this.txtMax, "txtMax");
            this.txtMax.BackColor = System.Drawing.Color.White;
            this.txtMax.CheckInRange = false;
            this.txtMax.DataType = STM.DLayer.DataType.Double;
            this.txtMax.DefaultValue = "0";
            this.txtMax.FractionalDigits = 0;
            this.txtMax.MaxValue = "0";
            this.txtMax.MinValue = "0";
            this.txtMax.Name = "txtMax";
            this.txtMax.Resolution = 0D;
            this.txtMax.Text = "0";
            this.txtMax.Tip = null;
            this.txtMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // tpCrossHead
            // 
            resources.ApplyResources(this.tpCrossHead, "tpCrossHead");
            this.tpCrossHead.BackColor = System.Drawing.Color.White;
            this.tpCrossHead.Controls.Add(this.OptionElectroHydrolic);
            this.tpCrossHead.Controls.Add(this.cbActuator);
            this.tpCrossHead.Controls.Add(this.label40);
            this.tpCrossHead.Controls.Add(this.label10);
            this.tpCrossHead.Controls.Add(this.label11);
            this.tpCrossHead.Controls.Add(this.label12);
            this.tpCrossHead.Controls.Add(this.label13);
            this.tpCrossHead.Controls.Add(this.label14);
            this.tpCrossHead.Controls.Add(this.label9);
            this.tpCrossHead.Controls.Add(this.label4);
            this.tpCrossHead.Controls.Add(this.label7);
            this.tpCrossHead.Controls.Add(this.label3);
            this.tpCrossHead.Controls.Add(this.label5);
            this.tpCrossHead.Controls.Add(this.label6);
            this.tpCrossHead.Controls.Add(this.txtCrsMin);
            this.tpCrossHead.Controls.Add(this.txtCrsMax);
            this.tpCrossHead.Controls.Add(this.txtCrsInc);
            this.tpCrossHead.Controls.Add(this.txtCrsLowJog);
            this.tpCrossHead.Controls.Add(this.txtCrsHiJog);
            this.tpCrossHead.Name = "tpCrossHead";
            // 
            // OptionElectroHydrolic
            // 
            resources.ApplyResources(this.OptionElectroHydrolic, "OptionElectroHydrolic");
            this.OptionElectroHydrolic.Name = "OptionElectroHydrolic";
            this.OptionElectroHydrolic.UseVisualStyleBackColor = true;
            // 
            // cbActuator
            // 
            resources.ApplyResources(this.cbActuator, "cbActuator");
            this.cbActuator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActuator.FormattingEnabled = true;
            this.cbActuator.Items.AddRange(new object[] {
            resources.GetString("cbActuator.Items"),
            resources.GetString("cbActuator.Items1")});
            this.cbActuator.Name = "cbActuator";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
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
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // txtCrsMin
            // 
            resources.ApplyResources(this.txtCrsMin, "txtCrsMin");
            this.txtCrsMin.BackColor = System.Drawing.Color.White;
            this.txtCrsMin.CheckInRange = true;
            this.txtCrsMin.DataType = STM.DLayer.DataType.Double;
            this.txtCrsMin.DefaultValue = "0";
            this.txtCrsMin.FractionalDigits = 0;
            this.txtCrsMin.MaxValue = "600";
            this.txtCrsMin.MinValue = "0";
            this.txtCrsMin.Name = "txtCrsMin";
            this.txtCrsMin.Resolution = 0D;
            this.txtCrsMin.Text = "0";
            this.txtCrsMin.Tip = null;
            this.txtCrsMin.TextChanged += new System.EventHandler(this.txtCrsMax_TextChanged);
            this.txtCrsMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtCrsMax
            // 
            resources.ApplyResources(this.txtCrsMax, "txtCrsMax");
            this.txtCrsMax.BackColor = System.Drawing.Color.White;
            this.txtCrsMax.CheckInRange = true;
            this.txtCrsMax.DataType = STM.DLayer.DataType.Double;
            this.txtCrsMax.DefaultValue = "0";
            this.txtCrsMax.FractionalDigits = 0;
            this.txtCrsMax.MaxValue = "1000";
            this.txtCrsMax.MinValue = "2";
            this.txtCrsMax.Name = "txtCrsMax";
            this.txtCrsMax.Resolution = 0D;
            this.txtCrsMax.Text = "2";
            this.txtCrsMax.Tip = null;
            this.txtCrsMax.TextChanged += new System.EventHandler(this.txtCrsMax_TextChanged);
            this.txtCrsMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtCrsInc
            // 
            resources.ApplyResources(this.txtCrsInc, "txtCrsInc");
            this.txtCrsInc.BackColor = System.Drawing.Color.White;
            this.txtCrsInc.CheckInRange = false;
            this.txtCrsInc.DataType = STM.DLayer.DataType.Double;
            this.txtCrsInc.DefaultValue = "0";
            this.txtCrsInc.FractionalDigits = 0;
            this.txtCrsInc.MaxValue = "0";
            this.txtCrsInc.MinValue = "0";
            this.txtCrsInc.Name = "txtCrsInc";
            this.txtCrsInc.Resolution = 0D;
            this.txtCrsInc.Text = "0";
            this.txtCrsInc.Tip = null;
            this.txtCrsInc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtCrsLowJog
            // 
            resources.ApplyResources(this.txtCrsLowJog, "txtCrsLowJog");
            this.txtCrsLowJog.BackColor = System.Drawing.Color.White;
            this.txtCrsLowJog.CheckInRange = true;
            this.txtCrsLowJog.DataType = STM.DLayer.DataType.Double;
            this.txtCrsLowJog.DefaultValue = "0";
            this.txtCrsLowJog.FractionalDigits = 0;
            this.txtCrsLowJog.MaxValue = "600";
            this.txtCrsLowJog.MinValue = "0";
            this.txtCrsLowJog.Name = "txtCrsLowJog";
            this.txtCrsLowJog.Resolution = 0D;
            this.txtCrsLowJog.Text = "0";
            this.txtCrsLowJog.Tip = null;
            this.txtCrsLowJog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // txtCrsHiJog
            // 
            resources.ApplyResources(this.txtCrsHiJog, "txtCrsHiJog");
            this.txtCrsHiJog.BackColor = System.Drawing.Color.White;
            this.txtCrsHiJog.CheckInRange = true;
            this.txtCrsHiJog.DataType = STM.DLayer.DataType.Double;
            this.txtCrsHiJog.DefaultValue = "0";
            this.txtCrsHiJog.FractionalDigits = 0;
            this.txtCrsHiJog.MaxValue = "1000";
            this.txtCrsHiJog.MinValue = "0";
            this.txtCrsHiJog.Name = "txtCrsHiJog";
            this.txtCrsHiJog.Resolution = 0D;
            this.txtCrsHiJog.Text = "0";
            this.txtCrsHiJog.Tip = null;
            this.txtCrsHiJog.TextChanged += new System.EventHandler(this.txtCrsHiJog_TextChanged);
            this.txtCrsHiJog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // tpHardware
            // 
            resources.ApplyResources(this.tpHardware, "tpHardware");
            this.tpHardware.BackColor = System.Drawing.Color.White;
            this.tpHardware.Controls.Add(this.pBarPortChanging);
            this.tpHardware.Controls.Add(this.txtPlotDecimationRatio);
            this.tpHardware.Controls.Add(this.label39);
            this.tpHardware.Controls.Add(this.txtPortName);
            this.tpHardware.Controls.Add(this.label28);
            this.tpHardware.Controls.Add(this.llFds);
            this.tpHardware.Controls.Add(this.label2);
            this.tpHardware.Controls.Add(this.label18);
            this.tpHardware.Controls.Add(this.txtReadInterval);
            this.tpHardware.Controls.Add(this.label8);
            this.tpHardware.Controls.Add(this.label1);
            this.tpHardware.Name = "tpHardware";
            // 
            // pBarPortChanging
            // 
            resources.ApplyResources(this.pBarPortChanging, "pBarPortChanging");
            this.pBarPortChanging.BackColor = System.Drawing.Color.Silver;
            this.pBarPortChanging.Name = "pBarPortChanging";
            // 
            // txtPlotDecimationRatio
            // 
            resources.ApplyResources(this.txtPlotDecimationRatio, "txtPlotDecimationRatio");
            this.txtPlotDecimationRatio.BackColor = System.Drawing.Color.White;
            this.txtPlotDecimationRatio.CheckInRange = true;
            this.txtPlotDecimationRatio.DataType = STM.DLayer.DataType.Int;
            this.txtPlotDecimationRatio.DefaultValue = "0";
            this.txtPlotDecimationRatio.FractionalDigits = 0;
            this.txtPlotDecimationRatio.MaxValue = "360000";
            this.txtPlotDecimationRatio.MinValue = "1";
            this.txtPlotDecimationRatio.Name = "txtPlotDecimationRatio";
            this.txtPlotDecimationRatio.Resolution = 0D;
            this.txtPlotDecimationRatio.Text = "10";
            this.txtPlotDecimationRatio.Tip = null;
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // txtPortName
            // 
            resources.ApplyResources(this.txtPortName, "txtPortName");
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.ReadOnly = true;
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // llFds
            // 
            resources.ApplyResources(this.llFds, "llFds");
            this.llFds.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llFds.Name = "llFds";
            this.llFds.TabStop = true;
            this.llFds.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llFds.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFds_LinkClicked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // txtReadInterval
            // 
            resources.ApplyResources(this.txtReadInterval, "txtReadInterval");
            this.txtReadInterval.BackColor = System.Drawing.Color.White;
            this.txtReadInterval.CheckInRange = true;
            this.txtReadInterval.DataType = STM.DLayer.DataType.Int;
            this.txtReadInterval.DefaultValue = "10";
            this.txtReadInterval.FractionalDigits = 0;
            this.txtReadInterval.MaxValue = "1000";
            this.txtReadInterval.MinValue = "10";
            this.txtReadInterval.Name = "txtReadInterval";
            this.txtReadInterval.Resolution = 0D;
            this.txtReadInterval.Text = "10";
            this.txtReadInterval.Tip = null;
            this.txtReadInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNext);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panelNavigation
            // 
            resources.ApplyResources(this.panelNavigation, "panelNavigation");
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavigation.Controls.Add(this.llApply);
            this.panelNavigation.Controls.Add(this.llCancel);
            this.panelNavigation.Controls.Add(this.llCrosshead);
            this.panelNavigation.Controls.Add(this.llHardware);
            this.panelNavigation.Controls.Add(this.llControl);
            this.panelNavigation.Name = "panelNavigation";
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
            // llCancel
            // 
            resources.ApplyResources(this.llCancel, "llCancel");
            this.llCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCancel.Name = "llCancel";
            this.llCancel.TabStop = true;
            this.llCancel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCancel_LinkClicked);
            // 
            // llCrosshead
            // 
            resources.ApplyResources(this.llCrosshead, "llCrosshead");
            this.llCrosshead.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCrosshead.Name = "llCrosshead";
            this.llCrosshead.TabStop = true;
            this.llCrosshead.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llCrosshead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCrosshead_LinkClicked);
            // 
            // llHardware
            // 
            resources.ApplyResources(this.llHardware, "llHardware");
            this.llHardware.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llHardware.Name = "llHardware";
            this.llHardware.TabStop = true;
            this.llHardware.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llHardware.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHardware_LinkClicked);
            // 
            // llControl
            // 
            resources.ApplyResources(this.llControl, "llControl");
            this.llControl.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llControl.Name = "llControl";
            this.llControl.TabStop = true;
            this.llControl.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llControl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llControl_LinkClicked);
            // 
            // FrmMachineSetting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.tbMachineSetting);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMachineSetting";
            this.Load += new System.EventHandler(this.FrmMachineSetting_Load);
            this.tbMachineSetting.ResumeLayout(false);
            this.tpControl.ResumeLayout(false);
            this.panleSpeedSettingSelector.ResumeLayout(false);
            this.panleSpeedSettingSelector.PerformLayout();
            this.tcSpeedControl.ResumeLayout(false);
            this.tpPID.ResumeLayout(false);
            this.tpPID.PerformLayout();
            this.tpExtenCtrl.ResumeLayout(false);
            this.tpExtenCtrl.PerformLayout();
            this.tpForceCtrl.ResumeLayout(false);
            this.tpForceCtrl.PerformLayout();
            this.tpStrainCtrl.ResumeLayout(false);
            this.tpStrainCtrl.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tpCrossHead.ResumeLayout(false);
            this.tpCrossHead.PerformLayout();
            this.tpHardware.ResumeLayout(false);
            this.tpHardware.PerformLayout();
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMachineSetting;
        private System.Windows.Forms.TabPage tpHardware;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private NRTextBox txtReadInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tpControl;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.LinkLabel llHardware;
        private System.Windows.Forms.LinkLabel llControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpCrossHead;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private NRTextBox txtCrsMin;
        private NRTextBox txtCrsMax;
        private NRTextBox txtCrsInc;
        private NRTextBox txtCrsLowJog;
        private NRTextBox txtCrsHiJog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel llCrosshead;
        private System.Windows.Forms.TabControl tcSpeedControl;
        private System.Windows.Forms.TabPage tpPID;
        private NRTextBox txtD;
        private NRTextBox txtI;
        private NRTextBox txtP;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TabPage tpExtenCtrl;
        private System.Windows.Forms.Label label45;
        private NRTextBox txtExtenTor;
        private NRTextBox txtKed;
        private NRTextBox txtKei;
        private NRTextBox txtKep;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TabPage tpForceCtrl;
        private System.Windows.Forms.Label label15;
        private NRTextBox txtForceTor;
        private NRTextBox txtKfd;
        private NRTextBox txtKfi;
        private NRTextBox txtKfp;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tpStrainCtrl;
        private System.Windows.Forms.Label label21;
        private NRTextBox txtStrainTor;
        private NRTextBox txtKsd;
        private NRTextBox txtKsi;
        private NRTextBox txtKsp;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label34;
        private NRTextBox txtMTimeOut;
        private NRTextBox txtMCMD;
        private NRTextBox txtVel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabPage tabPage6;
        private NRTextBox txtMOffset;
        private NRTextBox txtMStep;
        private NRTextBox txtMax;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Panel panleSpeedSettingSelector;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.LinkLabel llApply;
        private System.Windows.Forms.LinkLabel llCancel;
        private System.Windows.Forms.LinkLabel llFds;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtPortName;
        private NRTextBox txtPlotDecimationRatio;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cbActuator;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.CheckBox OptionElectroHydrolic;
        private System.Windows.Forms.ProgressBar pBarPortChanging;

        public event EventHandler<EventArgs> OnUpdateSettings;
        public event EventHandler<EventArgs> OnFds;
        public event EventHandler<EventArgs> OnOperationDone;
    }
}