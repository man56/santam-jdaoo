using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using STM.BLayer.Configurations;

namespace STM.PLayer.Report
{
    public partial class LogoTool : UserControl
    {
        public Font FontCompany { set; get; }
        public Font FontDiscription { set; get; }
        public Font FontDetail { set; get; }
        Logo logo;

        public new string CompanyName
        {
            set { txtComanyName.Text = value; }
            get { return txtComanyName.Text; }
        }

        public string Description
        {
            set { txtDescription.Text = value; }
            get { return txtDescription.Text; }
        }

        public string Detail
        {
            set { txtDetail.Text = value; }
            get { return txtDetail.Text; }
        }

        public string LogoPath { set; get; }
        public bool Changed { set; get; }

        public event EventHandler<EventArgs> OnPreview;

        public void InvokeOnPreview(EventArgs E)
        {
            var handler = OnPreview;
            if (handler != null) handler(this, E);
        }

        public LogoTool()
        {
            InitializeComponent();
            var rcm = new ComponentResourceManager(typeof(LogoTool));
			try
			{
				var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
				rcm.ApplyResources(this, "$this", cultureInfo);
				SetCulture(Controls, rcm, cultureInfo);
			}
			catch { }
        }

   
        private void SetCulture(ControlCollection controls, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                    SetCulture(control.Controls, rcm, cultureInfo);
                else
                {
                    rcm.ApplyResources(control, control.Name, cultureInfo);
                }
            }
        }
       
        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                pbLogo.BackgroundImage = new Bitmap(LogoPath);
                pbLogo.BackgroundImageLayout = ImageLayout.Zoom;
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        private void llBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = @"(Bitmap)*.bmp|*.bmp |(Jpeg)*.jpeg|*.jpeg|(Jpg)*jpg|*.jpg|All Files(*.*)|*.*";
                ofd.Multiselect = false;
                try
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ofd.RestoreDirectory = true;
                        LogoPath = ofd.FileName;
                        pbLogo.BackgroundImage = new Bitmap(LogoPath);
                        LogoPath = ofd.FileName;
                        pbLogo.BackgroundImageLayout = ImageLayout.Zoom;
                        Changed = true;
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
            }
        }

        private void llCompanyFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontCompany = GetFont(FontCompany);
            if (FontCompany != null)
                txtComanyName.Font = new Font(FontCompany.Name, 11f, FontCompany.Style);
        }

        private void llDiscriptionFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontDiscription = GetFont(FontDiscription);
            if (FontDiscription != null) 
            txtDescription.Font = new Font(FontDiscription.Name, 11f, FontDiscription.Style);
        }

        private void llDetailFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontDetail = GetFont(FontDetail);
            if(FontDetail!=null)
                txtDetail.Font = new Font(FontDetail.Name, 11f, FontDetail.Style);
        }

        private Font GetFont(Font curfont)
        {
            Font retFont = null;
            using (var fd = new FontDialog())
            {
                fd.FontMustExist = true;
                if (curfont != null)
                    fd.Font = curfont;
               
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    retFont = fd.Font;
                    Changed = true;
                }
            }

            return retFont;
        }

        private void llPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Preview();
            //OnPreview(this, EventArgs.Empty);
        }
  
        private void Preview()
        {
            logo = new Logo
                       {
                           Width = pbPreview.Width,
                           LogoPath = LogoPath,
                           Height = pbPreview.Height,
                           LTR = cbLTR.Checked,
                           LogoBmp = string.IsNullOrEmpty(LogoPath) ? null : new Bitmap(LogoPath),
                           FontCompanyName = FontCompany,
                           FontDetail = FontDetail,
                           FontDiscription = FontDiscription,
                           CompanyName = CompanyName,
                           Discription = Description,
                           Detail = Detail
                       };

            pbPreview.BackgroundImage = logo.GetReportLogo();
            pbPreview.BackgroundImageLayout = ImageLayout.Tile;
        }

        private void llLoad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Load();
        }

        internal void Load()
        {
            try
            {
                using (var sl = SettingLoader.Current)
                {
                    logo = sl.LoadLogo();
                }
                SetLogoFields();
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        private void llSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SettingLoader sl = SettingLoader.Current)
            {
                sl.SetLogo(logo);
            }
        }

        public Logo Logo
        {
            set
            {
                try
                {
                    logo = value;
                    SetLogoFields();
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
            }
            get
            {
                return logo;
            }
        }
  
        private void SetLogoFields()
        {
            if (logo != null)
            {
                txtComanyName.Text = logo.CompanyName;
                txtDescription.Text = logo.Discription;
                txtDetail.Text = logo.Detail;

                txtComanyName.Font = logo.FontCompanyName;
                FontCompany = logo.FontCompanyName;

                txtDescription.Font = logo.FontDiscription;
                FontDiscription = logo.FontDiscription;

                txtDetail.Font = logo.FontDetail;
                FontDetail = logo.FontDetail;

                cbLTR.Checked = logo.LTR;
                LogoPath = logo.LogoPath;

                pbLogo.BackgroundImage = new Bitmap(LogoPath);
                pbLogo.BackgroundImageLayout = ImageLayout.Zoom;
            }
            Preview();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbLogo.BackgroundImage = null;
            LogoPath = "";
        }
    }
}
