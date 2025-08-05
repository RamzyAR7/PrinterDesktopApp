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
    public partial class InvoiceForm : DevExpress.XtraEditors.XtraForm
    {
        private ShoppingDBEntities dbContext;
        private List<Invoice> allInvoices;
        private DataView invoiceView;
        
        public InvoiceForm()
        {
            InitializeComponent();
            dbContext = new ShoppingDBEntities();

            // Configure layout - same as ProductForm
            panelControl1.Dock = DockStyle.Top;

            // Set form to RTL
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            // Initialize components
            SetupSearchPanel();
            LoadInvoiceData();
            ConfigureGridView();

            // Handle window resize to adjust columns
            this.Resize += (s, e) => AdjustColumnWidths();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            // Already handled in constructor
        }

        private void SetupSearchPanel()
        {
            // Configure the panel - same as ProductForm
            panelControl1.Height = 50;
            panelControl1.Padding = new Padding(10);
            panelControl1.RightToLeft = RightToLeft.Yes;

            // Create search label
            var searchLabel = new LabelControl
            {
                Text = "بحث:",
                Appearance = { Font = new Font("Arial", 12, FontStyle.Bold) },
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(40, 24)
            };

            // Create search textbox
            var searchTextBox = new TextEdit
            {
                Properties =
                {
                    NullText = "ابحث عن رقم الفاتورة، اسم العميل، أو رقم الهاتف...",
                    Appearance = { 
                        TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Near },
                        Font = new Font("Arial", 12)
                    }
                },
                Size = new Size(400, 30)
            };

            // Position controls from right to left
            searchLabel.Location = new Point(panelControl1.Width - searchLabel.Width - 10, 12);
            searchTextBox.Location = new Point(panelControl1.Width - searchLabel.Width - searchTextBox.Width - 20, 10);

            // Handle search text changed
            searchTextBox.TextChanged += (s, e) =>
            {
                FilterInvoices(searchTextBox.Text);
            };

            // Add controls to panel
            panelControl1.Controls.Add(searchLabel);
            panelControl1.Controls.Add(searchTextBox);

            // Ensure search controls stay positioned on resize
            this.Resize += (s, e) =>
            {
                if (panelControl1.Width > 0)
                {
                    searchLabel.Location = new Point(panelControl1.Width - searchLabel.Width - 10, 12);
                    searchTextBox.Location = new Point(panelControl1.Width - searchLabel.Width - searchTextBox.Width - 20, 10);
                }
            };
        }

        private void LoadInvoiceData()
        {
            try
            {
                // Load all invoices that are not deleted
                allInvoices = dbContext.Invoices
                    .Where(i => !i.IsDeleted)
                    .OrderByDescending(i => i.InvoiceDate)
                    .ToList();

                // Create a DataTable for the grid - same structure as ProductForm
                var invoiceTable = CreateInvoiceDataTable();
                
                // Create DataView for filtering
                invoiceView = new DataView(invoiceTable);
                
                // Bind to the grid
                gridControl1.DataSource = invoiceView;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الفواتير: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateInvoiceDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("InvoiceNumber", typeof(string));
            table.Columns.Add("InvoiceDate", typeof(DateTime));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerPhone", typeof(string));
            table.Columns.Add("TotalAmount", typeof(decimal));

            foreach (var invoice in allInvoices)
            {
                table.Rows.Add(
                    invoice.Id,
                    invoice.InvoiceNumber,
                    invoice.InvoiceDate,
                    invoice.CustomerName,
                    invoice.CustomerPhone,
                    invoice.TotalAmount
                );
            }

            return table;
        }

        private void ConfigureGridView()
        {
            // Configure grid view columns with Arabic headers - same style as ProductForm
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

            // Set Arabic captions
            gridView1.Columns["InvoiceNumber"].Caption = "رقم الفاتورة";
            gridView1.Columns["InvoiceDate"].Caption = "تاريخ الفاتورة";
            gridView1.Columns["CustomerName"].Caption = "اسم العميل";
            gridView1.Columns["CustomerPhone"].Caption = "رقم الهاتف";
            gridView1.Columns["TotalAmount"].Caption = "المبلغ الإجمالي";

            // Configure grid view appearance - same as ProductForm
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.OptionsView.ShowGroupPanel = false;

            // Set the right-to-left reading order for Arabic text
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(242, 242, 242);

            // Increase row height
            gridView1.RowHeight = 30;

            // Format date column
            gridView1.Columns["InvoiceDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["InvoiceDate"].DisplayFormat.FormatString = "yyyy-MM-dd";

            // Format amount column with thousands separator
            gridView1.Columns["TotalAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["TotalAmount"].DisplayFormat.FormatString = "N0";

            // Configure grid appearance
            gridView1.Appearance.HeaderPanel.Font = new Font(gridView1.Appearance.HeaderPanel.Font.FontFamily, 12, FontStyle.Bold);
            gridView1.Appearance.Row.Font = new Font(gridView1.Appearance.Row.Font.FontFamily, 11);

            // Configure auto-sizing options
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.BestFitColumns();

            // Set column width proportions
            AdjustColumnWidths();
        }

        private void AdjustColumnWidths()
        {
            if (gridControl1.Width <= 0) return;

            try
            {
                // Set proportional widths like ProductForm
                int totalWidth = gridControl1.Width - 60; // Account for scrollbar and padding
                
                gridView1.Columns["InvoiceNumber"].Width = (int)(totalWidth * 0.15); // 15%
                gridView1.Columns["InvoiceDate"].Width = (int)(totalWidth * 0.15);   // 15%
                gridView1.Columns["CustomerName"].Width = (int)(totalWidth * 0.35);  // 35%
                gridView1.Columns["CustomerPhone"].Width = (int)(totalWidth * 0.20); // 20%
                gridView1.Columns["TotalAmount"].Width = (int)(totalWidth * 0.15);   // 15%
            }
            catch (Exception)
            {
                // Ignore any errors during width adjustment
            }
        }

        private void FilterInvoices(string searchText)
        {
            if (invoiceView == null) return;

            searchText = searchText?.Trim().ToLower() ?? "";
            
            if (string.IsNullOrEmpty(searchText))
            {
                invoiceView.RowFilter = "";
            }
            else
            {
                // Filter by invoice number, customer name, or phone
                invoiceView.RowFilter = $"InvoiceNumber LIKE '%{searchText}%' OR CustomerName LIKE '%{searchText}%' OR CustomerPhone LIKE '%{searchText}%'";
            }
        }

        private void InvoiceBtn_Click(object sender, EventArgs e)
        {
            var invoicePreview = new InvoicePreviewForm();
            invoicePreview.ShowDialog(this);
        }

        private void InvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }
        }
    }
}