using System.Collections.Generic;
using STM.BLayer;
using STM.Properties;

namespace STM.BLayer.Units.BS
{
    public struct ForceConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.ForceConvertor_UnitSet_ozf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_ozf, M = 3.59694309, Name = Resources.ForceConvertor_UnitSet_Ounce_force}},
                            {Resources.ForceConvertor_UnitSet_lbf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_lbf, M = 0.224808943, Name = Resources.ForceConvertor_UnitSet_Pound_force}},
                            {Resources.ForceConvertor_UnitSet_Klbf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_Klbf, M = 0.224808943*1e-3, Name = Resources.ForceConvertor_UnitSet_Kilo_pound_force}},
                            {Resources.ForceConvertor_UnitSet_Mlbf, new Unit {Abbreviation = Resources.ForceConvertor_UnitSet_Mlbf, M = 0.224808943*1e-6, Name = Resources.ForceConvertor_UnitSet_Mega_pound_force}}
                        });
    }
    public struct LengthConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.LengthConvertor_UnitSet__in, new Unit {Abbreviation = Resources.LengthConvertor_UnitSet__in, M = 0.039370079, Name = Resources.LengthConvertor_UnitSet_Inch}},
                            {Resources.LengthConvertor_UnitSet_ft, new Unit {Abbreviation = Resources.LengthConvertor_UnitSet_ft, M = 0.00328084, Name = Resources.LengthConvertor_UnitSet_Foot}},
                            {Resources.LengthConvertor_UnitSet_yd, new Unit {Abbreviation = Resources.LengthConvertor_UnitSet_yd, M = 0.001093613, Name = Resources.LengthConvertor_UnitSet_Yard}},
                        });
    }

	public struct StressConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StressConvertor_UnitSet_psi, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_psi, M = 145.03773773, Name = Resources.StressConvertor_UnitSet_Pound_per_square_inch}},
                            {Resources.StressConvertor_UnitSet_ksi, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_ksi, M =0.145037738, Name = Resources.StressConvertor_UnitSet_Thousand_pounds_per_square_inch}},
                            {Resources.StressConvertor_UnitSet_psf, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_psf, M = 20885.43423312, Name = Resources.StressConvertor_UnitSet_Pound_per_square_foot}},
                            {Resources.StressConvertor_UnitSet_tpsi, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_tpsi, M = 0.072518869, Name = Resources.StressConvertor_UnitSet_Ton_per_square_inch}},
                            {Resources.StressConvertor_UnitSet_tpsf, new Unit {Abbreviation = Resources.StressConvertor_UnitSet_tpsf, M = 9.323854568, Name = Resources.StressConvertor_UnitSet_Ton_per_square_foot_}}
                        });
    }
    public struct MassStress
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
        {
                                                                 { Resources.MassStress_UnitSet_n_a, new Unit { Abbreviation = Resources.MassStress_UnitSet_n_a, M = 1} }
        });
    }
    public struct MassStressControl
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
        {
                                                                 { Resources.MassStress_UnitSet_n_a, new Unit { Abbreviation = Resources.MassStress_UnitSet_n_a, M = 1} }
        });
    }

    public struct LengthStress
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.LengthStress_UnitSet_lbf_in, new Unit {Abbreviation = Resources.LengthStress_UnitSet_lbf_in, M = 5.7101467289827539728205128205128  , Name = Resources.ForceConvertor_UnitSet_Pound_force}},
                {Resources.LengthStress_UnitSet_Klbf_in, new Unit {Abbreviation = Resources.LengthStress_UnitSet_Klbf_in, M = 5.7101467289827539728205128205128 * 1e-3, Name = Resources.ForceConvertor_UnitSet_Kilo_pound_force}},
            });
    }

   

    public struct StrainConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StrainConvertor_UnitSet_Percent, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_Percent, M = 100, Name = Resources.StrainConvertor_UnitSet_Percent_Name}},
                            {Resources.StrainConvertor_UnitSet_Ɛ_Name, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_Ɛ, M = 1, Name = Resources.StrainConvertor_UnitSet_Ɛ_Name}},
                            {Resources.StrainConvertor_UnitSet_µƐ, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_µƐ, M = 1e-6, Name = Resources.StrainConvertor_UnitSet_µƐ_Name}},
                            {Resources.StrainConvertor_UnitSet_in_in, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_in_in, M = 1, Name = Resources.StrainConvertor_UnitSet_in_in_Name}},
                            {Resources.StrainConvertor_UnitSet_ft_ft, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_ft_ft, M = 1, Name = Resources.StrainConvertor_UnitSet_ft_ft_Name}},
                            {Resources.StrainConvertor_UnitSet_yd_yd, new Unit {Abbreviation = Resources.StrainConvertor_UnitSet_yd_yd, M = 1, Name = Resources.StrainConvertor_UnitSet_yd_yd_Name}},
                        });
    }

    public struct ForceControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.ForceControlConvertor_UnitSet_ozf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_ozf_sec, M = 3.59694309/60, Name = Resources.ForceControlConvertor_UnitSet_Ounce_force_pre_sec_Name}},
                            {Resources.ForceControlConvertor_UnitSet_lbf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_lbf_sec, M = 0.224808943/60, Name = Resources.ForceControlConvertor_UnitSet_Pound_force_pre_sec_Name}},
                            {Resources.ForceControlConvertor_UnitSet_Klbf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Klbf_sec, M = 0.224808943/60*1e-3, Name = Resources.ForceControlConvertor_UnitSet_Kilo_pound_force_pre_sec_Name}},
                            {Resources.ForceControlConvertor_UnitSet_Mlbf_sec, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Mlbf_sec, M = 0.224808943/60*1e-6, Name = Resources.ForceControlConvertor_UnitSet_Mega_pound_force_pre_sec_Name}},
                            {Resources.ForceControlConvertor_UnitSet_ozf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_ozf_min, M = 3.59694309, Name = Resources.ForceControlConvertor_UnitSet_Ounce_force_pre_min_Name}},
                            {Resources.ForceControlConvertor_UnitSet_lbf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_lbf_min, M = 0.224808943, Name = Resources.ForceControlConvertor_UnitSet_Pound_force_pre_min_Name}},
                            {Resources.ForceControlConvertor_UnitSet_Klbf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Klbf_min, M = 0.224808943*(1e-3), Name = Resources.ForceControlConvertor_UnitSet_Kilo_pound_force_pre_min_Name}},
                            {Resources.ForceControlConvertor_UnitSet_Mlbf_min, new Unit {Abbreviation = Resources.ForceControlConvertor_UnitSet_Mlbf_min, M = 0.224808943*(1e-6), Name = Resources.ForceControlConvertor_UnitSet_Mega_pound_force_pre_min_Name}}
                        });
    }
    public struct LengthStressControl
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
            {
                {Resources.LengthStressControl_UnitSet__lbf_in__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__lbf_in__sec, M = 0.57643318717948717948717948717949 / 60  , Name = Resources.ForceConvertor_UnitSet_Pound_force}},
                {Resources.LengthStressControl_UnitSet__lbf_in__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__lbf_in__min, M = 0.57643318717948717948717948717949  , Name = Resources.ForceConvertor_UnitSet_Pound_force}},
                {Resources.LengthStressControl_UnitSet__Klbf_in__sec, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__Klbf_in__sec, M = 0.57643318717948717948717948717949 *1e-3 / 60, Name = Resources.ForceConvertor_UnitSet_Kilo_pound_force}},
                {Resources.LengthStressControl_UnitSet__Klbf_in__min, new Unit {Abbreviation = Resources.LengthStressControl_UnitSet__Klbf_in__min, M = 0.57643318717948717948717948717949 *1e-3, Name = Resources.ForceConvertor_UnitSet_Kilo_pound_force}}
            });
    }
    public struct ExtenControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.ExtenControlConvertor_UnitSet_in_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_in_sec, M = 0.039370079/60, Name = Resources.ExtenControlConvertor_UnitSet_Inch_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_ft_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_ft_sec, M = 0.00328084/60, Name = Resources.ExtenControlConvertor_UnitSet_Foot_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_yd_sec, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_yd_sec, M = 0.001093613/60, Name = Resources.ExtenControlConvertor_UnitSet_Yard_per_sec}},
                            {Resources.ExtenControlConvertor_UnitSet_in_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_in_min, M = 0.039370079, Name = Resources.ExtenControlConvertor_UnitSet_Inch_per_min}},
                            {Resources.ExtenControlConvertor_UnitSet_ft_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_ft_min, M = 0.00328084, Name = Resources.ExtenControlConvertor_UnitSet_Foot_per_min}},
                            {Resources.ExtenControlConvertor_UnitSet_yd_min, new Unit {Abbreviation = Resources.ExtenControlConvertor_UnitSet_yd_min, M = 0.001093613, Name = Resources.ExtenControlConvertor_UnitSet_Yard_per_min}},
                        });
    }
    public struct StressControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StressControlConvertor_UnitSet_psi_sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_psi_sec, M = 145.03773773/60, Name = Resources.StressControlConvertor_UnitSet_Pound_per_square_inch_per_sec}},
                            {Resources.StressControlConvertor_UnitSet_ksi_sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_ksi_sec, M = 0.145037738/60, Name = Resources.StressControlConvertor_UnitSet_Thousand_pounds_per_square_inch_per_sec}},
                            {Resources.StressControlConvertor_UnitSet_psf_sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_psf_sec, M = 20885.43423312/60, Name = Resources.StressControlConvertor_UnitSet_Pound_per_square_foot_per_sec}},
                            {Resources.StressControlConvertor_UnitSet_tpsi_sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_tpsi_sec, M = 0.072518869/60, Name = Resources.StressControlConvertor_UnitSet_Ton_per_square_inch_per_sec}},
                            {Resources.StressControlConvertor_UnitSet_tpsf_sec, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_tpsf_sec, M = 9.323854568/60, Name = Resources.StressControlConvertor_UnitSet_Ton_per_square_foot_per_sec}},
                            {Resources.StressControlConvertor_UnitSet_psi_min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_psi_min, M = 145.03773773, Name = Resources.StressControlConvertor_UnitSet_Pound_per_square_inch_per_min}},
                            {Resources.StressControlConvertor_UnitSet_ksi_min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_ksi_min, M = 0.145037738, Name = Resources.StressControlConvertor_UnitSet_Thousand_pounds_per_square_inch_per_min}},
                            {Resources.StressControlConvertor_UnitSet_psf_min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_psf_min, M = 20885.43423312, Name = Resources.StressControlConvertor_UnitSet_Pound_per_square_foot_per_min}},
                            {Resources.StressControlConvertor_UnitSet_tpsi_min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_tpsi_min, M = 0.072518869, Name = Resources.StressControlConvertor_UnitSet_Ton_per_square_inch_per_min}},
                            {Resources.StressControlConvertor_UnitSet_tpsf_min, new Unit {Abbreviation = Resources.StressControlConvertor_UnitSet_tpsf_min, M = 9.323854568, Name = Resources.StressControlConvertor_UnitSet_Ton_per_square_foot_per_min}}
                        });
    }
    public struct StrainControlConvertor
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.StrainControlConvertor_UnitSet___sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet___sec, M = 100/60.0 * 1, Name = Resources.StrainControlConvertor_UnitSet_Percent_per_sec_Name}},
                            {Resources.StrainControlConvertor_UnitSet_Ɛ_sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet_Ɛ_sec, M = 1/60.0 * 1, Name = Resources.StrainControlConvertor_UnitSet_Ɛ_per_sec_Name}},
                            {Resources.StrainControlConvertor_UnitSet__in_in__sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__in_in__sec, M = 1/60.0 * 1, Name = Resources.StrainControlConvertor_UnitSet_in_in_per_sec}},
                            {Resources.StrainControlConvertor_UnitSet__ft_ft__sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__ft_ft__sec, M = 1/60.0 * 1, Name = Resources.StrainControlConvertor_UnitSet_ft_ft_per_sec}},
                            {Resources.StrainControlConvertor_UnitSet__yd_yd__sec, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__yd_yd__sec, M = 1/60.0 * 1, Name = Resources.StrainControlConvertor_UnitSet_yd_yd_per_sec}},
                            {Resources.StrainControlConvertor_UnitSet___min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet___min, M = 100.0, Name = Resources.StrainControlConvertor_UnitSet_Percent_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet_Ɛ_min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet_Ɛ_min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_Ɛ_per_min_Name}},
                            {Resources.StrainControlConvertor_UnitSet__in_in__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__in_in__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_in_in_per_min}},
                            {Resources.StrainControlConvertor_UnitSet__ft_ft__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__ft_ft__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_ft_ft_per_min}},
                            {Resources.StrainControlConvertor_UnitSet__yd_yd__min, new Unit {Abbreviation = Resources.StrainControlConvertor_UnitSet__yd_yd__min, M = 1.0, Name = Resources.StrainControlConvertor_UnitSet_yd_yd_per_min}},
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