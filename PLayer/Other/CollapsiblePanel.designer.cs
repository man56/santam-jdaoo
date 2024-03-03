namespace STM.PLayer.Other.CollapsiblePanel
{
    partial class CollapsiblePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBoxExpandCollapse = new System.Windows.Forms.PictureBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandCollapse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.pictureBoxExpandCollapse);
            this.pnlHeader.Controls.Add(this.pictureBoxImage);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(249, 30);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDoubleClick);
            // 
            // pictureBoxExpandCollapse
            // 
            this.pictureBoxExpandCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxExpandCollapse.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExpandCollapse.Image = global::STM.Properties.Resources.collapse;
            this.pictureBoxExpandCollapse.Location = new System.Drawing.Point(224, 5);
            this.pictureBoxExpandCollapse.Name = "pictureBoxExpandCollapse";
            this.pictureBoxExpandCollapse.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxExpandCollapse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExpandCollapse.TabIndex = 2;
            this.pictureBoxExpandCollapse.TabStop = false;
            this.pictureBoxExpandCollapse.Click += new System.EventHandler(this.pictureBoxExpandCollapse_Click);
            this.pictureBoxExpandCollapse.MouseLeave += new System.EventHandler(this.pictureBoxExpandCollapse_MouseLeave);
            this.pictureBoxExpandCollapse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxExpandCollapse_MouseMove);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Visible = false;
            // 
            // CollapsiblePanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlHeader);
            this.Size = new System.Drawing.Size(250, 150);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandCollapse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pictureBoxExpandCollapse;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}
