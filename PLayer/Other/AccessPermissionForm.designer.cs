namespace STM
{
    partial class AccessPermissionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessPermissionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.AcceptCommand = new System.Windows.Forms.Button();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // PasswordInput
            // 
            resources.ApplyResources(this.PasswordInput, "PasswordInput");
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Enter += new System.EventHandler(this.PasswordInput_Enter);
            // 
            // AcceptCommand
            // 
            resources.ApplyResources(this.AcceptCommand, "AcceptCommand");
            this.AcceptCommand.Name = "AcceptCommand";
            this.AcceptCommand.UseVisualStyleBackColor = true;
            this.AcceptCommand.Click += new System.EventHandler(this.AcceptCommand_Click);
            // 
            // CancelCommand
            // 
            resources.ApplyResources(this.CancelCommand, "CancelCommand");
            this.CancelCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.UseVisualStyleBackColor = true;
            this.CancelCommand.Click += new System.EventHandler(this.CancelCommand_Click);
            // 
            // AccessPermissionForm
            // 
            this.AcceptButton = this.AcceptCommand;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelCommand;
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.AcceptCommand);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccessPermissionForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button AcceptCommand;
        private System.Windows.Forms.Button CancelCommand;
    }
}