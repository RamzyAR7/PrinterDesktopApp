namespace DesktopApp
{
    partial class ProductForm
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
        ///
        private void InitializeComponent()
        {
            this.productGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.productPanal = new DevExpress.XtraEditors.PanelControl();
            this.PrintBarcodeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.btnBarcode = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPanal)).BeginInit();
            this.productPanal.SuspendLayout();
            this.SuspendLayout();
            // 
            // productGrid
            // 
            this.productGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productGrid.Location = new System.Drawing.Point(0, 54);
            this.productGrid.MainView = this.gridView1;
            this.productGrid.Name = "productGrid";
            this.productGrid.Size = new System.Drawing.Size(1031, 479);
            this.productGrid.TabIndex = 0;
            this.productGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.productGrid;
            this.gridView1.Name = "gridView1";
            // 
            // productPanal
            // 
            this.productPanal.Controls.Add(this.PrintBarcodeBtn);
            this.productPanal.Controls.Add(this.btnBarcode);
            this.productPanal.Location = new System.Drawing.Point(0, 2);
            this.productPanal.Name = "productPanal";
            this.productPanal.Size = new System.Drawing.Size(1031, 46);
            this.productPanal.TabIndex = 1;
            this.productPanal.Paint += new System.Windows.Forms.PaintEventHandler(this.productPanal_Paint);
            // 
            // PrintBarcodeBtn
            // 
            this.PrintBarcodeBtn.Location = new System.Drawing.Point(177, 12);
            this.PrintBarcodeBtn.Name = "PrintBarcodeBtn";
            this.PrintBarcodeBtn.Size = new System.Drawing.Size(146, 29);
            this.PrintBarcodeBtn.TabIndex = 1;
            this.PrintBarcodeBtn.Text = "طباعة صامتة";
            this.PrintBarcodeBtn.Click += new System.EventHandler(this.PrintBarcodeBtn_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(12, 11);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(159, 29);
            this.btnBarcode.TabIndex = 0;
            this.btnBarcode.Text = "طباعة باركود";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // ProductForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 533);
            this.Controls.Add(this.productPanal);
            this.Controls.Add(this.productGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "المنتجات";
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPanal)).EndInit();
            this.productPanal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl productGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl productPanal;
        public DevExpress.XtraEditors.SimpleButton btnBarcode;
        private DevExpress.XtraEditors.SimpleButton PrintBarcodeBtn;
    }
}