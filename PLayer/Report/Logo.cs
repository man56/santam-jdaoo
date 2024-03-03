using System;
using System.Drawing;

namespace STM.PLayer.Report
{
    public class Logo
    {
        public string CompanyName { set; get; }
        public string Discription { set; get; }
        public string Detail { set; get; }
        public Bitmap LogoBmp { set; get; }
        public string LogoPath { set; get; }
        public bool LTR { set; get; }

        public int Width { set; get; }
        public int Height { set; get; }

        public Font FontCompanyName { set; get; }
        public Font FontDiscription { set; get; }
        public Font FontDetail { set; get; }

        public Color ForeColor { set; get; }

        public Logo()
        {
            ForeColor = Color.Black;
            Width = 100;
            Height = 100;
        }

        public Bitmap GetReportLogo()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics gph = Graphics.FromImage(bmp);
            gph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            gph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            gph.TextContrast = 10;
            var max = 0;
            var hM = false;
            int logoW = 0;
            int logoH = 0;
            if (LogoBmp != null)
            {
                max = Math.Max(LogoBmp.Height, LogoBmp.Width);
                hM = max == LogoBmp.Height;
                logoW = (int)(hM ? Height * 1.0 / LogoBmp.Height * LogoBmp.Width : Width * 0.2);
                logoH = (int)(hM ? Height : Height - 1.0 / LogoBmp.Height * LogoBmp.Width);
            }

            if (LogoBmp != null)
                if (LTR)
                {
                    gph.DrawImage(LogoBmp, new Rectangle(Width - logoW, Height - logoH, logoW - 4, logoH - 4));
                }
                else
                {
                    gph.DrawImage(LogoBmp, new Rectangle(0, 0, logoW - 4, logoH - 4));
                }
            try
            {
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    StringFormat sf = new StringFormat() { Alignment = LTR ? StringAlignment.Near : StringAlignment.Near };
                    gph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    int y = 0;
                    gph.DrawString(CompanyName, FontCompanyName, brush, new Rectangle(LTR ? 0 : logoW, 0, Width - logoW, (int)FontCompanyName.GetHeight() + 1), sf);
                    y += (int)FontCompanyName.GetHeight();
                    gph.DrawString(Discription, FontDiscription, brush, new Rectangle(LTR ? 0 : logoW, y, Width - logoW, (int)FontDiscription.GetHeight() + 1), sf);
                    y += (int)FontDiscription.GetHeight();
                    gph.DrawString(Detail, FontDetail, brush, new Rectangle(LTR ? 0 : logoW, y, Width - logoW, Height), sf);
                    gph.DrawLine(Pens.Black, 0, Height - 2, Width, Height - 2);
                }
            }
            catch
            {
            }
            return bmp;
        }
    }
}
