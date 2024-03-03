using System;
using System.Windows.Forms;
using STM.BLayer.Parameters;
using STM.DLayer;
using System.Threading;
using STM.PLayer.UI;
using STM.Sensor;
using STM.BLayer.StmTest;

namespace STM.BLayer.Configurations
{
    public class Configuer
    {
        public delegate void LoadCellDetection(int type);
        public delegate void ExtensometerDetection(int type);
        public delegate void LoadCellAthentication(double maxCap, double ro);
        public delegate void ProgressReport(int percent);
		public delegate void TemperatureSensorDetection(int countOfSensors);
        public delegate void TemperatureSensorAthentication(double maxCap, double ro);

        public LoadCellDetection OnLoadCellDetection;
        public ExtensometerDetection OnExtensometerDetection;
        public LoadCellAthentication OnLoadCellAthentication;
        public ProgressReport OnProgressReport;
		public TemperatureSensorDetection OnTemperatureSensorDetection;
        public TemperatureSensorAthentication OnTemperatureSensorAthentication;

        public Configuer()
        {
            LoadConfigurations();
        }

        //public void Reconfig(bool fds = false, bool changeGain = false)
        //{
        //    if(!RS232.Connected)
        //    {
        //      var initilize =  RS232.Current;
        //    }
        //    try
        //    {
        //        if (RS232.Connected)
        //        {
        //            if (fds)
        //            {
        //                SetProgress(10);
        //                FDS();
        //                SetProgress(20);
        //                Def3();
        //                SetProgress(80);
        //                ResetSDB();
        //                SetProgress(100);
        //            }


        //            if (changeGain)
        //            {
        //                SetProgress(20);
        //                Def3();
        //                SetProgress(100);
        //            }
        //            else
        //                DetectHardware();
        //            InstrumentParameters.ForceMaxLimit = InstrumentParameters.ForceMaxPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
        //            InstrumentParameters.ForceMinLimit = InstrumentParameters.ForceMinPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    Sensors.CurrentEncoder.Zero();
        //}

        public void Reconfig(bool fds = false)
        {
            if (!RS232.Connected)
            {
                var initilize = RS232.Current;
            }
            try
            {
                if (RS232.Connected)
                {
                    if (fds)
                    {
                        SetProgress(10);
                        FDS();

                        SetProgress(20);

                        Def3();
                        SetProgress(80);
                        Def2(SettingLoader.Current.GetLastExtenAnalogType());
                        SetProgress(90);
                        ResetSDB();
                        SetProgress(100);
                    }

                    DetectHardware();

                    InstrumentParameters.ForceMaxLimit = InstrumentParameters.ForceMaxPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
                    InstrumentParameters.ForceMinLimit = InstrumentParameters.ForceMinPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
                }
                if (TMPR232.Connected)
                {
                    if (!RS232.Connected) DetectHardware();
                    TMPR232.Current.Send("01DMS,01,0001");
                    TMPR232.Current.Send("02DMS,01,0001");
                    TMPR232.Current.Send("03DMS,01,0001");
                    TMPR232.Current.Send("04DMS,01,0001");
                }
                else if (TMPR485.Connected)
                {
                    if (!RS485.Connected) DetectHardware();
                }
            }
            catch
            {
            }
            Sensors.CurrentEncoder.Zero();
        }

        public void SendEncoder()
        {
            if (!RS232.Connected)
            {
                var initilize = RS232.Current;
            }
            try
            {
                if (RS232.Connected)
                {
                    {
                        Def3();
                        SetProgress(80);
                        Def2(SettingLoader.Current.GetLastExtenAnalogType());
                        ResetSDB();
                        SetProgress(100);
                    }
                    InstrumentParameters.ForceMaxLimit = InstrumentParameters.ForceMaxPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
                    InstrumentParameters.ForceMinLimit = InstrumentParameters.ForceMinPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
                }
            }
            catch
            {
            }
            Sensors.CurrentEncoder.Zero();
        }

        public void FactoryDefualtSettings()
        {
            SetProgress(10);
            FDS();
            Def3();
            Def2(SettingLoader.Current.GetLastExtenAnalogType());
            SetProgress(100);
            ResetSDB();
        }
        private void SetProgress(int percent)
        {
            if (OnProgressReport != null)
                OnProgressReport(percent);
        }



        private static void LoadConfigurations()
        {
            using (var sl = SettingLoader.Current)
            {
                sl.LoadSpeedCtrlSetting();
                sl.LoadOption();
                sl.LoadCrossHeadSetting();
                sl.LoadInstruments();
            }
        }


        private void FDS()
        {
            var port = RS232.Current;
            do
            {
                RS232.Current.Send("FDS");
                Thread.Sleep(3500);
                var f = RS232.Read();
                if (f.Equals("Restore Fact") || f.Equals("SCB Ready")) break;
            }
            while (true);
            RS232.Current.ClearPortBuffer();
        }

        private static void Def3()
        {
            RS232 port = RS232.Current;
            RS232.Current.Send(string.Format("DEF3,1<{0}", Statistics.ExtenBitProtect == 0 ? 3000 : Statistics.ExtenBitProtect));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,2<{0}",(Math.Abs(InstrumentParameters.LfEncoderGain) < Double.Epsilon ? 1 : Math.Round(1/InstrumentParameters.LfEncoderGain, 2))));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,3<{0}", SpeedControlParameters.Offset));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,4<{0}", SpeedControlParameters.Max));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,5<{0}", SpeedControlParameters.P));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,6<{0}", SpeedControlParameters.I));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,7<{0}", SpeedControlParameters.D));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(string.Format("DEF3,8<{0}", 150 /*SpeedControl.Timeout*/));
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
        }

        public static void Def2(bool longAnalog)
        {
            RS232 port = RS232.Current;
            RS232.Current.Send(longAnalog? "DEF2,3<281B0" : "DEF2,3<28190");
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(longAnalog? "DEF2,4<2A1B0" : "DEF2,4<2A190");
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
            RS232.Current.Send(longAnalog ? "DEF2,5<221B0" : "DEF2,5<22190");
            Thread.Sleep(200);
            RS232.Current.ClearPortBuffer();
        }

        public static void ResetSDB()
        {
            RS232 port = RS232.Current;
            while (true)
            {
                RS232.Current.Send("RST");
                RS232.Read();
                Thread.Sleep(10000);
                var f = RS232.Read();
                if (f == "SCB Ready" || f == "SCB Ready")
                    break;
                Thread.Sleep(1000);
            }

            RS232.Current.ClearPortBuffer();
        }

		private void DetectHardware()
		{
            if (RS232.Connected)
            {
                RS232 port = RS232.Current;
                string cmd;

                do
                {
                    lock (port)
                    {
                        RS232.Current.ClearPortBuffer();
                        RS232.Current.Send("ADM");
                        cmd = RS232.Read();
                        if (cmd.Contains(";"))
                            break;

                        Thread.Sleep(1500);
                    }
                } while (true);

                bool notDefind = false;


                int loadCellType = Sensors.DetectLoadCell(cmd, ref notDefind);
                if (notDefind && OnLoadCellDetection != null)
                    OnLoadCellDetection(loadCellType);
                else if (OnLoadCellAthentication != null)
                    OnLoadCellAthentication(Sensors.CurrentLoadCell.MaxCap, Sensors.CurrentLoadCell.RO);

                notDefind = false;
                var extenType = Sensors.DetectExtensometer(cmd, ref notDefind);
                //if (extenType == 0)
                //    MessageBox.Show("Extensometer Disconnected!", AboutBox.AssemblyTitle, MessageBoxButtons.OK,
                //                    MessageBoxIcon.Error);
                //else
                if (notDefind)
                    OnExtensometerDetection?.Invoke(extenType);
            }

            if (TMPR232.Connected)
            {
                var notDefind = false;
                var tmprId = Sensors.DetectTemperatureSensor(1, ref notDefind);

                if (notDefind && OnTemperatureSensorDetection != null)
                    OnTemperatureSensorDetection(tmprId);
                else if (OnTemperatureSensorAthentication != null)
                    OnTemperatureSensorAthentication(Sensors.CurrentTemperatureSensor.MaxCap[0], Sensors.CurrentTemperatureSensor.RO[0]);
            }
            else if (TMPR485.Connected)
            {
                var notDefind = false;
                var tmprId = Sensors.DetectTemperatureSensor(1, ref notDefind);

                if (notDefind && OnTemperatureSensorDetection != null)
                    OnTemperatureSensorDetection(tmprId);
                else if (OnTemperatureSensorAthentication != null)
                    OnTemperatureSensorAthentication(Sensors.CurrentTemperatureSensor.MaxCap[0], Sensors.CurrentTemperatureSensor.RO[0]);
            }
        }
	}
}
