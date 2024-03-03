using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using STM.BLayer.Parameters;
using STM.BLayer.Reporting;
using STM.BLayer.StmTest;
using STM.PLayer.UI;
using STM.PLayer.Report;
using System.Globalization;
using STM.Sensor;
using STM.Extensions;

namespace STM.BLayer.Configurations
{
    class SettingLoader : IDisposable
    {
        static XDocument documet;
        static SettingLoader instance;

        public static SettingLoader Current
        {
            get { return instance ?? (instance = new SettingLoader()); }
        }

        public static string XmlPath { set; get; }

        private SettingLoader()
        {
            documet = XDocument.Load(XmlPath);
        }

        public string GetLanguge()
        {
            string lang;
            lang = documet.Descendants("Languge").First().Attribute("Lang").Value ?? "en";
            return lang;
        }

        public void SetLanguge(string lang)
        {
            documet.Descendants("Languge").First().Attribute("Lang").SetValue(lang);
            documet.Save(XmlPath);
        }

        public bool GetLastExtenAnalogType()
        {
            bool analogType;
            bool.TryParse(documet.Descendants("extenLongAnalog").First().Attribute("value").Value, out analogType);
            return analogType;
        }

        public void SetLastExtenAnalogType(bool longAnaog)
        {
            documet.Descendants("extenLongAnalog").First().Attribute("value").SetValue(longAnaog);
            documet.Save(XmlPath);
        }
        public void SetUser(string code)
        {
            documet.Descendants("User").First().Attribute("code").SetValue(code);
            documet.Save(XmlPath);
        }

        public string GetUser()
        {
            string lang;
            lang = documet.Descendants("User").First().Attribute("code").Value ?? "";
            return lang;
        }

        public void SetforceOffset(int code)
        {
            documet.Descendants("forceOffset").First().Attribute("value").SetValue(code);
            documet.Save(XmlPath);
        }

        public int GetforceOffset()
        {
            return (documet.Descendants("forceOffset").First().Attribute("value").Value ?? "0").ToInt32();
        }

        #region LoadCells

        public Dictionary<int, LoadCell> GetLoadcells()
        {
            try
            {
                var loadcells = documet.Descendants("sensors").Descendants("loadcells").Descendants("loadcell")
                                       .Where(x => x.Attribute("id").Value != "")
                                       .ToDictionary(x => int.Parse(x.Attribute("id").Value), x => new LoadCell(int.Parse(x.Attribute("maxCapacity").Value), double.Parse(x.Attribute("ro").Value), int.Parse(x.Attribute("id").Value)));
                return loadcells;
            }
            catch
            {
            }
            return new Dictionary<int, LoadCell>();
        }

        public void SetLoadcells(Dictionary<int, LoadCell> loadcells)
        {
            try
            {
                documet.Descendants("sensors").Descendants("loadcells").Descendants("loadcell").Remove();
            }
            catch
            {
            }
            foreach (XElement xElement in documet.Descendants("loadcells"))
            {
                foreach (var cell in loadcells.Values)
                    xElement.Add(
                                 new XElement("loadcell",
                    new XAttribute("id", cell.LoadCellType),
                    new XAttribute("maxCapacity", cell.MaxCap),
                    new XAttribute("ro", cell.RO)));
            }
            documet.Save(XmlPath);
        }

        public void AddloadCell(LoadCell loadCell)
        {
            foreach (XElement xElement in documet.Descendants("loadcells"))
            {
                xElement.Add(
                             new XElement("loadcell",
                new XAttribute("id", loadCell.LoadCellType),
                new XAttribute("maxCapacity", loadCell.MaxCap),
                new XAttribute("ro", loadCell.RO)));
            }
            documet.Save(XmlPath);
        }

        public void SetLoadcell(LoadCell loadCell)
        {
            try
            {
                var lc = documet.Descendants("sensors").Descendants("loadcells").Descendants("loadcell")
                                .Where(x => x.Attribute("id").Value == loadCell.LoadCellType.ToString())
                                .First();
                lc.SetAttributeValue("maxCapacity", loadCell.MaxCap);
                lc.SetAttributeValue("ro", loadCell.RO);
                documet.Save(XmlPath);
            }
            catch
            {
            }
        }

        #endregion

        #region Extensometers

        public Dictionary<int, ExtensoMeter> GetExtensometers()
        {
            try
            {
                var extensometers = documet.Descendants("sensors").Descendants("extensometres").Descendants(
                    "extensometer")
                    .Where(x => x.Attribute("id").Value != "")
                    .ToDictionary(x => int.Parse(x.Attribute("id").Value),
                        x => new ExtensoMeter(int.Parse(x.Attribute("maxCapacity").Value),
                            double.Parse(x.Attribute("rogain").Value),
                            int.Parse(x.Attribute("id").Value),
                            int.Parse(x.Attribute("type").Value) == 1,
                            int.Parse(x.Attribute("longAnalog").Value) == 1));
                return extensometers;
            }
            catch
            {
            }
            return new Dictionary<int, ExtensoMeter>();
        }

        public void SetExtensometers(Dictionary<int, ExtensoMeter> extensoMeters)
        {
            try
            {
                documet.Descendants("sensors").Descendants("extensometres").Descendants("extensometer").Remove();
            }
            catch
            {
            }
            foreach (XElement xElement in documet.Descendants("extensometres"))
            {
                foreach (var extensometer in extensoMeters.Values)
                    xElement.Add(
                        new XElement("extensometer",
                                     new XAttribute("id", extensometer.ExtensomereType),
                                     new XAttribute("maxCapacity", extensometer.MaxCap),
                                     new XAttribute("rogain", extensometer.RoGain),
                                     new XAttribute("type", extensometer.EncoderBased ? 1 : 0),
                                     new XAttribute("longAnalog", extensometer.LongAnalog ? 1 : 0)));
            }
            documet.Save(XmlPath);
        }

        public void AddExtensometer(ExtensoMeter extensometer)
        {
            foreach (XElement xElement in documet.Descendants("extensometres"))
            {
                xElement.Add(
                    new XElement("extensometer",
                        new XAttribute("id", extensometer.ExtensomereType),
                        new XAttribute("maxCapacity", extensometer.MaxCap),
                        new XAttribute("rogain", extensometer.RoGain),
                        new XAttribute("type", extensometer.EncoderBased ? 1 : 0),
                    new XAttribute("longAnalog", extensometer.LongAnalog ? 1 : 0)));
            }
            documet.Save(XmlPath);
        }

        public void SetExtensometer(ExtensoMeter extensoMeter)
        {
            var xs = documet.Descendants("sensors").Descendants("extensometres").Descendants("extensometer")
                            .Where(x => x.Attribute("id").Value == extensoMeter.ExtensomereType.ToString())
                            .First();
            xs.SetAttributeValue("maxCapacity", extensoMeter.MaxCap);
            xs.SetAttributeValue("rogain", extensoMeter.RoGain);
            xs.SetAttributeValue("type", extensoMeter.EncoderBased ? 1 : 0);
            xs.SetElementValue("longAnalog", extensoMeter.LongAnalog ? 1 : 0);
            documet.Save(XmlPath);
        }

        #endregion

        #region Temperature Sensor

        public Dictionary<int, TemperatureSensor> GetTemperatureSensors()
        {
            try
            {
                var temperatureS = documet.Descendants("sensors").Descendants("temperatureSensors").Descendants(
                    "temperatureSensor")
                    .Where(x => x.Attribute("id").Value != "")
                    .ToDictionary(x => int.Parse(x.Attribute("id").Value),
                        x => new TemperatureSensor(
                            int.Parse(x.Attribute("maxCapacity").Value),
                            double.Parse(x.Attribute("ro").Value)));
                return temperatureS;
            }
            catch
            {
            }
            return new Dictionary<int, TemperatureSensor>();
        }

        public void SetTemperatureSensors(Dictionary<int, TemperatureSensor>  temperatureSensors)
        {
            try
            {
                documet.Descendants("sensors").Descendants("temperatureSensors").Descendants("temperatureSensor").Remove();
            }
            catch
            {
            }
            foreach (XElement xElement in documet.Descendants("temperatureSensors"))
            {
                foreach (var temperatureSensor in temperatureSensors.Values)
                    xElement.Add(
                        new XElement("temperatureSensor",
                                     new XAttribute("maxCapacity", temperatureSensor.MaxCap),
                                     new XAttribute("ro", temperatureSensor.Gain)));
            }

            documet.Save(XmlPath);
        }

        public void SetTemperatureSensor(TemperatureSensor temperatureSensor)
        {
            try
            {
                var tp = documet.Descendants("sensors").Descendants("temperatureSensors").Descendants("temperatureSensor")
                                .FirstOrDefault();
                if (tp != null)
                {
                    tp.SetAttributeValue("maxCapacity", temperatureSensor.MaxCap);
                    tp.SetAttributeValue("ro", temperatureSensor.RO);
                }

                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureGain1").SetValue(InstrumentParameters.TemperatureGain1);
                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureGain2").SetValue(InstrumentParameters.TemperatureGain2);

                documet.Save(XmlPath);
            }
            catch(Exception e)
            {
            }
        }

        public void AddTemperatureSensor(TemperatureSensor temperatureSensor)
        {
            foreach (XElement xElement in documet.Descendants("temperatureSensors"))
            {
                xElement.Add(
                             new XElement("temperatureSensor",
                new XAttribute("id", temperatureSensor.CountOfSensors),
                new XAttribute("maxCapacity", temperatureSensor.MaxCap),
                new XAttribute("ro", temperatureSensor.RO)));
            }
            documet.Save(XmlPath);
        }

        #endregion

        #region machine

        #region Port

        public void LoadPortSetting()
        {
            foreach (XElement port in documet.Descendants("machine").Descendants("serialPort"))
            {
                try
                {
                    SerialPortParameters.Name = port.Attribute("name").Value;
                    SerialPortParameters.ReadInterval = (int)double.Parse(port.Attribute("readInterval").Value);
                    SerialPortParameters.DecimationRatio = int.Parse(port.Attribute("decimationRatio").Value);

                }
                catch
                {
                }

                try
                {
                    foreach (var element in documet.Descendants("machine").Descendants("TemperaturePort"))
                    {
                        TemperaturePortParameters.Name = element.Attribute("portname")?.Value;
                        TemperaturePortParameters.ReadInterval = int.Parse(element.Attribute("portinterval")?.Value ?? SerialPortParameters.ReadInterval.ToString());
                        TemperaturePortParameters.DecimationRatio = int.Parse(element.Attribute("portdecimation")?.Value ?? SerialPortParameters.DecimationRatio.ToString());
                    }
                }
                catch
                {
                }
            }
        }

        public void SavePortSetting()
        {
            foreach (XElement port in documet.Descendants("machine").Descendants("serialPort"))
            {
                try
                {
                    port.Attribute("name").SetValue(SerialPortParameters.Name);
                    port.Attribute("readInterval").SetValue(SerialPortParameters.ReadInterval);
                    port.Attribute("decimationRatio").SetValue(SerialPortParameters.DecimationRatio);

                }
                catch
                {
                }
            }
            try
            {
                foreach (XElement port in documet.Descendants("machine").Descendants("TemperaturePort"))
                {
                    try
                    {
                        port.Attribute("portname").SetValue(TemperaturePortParameters.Name);
                        port.Attribute("portinterval").SetValue(TemperaturePortParameters.ReadInterval);
                        port.Attribute("portdecimation").SetValue(TemperaturePortParameters.DecimationRatio);

                    }
                    catch
                    {
                    }
                }
                //var element = documet?.Element("machine")?.Element("TemperaturePort");
                //if (element == null)
                //{
                //    element = new XElement("TemperaturePort");
                //    documet.Element("machine").Add(element);
                //}
                //foreach (XElement port in documet.Descendants("TemperaturePort"))
                //{
                //    try
                //    {
                //        element.SetAttributeValue("portname", TemperaturePortParameters.Name);
                //        element.SetAttributeValue("portinterval", TemperaturePortParameters.ReadInterval);
                //        element.SetAttributeValue("portdecimation", TemperaturePortParameters.DecimationRatio);

                //    }
                //    catch
                //    {
                //    }
                //}
            }
            catch (Exception ex) { }

            documet.Save(XmlPath);
        }

        #endregion

        #region CrossHead

        public void LoadCrossHeadSetting()
        {
            foreach (XElement cross in documet.Descendants("machine").Descendants("crossHead"))
            {
                try
                {
                    CrossHead.HiJogSpeed = double.Parse(cross.Attribute("high").Value);
                    CrossHead.LowJogSpeed = double.Parse(cross.Attribute("low").Value);
                    Test.ReturnToZeroSpeed = (int)CrossHead.MinSpeed;
                    CrossHead.Increament = double.Parse(cross.Attribute("increament").Value);
                    CrossHead.MaxSpeed = double.Parse(cross.Attribute("max").Value);
                    CrossHead.MinSpeed = double.Parse(cross.Attribute("min").Value);
                    CrossHead.ActuatorUp = bool.Parse(cross.Attribute("act").Value);
                    CrossHead.ElectroHydrolic = bool.Parse(cross.Attribute("ehs").Value);
                }
                catch
                {
                }
            }
        }

        public void SaveCrossHeadSetting()
        {
            foreach (XElement cross in documet.Descendants("machine").Descendants("crossHead"))
            {
                try
                {
                    cross.Attribute("high").SetValue(CrossHead.HiJogSpeed);
                    cross.Attribute("low").SetValue(CrossHead.LowJogSpeed);
                    cross.Attribute("increament").SetValue(CrossHead.Increament);
                    cross.Attribute("max").SetValue(CrossHead.MaxSpeed);
                    cross.Attribute("min").SetValue(CrossHead.MinSpeed);
                    cross.Attribute("act").SetValue(CrossHead.ActuatorUp);
                    cross.Attribute("ehs").SetValue(CrossHead.ElectroHydrolic);
                }
                catch
                {
                }
            }
            documet.Save(XmlPath);
        }

        #endregion

        public void LoadSpeedCtrlSetting()
        {
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("pid"))
            {
                try
                {
                    SpeedControlParameters.P = double.Parse(ctrl.Attribute("p").Value);
                    SpeedControlParameters.I = double.Parse(ctrl.Attribute("i").Value);
                    SpeedControlParameters.D = double.Parse(ctrl.Attribute("d").Value);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("extension"))
            {
                try
                {
                    SpeedControlParameters.Kep = double.Parse(ctrl.Attribute("kep").Value);
                    SpeedControlParameters.Kei = double.Parse(ctrl.Attribute("kei").Value);
                    SpeedControlParameters.Ked = double.Parse(ctrl.Attribute("ked").Value);
                    SpeedControlParameters.Etorelance = double.Parse(ctrl.Attribute("torelance").Value);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("force"))
            {
                try
                {
                    SpeedControlParameters.Kfp = double.Parse(ctrl.Attribute("kfp").Value);
                    SpeedControlParameters.Kfi = double.Parse(ctrl.Attribute("kfi").Value);
                    SpeedControlParameters.Kfd = double.Parse(ctrl.Attribute("kfd").Value);
                    SpeedControlParameters.Ftorelance = double.Parse(ctrl.Attribute("torelance").Value);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("strain"))
            {
                try
                {
                    SpeedControlParameters.Ksp = double.Parse(ctrl.Attribute("ksp").Value);
                    SpeedControlParameters.Ksi = double.Parse(ctrl.Attribute("ksi").Value);
                    SpeedControlParameters.Ksd = double.Parse(ctrl.Attribute("ksd").Value);
                    SpeedControlParameters.STorelance = double.Parse(ctrl.Attribute("torelance").Value);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("motion"))
            {
                try
                {
                    SpeedControlParameters.Velocity = double.Parse(ctrl.Attribute("velocity").Value);
                    SpeedControlParameters.Command = double.Parse(ctrl.Attribute("command").Value);
                    SpeedControlParameters.Timeout = double.Parse(ctrl.Attribute("timeout").Value);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("motor"))
            {
                try
                {
                    SpeedControlParameters.Max = double.Parse(ctrl.Attribute("max").Value);
                    SpeedControlParameters.Step = double.Parse(ctrl.Attribute("step").Value);
                    SpeedControlParameters.Offset = double.Parse(ctrl.Attribute("offset").Value);
                }
                catch
                {
                }
            }
        }

        public void SaveSpeedCtrlSetting()
        {
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("pid"))
            {
                try
                {
                    ctrl.Attribute("p").SetValue(SpeedControlParameters.P);
                    ctrl.Attribute("i").SetValue(SpeedControlParameters.I);
                    ctrl.Attribute("d").SetValue(SpeedControlParameters.D);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("extension"))
            {
                try
                {
                    ctrl.Attribute("kep").SetValue(SpeedControlParameters.Kep);
                    ctrl.Attribute("kei").SetValue(SpeedControlParameters.Kei);
                    ctrl.Attribute("ked").SetValue(SpeedControlParameters.Ked);
                    ctrl.Attribute("torelance").SetValue(SpeedControlParameters.Etorelance);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("force"))
            {
                try
                {
                    ctrl.Attribute("kfp").SetValue(SpeedControlParameters.Kfp);
                    ctrl.Attribute("kfi").SetValue(SpeedControlParameters.Kfi);
                    ctrl.Attribute("kfd").SetValue(SpeedControlParameters.Kfd);
                    ctrl.Attribute("torelance").SetValue(SpeedControlParameters.Ftorelance);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("strain"))
            {
                try
                {
                    ctrl.Attribute("ksp").SetValue(SpeedControlParameters.Ksp);
                    ctrl.Attribute("ksi").SetValue(SpeedControlParameters.Ksi);
                    ctrl.Attribute("ksd").SetValue(SpeedControlParameters.Ksd);
                    ctrl.Attribute("torelance").SetValue(SpeedControlParameters.STorelance);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("motion"))
            {
                try
                {
                    ctrl.Attribute("velocity").SetValue(SpeedControlParameters.Velocity);
                    ctrl.Attribute("command").SetValue(SpeedControlParameters.Command);
                    ctrl.Attribute("timeout").SetValue(SpeedControlParameters.Timeout);
                }
                catch
                {
                }
            }
            foreach (XElement ctrl in documet.Descendants("machine").Descendants("motor"))
            {
                try
                {
                    ctrl.Attribute("max").SetValue(SpeedControlParameters.Max);
                    ctrl.Attribute("step").SetValue(SpeedControlParameters.Step);
                    ctrl.Attribute("offset").SetValue(SpeedControlParameters.Offset);
                }
                catch
                {
                }
            }

            documet.Save(XmlPath);
        }

        #endregion

        #region Measure Unit

        public Dictionary<int, MeasureTool> GetMeasureTools()
        {
            try
            {
                var measureTools = documet.Descendants("measures").Descendants("measure")
                                          .Where(x => !string.IsNullOrEmpty(x.Attribute("id").Value))
                                          .ToDictionary(
                                                        x => int.Parse(x.Attribute("id").Value),
                                                        x =>
                                                        new MeasureTool
                                                        {
                                                            MeasureLable = x.Attribute("label").Value,
                                                            MeasureType = (MeasureType)Enum.Parse(typeof(MeasureType), x.Attribute("type").Value),
                                                            Order = int.Parse(x.Attribute("id").Value),
                                                            Tool = x.Attribute("tool").Value,
                                                            Unit = x.Attribute("unit").Value,
                                                        });

                return measureTools;
            }
            catch
            {
            }
            return new Dictionary<int, MeasureTool>();
        }

        public void SetMeasureTools(Dictionary<int, MeasureTool> measureTools)
        {
            documet = XDocument.Load(XmlPath);
            try
            {
                documet.Descendants("measures").Descendants("measure").Remove();
            }
            catch
            {
            }
            foreach (XElement xElement in documet.Descendants("measures"))
            {
                foreach (var mt in measureTools.Values)
                    xElement.Add(
                                 new XElement("measure",
                    new XAttribute("id", mt.Order),
                    new XAttribute("label", mt.MeasureLable ?? ""),
                    new XAttribute("type", mt.MeasureType),
                    new XAttribute("tool", mt.Tool ?? ""),
                    new XAttribute("unit", mt.Unit ?? "")));
            }

            documet.Save(XmlPath);
        }

        public void GetUnits(out string units, out string forceUnit, out string extenUnit, out string stressUnit, out string strainUnit
            , out string timeUnit, out string specStress, out string lengthStress, out string temperatureUnit)
        {
            units = "SI";
            forceUnit = "N";
            extenUnit = "mm";
            stressUnit = "MPa";
            strainUnit = "mm/mm";
            timeUnit = "sec";
            specStress = "cN/denier";
            lengthStress = "N/mm";
            temperatureUnit = "°C";

            try
            {


                units = documet.Descendants("units").Descendants("Category").First().Attribute("current").Value;
                LoadSelectedUnits(units, out forceUnit, out extenUnit, out stressUnit, out strainUnit, out timeUnit, out specStress, out lengthStress, out temperatureUnit);
            }
            catch
            {
            }
        }

        public void LoadSelectedUnits(string unitMainCategories, out string forceUnit, out string extenUnit, out string stressUnit, out string strainUnit
            , out string timeUnit, out string specStress, out string lengthStress, out string temperatureUnit)
        {
            try
            {
                IEnumerable<XElement> elms = null;
                switch (unitMainCategories)
                {
                    case "SI": elms = documet.Descendants("units").Descendants("SI"); break;
                    case "MKS": elms = documet.Descendants("units").Descendants("MKS"); break;
                    case "BS": elms = documet.Descendants("units").Descendants("BS"); break;
                }
                forceUnit = elms.First().Attribute("forceUnit").Value;
                extenUnit = elms.First().Attribute("extenUnit").Value;
                stressUnit = elms.First().Attribute("stressUnit").Value;
                strainUnit = elms.First().Attribute("strainUnit").Value;
                timeUnit = elms.First().Attribute("timeUnit").Value;
                specStress = elms.First().Attribute("specStressUnit").Value;
                lengthStress = elms.First().Attribute("lengthStressUnit").Value;
                temperatureUnit = elms.First().Attribute("temperatureUnit").Value;

                return;
            }
            catch
            {
            }

            forceUnit = "N";
            extenUnit = "mm";
            stressUnit = "MPa";
            strainUnit = "mm/mm";
            timeUnit = "sec";
            specStress = "cN/Denier";
            lengthStress = "N/mm";
            temperatureUnit = "°C";
        }

        public void SetUnits(string mainUnits, string forceUnit, string extenUnit, string stressUnit, string strainUnit, string timeUnit, string specStress,
            string lengthStress, string temperatureUnit)
        {
            try
            {
                documet.Descendants("units").Descendants("Category").First().Attribute("current").SetValue(mainUnits);
                IEnumerable<XElement> elms = null;
                switch (mainUnits)
                {
                    case "SI": elms = documet.Descendants("units").Descendants("SI"); break;
                    case "MKS": elms = documet.Descendants("units").Descendants("MKS"); break;
                    case "BS": elms = documet.Descendants("units").Descendants("BS"); break;
                }
                if (elms != null)
                {
                    elms.First().Attribute("forceUnit").SetValue(forceUnit);
                    elms.First().Attribute("extenUnit").SetValue(extenUnit);
                    elms.First().Attribute("stressUnit").SetValue(stressUnit);
                    elms.First().Attribute("strainUnit").SetValue(strainUnit);
                    elms.First().Attribute("timeUnit").SetValue(timeUnit);
                    elms.First().Attribute("specStressUnit").SetValue(specStress);
                    elms.First().Attribute("lengthStressUnit").SetValue(lengthStress);
                    elms.First().Attribute("temperatureUnit").SetValue(temperatureUnit);
                }
            }
            catch
            {
            }
            documet.Save(XmlPath);
        }

        public void SetMainUnit(string mainUnits)
        {
            try
            {
                documet.Descendants("units").Descendants("Category").First().Attribute("current").SetValue(mainUnits);
            }
            catch
            {
            }
            documet.Save(XmlPath);
        }

        #endregion

        #region Instrument

        public void SetInstruments()
        {
            try
            {
                documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceFilter").SetValue(InstrumentParameters.ForceFilter);
                documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceMax").SetValue(InstrumentParameters.ForceMaxPercent);
                documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceMin").SetValue(InstrumentParameters.ForceMinPercent);
                documet.Descendants("instrumnet").Descendants("force").First().Attribute("forcePeakNoiseDetection").SetValue(InstrumentParameters.ForcePeakNoiseDetection);
                documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceRes").SetValue(InstrumentParameters.ForceRes);

                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenFilter").SetValue(InstrumentParameters.ExtenFilter);
                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenMax").SetValue(InstrumentParameters.ExtenMax);
                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenMin").SetValue(InstrumentParameters.ExtenMin);
                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenGaugeLength").SetValue(InstrumentParameters.ExtenGaugeLength);
                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenPeakNoiseDetection").SetValue(InstrumentParameters.ExtenPeakNoiseDetection);
                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenRes").SetValue(InstrumentParameters.ExtenRes);
                documet.Descendants("instrumnet").Descendants("exten").First().Attribute("useExtensometer").SetValue(InstrumentParameters.UseExtensometer);

                documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderFilter").SetValue(InstrumentParameters.LfEncoderFilter);
                documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderMax").SetValue(InstrumentParameters.LfEncoderMax);
                documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderMin").SetValue(InstrumentParameters.LfEncoderMin);
                documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderGain").SetValue(InstrumentParameters.LfEncoderGain);
                documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderRes").SetValue(InstrumentParameters.LfEncoderRes);
                documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderPeakNoiseDetection").SetValue(InstrumentParameters.LfEncoderPeakNoiseDetection);

                documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenFilter").SetValue(InstrumentParameters.LExtenFilter);
                documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenMax").SetValue(InstrumentParameters.LExtenMax);
                documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenMin").SetValue(InstrumentParameters.LExtenMin);
                documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenPeakNoiseDetection").SetValue(InstrumentParameters.LExtenPeakNoiseDetection);
                documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenRes").SetValue(InstrumentParameters.LExtenRes);
                documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenGaugeLength").SetValue(InstrumentParameters.LExtenGaugeLength);

                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureHMI").SetValue(InstrumentParameters.TemperatureHMI);
                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureRes").SetValue(InstrumentParameters.TemperatureRes);
                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureMax").SetValue(InstrumentParameters.TemperatureMax);
                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureGain1").SetValue(InstrumentParameters.TemperatureGain1);
                documet.Descendants("instrumnet").Descendants("temperature").First().Attribute("temperatureGain2").SetValue(InstrumentParameters.TemperatureGain2);
            }
            catch
            {
            }
            documet.Save(XmlPath);
        }

        public void LoadInstruments()
        {
            InstrumentParameters.ForceFilter = documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceFilter").Value.ToInt32();
            InstrumentParameters.ForceMaxPercent = documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceMax").Value.ToDouble();
            InstrumentParameters.ForceMinPercent = documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceMin").Value.ToDouble();
            InstrumentParameters.ForcePeakNoiseDetection = documet.Descendants("instrumnet").Descendants("force").First().Attribute("forcePeakNoiseDetection").Value.ToInt32();
            InstrumentParameters.ForceRes = documet.Descendants("instrumnet").Descendants("force").First().Attribute("forceRes").Value.ToInt32();

            InstrumentParameters.ExtenFilter = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenFilter").Value.ToInt32();
            InstrumentParameters.ExtenMax = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenMax").Value.ToDouble();
            InstrumentParameters.ExtenMin = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenMin").Value.ToDouble();
            InstrumentParameters.ExtenGaugeLength = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenGaugeLength").Value.ToDouble();
            InstrumentParameters.ExtenPeakNoiseDetection = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenPeakNoiseDetection").Value.ToInt32();
            InstrumentParameters.ExtenRes = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("extenRes").Value.ToInt32();
            InstrumentParameters.UseExtensometer = documet.Descendants("instrumnet").Descendants("exten").First().Attribute("useExtensometer").Value.ToBool();

            InstrumentParameters.LfEncoderFilter = documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderFilter").Value.ToInt32();
            InstrumentParameters.LfEncoderMax = documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderMax").Value.ToDouble();
            InstrumentParameters.LfEncoderMin = documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderMin").Value.ToDouble();
            InstrumentParameters.LfEncoderGain = documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderGain").Value.ToDouble();
            InstrumentParameters.LfEncoderRes = documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderRes").Value.ToInt32();
            InstrumentParameters.LfEncoderPeakNoiseDetection = documet.Descendants("instrumnet").Descendants("encoder").First().Attribute("encoderPeakNoiseDetection").Value.ToInt32();

            InstrumentParameters.LExtenFilter = documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenFilter").Value.ToInt32();
            InstrumentParameters.LExtenMax = documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenMax").Value.ToDouble();
            InstrumentParameters.LExtenMin = documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenMin").Value.ToDouble();
            InstrumentParameters.LExtenPeakNoiseDetection = documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenPeakNoiseDetection").Value.ToInt32();
            InstrumentParameters.LExtenRes = documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenRes").Value.ToInt32();
            InstrumentParameters.LExtenGaugeLength = documet.Descendants("instrumnet").Descendants("lExten").First().Attribute("lExtenGaugeLength").Value.ToDouble();

            var tempItem = documet.Descendants("instrumnet").Descendants("temperature").FirstOrDefault();
            if (tempItem != null)
            {
                InstrumentParameters.TemperatureHMI = tempItem.Attribute("temperatureHMI")?.Value?.ToBool() ?? false;
                InstrumentParameters.TemperatureRes = tempItem.Attribute("temperatureRes").Value.ToInt32();
                InstrumentParameters.TemperatureMax = tempItem.Attribute("temperatureMax").Value.ToInt32();
                InstrumentParameters.TemperatureGain1 = tempItem.Attribute("temperatureGain1")?.Value?.ToDouble()??10;
                InstrumentParameters.TemperatureGain2 = tempItem.Attribute("temperatureGain2")?.Value?.ToDouble() ?? 10;
                for (var i = 0; i < DLayer.TMPR232.NumberOfTemperaturChannels; i++)
                    InstrumentParameters.TemperatureOffset[i] = tempItem.Attribute($"temperatureOffset{i}")?.Value?.ToDouble() ?? 0;
                for (var i = 0; i < DLayer.TMPR232.NumberOfTemperaturChannels; i++)
                    InstrumentParameters.TemperatureChannelMapping[i] = tempItem.Attribute($"temperatureChannel{i}")?.Value?.ToInt32() ?? i;
            }

        }

        #endregion

        #region Instrument

        public void SetLogo(Logo logo)
        {
            try
            {
                documet.Descendants("Report").Descendants("Logo").First().Attribute("logoPath").SetValue(logo.LogoPath);
                documet.Descendants("Report").Descendants("Logo").First().Attribute("company").SetValue(logo.CompanyName);
                documet.Descendants("Report").Descendants("Logo").First().Attribute("description").SetValue(logo.Discription);
                documet.Descendants("Report").Descendants("Logo").First().Attribute("detail").SetValue(logo.Detail);
                documet.Descendants("Report").Descendants("Logo").First().Attribute("companyFont").SetValue(GetFontString(logo.FontCompanyName));
                documet.Descendants("Report").Descendants("Logo").First().Attribute("descriptionFont").SetValue(GetFontString(logo.FontDiscription));
                documet.Descendants("Report").Descendants("Logo").First().Attribute("detailFont").SetValue(GetFontString(logo.FontDetail));
                documet.Descendants("Report").Descendants("Logo").First().Attribute("LTR").SetValue(logo.LTR.ToString());
            }
            catch
            {
            }
            documet.Save(XmlPath);
        }

        private System.Drawing.Font GetFont(string font)
        {
            var param = font.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var name = param[0];
            var emSize = float.Parse(param[1]);
            var unit = (System.Drawing.GraphicsUnit)int.Parse(param[2]);
            var bold = bool.Parse(param[3]);
            var italic = bool.Parse(param[4]);
            var strict = bool.Parse(param[5]);
            var underline = bool.Parse(param[6]);

            var style = (System.Drawing.FontStyle)(-1);
            if (!bold && !italic)
                style = System.Drawing.FontStyle.Regular;
            if (bold)
                style = System.Drawing.FontStyle.Bold;
            if (italic)
                style |= System.Drawing.FontStyle.Italic;
            if (strict)
                style |= System.Drawing.FontStyle.Strikeout;
            if (underline)
                style |= System.Drawing.FontStyle.Underline;

            return new System.Drawing.Font(name, emSize, style, unit);
        }

        private string GetFontString(System.Drawing.Font font)
        {
            var name = font.Name;
            var emSize = font.Size;
            var unit = (int)font.Unit;
            var bold = font.Bold;
            var italic = font.Italic;
            var strict = font.Strikeout;
            var underline = font.Underline;
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", name, emSize, unit, bold, italic, strict, underline);
        }

        public Logo LoadLogo()
        {
            Logo logo = new Logo();
            logo.LogoPath = documet.Descendants("Report").Descendants("Logo").First().Attribute("logoPath").Value.ToString();
            logo.CompanyName = documet.Descendants("Report").Descendants("Logo").First().Attribute("company").Value.ToString();
            logo.Discription = documet.Descendants("Report").Descendants("Logo").First().Attribute("description").Value.ToString();
            logo.Detail = documet.Descendants("Report").Descendants("Logo").First().Attribute("detail").Value.ToString();
            logo.FontCompanyName = GetFont(documet.Descendants("Report").Descendants("Logo").First().Attribute("companyFont").Value.ToString());
            logo.FontDiscription = GetFont(documet.Descendants("Report").Descendants("Logo").First().Attribute("descriptionFont").Value.ToString());
            logo.FontDetail = GetFont(documet.Descendants("Report").Descendants("Logo").First().Attribute("detailFont").Value.ToString());
            logo.LTR = bool.Parse(documet.Descendants("Report").Descendants("Logo").First().Attribute("LTR").Value.ToString());
            return logo;
        }

        #endregion


        public void LoadColors()
        {
            try
            {
                foreach (var colors in documet.Descendants("ReportColors"))
                {
                    Colors.SucceedLoadOrSave = false;
                    int cl = 0;
                    if (int.TryParse(colors.Attribute("pageSpace").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.PageSpace = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.PageSpace = System.Drawing.Color.FromName(colors.Attribute("pageSpace").Value);
                    }
                    if (int.TryParse(colors.Attribute("background").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.Background = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.Background = System.Drawing.Color.FromName(colors.Attribute("background").Value);
                    }
                    if (int.TryParse(colors.Attribute("diagram").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.Diagram = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.Diagram = System.Drawing.Color.FromName(colors.Attribute("diagram").Value);
                    }
                    try
                    {
                        if (int.TryParse(colors.Attribute("diagram2").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                        {
                            Colors.Diagram2 = System.Drawing.Color.FromArgb(cl);
                        }
                        else
                        {
                            Colors.Diagram2 = System.Drawing.Color.FromName(colors.Attribute("diagram2").Value);
                        }
                    }
                    catch
                    {
                        Colors.Diagram2 = Colors.Diagram;
                    }
                    if (int.TryParse(colors.Attribute("lable").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.Lable = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.Lable = System.Drawing.Color.FromName(colors.Attribute("lable").Value);
                    }
                    if (int.TryParse(colors.Attribute("scale").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.Scale = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.Scale = System.Drawing.Color.FromName(colors.Attribute("scale").Value);
                    }
                    if (int.TryParse(colors.Attribute("title").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.Title = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.Title = System.Drawing.Color.FromName(colors.Attribute("title").Value);
                    }
                    if (int.TryParse(colors.Attribute("grid").Value, NumberStyles.HexNumber, new CultureInfo("en-US"), out cl))
                    {
                        Colors.Grid = System.Drawing.Color.FromArgb(cl);
                    }
                    else
                    {
                        Colors.Grid = System.Drawing.Color.FromName(colors.Attribute("grid").Value);
                    }

                    Colors.SucceedLoadOrSave = true;
                }
            }
            catch
            {
            }
        }

        public void SaveColors()
        {
            try
            {
                #region ReportLayout
                foreach (XElement colors in documet.Descendants("ReportColors"))
                {
                    Colors.SucceedLoadOrSave = false;
                    colors.Attribute("pageSpace").SetValue(Colors.PageSpace.Name);
                    colors.Attribute("background").SetValue(Colors.Background.Name);
                    colors.Attribute("diagram").SetValue(Colors.Diagram.Name);
                    colors.Attribute("diagram2").SetValue(Colors.Diagram2.Name);
                    colors.Attribute("lable").SetValue(Colors.Lable.Name);
                    colors.Attribute("scale").SetValue(Colors.Scale.Name);
                    colors.Attribute("title").SetValue(Colors.Title.Name);
                    colors.Attribute("grid").SetValue(Colors.Grid.Name);
                    Colors.SucceedLoadOrSave = true;
                }

                #endregion

                documet.Save(XmlPath);
            }
            catch
            {
            }
        }

        public void SaveOption()
        {
            foreach (XElement element in documet.Descendants("Options"))
            {
                element.Attribute("outputPath").SetValue(Options.OutputPath ?? "");
                element.Attribute("maxRecentFiles").SetValue(Options.MaxRecentFiles);
                element.Attribute("notifyLoadcellType").SetValue(Options.NotifyLoadcellType);
                element.Attribute("showGridLines").SetValue(Options.ShowGridLines);
                element.Attribute("showLanguageForm").SetValue(Options.ShowLanguageForm);

                element.Attribute("PrintLogo").SetValue(Options.PrintLogo);
                element.Attribute("PrintPlot").SetValue(Options.PrintPlot);
                element.Attribute("PrintTestResults").SetValue(Options.PrintTestResults);
                element.Attribute("PrintTestsSpec").SetValue(Options.PrintTestsSpec);
                element.Attribute("ResetMeasuresAtStart").SetValue(Options.ResetMeasuresAtStart);

                element.SetAttributeValue("HugeSampleCount", Options.HugeSampleCount);
                element.SetAttributeValue("UseTemperatureCompensation", Test.UseTemperatureCompensation);
                element.SetAttributeValue("SetTemperatureToZeroOnTestStop", Test.SetTemperatureToZeroOnTestStop);
                element.SetAttributeValue("MaximumTemperatureDiffrence", Test.MaximumTemperatureDiffrence);
                element.SetAttributeValue("TemperatureCompensationPeriod", Test.TemperatureCompensationPeriod);
                element.SetAttributeValue("BreakCounter", Test.BreakCounter);

                element.SetAttributeValue("TemperatureAxisRange", InstrumentParameters.TemperatureAxisRange);
           }

            try
            {
                foreach (XElement element in documet.Descendants("test").Descendants("def" +
                                                                                     "" +
                                                                                     ""))
                {
                    element.Attribute("path").SetValue(Options.DefTestPath);
                }
            }
            catch
            {
            }

            documet.Save(XmlPath);
        }

        public void LoadOption()
        {
            try
            {
                foreach (var element in documet.Descendants("Options"))
                {
                    Options.OutputPath = element.Attribute("outputPath").Value;
                    Options.MaxRecentFiles = int.Parse(element.Attribute("maxRecentFiles").Value);
                    Options.NotifyLoadcellType = bool.Parse(element.Attribute("notifyLoadcellType").Value);
                    Options.ShowGridLines = bool.Parse(element.Attribute("showGridLines").Value);
                    Options.ShowLanguageForm = bool.Parse(element.Attribute("showLanguageForm").Value);

                    Options.PrintLogo = bool.Parse(element.Attribute("PrintLogo").Value);
                    Options.PrintPlot = bool.Parse(element.Attribute("PrintPlot").Value);
                    Options.PrintTestsSpec = bool.Parse(element.Attribute("PrintTestsSpec").Value);
                    Options.PrintTestResults = bool.Parse(element.Attribute("PrintTestResults").Value);
                    Options.ResetMeasuresAtStart = bool.Parse(element.Attribute("ResetMeasuresAtStart").Value);

                    Options.HugeSampleCount = element.Attribute("HugeSampleCount")?.Value?.ToInt32() ?? 1000000;
                    Test.UseTemperatureCompensation = element.Attribute("UseTemperatureCompensation")?.Value?.ToBool() ?? false;
                    Test.SetTemperatureToZeroOnTestStop= element.Attribute("SetTemperatureToZeroOnTestStop")?.Value?.ToBool() ?? true;
                    Test.MaximumTemperatureDiffrence = element.Attribute("MaximumTemperatureDiffrence")?.Value?.ToInt32() ?? 100;
                    Test.TemperatureCompensationPeriod = element.Attribute("TemperatureCompensationPeriod")?.Value?.ToInt32() ?? 10;
                    Test.BreakCounter = element.Attribute("BreakCounter")?.Value?.ToInt32() ?? 50;

                    InstrumentParameters.TemperatureAxisRange = element.Attribute("TemperatureAxisRange")?.Value?.ToInt32() ?? 50;
                }
            }
            catch
            {
            }

            try
            {
                foreach (XElement element in documet.Descendants("test").Descendants("def"))
                {
                    Options.DefTestPath = element.Attribute("path").Value;
                }
            }
            catch
            {
            }
        }

        public List<ReportingParameters> LoadReportingTableColumns()
        {
            try
            {
                var cols = documet.Descendants("Report").Descendants("TableColumns").Descendants("col").Select(
                    p => new ReportingParameters
                    {
                        PointType = (PointType)Enum.Parse(typeof(PointType), p.Attribute("PointType").Value),
                        PointProperty = (PointProperty)Enum.Parse(typeof(PointProperty), p.Attribute("PointProperty").Value),
                        Name = p.Attribute("Name").Value.Equals("n/a") ? "" : p.Attribute("Name").Value,
                        Label = p.Attribute("Label").Value.Equals("n/a") ? "" : p.Attribute("Label").Value,
                        StepOrCycle = p.Attribute("StepOrCycle").Value.ToInt32(),
                        Attribute1 = p.Attribute("Attribute1").Value.Equals("n/a") ? (double?)null : p.Attribute("Attribute1").Value.ToDouble(),
                        Attribute2 = p.Attribute("Attribute2").Value.Equals("n/a") ? (double?)null : p.Attribute("Attribute2").Value.ToDouble(),
                        Attribute3 = p.Attribute("Attribute3").Value.Equals("n/a") ? (double?)null : p.Attribute("Attribute3").Value.ToDouble(),
                        Formula = p.Attribute("Formula").Value.Equals("n/a") ? "" : p.Attribute("Formula").Value,
                        ExpectedRangeA = p.Attribute("ExpectedRangeA").Value.Equals("n/a") ? (double?)null : p.Attribute("ExpectedRangeA").Value.ToDouble(),
                        ExpectedRangeB = p.Attribute("ExpectedRangeB").Value.Equals("n/a") ? (double?)null : p.Attribute("ExpectedRangeB").Value.ToDouble(),
                        ResultYellowRangeA = p.Attribute("ResultYellowRangeA").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultYellowRangeA").Value.ToDouble(),
                        ResultYellowRangeB = p.Attribute("ResultYellowRangeB").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultYellowRangeB").Value.ToDouble(),
                        ResultRedRangeA = p.Attribute("ResultRedRangeA").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultRedRangeA").Value.ToDouble(),
                        ResultRedRangeB = p.Attribute("ResultRedRangeB").Value.Equals("n/a") ? (double?)null : p.Attribute("ResultRedRangeB").Value.ToDouble(),
                        EnableAnalysing = bool.Parse(p.Attribute("EnableAnalysing").Value)

                    }).ToList();

                return cols;
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return null;
        }

        public void SaveReportingTableColumns(List<ReportingParameters> reportingParameteres)
        {
            documet.Descendants("Report").Descendants("TableColumns").Descendants("col").Remove();
            foreach (var xElement in documet.Descendants("Report").Descendants("TableColumns"))
            {

                foreach (var parametere in reportingParameteres)
                {
                    xElement.Add(
                        new XElement("col",
                            new XAttribute("PointType", parametere.PointType),
                            new XAttribute("PointProperty", parametere.PointProperty),
                            new XAttribute("Name", parametere.Name ?? "n/a"),
                            new XAttribute("Label", parametere.Label ?? "n/a"),
                            new XAttribute("StepOrCycle", parametere.StepOrCycle),
                            new XAttribute("Attribute1", parametere.Attribute1.HasValue ? parametere.Attribute1.Value.ToString() : "n/a"),
                            new XAttribute("Attribute2", parametere.Attribute2.HasValue ? parametere.Attribute2.Value.ToString() : "n/a"),
                            new XAttribute("Attribute3", parametere.Attribute3.HasValue ? parametere.Attribute3.Value.ToString() : "n/a"),
                            new XAttribute("Formula", parametere.Formula.Length > 0 ? parametere.Formula : "n/a"),
                            new XAttribute("ExpectedRangeA", parametere.ExpectedRangeA.HasValue ? parametere.ExpectedRangeA.Value.ToString() : "n/a"),
                            new XAttribute("ExpectedRangeB", parametere.ExpectedRangeB.HasValue ? parametere.ExpectedRangeB.Value.ToString() : "n/a"),
                            new XAttribute("ResultYellowRangeA", parametere.ResultYellowRangeA.HasValue ? parametere.ResultYellowRangeA.Value.ToString() : "n/a"),
                            new XAttribute("ResultYellowRangeB", parametere.ResultYellowRangeB.HasValue ? parametere.ResultYellowRangeB.Value.ToString() : "n/a"),
                            new XAttribute("ResultRedRangeA", parametere.ResultRedRangeA.HasValue ? parametere.ResultRedRangeA.Value.ToString() : "n/a"),
                            new XAttribute("ResultRedRangeB", parametere.ResultRedRangeB.HasValue ? parametere.ResultRedRangeB.Value.ToString() : "n/a"),
                            new XAttribute("EnableAnalysing", parametere.EnableAnalysing)
                            ));
                }

            }
            documet.Save(XmlPath);
        }

        public void SaveReportingTableOptions()
        {
            foreach (var xElement in documet.Descendants("Report").Descendants("TableOption"))
            {
                xElement.Attribute("ElasticModuleMinPercent").Value = ReportingParameters.ElasticModuleMinPercent.ToString();
                xElement.Attribute("ElasticModuleMaxPercent").Value = ReportingParameters.ElasticModuleMaxPercent.ToString();
                xElement.Attribute("ShowAcceptableRange").Value = ReportingParameters.ShowAcceptableRange.ToString();
                xElement.Attribute("ShowElasticModule").Value = ReportingParameters.ShowElasticModule.ToString();
                xElement.Attribute("ShowMeanRMS").Value = ReportingParameters.ShowMeanRMS.ToString();
                xElement.Attribute("UseRegression").Value = ReportingParameters.UseRegression.ToString();
                try
                {
                    xElement.Attribute("ShowUtYield").Value = ReportingParameters.ShowUtYield.ToString();
                }
                catch { }
            }
            documet.Save(XmlPath);
        }

        public void LoadReportingTableOptions()
        {
            foreach (var xElement in documet.Descendants("Report").Descendants("TableOption"))
            {
                ReportingParameters.ElasticModuleMinPercent = xElement.Attribute("ElasticModuleMinPercent").Value.ToDouble();
                ReportingParameters.ElasticModuleMaxPercent = xElement.Attribute("ElasticModuleMaxPercent").Value.ToDouble();
                ReportingParameters.ShowAcceptableRange = bool.Parse(xElement.Attribute("ShowAcceptableRange").Value);
                ReportingParameters.ShowElasticModule = bool.Parse(xElement.Attribute("ShowElasticModule").Value);
                ReportingParameters.ShowMeanRMS = bool.Parse(xElement.Attribute("ShowMeanRMS").Value);
                ReportingParameters.ShowUtYield = bool.Parse(xElement.Attribute("ShowUtYield")?.Value??"false");
                ReportingParameters.UseRegression = bool.Parse(xElement.Attribute("UseRegression").Value);
            }
        }

        public void Dispose()
        {
        }



    }
}
