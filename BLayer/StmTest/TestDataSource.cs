using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Xml.Linq;
using STM.BLayer.Reporting;
using STM.BLayer.TestSample;
using STM.Extensions;
using STM.PLayer.Report;
using STM.PLayer.UI;

namespace STM.BLayer.StmTest
{
    public class TestDataSource
    {
        public struct SingleReportResult
        {
            public DataSample BasePoint;
            public DataSample LastPoint;
            public DataSample PrevPoint;
            public DataSample Attribute1;
        }

        #region fields

        public double MinX { set; get; }
        public double MaxX { set; get; }
        public double MinY { set; get; }
        public double MaxY { set; get; }
        public double MinY2 { set; get; }
        public double MaxY2 { set; get; }
        // Nazarpour 1399/11/11
        public double Y2SetPoint { get; set; }

        public string Name { set; get; }
        public string FullPath { set; get; }
        public TestMethodType TestMethodType { set; get; }
        public Color DrawingColor { set; get; }
        public Color DrawingColor2 { set; get; }
        public Marker Marker { set; get; }
        public DashStyle LineStyle { set; get; }
        public TestingSample TestSample { set; get; }
        public TestInformation TestInformation { set; get; }
        public List<DataSample> Samples { set; get; }
        public List<PointF> ForegroundDrawnPoints { set; get; }
        public List<PointF> BackGroundDrawnPoints { set; get; }
        public List<PointF> TemperatureFgDrawnPoints { set; get; }
        public List<PointF> TemperatureBgDrawnPoints { set; get; }

        public int TestId { get; set; }
        public bool Visible { set; get; }
        public string XmlTestSetting { set; get; }

        public MeasureType XMeasureType { get; set; }
        public MeasureType YMeasureType { get; set; }
        public MeasureType Y2MeasureType { get; set; }

        #endregion

        #region Constructor & methods

        public TestDataSource()
        {
            Samples = new List<DataSample>();
            DrawingColor = Color.Gray;
            DrawingColor2 = Color.Gray;
            BackGroundDrawnPoints = new List<PointF>();
            ForegroundDrawnPoints = new List<PointF>();
            TemperatureFgDrawnPoints = new List<PointF>(1000);
            TemperatureBgDrawnPoints = new List<PointF>(1000);
            Visible = true;
        }

        public bool HasTemperature
        {
            get
            {
                return Samples.Any(p => p.NumberOfTemperatureSensors > 0);
            }
        }

        public void Rebind(out double minX, out double minY, out double maxX, out double maxY)
        {
            var id = 0;
            minX = 0.0;
            minY = 0.0;
            maxX = 0.0;
            maxY = 0.0;
            var maxY2 = 0.0;
            var minY2 = -1.0;
            var drawT = false;
            foreach (var testSample in Samples)
            {
                testSample.Area = TestSample.Area;
                testSample.Length = TestSample.GagueLength;
                testSample.Density = TestSample.Density;
                testSample.Width = TestSample.Width;
                testSample.BindAxisValues(id);
                minX = Math.Min(minX, testSample.XValue);
                minY = Math.Min(minY, testSample.YValue);
                maxX = Math.Max(maxX, testSample.XValue);
                maxY = Math.Max(maxY, testSample.YValue);
                if (double.IsNaN(minX)) minX = 0;
                if (double.IsNaN(minY)) minY = 0;
                if (double.IsNaN(maxX)) maxX = 0;
                if (double.IsNaN(maxY)) maxY = 0;
                if (double.IsInfinity(minX)) minX = 0;
                if (double.IsInfinity(minY)) minY = 0;
                if (double.IsInfinity(maxX)) maxX = 0;
                if (double.IsInfinity(maxY)) maxY = 0;
                // Nazarpour 1399/10/14
                if (testSample.NumberOfTemperatureSensors > 0)
                    try
                    {
                        maxY2 = Math.Max(maxY2, testSample.Temperature.Where(t => t > 0).Max());
                        if (minY2 < 0) minY2 = maxY2 * 0.9;
                        minY2 = Math.Min(minY2, testSample.Temperature.Where(t => t > 0).Min());
                        drawT = true;
                    }
                    catch { }
                id++;
            }
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
            // Nazarpour 1400/04/21
            if (drawT)
            {
                MinY2 = minY2;
                MaxY2 = maxY2;
                // Nazarpour 1399/11/11
                MinY2 = Math.Min(minY2, Y2SetPoint - Parameters.InstrumentParameters.TemperatureAxisRange);
                if (MinY2 < 0) MinY2 = 0;
                MaxY2 = Math.Max(MaxY2, Y2SetPoint + Parameters.InstrumentParameters.TemperatureAxisRange);
            }
            else
            {
                minY2 = maxY2 = 0;
            }
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

        public IEnumerable<DataSample> GetZoomRect(double minX, double MaxX, double minY, double maxY)
        {
            var retVal = Samples.Where(p => minX <= p.XValue && p.XValue <= MaxX).ToList();
            try
            {
                retVal.Insert(0, Samples[retVal.First().ID - 1]);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            try
            {
                retVal.Add(Samples[retVal.Last().ID + 1]);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return retVal;
        }

        #endregion

        #region Points / properties

        public DataSample ReportGetSampleAt(double x)
        {
            var sample = Samples.FirstOrDefault(p => x <= p.XValue);
            return sample;
        }

        /// <summary>
        /// Returns elastic module
        /// </summary>
        /// <param name="peak">peak</param>
        /// <returns></returns>
        public double GetElasticModule(out DataSample peak)
        {
            peak = GetPeakForce().BasePoint;
            if (peak == null)
                return double.NaN;

            var minLimitPercent = peak.Force * ReportingParameters.ElasticModuleMinPercent / 100.0;
            var maxLimitPercent = peak.Force * ReportingParameters.ElasticModuleMaxPercent / 100.0;

            var i = peak.Force>=0?  Samples.FindIndex(0, p => p.Force >= minLimitPercent): Samples.FindIndex(0, p => -p.Force >= -minLimitPercent);
            var j = peak.Force >= 0 ? Samples.FindIndex(i, p => p.Force >= maxLimitPercent): Samples.FindIndex(i, p => -p.Force >= -maxLimitPercent);

            if (!ReportingParameters.UseRegression)
            {
                var y1 = Samples[i].GetValue(MeasureType.Stress);
                var y2 = Samples[j].GetValue(MeasureType.Stress);

                var x1 = Samples[i].GetValue(MeasureType.Strain);
                var x2 = Samples[j].GetValue(MeasureType.Strain);

                return (y2 - y1) / (x2 - x1);
            }

            var stressAvg = 0.0;
            var strainAvg = 0.0;
            var xy = 0.0;
            var xx = 0.0;

            for (var index = i; index < j; index++)
            {
                stressAvg += Samples[index].GetValue(MeasureType.Stress);
                strainAvg += Samples[index].GetValue(MeasureType.Strain);
            }
            stressAvg /= j - i;
            strainAvg /= j - i;
            for (int index = i; index < j; index++)
            {
                xy += (Samples[index].GetValue(MeasureType.Stress) - stressAvg) * (Samples[index].GetValue(MeasureType.Strain) - strainAvg);
                xx += (Samples[index].GetValue(MeasureType.Stress) - stressAvg) * (Samples[index].GetValue(MeasureType.Stress) - stressAvg);
            }
            return xx / xy;
        }

        public double Get_UT_Yield(out DataSample data)
        {
            try
            {
                data = GetPeakForce().BasePoint;
                var yield = GetYeild().BasePoint;
                if (yield == null) yield = GetOffsetYeild(.2).BasePoint;
                if (data != null && yield != null)
                {
                    return data.Force / yield.Force;
                }
            }
            catch { }
            data = null;
            return double.NaN;
        }

        #region ReportTypes

        /// <summary>
        /// Returns peak sample
        /// </summary>
        /// <returns></returns>
        public SingleReportResult GetPeakForce(int stepOrCycle = -1)//ok
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            var minForce = samples[0].Force;
            var maxForce = samples[0].Force;
            var minIndex = 0;
            var maxIndex = 0;
            var curIndex = 0;
            DataSample preSample = null;
            DataSample lastSampel = null;
            foreach (var dataSample in samples)
            {
                if (dataSample.Force <= minForce)
                {
                    minForce = dataSample.Force;
                    minIndex = curIndex;
                }
                if (dataSample.Force >= maxForce)
                {
                    maxForce = dataSample.Force;
                    maxIndex = curIndex;
                }
                curIndex++;
            }

            if (Math.Abs(minForce) <= Math.Abs(maxForce))
            {
                try
                { preSample = samples[maxIndex - 1]; }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                try { lastSampel = samples[maxIndex + 1]; }
                catch (Exception exception)
                {
                    exception.ToString();
                }
            }
            else
            {
                try { preSample = samples[minIndex - 1]; }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                try { lastSampel = samples[minIndex + 1]; }
                catch (Exception exception)
                {
                    exception.ToString();
                }
            }


            var peakSample = Math.Abs(minForce) <= Math.Abs(maxForce) ? samples[maxIndex] : samples[minIndex];
            var sRange = new SingleReportResult { BasePoint = peakSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        /// <summary>
        /// Returns break sample, may be null
        /// </summary>
        /// <param name="breakPercent"></param>
        /// <returns></returns>
        public SingleReportResult GetBreakSample(double breakPercent)//ok
        {
            DataSample breakSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            var i = 0;
            for (; i < Samples.Count - 1; i++)
            {
                var curY = Samples[i].YValue;
                var nextY = Samples[i + 1].YValue;

                if (Math.Abs(nextY) > Math.Abs(curY) * (100.0 - breakPercent) / 100.0) continue;

                breakSample = Samples[i];
                break;
            }

            try { preSample = Samples[i - 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }
            try { lastSampel = Samples[i + 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }

            var sRange = new SingleReportResult { BasePoint = breakSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        public SingleReportResult GetYeild()//ok
        {
            DataSample yield = null;
            DataSample preSample = null;
            DataSample lastSampel = null;

            var peak = GetPeakForce().BasePoint;
            var ind = 0;
            for (; ind < Samples.Count && peak.Force / 2 >= Samples[ind].Force; ind++) { }

            var tmp = new List<DataSample>();
            for (; ind < peak.ID; ind++)
                tmp.Add(Samples[ind]);
            var yieldRange = tmp.ToArray();

            ind = 0;
            while (ind < yieldRange.Length)
            {
                var setSize = Math.Min(20, yieldRange.Length - ind);
                var set = new DataSample[setSize];
                Array.Copy(yieldRange, ind, set, 0, setSize);
                ind++;
                var m = set.Max(p => p.Force);
                if (m == set.Last().Force)
                    continue;

                yield = set.Where(p => p.Force == m).First();
                break;
            }

            try { preSample = Samples[yield.ID - 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }
            try { lastSampel = Samples[yield.ID + 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }

            var sRange = new SingleReportResult { BasePoint = yield, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;

        }

        public SingleReportResult GetUpperYield()//ok
        {
            DataSample upYield = null;
            DataSample preSample = null;
            DataSample lastSampel = null;

            var yield = GetYeild().BasePoint;
            var peak = GetPeakForce().BasePoint;

            if (yield == null)
                return new SingleReportResult { BasePoint = null, LastPoint = null, PrevPoint = null };

            for (var ind = yield.ID + 1; ind < peak.ID && Samples[ind].Force <= yield.Force; ind++)
            {
                upYield = upYield ?? Samples[ind];
                if (upYield.Force < Samples[ind].Force)
                    upYield = Samples[ind];
            }

            try { preSample = Samples[upYield.ID - 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }
            try { lastSampel = Samples[upYield.ID + 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }

            var sRange = new SingleReportResult { BasePoint = upYield, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        //1401/04/16 Nazarpour
        public SingleReportResult? GetLastPoint()
        {
            try
            {
                var pr = Samples[Samples.Count - 3];
                var br = Samples[Samples.Count - 2];
                var nx = Samples[Samples.Count - 1];
                return new SingleReportResult { BasePoint = br, LastPoint = nx, PrevPoint = pr };
            }
            catch { return null; }
        }

        public SingleReportResult GetLowerYield()//ok
        {
            DataSample lowerYield = null;
            DataSample preSample = null;
            DataSample lastSampel = null;

            var yield = GetYeild().BasePoint;
            var peak = GetPeakForce().BasePoint;

            if (yield == null)
                return new SingleReportResult { BasePoint = null, LastPoint = null, PrevPoint = null };

            for (var ind = yield.ID + 1; ind < peak.ID && Samples[ind].Force <= yield.Force; ind++)
            {
                lowerYield = lowerYield ?? Samples[ind];
                if (lowerYield.Force > Samples[ind].Force)
                    lowerYield = Samples[ind];
            }

            try { preSample = Samples[lowerYield.ID - 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }
            try { lastSampel = Samples[lowerYield.ID + 1]; }
            catch (Exception exception)
            {
                exception.ToString();
            }

            var sRange = new SingleReportResult { BasePoint = lowerYield, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        public SingleReportResult GetMeanYield()//ok
        {
            DataSample meanYield = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            var sum = 0.0;
            var mean = 0.0;
            var yield = GetYeild().BasePoint;
            if (yield == null)
                return new SingleReportResult { BasePoint = null, LastPoint = null, PrevPoint = null };

            for (var ind = yield.ID + 1; Samples[ind].Force <= yield.Force && ind < Samples.Count - 1; ind++)
            {
                sum += Samples[ind].Force;
                mean = sum / (ind - yield.ID);
            }

            for (var ind = yield.ID + 1; Samples[ind].Force <= yield.Force && ind < Samples.Count - 2; ind++)
            {
                if (Samples[ind].Force == mean)
                {
                    meanYield = Samples[ind];
                    preSample = Samples[ind - 1];

                    try { lastSampel = Samples[ind + 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    break;
                }
                if ((Samples[ind].Force > mean || mean > Samples[ind + 1].Force) &&
                    (Samples[ind].Force < mean || mean < Samples[ind + 1].Force)) continue;

                var t = EnterPolation(Samples[ind].Force, Samples[ind + 1].Force, Samples[ind].Time, Samples[ind + 1].Time, mean);
                var e = EnterPolation(Samples[ind].Force, Samples[ind + 1].Force, Samples[ind].Extension, Samples[ind + 1].Extension, mean);
                meanYield = new DataSample(mean, e, t) { Area = TestSample.Area, Length = TestSample.GagueLength, Density = TestSample.Density, Width = TestSample.Width, MarkedLoad = Samples[ind].MarkedLoad, StepOrCycle = Samples[ind].StepOrCycle };
                preSample = Samples[ind];
                try { lastSampel = Samples[ind + 1]; }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                break;
            }

            var sRange = new SingleReportResult { BasePoint = meanYield, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }


        private SingleReportResult GetOffsetYeild(double? offset)//ok
        {
            DataSample offsetYield = null;
            DataSample preSample = null;
            DataSample lastSample = null;

            DataSample peak;
            var m = GetElasticModule(out peak);
            //var x0 = Samples.Last().GetValue(MeasureType.Strain) * (offset.HasValue ? offset.Value : .02);
            //var y0 = peak.GetValue(MeasureType.Stress) * ReportingParameters.ElasticModuleMinPercent / 100.0;
            var x0 = (offset ?? .2) / 100.0;
            var y0 = 0.0;
            var attribute1 = new DataSample(y0 * TestSample.Area, x0 * TestSample.GagueLength, 0) { Area = TestSample.Area, Length = TestSample.GagueLength,
                Density = TestSample.Density, Width = TestSample.Width };

            var id = peak.ID - 1;
            while (id > 2)
            {
                var m1 = (Samples[id].GetValue(MeasureType.Stress) - y0) / (Samples[id].GetValue(MeasureType.Strain) - x0);
                var m0 = (Samples[id - 1].GetValue(MeasureType.Stress) - y0) / (Samples[id - 1].GetValue(MeasureType.Strain) - x0);

                if (m1 == m)
                {
                    offsetYield = Samples[id];
                    preSample = Samples[id - 1];
                    lastSample = Samples[id + 1];
                    break;
                }
                if (m0 == m)
                {
                    offsetYield = Samples[id - 1];
                    preSample = Samples[id - 2];
                    lastSample = Samples[id];
                    break;
                }
                if (m1 <= m && m <= m0)
                {
                    var f = (Samples[id - 1].Force + Samples[id].Force) / 2;
                    var e = (Samples[id - 1].Extension + Samples[id].Extension) / 2;
                    var t = (Samples[id - 1].Time + Samples[id].Time) / 2;
                    offsetYield = new DataSample(f, e, t)
                    {
                        Area = TestSample.Area,
                        Length = TestSample.GagueLength,
                        StepOrCycle = Samples[id - 1].StepOrCycle,
                        MarkedLoad = Samples[id - 1].MarkedLoad,
                        Density = TestSample.Density,
                        Width = TestSample.Width
                    };
                    preSample = Samples[id - 1];
                    lastSample = Samples[id];
                    break;
                }
                id--;
            }
            var sRange = new SingleReportResult { BasePoint = offsetYield, LastPoint = lastSample, PrevPoint = preSample, Attribute1 = attribute1 };
            return sRange;
        }

        static bool InRange(double a, double b, double value)
        {
            if (a <= value && value <= b) return true;
            if (a >= value && value >= b) return true;
            return false;
        }

        /// <summary>
        /// @ time
        /// </summary>
        /// <param name="time"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtTime(double time, int stepOrCycle = -1)//ok
        {
            DataSample baseSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;

            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            for (var index = 0; index < samples.Count - 1; index++)
            {
                if (time == samples[index].Time)
                {
                    baseSample = samples[index];
                    try { preSample = Samples[index - 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    lastSampel = Samples[index + 1];
                    break;
                }
                if (!InRange(samples[index].Time, samples[index + 1].Time, time)) continue;
                var f = EnterPolation(samples[index].Time, samples[index + 1].Time, samples[index].Force, samples[index + 1].Force, time);
                var e = EnterPolation(samples[index].Time, samples[index + 1].Time, samples[index].Extension, samples[index + 1].Extension, time);
                baseSample = new DataSample(f, e, time)
                {
                    Area = TestSample.Area,
                    Length = TestSample.GagueLength,
                    StepOrCycle = samples[index].StepOrCycle,
                    MarkedLoad = samples[index].MarkedLoad,
                    Density = TestSample.Density,
                    Width = TestSample.Width
                };
                preSample = samples[index];
                lastSampel = samples[index + 1];
                break;
            }
            var sRange = new SingleReportResult { BasePoint = baseSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        /// <summary>
        /// @ force
        /// </summary>
        /// <param name="force"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtForce(double force, int stepOrCycle = -1)//ok
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            DataSample baseSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            for (var index = 0; index < samples.Count - 1; index++)
            {
                if (force == samples[index].Force)
                {
                    baseSample = samples[index];
                    try { preSample = Samples[index - 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    lastSampel = Samples[index + 1];
                    break;
                }
                if (!InRange(samples[index].Force, samples[index + 1].Force, force)) continue;
                var t = EnterPolation(samples[index].Force, samples[index + 1].Force, samples[index].Time, samples[index + 1].Time, force);
                var e = EnterPolation(samples[index].Force, samples[index + 1].Force, samples[index].Extension, samples[index + 1].Extension, force);
                baseSample = new DataSample(force, e, t)
                {
                    Area = TestSample.Area,
                    Length = TestSample.GagueLength,
                    StepOrCycle = samples[index].StepOrCycle,
                    Density = TestSample.Density,
                    MarkedLoad = samples[index].MarkedLoad,
                    Width = TestSample.Width
                };
                preSample = samples[index];
                lastSampel = samples[index + 1];
                break;
            }
            var sRange = new SingleReportResult { BasePoint = baseSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        /// <summary>
        /// @ extension
        /// </summary>
        /// <param name="exten"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtExtension(double exten, int stepOrCycle = -1)//ok
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            DataSample baseSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            for (var index = 0; index < samples.Count - 1; index++)
            {
                if (exten == samples[index].Extension)
                {
                    baseSample = samples[index];
                    try { preSample = Samples[index - 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    lastSampel = Samples[index + 1];
                    break;
                }
                if (!InRange(samples[index].Extension, samples[index + 1].Extension, exten)) continue;

                var f = EnterPolation(samples[index].Extension, samples[index + 1].Extension, samples[index].Force, samples[index + 1].Force, exten);
                var t = EnterPolation(samples[index].Extension, samples[index + 1].Extension, samples[index].Time, samples[index + 1].Time, exten);
                baseSample = new DataSample(f, exten, t)
                {
                    Area = TestSample.Area,
                    Length = TestSample.GagueLength,
                    StepOrCycle = samples[index].StepOrCycle,
                    Density = TestSample.Density,
                    MarkedLoad = samples[index].MarkedLoad,
                    Width = TestSample.Width
                };
                preSample = samples[index];
                try { lastSampel = samples[index + 1]; }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                break;
            }
            var sRange = new SingleReportResult { BasePoint = baseSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        public static double? GetMousePos(List<DataSample> data, MeasureType xm, MeasureType ym, double x, double y)
        {
            if (data == null || data.Count == 0) return null;
            var points = data.Select(p => new { X = p.GetValue(xm), Y = p.GetValue(ym) }).ToList();
            var ys = new List<double>();

            for (var index = 0; index < points.Count - 1; index++)
            {
                if (Math.Abs(x - points[index].X) < double.Epsilon)
                {
                    ys.Add(points[index].Y);
                    continue;
                }
                if (!InRange(points[index].X, points[index + 1].X, x)) continue;

                var ey = EnterPolation(points[index].X, points[index + 1].X, points[index].Y, points[index + 1].Y, x);
                ys.Add(ey);
            }
            if (ys.Count == 0) return null;
            double minDistance = double.MaxValue;
            var minIndex = -1;

            for (var i = 0; i < ys.Count; i++)
            {
                var distance = Math.Abs(y - ys[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minIndex = i;
                }
            }
            if (minIndex >= 0)
                return ys[minIndex];
            return null;
        }

        /// <summary>
        /// @ strain
        /// </summary>
        /// <param name="strain"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtStrain(double strain, int stepOrCycle = -1)
        {
            var exten = strain * TestSample.GagueLength;
            return GetAtExtension(exten, stepOrCycle);
        }

        /// <summary>
        /// @ true strain
        /// </summary>
        /// <param name="trueStrain"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtTrueStrain(double trueStrain, int stepOrCycle = -1)
        {
            var exten = (trueStrain * TestSample.GagueLength) / (1 - trueStrain);
            return GetAtExtension(exten, stepOrCycle);
        }

        /// <summary>
        /// @ stress
        /// </summary>
        /// <param name="stress"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtStress(double stress, int stepOrCycle = -1)
        {
            var force = stress * TestSample.Area;
            return GetAtForce(force, stepOrCycle);
        }

        /// <summary>
        /// @ true stress
        /// </summary>
        /// <param name="trueStress"></param>
        /// <param name="stepOrCycle"></param>
        /// <returns></returns>
        public SingleReportResult GetAtTrueStress(double trueStress, int stepOrCycle = -1)//ok
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            DataSample baseSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            for (var index = 0; index < samples.Count; index++)
            {
                if (Math.Abs(trueStress - samples[index].GetValue(MeasureType.TrueStress)) < double.Epsilon)
                {
                    baseSample = samples[index];
                    try { preSample = Samples[index - 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    try { lastSampel = Samples[index + 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    break;
                }
                if (!InRange(samples[index].GetValue(MeasureType.TrueStress), samples[index + 1].GetValue(MeasureType.TrueStress), trueStress)) continue;
                var f = EnterPolation(samples[index].GetValue(MeasureType.TrueStress), samples[index + 1].GetValue(MeasureType.TrueStress), samples[index].Force, samples[index + 1].Force, trueStress);
                var e = EnterPolation(samples[index].GetValue(MeasureType.TrueStress), samples[index + 1].GetValue(MeasureType.TrueStress), samples[index].Extension, samples[index + 1].Extension, trueStress);
                var t = EnterPolation(samples[index].GetValue(MeasureType.TrueStress), samples[index + 1].GetValue(MeasureType.TrueStress), samples[index].Time, samples[index + 1].Time, trueStress);
                baseSample = new DataSample(f, e, t)
                {
                    Area = TestSample.Area,
                    Length = TestSample.GagueLength,
                    StepOrCycle = samples[index].StepOrCycle,
                    Density = TestSample.Density,
                    MarkedLoad = samples[index].MarkedLoad,
                    Width = TestSample.Width
                };
                preSample = samples[index];
                lastSampel = samples[index + 1];
                break;
            }
            var sRange = new SingleReportResult { BasePoint = baseSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        public SingleReportResult GetAtMassStress(double massStress, int stepOrCycle = -1)//ok
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            DataSample baseSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            for (var index = 0; index < samples.Count; index++)
            {
                if (Math.Abs(massStress - samples[index].GetValue(MeasureType.MassStress)) < double.Epsilon)
                {
                    baseSample = samples[index];
                    try { preSample = Samples[index - 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    try { lastSampel = Samples[index + 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    break;
                }
                if (!InRange(samples[index].GetValue(MeasureType.MassStress), samples[index + 1].GetValue(MeasureType.MassStress), massStress)) continue;
                var f = EnterPolation(samples[index].GetValue(MeasureType.MassStress), samples[index + 1].GetValue(MeasureType.MassStress), samples[index].Force, samples[index + 1].Force, massStress);
                var e = EnterPolation(samples[index].GetValue(MeasureType.MassStress), samples[index + 1].GetValue(MeasureType.MassStress), samples[index].Extension, samples[index + 1].Extension, massStress);
                var t = EnterPolation(samples[index].GetValue(MeasureType.MassStress), samples[index + 1].GetValue(MeasureType.MassStress), samples[index].Time, samples[index + 1].Time, massStress);
                baseSample = new DataSample(f, e, t)
                {
                    Area = TestSample.Area,
                    Length = TestSample.GagueLength,
                    StepOrCycle = samples[index].StepOrCycle,
                    Density = TestSample.Density,
                    MarkedLoad = samples[index].MarkedLoad,
                    Width = TestSample.Width
                };
                preSample = samples[index];
                lastSampel = samples[index + 1];
                break;
            }
            var sRange = new SingleReportResult { BasePoint = baseSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }

        public SingleReportResult GetAtLengthStress(double lengthStress, int stepOrCycle = -1)//ok
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            DataSample baseSample = null;
            DataSample preSample = null;
            DataSample lastSampel = null;
            for (var index = 0; index < samples.Count; index++)
            {
                if (Math.Abs(lengthStress - samples[index].GetValue(MeasureType.LengthStress)) < double.Epsilon)
                {
                    baseSample = samples[index];
                    try { preSample = Samples[index - 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    try { lastSampel = Samples[index + 1]; }
                    catch (Exception exception)
                    {
                        exception.ToString();
                    }
                    break;
                }
                if (!InRange(samples[index].GetValue(MeasureType.LengthStress), samples[index + 1].GetValue(MeasureType.LengthStress), lengthStress)) continue;
                var f = EnterPolation(samples[index].GetValue(MeasureType.LengthStress), samples[index + 1].GetValue(MeasureType.LengthStress), samples[index].Force, samples[index + 1].Force, lengthStress);
                var e = EnterPolation(samples[index].GetValue(MeasureType.LengthStress), samples[index + 1].GetValue(MeasureType.LengthStress), samples[index].Extension, samples[index + 1].Extension, lengthStress);
                var t = EnterPolation(samples[index].GetValue(MeasureType.LengthStress), samples[index + 1].GetValue(MeasureType.LengthStress), samples[index].Time, samples[index + 1].Time, lengthStress);
                baseSample = new DataSample(f, e, t)
                {
                    Area = TestSample.Area,
                    Length = TestSample.GagueLength,
                    StepOrCycle = samples[index].StepOrCycle,
                    Density = TestSample.Density,
                    MarkedLoad = samples[index].MarkedLoad,
                    Width = TestSample.Width
                };
                preSample = samples[index];
                lastSampel = samples[index + 1];
                break;
            }
            var sRange = new SingleReportResult { BasePoint = baseSample, LastPoint = lastSampel, PrevPoint = preSample };
            return sRange;
        }
        /// <summary>
        /// selects a range of data samples
        /// </summary>
        /// <param name="measureType">selection filter</param>
        /// <param name="start">selection start bound, if null, first sample accounted for the start sample</param>
        /// <param name="stop">selection stop bound</param>
        /// <param name="stepOrCycle">selection step</param>
        /// <returns></returns>
        public List<DataSample> GetRange(MeasureType measureType, double? start, double stop, int stepOrCycle = -1)
        {
            var samples = stepOrCycle > -1 ? Samples.Where(p => p.StepOrCycle == stepOrCycle).ToList() : Samples;
            if (start == null)
                start = samples[0].GetValue(measureType);

            var retVal = new List<DataSample>();
            switch (measureType)
            {
                case MeasureType.Force:
                case MeasureType.Extension:
                case MeasureType.Time:
                    foreach (var dataSample in samples)
                    {
                        var val = dataSample.GetValue(measureType);
                        if (val > stop)
                            break;
                        if (start <= val)
                            retVal.Add(dataSample);
                    }
                    break;

                case MeasureType.Stress:
                    var sforce = start * TestSample.Area;
                    var eForce = stop * TestSample.Area;
                    retVal = GetRange(MeasureType.Force, sforce, eForce, stepOrCycle);
                    break;

                case MeasureType.Strain:
                    var sExten = start * TestSample.GagueLength;
                    var eExten = stop * TestSample.GagueLength;
                    retVal = GetRange(MeasureType.Extension, sExten, eExten, stepOrCycle);
                    break;
            }
            return retVal;
        }

        private static double EnterPolation(double x1, double x2, double y1, double y2, double xm)
        {
            var len = x2 - x1;
            var yM = (xm - x1) / len * y2 + (x2 - xm) / len * y1;
            return yM;
        }

        #endregion

        #region report properties

        public double GetPointProperty(SingleReportResult singleReportResult, PointType pointType, PointProperty pointProperty, string formula = "")
        {
            var retVal = 0.0;
            if (singleReportResult.BasePoint == null)
                return double.NaN;

            switch (pointProperty)
            {
                case PointProperty.Force:
                case PointProperty.Extension:
                case PointProperty.Time:
                case PointProperty.Strain:
                case PointProperty.Stress:
                case PointProperty.TrueStrain:
                case PointProperty.TrueStress:
                case PointProperty.MassStress:
                case PointProperty.LengthStress:
				case PointProperty.Temperature:
				case PointProperty.SpecTempUP:
				case PointProperty.SpecTempCNT:
				case PointProperty.SpecTempDN:
					retVal = singleReportResult.BasePoint.GetValue(ReportingParameters.PointPropertyToMeasureType[pointProperty]);
                    break;

                case PointProperty.AA0:
                    retVal = 1 / (1 - 1 / Math.Exp(singleReportResult.BasePoint.GetValue(MeasureType.Strain)));
                    break;

                case PointProperty.BendingModule:
                    retVal = GetBendingModule(singleReportResult.BasePoint);
                    break;

                case PointProperty.BendingStrain:
                    retVal = GetBendingStrain(singleReportResult.BasePoint);
                    break;

                case PointProperty.BendingStress:
                    retVal = GetBendingStress(singleReportResult.BasePoint);
                    break;

                case PointProperty.ElongationAfterBreak:
                    retVal = GetElongationAfterBreak(singleReportResult.BasePoint);
                    break;

                case PointProperty.ForcePerLength:
                    retVal = singleReportResult.BasePoint.Force / TestSample.GagueLength;
                    break;

                case PointProperty.Formula:
                    retVal = SolveFormula(singleReportResult, pointType, formula);
                    break;

                case PointProperty.SecantModule:
                    retVal = singleReportResult.BasePoint.Force / singleReportResult.BasePoint.Extension;
                    break;

                case PointProperty.TangentModule:
                    retVal = GetTangent(singleReportResult);
                    break;
                    
                case PointProperty.Energy:
                    var range = Samples.Where(p => p.ID < singleReportResult.BasePoint.ID && p.StepOrCycle == singleReportResult.BasePoint.StepOrCycle).ToList();
                    retVal = GetIntegralArea(range, MeasureType.Extension, MeasureType.Force);
                    break;

                case PointProperty.Relaxation:
                    retVal = singleReportResult.BasePoint.GetValue(MeasureType.RelaxLoss);
                    break;

                case PointProperty.ForceLoss:
                    retVal = singleReportResult.BasePoint.GetValue(MeasureType.ForceLoss);
                    break;

                case PointProperty.StressLoss:
                    retVal = singleReportResult.BasePoint.GetValue(MeasureType.StressLoss);
                    break;
            }


            return retVal;
        }

        public double GetPointProperty(List<DataSample> dataSamples, PointType pointType, PointProperty pointProperty, out double area)
        {
            var retVal = 0.0;
            double width;
            area = 0;
            switch (pointType)
            {
                case PointType.ExtenLimit:
                    width = dataSamples.Last().Extension - dataSamples.First().Extension;
                    if (ReportingParameters.PointPropertyToMeasureType[pointProperty]!= (MeasureType)(-1))
                        area = GetIntegralArea(dataSamples, MeasureType.Extension, ReportingParameters.PointPropertyToMeasureType[pointProperty]);
                    else if( pointProperty== PointProperty.Energy)
                        area = GetIntegralArea(dataSamples, MeasureType.Extension, MeasureType.Force)*width;
                    else
                        area = double.NaN;
                    retVal = area / width;
                    break;

                case PointType.StrainLimit:
                    width = dataSamples.First().GetValue(MeasureType.Strain) - dataSamples.Last().GetValue(MeasureType.Strain);
                    if (ReportingParameters.PointPropertyToMeasureType[pointProperty] != (MeasureType)(-1))
                        area = GetIntegralArea(dataSamples, MeasureType.Strain, ReportingParameters.PointPropertyToMeasureType[pointProperty]);
                    else if (pointProperty == PointProperty.Energy)
                        area = GetIntegralArea(dataSamples, MeasureType.Extension, MeasureType.Force) * width;
                    else
                        area = double.NaN;
                   
                    retVal = area / width;
                    break;

                case PointType.TimeLimit:
                    width = dataSamples.Last().Time - dataSamples.First().Time ;
                    if (ReportingParameters.PointPropertyToMeasureType[pointProperty] != (MeasureType)(-1))
                        area = GetIntegralArea(dataSamples, MeasureType.Time, ReportingParameters.PointPropertyToMeasureType[pointProperty]);
                    else if (pointProperty == PointProperty.Energy)
                        area = GetIntegralArea(dataSamples, MeasureType.Extension, MeasureType.Force)*width;
                    else
                        area = double.NaN;
                   
                    retVal = area / width;

                    break;
            }

            return retVal;
        }

        public double GetRate(List<DataSample> dataSamples, PointType pointType, PointProperty pointProperty)
        {
            if (dataSamples == null || dataSamples.Count == 0)
                return double.NaN;

         
            var i = 0;
            var j = dataSamples.Count;
            var timeAvg = 0.0;
            var rateAvg = 0.0;
            var xy = 0.0;
            var xx = 0.0;

            MeasureType rType;
            switch (pointProperty)
            {
                case PointProperty.ForceRate:
                    rType = MeasureType.Force;
                    break;

                case PointProperty.StressRate:
                    rType = MeasureType.Stress;
                    break;

                case PointProperty.ExtenRate:
                    rType = MeasureType.Extension;
                    break;

                case PointProperty.StrainRate:
                    rType = MeasureType.Strain;
                    break;

                default:
                    return double.NaN;
            }
            
            for (var index = i; index < j; index++)
            {
                timeAvg += dataSamples[index].GetValue(MeasureType.Time);
                rateAvg += dataSamples[index].GetValue(rType);
            }
            timeAvg /= (j - i); // x
            rateAvg /= (j - i); // y
            for (int index = i; index < j; index++)
            {
                xy += (dataSamples[index].GetValue(rType) - rateAvg) * (dataSamples[index].GetValue(MeasureType.Time) - timeAvg);
                xx += (dataSamples[index].GetValue(rType) - rateAvg) * (dataSamples[index].GetValue(rType) - rateAvg);
            }
            return xx / xy;
        }

        private double GetTangent(SingleReportResult Single_report_result)
        {
            var midSample = Single_report_result.BasePoint;
            var prevSample = Single_report_result.PrevPoint;
            var pasSample = Single_report_result.LastPoint;

            if (midSample != null && prevSample != null && pasSample != null)
            {
                var dist12 = Math.Pow(midSample.Extension - prevSample.Extension, 2) +
                             Math.Pow(midSample.Force - prevSample.Force, 2);
                var dist22 = Math.Pow(midSample.Extension - pasSample.Extension, 2) +
                             Math.Pow(midSample.Force - pasSample.Force, 2);

                if (dist12 < dist22 && prevSample.StepOrCycle == midSample.StepOrCycle)
                {
                    return (midSample.GetValue(MeasureType.Stress) - prevSample.GetValue(MeasureType.Stress)) / (midSample.GetValue(MeasureType.Strain) - prevSample.GetValue(MeasureType.Strain));
                }
                return (midSample.Force - pasSample.Force) / (midSample.Extension - pasSample.Extension);
            }
            if (midSample != null)
                if (prevSample != null && prevSample.StepOrCycle == midSample.StepOrCycle)
                {
                    return (midSample.GetValue(MeasureType.Stress) - prevSample.GetValue(MeasureType.Stress)) / (midSample.GetValue(MeasureType.Strain) - prevSample.GetValue(MeasureType.Strain));
                }
                else if (pasSample != null && pasSample.StepOrCycle == midSample.StepOrCycle)
                {
                    return (midSample.GetValue(MeasureType.Stress) - pasSample.GetValue(MeasureType.Stress)) / (midSample.GetValue(MeasureType.Strain) - pasSample.GetValue(MeasureType.Strain));
                }
            return double.NaN;
        }

        private double GetBendingStrain(DataSample dataSample)
        {
            double strain = 0;
            switch (TestSample.BendingSampleType)
            {
                case BendingSampleType.Circular:
                    if (TestSample.ThreePoint)
                        strain = 6 * TestSample.R1 * dataSample.Extension / Math.Pow(TestSample.L, 2);
                    else
                        strain = 6 * TestSample.R1 * dataSample.Extension / Math.Pow(TestSample.l * 2, 2);
                    break;

                case BendingSampleType.Rectangular:
                    if (TestSample.ThreePoint)
                        strain = 6 * TestSample.Thickness * dataSample.Extension / Math.Pow(TestSample.L, 2);
                    else
                        strain = 6 * TestSample.Thickness * dataSample.Extension / Math.Pow(TestSample.l * 2, 2);
                    break;
            }
            return strain;
        }

        private double GetBendingStress(DataSample dataSample)
        {
            double stress = 0;
            switch (TestSample.BendingSampleType)
            {
                case BendingSampleType.Circular:
                    if (TestSample.ThreePoint)
                        stress = 8 * dataSample.Force * TestSample.L / (Math.PI * Math.Pow(TestSample.R1, 3));
                    else
                        stress = 8 * dataSample.Force * TestSample.l * 2 / (Math.PI * Math.Pow(TestSample.R1, 3));
                    break;

                case BendingSampleType.Rectangular:
                    if (TestSample.ThreePoint)
                        stress = 3 / 2.0 * dataSample.Force * TestSample.L / (TestSample.Width * Math.Pow(TestSample.Thickness, 2));
                    else
                        stress = 3 / 2.0 * dataSample.Force * TestSample.l * 2 / (TestSample.Width * Math.Pow(TestSample.Thickness, 2));
                    break;
            }
            return stress;
        }

        private double GetBendingModule(DataSample dataSample)
        {
            double module = 0;
            switch (TestSample.BendingSampleType)
            {
                case BendingSampleType.Circular:
                    if (TestSample.ThreePoint)
                        module = 4 * dataSample.Force * Math.Pow(TestSample.L, 3) / (3 * Math.PI * dataSample.Extension * Math.Pow(TestSample.R1, 4));
                    else
                        module = 4 * dataSample.Force * Math.Pow(2 * TestSample.l, 3) / (3 * Math.PI * dataSample.Extension * Math.Pow(TestSample.R1, 4));
                    break;

                case BendingSampleType.Rectangular:
                    if (TestSample.ThreePoint)
                        module = 3 / 2.0 * dataSample.Force * TestSample.L / (TestSample.Width * Math.Pow(TestSample.Thickness, 2));
                    else
                        module = 3 / 2.0 * dataSample.Force * TestSample.l * 2 / (TestSample.Width * Math.Pow(TestSample.Thickness, 2));
                    break;
            }
            return module;
        }

        private double GetElongationAfterBreak(DataSample dataSample)
        {
            DataSample peak;
            var m = GetElasticModule(out peak);
            var x = (-dataSample.GetValue(MeasureType.Stress) + m * dataSample.GetValue(MeasureType.Strain)) / m;
            return x;
        }

        private double GetIntegralArea(IList<DataSample> dataSamples, MeasureType x, MeasureType y)
        {
            var retVal = 0.0;

            for (var index = 0; index < dataSamples.Count - 1; index++)
            {
                var dx = dataSamples[index + 1].GetValue(x) - dataSamples[index].GetValue(x);
                var dy = dataSamples[index + 1].GetValue(y) + dataSamples[index].GetValue(y);
                retVal += dx * dy / 2;
            }

            return retVal;
        }

        private double SolveFormula(dynamic dataSamples, PointType pointType, string formula)
        {
            formula = formula.Replace(" ", "");
            var singlePoint = dataSamples.GetType() == typeof(SingleReportResult);
            double tmp;

            if (formula.Contains(Formula.Force.ToString()))
            {
                if (singlePoint)
                    tmp = GetPointProperty(dataSamples, pointType, PointProperty.Force);
                else
                    GetPointProperty(dataSamples, pointType, PointProperty.Force, out tmp);
                tmp *= UnitManager.ForceM;
                formula = formula.Replace(Formula.Force.ToString(), tmp.ToString());
            }

            if (formula.Contains(Formula.Extension.ToString()))
            {
                if (singlePoint)
                    tmp = GetPointProperty(dataSamples, pointType, PointProperty.Extension);
                else
                    GetPointProperty(dataSamples, pointType, PointProperty.Extension, out tmp);
                tmp *= UnitManager.ExtenM;
                formula = formula.Replace(Formula.Extension.ToString(), tmp.ToString());
            }
            if (formula.Contains(Formula.Stress.ToString()))
            {
                if (singlePoint)
                    tmp = GetPointProperty(dataSamples, pointType, PointProperty.Stress);
                else
                    GetPointProperty(dataSamples, pointType, PointProperty.Stress, out tmp);
                tmp *= UnitManager.StressM;
                formula = formula.Replace(Formula.Stress.ToString(), tmp.ToString());
            }
            if (formula.Contains(Formula.Strain.ToString()))
            {
                if (singlePoint)
                    tmp = GetPointProperty(dataSamples, pointType, PointProperty.Strain);
                else
                    GetPointProperty(dataSamples, pointType, PointProperty.Strain, out tmp);
                tmp *= UnitManager.StrainM;
                formula = formula.Replace(Formula.Strain.ToString(), tmp.ToString());
            }
            if (formula.Contains(Formula.TrueStrain.ToString()))
            {
                if (singlePoint)
                    tmp = GetPointProperty(dataSamples, pointType, PointProperty.TrueStrain);
                else
                    GetPointProperty(dataSamples, pointType, PointProperty.TrueStrain, out tmp);
                tmp *= UnitManager.StrainM;
                formula = formula.Replace(Formula.TrueStrain.ToString(), tmp.ToString());
            }
            if (formula.Contains(Formula.TrueStress.ToString()))
            {
                if (singlePoint)
                    tmp = GetPointProperty(dataSamples, pointType, PointProperty.TrueStress);
                else
                    GetPointProperty(dataSamples, pointType, PointProperty.TrueStress, out tmp);
                tmp *= UnitManager.StressM;
                formula = formula.Replace(Formula.TrueStress.ToString(), tmp.ToString());
            }
            return Calculator.GetValue(formula);
        }

        #endregion

        #endregion

        #region Reports

        public ReportingResult GetReportingResult(ReportingParameters paramteres, TestMethodType testMethodType)
        {
            SingleReportResult? reportResult = null;
            List<DataSample> pointRange = null;

            var stepOrCycle = paramteres.StepOrCycle;//(testMethodType == TestMethodType.Tensile || testMethodType == TestMethodType.Compressive ) ? -1 : paramteres.StepOrCycle;

            #region point(s) extraction
            switch (paramteres.PointType)
            {
                case PointType.Peak:
                    reportResult = GetPeakForce(stepOrCycle);
                    break;
                case PointType.Break:
                    if(Test.BreakForceOver.HasValue)
                        reportResult = GetBreakSample(Test.BreakForceOver.Value);
                    if (reportResult == null || reportResult.Value.BasePoint == null)
                        reportResult = GetLastPoint();
                    break;
                case PointType.Yield:
                    reportResult = GetYeild();
                    break;
                case PointType.YieldOffset:
                    reportResult = GetOffsetYeild(paramteres.Attribute1);
                    break;
                case PointType.LowerYield:
                    reportResult = GetLowerYield();
                    break;
                case PointType.UpperYield:
                    reportResult = GetUpperYield();
                    break;
                case PointType.MeanYield:
                    reportResult = GetMeanYield();
                    break;
                case PointType.Extension:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtExtension(paramteres.Attribute1.Value, stepOrCycle);
                    break;
                case PointType.Strain:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtStrain(paramteres.Attribute1.Value, stepOrCycle);
                    break;
                case PointType.TrueStrain:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtTrueStrain(paramteres.Attribute1.Value, stepOrCycle);
                    break;

                case PointType.Force:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtForce(paramteres.Attribute1.Value, stepOrCycle);
                    break;
                case PointType.Stress:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtStress(paramteres.Attribute1.Value, stepOrCycle);
                    break;
                case PointType.TrueStress:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtTrueStress(paramteres.Attribute1.Value, stepOrCycle);
                    break;
                    case PointType.MassStress:
                    if (paramteres.Attribute1.HasValue)
                    {
                        reportResult = GetAtMassStress(paramteres.Attribute1.Value, stepOrCycle);
                    }
                    break;
                case PointType.Time:
                    if (paramteres.Attribute1.HasValue)
                        reportResult = GetAtTime(paramteres.Attribute1.Value, stepOrCycle);
                    break;
               
                case PointType.ExtenLimit:
                case PointType.StrainLimit:
                case PointType.TimeLimit:
                    if (paramteres.Attribute1.HasValue && paramteres.Attribute2.HasValue)
                        pointRange = GetRange(ReportingParameters.PointsToMeasureType[paramteres.PointType], paramteres.Attribute1.Value, paramteres.Attribute2.Value, stepOrCycle);
                    break;
                default:
                    break;
            }
            #endregion

            #region property extraction

            var pValue = 0.0;
            if (reportResult.HasValue)
                pValue = GetPointProperty(reportResult.Value, paramteres.PointType, paramteres.PointProperty, paramteres.Formula);
            else if (pointRange != null)
            {
                double area;
                if (paramteres.PointProperty == PointProperty.ForceRate ||
                    paramteres.PointProperty == PointProperty.StressRate ||
                    paramteres.PointProperty == PointProperty.ExtenRate ||
                    paramteres.PointProperty == PointProperty.StrainRate)
                    pValue = GetRate(pointRange, paramteres.PointType, paramteres.PointProperty);
                else
                    pValue = GetPointProperty(pointRange, paramteres.PointType, paramteres.PointProperty, out area);
               
            }

            #endregion

            var reportPoint = new ReportingResult
            {
                ReportingPrameteres = paramteres,
                TestingSample = TestSample,
                Value = pValue,
                IsRangeLimit = pointRange != null,
                BasePoints = reportResult != null
                        ? new List<DataSample> { reportResult.Value.BasePoint }
                        : new List<DataSample> { pointRange.First(), pointRange.Last() },
                
                Attribute1 = reportResult.HasValue? reportResult.Value.Attribute1: null,
                TestName = Name
            };

            return reportPoint;
        }



        public void RemoveReportPoint(int pointId)
        {

        }

        public List<ExeclReportParameter> GetTestSettingsToReport()
        {
            var list = new List<ExeclReportParameter> { new ExeclReportParameter() { Name = "TestName", Value = TestName } };
            try
            {
                var xmlSetting = XmlTestSetting;
                var xmlDoc = XDocument.Parse(xmlSetting);
                var method = xmlDoc.Descendants("root").Descendants("GetTestParameters").First();
                var test = GetTestSettingsToReport(method);
                list.AddRange(test);
            }
            catch
            {
            }

            list.Add(new ExeclReportParameter() { Name = string.Empty, Value = string.Empty });

            return list;
        }

        #endregion

        private List<ExeclReportParameter> GetTestSettingsToReport(XElement xElement)
        {
            var mthodsParameter = new ExeclReportParameter() { Name = "Test Method" };
            var method = (TestMethodType)Enum.Parse(typeof(TestMethodType), xElement.Attribute("TestMethodType").Value);
            List<ExeclReportParameter> list;
            switch (method)
            {
                case TestMethodType.Compressive:
                    mthodsParameter.Value = @"Compression Test";
                    list = SetCompressiveFields(xElement);
                    break;

                case TestMethodType.Creep:
                    mthodsParameter.Value = @"Creep Test";
                    list = SetCreepFields(xElement);
                    break;

                case TestMethodType.Cyclic:
                    mthodsParameter.Value = @"Cyclic Test";
                    list = SetCyclicFields(xElement);
                    break;

                case TestMethodType.Relaxation:
                    mthodsParameter.Value = @"Relaxation Test";
                    list = SetRelaxationFields(xElement);
                    break;

                case TestMethodType.Step:
                    mthodsParameter.Value = @"Step Test";
                    list = SetStepFields(xElement);
                    break;

                case TestMethodType.Tensile:
                    mthodsParameter.Value = @"Tension Test";
                    list = SetTensileFields(xElement);
                    break;

                default:
                    list = new List<ExeclReportParameter>(1);
                    break;
            }
            list.Insert(0, mthodsParameter);

            return list;
        }

        private List<ExeclReportParameter> SetTensileFields(XElement xElement)
        {
            var list = new List<ExeclReportParameter>();
            if (bool.Parse(xElement.Attribute("TensilePreLoad").Value))
            {
                list.Add(new ExeclReportParameter(){Name="Preload", Value = xElement.Attribute("TensilePreLoadSetPoint").Value});
            }

            list.Add(new ExeclReportParameter() { Name = "Speed", Value = xElement.Attribute("MethodSpeed").Value });

            if (bool.Parse(xElement.Attribute("TensileEnableSecondSpeed").Value))
            {
                list.Add(new ExeclReportParameter() { Name = "Speed 2", Value = xElement.Attribute("TensileSecondSpeed").Value });
                list.Add(new ExeclReportParameter() { Name = "Speed 2 condition", Value = xElement.Attribute("TensileSecSpeedSetPoint").Value });
            }

            if (bool.Parse(xElement.Attribute("TensileEnableStoE").Value))
            {
                list.Add(new ExeclReportParameter() { Name = "S to E", Value = xElement.Attribute("TensileStoEType").Value });
            }

            return list;
        }

        private List<ExeclReportParameter> SetStepFields(XElement xElement)
        {
            var list = new List<ExeclReportParameter>();
            var steps = xElement.Descendants("Step").ToList();
            var i = 0;
            for (var j = 0; j < steps.Count; j++)
            {
                var rateType = steps[j].Attribute("Ctrl").Value;
                var rateUnit = steps[j].Attribute("Unit").Value;
                var rate = steps[j].Attribute("Rate").Value.ToDouble().ToString("0.##");
                var setType = steps[j].Attribute("LimitType").Value;
                var setUnit = steps[j].Attribute("LUnit").Value;
                var set = steps[j].Attribute("Limit").Value.ToDouble().ToString("0.##");
                var act = steps[j].Attribute("Action").Value;

                var item = new ExeclReportParameter
                {
                    Name = $"Step {j + 1}",
                    Value = $"Limit: {set}({setUnit})" + @", " + $"Speed: {rate}({rateUnit})" + $", Action: {act}"
                };
                i += 2;
            }

            return list;
        }

        private List<ExeclReportParameter> SetRelaxationFields(XElement xElement)
        {
            var list = new List<ExeclReportParameter>();
            list.Add(new ExeclReportParameter() { Name = $"Relax Set Point ({xElement.Attribute("RelaxSetPointType").Value})", Value = xElement.Attribute("CreepSetPoint").Value });
            list.Add(new ExeclReportParameter() { Name = $"Loading Ctrl Type", Value = xElement.Attribute("RelaxRate").Value });
            list.Add(new ExeclReportParameter() { Name = $"Test Time", Value = xElement.Attribute("RelaxTestTime").Value });
            return list;
        }

        private List<ExeclReportParameter> SetCyclicFields(XElement xElement)
        {
            var list = new List<ExeclReportParameter>();

            return list;

        }

        private List<ExeclReportParameter> SetCreepFields(XElement xElement)
        {
            var list = new List<ExeclReportParameter>();
            list.Add(new ExeclReportParameter() { Name = "Creep Set Point", Value = xElement.Attribute("CreepSetPoint").Value });
            list.Add(new ExeclReportParameter() { Name = $"Creep Set Point ({xElement.Attribute("CreepSetPointType").Value})", Value = xElement.Attribute("CreepSetPoint").Value });
            list.Add(new ExeclReportParameter() { Name = "Creep Rate", Value = xElement.Attribute("CreepRate").Value });
            list.Add(new ExeclReportParameter() { Name = "Keeping Time", Value = xElement.Attribute("CreepStablizeTime").Value });
            list.Add(new ExeclReportParameter() { Name = "Test Time", Value = xElement.Attribute("CreepTestTime").Value });
            return list;

        }

        private List<ExeclReportParameter> SetCompressiveFields(XElement xElement)
        {
            var list = new List<ExeclReportParameter>();
            list.Add(new ExeclReportParameter() { Name = "Speed", Value = xElement.Attribute("MethodSpeed").Value });
            return list;
        }


        public string TestName { get; set; }
    }
}