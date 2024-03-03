using System.Collections.Generic;
using STM.BLayer;
using STM.BLayer.Configurations;

namespace STM.Sensor
{
    /// <summary>
    /// Encapsulates sensors which are defined in the system and detects new devices
    /// </summary>
    public static class Sensors
    {
        static Dictionary<int, LoadCell> loadCells;
        static Dictionary<int, ExtensoMeter> extensoMeters;
        static Dictionary<int, TemperatureSensor> temperatureSensors;
        static readonly MotorEncoder MotorEncoder = new MotorEncoder();

        /// <summary>
        /// Adds lc to load cell list
        /// </summary>
        /// <param name="lc">Load cell to be added</param>
        public static void Add(LoadCell lc)
        {
            if (loadCells == null)
                loadCells = new Dictionary<int, LoadCell>();
            loadCells[lc.LoadCellType] = lc;

            CurrentLoadCell = lc;
            using (var sl = SettingLoader.Current)
            {
                sl.AddloadCell(lc);
            }
        }
        /// <summary>
        /// Adds lc to extensometre list
        /// </summary>
        /// <param name="ex">Extensometer to be added</param>
        public static void Add(ExtensoMeter ex)
        {
            if (extensoMeters == null)
                extensoMeters = new Dictionary<int, ExtensoMeter>();
            extensoMeters[ex.ExtensomereType] = ex;

            CurrentExtensoMeter = ex;

            using (var sl = SettingLoader.Current)
            {
                sl.AddExtensometer(ex);
            }
        }
        /// <summary>
        /// Adds ts to temperature sensors list
        /// </summary>
        /// <param name="ts">Temeperature sensor to be added</param>
        public static void Add(TemperatureSensor ts)
        {
            if (temperatureSensors == null)
                temperatureSensors = new Dictionary<int, TemperatureSensor>();
            temperatureSensors[ts.CountOfSensors] = ts;

            CurrentTemperatureSensor = ts;
            using (var sl = SettingLoader.Current)
            {
                sl.AddTemperatureSensor(ts);
            }
        }
        /// <summary>
        /// Current triggerd load cell
        /// </summary>
        public static LoadCell CurrentLoadCell { set; get; }
        /// <summary>
        /// Current triggerd temperature sensor
        /// </summary>
        public static TemperatureSensor CurrentTemperatureSensor { set; get; }
        /// <summary>
        /// Current triggerd extensometer
        /// </summary>
        public static ExtensoMeter CurrentExtensoMeter { set; get; }
        /// <summary>
        /// Current triggerd motor encoder
        /// </summary>
        public static MotorEncoder CurrentEncoder { get { return MotorEncoder; } }
        /// <summary>
        /// Detects recently equipped load cell
        /// </summary>
        /// <param name="cmd">The board data for changing statuse</param>
        /// <param name="notDefiend">if the load cell is a new one that hasn't adde yet, this parameter is true else false </param>
        /// <returns>Returns load cell type</returns>
        public static int DetectLoadCell(string cmd, ref bool notDefiend)
        {
            int typeCell = int.Parse(cmd.Substring(0, 4), System.Globalization.NumberStyles.HexNumber) / 100;
            try
            {
                CurrentLoadCell = loadCells[typeCell];
                notDefiend = false;
            }
            catch
            {
                notDefiend = true;
            }

            return typeCell;
        }
        /// <summary>
        /// Detects recently equipped extensometer
        /// </summary>
        /// <param name="cmd">The board data for changing statuse</param>
        /// <param name="notDefind">if the extensometer is a new one that hasn't adde yet, this parameter is true else false</param>
        /// <returns>Returns extensometer type</returns>
        public static int DetectExtensometer(string cmd, ref bool notDefind)
        {
            var typeExten = int.Parse(cmd.Substring(5, 4), System.Globalization.NumberStyles.HexNumber);

            try
            {
                CurrentExtensoMeter = extensoMeters[typeExten];

                if (CurrentExtensoMeter.LongAnalog != SettingLoader.Current.GetLastExtenAnalogType())
                {
                    SettingLoader.Current.SetLastExtenAnalogType(CurrentExtensoMeter.LongAnalog);

                    Configuer.Def2(CurrentExtensoMeter.LongAnalog);
                    Configuer.ResetSDB();
                }

                notDefind = false;
            }
            catch
            {
                notDefind = true;
            }

            if (Status.ExtensometerFailure)
            {
                notDefind = false;
            }

            return typeExten;
        }
        /// <summary>
        /// Detects recently equipped temperature sensors
        /// </summary>
        /// <param name="notDefind">if the temperature sensor is a new one that hasn't adde yet, this parameter is true else false</param>
        /// <returns>Returns temperature sensor type</returns>
        public static int DetectTemperatureSensor(int defaultSensor, ref bool notDefind)
        {
            try
            {
                CurrentTemperatureSensor = temperatureSensors[defaultSensor];
                notDefind = false;
            }
            catch
            {
                notDefind = true;
            }

            return defaultSensor;
        }
        /// <summary>
        /// Set all loadcells
        /// </summary>
        /// <param name="dicLoadcells"></param>
        public static void SetLoadcells(Dictionary<int, LoadCell> dicLoadcells)
        {
            loadCells = dicLoadcells;
        }
        /// <summary>
        /// Sets all extensometers
        /// </summary>
        /// <param name="dicExtensometers"></param>
        public static void SetExtensometers(Dictionary<int, ExtensoMeter> dicExtensometers)
        {
            extensoMeters = dicExtensometers;
        }
        /// <summary>
        /// Sets all temperature sensors
        /// </summary>
        /// <param name="dicTemperatureSensors"></param>
        public static void SetTemperatureSensors(Dictionary<int, TemperatureSensor> dicTemperatureSensors)
        {
            temperatureSensors = dicTemperatureSensors;
        }
    }
}