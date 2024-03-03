
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
            this.ClearOutputCommand = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.option_ShowAverages = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelChronometer = new System.Windows.Forms.Label();
            this.timerChronometer = new System.Windows.Forms.Timer(this.components);
            this.labelResetCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numZ1SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ2SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ3SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatureCompensationPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdApplyZ1SetPoint
            // 
            this.cmdApplyZ1SetPoint.Location = new System.Drawing.Point(312, 93);
            this.cmdApplyZ1SetPoint.Margin = new System.Windows.Forms.Padding(4);
            this.cmdApplyZ1SetPoint.Name = "cmdApplyZ1SetPoint";
            this.cmdApplyZ1SetPoint.Size = new System.Drawing.Size(79, 28);
            this.cmdApplyZ1SetPoint.TabIndex = 8;
            this.cmdApplyZ1SetPoint.Text = "Apply";
            this.cmdApplyZ1SetPoint.UseVisualStyleBackColor = true;
            this.cmdApplyZ1SetPoint.Click += new System.EventHandler(this.cmdApplyZ1SetPoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Set Point Z1:";
            // 
            // numZ1SetPoint
            // 
            this.numZ1SetPoint.Location = new System.Drawing.Point(116, 94);
            this.numZ1SetPoint.Margin = new System.Windows.Forms.Padding(4);
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
            this.numZ1SetPoint.Size = new System.Drawing.Size(115, 26);
            this.numZ1SetPoint.TabIndex = 7;
            // 
            // cmdApplyZ2SetPoint
            // 
            this.cmdApplyZ2SetPoint.Location = new System.Drawing.Point(312, 57);
            this.cmdApplyZ2SetPoint.Margin = new System.Windows.Forms.Padding(4);
            this.cmdApplyZ2SetPoint.Name = "cmdApplyZ2SetPoint";
            this.cmdApplyZ2SetPoint.Size = new System.Drawing.Size(79, 28);
            this.cmdApplyZ2SetPoint.TabIndex = 5;
            this.cmdApplyZ2SetPoint.Text = "Apply";
            this.cmdApplyZ2SetPoint.UseVisualStyleBackColor = true;
            this.cmdApplyZ2SetPoint.Click += new System.EventHandler(this.cmdApplyZ2SetPoint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set Point Z2:";
            // 
            // numZ2SetPoint
            // 
            this.numZ2SetPoint.Location = new System.Drawing.Point(116, 58);
            this.numZ2SetPoint.Margin = new System.Windows.Forms.Padding(4);
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
            this.numZ2SetPoint.Size = new System.Drawing.Size(115, 26);
            this.numZ2SetPoint.TabIndex = 4;
            // 
            // cmdApplyZ3SetPoint
            // 
            this.cmdApplyZ3SetPoint.Location = new System.Drawing.Point(312, 23);
            this.cmdApplyZ3SetPoint.Margin = new System.Windows.Forms.Padding(4);
            this.cmdApplyZ3SetPoint.Name = "cmdApplyZ3SetPoint";
            this.cmdApplyZ3SetPoint.Size = new System.Drawing.Size(79, 28);
            this.cmdApplyZ3SetPoint.TabIndex = 2;
            this.cmdApplyZ3SetPoint.Text = "Apply";
            this.cmdApplyZ3SetPoint.UseVisualStyleBackColor = true;
            this.cmdApplyZ3SetPoint.Click += new System.EventHandler(this.cmdApplyZ3SetPoint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Set Point Z3:";
            // 
            // numZ3SetPoint
            // 
            this.numZ3SetPoint.Location = new System.Drawing.Point(116, 24);
            this.numZ3SetPoint.Margin = new System.Windows.Forms.Padding(4);
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
            this.numZ3SetPoint.Size = new System.Drawing.Size(115, 26);
            this.numZ3SetPoint.TabIndex = 1;
            // 
            // chkEnableTemperatureCompensation
            // 
            this.chkEnableTemperatureCompensation.AutoSize = true;
            this.chkEnableTemperatureCompensation.Location = new System.Drawing.Point(12, 193);
            this.chkEnableTemperatureCompensation.Name = "chkEnableTemperatureCompensation";
            this.chkEnableTemperatureCompensation.Size = new System.Drawing.Size(257, 22);
            this.chkEnableTemperatureCompensation.TabIndex = 12;
            this.chkEnableTemperatureCompensation.Text = "Enable Temperature Compensation";
            this.chkEnableTemperatureCompensation.UseVisualStyleBackColor = true;
            this.chkEnableTemperatureCompensation.CheckedChanged += new System.EventHandler(this.chkEnableTemperatureCompensation_CheckedChanged);
            // 
            // nudTemperatureCompensationPeriod
            // 
            this.nudTemperatureCompensationPeriod.Location = new System.Drawing.Point(116, 131);
            this.nudTemperatureCompensationPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.nudTemperatureCompensationPeriod.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudTemperatureCompensationPeriod.Name = "nudTemperatureCompensationPeriod";
            this.nudTemperatureCompensationPeriod.Size = new System.Drawing.Size(115, 26);
            this.nudTemperatureCompensationPeriod.TabIndex = 10;
            // 
            // commandApplyTPeriod
            // 
            this.commandApplyTPeriod.Location = new System.Drawing.Point(312, 132);
            this.commandApplyTPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.commandApplyTPeriod.Name = "commandApplyTPeriod";
            this.commandApplyTPeriod.Size = new System.Drawing.Size(79, 28);
            this.commandApplyTPeriod.TabIndex = 11;
            this.commandApplyTPeriod.Text = "Apply";
            this.commandApplyTPeriod.UseVisualStyleBackColor = true;
            this.commandApplyTPeriod.Click += new System.EventHandler(this.commandApplyTPeriod_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Check Period:";
            // 
            // output_View
            // 
            this.output_View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_View.Location = new System.Drawing.Point(12, 248);
            this.output_View.Multiline = true;
            this.output_View.Name = "output_View";
            this.output_View.ReadOnly = true;
            this.output_View.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output_View.Size = new System.Drawing.Size(406, 203);
            this.output_View.TabIndex = 13;
            // 
            // ClearOutputCommand
            // 
            this.ClearOutputCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearOutputCommand.Location = new System.Drawing.Point(395, 219);
            this.ClearOutputCommand.Name = "ClearOutputCommand";
            this.ClearOutputCommand.Size = new System.Drawing.Size(24, 28);
            this.ClearOutputCommand.TabIndex = 14;
            this.ClearOutputCommand.Text = "x";
            this.ClearOutputCommand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ClearOutputCommand.UseVisualStyleBackColor = true;
            this.ClearOutputCommand.Click += new System.EventHandler(this.ClearOutputCommand_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "(min)";
            // 
            // option_ShowAverages
            // 
            this.option_ShowAverages.Appearance = System.Windows.Forms.Appearance.Button;
            this.option_ShowAverages.AutoSize = true;
            this.option_ShowAverages.Location = new System.Drawing.Point(328, 219);
            this.option_ShowAverages.Name = "option_ShowAverages";
            this.option_ShowAverages.Size = new System.Drawing.Size(61, 28);
            this.option_ShowAverages.TabIndex = 15;
            this.option_ShowAverages.Text = "Means";
            this.option_ShowAverages.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "(°C)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "(°C)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(239, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "(°C)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Temperature reset log:";
            // 
            // labelChronometer
            // 
            this.labelChronometer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChronometer.Location = new System.Drawing.Point(116, 167);
            this.labelChronometer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChronometer.Name = "labelChronometer";
            this.labelChronometer.Size = new System.Drawing.Size(115, 30);
            this.labelChronometer.TabIndex = 20;
            this.labelChronometer.Text = "00:00:00";
            // 
            // timerChronometer
            // 
            this.timerChronometer.Enabled = true;
            this.timerChronometer.Interval = 1000;
            this.timerChronometer.Tick += new System.EventHandler(this.timerChronometer_Tick);
            // 
            // labelResetCount
            // 
            this.labelResetCount.AutoSize = true;
            this.labelResetCount.Location = new System.Drawing.Point(157, 229);
            this.labelResetCount.Name = "labelResetCount";
            this.labelResetCount.Size = new System.Drawing.Size(16, 18);
            this.labelResetCount.TabIndex = 21;
            this.labelResetCount.Text = "0";
            // 
            // TemperatureMoreControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 463);
            this.Controls.Add(this.labelResetCount);
            this.Controls.Add(this.labelChronometer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.option_ShowAverages);
            this.Controls.Add(this.ClearOutputCommand);
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
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(430, 500);
            this.Name = "TemperatureMoreControlForm";
            this.Text = "Temperature Setpoint Reset";
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
        private System.Windows.Forms.Button ClearOutputCommand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox option_ShowAverages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelChronometer;
        private System.Windows.Forms.Timer timerChronometer;
        private System.Windows.Forms.Label labelResetCount;
    }
}