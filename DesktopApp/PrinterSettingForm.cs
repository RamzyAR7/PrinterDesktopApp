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
using System.Drawing.Printing;

namespace DesktopApp
{
    public partial class PrinterSettingForm : DevExpress.XtraEditors.XtraForm
    {
        public PrinterSettingForm()
        {
            InitializeComponent();
            
            LoadAvailablePrinters();
            LoadCurrentSettings();
            SetupEventHandlers();
        }

        private void LoadAvailablePrinters()
        {
            try
            {
                string[] availablePrinters = GetAvailablePrinters();
                
                // Load printers into both combo boxes
                comboBoxEdit1.Properties.Items.Clear();
                comboBoxEdit2.Properties.Items.Clear();
                
                comboBoxEdit1.Properties.Items.AddRange(availablePrinters);
                comboBoxEdit2.Properties.Items.AddRange(availablePrinters);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل قائمة الطابعات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentSettings()
        {
            // Load current printer settings
            comboBoxEdit1.Text = Properties.Settings.Default.InvoicePrinterName;
            comboBoxEdit2.Text = Properties.Settings.Default.BarcodePrinterName;
        }

        private void SetupEventHandlers()
        {
            // Save button (saves both printers at once)
            simpleButton1.Click += (s, e) => SaveAllPrinterSettings();
            
            // Cancel button
            simpleButton3.Click += (s, e) => this.Close();
        }

        private void SaveAllPrinterSettings()
        {
            try
            {
                bool hasChanges = false;
                
                // Save Invoice Printer
                string invoicePrinterName = comboBoxEdit1.Text.Trim();
                if (!string.IsNullOrEmpty(invoicePrinterName))
                {
                    if (!IsPrinterValid(invoicePrinterName))
                    {
                        var result = XtraMessageBox.Show($"الطابعة '{invoicePrinterName}' غير موجودة في النظام. هل تريد الحفظ على أي حال؟", 
                            "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (result == DialogResult.No)
                            return;
                    }
                    
                    Properties.Settings.Default.InvoicePrinterName = invoicePrinterName;
                    hasChanges = true;
                }

                // Save Barcode Printer
                string barcodePrinterName = comboBoxEdit2.Text.Trim();
                if (!string.IsNullOrEmpty(barcodePrinterName))
                {
                    if (!IsPrinterValid(barcodePrinterName))
                    {
                        var result = XtraMessageBox.Show($"الطابعة '{barcodePrinterName}' غير موجودة في النظام. هل تريد الحفظ على أي حال؟", 
                            "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (result == DialogResult.No)
                            return;
                    }
                    
                    Properties.Settings.Default.BarcodePrinterName = barcodePrinterName;
                    hasChanges = true;
                }

                if (hasChanges)
                {
                    Properties.Settings.Default.Save();
                    XtraMessageBox.Show("تم حفظ إعدادات الطابعات بنجاح", "نجح الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("يرجى اختيار طابعة واحدة على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ إعدادات الطابعات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string[] GetAvailablePrinters()
        {
            try
            {
                return PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
            }
            catch (Exception)
            {
                return new string[] { "No printers found" };
            }
        }

        private bool IsPrinterValid(string printerName)
        {
            if (string.IsNullOrEmpty(printerName))
                return false;

            try
            {
                return PrinterSettings.InstalledPrinters.Cast<string>()
                    .Any(p => p.Equals(printerName, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}