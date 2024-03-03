using System.Windows.Forms;

namespace STM
{

    public partial class LanguageFrm : Form
    {
        public static string LanguageName { set; get; }
        public LanguageFrm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LanguageName = "fa-IR";
            DialogResult = DialogResult.OK;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LanguageName = "en-US";
            DialogResult = DialogResult.OK;
        }


    }

}

