using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DesktopApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class ProductForm : XtraForm
    {
        private DataSet.Product productDataSet = new DataSet.Product();
        private ShoppingDBEntities dbContext;
        private DataView productView;

        public ProductForm()
        {
            InitializeComponent();
            dbContext = new ShoppingDBEntities();

            // Configure layout
            productPanal.Dock = DockStyle.Top;

            // Set form to RTL
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            // Initialize components
            SetupSearchPanel();
            
            // Load data asynchronously
            LoadDataAsync();
            
            SetupCrudButtons();

            // Handle window resize to adjust columns
            this.Resize += (s, e) => AdjustColumnWidths();
        }

        /// <summary>
        /// Asynchronously loads all product data
        /// </summary>
        private async void LoadDataAsync()
        {
            await LoadingManager.ExecuteDatabaseOperationAsync(this, LoadProductDataAsync, DatabaseOperationType.Load);
            // Configure grid view after data is loaded
            ConfigureGridView();
        }

        private void SetupSearchPanel()
        {
            // Configure the product panel with reduced height for single row layout
            productPanal.Height = 50; // Reduced height
            productPanal.Padding = new Padding(5);
            productPanal.RightToLeft = RightToLeft.Yes;

            // Resize and reposition existing buttons to be smaller and on the left
            ResizeAndRepositionButtons();

            // Create search label
            var searchLabel = new LabelControl
            {
                Text = "بحث:",
                Appearance = { Font = new Font("Arial", 10, FontStyle.Bold) },
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(35, 20)
            };

            // Create search textbox
            var searchTextBox = new TextEdit
            {
                Properties =
                {
                    NullText = "ابحث عن اسم المنتج، الشركة، أو الصنف...",
                    Appearance = { 
                        TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Near },
                        Font = new Font("Arial", 10)
                    }
                },
                Size = new Size(300, 25)
            };

            // Position search controls on the right side of the panel
            searchLabel.Location = new Point(productPanal.Width - searchLabel.Width - 10, 15);
            searchTextBox.Location = new Point(productPanal.Width - searchLabel.Width - searchTextBox.Width - 20, 13);

            // Handle search text changed
            searchTextBox.TextChanged += (s, e) =>
            {
                if (productView != null)
                {
                    string searchText = searchTextBox.Text.Trim();
                    string filter = string.Empty;

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        filter = $"ProductName LIKE '%{searchText}%' OR CompanyName LIKE '%{searchText}%' OR CategoryName LIKE '%{searchText}%'";
                    }

                    productView.RowFilter = filter;
                }
            };

            // Handle panel resize to maintain RTL layout
            productPanal.Resize += (s, e) =>
            {
                searchLabel.Location = new Point(productPanal.Width - searchLabel.Width - 10, 15);
                searchTextBox.Location = new Point(productPanal.Width - searchLabel.Width - searchTextBox.Width - 20, 13);
            };

            // Add controls to panel
            productPanal.Controls.Add(searchTextBox);
            productPanal.Controls.Add(searchLabel);
        }

        private void ResizeAndRepositionButtons()
        {
            // Make buttons smaller and position them on the left side
            var buttonSize = new Size(120, 30);
            var yPosition = 10;
            var xStart = 10;

            // Resize and reposition New button only
            if (NewBtn != null)
            {
                NewBtn.Size = buttonSize;
                NewBtn.Location = new Point(xStart, yPosition);
                NewBtn.Text = "جديد";
            }
        }

        private async Task LoadProductDataAsync()
        {
            // Clear existing data
            productDataSet.Tables["Product"].Clear();
            
            // Simulate some processing time for demonstration
            await Task.Delay(500);
            
            // Get the products from database with the latest prices
            var products = await Task.Run(() =>
            {
                return dbContext.Products
                    .Select(p => new
                    {
                        p.Id,
                        ProductName = p.Name,
                        CompanyName = p.Company.Name,
                        CategoryName = p.Category.Name,
                        SellingPrice = p.Prices.OrderByDescending(pr => pr.CreatedDate).FirstOrDefault().SellingPrice,
                        PurchasingPrice = p.Prices.OrderByDescending(pr => pr.CreatedDate).FirstOrDefault().PurchasingPrice,
                        p.CreatedDate
                    })
                    .OrderByDescending(p => p.CreatedDate) // Newest first
                    .ToList();
            });

            // Add data to the dataset on UI thread
            foreach (var product in products)
            {
                var row = productDataSet.Tables["Product"].NewRow();
                row["Id"] = product.Id.ToString();
                row["ProductName"] = product.ProductName;
                row["CompanyName"] = product.CompanyName;
                row["CategoryName"] = product.CategoryName;
                row["SellingPrice"] = product.SellingPrice.ToString();
                row["PurchasingPrice"] = product.PurchasingPrice.ToString();
                row["CreatedDate"] = product.CreatedDate.ToString("yyyy-MM-dd");
                productDataSet.Tables["Product"].Rows.Add(row);
            }

            // Set up data view for searching
            productView = new DataView(productDataSet.Tables["Product"]);
            productGrid.DataSource = productView;
        }

        private void LoadProductData()
        {
            // Legacy synchronous method - kept for compatibility
            LoadDataAsync();
        }

        private void ConfigureGridView()
        {
            try
            {
                if (gridView1 == null || productGrid == null) return;

                // Configure grid view columns with Arabic headers
                if (gridView1.Columns["Id"] != null)
                    gridView1.Columns["Id"].Visible = false; // Hide ID column

                // Show row numbers
                gridView1.IndicatorWidth = 50;  // Width of the row numbers column
                gridView1.CustomDrawRowIndicator += (s, e) =>
                {
                    if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                };

                // Set Arabic captions if columns exist
                SetColumnCaption("ProductName", "اسم المنتج");
                SetColumnCaption("CategoryName", "الصنف");
                SetColumnCaption("CompanyName", "الشركة");
                SetColumnCaption("SellingPrice", "سعر بيع");
                SetColumnCaption("PurchasingPrice", "سعر شراء");
                SetColumnCaption("CreatedDate", "تاريخ الإضافة");

                // Configure grid view appearance
                gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.OptionsView.ShowGroupPanel = false;

                // Set the right-to-left reading order for Arabic text
                gridView1.OptionsView.EnableAppearanceEvenRow = true;
                gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(242, 242, 242);

                // Increase row height
                gridView1.RowHeight = 30;

                // Configure scrollbars for better navigation with large datasets
                gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
                gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
                gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
                gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
                
                // Enable smooth scrolling for better user experience
                gridView1.OptionsView.ShowIndicator = true; // Show row indicators (numbers)
                gridView1.OptionsNavigation.AutoFocusNewRow = true;
                gridView1.OptionsNavigation.UseTabKey = false; // Prevent tab from leaving grid
                
                // Make grid read-only - prevent inline editing
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView1.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
                gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
                
                // Configure grid control scrollbars as backup
                productGrid.UseEmbeddedNavigator = false; // We'll use scrollbars instead
                productGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
                productGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                productGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
                productGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                productGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;

                // Format price columns with thousands separator if they exist
                if (gridView1.Columns["SellingPrice"] != null)
                {
                    gridView1.Columns["SellingPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns["SellingPrice"].DisplayFormat.FormatString = "N0";
                }

                if (gridView1.Columns["PurchasingPrice"] != null)
                {
                    gridView1.Columns["PurchasingPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns["PurchasingPrice"].DisplayFormat.FormatString = "N0";
                }

                // Configure grid appearance
                gridView1.Appearance.HeaderPanel.Font = new Font(gridView1.Appearance.HeaderPanel.Font.FontFamily, 12, FontStyle.Bold);
                gridView1.Appearance.Row.Font = new Font(gridView1.Appearance.Row.Font.FontFamily, 11);

                // Configure auto-sizing options
                gridView1.OptionsView.ColumnAutoWidth = true;
                gridView1.BestFitColumns();

                // Set column width proportions
                AdjustColumnWidths();

                // Add keyboard navigation support for large datasets
                ConfigureKeyboardNavigation();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error configuring grid view: {ex.Message}");
                // Don't throw - this is called during initialization and we don't want to crash
            }
        }

        /// <summary>
        /// Configure keyboard navigation for efficient browsing of large datasets
        /// </summary>
        private void ConfigureKeyboardNavigation()
        {
            try
            {
                // Enable keyboard shortcuts for navigation
                gridView1.OptionsNavigation.EnterMoveNextColumn = false; // Enter stays in same column, moves to next row
                gridView1.OptionsNavigation.AutoMoveRowFocus = true; // Auto move focus when typing
                
                // Add keyboard event handlers for enhanced navigation
                gridView1.KeyDown += GridView1_KeyDown;
                
                // Configure selection behavior
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
                gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
                
                // Add status information for large datasets
                this.Text = $"المنتجات - عدد المنتجات: {gridView1.RowCount}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error configuring keyboard navigation: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle keyboard shortcuts for grid navigation
        /// </summary>
        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Home:
                        if (e.Control) // Ctrl+Home: Go to first row
                        {
                            gridView1.MoveFirst();
                            e.Handled = true;
                        }
                        break;
                    
                    case Keys.End:
                        if (e.Control) // Ctrl+End: Go to last row
                        {
                            gridView1.MoveLast();
                            e.Handled = true;
                        }
                        break;
                    
                    case Keys.PageUp:
                        // Page Up: Move up by visible row count
                        for (int i = 0; i < 10; i++)
                        {
                            if (gridView1.FocusedRowHandle > 0)
                                gridView1.FocusedRowHandle--;
                            else
                                break;
                        }
                        e.Handled = true;
                        break;
                    
                    case Keys.PageDown:
                        // Page Down: Move down by visible row count
                        for (int i = 0; i < 10; i++)
                        {
                            if (gridView1.FocusedRowHandle < gridView1.RowCount - 1)
                                gridView1.FocusedRowHandle++;
                            else
                                break;
                        }
                        e.Handled = true;
                        break;
                    
                    case Keys.F5:
                        // F5: Refresh data
                        _ = RefreshProductDataAsync(); // Fire and forget for F5 refresh
                        e.Handled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error handling key navigation: {ex.Message}");
            }
        }

        private void SetColumnCaption(string columnName, string caption)
        {
            if (gridView1?.Columns[columnName] != null)
            {
                gridView1.Columns[columnName].Caption = caption;
            }
        }

        private void AdjustColumnWidths()
        {
            if (productGrid?.Width <= 0 || gridView1 == null) return;

            try
            {
                // Calculate available width (excluding indicator column and vertical scrollbar)
                int scrollbarWidth = 20;
                int availableWidth = productGrid.Width - gridView1.IndicatorWidth - scrollbarWidth;

                // Define column proportions (total = 100)
                var columnProportions = new Dictionary<string, int>
                {
                    { "ProductName", 30 },      // 30%
                    { "CategoryName", 15 },     // 15%
                    { "CompanyName", 15 },      // 15%
                    { "SellingPrice", 13 },     // 13%
                    { "PurchasingPrice", 13 },  // 13%
                    { "CreatedDate", 14 }       // 14%
                };

                // Apply proportional widths
                foreach (var column in columnProportions)
                {
                    if (gridView1.Columns[column.Key] != null)
                    {
                        int width = (availableWidth * column.Value) / 100;
                        gridView1.Columns[column.Key].Width = width;
                    }
                }

                gridView1.OptionsView.ColumnAutoWidth = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adjusting column widths: {ex.Message}");
                // Don't throw - this is called during resize events
            }
        }

        private void productPanal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrintBarcodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the focused row handle
                int focusedRowHandle = gridView1.FocusedRowHandle;
                if (focusedRowHandle < 0)
                {
                    XtraMessageBox.Show("الرجاء اختيار منتج", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get product data from the focused row
                var productName = gridView1.GetRowCellValue(focusedRowHandle, "ProductName").ToString();
                var priceStr = gridView1.GetRowCellValue(focusedRowHandle, "SellingPrice").ToString();
                
                if (!decimal.TryParse(priceStr, out decimal sellingPrice))
                {
                    XtraMessageBox.Show("خطأ في قراءة سعر المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Show the copy selection form
                using (var copyForm = new BarcodeCopyForm())
                {
                    if (copyForm.ShowDialog() == DialogResult.OK)
                    {
                        int numberOfCopies = copyForm.NumberOfCopies;
                        
                        // Show loading message
                        this.Cursor = Cursors.WaitCursor;
                        
                        // Print silently
                        SilentPrintUtility.PrintBarcodeSilent(productName, sellingPrice, numberOfCopies);
                        
                        // Show success message
                        XtraMessageBox.Show($"تم طباعة {numberOfCopies} نسخة بنجاح", "نجحت العملية", 
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ في الطباعة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void SetupCrudButtons()
        {
            // Setup Create button (NewBtn)
            NewBtn.Click += BtnCreate_Click;
            
            // Configure button properties
            NewBtn.Appearance.Font = new Font("Tahoma", 10, FontStyle.Bold);
            
            // Set button colors
            NewBtn.Appearance.BackColor = Color.ForestGreen;
            NewBtn.Appearance.ForeColor = Color.White;

            // Add double-click to edit functionality
            gridView1.DoubleClick += gridView1_DoubleClick;
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Open create form
                using (var createForm = new ProductCUForm())
                {
                    if (createForm.ShowDialog() == DialogResult.OK && createForm.ProductSaved)
                    {
                        // Refresh the grid with loading indicator
                        await RefreshProductDataAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في إضافة منتج جديد: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RefreshProductDataAsync()
        {
            await LoadingManager.ExecuteDatabaseOperationAsync(this, async () =>
            {
                // Clear existing data
                productDataSet.Tables["Product"].Clear();
                
                // Reload data
                await LoadProductDataAsync();
                
                // Refresh the view on UI thread
                productView = new DataView(productDataSet.Tables["Product"]);
                productGrid.DataSource = productView;
                
                // Adjust columns
                AdjustColumnWidths();
                
            }, DatabaseOperationType.Load);
        }

        private void RefreshProductData()
        {
            // Legacy synchronous method - now calls async version
            Task.Run(async () => await RefreshProductDataAsync());
        }

        // Add double-click to open ActionForm with product actions
        private async void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Get the focused row handle
                int focusedRowHandle = gridView1.FocusedRowHandle;
                if (focusedRowHandle < 0)
                {
                    return; // No row selected
                }

                // Get product ID from the focused row
                var productIdObj = gridView1.GetRowCellValue(focusedRowHandle, "Id");
                if (productIdObj == null || !int.TryParse(productIdObj.ToString(), out int productId))
                {
                    XtraMessageBox.Show("خطأ في تحديد المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the full product from database
                using (var context = new ShoppingDBEntities())
                {
                    var product = context.Products.FirstOrDefault(p => p.Id == productId);
                    if (product == null)
                    {
                        XtraMessageBox.Show("المنتج غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Open ActionForm with the selected product
                    using (var actionForm = new ActionForm(product))
                    {
                        if (actionForm.ShowDialog() == DialogResult.OK || actionForm.ProductModified)
                        {
                            // Refresh the grid if product was modified
                            await RefreshProductDataAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في فتح المنتج: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
