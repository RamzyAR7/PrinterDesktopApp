using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class ActionForm : DevExpress.XtraEditors.XtraForm
    {
        private Product currentProduct;
        private ShoppingDBEntities dbContext;
        public bool ProductModified { get; private set; } = false;

        public ActionForm(Product product)
        {
            InitializeComponent();
            currentProduct = product;
            dbContext = new ShoppingDBEntities();
            
            SetupForm();
            LoadProductInfo();
        }

        private void SetupForm()
        {
            // Configure form for RTL
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            
            // Set form properties
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إجراءات المنتج";
            
            // Set improved form size to accommodate all buttons properly
            this.Size = new System.Drawing.Size(580, 220);
            this.MinimumSize = new System.Drawing.Size(580, 220);
            
            // Apply enhanced styling
            ApplyEnhancedStyling();
        }

        private void ApplyEnhancedStyling()
        {
            // Set form background color
            this.BackColor = Color.FromArgb(248, 249, 250);
            
            // Style the panel
            if (panelControl1 != null)
            {
                panelControl1.BackColor = Color.White;
                panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                panelControl1.LookAndFeel.SkinName = "Office 2019 Colorful";
            }
            
            // Style the label
            if (lblProductName != null)
            {
                lblProductName.Appearance.ForeColor = Color.FromArgb(52, 58, 64);
                lblProductName.Appearance.BackColor = Color.Transparent;
                lblProductName.BackColor = Color.Transparent;
            }
            
            // Apply button styling
            StyleButton(EditBtn, Color.FromArgb(255, 193, 7), Color.FromArgb(33, 37, 41)); // Warning yellow
            StyleButton(DeleteBtn, Color.FromArgb(220, 53, 69), Color.White); // Danger red
            StyleButton(PreviewBtn, Color.FromArgb(23, 162, 184), Color.White); // Info teal
            StyleButton(PrintBtn, Color.FromArgb(0, 123, 255), Color.White); // Primary blue
        }
        
        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color backColor, Color foreColor)
        {
            if (button != null)
            {
                button.Appearance.BackColor = backColor;
                button.Appearance.ForeColor = foreColor;
                button.Appearance.Options.UseBackColor = true;
                button.Appearance.Options.UseForeColor = true;
                button.Appearance.BorderColor = backColor;
                button.Appearance.Options.UseBorderColor = true;
                button.LookAndFeel.SkinName = "Office 2019 Colorful";
                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                // Add hover effects
                button.AppearanceHovered.BackColor = Color.FromArgb(Math.Max(0, backColor.R - 20),
                                                                   Math.Max(0, backColor.G - 20),
                                                                   Math.Max(0, backColor.B - 20));
                button.AppearanceHovered.Options.UseBackColor = true;
                button.AppearancePressed.BackColor = Color.FromArgb(Math.Max(0, backColor.R - 40),
                                                                   Math.Max(0, backColor.G - 40),
                                                                   Math.Max(0, backColor.B - 40));
                button.AppearancePressed.Options.UseBackColor = true;
            }
        }

        private void LoadProductInfo()
        {
            if (currentProduct != null && lblProductName != null)
            {
                lblProductName.Text = $"المنتج: {currentProduct.Name}";
            }
        }

        private void ActionForm_Load(object sender, EventArgs e)
        {
            LoadProductInfo();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Button Event Handlers

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Edit button clicked
            EditBtn_Click(sender, e);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Open ProductCUForm in Edit mode
                using (var editForm = new ProductCUForm(currentProduct.Id))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        ProductModified = true;
                        // Refresh product info in case name changed
                        RefreshProductInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تعديل المنتج: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (currentProduct == null) return;

            var result = XtraMessageBox.Show($"هل أنت متأكد من حذف المنتج '{currentProduct.Name}'؟", 
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Remove the product from database
                    var productToDelete = dbContext.Products.Find(currentProduct.Id);
                    if (productToDelete != null)
                    {
                        dbContext.Products.Remove(productToDelete);
                        dbContext.SaveChanges();

                        XtraMessageBox.Show("تم حذف المنتج بنجاح", 
                            "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        ProductModified = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ في حذف المنتج: {ex.Message}", 
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (currentProduct == null) return;

            try
            {
                // Open barcode copy form to get number of copies
                using (var copyForm = new BarcodeCopyForm())
                {
                    if (copyForm.ShowDialog() == DialogResult.OK)
                    {
                        // Get current price for barcode printing
                        var currentPrice = dbContext.Prices
                            .Where(p => p.ProductId == currentProduct.Id && p.IsActive == true)
                            .OrderByDescending(p => p.CreatedDate)
                            .FirstOrDefault();

                        decimal sellingPrice = currentPrice?.SellingPrice ?? 0;
                        int numberOfCopies = copyForm.NumberOfCopies;

                        // Perform silent printing
                        SilentPrintUtility.PrintBarcodeSilent(currentProduct.Name, sellingPrice, numberOfCopies);
                        
                        XtraMessageBox.Show($"تم طباعة {numberOfCopies} نسخة من باركود المنتج '{currentProduct.Name}' بنجاح", 
                            "طباعة مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في الطباعة: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (currentProduct == null) return;

            try
            {
                // Get current price for barcode generation
                var currentPrice = dbContext.Prices
                    .Where(p => p.ProductId == currentProduct.Id && p.IsActive == true)
                    .OrderByDescending(p => p.CreatedDate)
                    .FirstOrDefault();

                decimal sellingPrice = currentPrice?.SellingPrice ?? 0;

                // Open barcode preview form with product details
                using (var barcodeForm = new ParcodePreviewForm(currentProduct.Name, sellingPrice))
                {
                    barcodeForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في عرض الباركود: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void RefreshProductInfo()
        {
            try
            {
                // Refresh product data from database
                var refreshedProduct = dbContext.Products.Find(currentProduct.Id);
                if (refreshedProduct != null)
                {
                    currentProduct = refreshedProduct;
                    LoadProductInfo();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing product info: {ex.Message}");
            }
        }

        ~ActionForm()
        {
            dbContext?.Dispose();
        }
    }
}
