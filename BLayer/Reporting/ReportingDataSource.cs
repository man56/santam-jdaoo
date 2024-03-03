using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using STM.BLayer.Configurations;
using STM.Extensions;

namespace STM.BLayer.Reporting
{
    public class ReportingDataSource
    {
        public List<ReportingParameters> ReportingParameters { set;get; } 
        public Dictionary<ReportingParameters, List<ReportingResult>> ReportingResults { set; get; }
        public Dictionary<string, double> ElasticModules { set; get; }
        public Dictionary<string, double> Ut_Yield { set; get; }

        public ReportingDataSource()
        {
            ReportingResults = new Dictionary<ReportingParameters, List<ReportingResult>>();
            ReportingParameters = new List<ReportingParameters>();
            ElasticModules = new Dictionary<string, double>();
            Ut_Yield = new Dictionary<string, double>();
        }

        public void AddReportingParameters(ReportingParameters reportingParameters)
        {
            if (!ReportingResults.ContainsKey(reportingParameters))
                ReportingResults[reportingParameters] = new List<ReportingResult>();

            if (ReportingParameters.Contains(reportingParameters))
                return;
            ReportingParameters.Add(reportingParameters);
        }
        public void AddReportingResult(ReportingParameters reportingParameters, ReportingResult reportingResult)
        {
            ReportingResults[reportingParameters].Add(reportingResult);
        }

 
        public static List<ReportingParameters> LoadReport(string fileName)
        {
           
            var xml = XDocument.Load(fileName);
            try
            {
                var cols = xml.Descendants("TableColumns").Descendants("col").Select(
                    p => new ReportingParameters
                             {
                                 PointType = (PointType)Enum.Parse(typeof(PointType), p.Attribute("PointType").Value),
                                 PointProperty = (PointProperty)Enum.Parse(typeof(PointProperty), p.Attribute("PointProperty").Value),
                                 Name = p.Attribute("Name").Value.Equals("n/a") ? "" : p.Attribute("Name").Value,
                                 Label = p.Attribute("Label").Value.Equals("n/a") ? "" : p.Attribute("Label").Value,
                                 StepOrCycle = p.Attribute("StepOrCycle").Value.ToInt32(),
                                 Attribute1 = p.Attribute("Attribute1").Value.Equals("n/a") ? (double?)null : p.Attribute("Attribute1").Value.ToDouble(),
                                 Attribute2 = p.Attribute("Attribute2").Value.Equals("n/a") ? (double?)null : p.Attribute("Attribute2").Value.ToDouble(),
                                 Attribute3 = p.Attribute("Attribute3").Value.Equals("n/a") ? (double?)null : p.Attribute("Attribute3").Value.ToDouble(),
                                 Formula = p.Attribute("Formula").Value.Equals("n/a") ? "" : p.Attribute("Formula").Value,
                                 ExpectedRangeA = p.Attribute("ExpectedRangeA").Value.Equals("n/a") ? (double?)null : p.Attribute("ExpectedRangeA").Value.ToDouble(),
                                 ExpectedRangeB = p.Attribute("ExpectedRangeB").Value.Equals("n/a") ? (double?)null : p.Attribute("ExpectedRangeB").Value.ToDouble(),
                                 ResultYellowRangeA = p.Attribute("ResultYellowRangeA").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultYellowRangeA").Value.ToDouble(),
                                 ResultYellowRangeB = p.Attribute("ResultYellowRangeB").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultYellowRangeB").Value.ToDouble(),
                                 ResultRedRangeA = p.Attribute("ResultRedRangeA").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultRedRangeA").Value.ToDouble(),
                                 ResultRedRangeB = p.Attribute("ResultRedRangeB").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultRedRangeB").Value.ToDouble(),
                                 EnableAnalysing = Boolean.Parse(p.Attribute("EnableAnalysing").Value)

                             }).ToList();
                return cols;
            }
            catch
            {

            }
            return null;
        }
        public void Load(string path)
        {
            try
            {
                SettingLoader.Current.LoadReportingTableOptions();
                if (string.IsNullOrEmpty(path))
                {
                    ReportingParameters = SettingLoader.Current.LoadReportingTableColumns();
                }
                else
                {
                    ReportingParameters = LoadReport(path);
                }
            }
            catch
            {
            }
        }

        public void Remove(ReportingResult reportResult)
        {
            ReportingResults[reportResult.ReportingPrameteres].Remove(reportResult);
        }
        public void Remove(ReportingParameters Reporting_parameters)
        {
            ReportingParameters.Remove(Reporting_parameters);
            ReportingResults.Remove(Reporting_parameters);
        }
        public void Clear()
        {
            ReportingParameters.Clear();
            ReportingResults.Clear();
        }
        public void ResetResults()
        {
            ReportingResults.Clear();
            ReportingResults = ReportingParameters.ToDictionary(p => p, p => new List<ReportingResult>());
        }
    }
}
