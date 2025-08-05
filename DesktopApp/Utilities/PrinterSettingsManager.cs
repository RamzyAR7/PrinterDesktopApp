using System;
using System.Drawing.Printing;
using System.Linq;

namespace DesktopApp
{
    public static class PrinterSettingsManager
    {
        /// <summary>
        /// Gets the barcode printer name from settings
        /// </summary>
        public static string GetBarcodePrinterName()
        {
            return DesktopApp.Properties.Settings.Default.BarcodePrinterName;
        }

        /// <summary>
        /// Gets the invoice printer name from settings
        /// </summary>
        public static string GetInvoicePrinterName()
        {
            return DesktopApp.Properties.Settings.Default.InvoicePrinterName;
        }

        /// <summary>
        /// Sets the barcode printer name and saves settings
        /// </summary>
        public static void SetBarcodePrinterName(string printerName)
        {
            DesktopApp.Properties.Settings.Default.BarcodePrinterName = printerName;
            DesktopApp.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Sets the invoice printer name and saves settings
        /// </summary>
        public static void SetInvoicePrinterName(string printerName)
        {
            DesktopApp.Properties.Settings.Default.InvoicePrinterName = printerName;
            DesktopApp.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Gets all available printers on the system
        /// </summary>
        public static string[] GetAvailablePrinters()
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

        /// <summary>
        /// Validates if a printer name exists on the system
        /// </summary>
        public static bool IsPrinterValid(string printerName)
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

        /// <summary>
        /// Gets the default printer name for the system
        /// </summary>
        public static string GetDefaultPrinter()
        {
            try
            {
                var printerSettings = new PrinterSettings();
                return printerSettings.PrinterName;
            }
            catch (Exception)
            {
                return "Default Printer";
            }
        }
    }
}
