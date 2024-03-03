using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STM.BLayer.StmTest;
using STM.DLayer;

namespace STM
{
    public partial class TemperatureMoreControlForm : Form
    {
        private delegate void void_deligate();
        private DateTime _NextUpdate;

        public TemperatureMoreControlForm()
        {
            InitializeComponent();
        }

        private void chkEnableTemperatureCompensation_CheckedChanged(object sender, EventArgs e)
        {
            Test.UseTemperatureCompensation = chkEnableTemperatureCompensation.Checked;
            labelChronometer.Visible = Test.UseTemperatureCompensation;
        }

        private void commandApplyTPeriod_Click(object sender, EventArgs e)
        {
            Test.TemperatureCompensationPeriod = (int)nudTemperatureCompensationPeriod.Value;
            Test.NextTemperatureCompensationTime = DateTime.Now.AddMinutes(Test.TemperatureCompensationPeriod);
            BLayer.Configurations.SettingLoader.Current.SaveOption();
        }

        private void cmdApplyZ1SetPoint_Click(object sender, EventArgs e)
        {
            TMPR232.Current.Set(1, (int)numZ1SetPoint.Value);
            Test.LastSetPoints[0] = (int)numZ1SetPoint.Value;
        }

        private void cmdApplyZ2SetPoint_Click(object sender, EventArgs e)
        {
            TMPR232.Current.Set(2, (int)numZ2SetPoint.Value);
            Test.LastSetPoints[1] = (int)numZ2SetPoint.Value;
        }

        private void cmdApplyZ3SetPoint_Click(object sender, EventArgs e)
        {
            TMPR232.Current.Set(3, (int)numZ3SetPoint.Value);
            Test.LastSetPoints[2] = (int)numZ3SetPoint.Value;
        }

        private void ClearOutputCommand_Click(object sender, EventArgs e)
        {
            output_View.Clear();
        }

        private void UpdateReport(bool applied, int[] setPoints, float[] averages, float[] currents, int unbalance, DateTime startDateTime, int delta)
        {
            if (setPoints != null)
            {
                float[] avg = new float[averages.Length];
                averages.CopyTo(avg, 0);
                float[] cur = new float[currents.Length];
                currents.CopyTo(cur, 0);
                float[] set = new float[setPoints.Length];
                setPoints.CopyTo(set, 0);

                this.BeginInvoke((Action)(() =>
                {
                    var timeOfTest = string.Format("{0:0.00}", BLayer.UnitManager.TimeM * (DateTime.Now - startDateTime).TotalSeconds);
                    var data = $"{DateTime.Now.ToString("HH:mm:ss")}, {timeOfTest} ({BLayer.UnitManager.TimeUnit}) of test\r\n";

                    if (unbalance == 0)
                    {
                        if (applied)
                        {
                            data += $"Set Points:";
                            for (var index = 0; index < 3; index++)
                                data += $" ZONE{index + 1}={set[index]};";
                            data += "\r\n______________________\r\n";

                            numZ1SetPoint.Value =(decimal) set[0];
                            numZ2SetPoint.Value = (decimal)set[1];
                            numZ3SetPoint.Value = (decimal)set[2];
                        }
                        else data = "";
                    }
                    else
                    {
                        if (option_ShowAverages.Checked)
                        {
                            data += $"{unbalance} Temperatures still not stable.";
                            for (var index = 0; index < 6; index++)
                                data += $"\r\nS{index + 1}:current={cur[index].ToString("0.00")}, avg={avg[index].ToString("0.00")} ";
                            data += "\r\n______________________\r\n";
                        }
                        else data = "";
                    }
                    
                    output_View.AppendText(data);
                }));
            }
        }

        private void TemperatureMoreControlForm_Load(object sender, EventArgs e)
        {
            Test.OnTemperatureCompensationCalculations += UpdateReport;

            if (Test.LastSetPoints != null)
            {
                numZ1SetPoint.Value = Test.LastSetPoints[0];
                numZ2SetPoint.Value = Test.LastSetPoints[1];
                numZ3SetPoint.Value = Test.LastSetPoints[2];
            }
            chkEnableTemperatureCompensation.Checked = Test.UseTemperatureCompensation;
            nudTemperatureCompensationPeriod.Value= Test.TemperatureCompensationPeriod;
            labelChronometer.Visible = Test.UseTemperatureCompensation;
        }

        private void TemperatureMoreControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Test.OnTemperatureCompensationCalculations -= UpdateReport;
        }

        private void timerChronometer_Tick(object sender, EventArgs e)
        {
            if (Test.UseTemperatureCompensation)
            {
                var ts = Test.NextTemperatureCompensationTime - DateTime.Now;
                if (ts.TotalSeconds >= 0)
                {
                    var s = $"{ts.Hours.ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}";
                    labelChronometer.Text = s;
                    labelResetCount.Text = Test.TemperatureResetCounter.ToString();
                }
                else
                {
                    labelChronometer.Text = "00:00:00";
                }
            }
        }
    }
}
