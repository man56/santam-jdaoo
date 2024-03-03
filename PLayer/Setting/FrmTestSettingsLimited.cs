using System;
using System.Windows.Forms;
using STM.BLayer.StmTest;
using STM.BLayer;

namespace STM.PLayer.Setting
{
    public partial class FrmTestSettingsLimited : Form
    {
        private TestStage _TestStage;
        private int? mDecimation = null;
        private int lastSelectedIndex = -1;

        private int CalcCreepTestTime()
        {
            return (int)(txtTestDurationH.ValueInDouble * 3600) + (int)(txtTestDuration.ValueInDouble * 60);
        }

        private void SetCreepTestTimes(string value)
        {
            var v = int.Parse(value);
            var h = v / 3600;
            var m = (v % 3600) / 60.0;
            txtTestDurationH.Text = h.ToString();
            txtTestDuration.Text = m.ToString();
        }

        public void UpdateFields(TestStage stage)
        {
            try
            {
                _TestStage = stage;
                UpdateDecimationValue(mDecimation = stage.Decimation);
                SetCreepTestTimes(stage.KeepTime.ToString());
                nrTemperatureSetpoint.Text = stage.TemperatureSetPoint.ToString();

                cbStopCondition.Checked = Test.CustomeStopType != 0;
                if (cbStopCondition.Checked)
                {
                    cbConditionType.Text = Test.CustomeStopType.ToString();
                    var cond = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbConditionType.Text);
                    lbConditionUbit.Text = UnitManager.GetUnit(cond);
                    txtConditionValue.Text = string.Format("{0:0.###}", UnitManager.ConvertToCurrent(Test.CustomeStopValue, lbConditionUbit.Text));
                }
            }
            catch
            {
            }
        }

        private void cbStopCondition_CheckedChanged(object sender, EventArgs e)
        {
            cbConditionType.Enabled = txtConditionValue.Enabled = cbStopCondition.Checked;
        }

        private void cbConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cond = (TestControlMode)Enum.Parse(typeof(TestControlMode), cbConditionType.Text);
            lbConditionUbit.Text = UnitManager.GetUnit(cond);
        }

        public event EventHandler<EventArgs> OnOperationDone;

        public FrmTestSettingsLimited()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var decimation = CalculateDecimation();
            _TestStage.Decimation = decimation ?? mDecimation;
            _TestStage.KeepTime = CalcCreepTestTime();
            _TestStage.TemperatureSetPoint = nrTemperatureSetpoint.ValueInFoalt;

            Test.CustomeStopType = cbStopCondition.Checked ? (TestControlMode)Enum.Parse(typeof(TestControlMode), cbConditionType.Text) : 0;
            Test.CustomeStopValue = UnitManager.ConvertToBase(txtConditionValue.Text, lbConditionUbit.Text);

            if (OnOperationDone != null)
                OnOperationDone(this, EventArgs.Empty);

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTestSettingsLimited_Load(object sender, EventArgs e)
        {
            cboDecimationUnit.SelectedIndex = 0;
            cbConditionType.DataSource = new[] { TestControlMode.Force, TestControlMode.Extension, TestControlMode.Stress, TestControlMode.Strain };
        }

        private void cboDecimationUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var decimation = CalculateDecimation();
            if (decimation.HasValue) mDecimation = decimation.Value;
            UpdateDecimationValue(mDecimation);
            lastSelectedIndex = cboDecimationUnit.SelectedIndex;
        }

        private int? CalculateDecimation()
        {
            int? decimation;
            try
            {
                decimation = int.Parse(txtDecimation.Text);
                if (decimation > 0)
                    switch (lastSelectedIndex)
                    {
                        case 1:
                            decimation = 100 / decimation;
                            break;

                        case 2:
                            decimation = (100 * 60 / decimation);
                            break;

                        case 3:
                            decimation = (100 * 3600 / decimation);
                            break;

                        default:
                            break;
                    }
                else
                    decimation = null;
            }
            catch
            {
                decimation = null;
            }

            return decimation;
        }

        private void UpdateDecimationValue(int? decimation)
        {
            if (decimation.HasValue)
            {
                if (decimation > 0) 
                switch (cboDecimationUnit.SelectedIndex)
                {
                    case 1:
                        decimation = (100 / decimation);
                        break;

                    case 2:
                        decimation = (100 * 60 / decimation);
                        break;

                    case 3:
                        decimation = (100 * 3600 / decimation);
                        break;

                    default:
                        break;
                }
                txtDecimation.Text =decimation>0? decimation.ToString():"";
            }
            else
                txtDecimation.Text = "";
        }
    }
}
