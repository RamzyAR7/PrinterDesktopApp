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
    public partial class ProductCUForm : DevExpress.XtraEditors.XtraForm
    {
        public ShoppingDBEntities dbContext;
        private Product currentProduct;
        public bool ProductSaved { get; private set; } = false;

        public ProductCUForm()
        {
            InitializeComponent();
            dbContext = new ShoppingDBEntities();
            SetupForm();
            LoadComboBoxData();
            ConfigureScrolling();
            AdjustFormSize();
        }

        public ProductCUForm(int productId) : this()
        {
            LoadProductForEdit(productId);
        }

        private void SetupForm()
        {
            // Configure form for RTL
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            
            // Set form properties with better scaling
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoScaleMode = AutoScaleMode.Font;
            
            // Enable key preview for keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += ProductCUForm_KeyDown;
            
            // Set validation events
            SetupValidation();
            
            // Configure form appearance with larger font
            this.Appearance.Options.UseFont = true;
            this.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Regular);
            
            // Apply larger fonts to all controls
            SetupLargerFonts();
        }

        private void SetupLargerFonts()
        {
            // Set larger font for all text controls
            Font largeFont = new Font("Tahoma", 11F, FontStyle.Regular);
            Font labelFont = new Font("Tahoma", 10F, FontStyle.Regular);
            Font buttonFont = new Font("Tahoma", 10F, FontStyle.Bold);
            
            // Apply fonts to text controls
            if (txtProductName != null)
            {
                txtProductName.Font = largeFont;
                txtProductName.Properties.Appearance.Font = largeFont;
                txtProductName.Height = 28;
            }
            
            if (txtDescription != null)
            {
                txtDescription.Font = largeFont;
                txtDescription.Properties.Appearance.Font = largeFont;
                txtDescription.Height = 60;
            }
            
            // Apply fonts to price controls
            if (txtSellingPrice != null)
            {
                txtSellingPrice.Font = largeFont;
                txtSellingPrice.Properties.Appearance.Font = largeFont;
                txtSellingPrice.Height = 28;
            }
            
            if (txtPurchasingPrice != null)
            {
                txtPurchasingPrice.Font = largeFont;
                txtPurchasingPrice.Properties.Appearance.Font = largeFont;
                txtPurchasingPrice.Height = 28;
            }
            
            if (txtGomlaPrice != null)
            {
                txtGomlaPrice.Font = largeFont;
                txtGomlaPrice.Properties.Appearance.Font = largeFont;
                txtGomlaPrice.Height = 28;
            }
            
            if (txtNosGomlaPrice != null)
            {
                txtNosGomlaPrice.Font = largeFont;
                txtNosGomlaPrice.Properties.Appearance.Font = largeFont;
                txtNosGomlaPrice.Height = 28;
            }
            
            // Apply fonts to combo boxes
            if (cmbCompany != null)
            {
                cmbCompany.Font = largeFont;
                cmbCompany.Properties.Appearance.Font = largeFont;
                cmbCompany.Height = 28;
            }
            
            if (cmbCategory != null)
            {
                cmbCategory.Font = largeFont;
                cmbCategory.Properties.Appearance.Font = largeFont;
                cmbCategory.Height = 28;
            }
            
            // Apply fonts to buttons
            if (CreateBtn != null)
            {
                CreateBtn.Font = buttonFont;
                CreateBtn.Appearance.Font = buttonFont;
                CreateBtn.Height = 35;
            }
            
            if (EditBtn != null)
            {
                EditBtn.Font = buttonFont;
                EditBtn.Appearance.Font = buttonFont;
                EditBtn.Height = 35;
            }
            
            // Apply to group control
            if (groupControl1 != null)
            {
                groupControl1.Appearance.Options.UseFont = true;
                groupControl1.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
                groupControl1.AppearanceCaption.Font = new Font("Tahoma", 12F, FontStyle.Bold);
                groupControl1.AppearanceCaption.Options.UseFont = true;
            }
        }

        private void SetupValidation()
        {
            Font nullTextFont = new Font("Tahoma", 10F, FontStyle.Italic);
            
            // Make required fields mandatory with larger fonts
            txtProductName.Properties.NullText = "يرجى إدخال اسم المنتج";
            txtProductName.Properties.NullValuePrompt = "يرجى إدخال اسم المنتج";
            txtProductName.Properties.Appearance.Options.UseFont = true;
            
            cmbCompany.Properties.NullText = "يرجى اختيار الشركة";
            cmbCompany.Properties.Appearance.Options.UseFont = true;
            
            cmbCategory.Properties.NullText = "يرجى اختيار الصنف";
            cmbCategory.Properties.Appearance.Options.UseFont = true;
            
            // Set numeric validation for prices with larger fonts
            txtSellingPrice.Properties.MinValue = 0;
            txtSellingPrice.Properties.Appearance.Options.UseFont = true;
            
            txtPurchasingPrice.Properties.MinValue = 0;
            txtPurchasingPrice.Properties.Appearance.Options.UseFont = true;
            
            txtGomlaPrice.Properties.MinValue = 0;
            txtGomlaPrice.Properties.Appearance.Options.UseFont = true;
            
            txtNosGomlaPrice.Properties.MinValue = 0;
            txtNosGomlaPrice.Properties.Appearance.Options.UseFont = true;
        }

        private void ConfigureScrolling()
        {
            // Configure the scrollable control
            scrollableControl1.AutoScroll = true;
            scrollableControl1.HorizontalScroll.Enabled = false;
            scrollableControl1.HorizontalScroll.Visible = false;
            scrollableControl1.VerticalScroll.Enabled = true;
            scrollableControl1.VerticalScroll.Visible = true;
        }

        private void AdjustFormSize()
        {
            // Increase form size to accommodate larger fonts and controls
            if (this.Size.Width < 650)
                this.Width = 650;
            if (this.Size.Height < 550)
                this.Height = 550;
            
            // Ensure form is not larger than screen
            var screen = Screen.FromControl(this);
            if (this.Width > screen.WorkingArea.Width * 0.9)
                this.Width = (int)(screen.WorkingArea.Width * 0.9);
            if (this.Height > screen.WorkingArea.Height * 0.9)
                this.Height = (int)(screen.WorkingArea.Height * 0.9);
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Load companies with search functionality
                var companies = dbContext.Companies
                    .Where(c => !c.IsDeleted)
                    .Select(c => new { c.Id, c.Name })
                    .OrderBy(c => c.Name)
                    .ToList();
                
                cmbCompany.Properties.DataSource = companies;
                cmbCompany.Properties.DisplayMember = "Name";
                cmbCompany.Properties.ValueMember = "Id";
                cmbCompany.Properties.NullText = "اختر الشركة...";
                cmbCompany.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
                
                // Configure company dropdown for search (LookUpEdit properties)
                cmbCompany.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                cmbCompany.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                cmbCompany.Properties.AutoSearchColumnIndex = 1; // Search in Name column
                cmbCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                
                // Configure company dropdown columns (show only Name) with larger fonts
                cmbCompany.Properties.Columns.Clear();
                var companyColumn = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "اسم الشركة");
                companyColumn.Width = 250;
                cmbCompany.Properties.Columns.Add(companyColumn);
                cmbCompany.Properties.ShowHeader = true;
                cmbCompany.Properties.ShowFooter = false;
                cmbCompany.Properties.PopupWidth = 300;
                cmbCompany.Properties.DropDownRows = 10;
                
                // Set larger fonts for dropdown appearance
                cmbCompany.Properties.Appearance.Font = new Font("Tahoma", 11F, FontStyle.Regular);
                cmbCompany.Properties.Appearance.Options.UseFont = true;
                cmbCompany.Properties.AppearanceDropDown.Font = new Font("Tahoma", 11F, FontStyle.Regular);
                cmbCompany.Properties.AppearanceDropDown.Options.UseFont = true;
                cmbCompany.Properties.AppearanceDropDownHeader.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                cmbCompany.Properties.AppearanceDropDownHeader.Options.UseFont = true;

                // Load all categories without filtering by company
                var categories = dbContext.Categories
                    .Where(c => !c.IsDeleted)
                    .Select(c => new { c.Id, c.Name })
                    .OrderBy(c => c.Name)
                    .ToList();
                
                cmbCategory.Properties.DataSource = categories;
                cmbCategory.Properties.DisplayMember = "Name";
                cmbCategory.Properties.ValueMember = "Id";
                cmbCategory.Properties.NullText = "اختر الصنف...";
                cmbCategory.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
                
                // Configure category dropdown for search (LookUpEdit properties)
                cmbCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                cmbCategory.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                cmbCategory.Properties.AutoSearchColumnIndex = 1; // Search in Name column
                cmbCategory.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                
                // Configure category dropdown columns (show only Name) with larger fonts
                cmbCategory.Properties.Columns.Clear();
                var categoryColumn = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "اسم الصنف");
                categoryColumn.Width = 250;
                cmbCategory.Properties.Columns.Add(categoryColumn);
                cmbCategory.Properties.ShowHeader = true;
                cmbCategory.Properties.ShowFooter = false;
                cmbCategory.Properties.PopupWidth = 300;
                cmbCategory.Properties.DropDownRows = 10;
                
                // Set larger fonts for dropdown appearance
                cmbCategory.Properties.Appearance.Font = new Font("Tahoma", 11F, FontStyle.Regular);
                cmbCategory.Properties.Appearance.Options.UseFont = true;
                cmbCategory.Properties.AppearanceDropDown.Font = new Font("Tahoma", 11F, FontStyle.Regular);
                cmbCategory.Properties.AppearanceDropDown.Options.UseFont = true;
                cmbCategory.Properties.AppearanceDropDownHeader.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                cmbCategory.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductForEdit(int productId)
        {
            try
            {
                currentProduct = dbContext.Products
                    .FirstOrDefault(p => p.Id == productId);

                if (currentProduct != null)
                {
                    groupControl1.Text = "تعديل منتج";
                    CreateBtn.Visible = false;
                    EditBtn.Visible = true;

                    // Load product data
                    txtProductName.Text = currentProduct.Name;
                    cmbCompany.EditValue = currentProduct.CompanyId;
                    cmbCategory.EditValue = currentProduct.CategoryId;
                    txtDescription.Text = currentProduct.Description;

                    // Load latest price
                    var latestPrice = dbContext.Prices
                        .Where(p => p.ProductId == productId)
                        .OrderByDescending(p => p.CreatedDate)
                        .FirstOrDefault();

                    if (latestPrice != null)
                    {
                        txtSellingPrice.EditValue = latestPrice.SellingPrice;
                        txtPurchasingPrice.EditValue = latestPrice.PurchasingPrice;
                        txtGomlaPrice.EditValue = latestPrice.GomlaPrice;
                        txtNosGomlaPrice.EditValue = latestPrice.NosGomlaPrice;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل بيانات المنتج: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
                errors.Add("يرجى إدخال اسم المنتج");

            if (cmbCompany.EditValue == null)
                errors.Add("يرجى اختيار الشركة");

            if (cmbCategory.EditValue == null)
                errors.Add("يرجى اختيار الصنف");

            if (txtSellingPrice.Value <= 0)
                errors.Add("يرجى إدخال سعر بيع صحيح");

            if (txtPurchasingPrice.Value <= 0)
                errors.Add("يرجى إدخال سعر شراء صحيح");

            if (errors.Any())
            {
                XtraMessageBox.Show(string.Join("\n", errors), 
                    "بيانات مطلوبة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var newProduct = new Product
                {
                    Name = txtProductName.Text.Trim(),
                    CompanyId = Convert.ToInt32(cmbCompany.EditValue),
                    CategoryId = Convert.ToInt32(cmbCategory.EditValue),
                    Description = txtDescription.Text?.Trim(),
                    CreatedDate = DateTime.Now
                };

                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();

                // Add price record
                var price = new Price
                {
                    ProductId = newProduct.Id,
                    SellingPrice = txtSellingPrice.Value,
                    PurchasingPrice = txtPurchasingPrice.Value,
                    GomlaPrice = txtGomlaPrice.Value,
                    NosGomlaPrice = txtNosGomlaPrice.Value,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                dbContext.Prices.Add(price);
                dbContext.SaveChanges();

                ProductSaved = true;
                XtraMessageBox.Show("تم إضافة المنتج بنجاح", 
                    "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في إضافة المنتج: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateForm() || currentProduct == null) return;

            try
            {
                // Update product
                currentProduct.Name = txtProductName.Text.Trim();
                currentProduct.CompanyId = Convert.ToInt32(cmbCompany.EditValue);
                currentProduct.CategoryId = Convert.ToInt32(cmbCategory.EditValue);
                currentProduct.Description = txtDescription.Text?.Trim();

                // Deactivate old prices
                var oldPrices = dbContext.Prices.Where(p => p.ProductId == currentProduct.Id);
                foreach (var oldPrice in oldPrices)
                {
                    oldPrice.IsActive = false;
                }

                // Add new price record
                var newPrice = new Price
                {
                    ProductId = currentProduct.Id,
                    SellingPrice = txtSellingPrice.Value,
                    PurchasingPrice = txtPurchasingPrice.Value,
                    GomlaPrice = txtGomlaPrice.Value,
                    NosGomlaPrice = txtNosGomlaPrice.Value,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                dbContext.Prices.Add(newPrice);
                dbContext.SaveChanges();

                ProductSaved = true;
                XtraMessageBox.Show("تم تحديث المنتج بنجاح", 
                    "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحديث المنتج: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbCategory_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void chkOptional_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Handle keyboard shortcuts
        private void ProductCUForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + D = Diagnostic
            if (e.Control && e.KeyCode == Keys.D)
            {
                DiagnoseCategoryData();
                e.Handled = true;
            }
        }

        // Diagnostic method to check category data
        private void DiagnoseCategoryData()
        {
            try
            {
                using (var context = new ShoppingDBEntities())
                {
                    // Check total categories
                    var totalCategories = context.Categories.Count();
                    var activeCategories = context.Categories.Count(c => !c.IsDeleted);
                    var deletedCategories = context.Categories.Count(c => c.IsDeleted);

                    // Check categories per company
                    var companiesWithCategories = context.Categories
                        .Where(c => !c.IsDeleted)
                        .GroupBy(c => c.CompanyId)
                        .Select(g => new { CompanyId = g.Key, Count = g.Count() })
                        .ToList();

                    // Get company names
                    var companies = context.Companies
                        .Where(c => !c.IsDeleted)
                        .Select(c => new { c.Id, c.Name })
                        .ToList();

                    StringBuilder diagnosticMessage = new StringBuilder();
                    diagnosticMessage.AppendLine("تشخيص بيانات الأصناف:");
                    diagnosticMessage.AppendLine($"إجمالي الأصناف: {totalCategories}");
                    diagnosticMessage.AppendLine($"الأصناف النشطة: {activeCategories}");
                    diagnosticMessage.AppendLine($"الأصناف المحذوفة: {deletedCategories}");
                    diagnosticMessage.AppendLine();
                    diagnosticMessage.AppendLine("الأصناف حسب الشركة:");
                    
                    foreach (var company in companies)
                    {
                        var categoryCount = companiesWithCategories
                            .FirstOrDefault(c => c.CompanyId == company.Id)?.Count ?? 0;
                        diagnosticMessage.AppendLine($"- {company.Name}: {categoryCount} صنف");
                    }

                    // If no categories exist, suggest adding some
                    if (activeCategories == 0)
                    {
                        diagnosticMessage.AppendLine();
                        diagnosticMessage.AppendLine("لا توجد أصناف نشطة في قاعدة البيانات!");
                        diagnosticMessage.AppendLine("يرجى إضافة بعض الأصناف أولاً.");
                    }

                    XtraMessageBox.Show(diagnosticMessage.ToString(), "تشخيص بيانات الأصناف", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تشخيص البيانات: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductCUForm_Load(object sender, EventArgs e)
        {

        }
    }
}