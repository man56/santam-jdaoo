using System;

namespace STM.BLayer.StmTest
{
    static class TestInitializer
    {
        public static double TimeQuantom { set; get; }

        public static Test CreateTest(TestParameters testProperties, TestingSample sample, TestInformation testInformation, string testName = "")
        {
            Test.StrainToExtenMode = 0;
            Test.StrainToExtenSetPoint = 0;
            var retVal = new Test(sample, testInformation, testName);
            var type = testProperties.GetType();
            Test.ExtenCurPosition = testProperties.ExtenCurrentPosition;
          
            if (type == typeof(TensileTestParameters))
                InitilizeTensileTest(testProperties as TensileTestParameters, retVal);
            else
            {
                Test.StrainToExtenEnabled = false;
                if (type == typeof(CompressiveTestParameters))
                    InitilizeCompresiveTest(testProperties as CompressiveTestParameters, retVal);

                else if (type == typeof(CreepTestParameters))
                {
                    InitilizeCreepTest(testProperties as CreepTestParameters, retVal);
                    retVal.IsLongRunning = true;
                }
                else if (type == typeof(RelaxationTestParameters))
                {
                    InitilizeRelaxationTest(testProperties as RelaxationTestParameters, retVal);
                    retVal.IsLongRunning = true;
                }
                else if (type == typeof(CyclicTestParameters))
                    InitilizeCyclicTest(testProperties as CyclicTestParameters, retVal);

                else if (type == typeof(StepTestParameters))
                    InitilizeStepTest(testProperties as StepTestParameters, retVal);
            }
        
            return retVal;
        }

        private static void InitilizeTensileTest(TensileTestParameters testProerties, Test test)
        {
            var stNo = 0;
            Test.TestMethodType = TestMethodType.Tensile;

            Test.StrainToExtenMode = testProerties.StrainToExtenMode;
            Test.StrainToExtenSetPoint = testProerties.StrainToExtenSetPoint;

            if (testProerties.PreLoadEnabled)
            {
                var preLoadStage = new TestStage
                                       {
                                           SetPointType = testProerties.PreLoadSetPointType,
                                           SetPoint = testProerties.PreLoadSetPoint,
                                           StageNo = ++stNo,
                                           PlotStageData = false,
                                           StageDescription = @"Preload",
                                           StepOrCycle = -1,
                                       };
                test.AddStage(preLoadStage);

                var keep = new TestStage
                               {
                                   SetPointType = testProerties.PreLoadSetPointType,
                                   SetPoint = testProerties.PreLoadSetPoint,
                                   KeepTime = testProerties.PreLoadWaiting,
                                   PlotStageData = false,
                                   Zerocode = testProerties.ZeroingCode,
                                   StageNo = ++stNo,
                                   StageDescription = @"Preload waiting time",
                                   StepOrCycle = -1
                               };
                if (testProerties.PreLoadWaiting > 0)
                    test.AddStage(keep);
            }

            int cycleStep = 1;
            if (testProerties.SecondSpeedEnabled)
            {
                var preSecSpeedStage = new TestStage
                {
                    SetPointType = testProerties.SecondSpeedSetPointType,
                    SetPoint = testProerties.SecondSpeedSetPoint,
                    RateControlMode = TestControlMode.Extension,
                    RateControlStep = testProerties.Rate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                    Rate = testProerties.Rate,
                    StageNo = ++stNo,
                    PlotStageData = true,
                    PassSetPoint = true,
                    StageDescription = @"First speed tension",
                    StepOrCycle = cycleStep,
                    IsSafeStage = true,
                    StepOverOnHotKey = System.Windows.Forms.Keys.F5
                };
                test.AddStage(preSecSpeedStage);

                var pastSecSpeedStage = new TestStage
                                                  {
                                                      RateControlStep = testProerties.SecondRate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                                                      Rate = testProerties.SecondRate,
                                                      RateControlMode = TestControlMode.Extension,
                                                      StageNo = ++stNo,
                                                      PlotStageData = true,
                                                      StageDescription = @"Second speed tension",
                                                      StepOrCycle = ++cycleStep
                };
                test.AddStage(pastSecSpeedStage);
            }
            else
            {
                var testStage = new TestStage
                                          {
                                              RateControlMode = TestControlMode.Extension,
                                              Rate = testProerties.Rate,
                                              RateControlStep = testProerties.Rate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                                              StageNo = ++stNo,
                                              PlotStageData = true,
                                              PassSetPoint = true,
                                              StageDescription = @"First speed tension",
                                              StepOrCycle = cycleStep
                };
                test.AddStage(testStage);
            }

        }

        private static void InitilizeCompresiveTest(CompressiveTestParameters compressiveTestProperties, Test test)
        {
            Test.TestMethodType = TestMethodType.Compressive;
            var testStage = new TestStage
            {
                RateControlMode = TestControlMode.Extension,
                Rate = compressiveTestProperties.Speed,
                StageNo = 1,
                PlotStageData = true,
                PassSetPoint = true,
                StageDescription = @"Compression",
                StepOrCycle = 1
            };
            test.AddStage(testStage);
        }


        private static string TimeFormat(double seconds)
        {
            var h = (int)(seconds / 3600);
            var m = (int)((seconds % 3600) / 60);
            var s = (int)(seconds % 60);
            return string.Format("{1:00}:{2:00}:{3:00}", seconds, h, m, s);
        }

        private static bool ValueIsNotZero(double value)
        {
            return value < -double.Epsilon || double.Epsilon < value;
        }

        private static void InitilizeCreepTest(CreepTestParameters creepTestProperties, Test test)
        {
            Test.TestMethodType = TestMethodType.Creep;
            var st = 0;
            var step = 0;
            // Nazarpour 980321      
            if (creepTestProperties.TemperatureSetPoint > 0)
            {
                test.AddStage(new TestStage
                {
                    SetPointType = TestControlMode.None,
                    TemperatuerControlMode = TemperatuerControlMode.Set,
                    TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                    TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                    StageNo = ++st,
                    PlotStageData = false,
                    StageDescription = $"Set Temperature {creepTestProperties.TemperatureSetPoint}(+{creepTestProperties.TemperatureSetPointOffset})°C",
                    StepOrCycle = -1,
                });
            }
            // Nazarpour
            if (ValueIsNotZero(creepTestProperties.PreLoadValue))
            {
                test.AddStage(new TestStage
                {
                    SetPointType = (TestControlMode)creepTestProperties.PreLoadType,
                    SetPoint = creepTestProperties.PreLoadValue,
                    RateControlMode = creepTestProperties.PreSetPointRateType,
                    Rate = creepTestProperties.PreSetPointRate,
                    RateControlStep = creepTestProperties.PreSetPointRate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                    TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                    TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                    StageNo = ++st,
                    PlotStageData = false,
                    StageDescription = $"PreLoad {creepTestProperties.PreLoadValue}",
                    StepOrCycle = -1,
                });

                if (ValueIsNotZero(creepTestProperties.PreLoadTime))
                    test.AddStage(new TestStage
                    {
                        SetPointType = (TestControlMode)creepTestProperties.PreLoadType,
                        SetPoint = creepTestProperties.PreLoadValue,
                        KeepTime = creepTestProperties.PreLoadTime,
                        TemperatuerControlMode = TemperatuerControlMode.WaitHigher, // 14020918
                        TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                        TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                        PlotStageData = false,
                        StageNo = ++st,
                        StageDescription = $"PreWait {TimeFormat(creepTestProperties.PreLoadTime)}",
                        StepOrCycle = -1,
                    });
            }
            // Nazarpour
            if (ValueIsNotZero(creepTestProperties.TemperatureSetPoint))
            {
                test.AddStage(new TestStage
                {
                    // Nazarpour 1400/08/05
                    SetPointType = /*TestControlMode.None, /*/ ValueIsNotZero(creepTestProperties.PreLoadValue) ? (TestControlMode)creepTestProperties.PreLoadType : TestControlMode.None,
                    SetPoint = creepTestProperties.PreLoadValue,
                    StageNo = ++st,
                    PlotStageData = false,
                    TemperatuerControlMode = TemperatuerControlMode.WaitHigher,
                    TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                    TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                    StageDescription = $"Wait Temperature {creepTestProperties.TemperatureSetPoint}°C",
                    StepOrCycle = -1,
                });
                if (creepTestProperties.PreHeatTime > 0)
                    test.AddStage(new TestStage
                    {
                        // Nazarpour 1400/08/05
                        SetPointType = /*TestControlMode.None, /*/ValueIsNotZero(creepTestProperties.PreLoadValue) ? (TestControlMode)creepTestProperties.PreLoadType : TestControlMode.None,
                        SetPoint = creepTestProperties.PreLoadValue,
                        StageNo = ++st,
                        PlotStageData = false,
                        TemperatuerControlMode = TemperatuerControlMode.Keep,
                        TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                        TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                        KeepTime = creepTestProperties.PreHeatTime,
                        StageDescription = $"PreHeat {TimeFormat(creepTestProperties.PreHeatTime)}",
                        StepOrCycle = -1,
                    });
            }

            var preSetPointStage = new TestStage
            {
                SetPointType = (TestControlMode)creepTestProperties.SetPointType,
                SetPoint = creepTestProperties.SetPointValue,
                RateControlMode = creepTestProperties.PreSetPointRateType,
                Rate = creepTestProperties.PreSetPointRate,
                RateControlStep = creepTestProperties.PreSetPointRate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                PlotStageData = creepTestProperties.PlotAllStages,
                StageNo = ++st,
                StageDescription = @"",
                StepOrCycle = creepTestProperties.PlotAllStages ? ++step : -1,
                TemperatuerControlMode = TemperatuerControlMode.Keep,
                TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                ResetExtensotemer = creepTestProperties.ResetExtension,
                ResetTestTime = true
            };
            test.AddStage(preSetPointStage);

            var controlMode = (TestControlMode)creepTestProperties.SetPointType;

            if (creepTestProperties.StabilizingTime > 0)
            {
                var stablizingStage = new TestStage
                {
                    SetPointType = controlMode,
                    SetPoint = creepTestProperties.SetPointValue,
                    KeepTime = creepTestProperties.StabilizingTime,
                    PlotStageData = creepTestProperties.PlotAllStages,
                    StageNo = ++st,
                    StageDescription = @"Stablizing",
                    StepOrCycle = creepTestProperties.PlotAllStages ? ++step : -1,
                    TemperatuerControlMode = TemperatuerControlMode.Keep,
                    TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                    TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                };
                test.AddStage(stablizingStage);
            }

            if (creepTestProperties.TestDuration > 0)
            {
                var limitControlStage = new TestStage
                {
                    SetPointType = controlMode,
                    SetPoint = creepTestProperties.SetPointValue,
                    KeepTime = creepTestProperties.TestDuration,
                    PlotStageData = true,
                    StageNo = ++st,
                    StageDescription = string.Format("{0} control", controlMode),
                    StepOrCycle = creepTestProperties.PlotAllStages ? ++step : -1,
                    Decimation = creepTestProperties.Decimation,
                    TemperatuerControlMode = TemperatuerControlMode.Keep,
                    TemperatureSetPoint = creepTestProperties.TemperatureSetPoint,
                    TemperatureSetPointOffset = creepTestProperties.TemperatureSetPointOffset,
                    LimitedModificationInTest = true,
                };
                test.AddStage(limitControlStage);
            }

            var rate = 60.0 * Math.Abs(creepTestProperties.SetPointValue) / 10; //* => 10(sec) */
            // Nazarpour 1399/11/14
            test.AddStage(new TestStage
            {
                SetPointType = controlMode,
                RateControlMode = controlMode,
                Rate = rate,
                RateControlStep = rate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                SetPoint = 0,
                KeepTime = 0,
                TemperatuerControlMode = TemperatuerControlMode.Set,
                TemperatureSetPoint = 0,
                TemperatureSetPointOffset = 0,
                StageNo = ++st,
                PlotStageData = false,
                StageDescription = $"Turn the furnace OFF.",
                StepOrCycle = -1,
                IsSafeStage = true,
            });
            var cooldownState = new TestStage
            {
                SetPointType = controlMode,
                SetPoint = 0,
                KeepTime = 24 * 60 * 60, // 24 hours for cooldown
                RateControlMode = controlMode,
                Rate = rate,
                RateControlStep = rate / (TimeQuantom == 0 ? 1 : 60000.0 / TimeQuantom),
                PlotStageData = false,
                StageNo = ++st,
                StageDescription = string.Format("cooldown, control force at ZERO wait temperature below 50°C"),
                StepOrCycle = -1,
                Decimation = creepTestProperties.Decimation,
                TemperatuerControlMode = TemperatuerControlMode.WaitLower,
                TemperatureSetPoint = 50,
                TemperatureSetPointOffset = 0,
                IsSafeStage = true,
            };
            test.AddStage(cooldownState);
        }

        private static void InitilizeRelaxationTest(RelaxationTestParameters relaxTestProperties, Test test)
        {
            var st = 0;
            var step = 0;
            Test.TestMethodType = TestMethodType.Relaxation;
            var preSetPointStage = new TestStage
                                       {
                                           SetPointType = (TestControlMode) relaxTestProperties.SetPointType,
                                           SetPoint = relaxTestProperties.SetPointValue,

                                           RateControlMode = relaxTestProperties.PreSetPointRateType,
                                           Rate = relaxTestProperties.PreSetPointRate,
                                           RateControlStep = relaxTestProperties.PreSetPointRate/ (Math.Abs(TimeQuantom) < float.Epsilon ? 1 : 60000.0/TimeQuantom),
                                           PlotStageData = relaxTestProperties.PlotAllStages,
                                           StageNo = ++st,
                                           StageDescription = @"",
                                           StepOrCycle = relaxTestProperties.PlotAllStages ? ++step : -1
                                       };
            test.AddStage(preSetPointStage);

            var controlMode = (TestControlMode)relaxTestProperties.SetPointType;
            if (relaxTestProperties.StabilizingTime > 0)
            {
                var stablizingStage = new TestStage
                {
                    SetPointType = controlMode,
                    SetPoint = relaxTestProperties.SetPointValue,
                    KeepTime = relaxTestProperties.StabilizingTime,
                    PlotStageData = relaxTestProperties.PlotAllStages,
                    StageNo = ++st,
                    StageDescription = @"Stablizing",
                    StepOrCycle = relaxTestProperties.PlotAllStages ? ++step : -1
                };
                test.AddStage(stablizingStage);
            }
            if (relaxTestProperties.TestDuration <= 0) return;
            var limitControlStage = new TestStage
                                        {
                                            SetPointType = controlMode,
                                            SetPoint = relaxTestProperties.SetPointValue,
                                            KeepTime = relaxTestProperties.TestDuration,
                                            PlotStageData = true,
                                            StageNo = ++st,
                                            StageDescription = string.Format("{0} control", controlMode),
                                            StepOrCycle = relaxTestProperties.PlotAllStages ? ++step : -1,
                                            Decimation = relaxTestProperties.Decimation
                                        };
            test.AddStage(limitControlStage);
        }

        private static void InitilizeCyclicTest(CyclicTestParameters cyclicTestProperties, Test test)
        {
            var st = 0;
            Test.TestMethodType = TestMethodType.Cyclic;
            for (var cycle = 0; cycle < cyclicTestProperties.CycleCount; cycle++)
            {
                var upStage = new TestStage
                {
                    RateControlMode = cyclicTestProperties.RateControlType,
                    Rate = cyclicTestProperties.CyclicRate,
                    RateControlStep = cyclicTestProperties.CyclicRate/(TimeQuantom == 0 ? 1 : 60000.0/TimeQuantom),
                    SetPointType = cyclicTestProperties.SetPointType,
                    SetPoint = cyclicTestProperties.Limit1,
                    PlotStageData = true,
                    StageNo = ++st,
                    StepOrCycle = st,
                    StageDescription = @"Go sub cycle",
                };
                test.AddStage(upStage);

                if (cyclicTestProperties.KeepTime > 0)
                {
                    var sleepStage = new TestStage
                    {
                        StageNo = ++st,
                        StepOrCycle = st,
                        KeepTime = cyclicTestProperties.KeepTime,
                        SetPointType = cyclicTestProperties.SetPointType,
                        SetPoint = cyclicTestProperties.Limit1,
                        StageDescription = string.Format("{0} control", cyclicTestProperties.SetPointType),
                    };
                    test.AddStage(sleepStage);
                }

                var downStage = new TestStage
                {
                    RateControlMode = cyclicTestProperties.RateControlType,
                    Rate = cyclicTestProperties.CyclicRate,
                    RateControlStep = cyclicTestProperties.CyclicRate/(TimeQuantom == 0 ? 1 : 60000.0/TimeQuantom),
                    SetPointType = cyclicTestProperties.SetPointType,
                    SetPoint = cyclicTestProperties.Limit2,
                    PlotStageData = true,
                    StageNo = ++st,
                    StepOrCycle = st,

                    StageDescription = @"Back sub cycle",
                };
                test.AddStage(downStage);

                if (cyclicTestProperties.KeepTime > 0)
                {
                    var sleepStage = new TestStage
                    {
                        StageNo = ++st,
                        KeepTime = cyclicTestProperties.KeepTime,
                        SetPointType = cyclicTestProperties.SetPointType,
                        SetPoint = cyclicTestProperties.Limit2,
                        StageDescription = string.Format("{0} control", cyclicTestProperties.SetPointType),
                        StepOrCycle = st
                    };
                    test.AddStage(sleepStage);
                }
            }
        }

        private static void InitilizeStepTest(StepTestParameters stepTestProperties, Test test)
        {
            var st = 0;
            Test.TestMethodType = TestMethodType.Step;
            for (var step = 0; step < stepTestProperties.SetPoints.Count; step++)
            {
                var preSetPointStage = new TestStage
                {
                    SetPointType = stepTestProperties.SetPointTypes[step],
                    SetPoint = stepTestProperties.SetPoints[step],
                    RateControlMode = stepTestProperties.RateControlTypes[step],
                    PassSetPoint = stepTestProperties.SetPointActions[step] == SetPointAction.None,
                    Rate = stepTestProperties.Rates[step],
                    RateControlStep = stepTestProperties.Rates[step]/(TimeQuantom == 0 ? 1 : 60000.0/TimeQuantom),
                    StartForceOffset = stepTestProperties.SetForce[step],
                    StartExtenOffset = stepTestProperties.SetExtension[step],
                    StageNo = ++st,
                    PlotStageData = true,
                    StepOrCycle = step,
                    StageDescription = @"",
                };
                test.AddStage(preSetPointStage);
                
                if(stepTestProperties.SetPointActions[step]== SetPointAction.Stop)
                    if (stepTestProperties.StepDurationTimes[step] > 0)
                    {
                        var sleepStage = new TestStage
                        {
                            StopTime = stepTestProperties.StepDurationTimes[step],
                            PlotStageData = true,
                            StageNo = ++st,
                            StepOrCycle = step,
                            StageDescription = @"Stop",
                        };
                        test.AddStage(sleepStage);

                    }
                if (stepTestProperties.SetPointActions[step] == SetPointAction.Keep)
                {
                    var ctrlStage = new TestStage
                    {
                        SetPointType = stepTestProperties.SetPointTypes[step],
                        SetPoint = stepTestProperties.SetPoints[step],
                        KeepTime = stepTestProperties.StepDurationTimes[step],
                        PlotStageData = true,
                        StageNo = ++st,
                        StepOrCycle = step,
                        StageDescription = string.Format("{0} control", stepTestProperties.SetPointTypes[step]),
                    };

                    test.AddStage(ctrlStage);
                }
            }
        }
    }
}
