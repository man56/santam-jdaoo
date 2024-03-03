namespace STM.BLayer.Parameters
{
    class ModbusPortParameters
    {
        public static string Name { set; get; }
        public static int ReadInterval { set; get; }
        public static int DecimationRatio { set; get; }
        public static int BaudRate { get { return 115200; } }
        public static System.IO.Ports.Parity Parity { get { return System.IO.Ports.Parity.Even; } }
        public static System.IO.Ports.StopBits StopBits { get { return System.IO.Ports.StopBits.One; } }

        public static int DataBits { get { return 7; } }
    }
}