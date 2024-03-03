using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using STM.BLayer.StmTest;

namespace STM.PLayer.UI
{
    public class PlotDataSource
    {
        private int id;

        public bool Invalid { set; get; }
        public static int XGridsCount { set; get; }
        public static int YGridsCount { set; get; }
		public static int Y2GridsCount { set; get; }

		private static int w;
        private static int h;

       
        public static int MarginLeft { set; get; }
        public static int MarginTop { set; get; }
        public static int MarginRight { set; get; }
        public static int MarginBottom { set; get; }

        private static Size _DrawingSize = Size.Empty;

        public static Size DrawingSize
        {
            set
            {
                _DrawingSize = value;

                w = _DrawingSize.Width - MarginLeft - MarginRight;
                h = _DrawingSize.Height - MarginTop - MarginBottom;
            }
        }

        public bool XReversed { get { return curZoomFrame.XReversed; } }
        public bool YReversed { get { return curZoomFrame.YReversed; } }
		public bool Y2Reversed { get { return curZoomFrame.Y2Reversed; } }

		public List<TestDataSource> DataSources; 
        public TestDataSource CurTestSource;
        private readonly Stack<ZoomFrame> zoomStack;
        private ZoomFrame curZoomFrame;

       
        public List<DataSample> Indicators;
        


        public double StartX { set; get; }
        public double StartY { set; get; }
		public double StartY2 { set; get; }
		public double XStep { set; get; }
        public double YStep { set; get; }

        private double _Y2Step = 0;

        public double Y2Step
        {
            get { return Program.FullCreepAvailable ? _Y2Step : 0; }
            set { _Y2Step = value; }
        }
		//public int yScaleWidth { set; get; }
		public PlotDataSource()
        {
            DataSources = new List<TestDataSource>();
            zoomStack = new Stack<ZoomFrame>();
            id = 0;
        }
        public void NewTest(double maxX, double maxY, bool enbaleStartScale = false)
        {
            id = 0;
            ZoomFrame.EnableStartUpSacle = enbaleStartScale;
            if(enbaleStartScale)
            {
                curZoomFrame = new ZoomFrame { Factor = 1, MinX = 0, MinY = 0, MaxY = maxY, MaxX = maxX, MinY2 = 0, MaxY2 = 0 };
                curZoomFrame.SetZoomedXY();
                curZoomFrame.AddMargin(); 
                Scale();
            }
            else
            {
                curZoomFrame = new ZoomFrame { Factor = 1, MinX = 0, MinY = 0, MaxY = 0.5, MaxX = 0.5, MinY2 = 0, MaxY2 = 0 };
                Scale(true);
            }
          
        }

        public void FinalizTest() // aa
        {
            curZoomFrame.SetZoomedXY();
            curZoomFrame.AddMargin();
            id = 0;
            AdjustPointBuffers();//testFinished: true);

            if (CurTestSource != null)
            {
                DataSources.Clear();
                DataSources.Add(CurTestSource);
            }
            
            CurTestSource = null;
            
            //Scale();
            //zoomStack.Clear();
            //zoomStack.Push(curZoomFrame.Clone());
            FitData(true);
            Invalid = true;
        }

        public void AddDataSource(TestDataSource dataSource, double mx, double my, double mxx, double myy)
        {
            if (mx == mxx)
                mxx++;
            if (my == myy)
                myy++;
            zoomStack.Clear();
            curZoomFrame = curZoomFrame ?? new ZoomFrame {Factor = 1.0};
            if (dataSource != null)
                DataSources.Add(dataSource);
            FitData(true);
        }

        public void RemoveDataSource(string testName)
        {
            foreach (var source in DataSources)
            {
                if (!source.Name.Equals(testName)) continue;
                DataSources.Remove(source);
                break;
            }
            Invalid = true;
        }

        public void AddTestSample(DataSample sample, int decimation, double temperatureSetPoint)
        {
            id++;
            sample.ID = id;
            if (CurTestSource == null)
                return;

            CurTestSource.Samples.Add(sample);

            if (Options.HugeSampleCount > 0 && id > Options.HugeSampleCount)
                return;

            curZoomFrame.CheckValues(sample.XValue, sample.YValue);
            curZoomFrame.CheckValues(sample.Temperature, temperatureSetPoint);

            CurTestSource.MaxX = curZoomFrame.MaxX;
            CurTestSource.MinX = curZoomFrame.MinX;
            CurTestSource.MaxY = curZoomFrame.MaxY;
            CurTestSource.MinY = curZoomFrame.MinY;
            CurTestSource.MinY2 = curZoomFrame.MinY2;
            CurTestSource.MaxY2 = curZoomFrame.MaxY2;

            if (ZoomFrame.EnableStartUpSacle)
            {
                if (sample.XValue < curZoomFrame.MinX ||
                       sample.XValue > curZoomFrame.MaxX ||
                       sample.YValue < curZoomFrame.MinY ||
                       sample.YValue > curZoomFrame.MaxY)
                {
                    ZoomFrame.EnableStartUpSacle = false;
                    Scale(true);
                }
            }
            else
            {
                Scale(true);
            }
            if (CurTestSource.ForegroundDrawnPoints.Count > 1000)
                Invalid = true;

            if (Invalid)
            {
                AdjustPointBuffers(decimation: decimation);
            }
            else
            {
                double x;
                double y;
                TransformXY(sample, out x, out y);

                var point = new Point { X = (int)x, Y = (int)y };
                CurTestSource.ForegroundDrawnPoints.Add(point);

                if (sample.NumberOfTemperatureSensors > 0)
                {
                    TransformXY(sample, sample.GetValue(Plot.Y2MeasureType), out x, out y);
                    point = new Point { X = (int)x, Y = (int)y };
                    CurTestSource.TemperatureFgDrawnPoints.Add(point);
                }
            }
        }
        
        public void Scale(bool inProgressTest = false)
        {
            if (curZoomFrame == null)
                curZoomFrame = new ZoomFrame {Factor = 1};
            if (curZoomFrame.IsPan)
            {
                var tMinX = curZoomFrame.XReversed ? -curZoomFrame.ScaledMaxX : curZoomFrame.ScaledMinX;
                var tMinY = curZoomFrame.YReversed ? -curZoomFrame.ScaledMaxY : curZoomFrame.ScaledMinY;

                StartX = (int) (tMinX/XStep)*XStep;
                StartY = (int) (tMinY/YStep)*YStep;
            }
            else if (inProgressTest)
            {
                ScaleRunTimeTest();
            }
            else
            {
				if (DataSources.Count == 0)
					ScaleOfflineTest(curZoomFrame.MaxX, curZoomFrame.MinX, curZoomFrame.MaxY, curZoomFrame.MinY, curZoomFrame.XSteps, curZoomFrame.YSteps);
				else
				{
                    // 980319
                    var yStep = ScaleOfflineTest(curZoomFrame.MaxX * Plot.XM, curZoomFrame.MinX * Plot.XM, curZoomFrame.MaxY * Plot.YM, curZoomFrame.MinY * Plot.YM, curZoomFrame.XSteps, curZoomFrame.YSteps);					
					var yStart = PlotAligner.GetSteps( curZoomFrame.MinY2 * Plot.Y2M, curZoomFrame.MaxY2 * Plot.Y2M, yStep);
					StartY2 = yStart;
					Y2Step = PlotAligner.Y2Step;
				}
                
            }
            if (zoomStack.Count < 1)
                zoomStack.Push(curZoomFrame.Clone());
        }

        private void ScaleRunTimeTest()
        {
            
            var bound = 0.0;
            // px
            var minX = curZoomFrame.XReversed ? -curZoomFrame.MaxX : curZoomFrame.MinX;
            var maxX = curZoomFrame.XReversed ? -curZoomFrame.MinX : curZoomFrame.MaxX;
          
            var gridCount = PlotAligner.GetFitMaxX(maxX * Plot.XM, ref bound);

            XStep = bound / gridCount;
            maxX = bound / Plot.XM;

            bound = Math.Sign(minX) * Math.Abs(Math.Ceiling(Math.Abs(minX * Plot.XM / XStep))) * XStep;
            minX = bound/Plot.XM;
            StartX = minX;

            var tmaxX = curZoomFrame.XReversed ? -minX : maxX;
            var tminX = curZoomFrame.XReversed ? -maxX : minX;
            if (!Invalid)
                Invalid = curZoomFrame.ScaledMaxX != tmaxX;
            curZoomFrame.ScaledMaxX = tmaxX;
            if (!Invalid)
                Invalid = curZoomFrame.ScaledMinX != tminX;
            curZoomFrame.ScaledMinX = tminX;

            // py
            var minY = curZoomFrame.YReversed ? -curZoomFrame.MaxY : curZoomFrame.MinY;
            var maxY = curZoomFrame.YReversed ? -curZoomFrame.MinY : curZoomFrame.MaxY;
            gridCount = PlotAligner.GetFitMaxY(maxY * Plot.YM, ref bound);
            YStep = bound / gridCount;
            maxY = bound / Plot.YM;

            bound = Math.Sign(minY) * Math.Abs(Math.Ceiling(Math.Abs(minY * Plot.YM / YStep))) * YStep;
            minY = bound / Plot.YM;
            StartY = minY;

            var tmaxY = curZoomFrame.YReversed ? -minY : maxY;
            var tminY = curZoomFrame.YReversed ? -maxY : minY;
            if (!Invalid)
                Invalid = curZoomFrame.ScaledMaxY != tmaxY;
            curZoomFrame.ScaledMaxY = tmaxY;
            if (!Invalid)
                Invalid = curZoomFrame.ScaledMinY != tminY;
            curZoomFrame.ScaledMinY = tminY;

            // Nazarpour 980319
            // pt
            var minY2 = curZoomFrame.Y2Reversed ? -curZoomFrame.MaxY2 : curZoomFrame.MinY2;
            var maxY2 = curZoomFrame.Y2Reversed ? -curZoomFrame.MinY2 : curZoomFrame.MaxY2;
            gridCount = PlotAligner.GetFitMaxY(maxY2 * Plot.Y2M, ref bound);
            Y2Step = bound / gridCount;
            maxY2 = bound / Plot.Y2M;

            bound = Math.Sign(minY2) * Math.Abs(Math.Ceiling(Math.Abs(minY2 * Plot.Y2M / Y2Step))) * Y2Step;
            while (minY2 < bound && Y2Step > 0) bound -= Y2Step;
            minY2 = bound / Plot.Y2M;
            StartY2 = minY2;

            var tmaxY2 = curZoomFrame.Y2Reversed ? -minY2 : maxY2;
            var tminY2 = curZoomFrame.Y2Reversed ? -maxY2 : minY2;
            if (!Invalid)
                Invalid = curZoomFrame.ScaledMaxY2 != tmaxY2;
            curZoomFrame.ScaledMaxY2 = tmaxY2;
            if (!Invalid)
                Invalid = curZoomFrame.ScaledMinY2 != tminY2;
            curZoomFrame.ScaledMinY2 = tminY2;
        }

        private int ScaleOfflineTest(double maxx, double minx, double maxy, double miny, int? xStep, int? yStep)
        {
            double xStart, yStart;
            XGridsCount = 0;
            YGridsCount = 0;
            Y2GridsCount = 0;
            if (xStep.HasValue && yStep.HasValue)
                PlotAligner.GetFixedScaleSteps(minx, maxx, miny, maxy, xStep.Value, yStep.Value, out xStart, out yStart);
            else
                PlotAligner.GetSteps(minx, maxx, miny, maxy, out xStart, out yStart);

            StartX = xStart;
            StartY = yStart;
            XStep = PlotAligner.XStep;
            YStep = PlotAligner.YStep;

            var y = yStart;
            var grids = 1;
            if (maxy > y && !double.IsInfinity(maxy))
            {
                for (; ; )
                    if ((y = y + YStep) > maxy)
                        break;
            }
            else if (maxy < y && !double.IsInfinity(maxy))
            {
                for (; ; grids++)
                    if ((y = y - YStep) < maxy)
                        break;
            }
            return grids;
        }

        public void Resize(Size size)
        {
            DrawingSize = size;
           
            Scale();
            AdjustPointBuffers(resized:true);
        }

        private object loc = new object();
        private void AdjustPointBuffers(bool testFinished = false, bool resized = false, int decimation = 0)
        {
            if ((Options.HugeSampleCount > 0 && (CurTestSource.Samples.Count > Options.HugeSampleCount >> 3)) && !testFinished)
                return;
            lock (loc)
                try
                {
                    if (CurTestSource != null)
                    {
                        CurTestSource.BackGroundDrawnPoints.Clear();
                        CurTestSource.TemperatureBgDrawnPoints.Clear();
                    }
                    else
                        return;

                    if (decimation == 0 || decimation > 1000)
                        decimation = (CurTestSource.Samples.Count / 1000) + 1;
                    else
                        decimation = (CurTestSource.Samples.Count / Math.Max(1, 1000 / decimation)) + 1;

                    var lastP = new Point();

                    for (int index = 0; index < CurTestSource.Samples.Count; index += decimation)
                    {
                        var testSample = CurTestSource.Samples[index];

                        double x;
                        double y;
                        TransformXY(testSample, out x, out y);

                        var point = new Point { X = (int)x, Y = (int)y };
                        CurTestSource.BackGroundDrawnPoints.Add(point);
                        lastP = point;
                    }

                    CurTestSource.ForegroundDrawnPoints.Clear();
                    if (!testFinished)
                        CurTestSource.ForegroundDrawnPoints.Add(lastP);

                    var lastT = new Point();
                    var drawT = false;
                    for (int index = 0; index < CurTestSource.Samples.Count; index += decimation)
                    {
                        var testSample = CurTestSource.Samples[index];
                        // 1400/04/12 Nazarpour
                        if (testSample.Temperature.Length > 0)
                        {
                            double x;
                            double y;
                            TransformXY(testSample, testSample.GetValue(Plot.Y2MeasureType), out x, out y);

                            var point = new Point { X = (int)x, Y = (int)y };
                            CurTestSource.TemperatureBgDrawnPoints.Add(point);
                            lastT = point;
                            drawT = true;
                        }
                    }
                    if (drawT)
                    {
                        CurTestSource.TemperatureFgDrawnPoints.Clear();
                        if (!testFinished)
                            CurTestSource.TemperatureFgDrawnPoints.Add(lastT);
                    }
                }
                catch { }
        }

        private void TransformXY(DataSample testSample, out double x, out double y)
        {

            x = testSample.XValue;
            y = testSample.YValue;
            
            if (!curZoomFrame.XReversed)
                x = (MarginLeft + (x - curZoomFrame.ScaledMinX) / (-curZoomFrame.ScaledMinX + curZoomFrame.ScaledMaxX) * w);
            else
                x = (MarginLeft + (-x + curZoomFrame.ScaledMaxX) / (-curZoomFrame.ScaledMinX + curZoomFrame.ScaledMaxX) *w);

            if (!curZoomFrame.YReversed)
                y = (MarginTop + h - (y - curZoomFrame.ScaledMinY)/(-curZoomFrame.ScaledMinY + curZoomFrame.ScaledMaxY)*h);
            else
                y = (MarginTop + h - (-y + curZoomFrame.ScaledMaxY) / (-curZoomFrame.ScaledMinY + curZoomFrame.ScaledMaxY) * h);
        }

        private void TransformXY(DataSample testSample, double t, out double x, out double y)
        {
            x = testSample.XValue;
            y = t;

            if (!curZoomFrame.XReversed)
                x = (MarginLeft + (x - curZoomFrame.ScaledMinX) / (-curZoomFrame.ScaledMinX + curZoomFrame.ScaledMaxX) * w);
            else
                x = (MarginLeft + (-x + curZoomFrame.ScaledMaxX) / (-curZoomFrame.ScaledMinX + curZoomFrame.ScaledMaxX) * w);

            // Nazarpour
            if (!curZoomFrame.Y2Reversed)
                y = (MarginTop + h - (y - curZoomFrame.ScaledMinY2) / (-curZoomFrame.ScaledMinY2 + curZoomFrame.ScaledMaxY2) * h);
            else
                y = (MarginTop + h - (-y + curZoomFrame.ScaledMaxY2) / (-curZoomFrame.ScaledMinY2 + curZoomFrame.ScaledMaxY2) * h);
        }

        public void Reset()
        {
            curZoomFrame = new ZoomFrame { Factor = 1, MinX = 0, MinY = 0, MaxY = 1, MaxX = 1 };
            curZoomFrame.SetZoomedXY();
            Scale();
        }

        public PointF GetPointValue(Point mouseLocation)
        {
            var x = (float)GetXValue(mouseLocation.X);
            var y = (float)GetYValue(mouseLocation.Y);
            return new PointF(x, y);
        }

        private double GetXValue(int mouseX)
        {
            var min = curZoomFrame.XReversed ? -curZoomFrame.ScaledMaxX : curZoomFrame.ScaledMinX;
            var max = curZoomFrame.XReversed ? -curZoomFrame.ScaledMinX : curZoomFrame.ScaledMaxX;
            var x = min + (max - min) * (mouseX) / (w);
            x *= curZoomFrame.XReversed ? -1 : 1;
            return x;
        }

        private double GetYValue(int mouseY)
        {
            var min = curZoomFrame.YReversed ? -curZoomFrame.ScaledMaxY : curZoomFrame.ScaledMinY;
            var max = curZoomFrame.YReversed ? -curZoomFrame.ScaledMinY : curZoomFrame.ScaledMaxY;
            var y = min + (max - min) * (h - mouseY) / (h);
            y *= curZoomFrame.YReversed ? -1 : 1;
            return y;
        }

        public ZoomFrame Zoom(Rectangle rect)
        {
            var minx = GetXValue(rect.Left);
            var maxx = GetXValue(rect.Right);
            var miny = GetYValue(rect.Bottom);
            var maxy = GetYValue(rect.Top);

            var zoomFrame = new ZoomFrame
                                {
                                    MaxX = Math.Max(minx, maxx),
                                    MinX = Math.Min(minx, maxx),
                                    MinY = Math.Min(miny, maxy),
                                    MaxY = Math.Max(miny, maxy),
                                    XM = Plot.XM,
                                    YM = Plot.YM,
                                };

            if (Math.Abs(maxx - minx) < 0.01 || Math.Abs(maxy - miny) < 0.01)
                return curZoomFrame;

            zoomFrame.Factor = ((curZoomFrame.MaxX - curZoomFrame.MinX)*(curZoomFrame.MaxY - curZoomFrame.MinY))/ 
                ((zoomFrame.MaxX - zoomFrame.MinX)*(zoomFrame.MaxY - zoomFrame.MinY));

            if (zoomFrame.Factor != 1)
            {
                zoomFrame.SetZoomedXY();
            }

            zoomStack.Push(curZoomFrame.Clone());
            curZoomFrame = zoomFrame;
            Scale();
            return zoomFrame;
        }

        public void Zoom(ZoomFrame zoomFrame)
        {
            zoomFrame.Factor = ((curZoomFrame.MaxX - curZoomFrame.MinX) * (curZoomFrame.MaxY - curZoomFrame.MinY)) /
                ((zoomFrame.MaxX - zoomFrame.MinX) * (zoomFrame.MaxY - zoomFrame.MinY));

            if (zoomFrame.Factor != 1)
            {
                zoomFrame.SetZoomedXY();
            }

            zoomStack.Push(curZoomFrame.Clone());
            curZoomFrame = zoomFrame;
            Scale();
        }

        public ZoomFrame Pan(int dx, int dy)
        {
            var x = -(double) dx/(w)*(curZoomFrame.ScaledMaxX - curZoomFrame.ScaledMinX);
            var y = (double) dy/(h)*(curZoomFrame.ScaledMaxY - curZoomFrame.ScaledMinY);

            zoomStack.Push(curZoomFrame.Clone());
            curZoomFrame.SetValues(curZoomFrame.ScaledMinX + x, curZoomFrame.ScaledMaxX + x, 
                                   curZoomFrame.ScaledMinY + y, curZoomFrame.ScaledMaxY + y);

            curZoomFrame.SetZoomedXY();
            curZoomFrame.IsPan = true;
            Scale();
            return curZoomFrame;
        }


        public void SetVisiable(string name, bool visible)
        {
            foreach (var source in DataSources.Where(source => source.Name == name))
            {
                source.Visible = visible;
                break;
            }
        }

        public void FitData(bool emptyStack = false)
        {
            try
            {
                if (emptyStack)
                {
                    zoomStack.Clear();
                    var minx = DataSources.Min(p => p.MinX);
                    var maxx = DataSources.Max(p => p.MaxX);
                    var miny = DataSources.Min(p => p.MinY);
                    var maxy = DataSources.Max(p => p.MaxY);
                    curZoomFrame.SetValues(minx, maxx, miny, maxy);
                    if (!curZoomFrame.KeepY2 && DataSources.Any(ds => ds.Y2MeasureType != MeasureType.None))
                    {
                        curZoomFrame.MinY2 = DataSources.Min(p => p.MinY2);
                        curZoomFrame.MaxY2 = DataSources.Max(p => p.MaxY2);
                        curZoomFrame.MinY2 -= BLayer.Parameters.InstrumentParameters.TemperatureAxisRange;
                        curZoomFrame.MaxY2 += BLayer.Parameters.InstrumentParameters.TemperatureAxisRange;
                    }
                    curZoomFrame.SetZoomedXY();
                    curZoomFrame.AddMargin();
                    curZoomFrame.IsPan = false;
                    curZoomFrame.Factor = 1.0;
                    zoomStack.Push(curZoomFrame.Clone());
                }
                while (zoomStack.Count > 1)
                    curZoomFrame = zoomStack.Pop();

                Scale();
            }
            catch
            {
                
            }
        }

        public ZoomFrame UndoScale()
        {
            try
            {
                if (zoomStack.Count == 1)
                    return curZoomFrame;

                curZoomFrame = zoomStack.Pop();
                Scale();
            }
            catch
            {
            }
            return curZoomFrame;
        }

        public ZoomFrame GetCurZoomLevel()
        {
            if (curZoomFrame == null)
            {
                curZoomFrame = new ZoomFrame { Factor = 1, MinX = 0, MinY = 0, MaxY = 8.9, MaxX = 9.9 };
                Scale();
            }
            return curZoomFrame;
        }

        public List<DataSample> GetPointsAt(int mouseX)
        {
            var x = GetXValue(mouseX);
            var samples = new List<DataSample>();
            foreach (var pds in DataSources)
            {
                lock (pds)
                    samples.Add(pds.ReportGetSampleAt(x));
            }

            return samples;
        }

        public double GetXAttribute(int x)
        {
            return GetXValue(x - MarginLeft);
        }

     
        public void Rebind()
        {
            foreach (var pds in DataSources)
            {
                try
                {
                    lock (pds)
                    {
                        double mx, my, mxx, myy;
                        pds.Rebind(out mx, out my, out mxx, out myy);
                        mx = Math.Min(curZoomFrame.MinX, mx);
                        my = Math.Min(curZoomFrame.MinY, my);
                        mxx = Math.Max(curZoomFrame.MaxX, mxx);
                        myy = Math.Max(curZoomFrame.MaxY, myy);
                        curZoomFrame.SetValues(mx, mxx, my, myy);
						curZoomFrame.MinY2 = pds.MinY2;
						curZoomFrame.MaxY2 = pds.MaxY2;

					}
                }
                catch
                {
                }
            }
            Invalid = true;
        }

        public void RebindY2(int minY2,int maxY2)
        {
            foreach (var pds in DataSources)
            {
                try
                {
                    lock (pds)
                    {
                        double mx, my, mxx, myy;
                        pds.Rebind(out mx, out my, out mxx, out myy);
                        mx = Math.Min(curZoomFrame.MinX, mx);
                        my = Math.Min(curZoomFrame.MinY, my);
                        mxx = Math.Max(curZoomFrame.MaxX, mxx);
                        myy = Math.Max(curZoomFrame.MaxY, myy);
                        curZoomFrame.SetValues(mx, mxx, my, myy);
                        curZoomFrame.MinY2 = minY2;
                        curZoomFrame.MaxY2 = maxY2;
                        curZoomFrame.KeepY2 = true;

                    }
                }
                catch
                {
                }
            }
            Invalid = true;
        }

        public void Clear()
        {
            DataSources.Clear();
        }
    }
}
