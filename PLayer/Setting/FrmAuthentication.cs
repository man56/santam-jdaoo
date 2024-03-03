using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using STM.Properties;

namespace STM.PLayer.UI
{
    public partial class AuthenticationFrm : Form
    {
        public string Password { set; get; }
        public AuthenticationFrm()
        {
            Password = "";
            InitializeComponent();
            ComponentResourceManager rcm = new ComponentResourceManager(typeof (AuthenticationFrm));
            CultureInfo cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            foreach (Control control in Controls)
                rcm.ApplyResources(control, control.Name, cultureInfo);
        }

        private void lbttnCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lbttnOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPassWord.Text.Equals(Password))
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show(Resources.AuthenticationFrm_Invalid_password_, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
