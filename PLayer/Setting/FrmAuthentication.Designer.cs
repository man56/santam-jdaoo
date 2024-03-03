using System.ComponentModel;
using System.Globalization;

namespace STM.PLayer.UI
{
    partial class AuthenticationFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbttnOk = new System.Windows.Forms.LinkLabel();
            this.lbttnCancel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPassWord
            // 
            resources.ApplyResources(this.txtPassWord, "txtPassWord");
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbttnOk
            // 
            resources.ApplyResources(this.lbttnOk, "lbttnOk");
            this.lbttnOk.Name = "lbttnOk";
            this.lbttnOk.TabStop = true;
            this.lbttnOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbttnOk_LinkClicked);
            // 
            // lbttnCancel
            // 
            resources.ApplyResources(this.lbttnCancel, "lbttnCancel");
            this.lbttnCancel.Name = "lbttnCancel";
            this.lbttnCancel.TabStop = true;
            this.lbttnCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbttnCancel_LinkClicked);
            // 
            // AuthenticationFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbttnCancel);
            this.Controls.Add(this.lbttnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthenticationFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
       
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbttnOk;
        private System.Windows.Forms.LinkLabel lbttnCancel;
    }
}