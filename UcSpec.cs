using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using STM.BLayer;
using STM.BLayer.StmTest;
using STM.Extensions;
using STM.Properties;

namespace STM
{
    public partial class UcSpec : UserControl
    {
        readonly Label[] lbs;
        public UcSpec()
        {
            InitializeComponent();
            lbs = new[]
            {
                lbP1, lbV1, lbP2, lbV2, lbP3, lbV3, lbP4, lbV4, lbP5, lbV5, lbP6, lbV6, lbP7, lbV7,
                lbP8, lbV8, lbP9, lbV9, lbP10, lbV10, lbP11, lbV11, lbP12, lbV12, lbP13, lbV13
            };

            var rcm = new ComponentResourceManager(typeof(UcSpec));
            var cultureInfo = LanguageFrm.LanguageName != null ? new CultureInfo(LanguageFrm.LanguageName) : CultureInfo.CurrentCulture;
            rcm.ApplyResources(this, "$this", cultureInfo);
            Program.SetCulture(Controls, rcm, cultureInfo);
        }

        public Panel InfoPanel() { return panel1; }
        public Panel MethodPanel() { return panel2; }

        public int PrintHeight;

        public double StablizTime;
        public bool ImportInfo(TestInformation testInfo)
        {
            lbOp.Text = testInfo.OperatorName;
            lbCr.Text = testInfo.CustomerName;
            lbDate.Text = testInfo.GetDate();
            string txtInfo = "";
            txtInfo = testInfo.Description.Aggregate(txtInfo,
                                            (current, s) =>
                                            current + $"{s}" + "");
            lbNote.Text = txtInfo;
            return true;
        }

        public bool ImportSpecimen(XElement xElement)
        {
            var retVale = true;
            try
            {
                lbSpecimenType.Text = xElement.Attribute("Type").Value;
                lbSpecimenId.Text = xElement.Attribute("SampleId").Value;
                lbSpecimenArea.Text = xElement.Attribute("Area").Value;

                var dim1 = xElement.Attribute("Dim1").Value;
                var dim2 = xElement.Attribute("Dim2").Value;
                var dim3 = xElement.Attribute("Dim3").Value;

                lbGs.Text = $"{xElement.Attribute("SampleGS").Value} mm";
                lbGl.Text = $"{xElement.Attribute("SampleGP").Value} mm";

                switch (lbSpecimenType.Text.ToLower())
                {
                    case "circular":
                        lbDims.Text = $"R: {dim1} (mm)";
                        break;

                    case "tear":
                    case "rectangular":
                        lbDims.Text = $"W: {dim1} (mm), T: {dim2} (mm)";
                        break;

                    case "pipe":
                    case "oring":
                        lbDims.Text = $"R1: {dim1}, R2: {dim2} (mm)";
                        break;

                    case "weight":
                        lbDims.Text = $"D: {dim1} (kg/m3), W: {dim2} (kg), L: {dim3} (mm),";
                        break;

                    case "area":
                        lbDims.Text = $"R: {dim1} (mm2)";
                        break;

                    case "denier":
                        lbDims.Text = $"D: {dim1} (gr/9000m), R1: {dim2} (gr/cm3),";
                        break;

                    case "tex":
                        lbDims.Text = $"D: {dim1} (gr/1000m), R1: {dim2} (gr/cm3),";
                        break;
                }

            }
            catch (Exception)
            {
                retVale = false;
            }
            return retVale;
        }

        public bool ImportMethod(XElement xml)
        {
            var retVale = true;
            try
            {
                SetMethodFields(xml);
            }
            catch (Exception)
            {
                retVale = false;
            }
            return retVale;
        }

        private void SetMethodFields(XElement xElement)
        {
            var method = (TestMethodType)Enum.Parse(typeof(TestMethodType), xElement.Attribute("TestMethodType").Value);
            StablizTime = 0;
            switch (method)
            {
                case TestMethodType.Compressive:
                    lbMode.Text = Resources.UcSpec_Compression_Test;
                    SetCompressiveFields(xElement);
                    break;

                case TestMethodType.Creep:
                    lbMode.Text = Resources.UcSpec_Creep_Test;
                    SetCreepFields(xElement);
                    break;

                case TestMethodType.Cyclic:
                    lbMode.Text = Resources.UcSpec_Cyclic_Test;
                    SetCyclicFields(xElement);
                    break;

                case TestMethodType.Relaxation:
                    lbMode.Text = Resources.UcSpec_Relaxation_Test;
                    SetRelaxationFields(xElement);
                    break;

                case TestMethodType.Step:
                    lbMode.Text = Resources.UcSpec_Step_Test;
                    SetStepFields(xElement);
                    break;

                case TestMethodType.Tensile:
                    lbMode.Text = Resources.UcSpec_Tension_Test;
                    SetTensileFields(xElement);
                    break;
            }
            SetPoses();
        }

        private void SetTensileFields(XElement xElement)
        {
            foreach (var lb in lbs)
                lb.Text = "";

            var i = 0;
            if (bool.Parse(xElement.Attribute("TensilePreLoad").Value))
            {
                lbs[i++].Text = Resources.UcSpec_Preload;
                var unit = xElement.Attribute("PreLoadUnits").Value;
                lbs[i++].Text = string.Format("{0}:{1}({2})", xElement.Attribute("TensilePreLoadType").Value,
                    UnitManager.ConvertToCurrent(xElement.Attribute("TensilePreLoadSetPoint").Value, unit).ToString("0.##"), unit);
            }
            var xtenRate = xElement.Attribute("SpeedUnits").Value;
            lbs[i++].Text = Resources.UcSpec_Speed;
            lbs[i++].Text = $"{UnitManager.ConvertToCurrent(xElement.Attribute("MethodSpeed").Value, xtenRate).ToString("0.##")}({xtenRate})";

            if (bool.Parse(xElement.Attribute("TensileEnableSecondSpeed").Value))
            {
                lbs[i++].Text = Resources.UcSpec_SetTensileFields_Speed_2_;
                var unit = xElement.Attribute("TensileSecSpeedUnit").Value;
                lbs[i++].Text =
                    $"{UnitManager.ConvertToCurrent(xElement.Attribute("TensileSecondSpeed").Value, xtenRate).ToString("0.##")}({xtenRate})";

                lbs[i++].Text = Resources.UcSpec_SetTensileFields_Speed_2_condition_;
                lbs[i++].Text =
                    $"{xElement.Attribute("TensileSecSpeedType").Value}: {UnitManager.ConvertToCurrent(xElement.Attribute("TensileSecSpeedSetPoint").Value, unit).ToString("0.##")}({unit})";
            }
            if (bool.Parse(xElement.Attribute("TensileEnableStoE").Value))
            {
                lbs[i++].Text = Resources.UcSpec_SetTensileFields_S_to_E;
                var unit = xElement.Attribute("TensileStoEUnit").Value;
                lbs[i].Text =
                    $"{xElement.Attribute("TensileStoEType").Value}: {UnitManager.ConvertToCurrent(xElement.Attribute("TensileStoESetPoint").Value, unit).ToString("0.##")}({unit})";
            }

            PrintHeight = lbs[i].Location.Y + lbs[i].Height + 10;
        }
        private void SetCompressiveFields(XElement xElement)
        {
            foreach (var lb in lbs)
                lb.Text = "";

            var i = 0;
            var xtenRate = xElement.Attribute("SpeedUnits").Value;
            lbs[i++].Text = Resources.UcSpec_Speed;
            lbs[i].Text =
                $"{UnitManager.ConvertToCurrent(xElement.Attribute("MethodSpeed").Value, xtenRate).ToString("0.##")}({xtenRate})";

            PrintHeight = lbs[i].Location.Y + lbs[i].Height + 10;
        }
        private void SetCyclicFields(XElement xElement)
        {
            foreach (var lb in lbs)
                lb.Text = "";
            var i = 0;

            lbs[i++].Text = Resources.UcSpec_SetCyclicFields_No__Cycle_;
            lbs[i++].Text = xElement.Attribute("CyclicCount").Value;

            var setPointType = (TestControlMode)Enum.Parse(typeof(TestControlMode), xElement.Attribute("CycleLimitType").Value);
            var unit = UnitManager.GetUnit(setPointType);

            lbs[i++].Text = Resources.UcSpec_SetCyclicFields_Limit_1_;
            lbs[i++].Text =
                $"{UnitManager.ConvertToCurrent(xElement.Attribute("CylicLimit1").Value, unit).ToString("0.##")}({unit})";

            lbs[i++].Text = Resources.UcSpec_SetCyclicFields_Limit_Type_;
            lbs[i++].Text = setPointType.ToString();

            lbs[i++].Text = Resources.UcSpec_SetCyclicFields_Limit_2_;
            lbs[i++].Text =
                $"{UnitManager.ConvertToCurrent(xElement.Attribute("CylicLimit2").Value, unit).ToString("0.##")}({unit})";

            lbs[i++].Text = Resources.UcSpec_SetCyclicFields_Limit_Time_;
            lbs[i++].Text = $"{xElement.Attribute("KeepTime").Value.ToDouble().ToString("0.##")}(min)";

            unit = xElement.Attribute("CyclicRateUnit").Value;
            lbs[i++].Text = Resources.UcSpec_Speed;
            lbs[i].Text =
                $"{UnitManager.ConvertToCurrent(xElement.Attribute("CyclcRate").Value, unit).ToString("0.##")}({unit})";

            PrintHeight = lbs[i].Location.Y + lbs[i].Height + 10;
        }

        private void SetStepFields(XElement xElement)
        {
            foreach (var lb in lbs)
                lb.Text = "";
            var i = 0;
            var steps = xElement.Descendants("Step").ToList();
            try
            {
                for (var j = 0; j < steps.Count(); j++)
                {
                    var rateType = steps[j].Attribute("Ctrl").Value;
                    var rateUnit = steps[j].Attribute("Unit").Value;
                    var rate = steps[j].Attribute("Rate").Value.ToDouble().ToString("0.##");
                    var setType = steps[j].Attribute("LimitType").Value;
                    var setUnit = steps[j].Attribute("LUnit").Value;
                    var set = steps[j].Attribute("Limit").Value.ToDouble().ToString("0.##");
                    var act = steps[j].Attribute("Action").Value;

                    lbs[i++].Text = Resources.UcSpec_SetStepFields_Step__j___1__;
                    lbs[i++].Text = string.Format(Resources.UcSpec_SetStepFields_Limit___0___1__, set, setUnit) + ", " +
                                    string.Format(Resources.UcSpec_SetStepFields_Speed___0___1__, rate, rateUnit) + ", " + 
                                    string.Format(Resources.UcSpec_SetStepFields_Action___0_, act);
                    i += 2;
                }

                PrintHeight = lbs[i - 2].Location.Y + lbs[i].Height + 10;
            }
            catch { }

        }
        private void SetCreepFields(XElement xElement)
        {
            foreach (var lb in lbs)
                lb.Text = "";

            var i = 0;

            lbs[i++].Text = @"Load Set:";
            var setPointType = (TestControlMode)Enum.Parse(typeof(TestControlMode), xElement.Attribute("CreepSetPointType").Value);
            var unit = UnitManager.GetUnit(setPointType);

            lbs[i++].Text =
                $"{setPointType}: {UnitManager.ConvertToCurrent(xElement.Attribute("CreepSetPoint").Value, unit)}({unit})";

            lbs[i++].Text = @"Loading Time:";
            lbs[i++].Text = "n/a";

            lbs[i++].Text = @"Loading Ctrl Type:";
            unit = xElement.Attribute("CreepRateUnit").Value;
            lbs[i++].Text = $"{UnitManager.ConvertToCurrent(xElement.Attribute("CreepRate").Value, unit).ToString("0.####")}({unit})";

            lbs[i++].Text = @"Keeping Time:";

            var st = $"{xElement.Attribute("CreepStablizeTime").Value.ToDouble().ToString("0.##")}(min)";
            double.TryParse(st, out StablizTime);
            lbs[i++].Text = st;


            lbs[i++].Text = @"Test Time:";
            unit = "min";
            lbs[i++].Text = $"{UnitManager.ConvertToCurrent(xElement.Attribute("CreepTestTime").Value.ToInt32(), unit).ToString("0.##")}({unit})";

            lbs[i++].Text = @"Extension @ Initial of Test:";
            lbs[i].Text = "n/a";

            PrintHeight = lbs[i].Location.Y + lbs[i].Height + 10;
        }
        public void SetCreepParams(string time, string extension)
        {
            lbs[3].Text = time;
            lbs[11].Text = extension;
        }
        private void SetRelaxationFields(XElement xElement)
        {
            foreach (var lb in lbs)
                lb.Text = "";

            var i = 0;

            lbs[i++].Text = @"Load Set:";
            var setPointType = (TestControlMode)Enum.Parse(typeof(TestControlMode), xElement.Attribute("RelaxSetPointType").Value);
            var unit = UnitManager.GetUnit(setPointType);

            lbs[i++].Text = $"{setPointType}: {UnitManager.ConvertToCurrent(xElement.Attribute("RelaxSetPoint").Value, unit).ToString("0.####")}({unit})";

            lbs[i++].Text = @"Loading Time:";
            lbs[i++].Text = "n/a";

            lbs[i++].Text = @"Loading Ctrl Type:";
            unit = xElement.Attribute("RelaxRateUnit").Value;
            lbs[i++].Text = $"{UnitManager.ConvertToCurrent(xElement.Attribute("RelaxRate").Value, unit).ToString("0.####")}({unit})";

            lbs[i++].Text = @"Keeping Time:";
            var st = $"{xElement.Attribute("RelaxStablizeTime").Value.ToDouble().ToString("0.##")}(min)";
            double.TryParse(st, out StablizTime);
            lbs[i++].Text = st;

            unit = "min";
            lbs[i++].Text = @"Test Time:";
            lbs[i++].Text = string.Format("{0}({1})", xElement.Attribute("RelaxTestTime").Value.ToDouble().ToString("0.##"), unit);
           
            lbs[i++].Text = @"Test Control Type:";
            lbs[i++].Text = (setPointType == TestControlMode.Force || setPointType == TestControlMode.Stress ? TestControlMode.Extension : setPointType).ToString();

            lbs[i++].Text = @"Extension @ Initial of Test:";
            lbs[i++].Text = "n/a";

            lbs[i++].Text = @"Force @ Initial of Test:";
            lbs[i].Text = "n/a";

            PrintHeight = lbs[i].Location.Y + lbs[i].Height + 10;
        }

        public void SetRelaxParams(string time, string force, string extension)
        {
            lbs[3].Text = time;
            lbs[13].Text = extension;
            lbs[15].Text = force;
        }

        private void SetPoses()
        {
            lbV1.Location = new Point(lbP1.Location.X + lbP1.Width + 5, lbV1.Location.Y);
            lbV2.Location = new Point(lbP2.Location.X + lbP2.Width + 5, lbV2.Location.Y);
            lbV3.Location = new Point(lbP3.Location.X + lbP3.Width + 5, lbV3.Location.Y);
            lbV4.Location = new Point(lbP4.Location.X + lbP4.Width + 5, lbV4.Location.Y);
            lbV5.Location = new Point(lbP5.Location.X + lbP5.Width + 5, lbV5.Location.Y);
            lbV6.Location = new Point(lbP6.Location.X + lbP6.Width + 5, lbV6.Location.Y);
            lbV7.Location = new Point(lbP7.Location.X + lbP7.Width + 5, lbV7.Location.Y);
            lbV8.Location = new Point(lbP8.Location.X + lbP8.Width + 5, lbV8.Location.Y);
            lbV9.Location = new Point(lbP9.Location.X + lbP9.Width + 5, lbV9.Location.Y);
            lbV10.Location = new Point(lbP10.Location.X + lbP10.Width + 5, lbV10.Location.Y);
            lbV11.Location = new Point(lbP11.Location.X + lbP11.Width + 5, lbV11.Location.Y);
            lbV12.Location = new Point(lbP12.Location.X + lbP12.Width + 5, lbV12.Location.Y);
            lbV13.Location = new Point(lbP13.Location.X + lbP13.Width + 5, lbV13.Location.Y);
        }

        internal void SetTestName(string selected)
        {
            lbTestName.Text = selected;
        }

        internal void Multiple()
        {
            
        }

        internal void CancelMultiple()
        {
          
        }

        private void UcSpec_Load(object sender, EventArgs e)
        {
            tcSpec.SelectedIndex = 1;
            tcSpec.SelectedIndex = 0;
        }


       
    }
}
