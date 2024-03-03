using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.Configurations;

//modified 90.9.10
namespace STM.PLayer.Setting
{

    public partial class FrmUnitSetting : Form
    {

        public bool UnitSystemChanged { private set; get; }
        public bool ForceUnitChanged { private set; get; }
        public bool ExtensionUnitChanged { private set; get; }
        public bool StressUnitChanged { private set; get; }
        public bool StrainUnitChanged { private set; get; }
        public bool TimeUnitChanged { private set; get; }
        public bool SpecificStressUnitChanged { private set; get; }
        public bool LengthStressUnitChanged { private set; get; }
		public bool TemperatureUnitChanged { private set; get; }

		public FrmUnitSetting()
		{
			InitializeComponent();

			LoadUnits();
		}

		#region link labels

        #endregion

        #region Units

        private void cbReportingUnitMainCatagories_SelectedIndexChanged(object sender, EventArgs e)
        {
	        var tmp = UnitManager.CurrentUnitCategory;

	        UnitManager.CurrentUnitCategory = (UnitMainCategories)Enum.Parse(typeof(UnitMainCategories),
		        cbUnitMainCatagories.SelectedValue as string ?? "");
	        cbUnitForce.ValueMember = "Key";
	        cbUnitForce.DisplayMember = "Value";
	        cbUnitForce.DataSource = UnitManager.ForceUnits.ToDictionary().ToList();

	        cbUnitExtension.ValueMember = "Key";
	        cbUnitExtension.DisplayMember = "Value";
	        cbUnitExtension.DataSource = UnitManager.ExtensionUnits.ToDictionary().ToList();

	        cbUnitStress.ValueMember = "Key";
	        cbUnitStress.DisplayMember = "Value";
	        cbUnitStress.DataSource = UnitManager.StressUnits.ToDictionary().ToList();

	        cbUnitStrain.ValueMember = "Key";
	        cbUnitStrain.DisplayMember = "Value";
	        cbUnitStrain.DataSource = UnitManager.StrainUnits.ToDictionary().ToList();

	        cbUnitTime.ValueMember = "Key";
	        cbUnitTime.DisplayMember = "Value";
	        cbUnitTime.DataSource = UnitManager.TimeUnits.ToDictionary().ToList();

	        cbUnitTemperature.ValueMember = "Key";
	        cbUnitTemperature.DisplayMember = "Value";
	        cbUnitTemperature.DataSource = UnitManager.TemperatureUnits.ToDictionary().ToList();

	        cbUnitSpecificStress.ValueMember = "Key";
	        cbUnitSpecificStress.DisplayMember = "Value";
			cbUnitSpecificStress.DataSource = UnitManager.MassStressUnits.ToDictionary().ToList();

			cbUnitLengthStress.ValueMember = "Key";
			cbUnitLengthStress.DisplayMember = "Value";
			cbUnitLengthStress.DataSource = UnitManager.LengthStressUnits.ToDictionary().ToList();


			cbUnitForce.SelectedValue = (UnitManager.ForceUnit);
	        cbUnitExtension.SelectedValue =(UnitManager.ExtensionUnit);
	        cbUnitStress.SelectedValue =(UnitManager.StressUnit);
	        cbUnitStrain.SelectedValue =(UnitManager.StrainUnit);
	        cbUnitTime.SelectedValue = (UnitManager.TimeUnit);
	        cbUnitSpecificStress.SelectedValue = (UnitManager.MassStressUnit);
	        cbUnitLengthStress.SelectedValue = (UnitManager.LengthStressUnit);
	        cbUnitTemperature.SelectedValue = (UnitManager.TemperatureUnit);

	        UnitManager.CurrentUnitCategory = tmp;
        }

        private void SaveUnits()
        {
            var unitSystem = (UnitMainCategories)Enum.Parse(typeof(UnitMainCategories), cbUnitMainCatagories.SelectedValue as string ?? "");
            UnitSystemChanged = unitSystem != UnitManager.CurrentUnitCategory;
            
            ForceUnitChanged = UnitManager.ForceUnit != cbUnitForce.Text;
            ExtensionUnitChanged = UnitManager.ExtensionUnit != cbUnitExtension.Text;
            StressUnitChanged = UnitManager.StressUnit != cbUnitStress.Text;
            StrainUnitChanged = UnitManager.StrainUnit != cbUnitStrain.Text;
            TimeUnitChanged = UnitManager.TimeUnit != cbUnitTime.Text;
            SpecificStressUnitChanged = UnitManager.MassStressUnit != cbUnitSpecificStress.Text;
            LengthStressUnitChanged = UnitManager.LengthStressUnit != cbUnitLengthStress.Text;
			TemperatureUnitChanged = UnitManager.TemperatureUnit != cbUnitTemperature.Text;
            UnitManager.CurrentUnitCategory = unitSystem;
            SettingLoader.Current.SetUnits(
                cbUnitMainCatagories.SelectedValue as string ?? "",
                cbUnitForce.Text,
                cbUnitExtension.Text,
                cbUnitStress.Text,
                cbUnitStrain.Text,
                cbUnitTime.Text, 
                cbUnitSpecificStress.Text,
                cbUnitLengthStress.Text,
				cbUnitTemperature.Text);
            UnitManager.LoadUnits();
        }

        private void LoadUnits()
        {
			var resources = new ResourceManager(typeof(MainFrm));

			var uDic = new Dictionary<string, string>
			{
				{ UnitMainCategories.SI.ToString(), resources.GetString("subMenuSI.Text") },
				{ UnitMainCategories.BS.ToString(), resources.GetString("subMenuBS.Text") },
				{ UnitMainCategories.MKS.ToString(), resources.GetString("subMenuMKS.Text") },
			};
			cbUnitMainCatagories.ValueMember = "Key";
			cbUnitMainCatagories.DisplayMember = "Value";
			cbUnitMainCatagories.DataSource = uDic.ToList();

			cbUnitForce.ValueMember = "Key";
			cbUnitForce.DisplayMember = "Value";
			cbUnitForce.DataSource = UnitManager.ForceUnits.ToDictionary().ToList();

			cbUnitExtension.ValueMember = "Key";
			cbUnitExtension.DisplayMember = "Value";
			cbUnitExtension.DataSource = UnitManager.ExtensionUnits.ToDictionary().ToList();

			cbUnitStress.ValueMember = "Key";
			cbUnitStress.DisplayMember = "Value";
			cbUnitStress.DataSource = UnitManager.StressUnits.ToDictionary().ToList();

			cbUnitStrain.ValueMember = "Key";
			cbUnitStrain.DisplayMember = "Value";
			cbUnitStrain.DataSource = UnitManager.StrainUnits.ToDictionary().ToList();

			cbUnitTime.ValueMember = "Key";
			cbUnitTime.DisplayMember = "Value";
			cbUnitTime.DataSource = UnitManager.TimeUnits.ToDictionary().ToList();

			cbUnitTemperature.ValueMember = "Key";
			cbUnitTemperature.DisplayMember = "Value";
			cbUnitTemperature.DataSource = UnitManager.TemperatureUnits.ToDictionary().ToList();

			cbUnitMainCatagories.SelectedValue = UnitManager.CurrentUnitCategory.ToString();


            cbUnitForce.SelectedValue = UnitManager.ForceUnit;
            cbUnitExtension.SelectedValue = UnitManager.ExtensionUnit;
            cbUnitStress.SelectedValue = UnitManager.StressUnit;
            cbUnitStrain.SelectedValue = UnitManager.StrainUnit;
            cbUnitTime.SelectedValue = UnitManager.TimeUnit;

			cbUnitTemperature.SelectedValue = UnitManager.TemperatureUnit;
        }

        #endregion

        private void llUnitsOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveUnits();
            DialogResult = DialogResult.OK;
            HideForm();
        }

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            HideForm();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult = DialogResult.Cancel;
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