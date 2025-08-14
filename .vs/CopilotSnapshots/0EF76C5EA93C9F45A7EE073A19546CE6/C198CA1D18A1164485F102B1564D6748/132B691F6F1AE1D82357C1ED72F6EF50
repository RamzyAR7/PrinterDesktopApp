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
    public partial class InvoiceActionForm : DevExpress.XtraEditors.XtraForm
    {
        private Invoice currentInvoice;
        private ShoppingDBEntities dbContext;
        public bool InvoiceModified { get; private set; } = false;

        public InvoiceActionForm(Invoice invoice)
        {
            InitializeComponent();
            currentInvoice = invoice;
            dbContext = new ShoppingDBEntities();
            
            SetupForm();
            LoadInvoiceInfo();
            WireUpEvents();
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
            this.Text = "إجراءات الفاتورة";
            
            // Adjust form size for better fit
            this.Size = new System.Drawing.Size(700, 250);
            this.MinimumSize = new System.Drawing.Size(700, 250);
            
            // Apply enhanced styling
            ApplyEnhancedStyling();
            
            // Adjust panel and buttons for better fit
            AdjustPanelAndButtons();
        }

        private void AdjustPanelAndButtons()
        {
            // Adjust panel to fit form better
            if (panelControl1 != null)
            {
                panelControl1.Dock = DockStyle.None;
                panelControl1.Location = new Point(20, 80);
                panelControl1.Size = new Size(this.ClientSize.Width - 40, 100);
                panelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }

            // Adjust buttons to fit panel evenly
            AdjustButtonLayout();
        }

        private void AdjustButtonLayout()
        {
            if (panelControl1 == null) return;

            var buttons = new[] { EditBtn, DeleteBtn, PreviewBtn, PrintBtn };
            int panelWidth = panelControl1.Width - 20; // Leave 10px margin on each side
            int buttonWidth = (panelWidth - 30) / 4; // 10px spacing between buttons
            int buttonHeight = 70;
            int yPosition = 15;

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != null)
                {
                    buttons[i].Size = new Size(buttonWidth, buttonHeight);
                    buttons[i].Location = new Point(10 + (i * (buttonWidth + 10)), yPosition);
                    buttons[i].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }
            }
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
            
            // Style the labels
            if (lblProductName != null)
            {
                lblProductName.Appearance.ForeColor = Color.FromArgb(52, 58, 64);
                lblProductName.Appearance.BackColor = Color.Transparent;
                lblProductName.BackColor = Color.Transparent;
                lblProductName.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            }

            if (labelControl1 != null)
            {
                labelControl1.Appearance.ForeColor = Color.FromArgb(52, 58, 64);
                labelControl1.Appearance.BackColor = Color.Transparent;
                labelControl1.BackColor = Color.Transparent;
                labelControl1.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            }
            
            // Apply button styling with proper colors
            StyleButton(EditBtn, Color.FromArgb(255, 193, 7), Color.FromArgb(33, 37, 41), "تعديل"); // Warning yellow
            StyleButton(DeleteBtn, Color.FromArgb(220, 53, 69), Color.White, "حذف"); // Danger red
            StyleButton(PreviewBtn, Color.FromArgb(23, 162, 184), Color.White, "معاينة"); // Info teal
            StyleButton(PrintBtn, Color.FromArgb(0, 123, 255), Color.White, "طباعة"); // Primary blue
        }
        
        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color backColor, Color foreColor, string text)
        {
            if (button != null)
            {
                button.Text = text;
                button.Appearance.BackColor = backColor;
                button.Appearance.ForeColor = foreColor;
                button.Appearance.Options.UseBackColor = true;
                button.Appearance.Options.UseForeColor = true;
                button.Appearance.BorderColor = backColor;
                button.Appearance.Options.UseBorderColor = true;
                button.LookAndFeel.SkinName = "Office 2019 Colorful";
                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                button.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);

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

        private void WireUpEvents()
        {
            // Wire up button events
            if (EditBtn != null)
                EditBtn.Click += EditBtn_Click;
            
            if (DeleteBtn != null)
                DeleteBtn.Click += DeleteBtn_Click;
            
            if (PreviewBtn != null)
                PreviewBtn.Click += PreviewBtn_Click;
            
            if (PrintBtn != null)
                PrintBtn.Click += PrintBtn_Click;

            // Handle form resize to adjust buttons
            this.Resize += InvoiceActionForm_Resize;
        }

        private void InvoiceActionForm_Resize(object sender, EventArgs e)
        {
            // Readjust buttons when form is resized
            AdjustButtonLayout();
        }

        private void LoadInvoiceInfo()
        {
            if (currentInvoice != null)
            {
                // Update invoice number label
                if (lblProductName != null)
                {
                    lblProductName.Text = $"رقم الفاتورة: {currentInvoice.InvoiceNumber}";
                }

                // Update customer name label
                if (labelControl1 != null)
                {
                    labelControl1.Text = $"اسم العميل: {currentInvoice.CustomerName}";
                }
            }
        }

        private void InvoiceActionForm_Load(object sender, EventArgs e)
        {
            LoadInvoiceInfo();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            // Empty - for designer compatibility
        }

        #region Button Event Handlers

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Open InvoiceCUForm in Edit mode
                using (var editForm = new InvoiceCUForm(currentInvoice.Id))
                {
                    if (editForm.ShowDialog() == DialogResult.OK && editForm.InvoiceSaved)
                    {
                        InvoiceModified = true;
                        // Refresh invoice info in case data changed
                        RefreshInvoiceInfo();
                        
                        XtraMessageBox.Show("تم تعديل الفاتورة بنجاح", 
                            "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تعديل الفاتورة: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (currentInvoice == null) return;

            var result = XtraMessageBox.Show($"هل أنت متأكد من حذف الفاتورة رقم '{currentInvoice.InvoiceNumber}'؟\n\nالعميل: {currentInvoice.CustomerName}\nالتاريخ: {currentInvoice.InvoiceDate.ToString("yyyy-MM-dd")}\n\nهذا الإجراء لا يمكن التراجع عنه.", 
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Remove the invoice from database
                    var invoiceToDelete = dbContext.Invoices.Find(currentInvoice.Id);
                    if (invoiceToDelete != null)
                    {
                        // Remove invoice items first
                        var invoiceItems = dbContext.InvoiceItems.Where(i => i.InvoiceId == invoiceToDelete.Id);
                        dbContext.InvoiceItems.RemoveRange(invoiceItems);
                        
                        // Remove the invoice
                        dbContext.Invoices.Remove(invoiceToDelete);
                        dbContext.SaveChanges();

                        XtraMessageBox.Show("تم حذف الفاتورة بنجاح", 
                            "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        InvoiceModified = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ في حذف الفاتورة: {ex.Message}", 
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (currentInvoice == null) return;

            try
            {
                // Open copy selection form to get number of copies
                using (var copyForm = new BarcodeCopyForm())
                {
                    if (copyForm.ShowDialog() == DialogResult.OK)
                    {
                        int numberOfCopies = copyForm.NumberOfCopies;
                        
                        // Show loading cursor
                        this.Cursor = Cursors.WaitCursor;
                        
                        // Perform silent printing
                        SilentPrintUtility.PrintInvoiceSilent(currentInvoice.Id, numberOfCopies);
                        
                        XtraMessageBox.Show($"تم طباعة {numberOfCopies} نسخة من الفاتورة رقم '{currentInvoice.InvoiceNumber}' بنجاح", 
                            "طباعة مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في الطباعة: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (currentInvoice == null) return;

            try
            {
                // Open invoice preview form with invoice data
                using (var previewForm = new InvoicePreviewForm(currentInvoice.Id))
                {
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في معاينة الفاتورة: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void RefreshInvoiceInfo()
        {
            try
            {
                // Refresh invoice data from database
                var refreshedInvoice = dbContext.Invoices.Find(currentInvoice.Id);
                if (refreshedInvoice != null)
                {
                    currentInvoice = refreshedInvoice;
                    LoadInvoiceInfo();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing invoice info: {ex.Message}");
            }
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {
            // Legacy event handler - keeping for compatibility
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}