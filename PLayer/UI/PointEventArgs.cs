using System;

namespace STM.PLayer.UI
{
    public class PointEventArgs : EventArgs
    {
        public double X { set; get; }
        public MeasureType XType { set; get; }
        public string Unit { set; get; }
    }
}