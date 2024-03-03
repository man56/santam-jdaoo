using STM.BLayer.Parameters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace STM.PLayer.Setting
{
    public partial class FrmCalibration : Form
    {
        bool loadcellCalibrated;
        bool shortExtenCalibrated;
        bool longExtenCalibrated;

        #region events

        public event EventHandler<EventArgs> OnSetStartForcePoint;
        public event EventHandler<EventArgs> OnForceCalibrate;
        public event EventHandler<EventArgs> OnForceSave;
        public event EventHandler<EventArgs> OnTemperatureSave;

        public event EventHandler<EventArgs> OnSetStartExtenPoint;
        public event EventHandler<EventArgs> OnShortExtenCalibrate;
        public event EventHandler<EventArgs> OnShortExtenSave;

        public event EventHandler<EventArgs> OnLongExtenCalibrate;
        public event EventHandler<EventArgs> OnLongExtenSave;

        #endregion

        #region fields

        public double StopForce
        {
            set { txtStopForce.Text = value.ToString(); }
            get { return txtStopForce.ValueInDouble; }
        }
        public double StartForce
        {
            set { txtStartForce.Text = value.ToString(); }
            get { return txtStartForce.ValueInDouble; }
        }
        public double ForceRO
        {
            set { txtCurForceRO.Text = value.ToString(); }
            get { return txtCurForceRO.ValueInDouble; }
        }
        public int ForceMaxCap
        {
            set { txtLoadCellMaXCap.Text = value.ToString(); }
            get { return txtLoadCellMaXCap.ValueInInt; }
        }
        public double TemperatureGain1
        {
            set { nrTemperatureGain1.Text = value.ToString(); }
            get { return nrTemperatureGain1.ValueInDouble; }
        }

        public double TemperatureGain2
        {
            set { nrTemperatureGain2.Text = value.ToString(); }
            get { return nrTemperatureGain2.ValueInDouble; }
        }

        public double StopShortExten
        {
            set { txtStopShortExtension.Text = value.ToString(); }
            get { return txtStopShortExtension.ValueInDouble; }
        }
        public double StartShortExten
        {
            set { txtStartShortExtension.Text = value.ToString(); }
            get { return txtStartShortExtension.ValueInDouble; }
        }
        public double ShortExtenRO
        {
            set { txtCurShortExtenRo.Text = value.ToString(); }
            get { return txtCurShortExtenRo.ValueInDouble; }
        }
        public double ShortExtenMaxCap
        {
            set { txtShortExtenMaXCap.Text = value.ToString(); }
            get { return txtShortExtenMaXCap.ValueInDouble; }
        }


        public double StopLongExten
        {
            set { txtStopLongExtension.Text = value.ToString(); }
            get { return txtStopLongExtension.ValueInDouble; }
        }
        public double StartLongExten
        {
            set { txtStartLongExtension.Text = value.ToString(); }
            get { return txtStartLongExtension.ValueInDouble; }
        }
        public double LongExtenGain
        {
            set { txtLongExtenGain.Text = value.ToString(); }
            get { return txtLongExtenGain.ValueInDouble; }
        }
        public double LongExtenMaxCap
        { 
            set { txtLongExtensionCap.Text = value.ToString(); }
            get { return txtLongExtensionCap.ValueInDouble; }
        }

        #endregion

        #region constructor

        public FrmCalibration()
        {
            InitializeComponent();
            var rcm = new ComponentResourceManager(typeof(FrmCalibration));
            var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            SetCulture(Controls, rcm, cultureInfo);
        }

        private void SetCulture(Control.ControlCollection controls, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                    SetCulture(control.Controls, rcm, cultureInfo);
                else
                {
                    rcm.ApplyResources(control, control.Name, cultureInfo);
                }
            }
        }

        #endregion

        #region calibration cmds

        private void rbLoadcellDirectCalibration_CheckedChanged(object sender, EventArgs e)
        {
            txtLoadCellMaXCap.Enabled = rbLoadcellDirectCalibration.Checked;
           
            txtLoadCellRO.Enabled = rbLoadcellDirectCalibration.Checked;
            pnlLoadcellCalibration.Enabled = !rbLoadcellDirectCalibration.Checked;
        }

        private void llSetForceStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnSetStartForcePoint != null)
                OnSetStartForcePoint(this, EventArgs.Empty);
        }
        
        private void llCalibrateForce_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnForceCalibrate != null)
                OnForceCalibrate(this, EventArgs.Empty);
        }
        
        private void llSaveForceRO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadcellCalibrated = true;
        }

        private void SaveForceRO()
        {
            if (rbLoadcellDirectCalibration.Checked)
                txtCurForceRO.Text = txtLoadCellRO.Text;
            else
                txtLoadCellRO.Text = txtCurForceRO.Text;
            if (OnForceSave != null)
                OnForceSave(this, EventArgs.Empty);
        }

        private void SaveTemperature()
        {
            if (OnTemperatureSave != null)
                OnTemperatureSave(this, EventArgs.Empty);
        }

        private void llSetShortExtenStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnSetStartExtenPoint != null)
                OnSetStartExtenPoint(this, EventArgs.Empty);
        }
        private void llCaribrateShortExten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnShortExtenCalibrate != null)
                OnShortExtenCalibrate(this, EventArgs.Empty);
        }
        private void llSaveShortExtenRO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            shortExtenCalibrated = true;
        }

        private void SaveShortExtenRO()
        {
            if (rbShortExtenDirectCalibration.Checked)
                txtCurShortExtenRo.Text = txtShortExtenRO.Text;
            else
                txtShortExtenRO.Text = txtCurShortExtenRo.Text;
            if (OnShortExtenSave != null)
                OnShortExtenSave(this, EventArgs.Empty);
        }

        private void llSetLongExtenStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnSetStartExtenPoint != null)
                OnSetStartExtenPoint(this, EventArgs.Empty);
        }
        private void llCaribrateLongExten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnLongExtenCalibrate != null)
                OnLongExtenCalibrate(this, EventArgs.Empty);
        }

        private void llSaveLongExtenGain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            longExtenCalibrated = true;
        }

        private void SaveLongExtenGain()
        {
            if (OnLongExtenSave != null)
                OnLongExtenSave(this, EventArgs.Empty);
        }

        #endregion

        #region navigation

        private void llSample_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tcCalibration.SelectedTab = tpLoadcell;
            CheckLinkLableGroup(sender as Control);
        }

        private void llInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tcCalibration.SelectedTab = tpShortExten;
            CheckLinkLableGroup(sender as Control);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tcCalibration.SelectedTab = tpLongExten;
            CheckLinkLableGroup(sender as Control);
        }
		private void lkTemperature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            if (Program.FullCreepAvailable)
            {
                tcCalibration.SelectedTab = tbpTemperature;
                CheckLinkLableGroup(sender as Control);
            }
            else
            {
                lkTemperature.Enabled = false;
            }
		}

		private void CheckLinkLableGroup(Control control)
        {
            foreach (Control ctrl in panelNavigation.Controls)
                if (ctrl is LinkLabel)
                {
                    if (ctrl.Equals(control))
                    {
                        ctrl.Font = new Font(ctrl.Font.Name, ctrl.Font.Size, FontStyle.Bold);
                    }
                    else
                        ctrl.Font = new Font(ctrl.Font.Name, ctrl.Font.Size, FontStyle.Regular);
                }
        }

        #endregion

        private void TextBoxNext(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ctrl = GetNextControl(sender as Control, true);
                if (ctrl is TextBox)
                    ctrl.Focus();
            }
        }

        private void rbShortExtenDirectCalibration_CheckedChanged(object sender, EventArgs e)
        {
            txtShortExtenMaXCap.Enabled = rbShortExtenDirectCalibration.Checked;
            txtShortExtenRO.Enabled = rbShortExtenDirectCalibration.Checked;
            pnlShortTravelCalibration.Enabled = !rbShortExtenDirectCalibration.Checked;
        }

        private void llSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(loadcellCalibrated)
                SaveForceRO();
            if(shortExtenCalibrated)
                SaveShortExtenRO();
            if(longExtenCalibrated)
                SaveLongExtenGain();

            InstrumentParameters.TemperatureGain1 = nrTemperatureGain1.ValueInDouble;
            InstrumentParameters.TemperatureGain2 = nrTemperatureGain2.ValueInDouble;
            SaveTemperature();

            DialogResult = DialogResult.OK;
            HideForm();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            HideForm();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideForm();
        }
        private void HideForm()
        {
            Hide();
            if (OnOperationDone != null)
                OnOperationDone(this, EventArgs.Empty);
        }

        private void FrmCalibration_Load(object sender, EventArgs e)
        {
            loadcellCalibrated = false;
            shortExtenCalibrated = false;
            longExtenCalibrated = false;
            tcCalibration.SelectedIndex = 0;
            try
            {
                txtLoadCellMaXCap.Text = Sensor.Sensors.CurrentLoadCell.MaxCap.ToString();
                txtLoadCellRO.Text = Sensor.Sensors.CurrentLoadCell.RO.ToString();

                llLongExten.Enabled = Sensor.Sensors.CurrentExtensoMeter.EncoderBased;
                llShortExten.Enabled = !llLongExten.Enabled;
                if (!Sensor.Sensors.CurrentExtensoMeter.EncoderBased)
                {
                    txtShortExtenMaXCap.Text = Sensor.Sensors.CurrentExtensoMeter.MaxCap.ToString();
                    txtShortExtenRO.Text = Sensor.Sensors.CurrentExtensoMeter.RoGain.ToString();
                }
                else
                {
                    txtLongExtensionCap.Text = Sensor.Sensors.CurrentExtensoMeter.MaxCap.ToString();
                    txtLongExtenGain.Text = Sensor.Sensors.CurrentExtensoMeter.RoGain.ToString();
                }
            }
            catch
            {
            }

            nrTemperatureGain1.Text = InstrumentParameters.TemperatureGain1.ToString();
            nrTemperatureGain2.Text = InstrumentParameters.TemperatureGain2.ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Tab))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

	}
}
