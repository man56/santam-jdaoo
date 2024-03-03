using System.Globalization;
using STM.BLayer.Parameters;
using System.Threading.Tasks;
using System.Windows.Forms;
using STM.Properties;

namespace STM.BLayer
{
	public static class Status
	{
		public static bool UpMicroSwitch { private set; get; }
		public static bool DownMicroSwitch { private set; get; }
		public static bool ZeroKey { set; get; }
		public static bool CtrlKey { private set; get; }
		public static bool CtrlZeroKey { private set; get; }
		public static bool StartKey { private set; get; }
		public static bool StopKey { private set; get; }

		public static bool LoadcellFailure { private set; get; }
		public static bool ExtensometerFailure { private set; get; }
		public static bool LfEncoderFailure { private set; get; }
		public static bool DriverFailure { private set; get; }

		public static bool UpMicroSwitchChanged { private set; get; }
		public static bool DownMicroSwitchChanged { private set; get; }
		public static bool LoadcellFailureChanged { private set; get; }
		public static bool ExtensometerFailureChanged { private set; get; }
		public static bool LfEncoderFailureChanged { private set; get; }
		public static bool DriverFailureChanged { private set; get; }

		public static CrossHeadSpeedMode StatusSpeedMode { private set; get; }

        // 1399/11/30 Nazarpour
        private static bool _pStartKey = false;
        private static bool _pStopKey = false;

        public static bool IsStartKeySignal()
        {
            var ok = _pStartKey;
            _pStartKey = false;
            return ok;
        }

        public static bool IsStopKeySignal()
        {
            var ok = _pStopKey;
            _pStopKey = false;
            return ok;
        }
        // // // // // // // //

		public static void ParseStatus(string status)
		{
			UpMicroSwitch = false;
			DownMicroSwitch = false;
			CtrlKey = false;
			StartKey = false;
			StopKey = false;
			ZeroKey = false;
			CtrlZeroKey = false;
			StatusSpeedMode = CrossHeadSpeedMode.None;
			var kb = short.Parse(status.Substring(2, 2), NumberStyles.HexNumber);
			switch (kb)
			{
				case 0x3E:
                    if (!StartKey) _pStartKey = true;
					StartKey = true;
					break;
				case 0x3D:
                    if (!StopKey) _pStopKey = true;
					StopKey = true;
					break;
				case 0x3B:
					CtrlKey = true;
					break;
				case 0x37:
					ZeroKey = true;
					break;
				case 0x2F:
					StatusSpeedMode = CrossHeadSpeedMode.FastUp;
					break;
				case 0x1F:
					StatusSpeedMode = CrossHeadSpeedMode.FastDown;
					break;
				case 0x33:
					CtrlZeroKey = true;
					CtrlKey = true;
					break;
				case 0x2B:
					CtrlKey = true;
					StatusSpeedMode = CrossHeadSpeedMode.Up;
					break;
				case 0x1B:
					CtrlKey = true;
					StatusSpeedMode = CrossHeadSpeedMode.Down;
					break;
			}

            if (!StartKey) _pStartKey = false;
            if (!StopKey) _pStopKey = false;

			var chk = short.Parse(status.Substring(0, 2), NumberStyles.HexNumber);
			var flags = new bool[8];
			for (int index = 0; index < 8; index++)
			{
				flags[index] = ((chk & (1 << index)) != 0);
			}

			LoadcellFailure = flags[0] || flags[2];
			if (LoadcellFailure && !LoadcellFailureChanged)
			{
				Task.Factory.StartNew(() => MessageBox.Show(Resources.Status_ParseStatus_Loadcell_Disconnected_));
			}
			LoadcellFailureChanged = LoadcellFailure;

			ExtensometerFailure = flags[1] || flags[4];
			if (ExtensometerFailure && !ExtensometerFailureChanged)
			{
				Task.Factory.StartNew(() => MessageBox.Show(Resources.Status_ParseStatus_Extensometer_Disconnected_));
			}
			ExtensometerFailureChanged = ExtensometerFailure;

			LfEncoderFailure = flags[3];
			if (LfEncoderFailure && !LfEncoderFailureChanged)
			{
				Task.Factory.StartNew(() => MessageBox.Show(Resources.Status_ParseStatus_LF_Encoder_Disconnected_));
			}
			LfEncoderFailureChanged = LfEncoderFailure;

			DriverFailure = flags[5];
			if (DriverFailure && !DriverFailureChanged)
			{
				Task.Factory.StartNew(() => MessageBox.Show(Resources.Status_ParseStatus_Driver_Disconnected_));
			}
			DriverFailureChanged = DriverFailure;

			UpMicroSwitch = flags[6];
			if (UpMicroSwitch && !UpMicroSwitchChanged)
			{
				Task.Factory.StartNew(() => MessageBox.Show(Resources.Status_ParseStatus_Up_Micro_Switch_Hitted_));
			}
			UpMicroSwitchChanged = UpMicroSwitch;

			DownMicroSwitch = flags[7];
			if (DownMicroSwitch && !DownMicroSwitchChanged)
			{
				Task.Factory.StartNew(() => MessageBox.Show(Resources.Status_ParseStatus_Down_Micro_Switch_Hitted_));
			}
			DownMicroSwitchChanged = DownMicroSwitch;

			if (UpMicroSwitch)
				if (StatusSpeedMode == CrossHeadSpeedMode.FastUp || StatusSpeedMode == CrossHeadSpeedMode.Up)
					StatusSpeedMode = CrossHeadSpeedMode.None;
				else if (DownMicroSwitch)
					if (StatusSpeedMode == CrossHeadSpeedMode.FastDown || StatusSpeedMode == CrossHeadSpeedMode.Down)
						StatusSpeedMode = CrossHeadSpeedMode.None;
		}
	}
}