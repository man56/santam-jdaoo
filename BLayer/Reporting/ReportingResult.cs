using System.Collections.Generic;
using System.Linq;
using STM.BLayer.StmTest;
using STM.BLayer.TestSample;

namespace STM.BLayer.Reporting
{
    public class ReportingResult
    {
        public ReportingParameters ReportingPrameteres { set; get; }
        public List<DataSample> BasePoints { set; get; }
        public TestingSample TestingSample { set; get; }// to compute strin exten stress...
        public string TestName { set; get; }
        public double Value { set; get; }
        public bool IsRangeLimit { set; get; }

        public DataSample Attribute1 { get; set; }

        public ReportingResult(){}
        public ReportingResult(string savedString)
        {
            var data = savedString.Remove(0, "PointValue: ".Length);
            var parameters = data.Split((char) 3).Select(p => p.Trim()).ToList();
            Value = double.Parse(parameters[1]);
        }

        public string AnalysisResult()
        {
            var val = Value;
            if (!ReportingPrameteres.EnableAnalysing)
                return "";

            if (ReportingPrameteres.ExpectedRangeA.HasValue && ReportingPrameteres.ExpectedRangeB.HasValue)
                if (ReportingPrameteres.ExpectedRangeA.Value <= val && val <= ReportingPrameteres.ExpectedRangeB.Value)
                    return "";
            if (ReportingPrameteres.ResultYellowRangeA.HasValue && ReportingPrameteres.ResultYellowRangeB.HasValue)
                if (ReportingPrameteres.ResultYellowRangeA.Value <= val && val <= ReportingPrameteres.ResultYellowRangeB.Value)
                    return "(!)";
            if (ReportingPrameteres.ResultRedRangeA.HasValue && ReportingPrameteres.ResultRedRangeB.HasValue)
                if (ReportingPrameteres.ResultRedRangeA.Value <= val && val <= ReportingPrameteres.ResultRedRangeB.Value)
                    return "(×)";

            return "";
        }

        public static bool IsApplicablePoint(PointType points, PointProperty ponitProperty)
        {
            switch (points)
            {
                case PointType.StrainLimit:
                case PointType.ExtenLimit:
                case PointType.TimeLimit:
                    switch (ponitProperty)
                    {
                        case PointProperty.AA0:
                        case PointProperty.TangentModule:
                        case PointProperty.ForcePerLength:
                        case PointProperty.BendingModule:
                        case PointProperty.SecantModule:
                        case PointProperty.BendingStrain:
                        case PointProperty.BendingStress:
                        case PointProperty.TrueStrain:
                        case PointProperty.TrueStress:
                            return false;
                    }
                    break;

                default:
                    return true;
            }
            return false;
        }

        public string GetSaveString()
        {
            var saveString = ReportingPrameteres.ToString();
            return saveString;
        }
    }


}
