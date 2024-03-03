using System;
using System.IO;
using STM.BLayer.Parameters;

namespace STM.Sensor
{
    public class MotorEncoder
    {
        public static bool S2EChanged { set; get; }
        private double s2eChangedPostiostion;
        static double ex;
        private double extensionBase;
        private DateTime lastRead;
        private double lastEncValue;
        private DateTime now;
        private double extenOrgin;
        public static double StoEExtension { get; set; }

        
        public double GetExtension(double encoderPulses, out double speed)
        {
            now = DateTime.Now;
            var dt = (now - lastRead).TotalMinutes;
            lastRead = now;

            var dx = (encoderPulses - lastEncValue) * InstrumentParameters.LfEncoderGain;
            lastEncValue = encoderPulses;
            speed = dx / (Math.Abs(dt - 0) < double.Epsilon ? 0.1 / 60 : dt);
            if(S2EChanged)
            {
                s2eChangedPostiostion = encoderPulses - Statistics.MotorEncodeOff;
                S2EChanged = false;
            }
            ex = (encoderPulses /*- Statistics.MotorEncodeOff- s2eChangedPostiostion*/) * InstrumentParameters.LfEncoderGain + StoEExtension - extensionBase;
            return ex + extenOrgin;
        }

        public void Zero()
        {
            lastEncValue = 0;
            lastRead = DateTime.Now;// Delay.GetCurTime();
            extenOrgin = 0;
            Statistics.MotorEncodeOff = 0;
        }

        public void SetExtensionBase(double newExtenOrgin)
        {
            extenOrgin = newExtenOrgin;
        }
    }
}
