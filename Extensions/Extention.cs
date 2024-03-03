using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.Reporting;

namespace STM.Extensions
{
    public static class Extention
    {
        public static double AbsMin(double a, double b)
        {
            return Math.Abs(a) <= Math.Abs(b) ? a : b;
        }

        public static int ToInt32(this string str)
        {
            try
            {
                return (int)double.Parse(str);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return 0;
        }


        public static double ToDouble(this string str)
        {
            try
            {
                return double.Parse(str);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return 0.0;
        }

        public static bool ToBool(this string str)
        {
            try
            {
                return bool.Parse(str);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return false;
        }

        public static void SetCols(this DataGridView dataGridView, int id, ReportingParameters rParam, bool editMode)
        {
            using (var gph = dataGridView.CreateGraphics())
            {
                // point type
                var maxLen = 0f;
                var tmpStr = !string.IsNullOrEmpty(rParam.Name) ? rParam.Name : rParam.PointType.ToString();
                var headerText = tmpStr;
                var size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                maxLen = Math.Max(size.Width, maxLen);
                headerText += Environment.NewLine;

                var propUnit = rParam.PropertyUint;
                //if (rParam.PointProperty == PointProperty.ForcePerLength || rParam.PointProperty == PointProperty.Energy)
                //{
                //    propUnit = UnitManager.GetSpecialUnits(rParam.PointProperty);
                //}

                // point param
                if (rParam.Attribute1.HasValue && !rParam.Attribute2.HasValue)
                {
                    if (rParam.PointType == PointType.YieldOffset)
                        tmpStr = string.Format("@{0} ({1})", rParam.Attribute1.ToString(), "%");
                    else
                        tmpStr = string.Format("@{0:f02} ({1})", UnitManager.ConvertToCurrent(rParam.Attribute1.ToString(), rParam.PointUnit), rParam.PointUnit);
                    size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                    headerText += tmpStr;
                    maxLen = Math.Max(size.Width, maxLen);
                    headerText += Environment.NewLine;
                }
                else if (rParam.Attribute1.HasValue && rParam.Attribute2.HasValue)
                {
                    tmpStr = string.Format("({0:f02}-{1:f02}) ({2})", UnitManager.ConvertToCurrent(rParam.Attribute1.ToString(), rParam.PointUnit),
                                                                      UnitManager.ConvertToCurrent(rParam.Attribute2.ToString(), rParam.PointUnit), rParam.PointUnit);
                    size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                    headerText += tmpStr;
                    maxLen = Math.Max(size.Width, maxLen);
                    headerText += Environment.NewLine;
                }
                tmpStr = string.IsNullOrEmpty(propUnit) ?
                    string.Format("{0}", (!string.IsNullOrEmpty(rParam.Label) ? rParam.Label : rParam.PointProperty.ToString())) :
                    string.Format("{0} ({1})", (!string.IsNullOrEmpty(rParam.Label) ? rParam.Label : rParam.PointProperty.ToString()), rParam.PropertyUint);
                size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                headerText += tmpStr;
                maxLen = Math.Max(size.Width, maxLen);

                try
                {
                    if (!editMode)
                        dataGridView.Columns.Add(string.Format("col{0}", id), headerText);
                    else
                        dataGridView.Columns[string.Format("col{0}", id)].HeaderText = headerText;
                }
                catch (NullReferenceException nullReferenceException)
                {
                    nullReferenceException.ToString();
                    dataGridView.Columns.Add(string.Format("col{0}", id), headerText);
                }
                dataGridView.Columns[string.Format("col{0}", id)].Width = (int)maxLen + 30;
            }
        }

        public static void SetCols(this DataGridView dataGridView, DataGridViewColumn Column, ReportingParameters rParam, bool editMode)
        {
            using (var gph = dataGridView.CreateGraphics())
            {
                // point type
                var maxLen = 0f;
                var tmpStr = !string.IsNullOrEmpty(rParam.Name) ? rParam.Name : rParam.PointType.ToString();
                var headerText = tmpStr;
                var size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                maxLen = Math.Max(size.Width, maxLen);
                headerText += Environment.NewLine;

                var propUnit = rParam.PropertyUint;
                //if (rParam.PointProperty == PointProperty.ForcePerLength || rParam.PointProperty == PointProperty.Energy)
                //{
                //    propUnit = UnitManager.GetSpecialUnits(rParam.PointProperty);
                //}

                // point param
                if (rParam.Attribute1.HasValue && !rParam.Attribute2.HasValue)
                {
                    if (rParam.PointType == PointType.YieldOffset)
                        tmpStr = string.Format("@{0} ({1})", rParam.Attribute1.ToString(), "%");
                    else
                        tmpStr = string.Format("@{0:f02} ({1})", UnitManager.ConvertToCurrent(rParam.Attribute1.ToString(), rParam.PointUnit), rParam.PointUnit);
                    size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                    headerText += tmpStr;
                    maxLen = Math.Max(size.Width, maxLen);
                    headerText += Environment.NewLine;
                }
                else if (rParam.Attribute1.HasValue && rParam.Attribute2.HasValue)
                {
                    tmpStr = string.Format("({0:f02}-{1:f02}) ({2})", UnitManager.ConvertToCurrent(rParam.Attribute1.ToString(), rParam.PointUnit),
                                                                      UnitManager.ConvertToCurrent(rParam.Attribute2.ToString(), rParam.PointUnit), rParam.PointUnit);
                    size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                    headerText += tmpStr;
                    maxLen = Math.Max(size.Width, maxLen);
                    headerText += Environment.NewLine;
                }
                tmpStr = string.IsNullOrEmpty(propUnit) ?
                    string.Format("{0}", (!string.IsNullOrEmpty(rParam.Label) ? rParam.Label : rParam.PointProperty.ToString())) :
                    string.Format("{0} ({1})", (!string.IsNullOrEmpty(rParam.Label) ? rParam.Label : rParam.PointProperty.ToString()), propUnit);
                size = gph.MeasureString(tmpStr, dataGridView.ColumnHeadersDefaultCellStyle.Font);
                headerText += tmpStr;
                maxLen = Math.Max(size.Width, maxLen);

                try
                {
                    if (!editMode)
                    {
                        Column.HeaderText = headerText;
                        dataGridView.Columns.Add(Column);
                    }
                    else
                        Column.HeaderText = headerText;
                }
                catch (NullReferenceException)
                {
                    Column.HeaderText = headerText;
                    dataGridView.Columns.Add(Column);
                }
                Column.Width = (int)maxLen + 30;
            }
        }

        public static void SetCols(this DataGridView dataGridView, int id, string text)
        {
            using (var gph = dataGridView.CreateGraphics())
            {
                var maxLen = gph.MeasureString(text, dataGridView.ColumnHeadersDefaultCellStyle.Font).Width;
                try
                {
                    dataGridView.Columns[string.Format("col{0}", id)].HeaderText = text;
                }
                catch (NullReferenceException)
                {
                    dataGridView.Columns.Add(string.Format("col{0}", id), text);
                }
                dataGridView.Columns[string.Format("col{0}", id)].Width = (int)maxLen + 30;
                if (id < 0)
                    dataGridView.Columns[string.Format("col{0}", id)].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public static List<Bitmap> GetPrintVersion(this DataGridView dataGridView, int width, int height, int firstPageHeight, List<int> selectedColIndecis, string segmentName)
        {
            if (dataGridView.Rows.Count < 0 && dataGridView.Columns.Count < 0)
            {
                return new List<Bitmap> { new Bitmap(1, 1) };
            }
            var retVal = new List<Bitmap>();
            var firstCol = selectedColIndecis != null ? selectedColIndecis[0] : 0;
            var firstColWidth = dataGridView.Columns[firstCol].Width;
            var cols = selectedColIndecis ?? (from DataGridViewColumn column in dataGridView.Columns select column.DisplayIndex).ToList();
            var isFirstPage = true;
            var curPageCols = new List<int>();
            var w = firstColWidth;

            for (var index = 0; index < cols.Count; index++)
            {
                var col = cols[index];
                if (dataGridView.Columns[col].Width + w < width)
                {
                    curPageCols.Add(col);
                    w += dataGridView.Columns[col].Width;
                }
                else
                {
                    retVal.AddRange(CreateColsPrintVersion(dataGridView, curPageCols, width, isFirstPage ? firstPageHeight : height, segmentName));
                    segmentName = "";
                    isFirstPage = false;
                    curPageCols = new List<int> {firstCol};
                    w = firstColWidth;
                    index--;
                }
            }
            if(curPageCols.Count>1)
            {
                retVal.AddRange(CreateColsPrintVersion(dataGridView, curPageCols, width, isFirstPage ? firstPageHeight : height, segmentName));
            }
            return retVal;
        }

        private static IEnumerable<Bitmap> CreateColsPrintVersion(DataGridView dataGridView, IEnumerable<int> cols, int width, int height, string segmentName)
        {
            var retVal = new List<Bitmap>();
            Bitmap bmp = null;
            Graphics gph = null;
            var gridsPrinted = false;
            var x = 0;
            var y = 0;
            var size= new Size(0,0);
            var xGrids = new List<int>{0};
            var yGrids = new List<int>{0};
            var yOffset = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                x = 0;
                if (y + row.Height > height - 1)
                {
                    PrintGrids(gph, xGrids, yGrids, x, y, 0);
                    gridsPrinted = true;
                    xGrids = new List<int> { 0 };
                    yGrids = new List<int> { 0 };
                    segmentName = "";
 
                    gph.DrawImage(bmp, 1, 15 + yOffset);
                    bmp = new Bitmap(width + 2, y + 12);
                    gph = CreateGraphics(bmp);

                    retVal.Add(bmp);
                    y = 0;
                    x = 0;
                }
                if (y == 0)
                { 
                    yOffset =  string.IsNullOrEmpty(segmentName) ? 0 : 40;
                    yGrids = new List<int> { yOffset };
                    gridsPrinted = false;
                    bmp = new Bitmap(width, height);
                    gph = CreateGraphics(bmp);
                    gph.DrawString(segmentName, new Font("Calibry", 12, FontStyle.Bold), Brushes.Black, new Rectangle(1, 1, 250, yOffset),
                                       new StringFormat { LineAlignment = StringAlignment.Center });
                    segmentName = "";
                    y += yOffset;
                   
                    foreach (var col in cols)
                    {
                        size = dataGridView.Columns[col].HeaderCell.Size;
                        gph.DrawString(dataGridView.Columns[col].HeaderText, dataGridView.ColumnHeadersDefaultCellStyle.Font, Brushes.Black,
                                       new Rectangle(x, y, size.Width, size.Height),
                                       new StringFormat {Alignment = StringAlignment.Center});
                        x += size.Width;
                        xGrids.Add(x);
                    }
                    y += size.Height;
                    yGrids.Add(y);
                    x = 0;
                }

                foreach (var col in cols)
                {
                    size = row.Cells[col].Size;
                    var value = row.Cells[col].Value ?? "";
                    using (Brush brush = new SolidBrush(row.DefaultCellStyle.BackColor))
                    {
                        gph.FillRectangle(brush, new Rectangle(x, y, size.Width, size.Height));
                    }
                    gph.DrawString(value.ToString(),
                                   dataGridView.DefaultCellStyle.Font, Brushes.Black, new Rectangle(x, y, size.Width, size.Height),
                                   new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    x += size.Width;
                }
                y += size.Height;
                yGrids.Add(y);
            }
            if (!gridsPrinted && dataGridView.Rows.Count > 0)
            {
                PrintGrids(gph, xGrids, yGrids, x, y, yOffset);
                var bitmap = new Bitmap(width + 2, y + 12);
                var bitmapGph = Graphics.FromImage(bitmap);
                bitmapGph.DrawImage(bmp, 1, 1);
                retVal.Add(bitmap);
            }
            return retVal;
        }

        private static void PrintGrids(Graphics gph, IEnumerable<int> xGrids, IEnumerable<int> yGrids, int w, int h, int yOffset)
        {
            foreach (int xGrid in xGrids)
            {
                gph.DrawLine(Pens.Black, xGrid, yOffset, xGrid, h);
            }
            foreach (int yGrid in yGrids)
            {
                gph.DrawLine(Pens.Black, 0, yGrid, w, yGrid);
            }
        }

        private static Graphics CreateGraphics(Bitmap bmp)
        {
            var gph = Graphics.FromImage(bmp);
            gph.SmoothingMode = SmoothingMode.HighQuality;
            gph.TextContrast = 12;
            gph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        
            return gph;
        }
    }
}
