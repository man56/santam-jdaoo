using System;

namespace STM.PLayer.Open
{
    partial class FrmOpenFileDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpenFileDialog));
            this.llOpen = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.flb = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dirExplorer = new STM.PLayer.Open.ExplorerTree();
            this.SuspendLayout();
            // 
            // llOpen
            // 
            resources.ApplyResources(this.llOpen, "llOpen");
            this.llOpen.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llOpen.Name = "llOpen";
            this.llOpen.TabStop = true;
            this.llOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpen_LinkClicked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtPath
            // 
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtMode
            // 
            resources.ApplyResources(this.txtMode, "txtMode");
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            // 
            // txtCustomer
            // 
            resources.ApplyResources(this.txtCustomer, "txtCustomer");
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            // 
            // txtArea
            // 
            resources.ApplyResources(this.txtArea, "txtArea");
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            // 
            // txtComments
            // 
            resources.ApplyResources(this.txtComments, "txtComments");
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // flb
            // 
            resources.ApplyResources(this.flb, "flb");
            this.flb.FormattingEnabled = true;
            this.flb.Name = "flb";
            this.flb.Pattern = "*.ttdx*.ttd";
            this.flb.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.flb.SelectedIndexChanged += new System.EventHandler(this.flb_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dirExplorer
            // 
            resources.ApplyResources(this.dirExplorer, "dirExplorer");
            this.dirExplorer.BackColor = System.Drawing.Color.Black;
            this.dirExplorer.Name = "dirExplorer";
            this.dirExplorer.SelectedPath = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Enterprise\\Common7\\IDE";
            this.dirExplorer.PathChanged += new STM.PLayer.Open.ExplorerTree.PathChangedEventHandler(this.dirExplorer_PathChanged);
            // 
            // FrmOpenFileDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dirExplorer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flb);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.llOpen);
            this.Controls.Add(this.txtArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpenFileDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox flb;
        private System.Windows.Forms.Label label1;
        private ExplorerTree dirExplorer;

        public event EventHandler<EventArgs> OnOperationDone;
    }
}