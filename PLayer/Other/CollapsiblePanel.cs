using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using STM.Properties;

namespace STM.PLayer.Other.CollapsiblePanel
{
    [Designer(typeof(CollapsiblePanelDesigner))]
    [ToolboxBitmap(typeof(CollapsiblePanel), "OVT.CustomControls.CollapsiblePanel.bmp")]
    [DefaultProperty("HeaderText")]
    public partial class CollapsiblePanel : Panel
    {

        #region "Private members"

        private bool collapse = false;
        private int originalHight = 0;
        private int headerCornersRadius = 10;
        private string headerText;
        private Color headerTextColor;
        private Color headerBackColor;
        private Image headerImage;
        private Font headerFont;
        private bool mouseDown;
        private Point mouseDownPoint;
        private Point mouseUpPoint;
        #endregion 


        
        #region "Public Properties"

        [Browsable(false)]
        public new Color BackColor
        {
            get
            {
                return Color.Transparent;

            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }

        [DefaultValue(false)]
        [Description("Collapses the control when set to true")]
        [Category("CollapsiblePanel")]
        public bool Collapse
        {
            get { return collapse; }
            set 
            {
                // If using animation make sure to ignore requests for collapse or expand while a previous
                // operation is in progress.
                collapse = value;
                CollapseOrExpand();
                Refresh();
            }
        }

        [DefaultValue(10)]
        [Category("CollapsiblePanel")]
        [Description("Top corners radius, it should be in [1, 15] range")]
        public int HeaderCornersRadius
        {
            get
            {
                return headerCornersRadius;
            }

            set
            {
                if (value < 1 || value > 15)
                    throw new ArgumentOutOfRangeException("HeaderCornersRadius", value, "Value should be in range [1, 90]");
                else
                {
                    headerCornersRadius = value;
                    Refresh();
                }
            }
        }

        [Category("CollapsiblePanel")]
        [Description("Text to show in panel's header")]
        public string HeaderText
        {
            get { return headerText; }
            set
            {
                headerText = value;
                Refresh();
            }
        }

        [Category("CollapsiblePanel")]
        [Description("Color of text header, and panel's borders when ShowHeaderSeparator is set to true")]
        public Color HeaderTextColor
        {
            get { return headerTextColor; }
            set
            {
                headerTextColor = value;
                Refresh();
            }
        }


        [Category("CollapsiblePanel")]
        [Description("Image that will be displayed in the top left corner of the panel")]
        public Image HeaderImage
        {
            get { return headerImage; }
            set
            {
                headerImage = value;
                Refresh();
            }
        }


        [Category("CollapsiblePanel")]
        [Description("The font used to display text in the panel's header.")]
        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value;
                Refresh();
            }
        }

        [Category("CollapsiblePanel")]
        [Description("Back Color of text header, and panel's borders when ShowHeaderSeparator is set to true")]
        public Color HeaderBackColor
        {
            get { return headerBackColor; }
            set
            {
                headerBackColor = value;
                Refresh();
            }
        }

        #endregion 


        public CollapsiblePanel()
        {
            InitializeComponent();
            pnlHeader.Width = Width -1;
            
            headerFont = new Font(Font, FontStyle.Bold);
            headerTextColor = Color.Black;
            headerBackColor = Color.FromArgb(150, 150, 255);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawHeaderPanel(e);
        }
        private void DrawHeaderPanel(PaintEventArgs e)
        {
            var headerRect = pnlHeader.ClientRectangle;
           
            using (var brush = new SolidBrush(headerBackColor))
            {
                e.Graphics.FillRectangle(brush, headerRect);
                e.Graphics.DrawRectangle(new Pen(headerTextColor), headerRect);
            }
          
            {
                var start = new Point(pnlHeader.Location.X, pnlHeader.Location.Y + pnlHeader.Height);
                var end = new Point(pnlHeader.Location.X + pnlHeader.Width, pnlHeader.Location.Y + pnlHeader.Height);
                e.Graphics.DrawLine(new Pen(headerTextColor, 2), start, end);
                var bodyRect = this.ClientRectangle;
                bodyRect.Y += this.pnlHeader.Height;
                bodyRect.Height -= (this.pnlHeader.Height + 1);
                bodyRect.Width -= 1;
                e.Graphics.DrawRectangle(new Pen(headerTextColor), bodyRect);
            }

            var headerRectHeight = pnlHeader.Height;
            if (headerImage != null)
            {
                pictureBoxImage.Image = headerImage;
                pictureBoxImage.Visible = true;
            }
            else
            {
                pictureBoxImage.Image = null;
                pictureBoxImage.Visible = false;
            }


            if (String.IsNullOrEmpty(headerText)) return;
            var offset = 10;
            if (headerImage != null)
            {
                offset = 10 + headerRectHeight;
            }
            var headerTextPosition = new PointF();
            var headerTextSize = TextRenderer.MeasureText(headerText, headerFont);
            headerTextPosition.X = (offset);
            headerTextPosition.Y = (headerRect.Height - headerTextSize.Height) / 2;
            e.Graphics.DrawString(headerText, headerFont, new SolidBrush(headerTextColor),
                                  headerTextPosition);
        }

        private void pictureBoxExpandCollapse_Click(object sender, EventArgs e)
        {
            Collapse = !Collapse;
        }

        private void CollapseOrExpand()
        {
            if (collapse)
            {
                originalHight = this.Height;
                Height = pnlHeader.Height;
                pictureBoxExpandCollapse.Image = Resources.expand;
            }
            else
            {
                Height = originalHight;
                pictureBoxExpandCollapse.Image = Resources.collapse;
            }
        }

        private void pictureBoxExpandCollapse_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxExpandCollapse.Image = !collapse ? Resources.collapse_hightlight : Resources.expand_highlight;
        }

        private void pictureBoxExpandCollapse_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxExpandCollapse.Image = !collapse ? Resources.collapse : Resources.expand;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            pnlHeader.Width = Width -1;
            Refresh();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            pnlHeader.Width = Width -1;
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!collapse)
            {
                if (Math.Abs(e.Y - Height) < 10)
                {
                    mouseDown = true;
                    Cursor = Cursors.SizeNS;
                    mouseDownPoint = e.Location;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (mouseDown)
            {
                mouseDown = false;
                Cursor = Cursors.Default;
                mouseUpPoint = e.Location;
            }
            if (!collapse)
            {
                var h = Height + (mouseUpPoint.Y - mouseDownPoint.Y);
                if (h >= MinimumSize.Height)
                    Height = h;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (Math.Abs(Control.MousePosition.Y - Height) < 10)
            {
                Cursor = Cursors.SizeNS;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = Math.Abs(e.Y - Height) > 10 ? Cursors.Default : Cursors.SizeNS;
        }

        private void pnlHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Collapse = !Collapse;
        }

    }
}
