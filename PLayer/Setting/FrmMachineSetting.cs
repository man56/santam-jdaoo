using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer.Configurations;
using System.Drawing;
using STM.BLayer.Parameters;
using STM.BLayer.StmTest;

namespace STM.PLayer.Setting
{
    public partial class FrmMachineSetting : Form
    {
        //public bool PortChanged {private set; get; }
        public bool PidChanged { private set; get; }

        public FrmMachineSetting()
        {
            InitializeComponent();

            var rcm = new ComponentResourceManager(typeof(FrmMachineSetting));
            var cultureInfo = new CultureInfo(LanguageFrm.LanguageName);
            rcm.ApplyResources(this, "$this", cultureInfo);
            foreach (Control control in Controls)
            {
                if (control.HasChildren)
                    foreach (Control chControl in control.Controls)
                    {
                        rcm.ApplyResources(chControl, chControl.Name, cultureInfo);
                        if (chControl.HasChildren)
                            foreach (Control ch1Control in chControl.Controls)
                            {
                                rcm.ApplyResources(ch1Control, ch1Control.Name, cultureInfo);
                                if (ch1Control.HasChildren)
                                    foreach (Control ch2Control in ch1Control.Controls)
                                    {
                                        rcm.ApplyResources(ch2Control, ch2Control.Name, cultureInfo);
                                    }
                            }
                    }
                rcm.ApplyResources(control, control.Name, cultureInfo);
            }
            LoadSettings();
            LoadFields();
        }
        private void LoadSettings()
        {
            using (var sl = SettingLoader.Current)
            {
                sl.LoadPortSetting();
                sl.LoadCrossHeadSetting();
                sl.LoadSpeedCtrlSetting();
            }

        }

        #region load save methods

        private void LoadFields()
        {
            try
            {
                txtPortName.Text = SerialPortParameters.Name;
            }
            catch
            {
            }
            txtReadInterval.Text = SerialPortParameters.ReadInterval.ToString();
            txtPlotDecimationRatio.Text = SerialPortParameters.DecimationRatio.ToString();
            txtCrsHiJog.Text = CrossHead.HiJogSpeed.ToString();
            txtCrsLowJog.Text = CrossHead.LowJogSpeed.ToString();
            txtCrsInc.Text = CrossHead.Increament.ToString();
            txtCrsMax.Text = CrossHead.MaxSpeed.ToString();
            txtCrsMin.Text = CrossHead.MinSpeed.ToString();
            cbActuator.SelectedIndex = CrossHead.ActuatorUp ? 0 : 1;
            txtP.Text = SpeedControlParameters.P.ToString();
            txtI.Text = SpeedControlParameters.I.ToString();
            txtD.Text = SpeedControlParameters.D.ToString();
            OptionElectroHydrolic.Checked = CrossHead.ElectroHydrolic;

            txtKsi.Text = SpeedControlParameters.Ksi.ToString();
            txtKsp.Text = SpeedControlParameters.Ksp.ToString();
            txtKsd.Text = SpeedControlParameters.Ksd.ToString();
            txtStrainTor.Text = SpeedControlParameters.STorelance.ToString();

            txtKei.Text = SpeedControlParameters.Kei.ToString();
            txtKep.Text = SpeedControlParameters.Kep.ToString();
            txtKed.Text = SpeedControlParameters.Ked.ToString();
            txtExtenTor.Text = SpeedControlParameters.Etorelance.ToString();

            txtKfi.Text = SpeedControlParameters.Kfi.ToString();
            txtKfp.Text = SpeedControlParameters.Kfp.ToString();
            txtKfd.Text = SpeedControlParameters.Kfd.ToString();
            txtForceTor.Text = SpeedControlParameters.Ftorelance.ToString();

            txtMax.Text = SpeedControlParameters.Max.ToString();
            txtMCMD.Text = SpeedControlParameters.Command.ToString();
            txtMOffset.Text = SpeedControlParameters.Offset.ToString();
            txtMStep.Text = SpeedControlParameters.Step.ToString();
            txtMTimeOut.Text = SpeedControlParameters.Timeout.ToString();
            txtVel.Text = SpeedControlParameters.Velocity.ToString();
        }

        private void SetSettings()
        {
            SerialPortParameters.Name = txtPortName.Text;
            SerialPortParameters.ReadInterval = txtReadInterval.ValueInInt;
            SerialPortParameters.DecimationRatio = txtPlotDecimationRatio.ValueInInt;
            CrossHead.HiJogSpeed = txtCrsHiJog.ValueInDouble;
            CrossHead.LowJogSpeed = txtCrsLowJog.ValueInDouble;
            CrossHead.Increament = txtCrsInc.ValueInDouble;
            CrossHead.MaxSpeed = txtCrsMax.ValueInDouble;
            CrossHead.MinSpeed = txtCrsMin.ValueInDouble;
            CrossHead.ActuatorUp = cbActuator.SelectedIndex == 0;
            Test.ReturnToZeroSpeed = (int)CrossHead.MinSpeed;
            CrossHead.ElectroHydrolic = OptionElectroHydrolic.Checked;

            if (Math.Abs(SpeedControlParameters.P - txtP.ValueInDouble) > double.Epsilon)
                PidChanged = true;
            SpeedControlParameters.P = txtP.ValueInDouble;

            if (Math.Abs(SpeedControlParameters.I - txtI.ValueInDouble) > double.Epsilon)
                PidChanged = true;
            SpeedControlParameters.I = txtI.ValueInDouble;

            if (Math.Abs(SpeedControlParameters.D - txtD.ValueInDouble) > double.Epsilon)
                PidChanged = true;
            SpeedControlParameters.D = txtD.ValueInDouble;

            SpeedControlParameters.Ksi = txtKsi.ValueInDouble;
            SpeedControlParameters.Ksp = txtKsp.ValueInDouble;
            SpeedControlParameters.Ksd = txtKsd.ValueInDouble;
            SpeedControlParameters.STorelance = txtStrainTor.ValueInDouble;

            SpeedControlParameters.Kei = txtKei.ValueInDouble;
            SpeedControlParameters.Kep = txtKep.ValueInDouble;
            SpeedControlParameters.Ked = txtKed.ValueInDouble;
            SpeedControlParameters.Etorelance = txtExtenTor.ValueInDouble;

            SpeedControlParameters.Kfi = txtKfi.ValueInDouble;
            SpeedControlParameters.Kfp = txtKfp.ValueInDouble;
            SpeedControlParameters.Kfd = txtKfd.ValueInDouble;
            SpeedControlParameters.Ftorelance = txtForceTor.ValueInDouble;

            if (Math.Abs(SpeedControlParameters.Max - txtMax.ValueInDouble) > double.Epsilon)
                PidChanged = true;
            SpeedControlParameters.Max = txtMax.ValueInDouble;
            if (Math.Abs(SpeedControlParameters.Offset - txtMOffset.ValueInDouble) > double.Epsilon)
                PidChanged = true;
            SpeedControlParameters.Offset = txtMOffset.ValueInDouble;
            if (Math.Abs(SpeedControlParameters.Step - txtMStep.ValueInDouble) > double.Epsilon)
                PidChanged = true;
            SpeedControlParameters.Step = txtMStep.ValueInDouble;

            SpeedControlParameters.Command = txtMCMD.ValueInDouble;
            SpeedControlParameters.Timeout = txtMTimeOut.ValueInDouble;
            SpeedControlParameters.Velocity = txtVel.ValueInDouble;
        }

        private void llFds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnFds(this, EventArgs.Empty);
        }

        #endregion

        #region link labels

        private void llHardware_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbMachineSetting.SelectedTab = tpHardware;
            CheckLinkLableGroup(sender as Control);
        }
       
        private void llCrosshead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbMachineSetting.SelectedTab = tpCrossHead;
            CheckLinkLableGroup(sender as Control);
        }

        private void llControl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbMachineSetting.SelectedTab = tpControl;
            CheckLinkLableGroup(sender as Control);
        }

        private void CheckLinkLableGroup(IDisposable control)
        {
            foreach (var ctrl in panelNavigation.Controls.OfType<LinkLabel>())
            {
                ctrl.Font = ctrl.Equals(control) ? new Font(ctrl.Font.Name, ctrl.Font.Size, FontStyle.Bold) :
                            new Font(ctrl.Font.Name, ctrl.Font.Size, FontStyle.Regular);
            }
        }

        #endregion

        # region form metghods

        private void cbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcSpeedControl.SelectedIndex = cbSpeed.SelectedIndex;
        }

        private void tbMachineSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            panleSpeedSettingSelector.Visible = tbMachineSetting.SelectedTab == tpControl;
        }

       
        private void FrmMachineSetting_Load(object sender, EventArgs e)
        {
            cbSpeed.Text = @"Speed Control Factors";
        }

        private void llApply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetSettings();
            SettingLoader.Current.SavePortSetting();
            SettingLoader.Current.SaveCrossHeadSetting();
            SettingLoader.Current.SaveSpeedCtrlSetting();
            if (PidChanged)
            {
                InvokeOnUpdateSettings(EventArgs.Empty);
            }
            HideForm();
            DialogOk(this, EventArgs.Empty);

        }

        public event EventHandler<EventArgs> DialogOk; 

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadFields();
            HideForm();
        }

        public void SetProgress (int percent)
        {
            pBarPortChanging.Visible = percent > 0 & percent != 100;
            pBarPortChanging.Value = percent;
            if(percent>=100)
                DialogResult = DialogResult.OK;
        }

        public void InvokeOnUpdateSettings(EventArgs e)
        {
            EventHandler<EventArgs> handler = OnUpdateSettings;
            if (handler != null) handler(this, e);
        }

        #endregion

        private void txtCrsMax_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                txtCrsHiJog.MaxValue = txtCrsMax.Text;
                txtCrsLowJog.MinValue = txtCrsMin.Text;
                txtCrsHiJog.CheckInRange = true;
                txtCrsLowJog.CheckInRange = true;
                txtCrsHiJog.Validate();
                txtCrsLowJog.Validate();
            }
            catch
            {
            }
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

        private void txtCrsHiJog_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCrsLowJog.MaxValue = txtCrsHiJog.Text;
                txtCrsLowJog.CheckInRange = true;
                txtCrsLowJog.Validate();
            }
            catch
            {
            }
        }
    }
}
