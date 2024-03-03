using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using STM.BLayer;
using STM.BLayer.StmTest;

namespace STM.PLayer.Report
{
    public class ExeclReportParameter
    {
        public string Name { set; get; }
        public string Value { set; get; }
    }

    public class ExcelReportColumnData
    {
        public string Name { set; get; }
        public string Unit { set; get; }
        public List<double> Data { set; get; }
        public string DataFormat { set; get; }
    }

    public class ExcelReport
    {
        private Microsoft.Office.Interop.Excel.Application app = null;
        private Workbook workbook = null;
        private Worksheet worksheet = null;
        private Range workSheet_range = null;

        //public void Save(List<ExeclReportParameter> parameters, string path, ExcelReportColumnData cl1, ExcelReportColumnData cl2 = null)
        //{
        //    app = new Microsoft.Office.Interop.Excel.Application();
        //    app.Visible = true;
        //    workbook = app.Workbooks.Add(1);
        //    worksheet = workbook.Sheets[1];

        //    var ChartObjects = worksheet.ChartObjects(Type.Missing);
        //    var chartObject = ChartObjects.Add(250, 100, 500, 350);

        //    chartObject.Chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers;
        //    chartObject.Chart.HasTitle = true;

        //    int rw = 3;
        //    int cl = 1;

        //    foreach (var item in parameters)
        //    {
        //        workSheet_range = worksheet.get_Range(GetCellAddress(rw, cl), GetCellAddress(rw, cl));
        //        workSheet_range.Interior.Color = Color.LightGray.ToArgb();
        //        worksheet.Cells[rw, cl] = item.Name.ToString();
        //        worksheet.Cells[rw++, cl + 1] = item.Value;
        //    }

        //    var baseRow = rw;
        //    List<ExcelReportColumnData> datas = new List<ExcelReportColumnData> { cl1, cl2 };

        //    foreach (var data in datas)
        //    {
        //        if (data != null)
        //        {
        //            rw = baseRow;
        //            worksheet.Cells[rw, cl] = string.Format("{0}({1})", data.Name, data.Unit);
        //            rw++;
        //            foreach (var value in data.Data)
        //            {
        //                worksheet.Cells[rw++, cl] = string.Format(data.DataFormat, value);
        //            }
        //            cl++;
        //        }
        //    }

        //    var oSeriesCollection = chartObject.Chart.SeriesCollection();
        //    var oSeries = oSeriesCollection.NewSeries();

        //    oSeries.Values = worksheet.Range[GetCellAddress(baseRow + 1, 1), GetCellAddress(baseRow + cl1.Data.Count, 1)];
        //    oSeries.XValues = worksheet.Range[GetCellAddress(baseRow + 1, 0), GetCellAddress(baseRow + cl1.Data.Count, 0)];

        //    Axis axis = chartObject.Chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
        //    axis.HasTitle = true;
        //    axis.MinimumScaleIsAuto = true;
        //    axis.MaximumScaleIsAuto = true;
        //    axis.AxisTitle.Text = cl2.Name;

        //    Axis xAxis = chartObject.Chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
        //    xAxis.HasTitle = true;
        //    xAxis.AxisTitle.Text = cl1.Name;

        //    // Add title:
        //    chartObject.Chart.HasTitle = true;
        //    chartObject.Chart.ChartTitle.Text = "Peak Function";

        //    // Remove legend:
        //    chartObject.Chart.HasLegend = false;

        //}

        public void Save(TestDataSource dataSource, string path, 
            List<ExeclReportParameter> sample, 
            List<ExeclReportParameter> common,
            List<ExeclReportParameter> settings,
            string xMeasure, string xUnit, 
            string yMeasure, string yUnit, 
            double xm , double ym)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    app = new Application();
                    app.Visible = true;
                    workbook = app.Workbooks.Add(1);
                    app.DefaultFilePath = path;
                    worksheet = workbook.Sheets[1];

                    worksheet.StandardWidth = 15;

                   /* var chartObjects = worksheet.ChartObjects(Type.Missing);
                    var chartObject = chartObjects.Add(250, 80, 500, 350);

                    chartObject.Chart.ChartType = XlChartType.xlLine;
                    chartObject.Chart.HasTitle = true;
                    */
                    var rw = 1;
                    var cl = 1;

                    foreach (var item in sample)
                    {
                        workSheet_range = worksheet.Range[GetCellAddress(rw, cl), GetCellAddress(rw, cl)];
                        workSheet_range.Interior.Color = Color.LightGray.ToArgb();
                        worksheet.Cells[rw, cl] = item.Name;
                        worksheet.Cells[rw++, cl + 1] = item.Value;
                    }

                    foreach (var item in common)
                    {
                        workSheet_range = worksheet.Range[GetCellAddress(rw, cl), GetCellAddress(rw, cl)];
                        workSheet_range.Interior.Color = Color.LightGray.ToArgb();
                        worksheet.Cells[rw, cl] = item.Name;
                        worksheet.Cells[rw++, cl + 1] = item.Value;
                    }

                    foreach (var item in settings)
                    {
                        workSheet_range = worksheet.Range[GetCellAddress(rw, cl), GetCellAddress(rw, cl)];
                        workSheet_range.Interior.Color = Color.LightGray.ToArgb();
                        worksheet.Cells[rw, cl] = item.Name;
                        worksheet.Cells[rw++, cl + 1] = item.Value;
                    }

                    var baseRow = rw;

                    rw = baseRow;

                    //worksheet.Cells[rw, cl] = string.Format("{0}({1})", xMeasure, xUnit);
                    //worksheet.Cells[rw, cl+1] = string.Format("{0}({1})", yMeasure, yUnit);

                    worksheet.Cells[rw, cl] = "Step";
                    worksheet.Cells[rw, cl+1] = "Extension(mm)";
                    worksheet.Cells[rw, cl + 2] = "Force(N)";
                    worksheet.Cells[rw, cl + 3] = "Time(sec)";

                    var tp_add_hdr = dataSource.HasTemperature;

                    foreach (var data in dataSource.Samples.Where(data => data != null))
                    {
                        if (tp_add_hdr)
                        {
                            tp_add_hdr = false;
                            for (var t = 1; t <= data.NumberOfTemperatureSensors; t++)
                            {
                                worksheet.Cells[rw, cl + 3 + t] = $"Temperature [{t}]";
                            }
                        }

                        rw++;
                        worksheet.Cells[rw, cl] = string.Format("{0:F03}", data.StepOrCycle);
                        worksheet.Cells[rw, cl + 1] = string.Format("{0:F03}", data.Extension);
                        worksheet.Cells[rw, cl + 2] = string.Format("{0:F03}", data.Force);
                        worksheet.Cells[rw, cl + 3] = string.Format("{0:F03}", data.Time);
                        for (var t = 0; t < data.NumberOfTemperatureSensors; t++)
                        {
                            worksheet.Cells[rw, cl + 4 + t] = data.Temperature[t];
                        }
                    }

                    /*var oSeriesCollection = chartObject.Chart.SeriesCollection();
                    var oSeries = oSeriesCollection.NewSeries();
                    
                    oSeries.Values =
                        worksheet.Range[
                            GetCellAddress(baseRow + 1, 1), GetCellAddress(baseRow + dataSource.Samples.Count, 1)];
                    oSeries.XValues =
                        worksheet.Range[
                            GetCellAddress(baseRow + 1, 0), GetCellAddress(baseRow + dataSource.Samples.Count, 0)];


                    Axis axis = chartObject.Chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
                    axis.HasTitle = true;
                    axis.MinimumScaleIsAuto = true;
                    axis.MaximumScaleIsAuto = true;
                    //axis.AxisTitle.Text = string.Format("{0}({1})", yMeasure, yUnit);
                    axis.AxisTitle.Text = "Force(N)";

                    Axis xAxis = chartObject.Chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
                    xAxis.HasTitle = true;
                    xAxis.AxisTitle.Text = string.Format("{0}({1})", xMeasure, xUnit);
                    xAxis.AxisTitle.Text = "Extension(mm)";

                    // Add title:
                    chartObject.Chart.HasTitle = true;
                    chartObject.Chart.ChartTitle.Text = "";

                    // Remove legend:
                    chartObject.Chart.HasLegend = false;
                    */
                    workbook.Save();
                    //    workbook.SaveAs(
                    //        path,
                    //        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, 
                    //        Type.Missing,
                    //        Type.Missing, 
                    //        Type.Missing,
                    //        Type.Missing,
                    //        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, 
                    //        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //
                }
                catch(Exception exception)
                {
                    exception.ToString();
                }
            });
        }

        private string GetCellAddress(int rw, int col)
        {
            int baseA = Encoding.ASCII.GetBytes("A")[0];
            return string.Format("{0}{1}", (char)(baseA + col), rw);
        }
    }
}
