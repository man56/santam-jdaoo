using System;
using System.Collections.Generic;
using STM.BLayer.Parameters;

namespace STM.BLayer.StmTest
{
    public class AvgFilter
    {
        #region Fields

        Queue<double> filterForce;
        Queue<double> filterLfExten;
        Queue<double> filterExExten;
        Queue<double> filterLateralExten;

        private double sumForce;
        private double sumLfExten;
        private double sumExExten;
        private double sumLateralExten;

        private double avgForce;
        private double avgLfExten;
        private double avgExExten;
        private double avgLateralExten;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AvgFilter()
        {
            Reset();
        }

        #endregion

        #region Methods

        // Resets filltering variables
        public void Reset()
        {
            filterForce = new Queue<double>(InstrumentParameters.ForceFilter);
            filterLfExten = new Queue<double>(InstrumentParameters.LfEncoderFilter);
            filterExExten= new Queue<double>(InstrumentParameters.ExtenFilter);
            filterLateralExten = new Queue<double>(InstrumentParameters.LExtenFilter);

            sumForce = 0;
            sumLfExten = 0;
            sumExExten = 0;
            sumLateralExten = 0;

            avgForce = 0;
            avgLfExten = 0;
            avgExExten = 0;
            avgLateralExten = 0;
        
        }

        /// <summary>
        /// Filter instance parametes with perevious avearging number instances
        /// </summary>
        public void AddFilter(ref double force, ref double loadFrameExten, ref double extensometerExten, ref double lateralExten)
        {
            sumForce += force;
            sumLfExten += loadFrameExten;
            sumExExten += extensometerExten;
            sumLateralExten += lateralExten;

            filterForce.Enqueue(force);
            filterLfExten.Enqueue(loadFrameExten);
            filterExExten.Enqueue(extensometerExten);
            filterLateralExten.Enqueue(lateralExten);

            if (filterForce.Count > InstrumentParameters.ForceFilter)
                sumForce -= filterForce.Dequeue();
            if (filterLfExten.Count > InstrumentParameters.LfEncoderFilter)
                sumLfExten -= filterLfExten.Dequeue();

            if (filterExExten.Count > InstrumentParameters.ExtenFilter)
                sumExExten -= filterExExten.Dequeue();

            if (filterLateralExten.Count > InstrumentParameters.LExtenFilter)
                sumLateralExten -= filterLateralExten.Dequeue();

            avgForce = sumForce / filterForce.Count;
            avgLfExten = sumLfExten / filterLfExten.Count;
            avgExExten = sumExExten / filterExExten.Count;
            avgLateralExten = sumLateralExten / filterLateralExten.Count;

            force = /*Math.Abs(force - avgForce) > Math.Abs(0.1 * avgForce) ? force :*/ avgForce;
            loadFrameExten = /*Math.Abs(loadFrameExten - avgLfExten) > Math.Abs(0.1 * avgLfExten) ? loadFrameExten :*/ avgLfExten;
            extensometerExten = /*Math.Abs(extensometerExten - avgExExten) > Math.Abs(0.1 * avgExExten) ? extensometerExten :*/ avgExExten;
            lateralExten = /*Math.Abs(lateralExten - avgLateralExten) > Math.Abs(0.1 * avgLateralExten) ? lateralExten : */ avgLateralExten;
        }

        public void ZeroForce()
        {
            sumForce = 0;
            filterForce.Clear();
        }

        public void ZeroExtensometerExtension()
        {
            sumExExten = 0;
            filterExExten.Clear();
        }

        public void ZeroLfExtension()
        {
            sumLfExten = 0;
            filterLfExten.Clear();
        }

		public void ZeroTemperature(int sensorIndex)
		{			
		}

		#endregion
	}
}
