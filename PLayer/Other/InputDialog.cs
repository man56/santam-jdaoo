using System;
using System.Windows.Forms;

namespace STM.PLayer.Other
{
    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
        }

        private void llOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public string Msg
        {
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                lbMsg.Text = value;
            }
        }

        public string UserInput
        {
            get { return txtInput.Text; }
        }
    }
}
