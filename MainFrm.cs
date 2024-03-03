using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.Parameters;
using STM.BLayer.Reporting;
using STM.BLayer.StmTest;
using STM.BLayer.TestSample;
using STM.DLayer;
using STM.Extensions;
using STM.PLayer;
using STM.PLayer.Other;
using STM.PLayer.Report;
using STM.PLayer.Setting;
using STM.PLayer.UI;
using STM.Sensor;
using System.Threading.Tasks;
using OpenFileDialog = STM.PLayer.Open.FrmOpenFileDialog;
using STM.PLayer.Open;
using STM.BLayer.Configurations;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
//using Microsoft.Office.Interop.Excel;
using Button = System.Windows.Forms.Button;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;
using System.Xml.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using STM.Properties;

namespace STM
{
    public partial class MainFrm : Form
    {
        private readonly object tmrLock = "TimerLock";
        private Configuer configure;
        private DateTime lastAuthenticationTime;

        private ConcurrentQueue<MeasuredParams> readData;
        private MeasuredParams lastMonitorData;
        private readonly MonitorInvokeDelegate monitorInvokeDelegate;

        private Test test;
        private bool testRunning;
        private bool _DoTestTermination;
        private bool keyBoardCtrl;
        int dgvTestsCurrentRow;

        private CrossHeadSpeedMode crossHeadSpeedMode;
        private Logo logo;

        private readonly ManualResetEventSlim autoResetEvent;
        private readonly ManualResetEventSlim autoResetEventT;
        private readonly ManualResetEventSlim autoResetEventD;
        private Thread readThread, temperatureThread;
        private Thread monitorUpdaterThread;

        private TestFileDirtyStatus testOpenSaveStatus;

        private ReportingDataSource reportingDataSource;

        #region forms

        private FrmTestSetting frmTestSetting;
        private FrmCalibration frmCalibration;
        private FrmOpenFileDialog frmOpenFileDialog;
        private FileHistory testHistory;
        private FrmReporting frmReporting;
        private FrmMachineSetting frmMachineSetting;
        private FrmInstrument frmInstrument;
        private FrmReportingOptions frmReportingOptions;

        private FrmUnitSetting frmUnitSetting;
        private AboutBox about;


        #endregion

        #region constructor

        public MainFrm()
        {
            InitializeComponent();
            CreateForms();

            monitorInvokeDelegate = SetMonitorData;
            Statistics.ForceOff = SettingLoader.Current.GetforceOffset();

            testHistory = new FileHistory();

            foreach (var menu in subMenuUnits.DropDownItems.OfType<ToolStripMenuItem>())
            {
                menu.Checked = menu.Text.Equals(UnitManager.CurrentUnitCategory.ToString());
            }

            readData = new ConcurrentQueue<MeasuredParams>();
            crossHeadSpeedMode = CrossHeadSpeedMode.None;

            KeyPreview = true;

            autoResetEvent = new ManualResetEventSlim(false);
            autoResetEventT = new ManualResetEventSlim(false);
            autoResetEventD = new ManualResetEventSlim(false);

            LoadLogo();

            reportingDataSource = new ReportingDataSource();
            InitilizeReporting();
            pnlContainer.VerticalScroll.Visible = true;

            var types = MeasureTool.MeasurAbbreviations.Values.ToList();
            types.Remove(MeasureTool.MeasurAbbreviations["RelaxLoss"]);
            types.Remove(MeasureTool.MeasurAbbreviations["ForceLoss"]);
            types.Remove(MeasureTool.MeasurAbbreviations["StressLoss"]);

            types.Remove("None");
            types.Remove("Temperature");
            types.Remove("Specimen Temp Up");
            types.Remove("Specimen Temp Center");
            types.Remove("Specimen Temp Down");
            ctxMenuXType.Items.AddRange(types.ToArray());
            ctxMenuXType.SelectedIndex = 0;
            ctxMenuYType.Items.AddRange(types.ToArray());
            ctxMenuYType.SelectedIndex = 1;

            currentTests = new List<string>();

            var rcm = new ComponentResourceManager(typeof(MainFrm));
            var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            Program.SetCulture(Controls, rcm, cultureInfo);
            Program.SetMenuCulture(ctxMenuTestProperties, rcm, cultureInfo);
            Program.SetMenuCulture(ctxMenuDiagram, rcm, cultureInfo);
        }

        private void CreateForms()
        {
            frmTestSetting = new FrmTestSetting { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmMachineSetting = new FrmMachineSetting { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmOpenFileDialog = new OpenFileDialog { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmInstrument = new FrmInstrument { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmReporting = new FrmReporting { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmCalibration = new FrmCalibration { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmUnitSetting = new FrmUnitSetting { Owner = this, StartPosition = FormStartPosition.CenterParent };
            frmReportingOptions = new FrmReportingOptions { Owner = this, StartPosition = FormStartPosition.CenterParent };
            about = new AboutBox { Owner = this, StartPosition = FormStartPosition.CenterParent };

            frmTestSetting.LoadDefault();
            SetNewTestSpec();

            frmReportingOptions.DialogOk += FrmReportingOptions_DialogOk;
            frmMachineSetting.DialogOk += (sender, args) =>
            {
                TestInitializer.TimeQuantom = SerialPortParameters.ReadInterval;
                configure.OnProgressReport -= frmMachineSetting.SetProgress;
            };

            frmMachineSetting.OnUpdateSettings += (s, ex) =>
            {
                timer.Stop();
                RS232.Current.ClearPortBuffer();
                configure.Reconfig(fds: true);
                timer.Start();
            };

            frmMachineSetting.OnFds += (se, ex) =>
            {
                timer.Stop();
                RS232.Current.ClearPortBuffer();
                configure.Reconfig(true);
                timer.Start();
            };

            frmInstrument.DialogOk += (sender, args) =>
            {
                test?.ResetFilter();

                if (configure.OnProgressReport != null) configure.OnProgressReport -= frmInstrument.SetProgress;
            };

            frmInstrument.OnUpdateSettings += (s, ex) =>
            {
                timer.Stop();
                RS232.Current.ClearPortBuffer();
                configure.SendEncoder();
                timer.Start();
            };

            frmInstrument.OnChangeForceBoundary += (s, ex) =>
                {
                    try
                    {
                        InstrumentParameters.ForceMaxLimit = InstrumentParameters.ForceMaxPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
                        InstrumentParameters.ForceMinLimit = InstrumentParameters.ForceMinPercent / 100 * Sensors.CurrentLoadCell.MaxCap * Statistics.G;
                    }
                    catch
                    {
                    }
                };

            frmReporting.OnClickingCmd += delegate { plot.ViewCmd = ViewCmd.PointSelection; };
            frmReporting.Activated += (s, e) => { plot.ViewCmd = ViewCmd.None; };

            frmOpenFileDialog.OnOperationDone += (s, e) =>
            {
                if (frmOpenFileDialog.DialogResult != DialogResult.OK) return;
                OpenTests(frmOpenFileDialog.TestsPath);
            };

            frmReporting.OnOperationDone += Updatereporting;
            frmUnitSetting.OnOperationDone += OnfrmUnitDialogresult;
            #region force calibration

            frmCalibration.OnSetStartForcePoint += (sender, e) =>
            {
                try
                {
                    Sensors.CurrentLoadCell.SetCalibrationStartPoint();
                }
                catch
                {
                }
            };

            frmCalibration.OnForceCalibrate += (sender, e) =>
            {
                frmCalibration.ForceRO = Sensors.CurrentLoadCell.Calibrate(frmCalibration.StartForce, frmCalibration.StopForce);
            };

            frmCalibration.OnForceSave += (sender, e) =>
            {
                Sensors.CurrentLoadCell.SetRO(frmCalibration.ForceRO);
                Sensors.CurrentLoadCell.SetMaxCap(frmCalibration.ForceMaxCap);
                SettingLoader.Current.SetLoadcell(Sensors.CurrentLoadCell);
            };

            frmCalibration.OnTemperatureSave += (sender, e) =>
            {
                Sensors.CurrentTemperatureSensor?.SetGain(1 / frmCalibration.TemperatureGain1, 1 / frmCalibration.TemperatureGain2);
                SettingLoader.Current.SetTemperatureSensor(Sensors.CurrentTemperatureSensor);
            };

            #endregion

            #region short exten calibration

            frmCalibration.OnSetStartExtenPoint += (sender, e) =>
            {
                try
                {
                    Sensors.CurrentExtensoMeter.SetCalibrationStartPoint();
                }
                catch
                {
                }
            };

            frmCalibration.OnShortExtenCalibrate += (sender, e) =>
            {
                frmCalibration.ShortExtenRO = Sensors.CurrentExtensoMeter.Calibrate(
                        frmCalibration.StartShortExten, frmCalibration.StopShortExten);
            };

            frmCalibration.OnShortExtenSave += (sender, e) =>
            {
                Sensors.CurrentExtensoMeter.SetMaxCap(frmCalibration.ShortExtenMaxCap);
                Sensors.CurrentExtensoMeter.SetRoOrGain(frmCalibration.ShortExtenRO);
                SettingLoader.Current.SetExtensometer(Sensors.CurrentExtensoMeter);
            };

            #endregion

            #region long exten calibration

            frmCalibration.OnLongExtenCalibrate += (sender, e) =>
            {
                frmCalibration.LongExtenGain =
                    Sensors.CurrentExtensoMeter.Calibrate(frmCalibration.StartLongExten, frmCalibration.StopLongExten);
            };
            frmCalibration.OnLongExtenSave += (sender, e) =>
            {
                Sensors.CurrentExtensoMeter.SetRoOrGain(frmCalibration.LongExtenGain);
                Sensors.CurrentExtensoMeter.SetMaxCap(frmCalibration.LongExtenMaxCap);
                SettingLoader.Current.SetExtensometer(Sensors.CurrentExtensoMeter);
            };

            #endregion
        }

        private void FrmReportingOptions_DialogOk(object sender, EventArgs e)
        {
            LoadTestGroupHistoryMenu();
            if (Options.ShowGridLines != gridDraw)
                plot.DataSource.Invalid = true;
            plot.Update();
        }



        private void InitilizeReporting()
        {
            var reportFilePath = frmTestSetting.ReportFilePath;
            if (!string.IsNullOrEmpty(reportFilePath))
                reportFilePath = string.Format("Report Settings\\{0}", reportFilePath);
            reportingDataSource.Load(reportFilePath);
            SetReportResultGridView();
        }

        private void LoadLogo()
        {
            using (var sl = SettingLoader.Current)
            {
                logo = sl.LoadLogo();
            }
            try
            {
                logo.LogoBmp = new Bitmap(logo.LogoPath);
            }
            catch
            {
                logo.LogoBmp = new Bitmap(1, 1);
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                //var debugScreen = 0;
                //if (!int.TryParse(Environment.GetEnvironmentVariable("DEBUG_SCREEN") ?? string.Empty, out debugScreen)) debugScreen = 1;
                //Application.OpenForms[0].MoveToScreen(debugScreen);
            }
#endif
            Text = Application.CompanyName + " Jadoo" + (Program.FullCreepAvailable ? " Creep" : "") + " Software (" + Application.ProductVersion + ")";
            toolStripMenuItem6.Visible = Program.FullCreepAvailable;
            temperatureDiagramToolStripMenuItem.Visible = Program.FullCreepAvailable;
            nrMaxTemperature.Visible = Program.FullCreepAvailable;
            nrMinTemperature.Visible = Program.FullCreepAvailable;

            Task.Factory.StartNew(() =>
                                      {
                                          Test.ReadSDB();
                                          configure = new Configuer();
                                          timer.Period = SerialPortParameters.ReadInterval;
                                          test = new Test();
                                          configure.OnExtensometerDetection += NotifyNewExtensometerDetection;
                                          configure.OnLoadCellDetection += NotifyNewLoadCellDetection;
                                          configure.OnLoadCellAthentication += NotifyNewLoadCellAthentication;
                                          configure.OnTemperatureSensorDetection += NotifyNewTemperatureSensorDetection;
                                          configure.OnTemperatureSensorAthentication += NotifyNewTemperatureSensorAthentication;
                                          if (InstrumentParameters.TemperatureHMI)
                                              TMPR485.Current?.UpdateTemperatures();
                                          else
                                              TMPR232.Current?.ClearPortBuffer();

                                          configure.Reconfig();

                                          timer.Start();
                                      });
            plot.Initilize();
            StartPlotUpdaterTask();
            LoadPlotUnitsMenuItems();
            monitorUpdaterThread = new Thread(SetMonitorData);
            monitorUpdaterThread.Start();

            temperatureThread = new Thread(ReadTemperatures) { };
            if (Program.FullCreepAvailable)
            {
                temperatureThread.Start();
            }

            readThread = new Thread(Read) { Priority = ThreadPriority.Highest };
            readThread.Start();
            LoadTestGroupHistoryMenu();

            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                SplashScreen.CloseForm(3000);
                //BringMainWindowToFront(Process.GetCurrentProcess().ProcessName);
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                this.Show();
                this.Activate();
            }
        }

        private void LoadTestGroupHistoryMenu()
        {
            try
            {
                var openedTests = plot.DataSource.DataSources.Select(p => p.FullPath).ToList();
                menuRecentTests.DropDownItems.Clear();
                var recentTests = testHistory.GetRecentTests().Where((p, i) => i < Options.MaxRecentFiles).ToList();
                menuRecentTests.DropDownItems.AddRange(recentTests.Select(p => p != null ? new ToolStripMenuItem(p) { Name = string.Format("menuRecentTest{0}", p), } : null).ToArray());
                foreach (ToolStripMenuItem item in menuRecentTests.DropDownItems)
                {
                    item.Checked = openedTests.Contains(item.Text);
                    item.Click += (s, e) =>
                                      {
                                          var menu = (ToolStripMenuItem)s;
                                          if (menu.Checked)
                                          {
                                              menu.Checked = false;
                                              var fileInfo = new FileInfo(menu.Text);
                                              var testName = fileInfo.Extension == ".ttdx"
                                                  ? fileInfo.Name.Replace(".ttdx", "")
                                                  : fileInfo.Name.Replace(".ttd", "");

                                              if (!currentTests.Contains(testName)) return;
                                              CloseTest(testName);
                                          }
                                          else
                                          {
                                              menu.Checked = true;
                                              var name = menu.Name.Remove(0, "menuRecentTest".Length);
                                              OpenTests(new List<string> { name }, true);
                                          }
                                      };
                }

            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            try
            {
                ctxCbRecentGroups.Items.Clear();
                menuAddToGroup.DropDownItems.Clear();
                ctxCbRecentGroups.Items.AddRange(testHistory.GetGroups());

                ctxCbRecentGroups.Enabled = ctxCbRecentGroups.Items.Count > 0;
                if (ctxCbRecentGroups.Enabled) ctxCbRecentGroups.SelectedIndex = 0;
                menuAddToGroup.DropDownItems.AddRange(testHistory.GetGroups().Select(p => new ToolStripMenuItem(p) { Name = string.Format("menuGroups{0}", p) }).ToArray());
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

        }

        //private void OpenGroup(object sender, EventArgs e)
        //{
        //    var gName = ((ToolStripItem) sender).Name.Remove(0, "menuGroups".Length);
        //    var paths = testHistory.GetGroupTest(gName);
        //    OpenTests(paths);
        //}



        #endregion
        // 1400/04/22, Nazarpour
        private volatile int _ElectroHydrocControlCounter = 0;
        private volatile int _TemperatureResetCounter = 0;
        private double _ForceAtBreak = 0.0;

        private void timer_Tick(object sender, EventArgs e)
        {
            lock (tmrLock)
            {
                autoResetEvent.Set();
            }

            if (_TemperatureResetCounter > 0)
            {
                if (--_TemperatureResetCounter == 0)
                {
                    var force = Math.Abs(lastMonitorData.Force);
                    if (force < Math.Abs(Sensors.CurrentLoadCell?.MaxCap ?? int.MaxValue) * 0.05)
                    {
                        if (force < Math.Abs(_ForceAtBreak) * 0.3)
                            Test.SetTemperature(InstrumentParameters.TemperatureHMI, 0.0f);
                    }
                }
            }

            //if (CrossHead.ElectroHydrolic)
            //{
            //    if (_ElectroHydrocControlCounter > 0)
            //    {
            //        if (--_ElectroHydrocControlCounter == 0)
            //        {
            //            Test.JogSpeed = 0; // Also in Read()
            //        }
            //    }

            //    if (_ElectroHydrocControlCounter < 0)
            //    {
            //        if (++_ElectroHydrocControlCounter == 0)
            //        {
            //            if (CrossHead.ActuatorUp)
            //            {

            //            }
            //            else if(lastMonitorData.Force < 1000)
            //            {
            //                Test.JogSpeed = 0.001; // Also in Read()
            //                _ElectroHydrocControlCounter = 50;
            //            }
            //        }
            //    }
            //}
        }

        private void ReadTemperatures()
        {
            while (true)
            {
                autoResetEventT.Wait();
                autoResetEventT.Reset();

                Test.ReadTemperatures(InstrumentParameters.TemperatureHMI);

                //autoResetEventD.Set();
            }
        }

        private void Read()
        {
            while (true)
            {
                autoResetEvent.Wait();
                autoResetEvent.Reset();

                CrossHead.CtrlKey = Status.CtrlKey || keyBoardCtrl;
                var mode = Status.StatusSpeedMode == CrossHeadSpeedMode.None ? crossHeadSpeedMode : Status.StatusSpeedMode;
                // 1400/09/11, Nazarpour
                if (!testRunning)
                    Test.JogSpeed = mode != CrossHeadSpeedMode.None ?
                        CrossHead.GetJogSpeed(mode) : (_ElectroHydrocControlCounter > 0 ? 0.001 : 0);
                //Test.JogSpeed = mode != CrossHeadSpeedMode.None ? CrossHead.GetJogSpeed(mode) : 0;

                var currentMeasures = test.Read();
                CheckFialures();

                CheckStatusKey();
                lastMonitorData = currentMeasures;

                autoResetEventD.Set();
                autoResetEventT.Set();

                if (!currentMeasures.ToPlot) continue;
                readData.Enqueue(currentMeasures);

            }
        }

        private void StartPlotUpdaterTask()
        {
            Task.Factory.StartNew(() =>
                     {
                         while (true)
                         {
                             BeginInvoke(new PlotUpdateDelagte(() =>
                                          {
                                              MeasuredParams measuredParams;
                                              while (readData.TryDequeue(out measuredParams))
                                              {
                                                  var dSample = new DataSample(
                                                      measuredParams.Force,
                                                      measuredParams.Extension,
                                                      measuredParams.Time,
                                                      test.TestingSample?.GagueLength ?? 0,
                                                      test.TestingSample?.Area ?? 0,
                                                      test.TestingSample?.Density ?? 0,
                                                      test.TestingSample?.Width ?? 0,
                                                      measuredParams.StepOrCycle
                                                      );
                                                  if (TMPR232.Connected)
                                                      dSample.SetTemperatures(measuredParams.Temperature);
                                                        //dSample.SetTemperatures(measuredParams.Temperature[3], measuredParams.Temperature[4], measuredParams.Temperature[5],
                                                        //        measuredParams.Temperature[0], measuredParams.Temperature[1], measuredParams.Temperature[2],
                                                        //        measuredParams.Temperature[6]);
                                                  else if (TMPR485.Connected)
                                                      dSample.SetTemperatures(measuredParams.Temperature);
                                                  plot.AddPlotSample(dSample, measuredParams.Decimation, test.curStage?.TemperatureSetPoint ?? 0);
                                                  TestOpenSave.Current.AddDataSample(dSample);
                                              }
                                              plot.Refresh();
                                          }));
                             if (_DoTestTermination)
                             {
                                 TerminateCurrentTest();
                                 _DoTestTermination = false;

                                 SettingLoader.Current.LoadSpeedCtrlSetting();
                             }
                             Thread.Sleep(100);
                         }
                     });
        }

        private void SetMonitorData()
        {
            while (true)
            {
                autoResetEventD.Wait();
                autoResetEventD.Reset();

                if (lastMonitorData != null)
                    BeginInvoke(monitorInvokeDelegate, new object[] { lastMonitorData });

                //Thread.Sleep(50);
            }
        }

        private void SetMonitorData(MeasuredParams measuredParams)
        {
            measureMonitors.SetMeasuredParams(measuredParams);
            if (testRunning)
            {
                bttnStartTest.BackgroundImage = measuredParams.MotorResponseSpeed > 0 ? images1.SlowUp : images1.SlowDown;
            }
            else
            {
                bttnStartTest.BackgroundImage = images1.StartTest;
            }
            tslEncoderSpeed.Text = string.Format("(Set:Response) {0,-8:0.000}: {1,-8:0.000}", measuredParams.SetSpeed, measuredParams.MotorResponseSpeed);
        }

        #region timer and data read


        #endregion

        #region Methods

        private void NotifyNewExtensometerDetection(int type)
        {
            using (var sdf = new SensorDetectionFrm())
            {
                sdf.SensorType = SensorType.Extensometer;
                sdf.Text = Resources.MainFrm_NotifyNewExtensometerDetection_New_extensometer_is_detected;
                if (sdf.ShowDialog() != DialogResult.OK) return;
                Sensors.Add(new ExtensoMeter((int)sdf.MaxCapacity, sdf.RO, type, sdf.Option == 1, sdf.Option == 2));
                SettingLoader.Current.SetLastExtenAnalogType(sdf.Option == 2);
                Configuer.Def2(sdf.Option == 2);
                Configuer.ResetSDB();

            }
            //using (var af = new AuthenticationFrm())
            //{
            //    bool show = ShowAuthenticationFrm();
            //    bool validUser = false;
            //    if (show)
            //        validUser = af.ShowDialog() == DialogResult.OK;
            //    lastAuthenticationTime = validUser ? DateTime.Now : lastAuthenticationTime;
            //    if (!show || validUser)
            //    {

            //    }
            //}
        }

        private void NotifyNewLoadCellAthentication(double maxCap, double ro)
        {
            using (var sdf = new SensorDetectionFrm())
            {
                sdf.SensorType = SensorType.Loadcell;
                sdf.Text = Resources.MainFrm_NotifyNewLoadCellAthentication_Loadcell_Identification;
                sdf.LbOkText = "Ok";
                sdf.MaxCapacity = maxCap > 0 ? maxCap : 1;
                sdf.RO = ro != 0 ? ro : 10;
                sdf.ReadOnly = true;
                sdf.ShowDialog();

            }
        }

        private void NotifyNewTemperatureSensorAthentication(double maxCap, double ro)
        {
            using (var sdf = new SensorDetectionFrm())
            {
                sdf.SensorType = SensorType.TemperatureSensor;
                sdf.Text = Resources.MainFrm_NotifyNewTemperatureSensorAthentication_Temperature_Sensor_Identification;
                sdf.LbOkText = "Ok";
                sdf.MaxCapacity = maxCap;
                sdf.RO = ro;
                sdf.ReadOnly = true;
                sdf.ShowDialog();

            }
        }

        private void NotifyNewLoadCellDetection(int type)
        {
            using (var sdf = new SensorDetectionFrm())
            {
                sdf.SensorType = SensorType.Loadcell;
                sdf.Text = Resources.MainFrm_NotifyNewLoadCellDetection_New_loadcell_is_detected;
                if (sdf.ShowDialog() == DialogResult.OK)
                {
                    Sensors.Add(new LoadCell((int)sdf.MaxCapacity, (int)sdf.RO, type));
                }
            }
            //using (var af = new AuthenticationFrm())
            //{
            //    bool show = ShowAuthenticationFrm();
            //    bool validUser = false;
            //    if (show)
            //        validUser = af.ShowDialog() == DialogResult.OK;
            //    lastAuthenticationTime = validUser ? DateTime.Now : lastAuthenticationTime;
            //    if (!show || validUser)
            //    {
            //        using (var sdf = new SensorDetectionFrm())
            //        {
            //            sdf.SensorType = SensorType.Loadcell;
            //            sdf.Text = @"New loadcell is detected";
            //            if (sdf.ShowDialog() == DialogResult.OK)
            //            {
            //                Sensors.Add(new LoadCell((int) sdf.MaxCapacity, (int) sdf.RO, type));
            //            }
            //        }
            //    }
            //    else
            //        return;
            //}
        }

        private void NotifyNewTemperatureSensorDetection(int countOfSensors)
        {
            using (var sdf = new SensorDetectionFrm())
            {
                sdf.SensorType = SensorType.TemperatureSensor;
                sdf.Text = Resources
	                .MainFrm_NotifyNewTemperatureSensorAthentication_Temperature_Sensor_Identification;
                sdf.MaxCapacity = 1;
                sdf.RO = InstrumentParameters.TemperatureGain1;
                //if (sdf.ShowDialog() == DialogResult.OK)
                {
                    Sensors.Add(new TemperatureSensor((int)sdf.MaxCapacity, (int)sdf.RO /*, countOfSensors*/));
                }
            }
        }

        private bool ShowAuthenticationFrm()
        {
            bool showAuthntication = !((DateTime.Now - lastAuthenticationTime).TotalSeconds < 180);
            return showAuthntication;
        }

        #endregion

        #region control button events



        private void bttnStartTest_Click(object sender, EventArgs e)
        {
            ConfigStartTest();
        }

        private void ConfigStartTest()
        {
            if (testRunning)
                return;

            CheckModification();
            menuAddToGroup.Enabled = false;

            reportingDataSource.ReportingResults.Clear();
            rtbTestProgress.ReadOnly = true;
            rtbTestProgress.Clear();
            rtbTestProgress.SelectionFont = new Font("Times new romans", 15f, FontStyle.Bold);
            rtbTestProgress.AppendText(Resources.MainFrm_ConfigStartTest_Test_Progress + Environment.NewLine);
            rtbTestProgress.SelectionFont = new Font("Times new romans", 12f, FontStyle.Regular);
            tcTestsTab.SelectedTab = tpTestProgress;
            // aa ucSpe

            Plot.XM = MeasureTool.GetUnit(Plot.XMeasureType).M;
            Plot.YM = MeasureTool.GetUnit(Plot.YMeasureType).M;
            Plot.Y2M = MeasureTool.GetUnit(Plot.Y2MeasureType).M;
            StartTest();
        }

        private void bttnStopTest_Click(object sender, EventArgs e)
        {
            PrepareStopTest(e);
        }

        private void PrepareStopTest(EventArgs e = null)
        {
            if (test != null && testRunning && test.IsLongRunning && !(e is Test.TestFinishEventArgs))
            {
                if (test.IsInSafeStage())
                {
                    if (MessageBox.Show(this, Resources.MainFrm_PrepareStopTest_, Resources.FrmTestSetting_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                    _DoTestTermination = true;
                    test.CancelReturnZero();
                    crossHeadSpeedMode = CrossHeadSpeedMode.None;
                }
                else
                {
                    if (MessageBox.Show(this,
                        Resources.MainFrm_PrepareStopTest_2, Resources.FrmTestSetting_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                    test.JumpToSafeStage();
                }

                if (_TemperatureResetCounter == 0 && Test.SetTemperatureToZeroOnTestStop)
                    Test.SetTemperature(InstrumentParameters.TemperatureHMI, 0.0f);
            }
            else
            {
                _DoTestTermination = true;
                test?.CancelReturnZero();
                crossHeadSpeedMode = CrossHeadSpeedMode.None;
            }
        }

        private void bttnJogUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            crossHeadSpeedMode = CrossHead.CtrlKey ? CrossHeadSpeedMode.Up : CrossHeadSpeedMode.FastUp;
        }

        private void bttnJogDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            crossHeadSpeedMode = CrossHead.CtrlKey ? CrossHeadSpeedMode.Down : CrossHeadSpeedMode.FastDown;
        }

        private void JogSpeedMouseUp(object sender, MouseEventArgs e)
        {
            // 1400/04/22, Nazarpour
            if (CrossHead.ElectroHydrolic)
            {
                if (crossHeadSpeedMode == CrossHeadSpeedMode.Down || crossHeadSpeedMode == CrossHeadSpeedMode.FastDown)
                    _ElectroHydrocControlCounter = -50;
                //if (crossHeadSpeedMode == CrossHeadSpeedMode.Up || crossHeadSpeedMode == CrossHeadSpeedMode.FastUp)
                //    _ElectroHydrocControlCounter = 50;
            }
            Test.JogSpeed = 0;
            CrossHead.RestSpeed();
            crossHeadSpeedMode = CrossHeadSpeedMode.None;
        }

        private void bttnReturnToZero_Click(object sender, EventArgs e)
        {
            test.ReturnToZero(CrossHead.CtrlKey ? ReturnZeroMode.Force : ReturnZeroMode.Extension);
        }

        #endregion

        #region measure monitor


        private void measureMonitors_OnZeroExten(object sender, EventArgs e)
        {
            if (!testRunning)
                lock (tmrLock)
                    test.ZeroLfExtension();
        }

        private void measureMonitors_OnZeroStrain(object sender, EventArgs e)
        {
            if (!testRunning)
                lock (tmrLock)
                    test.ZeroExExtension();
        }

        private void measureMonitors_OnZeroForce(object sender, EventArgs e)
        {
            if (!testRunning)
                lock (tmrLock)
                    test.ZeroForce();
        }

        private void measureMonitors_OnZeroTemperature(object sender, EventArgs e)
        {
            //lock (tmrLock)
            //	test.ZeroTemperature();
        }

        private void measureMonitors_OnZeroTemperatureUp(object sender, EventArgs e)
        {
            //lock (tmrLock)
            //	test.ZeroTemperatureUp();
        }

        private void measureMonitors_OnZeroTemperatureCenter(object sender, EventArgs e)
        {
            //lock (tmrLock)
            //	test.ZeroTemperatureCenter();
        }

        private void measureMonitors_OnZeroTemperatureDown(object sender, EventArgs e)
        {
            //lock (tmrLock)
            //	test.ZeroTemperatureDown();
        }

        #endregion

        #region unit changing

        //add
        public void UpdateUnit(MeasureType measureType, string unit, bool updateReport = true, bool updatePlot = true)
        {
            MeasureTool.SetUnit(measureType, unit);

            measureMonitors.UpdateUnit(measureType, unit);
            LoadPlotUnitsMenuItems(true, updateReport);
            if (updateReport)
            {
                UpdateReportsDataSource();
                SetReportResultGridView();
            }
            var changes = false;
            if (Plot.XMeasureType == measureType || MeasureTool.IsExtensionGroup(Plot.XMeasureType, measureType))
            {
                changes = Plot.XUnitText != unit;
                Plot.XUnitText = unit;
                Plot.XMeasureText = MeasureTool.IsExtensionGroup(Plot.XMeasureType, measureType)
                                        ? Resources.MeasureTool_MeasurAbbreviations_Extension
                                        : MeasureTool.GetMeasureName(measureType).ToUpper();
                Plot.XM = MeasureTool.GetUnit(Plot.XMeasureType).M;
            }
            else if (Plot.YMeasureType == measureType || MeasureTool.IsExtensionGroup(Plot.YMeasureType, measureType))
            {
                changes = Plot.YUnitText != unit;
                Plot.YUnitText = unit;
                Plot.YMeasureText = MeasureTool.IsExtensionGroup(Plot.YMeasureType, measureType)
                                        ? Resources.MeasureTool_MeasurAbbreviations_Extension
										: MeasureTool.GetMeasureName(measureType).ToUpper();
				Plot.YM = MeasureTool.GetUnit(Plot.YMeasureType).M;
            }
            else if (Plot.Y2MeasureType != MeasureType.None)
            {
                changes = Plot.Y2UnitText != MeasureTool.GetUnit(Plot.Y2MeasureType).Abbreviation;
                Plot.YUnitText = unit;

                Plot.Y2MeasureText = MeasureTool.IsExtensionGroup(Plot.Y2MeasureType, measureType)
                                        ? Resources.MeasureTool_MeasurAbbreviations_Extension
										: MeasureTool.GetMeasureName(measureType).ToUpper();
				Plot.Y2M = MeasureTool.GetUnit(Plot.Y2MeasureType).M;
            }
            if (changes && !testRunning && updatePlot)
            {
                plot.UnitChanges();
            }
        }

        private void LoadPlotUnitsMenuItems(bool update = false, bool updateReport = true)
        {
            ctxMenuXUnit.DropDownItems.Clear();
            ctxMenuYUnit.DropDownItems.Clear();
            ctxMenuXOffset.Text = string.Format(Resources.MainFrm_LoadPlotUnitsMenuItems_Offset__0__by, MeasureTool.GetMeasureName(Plot.XMeasureType));
            string xSelected;
            string ySelected;
            var items = MeasureTool.Units(Plot.XMeasureType, out xSelected);
            ctxMenuXUnit.Text = string.IsNullOrEmpty(Plot.XMeasureText)
                                    ? ctxMenuXUnit.Text
                                    : string.Format(Resources.MainFrm_LoadPlotUnitsMenuItems__0__Units, MeasureTool.GetMeasureName(Plot.XMeasureType));
            foreach (var menu in items.Select(item => new ToolStripMenuItem(item) { Name = item, Checked = false }))
            {
                ctxMenuXUnit.DropDownItems.Add(menu);
                menu.Checked = menu.Text.Equals(xSelected);
                ToolStripMenuItem menu1 = menu;
                menu.Click += (s, e) =>
                                  {
                                      if (menu1.Checked)
                                          return;
                                      UpdateUnit(Plot.XMeasureType, menu1.Text);
                                  };
            }
            items = MeasureTool.Units(Plot.YMeasureType, out ySelected);
            ctxMenuYUnit.Text = string.IsNullOrEmpty(Plot.YMeasureText)
                                    ? ctxMenuYUnit.Text
                                    : string.Format(Resources.MainFrm_LoadPlotUnitsMenuItems__0__Units,  MeasureTool.GetMeasureName(Plot.YMeasureType));

            foreach (var menu in items.Select(item => new ToolStripMenuItem(item) { Name = item, Checked = false }))
            {
                var menu1 = menu;
                menu.Click += (s, e) =>
                                  {
                                      if (menu1.Checked)
                                          return;
                                      UpdateUnit(Plot.YMeasureType, menu1.Text);
                                  };
                menu.Checked = menu.Text.Equals(ySelected);
                ctxMenuYUnit.DropDownItems.Add(menu);
            }

            if (!update)
            {
                UpdateUnit(Plot.XMeasureType, xSelected, updateReport, true);
                UpdateUnit(Plot.YMeasureType, ySelected, updateReport, true);
            }
        }

        // private void UnitChanges(object sender, UnitChangeEventArgs e)


        #endregion

        #region drag

        private void MainFrm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void MainFrm_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var i = 0;
            i++;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ShowDialog();
            }
        }

        #endregion

        #region file menu

        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveTest();
        }

        bool blockedDlgInProgress;
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            //var t = new Thread(() =>
            //{
            SaveFileDialog fbd = new SaveFileDialog();
            fbd.Filter = @"Test File|*.ttdx";

            if (fbd.ShowDialog() == DialogResult.Cancel)
                return;

            selectedPath = fbd.FileName;
            if (selectedPath != "")
            {
                SaveTest(selectedPath);
            }
            //});
            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();

            // Invoke((Action)(() => { saveFileDialog.ShowDialog() }));

            // t.Join();

            //if (blockedDlgInProgress) return;

            //Task.Factory.StartNew(() =>
            //{

            //    blockedDlgInProgress = true;
            //    try
            //    {
            //        using (var saveFileDialog = new SaveFileDialog())
            //        {
            //            //Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            //            saveFileDialog.Filter = @"Test File|*.ttdx";
            //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //            {
            //                SaveTest(saveFileDialog.FileName);
            //            }
            //        }
            //    }
            //    catch(Exception exception)
            //    {

            //    }
            //    blockedDlgInProgress = false;
            //});

        }

        private void menuCloseTest_Click(object sender, EventArgs e)
        {
            CloseAll();
        }

        private void menuPrint_Click(object sender, EventArgs e)
        {
            var printList = GetPrintData();
            printting.SetPrintData(printList);
            printting.Print();
        }

        private bool printPreviewTask;

        private void menuPrintPreview_Click(object sender, EventArgs e)
        {
            if (printPreviewTask) return;
            Task.Factory.StartNew(() =>
            {
                printPreviewTask = true;
                try
                {
                    var printList = GetPrintData();
                    printting.SetPrintData(printList);
                    printting.ShowPrintPreview();
                }
                catch { }
                printPreviewTask = false;
            });
        }

        private IEnumerable<Bitmap> GetPrintData()
        {
            var printList = new List<Bitmap>();
            Rectangle bounds;
            try
            {
                bounds = printting.GetMarginBounds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Bitmap>();
            }
            var y = bounds.Top;
            if (Options.PrintLogo)
            {
                LoadLogo();
                logo.Width = bounds.Width;
                logo.Height = 70;
                y += logo.Height;
                printList.Add(logo.GetReportLogo());
            }
            if (Options.PrintPlot)
            {
                var plotp = plot.GetPrintVersion(bounds.Width, 400, 60, 20, 20, 45);
                printList.Add(plotp);
                y += plotp.Height;
            }

            var rem = Bounds.Height - y;
            if (rem < 150)
                rem = bounds.Height;
            try
            {
                if (Options.PrintTestsSpec)
                {
                    lbCaption.Text = Resources.MainFrm_GetPrintData_Test_Specifications;
                    var caption = new Bitmap(lbCaption.Width, lbCaption.Height);
                    lbCaption.DrawToBitmap(caption, lbCaption.ClientRectangle);
                    var gph = Graphics.FromImage(caption);
                    gph.DrawRectangle(Pens.Black, 1, 1, caption.Width - 2, caption.Height - 2);
                    printList.Add(caption);

                    ucSpec.Multiple();
                    var bmp = new Bitmap(ucSpec.InfoPanel().Width, ucSpec.InfoPanel().Height);
                    ucSpec.InfoPanel().DrawToBitmap(bmp, ucSpec.InfoPanel().ClientRectangle);
                    printList.Add(bmp);
                    bmp = new Bitmap(ucSpec.MethodPanel().Width, ucSpec.PrintHeight + 20);
                    ucSpec.MethodPanel().DrawToBitmap(bmp, ucSpec.MethodPanel().ClientRectangle);
                    printList.Add(bmp);
                    ucSpec.CancelMultiple();
                }
            }
            catch
            {
            }

            try
            {
                if (Options.PrintTestResults)
                {
                    lbCaption.Text = Resources.MainFrm_GetPrintData_Tests_Results;
                    var caption = new Bitmap(lbCaption.Width, lbCaption.Height);
                    lbCaption.DrawToBitmap(caption, lbCaption.ClientRectangle);
                    var gph = Graphics.FromImage(caption);
                    gph.DrawRectangle(Pens.Black, 1, 1, caption.Width - 2, caption.Height - 2);
                    printList.Add(caption);

                    dgvReportingResults.EnableHeadersVisualStyles = false;
                    var rows = new List<int>();
                    var cols = new List<int>();
                    foreach (DataGridViewRow row in dgvReportingResults.Rows)
                    {
                        if (row.Selected) rows.Add(row.Index);
                        row.Selected = false;
                    }
                    foreach (DataGridViewColumn col in dgvReportingResults.Columns)
                    {
                        if (col.Selected) cols.Add(col.Index);
                        col.Selected = false;
                    }

                    var bmp = new Bitmap(dgvReportingResults.Width, dgvReportingResults.Height);
                    dgvReportingResults.DrawToBitmap(bmp, dgvReportingResults.ClientRectangle);
                    dgvReportingResults.EnableHeadersVisualStyles = true;
                    foreach (var row in rows)
                        dgvReportingResults.Rows[row].Selected = true;
                    foreach (var col in cols)
                        dgvReportingResults.Columns[col].Selected = true;
                    printList.Add(bmp);
                }
            }
            catch
            {
            }



            return printList;
        }

        private void menuOpenTest_Click(object sender, EventArgs e)
        {
            frmOpenFileDialog.Show();
        }

        private void OpenTests(IEnumerable<string> testsPath, bool append = false)
        {
            TestOpenSave.Current.ClearLastTests = !append;
            if (!append)
            {
                plot.DataSource.Clear();
                reportingDataSource.ReportingResults.Clear();
                frmReporting.ReportingParameters.Clear();
                currentTests.Clear();
                plot.Initilize();
            }
            if (!append)
                currentTests.Clear();
            foreach (var path in testsPath)
            {
                TestingSample sample = null;
                TestInformation testInfo = null;
                TestMethodType testMethodType = 0;
                string testName = "";
                if (path.EndsWith(".ttd"))
                {
                    testName = TestOpenSave.Current.ReadSpecification_PrevVersions(path, out sample, out testInfo, out testMethodType, true);
                    testHistory.AddOpenedTestToHistory(new List<string> { path });
                    currentTests.Add(testName);
                }
                else if (path.EndsWith(".ttdx"))
                {
                    testName = TestOpenSave.Current.ReadSpecification(path, out sample, out testInfo, out testMethodType, true);
                    if (testName != null)
                    {
                        testHistory.AddOpenedTestToHistory(new List<string> { path });
                        currentTests.Add(testName);
                    }
                    else testHistory.Remove(path);
                }
            }

            reportingDataSource.Clear();
            RefreshDgvTests();
            LoadTestGroupHistoryMenu();
        }



        #endregion

        #region Setting Menu

        private void subMenuMachineSetting_Click(object sender, EventArgs e)
        {
            configure.OnProgressReport += frmMachineSetting.SetProgress;
            frmMachineSetting.Show();
        }

        private void subMenuInstrument_Click(object sender, EventArgs e)
        {
            configure.OnProgressReport += frmInstrument.SetProgress;
            frmInstrument.Show();
        }


        private void subMenuOptionSetting_Click(object sender, EventArgs e)
        {
            frmReportingOptions.OnColorPreview += OnColorPreview;
            gridDraw = Options.ShowGridLines;
            frmReportingOptions.Show();
        }

        private void OnColorPreview(object s, ColorPreviewEventArgs ev)
        {
            switch (ev.SectionName)
            {
                case ColorSection.Background:
                    plot.BackGroundColor = Colors.Background;
                    break;

                case ColorSection.Diagram:
                    break;

                case ColorSection.Diagram2:
                    break;

                case ColorSection.Grid:
                    plot.GridColor = ev.Color;
                    break;

                case ColorSection.Lable:
                    plot.LabelColor = ev.Color;
                    break;

                case ColorSection.PageSpac:
                    plot.MarginColor = ev.Color;
                    break;

                case ColorSection.Scale:
                    plot.ScaleColor = ev.Color;
                    break;

                case ColorSection.Title:
                    break;

            }
            plot.DataSource.Invalid = true;
            plot.Update();
        }

        private void subMenuCalibration_Click(object sender, EventArgs e)
        {
            frmCalibration.Show();
        }

        #endregion

        #region Test menu

        private void subMenuDefaultTest_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = dgvReportingResults.Rows[dgvTestsCurrentRow].Cells[string.Format("col{0}", -1)].Value.ToString().Trim();
                if (!currentTests.Contains(selected)) return;
                var xmlSetting = plot.DataSource.DataSources.First(p => p.Name == selected).XmlTestSetting;
                frmTestSetting.SetDefaultSetting(xmlSetting); //aa
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        private void subMenuDrawParams_Click(object sender, EventArgs e)
        {
            Color color;
            DashStyle lineStyle;
            Marker marker;
            using (var frmDrwaings = new FrmDrwaings())
            {
                frmDrwaings.ShowDialog();
                frmDrwaings.BringToFront();
                color = frmDrwaings.DrawingColor;
                lineStyle = frmDrwaings.DrawingLineStyle;
                marker = frmDrwaings.DrawingMarker;
            }

            try
            {
                var selected = dgvReportingResults.Rows[dgvTestsCurrentRow].Cells[string.Format("col{0}", -1)].Value.ToString().TrimStart();
                if (!currentTests.Contains(selected)) return;
                var dataSource = plot.DataSource.DataSources.First(p => p.Name == selected);
                dataSource.DrawingColor = color;
                dataSource.LineStyle = lineStyle;
                dataSource.Marker = marker;
                plot.DataSource.Invalid = true;
                plot.Update();
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }


        private void NewTest_Click(object sender, EventArgs e)
        {
            if (testRunning && test != null)
            {
                if (test.IsLongRunning)
                {
                    var stage = test.stages.Where(s => s.LimitedModificationInTest).FirstOrDefault();
                    if (stage == null && test.curStage != null && test.curStage.LimitedModificationInTest) stage = test.curStage;
                    if (stage != null)
                    {
                        FrmTestSettingsLimited frm = new FrmTestSettingsLimited();
                        frm.Show(this);
                        //frm.OnOperationDone += (s, a) => { };
                        frm.UpdateFields(stage);
                    }
                }
                return;
            }

            if (sender != subMenuNewTest) // 1401/02 Nazarpour
            {
                frmTestSetting.OnOperationDone += OnNewTestDialogResultNew;
                CloseAll();
                frmTestSetting.Show();
            }
            else if (currentTests.Count>0)  // 1402/07/24 Nazarpour
            {
                ctxMenuCurrentTest_Click(sender, e);
            }
            else
            {
                frmTestSetting.OnOperationDone += OnNewTestDialogResult;
                frmTestSetting.Show();
            }
        }

        private void OnNewTestDialogResultNew(object sender, EventArgs e)
        {
            frmTestSetting.OnOperationDone -= OnNewTestDialogResultNew;

            if (frmTestSetting.DialogResult == DialogResult.OK)
                menuCloseTest_Click(sender, e);

            OnNewTestDialogResult(sender, e);
        }

        private void OnNewTestDialogResult(object sender, EventArgs e)
        {
            frmTestSetting.OnOperationDone -= OnNewTestDialogResult;

            if (frmTestSetting.DialogResult == DialogResult.OK)
            {
                if (frmTestSetting.MeasureChanged)
                {
                    measureMonitors.ReLoadMeasures();
                    frmTestSetting.MeasureChanged = false;
                }

                Plot.XMeasureType = frmTestSetting.XMeasureType;
                Plot.YMeasureType = frmTestSetting.YMeasureType;
                Plot.Y2MeasureType = frmTestSetting.Y2MeasureType;
                Plot.XUnitText = MeasureTool.GetUnit(frmTestSetting.XMeasureType).Abbreviation;
                Plot.YUnitText = MeasureTool.GetUnit(frmTestSetting.YMeasureType).Abbreviation;
                Plot.Y2UnitText = MeasureTool.GetUnit(frmTestSetting.Y2MeasureType).Abbreviation;
                Plot.XMeasureText = MeasureTool.MeasurAbbreviations[frmTestSetting.XMeasureType.ToString()].ToUpper();
                Plot.YMeasureText = MeasureTool.MeasurAbbreviations[frmTestSetting.YMeasureType.ToString()].ToUpper();
                Plot.Y2MeasureText = MeasureTool.MeasurAbbreviations[frmTestSetting.Y2MeasureType.ToString()];

                SetNewTestSpec();
            }
        }

        private void SetNewTestSpec()
        {
            ucSpec.ImportMethod(frmTestSetting.GetMethodElemnet());
            ucSpec.ImportSpecimen(frmTestSetting.GetSpecimenElement());
            ucSpec.ImportInfo(frmTestSetting.TestInformation);
        }

        private void CheckModification()
        {
            if (testOpenSaveStatus != TestFileDirtyStatus.None)
                if (testOpenSaveStatus == TestFileDirtyStatus.New)
                {
                    var dlgResult = MessageBox.Show(Resources.MainFrm_CheckModification_Save_changes_, AboutBox.AssemblyTitle, MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.Yes)
                    {
                        SaveTest();
                        testOpenSaveStatus = TestFileDirtyStatus.Saved;
                    }
                }
        }

        private void TerminateCurrentTestu()
        {

        }

        private void SaveTest(string saveAs = "")
        {
            try
            {
                var path = string.IsNullOrEmpty(saveAs) ? plot.DataSource.DataSources[0].FullPath : saveAs;
                plot.DataSource.DataSources[0].XmlTestSetting = frmTestSetting.GetCurrentTestSetting();

                TestOpenSave.Current.SaveTest(UnitManager.CurrentUnitCategory, plot.DataSource.DataSources[0],
                           reportingDataSource.ReportingParameters.ToList(), Plot.XMeasureType, Plot.YMeasureType, path);
                if (!string.IsNullOrEmpty(saveAs))
                {
                    var preName = plot.DataSource.DataSources[0].Name;
                    plot.DataSource.DataSources[0].FullPath = saveAs;
                    plot.DataSource.DataSources[0].Name = saveAs.Split('\\').Last().Split('.')[0];

                    foreach (DataGridViewRow rw in dgvReportingResults.Rows)
                    {
                        if (rw.Cells[1].Value.ToString().Equals(preName))
                            rw.Cells[1].Value = plot.DataSource.DataSources[0].Name;
                    }
                }

                testOpenSaveStatus = TestFileDirtyStatus.Saved;
            }
            catch (Exception ex)
            {
            }
        }


        private void ShowReportingFrm()
        {
            if (!testRunning)
                frmReporting.Show();
        }

        private void Updatereporting(object sender, EventArgs e)
        {
            if (frmReporting.DialogResult != DialogResult.OK) return;
            var removedParameters = reportingDataSource.ReportingParameters.Where(p => !frmReporting.ReportingParameters.Contains(p)).ToList();
            foreach (var parametere in removedParameters)
            {
                reportingDataSource.Remove(parametere);
            }
            reportingDataSource.Clear();
            reportingDataSource.ReportingParameters = frmReporting.ReportingParameters.ToList();
            foreach (var parametere in reportingDataSource.ReportingParameters)
            {
                reportingDataSource.AddReportingParameters(parametere);
                foreach (var testDataSource in plot.DataSource.DataSources)
                {
                    try
                    {
                        var result = testDataSource.GetReportingResult(parametere, testDataSource.TestMethodType);
                        reportingDataSource.AddReportingResult(parametere, result);
                    }
                    catch
                    {
                        reportingDataSource.AddReportingResult(parametere, null);
                    }
                }
            }

            plot.ReportPoints.Clear();

            foreach (var value in reportingDataSource.ReportingResults.Values)
            {
                plot.ReportPoints.AddRange(value);
            }


            try
            {
                if (ReportingParameters.ShowElasticModule)
                {
                    foreach (var testDataSource in plot.DataSource.DataSources)
                    {
                        DataSample peak;
                        reportingDataSource.ElasticModules[testDataSource.Name] = testDataSource.GetElasticModule(out peak);
                    }
                }
            }
            catch
            {

            }

            try
            {
                if (ReportingParameters.ShowUtYield)
                {
                    foreach (var testDataSource in plot.DataSource.DataSources)
                    {
                        DataSample peak;
                        reportingDataSource.Ut_Yield[testDataSource.Name] = testDataSource.Get_UT_Yield(out peak);
                    }
                }
            }
            catch
            {

            }

            SetReportResultGridView();

            if (!plot.ShowReportPoints) return;
            plot.DataSource.Invalid = true;
            plot.Update();
        }

        private void UpdateReportsDataSource()
        {
            try
            {
                reportingDataSource.ResetResults();
                var reportingParameteres = reportingDataSource.ReportingParameters.ToList();

                if (ReportingParameters.ShowElasticModule)
                {
                    foreach (var testDataSource in plot.DataSource.DataSources)
                    {
                        DataSample peak;
                        var result = testDataSource.GetElasticModule(out peak);
                        reportingDataSource.ElasticModules[testDataSource.Name] = result;
                    }
                }

                if (ReportingParameters.ShowUtYield)
                {
                    foreach (var testDataSource in plot.DataSource.DataSources)
                    {
                        DataSample data;
                        var result = testDataSource.Get_UT_Yield(out data);
                        reportingDataSource.Ut_Yield[testDataSource.Name] = result;
                    }
                }

                foreach (var parametere in reportingParameteres)
                    try
                    {
                        foreach (var testDataSource in plot.DataSource.DataSources)
                        {
                            var result = testDataSource.GetReportingResult(parametere, testDataSource.TestMethodType);
                            reportingDataSource.AddReportingResult(parametere, result);
                        }
                    } // Nazarpour
                    catch { }
                plot.ReportPoints.Clear();
                foreach (var value in reportingDataSource.ReportingResults.Values)
                {
                    plot.ReportPoints.AddRange(value);
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        private void SetReportResultGridView()
        {
	        var rm = new System.Resources.ResourceManager(typeof(MainFrm));

			dgvReportingResults.Columns.Clear();
            dgvReportingResults.Rows.Clear();
            dgvReportingResults.SetCols(-2, "RW");
            dgvReportingResults.SetCols(-1, rm.GetString("dgvTestNameCol.HeaderText"));
            if (ReportingParameters.ShowElasticModule)
            {
                double m;
                var headerText =  Resources.MainFrm_SetReportResultGridView_Elastic_Module + Environment.NewLine + UnitManager.GetSpecialUnits((PointProperty)(-20), out m);
                dgvReportingResults.SetCols(0, headerText);
            }
            if (ReportingParameters.ShowUtYield)
            {
                double m;
                var headerText = "UT /" + Environment.NewLine + Resources.FrmTestSetting_Yield;
                dgvReportingResults.SetCols(1, headerText);
            }
            foreach (var rParams in reportingDataSource.ReportingParameters)
            {
                var col = new DataGridViewTextBoxColumn();
                dgvReportingResults.SetCols(col, rParams, false);
            }

            try
            {
                var results = new Dictionary<ReportingParameters, List<ReportingResult>>();
                foreach (var result in reportingDataSource.ReportingResults)
                {
                    var values = new List<ReportingResult>();
                    foreach (var res in result.Value)
                    {
                        if (!ReferenceEquals(res, null))
                            if (currentTests.Contains(res.TestName))
                                values.Add(res);
                    }
                    results.Add(result.Key, values);
                }
                var i = 1;
                foreach (var testName in currentTests)
                {
                    if (ReportingParameters.ShowElasticModule)
                    {
                        double m;
                        UnitManager.GetSpecialUnits((PointProperty)(-20), out m);
                        if (ReportingParameters.ShowUtYield)
                            dgvReportingResults.Rows.Add(i, testName, string.Format("  {0:f03}", reportingDataSource.ElasticModules[testName] * m), string.Format("  {0:f03}", reportingDataSource.Ut_Yield[testName]));
                        else
                            dgvReportingResults.Rows.Add(i, testName, string.Format("  {0:f03}", reportingDataSource.ElasticModules[testName] * m));
                    }
                    else
                    {
                        if (ReportingParameters.ShowUtYield)
                            dgvReportingResults.Rows.Add(i, testName, string.Format("  {0:f03}", reportingDataSource.Ut_Yield[testName]));
                        else
                            dgvReportingResults.Rows.Add(i, testName);
                    }
                    i++;
                }
                var key = reportingDataSource.ReportingParameters.First();
                var list = reportingDataSource.ReportingResults[key].Where(p => currentTests.Contains(p.TestName)).ToList();

                var seprator = false;
                if (ReportingParameters.ShowAcceptableRange || ReportingParameters.ShowMeanRMS)
                {
                    seprator = true;
                    dgvReportingResults.Rows.Add(string.Empty);
                    dgvReportingResults.Rows[dgvReportingResults.Rows.Count - 1].Height = 2;
                    dgvReportingResults.Rows[dgvReportingResults.Rows.Count - 1].DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Black, SelectionBackColor = Color.Black, SelectionForeColor = Color.Black };
                }
                if (ReportingParameters.ShowAcceptableRange)
                {
                    dgvReportingResults.Rows.Add(Resources.MainFrm_SetReportResultGridView_Acc_From, "---");
                    dgvReportingResults.Rows.Add(Resources.MainFrm_SetReportResultGridView_Acc_To, "---");
                }
                var colId = 2;

                if (ReportingParameters.ShowMeanRMS)
                {
                    dgvReportingResults.Rows.Add(Resources.MainFrm_SetReportResultGridView_Avg_, "---");
                    dgvReportingResults.Rows.Add(Resources.MainFrm_SetReportResultGridView_RMS, "---");
                    dgvReportingResults.Rows.Add(Resources.MainFrm_SetReportResultGridView_Delta, "---");
                    var offset = (ReportingParameters.ShowAcceptableRange ? 2 : 0) + (seprator ? 1 : 0);

                    if (ReportingParameters.ShowElasticModule)
                    {
                        double m;
                        UnitManager.GetSpecialUnits((PointProperty)(-20), out m);
                        var elastic = currentTests.Select(p => reportingDataSource.ElasticModules[p]).ToList();
                        var avg = elastic.Average();
                        var rms = Math.Sqrt(elastic.Sum(p => (p - avg) * (p - avg)) / (elastic.Count - 1));
                        var delta = elastic.Max() - elastic.Min();

                        dgvReportingResults.Rows[list.Count + offset].Cells[colId].Value = string.Format("  {0:f03}", avg * m);
                        dgvReportingResults.Rows[list.Count + offset + 1].Cells[colId].Value = string.Format("  {0:f03}", rms * m);
                        dgvReportingResults.Rows[list.Count + offset + 2].Cells[colId].Value = string.Format("  {0:f03}", delta * m);
                        colId++;
                    }

                    if (ReportingParameters.ShowUtYield)
                    {
                        var ut_yield = currentTests.Select(p => reportingDataSource.Ut_Yield[p]).ToList();
                        var avg = ut_yield.Average();
                        var rms = Math.Sqrt(ut_yield.Sum(p => (p - avg) * (p - avg)) / (ut_yield.Count - 1));
                        var delta = ut_yield.Max() - ut_yield.Min();

                        dgvReportingResults.Rows[list.Count + offset].Cells[colId].Value = string.Format("  {0:f03}", avg);
                        dgvReportingResults.Rows[list.Count + offset + 1].Cells[colId].Value = string.Format("  {0:f03}", rms);
                        dgvReportingResults.Rows[list.Count + offset + 2].Cells[colId].Value = string.Format("  {0:f03}", delta);
                        colId++;
                    }
                }
                else // 1401/09/02 Nazarpour
                {
                    if (ReportingParameters.ShowElasticModule) colId++;
                    if (ReportingParameters.ShowUtYield) colId++;
                }
                dgvReportingResults.Columns[0].Frozen = true;
                dgvReportingResults.Columns[1].Frozen = true;

                foreach (var col in reportingDataSource.ReportingParameters)
                {
                    var colKey = col;
                    var mUnit = 1.0;
                    var pType = col.PointProperty;
                    var mType = ReportingParameters.PointPropertyToMeasureType[pType];
                    if ((int)mType != -1)
                        mUnit = MeasureTool.GetUnit(mType).M;
                    else
                        UnitManager.GetSpecialUnits(pType, out mUnit);
                    var rw = 0;
                    for (; rw < list.Count; rw++)
                    {
                        try
                        {
                            var analysingIcon = results[colKey][rw].AnalysisResult();
                            dgvReportingResults.Rows[rw].Cells[colId].Value = string.Format("  {0}{1:f03}", analysingIcon, results[colKey][rw].Value * mUnit);
                        }
                        catch// 90.12.7
                        {
                            dgvReportingResults.Rows[rw].Cells[colId].Value = "---";
                        }
                    }
                    rw += (seprator ? 1 : 0);
                    if (ReportingParameters.ShowAcceptableRange)
                    {
                        dgvReportingResults.Rows[rw++].Cells[colId].Value = string.Format("  {0:f03}", colKey.ExpectedRangeA * mUnit);
                        dgvReportingResults.Rows[rw++].Cells[colId].Value = string.Format("  {0:f03}", colKey.ExpectedRangeB * mUnit);
                    }

                    if (ReportingParameters.ShowMeanRMS)
                    {
                        var mean = results[colKey].Average(p => p.Value);
                        var rms = Math.Sqrt(results[colKey].Sum(p => (p.Value - mean) * (p.Value - mean)) / (results[colKey].Count - 1));
                        var delta = results[colKey].Max(p => p.Value) - results[colKey].Min(p => p.Value);
                        dgvReportingResults.Rows[rw++].Cells[colId].Value = string.Format("  {0:f03}", mean * mUnit);
                        dgvReportingResults.Rows[rw++].Cells[colId].Value = string.Format("  {0:f03}", rms * mUnit);
                        dgvReportingResults.Rows[rw++].Cells[colId].Value = string.Format("  {0:f03}", delta * mUnit);
                    }

                    colId++;
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

            dgvReportingResults.Height = (dgvReportingResults.RowCount + 2) * dgvReportingResults.RowTemplate.Height + 100;
            collapsiblePanel3.Height = dgvReportingResults.Height + 45;
        }

        #endregion

        #region Tools menu

        private void subMenuToolsStandard_Click(object sender, EventArgs e)
        {
            subMenuToolsStandard.Checked = !subMenuToolsStandard.Checked;
            closeTs.Visible = subMenuToolsStandard.Checked;
        }

        private void subMenuToolsStatusBar_Click(object sender, EventArgs e)
        {
            subMenuToolsStatusBar.Checked = !subMenuToolsStatusBar.Checked;
            statusStandard.Visible = subMenuToolsStatusBar.Checked;
        }

        private void subMenuToolsMeasures_Click(object sender, EventArgs e)
        {
            subMenuToolsMeasures.Checked = !subMenuToolsMeasures.Checked;
            measureMonitors.Visible = subMenuToolsMeasures.Checked;
        }

        #endregion

        #region Test defination control


        //aaaaa
        private bool InitilizeTest()
        {
            if (!frmTestSetting.ValidSetting)
            {
                MessageBox.Show(Resources.MainFrm_InitilizeTest_Error_in_test_setting, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var testParameters = frmTestSetting.GetTestParameters();
            frmTestSetting.SetSpeedCtrlParameters();
            test = TestInitializer.CreateTest(testParameters, frmTestSetting.Sample, frmTestSetting.TestInformation);
            // Nazarpour 1399/11/14
            if (test.IsLongRunning)
            {
                var description = "";
                if (testParameters is CreepTestParameters)
                {
                    var creep = testParameters as CreepTestParameters;
                    var preTemp = UnitManager.TemperatureM * creep.TemperatureSetPoint;
                    var preTime = UnitManager.TimeM * creep.PreLoadTime;
                    var testTime = UnitManager.TimeM * creep.TestDuration;
                    var preUnit = "";
                    var testUnit = "";
                    var limitUnit = "";
                    switch (creep.PreLoadType)
                    {
                        case CreepSetPoint.Force:
                            preUnit = UnitManager.ForceUnit;
                            break;

                        case CreepSetPoint.Stress:
                            preUnit = UnitManager.StressUnit;
                            break;

                        case CreepSetPoint.MassStress:
                            preUnit = UnitManager.MassStressUnit;
                            break;

                        case CreepSetPoint.LengthStress:
                            preUnit = UnitManager.LengthStressUnit;
                            break;
                    }
                    switch (creep.SetPointType)
                    {
                        case CreepSetPoint.Force:
                            testUnit = UnitManager.ForceUnit;
                            break;

                        case CreepSetPoint.Stress:
                            testUnit = UnitManager.StressUnit;
                            break;

                        case CreepSetPoint.MassStress:
                            testUnit = UnitManager.MassStressUnit;
                            break;

                        case CreepSetPoint.LengthStress:
                            testUnit = UnitManager.LengthStressUnit;
                            break;
                    }
                    switch (Test.CustomeStopType)
                    {
                        case TestControlMode.Force:
                            limitUnit = UnitManager.ForceUnit;
                            break;

                        case TestControlMode.Extension:
                            limitUnit = UnitManager.ExtensionUnit;
                            break;

                        case TestControlMode.Stress:
                        case TestControlMode.TrueStress:
                            limitUnit = UnitManager.StressUnit;
                            break;

                        case TestControlMode.Strain:
                        case TestControlMode.TrueStrain:
                            limitUnit = UnitManager.StrainUnit;
                            break;
                    }
                    description +=
                        string.Format(Resources.MainFrm_InitilizeTest_, (creep.PreLoadValue), (preUnit), preTime, UnitManager.TimeUnit, preTemp, (UnitManager.TemperatureUnit), creep.SetPointValue, (testUnit), testTime, UnitManager.TimeUnit, Test.CustomeStopValue, limitUnit);
                }
                else if (testParameters is RelaxationTestParameters)
                {
                    //var relax = testParameters as RelaxationTestParameters;
                    //var preTemp = UnitManager.TemperatureM * relax.TemperatureSetPoint;
                    //var preTime = UnitManager.TimeM * relax.PreLoadTime;
                    //var testTime = UnitManager.TimeM * relax.TestDuration;

                    //description +=
                    //	$"specimen will get {relax.PreLoadValue:F0} {relax.PreLoadType} for {preTime:F0} {UnitManager.TimeUnit} " +
                    //	$"and oven will get to {preTemp:F0} {UnitManager.TemperatureUnit}.\r\n" +
                    //	$"afterward, specimen will get {relax.SetPointValue} {relax.PreLoadType} for {testTime} {UnitManager.TimeUnit} and displaces at most {0}.";
                }
                description += "\r\n\r\n\r\nAre you sure to run the test ?";

                if (MessageBox.Show(this, description, Resources.MainFrm_InitilizeTest_Test_conditions_confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return false;
            }

            test.OnTestStops += Test_OnTestStops;
            test.OnContinueTestS2E += OnTestOnOnContinueTestS2E;
            test.OnStopTestS2E += OnTestOnOnStopTestS2E;
            InitilizeReporting();
            return true;
        }

        private void Test_OnTestStops(object sender, Test.TestFinishEventArgs e)
        {
            if (e == Test.TestFinishEventArgs.Break)
            {
                _ForceAtBreak = e.ForceAtBreak;
                _TemperatureResetCounter = 100;
            }
            PrepareStopTest(e);
        }

        private void OnTestOnOnStopTestS2E(object sender, EventArgs e)
        {
            using (var prompter = new Prompter { Text = Resources.MainFrm_OnTestOnOnStopTestS2E_Strain_to_switching, 
	                   Message = Resources.MainFrm_OnTestOnOnStopTestS2E_Remove_Extensometer_, UserCancel = true })
            {
                prompter.ShowDialog();
                prompter.BringToFront();
            }
        }

        private void OnTestOnOnContinueTestS2E(object sender, EventArgs e)
        {
            var thd = new Thread(() =>
            {
                using (var prompter = new Prompter
                {
                    FadeTime = 5,
                    Text = Resources.MainFrm_OnTestOnOnStopTestS2E_Strain_to_switching,
                    Message = Resources.MainFrm_OnTestOnOnStopTestS2E_Remove_Extensometer_
                })
                {
                    prompter.ShowDialog();
                    prompter.BringToFront();
                }
            });
            thd.Start();
        }

        private void StartTest()
        {
            if (InitilizeTest() == false)
                return;

            SetCtxDiagramMenuType();

            if (Sensors.CurrentLoadCell != null)
            {
                Sensors.CurrentLoadCell.BreakForceOver = Test.BreakForceOver;
            }
            InstrumentParameters.ForceMinPercent = InstrumentParameters.ForceMinPercent / 100.0 * (Sensors.CurrentLoadCell != null ? Sensors.CurrentLoadCell.MaxCap * Statistics.G : 0);
            InstrumentParameters.ForceMaxPercent = InstrumentParameters.ForceMaxPercent / 100.0 * (Sensors.CurrentLoadCell != null ? Sensors.CurrentLoadCell.MaxCap * Statistics.G : 0);

            testOpenSaveStatus = TestFileDirtyStatus.New;
            readData = new ConcurrentQueue<MeasuredParams>();
            plot.NewTest(test, frmTestSetting.DiagramXStop, frmTestSetting.DiagramYStop, frmTestSetting.EnableStartScale);

            tsbZoom.Enabled = false;
            tsbUndo.Enabled = false;
            bttnJogDown.Enabled = false;
            bttnJogUp.Enabled = false;
            bttnReturnToZero.Enabled = false;
            bttnStrainToExten.Enabled = true;
            measureMonitors.Freeze();
            var dir = string.Format("{0}\\{1}", Options.OutputPath, test.TestInformation.Date);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            dgvReportingResults.Rows.Clear();
            test.OnStageChanged += (i, s) => BeginInvoke(new SetStageDescriptionText(SetStageDescription), new object[] { i, s });

            bttnStartTest.Enabled = false;

            testRunning = true;

            var fullPath = $"{Options.OutputPath}\\last.ttdx";


            TestOpenSave.Current.StartNewTestLog(UnitManager.CurrentUnitCategory, new TestDataSource
            {
                TestSample = test.TestingSample,
                TestInformation = test.TestInformation,
                TestMethodType = Test.TestMethodType
            },
            reportingDataSource.ReportingParameters.ToList(), Plot.XMeasureType, Plot.YMeasureType, fullPath);

            test.Start();
        }

        private void SetCtxDiagramMenuType()
        {
            foreach (ToolStripItem item in ctxMenuDiagramType.DropDownItems)            
                if (item is ToolStripMenuItem tsi)                
                    tsi.Checked = false;
                            
            if (Plot.XMeasureType == MeasureType.Extension && Plot.YMeasureType == MeasureType.Force)
                ctxMenuForceExtension.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Strain && Plot.YMeasureType == MeasureType.Stress)
                ctxMenuStressStrain.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Strain && Plot.YMeasureType == MeasureType.MassStress)
                massStressStarinToolStripMenuItem.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Strain && Plot.YMeasureType == MeasureType.LengthStress)
                lengthStressStarinToolStripMenuItem.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Time && Plot.YMeasureType == MeasureType.Force)
                ctxMenuForceTime.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Time && Plot.YMeasureType == MeasureType.Extension)
                ctxMenuExtensionTime.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Time && Plot.YMeasureType == MeasureType.Stress)
                ctxMenuStressTime.Checked = true;
            else if (Plot.XMeasureType == MeasureType.Time && Plot.YMeasureType == MeasureType.Strain)
                ctxMenuStrainTime.Checked = true;
        }

        private void SetStageDescription(int id, string stagedescription)
        {
            rtbTestProgress.SelectionFont = new Font("Times new romans", 12f, FontStyle.Regular);
            rtbTestProgress.AppendText(string.Format("{0}:   ", DateTime.Now.ToLongTimeString()));
            rtbTestProgress.AppendText(string.Format("Step {0}: {1}", id, stagedescription));
            rtbTestProgress.AppendText(Environment.NewLine);
            rtbTestProgress.HideSelection = true;
        }

        private void TerminateCurrentTest()
        {
            testRunning = false;
            test.ReturnToZero(ReturnZeroMode.None, true);
            test.StopTest();
            measureMonitors.UnFreeze();

            try
            {
                var fullPath = string.Format("{0}\\{1}\\{2}.ttdx", Options.OutputPath, test.TestInformation.Date, test.TestPath);
                plot.TerminateCurrentTest(test.TestPath, fullPath);
                currentTests = new List<string> { test.TestPath };
                testHistory.AddNewTestToHistory(fullPath);

                try
                {
                    if (Test.TestMethodType == TestMethodType.Relaxation || Test.TestMethodType == TestMethodType.Creep)
                    {
                        var stepId = plot.DataSource.DataSources.First().Samples.Last().StepOrCycle;
                        var index = plot.DataSource.DataSources.First().Samples.FindIndex(p => p.StepOrCycle == stepId);
                        for (int i = index; i < plot.DataSource.DataSources.First().Samples.Count; i++)
                            plot.DataSource.DataSources.First().Samples[i].MarkedLoad = plot.DataSource.DataSources.First().Samples[index].Force;
                    }
                }
                catch
                {
                }
                //OpenTests(fullPath);
            }
            catch (Exception e)
            {
	            // ignored
            }

            {
                BeginInvoke(new TestStop(() =>
                                             {


                                                 tsbZoom.Enabled = true;
                                                 tsbUndo.Enabled = true;
                                                 bttnJogDown.Enabled = true;
                                                 bttnJogUp.Enabled = true;
                                                 bttnReturnToZero.Enabled = true;
                                                 bttnStrainToExten.Enabled = false;

                                                 plot.ViewCmd = ViewCmd.None;
                                                 tcTestsTab.SelectedTab = tpTestSpec;


                                                 UpdateReportsDataSource();
                                                 SetReportResultGridView();
                                                 bttnStartTest.Enabled = true;
                                                 SaveTest();
                                                 TestOpenSave.Current.TerminateCurrentTest();
                                                 LoadTestGroupHistoryMenu();
                                                 try
                                                 {
                                                     //ucSpec.Rows.Add(ucSpec.Rows.Count + 1, test.TestPath, Test.TestMethodType.ToString(), string.Format("{0:f03}", test.TestingSample.Area),
                                                     //                      string.Format("{0:f02}", test.TestingSample.GagueLength), test.TestInformation.Description.Aggregate("", (current, s) => current + s + " "));
                                                 }
                                                 catch
                                                 {

                                                 }

                                             }));
            }
            Thread.Sleep(250);
            BeginInvoke(new TestStop(() =>
                                             {

                                                 plot.DataSource.Rebind();
                                                 plot.Fit(true);
                                                 LoadPlotUnitsMenuItems();

                                             }));
        }

        private void CheckFialures()
        {
            if (Status.UpMicroSwitch)
            {
                Test.JogSpeed = 0;
                test.StopTest();
                measureMonitors.UnFreeze();
                tlsStatusLabel.Text = Resources.MainFrm_CheckFialures_Up_Micro_Switch;
            }
            if (Status.DownMicroSwitch)
            {
                Test.JogSpeed = 0;
                test.StopTest();
                measureMonitors.UnFreeze();
                tlsStatusLabel.Text = Resources.MainFrm_CheckFialures_Down_Micro_Switch;
            }
            if (Status.DriverFailure)
            {
            }
            if (Status.ExtensometerFailure)
            {
            }
            if (Status.LfEncoderFailure)
            {
            }
            if (Status.LoadcellFailure)
            {
            }
        }

        public delegate void invokeDel1();
        private void CheckStatusKey()
        {
            if (Status.ZeroKey)
            {
                if (!testRunning)
                    test.ReturnToZero(ReturnZeroMode.Extension);
            }
            else if (Status.CtrlZeroKey)
            {
                if (!testRunning)
                    test.ReturnToZero(ReturnZeroMode.Force);
            }
            else if (Status.IsStartKeySignal())
            {
                this.Invoke((Action)(() =>
                {
                    ConfigStartTest();
                }));
            }
            else if (Status.IsStopKeySignal())
            {
                this.Invoke((Action)(() =>
                {
                    PrepareStopTest();
                }));
            }
        }

        #endregion

        #region form method

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            e.IsInputKey = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            keyBoardCtrl = e.Modifiers == Keys.Control;

            if (!testRunning)
            {
                if (keyBoardCtrl)
                {
                    bttnJogDown.BackgroundImage = images1.SlowDown;
                    bttnJogUp.BackgroundImage = images1.SlowUp;
                    bttnReturnToZero.BackgroundImage = images1.F0;

                    bttnJogUp.BackgroundImageLayout = ImageLayout.Zoom;
                    bttnJogDown.BackgroundImageLayout = ImageLayout.Zoom;
                    bttnReturnToZero.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
            else
            {
                if (test.curStage.StepOverOnHotKey == e.KeyCode)
                {
                    test.JumpToSafeStage(false);
                }
            }
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    if (!testRunning)
                        crossHeadSpeedMode = CrossHead.CtrlKey ? CrossHeadSpeedMode.Up : CrossHeadSpeedMode.FastUp;
                    break;

                case Keys.PageDown:
                    if (!testRunning)
                        crossHeadSpeedMode = CrossHead.CtrlKey ? CrossHeadSpeedMode.Down : CrossHeadSpeedMode.FastDown;
                    break;

                case Keys.Escape:
                    bttnStopTest_Click(this, e); //1399/11/30
                                                 //crossHeadSpeedMode = CrossHeadSpeedMode.None;
                                                 //_DoTestTermination = true;
                    break;

                case Keys.Home:
                    if (!testRunning)
                        test.ReturnToZero(CrossHead.CtrlKey ? ReturnZeroMode.Force : ReturnZeroMode.Extension);
                    break;
            }
        }


        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Control || e.KeyData == (Keys.LButton | Keys.ShiftKey))
                keyBoardCtrl = false;
            if (!keyBoardCtrl)
            {
                bttnJogDown.BackgroundImage = images1.FastDown;
                bttnJogUp.BackgroundImage = images1.FastUp;
                bttnReturnToZero.BackgroundImage = images1.E0;

                bttnJogUp.BackgroundImageLayout = ImageLayout.Stretch;
                bttnJogDown.BackgroundImageLayout = ImageLayout.Stretch;
                bttnReturnToZero.BackgroundImageLayout = ImageLayout.Zoom;
            }
            //if (e.KeyData == Keys.PageUp || e.KeyData == Keys.PageDown)
            if (!testRunning)
            {
                Test.JogSpeed = 0;
                crossHeadSpeedMode = CrossHeadSpeedMode.None;
            }
        }

        #endregion

        #region toolbar


        private void onPlotToolbarsClick(object sender, EventArgs e)
        {
            if (sender.Equals(tsbZoom) || sender.Equals(menuToolsZoomIn))
            {
                tsbZoom.Checked = !tsbZoom.Checked;
                menuToolsZoomIn.Checked = !menuToolsZoomIn.Checked;
                plot.ViewCmd = tsbZoom.Checked ? ViewCmd.Zoom : ViewCmd.None;
                tsbPan.Checked = false;
                menuToolsPan.Checked = false;
                tsbIndicator.Checked = false;
                plot.ShowMousePointLocation = false;
            }
            else if (sender.Equals(tsbUndo) || sender.Equals(menuToolsZoomOut))
            {
                tsbZoom.Checked = false;
                menuToolsZoomIn.Checked = false;
                tsbPan.Checked = false;
                menuToolsPan.Checked = false;
                tsbIndicator.Checked = false;
                plot.ShowMousePointLocation = false;
                plot.UndoScale();
            }
            else if (sender.Equals(tsbPan) || sender.Equals(menuToolsPan))
            {
                tsbPan.Checked = !tsbPan.Checked;
                menuToolsPan.Checked = !menuToolsPan.Checked;
                plot.ViewCmd = tsbPan.Checked ? ViewCmd.Pan : ViewCmd.None;

                tsbZoom.Checked = false;
                menuToolsZoomIn.Checked = false;
                tsbIndicator.Checked = false;
                plot.ShowMousePointLocation = false;
            }
            else if (sender.Equals(tsbIndicator))
            {
                var isChecked = !plot.ShowMousePointLocation;
                tsbIndicator.Checked = isChecked;
                plot.ShowMousePointLocation = isChecked;
            }
            else if (sender.Equals(tsbFit) || sender.Equals(menuToolsFit))
            {
                plot.Fit(true);
                tsbZoom.Checked = false;
                menuToolsZoomIn.Checked = false;
                tsbPan.Checked = false;
                menuToolsPan.Checked = false;
                tsbIndicator.Checked = false;
                plot.ShowMousePointLocation = false;
            }

        }

        #endregion

        #region Plot menu

        //add
        private void plot_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !testRunning)
            {
                ctxMenuDiagram.Show(plot, e.Location);
            }
        }




        private void unitMenu_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
                return;

            SettingLoader.Current.SetUnits(
                UnitManager.CurrentUnitCategory.ToString(),
                UnitManager.ForceUnit,
                UnitManager.ExtensionUnit,
                UnitManager.StressUnit,
                UnitManager.StrainUnit,
                UnitManager.TimeUnit,
                UnitManager.MassStressUnit, UnitManager.LengthStressUnit,
                UnitManager.TemperatureUnit);

            foreach (var menu in subMenuUnits.DropDownItems.OfType<ToolStripMenuItem>())
            {
                menu.Checked = false;
            }
            if (sender.Equals(subMenuSI))
            {
                UnitManager.CurrentUnitCategory = UnitMainCategories.SI;
                subMenuSI.Checked = true;
            }
            else if (sender.Equals(subMenuBS))
            {
                UnitManager.CurrentUnitCategory = UnitMainCategories.BS;
                subMenuBS.Checked = true;
            }
            else if (sender.Equals(subMenuMKS))
            {
                UnitManager.CurrentUnitCategory = UnitMainCategories.MKS;
                subMenuMKS.Checked = true;
            }
            SettingLoader.Current.SetMainUnit(UnitManager.CurrentUnitCategory.ToString());
            frmTestSetting.UpdateUnit();
            measureMonitors.ReloadUnits();
            LoadPlotUnitsMenuItems();
            plot.Fit();
        }

        #endregion


        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_DoTestTermination || testRunning)
            {
                e.Cancel = true;
            }
            else
            {
                measureMonitors.SaveMeasures();
                SettingLoader.Current.SetUnits(
                    UnitManager.CurrentUnitCategory.ToString(),
                    UnitManager.ForceUnit,
                    UnitManager.ExtensionUnit,
                    UnitManager.StressUnit,
                    UnitManager.StrainUnit,
                    UnitManager.TimeUnit,
                    UnitManager.MassStressUnit, UnitManager.LengthStressUnit,
                    UnitManager.TemperatureUnit);

                try
                { readThread.Abort(); }
                catch { }

                try { monitorUpdaterThread.Abort(); }
                catch { }
            }
        }


        private void OncurrentTestDefiniationChanged(object sender, EventArgs e)
        {
            var sampleChanged = false;
            var infoChanged = false;
            frmTestSetting.OnOperationDone -= OncurrentTestDefiniationChanged;
            if (frmTestSetting.DialogResult == DialogResult.OK)
            {
                sampleChanged = !plot.DataSource.DataSources[0].TestSample.Equals(frmTestSetting.Sample);
                plot.DataSource.DataSources[0].TestSample = frmTestSetting.Sample;
                infoChanged = !plot.DataSource.DataSources[0].TestInformation.Equals(frmTestSetting.TestInformation);
                plot.DataSource.DataSources[0].TestInformation = frmTestSetting.TestInformation;
                plot.DataSource.Invalid = true;

                var path = plot.DataSource.DataSources[0].FullPath;
                plot.DataSource.DataSources[0].XmlTestSetting = frmTestSetting.GetCurrentTestSetting();
                TestOpenSave.Current.SaveTest(UnitManager.CurrentUnitCategory, plot.DataSource.DataSources[0],
                       reportingDataSource.ReportingParameters.ToList(), Plot.XMeasureType, Plot.YMeasureType, path);
            }
            frmTestSetting.EditMode = false;

            // Nazarpour 1402/06/29
            if (infoChanged) ucSpec.ImportInfo(plot.DataSource.DataSources[0].TestInformation);

            if (!sampleChanged) return;
            plot.DataSource.Rebind();
            //var row = ucSpec.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[1].Value.ToString().TrimStart().Equals(plot.DataSource.DataSources[0].Name)).First().Index;
            //ucSpec.Rows[row].Cells[3].Value = string.Format("{0:f03}", plot.DataSource.DataSources[0].TestSample.Area);
            //ucSpec.Rows[row].Cells[4].Value = string.Format("{0:f03}", plot.DataSource.DataSources[0].TestSample.GagueLength);
            //ucSpec.Rows[row].Cells[5].Value = plot.DataSource.DataSources[0].TestInformation.Description.Aggregate("", (current, s) => current + s + " ");
            UpdateReportsDataSource();
            SetReportResultGridView();
            plot.Fit(true);
        }

        private void plot_OnPlotResize(object sender, EventArgs e)
        {
            plotPanel.Size = new Size(plot.Size.Width, plot.Size.Height + 80);
        }

        private void plot_OnPointClick(object sender, PointEventArgs e)
        {
            frmReporting.SetClickedPoint(e.X, e.XType);
            ShowReportingFrm();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (about == null)
                about = new AboutBox { Owner = this, StartPosition = FormStartPosition.CenterParent };
            about.Show();

        }

        private void onMenuShowReportPoints_Click(object sender, EventArgs e)
        {
            var chk = !ctxMenuShowReportPoints.Checked;
            ctxMenuShowReportPoints.Checked = chk;
            menuShowReportPoints.Checked = chk;
            plot.ShowReportPoints = ctxMenuShowReportPoints.Checked;
            plot.DataSource.Invalid = true;
            plot.Update();
        }

        private void onMenuShowReportLabels_Click(object sender, EventArgs e)
        {
            var chk = !ctxMenuShowReportLabels.Checked;
            ctxMenuShowReportLabels.Checked = chk;
            menuShowReportLabels.Checked = chk;
            plot.ShowReportLabels = ctxMenuShowReportLabels.Checked;
            plot.DataSource.Invalid = true;
            plot.Update();
        }

        private void onMenuShowReportLines_Click(object sender, EventArgs e)
        {
            var chk = !ctxMenuShowReportLines.Checked;
            ctxMenuShowReportLines.Checked = chk;
            menuShowReportPoints.Checked = chk;
            plot.ShowReportLines = ctxMenuShowReportLines.Checked;
            plot.DataSource.Invalid = true;
            plot.Update();
        }

        private void menuCreateGroup_Click(object sender, EventArgs e)
        {
            using (var inputDlg = new InputDialog())
            {
                inputDlg.Text = Resources.MainFrm_menuCreateGroup_Click_New_Group;
                inputDlg.Msg = Resources.MainFrm_menuCreateGroup_Click_Enter_Group_Name_;
                if (inputDlg.ShowDialog() == DialogResult.OK)
                {
                    var gName = inputDlg.UserInput;
                    testHistory.CreateGroup(gName, plot.DataSource.DataSources.Select(p => p.FullPath).ToArray());
                    LoadTestGroupHistoryMenu();
                }
            }
        }

        private void bttnStrainToExten_Click(object sender, EventArgs e)
        {
            test.SwitchStrainToExtension();
            bttnStrainToExten.Enabled = false;
            OnTestOnOnContinueTestS2E(sender, e);
        }

        private void menuOpenGroup_Click(object sender, EventArgs e)
        {
            var paths = testHistory.GetGroupTest(ctxCbRecentGroups.Text);
            OpenTests(paths);
        }

        private void menuDeleteGroup_Click(object sender, EventArgs e)
        {
            testHistory.DeleteGroup(ctxCbRecentGroups.Text);
            LoadTestGroupHistoryMenu();
        }

        private void menuExportAsExcel_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Excel|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var selected = dgvReportingResults.Rows[dgvTestsCurrentRow].Cells[string.Format("col{0}", -1)].Value.ToString().Trim();
                        if (!currentTests.Contains(selected)) return;
                        var dataSource = plot.DataSource.DataSources.First(p => p.Name == selected);
                        var xlxReport = new ExcelReport();
                        xlxReport.Save(dataSource, 
                            saveFileDialog.FileName, 
                            dataSource.TestSample.ToReport(),
                            dataSource.TestInformation.ToReport(),
                            dataSource.GetTestSettingsToReport(), 
                            Plot.XMeasureText, Plot.XUnitText,
                            Plot.YMeasureText, Plot.YUnitText, 
                            Plot.XM, Plot.YM);
                    }
                    catch
                    {
                    }
                }
            }
        }


        private void UpdateUnit(object sender, UnitChangeEventArgs e)
        {
            UpdateUnit(e.measureType, e.Unit);
        }



        #region testList

        private bool dgvTestsCtrl;
        private List<string> currentTests;
        private bool gridDraw;


        private void dgvReportingResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !testRunning)
            {
                if (dgvReportingResults.RowCount > 0)
                    ctxMenuTestProperties.Show(dgvReportingResults, e.Location);
            }
        }

        private void CloseTest(string name)
        {

            var rows = dgvReportingResults.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[1].Value != null && p.Cells[1].Value.ToString().TrimStart().Equals(name)).Select(p => p.Index).ToList();
            currentTests.Remove(name);
            plot.RemoveDataSource(name);
            foreach (var i in rows)
            {
                dgvReportingResults.Rows.RemoveAt(i);
            }
            if (plot.DataSource.DataSources.Count == 0)
                InitiateZeroDs();
            foreach (var item in menuRecentTests.DropDownItems.OfType<ToolStripMenuItem>())
            {
                var tName = item.Text.Split('\\').Last();
                if (tName == name)
                {
                    item.Checked = false;
                    break;
                }
            }

            //UpdateReportsDataSource();  aaaa
            SetReportResultGridView();
            plot.Fit(true);
        }

        private void CloseAll()
        {
            foreach (ToolStripMenuItem item in menuRecentTests.DropDownItems)
                item.Checked = false;
            CheckModification();
            InitiateZeroDs();
        }

        private void InitiateZeroDs()
        {
            plot.ResetPlotLables();
            plot.Initilize();
            currentTests.Clear();
            reportingDataSource.Clear();
            dgvReportingResults.Rows.Clear();
            TestOpenSave.Current.ClearLastTests = true;
        }

        private void RefreshDgvTests()
        {
            reportingDataSource.Clear();

            var addedSorces = plot.DataSource.DataSources.Select(q => q.TestName).ToList();

            foreach (var currentTest in currentTests.Where(p => !addedSorces.Contains(p)))
            {
                List<ReportingParameters> curTestReportingParameters;
                var dataSource = TestOpenSave.Current.Read(currentTest.TrimStart(), out curTestReportingParameters);
                if (dataSource == null) continue;
                plot.AddDataSource(dataSource);
                foreach (var parameter in curTestReportingParameters)
                {
                    reportingDataSource.AddReportingParameters(parameter);
                }
            }
            //    LoadPlotUnitsMenuItems();


            string xSelected;
            string ySelected;
            string y2Selected;
            MeasureTool.Units(Plot.XMeasureType, out xSelected);
            MeasureTool.Units(Plot.YMeasureType, out ySelected);
            MeasureTool.Units(Plot.Y2MeasureType, out y2Selected);

            UpdateUnit(Plot.Y2MeasureType, y2Selected, false);

            UpdateUnit(Plot.XMeasureType, xSelected, false);
            UpdateUnit(Plot.YMeasureType, ySelected, true);

            plot.Fit(true);

        }

        #endregion



        #region plot context menu

        //add
        private void SetDiagramType(object sender, EventArgs e)
        {
            ToolStripMenuItem last = null;
            foreach (ToolStripItem item in ctxMenuDiagramType.DropDownItems)            
                if (item is ToolStripMenuItem tsi)
                {
                    if (tsi.Checked)
                        last = tsi;
                    tsi.Checked = false;
                }            

            if (sender.Equals(ctxMenuExtensionTime))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.Extension;
            }
            else if (sender.Equals(ctxMenuForceExtension))
            {
                Plot.XMeasureType = MeasureType.Extension;
                Plot.YMeasureType = MeasureType.Force;
            }
            else if (sender.Equals(ctxMenuForceTime))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.Force;
            }
            else if (sender.Equals(ctxMenuStressStrain))
            {
                Plot.XMeasureType = MeasureType.Strain;
                Plot.YMeasureType = MeasureType.Stress;
            }
            else if (sender.Equals(ctxMenuStressTime))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.Stress;
            }
            else if (sender.Equals(ctxMenuStrainTime))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.Strain;
            }

            else if (sender.Equals(relaxLost))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.RelaxLoss;
            }
            else if (sender.Equals(forceLost))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.ForceLoss;
            }
            else if (sender.Equals(stressLost))
            {
                Plot.XMeasureType = MeasureType.Time;
                Plot.YMeasureType = MeasureType.StressLoss;
            }

            else if (sender.Equals(massStressStarinToolStripMenuItem))
            {
                if (plot.DataSource.DataSources.Count > 0)
                    if (plot.DataSource.DataSources[0].TestSample.TensionCompressionSampleType ==
                        TensionCompressionSampleType.Denier || plot.DataSource.DataSources[0].TestSample.TensionCompressionSampleType == TensionCompressionSampleType.Tex)
                    {
                        Plot.XMeasureType = MeasureType.Strain;
                        Plot.YMeasureType = MeasureType.MassStress;
                    }
                    else
                    {
                        ((ToolStripMenuItem)sender).Checked = false;
                        if (last != null) last.Checked = true;
                    }


            }
            else if (sender.Equals(lengthStressStarinToolStripMenuItem))
            {
                if (plot.DataSource.DataSources.Count > 0)
                    if (plot.DataSource.DataSources[0].TestSample.TensionCompressionSampleType ==
                        TensionCompressionSampleType.Tear)
                    {
                        Plot.XMeasureType = MeasureType.Strain;
                        Plot.YMeasureType = MeasureType.LengthStress;
                    }
                    else
                    {
                        ((ToolStripMenuItem)sender).Checked = false;
                        if (last != null) last.Checked = true;
                    }
            }
            Plot.XMeasureText = MeasureTool.GetMeasureName(Plot.XMeasureType).ToUpper();
            Plot.YMeasureText = MeasureTool.GetMeasureName(Plot.YMeasureType).ToUpper();
            Plot.Y2MeasureText = MeasureTool.GetMeasureName(Plot.Y2MeasureType).ToUpper();

            plot.DataSource.Rebind();
            plot.Fit(true);
            LoadPlotUnitsMenuItems(updateReport: false);

        }

        private void ctxMenuUpdate_Click(object sender, EventArgs e)
        {

            var mtype = MeasureTool.GetMeasureType(ctxMenuXType.Text);
            mtype = MeasureTool.IsExtension(mtype) ? MeasureType.Extension : mtype;
            Plot.XMeasureType = mtype;

            mtype = MeasureTool.GetMeasureType(ctxMenuYType.Text);
            mtype = MeasureTool.IsExtension(mtype) ? MeasureType.Extension : mtype;
            Plot.YMeasureType = mtype;

            Plot.XMeasureText = MeasureTool.MeasurAbbreviations[Plot.XMeasureType.ToString()].ToUpper();
            Plot.YMeasureText = MeasureTool.MeasurAbbreviations[Plot.YMeasureType.ToString()].ToUpper();
            Plot.Y2MeasureText = MeasureTool.MeasurAbbreviations[Plot.Y2MeasureType.ToString()].ToUpper();

            plot.DataSource.Rebind();
            try
            {
                plot.Fit(true);
                LoadPlotUnitsMenuItems();

            }
            catch (Exception exception)
            {
                exception.ToString();
            }

            foreach (ToolStripItem item in ctxMenuDiagramType.DropDownItems)
                if (item is ToolStripMenuItem tsi)
                    tsi.Checked = false;
        }


        //add
        private void subMenuFixedScale_Click(object sender, EventArgs e)
        {
            using (var frmFixedScale = new FrmFixedScale())
            {
                var zl = plot.DataSource.GetCurZoomLevel();
                zl.XM = Plot.XM;
                zl.YM = Plot.YM;

                frmFixedScale.SetFields(zl, Plot.XUnitText, Plot.YUnitText, PlotDataSource.XGridsCount, PlotDataSource.YGridsCount);
                frmFixedScale.ShowDialog();
                frmFixedScale.BringToFront();
                if (frmFixedScale.DialogResult != DialogResult.OK) return;

                ZoomFrame newZoom = frmFixedScale.GetDiagramSetting();
                plot.SetFixedScale(newZoom);
            }
        }

        private void menuXpxOffset_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem menuItem in ctxMenuXOffset.DropDownItems)
            {
                menuItem.Checked = false;
            }
            var menu = (ToolStripMenuItem)sender;
            menu.Checked = true;
            plot.XOffset = ctxXOffset.Checked;
            plot.DataSource.Invalid = true;
            plot.Update();
        }

        private void subMenuTestReportPoints_Click(object sender, EventArgs e)
        {
            frmReporting.ReportingParameters = reportingDataSource.ReportingParameters;
            ShowReportingFrm();
        }

        #endregion

        private void dgvReportingResults_Sorted(object sender, EventArgs e)
        {
            int i;
            var order = new Dictionary<string, int> { { "", -1 }, { "Acc From", 0 }, { "Acc To", 1 }, { "Avg.", 2 }, { "RMS", 3 }, { "Delta", 4 } };
            var rows = dgvReportingResults.Rows.Cast<DataGridViewRow>().Where(p => !int.TryParse(p.Cells[0].Value.ToString(), out i)).ToList();
            rows = rows.OrderBy(p => order[p.Cells[0].Value.ToString()]).ToList();
            foreach (var row in rows)
            {
                dgvReportingResults.Rows.Remove(row);
                dgvReportingResults.Rows.Add(row);
            }
        }

        private void subMenuMeasures_Click(object sender, EventArgs e)
        {
            frmUnitSetting.Show();
        }

        private void OnfrmUnitDialogresult(object sender, EventArgs e)
        {
            if (frmUnitSetting.DialogResult != DialogResult.OK) return;

            if (frmUnitSetting.UnitSystemChanged)
            {
                subMenuSI.Checked = UnitManager.CurrentUnitCategory == UnitMainCategories.SI;
                subMenuBS.Checked = UnitManager.CurrentUnitCategory == UnitMainCategories.BS;
                subMenuMKS.Checked = UnitManager.CurrentUnitCategory == UnitMainCategories.MKS;
                SettingLoader.Current.SetMainUnit(UnitManager.CurrentUnitCategory.ToString());
                LoadPlotUnitsMenuItems();
                plot.Fit();
            }
            else
            {
                if (frmUnitSetting.ForceUnitChanged)
                    UpdateUnit(MeasureType.Force, UnitManager.ForceUnit);
                if (frmUnitSetting.ExtensionUnitChanged)
                    UpdateUnit(MeasureType.Extension, UnitManager.ExtensionUnit);
                if (frmUnitSetting.StressUnitChanged)
                    UpdateUnit(MeasureType.Stress, UnitManager.StressUnit);
                if (frmUnitSetting.StrainUnitChanged)
                    UpdateUnit(MeasureType.Strain, UnitManager.StrainUnit);
                if (frmUnitSetting.TimeUnitChanged)
                    UpdateUnit(MeasureType.Time, UnitManager.TimeUnit);
                if (frmUnitSetting.SpecificStressUnitChanged)
                    UpdateUnit(MeasureType.MassStress, UnitManager.MassStressUnit);
                if (frmUnitSetting.LengthStressUnitChanged)
                    UpdateUnit(MeasureType.LengthStress, UnitManager.LengthStressUnit);
            }
            frmTestSetting.UpdateUnit();
            measureMonitors.ReloadUnits();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void measureMonitors_OnUnitSystems(object sender, EventArgs e)
        {
            subMenuMeasures_Click(sender, e);
        }

        private void ctxMenuDiagram_Opened(object sender, EventArgs e)
        {
            ctxXOffset.Checked = plot.XOffset;
            ctxNoXOffset.Checked = !ctxXOffset.Checked;
            ctxNoXOffset.Text = string.Format("0 {0}", Plot.XUnitText);
            ctxXOffset.Text = string.Format("{0} {1}", plot.DataSource.XStep, Plot.XUnitText);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_DoTestTermination || testRunning)
            {
                e.Cancel = true;
            }
            else
            {
                measureMonitors.SaveMeasures();
                SettingLoader.Current.SetUnits(
                    UnitManager.CurrentUnitCategory.ToString(),
                    UnitManager.ForceUnit,
                    UnitManager.ExtensionUnit,
                    UnitManager.StressUnit,
                    UnitManager.StrainUnit,
                    UnitManager.TimeUnit, UnitManager.MassStressUnit, UnitManager.LengthStressUnit,
                    UnitManager.TemperatureUnit);

                try
                { readThread.Abort(); }
                catch { }

                try { monitorUpdaterThread.Abort(); }
                catch { }

                Environment.Exit(0);
            }
        }

        private void bttnStartTest_MouseHover(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            if (bttnTip == null)
                bttnTip = new ToolTip();
            bttnTip.Show((string)button.Tag, button, 1000);
        }

        private void dgvReportingResults_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvTestsCurrentRow = e.RowIndex;

        }

        private void closeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected = dgvReportingResults.Rows[dgvTestsCurrentRow].Cells[string.Format("col{0}", -1)].Value.ToString().TrimStart();
            if (!currentTests.Contains(selected)) return;
            CloseTest(selected);
        }

        private void ucSpec_Load(object sender, EventArgs e)
        {

        }

        private void dgvReportingResults_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportingResults.SelectedRows.Count == 1)
                {
                    var selected =
                        dgvReportingResults.SelectedRows.Cast<DataGridViewRow>()
                            .Select(p => p.Cells[1].Value.ToString().TrimStart())
                            .ToList()
                            .First();
                    var ds = plot.DataSource.DataSources.First(p => p.Name == selected);
                    var xmlSetting = ds.XmlTestSetting;
                    var xmlDoc = XDocument.Parse(xmlSetting);
                    var method = xmlDoc.Descendants("root").Descendants("GetTestParameters").First();
                    ucSpec.ImportMethod(method);
                    var sample = xmlDoc.Descendants("root").Descendants("Sample").First();
                    ucSpec.ImportSpecimen(sample);
                    ucSpec.ImportInfo(ds.TestInformation);
                    ucSpec.SetTestName(selected);

                    if (ds.TestMethodType == TestMethodType.Relaxation)
                    {
                        var step = ds.Samples.Last().StepOrCycle;
                        var first = ds.Samples.FirstOrDefault(p => p.StepOrCycle == step);
                        if (first == null)
                            ucSpec.SetRelaxParams(Resources.n_a, Resources.n_a, Resources.n_a);
                        else
                        {
                            var t = first.Time;
                            if (t - ucSpec.StablizTime > 0)
                            {
                                var funit = UnitManager.GetUnit(MeasureType.Force);
                                var eunit = UnitManager.GetUnit(MeasureType.Extension);
                                ucSpec.SetRelaxParams(
                                    string.Format("{0}({1})",
                                        UnitManager.ConvertToCurrent(t - ucSpec.StablizTime, "min").ToString("0.##"),
                                        "min"),
                                    string.Format("{0}({1})",
                                        UnitManager.ConvertToCurrent(first.Force, funit).ToString("0.##"), funit),
                                    string.Format("{0}({1})",
                                        UnitManager.ConvertToCurrent(first.Extension, eunit).ToString("0.##"), eunit));
                            }
                        }
                    }
                    if (ds.TestMethodType == TestMethodType.Creep)
                    {
                        var step = ds.Samples.Last().StepOrCycle;
                        var first = ds.Samples.FirstOrDefault(p => p.StepOrCycle == step);
                        if (first == null)
                            ucSpec.SetCreepParams(Resources.MassStress_UnitSet_n_a, Resources.MassStress_UnitSet_n_a);
                        else
                        {
                            var t = first.Time;
                            if (t - ucSpec.StablizTime > 0)
                            {
                                var eunit = UnitManager.GetUnit(MeasureType.Extension);
                                ucSpec.SetCreepParams(
                                    string.Format("{0}({1})",
                                        UnitManager.ConvertToCurrent(t - ucSpec.StablizTime, "min").ToString("0.##"),
                                        "min"),
                                    string.Format("{0}({1})",
                                        UnitManager.ConvertToCurrent(first.Extension, eunit).ToString("0.##"), eunit));
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void ctxMenuCurrentTest_Click(object sender, EventArgs e)
        {
            if (dgvTestsCurrentRow == -1 && dgvReportingResults.SelectedRows.Count > 0)
                dgvTestsCurrentRow = dgvReportingResults.SelectedRows[0].Index;
            if (dgvTestsCurrentRow == -1)
                return;
            var selected = dgvReportingResults.Rows[dgvTestsCurrentRow].Cells[string.Format("col{0}", -1)].Value.ToString().TrimStart();
            if (selected.Equals("---")) return;
            frmTestSetting.EditMode = true;
            frmTestSetting.TestInformation = plot.DataSource.DataSources.First(p => p.Name == selected).TestInformation;
            frmTestSetting.OnOperationDone += OncurrentTestDefiniationChanged;
            frmTestSetting.TopMost = true;
            frmTestSetting.Show();
        }

        private bool m_bLayoutCalled = false;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);
        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        private void temperatureControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.FullCreepAvailable)
            {
                var frm = new TemperatureMoreControlForm();
                frm.Show(this);
            }
            else
            {
                temperatureControlToolStripMenuItem.Enabled = false;
            }
        }

        private void testTimeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new TestTimeReport();
            frm.Show(this);
        }

        private void specTempUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.SpecTempUP;
            plot.Fit(true);
        }

        private void specTempCNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.SpecTempCNT;
            plot.Fit(true);

        }

        private void specTempDNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.SpecTempDN;
            plot.Fit(true);
        }

        private void ambientTempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.AmbientTemp;
            plot.Fit(true);
        }

        private void nrTemperatureRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                plot.DataSource.RebindY2(nrMinTemperature.ValueInInt, nrMaxTemperature.ValueInInt);
                plot.Fit(true);
            }
        }

        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.Temperature;
            plot.Fit(true);
        }

        private void zoneTempUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.ZoneTempUP;
            plot.Fit(true);
        }

        private void zoneTempCNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.ZoneTempCNT;
            plot.Fit(true);
        }

        private void zoneTempDNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot.Y2MeasureType = MeasureType.ZoneTempDN;
            plot.Fit(true);
        }

        public void BringMainWindowToFront(string processName)
        {
            // get the process
            Process bProcess = Process.GetProcessesByName(processName).FirstOrDefault();

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Restore);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
            else
            {
                // the process is not running, so start it
                Process.Start(processName);
            }
        }
    }
}
