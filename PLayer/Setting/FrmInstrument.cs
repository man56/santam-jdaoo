using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using STM.BLayer.Parameters;
using STM.Sensor;
using STM.BLayer.Configurations;

namespace STM.PLayer.Setting
{
    public partial class FrmInstrument : Form
    {
        #region form

        Dictionary<int, LoadCell> loadDic;
        Dictionary<int, ExtensoMeter> extenDic;
        Dictionary<int, TemperatureSensor> tempsDic;

        public event EventHandler<EventArgs> DialogOk;

        public FrmInstrument()
        {
            InitializeComponent();
            var rcm = new ComponentResourceManager(typeof(FrmInstrument));
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

        private void FrmInstrument_Load(object sender, EventArgs e)
        {
            LoadFileds();
        }

        private void LoadFileds()
        {
            LoadLoadCells();
            LoadExtensoMeters();
            LoadTemperatures();
            LoadOtherParams();
            if (dgvExtensometers.Rows.Count == 0)
            {
                lbNoExtensometer.Visible = true;
            }
            if (dgvLoadCells.Rows.Count == 0)
            {
                lbNoLoadcell.Visible = true;
            }
        }

        #endregion

        #region LoadCells

        private void LoadLoadCells()
        {
            dgvLoadCells.BackgroundColor = Color.White;
            loadDic = SettingLoader.Current.GetLoadcells();

            var id = 0;
            dgvLoadCells.Rows.Clear();
            foreach (var loadCell in loadDic.Values)
            {
                dgvLoadCells.Rows.Add(loadCell.LoadCellType, ++id, loadCell.MaxCap, loadCell.RO);
                try
                {
                    if (Sensors.CurrentLoadCell.MaxCap == loadCell.MaxCap)
                    {
                        dgvLoadCells.Rows[id - 1].Selected = true;
                    }
                }
                catch
                {
                }
            }
            lbNoLoadcell.Visible = dgvLoadCells.Rows.Count == 0;
        }

        private void dgvLoadCells_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lbNoLoadcell.Visible = dgvLoadCells.Rows.Count == 0;
        }

        private void SaveLoadCell()
        {
            var keys = new List<int>();
            foreach (DataGridViewRow row in dgvLoadCells.Rows)
            {
                try
                {
                    var key = int.Parse(row.Cells[0].Value.ToString());
                    keys.Add(key);
                }
                catch { }
            }
            var lastKeys = loadDic.Keys.ToList();
            foreach (var key in lastKeys)
            {
                if (keys.Contains(key))
                {
                    keys.Remove(key);
                }
                else
                {
                    loadDic.Remove(key);
                }
            }
            using (SettingLoader sl = SettingLoader.Current)
            {
                sl.SetLoadcells(loadDic);
            }
        }

        #endregion

        #region Extensometers

        private void LoadExtensoMeters()
        {
            dgvExtensometers.BackgroundColor = Color.White;
          

            extenDic = SettingLoader.Current.GetExtensometers();

            var id = 0;
            dgvExtensometers.Rows.Clear();
            foreach (var extensometer in extenDic.Values)
            {
                dgvExtensometers.Rows.Add(extensometer.ExtensomereType, ++id, extensometer.MaxCap, extensometer.RoGain);
                try
                {
                    if (Sensors.CurrentExtensoMeter.MaxCap == extensometer.MaxCap)
                    {
                        dgvExtensometers.Rows[id - 1].Selected = true;
                    }
                }
                catch
                {
                }
            }
            lbNoExtensometer.Visible = dgvExtensometers.Rows.Count == 0;
        }

        private void dgvExtensometer_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lbNoExtensometer.Visible = dgvExtensometers.Rows.Count == 0;
        }

        private void SaveExtenSometers()
        {
            var keys = new List<int>();
            foreach (DataGridViewRow row in dgvExtensometers.Rows)
            {
                try
                {
                    var key = int.Parse(row.Cells[0].Value.ToString());
                    keys.Add(key);
                }
                catch { }
            }
            var lastKeys = extenDic.Keys.ToList();
            foreach (var key in lastKeys)
            {
                if (keys.Contains(key))
                {
                    keys.Remove(key);
                }
                else
                {
                    extenDic.Remove(key);
                }
            }
            SettingLoader.Current.SetExtensometers(extenDic);
        }

        #endregion

        #region Temperature

        private void LoadTemperatures()
        {
            tempsDic = SettingLoader.Current.GetTemperatureSensors();
        }

        private void SaveTemperatureSensors()
        {
            SettingLoader.Current.SetTemperatureSensors(tempsDic);
        }

        #endregion

        #region instruments

        private void SetInstruments()
        {
            InstrumentParameters.ForceFilter = txtLoadcellFilter.ValueInInt;
            InstrumentParameters.ForceMaxPercent = txtForceMax.ValueInDouble;
            InstrumentParameters.ForceMinPercent = txtForceMin.ValueInDouble;
            InstrumentParameters.ForcePeakNoiseDetection = txtLoadcellPeakNoise.ValueInInt;
            InstrumentParameters.ForceRes = txtLoadcellRes.ValueInInt;

            InstrumentParameters.ExtenFilter = txtExtenFilter.ValueInInt;
            InstrumentParameters.ExtenMax = txtExtenMax.ValueInDouble;
            InstrumentParameters.ExtenMin = txtExtenMin.ValueInDouble;
            InstrumentParameters.ExtenGaugeLength = txtExtenGauge.ValueInDouble;
            InstrumentParameters.ExtenPeakNoiseDetection = txtExtenPeakNoise.ValueInInt;
            InstrumentParameters.ExtenRes = txtExtenRes.ValueInInt;
            InstrumentParameters.UseExtensometer = cbUseExtensometer.Checked;

            InstrumentParameters.LfEncoderFilter = txtExtenFilter.ValueInInt;
            InstrumentParameters.LfEncoderMax = txtEncoderMax.ValueInDouble;
            InstrumentParameters.LfEncoderMin = txtEncoderMin.ValueInDouble;
            InstrumentParameters.LfEncoderGain = txtEncoderGain.ValueInDouble;
            InstrumentParameters.LfEncoderRes = txtEncoderRes.ValueInInt;
            InstrumentParameters.LfEncoderPeakNoiseDetection = txtEncoderPeakNoise.ValueInInt;

            InstrumentParameters.LExtenFilter = txtLExtenFilter.ValueInInt;
            InstrumentParameters.LExtenMax = txtLExtenMax.ValueInDouble;
            InstrumentParameters.LExtenMin = txtLExtenMin.ValueInDouble;
            InstrumentParameters.LExtenPeakNoiseDetection = txtLExtenNoise.ValueInInt;
            InstrumentParameters.LExtenRes = txtLExtenRes.ValueInInt;
            InstrumentParameters.LExtenGaugeLength = txtLExtenGauge.ValueInDouble;

            InstrumentParameters.TemperatureHMI = tmprUseHMI.Checked;
            InstrumentParameters.TemperatureRes = tmprResolution.ValueInInt;
            InstrumentParameters.TemperatureMax = tmprMaximum.ValueInInt;
            InstrumentParameters.TemperatureAxisRange = txtDiagramY2ScaleRange.ValueInInt;


            SettingLoader.Current.SetInstruments();
            SaveLoadCell();
            SaveExtenSometers();
            SaveTemperatureSensors();
            SettingLoader.Current.SaveOption();
        }
        private void LoadOtherParams()
        {
            using (SettingLoader sl = SettingLoader.Current)
            {
                sl.LoadInstruments();
            }
            txtLoadcellFilter.Text = InstrumentParameters.ForceFilter.ToString();
            txtForceMax.Text = InstrumentParameters.ForceMaxPercent.ToString();
            txtForceMin.Text = InstrumentParameters.ForceMinPercent.ToString();
            txtLoadcellPeakNoise.Text = InstrumentParameters.ForcePeakNoiseDetection.ToString();
            txtLoadcellRes.Text = InstrumentParameters.ForceRes.ToString();

            txtExtenFilter.Text = InstrumentParameters.ExtenFilter.ToString();
            txtExtenMax.Text = InstrumentParameters.ExtenMax.ToString();
            txtExtenMin.Text = InstrumentParameters.ExtenMin.ToString();
            txtExtenGauge.Text = InstrumentParameters.ExtenGaugeLength.ToString();
            txtExtenPeakNoise.Text = InstrumentParameters.ExtenPeakNoiseDetection.ToString();
            txtExtenRes.Text = InstrumentParameters.ExtenRes.ToString();
            cbUseExtensometer.Checked = InstrumentParameters.UseExtensometer;
            txtEncoderFilter.Text = InstrumentParameters.LfEncoderFilter.ToString();
            txtEncoderMax.Text = InstrumentParameters.LfEncoderMax.ToString();
            txtEncoderMin.Text = string.Format("{0}", InstrumentParameters.LfEncoderMin);
            txtEncoderGain.Text =string.Format("{0:0.################################}", InstrumentParameters.LfEncoderGain);
            txtEncoderRes.Text = InstrumentParameters.LfEncoderRes.ToString();
            txtEncoderPeakNoise.Text = InstrumentParameters.LfEncoderPeakNoiseDetection.ToString();

            txtLExtenFilter.Text = InstrumentParameters.LExtenFilter.ToString();
            txtLExtenMax.Text = InstrumentParameters.LExtenMax.ToString();
            txtLExtenMin.Text = InstrumentParameters.LExtenMin.ToString();
            txtLExtenNoise.Text = InstrumentParameters.LExtenPeakNoiseDetection.ToString();
            txtLExtenRes.Text = InstrumentParameters.LExtenRes.ToString();
            txtLExtenGauge.Text = InstrumentParameters.LExtenGaugeLength.ToString();

            tmprResolution.Text = InstrumentParameters.TemperatureRes.ToString();
            tmprMaximum.Text = InstrumentParameters.TemperatureMax.ToString();
            // Nazarpour 1399/11/11
            txtDiagramY2ScaleRange.Text = InstrumentParameters.TemperatureAxisRange.ToString();
            tmprUseDirect.Checked = !InstrumentParameters.TemperatureHMI;
            tmprUseHMI.Checked = InstrumentParameters.TemperatureHMI;
        }

        #endregion

        #region navigators

        private void llForce_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbInstrument.SelectedTab = tpLoadcell;
            CheckLinkLableGroup(sender as Control);
        }

        private void llExtension_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbInstrument.SelectedTab = tpLDEncoder;
            CheckLinkLableGroup(sender as Control);
        }

        private void llStrain1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbInstrument.SelectedTab = tpExtensometer;
            CheckLinkLableGroup(sender as Control);
        }

        private void llStrain2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbInstrument.SelectedTab = tpStrain2;
            CheckLinkLableGroup(sender as Control);
        }

		private void lkTemperature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            if (Program.FullCreepAvailable)
            {
                tbInstrument.SelectedTab = tbpTemperature;
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

        #region apply cancel exit

        private void llApply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var update = Math.Abs(double.Parse(txtEncoderGain.Text) - InstrumentParameters.LfEncoderGain) > double.Epsilon;
                SetInstruments();
                OnChangeForceBoundary(this, EventArgs.Empty);
                if (update)
                    InvokeOnUpdateSettings(EventArgs.Empty);
            }
            catch
            {
            }
            HideForm();
            DialogOk(this, EventArgs.Empty);
        }

        private void lbExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadFileds();
            HideForm();
        }

        #endregion

        public void SetProgress(int percent)
        {
            pBarPortChanging.Visible = percent > 0 & percent != 100;
            pBarPortChanging.Value = percent;
        }

        public void InvokeOnUpdateSettings(EventArgs e)
        {
            var handler = OnUpdateSettings;
            if (handler != null) handler(this, e);
        }

        private void TextBoxNext(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ctrl = GetNextControl(sender as Control, true);
                if (ctrl is TextBox)
                    ctrl.Focus();
            }
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

	}
}
