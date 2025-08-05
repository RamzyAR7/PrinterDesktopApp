namespace DesktopApp
{
    partial class MainForm
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
            this.btnProduct = new DevExpress.XtraEditors.SimpleButton();
            this.btnInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.panelMainContainer = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelMainContainer)).BeginInit();
            this.panelMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnProduct.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Appearance.Options.UseBackColor = true;
            this.btnProduct.Appearance.Options.UseFont = true;
            this.btnProduct.Location = new System.Drawing.Point(7, 5);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(392, 46);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "المنتجات";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnInvoice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.Appearance.Options.UseBackColor = true;
            this.btnInvoice.Appearance.Options.UseFont = true;
            this.btnInvoice.AutoWidthInLayoutControl = true;
            this.btnInvoice.ImageOptions.ImageUri.Uri = "dashboards/insertlistbox";
            this.btnInvoice.Location = new System.Drawing.Point(406, 8);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(383, 44);
            this.btnInvoice.TabIndex = 1;
            this.btnInvoice.Text = "الفواتير";
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainContainer.Controls.Add(this.pictureBox1);
            this.panelMainContainer.Location = new System.Drawing.Point(3, 74);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(788, 400);
            this.panelMainContainer.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DesktopApp.Properties.Resources.error_img;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 396);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.Controls.Add(this.btnInvoice);
            this.panelControl1.Controls.Add(this.btnProduct);
            this.panelControl1.Location = new System.Drawing.Point(1, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl1.Size = new System.Drawing.Size(790, 61);
            this.panelControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 486);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelMainContainer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelMainContainer)).EndInit();
            this.panelMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnInvoice;
        private DevExpress.XtraEditors.SimpleButton btnProduct;
        private DevExpress.XtraEditors.PanelControl panelMainContainer;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

