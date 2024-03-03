using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace STM.PLayer.Print
{
    public class Printting : IComponent
    {
        public PrintDocument PrintDoc { set; get; }
        public PrintPreviewDialog PrintPreview { set; get; }
        public PrintDialog PrintDialog { set; get; }
        public PageSetupDialog PageSetupDialog { set; get; }
        private List<Bitmap> printList;
        private int lastY;
        private Rectangle boundsRectangle;
        public Printting()
        {
            Initilize();
        }

        private int printIndex;

        public void Initilize()
        {
            PrintDoc = new PrintDocument();
            PrintPreview = new PrintPreviewDialog { Document = PrintDoc };
            PrintDialog = new PrintDialog { Document = PrintDoc };
            PageSetupDialog = new PageSetupDialog();
            printList = new List<Bitmap>();
            PrintDoc.PrintPage += PrintDoc_PrintPage;
            PrintDoc.EndPrint += PrintDoc_EndPrint;
        }

        public void ShowPrintPreview()
        {
            PrintPreview.ShowInTaskbar = true;
            PrintPreview.ShowDialog();
        }

        public void ShowPageSetupDialog()
        {
            PageSetupDialog.PageSettings = PrintDoc.DefaultPageSettings;
            if (PageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDoc.DefaultPageSettings = PageSetupDialog.PageSettings;
            }
        }

        public Rectangle GetMarginBounds()
        {
            boundsRectangle = PrintDoc.PrinterSettings.DefaultPageSettings.Bounds;
            boundsRectangle.X = PrintDoc.PrinterSettings.DefaultPageSettings.Margins.Left;
            boundsRectangle.Y = PrintDoc.PrinterSettings.DefaultPageSettings.Margins.Top;
            boundsRectangle.Width -= PrintDoc.PrinterSettings.DefaultPageSettings.Margins.Left +
                               PrintDoc.PrinterSettings.DefaultPageSettings.Margins.Right;
            boundsRectangle.Height -= PrintDoc.PrinterSettings.DefaultPageSettings.Margins.Top +
                               PrintDoc.PrinterSettings.DefaultPageSettings.Margins.Bottom;
            return boundsRectangle;
        }

        public int GetPageRemaingSpaceHeight()
        {
            return boundsRectangle.Height - lastY;
        }

        public void SetPrintData(IEnumerable<Bitmap> printObjects)
        {
            printIndex = 0;
            printList = printObjects.ToList();

        }

        public void Print()
        {
            try
            {
                PrintDoc.Print();
            }
            catch { }
        }

        private void PrintDoc_EndPrint(object Sender, PrintEventArgs E)
        {
            printList.Clear();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var y = 0;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextContrast = 12;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit; 
            for (; printIndex < printList.Count; printIndex++)
            {
                if (printList[printIndex].Height + y > e.PageBounds.Height)
                {
                    e.HasMorePages = true;
                    break;
                }
                e.Graphics.DrawImage(
                    printList[printIndex],
                    new Rectangle(e.MarginBounds.X, y, printList[printIndex].Width, printList[printIndex].Height),
                    new Rectangle(0, 0, printList[printIndex].Width, printList[printIndex].Height),
                    GraphicsUnit.Pixel);
                y += printList[printIndex].Height;
                lastY = y;
            }
        }

        public void Dispose()
        {

        }

        public ISite Site { get; set; }
        public event EventHandler Disposed;
    }
}
