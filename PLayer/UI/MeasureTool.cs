using System;
using System.Collections.Generic;
using System.Linq;
using STM.BLayer;
using STM.Properties;

namespace STM.PLayer.UI
{
	public class MeasureTool
	{
		public MeasureType MeasureType { set; get; }
		public string MeasureLable { set; get; }
		public string Unit { set; get; }
		public int Order { set; get; }
		public string Tool { set; get; }

		static readonly Dictionary<MeasureType, string> Labels = new Dictionary<MeasureType, string>
														  {
															  {MeasureType.Force, Resources.MeasureTool_Labels_Force_LC_},
															  {MeasureType.ExtenExtension, Resources.MeasureTool_Labels_Extension_Ex_},
															  {MeasureType.LFExtension, Resources.MeasureTool_Labels_Extension_LF_},
															  {MeasureType.Stress, Resources.MeasureTool_Labels_Stress_LC_},
															  {MeasureType.TrueStress, Resources.MeasureTool_Labels_True_Stress_LC_},
															  {MeasureType.MassStress, Resources.MeasureTool_Labels_Mass_Stress__LC_},
															  {MeasureType.LengthStress, Resources.MeasureTool_Labels_Length_Stress__LC_},
															  {MeasureType.LStrain, Resources.MeasureTool_Labels_Lateral_Strain_LE_},
															  {MeasureType.TrueStrain, Resources.MeasureTool_Labels_True_Strain_EX_},
															  {MeasureType.Strain,Resources.MeasureTool_Labels_Strain_EX_},
															  {MeasureType.Temperature,Resources.MeasureTool_Labels_Temperature},
															  {MeasureType.SpecTempUP,Resources.MeasureTool_Labels_Spec__Temp_UP},
															  {MeasureType.SpecTempCNT,Resources.MeasureTool_Labels_Spec__Temp_CNT},
															  {MeasureType.SpecTempDN,Resources.MeasureTool_Labels_Spec__Temp_DN},
															  {MeasureType.ZoneTempUP,Resources.MeasureTool_Labels_Zone_Temp_UP},
															  {MeasureType.ZoneTempCNT,Resources.MeasureTool_Labels_Zone_Temp_CNT},
															  {MeasureType.ZoneTempDN,Resources.MeasureTool_Labels_Zone_Temp_DN},
															  {MeasureType.AmbientTemp,Resources.MeasureTool_Labels_Ambient_Temp},                                                      
															  {MeasureType.Time, Resources.MeasureTool_Labels_Time}

														  };
		#region static methods


		public static Dictionary<MeasureType, string> MeasureToolLabels
		{
			get { return Labels; }
		}

		public static Dictionary<string, string> MeasurAbbreviations
		{
			get
			{
				return new Dictionary<string, string>
														  {
															  {"None","" },
															  {"Force", Resources.MeasureTool_MeasurAbbreviations_Force},
															  {"Extension", Resources.MeasureTool_MeasurAbbreviations_Extension},
															  {"Stress", Resources.MeasureTool_MeasurAbbreviations_Stress},
															  {"TrueStress", Resources.MeasureTool_MeasurAbbreviations_True_Stress},
															  {"MassStress", Resources.MeasureTool_MeasurAbbreviations_Mass_Stress},
															  {"LengthStress", Resources.MeasureTool_MeasurAbbreviations_Length_Stress},
															  {"LStrain", Resources.MeasureTool_MeasurAbbreviations_Lateral_Strain},
															  {"TrueStrain", Resources.MeasureTool_MeasurAbbreviations_True_Strain},
															  {"Strain",Resources.MeasureTool_MeasurAbbreviations_Strain},
															  {"Temperature",Resources.MeasureTool_MeasurAbbreviations_Temperature },
															  {"SpecTempUP", Resources.MeasureTool_MeasurAbbreviations_Spec__Temp_UP },
															  {"SpecTempCNT",Resources.MeasureTool_MeasurAbbreviations_Spec__Temp_CNT },
															  {"SpecTempDN",Resources.MeasureTool_MeasurAbbreviations_Spec__Temp_DN },
															  {"ZoneTempUP", Resources.MeasureTool_MeasurAbbreviations_Zone_Temp_UP },
															  {"ZoneTempCNT",Resources.MeasureTool_MeasurAbbreviations_Zone_Temp_CNT },
															  {"ZoneTempDN",Resources.MeasureTool_MeasurAbbreviations_Zone_Temp_DN },
															  {"AmbientTemp",Resources.MeasureTool_MeasurAbbreviations_Ambient_Temp },
															  {"Time",Resources.MeasureTool_MeasurAbbreviations_Time},
															  {"RelaxLoss", Resources.MeasureTool_MeasurAbbreviations_Relaxation_Loss},
															  {"ForceLoss", Resources.MeasureTool_MeasurAbbreviations_Force_Loss},
															  {"StressLoss", Resources.MeasureTool_MeasurAbbreviations_Stress_Loss},
														  };
			}
		}

		public static MeasureType GetToolMeasureType(string mesauerTool)
		{
			return Labels.Keys.FirstOrDefault(key => Labels[key] == mesauerTool);
		}

		public static MeasureType GetMeasureType(string mesauer)
		{
			mesauer = mesauer.Replace(" ", "").Replace(".", "");
            return Labels.Keys.FirstOrDefault(key => key.ToString() == mesauer || Labels[key].Split("()".ToCharArray())[0].Replace(" ", "").Replace(".","") == mesauer);
		}

		public static void SetExtensionTool(string tool = "EX")
		{
			if (tool == "EX")
			{
				Labels[MeasureType.TrueStrain] = Resources.MeasureTool_Labels_True_Strain_EX_;
				Labels[MeasureType.Strain] = Resources.MeasureTool_Labels_Strain_EX_;
			}
			else
			{
				Labels[MeasureType.TrueStrain] = Resources.MeasureTool_SetExtensionTool_True_Strain_LF_;
				Labels[MeasureType.Strain] = Resources.MeasureTool_SetExtensionTool_Strain_LF_;
			}
		}

		public static string[] GetToolNames(string measureType)
		{
			measureType = measureType.Replace(" ", "");
			var measure = (MeasureType)Enum.Parse(typeof(MeasureType), measureType);
			var tools = new string[0];
			switch (measure)
			{
				case MeasureType.Force:
				case MeasureType.Stress:
				case MeasureType.TrueStress:
				case MeasureType.LengthStress:
				case MeasureType.MassStress:
				case MeasureType.StressLoss:
				case MeasureType.ForceLoss:
				case MeasureType.RelaxLoss:
					tools = new[] { Resources.MeasureTool_GetToolNames_Loadcell_LC_ };
					break;

				case MeasureType.Extension:
					tools = new[] { Resources.MeasureTool_GetToolNames_Loadframe_Encoder_LF_, Resources.MeasureTool_GetToolNames_Extensometer_EX_ };
					break;
				case MeasureType.TrueStrain:
				case MeasureType.Strain:
					tools = new[] { Resources.MeasureTool_GetToolNames_Extension_tool };
					break;

				case MeasureType.LStrain:
					tools = new[] { Resources.MeasureTool_GetToolNames_Lateral_Extensometer_LE_ };
					break;

				case MeasureType.Temperature:
					tools = new[] { Labels[MeasureType.AmbientTemp], Labels[MeasureType.SpecTempUP], Labels[MeasureType.SpecTempCNT], Labels[MeasureType.SpecTempDN], Labels[MeasureType.ZoneTempUP], Labels[MeasureType.ZoneTempCNT], Labels[MeasureType.ZoneTempDN], Labels[MeasureType.Temperature] };
					break;
			}

			return tools;
		}

		public static List<string> GetMeasureNames()
		{
			var names = Enum.GetNames(typeof(MeasureType)).ToList();
			names.Remove(MeasureType.LFExtension.ToString());
			names.Remove(MeasureType.ExtenExtension.ToString());
			names.Remove(MeasureType.RelaxLoss.ToString());
			names.Remove(MeasureType.ForceLoss.ToString());
			names.Remove(MeasureType.StressLoss.ToString());
            names.Remove(MeasureType.Temperature.ToString());
            names.Remove(MeasureType.SpecTempUP.ToString());
            names.Remove(MeasureType.SpecTempCNT.ToString());
            names.Remove(MeasureType.SpecTempDN.ToString());
            names.Remove(MeasureType.ZoneTempUP.ToString());
			names.Remove(MeasureType.ZoneTempCNT.ToString());
			names.Remove(MeasureType.ZoneTempDN.ToString());
            names.Remove(MeasureType.AmbientTemp.ToString());
            return names;
		}

        public static string GetMeasureName(MeasureType type)
		{
			switch (type)
            {
                case MeasureType.None:
                    return Resources.MeasureTool_MeasurAbbreviations_None;

                case MeasureType.Force: 
					return Resources.MeasureTool_MeasurAbbreviations_Force;

                case MeasureType.Extension:
                    return Resources.MeasureTool_MeasurAbbreviations_Extension;

                case MeasureType.Stress:
                    return Resources.MeasureTool_MeasurAbbreviations_Stress;

                case MeasureType.TrueStress:
                    return Resources.MeasureTool_MeasurAbbreviations_True_Stress;

                case MeasureType.MassStress:
                    return Resources.MeasureTool_MeasurAbbreviations_Mass_Stress;

                case MeasureType.LengthStress:
                    return Resources.MeasureTool_MeasurAbbreviations_Length_Stress;

                case MeasureType.Strain:
                    return Resources.MeasureTool_MeasurAbbreviations_Strain;

                case MeasureType.TrueStrain:
                    return Resources.MeasureTool_MeasurAbbreviations_True_Strain;

                case MeasureType.LStrain:
                    return Resources.MeasureTool_MeasurAbbreviations_Lateral_Strain;

                case MeasureType.Time:
					return Resources.MeasureTool_MeasurAbbreviations_Time;

				case MeasureType.Temperature:
					return Resources.MeasureTool_Labels_Temperature;

                default: return "";
			}
        }


        public static bool IsExtensionGroup(MeasureType measureType1, MeasureType measureType2)
		{
			bool retVal = false;
			switch (measureType1)
			{
				case MeasureType.Extension:
				case MeasureType.ExtenExtension:
				case MeasureType.LFExtension:
					if (measureType2 == MeasureType.Extension || measureType2 == MeasureType.LFExtension || measureType2 == MeasureType.ExtenExtension)
						retVal = true;
					break;
			}
			return retVal;
		}

		public static bool IsExtension(MeasureType measureType)
		{

			bool retVal = false;
			switch (measureType)
			{
				case MeasureType.Extension:
				case MeasureType.ExtenExtension:
				case MeasureType.LFExtension:
					retVal = true;
					break;
			}

			return retVal;
		}

		public static bool IsTemperature(MeasureType measureType)
		{

			bool retVal = false;
			switch (measureType)
			{
				case MeasureType.Temperature:
				case MeasureType.SpecTempUP:
				case MeasureType.SpecTempCNT:
				case MeasureType.SpecTempDN:
				case MeasureType.ZoneTempUP:
				case MeasureType.ZoneTempCNT:
				case MeasureType.ZoneTempDN:
				case MeasureType.AmbientTemp:
					retVal = true;
					break;
			}

			return retVal;
		}

		public static MeasureType GetType(MeasureType measureType, string tool)
		{
			if (measureType == MeasureType.Extension)
			{
				if (tool.Equals(Resources.MeasureTool_GetToolNames_Extensometer_EX_))
					return MeasureType.ExtenExtension;
				return MeasureType.LFExtension;
			} else if(measureType == MeasureType.Temperature)
			{
				if (tool.Equals(Labels[MeasureType.SpecTempUP]))
					return MeasureType.SpecTempUP;
				if (tool.Equals(Labels[MeasureType.SpecTempCNT]))
					return MeasureType.SpecTempCNT;
				if (tool.Equals(Labels[MeasureType.SpecTempDN]))
					return MeasureType.SpecTempDN;
			}
			return measureType;
		}

		#endregion



		public static string[] Units(MeasureType measureType, out string selected)
		{
			selected = "";
			string[] items = null;
			switch (measureType)
			{
				case MeasureType.Force:
				case MeasureType.ForceLoss:
					{
						items = UnitManager.ForceUnits;
						selected = UnitManager.ForceUnit;
					}
					break;

				case MeasureType.Stress:
				case MeasureType.TrueStress:
				case MeasureType.StressLoss:
					{
						items = UnitManager.StressUnits;
						selected = UnitManager.StressUnit;
					}
					break;

				case MeasureType.MassStress:
					{
						items = UnitManager.MassStressUnits;
						selected = UnitManager.MassStressUnit;
					}
					break;

				case MeasureType.LengthStress:
					{
						items = UnitManager.LengthStressUnits;
						selected = UnitManager.LengthStressUnit;
					}
					break;


				case MeasureType.ExtenExtension:
				case MeasureType.LFExtension:
				case MeasureType.Extension:
					{
						items = UnitManager.ExtensionUnits;
						selected = UnitManager.ExtensionUnit;
					}
					break;

				case MeasureType.LStrain:
				case MeasureType.Strain:
				case MeasureType.TrueStrain:
					{
						items = UnitManager.StrainUnits;
						selected = UnitManager.StrainUnit;
					}
					break;

				case MeasureType.Temperature:
				case MeasureType.SpecTempUP:
				case MeasureType.SpecTempCNT:
				case MeasureType.SpecTempDN:
				case MeasureType.ZoneTempUP:
				case MeasureType.ZoneTempCNT:
				case MeasureType.ZoneTempDN:
				case MeasureType.AmbientTemp:
					{
						items = UnitManager.TemperatureUnits;
						selected = UnitManager.TemperatureUnit;
					}
					break;

				case MeasureType.Time:
					{
						items = UnitManager.TimeUnits;
						selected = UnitManager.TimeUnit;
					}
					break;


				case MeasureType.RelaxLoss:
					{
						items = UnitManager.Percent.GetUnitNames();
						selected = "%";
					}
					break;
			}
			return items;
		}

		public static double SetUnit(MeasureType mType, string unit)
		{
			var m = 1.0;
			switch (mType)
			{
				case MeasureType.Force:
					m = UnitManager.SetDefaultForceUnit(unit);
					UnitManager.ForceUnit = unit;
					break;

				case MeasureType.Extension:
				case MeasureType.LFExtension:
				case MeasureType.ExtenExtension:
					m = UnitManager.SetDefaultExtenUnit(unit);
					UnitManager.ExtensionUnit = unit;
					break;

				case MeasureType.Stress:
				case MeasureType.TrueStress:
					m = UnitManager.SetStressUnit(unit);
					UnitManager.StressUnit = unit;
					break;

				case MeasureType.Strain:
				case MeasureType.TrueStrain:
				case MeasureType.LStrain:
					m = UnitManager.SetStrainUnit(unit);
					UnitManager.StrainUnit = unit;
					break;

				case MeasureType.Temperature:
				case MeasureType.SpecTempUP:
				case MeasureType.SpecTempCNT:
				case MeasureType.SpecTempDN:
				case MeasureType.ZoneTempUP:
				case MeasureType.ZoneTempCNT:
				case MeasureType.ZoneTempDN:
				case MeasureType.AmbientTemp:
					m = UnitManager.SetTemperatureUnit(unit);
					UnitManager.TemperatureUnit = unit;
					break;

				case MeasureType.Time:
					m = UnitManager.SetTimeUnit(unit);
					UnitManager.TimeUnit = unit;
					break;

				case MeasureType.MassStress:
					m = UnitManager.SetMassStressUnit(unit);
					UnitManager.MassStressUnit = unit;
					break;

				case MeasureType.LengthStress:
					m = UnitManager.SetLengthStressUnit(unit);
					UnitManager.LengthStressUnit = unit;
					break;

			}
			return m;
		}

		public static Unit GetUnit(MeasureType mType)
		{
			var unitName = "";
			var m = 1.0;
			switch (mType)
			{
				case MeasureType.Force:
				case MeasureType.ForceLoss:
					{
						unitName = UnitManager.ForceUnit;
						m = UnitManager.ForceM;
					}
					break;

				case MeasureType.Stress:
				case MeasureType.TrueStress:
				case MeasureType.StressLoss:
					{
						unitName = UnitManager.StressUnit;
						m = UnitManager.StressM;
					}
					break;

				case MeasureType.MassStress:
					{
						unitName = UnitManager.MassStressUnit;
						m = UnitManager.MassStressM;
					}
					break;

				case MeasureType.LengthStress:
					{
						unitName = UnitManager.LengthStressUnit;
						m = UnitManager.LengthStressM;
					}
					break;

				case MeasureType.ExtenExtension:
				case MeasureType.LFExtension:
				case MeasureType.Extension:
					{
						unitName = UnitManager.ExtensionUnit;
						m = UnitManager.ExtenM;
					}
					break;

				case MeasureType.LStrain:
				case MeasureType.Strain:
				case MeasureType.TrueStrain:
					{
						unitName = UnitManager.StrainUnit;
						m = UnitManager.StrainM;
					}
					break;

				case MeasureType.Temperature:
				case MeasureType.SpecTempUP:
				case MeasureType.SpecTempCNT:
				case MeasureType.SpecTempDN:
				case MeasureType.ZoneTempUP:
				case MeasureType.ZoneTempCNT:
				case MeasureType.ZoneTempDN:
				case MeasureType.AmbientTemp:
					{
						unitName = UnitManager.TemperatureUnit;
						m = UnitManager.TemperatureM;
					}
					break;

				case MeasureType.Time:
					{
						unitName = UnitManager.TimeUnit;
						m = UnitManager.TimeM;
					}
					break;

				case MeasureType.RelaxLoss:
					{
						unitName = "%";
						m = 100;
					}
					break;
			}
			return new Unit { Abbreviation = unitName, M = m, Name = unitName };
		}
	}
}
