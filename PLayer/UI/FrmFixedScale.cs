using System;
using System.Windows.Forms;

namespace STM.PLayer.UI
{
    public partial class FrmFixedScale : Form
    {
        ZoomFrame frame;
        int xGrids;
        int yGrids;
        public FrmFixedScale()
        {
            InitializeComponent();
        }

        public void SetFields(ZoomFrame zoomFrame, string xUnit, string yUnit, int xGridCount, int yGridCount)
        {
            try
            {
                txtDiagramMinX.Text = string.Format("{0:f03}", zoomFrame.MinX * zoomFrame.XM);
                txtDiagramMaxX.Text = string.Format("{0:f03}", zoomFrame.MaxX * zoomFrame.XM);
                txtDiagramXSteps.Text = xGridCount.ToString();

                lbDiagramXUnitMax.Text = xUnit;
                lbDiagramXUnitMin.Text = xUnit;

                txtDiagramMinY.Text = string.Format("{0:f03}", zoomFrame.MinY * zoomFrame.YM);
                txtDiagramMaxY.Text = string.Format("{0:f03}", zoomFrame.MaxY * zoomFrame.YM);
                txtDiagramYSteps.Text = yGridCount.ToString();

                lbDiagramYUnitMax.Text = yUnit;
                lbDiagramYUnitMin.Text = yUnit;
                frame = zoomFrame;
                xGrids = xGridCount;
                yGrids = yGridCount;
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        public ZoomFrame GetDiagramSetting()
        {
            var zoomFrame = new ZoomFrame
            {
                MinX = txtDiagramMinX.ValueInDouble / frame.XM,
                MaxX = txtDiagramMaxX.ValueInDouble / frame.XM,
                XSteps = txtDiagramXSteps.ValueInInt,

                MinY = txtDiagramMinY.ValueInDouble / frame.YM,
                MaxY = txtDiagramMaxY.ValueInDouble / frame.YM,
                YSteps = txtDiagramYSteps.ValueInInt,
            };

            return zoomFrame;
        }

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetFields(frame, lbDiagramXUnitMax.Text, lbDiagramYUnitMax.Text, xGrids, yGrids);
        }

        private void llOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
