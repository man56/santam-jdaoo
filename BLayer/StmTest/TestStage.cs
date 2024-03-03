using System;
using System.IO;

namespace STM.BLayer.StmTest
{
    public class TestStage
    {
        public TestControlMode RateControlMode { set; get; }
        public double RateControlStep { set; get; }
        public double SubSetPoint { set; get; }
        public double Rate { set; get; }

        public bool PassSetPoint { set; get; }

        public TestControlMode SetPointType { set; get; }
        public double SetPoint { set; get; }

        public int StageNo { set; get; }
        public bool Terminated { set; get; }
        public ZeroCode Zerocode { set; get; }

        public DateTime StartTime { set; get; }
        public double StopTime { set; get; }
        public double KeepTime { set; get; }
        public bool PlotStageData { set; get; }

        public double? StartForceOffset;
        public double? StartExtenOffset;

        public bool ResetTestTime { get; set; } // Nazarpour
        public bool ResetExtensotemer { get; set; } // Nazarpour

        public string StageDescription { set; get; }
        public int StepOrCycle { set; get; }

        public float TemperatureSetPoint { get; set; } // Nazarpour
        public float TemperatureSetPointOffset { get; set; } // Nazarpour
        public TemperatuerControlMode TemperatuerControlMode { get; set; } // Nazarpour
        public System.Windows.Forms.Keys StepOverOnHotKey { get; set; }

        public int? Decimation = 0;

        // Nazarpour 1399/11/14
        public bool LimitedModificationInTest = false;
        public bool IsSafeStage = false;

        public double GetCurrentLimit(bool rateControl, int sgn)
        {
            var sepoint = rateControl ? SubSetPoint += RateControlStep * sgn : SetPoint;
            return sepoint;
        }

        public double GetTrueStarinLimit()
        {
            return SetPoint;
        }

        public override string ToString()
        {
            return StageDescription ?? ("@" + this.SetPointType);
        }
    }
}