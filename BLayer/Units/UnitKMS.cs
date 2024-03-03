using System.Collections.Generic;
using STM.Properties;

namespace STM.BLayer.Units.MKS
{
    public struct ForceConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.ForceConvertor_UnitSet_gf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_gf, M = 101.971621298, Name = Resources.ForceConvertor_UnitSet_Gram_force}},
                            {Resources.ForceConvertor_UnitSet_Kgf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_Kgf, M = 0.101971621, Name = Resources.ForceConvertor_UnitSet_Kilo_gram_force}},
                            {Resources.ForceConvertor_UnitSet_Tonf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_Tonf, M = 0.000101971621, Name = Resources.ForceConvertor_UnitSet_Ton_force}}
                        });
    }
    
    public struct LengthConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.LengthConvertor_UnitSet_µm, new Unit {Abbreviation = Resources.LengthConvertor_UnitSet_µm, M = 1000.0, Name = Resources.LengthConvertor_UnitSet_Micro_meter}},
                            {Resources.LengthConvertor_UnitSet_mm, new Unit {Abbreviation =Resources.LengthConvertor_UnitSet_mm, M = 1.0, Name = Resources.LengthConvertor_UnitSet_Milimeter}},
                            {Resources.LengthConvertor_UnitSet_cm, new Unit {Abbreviation = Resources.LengthConvertor_UnitSet_cm, M = 0.1, Name = Resources.LengthConvertor_UnitSet_Centimeter}},
                            {Resources.LengthConvertor_UnitSet_m, new Unit {Abbreviation = Resources.LengthConvertor_UnitSet_m, M = 0.001, Name = Resources.LengthConvertor_UnitSet_Meter}}
                        });
    }

	public struct StressConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.StressConvertor_UnitSet_kg_cm2, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_kg_cm2, M = 10.19716213, Name = Resources.StressConvertor_UnitSet_kg_cm2_Name}},
                {Resources.StressConvertor_UnitSet_kg_mm2, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_kg_mm2, M = 0.101971621, Name = Resources.StressConvertor_UnitSet_kg_mm2_Name}},
                {Resources.StressConvertor_UnitSet_kg_m2, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_kg_m2, M = 101971.621297793, Name = Resources.StressConvertor_UnitSet_kg_m2_Name}},
                {Resources.StressConvertor_UnitSet_Ton_cm2, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_Ton_cm2, M = 0.01019716, Name = Resources.StressConvertor_UnitSet_Ton_cm2_Name}},
                {Resources.StressConvertor_UnitSet_Ton_mm2, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_Ton_mm2, M = 0.000101971621, Name = Resources.StressConvertor_UnitSet_Ton_mm2_Name}},
                {Resources.StressConvertor_UnitSet_Ton_m2, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_Ton_m2, M = 101.971621297, Name = Resources.StressConvertor_UnitSet_Ton_m2_Name}},
            });
    }

   public struct LengthStress
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.LengthStress_UnitSet_grf_mm, new Unit {Abbreviation = Resources.LengthStress_UnitSet_grf_mm, M = 101.971621}},
                {Resources.LengthStress_UnitSet_kgf_mm, new Unit {Abbreviation = Resources.LengthStress_UnitSet_kgf_mm, M = 0.101971621}},
                {Resources.LengthStress_UnitSet_grf_cm, new Unit {Abbreviation =Resources.LengthStress_UnitSet_grf_cm, M = 101.971621 * 10}},
                {Resources.LengthStress_UnitSet_kgf_cm, new Unit {Abbreviation =Resources.LengthStress_UnitSet_kgf_cm, M = 0.101971621 * 10}},
            });
    }
    public struct MassStress
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.MassStress_UnitSet_grf_Denier, new Unit {Abbreviation = Resources.MassStress_UnitSet_grf_Denier, M = 101.971621298}},
                {Resources.MassStress_UnitSet_kgf_Denier, new Unit {Abbreviation = Resources.MassStress_UnitSet_kgf_Denier, M = 0.101971621}},
                {Resources.MassStress_UnitSet_grf_Tex, new Unit {Abbreviation = Resources.MassStress_UnitSet_grf_Tex, M = 101.971621298/0.1111}},
                {Resources.MassStress_UnitSet_kgf_Tex, new Unit {Abbreviation = Resources.MassStress_UnitSet_kgf_Tex, M = 0.101971621/0.1111}},
            });
    }

    public struct MassStressControl
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.MassStressControl_UnitSet__grf_Denier__sec, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__grf_Denier__sec, M =  101.971621298/60}},
                {Resources.MassStressControl_UnitSet__grf_Denier__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__grf_Denier__min, M =  101.971621298}},
                {Resources.MassStressControl_UnitSet__kgf_Denier__sec, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__kgf_Denier__sec, M = 0.101971621 /60}},
                {Resources.MassStressControl_UnitSet__kgf_Denier__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__kgf_Denier__min, M = 0.101971621}},
                {Resources.MassStressControl_UnitSet__grf_Tex__sec, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__grf_Tex__sec, M = 101.971621298/0.1111 / 60}},
                {Resources.MassStressControl_UnitSet__grf_Tex__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__grf_Tex__min, M = 101.971621298/0.1111}},
                {Resources.MassStressControl_UnitSet__kgf_Tex__sec, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__kgf_Tex__sec, M = 0.101971621/0.1111 / 60}},
                {Resources.MassStressControl_UnitSet__kgf_Tex__min, new Unit {Abbreviation = Resources.MassStressControl_UnitSet__kgf_Tex__min, M = 0.101971621/0.1111}},
            });
    }

 
    
    public struct StrainConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StrainConvertor_UnitSet_Percent, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_Percent, M = 100, Name = Resources.StrainConvertor_UnitSet_Percent_Name}},
                            {Resources.StrainConvertor_UnitSet_Ɛ, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_Ɛ, M = 1, Name = Resources.StrainConvertor_UnitSet_Ɛ_Name}},
                            {Resources.StrainConvertor_UnitSet_µƐ, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_µƐ, M = 1e-6, Name = Resources.StrainConvertor_UnitSet_µƐ_Name}},
                            {Resources.StrainConvertor_UnitSet_µm_µm, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_µm_µm, M = 1, Name = Resources.StrainConvertor_UnitSet_µm_µm_Name}},
                            {Resources.StrainConvertor_UnitSet_mm_mm, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_mm_mm, M = 1, Name = Resources.StrainConvertor_UnitSet_mm_mm_Name}},
                            {Resources.StrainConvertor_UnitSet_cm_cm, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_cm_cm, M = 1, Name = Resources.StrainConvertor_UnitSet_cm_cm_Name}},
                            {Resources.StrainConvertor_UnitSet_m_m, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_m_m, M = 1, Name = Resources.StrainConvertor_UnitSet_m_m_Name}}
                        });
    }

    public struct ForceControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.ForceControlConvertor_UnitSet_gf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_gf_sec, M = 101.971621298/60, Name = Resources.ForceControlConvertor_UnitSet_Gram_force_per_sec}},
                {Resources.ForceControlConvertor_UnitSet_Kgf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Kgf_sec, M = 0.101971621/60, Name = Resources.ForceControlConvertor_UnitSet_Kilo_gram_force_per_sec}},
                {Resources.ForceControlConvertor_UnitSet_Tonf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Tonf_sec, M = 0.000101971621/60, Name = Resources.ForceControlConvertor_UnitSet_Ton_force_per_sec}},
                {Resources.ForceControlConvertor_UnitSet_gf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_gf_min, M = 101.971621298, Name = Resources.ForceControlConvertor_UnitSet_Gram_force_per_min}},
                {Resources.ForceControlConvertor_UnitSet_Kgf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Kgf_min, M = 0.101971621, Name = Resources.ForceControlConvertor_UnitSet_Kilo_gram_force_per_min}},
                {Resources.ForceControlConvertor_UnitSet_Tonf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Tonf_min, M = 0.000101971621, Name = Resources.ForceControlConvertor_UnitSet_Ton_force_per_min}},
            });
    }

    public struct LengthStressControl
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.LengthStressControl_UnitSet__grf_mm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__grf_mm__sec, M = 101.971621 / 60}},
                {Resources.LengthStressControl_UnitSet__grf_mm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__grf_mm__min, M = 101.971621}},
                {Resources.LengthStressControl_UnitSet__kgf_mm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kgf_mm__sec, M = 0.101971621 / 60}},
                {Resources.LengthStressControl_UnitSet__kgf_mm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kgf_mm__min, M = 0.101971621}},
                {Resources.LengthStressControl_UnitSet__grf_cm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__grf_cm__sec, M = 101.971621*10 / 60}},
                {Resources.LengthStressControl_UnitSet__grf_cm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__grf_cm__min, M = 101.971621*10}},
                {Resources.LengthStressControl_UnitSet__kgf_cm__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kgf_cm__sec, M = 0.101971621 / 60}},
                {Resources.LengthStressControl_UnitSet__kgf_cm__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__kgf_cm__min, M = 0.101971621}},
            });
    }

    public struct ExtenControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.ExtenControlConvertor_UnitSet_µm_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_µm_sec, M = 1000.0/60, Name = Resources.ExtenControlConvertor_UnitSet_Micro_meter_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_mm_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_mm_sec, M = 1/60.0, Name = Resources.ExtenControlConvertor_UnitSet_Milimeter_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_cm_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_cm_sec, M = 0.1/60, Name = Resources.ExtenControlConvertor_UnitSet_Centimeter_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_m_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_m_sec, M = 0.001/60, Name = Resources.ExtenControlConvertor_UnitSet_Meter_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_µm_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_µm_min, M = 1000.0, Name = Resources.ExtenControlConvertor_UnitSet_Micro_meter_per_min}},
                            {Resources.ExtenControlConvertor_UnitSet_mm_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_mm_min, M = 1.0, Name = Resources.ExtenControlConvertor_UnitSet_Milimeter_per_min}},
                            {Resources.ExtenControlConvertor_UnitSet_cm_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_cm_min, M = 0.1, Name = Resources.ExtenControlConvertor_UnitSet_Centimeter_per_min}},
                            {Resources.ExtenControlConvertor_UnitSet_m_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_m_min, M = 0.001, Name = Resources.ExtenControlConvertor_UnitSet_Meter_per_min}},
                        });
    }

    public struct StressControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StressControlConvertor_UnitSet__kg_cm2__sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__kg_cm2__sec, M = 10.19716213/60, Name = Resources.StressControlConvertor_UnitSet_kg_cm2_per_sec_Name}},
                            {Resources.StressControlConvertor_UnitSet__kg_mm2__sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__kg_mm2__sec, M = 0.101971621/60, Name = Resources.StressControlConvertor_UnitSet_kg_mm2_per_sec_Name}},
                            {Resources.StressControlConvertor_UnitSet__kg_m2__sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__kg_m2__sec, M = 101971.621297793/60, Name = Resources.StressControlConvertor_UnitSet_kg_m2_per_sec_Name}},
                            {Resources.StressControlConvertor_UnitSet__Ton_cm2__sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__Ton_cm2__sec, M = 0.01019716/60, Name = Resources.StressControlConvertor_UnitSet_Ton_cm2_per_sec_Name}},
                            {Resources.StressControlConvertor_UnitSet__Ton_mm2__sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__Ton_mm2__sec, M = 0.000101971621/60, Name = Resources.StressControlConvertor_UnitSet_Ton_mm2_per_sec_Name}},
                            {Resources.StressControlConvertor_UnitSet__Ton_m2__sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__Ton_m2__sec, M = 101.971621297/60, Name = Resources.StressControlConvertor_UnitSet_Ton_m2_per_sec_Name}},
                            {Resources.StressControlConvertor_UnitSet__kg_cm2__min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__kg_cm2__min, M = 10.19716213, Name = Resources.StressControlConvertor_UnitSet_kg_cm2_per_min_Name}},
                            {Resources.StressControlConvertor_UnitSet__kg_mm2__min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__kg_mm2__min, M = 0.101971621, Name = Resources.StressControlConvertor_UnitSet_kg_mm2_per_min_Name}},
                            {Resources.StressControlConvertor_UnitSet__kg_m2__min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__kg_m2__min, M = 101971.621297793, Name = Resources.StressControlConvertor_UnitSet_kg_m2_per_min_Name}},
                            {Resources.StressControlConvertor_UnitSet__Ton_cm2__min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__Ton_cm2__min, M = 0.01019716, Name = Resources.StressControlConvertor_UnitSet_Ton_cm2_per_min_Name}},
                            {Resources.StressControlConvertor_UnitSet__Ton_mm2__min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__Ton_mm2__min, M = 0.000101971621, Name = Resources.StressControlConvertor_UnitSet_Ton_mm2_per_min_Name}},
                            {Resources.StressControlConvertor_UnitSet__Ton_m2__min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet__Ton_m2__min, M = 101.971621297, Name = Resources.StressControlConvertor_UnitSet_Ton_m2_per_min_Name}},
                        });
    }

   
    public struct StrainControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StrainControlConvertor_UnitSet___sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet___sec, M = 100/60.0, Name = Resources.StrainControlConvertor_UnitSet_Percent_per_sec_Name}},
                            {Resources.StrainControlConvertor_UnitSet_Ɛ_sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet_Ɛ_sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_Ɛ_per_sec_Name}},
                            {Resources.StrainControlConvertor_UnitSet__mm_mm__sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__mm_mm__sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_mm_mm_per_sec_Name}},
                            {Resources.StrainControlConvertor_UnitSet__cm_cm__sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__cm_cm__sec, M = 1/60.0, Name = Resources.StrainControlConvertor_UnitSet_cm_cm_per_sec_Name}},
                            {Resources.StrainControlConvertor_UnitSet__m_m__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__m_m__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_m_m_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet___min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet___min, M = 100.0, Name = Resources.StrainControlConvertor_UnitSet_Percent_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet_Ɛ_min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet_Ɛ_min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_Ɛ_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet__µm_µm__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__µm_µm__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_µm_µm_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet__mm_mm__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__mm_mm__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_mm_mm_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet__cm_cm__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__cm_cm__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_cm_cm_per_min_Name}}
                        });
    }

    public struct SpeedControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.ExtenControlConvertor_UnitSet_mm_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_mm_sec, M = 1.0/60, Name = Resources.SpeedControlConvertor_UnitSet_mm_per_sec_Name}},
                            {Resources.ExtenControlConvertor_UnitSet_cm_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_cm_sec, M = 0.1/60, Name = Resources.SpeedControlConvertor_UnitSet_cm_per_sec_Name}},
                            {Resources.ExtenControlConvertor_UnitSet_m_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_m_sec, M = 0.001/60, Name = Resources.SpeedControlConvertor_UnitSet_m_per_sec_Name}},
                            {Resources.ExtenControlConvertor_UnitSet_mm_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_mm_min, M = 1.0, Name = Resources.SpeedControlConvertor_UnitSet_mm_per_min_Name}},
                            {Resources.ExtenControlConvertor_UnitSet_cm_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_cm_min, M = 0.1, Name = Resources.SpeedControlConvertor_UnitSet_cm_per_min_Name}},
                            {Resources.ExtenControlConvertor_UnitSet_m_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_m_min, M = 0.001, Name = Resources.SpeedControlConvertor_UnitSet_m_per_min_Name}}
                        });
    }

	public struct TemperatureConvertor
	{
		public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
						{
							{Resources.TemperatureConvertor_UnitSet_C, new Unit {Abbreviation = Resources.TemperatureConvertor_UnitSet__C, M = 1, Name = Resources.TemperatureConvertor_UnitSet_Celsius_Name}},
						});
	}

}
