namespace STM.BLayer.Parameters
{
	class InstrumentParameters
	{
		public static int ForceRes { set; get; }
		public static int ForceFilter { set; get; }
		public static int ForcePeakNoiseDetection { set; get; }
		public static double ForceMinPercent { set; get; }
		public static double ForceMaxPercent { set; get; }
		public static double ForceMinLimit { set; get; }
		public static double ForceMaxLimit { set; get; }

		public static int ExtenRes { set; get; }
		public static int ExtenFilter { set; get; }
		public static double ExtenGaugeLength { set; get; }
		public static int ExtenPeakNoiseDetection { set; get; }
		public static double ExtenMin { set; get; }
		public static double ExtenMax { set; get; }
		public static bool UseExtensometer { get; set; }

		public static int LfEncoderRes { set; get; }
		public static int LfEncoderFilter { set; get; }
		public static int LfEncoderPeakNoiseDetection { set; get; }
		public static double LfEncoderMin { set; get; }
		public static double LfEncoderMax { set; get; }
		public static double LfEncoderGain { set; get; }

		public static int LExtenRes { set; get; }
		public static int LExtenFilter { set; get; }
		public static double LExtenGaugeLength { set; get; }
		public static int LExtenPeakNoiseDetection { set; get; }
		public static double LExtenMin { set; get; }
		public static double LExtenMax { set; get; }

		public static int TemperatureRes { get; set; }

		public static int TemperatureMax { get; set; }

		public static bool TemperatureHMI { get; set; }

        public static double TemperatureGain1 { get; set; }
		public static double TemperatureGain2 { get; set; }
        public static double TemperatureAxisRange { get; set; }

        private static double[] _TemperatureOffset = new double[DLayer.TMPR232.NumberOfTemperaturChannels];
        public static double[] TemperatureOffset { get { return _TemperatureOffset; } }

        static int[] _TemperatureChannelMapping = new int[DLayer.TMPR232.NumberOfTemperaturChannels];
        public static int[] TemperatureChannelMapping { get { return _TemperatureChannelMapping; } }

    }
}
