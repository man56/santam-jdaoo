using System;

namespace STM.PLayer.Setting
{
    partial class FrmUnitSetting
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnitSetting));
			this.label73 = new System.Windows.Forms.Label();
			this.llUnitsOk = new System.Windows.Forms.LinkLabel();
			this.label59 = new System.Windows.Forms.Label();
			this.cbUnitTime = new System.Windows.Forms.ComboBox();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.cbUnitStrain = new System.Windows.Forms.ComboBox();
			this.cbUnitStress = new System.Windows.Forms.ComboBox();
			this.cbUnitExtension = new System.Windows.Forms.ComboBox();
			this.cbUnitForce = new System.Windows.Forms.ComboBox();
			this.cbUnitMainCatagories = new System.Windows.Forms.ComboBox();
			this.llCancel = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.cbUnitSpecificStress = new System.Windows.Forms.ComboBox();
			this.cbUnitLengthStress = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbUnitTemperature = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label73
			// 
			resources.ApplyResources(this.label73, "label73");
			this.label73.Name = "label73";
			// 
			// llUnitsOk
			// 
			resources.ApplyResources(this.llUnitsOk, "llUnitsOk");
			this.llUnitsOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.llUnitsOk.Name = "llUnitsOk";
			this.llUnitsOk.TabStop = true;
			this.llUnitsOk.VisitedLinkColor = System.Drawing.Color.Blue;
			this.llUnitsOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llUnitsOk_LinkClicked);
			// 
			// label59
			// 
			resources.ApplyResources(this.label59, "label59");
			this.label59.Name = "label59";
			// 
			// cbUnitTime
			// 
			resources.ApplyResources(this.cbUnitTime, "cbUnitTime");
			this.cbUnitTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitTime.FormattingEnabled = true;
			this.cbUnitTime.Items.AddRange(new object[] {
            resources.GetString("cbUnitTime.Items"),
            resources.GetString("cbUnitTime.Items1")});
			this.cbUnitTime.Name = "cbUnitTime";
			// 
			// label44
			// 
			resources.ApplyResources(this.label44, "label44");
			this.label44.Name = "label44";
			// 
			// label43
			// 
			resources.ApplyResources(this.label43, "label43");
			this.label43.Name = "label43";
			// 
			// label42
			// 
			resources.ApplyResources(this.label42, "label42");
			this.label42.Name = "label42";
			// 
			// label36
			// 
			resources.ApplyResources(this.label36, "label36");
			this.label36.Name = "label36";
			// 
			// label23
			// 
			resources.ApplyResources(this.label23, "label23");
			this.label23.Name = "label23";
			// 
			// cbUnitStrain
			// 
			resources.ApplyResources(this.cbUnitStrain, "cbUnitStrain");
			this.cbUnitStrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitStrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitStrain.FormattingEnabled = true;
			this.cbUnitStrain.Items.AddRange(new object[] {
            resources.GetString("cbUnitStrain.Items"),
            resources.GetString("cbUnitStrain.Items1")});
			this.cbUnitStrain.Name = "cbUnitStrain";
			// 
			// cbUnitStress
			// 
			resources.ApplyResources(this.cbUnitStress, "cbUnitStress");
			this.cbUnitStress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitStress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitStress.FormattingEnabled = true;
			this.cbUnitStress.Items.AddRange(new object[] {
            resources.GetString("cbUnitStress.Items"),
            resources.GetString("cbUnitStress.Items1")});
			this.cbUnitStress.Name = "cbUnitStress";
			// 
			// cbUnitExtension
			// 
			resources.ApplyResources(this.cbUnitExtension, "cbUnitExtension");
			this.cbUnitExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitExtension.FormattingEnabled = true;
			this.cbUnitExtension.Items.AddRange(new object[] {
            resources.GetString("cbUnitExtension.Items"),
            resources.GetString("cbUnitExtension.Items1")});
			this.cbUnitExtension.Name = "cbUnitExtension";
			// 
			// cbUnitForce
			// 
			resources.ApplyResources(this.cbUnitForce, "cbUnitForce");
			this.cbUnitForce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitForce.FormattingEnabled = true;
			this.cbUnitForce.Items.AddRange(new object[] {
            resources.GetString("cbUnitForce.Items"),
            resources.GetString("cbUnitForce.Items1")});
			this.cbUnitForce.Name = "cbUnitForce";
			// 
			// cbUnitMainCatagories
			// 
			resources.ApplyResources(this.cbUnitMainCatagories, "cbUnitMainCatagories");
			this.cbUnitMainCatagories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitMainCatagories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitMainCatagories.FormattingEnabled = true;
			this.cbUnitMainCatagories.Name = "cbUnitMainCatagories";
			this.cbUnitMainCatagories.SelectedIndexChanged += new System.EventHandler(this.cbReportingUnitMainCatagories_SelectedIndexChanged);
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
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// cbUnitSpecificStress
			// 
			resources.ApplyResources(this.cbUnitSpecificStress, "cbUnitSpecificStress");
			this.cbUnitSpecificStress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitSpecificStress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitSpecificStress.FormattingEnabled = true;
			this.cbUnitSpecificStress.Items.AddRange(new object[] {
            resources.GetString("cbUnitSpecificStress.Items"),
            resources.GetString("cbUnitSpecificStress.Items1")});
			this.cbUnitSpecificStress.Name = "cbUnitSpecificStress";
			// 
			// cbUnitLengthStress
			// 
			resources.ApplyResources(this.cbUnitLengthStress, "cbUnitLengthStress");
			this.cbUnitLengthStress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitLengthStress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitLengthStress.FormattingEnabled = true;
			this.cbUnitLengthStress.Items.AddRange(new object[] {
            resources.GetString("cbUnitLengthStress.Items"),
            resources.GetString("cbUnitLengthStress.Items1")});
			this.cbUnitLengthStress.Name = "cbUnitLengthStress";
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
			// cbUnitTemperature
			// 
			resources.ApplyResources(this.cbUnitTemperature, "cbUnitTemperature");
			this.cbUnitTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.cbUnitTemperature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUnitTemperature.FormattingEnabled = true;
			this.cbUnitTemperature.Items.AddRange(new object[] {
            resources.GetString("cbUnitTemperature.Items"),
            resources.GetString("cbUnitTemperature.Items1")});
			this.cbUnitTemperature.Name = "cbUnitTemperature";
			// 
			// FrmUnitSetting
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbUnitTemperature);
			this.Controls.Add(this.cbUnitLengthStress);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbUnitSpecificStress);
			this.Controls.Add(this.llCancel);
			this.Controls.Add(this.label73);
			this.Controls.Add(this.llUnitsOk);
			this.Controls.Add(this.label59);
			this.Controls.Add(this.cbUnitMainCatagories);
			this.Controls.Add(this.cbUnitTime);
			this.Controls.Add(this.cbUnitForce);
			this.Controls.Add(this.label44);
			this.Controls.Add(this.cbUnitExtension);
			this.Controls.Add(this.label43);
			this.Controls.Add(this.cbUnitStress);
			this.Controls.Add(this.label42);
			this.Controls.Add(this.cbUnitStrain);
			this.Controls.Add(this.label36);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmUnitSetting";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbUnitStrain;
        private System.Windows.Forms.ComboBox cbUnitStress;
        private System.Windows.Forms.ComboBox cbUnitExtension;
        private System.Windows.Forms.ComboBox cbUnitForce;
        private System.Windows.Forms.ComboBox cbUnitMainCatagories;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.ComboBox cbUnitTime;
        private System.Windows.Forms.LinkLabel llUnitsOk;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.LinkLabel llCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnitSpecificStress;
        private System.Windows.Forms.ComboBox cbUnitLengthStress;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbUnitTemperature;

		public event EventHandler<EventArgs> OnOperationDone;
    }
}