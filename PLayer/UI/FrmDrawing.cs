using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace STM.PLayer.UI
{
    partial class FrmDrwaings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrwaings));
            this.llOpen = new System.Windows.Forms.LinkLabel();
            this.cbLineStyle = new System.Windows.Forms.ComboBox();
            this.lbxMarkers = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbColors = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // llOpen
            // 
            resources.ApplyResources(this.llOpen, "llOpen");
            this.llOpen.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llOpen.Name = "llOpen";
            this.llOpen.TabStop = true;
            this.llOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOk_LinkClicked);
            // 
            // cbLineStyle
            // 
            resources.ApplyResources(this.cbLineStyle, "cbLineStyle");
            this.cbLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLineStyle.FormattingEnabled = true;
            this.cbLineStyle.Name = "cbLineStyle";
            // 
            // lbxMarkers
            // 
            resources.ApplyResources(this.lbxMarkers, "lbxMarkers");
            this.lbxMarkers.BackColor = System.Drawing.SystemColors.Window;
            this.lbxMarkers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxMarkers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbxMarkers.FormattingEnabled = true;
            this.lbxMarkers.MultiColumn = true;
            this.lbxMarkers.Name = "lbxMarkers";
            this.lbxMarkers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxMarkers_DrawItem);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // lbColors
            // 
            resources.ApplyResources(this.lbColors, "lbColors");
            this.lbColors.BackColor = System.Drawing.SystemColors.Window;
            this.lbColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbColors.FormattingEnabled = true;
            this.lbColors.Name = "lbColors";
            this.lbColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbColors_DrawItem);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // FrmDrwaings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lbColors);
            this.Controls.Add(this.lbxMarkers);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbLineStyle);
            this.Controls.Add(this.llOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDrwaings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkLabel llOpen;
        private ComboBox cbLineStyle;
        private ListBox lbxMarkers;
        private Label label13;
        private Label label14;
        private ListBox lbColors;
        private Label label15;

    }
    public partial class FrmDrwaings : Form
    {

        public FrmDrwaings()
        {
            InitializeComponent();

            var markers = Enum.GetNames(typeof(Marker));
            lbxMarkers.Items.Clear();
            foreach (var m in markers)
                lbxMarkers.Items.Add(m);

            var colorNames = Enum.GetNames(typeof(KnownColor));
            foreach (var colorName in colorNames)
            {
                var knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
                if (knownColor > KnownColor.Transparent)
                {
                    lbColors.Items.Add(colorName);
                }
            }
            cbLineStyle.DataSource = new[] { "______", "_ _ _ _", "........", "_ . _. _" };
            cbLineStyle.SelectedIndex = 0;
            lbxMarkers.SelectedIndex = 0;
            lbColors.SelectedIndex = 0;
        }

        private void llOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DrawingColor = Color.FromName(lbColors.Text);
            DrawingMarker = (Marker)Enum.Parse(typeof(Marker), lbxMarkers.Text);
            switch (cbLineStyle.Text)
            {
                case "______": DrawingLineStyle = DashStyle.Solid; break;
                case "_ _ _ _": DrawingLineStyle = DashStyle.Dash; break;
                case "........": DrawingLineStyle = DashStyle.DashDotDot; break;
                case "_ . _. _": DrawingLineStyle = DashStyle.DashDot; break;
                default: DrawingLineStyle = DashStyle.Solid; break;
            }
            DialogResult = DialogResult.OK;
        }

        private void lbxMarkers_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            switch (lbxMarkers.Items[e.Index].ToString())
            {
                case "None":
                    break;

                case "Circle":
                    e.Graphics.DrawEllipse(Pens.Black, new Rectangle(e.Bounds.Left + e.Bounds.Width / 2 - 4, e.Bounds.Top + e.Bounds.Height / 2 - 4, 8, 8));
                    break;

                case "Square":
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.Left + e.Bounds.Width / 2 - 4, e.Bounds.Top + e.Bounds.Height / 2 - 4, 8, 8));
                    break;

                case "Star":
                    using (Brush brush = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString("*", e.Font, brush, new Rectangle(e.Bounds.Left + e.Bounds.Width / 2 - 8, e.Bounds.Top + e.Bounds.Height / 2 - 6, 10, 10));
                    }
                    break;

                case "Triangular":
                    var ps = new[]
                                             {
                                                 new PointF(e.Bounds.Left + e.Bounds.Width / 2, e.Bounds.Top + e.Bounds.Height / 2 - 4),
                                                 new PointF(e.Bounds.Left + e.Bounds.Width / 2 - 4,e.Bounds.Top + e.Bounds.Height / 2 + 4),
                                                 new PointF(e.Bounds.Left + e.Bounds.Width / 2 + 4, e.Bounds.Top + e.Bounds.Height / 2 + 4),
                                                 new PointF(e.Bounds.Left + e.Bounds.Width / 2 , e.Bounds.Top + e.Bounds.Height / 2 - 4)
                                             };
                    e.Graphics.DrawLines(Pens.Black, ps);
                    break;
            }
        }

        private void lbColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
            e.Graphics.FillRectangle(new SolidBrush(Color.FromName(lbColors.Items[e.Index].ToString())), e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 2, e.Bounds.Height - 2);

            e.Graphics.DrawString(lbColors.Items[e.Index].ToString(), e.Font, Brushes.Black, new RectangleF(e.Bounds.Height, e.Bounds.Top + 1, 200, e.Bounds.Height - 2), sf);
        }


        public Color DrawingColor { get; set; }

        public Marker DrawingMarker { get; set; }

        public DashStyle DrawingLineStyle { get; set; }
    }
}
