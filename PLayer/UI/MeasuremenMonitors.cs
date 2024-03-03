using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.Configurations;
using STM.BLayer.Parameters;
using STM.DLayer;
using STM.BLayer.StmTest;
using STM.Properties;

namespace STM.PLayer.UI
{
    public partial class MeasurementMonitors : UserControl
    {
        #region Fields
        private static UnitMainCategories UnitMainCategory { set; get; }
        public static Dictionary<int, MeasureTool> MeasureTools { private set; get; }

        private int monitorsCount = 0;

        private const int MinWidth = 180;
        private const int Maxwidth = 316;
        #endregion

        #region constructor

        public MeasurementMonitors()
        {
            InitializeComponent();
        }

        private void MeasuremenMonitors_Load(object sender, EventArgs e)
        {
            MeasureTools = new Dictionary<int, MeasureTool>();
            UnitMainCategory = UnitManager.CurrentUnitCategory;
            try
            {
                LoadMonitors();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion

        #region Add monitors

        private void bttnMenuSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddMonitor();
            AlignMonitors();
        }

        public void ReLoadMeasures()
        {
            for (int index = 0; index < Controls.Count; index++)
            {
                Control ctrl = Controls[index];
                if (!(ctrl is MeasureMonitor))
                    continue;
                Controls.Remove(ctrl);
                index--;
                monitorsCount--;
            }
            monitorsCount = 0;
            UnitMainCategory = UnitManager.CurrentUnitCategory;
            MeasureTools = new Dictionary<int, MeasureTool>();
            try
            {
                LoadMonitors();
            }
            catch
            {
            }
        }

        private void LoadMonitors()
        {
            using (var sl = SettingLoader.Current)
            {
                MeasureTools = sl.GetMeasureTools();
            }
            foreach (var measureTool in MeasureTools.Values)
            {
                MeasureType mm = MeasureTool.GetType(measureTool.MeasureType, measureTool.Tool);
                AddMonitor(mm, measureTool.Tool, measureTool.Unit, measureTool.MeasureLable);
            }
            AlignMonitors();
        }

        private void AddMonitor(MeasureType type = MeasureType.Force, string tool = "", string unit = "", string label = "")
        {
            if (monitorsCount >= 7)
                return;

            var monitor = new MeasureMonitor(type, tool) { Order = monitorsCount, Label = label };

            Controls.Add(monitor);

            monitor.OnUnitChanges += monitor_OnUnitChanges;
            monitor.OnMeasureDelete += monitor_OnMeasureDelete;
            monitor.OnZero += monitor_OnZero;
            monitor.OnUnitSystem += MonitorOnOnUnitSystem;
            monitorsCount++;

            if (!string.IsNullOrEmpty(unit))
                monitor.UpdateUnit(unit);
        }

       

        private void AlignMonitors()
        {
            var x = 0;
            var width = (Width - panelAdd.Width) / (monitorsCount == 0 ? 1 : monitorsCount);
            width = width > Maxwidth ? Maxwidth : width;
            width = width < MinWidth ? MinWidth : width;
            foreach (Control ctrl in Controls)
            {
                if (ctrl is MeasureMonitor)
                    ctrl.Width = width;
                ctrl.Left = x;
                x += ctrl.Width;
            }
        }

        public void SaveMeasures()
        {
            using (var sl = SettingLoader.Current)
            {
                var index = 0;
                MeasureTools = new Dictionary<int, MeasureTool>();
                foreach (Control ctrl in Controls)
                    if (ctrl is MeasureMonitor)
                    {
                        MeasureMonitor mmon = ctrl as MeasureMonitor;
                        MeasureTools[index] = new MeasureTool { MeasureType = mmon.MeasureType, Order = index, Unit = mmon.Unit, MeasureLable = mmon.Label, Tool = mmon.ToolName };
                        mmon.Order = index;
                        index++;
                    }
                sl.SetMeasureTools(MeasureTools);
            }
        }

        #endregion

        #region Methods

        private void monitor_OnMeasureDelete(object sender, EventArgs e)
        {
            Controls.Remove(sender as MeasureMonitor);
            monitorsCount--;
            AlignMonitors();
        }

        private void monitor_OnUnitChanges(object sender, UnitChangeEventArgs e)
        {
            OnUnitChanges(this, e);
        }

        private void MonitorOnOnUnitSystem(object sender, EventArgs eventArgs)
        {
            OnUnitSystems(sender, eventArgs);
        }

        private void monitor_OnZero(object sender, EventArgs e)
        {
            var mon = sender as MeasureMonitor;
            if (mon == null) return;
            switch (mon.MeasureType)
            {
                case MeasureType.Force:
                case MeasureType.Stress:
                case MeasureType.TrueStress:
                case MeasureType.MassStress:
                case MeasureType.LengthStress:
                    OnZeroForce(this, EventArgs.Empty);
                    break;

                case MeasureType.ExtenExtension:
                    OnZeroStrain(this, EventArgs.Empty);
                    break;

                case MeasureType.LFExtension:
                    OnZeroExten(this, EventArgs.Empty);
                    break;

                case MeasureType.Strain:
                case MeasureType.TrueStrain:
                    OnZeroStrain(this, EventArgs.Empty);
                    OnZeroExten(this, EventArgs.Empty);
                    break;

				case MeasureType.Temperature:
					OnZeroTemperature(this, EventArgs.Empty);
					break;

				case MeasureType.SpecTempUP:
					OnZeroTemperatureUp(this, EventArgs.Empty);
					break;

				case MeasureType.SpecTempCNT:
					OnZeroTemperatureCenter(this, EventArgs.Empty);
					break;

				case MeasureType.SpecTempDN:
					OnZeroTemperatureDown(this, EventArgs.Empty);
					break;
			}
        }

        //add
        public void UpdateUnit(MeasureType measureType, string unit)
        {
            foreach (var mon in Controls.OfType<MeasureMonitor>().Where(p => p.MeasureType == measureType || MeasureTool.IsExtensionGroup(measureType, p.MeasureType)))
            {
                mon.UpdateUnit(unit);
            }
        }

        public void ReloadUnits()
        {
            foreach (var mon in Controls.OfType<MeasureMonitor>().Select(ctrl => ctrl))
            {
                mon.LoadUnitMenu();
            }
        }

        public void SetMeasuredParams(MeasuredParams cur)
        {
            if (cur == null)
                return;
            foreach (var mon in Controls.OfType<MeasureMonitor>().Select(ctrl => ctrl))
            {
                switch (mon.MeasureType)
                {
                    case MeasureType.Force:
                        {
                            mon.ValueInString = GetValueString(UnitManager.ForceM * cur.Force, InstrumentParameters.ForceRes);
                        }
                        break;

                    case MeasureType.ExtenExtension:
                        {
                            mon.ValueInString = double.IsNaN(cur.ExtenExtention) ? double.NaN.ToString() :
                                GetValueString(UnitManager.ExtenM * cur.ExtenExtention, InstrumentParameters.ExtenRes);
                        }
                        break;

                    case MeasureType.LFExtension:
                        {
                            mon.ValueInString = GetValueString(cur.LFExtention * UnitManager.ExtenM, InstrumentParameters.LfEncoderRes);
                        }
                        break;

					case MeasureType.Temperature:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[7], InstrumentParameters.TemperatureRes);
                        }
                        break;

                    case MeasureType.SpecTempUP:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[6], InstrumentParameters.TemperatureRes);
                        }
                        break;

                    case MeasureType.SpecTempCNT:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[5], InstrumentParameters.TemperatureRes);
                        }
                        break;
                    case MeasureType.SpecTempDN:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[4], InstrumentParameters.TemperatureRes);
                        }
                        break;

                    case MeasureType.ZoneTempUP:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[3], InstrumentParameters.TemperatureRes);
                        }
                        break;

                    case MeasureType.ZoneTempCNT:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[2], InstrumentParameters.TemperatureRes);
                        }
                        break;
                    case MeasureType.ZoneTempDN:
                        {
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM * cur.Temperature[1], InstrumentParameters.TemperatureRes);
                        }
                        break;

                    case MeasureType.AmbientTemp:
						{
                            if (!TMPR232.Connected && !TMPR485.Connected)
                                mon.ValueInString = Resources.n_a;
                            else
                                mon.ValueInString = GetValueString(UnitManager.TemperatureM*cur.Temperature[0], InstrumentParameters.TemperatureRes);
						}
						break;

					case MeasureType.Stress:
                        {
                            var stress = UnitManager.StressM * cur.Stress;
                            mon.ValueInString = GetValueString(stress, InstrumentParameters.ForceRes);
                        }
                        break;

                    case MeasureType.TrueStress:
                        {
                            var stress = UnitManager.StressM * cur.TrueStress;
                            mon.ValueInString = GetValueString(stress, InstrumentParameters.ForceRes);
                        }
                        break;

                    case MeasureType.MassStress:
                        {
                            var spstress = UnitManager.MassStressM * cur.MassStress;
                            mon.ValueInString = GetValueString(spstress, InstrumentParameters.ForceRes);
                        }
                        break;

                        case MeasureType.LengthStress:
                        {
                            var lstress = UnitManager.LengthStressM*cur.LengthStress;
                            mon.ValueInString = GetValueString(lstress, InstrumentParameters.ForceRes);
                        }
                        break;

                    case MeasureType.Strain:
                        {
                            var strain = UnitManager.StrainM * cur.Strain;
                            mon.ValueInString = GetValueString(strain, InstrumentParameters.ExtenRes);
                        }
                        break;

                    case MeasureType.TrueStrain:
                        {
                            var strain = UnitManager.StrainM * cur.TrueStrain;
                            mon.ValueInString = GetValueString(strain, InstrumentParameters.ExtenRes);
                        }
                        break;

                    case MeasureType.Time:
                        {
                            if (cur.TestData && !double.IsNaN(cur.Time))
                                mon.ValueInString = string.Format("{0:0.00}", UnitManager.TimeM*cur.Time);
                        }
                        break;
                }
            }
        }


        private static string GetValueString(double value, int resulation)
        {
            if (double.IsNaN(value)) return value.ToString();
            if (resulation == 0)
                return ((long)value).ToString("N0");
            var format ="{0";
            var fractions = "{0:0.";
            for (int i = 0; i < resulation;i++ )
            {
                fractions += "0";
            }

            format = (resulation > 0 ? fractions : format) + "}";
            return string.Format(format, value);
        }

        #endregion

        public void Freeze()
        {
            //bttnMenuSetting.Enabled = false;
            //foreach (var mmon in Controls.OfType<MeasureMonitor>().Select(ctrl => ctrl))
            //    mmon.Freeze();
        }
        delegate void invokeDel1();
        void EnableAddMonitor()
        {
            bttnMenuSetting.Enabled = true;
        }
        public void UnFreeze()
        {
            BeginInvoke(new invokeDel1(EnableAddMonitor));
            foreach (var mmon in Controls.OfType<MeasureMonitor>().Select(ctrl => ctrl))
                mmon.UnFreeze();
        }
    }
    public class UnitChangeEventArgs : EventArgs
    {
        public MeasureType measureType { set; get; }
        public string Unit { set; get; }
    }
}
