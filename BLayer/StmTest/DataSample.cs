using System;
using System.Linq;
using System.Windows.Forms;
using STM.PLayer.UI;
using STM.BLayer.Parameters;
using STM.PLayer.Setting;

namespace STM.BLayer.StmTest
{
    public class DataSample
    {
        public double Area { set; get; }
        public double Density { set; get; }
        public double Width { get; set; }
        public double Length { set; get; }
        public double Force { private set; get; }
        public double Extension { private set; get; }
        public double XValue { set; get; }
        public double YValue { set; get; }
        public double Time { private set; get; }
        public double[] Temperature { get; set; }
        public int NumberOfTemperatureSensors { get; set; }


        public int ID { set; get; }
        public int StepOrCycle { set; get; }
        public double? MarkedLoad { set; get; }

        public DataSample()
        {
            NumberOfTemperatureSensors = 0;// DLayer.TMPR232.NumberOfTemperaturChannels;
            Temperature = new double[NumberOfTemperatureSensors];
        }

        public DataSample(double force, double extension, double time) : this()
        {
            Force = force;
            Extension = extension;
            Time = time;
            BindAxisValues();
        }

        public DataSample(double force, double extension, double time, double length, double area, double density, double width, int stepCycle) : this()
        {
            Force = force;
            Extension = extension;
            Time = time;
            Length = length;
            Density = density;
            Width = width;
            Area = area;
            StepOrCycle = stepCycle;
            BindAxisValues();
        }

        public DataSample(string savedString) : this()
        {
            //Nazarpour: "\t" separates previous data from Temperature data, it can be used for expanding saved data.
            var parameters = savedString.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            // Nazarpour 1402/06/22
            if (parameters.Count > 3)
            {
                StepOrCycle = int.Parse(parameters[0]);
                Extension = double.Parse(parameters[1]);
                Force = double.Parse(parameters[2]);
                Time = double.Parse(parameters[3]);
            }
            else
            {
                StepOrCycle = 0;
                Extension = double.Parse(parameters[0]);
                Force = double.Parse(parameters[1]);
                Time = double.Parse(parameters[2]);
            }

            // Nazarpour 1399/10/14
            NumberOfTemperatureSensors = Math.Max(parameters.Count - 4, 0);
            if ((Temperature?.Length ?? 0) < NumberOfTemperatureSensors)
                Temperature = new double[NumberOfTemperatureSensors];

            for (var i = 0; i < NumberOfTemperatureSensors; i++)
                Temperature[i] = double.Parse(parameters[i + 4]);


            // DEBUG 980319
            //NumberOfTemperatureSensors = 1;
            //Temperature = 200 - Extension * 7;
        }

        private void BindAxisValues()
        {
            XValue = GetValue(Plot.XMeasureType);
            YValue = GetValue(Plot.YMeasureType);
        }

        public bool BindValidAxisValues(int id)
        {
            bool retval = true;
            XValue = GetValidValue(Plot.XMeasureType, ref retval);
            YValue = GetValidValue(Plot.YMeasureType, ref retval);
            ID = id;
            return retval;
        }

        public void BindAxisValues(int id)
        {
            XValue = GetValue(Plot.XMeasureType);
            YValue = GetValue(Plot.YMeasureType);

            ID = id;
        }

        public double GetValue(MeasureType measureType)
        {
            var x = 0.0;
            switch (measureType)
            {
                case MeasureType.Force:
                    x = Force;
                    break;
                case MeasureType.Extension:
                case MeasureType.LFExtension:
                case MeasureType.ExtenExtension:
                    x = Extension;
                    break;
                case MeasureType.Stress:
                    x = Force / Area;
                    break;
                case MeasureType.Strain:
                    x = Extension / Length;
                    break;
                case MeasureType.TrueStress:
                    var strain = Extension / Length;
                    x = Force / (Area * (1 - 1 / Math.Exp(strain)));
                    break;
                case MeasureType.TrueStrain:
                    x = Extension / (Length + Extension);
                    break;
                case MeasureType.Time:
                    x = Time;
                    break;
                case MeasureType.MassStress:
                    x = Force / Density;
                    break;

                case MeasureType.LengthStress:
                    x = Force / Width;
                    break;

                case MeasureType.RelaxLoss:
                    x = MarkedLoad.HasValue ? (MarkedLoad.Value - Force) / MarkedLoad.Value : 0;
                    break;
                case MeasureType.ForceLoss:
                    x = MarkedLoad.HasValue ? (MarkedLoad.Value - Force) : 0;
                    break;
                case MeasureType.StressLoss:
                    x = MarkedLoad.HasValue ? (MarkedLoad.Value - Force) / Area : 0;
                    break;
                case MeasureType.Temperature:
                    x = Temperature.Length > 7 ? Temperature[7] : 0;
                    break;
                case MeasureType.SpecTempUP:
                    x = Temperature.Length > 6 ? Temperature[6] : 0;
                    break;
                case MeasureType.SpecTempCNT:
                    x = Temperature.Length > 5 ? Temperature[5] : 0;
                    break;
                case MeasureType.SpecTempDN:
                    x = Temperature.Length > 4 ? Temperature[4] : 0;
                    break;
                case MeasureType.ZoneTempUP:
                    x = Temperature.Length > 3 ? Temperature[3] : 0;
                    break;
                case MeasureType.ZoneTempCNT:
                    x = Temperature.Length > 2 ? Temperature[2] : 0;
                    break;
                case MeasureType.ZoneTempDN:
                    x = Temperature.Length > 1 ? Temperature[1] : 0;
                    break;
                case MeasureType.AmbientTemp:
                    x = Temperature.Length > 0 ? Temperature[0] : 0;
                    break;
                default:
                    x = double.NaN;
                    break;
            }
            return x;
        }
        public double GetValidValue(MeasureType measureType, ref bool valid)
        {
            var x = 0.0; valid = true;
            switch (measureType)
            {
                case MeasureType.Force:
                    x = Force;
                    break;
                case MeasureType.Extension:
                case MeasureType.LFExtension:
                case MeasureType.ExtenExtension:
                    x = Extension;
                    break;
                case MeasureType.Stress:
                    x = Force / Area;
                    break;
                case MeasureType.Strain:
                    x = Extension / Length;
                    break;
                case MeasureType.TrueStress:
                    var strain = Extension / Length;
                    x = Force / (Area * (1 - 1 / Math.Exp(strain)));
                    break;
                case MeasureType.TrueStrain:
                    x = Extension / (Length + Extension);
                    break;
                case MeasureType.Time:
                    x = Time;
                    break;
                case MeasureType.MassStress:
                    x = Force / Density;
                    break;

                case MeasureType.LengthStress:
                    x = Force / Width;
                    break;

                case MeasureType.RelaxLoss:
                    {
                        valid = MarkedLoad.HasValue;
                        x = MarkedLoad.HasValue ? (MarkedLoad.Value - Force) / MarkedLoad.Value : 0;
                    }
                    break;
                case MeasureType.ForceLoss:
                    {
                        valid = MarkedLoad.HasValue;
                        x = MarkedLoad.HasValue ? (MarkedLoad.Value - Force) : 0;
                    }
                    break;
                case MeasureType.StressLoss:
                    {
                        valid = MarkedLoad.HasValue;
                        x = MarkedLoad.HasValue ? (MarkedLoad.Value - Force) / Area : 0;
                    }
                    break;
                case MeasureType.Temperature:
                    x = Temperature[7];
                    break;
                case MeasureType.SpecTempUP:
                    x = Temperature[6];
                    break;
                case MeasureType.SpecTempCNT:
                    x = Temperature[5];
                    break;
                case MeasureType.SpecTempDN:
                    x = Temperature[4];
                    break;
                case MeasureType.ZoneTempUP:
                    x = Temperature[3];
                    break;
                case MeasureType.ZoneTempCNT:
                    x = Temperature[2];
                    break;
                case MeasureType.ZoneTempDN:
                    x = Temperature[1];
                    break;
                case MeasureType.AmbientTemp:
                    x = Temperature[0];
                    break;
                default:
                    x = Force;
                    break;


            }
            return x;
        }


        public string GetSaveString()
        {
            var saveString = string.Format("{0}  {1:0.00000}  {2:0.00000} {3:0.00000}", StepOrCycle, Extension, Force, Time);
            //var saveString = string.Format("{0}  {1,-10}  {2,-10} {3,-10}", StepOrCycle, Extension, Force, Time);
            if (NumberOfTemperatureSensors > 0)
            {
                saveString += "\t";

                for (var i = 0; i < NumberOfTemperatureSensors; i++)
                    saveString += string.Format(" {0:0.0}", Temperature[i]);
            }
            return saveString;
        }

        public void SetTemperatures(params float[] temperature)
        {
            NumberOfTemperatureSensors = temperature?.Length ?? 0;
            Temperature = new double[NumberOfTemperatureSensors];
            
            for (var i = 0; i < NumberOfTemperatureSensors; i++)
                Temperature[i] = temperature[i];
        }

        public class TestExtremom
        {
            public double MaxForce { set; get; }
            public double MinForce { set; get; }
            public double MaxExtension { set; get; }
            public double MinExtension { set; get; }
            public double MaxTemperature { get; set; }
            public double MinTemperature { get; set; }
        }
    }
}