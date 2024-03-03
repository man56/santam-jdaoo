namespace STM.BLayer.Parameters
{
    class TemperaturePortParameters
    {
        public static string Name { set; get; }
        public static int ReadInterval { set; get; }
        public static int DecimationRatio { set; get; }
        public static int BaudRate { get { return 9600; } }
        public static int DataBits { get { return 8; } }
        public static System.IO.Ports.Parity Parity { get { return System.IO.Ports.Parity.None; } }
        public static System.IO.Ports.StopBits StopBits { get { return System.IO.Ports.StopBits.One; } }
    }
}