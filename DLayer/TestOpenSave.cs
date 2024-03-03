using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using STM.BLayer;
using System.Collections.Generic;
using STM.BLayer.Reporting;
using STM.BLayer.StmTest;
using STM.BLayer.TestSample;
using System;
using System.Text;
using STM.PLayer.UI;
using STM.Extensions;
using System.Xml.Linq;

namespace STM.DLayer
{
    class TestOpenSave
    {
        static readonly object Lck = "TestOpenSaveLock";
        private readonly Dictionary<int, Color> drawingColors;
        private Dictionary<string ,int> currentTestIds;
        public readonly Dictionary<string, string> testNamePath;
        static TestOpenSave instanse;
        private string testName;
        private StreamWriter currentTestWriter;
        public static TestOpenSave Current
        {
            get
            {
                if(instanse== null)
                {
                    lock (Lck)
                    {
                        if(instanse== null)
                        {
                            instanse = new TestOpenSave();
                        }

                    }
                }
                return instanse;
            }
        }

        private TestOpenSave()
        {
            currentTestIds = new Dictionary<string, int>();
            testNamePath = new Dictionary<string, string>();
            drawingColors = new Dictionary<int, Color>
            {
            {1, Color.Black},
            {2, Color.Blue},
            {3, Color.Green},
            {4, Color.Red},
            {5, Color.Yellow},
            {6, Color.Maroon},
            {7, Color.Lime},
            {8, Color.Purple},
            {9, Color.DarkOrange},
            {10, Color.Pink}
            };
        }

        public void StartNewTestLog(UnitMainCategories unitCategory, TestDataSource dataSource, List<ReportingParameters> rParams,
                             MeasureType xMeasure, MeasureType yMeasure, string path)
        {
            try
            {
                currentTestWriter?.Close();
                currentTestWriter = new StreamWriter(path) {AutoFlush = true};

                currentTestWriter.WriteLine("TestSettings");
                try
                {
                    currentTestWriter.WriteLine(dataSource.XmlTestSetting);
                }
                catch (Exception)
                {
                }
                currentTestWriter.WriteLine("/TestSettings");
                
                currentTestWriter.WriteLine("Sample");
                try
                {
                    currentTestWriter.WriteLine(dataSource.TestSample.GetSaveString());
                }
                catch (Exception)
                {
                }
                currentTestWriter.WriteLine("/Sample");

                currentTestWriter.WriteLine("Information");
                try
                {
                    currentTestWriter.WriteLine(dataSource.TestInformation.GetSaveString());
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                currentTestWriter.WriteLine("/Information");

                currentTestWriter.WriteLine("Mode");
                try
                {
                    currentTestWriter.WriteLine("Mode: " + dataSource.TestMethodType);
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                currentTestWriter.WriteLine("/Mode");

                currentTestWriter.WriteLine("Diagram");
                try
                {
                    currentTestWriter.WriteLine("X: {0}", xMeasure);
                    currentTestWriter.WriteLine("Y: {0}", yMeasure);
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                currentTestWriter.WriteLine("/Diagram");

                currentTestWriter.WriteLine("PointsParams");
                try
                {
                    foreach (var point in rParams)
                    {
                        currentTestWriter.WriteLine(point.GetSaveString());
                    }
                }
                catch (Exception)
                {
                }
                currentTestWriter.WriteLine("/PointsParams");

                currentTestWriter.WriteLine("Data");
            }
            catch (Exception)
            {
            }
        }

        public void AddDataSample(DataSample dataSample)
        {
            currentTestWriter?.WriteLine(dataSample.GetSaveString());
        }

        public void TerminateCurrentTest()
        {
            try
            {
                if (currentTestWriter == null) return;
                currentTestWriter.WriteLine("/Data");
                currentTestWriter.Close();
                currentTestWriter = null;
            }
            catch
            {
                
            }
        }

        public void SaveTest(UnitMainCategories unitCategory, TestDataSource dataSource, List<ReportingParameters> rParams, 
                             MeasureType xMeasure, MeasureType yMeasure, string path)
        {
            try
            {

                var writer = new StreamWriter(path);
                
                writer.WriteLine("TestSettings");
                try
                {
                    writer.WriteLine(dataSource.XmlTestSetting);
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                writer.WriteLine("/TestSettings");
                writer.Flush();

                
                writer.WriteLine("Sample");
                try
                {
                    writer.WriteLine(dataSource.TestSample.GetSaveString());
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                writer.WriteLine("/Sample");
                writer.Flush();

                
                writer.WriteLine("Information");
                try
                {
                    writer.WriteLine(dataSource.TestInformation.GetSaveString());
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                writer.WriteLine("/Information");
                writer.Flush();

                
                writer.WriteLine("Mode");
                try
                {
                    writer.WriteLine("Mode: " + dataSource.TestMethodType);
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                writer.WriteLine("/Mode");
                writer.Flush();

                
                writer.WriteLine("Diagram");
				try
				{
					writer.WriteLine("X: {0}", xMeasure);
					writer.WriteLine("Y: {0}", yMeasure);
					writer.WriteLine("Y2: {0}", dataSource.HasTemperature ? MeasureType.Temperature.ToString() : MeasureType.None.ToString());
				}
				catch (Exception exception)
				{
					exception.ToString();
				}
                writer.WriteLine("/Diagram");
                writer.Flush();


                writer.WriteLine("PointsParams");
                try
                {
                    foreach (var point in rParams)
                    {
                         writer.WriteLine(point.GetSaveString());
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                writer.WriteLine("/PointsParams");
                writer.Flush();

                writer.WriteLine("Data");
                try
                {
                    writer.WriteLine("#Step, Extension(mm), Force(N), Time(sec), Amb Temp(°C), Zone Temp 1 (°C), Zone Temp 2 (°C), Zone Temp 3 (°C), Spec Temp DN(°C), Spec Temp CNT(°C), Spec Temp UP(°C)");
                    foreach (var testSample in dataSource.Samples)
                        writer.WriteLine(testSample.GetSaveString());
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
                writer.WriteLine("/Data");
                writer.Flush();
                writer.Close();
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        public string ReadSpecification(string path, out TestingSample sample, out TestInformation information,
                                        out TestMethodType testMethodType, bool addToCurrentTests = false)
        {
            sample = null;
            information = null;
            testMethodType = 0;
            int dataCount = 0;
            try
            {
                var reader = new StreamReader(path);

                while (!reader.EndOfStream)
                {
                    if(dataCount>=3)
                    {
                        reader.Close();
                        break;
                    }
                    var code = reader.ReadLine();
                    switch (code)
                    {
                        case "Sample":
                            {
                                while (true)
                                {
                                    var line = reader.ReadLine();
                                    if (line.Contains("/Sample"))
                                        break;
                                    sample = new TestingSample(line);
                                    dataCount++;
                                }
                            }
                            break;

                        case "Information":
                            {
                                var data = "";
                                while (true)
                                {
                                    var line = reader.ReadLine();
                                    if (line.Contains("/Information"))
                                    {
                                        information = new TestInformation(data);
                                        dataCount++;
                                        break;
                                    }
                                    data += line + Environment.NewLine;
                                }
                            }
                            break;

                        case "Mode":
                            {
                                var line = reader.ReadLine();
                                if (line.Contains("/Mode"))
                                {
                                    dataCount++;
                                    break;
                                }

                                testMethodType = (TestMethodType)Enum.Parse(typeof(TestMethodType), line.Remove(0, "Mode: ".Length));
                            }
                            break;

                    }
                }

                if(addToCurrentTests)
                {
                    testName = path.Split('\\').Last().Replace(".ttdx","");
                    testNamePath[testName] = path;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return testName;
        }

        public string ReadSpecification_PrevVersions(string path, out TestingSample sample, out TestInformation information,
                                       out TestMethodType testMethod, bool addToCurrentTests = false)
        {
            sample = null;
            information = null;
            testMethod = 0;
            int dataCount = 0;
            try
            {
                var reader = new StreamReader(path);
                var breakWhile = false;
                while (!reader.EndOfStream && !breakWhile)
                {
                    if (dataCount >= 3)
                    {
                        reader.Close();
                        break;
                    }
                    var code = reader.ReadLine()?.Trim()?.ToUpper();				
                    switch (code)
                    {
                        case "SPECIMEN":
                            {
                                var type = reader.ReadLine()?.Trim()?.ToUpper(); // RECTANGULAR   DIAMETER  WEIGH  AREA
                                var p1 = reader.ReadLine().Trim().ToDouble();  // dimameter
                                var p2 = reader.ReadLine().Trim().ToDouble();  // inner diameter
                                var p3 = reader.ReadLine().Trim().ToDouble(); // thickness // area
                                var p4 = reader.ReadLine().Trim().ToDouble(); // width
                                var p5 = reader.ReadLine().Trim().ToDouble(); // g len
                                var p6 = reader.ReadLine().Trim().ToDouble();  // density
                                var p7 = reader.ReadLine().Trim().ToDouble();  // weight
                                var p8 = reader.ReadLine().Trim().ToDouble();  // total len
                                var id = reader.ReadLine();  // sample

                                switch (type)
                                {
                                    case "RECTANGULAR":
                                        sample = new TestingSample(TensionCompressionSampleType.Rectangular, id, p5, p4, p3, 0);
                                        break;

                                    case "DIAMETER":
                                        sample = new TestingSample(TensionCompressionSampleType.Pipe, id, p5, p1, p2, 0);
                                        break;

                                    case "WEIGH":
                                        sample = new TestingSample(TensionCompressionSampleType.Weight, id, p5, p6, p7, p8);
                                        break;

                                    case "AREA":
                                        sample = new TestingSample(TensionCompressionSampleType.Area, id, p5, p3, 0, 0);
                                        break;
                                }

                                var date = reader.ReadLine().Trim();
                                information = new TestInformation() { Date = date };
                            }
                            break;


                        case "MODE":
                            {
                                var line = reader.ReadLine()?.Trim()?.ToUpper();
                                switch (line)
                                {
                                    case "TENSILE": testMethod = TestMethodType.Tensile;
                                        break;

                                    case "RELAXATION": testMethod = TestMethodType.Relaxation;
                                        break;

                                    case "CREEP": testMethod = TestMethodType.Creep;
                                        break;

                                    case "CYCLIC": testMethod = TestMethodType.Cyclic;
                                        break;

                                    case "STEP": testMethod = TestMethodType.Step;
                                        break;

                                    case "COMPRESSIVE": testMethod = TestMethodType.Compressive;
                                        break;
                                }

                                breakWhile = true;
                            }
                            break;

                    }
                }

                if (addToCurrentTests)
                {
                    testName = path.Split('\\').Last().Split('.')[0];
                    testNamePath[testName] = path;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return testName;
        }

        public TestDataSource Read(string fullPath, out List<ReportingParameters> reportPoints)
        {
            try
            {
                var name = fullPath;
                fullPath = testNamePath[fullPath];
                UnitMainCategories mainUints;
                TestDataSource dataSource;

                OpenTest(fullPath, out mainUints, out dataSource, out reportPoints);
                if (dataSource != null)
                {
                    dataSource.FullPath = fullPath;
                    int testId;
                    var extension = fullPath.Split('\\').Last().Split('.').Last();
                    dataSource.Name = fullPath.Split('\\').Last().Replace("." + extension, "");
                    dataSource.DrawingColor = GetColor(dataSource.Name, out testId);
                    dataSource.TestId = testId;
                    dataSource.TestName = testName;
                    return dataSource;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reportPoints= new List<ReportingParameters>();
            return null;
        }

        private void OpenTest(string path, out UnitMainCategories unitCategory, out TestDataSource dataSource, out  List<ReportingParameters> points)
        {
            dataSource = null;
            unitCategory = UnitMainCategories.SI;
            TestingSample sample = null;
            TestInformation information = null;
            TestMethodType Test_method_type = 0;

            MeasureType xMeasure = MeasureType.Extension;
            MeasureType yMeasure = MeasureType.Force;
			MeasureType y2Measure = MeasureType.None;

			bool settingsRead = false;
            var sb = new StringBuilder();
            points = new List<ReportingParameters>();

            var reader = new StreamReader(path);

            while (!reader.EndOfStream)
            {
                var code = reader.ReadLine();
                switch (code?.ToUpper())
                {
                    // Nazarpour 1402/06/22
                    case "SPECIMEN":
                    {
                        var data = "Sample: ";
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line == null || line.Trim() == "" || line.ToUpper().Contains("/SAMPLE"))
                                break;
                            data += ((char)3) + line.Replace("\n", "").Replace("\r", "");
                        }

                        sample = new TestingSample(data);
                    }
                        break;

                    case "SAMPLE":
                    {
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line?.ToUpper()?.Contains("/SAMPLE") ?? false)
                                break;
                            sample = new TestingSample(line);
                        }
                    }
                        break;

                    case "INFORMATION":
                    {
                        var data = "";
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line?.ToUpper()?.Contains("/INFORMATION") ?? false)
                            {
                                information = new TestInformation(data);
                                break;
                            }

                            data += line + Environment.NewLine;
                        }
                    }
                        break;

                    case "MODE":
                    {
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line?.ToUpper()?.Contains("/MODE") ?? false)
                                break;
                            if (line.StartsWith("Mode: "))
                                Test_method_type = (TestMethodType)Enum.Parse(typeof(TestMethodType),
                                    line.Remove(0, "Mode: ".Length));
                            else
                            {
                                Test_method_type = (TestMethodType)Enum.Parse(typeof(TestMethodType),
                                    line.Substring(0, 1).ToUpper() + line.Substring(1).ToLower());
                                break;
                            }
                        }
                    }
                        break;

                    case "DIAGRAM":
                    {
                        while (true)
                        {
                            var line = reader.ReadLine();
                            xMeasure = MeasureTool.GetMeasureType(line.Replace("X: ", "").Trim());
                            xMeasure = MeasureTool.IsExtension(xMeasure) ? MeasureType.Extension : xMeasure;
                            line = reader.ReadLine();
                            yMeasure = MeasureTool.GetMeasureType(line.Replace("Y: ", "").Trim());
                            yMeasure = MeasureTool.IsExtension(yMeasure) ? MeasureType.Extension : yMeasure;
                            line = reader.ReadLine();
                            if (line?.ToUpper()?.StartsWith("Y2: ") ?? false)
                            {
                                y2Measure = MeasureTool.GetMeasureType(line.Replace("Y2: ", "").Trim());
                                y2Measure = MeasureTool.IsExtension(y2Measure) ? MeasureType.Extension : y2Measure;
                                line = reader.ReadLine();
                            }

                            if (line?.ToUpper()?.Contains("/DIAGRAM") ?? false)
                            {
                                break;
                            }
                        }
                    }
                        break;

                    case "POINTSPARAMS":
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line?.ToUpper()?.Contains("/POINTSPARAMS") ?? false)
                                break;
                            points.Add(new ReportingParameters(line));
                        }

                        break;

                    case "DATA":
                    {
                        dataSource = new TestDataSource();
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line == null || line.Trim() == "" || line.ToUpper().Contains("/DATA"))
                                break;
                            if (!line.StartsWith("#"))
                                dataSource.Samples.Add(new DataSample(line));
                        }
                    }
                        break;

                    default:
                        if (!code.StartsWith("#"))
                        {
                            if (code?.ToUpper() == "TESTSETTINGS")
                                sb = new StringBuilder();
                            else if (code?.ToUpper() != "/TESTSETTINGS" && !settingsRead)
                                sb.AppendLine(code);
                            else
                                settingsRead = true;
                        }

                        break;
                }
            }

            reader.Close();


            if (dataSource == null) return;
            dataSource.XmlTestSetting = sb.ToString();
            dataSource.TestMethodType = Test_method_type;
            dataSource.TestSample = sample;
            dataSource.TestInformation = information;
            dataSource.XMeasureType = xMeasure;
            dataSource.YMeasureType = yMeasure;
			dataSource.Y2MeasureType = y2Measure;
            try
            { // Nazarpour 1399/11/11
                var xmlDoc = XDocument.Parse(dataSource.XmlTestSetting);
                var method = xmlDoc.Descendants("root").Descendants("GetTestParameters").First();
                dataSource.Y2SetPoint = double.Parse(method.Attribute("CreepTemperature").Value);
            }
            catch (Exception e) // 1400/2/28, Nazarpour
            {
                double tmin = double.MaxValue, tmax = double.MinValue, tavg=0;
                int c = 0;
                foreach (var s in dataSource.Samples)
                    if(s.NumberOfTemperatureSensors > 0)
                    {
                        foreach (var t in s.Temperature)
                        {
                            if (t < tmin && t>0) tmin = t;
                            if (t > tmax) tmax = t;
                            if (t > 0) { c++; tavg += t; }
                        }
                    }
                //dataSource.Y2SetPoint = (tmax + tmin) / 2;
                if (c > 0) dataSource.Y2SetPoint = tavg / c; else dataSource.Y2SetPoint = 0;
            }
			if (Test_method_type == TestMethodType.Relaxation)
            {
                var stepId = dataSource.Samples.Last().StepOrCycle;
                var index = dataSource.Samples.FindIndex(p => p.StepOrCycle == stepId);
                for (int i = index; i < dataSource.Samples.Count; i++)
                    dataSource.Samples[i].MarkedLoad = dataSource.Samples[index].Force;
            }
        }

        private void OpenTest_PrevVersions(string path, out UnitMainCategories unitCategory, out TestDataSource dataSource,
                            out  List<ReportingParameters> points)
        {
            dataSource = null;
            unitCategory = UnitMainCategories.SI;
            TestingSample sample = null;
            TestInformation information = null;
            TestMethodType testMethod = 0;

            MeasureType xMeasure = MeasureType.Extension;
            MeasureType yMeasure = MeasureType.Force;
			MeasureType y2Measure = MeasureType.None;

			bool settingsRead = false;
            var sb = new StringBuilder();
            points = new List<ReportingParameters>();

            var reader = new StreamReader(path);

            while (!reader.EndOfStream)
            {
                var code = reader.ReadLine();
                switch (code)
                {
                    case "UNITS":
                        {
                            var unit = reader.ReadLine().Trim().ToUpper();
                            switch (unit)
                            {
                                case "SI": unitCategory = UnitMainCategories.SI; break;
                                case "BS": unitCategory = UnitMainCategories.BS; break;
                                case "MKS": unitCategory = UnitMainCategories.MKS; break;
                                default: unitCategory = UnitMainCategories.SI; break;
                            }
                        }
                        break;
                    case "SPECIMEN":
                        {
                            var type = reader.ReadLine().Trim().ToUpper(); // RECTANGULAR   DIAMETER  WEIGH  AREA
                            var p1 = reader.ReadLine().Trim().ToDouble();  // dimameter
                            var p2 = reader.ReadLine().Trim().ToDouble();  // inner diameter
                            var p3 = reader.ReadLine().Trim().ToDouble(); // thickness // area
                            var p4 = reader.ReadLine().Trim().ToDouble(); // width
                            var p5 = reader.ReadLine().Trim().ToDouble(); // g len
                            var p6 = reader.ReadLine().Trim().ToDouble();  // density
                            var p7 = reader.ReadLine().Trim().ToDouble();  // weight
                            var p8 = reader.ReadLine().Trim().ToDouble();  // total len
                            var id = reader.ReadLine();  // sample

                            switch (type)
                            {
                                case "RECTANGULAR":
                                    sample = new TestingSample(TensionCompressionSampleType.Rectangular, id, p5, p4, p3, 0);
                                    break;

                                case "DIAMETER":
                                    sample = new TestingSample(TensionCompressionSampleType.Pipe, id, p5, p1, p2, 0);
                                    break;

                                case "WEIGH":
                                    sample = new TestingSample(TensionCompressionSampleType.Weight, id, p5, p6, p7, p8);
                                    break;

                                case "AREA":
                                    sample = new TestingSample(TensionCompressionSampleType.Area, id, p5, p3, 0, 0);
                                    break;
                            }

                            var date = reader.ReadLine().Trim();
                            information = new TestInformation() { Date = date };
                        }
                        break;

                    case "MODE":
                        {
                            var line = reader.ReadLine().Trim().ToUpper();
                            switch (line)
                            {
                                case "TENSILE": testMethod = TestMethodType.Tensile;
                                    break;

                                case "RELAXATION": testMethod = TestMethodType.Relaxation;
                                    break;

                                case "CREEP": testMethod = TestMethodType.Creep;
                                    break;

                                case "CYCLIC": testMethod = TestMethodType.Cyclic;
                                    break;

                                case "STEP": testMethod = TestMethodType.Step;
                                    break;

                                case "COMPRESSIVE": testMethod = TestMethodType.Compressive;
                                    break;
                            }
                        }
                        break;
                    case "[USERS]":
                        {
                            var customer = reader.ReadLine().Trim();
                            var op = reader.ReadLine().Trim();
                            information.CustomerName = customer;
                            information.OperatorName = op;
                        }
                        break;

                    case "[COMMENTS]":
                        {
                            var coms = new List<string>();
                            reader.ReadLine();
                            while (true)
                            {
                                var comment = reader.ReadLine();
                                if (comment.Equals("End."))
                                    break;

                                coms.Add(comment);
                            }
                            information.Description = coms.ToArray();
                        }
                        break;


                    case "[TABLE]":
                        while (true)
                        {
                            var line = reader.ReadLine();
                            if (line.Trim().Equals(""))
                                break;

                            var def = line.Split("=,:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            var name = def[0];
                            var pType = def[1].Trim().ToUpper();
                            var atPoint1 = def[2];
                            var atPoint2 = def[3];
                            var codes = int.Parse(def[4].Trim().Replace("&H", ""), NumberStyles.HexNumber);
                            PointType pointType = PointType.Force;
                            switch (pType)
                            {
                                case "FORCE": pointType = PointType.Force; break;
                                case "EXTENSION": pointType = PointType.Extension; break;
                                case "Stress": pointType = PointType.Stress; break;
                                case "Strain": pointType = PointType.Strain; break;
                                case "Offset": pointType = PointType.YieldOffset; break;
                                case "Exten Limit": pointType = PointType.ExtenLimit; break;
                                case "Elong Limit": pointType = PointType.StrainLimit; break;
                                case "Time": pointType = PointType.Time; break;
                            }
                            int nameId = 0;
                            if ((codes & 2) == 2)
                            {
                                var property = PointProperty.Force;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 4) == 4)
                            {
                                var property = PointProperty.Extension;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 8) == 8)
                            {
                                var property = PointProperty.
                                    Stress;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 16) == 16)
                            {
                                var property = PointProperty.Strain;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 32) == 32)
                            {
                                var property = PointProperty.ElongationAfterBreak;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;

                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 64) == 64)
                            {
                                var property = PointProperty.BendingModule;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;

                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 128) == 128)
                            {
                                var property = PointProperty.Energy;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 256) == 256)
                            {
                                var property = PointProperty.BendingStress;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                            if ((codes & 512) == 512)
                            {
                                var property = PointProperty.Time;
                                var label = property.ToString();
                                var pName = nameId == 0 ? name : name + nameId;
                                nameId++;
                                points.Add(new ReportingParameters
                                {
                                    Attribute1 = atPoint1.ToInt32(),
                                    Label = label,
                                    Name = pName,
                                    PointProperty = property,
                                    PointType = pointType
                                });
                            }
                        }
                        break;

                    case "DATA":
                        {
                            dataSource = new TestDataSource();
                            while (true)
                            {
                                var line = reader.ReadLine();
                                if (line.Trim().Equals(""))
                                    break;
                                dataSource.Samples.Add(new DataSample(line));
                            }
                        }
                        break;

                    default:
                        if (code == "TestSettings")
                            sb = new StringBuilder();
                        else if (code != "/TestSettings" && !settingsRead)
                            sb.AppendLine(code);
                        else
                            settingsRead = true;
                        break;
                }
            }
            reader.Close();


            if (dataSource == null) return;
            dataSource.XmlTestSetting = sb.ToString();
            dataSource.TestMethodType = testMethod;
            dataSource.TestSample = sample;
            dataSource.TestInformation = information;
            dataSource.XMeasureType = xMeasure;
            dataSource.YMeasureType = yMeasure;
			dataSource.Y2MeasureType = y2Measure;
		}

        public void RemoveTestRecord(string test)
        {
            currentTestIds.Remove(test);
            testNamePath.Remove(test);
        }

        public bool ClearLastTests
        {
            set
            {
                if (!value) return;
                currentTestIds.Clear();
                testNamePath.Clear();
            }
        }

        private Color GetColor(string test, out int index)
        {
            index = 1;
            if (currentTestIds == null)
                currentTestIds = new Dictionary<string, int>();
            try
            {
                var usedColors = currentTestIds.Values.OrderBy(p => p).ToList();
                foreach (var id in usedColors)
                {
                    if (index != id)
                    {
                        currentTestIds[test] = index;
                        return drawingColors[index];
                    }
                    index++;
                }
                index++;
                currentTestIds[test] = index;
                return drawingColors[index];
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

            return Color.Black;
        }
    }
}
