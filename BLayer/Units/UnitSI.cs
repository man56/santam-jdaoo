using System.Collections.Generic;
using STM.Properties;

//Force : Newton
//Stress : Mpa
//extention : mm
//speed : mm/min
//strain : mm/mm
//force control : N/min
//exten control : mm/min
//stress control MPa/min
//strain control (%.mm,m,cm)/min
// speed control mm/min
namespace STM.BLayer.Units.SI
{
    public struct ForceConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { Resources.ForceConvertor_UnitSet_N, new Unit { Abbreviation = Resources.ForceConvertor_UnitSet_N, M = 1, Name = Resources.ForceConvertor_UnitSet_Newton } },
                                                                 { Resources.ForceConvertor_UnitSet_dN, new Unit { Abbreviation = Resources.ForceConvertor_UnitSet_dN, M = 0.1, Name = Resources.ForceConvertor_UnitSet_Deci_Newton } },
                                                                 { Resources.ForceConvertor_UnitSet_kN, new Unit { Abbreviation = "kN", M = 0.001, Name = Resources.ForceConvertor_UnitSet_Kilo_newton } },
                                                                 { Resources.ForceConvertor_UnitSet_MN, new Unit { Abbreviation = Resources.ForceConvertor_UnitSet_MN, M = 1.0e-6, Name = Resources.ForceConvertor_UnitSet_Mega_newton } },
                                                                 { Resources.ForceConvertor_UnitSet_GN, new Unit { Abbreviation = Resources.ForceConvertor_UnitSet_GN, M = 1.0e-9, Name = Resources.ForceConvertor_UnitSet_Giga_newton } }
                                                             });
    }

    public struct ExtenConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { Resources.LengthConvertor_UnitSet_mm, new Unit { Abbreviation = Resources.LengthConvertor_UnitSet_mm, M = 1, Name = Resources.ExtenConvertor_UnitSet_milimeter } },
                                                                 { Resources.LengthConvertor_UnitSet_cm, new Unit { Abbreviation = Resources.LengthConvertor_UnitSet_cm, M = 0.1, Name = Resources.ExtenConvertor_UnitSet_cantimeter } },
                                                                 { Resources.LengthConvertor_UnitSet_m, new Unit { Abbreviation = Resources.LengthConvertor_UnitSet_m, M = 0.001, Name = Resources.ExtenConvertor_UnitSet_meter } },
                                                             });
    }

    public struct StressConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                                                                                                              {
                                                                 { Resources.StressConvertor_UnitSet_Pa, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_Pa, M = 1e6, Name = Resources.StressConvertor_UnitSet_Pascal } },
                                                                 { Resources.StressConvertor_UnitSet_kPa, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_kPa, M = 1e3, Name = Resources.StressConvertor_UnitSet_Kilo_Pascal } },
                                                                 { Resources.StressConvertor_UnitSet_MPa, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_MPa, M = 1.0, Name = Resources.StressConvertor_UnitSet_Mega_Passcal } },////
                                                                 { Resources.StressConvertor_UnitSet_GPa, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_GPa, M = 0.001, Name = Resources.StressConvertor_UnitSet_Giga_Passcal } },
                                                                 { "N/cm2", new Unit { Abbreviation = Resources.StressConvertor_UnitSet_N_cm2, M = 100, Name = "N/cm2" } },
                                                                 { Resources.StressConvertor_UnitSet_N_mm2, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_N_mm2, M = 1.0, Name = Resources.StressConvertor_UnitSet_N_mm2 } },
                                                                 { "kN/cm2", new Unit { Abbreviation = Resources.StressConvertor_UnitSet_kN_cm2, M = 0.1, Name = "kN/cm2" } },
                                                                 { Resources.StressConvertor_UnitSet_kN_mm2, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_kN_mm2, M = 0.001, Name = Resources.StressConvertor_UnitSet_kN_mm2 } },
                                                                 { Resources.StressConvertor_UnitSet_MN_cm2, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_MN_cm2, M = 1e-4, Name = Resources.StressConvertor_UnitSet_MN_cm2 } },
                                                                 { Resources.StressConvertor_UnitSet_MN_mm2, new Unit { Abbreviation = Resources.StressConvertor_UnitSet_MN_mm2, M = 1e-6, Name = Resources.StressConvertor_UnitSet_MN_mm2 } },
                                                             });
    }

    public struct MassStress
    {
        public static readonly UnitSet UnitSet= new UnitSet(new Dictionary<string, Unit>
        {
                                                                 { Resources.MassStress_UnitSet_cN_Denier, new Unit { Abbreviation = Resources.MassStress_UnitSet_cN_Denier, M = 100 } },
                                                                 { Resources.MassStress_UnitSet_dN_Denier, new Unit { Abbreviation = Resources.MassStress_UnitSet_dN_Denier, M = 10 } },
                                                                 { Resources.MassStress_UnitSet_N_Denier, new Unit { Abbreviation = Resources.MassStress_UnitSet_N_Denier, M = 1.0 } },////
                                                                 { Resources.MassStress_UnitSet_cN_Tex, new Unit { Abbreviation = Resources.MassStress_UnitSet_cN_Tex, M = 100/0.11111 } },
                                                                 { Resources.MassStress_UnitSet_dN_Tex, new Unit { Abbreviation = Resources.MassStress_UnitSet_dN_Tex, M = 10/0.1111 } },
                                                                 { Resources.MassStress_UnitSet_N_Tex, new Unit { Abbreviation = Resources.MassStress_UnitSet_N_Tex, M = 1/0.11111 } },////
            }); 
    }

    public struct MassStressControl
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.MassStressControl_UnitSet__cN_Denier__sec, new Unit {Abbreviation =Resources.MassStressControl_UnitSet__cN_Denier__sec, M = 100 / 60.0}},
                {Resources.MassStressControl_UnitSet__cN_Denier__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__cN_Denier__min, M = 100}},
                {Resources.MassStressControl_UnitSet__dN_Denier__sec, new Unit {Abbreviation =Resources.MassStressControl_UnitSet__dN_Denier__sec, M = 10/60.0}},
                {Resources.MassStressControl_UnitSet__dN_Denier__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__dN_Denier__min, M = 10}},
                {Resources.MassStressControl_UnitSet__N_Denier__sec, new Unit {Abbreviation =Resources.MassStressControl_UnitSet__N_Denier__sec, M = 1.0/ 60}}, ////
                {Resources.MassStressControl_UnitSet__N_Denier__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__N_Denier__min, M = 1.0}},
                {Resources.MassStressControl_UnitSet__cN_Tex__sec, new Unit {Abbreviation =Resources.MassStressControl_UnitSet__cN_Tex__sec, M = 100/0.11111/60}},
                {Resources.MassStressControl_UnitSet__cN_Tex__min, new Unit {Abbreviation =Resources.MassStressControl_UnitSet__cN_Tex__min, M = 100/0.11111}},
                {Resources.MassStressControl_UnitSet__dN_Tex__sec, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__dN_Tex__sec, M = 10/0.1111/60}},
                {Resources.MassStressControl_UnitSet__N_Tex__min, new Unit {Abbreviation =Resources.MassStressControl_UnitSet__N_Tex__min, M = 1/0.11111}}, ////
            });
    }

    public struct LengthStress
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.LengthStress_UnitSet_N_mm, new Unit {Abbreviation = Resources.LengthStress_UnitSet_N_mm, M = 1}},
                {Resources.LengthStress_UnitSet_kN_mm, new Unit {Abbreviation =Resources.LengthStress_UnitSet_kN_mm, M = 0.001}},
                {Resources.LengthStress_UnitSet_N_cm, new Unit {Abbreviation = Resources.LengthStress_UnitSet_N_cm,M  = 10}}, ////
                {Resources.LengthStress_UnitSet_KN_cm, new Unit {Abbreviation =Resources.LengthStress_UnitSet_KN_cm, M = 0.01}}
            });
    }

    public struct LengthStressControl
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.LengthStressControl_UnitSet__N_mm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__N_mm__sec, M = 1.0/60}},
                {Resources.LengthStressControl_UnitSet__N_mm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__N_mm__min, M = 1.0}},
                {Resources.LengthStressControl_UnitSet__kN_mm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kN_mm__sec, M = (1e-3)/60.0}},
                {Resources.LengthStressControl_UnitSet__kN_mm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kN_mm__min, M = (1e-3)}},
                {Resources.LengthStressControl_UnitSet__N_cm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__N_cm__sec, M = 10.0/60}}, ////
                {Resources.LengthStressControl_UnitSet__N_cm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__N_cm__min, M = 10.0}}, ////
                {Resources.LengthStressControl_UnitSet__kN_cm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kN_cm__sec, M = 0.01/60}},
                {Resources.LengthStressControl_UnitSet__kN_cm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kN_cm__min, M = 0.01}}
            });
    }

    public struct StrainConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { Resources.StrainConvertor_UnitSet_Percent, new Unit { Abbreviation = Resources.StrainConvertor_UnitSet_Percent, M = 100, Name = "Percent" } },
                                                                 { Resources.StrainConvertor_UnitSet_Ɛ, new Unit { Abbreviation = Resources.StrainConvertor_UnitSet_Ɛ, M = 1, Name = Resources.StrainConvertor_UnitSet_Ɛ_Name } },
                                                                 { Resources.StrainConvertor_UnitSet_µƐ, new Unit { Abbreviation =  Resources.StrainConvertor_UnitSet_µƐ, M = 1e6, Name =  Resources.StrainConvertor_UnitSet_µƐ_Name} },
                                                                 { Resources.StrainConvertor_UnitSet_mm_mm, new Unit { Abbreviation = Resources.StrainConvertor_UnitSet_mm_mm, M = 1, Name =  Resources.StrainConvertor_UnitSet_mm_mm_Name } },
                                                                 { Resources.StrainConvertor_UnitSet_cm_cm_Name, new Unit { Abbreviation = Resources.StrainConvertor_UnitSet_cm_cm, M = 1, Name = Resources.StrainConvertor_UnitSet_cm_cm_Name } },
                                                                 {  Resources.StrainConvertor_UnitSet_m_m, new Unit { Abbreviation = Resources.StrainConvertor_UnitSet_m_m, M = 1, Name = Resources.StrainConvertor_UnitSet_m_m_Name } },
                                                             });
    }

    public struct ForceControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { Resources.ForceControlConvertor_UnitSet_N_sec, new Unit { Abbreviation = Resources.ForceControlConvertor_UnitSet_N_sec, M = 1.0/60, Name = Resources.ForceControlConvertor_UnitSet_Newton_per_sec } },
                                                                 { Resources.ForceControlConvertor_UnitSet_kN_sec, new Unit { Abbreviation = Resources.ForceControlConvertor_UnitSet_kN_sec, M = (1e-3)/60.0, Name = Resources.ForceControlConvertor_UnitSet_Kilo_newton_per_sec } },
                                                                 { Resources.ForceControlConvertor_UnitSet_MN_sec, new Unit { Abbreviation = Resources.ForceControlConvertor_UnitSet_MN_sec, M = (1e-6)/60.0, Name = Resources.ForceControlConvertor_UnitSet_Mega_newton_per_sec } },
                                                                 { Resources.ForceControlConvertor_UnitSet_N_min, new Unit { Abbreviation = Resources.ForceControlConvertor_UnitSet_N_min, M = 1.0, Name = Resources.ForceControlConvertor_UnitSet_Newton_per_min } },
                                                                 { Resources.ForceControlConvertor_UnitSet_kN_min, new Unit { Abbreviation = Resources.ForceControlConvertor_UnitSet_kN_min, M = 1.0 * (1e-3), Name = Resources.ForceControlConvertor_UnitSet_Kilo_newton_per_min } },
                                                                 { Resources.ForceControlConvertor_UnitSet_MN_min, new Unit { Abbreviation = Resources.ForceControlConvertor_UnitSet_MN_min, M = 1.0 * (1e-6), Name = Resources.ForceControlConvertor_UnitSet_Mega_newton_per_min } }
                                                             });
    }

    public struct StressControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                                                                                                              {
                                                                 { Resources.StressControlConvertor_UnitSet_Pa_sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_Pa_sec, M = 1e6/60.0, Name = Resources.StressControlConvertor_UnitSet_Pascal_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet_kPa_sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_kPa_sec, M = (1e3)/60.0, Name = Resources.StressControlConvertor_UnitSet_Kilo_pascal_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet_MPa_sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_MPa_sec, M = 1.0/60.0, Name = Resources.StressControlConvertor_UnitSet_Mega_passcal_per_sec_Name } }, //
                                                                 { Resources.StressControlConvertor_UnitSet_GPa_sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_GPa_sec, M = (1e-3)/60.0, Name = Resources.StressControlConvertor_UnitSet_Giga_passcal_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet__N_cm2__sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__N_cm2__sec, M = 100/60.0, Name = Resources.StressControlConvertor_UnitSet_N_cm2_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet__N_mm2__sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__N_mm2__sec, M = 1.0/60.0, Name = Resources.StressControlConvertor_UnitSet_N_mm2_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet__kN_cm2__sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__kN_cm2__sec, M = 0.1/60.0, Name = Resources.StressControlConvertor_UnitSet_kN_cm2_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet__kN_mm2__sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__kN_mm2__sec, M = (1e-3)/60.0, Name = Resources.StressControlConvertor_UnitSet_kN_mm2_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet__MN_cm2__sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__MN_cm2__sec, M = (1e-4)/60.0, Name = Resources.StressControlConvertor_UnitSet_MN_cm2_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet__MN_mm2__sec, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__MN_mm2__sec, M = (1e-6)/60.0, Name = Resources.StressControlConvertor_UnitSet_MN_mm2_per_sec_Name } },
                                                                 { Resources.StressControlConvertor_UnitSet_Pa_min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_Pa_min, M = 1e6, Name = Resources.StressControlConvertor_UnitSet_Pascal_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet_kPa_min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_kPa_min, M = 1e3, Name = Resources.StressControlConvertor_UnitSet_Kilo_pascal_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet_MPa_min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_MPa_min, M = 1.0, Name = Resources.StressControlConvertor_UnitSet_Mega_passcal_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet_GPa_min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet_GPa_min, M = 0.001, Name = Resources.StressControlConvertor_UnitSet_Giga_passcal_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet__N_cm2__min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__N_cm2__min, M = 100, Name = Resources.StressControlConvertor_UnitSet_N_cm2_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet__N_mm2__min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__N_mm2__min, M = 1.0, Name = Resources.StressControlConvertor_UnitSet_N_mm2_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet__kN_cm2__min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__kN_cm2__min, M = 0.1, Name = Resources.StressControlConvertor_UnitSet_kN_cm2_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet__kN_mm2__min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__kN_mm2__min, M = 1e-3, Name = Resources.StressControlConvertor_UnitSet_kN_mm2_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet__MN_cm2__min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__MN_cm2__min, M = 1e-4, Name = Resources.StressControlConvertor_UnitSet_MN_cm2_per_min } },
                                                                 { Resources.StressControlConvertor_UnitSet__MN_mm2__min, new Unit { Abbreviation = Resources.StressControlConvertor_UnitSet__MN_mm2__min, M = 1e-6, Name = Resources.StressControlConvertor_UnitSet_MN_mm2r_per_min } },
                                                             });
    }

    public struct StrainControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { Resources.StrainControlConvertor_UnitSet___sec, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet___sec, M = 100/60.0, Name = Resources.StrainControlConvertor_UnitSet_Percent_per_sec_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet_Ɛ_sec, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet_Ɛ_sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_Ɛ_per_sec_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet__mm_mm__sec, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet__mm_mm__sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_mm_per_mm_per_sec_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet__cm_cm__sec, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet__cm_cm__sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_cm_per_cm_per_sec_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet__m_m__sec, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet__m_m__sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_m_per_m_per_sec_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet___min, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet___min, M = 100.0, Name = Resources.StrainControlConvertor_UnitSet_Percent_per_min_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet_Ɛ_min, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet_Ɛ_min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_Ɛ_per_min_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet__mm_mm__min, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet__mm_mm__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_mm_per_mm_per_min_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet__cm_cm__min, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet__cm_cm__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_cm_per_cm_per_min_Name } },
                                                                 { Resources.StrainControlConvertor_UnitSet__m_m__min, new Unit { Abbreviation = Resources.StrainControlConvertor_UnitSet__m_m__min, M =  1.0, Name = Resources.StrainControlConvertor_UnitSet_m_per_m_per_min_Name } }
                                                             });
    }

    public struct ExtenControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                                                             {
                                                                 { Resources.ExtenControlConvertor_UnitSet_mm_min, new Unit { Abbreviation = Resources.ExtenControlConvertor_UnitSet_mm_min, M = 1.0, Name = Resources.SpeedControlConvertor_UnitSet_mm_per_min_Name } },
                                                                 { Resources.ExtenControlConvertor_UnitSet_cm_min, new Unit { Abbreviation = Resources.ExtenControlConvertor_UnitSet_cm_min, M = 0.1, Name = Resources.SpeedControlConvertor_UnitSet_cm_per_min_Name } },
                                                                 { Resources.ExtenControlConvertor_UnitSet_m_min, new Unit { Abbreviation = Resources.ExtenControlConvertor_UnitSet_m_min, M = 0.001, Name = Resources.SpeedControlConvertor_UnitSet_m_per_min_Name } },
                                                                 { Resources.ExtenControlConvertor_UnitSet_mm_sec, new Unit { Abbreviation = Resources.ExtenControlConvertor_UnitSet_mm_sec, M = 1/60.0, Name = Resources.SpeedControlConvertor_UnitSet_mm_per_sec_Name } },
                                                                 { Resources.ExtenControlConvertor_UnitSet_cm_sec, new Unit { Abbreviation = Resources.ExtenControlConvertor_UnitSet_cm_sec, M = 0.1/60, Name = Resources.SpeedControlConvertor_UnitSet_cm_per_sec_Name } },
                                                                 { Resources.ExtenControlConvertor_UnitSet_m_sec, new Unit { Abbreviation = Resources.ExtenControlConvertor_UnitSet_m_sec, M = 0.001/60, Name = Resources.SpeedControlConvertor_UnitSet_m_per_sec_Name } },
                                                             });
    }

	public struct TemperatureConvertor
	{
		public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
						{
							{Resources.TemperatureConvertor_UnitSet__C, new Unit {Abbreviation = Resources.TemperatureConvertor_UnitSet__C, M = 1, Name = Resources.TemperatureConvertor_UnitSet_Celsius_Name}},
						});
	}

}

