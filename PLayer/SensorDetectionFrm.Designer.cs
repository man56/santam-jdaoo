namespace STM.PLayer
{
    partial class SensorDetectionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorDetectionFrm));
            this.lblMaxCap = new System.Windows.Forms.Label();
            this.lbRoGain = new System.Windows.Forms.Label();
            this.lbMvv = new System.Windows.Forms.Label();
            this.lbUnit = new System.Windows.Forms.Label();
            this.lbOk = new System.Windows.Forms.LinkLabel();
            this.pnlExType = new System.Windows.Forms.Panel();
            this.cbExtenType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaxCapacity = new STM.PLayer.NRTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtRO = new STM.PLayer.NRTextBox();
            this.pnlExType.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaxCap
            // 
            resources.ApplyResources(this.lblMaxCap, "lblMaxCap");
            this.lblMaxCap.Name = "lblMaxCap";
            // 
            // lbRoGain
            // 
            resources.ApplyResources(this.lbRoGain, "lbRoGain");
            this.lbRoGain.Name = "lbRoGain";
            // 
            // lbMvv
            // 
            resources.ApplyResources(this.lbMvv, "lbMvv");
            this.lbMvv.Name = "lbMvv";
            // 
            // lbUnit
            // 
            resources.ApplyResources(this.lbUnit, "lbUnit");
            this.lbUnit.Name = "lbUnit";
            // 
            // lbOk
            // 
            resources.ApplyResources(this.lbOk, "lbOk");
            this.lbOk.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lbOk.Name = "lbOk";
            this.lbOk.TabStop = true;
            this.lbOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbOk_LinkClicked);
            // 
            // pnlExType
            // 
            resources.ApplyResources(this.pnlExType, "pnlExType");
            this.pnlExType.Controls.Add(this.cbExtenType);
            this.pnlExType.Controls.Add(this.label4);
            this.pnlExType.Name = "pnlExType";
            // 
            // cbExtenType
            // 
            resources.ApplyResources(this.cbExtenType, "cbExtenType");
            this.cbExtenType.FormattingEnabled = true;
            this.cbExtenType.Items.AddRange(new object[] {
            resources.GetString("cbExtenType.Items"),
            resources.GetString("cbExtenType.Items1"),
            resources.GetString("cbExtenType.Items2")});
            this.cbExtenType.Name = "cbExtenType";
            this.cbExtenType.SelectedIndexChanged += new System.EventHandler(this.cbExtenType_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.txtMaxCapacity);
            this.panel2.Controls.Add(this.lblMaxCap);
            this.panel2.Controls.Add(this.lbUnit);
            this.panel2.Name = "panel2";
            // 
            // txtMaxCapacity
            // 
            resources.ApplyResources(this.txtMaxCapacity, "txtMaxCapacity");
            this.txtMaxCapacity.BackColor = System.Drawing.Color.White;
            this.txtMaxCapacity.CheckInRange = false;
            this.txtMaxCapacity.DataType = STM.DLayer.DataType.Int;
            this.txtMaxCapacity.DefaultValue = "0";
            this.txtMaxCapacity.FractionalDigits = 0;
            this.txtMaxCapacity.MaxValue = "0";
            this.txtMaxCapacity.MinValue = "0";
            this.txtMaxCapacity.Name = "txtMaxCapacity";
            this.txtMaxCapacity.Resolution = 0D;
            this.txtMaxCapacity.Text = "0";
            this.txtMaxCapacity.Tip = null;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.txtRO);
            this.panel3.Controls.Add(this.lbRoGain);
            this.panel3.Controls.Add(this.lbMvv);
            this.panel3.Controls.Add(this.lbOk);
            this.panel3.Name = "panel3";
            // 
            // txtRO
            // 
            resources.ApplyResources(this.txtRO, "txtRO");
            this.txtRO.BackColor = System.Drawing.Color.White;
            this.txtRO.CheckInRange = false;
            this.txtRO.DataType = STM.DLayer.DataType.Double;
            this.txtRO.DefaultValue = "0";
            this.txtRO.FractionalDigits = 8;
            this.txtRO.MaxValue = "0";
            this.txtRO.MinValue = "0";
            this.txtRO.Name = "txtRO";
            this.txtRO.Resolution = 2D;
            this.txtRO.Text = "0";
            this.txtRO.Tip = null;
            // 
            // SensorDetectionFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlExType);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensorDetectionFrm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SensorDetectionFrm_Load);
            this.pnlExType.ResumeLayout(false);
            this.pnlExType.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMaxCap;
        private System.Windows.Forms.Label lbRoGain;
        private NRTextBox txtMaxCapacity;
        private NRTextBox txtRO;
        private System.Windows.Forms.Label lbMvv;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.LinkLabel lbOk;
        private System.Windows.Forms.Panel pnlExType;
        private System.Windows.Forms.ComboBox cbExtenType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}