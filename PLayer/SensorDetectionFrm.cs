using System;
using System.Windows.Forms;
using STM.Properties;
using STM.Sensor;

namespace STM.PLayer
{
    public partial class SensorDetectionFrm : Form
    {
        public double MaxCapacity { set; get; }
        public double RO { set; get; }
        public bool ReadOnly { set; get; }
        public int Option => cbExtenType.SelectedIndex;

        private SensorType _SensorType;
        public SensorType SensorType
        {
            set
            {
                _SensorType = value;
                var lcType = value == SensorType.Loadcell;
                var tpType = value == SensorType.TemperatureSensor;
                pnlExType.Visible = !(lcType || tpType);
                Height = Height - ((lcType || tpType) ? pnlExType.Height : 0);
                lbUnit.Text = lcType ? Resources.FrmTestSetting_Kg : (tpType ? Resources.TemperatureConvertor_UnitSet__C : Resources.LengthConvertor_UnitSet_mm);                
            }
            get { return _SensorType; }
        }

        public string LbOkText
        {
            set { lbOk.Text = value; }
        }

        public SensorDetectionFrm()
        {
            InitializeComponent();
            cbExtenType.SelectedIndex = 0;
            txtMaxCapacity.Focus();
        }

        private void lbOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaxCapacity = txtMaxCapacity.ValueInInt;
            RO = txtRO.ValueInDouble;
            DialogResult = DialogResult.OK;
        }


        private void SensorDetectionFrm_Load(object sender, EventArgs e)
        {
            txtMaxCapacity.Text = MaxCapacity.ToString();
            txtRO.Text = RO.ToString();

            txtMaxCapacity.ReadOnly = ReadOnly;
            txtRO.ReadOnly = ReadOnly;
        }

        private void cbExtenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SensorType == SensorType.TemperatureSensor)
            {
                lbMvv.Visible = false;
                lblMaxCap.Text = "Multiplier:";
                lbRoGain.Text = "Divider:";
            }
            else if (cbExtenType.SelectedIndex == 0)
            {
                lbMvv.Visible = true;
                lbRoGain.Text = "R.O.:";
            }
            else
            {
                lbMvv.Visible = false;
                lbRoGain.Text = "Gain:";
            }
        }
    }
}
