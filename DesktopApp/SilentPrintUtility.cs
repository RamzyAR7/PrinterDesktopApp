using System;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DesktopApp.Extensions;
using System.Data.Entity;

namespace DesktopApp
{
    public static class SilentPrintUtility
    {
        public static void PrintBarcodeSilent(string productName, decimal price, int numberOfCopies = 1)
        {
            try
            {
                // Generate barcode data
                int encryptedPrice = PriceEncrypt.EncryptPrice(price);
                byte[] barcodeImage = BarcodeGenrator.GenerateBarcodeImage(productName, encryptedPrice.ToString());

                // Create dataset and add the barcode image
                var barcodeDataSet = new DataSet.Barcode();
                barcodeDataSet.BarcodeTable.AddBarcodeTableRow(barcodeImage);

                // Create Crystal Report
                var report = new CrystalReports.Barcode();
                report.SetDataSource(barcodeDataSet);

                // Print settings
                var printOptions = report.PrintOptions;
                printOptions.PrinterName = Properties.Settings.Default.BarcodePrinterName;
                
                // Print the specified number of copies
                for (int i = 0; i < numberOfCopies; i++)
                {
                    report.PrintToPrinter(1, false, 0, 0);
                }

                // Clean up
                report.Close();
                report.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في الطباعة الصامتة: {ex.Message}");
            }
        }

        public static void PrintInvoiceSilent(int invoiceId, int numberOfCopies = 1)
        {
            try
            {
                using (var dbContext = new ShoppingDBEntities())
                {
                    // Load invoice with items
                    var invoice = dbContext.Invoices
                        .Include(i => i.InvoiceItems)
                        .FirstOrDefault(i => i.Id == invoiceId);

                    if (invoice == null)
                    {
                        throw new Exception("الفاتورة غير موجودة");
                    }

                    // Create Arabic-formatted dataset
                    var arabicInvoiceDataSet = InvoiceDataTableExtensions.CreateArabicInvoiceDataSet(invoice);

                    // Create Crystal Report
                    var report = new CrystalReports.Invoice();
                    report.SetDataSource(arabicInvoiceDataSet);

                    // Print settings
                    var printOptions = report.PrintOptions;
                    printOptions.PrinterName = Properties.Settings.Default.InvoicePrinterName;
                    
                    // Print the specified number of copies
                    for (int i = 0; i < numberOfCopies; i++)
                    {
                        report.PrintToPrinter(1, false, 0, 0);
                    }

                    // Clean up
                    report.Close();
                    report.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في طباعة الفاتورة: {ex.Message}");
            }
        }
    }
}