namespace STM.PLayer.Other
{
    partial class InputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
            this.lbMsg = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.llOk = new System.Windows.Forms.LinkLabel();
            this.llCancel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.Name = "lbMsg";
            // 
            // txtInput
            // 
            resources.ApplyResources(this.txtInput, "txtInput");
            this.txtInput.Name = "txtInput";
            // 
            // llOk
            // 
            resources.ApplyResources(this.llOk, "llOk");
            this.llOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llOk.Name = "llOk";
            this.llOk.TabStop = true;
            this.llOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOk_LinkClicked);
            // 
            // llCancel
            // 
            resources.ApplyResources(this.llCancel, "llCancel");
            this.llCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llCancel.Name = "llCancel";
            this.llCancel.TabStop = true;
            this.llCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCancel_LinkClicked);
            // 
            // InputDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.llCancel);
            this.Controls.Add(this.llOk);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.LinkLabel llOk;
        private System.Windows.Forms.LinkLabel llCancel;
    }
}