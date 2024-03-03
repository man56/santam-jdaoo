
namespace STM.PLayer.Setting
{
    partial class FrmTestSettingsLimited
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestSettingsLimited));
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTestDuration = new STM.PLayer.NRTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDecimation = new STM.PLayer.NRTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbConditionUbit = new System.Windows.Forms.Label();
            this.txtConditionValue = new STM.PLayer.NRTextBox();
            this.cbConditionType = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.cbStopCondition = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestDurationH = new STM.PLayer.NRTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nrTemperatureSetpoint = new STM.PLayer.NRTextBox();
            this.cboDecimationUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            resources.ApplyResources(this.OkButton, "OkButton");
            this.OkButton.Name = "OkButton";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtTestDuration
            // 
            resources.ApplyResources(this.txtTestDuration, "txtTestDuration");
            this.txtTestDuration.BackColor = System.Drawing.Color.White;
            this.txtTestDuration.CheckInRange = false;
            this.txtTestDuration.DataType = STM.DLayer.DataType.Double;
            this.txtTestDuration.DefaultValue = "0.0";
            this.txtTestDuration.FractionalDigits = 2;
            this.txtTestDuration.MaxValue = "0";
            this.txtTestDuration.MinValue = "0";
            this.txtTestDuration.Name = "txtTestDuration";
            this.txtTestDuration.Resolution = 0D;
            this.txtTestDuration.Text = "0.0";
            this.txtTestDuration.Tip = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtDecimation
            // 
            resources.ApplyResources(this.txtDecimation, "txtDecimation");
            this.txtDecimation.BackColor = System.Drawing.Color.White;
            this.txtDecimation.CheckInRange = false;
            this.txtDecimation.DataType = STM.DLayer.DataType.Int;
            this.txtDecimation.DefaultValue = "100";
            this.txtDecimation.FractionalDigits = 2;
            this.txtDecimation.MaxValue = "3600000";
            this.txtDecimation.MinValue = "0";
            this.txtDecimation.Name = "txtDecimation";
            this.txtDecimation.Resolution = 0D;
            this.txtDecimation.Text = "100";
            this.txtDecimation.Tip = null;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtTestDurationH
            // 
            resources.ApplyResources(this.txtTestDurationH, "txtTestDurationH");
            this.txtTestDurationH.BackColor = System.Drawing.Color.White;
            this.txtTestDurationH.CheckInRange = false;
            this.txtTestDurationH.DataType = STM.DLayer.DataType.Double;
            this.txtTestDurationH.DefaultValue = "0.0";
            this.txtTestDurationH.FractionalDigits = 2;
            this.txtTestDurationH.MaxValue = "0";
            this.txtTestDurationH.MinValue = "0";
            this.txtTestDurationH.Name = "txtTestDurationH";
            this.txtTestDurationH.Resolution = 0D;
            this.txtTestDurationH.Text = "0.0";
            this.txtTestDurationH.Tip = null;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // nrTemperatureSetpoint
            // 
            resources.ApplyResources(this.nrTemperatureSetpoint, "nrTemperatureSetpoint");
            this.nrTemperatureSetpoint.BackColor = System.Drawing.Color.White;
            this.nrTemperatureSetpoint.CheckInRange = false;
            this.nrTemperatureSetpoint.DataType = STM.DLayer.DataType.Int;
            this.nrTemperatureSetpoint.DefaultValue = "100";
            this.nrTemperatureSetpoint.FractionalDigits = 2;
            this.nrTemperatureSetpoint.MaxValue = "3600000";
            this.nrTemperatureSetpoint.MinValue = "0";
            this.nrTemperatureSetpoint.Name = "nrTemperatureSetpoint";
            this.nrTemperatureSetpoint.Resolution = 0D;
            this.nrTemperatureSetpoint.Text = "100";
            this.nrTemperatureSetpoint.Tip = null;
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
            // FrmTestSettingsLimited
            // 
            this.AcceptButton = this.OkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboDecimationUnit);
            this.Controls.Add(this.lbConditionUbit);
            this.Controls.Add(this.txtConditionValue);
            this.Controls.Add(this.cbConditionType);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.cbStopCondition);
            this.Controls.Add(this.nrTemperatureSetpoint);
            this.Controls.Add(this.txtDecimation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTestDurationH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTestDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmTestSettingsLimited";
            this.Load += new System.EventHandler(this.FrmTestSettingsLimited_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label1;
        private NRTextBox txtTestDuration;
        private System.Windows.Forms.Label label2;
        private NRTextBox txtDecimation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbConditionUbit;
        private NRTextBox txtConditionValue;
        private System.Windows.Forms.ComboBox cbConditionType;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.CheckBox cbStopCondition;
        private System.Windows.Forms.Label label3;
        private NRTextBox txtTestDurationH;
        private System.Windows.Forms.Label label5;
        private NRTextBox nrTemperatureSetpoint;
        private System.Windows.Forms.ComboBox cboDecimationUnit;
    }
}