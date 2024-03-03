using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer.Configurations;
using STM.BLayer.Reporting;
using STM.BLayer.Units.SI;
using STM.PLayer.UI;
using STM.Properties;

namespace STM.BLayer
{
    public enum UnitMainCategories
    {
        SI = 1,
        BS = 2,
        MKS = 3
    }

    public class Unit
    {
        public string Name { set; get; }
        public string Abbreviation { set; get; }
        public double M { set; get; }
    }

    public class UnitSet
    {
        public double M { private set; get; }
        public readonly Dictionary<string, Unit> Units;

        public UnitSet(Dictionary<string, Unit> units)
        {
            Units = units;
            M = 1.0;
        }

        public void Initiate(string unitName)
        {
            try
            {
                M = Units[unitName].M;
            }
            catch
            {
                M = 1.0;
            }
        }

        public double ConvertToBaseUnit(double value, string unit)
        {
            var tm = 1 / Units[unit].M;
            return tm * value;
        }

        public double ConvertToUnit(double value, string unit)
        {
            return value * Units[unit].M;
        }

        public string[] GetUnitNames()
        {
            return Units.Select(p => p.Value.Abbreviation).ToArray();
        }
    }

    public static class UnitManager
    {
        private static UnitSet forceUnits;
        private static UnitSet extenUnits;
        private static UnitSet stressUnits;
        private static UnitSet strainUnits;
        private static UnitSet timeUnits;
        private static UnitSet temperatureUnits;
        private static UnitSet massStress;
        private static UnitSet lengthStress;

        private static UnitSet forceControl;
        private static UnitSet stressControl;
        private static UnitSet extenControl;
        private static UnitSet strainControl;
        private static UnitSet lengthStressControl;
        private static UnitSet massStressControl;


        public static UnitSet Percent;

        public static double ForceM { private set; get; }
        public static double ExtenM { private set; get; }
        public static double StressM { private set; get; }
        public static double MassStressM { private set; get; }
        public static double LengthStressM { private set; get; }
        public static double StrainM { private set; get; }
        public static double TimeM { private set; get; }
        public static double TemperatureM { private set; get; }


        private static UnitMainCategories currentUnitCategory;

        public static string ForceUnit { set; get; }
        public static string ExtensionUnit { set; get; }
        public static string StressUnit { set; get; }
        public static string StrainUnit { set; get; }
        public static string TimeUnit { set; get; }
        public static string MassStressUnit { set; get; }
        public static string LengthStressUnit { set; get; }
        public static string TemperatureUnit { set; get; }

        public static UnitMainCategories CurrentUnitCategory
        {
            set
            {
                currentUnitCategory = value;
                switch (value)
                {
                    case UnitMainCategories.SI:
                        {
                            forceUnits = ForceConvertor.UnitSet;
                            extenUnits = ExtenConvertor.UnitSet;
                            stressUnits = StressConvertor.UnitSet;
                            strainUnits = StrainConvertor.UnitSet;
                            massStress = MassStress.UnitSet;
                            lengthStress = LengthStress.UnitSet;
                            temperatureUnits = TemperatureConvertor.UnitSet;

                            extenControl = ExtenControlConvertor.UnitSet;
                            forceControl = ForceControlConvertor.UnitSet;
                            stressControl = StressControlConvertor.UnitSet;
                            strainControl = StrainControlConvertor.UnitSet;
                            lengthStressControl = LengthStressControl.UnitSet;
                            massStressControl = MassStressControl.UnitSet;

                        }
                        break;

                    case UnitMainCategories.BS:
                        {
                            forceUnits = Units.BS.ForceConvertor.UnitSet;
                            extenUnits = Units.BS.LengthConvertor.UnitSet;
                            stressUnits = Units.BS.StressConvertor.UnitSet;
                            strainUnits = Units.BS.StrainConvertor.UnitSet;
                            massStress = Units.BS.MassStress.UnitSet;
                            lengthStress = Units.BS.LengthStress.UnitSet;
                            temperatureUnits = Units.BS.TemperatureConvertor.UnitSet;

                            forceControl = Units.BS.ForceControlConvertor.UnitSet;
                            stressControl = Units.BS.StressControlConvertor.UnitSet;
                            strainControl = Units.BS.StrainControlConvertor.UnitSet;
                            extenControl = Units.BS.ExtenControlConvertor.UnitSet;
                            lengthStressControl = Units.BS.LengthStressControl.UnitSet;
                            massStressControl = Units.BS.MassStressControl.UnitSet;
                        }
                        break;

                    case UnitMainCategories.MKS:
                        {
                            forceUnits = Units.MKS.ForceConvertor.UnitSet;
                            extenUnits = Units.MKS.LengthConvertor.UnitSet;
                            stressUnits = Units.MKS.StressConvertor.UnitSet;
                            strainUnits = Units.MKS.StrainConvertor.UnitSet;
                            massStress = Units.MKS.MassStress.UnitSet;
                            lengthStress = Units.MKS.LengthStress.UnitSet;
                            temperatureUnits = Units.MKS.TemperatureConvertor.UnitSet;

                            forceControl = Units.MKS.ForceControlConvertor.UnitSet;
                            stressControl = Units.MKS.StressControlConvertor.UnitSet;
                            extenControl = Units.MKS.ExtenControlConvertor.UnitSet;
                            strainControl = Units.MKS.StrainControlConvertor.UnitSet;
                            lengthStressControl = Units.MKS.LengthStressControl.UnitSet;
                            massStressControl = Units.MKS.MassStressControl.UnitSet;
                        }
                        break;

                    default:
                        {
                            forceUnits = ForceConvertor.UnitSet;
                            extenUnits = ExtenConvertor.UnitSet;
                            stressUnits = StressConvertor.UnitSet;
                            strainUnits = StrainConvertor.UnitSet;
                            massStress = MassStress.UnitSet;
                            temperatureUnits = TemperatureConvertor.UnitSet;

                            forceControl = ForceControlConvertor.UnitSet;
                            stressControl = StressControlConvertor.UnitSet;
                            strainControl = StrainControlConvertor.UnitSet;
                            extenControl = ExtenControlConvertor.UnitSet;
                            lengthStressControl = Units.BS.LengthStressControl.UnitSet;
                            massStressControl = Units.BS.MassStressControl.UnitSet;
                        }
                        break;
                }
                timeUnits = Time.TimeUnits.UnitSet;
                Percent = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { "%", new Unit { Abbreviation = "%", M = 100, Name = "%" } }});
                LoadNewCategorySelectedUnits(value);

            }
            get
            {
                return currentUnitCategory;
            }
        }

        public static void LoadUnits()//1
        {
            string umc;
            string forceUnit;
            string extenUnit;
            string stressUnit;
            string strainUnit;
            string timeUnit;
            string specStress;
            string lengthStress;
            string temperatureUnit;

            SettingLoader.Current.GetUnits(
                out umc,
                out forceUnit,
                out extenUnit,
                out stressUnit,
                out strainUnit,
                out timeUnit,
                out specStress,
                out lengthStress,
                out temperatureUnit
                );

            CurrentUnitCategory = UnitMainCategories.MKS;
            CurrentUnitCategory = (UnitMainCategories)Enum.Parse(typeof(UnitMainCategories), umc);

            ForceUnit = forceUnit;
            ExtensionUnit = extenUnit;
            StressUnit = stressUnit;
            StrainUnit = strainUnit;
            TimeUnit = timeUnit;
            MassStressUnit = specStress;
            LengthStressUnit = lengthStress;
            TemperatureUnit = temperatureUnit;
        }

        static void LoadNewCategorySelectedUnits(UnitMainCategories mainCategory)
        {
            string forceUnit;
            string extenUnit;
            string stressUnit;
            string strainUnit;
            string timeUnit;
            string specificStressUnit;
            string lengthStressUnit;
            string temperatureUnit;

            using (var sl = SettingLoader.Current)
            {
                sl.LoadSelectedUnits(
                            mainCategory.ToString(),
                            out forceUnit,
                            out extenUnit,
                            out stressUnit,
                            out strainUnit,
                            out timeUnit, out specificStressUnit, out lengthStressUnit,
                            out temperatureUnit);
            }
            ForceUnit = forceUnit;
            ExtensionUnit = extenUnit;
            StressUnit = stressUnit;
            StrainUnit = strainUnit;
            TimeUnit = timeUnit;
            MassStressUnit = specificStressUnit;
            LengthStressUnit = lengthStressUnit;
            TemperatureUnit = temperatureUnit;

            SetDefaultForceUnit(forceUnit);
            SetDefaultExtenUnit(extenUnit);
            SetDefaultTemperatureUnit(temperatureUnit);
            SetStressUnit(StressUnit);
            SetMassStressUnit(MassStressUnit);
            SetLengthStressUnit(LengthStressUnit);
            SetStrainUnit(StrainUnit);
            SetTimeUnit(timeUnit);
        }

        public static string GetSpecialUnits(PointProperty pointProperty, out double m)
        {
            m = 1.0;
            switch (pointProperty)
            {
                case PointProperty.ForcePerLength:
                    m = ForceM / ExtenM;
                    return string.Format("({0}) / ({1})", ForceUnit, ExtensionUnit);

                case PointProperty.Energy:
                    m = ForceM * ExtenM;
                    return string.Format("{0} * {1}", ForceUnit, ExtensionUnit);

                case PointProperty.TangentModule:
                    m = StressM / StrainM;
                    return string.Format("({0}) / ({1})", StressUnit, StrainUnit);

                case PointProperty.SecantModule:
                    m = StressM / StrainM;
                    return string.Format("({0}) / ({1})", StressUnit, StrainUnit);

                case PointProperty.ForceRate:
                    m = ForceM / TimeM;
                    return string.Format("({0}) / ({1})", ForceUnit, TimeUnit);

                case PointProperty.ExtenRate:
                    m = ExtenM / TimeM;
                    return string.Format("({0}) / ({1})", ExtensionUnit, TimeUnit);

                case PointProperty.StressRate:
                    m = StressM / TimeM;
                    return string.Format("({0}) / ({1})", StressUnit, TimeUnit);

                case PointProperty.StrainRate:
                    m = StrainM / TimeM;
                    return string.Format("({0}) / ({1})", StrainUnit, TimeUnit);
            }

            if ((int)pointProperty == -20)
            {
                m = StressM / StrainM;
                return string.Format("({0}) / ({1})", StressUnit, StrainUnit);
            }
            return "";
        }

        public static string[] ForceUnits
        {
            get
            {
                return forceUnits.GetUnitNames();
            }
        }
        public static string[] ExtensionUnits
        {
            get
            {
                return extenUnits.GetUnitNames();
            }
        }

        public static string[] TemperatureUnits
        {
            get
            {
                return temperatureUnits.GetUnitNames();
            }
        }

        public static string[] StressUnits
        {
            get
            {
                return stressUnits.GetUnitNames();
            }
        }
        public static string[] MassStressUnits
        {
            get
            {
                return massStress.GetUnitNames();
            }
        }
        public static string[] LengthStressUnits
        {
            get
            {
                return lengthStress.GetUnitNames();
            }
        }

        public static string[] StrainUnits
        {
            get
            {
                return strainUnits.GetUnitNames();
            }
        }

        public static string[] TimeUnits
        {
            get
            {
                return Time.TimeUnits.UnitSet.GetUnitNames();
            }
        }

        public static string[] ForceControlUnits
        {
            get
            {
                return forceControl.GetUnitNames();
            }
        }
        public static string[] ExtenControlUnits
        {
            get
            {
                return extenControl.GetUnitNames();
            }
        }
        public static string[] StressControlUnits
        {
            get
            {
                return stressControl.GetUnitNames();
            }
        }
        public static string[] StrainControlUnits
        {
            get
            {
                return strainControl.GetUnitNames();
            }
        }

        public static string[] LengthStressControlUnits
        {
            get
            {
                return lengthStressControl.GetUnitNames();
            }
        }

        public static string[] MassStressControlUnits
        {
            get
            {
                return massStressControl.GetUnitNames();
            }
        }

        public static double SetDefaultForceUnit(string unit)
        {
            forceUnits.Initiate(unit);
            ForceM = forceUnits.M;
            return ForceM;
        }

        public static double SetDefaultExtenUnit(string unit)
        {
            extenUnits.Initiate(unit);
            ExtenM = extenUnits.M;
            return ExtenM;
        }

        public static double SetDefaultTemperatureUnit(string unit)
        {
            temperatureUnits.Initiate(unit);
            TemperatureM = temperatureUnits.M;
            return ExtenM;
        }

        public static double SetStressUnit(string unit)
        {
            stressUnits.Initiate(unit);
            StressM = stressUnits.M;
            return StressM;
        }

        public static double SetMassStressUnit(string unit)
        {
            massStress.Initiate(unit);
            MassStressM = massStress.M;
            return MassStressM;
        }

        public static double SetLengthStressUnit(string unit)
        {
            lengthStress.Initiate(unit);
            LengthStressM = lengthStress.M;
            return LengthStressM;
        }


        public static double SetStrainUnit(string unit)
        {
            strainUnits.Initiate(unit);
            StrainM = strainUnits.M;
            return StrainM;
        }

        public static double SetTimeUnit(string unit)
        {
            Time.TimeUnits.UnitSet.Initiate(unit);
            TimeM = Time.TimeUnits.UnitSet.M;
            return TimeM;
        }

        public static double SetTemperatureUnit(string unit)
        {
            temperatureUnits.Initiate(unit);
            TemperatureM = temperatureUnits.M;
            return TemperatureM;
        }


        public static double ConvertToBase(string value, string unit)
        {
            if (string.IsNullOrEmpty(value))
                value = "0";
            var val = double.Parse(value);

            if (forceUnits.Units.ContainsKey(unit))
                return forceUnits.ConvertToBaseUnit(val, unit);

            if (extenUnits.Units.ContainsKey(unit))
                return extenUnits.ConvertToBaseUnit(val, unit);

            if (stressUnits.Units.ContainsKey(unit))
                return stressUnits.ConvertToBaseUnit(val, unit);

            if (massStress.Units.ContainsKey(unit))
                return massStress.ConvertToBaseUnit(val, unit);

            if (lengthStress.Units.ContainsKey(unit))
                return lengthStress.ConvertToBaseUnit(val, unit);

            if (strainUnits.Units.ContainsKey(unit))
                return strainUnits.ConvertToBaseUnit(val, unit);

            if (Time.TimeUnits.UnitSet.Units.ContainsKey(unit))
                return Time.TimeUnits.UnitSet.ConvertToBaseUnit(val, unit);

            if (forceControl.Units.ContainsKey(unit))
                return forceControl.ConvertToBaseUnit(val, unit);

            if (extenControl.Units.ContainsKey(unit))
                return extenControl.ConvertToBaseUnit(val, unit);

            if (stressControl.Units.ContainsKey(unit))
                return stressControl.ConvertToBaseUnit(val, unit);

            if (lengthStressControl.Units.ContainsKey(unit))
                return lengthStressControl.ConvertToBaseUnit(val, unit);

            if (massStressControl.Units.ContainsKey(unit))
                return massStressControl.ConvertToBaseUnit(val, unit);


            return strainControl.Units.ContainsKey(unit) ? strainControl.ConvertToBaseUnit(val, unit) : double.Parse(value);
        }

        public static double ConvertToCurrent(string value, string unit)
        {
            var val = double.Parse(value);

            return ConvertToCurrent(val, unit);
        }

        public static double ConvertToCurrent(double val, string unit)
        {
            if (forceUnits.Units.ContainsKey(unit))
                return forceUnits.ConvertToUnit(val, unit);

            if (extenUnits.Units.ContainsKey(unit))
                return extenUnits.ConvertToUnit(val, unit);

            if (stressUnits.Units.ContainsKey(unit))
                return stressUnits.ConvertToUnit(val, unit);

            if (massStress.Units.ContainsKey(unit))
                return massStress.ConvertToUnit(val, unit);

            if (lengthStress.Units.ContainsKey(unit))
                return lengthStress.ConvertToUnit(val, unit);

            if (strainUnits.Units.ContainsKey(unit))
                return strainUnits.ConvertToUnit(val, unit);

            if (Time.TimeUnits.UnitSet.Units.ContainsKey(unit))
                return Time.TimeUnits.UnitSet.ConvertToUnit(val, unit);

            if (forceControl.Units.ContainsKey(unit))
                return forceControl.ConvertToUnit(val, unit);

            if (extenControl.Units.ContainsKey(unit))
                return extenControl.ConvertToUnit(val, unit);

            if (stressControl.Units.ContainsKey(unit))
                return stressControl.ConvertToUnit(val, unit);

            if (strainControl.Units.ContainsKey(unit))
                return strainControl.ConvertToUnit(val, unit);

            if (lengthStressControl.Units.ContainsKey(unit))
                return lengthStressControl.ConvertToUnit(val, unit);

            if (massStressControl.Units.ContainsKey(unit))
                return massStressControl.ConvertToUnit(val, unit);

            return val;
        }

        public static string GetUnit(TestControlMode testControlMode)
        {
            return GetUnit((MeasureType)testControlMode);
        }


        public static string GetUnit(MeasureType testControlMode)
        {
            switch (testControlMode)
            {
                case MeasureType.Force:
                    return ForceUnit;

                case MeasureType.Extension:
                    return ExtensionUnit;

                case MeasureType.Stress:
                case MeasureType.TrueStress:
                    return StressUnit;

                case MeasureType.Strain:
                case MeasureType.TrueStrain:
                    return StrainUnit;

                case MeasureType.Time:
                    return TimeUnit;
            }
            return "";
        }

        public static string TranslateUnitTitle(string unit)
        {
	        switch (unit.Replace('/', '_').Replace('(', '_').Replace(')', '_').Replace('%', '_'))
	        {
		        case "dN":
			        return Resources.ForceConvertor_UnitSet_dN;

		        case "gf":
			        return Resources.ForceConvertor_UnitSet_gf;

		        case "GN":
			        return Resources.ForceConvertor_UnitSet_GN;

		        case "Kgf":
			        return Resources.ForceConvertor_UnitSet_Kgf;

		        case "Klbf":
			        return Resources.ForceConvertor_UnitSet_Klbf;

		        case "kN":
			        return Resources.ForceConvertor_UnitSet_kN;

		        case "lbf":
			        return Resources.ForceConvertor_UnitSet_lbf;

		        case "Mlbf":
			        return Resources.ForceConvertor_UnitSet_Mlbf;

		        case "MN":
			        return Resources.ForceConvertor_UnitSet_MN;

		        case "N":
			        return Resources.ForceConvertor_UnitSet_N;

		        case "ozf":
			        return Resources.ForceConvertor_UnitSet_ozf;

		        case "Tonf":
			        return Resources.ForceConvertor_UnitSet_Tonf;


		        case "cm":
			        return Resources.LengthConvertor_UnitSet_cm;

		        case "ft":
			        return Resources.LengthConvertor_UnitSet_ft;

		        case "m":
			        return Resources.LengthConvertor_UnitSet_m;

		        case "mm":
			        return Resources.LengthConvertor_UnitSet_mm;

		        case "yd":
			        return Resources.LengthConvertor_UnitSet_yd;

		        case "in":
			        return Resources.LengthConvertor_UnitSet__in;

		        case "µm":
			        return Resources.LengthConvertor_UnitSet_µm;


		        case "GPa":
			        return Resources.StressConvertor_UnitSet_GPa;

		        case "kg_cm2":
			        return Resources.StressConvertor_UnitSet_kg_cm2;

		        case "kg_m2":
			        return Resources.StressConvertor_UnitSet_kg_m2;

		        case "kg_mm2":
			        return Resources.StressConvertor_UnitSet_kg_mm2;

		        case "kN_cm2":
			        return Resources.StressConvertor_UnitSet_kN_cm2;

		        case "kN_mm2":
			        return Resources.StressConvertor_UnitSet_kN_mm2;

		        case "kPa":
			        return Resources.StressConvertor_UnitSet_kPa;

		        case "ksi":
			        return Resources.StressConvertor_UnitSet_ksi;

		        case "MN_cm2":
			        return Resources.StressConvertor_UnitSet_MN_cm2;

		        case "MN_mm2":
			        return Resources.StressConvertor_UnitSet_MN_mm2;

		        case "MPa":
			        return Resources.StressConvertor_UnitSet_MPa;

		        case "N_cm2":
			        return Resources.StressConvertor_UnitSet_N_cm2;

		        case "N_mm2":
			        return Resources.StressConvertor_UnitSet_N_mm2;

		        case "Pa":
			        return Resources.StressConvertor_UnitSet_Pa;

		        case "psf":
			        return Resources.StressConvertor_UnitSet_psf;

		        case "psi":
			        return Resources.StressConvertor_UnitSet_psi;

		        case "Ton_cm2":
			        return Resources.StressConvertor_UnitSet_Ton_cm2;

		        case "Ton_m2":
			        return Resources.StressConvertor_UnitSet_Ton_m2;

		        case "Ton_mm2":
			        return Resources.StressConvertor_UnitSet_Ton_mm2;

		        case "tpsf":
			        return Resources.StressConvertor_UnitSet_tpsf;

		        case "tpsi":
			        return Resources.StressConvertor_UnitSet_tpsi;


		        case "cm_cm":
			        return Resources.StrainConvertor_UnitSet_cm_cm;

		        case "ft_ft":
			        return Resources.StrainConvertor_UnitSet_ft_ft;

		        case "in_in":
			        return Resources.StrainConvertor_UnitSet_in_in;

		        case "mm_mm":
			        return Resources.StrainConvertor_UnitSet_mm_mm;

		        case "m_m":
			        return Resources.StrainConvertor_UnitSet_m_m;

		        case "%":
			        return Resources.StrainConvertor_UnitSet_Percent;

		        case "yd_yd":
			        return Resources.StrainConvertor_UnitSet_yd_yd;

		        case "µm_µm":
			        return Resources.StrainConvertor_UnitSet_µm_µm;

		        case "µƐ":
			        return Resources.StrainConvertor_UnitSet_µƐ;

		        case "Ɛ":
			        return Resources.StrainConvertor_UnitSet_Ɛ;


		        case "cm_min":
			        return Resources.ExtenControlConvertor_UnitSet_cm_min;

		        case "cm_sec":
			        return Resources.ExtenControlConvertor_UnitSet_cm_sec;

		        case "ft_min":
			        return Resources.ExtenControlConvertor_UnitSet_ft_min;

		        case "ft_sec":
			        return Resources.ExtenControlConvertor_UnitSet_ft_sec;

		        case "in_min":
			        return Resources.ExtenControlConvertor_UnitSet_in_min;

		        case "in_sec":
			        return Resources.ExtenControlConvertor_UnitSet_in_sec;

		        case "mm_min":
			        return Resources.ExtenControlConvertor_UnitSet_mm_min;

		        case "mm_sec":
			        return Resources.ExtenControlConvertor_UnitSet_mm_sec;

		        case "m_min":
			        return Resources.ExtenControlConvertor_UnitSet_m_min;

		        case "m_sec":
			        return Resources.ExtenControlConvertor_UnitSet_m_sec;

		        case "yd_min":
			        return Resources.ExtenControlConvertor_UnitSet_yd_min;

		        case "yd_sec":
			        return Resources.ExtenControlConvertor_UnitSet_yd_sec;

		        case "µm_min":
			        return Resources.ExtenControlConvertor_UnitSet_µm_min;

		        case "µm_sec":
			        return Resources.ExtenControlConvertor_UnitSet_µm_sec;


		        case "gf_min":
			        return Resources.ForceControlConvertor_UnitSet_gf_min;

		        case "gf_sec":
			        return Resources.ForceControlConvertor_UnitSet_gf_sec;

		        case "Kgf_min":
			        return Resources.ForceControlConvertor_UnitSet_Kgf_min;

		        case "Kgf_sec":
			        return Resources.ForceControlConvertor_UnitSet_Kgf_sec;

		        case "Klbf_min":
			        return Resources.ForceControlConvertor_UnitSet_Klbf_min;

		        case "Klbf_sec":
			        return Resources.ForceControlConvertor_UnitSet_Klbf_sec;

		        case "kN_min":
			        return Resources.ForceControlConvertor_UnitSet_kN_min;

		        case "kN_sec":
			        return Resources.ForceControlConvertor_UnitSet_kN_sec;

		        case "lbf_min":
			        return Resources.ForceControlConvertor_UnitSet_lbf_min;

		        case "lbf_sec":
			        return Resources.ForceControlConvertor_UnitSet_lbf_sec;

		        case "N_min":
			        return Resources.ForceControlConvertor_UnitSet_N_min;

		        case "N_sec":
			        return Resources.ForceControlConvertor_UnitSet_N_sec;

		        case "ozf_min":
			        return Resources.ForceControlConvertor_UnitSet_ozf_min;

		        case "ozf_sec":
			        return Resources.ForceControlConvertor_UnitSet_ozf_sec;

		        case "Tonf_min":
			        return Resources.ForceControlConvertor_UnitSet_Tonf_min;

		        case "Tonf_sec":
			        return Resources.ForceControlConvertor_UnitSet_Tonf_sec;

		        case "MN_sec":
			        return Resources.ForceControlConvertor_UnitSet_MN_sec;

		        case "MN_min":
			        return Resources.ForceControlConvertor_UnitSet_MN_min;


		        case "GPa_min":
			        return Resources.StressControlConvertor_UnitSet_GPa_min;

		        case "GPa_sec":
			        return Resources.StressControlConvertor_UnitSet_GPa_sec;

		        case "kPa_min":
			        return Resources.StressControlConvertor_UnitSet_kPa_min;

		        case "kPa_sec":
			        return Resources.StressControlConvertor_UnitSet_kPa_sec;

		        case "ksi_min":
			        return Resources.StressControlConvertor_UnitSet_ksi_min;

		        case "ksi_sec":
			        return Resources.StressControlConvertor_UnitSet_ksi_sec;

		        case "MPa_min":
			        return Resources.StressControlConvertor_UnitSet_MPa_min;

		        case "MPa_sec":
			        return Resources.StressControlConvertor_UnitSet_MPa_sec;

		        case "Pa_min":
			        return Resources.StressControlConvertor_UnitSet_Pa_min;

		        case "Pa_sec":
			        return Resources.StressControlConvertor_UnitSet_Pa_sec;

		        case "psf_min":
			        return Resources.StressControlConvertor_UnitSet_psf_min;

		        case "psf_sec":
			        return Resources.StressControlConvertor_UnitSet_psf_sec;

		        case "psi_min":
			        return Resources.StressControlConvertor_UnitSet_psi_min;

		        case "psi_sec":
			        return Resources.StressControlConvertor_UnitSet_psi_sec;

		        case "tpsf_min":
			        return Resources.StressControlConvertor_UnitSet_tpsf_min;

		        case "tpsf_sec":
			        return Resources.StressControlConvertor_UnitSet_tpsf_sec;

		        case "tpsi_min":
			        return Resources.StressControlConvertor_UnitSet_tpsi_min;

		        case "tpsi_sec":
			        return Resources.StressControlConvertor_UnitSet_tpsi_sec;

		        case "_N_cm2__sec":
			        return Resources.StressControlConvertor_UnitSet__N_cm2__sec;

		        case "_N_cm2__min":
			        return Resources.StressControlConvertor_UnitSet__N_cm2__min;

		        case "_N_mm2__sec":
			        return Resources.StressControlConvertor_UnitSet__N_mm2__sec;

		        case "_N_mm2__min":
			        return Resources.StressControlConvertor_UnitSet__N_mm2__min;

		        case "_kN_cm2__sec":
			        return Resources.StressControlConvertor_UnitSet__kN_cm2__sec;

		        case "_kN_cm2__min":
			        return Resources.StressControlConvertor_UnitSet__kN_cm2__min;

		        case "_kN_mm2__sec":
			        return Resources.StressControlConvertor_UnitSet__kN_mm2__sec;

		        case "_kN_mm2__min":
			        return Resources.StressControlConvertor_UnitSet__kN_mm2__min;

		        case "_MN_cm2__sec":
			        return Resources.StressControlConvertor_UnitSet__MN_cm2__sec;

		        case "_MN_cm2__min":
			        return Resources.StressControlConvertor_UnitSet__MN_cm2__min;

		        case "_MN_mm2__sec":
			        return Resources.StressControlConvertor_UnitSet__MN_mm2__sec;

		        case "_MN_mm2__min":
			        return Resources.StressControlConvertor_UnitSet__MN_mm2__min;


		        case "__sec":
			        return Resources.StrainControlConvertor_UnitSet___sec;

		        case "__min":
			        return Resources.StrainControlConvertor_UnitSet___min;

		        case "Ɛ_sec":
			        return Resources.StrainControlConvertor_UnitSet_Ɛ_sec;

		        case "Ɛ_min":
			        return Resources.StrainControlConvertor_UnitSet_Ɛ_min;

		        case "_mm_mm__sec":
			        return Resources.StrainControlConvertor_UnitSet__mm_mm__sec;

		        case "_mm_mm__min":
			        return Resources.StrainControlConvertor_UnitSet__mm_mm__min;

		        case "_cm_cm__sec":
			        return Resources.StrainControlConvertor_UnitSet__cm_cm__sec;

		        case "_cm_cm__min":
			        return Resources.StrainControlConvertor_UnitSet__cm_cm__min;

		        case "_m_m__sec":
			        return Resources.StrainControlConvertor_UnitSet__m_m__sec;

		        case "_m_m__min":
			        return Resources.StrainControlConvertor_UnitSet__m_m__min;

		        case "sec":
			        return Resources.TimeUnits_UnitSet_sec;

		        case "min":
			        return Resources.TimeUnits_UnitSet_min;

		        case "h":
			        return Resources.TimeUnits_UnitSet_h;

		        case "N_Tex":
			        return Resources.MassStress_UnitSet_N_Tex;

		        case "N_Denier":
			        return Resources.MassStress_UnitSet_N_Denier;

		        case "cN_Tex":
			        return Resources.MassStress_UnitSet_cN_Tex;

		        case "cN_Denier":
			        return Resources.MassStress_UnitSet_cN_Denier;

		        case "dN_Tex":
			        return Resources.MassStress_UnitSet_dN_Tex;

		        case "dN_Denier":
			        return Resources.MassStress_UnitSet_dN_Denier;

		        case "grf_Denier":
			        return Resources.MassStress_UnitSet_grf_Denier;

		        case "kgf_Denier":
			        return Resources.MassStress_UnitSet_kgf_Denier;

		        case "kgf_Tex":
			        return Resources.MassStress_UnitSet_kgf_Tex;

		        case "grf_Tex":
			        return Resources.MassStress_UnitSet_grf_Tex;

		        case "Klbf_in":
			        return Resources.LengthStress_UnitSet_Klbf_in;

		        case "N_mm":
			        return Resources.LengthStress_UnitSet_N_mm;

		        case "N_cm":
			        return Resources.LengthStress_UnitSet_N_cm;

		        case "KN_cm":
			        return Resources.LengthStress_UnitSet_KN_cm;

		        case "grf_cm": 
			        return Resources.LengthStress_UnitSet_grf_cm;

		        case "grf_mm": 
			        return Resources.LengthStress_UnitSet_grf_mm;

		        case "kN_mm":
			        return Resources.LengthStress_UnitSet_kN_mm;
                    
		        case "kgf_cm": 
			        return Resources.LengthStress_UnitSet_kgf_cm;

		        case "kgf_mm":
			        return Resources.LengthStress_UnitSet_kgf_mm;

		        case "lbf_in":
			        return Resources.LengthStress_UnitSet_lbf_in;

				case "\u00b0C":
			        return Resources.TemperatureConvertor_UnitSet__C;

		        default:
			        return unit;

	        }
        }

        public static Dictionary<string, string> ToDictionary(this List<string> list)
        {
            var dic = new Dictionary<string, string>(list.Count);
            foreach (var key in list)
            {
	            dic.Add(key, TranslateUnitTitle(key));
            }

			return dic;
        }

        public static Dictionary<string, string> ToDictionary(this string[] list)
        {
            var dic = new Dictionary<string, string>(list.Length);
            foreach (var key in list)
            {
                dic.Add(key, TranslateUnitTitle(key));
            }

            return dic;
        }

    }
}