using System;

namespace STM.PLayer.UI
{
    partial class MeasurementMonitors
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasurementMonitors));
			this.panelAdd = new System.Windows.Forms.Panel();
			this.bttnMenuSetting = new System.Windows.Forms.LinkLabel();
			this.panelAdd.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelAdd
			// 
			this.panelAdd.Controls.Add(this.bttnMenuSetting);
			resources.ApplyResources(this.panelAdd, "panelAdd");
			this.panelAdd.Name = "panelAdd";
			// 
			// bttnMenuSetting
			// 
			this.bttnMenuSetting.ActiveLinkColor = System.Drawing.Color.Blue;
			resources.ApplyResources(this.bttnMenuSetting, "bttnMenuSetting");
			this.bttnMenuSetting.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.bttnMenuSetting.Name = "bttnMenuSetting";
			this.bttnMenuSetting.TabStop = true;
			this.bttnMenuSetting.VisitedLinkColor = System.Drawing.Color.Blue;
			this.bttnMenuSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bttnMenuSetting_LinkClicked);
			// 
			// MeasurementMonitors
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelAdd);
			this.Name = "MeasurementMonitors";
			this.Load += new System.EventHandler(this.MeasuremenMonitors_Load);
			this.panelAdd.ResumeLayout(false);
			this.panelAdd.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel bttnMenuSetting;
        public event EventHandler<UnitChangeEventArgs> OnUnitChanges;
        public event EventHandler<EventArgs> OnZeroForce;
        public event EventHandler<EventArgs> OnZeroExten;
        public event EventHandler<EventArgs> OnZeroStrain;
        public event EventHandler<EventArgs> OnUnitSystems;
		public event EventHandler<EventArgs> OnZeroTemperature;
		public event EventHandler<EventArgs> OnZeroTemperatureUp;
		public event EventHandler<EventArgs> OnZeroTemperatureCenter;
		public event EventHandler<EventArgs> OnZeroTemperatureDown;
	}
}