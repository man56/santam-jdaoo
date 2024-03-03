using Microsoft.Office.Interop.Excel;
using STM.BLayer.TestSample;
using STM.PLayer.Report;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static STM.BLayer.StmTest.TestInformation;

namespace STM.BLayer.StmTest
{
    public class TestInformation
    {
        public enum DateCultureFormats
        {
            Custom = 0,
            System = 1,
            Persian = 2,
        }

        public string CustomerName { set; get; }
        public string OperatorName { set; get; }
        public DateTime TestDate { get; set; }
        public string Date { set; get; }
        public DateCultureFormats DateCultureFormat;
        public static string PerisanDate
        {
            get
            {
                var calendar = new PersianCalendar();
                var year = calendar.GetYear(DateTime.Now);
                var month = calendar.GetMonth(DateTime.Now);
                var day = calendar.GetDayOfMonth(DateTime.Now);

                return string.Format("{0}.{1}.{2}", year, month, day);
            }
        }

        public static string CurrentDate => DateTime.Now.ToShortDateString();

        public string GetDate()
        {
            return GetDate(DateCultureFormat);
        }

        public static string GetDate(DateTime date, DateCultureFormats format)
        {
            switch (format)
            {
                case DateCultureFormats.Persian:
                    try
                    {
                        var calendar = new PersianCalendar();
                        var year = calendar.GetYear(date);
                        var month = calendar.GetMonth(date);
                        var day = calendar.GetDayOfMonth(date);

                        return string.Format("{0}.{1}.{2}", year, month, day);
                    }
                    catch
                    {
                        return null;
                    }
                case DateCultureFormats.System:
                    return date.ToShortDateString();

                default:
                    return null;
            }
        }

        public string GetDate(DateCultureFormats format)
        {
            return GetDate(TestDate, DateCultureFormat) ?? Date;
        }

        public string[] Description { set; get; }

        public TestInformation()
        {
            TestDate = DateTime.Now;
            DateCultureFormat = DateCultureFormats.System;
        }

        public TestInformation(string savedString):this()
        {
            var strings = savedString.Replace(Environment.NewLine, "\n").Split('\n');
            var desc = new List<string>();
            foreach (string s in strings)
            {
                var code = s.Split(':')[0];
                switch (code)
                {
                    case "CustomerName": CustomerName = s.Remove(0, "CustomerName: ".Length);
                        break;

                    case "Date": Date = s.Remove(0, "Date: ".Length);
                        break;

                    case "Description": desc.Add(s.Remove(0, "Description: ".Length));
                        break;

                    case "OperatorName": OperatorName = s.Remove(0, "OperatorName: ".Length);
                        break;

                    case "TestDate":
                        TestDate = DateTime.Parse(s.Remove(0, "TestDate: ".Length));
                        break;

                    case "DateCultureFormat":
                        DateCultureFormat = (DateCultureFormats) Enum.Parse(typeof(DateCultureFormats), s.Remove(0, "DateCultureFormat: ".Length));
                        break;
                }
            }

            Description = desc.ToArray();
        }

        public string GetSaveString()
        {
            var saveString = "";
            saveString += string.Format("CustomerName: {0}", CustomerName) + Environment.NewLine;
            saveString += string.Format("Date: {0}", Date) + Environment.NewLine;
            saveString += string.Format("DateCultureFormat: {0}", DateCultureFormat) + Environment.NewLine;
            saveString += string.Format("TestDate: {0}", TestDate) + Environment.NewLine;
            saveString = Description.Aggregate(saveString,
                                            (current, s) =>
                                            current + string.Format("Description: {0}", s) + Environment.NewLine);
            saveString += string.Format("OperatorName: {0}", OperatorName) + Environment.NewLine;

            return saveString;
        }


        public bool Equals(TestInformation other)
        {
            return this.GetSaveString() == other.GetSaveString();
        }


        public List<ExeclReportParameter> ToReport()
        {
            var retVal = new List<ExeclReportParameter>{
                new ExeclReportParameter {Name = "CustomerName", Value = CustomerName},
                new ExeclReportParameter {Name = "OperatorName", Value = OperatorName},
                new ExeclReportParameter {Name = "TestDate", Value = GetDate()},
                new ExeclReportParameter {Name = "Description", Value = string.Join(Environment.NewLine, Description)},
            };

            retVal.Add(new ExeclReportParameter { Name = string.Empty, Value = string.Empty });

            return retVal;
        }

    }
}