using STM.BLayer.Parameters;
using System;
using System.Linq;

namespace STM.PLayer.UI
{
    public class ZoomFrame
    {
        public static bool EnableStartUpSacle { set; get; }
        public double ScaledMinX { set; get; } // min x
        public double ScaledMaxX { set; get; } // max x
        public double ScaledMinY { set; get; } // min y
        public double ScaledMaxY { set; get; } // max y
		public double ScaledMinY2 { set; get; } // min y
		public double ScaledMaxY2 { set; get; } // max y

		public double Factor { set; get; }

        public bool IsPan { set; get; }
        public double MinX { set; get; } // min x
        public double MaxX { set; get; } // max x
        public double MinY { set; get; } // min y
        public double MaxY { set; get; } // max y
		public double MinY2 { set; get; } // min t
		public double MaxY2 { set; get; } // max t
        public bool KeepY2 { get; set; }

		public int? XSteps { set; get; }
        public int? YSteps { set; get; }
		public int? Y2Steps { set; get; }

		public double XM { set; get; }
        public double YM { set; get; }
		public double Y2M { set; get; }


		public void SetValues(double minX, double maxX, double minY, double maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }

        public void CheckValues(double x, double y)
        {
            if(EnableStartUpSacle)
                return;
            MinX = Math.Min(x, MinX);
            MaxX = Math.Max(x, MaxX);
            MinY = Math.Min(y, MinY);
            MaxY = Math.Max(y, MaxY);
        }

        public void CheckValues(double[] tp, double temperatureSetPoint)
        {
            //// if (EnableStartUpSacle) return;
            //// 980319
            //var maxY2 = tp.Where(t => t > 0).Max();
            //var minY2 = Math.Min(tp.Where(t => t > 0).Min(), .9 * maxY2);
            //// 991014
            //MaxY2 = Math.Max(maxY2 * 1.1, MaxY2);
            //MinY2 = Math.Min(minY2, tp.Where(t => t > 0).Min() * 0.9);
            // Nazarpour 1399/11/11
            MinY2 = MaxY2 = temperatureSetPoint;
            MinY2 -= InstrumentParameters.TemperatureAxisRange;
            MaxY2 += InstrumentParameters.TemperatureAxisRange;
            if (MinY2 < 0) MinY2 = 0;
        }

        private double Min(double v1, double v2, double v3, double v4)
        {
            var v = v1;
            if (v2 < v) v = v2;
            if (v3 < v) v = v3;
            if (v4 < v) v = v4;
            return v;
        }

        private double Max(double v1, double v2, double v3, double v4)
        {
            var v = v1;
            if (v2 > v) v = v2;
            if (v3 > v) v = v3;
            if (v4 > v) v = v4;
            return v;
        }

        public bool XReversed
        {
            get { return (MinX < 0 && Math.Abs(MinX) > Math.Abs(MaxX) && !IsPan); }
        }

        public bool YReversed
        {
            get { return (MinY < 0 && Math.Abs(MinY) > Math.Abs(MaxY) && !IsPan); }
        }

		public bool Y2Reversed
		{
            get { return YReversed; } // (MinY2 < 0 && Math.Abs(MinY2) > Math.Abs(MaxY2) && !IsPan); }
		} 

		public void SetZoomedXY()
        {
            ScaledMinX = MinX;
            ScaledMaxX = MaxX;
            ScaledMinY = MinY;
            ScaledMaxY = MaxY;
			ScaledMinY2 = MinY2;
			ScaledMaxY2 = MaxY2;
		}

        public ZoomFrame Clone()
        {
			var snapShot = new ZoomFrame
			{
				ScaledMinX = ScaledMinX,
				ScaledMaxX = ScaledMaxX,
				ScaledMinY = ScaledMinY,
				ScaledMaxY = ScaledMaxY,
				Factor = Factor,
				IsPan = IsPan,
				MinX = MinX,
				MaxX = MaxX,
				MinY = MinY,
				MaxY = MaxY,
				XSteps = XSteps,
				YSteps = YSteps,
				XM = XM,
				YM = YM
								   ,
				ScaledMaxY2 = ScaledMaxY2,
				MinY2 = MinY2,
				MaxY2 = MaxY2,
				Y2Steps=Y2Steps,
				Y2M = Y2M
			};
            return snapShot;
        }

        public void AddMargin()
        {
            ScaledMinX *= 1.1;
            ScaledMaxX *= 1.1;
            ScaledMinY *= 1.1;
            ScaledMaxY *= 1.1;           
            // Nazarpour 1399/11/11
          //  ScaledMinY2 -= InstrumentParameters.TemperatureAxisRange > 0 ? InstrumentParameters.TemperatureAxisRange :  .1* ScaledMinY2;
           // ScaledMaxY2 += InstrumentParameters.TemperatureAxisRange > 0 ? InstrumentParameters.TemperatureAxisRange : .1 * ScaledMinY2;

        }

        internal void CheckMaxs()
        {
            if (ScaledMaxX == ScaledMinX)
                ScaledMaxX++;
            if (ScaledMinY == ScaledMaxY)
                ScaledMaxY++;
            // Nazarpour 1400/04/21
            //if (ScaledMinY2 == ScaledMaxY2)
            //	ScaledMaxY2++;
        }
    }
}