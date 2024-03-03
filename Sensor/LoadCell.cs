using System;
using STM.BLayer.Configurations;

namespace STM.Sensor
{
    public class LoadCell
    {
        public int MaxCap;
        public double RO { private set; get; }
        public double Gain { private set; get; }
        public int LoadCellType { set; get; }
        public double? BreakForceOver;
        public double ForceAtBreak;
        double lastForce = -1;
        private int lastRead;
        private int calibrationStartPoint;
        private double force;
        private double forceBase;

        // 1399/11/30 Nazarpour
        private int break_condition_counter = 0;

        public LoadCell(int maxCapacity, double ro, int type)
        {
            MaxCap = maxCapacity;
            RO = ro;
            LoadCellType = type;
            Gain = (MaxCap * Statistics.A2D_MV_VOLT / Statistics.A2D_Max_Count) / RO;
        }

        public double DirectForce(int loadcellOutput, ref StopCode stop, ref bool peakDetected)
        {
            lastRead = loadcellOutput;
            //if ((loadcellOutput - Statistics.A2D_Real_Max_Count) >= Statistics.ForceProtection * Statistics.A2D_Max_Count / 100)
            //    stop = StopCode.SensorOverflow;
            //else if ((loadcellOutput - Statistics.A2D_Real_Max_Count) <= Statistics.ForceProtection * Statistics.A2D_Max_Count / -100)
            //    stop = StopCode.LoadCellProtection;
            //else
            //    stop = StopCode.None;


            force = (loadcellOutput - Statistics.ForceOff) * Gain * Statistics.G - forceBase;

            var df = Math.Abs(force) - Math.Abs(lastForce);
            if (BreakForceOver.HasValue && (Math.Abs(df / force) * 100) >= BreakForceOver.Value)
            {
                if (Math.Abs(lastForce) > 40)
                {
                    if (--break_condition_counter <= 0)// 1390//1/30 Nazarpour
                    {
                        ForceAtBreak = lastForce;
                        stop = StopCode.ForceBreakPoint;
                        lastForce = force;// 1390//1/30 Nazarpour
                    }
                }else
                    lastForce = force;// 1390//1/30 Nazarpour
            }
            else
            {
                break_condition_counter = BLayer.StmTest.Test.BreakCounter;
                lastForce = force;// 1390//1/30 Nazarpour
            }
            peakDetected = force < lastForce;
            //lastForce = force;// 1390//1/30 Nazarpour
            return force;
        }

        public bool ExtensionBreak(double extention, double threshold, ref StopCode stopCode)
        {
            return false;
        }

        public void Zero()
        {
            Statistics.ForceOff = lastRead;
            SettingLoader.Current.SetforceOffset(lastRead);
        }

        public void SetCalibrationStartPoint()
        {
            calibrationStartPoint = lastRead;
        }

        public double Calibrate(double startForce, double stopForce)
        {
            var g = (stopForce - startForce)/((lastRead - calibrationStartPoint)*Statistics.G);
            return Math.Abs((MaxCap*Statistics.A2D_MV_VOLT/Statistics.A2D_Max_Count)/g);
        }

        public void SetRO(double ro)
        {
            RO = ro;
            Gain = (MaxCap * Statistics.A2D_MV_VOLT / Statistics.A2D_Max_Count) / RO;
        }

        public void SetMaxCap(int maxCap)
        {
            MaxCap = maxCap;
            Gain = (MaxCap * Statistics.A2D_MV_VOLT / Statistics.A2D_Max_Count) / RO;
        }

        public void SetForceBase(double forceOrgin)
        {
            if (forceOrgin == 0)
                forceBase = 0;
            else
            {
                forceBase = -forceOrgin + (force + forceBase);
            }
        }
    }
}
