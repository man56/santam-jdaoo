using System;

namespace STM.PLayer.UI
{
    static class PlotAligner
    {
        private static readonly double[] XAutoStep = new[] { 0, 0.1, 0.2, 0.25, 0.5, 0.5, 0.5, 1, 1, 1, 1 };
        private static readonly double[] YAutoStep = new[] { 0, 0.1, 0.2, 0.25, 0.5, 0.5, 0.5, 1, 1, 1, 1 };

        public static double XStep { private set; get; }
        public static double YStep { private set; get; }
		public static double Y2Step { private set; get; }

		public static void GetSteps(double xMin, double xMax, double yMin, double yMax, out double xStart, out double yStart)
        {
            XStep = xMax - xMin;
            YStep = yMax - yMin;

            var m = XStep;
            var n = 1.0;

            if (double.IsInfinity(m) || double.IsInfinity(n))
            {
                xStart = SetXGridStart(0, 0);
                yStart = SetYGridStart(0, 0);
                return;
            }

            while (m >= 10)
            {
                m /= 10;
                n *= 10;
            }
            while (0 < m && m < 1)
            {
                m *= 10;
                n /= 10;
            }
            XStep = XAutoStep[(int) Math.Ceiling(m)] * n;
            xStart = SetXGridStart(xMin, xMax);

            m = YStep;
            n = 1.0;
            while (m >= 10)
            {
                m /= 10;
                n *= 10;
            }
            while (0 < m && m < 1)
            {
                m *= 10;
                n /= 10;
            }

            YStep = YAutoStep[(int) m] * n;

            yStart = SetYGridStart(yMin, yMax);
        }

        // Nazarpour
		public static double GetSteps(double yMin, double yMax, int grids)
		{
            // 980319
            //yMax = yMax + .1 * yMax;
            //yMin = yMin - .1 * yMin;

            Y2Step = yMax - yMin;

			var m = Y2Step;
			var n = 1.0;
			while (m >= 10)
			{
				m /= 10;
				n *= 10;
			}
			while (0 < m && m < 1)
			{
				m *= 10;
				n /= 10;
			}

			Y2Step = YAutoStep[(int)m] * n;

			return SetY2GridStart(yMin, yMax);
		}

		public static void GetFixedScaleSteps(double xMin, double xMax, double yMin, double yMax, int xStepCount, int yStepCount, out double xStart, out double yStart)
        {
            XStep = (xMax - xMin)/xStepCount;
            YStep = (yMax - yMin)/yStepCount;

            xStart = SetXGridStart(xMin, xMax);
            yStart = SetYGridStart(yMin, yMax);
        }

        private static double SetXGridStart(double xMin, double xMax)
        {
            var m = -XStep;

            if (m > xMax)
            {
                m = (int)(xMax / XStep) * XStep;
                if (m != xMax)
                    m -= XStep;
            }
            if (m - XStep > m)
            {
                if (0 < xMin)
                {
                    m = (int)(xMin / XStep) * XStep;
                    if (m != xMin)
                        m += XStep;
                    else
                        m = 0.0;
                }
            }

            if (0 < xMin)
            {
                m = (int)(xMin / XStep) * XStep;
                if (m != xMin)
                    m += XStep;
                else
                    m = 0.0;
            }

            if (xMin < 0)
            {
                m = (int)(xMin / XStep) * XStep;
                if (m == xMin)
                    m -= XStep;
            }
            return m;
        }

        public static double SetXGridStart(double xMin, double xMax, double step)
        {
            var m = -step;

            if (m > xMax)
            {
                m = (int)(xMax / step) * step;
                if (m != xMax)
                    m -= step;
            }
            if (m - XStep > m)
            {
                if (0 < xMin)
                {
                    m = (int)(xMin / step) * step;
                    if (m != xMin)
                        m += step;
                    else
                        m = 0.0;
                }
            }

            if (0 < xMin)
            {
                m = (int)(xMin / step) * step;
                if (m != xMin)
                    m += step;
                else
                    m = 0.0;
            }

            if (xMin < 0)
            {
                m = (int)(xMin / step) * step;
                if (m == xMin)
                    m -= step;
            }
            return m;
        }

        private static double SetYGridStart(double yMin, double yMax)
        {
            var m = -YStep;

            if (m > yMax)
            {
                m = (int)(yMax / YStep) * YStep;
                if (m != yMax)
                    m -= YStep;
            }
            if (m - YStep > m)
            {
                if (0 < yMin)
                {
                    m = (int)(yMin / YStep) * YStep;
                    if (m != yMin)
                        m += YStep;
                    else
                        m = 0.0;
                }
            }

            if (0 < yMin)
            {
                m = (int)(yMin / YStep) * YStep;
                if (m != yMin)
                    m += YStep;
                else
                    m = 0.0;
            }

            if (yMin < 0)
            {
                m = (int)(yMin / YStep) * YStep;
                if (m == yMin)
                    m -= YStep;
            }

            return m;
        }

		private static double SetY2GridStart(double yMin, double yMax)
		{
			var m = -Y2Step;

			if (m > yMax)
			{
				m = (int)(yMax / Y2Step) * Y2Step;
				if (m != yMax)
					m -= Y2Step;
			}
			if (m - Y2Step > m)
			{
				if (0 < yMin)
				{
					m = (int)(yMin / Y2Step) * Y2Step;
					if (m != yMin)
						m += Y2Step;
					else
						m = 0.0;
				}
			}

			if (0 < yMin)
			{
				m = (int)(yMin / Y2Step) * Y2Step;
				if (m != yMin)
					m -= Y2Step;
				else
					m = 0.0;
			}

			if (yMin < 0)
			{
				m = (int)(yMin / Y2Step) * Y2Step;
				if (m == yMin)
					m -= Y2Step;
			}

			return m;
		}

		public static int SetYGridStart(double yMin, double yMax, double step)
        {
            var m = -step;

            if (m > yMax)
            {
                m = (int)(yMax / step) * step;
                if (m != yMax)
                    m -= step;
            }
            if (m - step > m)
            {
                if (0 < yMin)
                {
                    m = (int)(yMin / step) * step;
                    if (m != yMin)
                        m += step;
                    else
                        m = 0.0;
                }
            }

            if (0 < yMin)
            {
                m = (int)(yMin / step) * step;
                if (m != yMin)
                    m += step;
                else
                    m = 0.0;
            }

            if (yMin < 0)
            {
                m = (int)(yMin / step) * step;
                if (m == yMin)
                    m -= step;
            }

            return (int)m;
        }

        public static int GetFitMaxX(double value, ref double bound)
        {
            bound = 0;

            var grids = 0;
            if (value == 0)
            {
                bound = 0;
                return 1;
            }
            double digits = GetDigits(value);
            double dif = Math.Abs(value);
            var mx = Math.Pow(10, digits);
            mx = mx == 0 ? 1 : mx;
            var msb = (int) (dif/mx);

            if (msb == 0)
            {
                msb = (int) (10.0*dif/mx);
                mx /= 10;
            }
            var sign = Math.Sign(value);
            if (msb < 1)
            {
                grids = 10;
                bound = 1 * mx * sign;
            }
            else if (msb < 2)
            {
                grids = 8; // 20;
                bound = 2*mx*sign;
            }
            else if (msb < 3)
            {
                grids = 12; // 15;
                bound = 3 * mx * sign;
            }
            else if (msb < 4)
            {
                grids = 8; // 16;
                bound = 4 * mx * sign;
            }
            else if (msb < 5) //
            {
                grids = 10;
                bound = 5 * mx * sign;
            }
            else if (msb < 6)
            {
                grids = 12;
                bound = 6 * mx * sign;
            }
            else if (msb < 10)
            {
                grids = 10;
                bound = 10 * mx * sign;
            }
            else if (msb == 10)
            {
                grids = 11;
                bound = 11 * mx * sign;
            }

            return grids;
        }

        public static int GetFitMaxY(double value, ref double bound)
        {
            bound = 0;
            var grids = 0;
            if (value == 0)
            {
                bound = 0;
                return 1;
            }

            double digits = GetDigits(value);
            double dif = Math.Abs(value);
            var my = Math.Pow(10, digits);
            var msb = (int)(dif / my);

            if (msb == 0)
            {
                msb = (int)(10.0 * dif / my);
                my /= 10;
            }

            var sign = Math.Sign(value);
            if (msb < 1)
            {
                grids = 11;
                bound = 1.1 * my * sign;
            }
            else if (msb < 2)
            {
                grids = 9;
                bound = 2.25 * my * sign;
            }
            else if (msb < 5)
            {
                grids = 11;
                bound = 5.5 * my * sign;
            }
            else if (msb < 9)
            {
                grids = 10;
                bound = 10 * my * sign;
            }
            else if (msb < 10)
            {
                grids = 11;
                bound = 11 * my * sign;
            }

            return grids;
        }

        public static int GetDigits(double value)
        {
            try
            {
                var dif = Math.Abs(value);
                dif = (dif == 1
                      ? 1.0001 :
                      dif);
                var sign = Math.Sign(Math.Log10(dif));
                return (int)Math.Ceiling(Math.Abs(Math.Log10(dif))) * sign;
            }
            catch { return 0; }
        }
    }
}