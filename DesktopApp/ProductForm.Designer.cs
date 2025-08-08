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
        private void InitializeComponent()
        {
            this.productPanal = new DevExpress.XtraEditors.PanelControl();
            this.NewBtn = new DevExpress.XtraEditors.SimpleButton();
            this.productGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.productPanal)).BeginInit();
            this.productPanal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // productPanal
            // 
            this.productPanal.Controls.Add(this.NewBtn);
            this.productPanal.Dock = System.Windows.Forms.DockStyle.Top;
            this.productPanal.Location = new System.Drawing.Point(0, 0);
            this.productPanal.Name = "productPanal";
            this.productPanal.Size = new System.Drawing.Size(1031, 50);
            this.productPanal.TabIndex = 0;
            // 
            // NewBtn
            // 
            this.NewBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.NewBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.NewBtn.Appearance.Options.UseBackColor = true;
            this.NewBtn.Appearance.Options.UseFont = true;
            this.NewBtn.Location = new System.Drawing.Point(10, 10);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(160, 30);
            this.NewBtn.TabIndex = 0;
            this.NewBtn.Text = "جديد";
            // 
            // productGrid
            // 
            this.productGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productGrid.Location = new System.Drawing.Point(0, 50);
            this.productGrid.MainView = this.gridView1;
            this.productGrid.Name = "productGrid";
            this.productGrid.Size = new System.Drawing.Size(1031, 483);
            this.productGrid.TabIndex = 1;
            this.productGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.productGrid;
            this.gridView1.Name = "gridView1";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 533);
            this.Controls.Add(this.productGrid);
            this.Controls.Add(this.productPanal);
            this.Name = "ProductForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "المنتجات";
            ((System.ComponentModel.ISupportInitialize)(this.productPanal)).EndInit();
            this.productPanal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region UI Configuration Methods

        /// <summary>
        /// Configures the basic form layout and properties
        /// </summary>
        private void ConfigureFormLayout()
        {
            // Configure layout
            productPanal.Dock = System.Windows.Forms.DockStyle.Top;

            // Set form to RTL
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
        }

        /// <summary>
        /// Sets up enhanced button styling
        /// </summary>
        private void SetupEnhancedButtons()
        {
            // Enhanced button styling with modern appearance
            System.Drawing.Font buttonFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            
            // Enhanced New/Create button styling
            StyleEnhancedButton(NewBtn, buttonFont, 
                System.Drawing.Color.FromArgb(40, 167, 69),    // Success green background
                System.Drawing.Color.White,                    // White text
                System.Drawing.Color.FromArgb(52, 181, 85),    // Lighter green hover
                System.Drawing.Color.FromArgb(34, 139, 57),    // Darker green pressed
                "✚ إضافة");                    // Icon + text
            
            // Note: Action buttons (Edit, Delete, Print, Barcode) are now handled by ActionForm on double-click

            // Note: PrintBarcodeBtn not currently implemented
            // StyleEnhancedButton(PrintBarcodeBtn, buttonFont,
            //     System.Drawing.Color.FromArgb(23, 162, 184),   // Info cyan background
            //     System.Drawing.Color.White,                    // White text
            //     System.Drawing.Color.FromArgb(58, 176, 195),   // Lighter cyan hover
            //     System.Drawing.Color.FromArgb(14, 123, 140),   // Darker cyan pressed
            //     "🖨 طباعة");                   // Icon + text
        }

        /// <summary>
        /// Applies enhanced styling to a button
        /// </summary>
        private void StyleEnhancedButton(DevExpress.XtraEditors.SimpleButton button, System.Drawing.Font font, 
            System.Drawing.Color backgroundColor, System.Drawing.Color textColor, System.Drawing.Color hoverColor, System.Drawing.Color pressedColor, string text = null)
        {
            if (button == null) return;

            // Set button text if provided
            if (!string.IsNullOrEmpty(text))
                button.Text = text;

            // Enhanced button appearance
            button.Appearance.Font = font;
            button.Appearance.Options.UseFont = true;
            button.Appearance.BackColor = backgroundColor;
            button.Appearance.ForeColor = textColor;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.BorderColor = backgroundColor;
            button.Appearance.Options.UseBorderColor = true;
            
            // Modern button styling
            button.LookAndFeel.SkinName = "Office 2019 Colorful";
            button.Height = 45; // Increased height for better visibility
            button.Width = System.Math.Max(button.Width, 100); // Minimum width
            
            // Text alignment and padding
            button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            
            // Add rounded corners effect through border styling
            button.Appearance.BorderColor = System.Drawing.Color.FromArgb(System.Math.Max(0, backgroundColor.R - 30),
                                                          System.Math.Max(0, backgroundColor.G - 30),
                                                          System.Math.Max(0, backgroundColor.B - 30));
            
            // Enhanced hover effects
            button.AppearanceHovered.BackColor = hoverColor;
            button.AppearanceHovered.ForeColor = textColor;
            button.AppearanceHovered.BorderColor = hoverColor;
            button.AppearanceHovered.Options.UseBackColor = true;
            button.AppearanceHovered.Options.UseForeColor = true;
            button.AppearanceHovered.Options.UseBorderColor = true;
            
            // Enhanced pressed effects
            button.AppearancePressed.BackColor = pressedColor;
            button.AppearancePressed.ForeColor = textColor;
            button.AppearancePressed.BorderColor = pressedColor;
            button.AppearancePressed.Options.UseBackColor = true;
            button.AppearancePressed.Options.UseForeColor = true;
            button.AppearancePressed.Options.UseBorderColor = true;
            
            // Disabled state styling
            button.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            button.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(173, 181, 189);
            button.AppearanceDisabled.BorderColor = System.Drawing.Color.FromArgb(108, 117, 125);
            button.AppearanceDisabled.Options.UseBackColor = true;
            button.AppearanceDisabled.Options.UseForeColor = true;
            button.AppearanceDisabled.Options.UseBorderColor = true;

            // Add subtle shadow effect through border
            button.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            
            // Ensure button is visible and properly configured
            button.Visible = true;
            button.Enabled = true;
            button.BringToFront();
            
            // Add mouse enter/leave events for additional visual feedback
            button.MouseEnter += (s, e) => {
                button.Cursor = System.Windows.Forms.Cursors.Hand;
            };
            
            button.MouseLeave += (s, e) => {
                button.Cursor = System.Windows.Forms.Cursors.Default;
            };
        }

        #endregion

        private DevExpress.XtraGrid.GridControl productGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl productPanal;
        private DevExpress.XtraEditors.SimpleButton NewBtn;
    }
}