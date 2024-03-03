using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STM
{
    public partial class AccessPermissionForm : Form
    {
        public string RequiredPassword { get; set; }

        public int RetryCount { get; set; }

        public AccessPermissionForm()
        {
            InitializeComponent();
        }

        private void CancelCommand_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AcceptCommand_Click(object sender, EventArgs e)
        {
            if (PasswordInput.Text == RequiredPassword)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (RetryCount-- > 0)
            {
                if (MessageBox.Show(this, "Password was incorrect, please check your input and try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk) != DialogResult.Retry)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                } else
                {
                    PasswordInput.Select();
                }
            }
            else
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void PasswordInput_Enter(object sender, EventArgs e)
        {
            PasswordInput.SelectAll();
        }
    }
}
