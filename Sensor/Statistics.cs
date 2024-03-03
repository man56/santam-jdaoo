using System;
using STM.PLayer.UI;

namespace STM.Sensor
{
    class Statistics
    {
        public static double A2D_Max_Count { get { return 6291456; } }
        public static double A2D_Real_Max_Count { get { return 8388608; } }
        public static double A2D_MV_VOLT { get { return 3; } }

        public static double ForceGain { set; get; }
        public static double ForceOff { set; get; }
        public static double ForceProtection { set { }
            get { return 90; }
        }

        public static double ExtenGain { set; get; }
        public static double ExtenOff { set; get; }
        public static int ExtenBitProtect { set; get; }

        public static int MotorEncodeOff { get; set; }
        public static Int64[] AD2Mode1Init = new long[] { 0x3800110, 0x420, 0x28190, 0x2A190, 0x22190, 0x5800000, 0x6593CEA };
        public static Int64[] AD2Mode2Init = new long[] { 0x3800110, 0x420, 0x281B0, 0x2A1B0, 0x221B0, 0x5800000, 0x6593CEA };
        public static string[] ExtensoName = new string[] { "Short Travel", "Long Travel Analoge", "Long Travel Digital", "Two Range ", "Two Range (Analoge)" };

        public static double G
        {
            get
            {
                return 9.80665002864;
            }
        }
    }
}
