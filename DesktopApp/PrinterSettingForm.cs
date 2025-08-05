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
            LoadCurrentSettings();
            SetupEventHandlers();
        }

        private void LoadCurrentSettings()
        {
            // Load current printer settings
            textBox1.Text = Properties.Settings.Default.InvoicePrinterName;
            textBox2.Text = Properties.Settings.Default.BarcodePrinterName;
        }

        private void SetupEventHandlers()
        {
            // Invoice printer save button
            simpleButton1.Click += (s, e) => SaveInvoicePrinter();
            
            // Barcode printer save button
            simpleButton2.Click += (s, e) => SaveBarcodePrinter();
            
            // Add double-click to textboxes to show available printers
            textBox1.DoubleClick += (s, e) => ShowAvailablePrinters(textBox1);
            textBox2.DoubleClick += (s, e) => ShowAvailablePrinters(textBox2);
        }

        private void SaveInvoicePrinter()
        {
            try
            {
                string printerName = textBox1.Text.Trim();
                
                if (string.IsNullOrEmpty(printerName))
                {
                    XtraMessageBox.Show("يرجى إدخال اسم الطابعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsPrinterValid(printerName))
                {
                    var result = XtraMessageBox.Show($"الطابعة '{printerName}' غير موجودة في النظام. هل تريد الحفظ على أي حال؟", 
                        "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.No)
                        return;
                }

                Properties.Settings.Default.InvoicePrinterName = printerName;
                Properties.Settings.Default.Save();
                XtraMessageBox.Show("تم حفظ إعدادات طابعة الفواتير بنجاح", "نجح الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ إعدادات الطابعة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBarcodePrinter()
        {
            try
            {
                string printerName = textBox2.Text.Trim();
                
                if (string.IsNullOrEmpty(printerName))
                {
                    XtraMessageBox.Show("يرجى إدخال اسم الطابعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsPrinterValid(printerName))
                {
                    var result = XtraMessageBox.Show($"الطابعة '{printerName}' غير موجودة في النظام. هل تريد الحفظ على أي حال؟", 
                        "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.No)
                        return;
                }

                Properties.Settings.Default.BarcodePrinterName = printerName;
                Properties.Settings.Default.Save();
                XtraMessageBox.Show("تم حفظ إعدادات طابعة الباركود بنجاح", "نجح الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ إعدادات الطابعة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAvailablePrinters(TextBox targetTextBox)
        {
            try
            {
                string[] availablePrinters = GetAvailablePrinters();
                
                if (availablePrinters.Length == 0)
                {
                    XtraMessageBox.Show("لا توجد طابعات متاحة في النظام", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a simple selection dialog
                using (var form = new XtraForm())
                {
                    form.Text = "اختر الطابعة";
                    form.Size = new Size(400, 300);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.RightToLeft = RightToLeft.Yes;
                    form.RightToLeftLayout = true;

                    var listBox = new ListBox()
                    {
                        DataSource = availablePrinters,
                        Dock = DockStyle.Fill,
                        Font = new Font("Arial", 10)
                    };

                    var buttonPanel = new Panel()
                    {
                        Height = 50,
                        Dock = DockStyle.Bottom
                    };

                    var okButton = new SimpleButton()
                    {
                        Text = "موافق",
                        Size = new Size(80, 30),
                        Location = new Point(10, 10)
                    };

                    var cancelButton = new SimpleButton()
                    {
                        Text = "إلغاء",
                        Size = new Size(80, 30),
                        Location = new Point(100, 10)
                    };

                    okButton.Click += (s, e) =>
                    {
                        if (listBox.SelectedItem != null)
                        {
                            targetTextBox.Text = listBox.SelectedItem.ToString();
                            form.DialogResult = DialogResult.OK;
                            form.Close();
                        }
                    };

                    cancelButton.Click += (s, e) =>
                    {
                        form.DialogResult = DialogResult.Cancel;
                        form.Close();
                    };

                    buttonPanel.Controls.Add(okButton);
                    buttonPanel.Controls.Add(cancelButton);
                    form.Controls.Add(listBox);
                    form.Controls.Add(buttonPanel);

                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في عرض الطابعات المتاحة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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