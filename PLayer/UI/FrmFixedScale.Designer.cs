namespace STM.PLayer.UI
{
    partial class FrmFixedScale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFixedScale));
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lbDiagramYUnitMax = new System.Windows.Forms.Label();
            this.lbDiagramXUnitMax = new System.Windows.Forms.Label();
            this.lbDiagramYUnitMin = new System.Windows.Forms.Label();
            this.lbDiagramXUnitMin = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llCancel = new System.Windows.Forms.LinkLabel();
            this.txtDiagramYSteps = new STM.PLayer.NRTextBox();
            this.txtDiagramXSteps = new STM.PLayer.NRTextBox();
            this.txtDiagramMaxY = new STM.PLayer.NRTextBox();
            this.txtDiagramMinY = new STM.PLayer.NRTextBox();
            this.txtDiagramMaxX = new STM.PLayer.NRTextBox();
            this.txtDiagramMinX = new STM.PLayer.NRTextBox();
            this.llOk = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // lbDiagramYUnitMax
            // 
            resources.ApplyResources(this.lbDiagramYUnitMax, "lbDiagramYUnitMax");
            this.lbDiagramYUnitMax.Name = "lbDiagramYUnitMax";
            // 
            // lbDiagramXUnitMax
            // 
            resources.ApplyResources(this.lbDiagramXUnitMax, "lbDiagramXUnitMax");
            this.lbDiagramXUnitMax.Name = "lbDiagramXUnitMax";
            // 
            // lbDiagramYUnitMin
            // 
            resources.ApplyResources(this.lbDiagramYUnitMin, "lbDiagramYUnitMin");
            this.lbDiagramYUnitMin.Name = "lbDiagramYUnitMin";
            // 
            // lbDiagramXUnitMin
            // 
            resources.ApplyResources(this.lbDiagramXUnitMin, "lbDiagramXUnitMin");
            this.lbDiagramXUnitMin.Name = "lbDiagramXUnitMin";
            // 
            // label84
            // 
            resources.ApplyResources(this.label84, "label84");
            this.label84.Name = "label84";
            // 
            // label85
            // 
            resources.ApplyResources(this.label85, "label85");
            this.label85.Name = "label85";
            // 
            // label81
            // 
            resources.ApplyResources(this.label81, "label81");
            this.label81.Name = "label81";
            // 
            // label82
            // 
            resources.ApplyResources(this.label82, "label82");
            this.label82.Name = "label82";
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
            // llCancel
            // 
            resources.ApplyResources(this.llCancel, "llCancel");
            this.llCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCancel.Name = "llCancel";
            this.llCancel.TabStop = true;
            this.llCancel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCancel_LinkClicked);
            // 
            // txtDiagramYSteps
            // 
            this.txtDiagramYSteps.BackColor = System.Drawing.Color.White;
            this.txtDiagramYSteps.CheckInRange = false;
            this.txtDiagramYSteps.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramYSteps.DefaultValue = "0";
            resources.ApplyResources(this.txtDiagramYSteps, "txtDiagramYSteps");
            this.txtDiagramYSteps.FractionalDigits = 0;
            this.txtDiagramYSteps.MaxValue = "0";
            this.txtDiagramYSteps.MinValue = "0";
            this.txtDiagramYSteps.Name = "txtDiagramYSteps";
            this.txtDiagramYSteps.Resolution = 0D;
            this.txtDiagramYSteps.Text = "0";
            this.txtDiagramYSteps.Tip = null;
            // 
            // txtDiagramXSteps
            // 
            this.txtDiagramXSteps.BackColor = System.Drawing.Color.White;
            this.txtDiagramXSteps.CheckInRange = false;
            this.txtDiagramXSteps.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramXSteps.DefaultValue = "0";
            resources.ApplyResources(this.txtDiagramXSteps, "txtDiagramXSteps");
            this.txtDiagramXSteps.FractionalDigits = 0;
            this.txtDiagramXSteps.MaxValue = "0";
            this.txtDiagramXSteps.MinValue = "0";
            this.txtDiagramXSteps.Name = "txtDiagramXSteps";
            this.txtDiagramXSteps.Resolution = 0D;
            this.txtDiagramXSteps.Text = "0";
            this.txtDiagramXSteps.Tip = null;
            // 
            // txtDiagramMaxY
            // 
            this.txtDiagramMaxY.BackColor = System.Drawing.Color.White;
            this.txtDiagramMaxY.CheckInRange = false;
            this.txtDiagramMaxY.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramMaxY.DefaultValue = "0";
            resources.ApplyResources(this.txtDiagramMaxY, "txtDiagramMaxY");
            this.txtDiagramMaxY.FractionalDigits = 0;
            this.txtDiagramMaxY.MaxValue = "0";
            this.txtDiagramMaxY.MinValue = "0";
            this.txtDiagramMaxY.Name = "txtDiagramMaxY";
            this.txtDiagramMaxY.Resolution = 0D;
            this.txtDiagramMaxY.Text = "0";
            this.txtDiagramMaxY.Tip = null;
            // 
            // txtDiagramMinY
            // 
            this.txtDiagramMinY.BackColor = System.Drawing.Color.White;
            this.txtDiagramMinY.CheckInRange = false;
            this.txtDiagramMinY.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramMinY.DefaultValue = "0";
            resources.ApplyResources(this.txtDiagramMinY, "txtDiagramMinY");
            this.txtDiagramMinY.FractionalDigits = 0;
            this.txtDiagramMinY.MaxValue = "0";
            this.txtDiagramMinY.MinValue = "0";
            this.txtDiagramMinY.Name = "txtDiagramMinY";
            this.txtDiagramMinY.Resolution = 0D;
            this.txtDiagramMinY.Text = "0";
            this.txtDiagramMinY.Tip = null;
            // 
            // txtDiagramMaxX
            // 
            this.txtDiagramMaxX.BackColor = System.Drawing.Color.White;
            this.txtDiagramMaxX.CheckInRange = false;
            this.txtDiagramMaxX.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramMaxX.DefaultValue = "0";
            resources.ApplyResources(this.txtDiagramMaxX, "txtDiagramMaxX");
            this.txtDiagramMaxX.FractionalDigits = 0;
            this.txtDiagramMaxX.MaxValue = "0";
            this.txtDiagramMaxX.MinValue = "0";
            this.txtDiagramMaxX.Name = "txtDiagramMaxX";
            this.txtDiagramMaxX.Resolution = 0D;
            this.txtDiagramMaxX.Text = "0";
            this.txtDiagramMaxX.Tip = null;
            // 
            // txtDiagramMinX
            // 
            this.txtDiagramMinX.BackColor = System.Drawing.Color.White;
            this.txtDiagramMinX.CheckInRange = false;
            this.txtDiagramMinX.DataType = STM.DLayer.DataType.Double;
            this.txtDiagramMinX.DefaultValue = "0";
            resources.ApplyResources(this.txtDiagramMinX, "txtDiagramMinX");
            this.txtDiagramMinX.FractionalDigits = 0;
            this.txtDiagramMinX.MaxValue = "0";
            this.txtDiagramMinX.MinValue = "0";
            this.txtDiagramMinX.Name = "txtDiagramMinX";
            this.txtDiagramMinX.Resolution = 0D;
            this.txtDiagramMinX.Text = "0";
            this.txtDiagramMinX.Tip = null;
            // 
            // llOk
            // 
            resources.ApplyResources(this.llOk, "llOk");
            this.llOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llOk.Name = "llOk";
            this.llOk.TabStop = true;
            this.llOk.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOk_LinkClicked);
            // 
            // FrmFixedScale
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.llOk);
            this.Controls.Add(this.llCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.lbDiagramYUnitMax);
            this.Controls.Add(this.lbDiagramXUnitMax);
            this.Controls.Add(this.lbDiagramYUnitMin);
            this.Controls.Add(this.lbDiagramXUnitMin);
            this.Controls.Add(this.label84);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.label81);
            this.Controls.Add(this.label82);
            this.Controls.Add(this.txtDiagramYSteps);
            this.Controls.Add(this.txtDiagramXSteps);
            this.Controls.Add(this.txtDiagramMaxY);
            this.Controls.Add(this.txtDiagramMinY);
            this.Controls.Add(this.txtDiagramMaxX);
            this.Controls.Add(this.txtDiagramMinX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFixedScale";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lbDiagramYUnitMax;
        private System.Windows.Forms.Label lbDiagramXUnitMax;
        private System.Windows.Forms.Label lbDiagramYUnitMin;
        private System.Windows.Forms.Label lbDiagramXUnitMin;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private NRTextBox txtDiagramYSteps;
        private NRTextBox txtDiagramXSteps;
        private NRTextBox txtDiagramMaxY;
        private NRTextBox txtDiagramMinY;
        private NRTextBox txtDiagramMaxX;
        private NRTextBox txtDiagramMinX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llCancel;
        private System.Windows.Forms.LinkLabel llOk;
    }
}