using System;
using System.Drawing;

namespace STM.PLayer.Report
{
    public class ColorPreviewEventArgs : EventArgs
    {
        public Color Color { set; get; }
        public ColorSection SectionName { set; get; }
    }
}