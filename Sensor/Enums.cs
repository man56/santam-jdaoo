namespace STM.Sensor
{
    public enum SensorType
    {
        Loadcell = 1,
        Extensometer = 2,
		TemperatureSensor
	}


    public enum StopCode
    {
        None = 0,
        ForceBreakPoint = 1,
        LoadCellProtection = 2,
        OperatorCommand = 3,
        SensorOverflow = 4,
        SensorUnderflow
    }

    public enum ReturnZeroMode
    {
        None = 0,
        Extension = 1,
        Force = 2
    }
}
