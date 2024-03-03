using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer.Reporting;
using STM.BLayer.StmTest;
using STM.Properties;

namespace STM.PLayer.UI
{
    class Plot : PictureBox
    {
        #region fields

        public static string XMeasureText { set; get; }
        public static string YMeasureText { set; get; }
        public static string Y2MeasureText { set; get; }

        public static string XUnitText { set; get; }
        public static string YUnitText { set; get; }
        public static string Y2UnitText { set; get; }

        public static double XM { set; get; }
        public static double YM { set; get; }
        public static double Y2M { set; get; }

        public bool XOffset { set; get; }

        public static MeasureType XMeasureType { set; get; }
        public static MeasureType YMeasureType { set; get; }
        public static MeasureType Y2MeasureType { set; get; }

        public int MaxDataCount { set; get; }
        private ZoomFrame curZoomFrame;

        public bool DrawRect { get; set; }
        public int MarginLeft { set; get; }
        public int BaseMarginLeft { set; get; }
        public int MarginRight { set; get; }
        public int MarginTop { set; get; }
        public int MarginBottom { set; get; }

        public bool TestValidData { set; get; }

        private bool mouseDown;
        private Point mouseCurPoint;
        private Point mouseDownPoint;
        private Point mouseLastPoint;
        private Rectangle zoomRect;
        public ViewCmd ViewCmd;
        public PlotDataSource DataSource;
        private bool dataIsEmpty;

        public List<ReportingResult> ReportPoints { set; get; }

        public bool ShowMousePointLocation { get; set; }

        public bool ShowReportPoints { get; set; }
        public bool ShowReportLabels { get; set; }
        public bool ShowReportLines { get; set; }

        #endregion

        public Color GridColor { get; set; }
        public Color LabelColor { get; set; }
        public Color MarginColor { get; set; }
        public Color ScaleColor { get; set; }
        public Color BackGroundColor { set; get; }

        #region initilizing

        public Plot()
        {
            ReportPoints = new List<ReportingResult>();
            ResetPlotLables();
        }

        public void ResetPlotLables()
        {
            XMeasureType = MeasureType.Extension;
            XUnitText = MeasureTool.GetMeasureName(XMeasureType);
            XM = 1.0;
            XMeasureText = Resources.MeasureTool_MeasurAbbreviations_Extension.ToUpper();

            YMeasureType = MeasureType.Force;
            YUnitText = MeasureTool.GetMeasureName(YMeasureType);
            YM = 1.0;
            YMeasureText = Resources.MeasureTool_MeasurAbbreviations_Force.ToUpper();

            if (true)
            {
                Y2MeasureType = MeasureType.Temperature;
                Y2UnitText = MeasureTool.GetMeasureName(Y2MeasureType);
                Y2M = 1.0;
                Y2MeasureText = Resources.MeasureTool_MeasurAbbreviations_Temperature.ToUpper();
            }
            else
            {
                Y2MeasureType = MeasureType.None;
                Y2UnitText = null;
                Y2M = 0;
                Y2MeasureText = null;
            }
        }

        public void Initilize(bool reset = true)
        {
            MarginLeft = 50;
            BaseMarginLeft = 50;
            MarginTop = 20;
            MarginBottom = 50;
            MarginRight = 70;
            ReportPoints = new List<ReportingResult>();
            PlotDataSource.MarginTop = MarginTop;
            PlotDataSource.MarginRight = MarginRight;
            PlotDataSource.MarginBottom = MarginBottom;
            PlotDataSource.MarginLeft = BaseMarginLeft;
            PlotDataSource.DrawingSize = Size;

            dataIsEmpty = true;
            DataSource = new PlotDataSource();

            GridColor = Colors.Grid;
            LabelColor = Colors.Lable;
            MarginColor = Colors.PageSpace;
            ScaleColor = Colors.Scale;
            BackGroundColor = Colors.Background;
            if (reset)
            {
                DataSource.Reset();
                DataSource.Invalid = true;
            }
        }

        #endregion

        #region mouse events

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left)
                return;
            if (ViewCmd == ViewCmd.None)
                return;

            var point = SetInMargin(e.Location);
            mouseDownPoint = point;
            mouseLastPoint = point;
            zoomRect = new Rectangle(0, 0, 0, 0);
            mouseDown = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (ViewCmd == ViewCmd.PointSelection || ShowMousePointLocation)
            {
                mouseCurPoint = SetInMargin(e.Location);
                Invalidate();
            }
            else if (mouseDown)
            {
                if (!(Gph.GetDistance(e.Location, mouseLastPoint) > 3)) return;
                mouseLastPoint = SetInMargin(e.Location);
                zoomRect = Gph.GetRectangle(mouseDownPoint, mouseLastPoint);
                Invalidate();
            }
        }

        private Point SetInMargin(Point point)
        {
            if (point.X < MarginLeft)
                point.X = MarginLeft;
            else if (point.X > Width - MarginRight)
                point.X = Width - MarginRight;

            if (point.Y < MarginTop)
                point.Y = MarginTop;
            else if (point.Y > Height - MarginBottom)
                point.Y = Height - MarginBottom;

            return point;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left)
                return;
            mouseDown = false;

            switch (ViewCmd)
            {
                case ViewCmd.Zoom:
                    #region zoom
                    {
                        //var rectangle = Gph.GetRectangle(new Point { X = mouseDownPoint.X - MarginLeft- DataSource.yScaleWidth, Y = mouseDownPoint.Y - MarginTop },
                        //                                       new Point { X = mouseLastPoint.X - MarginLeft - DataSource.yScaleWidth, Y = mouseLastPoint.Y - MarginTop });
                        var rectangle = Gph.GetRectangle(new Point { X = mouseDownPoint.X - MarginLeft, Y = mouseDownPoint.Y - MarginTop },
                                                               new Point { X = mouseLastPoint.X - MarginLeft, Y = mouseLastPoint.Y - MarginTop });

                        if (rectangle.Width < 5)
                            return;

                        ZoomIn(rectangle);
                        Invalidate();
                    }
                    #endregion
                    break;

                case ViewCmd.Pan:
                    #region Pan
                    {
                        Pan(mouseLastPoint.X - mouseDownPoint.X, mouseLastPoint.Y - mouseDownPoint.Y);
                        Invalidate();
                    }
                    #endregion
                    break;

                case ViewCmd.PointSelection:
                    #region PointSelection
                    {
                        var point = SetInMargin(e.Location);
                        if (ViewCmd == ViewCmd.PointSelection)
                        {
                            var x = DataSource.GetXAttribute(point.X);
                            OnPointClick(this, new PointEventArgs { Unit = XUnitText, X = x, XType = XMeasureType });
                        }
                        Invalidate();
                    }
                    #endregion
                    break;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseDown = false;
        }

        #endregion

        #region Graphic

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            if (dataIsEmpty)
            {
                curZoomFrame = DataSource.GetCurZoomLevel();
                DrawGrids(e.Graphics, curZoomFrame, Width, Height, MarginLeft, MarginRight, MarginTop, MarginBottom);
            }

            if (ViewCmd == ViewCmd.Zoom && mouseDown)
            {
                #region zoom rectangle

                using (var pen = new Pen(Color.Black))
                {
                    pen.DashStyle = DashStyle.DashDot;
                    pen.DashOffset = 20;
                    e.Graphics.DrawRectangle(pen, zoomRect);
                }

                #endregion
            }
            else if (ViewCmd == ViewCmd.Pan && mouseDown)
            {
                #region pan line

                using (var pen = new Pen(Color.Black))
                {
                    pen.DashStyle = DashStyle.DashDot;
                    pen.DashOffset = 20;
                    e.Graphics.DrawLine(pen, mouseDownPoint, mouseLastPoint);
                }

                #endregion
            }
            else if (ViewCmd == ViewCmd.PointSelection || ShowMousePointLocation)
            {
                try
                {
                    var pos = DataSource.GetPointValue(new Point(mouseCurPoint.X - MarginLeft, mouseCurPoint.Y - MarginTop));
                    var y = TestDataSource.GetMousePos(DataSource.Indicators, XMeasureType, YMeasureType, pos.X, pos.Y);
                    if (y.HasValue)
                    {
                        var zoomWidth = Math.Abs(curZoomFrame.ScaledMaxX - curZoomFrame.ScaledMinX);
                        var zoomHeight = Math.Abs(curZoomFrame.ScaledMaxY - curZoomFrame.ScaledMinY);

                        var ht = (Height - MarginTop - MarginBottom);
                        var dPoint = new Point
                                    (
                                    MarginLeft + (int)((DataSource.XReversed ? (-pos.X + curZoomFrame.ScaledMaxX) : (pos.X - curZoomFrame.ScaledMinX)) / zoomWidth * (Width - MarginLeft - MarginRight)),
                                    MarginTop + (int)(DataSource.YReversed ? (ht - (-y + curZoomFrame.ScaledMaxY) / zoomHeight * ht) : (ht - (y - curZoomFrame.ScaledMinY) / zoomHeight * ht))
                                    );

                        e.Graphics.DrawLine(Pens.Blue, dPoint.X, MarginTop, dPoint.X, Height - MarginBottom);
                        if (DataSource.DataSources.Count == 1)
                            e.Graphics.DrawLine(Pens.Blue, MarginLeft, dPoint.Y, Width - MarginRight, dPoint.Y);

                        using (var font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point))
                        {
                            var xstr = string.Format("{0:0.###}", pos.X * XM);
                            var ystr = string.Format("{0:0.###}", y * YM);
                            var h = (int)e.Graphics.MeasureString("1", font).Height * (DataSource.DataSources.Count == 1 ? 2 : 1);
                            var w = (int)e.Graphics.MeasureString(xstr, font).Width;
                            if (DataSource.DataSources.Count == 1)
                                w = (int)Math.Max(w, e.Graphics.MeasureString(ystr, font).Width);

                            var rect = new Rectangle(dPoint.X + 15, dPoint.Y + 15, w + 5, h);
                            rect.X = Math.Max(rect.X, MarginLeft);
                            rect.X = Math.Min(rect.Right - w - 5, Width - MarginRight);
                            rect.Y = Math.Max(MarginTop, rect.Top);
                            rect.Y = Math.Min(Height - MarginBottom - h, rect.Top);
                            using (var brush = new SolidBrush(Color.FromArgb(255, 200, 200, 0)))
                            {
                                e.Graphics.FillRectangle(brush, rect);
                                e.Graphics.DrawRectangle(Pens.Blue, rect);
                            }
                            e.Graphics.DrawString(xstr, font, Brushes.Black, rect, new StringFormat { LineAlignment = StringAlignment.Near });
                            if (DataSource.DataSources.Count == 1)
                                e.Graphics.DrawString(ystr, font, Brushes.Black, rect, new StringFormat { LineAlignment = StringAlignment.Far });
                        }
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
            }

            #region sample drawing

            try
            {
                if (DataSource.CurTestSource != null)
                {
                    var points = DataSource.CurTestSource.ForegroundDrawnPoints.ToArray();
                    if (points.Length > 1)
                        using (var pen = new Pen(Colors.Diagram))
                        {
                            e.Graphics.DrawLines(pen, points);
                        }
                    using (var pen = new Pen(Colors.Diagram2))
                    {
                        var points2 = DataSource.CurTestSource.TemperatureFgDrawnPoints.ToArray();
                        if (points2.Length > 1)
                            e.Graphics.DrawLines(pen, points2);
                    }
                }
                if (DataSource.Invalid)
                {
                    var zf = DataSource.GetCurZoomLevel();
                    using (var bitmap = new Bitmap(10, 10))
                    {
                        var gph = Graphics.FromImage(bitmap);
                        using (var font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point))
                        {
                            var m = (int)gph.MeasureString(string.Format("{0:0.000}", curZoomFrame.ScaledMaxY * YM), font).Width;
                            MarginLeft = BaseMarginLeft + m;
                            PlotDataSource.MarginLeft = MarginLeft;
                            if ((DataSource.CurTestSource != null && DataSource.CurTestSource.HasTemperature)
                            || (DataSource.DataSources.Any(ds => ds.HasTemperature)))//Nazarpour
                                                                                     //var points2 = DataSource.CurTestSource.ForegroundDrawnPoints.ToArray();
                                using (var pen = new Pen(Colors.Diagram2))
                                {
                                    PlotDataSource.MarginRight = MarginRight; // +m
                                                                              //e.Graphics.DrawLines(pen, points2);
                                }
                            PlotDataSource.DrawingSize = Size;
                        }
                    }
                    SetBackGround(CreateBasePlot(zf, Width, Height, MarginLeft, MarginRight, MarginTop, MarginBottom));
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                }
            }
            catch (Exception ex)
            {
                Console.Write(@"exception :" + ex.Message);
            }

            #endregion


        }

        private Bitmap CreateBasePlot(ZoomFrame zoomFrame, int width, int height, int leftMargin, int rightMargin, int topMargin,
                                      int bottomMargin, bool print = false)
        {

            var testsXoffset = DataSource.DataSources.ToDictionary(p => p.Name, p => 0);

            curZoomFrame = zoomFrame;
            DataSource.Invalid = false;
            var basePlot = new Bitmap(width, height);
            var gph = Graphics.FromImage(basePlot);
            gph.Clear(BackGroundColor);
            gph.SmoothingMode = SmoothingMode.AntiAlias;
            gph.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;


            var plotWidth = width - leftMargin - rightMargin;
            var plotHeight = height - topMargin - bottomMargin;
            gph.DrawRectangle(Pens.Blue, leftMargin, topMargin, plotWidth, plotHeight);

            if (DataSource.CurTestSource != null && DataSource.CurTestSource.BackGroundDrawnPoints.Count > 0)
            {
                Draw(gph, Colors.Diagram, Marker.None, DashStyle.Solid, false, DataSource.CurTestSource.BackGroundDrawnPoints.ToArray());
                Draw(gph, Colors.Diagram2, Marker.None, DashStyle.Solid, false, DataSource.CurTestSource.TemperatureBgDrawnPoints.ToArray());
            }
            else
            {
                //if (!print)
                //    DataSource.Indicators = new Point[plotWidth];

                var zoomWidth = Math.Abs(zoomFrame.ScaledMaxX - zoomFrame.ScaledMinX);
                var zoomHeight = Math.Abs(zoomFrame.ScaledMaxY - zoomFrame.ScaledMinY);
                var zoomY2 = Math.Abs(zoomFrame.ScaledMaxY2 - zoomFrame.ScaledMinY2);

                var step = (XOffset ? PlotAligner.XStep / XM : 0) / zoomWidth * plotWidth;
                var xoff = -step;

                foreach (var source in DataSource.DataSources)
                {
                    xoff += step;
                    if (testsXoffset.ContainsKey(source.Name))
                        testsXoffset[source.Name] = (int)xoff;
                    DataSource.Indicators = source.GetZoomRect(zoomFrame.MinX, zoomFrame.MaxX, zoomFrame.MinY, zoomFrame.MaxY).ToList();
                    if (!DataSource.Indicators.Any())
                        continue;
                    //if (!print)
                    //    try
                    //    {
                    //        foreach (var data in samples)
                    //        {

                    //            var index = (int)((DataSource.XReversed ? (-data.XValue + zoomFrame.ScaledMaxX) : (data.XValue - zoomFrame.ScaledMinX)) / zoomWidth * (plotWidth));
                    //            if (index < 0)
                    //                continue;
                    //            DataSource.Indicators[index] = new Point
                    //                (
                    //                leftMargin + (int)((DataSource.XReversed ? (-data.XValue + zoomFrame.ScaledMaxX) : (data.XValue - zoomFrame.ScaledMinX)) / zoomWidth * (plotWidth)),
                    //                topMargin + (int)(DataSource.YReversed ? (plotHeight - (-data.YValue + zoomFrame.ScaledMaxY) / zoomHeight * plotHeight) : (plotHeight - (data.YValue - zoomFrame.ScaledMinY) / zoomHeight * plotHeight))
                    //                );
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        ex.ToString();
                    //    }

                    var samplesGroup = DataSource.Indicators.GroupBy(p => p.StepOrCycle);
                    foreach (var points in samplesGroup.Select(dataSamples => dataSamples.Select(p => GetPlotCordination(leftMargin, topMargin, zoomWidth, zoomHeight, (int)xoff, p, plotWidth, plotHeight)).ToArray()))
                    {
                        Draw(gph, source.DrawingColor, source.Marker, source.LineStyle, false, points.ToArray());
                    }
                    if (zoomY2 > double.Epsilon || zoomY2 < -double.Epsilon)
                        foreach (var points in samplesGroup.Select(dataSamples => dataSamples.Select(p => GetPlotCordination2(leftMargin, topMargin, zoomWidth, zoomY2, (int)xoff, p, plotWidth, plotHeight)).ToArray()))
                        {
                            Draw(gph, Colors.Diagram2, source.Marker, source.LineStyle, false, points.ToArray());
                        }
                }
            }
            DrawReportPoints(zoomFrame, gph, width, height, leftMargin, rightMargin, topMargin, bottomMargin, testsXoffset);
            DrawGrids(gph, zoomFrame, width, height, leftMargin, rightMargin, topMargin, bottomMargin);
            return basePlot;
        }


        private void Draw(Graphics gph, Color foreColor, Marker marker, DashStyle dash, bool discarte, PointF[] points)
        {
            MaxDataCount = Math.Max(MaxDataCount, points.Length);

            try
            {
                using (var pen = new Pen(foreColor))
                {
                    pen.DashStyle = dash;
                    switch (marker)
                    {
                        case Marker.None:
                            gph.DrawLines(pen, points);
                            break;

                        case Marker.Circle:
                            if (!discarte)
                                gph.DrawLines(pen, points);
                            foreach (PointF pointF in points)
                            {
                                gph.DrawEllipse(pen, pointF.X - 2, pointF.Y - 2, 4, 4);
                            }
                            break;

                        case Marker.Triangular:
                            if (!discarte)
                                gph.DrawLines(pen, points);
                            foreach (PointF pointF in points)
                            {
                                var ps = new[]
                                {
                                    new PointF(pointF.X, pointF.Y - 3),
                                    new PointF(pointF.X - 3, pointF.Y + 3),
                                    new PointF(pointF.X + 3, pointF.Y + 3),
                                    new PointF(pointF.X, pointF.Y - 3)
                                };
                                gph.DrawLines(pen, ps);
                            }
                            break;

                        case Marker.Square:
                            if (!discarte)
                                gph.DrawLines(pen, points);
                            foreach (var pointF in points)
                            {
                                gph.DrawRectangle(pen, pointF.X - 2, pointF.Y - 2, 4, 4);
                            }
                            break;

                        case Marker.Star:
                            if (!discarte)
                                gph.DrawLines(pen, points);
                            using (Brush brush = new SolidBrush(pen.Color))
                            {
                                using (var font = new Font(FontFamily.GenericSerif, 10))
                                {
                                    foreach (PointF pointF in points)
                                    {
                                        gph.DrawString("*", font, brush, pointF.X - 5, pointF.Y - 5);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        private void DrawReportPoints(ZoomFrame zoomFrame, Graphics gph, int width, int height, int leftMargin, int rightMargin, int topMargin,
                                      int bottomMargin, IDictionary<string, int> testsXoffset)
        {
            var plotWidth = width - leftMargin - rightMargin;
            var plotheight = height - topMargin - bottomMargin;
            var zoomWidth = Math.Abs(zoomFrame.ScaledMaxX - zoomFrame.ScaledMinX);
            var zoomHeight = Math.Abs(zoomFrame.ScaledMaxY - zoomFrame.ScaledMinY);
            var zoomY2 = Math.Abs(zoomFrame.ScaledMaxY2 - zoomFrame.ScaledMinY2);
            try
            {

                if (ShowReportPoints)
                {
                    var pen = new Pen(LabelColor);
                    var brush = new SolidBrush(LabelColor);
                    var font = new Font(FontFamily.GenericSansSerif, 9);
                    foreach (var point in ReportPoints)
                    {
                        var offset = testsXoffset.ContainsKey(point.TestName) ? testsXoffset[point.TestName] : 0;
                        switch (point.BasePoints.Count)
                        {
                            case 2:
                                if (ShowReportLines && ReportingParameters.PointPropertyToMeasureType[point.ReportingPrameteres.PointProperty] == YMeasureType)
                                {
                                    var p1 = GetPlotCordination(leftMargin, topMargin, zoomWidth, zoomHeight, offset, point.Value, point.BasePoints[0].GetValue(XMeasureType), plotWidth, plotheight);
                                    var p2 = GetPlotCordination(leftMargin, topMargin, zoomWidth, zoomHeight, offset, point.Value, point.BasePoints[1].GetValue(XMeasureType), plotWidth, plotheight);
                                    gph.DrawLine(pen, p1, p2);
                                    if (ShowReportLabels)
                                    {
                                        var rect = Gph.GetRectangle(p1, p2);
                                        rect.Y -= 25;
                                        rect.Height = 50;
                                        gph.DrawString(point.ReportingPrameteres.Name, font, brush,
                                                 rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                                    }
                                }
                                break;
                            case 1:
                                {
                                    var p1 = GetPlotCordination(leftMargin, topMargin, zoomWidth, zoomHeight, offset, point.BasePoints[0], plotWidth, plotheight);

                                    gph.FillEllipse(brush, p1.X - 2, p1.Y - 2, 4, 4);

                                    if (point.Attribute1 != null && ShowReportLines)
                                    {
                                        var m = (point.BasePoints[0].GetValue(YMeasureType) - point.Attribute1.GetValue(YMeasureType)) /
                                                (point.BasePoints[0].GetValue(XMeasureType) - point.Attribute1.GetValue(XMeasureType));
                                        double y2 = 0;
                                        var x2 = -(point.BasePoints[0].GetValue(YMeasureType) - m * point.BasePoints[0].GetValue(XMeasureType)) / m;
                                        var pp2 = GetPlotCordination(leftMargin, topMargin, zoomWidth, zoomHeight, offset, y2, x2, plotWidth, plotheight);
                                        gph.DrawLine(pen, p1, pp2);
                                    }

                                    if (ShowReportLabels)
                                    {
                                        gph.DrawString(point.ReportingPrameteres.Name, font, brush,
                                                 new RectangleF(p1.X - 60, p1.Y - 25, 120, 20),
                                                 new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private PointF GetPlotCordination(int leftMargin, int topMargin, double zoomWidth, double zoomHeight, int offset, DataSample dataSample, int plotWidth, int plotHeight)
        {
            return dataSample == null ? new PointF(-500, -500) :
            new PointF
                (
                leftMargin + (float)((DataSource.XReversed ? (-dataSample.GetValue(XMeasureType) + curZoomFrame.ScaledMaxX) : (dataSample.GetValue(XMeasureType) - curZoomFrame.ScaledMinX)) / zoomWidth * plotWidth) + offset,
                topMargin + (float)(DataSource.YReversed ? (plotHeight - (-dataSample.GetValue(YMeasureType) + curZoomFrame.ScaledMaxY) / zoomHeight * plotHeight) : (plotHeight - (dataSample.GetValue(YMeasureType) - curZoomFrame.ScaledMinY) / zoomHeight * plotHeight))
                );
        }
        private PointF GetPlotCordination(int leftMargin, int topMargin, double zoomWidth, double zoomHeight, int offset, double y, double x, int plotWidth, int plotHeight)
        {
            return new PointF
                (
                leftMargin + (float)((DataSource.XReversed ? (-x + curZoomFrame.ScaledMaxX) : (x - curZoomFrame.ScaledMinX)) / zoomWidth * plotWidth) + offset,
                topMargin + (float)(DataSource.YReversed ? (plotHeight - (-y + curZoomFrame.ScaledMaxY) / zoomHeight * plotHeight) : (plotHeight - (y - curZoomFrame.ScaledMinY) / zoomHeight * plotHeight))
                );
        }
        private PointF GetPlotCordination2(int leftMargin, int topMargin, double zoomWidth, double zoomHeight, int offset, DataSample dataSample, int plotWidth, int plotHeight)
        {
            return Y2MeasureType != MeasureType.None ? ( dataSample == null ? new PointF(-500, -500) :
            new PointF
                (
                leftMargin + (float)((DataSource.XReversed ? (-dataSample.GetValue(XMeasureType) + curZoomFrame.ScaledMaxX) : (dataSample.GetValue(XMeasureType) - curZoomFrame.ScaledMinX)) / zoomWidth * plotWidth) + offset,
                topMargin + (float)(DataSource.Y2Reversed ? (plotHeight - (-dataSample.GetValue(Y2MeasureType) + curZoomFrame.ScaledMaxY2) / zoomHeight * plotHeight) : (plotHeight - (dataSample.GetValue(Y2MeasureType) - curZoomFrame.ScaledMinY2) / zoomHeight * plotHeight))
                )) : new PointF(-500, -500);
        }

        private void DrawGrids(Graphics gph, ZoomFrame zoomFrame, int width, int height, int leftMargin, int rightMargin, int topMargin, int bottomMargin)
        {
            curZoomFrame.CheckMaxs();
            var xl = Math.Abs(zoomFrame.ScaledMaxX - zoomFrame.ScaledMinX);

            PlotDataSource.XGridsCount = 0;
            PlotDataSource.YGridsCount = 0;
            PlotDataSource.Y2GridsCount = 0;

            var wl = width - leftMargin - rightMargin;
            var hl = height - topMargin - bottomMargin;

            using (Brush brush = new SolidBrush(MarginColor))
            {
                gph.FillRectangle(brush, 0, 0, leftMargin, height);
                gph.FillRectangle(brush, 0, 0, width, topMargin);
                gph.FillRectangle(brush, width - rightMargin, 0, rightMargin, height);
                gph.FillRectangle(brush, 0, height - bottomMargin, width, bottomMargin);
            }
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoClip
            };

            gph.SmoothingMode = SmoothingMode.Default;
            using (var font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                using (Brush brushY2 = new SolidBrush(Colors.Diagram2))
                using (Brush brush = new SolidBrush(Colors.Lable))
                {
                    if (!string.IsNullOrEmpty(XMeasureText))
                        gph.DrawString(XMeasureText, font, brush, new Rectangle(leftMargin, height - bottomMargin, width - leftMargin - rightMargin, 50), sf);
                    if (!string.IsNullOrEmpty(YMeasureText))
                        gph.DrawString(YMeasureText, font, brush, new Rectangle(0, topMargin, 20, height - topMargin - bottomMargin), sf);
                    // Nazarpour
                    if (DataSource.Y2Step != 0)
                        gph.DrawString(Y2MeasureText, font, brushY2, new Rectangle(width - 20, topMargin, 20, height - topMargin - bottomMargin), sf);
                }
            }
            using (var font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point))
            {
                using (Brush brush = new SolidBrush(Colors.Lable))
                {
                    sf.Alignment = StringAlignment.Far;
                    if (!string.IsNullOrEmpty(XMeasureText))
                        gph.DrawString(string.Format("{0}", XUnitText), font, brush, new Rectangle(width - 150, height - bottomMargin, 150, 50), sf);

                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    if (!string.IsNullOrEmpty(YMeasureText))
                        gph.DrawString(string.Format("{0}", YUnitText), font, brush, new Rectangle(leftMargin, 0, 150, topMargin), sf);
                    // Nazarpour
                    if (DataSource.Y2Step != 0)
                    {
                        var t = string.Format("{0}", Y2UnitText);
                        var size = gph.MeasureString(t, font);
                        gph.DrawString(t, font, brush, new RectangleF(width - MarginRight - size.Width, MarginTop - size.Height, size.Width, size.Height), sf);
                    }
                }
            }

            try
            {
                gph.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                using (var font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point))
                {
                    using (var brush = new SolidBrush(ScaleColor))
                    {
                        using (var pen = new Pen(GridColor))
                        {
                            var yl = Math.Abs(zoomFrame.ScaledMaxY - zoomFrame.ScaledMinY);
                            var emptyOrNuulTest = DataSource.DataSources.Count == 0 && DataSource.CurTestSource == null;
                            var xm = emptyOrNuulTest ? 1 : XM;
                            xm = xm == 0 ? 1 : xm;

                            pen.DashStyle = DashStyle.Dot;
                            var x = DataSource.StartX / xm;
                            sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                            var sign = curZoomFrame.XReversed ? -1 : 1;
                            var smx = sign == 1 ? curZoomFrame.ScaledMaxX : -curZoomFrame.ScaledMinX;
                            var six = sign == 1 ? curZoomFrame.ScaledMinX : -curZoomFrame.ScaledMaxX;

                            while (x < smx)
                            {
                                var px = (int)((x - six) / xl * wl) + leftMargin;
                                if (px >= leftMargin && px <= width - rightMargin)
                                {
                                    PlotDataSource.XGridsCount++;
                                    if (Options.ShowGridLines)
                                        gph.DrawLine(pen, px, topMargin, px, height - bottomMargin);
                                    gph.DrawString(string.Format("{0:0.0##}", x * xm * sign), font, brush, new Rectangle(px - 30, height - bottomMargin, 60, 20), sf);
                                }
                                x += (DataSource.XStep == 0 ? xm / 10 : DataSource.XStep) / xm;
                            }
                            {
                                var ym = emptyOrNuulTest ? 1 : YM;
                                ym = ym == 0 ? 1 : ym;
                                var y = DataSource.StartY / ym;
                                sf.Alignment = StringAlignment.Far;
                                sign = curZoomFrame.YReversed ? -1 : 1;
                                var smy = sign == 1 ? curZoomFrame.ScaledMaxY : -curZoomFrame.ScaledMinY;
                                var siy = sign == 1 ? curZoomFrame.ScaledMinY : -curZoomFrame.ScaledMaxY;
                                while (y <= smy && !double.IsInfinity(smy))
                                {
                                    var py = hl - (int)((y - siy) / yl * hl) + topMargin;
                                    if (py >= topMargin && py <= height - bottomMargin)
                                    {
                                        PlotDataSource.YGridsCount++;
                                        if (Options.ShowGridLines)
                                            gph.DrawLine(pen, leftMargin, py, width - rightMargin, py);
                                        gph.DrawString(string.Format("{0:0.0##}", y * ym * sign), font, brush, new Rectangle(0, py - 10, leftMargin, 20), sf);
                                    }
                                    var dy = (DataSource.YStep == 0 ? xm / 4 : DataSource.YStep) / ym;
                                    var yBefore = (int)y;
                                    if (yl * hl > float.Epsilon)
                                        for (var nY = hl - (int)((y - siy) / yl * hl) + topMargin; py == nY; y += dy)
                                        {
                                            nY = hl - (int)((y - siy) / yl * hl) + topMargin;
                                        }
                                    if ((int)y == yBefore) y++;

                                }
                            }
                            if (DataSource.Y2Step != 0)
                            {
                                var y2l = Math.Abs(zoomFrame.ScaledMaxY2 - zoomFrame.ScaledMinY2);
                                var y2m = emptyOrNuulTest ? 1 : Y2M;
                                y2m = y2m == 0 ? 1 : y2m;
                                var y2 = DataSource.StartY2 / y2m;
                                sf.Alignment = StringAlignment.Near;
                                sign = curZoomFrame.Y2Reversed ? -1 : 1;
                                var smy2 = sign == 1 ? curZoomFrame.ScaledMaxY2 : -curZoomFrame.ScaledMinY2;
                                var siy2 = sign == 1 ? curZoomFrame.ScaledMinY2 : -curZoomFrame.ScaledMaxY2;
                                while (y2 <= smy2)
                                {
                                    var py2 = hl - (int)((y2 - siy2) / y2l * hl) + topMargin;
                                    if (py2 >= topMargin && py2 <= height - bottomMargin)
                                    {
                                        PlotDataSource.Y2GridsCount++;
                                        gph.DrawString(string.Format("{0:0.0##}", y2 * y2m * sign), font, brush, new Rectangle(width - rightMargin, py2 - 10, rightMargin, 20), sf);
                                    }
                                    y2 += (DataSource.Y2Step == 0 ? xm / 4 : DataSource.Y2Step) / y2m;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

        }

        private void ZoomIn(Rectangle rectangle)
        {
            if (MaxDataCount < 15)
                return;
            try
            {
                var zoom = DataSource.Zoom(rectangle);

                SetBackGround(CreateBasePlot(zoom, Width, Height, MarginLeft, MarginRight, MarginTop, MarginBottom));
            }
            catch
            {
            }
        }

        public void SetFixedScale(ZoomFrame zoomFrame)
        {
            DataSource.Zoom(zoomFrame);
            SetBackGround(CreateBasePlot(zoomFrame, Width, Height, MarginLeft, MarginRight, MarginTop, MarginBottom));
        }

        private void Pan(int dx, int dy)
        {
            try
            {
                var zoomFrame = DataSource.Pan(dx, dy);
                SetBackGround(CreateBasePlot(zoomFrame, Width, Height, MarginLeft, MarginRight, MarginTop, MarginBottom));
            }
            catch
            {
            }
        }

        public void UndoScale()
        {
            try
            {
                var zoom = DataSource.UndoScale();
                SetBackGround(CreateBasePlot(zoom, Width, Height, MarginLeft, MarginRight, MarginTop, MarginBottom));
                Update();
            }
            catch
            {
            }
        }

        private void SetBackGround(Bitmap bitmap)
        {
            BackgroundImage = bitmap;
            BackgroundImageLayout = ImageLayout.Zoom;
        }

        public Bitmap GetPrintVersion(int width, int height, int mLeft, int mRight, int mTop, int mBottom)
        {
            var basePlot = CreateBasePlot(DataSource.GetCurZoomLevel(), width, height, mLeft, mRight, mTop, mBottom, true);
            return basePlot;
        }

        #endregion

        #region test data

        public void NewTest(Test test, double maxX, double maxY, bool enbaleStartScale = false)
        {
            //DataSource.Reset();

            //ReportPoints = new List<ReportingResult>();
            Initilize(false);
            DataSource = new PlotDataSource
            {
                CurTestSource = new TestDataSource
                {
                    TestSample = test.TestingSample,
                    TestInformation = test.TestInformation,
                    TestMethodType = Test.TestMethodType,
                    Name = "CurTest",
                    Samples = new List<DataSample>(),
                    DrawingColor = Colors.Diagram,
                    DrawingColor2 = Colors.Diagram2,

                },
            };
            DataSource.NewTest(maxX, maxY, enbaleStartScale);
            DataSource.Invalid = true;
        }

        public void AddPlotSample(DataSample sample, int decimation, double temperatureSetPoint)
        {
            dataIsEmpty = false;
            DataSource.AddTestSample(sample, decimation, temperatureSetPoint);
        }

        public void AddDataSource(TestDataSource source)
        {
            dataIsEmpty = false;
            DataSource.Invalid = true;
            double mx, my, mxx, myy;
            source.Rebind(out mx, out my, out mxx, out myy);
            DataSource.AddDataSource(source, mx, my, mxx, myy);
        }

        public void AddDataSources(List<TestDataSource> dataSources)
        {
            foreach (var source in dataSources)
            {
                double mx, my, mxx, myy;
                source.Rebind(out mx, out my, out mxx, out myy);
                DataSource.AddDataSource(source, mx, my, mxx, myy);
            }
            dataIsEmpty = false;
            DataSource.Invalid = true;
            Refresh();
        }

        public void RemoveDataSource(string testName)
        {
            DataSource.RemoveDataSource(testName);
            var reports = ReportPoints.Where(p => p?.TestName?.Equals(testName) ?? false).ToList();
            foreach (var result in reports)
            {
                ReportPoints.Remove(result);
            }
        }

        public void TerminateCurrentTest(string name, string fullPath)
        {
            DataSource.FinalizTest();
            DataSource.DataSources[0].Name = name;
            DataSource.DataSources[0].FullPath = fullPath;
            ViewCmd = ViewCmd.None;
            Invalidate();
        }

        #endregion

        #region methods

        protected override void OnSizeChanged(EventArgs e)
        {
            if (DataSource == null) return;
            try
            {
                base.OnSizeChanged(e);
                DataSource.Invalid = true;
                DataSource.Resize(Size);
                Invalidate();
                Update();
            }
            catch
            {
            }
        }

        public void UnitChanges()
        {
            try
            {
                DataSource.Invalid = true;
                DataSource.Scale();
                Update();
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        public void Fit(bool emptyStack = false)
        {
            DataSource.FitData(emptyStack);
            DataSource.Invalid = true;
            Refresh();
            ViewCmd = ViewCmd.None;
        }

        #endregion

        #region events

        public event EventHandler<PointEventArgs> OnPointClick;
        public event EventHandler<EventArgs> OnPlotResize;

        #endregion
    }

    static class Gph
    {
        public static double GetDistance(Point pointFrom, Point pointTo)
        {
            return Math.Sqrt((pointFrom.X - pointTo.X) * (pointFrom.X - pointTo.X) + (pointFrom.Y - pointTo.Y) * (pointFrom.Y - pointTo.Y));
        }

        public static Rectangle GetRectangle(Point pointFrom, Point pointTo)
        {
            var w = Math.Abs(pointFrom.X - pointTo.X);
            var h = Math.Abs(pointFrom.Y - pointTo.Y);

            var x = Math.Min(pointTo.X, pointFrom.X);
            var y = Math.Min(pointTo.Y, pointFrom.Y);
            return new Rectangle(x, y, w, h);
        }

        public static RectangleF GetRectangle(PointF pointFrom, PointF pointTo)
        {
            var w = Math.Abs(pointFrom.X - pointTo.X);
            var h = Math.Abs(pointFrom.Y - pointTo.Y);

            var x = Math.Min(pointTo.X, pointFrom.X);
            var y = Math.Min(pointTo.Y, pointFrom.Y);
            return new RectangleF(x, y, w, h);
        }
    }
}
