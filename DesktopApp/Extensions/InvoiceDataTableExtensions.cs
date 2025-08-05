using System;
using System.Collections.Generic;
using System.Data;
using DesktopApp.DataSet;
using DesktopApp.Utilities;

namespace DesktopApp.Extensions
{
    public static class InvoiceDataTableExtensions
    {
        /// <summary>
        /// Creates a completely Arabic-formatted DataTable for Crystal Reports
        /// All numeric fields are stored as Arabic-formatted strings
        /// </summary>
        public static DataTable CreateArabicInvoiceDataTable(Invoice invoice)
        {
            try
            {
                // Create Invoice Header Table
                var invoiceTable = new DataTable("InvoiceTable");
                
                // Add all columns as string type for Arabic formatting
                invoiceTable.Columns.Add("Id", typeof(string));
                invoiceTable.Columns.Add("InvoiceNumber", typeof(string));
                invoiceTable.Columns.Add("InvoiceDate", typeof(string));
                invoiceTable.Columns.Add("CustomerName", typeof(string));
                invoiceTable.Columns.Add("CustomerPhone", typeof(string));
                invoiceTable.Columns.Add("TotalAmount", typeof(string));
                invoiceTable.Columns.Add("Discount", typeof(string));
                invoiceTable.Columns.Add("NetAmount", typeof(string));

                // Add invoice row with Arabic formatted values
                var invoiceRow = invoiceTable.NewRow();
                invoiceRow["Id"] = ArabicNumberConverter.ConvertIntegerToArabic(invoice.Id);
                invoiceRow["InvoiceNumber"] = ArabicNumberConverter.ConvertToArabicDigits(invoice.InvoiceNumber ?? "");
                invoiceRow["InvoiceDate"] = ArabicNumberConverter.FormatDateWithSlashesArabic(invoice.InvoiceDate);
                invoiceRow["CustomerName"] = invoice.CustomerName ?? "";
                invoiceRow["CustomerPhone"] = ArabicNumberConverter.ConvertToArabicDigits(invoice.CustomerPhone ?? "");
                invoiceRow["TotalAmount"] = ArabicNumberConverter.ConvertDecimalToArabic(invoice.TotalAmount);
                invoiceRow["Discount"] = ArabicNumberConverter.ConvertDecimalToArabic(invoice.Discount);
                invoiceRow["NetAmount"] = ArabicNumberConverter.ConvertDecimalToArabic(invoice.NetAmount);
                
                invoiceTable.Rows.Add(invoiceRow);
                
                return invoiceTable;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating Arabic invoice table: {ex.Message}");
                return new DataTable("InvoiceTable");
            }
        }

        /// <summary>
        /// Creates Arabic-formatted Invoice Items DataTable
        /// All numeric fields are stored as Arabic-formatted strings
        /// </summary>
        public static DataTable CreateArabicInvoiceItemsDataTable(ICollection<InvoiceItem> invoiceItems, int invoiceId)
        {
            try
            {
                // Create Invoice Items Table
                var itemsTable = new DataTable("InvoiceItemsTable");
                
                // Add all columns as string type for Arabic formatting
                itemsTable.Columns.Add("Id", typeof(string));
                itemsTable.Columns.Add("ProductName", typeof(string));
                itemsTable.Columns.Add("UnitPrice", typeof(string));
                itemsTable.Columns.Add("Quantity", typeof(string));
                itemsTable.Columns.Add("InvoiceId", typeof(string));
                itemsTable.Columns.Add("TotalPrice", typeof(string));

                // Add items with Arabic formatted values
                foreach (var item in invoiceItems)
                {
                    var itemRow = itemsTable.NewRow();
                    itemRow["Id"] = ArabicNumberConverter.ConvertIntegerToArabic(item.Id);
                    itemRow["ProductName"] = item.ProductName ?? "";
                    itemRow["UnitPrice"] = ArabicNumberConverter.ConvertDecimalToArabic(item.UnitPrice);
                    itemRow["Quantity"] = ArabicNumberConverter.ConvertIntegerToArabic(item.Quantity);
                    itemRow["InvoiceId"] = ArabicNumberConverter.ConvertIntegerToArabic(invoiceId);
                    itemRow["TotalPrice"] = ArabicNumberConverter.ConvertDecimalToArabic(item.UnitPrice * item.Quantity);
                    
                    itemsTable.Rows.Add(itemRow);
                }
                
                return itemsTable;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating Arabic items table: {ex.Message}");
                return new DataTable("InvoiceItemsTable");
            }
        }

        /// <summary>
        /// Creates a complete Arabic-formatted DataSet for Crystal Reports
        /// </summary>
        public static System.Data.DataSet CreateArabicInvoiceDataSet(Invoice invoice)
        {
            try
            {
                var dataSet = new System.Data.DataSet("InvoiceDataSet");
                
                // Add invoice table
                var invoiceTable = CreateArabicInvoiceDataTable(invoice);
                dataSet.Tables.Add(invoiceTable);
                
                // Add items table
                var itemsTable = CreateArabicInvoiceItemsDataTable(invoice.InvoiceItems, invoice.Id);
                dataSet.Tables.Add(itemsTable);
                
                // Create relationship between tables
                if (invoiceTable.Rows.Count > 0 && itemsTable.Rows.Count > 0)
                {
                    var relation = new DataRelation("InvoiceToItems",
                        invoiceTable.Columns["Id"],
                        itemsTable.Columns["InvoiceId"]);
                    dataSet.Relations.Add(relation);
                }
                
                return dataSet;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating Arabic dataset: {ex.Message}");
                return new System.Data.DataSet("InvoiceDataSet");
            }
        }
    }
}
