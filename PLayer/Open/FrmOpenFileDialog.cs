using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.StmTest;
using STM.BLayer.TestSample;
using STM.DLayer;

namespace STM.PLayer.Open
{
    public partial class FrmOpenFileDialog : Form
    {
        public List<string> TestsPath { set; get; }

        private List<string> lastSelectedItems;

        public FrmOpenFileDialog()
        {
            InitializeComponent();
            lastSelectedItems = new List<string>(); 
            
            var rcm = new ComponentResourceManager(typeof(FrmOpenFileDialog));
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

        private void llOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestsPath = new List<string>();

            foreach (var item in flb.SelectedItems)
            {
                TestsPath.Add(flb.Path + '\\' + item);
            }
            DialogResult = DialogResult.OK;
            HideForm();
        }

        private void dirExplorer_PathChanged(object sender, System.EventArgs e)
        {
            flb.Pattern = "*.ttdx;*.ttd";
            flb.Path = dirExplorer.SelectedPath;
        }

        private void flb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                var item = LastSecltedItem();
                if (!string.IsNullOrEmpty(item))
                {
                    var path =  dirExplorer.SelectedPath + '\\' + item;
                    txtPath.Text = path;
                    TestingSample sample = null;
                    TestInformation testInfo = null;
                    TestMethodType testMethodType = 0;
                    string testName = "";
                    if (path.EndsWith(".ttd"))
                    {
                        testName = TestOpenSave.Current.ReadSpecification_PrevVersions(path, out sample, out testInfo, out testMethodType, true);
                    }
                    else if (path.EndsWith(".ttdx"))
                    {
                        testName = TestOpenSave.Current.ReadSpecification(path, out sample, out testInfo, out testMethodType, true);
                    }
                    if (!string.IsNullOrEmpty(testName))
                    {
                        txtMode.Text = testMethodType.ToString();
                        txtArea.Text = string.Format("{0:f03}", sample.Area);
                        txtComments.Lines = testInfo.Description;
                        txtCustomer.Text = testInfo.CustomerName;
                        txtDate.Text = testInfo.Date;
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        private string LastSecltedItem()
        {
            var retVal = "";
            try
            {
                var currentSelectedCollection = (from object selectedItem in flb.SelectedItems select selectedItem.ToString()).ToList();
                foreach (var item in currentSelectedCollection.Where(item => !lastSelectedItems.Contains(item)))
                {
                    lastSelectedItems = currentSelectedCollection.ToList();
                    retVal = item;
                    break;
                }

                if (string.IsNullOrEmpty(retVal))
                {
                    retVal = flb.SelectedItem.ToString();
                    lastSelectedItems = new List<string> { retVal };
                }
            }
            catch
            {
                return string.Empty;
            }

            return retVal;
        }

        //private void ConvertOldHeader(string path)
        //{
        //    var reader = new StreamReader(path);
        //    while (!reader.EndOfStream)
        //    {
        //        var header = reader.ReadLine().Trim().ToUpper();
        //        if (header.Equals("DATA"))
        //            break;

        //        switch (header)
        //        {
        //            case "SAMPLE":
        //                ReadOldSample(reader);
        //                break;

        //        }
        //    }
        //}

        //private TestingSample ReadOldSample(StreamReader reader)
        //{
        //    TestingSample testSampel = null;
        //    var secType = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //    if (secType[0].Equals("SecType"))
        //    {


        //        var Width = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var Width = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var Diameter = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var InnerDiam = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var Density = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var Weigh = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var GageLen = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var TotalLen = reader.ReadLine().ToUpper().Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        var SampleID = reader.ReadLine();

        //        switch (secType[1])
        //        {
        //            case "Rectangular":
        //                {
        //                    var th = double.Parse(Width[1]);
        //                    var wh = double.Parse(Width[1]);
        //                    var len = double.Parse(GageLen[1]);
        //                    var sampleArea = th * wh;
        //                    testSampel = new TestingSample(TensionCompressionSampleType.Rectangular, SampleID, len, wh, th, 0);
        //                }
        //                break;

        //            case "Diameter":
        //                {
        //                    var od = double.Parse(Diameter[1]);
        //                    var id = double.Parse(InnerDiam[1]);
        //                    var len = double.Parse(GageLen[1]);
        //                    var sampleArea = (od - id) * (od + id) * Math.PI / 4;
        //                    testSampel = new TestingSample(TensionCompressionSampleType.Pipe, SampleID, len, od, id, 0);
        //                }
        //                break;

        //            case "Weigh":
        //                {
        //                    var d = double.Parse(Density[1]);
        //                    var w = double.Parse(Weigh[1]);
        //                    var l = double.Parse(GageLen[1]);
        //                    var len = double.Parse(TotalLen[1]);
        //                    var sampleArea = w / (d * 1e-9 * len);
        //                    testSampel = new TestingSample(TensionCompressionSampleType.Weight, SampleID, l, d, w, len);
        //                }
        //                break;

        //            case "Area":
        //                {
        //                    var area = double.Parse(Width[1]);
        //                    var len = double.Parse(GageLen[1]);
        //                    testSampel = new TestingSample(TensionCompressionSampleType.Area, SampleID, len, area, 0, 0);
        //                }
        //                break;

        //            default:
        //                break;
        //        }

        //    }
        //    else return null;


        //    return testSampel;
        //}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult= DialogResult.Cancel;
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
