using System;
using STM.BLayer.Configurations;

namespace STM.Sensor
{
	public class TemperatureSensor
	{
		private const int MaxSensors = DLayer.TMPR232.NumberOfTemperaturChannels;

		public int CountOfSensors { set; get; }

		public int[] MaxCap;
		public double[] RO { private set; get; }
		public double[] Gain { private set; get; }

		private float[] lastRead;
		private float[] calibrationStartPoint;
		private float[] temperature;
		private double[] temperatureOffset;

		public TemperatureSensor(int countOfSensors = MaxSensors)
		{
			CountOfSensors = countOfSensors;

			RO = new double[MaxSensors];
			Gain = new double[MaxSensors];
			MaxCap = new int[MaxSensors];

			temperature = new float[MaxSensors];
			temperatureOffset = new double[MaxSensors];
			lastRead = new float[MaxSensors];
			calibrationStartPoint = new float[MaxSensors];
		}

		public TemperatureSensor(int maxCapacity, double ro) : this()
		{
			var gain = maxCapacity / ro;
			for (var i = 0; i < CountOfSensors; i++)
			{
				RO[i] = ro;
				Gain[i] = gain;
				MaxCap[i] = maxCapacity;
                temperatureOffset[i] = BLayer.Parameters.InstrumentParameters.TemperatureOffset[i];

            }
		}

		public float GetTemperature(float temperatureData, int temperatureSensorIndex)
		{
			lastRead[temperatureSensorIndex] = temperatureData;

			temperature[temperatureSensorIndex] = (float)(temperatureData * Gain[temperatureSensorIndex] - temperatureOffset[temperatureSensorIndex]);

			return temperature[temperatureSensorIndex];
		}

		public void GetTemperature(float[] temperatureData, float[] temperature)
		{
			if (temperatureData == null)
				for (var temperatureSensorIndex = 0; temperatureSensorIndex < temperature.Length; temperatureSensorIndex++)
					temperature[temperatureSensorIndex] = GetTemperature(0, temperatureSensorIndex);
			else
				for (var temperatureSensorIndex = 0; temperatureSensorIndex < temperature.Length; temperatureSensorIndex++)
					temperature[temperatureSensorIndex] = GetTemperature(temperatureSensorIndex < temperatureData.Length ? temperatureData[temperatureSensorIndex] : 0, temperatureSensorIndex);
		}

		public void Zero(int temperatureSensorIndex)
		{
			// SettingLoader.Current.SetforceOffset(lastRead);
			temperatureOffset[temperatureSensorIndex] = lastRead[temperatureSensorIndex] * Gain[temperatureSensorIndex];
		}

		public void SetCalibrationStartPoint(int temperatureSensorIndex)
		{
			calibrationStartPoint[temperatureSensorIndex] = lastRead[temperatureSensorIndex];
		}

		public double Calibrate(double startTemperature, double stopTemperature, int temperatureSensorIndex)
		{
			var tmp = (stopTemperature - startTemperature) / (lastRead[temperatureSensorIndex] - calibrationStartPoint[temperatureSensorIndex]);
			return Math.Abs(MaxCap[temperatureSensorIndex] / tmp);
		}

		public void SetRO(double ro, int temperatureSensorIndex)
		{
			RO[temperatureSensorIndex] = ro;
			Gain[temperatureSensorIndex] = MaxCap[temperatureSensorIndex] / ro;
		}

		public void SetMaxCap(int maxCap, int temperatureSensorIndex)
		{
			MaxCap[temperatureSensorIndex] = maxCap;
			Gain[temperatureSensorIndex] = maxCap / RO[temperatureSensorIndex];
		}

		public void SetOffset(double offset, int temperatureSensorIndex)
		{
			temperatureOffset[temperatureSensorIndex] = offset;
		}

		public void SetGain(double gain1, double gainK)
		{
			for (var index = 0; index < Gain.Length; index++)
				Gain[index] = gain1;

			if (gainK > 0)
				for (var index = 0; index < 3 && index < Gain.Length; index++)
					Gain[index] = gainK;
		}
	}
}
