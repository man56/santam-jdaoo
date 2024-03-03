using System;

namespace STM.Sensor
{
    public class ExtensoMeter
    {
        public bool EncoderBased { private set; get; }
        public bool LongAnalog { private set; get; }
        public double MaxCap;
        public double RoGain { set; get; }
        private double gain;
        public int ExtensomereType { set; get; }
        private int lastExtenValue;
        private int calibrationStartPoint;
        private double extensionBase;
        private double exten;

        private double extenOrgin;

        public ExtensoMeter(int maxCapacity, double ratedOutput, int type, bool encoderBased, bool longAnalog = false)
        {
            MaxCap = maxCapacity;
            RoGain = ratedOutput;
            ExtensomereType = type;
            EncoderBased = encoderBased;
            gain = encoderBased ? RoGain : (MaxCap*Statistics.A2D_MV_VOLT/Statistics.A2D_Max_Count)/RoGain;
            LongAnalog = longAnalog;
        }

        public double GetExtension(int registerValue, int encoderValue)
        {
            if (EncoderBased)
            {
                lastExtenValue = encoderValue;
                exten = -(encoderValue) * gain - extensionBase;
            }
            else
            {
                lastExtenValue = registerValue;
                exten = -(registerValue - Statistics.ExtenOff)*gain - extensionBase;
            }
            return exten + extenOrgin;
        }

        public void Zero()
        {
            if (!EncoderBased)
                Statistics.ExtenOff = lastExtenValue;

            extenOrgin = 0;
        }

        public void SetCalibrationStartPoint()
        {
            calibrationStartPoint = lastExtenValue;
        }

        public double Calibrate(double startExten, double stopExtension)
        {
            if (EncoderBased)
            {
                return (stopExtension - startExten) / (lastExtenValue - calibrationStartPoint);
            }
            var tmp = (stopExtension - startExten) / (lastExtenValue - calibrationStartPoint);
            return Math.Abs((MaxCap * Statistics.A2D_MV_VOLT / Statistics.A2D_Max_Count) / tmp);
        }

        public void SetRoOrGain(double rg)
        {
            RoGain = rg;
            gain = EncoderBased ? RoGain : (MaxCap * Statistics.A2D_MV_VOLT / Statistics.A2D_Max_Count) / RoGain;
        }

        public void SetMaxCap(double maxCap)
        {
            MaxCap = maxCap;
            gain = EncoderBased ? RoGain : (MaxCap * Statistics.A2D_MV_VOLT / Statistics.A2D_Max_Count) / RoGain;
        }

        public void SetExtensionBase(double newExtenOrgin)
        {
            extenOrgin = newExtenOrgin;
        }
    }
}
