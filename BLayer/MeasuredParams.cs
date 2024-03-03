using System;

namespace STM.BLayer
{
	public class MeasuredParams : ICloneable
	{
		public double Force { set; get; }
		public double LFExtention { set; get; }
		public double ExtenExtention { set; get; }
		public double Extension { set; get; }
		public double MotorResponseSpeed { set; get; }
		public double SetSpeed { set; get; }
		public double Stress { set; get; }
		public double MassStress { set; get; }
		public double LengthStress { set; get; }
		public double TrueStress { set; get; }
		public double Strain { set; get; }
		public double TrueStrain { set; get; }
		public Boolean ToPlot { set; get; }
		public double Time { get; set; }
		public bool TestData { get; set; }
		public int StepOrCycle { set; get; }
		public float[] Temperature { get; set; }
		public int Decimation { get; set; }

		public object Clone()
		{
			var mp = new MeasuredParams(Temperature)
			{
				Force = Force,
				LFExtention = LFExtention,
				ExtenExtention = ExtenExtention,
				MotorResponseSpeed = MotorResponseSpeed,
				Time = Time,
				ToPlot = ToPlot,
				StepOrCycle = StepOrCycle,
			};


			return mp;
		}

		public MeasuredParams()
		{
			Temperature = new float[DLayer.TMPR232.NumberOfTemperaturChannels];
		}

		public MeasuredParams(float[] temperature)
		{
			Temperature = new float[temperature.Length];
			for (int i = 0; i < temperature.Length; i++)
				Temperature[i] = temperature[i];
		}
	}

	public class BoardReadData
	{
		public int LoadcellA2D { set; get; }
		public int ExtenA2D { set; get; }
		public int MotorEncoder { set; get; }
		public int ExtenEncoder { set; get; }
		public float[] TemperatureData { get; set; }

		public BoardReadData()
		{
			TemperatureData = new float[Math.Max(DLayer.TMPR232.NumberOfTemperaturChannels, DLayer.TMPR485.NumberOfTemperaturChannels) ];
		}

		public BoardReadData(float[] temperatureData)
		{
			TemperatureData = new float[temperatureData.Length];
			for (var i = 0; i < temperatureData.Length; i++)
				TemperatureData[i] = temperatureData[i];
		}

		public bool Valid { set; get; }
	}
}