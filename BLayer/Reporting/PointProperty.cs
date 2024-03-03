namespace STM.BLayer.Reporting
{
    public enum PointProperty
    {
        Force = 1,
        Stress,
        TrueStress,
        MassStress, 
        LengthStress,
        Extension,
        Strain,
        TrueStrain,
        ElongationAfterBreak,
        SecantModule,
        TangentModule,
        Energy,
        Time,
        BendingStress,
        BendingStrain,
        BendingModule,
        AA0,
        ForcePerLength,
        Formula,

        ForceRate,
        ExtenRate,
        StressRate,
        StrainRate,
        Relaxation,
        ForceLoss,
        StressLoss,	

		Temperature,
		SpecTempUP,
		SpecTempCNT,
		SpecTempDN,
		AmbientTemp,
		ZoneTempUP,
		ZoneTempCNT,
		ZoneTempDN
	}
}