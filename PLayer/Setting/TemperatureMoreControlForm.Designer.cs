
namespace STM
{
    partial class TemperatureMoreControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureMoreControlForm));
            this.cmdApplyZ1SetPoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numZ1SetPoint = new System.Windows.Forms.NumericUpDown();
            this.cmdApplyZ2SetPoint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numZ2SetPoint = new System.Windows.Forms.NumericUpDown();
            this.cmdApplyZ3SetPoint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numZ3SetPoint = new System.Windows.Forms.NumericUpDown();
            this.chkEnableTemperatureCompensation = new System.Windows.Forms.CheckBox();
            this.nudTemperatureCompensationPeriod = new System.Windows.Forms.NumericUpDown();
            this.commandApplyTPeriod = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.output_View = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.option_ShowAverages = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelChronometer = new System.Windows.Forms.Label();
            this.timerChronometer = new System.Windows.Forms.Timer(this.components);
            this.labelResetCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkEnableResetTemperatureSetpointAfterStop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numZ1SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ2SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ3SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatureCompensationPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdApplyZ1SetPoint
            // 
            resources.ApplyResources(this.cmdApplyZ1SetPoint, "cmdApplyZ1SetPoint");
            this.cmdApplyZ1SetPoint.Name = "cmdApplyZ1SetPoint";
            this.cmdApplyZ1SetPoint.UseVisualStyleBackColor = true;
            this.cmdApplyZ1SetPoint.Click += new System.EventHandler(this.cmdApplyZ1SetPoint_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numZ1SetPoint
            // 
            resources.ApplyResources(this.numZ1SetPoint, "numZ1SetPoint");
            this.numZ1SetPoint.DecimalPlaces = 1;
            this.numZ1SetPoint.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numZ1SetPoint.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numZ1SetPoint.Name = "numZ1SetPoint";
            // 
            // cmdApplyZ2SetPoint
            // 
            resources.ApplyResources(this.cmdApplyZ2SetPoint, "cmdApplyZ2SetPoint");
            this.cmdApplyZ2SetPoint.Name = "cmdApplyZ2SetPoint";
            this.cmdApplyZ2SetPoint.UseVisualStyleBackColor = true;
            this.cmdApplyZ2SetPoint.Click += new System.EventHandler(this.cmdApplyZ2SetPoint_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numZ2SetPoint
            // 
            resources.ApplyResources(this.numZ2SetPoint, "numZ2SetPoint");
            this.numZ2SetPoint.DecimalPlaces = 1;
            this.numZ2SetPoint.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numZ2SetPoint.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numZ2SetPoint.Name = "numZ2SetPoint";
            // 
            // cmdApplyZ3SetPoint
            // 
            resources.ApplyResources(this.cmdApplyZ3SetPoint, "cmdApplyZ3SetPoint");
            this.cmdApplyZ3SetPoint.Name = "cmdApplyZ3SetPoint";
            this.cmdApplyZ3SetPoint.UseVisualStyleBackColor = true;
            this.cmdApplyZ3SetPoint.Click += new System.EventHandler(this.cmdApplyZ3SetPoint_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numZ3SetPoint
            // 
            resources.ApplyResources(this.numZ3SetPoint, "numZ3SetPoint");
            this.numZ3SetPoint.DecimalPlaces = 1;
            this.numZ3SetPoint.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numZ3SetPoint.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numZ3SetPoint.Name = "numZ3SetPoint";
            // 
            // chkEnableTemperatureCompensation
            // 
            resources.ApplyResources(this.chkEnableTemperatureCompensation, "chkEnableTemperatureCompensation");
            this.chkEnableTemperatureCompensation.Name = "chkEnableTemperatureCompensation";
            this.chkEnableTemperatureCompensation.UseVisualStyleBackColor = true;
            this.chkEnableTemperatureCompensation.CheckedChanged += new System.EventHandler(this.chkEnableTemperatureCompensation_CheckedChanged);
            // 
            // nudTemperatureCompensationPeriod
            // 
            resources.ApplyResources(this.nudTemperatureCompensationPeriod, "nudTemperatureCompensationPeriod");
            this.nudTemperatureCompensationPeriod.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudTemperatureCompensationPeriod.Name = "nudTemperatureCompensationPeriod";
            // 
            // commandApplyTPeriod
            // 
            resources.ApplyResources(this.commandApplyTPeriod, "commandApplyTPeriod");
            this.commandApplyTPeriod.Name = "commandApplyTPeriod";
            this.commandApplyTPeriod.UseVisualStyleBackColor = true;
            this.commandApplyTPeriod.Click += new System.EventHandler(this.commandApplyTPeriod_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // output_View
            // 
            resources.ApplyResources(this.output_View, "output_View");
            this.output_View.Name = "output_View";
            this.output_View.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // option_ShowAverages
            // 
            resources.ApplyResources(this.option_ShowAverages, "option_ShowAverages");
            this.option_ShowAverages.Name = "option_ShowAverages";
            this.option_ShowAverages.UseVisualStyleBackColor = true;
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
            // labelChronometer
            // 
            resources.ApplyResources(this.labelChronometer, "labelChronometer");
            this.labelChronometer.Name = "labelChronometer";
            // 
            // timerChronometer
            // 
            this.timerChronometer.Enabled = true;
            this.timerChronometer.Interval = 1000;
            this.timerChronometer.Tick += new System.EventHandler(this.timerChronometer_Tick);
            // 
            // labelResetCount
            // 
            resources.ApplyResources(this.labelResetCount, "labelResetCount");
            this.labelResetCount.Name = "labelResetCount";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            this.label10.Click += new System.EventHandler(this.ClearOutputCommand_Click);
            // 
            // chkEnableResetTemperatureSetpointAfterStop
            // 
            resources.ApplyResources(this.chkEnableResetTemperatureSetpointAfterStop, "chkEnableResetTemperatureSetpointAfterStop");
            this.chkEnableResetTemperatureSetpointAfterStop.Name = "chkEnableResetTemperatureSetpointAfterStop";
            this.chkEnableResetTemperatureSetpointAfterStop.UseVisualStyleBackColor = true;
            this.chkEnableResetTemperatureSetpointAfterStop.CheckedChanged += new System.EventHandler(this.chkEnableResetTemperatureSetpointAfterStop_CheckedChanged);
            // 
            // TemperatureMoreControlForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkEnableResetTemperatureSetpointAfterStop);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelResetCount);
            this.Controls.Add(this.labelChronometer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.option_ShowAverages);
            this.Controls.Add(this.output_View);
            this.Controls.Add(this.commandApplyTPeriod);
            this.Controls.Add(this.nudTemperatureCompensationPeriod);
            this.Controls.Add(this.chkEnableTemperatureCompensation);
            this.Controls.Add(this.numZ3SetPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numZ2SetPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdApplyZ3SetPoint);
            this.Controls.Add(this.numZ1SetPoint);
            this.Controls.Add(this.cmdApplyZ2SetPoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdApplyZ1SetPoint);
            this.Name = "TemperatureMoreControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemperatureMoreControlForm_FormClosing);
            this.Load += new System.EventHandler(this.TemperatureMoreControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numZ1SetPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ2SetPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ3SetPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatureCompensationPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdApplyZ1SetPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numZ1SetPoint;
        private System.Windows.Forms.Button cmdApplyZ2SetPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numZ2SetPoint;
        private System.Windows.Forms.Button cmdApplyZ3SetPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numZ3SetPoint;
        private System.Windows.Forms.CheckBox chkEnableTemperatureCompensation;
        private System.Windows.Forms.NumericUpDown nudTemperatureCompensationPeriod;
        private System.Windows.Forms.Button commandApplyTPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox output_View;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox option_ShowAverages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelChronometer;
        private System.Windows.Forms.Timer timerChronometer;
        private System.Windows.Forms.Label labelResetCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkEnableResetTemperatureSetpointAfterStop;
    }
}