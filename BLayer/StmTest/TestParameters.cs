using System.Collections.Generic;

namespace STM.BLayer.StmTest
{
    public class TestParameters
    {
        protected double Rate { set; get; }
        public double ExtenCurrentPosition { set; get; }

        public TestControlMode CustomeStopType;
        public double CustomeStopValue;
    }

    public class TensileTestParameters : TestParameters
    {
        public new double Rate
        {
            set { base.Rate = value; }
            get { return base.Rate; }
        }
        public double SecondRate { set; get; }

        public bool PreLoadEnabled { set; get; }
        public TestControlMode PreLoadSetPointType { set; get; }
        public double PreLoadSetPoint { set; get; }
        public int PreLoadWaiting { set; get; }
        public ZeroCode ZeroingCode { set; get; }

        public bool SecondSpeedEnabled { set; get; }
        public TestControlMode SecondSpeedSetPointType { set; get; }
        public double SecondSpeedSetPoint { set; get; }
        public double BreakForceOver { set; get; }

        public StrainToExtenMode StrainToExtenMode { set; get; }
        public double StrainToExtenSetPoint { set; get; }
    }

    public class CompressiveTestParameters : TestParameters
    {
        public double Speed
        {
            set { Rate = value; }
            get { return Rate; }
        }
    }

    public class RelaxationTestParameters : TestParameters
    {
        public double Speed
        {
            set { Rate = value; }
            get { return Rate; }
        }

        public TestControlMode PreSetPointRateType { set; get; }
        public double PreSetPointRate { set; get; }
        public RelaxationSetPoint SetPointType { set; get; }
        public double SetPointValue { set; get; }

        public double StabilizingTime { set; get; }
        public double TestDuration { set; get; }
        public bool PlotAllStages { set; get; }
        public int Decimation { set; get; }
    }

    public class CreepTestParameters : TestParameters
    {
        public double Speed
        {
            set { Rate = value; }
            get { return Rate; }
        }

        public TestControlMode PreSetPointRateType { set; get; }
        public double PreSetPointRate { set; get; }
        public CreepSetPoint SetPointType { set; get; }
        public double SetPointValue { set; get; }
        // Nazarpour
        public CreepSetPoint PreLoadType { set; get; }
        public double PreLoadValue { set; get; }
        public double PreLoadTime { set; get; }
        public float TemperatureSetPoint { set; get; }
        public float TemperatureSetPointOffset { set; get; }
        public double PreHeatTime { set; get; }



        public int StabilizingTime { set; get; }
        public int TestDuration { set; get; }
        public bool PlotAllStages { set; get; }

        public int Decimation { set; get; }

        public bool ResetExtension { get; set; }
    }


    public class CyclicTestParameters : TestParameters
    {
        public double Speed
        {
            set { Rate = value; }
            get { return Rate; }
        }

        public int CycleCount { set; get; }
        public TestControlMode RateControlType { set; get; }
        public double CyclicRate { set; get; }
        public TestControlMode SetPointType { set; get; }
        public double Limit1 { set; get; }
        public double Limit2 { set; get; }
        public double KeepTime { set; get; }
    }

    public class StepTestParameters : TestParameters
    {
        public List<TestControlMode> RateControlTypes { set; get; }
        public List<double> Rates { set; get; }
        public List<TestControlMode> SetPointTypes { set; get; }
        public List<double> SetPoints { set; get; }
        public List<double> StepDurationTimes { set; get; }
        public List<SetPointAction> SetPointActions { set; get; }
        public List<double?> SetForce { set; get; }
        public List<double?> SetExtension { set; get; }

        public StepTestParameters()
        {
            RateControlTypes = new List<TestControlMode>();
            Rates = new List<double>();
            SetPointTypes = new List<TestControlMode>();
            SetPoints = new List<double>();
            StepDurationTimes = new List<double>();
            SetForce = new List<double?>();
            SetExtension = new List<double?>();
            SetPointActions = new List<SetPointAction>();
        }

        public void AddNewStep(TestControlMode rateCtrlMode, double rate, TestControlMode limitMode, double limit, SetPointAction setPointMode, double duration, double? setForce, double? setExtension)
        {
            RateControlTypes.Add(rateCtrlMode);
            Rates.Add(rate);
            SetPointTypes.Add(limitMode);
            SetPoints.Add(limit);
            SetPointActions.Add(setPointMode);
            StepDurationTimes.Add(duration);
            SetForce.Add(setForce);
            SetExtension.Add(setExtension);
        }
    }
}
