using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using STM.BLayer.Parameters;
using STM.BLayer.TestSample;
using STM.DLayer;
using STM.PLayer.UI;
using STM.Sensor;
using System.Windows.Forms;
using STM.Extensions;
using System.Threading.Tasks;
using System.Linq;
using STM.Properties;

namespace STM.BLayer.StmTest
{
    public class Test
    {
        public delegate void TemperatureCompensationCalculations(bool applied, float[] setPoints, float[] averages, float[] currents, int unbalance, DateTime startDateTime, int delta);
        public static TemperatureCompensationCalculations OnTemperatureCompensationCalculations;

        public delegate void StageChanged(int id, string stageDescription);
        public StageChanged OnStageChanged;

        // Nazarpour 1399/11/14
        public class TestFinishEventArgs : EventArgs
        {
            public static readonly TestFinishEventArgs Finished = new TestFinishEventArgs(TerminationReason.Finished);
            public static readonly TestFinishEventArgs Break = new TestFinishEventArgs(TerminationReason.Break);
            public static readonly TestFinishEventArgs Limits = new TestFinishEventArgs(TerminationReason.Limits);
            public static readonly TestFinishEventArgs Protection = new TestFinishEventArgs(TerminationReason.Protection);
            public static readonly TestFinishEventArgs FatalError = new TestFinishEventArgs(TerminationReason.FatalError);
            public static readonly TestFinishEventArgs Exception = new TestFinishEventArgs(TerminationReason.Exception);
            public static readonly TestFinishEventArgs UserRequest = new TestFinishEventArgs(TerminationReason.UserRequest);

            public enum TerminationReason
            {
                Finished,
                Break,
                Limits,
                Protection,
                FatalError,
                Exception,
                UserRequest,
            }

            public readonly TerminationReason Reason;
            public double ForceAtBreak { get; set; }

            public TestFinishEventArgs(TerminationReason reason)
            {
                Reason = reason;
            }
        }

        // 1400/04/05 Nazarpour
        public enum ElectroHydrolicCrossHeadStates
        {
            Ignore = 0,
            CheckDirection,
            UpwardDirection,
            DownwardDirection
        }
        public static ElectroHydrolicCrossHeadStates ElectroHydrolicCrossHeadState = ElectroHydrolicCrossHeadStates.Ignore;

        public event EventHandler<TestFinishEventArgs> OnTestStops;
        public event EventHandler<EventArgs> OnStopTestS2E;
        public event EventHandler<EventArgs> OnContinueTestS2E;

        public static double JogSpeed { set; get; }
        public static int ReturnToZeroSpeed { set; get; }
        public ReturnZeroMode returnZeroMode { get; private set; }
        private StopCode stopCode;
        private bool newStepStartet;
        public TestingSample TestingSample { private set; get; }
        public TestInformation TestInformation { private set; get; }
        public static TestMethodType TestMethodType { set; get; }
        public string TestPath { set; get; }
        public TestStage curStage;
        private bool _IsLongRunning = false;
        public bool IsLongRunning
        {
            get { return _IsLongRunning && Program.FullCreepAvailable; }
            set { _IsLongRunning = value; }
        }
        private DateTime startDateTime;
        private bool TestInProgress { set; get; }

        public static TestControlMode CustomeStopType;
        public static double CustomeStopValue;
        public static StrainToExtenMode StrainToExtenMode { set; get; }
        public static double StrainToExtenSetPoint { set; get; }
        public static StrainRemoveOptions RemoveStarinOptions { set; get; }
        public static bool StrainToExtenEnabled { set; get; }
        private bool s2E;
        private bool strainRemoved;
        private bool peakDetected;

        public static double? BreakForceOver { set; get; }
        private readonly AvgFilter testFilter;
        public readonly List<TestStage> stages;
        private int receivedSampleCount;

        private double force;
        private double exExtension;
        private double lfEncoderExtension;
        private double extension;
        private double stress;
        private double strain;

        private static int NumberOfTemperaturChannels = Math.Max(TMPR232.NumberOfTemperaturChannels, TMPR485.NumberOfTemperaturChannels);

        // Nazarpour 1399/10/14: Array instead of varables
        private static readonly float[] temperatureValue = new float[NumberOfTemperaturChannels];
        private static readonly float[] temperatureData = new float[NumberOfTemperaturChannels];
        private bool RaiseRichingLimits = false;

        private double pForce;
        private double pExtension;
        private double pStress;
        private double pStrain;

        private double massStress, lengthStress;
        private double motorSpeed;
        private double trueStress;
        private double trueStrain;

        private double maxAmpForce;
        private const string LogTestPath = "C:\\Windows\\System32\\stx.pl";

        private static bool firstRead;
        private int noisyData;
        public static double ExtenCurPosition { set; get; }

        private bool ExtensometerInUse
        {
            get
            {
                if (Sensors.CurrentExtensoMeter != null && Sensors.CurrentExtensoMeter.EncoderBased && InstrumentParameters.UseExtensometer)
                    return true;
                return !Status.ExtensometerFailure && InstrumentParameters.UseExtensometer;
            }
        }

        // 1399/11/30 Nazarpour
        public static bool SetTemperatureToZeroOnTestStop { get; set; }
        public static int BreakCounter { get; set; }
        public static bool UseTemperatureCompensation { get; set; }
        public static DateTime NextTemperatureCompensationTime { get; set; }
        public static int TemperatureCompensationPeriod { get; set; }
        public static int TemperatureResetCounter { get; set; }
        public static float[] LastSetPoints { get; set; }
        // 1400/09/13 Nazarpour
        public static int MaximumTemperatureDiffrence { get; set; }

        private static float[] TemperatureSum;
        private static int TemperatureSumCount;
        private float lastTempSetpoint = 0;

        #region constructor

        static Test()
        {
            UseTemperatureCompensation = true;
            LastSetPoints = new float[NumberOfTemperaturChannels];
        }

        public Test(TestingSample sample, TestInformation customerOperator, string testName = "")
        {
            stages = new List<TestStage>();
            curStage = null;
            noisyData = 0;
            TestingSample = sample;
            TestInformation = customerOperator;
            TestInformation.Date = TestInformation.CurrentDate;
            TestInformation.DateCultureFormat = TestInformation.DateCultureFormats.System;
            testFilter = new AvgFilter();

            var dt = DateTime.Now;
            var dtStr = string.Format("{0}.{1}.{2}", dt.Hour, dt.Minute, dt.Second);
            TestPath = string.Format("{0}", string.IsNullOrEmpty(testName) ? dtStr : testName);
            strainRemoved = false;
            peakDetected = false;
        }

        public Test()
        {
            testFilter = new AvgFilter();
            firstRead = true;


        }

        #endregion

        #region initiating start stop test

        public void AddStage(TestStage stage)
        {
            stages.Add(stage);
        }

        private bool InitiateStarting()
        {
            try
            {
                InitiateNewStage();
                noisyData = 0;
                return true;
            }
            catch
            {
            }
            return false;
        }

        public void Start()
        {
            try
            {
                if (Options.ResetMeasuresAtStart)
                {
                    ZeroExExtension();
                    ZeroLfExtension();
                }
                if (Math.Abs(ExtenCurPosition) > double.Epsilon)
                {
                    ZeroExExtension();
                    ZeroLfExtension();
                    Sensors.CurrentEncoder.SetExtensionBase(ExtenCurPosition);
                    if (Sensors.CurrentExtensoMeter != null)
                        Sensors.CurrentExtensoMeter.SetExtensionBase(ExtenCurPosition);
                }
                testFilter.Reset();

                LastSetPoints = null;
                NextTemperatureCompensationTime = DateTime.Now.AddMinutes(TemperatureCompensationPeriod);

                TemperatureSum = new float[NumberOfTemperaturChannels];
                TemperatureSumCount = 0;

                SpeedControlParameters.EerrorLast = 0;
                SpeedControlParameters.EerrorSum = 0;

                SpeedControlParameters.FerrorLast = 0;
                SpeedControlParameters.FerrorSum = 0;

                SpeedControlParameters.SerrorLast = 0;
                SpeedControlParameters.SerrorSum = 0;

                ElectroHydrolicCrossHeadState = ElectroHydrolicCrossHeadStates.CheckDirection;

                //Sensors.CurrentLoadCell.SetForceBase(0);
                //Sensors.CurrentExtensoMeter.SetExtensionBase(0);
                //Sensors.CurrentEncoder.SetExtensionBase(ExtenCurPosition);
                var curStageNotNull = InitiateStarting();
                TestInProgress = curStageNotNull;
                startDateTime = DateTime.Now;
                s2E = false;
                MotorEncoder.S2EChanged = false;
                MotorEncoder.StoEExtension = 0;
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        public void StopTest()
        {
            try
            {
                TestInProgress = false;
                MotorEncoder.StoEExtension = 0;

                var writer = new StreamWriter(LogTestPath, true);
                writer.WriteLine("{0:-20}      {1}        {2}           {3}", maxAmpForce, TestInformation.PerisanDate, DateTime.Now.TimeOfDay, TestInformation.OperatorName);
                writer.Flush();
                writer.Close();
                stages.Clear();

                //Sensors.CurrentEncoder.SetExtensionBase(0);
                //Sensors.CurrentExtensoMeter.SetExtensionBase(0);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        public bool JumpToSafeStage(bool safe = true)
        {
            if (IsInSafeStage() != safe)
            {
                for (; stages.Count > 0;)
                {
                    curStage = stages[0];
                    if (IsInSafeStage() == safe)
                    {
                        InitiateNewStage();
                        break;
                    }
                    stages.RemoveAt(0);
                }
                //if(stages.Count == 0) curStage = null;
            }
            return true;
        }

        public bool IsInSafeStage()
        {
            return (curStage == null) || curStage.IsSafeStage || stages.Count == 0;
        }

        #endregion

        #region  control

        private void InitiateNewStage()
        {
            curStage = stages[0];

            if (OnStageChanged != null)
            {
                var description = curStage.StageDescription + (string.IsNullOrEmpty(curStage.StageDescription) ? "" : ", ");
                if (curStage.SetPointType > 0)
                {
                    var unit = MeasureTool.GetUnit((MeasureType)curStage.SetPointType).Abbreviation;
                    description += $"Set Point:{UnitManager.ConvertToCurrent(curStage.SetPoint.ToString(CultureInfo.InvariantCulture), unit).ToString("0.##")} ({unit})";
                }
                OnStageChanged(curStage.StageNo, description);
            }
            stages.RemoveAt(0);
            SetCrossHeadDirection();

            if (curStage.ResetTestTime)
            {
                startDateTime = DateTime.Now;
            }

            if (curStage.ResetExtensotemer)
            {
                ZeroLfExtension();
                ZeroExExtension();
            }

            // 1400/04/05 Nazarpour
            if (CrossHead.ElectroHydrolic && ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.CheckDirection)
            {
                if (CrossHead.CrossHeadDirection == CrossHeadDirection.Up)
                    ElectroHydrolicCrossHeadState = ElectroHydrolicCrossHeadStates.UpwardDirection;
                else if (CrossHead.CrossHeadDirection == CrossHeadDirection.Down)
                    ElectroHydrolicCrossHeadState = ElectroHydrolicCrossHeadStates.DownwardDirection;
            }
            SpeedControlParameters.FerrorSum = 0;
            SpeedControlParameters.SerrorSum = 0;
            SpeedControlParameters.EerrorSum = 0;

            curStage.StartTime = DateTime.Now;

            if (curStage.StartForceOffset != null)
            {
                ZeroForce();
                Sensors.CurrentLoadCell.SetForceBase(curStage.StartForceOffset.Value);
            }

            if (curStage.StartExtenOffset.HasValue)
            {
                ZeroExExtension();
                ZeroLfExtension();
                Sensors.CurrentEncoder.SetExtensionBase(curStage.StartExtenOffset.Value);
                Sensors.CurrentExtensoMeter?.SetExtensionBase(curStage.StartExtenOffset.Value);
            }
            newStepStartet = true;
        }

        private void SetCrossHeadDirection()
        {
            switch (curStage.SetPointType)
            {
                case TestControlMode.Extension:
                    CrossHead.SetCrossHeadDirection(extension, curStage.SetPoint);
                    curStage.SubSetPoint = extension;
                    break;
                case TestControlMode.Strain:
                    CrossHead.SetCrossHeadDirection(strain, curStage.SetPoint);
                    curStage.SubSetPoint = strain;
                    break;

                case TestControlMode.TrueStrain:
                    CrossHead.SetCrossHeadDirection(trueStrain, curStage.SetPoint);
                    curStage.SubSetPoint = trueStrain;
                    break;

                case TestControlMode.Force:
                    CrossHead.SetCrossHeadDirection(force, curStage.SetPoint);
                    curStage.SubSetPoint = force;
                    break;

                case TestControlMode.Stress:
                    CrossHead.SetCrossHeadDirection(stress, curStage.SetPoint);
                    curStage.SubSetPoint = stress;
                    break;

                case TestControlMode.TrueStress:
                    CrossHead.SetCrossHeadDirection(trueStress, curStage.SetPoint);
                    curStage.SubSetPoint = trueStress;
                    break;

                case TestControlMode.MassStress:
                    CrossHead.SetCrossHeadDirection(massStress, curStage.SetPoint);
                    curStage.SubSetPoint = massStress;
                    break;

                case TestControlMode.LengthStress:
                    CrossHead.SetCrossHeadDirection(lengthStress, curStage.SetPoint);
                    curStage.SubSetPoint = lengthStress;
                    break;

                default:
                    if (TestMethodType == TestMethodType.Tensile)
                    {
                        CrossHead.CrossHeadDirection = CrossHeadDirection.Up;
                        CrossHead.CrossHeadDirectionSpeedSgn = 1;
                    }
                    else if (TestMethodType == TestMethodType.Compressive)
                    {
                        CrossHead.CrossHeadDirection = CrossHeadDirection.Down;
                        CrossHead.CrossHeadDirectionSpeedSgn = -1;
                    }
                    break;

            }
        }

        private void CheckStageTermination()
        {
            if (curStage.StopTime > 0)
            {
                curStage.Terminated = (DateTime.Now - curStage.StartTime).TotalSeconds > curStage.StopTime;
            }
            else if (curStage.KeepTime > 0)
            {
                curStage.Terminated = (DateTime.Now - curStage.StartTime).TotalSeconds >= curStage.KeepTime;
            }
            else
                CheckSetPoints();//ok
            CheckTemperatureSetPoints();

            if (!curStage.Terminated)
                return;

            ZeroMeasures();

            if (TestMethodType == TestMethodType.Relaxation && stages.Count == 1)
            {
                if (curStage.SetPointType == TestControlMode.Force || curStage.SetPointType == TestControlMode.Stress || curStage.SetPointType == TestControlMode.TrueStress)
                {
                    stages[stages.Count - 1].SetPointType = TestControlMode.Extension;
                    stages[stages.Count - 1].SetPoint = extension;
                    stages[stages.Count - 1].StageDescription = string.Format("Extension control");
                }
            }

            try
            {
                InitiateNewStage();
            }
            catch
            {
                TestInProgress = false;
                OnTestStops(this, TestFinishEventArgs.Finished);
            }
        }

        private void CheckSetPoints()
        {
            if (curStage.Terminated)
                return;
            switch (curStage.SetPointType)
            {
                case TestControlMode.Force:
                    curStage.Terminated = CrossHead.CrossHeadReaches(force, curStage.SetPoint);
                    break;

                case TestControlMode.Extension:
                    curStage.Terminated = CrossHead.CrossHeadReaches(extension, curStage.SetPoint);
                    break;

                case TestControlMode.Stress:
                    curStage.Terminated = CrossHead.CrossHeadReaches(stress, curStage.SetPoint);
                    break;

                case TestControlMode.TrueStress:
                    curStage.Terminated = CrossHead.CrossHeadReaches(trueStress, curStage.SetPoint);
                    break;

                case TestControlMode.MassStress:
                    curStage.Terminated = CrossHead.CrossHeadReaches(massStress, curStage.SetPoint);
                    break;

                case TestControlMode.LengthStress:
                    curStage.Terminated = CrossHead.CrossHeadReaches(lengthStress, curStage.SetPoint);
                    break;

                case TestControlMode.Strain:
                    curStage.Terminated = CrossHead.CrossHeadReaches(strain, curStage.SetPoint);
                    break;

                case TestControlMode.TrueStrain:
                    curStage.Terminated = CrossHead.CrossHeadReaches(trueStrain, curStage.SetPoint);
                    break;
            }
        }

        private void CheckTemperatureSetPoints()
        {
            // prevent overflow in 1 hour for 100 sample/seconds
            if (++TemperatureSumCount > 60 * 60 * 100)
            {
                for (var index = 0; index < TemperatureSum.Length; index++)
                    TemperatureSum[index] /= TemperatureSumCount;

                TemperatureSumCount = 1;
            }
            for (var index = 0; index < TemperatureSum.Length; index++)
                TemperatureSum[index] += temperatureValue[index];

            var mean = GetAverageTemperature(temperatureValue);
            var useExtraProcess = UseTemperatureCompensation;

            switch (curStage.TemperatuerControlMode)
            {
                case TemperatuerControlMode.Set:
                    TemperatureResetCounter = 0;
                    if (curStage.TemperatureSetPoint > 0 || SetTemperatureToZeroOnTestStop)
                    {
                        lastTempSetpoint = curStage.TemperatureSetPoint;
                        LastSetPoints = CalculateSetPoints(curStage.TemperatureSetPoint + curStage.TemperatureSetPointOffset, ref useExtraProcess);
                        for (int index = 4; index < LastSetPoints.Length; index++)
                            LastSetPoints[index] = (int)curStage.TemperatureSetPoint;
                        if (OnTemperatureCompensationCalculations != null)
                        {
                            OnTemperatureCompensationCalculations(true, LastSetPoints, TemperatureSum, temperatureValue, 0, startDateTime, 0);
                        }

                        curStage.Terminated = SetTemperature(InstrumentParameters.TemperatureHMI, LastSetPoints);
                    }
                    break;

                case TemperatuerControlMode.WaitHigher:
                    {
                        var setPoints = CalculateSetPoints(curStage.TemperatureSetPoint, ref useExtraProcess);
                        if (curStage.TemperatureSetPoint > 0 || SetTemperatureToZeroOnTestStop)
                            if (useExtraProcess)
                                SetTemperature(InstrumentParameters.TemperatureHMI, LastSetPoints = setPoints);
                    }
                    curStage.Terminated = (mean >= curStage.TemperatureSetPoint);
                    break;

                case TemperatuerControlMode.WaitLower:
                    curStage.Terminated = (mean <= curStage.TemperatureSetPoint);
                    break;

                case TemperatuerControlMode.Keep:
                    {
                        var setPoints = CalculateSetPoints(curStage.TemperatureSetPoint, ref useExtraProcess);
                        //Nazarpour 1400/09/14
                        if (lastTempSetpoint != curStage.TemperatureSetPoint)
                        {
                            lastTempSetpoint = curStage.TemperatureSetPoint;
                            for (var channel = 4; channel <= 6; channel++)
                                SetTemperature(InstrumentParameters.TemperatureHMI, channel, (int)lastTempSetpoint);
                        }

                        if (curStage.TemperatureSetPoint > 0 || SetTemperatureToZeroOnTestStop)
                            if (useExtraProcess)
                                SetTemperature(InstrumentParameters.TemperatureHMI, LastSetPoints = setPoints);
                    }
                    break;
            }
        }

        private float[] CalculateSetPoints(float temperatureSetPoint, ref bool useExtraProcess)
        {
            var setPoints = new float[NumberOfTemperaturChannels];

            for (int channel = 0; channel < setPoints.Length; channel++)
                setPoints[channel] = temperatureSetPoint;

            if (useExtraProcess && UseTemperatureCompensation && TemperatureCompensationPeriod > 0 && DateTime.Now >= NextTemperatureCompensationTime && temperatureSetPoint > 0)
            {
                setPoints = CompensateTemperatureSetPoints(setPoints, ref useExtraProcess);

                NextTemperatureCompensationTime = DateTime.Now.AddMinutes(TemperatureCompensationPeriod);
            }
            else
                useExtraProcess = false;

            return setPoints;
        }

        private float[] CompensateTemperatureSetPoints(float[] setPoints, ref bool useExtraProcess)
        {
            if (LastSetPoints == null)
                setPoints.CopyTo(LastSetPoints = new float[setPoints.Length], 0);

            for (var index = 0; index < TemperatureSum.Length; index++)
                TemperatureSum[index] /= (float)TemperatureSumCount;

            var inBalance = 0;
            for (var index = 0; index < 6; index++)
                if (Math.Abs(TemperatureSum[index] - temperatureValue[index]) < .5/* divide calibration gain*/) inBalance++;

            useExtraProcess = false;
            if (inBalance == 6)
            {// temperature controllers 1 & 2 & 3

                // 1401/03/13, Nazarpour: TemperatureSum has mean temperatures
                var mean = GetAverageTemperature(TemperatureSum);//   GetAverageTemperature(temperatureValue);
                if (mean > 0)
                {
                    var aspm = GetAverageSetPointOfTemperature(temperatureValue);
                    if (Math.Abs(aspm - mean) <= MaximumTemperatureDiffrence)
                        for (var index = 1; index <= 3; index++)
                        {
                            var delta = setPoints[index] - mean;
                            if (delta != 0)
                            {
                                if (Math.Abs(delta) > 4)
                                {
                                    setPoints[index] = LastSetPoints[index] + delta * 2 / 3;
                                    useExtraProcess = true;
                                }
                                else if (InstrumentParameters.TemperatureHMI)
                                {
                                    if (Math.Abs(delta) > .1)
                                    {
                                        setPoints[index] = LastSetPoints[index] + delta;
                                        useExtraProcess = true;
                                    }
                                }
                                else if (Math.Abs(delta) >= 1)
                                {
                                    setPoints[index] = LastSetPoints[index] + delta;
                                    useExtraProcess = true;
                                }
                            }
                        }
                }
                if (useExtraProcess) TemperatureResetCounter++;
            }

            if (OnTemperatureCompensationCalculations != null)
            {
                OnTemperatureCompensationCalculations(useExtraProcess, setPoints, TemperatureSum, temperatureValue, 6 - inBalance, startDateTime, 0);
            }

            //reset temperature sums (means)
            for (var index = 0; index < TemperatureSum.Length; index++)
                TemperatureSum[index] = 0;
            TemperatureSumCount = 0;

            return setPoints;
        }

        private float GetAverageTemperature(float[] temperatures)
        {
            var count = 0;
            float average = 0;
            if (temperatures[4] > 0) { average += temperatures[4]; count++; }
            if (temperatures[5] > 0) { average += temperatures[5]; count++; }
            if (temperatures[6] > 0) { average += temperatures[6]; count++; }
            return count > 0 ? average /= (float)count : 0;
        }

        private float GetAverageSetPointOfTemperature(float[] temperatures)
        {
            var count = 0;
            float average = 0;
            if (temperatures[1] > 0) { average += temperatures[1]; count++; }
            if (temperatures[2] > 0) { average += temperatures[2]; count++; }
            if (temperatures[3] > 0) { average += temperatures[3]; count++; }
            return count > 0 ? average /= (float)count : 0;
        }

        private void ZeroMeasures()
        {
            //Log.AddTolog("CheckZeroMeasures");
            switch (curStage.Zerocode)
            {
                case ZeroCode.Force:
                    ZeroForce();
                    break;

                case ZeroCode.Exten:
                    ZeroLfExtension();
                    break;

                case ZeroCode.Strain:
                    ZeroExExtension();
                    break;

                case ZeroCode.SE:
                    ZeroLfExtension();
                    ZeroExExtension();
                    break;

                case ZeroCode.SEF:
                    ZeroForce();
                    ZeroLfExtension();
                    ZeroExExtension();
                    break;
            }
        }

        private void CheckStoE()
        {
            if ((StrainToExtenEnabled == false || s2E) || strainRemoved)
                return;

            switch (StrainToExtenMode)
            {
                case StrainToExtenMode.Extention:
                    if (extension >= StrainToExtenSetPoint)
                        SwitchStrainToExtension();
                    break;

                case StrainToExtenMode.Peak:
                    if (peakDetected && strain >= StrainToExtenSetPoint)
                        SwitchStrainToExtension();
                    break;

                case StrainToExtenMode.Strain:
                    if (strain >= StrainToExtenSetPoint)
                        SwitchStrainToExtension();
                    break;
            }
            if (strainRemoved || !s2E) return;
            if (RemoveStarinOptions == StrainRemoveOptions.Stop)
                OnStopTestS2E(this, EventArgs.Empty);
            else
                OnContinueTestS2E(this, EventArgs.Empty);

            strainRemoved = true;
        }

        public void SwitchStrainToExtension()
        {
            ZeroLfExtension();
            s2E = true;
            MotorEncoder.S2EChanged = true;
            MotorEncoder.StoEExtension = double.IsNaN(exExtension) ? 0 : exExtension;
        }

        private void CheckTestStopCustomCriterin()
        {
            var TestInProgress = this.TestInProgress;
            var customeStopValue_75 = CustomeStopValue * 0.75;
            var raiseRichingLimits = RaiseRichingLimits;

            string comment = "";
            switch (CustomeStopType)
            {
                case TestControlMode.Force:
                    if ((pForce <= CustomeStopValue && CustomeStopValue <= force) ||
                        (pForce >= CustomeStopValue && CustomeStopValue >= force))
                    {
                        TestInProgress = false;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Force_reaches_stop_condition;
                    }
                    if ((pForce <= customeStopValue_75 && customeStopValue_75 <= force) ||
                        (pForce >= customeStopValue_75 && customeStopValue_75 >= force))
                    {
                        raiseRichingLimits = true;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Force_reaches_75__stop_condition;
                    }
                    break;

                case TestControlMode.Stress:
                    if ((pStress <= CustomeStopValue && CustomeStopValue <= stress) ||
                        (pStress >= CustomeStopValue && CustomeStopValue >= stress))
                    {
                        TestInProgress = false;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Strees_reaches_stop_condition;
                    }
                    if ((pStress <= customeStopValue_75 && customeStopValue_75 <= stress) ||
                        (pStress >= customeStopValue_75 && customeStopValue_75 >= stress))
                    {
                        raiseRichingLimits = true;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Strees_reaches_75__stop_condition;
                    }
                    break;

                case TestControlMode.Extension:
                    if ((pExtension <= CustomeStopValue && CustomeStopValue <= extension) ||
                        (pExtension >= CustomeStopValue && CustomeStopValue >= extension))
                    {
                        TestInProgress = false;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Extension_reaches_stop_condition;
                    }
                    if ((pExtension <= customeStopValue_75 && customeStopValue_75 <= extension) ||
                        (pExtension >= customeStopValue_75 && customeStopValue_75 >= extension))
                    {
                        raiseRichingLimits = true;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Extension_reaches_75__stop_condition;
                    }
                    break;

                case TestControlMode.Strain:
                    if ((pStrain <= CustomeStopValue && CustomeStopValue <= strain) ||
                        (pStrain >= CustomeStopValue && CustomeStopValue >= strain))
                    {
                        TestInProgress = false;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Strain_reaches_stop_condition;
                    }
                    if ((pStrain <= customeStopValue_75 && customeStopValue_75 <= strain) ||
                        (pStrain >= customeStopValue_75 && customeStopValue_75 >= strain))
                    {
                        raiseRichingLimits = true;
                        comment = Resources.Test_CheckTestStopCustomCriterin_Strain_reaches_75__stop_condition;
                    }
                    break;

            }
            pForce = force;
            pStrain = strain;
            pStress = stress;
            pExtension = extension;

            // Nazarpour 1399/11/14
            if (RaiseRichingLimits ^ raiseRichingLimits)
            {
                RaiseRichingLimits = raiseRichingLimits;
                Task.Factory.StartNew(() =>
                {
                    MessageBox.Show(comment, Resources.Test_CheckTestStopCustomCriterin_Warning, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                });
            }

            if (!TestInProgress && this.TestInProgress)
            {
                OnTestStops(this, TestFinishEventArgs.Limits);
                Task.Factory.StartNew(() =>
                {
                    MessageBox.Show(comment, Resources.Test_CheckTestStopCustomCriterin_Test_stopped_due_to_protection, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
        }
        int force_exceeds_lower_limit = 0;
        int force_exceeds_upper_limit = 0;

        private void CheckStopCriterian(double reportingSpeed)
        {
            if (reportingSpeed < 0) reportingSpeed = -reportingSpeed;

            string comment = "";
            if (force < InstrumentParameters.ForceMinLimit)
            {
                if (reportingSpeed > 1)
                {
                    comment = Resources.Test_CheckStopCriterian_Force_exceeds_lower_limit;
                    TestInProgress = false;
                }
                else if (++force_exceeds_lower_limit >= 50)
                {
                    comment = Resources.Test_CheckStopCriterian_Force_exceeds_lower_limit;
                    TestInProgress = false;
                }
            }
            else force_exceeds_lower_limit = 0;

            if (force > InstrumentParameters.ForceMaxLimit)
            {
                if (reportingSpeed > 1)
                {
                    comment = Resources.Test_CheckStopCriterian_Force_exceeds_upper_limit;
                    TestInProgress = false;
                }
                else if (++force_exceeds_upper_limit >= 50)
                {
                    comment = Resources.Test_CheckStopCriterian_Force_exceeds_upper_limit;
                    TestInProgress = false;
                }
            }
            else
                force_exceeds_upper_limit = 0;

            if (exExtension < InstrumentParameters.ExtenMin)
            {
                comment = Resources.Test_CheckStopCriterian_Extension__extensometer__exceeds_lower_limit;
                TestInProgress = false;
            }
            else if (exExtension > InstrumentParameters.ExtenMax)
            {
                comment = Resources.Test_CheckStopCriterian_Extension__extensometer__exceeds_upper_limit;
                TestInProgress = false;
            }
            else if (lfEncoderExtension < InstrumentParameters.LfEncoderMin)
            {
                comment = Resources.Test_CheckStopCriterian_Extension__encoder__exceeds_lower_limit;
                TestInProgress = false;
            }
            else if (lfEncoderExtension > InstrumentParameters.LfEncoderMax)
            {
                comment = Resources.Test_CheckStopCriterian_Extension__extensometer__exceeds_upper_limit;
                TestInProgress = false;
            }
            // Nazarpour 980401
            else if (temperatureValue.Any(t => t > InstrumentParameters.TemperatureMax))
            {
                SetTemperature(InstrumentParameters.TemperatureHMI, 0);
                comment = Resources.Test_CheckStopCriterian_Temperature_Overheat_limit;
                TestInProgress = false;
            }

            if (!TestInProgress)
            {
                OnTestStops(this, TestFinishEventArgs.Protection);
                Task.Factory.StartNew(() =>
                {
                    MessageBox.Show(comment, Resources.Test_CheckTestStopCustomCriterin_Test_stopped_due_to_protection, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
        }

        #endregion

        #region speed

        private double GetSpeed()
        {
            var rateMode = curStage.RateControlMode;
            var ctrlMode = curStage.SetPointType;
            double rateSpeed;
            var ctrlSpeed = 0.0;
            bool extensionStrainRateIsValid;
            var extensionStrainRate = GetExtensionStrainSpeed(rateMode, curStage.Rate,
                                      TestingSample.GagueLength, extension, out extensionStrainRateIsValid);// exten strain rate  mm/min
            extensionStrainRate *= CrossHead.CrossHeadDirectionSpeedSgn;
            if (curStage.PassSetPoint)
            {
                if (extensionStrainRateIsValid)
                    return extensionStrainRate;
                ctrlSpeed = GetForceSetPointPassSpeed(rateMode); // mm/min
                return ctrlSpeed;
            }

            if (extensionStrainRateIsValid)
            {
                rateSpeed = extensionStrainRate;

                SpeedControlParameters.FerrorSum = 0;
                SpeedControlParameters.SerrorSum = 0;
                SpeedControlParameters.EerrorSum = 0;
            }
            else
            {
                rateSpeed = GetSetPointCtrlSpeed(rateMode, true); // mm/ min
                curStage.Terminated = false;
            }
            if (ctrlMode != TestControlMode.None)
                ctrlSpeed = GetSetPointCtrlSpeed(ctrlMode, false, extensionStrainRate, extensionStrainRateIsValid);

            if (rateMode != TestControlMode.None & ctrlMode != TestControlMode.None)
            {
                return Math.Abs(rateSpeed) < Math.Abs(ctrlSpeed) ? rateSpeed : ctrlSpeed;
            }
            if (rateMode == TestControlMode.None & ctrlMode != TestControlMode.None)
            {
                return ctrlSpeed;
            }
            if (ctrlMode == TestControlMode.None & rateMode != TestControlMode.None)
            {
                return rateSpeed;
            }
            return 0;
        }

        private static double GetExtensionStrainSpeed(TestControlMode rateControl, double rate, double initialLength,
                                                       double curExtension, out bool valid)
        {
            var speed = 0.0;
            valid = false;
            switch (rateControl)
            {
                case TestControlMode.Extension:
                    speed = rate;
                    valid = true;
                    break;

                case TestControlMode.Strain:
                    speed = rate * initialLength;
                    valid = true;
                    break;

                case TestControlMode.TrueStrain:
                    speed = rate * (curExtension + initialLength);
                    valid = true;
                    break;
            }
            return speed;
        }

        private double GetForceSetPointPassSpeed(TestControlMode mode) // mm/min
        {
            double spd = 0.0;

            var fLimit = CrossHead.CrossHeadDirectionSpeedSgn > 0 ? InstrumentParameters.ForceMaxLimit : InstrumentParameters.ForceMinLimit;

            switch (mode)
            {
                case TestControlMode.Force:
                    spd = ComputePassSetpointSpeed(Extention.AbsMin(curStage.GetCurrentLimit(true, CrossHead.CrossHeadDirectionSpeedSgn), fLimit),
                                                   force, SpeedControlParameters.Kfp);
                    break;

                case TestControlMode.Stress:
                    {
                        var forcelimit = curStage.GetCurrentLimit(true, CrossHead.CrossHeadDirectionSpeedSgn) * TestingSample.Area;
                        spd = ComputePassSetpointSpeed(Extention.AbsMin(forcelimit, fLimit), force, SpeedControlParameters.Kfp);
                    }
                    break;

                case TestControlMode.TrueStress:
                    spd = ComputePassSetpointSpeed(Extention.AbsMin(curStage.GetCurrentLimit(true, CrossHead.CrossHeadDirectionSpeedSgn),
                                                   fLimit / TestingSample.Area), trueStress, SpeedControlParameters.Kfp);
                    break;

                case TestControlMode.MassStress:
                    spd = ComputePassSetpointSpeed(Extention.AbsMin(curStage.GetCurrentLimit(true, CrossHead.CrossHeadDirectionSpeedSgn),
                                                   fLimit / TestingSample.Density), trueStress, SpeedControlParameters.Kfp);
                    break;

                case TestControlMode.LengthStress:
                    spd = ComputePassSetpointSpeed(Extention.AbsMin(curStage.GetCurrentLimit(true, CrossHead.CrossHeadDirectionSpeedSgn),
                                                   fLimit / TestingSample.Width), trueStress, SpeedControlParameters.Kfp);
                    break;
            }
            return spd;
        }

        private double GetSetPointCtrlSpeed(TestControlMode mode, bool rateControl = false, double logicalSpeed = 0, bool validLogical = false)// mm/min
        {
            double spd = 0.0;
            var mf = Sensors.CurrentLoadCell == null ? 0 : Sensors.CurrentLoadCell.MaxCap;
            rateControl = !rateControl;
            switch (mode)
            {
                case TestControlMode.Force:
                    {
                        var lastError = rateControl ? SpeedControlParameters.FerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.FerrorSum : 0;

                        spd = ComputeSpeed(curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn), force,
                            SpeedControlParameters.Kfp, SpeedControlParameters.Kfi, rateControl ? SpeedControlParameters.Kfd : 0, ref lastError, ref sumError,
                            SpeedControlParameters.Ftorelance * mf * Statistics.G / 100.0, logicalSpeed, validLogical);
                        if (rateControl)
                        {
                            SpeedControlParameters.FerrorLast = lastError;
                            SpeedControlParameters.FerrorSum = sumError;
                        }
                    }
                    break;

                case TestControlMode.Extension:
                    {
                        var lastError = rateControl ? SpeedControlParameters.EerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.EerrorSum : 0;

                        spd = ComputeSpeed(curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn), extension,
                            SpeedControlParameters.Kep, SpeedControlParameters.Kei, rateControl ? SpeedControlParameters.Ked : 0, ref lastError, ref sumError,
                            SpeedControlParameters.Etorelance, logicalSpeed, validLogical);

                        SpeedControlParameters.EerrorLast = lastError;
                        SpeedControlParameters.EerrorSum = sumError;
                    }
                    break;

                case TestControlMode.Stress:
                    {
                        var lastError = rateControl ? SpeedControlParameters.FerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.FerrorSum : 0;

                        var forcelimit = curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn) * TestingSample.Area;
                        spd = ComputeSpeed(forcelimit, force,
                            SpeedControlParameters.Kfp, SpeedControlParameters.Kfi, rateControl ? SpeedControlParameters.Kfd : 0, ref lastError, ref sumError,
                            SpeedControlParameters.Ftorelance * mf * Statistics.G / 100.0, logicalSpeed, validLogical);

                        SpeedControlParameters.FerrorLast = lastError;
                        SpeedControlParameters.FerrorSum = sumError;
                    }
                    break;

                case TestControlMode.MassStress:
                    {
                        var lastError = rateControl ? SpeedControlParameters.FerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.FerrorSum : 0;

                        var forcelimit = curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn) * TestingSample.Density;
                        spd = ComputeSpeed(forcelimit, force,
                            SpeedControlParameters.Kfp, SpeedControlParameters.Kfi, rateControl ? SpeedControlParameters.Kfd : 0, ref lastError, ref sumError,
                            SpeedControlParameters.Ftorelance * mf * Statistics.G / 100.0, logicalSpeed, validLogical);

                        SpeedControlParameters.FerrorLast = lastError;
                        SpeedControlParameters.FerrorSum = sumError;
                    }
                    break;

                case TestControlMode.LengthStress:
                    {
                        var lastError = rateControl ? SpeedControlParameters.FerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.FerrorSum : 0;

                        var forcelimit = curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn) * TestingSample.Width;
                        spd = ComputeSpeed(forcelimit, force,
                            SpeedControlParameters.Kfp, SpeedControlParameters.Kfi, rateControl ? SpeedControlParameters.Kfd : 0, ref lastError, ref sumError,
                            SpeedControlParameters.Ftorelance * mf * Statistics.G / 100.0, logicalSpeed, validLogical);

                        SpeedControlParameters.FerrorLast = lastError;
                        SpeedControlParameters.FerrorSum = sumError;
                    }
                    break;

                case TestControlMode.TrueStress:
                    {
                        var lastError = rateControl ? SpeedControlParameters.FerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.FerrorSum : 0;

                        spd = ComputeSpeed(curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn), trueStress,
                            SpeedControlParameters.Kfp, SpeedControlParameters.Kfi, rateControl ? SpeedControlParameters.Kfd : 0, ref lastError, ref sumError,
                          SpeedControlParameters.Ftorelance * mf * Statistics.G / 100.0, logicalSpeed, validLogical);

                        SpeedControlParameters.FerrorLast = lastError;
                        SpeedControlParameters.FerrorSum = sumError;
                    }
                    break;

                case TestControlMode.Strain:
                    {
                        var lastError = rateControl ? SpeedControlParameters.SerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.SerrorSum : 0;

                        spd = ComputeSpeed(curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn), strain,
                            SpeedControlParameters.Ksp, SpeedControlParameters.Ksi, rateControl ? SpeedControlParameters.Ksd : 0, ref lastError, ref sumError,
                          SpeedControlParameters.STorelance, logicalSpeed, validLogical);

                        SpeedControlParameters.SerrorLast = lastError;
                        SpeedControlParameters.SerrorSum = sumError;
                    }
                    break;

                case TestControlMode.TrueStrain:
                    {// spd = GetStrainLimitSpeed(curStage.GetTrueStarinLimit());
                        var lastError = rateControl ? SpeedControlParameters.SerrorLast : 0;
                        var sumError = rateControl ? SpeedControlParameters.SerrorSum : 0;

                        spd = ComputeSpeed(curStage.GetCurrentLimit(!rateControl, CrossHead.CrossHeadDirectionSpeedSgn), trueStrain,
                            SpeedControlParameters.Ksp, SpeedControlParameters.Ksi, rateControl ? SpeedControlParameters.Ksd : 0, ref lastError, ref sumError,
                             SpeedControlParameters.STorelance, logicalSpeed, validLogical);

                        SpeedControlParameters.SerrorLast = lastError;
                        SpeedControlParameters.SerrorSum = sumError;
                    }
                    break;
            }
            return spd;
        }

        private double ComputeSpeed(double controlLimit, double curPoint, double controlP, double controlI, double controlD,
                                    ref double lastError, ref double sumError, double controlTorelance, double logicalSpeed, bool validLogical)// mm/min
        {
            double retSpeed;

            var error = controlLimit - curPoint;

            if (Math.Abs(error) < controlTorelance)
            {
                if (curStage.KeepTime <= 0 && curStage.TemperatuerControlMode == TemperatuerControlMode.None)
                {
                    curStage.Terminated = true;
                    retSpeed = 0;
                }
                else
                    retSpeed = controlI * sumError; // 0
            }
            else
            {
                sumError += error;
                var termI = controlI * sumError;
                if (CrossHead.ElectroHydrolic)
                {
                    if (termI > 0)
                    {
                        if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.DownwardDirection)
                            termI = 0;
                        else if (termI > CrossHead.HiJogSpeed)
                            termI = CrossHead.HiJogSpeed;

                        sumError = termI / controlI;
                    }
                    else if (termI < 0)
                    {
                        if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.UpwardDirection)
                            termI = 0;
                        else if (termI < -CrossHead.HiJogSpeed)
                            termI = -CrossHead.HiJogSpeed;

                        sumError = termI / controlI;
                    }
                }
                else
                {
                    if (termI > CrossHead.HiJogSpeed)
                    {
                        termI = CrossHead.HiJogSpeed;
                        sumError = termI / controlI;
                    }
                    else if (termI < -CrossHead.HiJogSpeed)
                    {
                        termI = -CrossHead.HiJogSpeed;
                        sumError = termI / controlI;
                    }
                }

                var diff = error - lastError;
                lastError = error;

                retSpeed = error * controlP + termI + diff * controlD;
                retSpeed = validLogical ? Extention.AbsMin(retSpeed, logicalSpeed) : retSpeed;
                /*if (retSpeed <= -double.Epsilon)
                {
                    if (retSpeed > -0.06) retSpeed = -0.06;
                }
                else if (retSpeed >= double.Epsilon)
                {
                    if (retSpeed < 0.06) retSpeed = 0.06;
                }*/
            }

            return retSpeed;
        }

        private double ComputePassSetpointSpeed(double controlLimit, double curPoint, double controlFactor,
                                                double logicalSpeed = 0, bool validLogical = false)// mm/min
        {
            var controlError = controlLimit - curPoint;

            double retSpeed = controlError * controlFactor;
            retSpeed = validLogical ? Extention.AbsMin(retSpeed, logicalSpeed) : retSpeed;

            return retSpeed;
        }

        private double GetReturnToZeroSpeed(ReturnZeroMode mode)
        {
            double retSpeed;
            var fTorelance = Sensors.CurrentLoadCell == null ? 0 : Sensors.CurrentLoadCell.MaxCap * Statistics.G * SpeedControlParameters.Ftorelance / 100;
            var error = (mode == ReturnZeroMode.Extension ? (0 - lfEncoderExtension) : (mode == ReturnZeroMode.Force ? 0 - force : 0));
            var torlance = (mode == ReturnZeroMode.Extension ? SpeedControlParameters.Etorelance : fTorelance);
            if (Math.Abs(error) < torlance)
            {
                retSpeed = 0;
            }
            else
            {
                var k = mode == ReturnZeroMode.Extension ? SpeedControlParameters.Kep : SpeedControlParameters.Kfp;
                retSpeed = error * k;
                var sign = Math.Sign(retSpeed);
                retSpeed = Math.Abs(retSpeed);

                if (retSpeed >= CrossHead.HiJogSpeed)
                    retSpeed = CrossHead.HiJogSpeed;

                retSpeed *= sign;
            }
            return retSpeed;
        }

        #endregion

        #region zero

        public void ZeroLfExtension()
        {
            RS232.Current.Send("E1Z");
            Sensors.CurrentEncoder.SetExtensionBase(0);
            testFilter.ZeroLfExtension();
            Sensors.CurrentEncoder.Zero();
        }

        public void ZeroExExtension()
        {
            if (Sensors.CurrentExtensoMeter != null)
            {
                Sensors.CurrentExtensoMeter.SetExtensionBase(0);
                if (Sensors.CurrentExtensoMeter.EncoderBased)
                    RS232.Current.Send("E2Z");
                else
                    Sensors.CurrentExtensoMeter.Zero();
            }
            testFilter.ZeroExtensometerExtension();
            exExtension = 0;
        }

        public void ZeroForce()
        {
            if (Sensors.CurrentLoadCell != null)
            {
                Sensors.CurrentLoadCell.Zero();
                Sensors.CurrentLoadCell.SetForceBase(0);
            }
            testFilter.ZeroForce();
            force = 0;
        }

        public void ZeroTemperatures(int index)
        {
            if (Sensors.CurrentTemperatureSensor != null)
            {
                Sensors.CurrentTemperatureSensor.Zero(index);
            }
            testFilter.ZeroTemperature(index);
            temperatureValue[index] = 0;
        }

        public void ReturnToZero(ReturnZeroMode mode = ReturnZeroMode.None, bool cancel = false)
        {
            returnZeroMode = cancel ? ReturnZeroMode.None : mode;
        }

        public void CancelReturnZero()
        {
            returnZeroMode = ReturnZeroMode.None;


            SpeedControlParameters.EerrorLast = 0;
            SpeedControlParameters.EerrorSum = 0;

            SpeedControlParameters.FerrorLast = 0;
            SpeedControlParameters.FerrorSum = 0;

            SpeedControlParameters.SerrorLast = 0;
            SpeedControlParameters.SerrorSum = 0;

            ElectroHydrolicCrossHeadState = ElectroHydrolicCrossHeadStates.Ignore;
        }

        public void ResetFilter()
        {
            testFilter.Reset();
        }
        #endregion

        #region read

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public MeasuredParams Read()
        {
            double reportingSpeed;

            #region return to zero

            if (returnZeroMode != ReturnZeroMode.None)
            {
                JogSpeed = GetReturnToZeroSpeed(returnZeroMode); // ok  mm/ min
                if (!CrossHead.ActuatorUp)
                    JogSpeed *= -1;
                if (JogSpeed == 0)
                    returnZeroMode = ReturnZeroMode.None;
            }

            #endregion

            if (Math.Abs(JogSpeed - 0) <= double.Epsilon)
            {
                double speed;
                if (TestInProgress)
                {
                    receivedSampleCount++;
                    CheckStageTermination(); // ok
                    CheckStoE();
                    speed = GetSpeed();
                }
                else
                    speed = 0;

                if (s2E && !strainRemoved && RemoveStarinOptions == StrainRemoveOptions.Stop)
                    speed = 0;

                if (speed > CrossHead.HiJogSpeed)
                    speed = CrossHead.HiJogSpeed;
                if (speed < -CrossHead.HiJogSpeed)
                    speed = -CrossHead.HiJogSpeed;

                reportingSpeed = speed;
                if (!CrossHead.ActuatorUp)
                    speed *= -1;

                // 1400/04/05 Nazarpour
                if (CrossHead.ElectroHydrolic)
                    if (CrossHead.ActuatorUp)
                    {
                        if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.UpwardDirection && speed <= 0) speed = 0.001;
                        if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.DownwardDirection && speed >= 0) speed = -0.001;
                    }
                    else
                    {
                        if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.UpwardDirection && speed >= 0) speed = 0.001;
                        if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.DownwardDirection && speed <= 0) speed = -0.001;
                    }

                ProcessSdbData(speed);
            }
            else
            {
                reportingSpeed = JogSpeed;
                if (CrossHead.ActuatorUp)
                {
                    if (force < InstrumentParameters.ForceMinLimit && JogSpeed < 0)
                        JogSpeed = 0;
                    if (force > InstrumentParameters.ForceMaxLimit && JogSpeed > 0)
                        JogSpeed = 0;
                }
                else
                {
                    if (force < InstrumentParameters.ForceMinLimit && JogSpeed > 0)
                        JogSpeed = 0;
                    if (force > InstrumentParameters.ForceMaxLimit && JogSpeed < 0)
                        JogSpeed = 0;
                }

                // 1400/04/05 Nazarpour
                var speed = JogSpeed;
                //if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.UpwardDirection && speed < 0) speed = -0.001;
                //if (Test.ElectroHydrolicCrossHeadState == ElectroHydrolicCrossHeadStates.DownwardDirection && speed > 0) speed = 0.001;

                ProcessSdbData(speed);
            }


            if (TestInProgress && Math.Abs(JogSpeed - 0) <= double.Epsilon)
            {
                CheckStopCriterian(reportingSpeed);
                CheckTestStopCustomCriterin();
            }

            #region read data interpreation

            var f = force;
            var ex = exExtension;
            double ls = 0; // lateral strain
            var lfx = lfEncoderExtension;
            var exten = ex;

            testFilter.AddFilter(ref f, ref lfx, ref ex, ref ls);

            if (!s2E && !Status.ExtensometerFailure && InstrumentParameters.UseExtensometer)
            {
                exten = ex;
            }
            else
                exten = lfx;
            var sampleIsNull = TestingSample == null;
            var tStrain = sampleIsNull ? double.NaN : exten / (TestingSample.GagueLength + exten);
            var filterdStrain = sampleIsNull ? double.NaN : exten / TestingSample.GagueLength;
            var filterdStress = sampleIsNull ? double.NaN : f / TestingSample.Area;
            var tstress = sampleIsNull ? double.NaN : f / TestingSample.Area * (1 - 1 / Math.Exp(filterdStrain));


            #endregion

            if (Math.Abs(f) > Math.Abs(maxAmpForce))
            {
                maxAmpForce = f;
            }
            var decimation = SerialPortParameters.DecimationRatio;
            if (TestInProgress && curStage != null && curStage.Decimation.HasValue)
                decimation = curStage.Decimation.Value;

            bool samplePlotted = newStepStartet ? newStepStartet : (decimation == 0 || receivedSampleCount % decimation == 0);
            samplePlotted &= (TestInProgress && curStage.PlotStageData);
            newStepStartet = false;
            return new MeasuredParams(temperatureValue)
            {
                Force = f,
                ExtenExtention = ex,
                LFExtention = lfx,
                Extension = exten,
                SetSpeed = reportingSpeed,
                MotorResponseSpeed = motorSpeed,
                Strain = filterdStrain,
                Stress = filterdStress,
                MassStress = massStress,
                LengthStress = lengthStress,
                Time = (curStage?.TemperatuerControlMode != TemperatuerControlMode.WaitLower ? (DateTime.Now - startDateTime).TotalSeconds : double.NaN),
                ToPlot = samplePlotted,
                TestData = TestInProgress,
                TrueStrain = tStrain,
                TrueStress = tstress,
                StepOrCycle = curStage != null ? curStage.StepOrCycle : -1,
                Decimation = curStage?.Decimation ?? 0
            };
        }

        private void ProcessSdbData(double speed)
        {
            if (!RS232.Connected)
            {
                var tempData = new BoardReadData(temperatureData);

                ComputeMeasures(tempData);

                return;
            }

            var registerData = ReadSDB(speed);
            var noise = CheckNoise(registerData);

            if (noise && TestInProgress)
            {
                noisyData++;
                if (noisyData > 4)
                {
                    MessageBox.Show(Resources.Test_ProcessSdbData_Test_stopped_due_to_fatal_error_in_data, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TestInProgress = false;
                    OnTestStops(this, TestFinishEventArgs.Protection);
                }
            }
            else
            {
                ComputeMeasures(registerData);
            }
        }


        public static void ReadTemperatures(bool useHMi)
        {
            if (useHMi)
                ReadTemperaturesHMI();
            else
                ReadTemperaturesDirect();
        }

        public static void ReadTemperaturesDirect()
        {
            for (var i = 0; i < TMPR232.NumberOfTemperaturChannels; i++)
                temperatureData[i] = TMPR232.Current.Read(i);

            var t = temperatureData[4];
            for (var i = 5; i < TMPR232.NumberOfTemperaturChannels; i++)
                temperatureData[i - 1] = temperatureData[i];
            temperatureData[7] = t;
        }

        public static void ReadTemperaturesHMI()
        {
            for (var i = 0; i <= TMPR485.NumberOfTemperaturChannels; i++)
            {
                temperatureData[i] = TMPR485.Current.Read(i);
                //Delay.Sleep(50);
            }
        }

        public static bool SetTemperature(bool useHMI, float value)
        {
            if (useHMI)
                return SetTemperaturesHMI(value);
            else
                return SetTemperaturesDirect(value);
        }

        private static bool SetTemperaturesDirect(float value)
        {
            return TMPR232.Current.Set(value);
        }

        private static bool SetTemperaturesHMI(float value)
        {
            return TMPR485.Current.Set(value);
        }


        public static bool SetTemperature(bool useHMI, int channel, float value)
        {
            if (useHMI)
                return SetTemperaturesHMI(channel, value);
            else
                return SetTemperaturesDirect(channel, value);
        }

        private static bool SetTemperaturesDirect(int channel, float value)
        {
            return TMPR232.Current.Set(channel, value);
        }

        private static bool SetTemperaturesHMI(int channel, float value)
        {
            return TMPR485.Current.Set(channel, value);
        }


        public bool SetTemperature(bool useHMI, params float[] setPoints)
        {
            if (useHMI)
                return SetTemperaturesHMI(setPoints);
            else
                return SetTemperaturesDirect(setPoints);
        }

        private bool SetTemperaturesDirect(float[] setPoints)
        {
            return TMPR232.Current.Set(setPoints);
        }

        private bool SetTemperaturesHMI(float[] setPoints)
        {
            return TMPR485.Current.Set(setPoints);
        }


        //public void ReadTemperatures()
        //{
        //    if (!TMPR232.Connected) return;

        //    temperature = ReadTemperature("01");
        //    temperatureUp = ReadTemperature("02");
        //    temperatureCenter = ReadTemperature("03");
        //    temperatureDown = ReadTemperature("04");

        //}

        //private float ReadTemperature(string v)
        //{
        //    var response = TMPR232.Current.Send(v+"DMC");
        //    if (response != null)
        //        try
        //        {
        //            var ok = response.IndexOf("OK") + "OK,".Length;
        //            response = response.Substring(ok, response.Length - ok -1);
        //            int temp;
        //            if (int.TryParse(response, NumberStyles.HexNumber,null, out temp))
        //                return temp / 10.0f;
        //        }
        //        catch { }
        //    return float.MinValue;
        //}


        protected static byte GetLRC(byte[] data)
        {
            var lrc = 0;
            foreach (byte b in data)
                lrc -= b;
            return (byte)lrc;
        }

        protected static byte GetLRC(byte[] data, int startIndex, int length)
        {
            length += startIndex;
            var lrc = 0;
            for (var index = startIndex; index < length; index++)
                lrc -= data[index];
            return (byte)lrc;
        }

        protected static byte GetLRC(string frame)
        {
            frame = frame.TrimEnd('\n', '\r', ' ');
            var length = frame.Length;

            var value = new byte[length];
            for (int arr_index = 0, str_index = 0; str_index < length; str_index++)
                value[arr_index++] = (byte)((int)frame[str_index]);

            return GetLRC(value);
        }


        private static bool ControlLrc(string cmd)
        {
            if (cmd.Length < 36) return true;
            try
            {
                var lrc = GetLRC(cmd.Substring(0, 36));
                var v = int.Parse(cmd.Substring(36, 2), System.Globalization.NumberStyles.HexNumber);
                return lrc == v;
            }
            catch { return true; }
        }

        public static BoardReadData ReadSDB(double speed = 0)
        {
            RS232.Current.Send("RD");
            RS232.Current.Send(string.Format("S,{0}", (int)(speed * 1000)));
            var cmd = RS232.Read();
            try
            {
                // 1398/05/29 Nazarpour
                if (!ControlLrc(cmd))
                    return new BoardReadData(temperatureData);

                var a2D1 = int.Parse(cmd.Substring(0, 8), NumberStyles.HexNumber);
                var a2D2 = int.Parse(cmd.Substring(8, 8), NumberStyles.HexNumber);
                var enc1 = int.Parse(cmd.Substring(16, 8), NumberStyles.HexNumber);
                var enc2 = int.Parse(cmd.Substring(24, 8), NumberStyles.HexNumber);
                Status.ParseStatus(cmd.Substring(32, 4));


                var retParams = new BoardReadData(temperatureData)
                {
                    LoadcellA2D = a2D1,
                    ExtenA2D = a2D2,
                    MotorEncoder = enc1,
                    ExtenEncoder = enc2,
                    Valid = true
                };
                if (firstRead)
                {
                    //Statistics.ForceOff = retParams.LoadcellA2D;
                    //Statistics.ExtenOff = retParams.ExtenA2D;
                    //Statistics.MotorEncodeOff = retParams.MotorEncoder;
                    firstRead = false;
                }

                return retParams;
            }
            catch
            {
                // Nazarpour 1399/10/14 
                return new BoardReadData(temperatureData);
            }
        }

        private static bool CheckNoise(BoardReadData registerData)
        {
            var noise = false;
            //if (Math.Abs((lastRegisterRead.LoadcellA2D - registerData.LoadcellA2D) * 100.0 / lastRegisterRead.LoadcellA2D) > Instrument.ForcePeakNoiseDetection)
            //    noise = true;
            //else if (Math.Abs((lastRegisterRead.ExtenA2D - registerData.ExtenA2D) * 100.0 / lastRegisterRead.ExtenA2D) > Instrument.ExtenPeakNoiseDetection)
            //    noise = true;
            //else if (Math.Abs((lastRegisterRead.MotorEncoder - registerData.MotorEncoder) * 100.0 / lastRegisterRead.MotorEncoder) > Instrument.LfEncoderPeakNoiseDetection)
            //    noise = true;
            //lastRegisterRead = registerData;
            return noise;
        }

        private void ComputeMeasures(BoardReadData registerData)
        {

            double mspeed;
            force = Sensors.CurrentLoadCell == null ? 0 : Sensors.CurrentLoadCell.DirectForce(registerData.LoadcellA2D, ref stopCode, ref peakDetected);
            lfEncoderExtension = Sensors.CurrentEncoder.GetExtension(registerData.MotorEncoder, out mspeed);
            if (!CrossHead.ActuatorUp)
                lfEncoderExtension *= -1;
            exExtension = Sensors.CurrentExtensoMeter == null ? 0 : Sensors.CurrentExtensoMeter.GetExtension(registerData.ExtenA2D, registerData.ExtenEncoder);
            motorSpeed = mspeed;

            if (Status.LoadcellFailure)
            {
                force = 0;
            }
            if (Status.ExtensometerFailure)
            {
                exExtension = 0;
            }

            extension = !ExtensometerInUse ? lfEncoderExtension : exExtension;

            //Nazarpour 1399/10/14
            Sensors.CurrentTemperatureSensor?.GetTemperature(Sensors.CurrentTemperatureSensor == null ? null : registerData.TemperatureData, temperatureValue);

            if (TestingSample == null) return;
            exExtension = exExtension * TestingSample.GagueLength / InstrumentParameters.ExtenGaugeLength;

            extension = (!s2E && ExtensometerInUse && !Status.ExtensometerFailure) ? exExtension : lfEncoderExtension;

            trueStrain = extension / (TestingSample.GagueLength + extension);
            strain = extension / TestingSample.GagueLength;

            stress = force / TestingSample.Area;
            trueStress = force / TestingSample.Area * (1 - 1 / Math.Exp(strain));

            massStress = TestingSample.Density > 0 ? force / TestingSample.Density : 0;
            lengthStress = TestingSample.Width > 0 ? force / TestingSample.Width : 0;


            if ((TestMethodType == TestMethodType.Tensile || TestMethodType == TestMethodType.Creep || TestMethodType == TestMethodType.Creep) && stopCode == StopCode.ForceBreakPoint && TestInProgress)
            {
                TestFinishEventArgs.Break.ForceAtBreak = Sensors.CurrentLoadCell.ForceAtBreak;
                OnTestStops(this, TestFinishEventArgs.Break);
            }
        }

        #endregion
    }
}
