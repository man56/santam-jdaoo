namespace STM.PLayer.UI
{
    partial class MeasureMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasureMonitor));
            this.lbUnit = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbMeasure = new System.Windows.Forms.Label();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.bttnZero = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUnit
            // 
            resources.ApplyResources(this.lbUnit, "lbUnit");
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbUnit_MouseClick);
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.tblLayout.SetColumnSpan(this.lbName, 2);
            this.lbName.Name = "lbName";
            this.lbName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbName_MouseClick);
            // 
            // lbMeasure
            // 
            resources.ApplyResources(this.lbMeasure, "lbMeasure");
            this.lbMeasure.Name = "lbMeasure";
            // 
            // tblLayout
            // 
            resources.ApplyResources(this.tblLayout, "tblLayout");
            this.tblLayout.Controls.Add(this.lbName, 0, 0);
            this.tblLayout.Controls.Add(this.lbUnit, 0, 2);
            this.tblLayout.Controls.Add(this.lbMeasure, 0, 1);
            this.tblLayout.Name = "tblLayout";
            // 
            // bttnZero
            // 
            resources.ApplyResources(this.bttnZero, "bttnZero");
            this.bttnZero.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.bttnZero.ForeColor = System.Drawing.Color.Red;
            this.bttnZero.Name = "bttnZero";
            this.bttnZero.UseVisualStyleBackColor = true;
            this.bttnZero.Click += new System.EventHandler(this.bttnZero_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bttnZero);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // MeasureMonitor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tblLayout);
            this.Name = "MeasureMonitor";
            this.Load += new System.EventHandler(this.MeasureMonitor_Load);
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbMeasure;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Button bttnZero;
        private System.Windows.Forms.Panel panel1;
    }
}