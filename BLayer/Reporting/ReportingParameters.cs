using System;
using System.Collections.Generic;
using System.Linq;
using STM.PLayer.UI;
using STM.Properties;

namespace STM.BLayer.Reporting
{
    public class ReportingParameters
    {
        #region abbrevitions

        public static double ElasticModuleMaxPercent { set; get; }
        public static double ElasticModuleMinPercent { set; get; }
        public static bool ShowElasticModule { set; get; }
        public static bool UseRegression { set; get; }
        public static bool ShowMeanRMS { set; get; }
        public static bool ShowUtYield { set; get; }
        public static bool ShowAcceptableRange { set; get; }

        public static readonly Dictionary<PointType, string> ReportPointAbbrev = new Dictionary<PointType, string>
                                                                                     {
                                                                                         {PointType.Peak, Resources.FrmTestSetting_Peak },
                                                                                         {PointType.Break,Resources.FrmTestSetting_Break},
                                                                                         {PointType.Yield, Resources.FrmTestSetting_Yield},
                                                                                         {PointType.YieldOffset,Resources.FrmTestSetting_Yield_Offset},
                                                                                         {PointType.UpperYield, Resources.FrmTestSetting_Upper_Yield},
                                                                                         {PointType.LowerYield, Resources.FrmTestSetting_Lower_Yield},
                                                                                         {PointType.MeanYield, Resources.FrmTestSetting_Mean_Yield},
                                                                                         {PointType.Extension, "@" + Resources.FrmTestSetting_Extension },
                                                                                         {PointType.Strain,  "@" + Resources.MeasureTool_MeasurAbbreviations_Strain},
                                                                                         {PointType.TrueStrain, "@" + Resources.MeasureTool_MeasurAbbreviations_True_Strain},
                                                                                         {PointType.Force, "@" + Resources.MeasureTool_MeasurAbbreviations_Force},
                                                                                         {PointType.Stress,  "@" + Resources.MeasureTool_MeasurAbbreviations_Stress},
                                                                                         {PointType.TrueStress,  "@" + Resources.MeasureTool_MeasurAbbreviations_True_Stress},
                                                                                         {PointType.MassStress,  "@" + Resources.MeasureTool_MeasurAbbreviations_Mass_Stress},
                                                                                         {PointType.LengthStress, "@" + Resources.MeasureTool_MeasurAbbreviations_Length_Stress},
                                                                                         {PointType.ExtenLimit, "@" + Resources.FrmTestSetting_Exten_Limit},
                                                                                         {PointType.StrainLimit, "@" + Resources.FrmTestSetting_Strain_Limit},
                                                                                         {PointType.TimeLimit,  "@" + Resources.FrmTestSetting_Time_Limit},
                                                                                         {PointType.Time,  "@" + Resources.MeasureTool_Labels_Time},
                                                                                         {PointType.Click, Resources.User_Click},
        };

        public static readonly Dictionary<PointProperty, string> ReportPropertyAbbrev = new Dictionary<PointProperty, string>
                                                                                            {
                                                                                                {PointProperty.Force, Resources.MeasureTool_MeasurAbbreviations_Force},
                                                                                                {PointProperty.Stress,Resources.MeasureTool_MeasurAbbreviations_Stress},
                                                                                                {PointProperty.MassStress,  Resources.MeasureTool_MeasurAbbreviations_Mass_Stress},
                                                                                                {PointProperty.LengthStress,Resources.MeasureTool_MeasurAbbreviations_Length_Stress},
                                                                                                {PointProperty.TrueStress, Resources.MeasureTool_MeasurAbbreviations_True_Stress},
                                                                                                {PointProperty.Extension, Resources.FrmTestSetting_Extension},
                                                                                                {PointProperty.Strain,  Resources.MeasureTool_MeasurAbbreviations_Strain},
                                                                                                {PointProperty.TrueStrain,  Resources.MeasureTool_MeasurAbbreviations_True_Strain},
                                                                                                {PointProperty.ElongationAfterBreak,Resources.Elongation_After_Break },
                                                                                                {PointProperty.SecantModule,Resources.ReportingParameters_ReportPropertyAbbrev_Secant_Module},
                                                                                                {PointProperty.TangentModule, Resources.ReportingParameters_ReportPropertyAbbrev_Tangent_Module},
                                                                                                {PointProperty.Energy, Resources.ReportingParameters_ReportPropertyAbbrev_Energy},
                                                                                                {PointProperty.Time,Resources.MeasureTool_Labels_Time},
                                                                                                {PointProperty.ForceRate, Resources.ReportingParameters_ReportPropertyAbbrev_Force_Rate},
                                                                                                {PointProperty.ExtenRate, Resources.ReportingParameters_ReportPropertyAbbrev_Extension_Rate},
                                                                                                {PointProperty.StressRate, Resources.ReportingParameters_ReportPropertyAbbrev_Stress_Rate},
                                                                                                {PointProperty.StrainRate, Resources.ReportingParameters_ReportPropertyAbbrev_Strain_Rate},
                                                                                                {PointProperty.Relaxation, Resources.ReportingParameters_ReportPropertyAbbrev_Relaxation},
                                                                                                {PointProperty.ForceLoss, Resources.ReportingParameters_ReportPropertyAbbrev_Force_Loss},
                                                                                                {PointProperty.StressLoss, Resources.ReportingParameters_ReportPropertyAbbrev_Stress_Loss},
                                                                                                {PointProperty.BendingStress, Resources.ReportingParameters_ReportPropertyAbbrev_Bending_Stress},
                                                                                                {PointProperty.BendingStrain, Resources.ReportingParameters_ReportPropertyAbbrev_Bending_Strain},
                                                                                                {PointProperty.BendingModule, Resources.ReportingParameters_ReportPropertyAbbrev_Bending_Module},
                                                                                                {PointProperty.AA0, Resources.ReportingParameters_ReportPropertyAbbrev_A_A0},
                                                                                                {PointProperty.ForcePerLength,Resources.ReportingParameters_ReportPropertyAbbrev_Force_Per_Length},
                                                                                                {PointProperty.Formula, Resources.ReportingParameters_ReportPropertyAbbrev_Formula},
                                                                                                {PointProperty.Temperature,Resources.MeasureTool_Labels_Temperature},
                                                                                                {PointProperty.SpecTempUP, Resources.MeasureTool_Labels_Spec__Temp_UP},
                                                                                                {PointProperty.SpecTempCNT, Resources.MeasureTool_Labels_Spec__Temp_CNT},
                                                                                                {PointProperty.SpecTempDN, Resources.MeasureTool_Labels_Spec__Temp_DN},
                                                                                                {PointProperty.AmbientTemp, Resources.MeasureTool_Labels_Ambient_Temp},
                                                                                                {PointProperty.ZoneTempUP, Resources.MeasureTool_Labels_Zone_Temp_UP},
                                                                                                {PointProperty.ZoneTempCNT,Resources.MeasureTool_Labels_Zone_Temp_CNT},
                                                                                                {PointProperty.ZoneTempDN, Resources.MeasureTool_Labels_Zone_Temp_DN},
                                                                                            };

        public static readonly Dictionary<PointProperty, MeasureType> PointPropertyToMeasureType = new Dictionary<PointProperty, MeasureType>
        {
        {PointProperty.Force, MeasureType.Force},
        {PointProperty.Stress, MeasureType.Stress},
        {PointProperty.MassStress, MeasureType.MassStress},
        {PointProperty.LengthStress, MeasureType.LengthStress },
        {PointProperty.TrueStress, MeasureType.TrueStress},
        {PointProperty.Extension, MeasureType.Extension},
        {PointProperty.Strain, MeasureType.Strain},
        {PointProperty.TrueStrain, MeasureType.TrueStrain},
        {PointProperty.ElongationAfterBreak, MeasureType.Strain}, 
        {PointProperty.SecantModule, (MeasureType)(-1)},
        {PointProperty.TangentModule, (MeasureType)(-1)},
        {PointProperty.Energy, (MeasureType)(-1)},
        {PointProperty.Time, MeasureType.Time},
        {PointProperty.BendingStress, MeasureType.Stress},
        {PointProperty.BendingStrain, MeasureType.Strain},
        {PointProperty.BendingModule, (MeasureType)(-1)},
        {PointProperty.AA0, (MeasureType)(-1)}, 
        {PointProperty.ForcePerLength,(MeasureType)(-1)},
        {PointProperty.Formula, (MeasureType)(-1)},
        {PointProperty.ForceRate, (MeasureType)(-1)},
        {PointProperty.ExtenRate, (MeasureType)(-1)},
        {PointProperty.StressRate, (MeasureType)(-1)},
        {PointProperty.StrainRate, (MeasureType)(-1)},
        {PointProperty.Relaxation, MeasureType.RelaxLoss},
        {PointProperty.ForceLoss, MeasureType.ForceLoss},
        {PointProperty.StressLoss, MeasureType.StressLoss},
		{PointProperty.Temperature, MeasureType.Temperature},
		{PointProperty.SpecTempUP, MeasureType.SpecTempUP},
		{PointProperty.SpecTempCNT, MeasureType.SpecTempCNT},
		{PointProperty.SpecTempDN, MeasureType.SpecTempDN},
		{PointProperty.AmbientTemp, MeasureType.AmbientTemp},
		{PointProperty.ZoneTempUP, MeasureType.ZoneTempUP},
		{PointProperty.ZoneTempCNT, MeasureType.ZoneTempCNT},
		{PointProperty.ZoneTempDN, MeasureType.ZoneTempDN},
		};

        public static readonly Dictionary<PointType, MeasureType> PointsToMeasureType = new Dictionary<PointType, MeasureType>
                                                                                            {
                                                                                                {PointType.Break,(MeasureType)(-1)},
                                                                                                {PointType.Click, (MeasureType)(-1)},
                                                                                                {PointType.ExtenLimit, MeasureType.Extension}, 
                                                                                                {PointType.Extension, MeasureType.Extension},
                                                                                                {PointType.Force, MeasureType.Force},
                                                                                                {PointType.LowerYield, (MeasureType)(-1)}, 
                                                                                                {PointType.YieldOffset, (MeasureType)(-1)}, 
                                                                                                {PointType.MeanYield, (MeasureType)(-1)}, 
                                                                                                {PointType.Peak, (MeasureType)(-1)},
                                                                                                {PointType.Strain, MeasureType.Strain}, 
                                                                                                {PointType.StrainLimit, MeasureType.Strain}, 
                                                                                                {PointType.Stress, MeasureType.Stress}, 
                                                                                                {PointType.MassStress, MeasureType.MassStress},
                                                                                                {PointType.LengthStress, MeasureType.LengthStress},
                                                                                                {PointType.Time, MeasureType.Time}, 
                                                                                                {PointType.TimeLimit, MeasureType.Time}, 
                                                                                                {PointType.TrueStrain, MeasureType.Strain},
                                                                                                {PointType.TrueStress, MeasureType.Stress}, 
                                                                                            };


        public static PointType AbbrevToPoints(string abbreve)
        {
            if (ReportPointAbbrev.Values.Contains(abbreve))
                return ReportPointAbbrev.First(p => p.Value.Equals(abbreve)).Key;
            return (PointType)(-1);
        }

        public static PointProperty AbbrevToPointProperty(string abbreve)
        {
            if (ReportPropertyAbbrev.Values.Contains(abbreve))
                return ReportPropertyAbbrev.First(p => p.Value.Equals(abbreve)).Key;
            return (PointProperty)(-1);
        }

        #endregion

        public PointType PointType { set; get; }
        public PointProperty PointProperty { set; get; }
        public string Name { set; get; }
        public string Label { set; get; }
     
        public int StepOrCycle { set; get; }

        public double? Attribute1 { set; get; }
        public double? Attribute2 { set; get; }
        public double? Attribute3 { set; get; }

        public bool EnableAnalysing { set; get; }
        public double? ExpectedRangeA { set; get; }
        public double? ResultYellowRangeA { set; get; }
        public double? ResultRedRangeA { set; get; }
        public double? ExpectedRangeB { set; get; }
        public double? ResultYellowRangeB { set; get; }
        public double? ResultRedRangeB { set; get; }
        public string Formula { set; get; }

        public List<string> OwnerTests { set; get; } 

        public string PointUnit
        {
            get
            {
                var pType = PointsToMeasureType[PointType];
                return MeasureTool.GetUnit(pType).Abbreviation;
            }
        }

        public string PropertyUint
        {
            get
            {
                var pType = PointPropertyToMeasureType[PointProperty];
                var unit = "";
                if ((int)pType != -1)
                {
                    unit = MeasureTool.GetUnit(pType).Abbreviation;
                }
                else
                {
                    double m;
                    unit = UnitManager.GetSpecialUnits(PointProperty, out m);
                }
                return unit;

            }
        }

        #region overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ReportingParameters)) return false;
            return Equals((ReportingParameters) obj);
        }
        #endregion

        public ReportingParameters()
        {
            OwnerTests = new List<string>(); 
        }

        public ReportingParameters(string savedString)
        {
            var data = savedString.Remove(0, "PointParameters: ".Length);
            var parameters = data.Split((char)3).Select(p => p.Trim()).ToList();
            PointType = (PointType)Enum.Parse(typeof(PointType), parameters[0]);
            PointProperty = (PointProperty)Enum.Parse(typeof(PointProperty), parameters[1]);
            Name = parameters[2];
            Label = parameters[3];
            StepOrCycle = int.Parse(parameters[4]);
            Attribute1 = parameters[5].Equals("n/a") ? (double?)null : double.Parse(parameters[5]);
            Attribute2 = parameters[6].Equals("n/a") ? (double?)null : double.Parse(parameters[6]);
            Attribute3 = parameters[7].Equals("n/a") ? (double?)null : double.Parse(parameters[7]);
            Formula = parameters[8].Equals("n/a") ? "" : Formula;
            ExpectedRangeA = parameters[9].Equals("n/a") ? (double?)null : double.Parse(parameters[9]);
            ExpectedRangeB = parameters[10].Equals("n/a") ? (double?)null : double.Parse(parameters[10]);
            ResultYellowRangeA = parameters[11].Equals("n/a") ? (double?)null : double.Parse(parameters[11]);
            ResultYellowRangeB = parameters[12].Equals("n/a") ? (double?)null : double.Parse(parameters[12]);
            ResultRedRangeA = parameters[13].Equals("n/a") ? (double?)null : double.Parse(parameters[13]);
            ResultRedRangeB = parameters[14].Equals("n/a") ? (double?)null : double.Parse(parameters[14]);
            EnableAnalysing = bool.Parse(parameters[15]);
            OwnerTests = new List<string>();
        }

        #region Save string

        public string GetSaveString()
        {
            var saveString = "";
            var spacer = ((char) 3).ToString();
            saveString += string.Format("PointParameters:  {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15}",
                                        PointType + spacer,
                                        PointProperty + spacer,
                                        (Name ?? "n/a") + spacer,
                                        (Label?? "n/a") + spacer,
                                        StepOrCycle + spacer,
                                        (Attribute1.HasValue ? Attribute1.Value.ToString() : "n/a") + spacer,
                                        (Attribute2.HasValue ? Attribute2.Value.ToString() : "n/a") + spacer,
                                        (Attribute3.HasValue ? Attribute3.Value.ToString() : "n/a") + spacer,
                                        (Formula.Length>0? Formula : "n/a") + spacer,
                                        (ExpectedRangeA.HasValue ? ExpectedRangeA.Value.ToString() : "n/a") + spacer,
                                        (ExpectedRangeB.HasValue ? ExpectedRangeB.Value.ToString() : "n/a") + spacer,
                                        (ResultYellowRangeA.HasValue ? ResultYellowRangeA.Value.ToString() : "n/a") + spacer,
                                        (ResultYellowRangeB.HasValue ? ResultYellowRangeB.Value.ToString() : "n/a") + spacer,
                                        (ResultRedRangeA.HasValue ? ResultRedRangeA.Value.ToString() : "n/a") + spacer,
                                        (ResultRedRangeA.HasValue ? ResultRedRangeA.Value.ToString() : "n/a")+ spacer,
                                        EnableAnalysing);


            return saveString;
        }
        
        #endregion

        public bool Equals(ReportingParameters other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.PointType, PointType) && Equals(other.PointProperty, PointProperty) && other.StepOrCycle == StepOrCycle && other.Attribute1.Equals(Attribute1) && other.Attribute2.Equals(Attribute2) && other.Attribute3.Equals(Attribute3) && Equals(other.Formula, Formula);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = PointType.GetHashCode();
                result = (result*397) ^ PointProperty.GetHashCode();
                result = (result*397) ^ StepOrCycle;
                result = (result*397) ^ (Attribute1.HasValue ? Attribute1.Value.GetHashCode() : 0);
                result = (result*397) ^ (Attribute2.HasValue ? Attribute2.Value.GetHashCode() : 0);
                result = (result*397) ^ (Attribute3.HasValue ? Attribute3.Value.GetHashCode() : 0);
                result = (result*397) ^ (Formula != null ? Formula.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(ReportingParameters left, ReportingParameters right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReportingParameters left, ReportingParameters right)
        {
            return !Equals(left, right);
        }
    }

    public enum Formula
    {
        Force,
        Extension,
        Stress,
        Strain,
        TrueStress,
        TrueStrain,
    }
}