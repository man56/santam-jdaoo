using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using STM.BLayer.StmTest;
using STM.Properties;

namespace STM
{

    public partial class LanguageFrm : Form
    {
        public static readonly string EnglishCulture =Resources.LanguageFrm_EnglishCulture_en;
        public static readonly string PersianCulture =Resources.LanguageFrm_PersianCulture_fa;
        public static readonly string RussianCulture =Resources.LanguageFrm_RussianCulture_ru;

        public static string LanguageName { set; get; }


        public LanguageFrm()
        {
            InitializeComponent();
        }

        private void LanguageFrm_Load(object sender, System.EventArgs e)
        {
            if (LanguageName == EnglishCulture)
                LanguageList.SelectedIndex = 0;
            else if (LanguageName == PersianCulture)
                LanguageList.SelectedIndex = 1;
            else if (LanguageName == RussianCulture)
                LanguageList.SelectedIndex = 2;
            else
                LanguageList.SelectedIndex = 0;

            DialogResult = DialogResult.None;
        }

        private void LanguageList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            switch (LanguageList.SelectedIndex)
            {
                case 0:
                    LanguageName = EnglishCulture;
                    break;
                case 1:
                    LanguageName = PersianCulture;
                    break;
                case 2:
                    LanguageName = RussianCulture;
                    break;
            }

            Options.ShowLanguageForm = !chkDontShowAgain.Checked;
            DialogResult = DialogResult.OK;

			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(LanguageName);

        }

        public static bool IsEnglish
        {
            get { return LanguageName == EnglishCulture; }
        }

        public static bool IsPersian
        {
            get { return LanguageName == PersianCulture; }
        }

        public static bool IsRussian
        {
            get { return LanguageName == RussianCulture; }
        }
    }

}

