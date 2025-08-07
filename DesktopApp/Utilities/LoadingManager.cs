using DevExpress.XtraEditors;
using DesktopApp.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Utilities
{
    /// <summary>
    /// Manages loading indicators across the application
    /// </summary>
    public static class LoadingManager
    {
        /// <summary>
        /// Shows a loading indicator on a form and executes an async operation
        /// </summary>
        /// <param name="parentForm">The form to show loading on</param>
        /// <param name="operation">The async operation to execute</param>
        /// <param name="loadingMessage">Custom loading message</param>
        /// <returns>Task representing the operation</returns>
        public static async Task ExecuteWithLoadingAsync(Control parentForm, Func<Task> operation, string loadingMessage = "جاري التحميل...")
        {
            LoadingControl loadingControl = null;
            
            try
            {
                // Create and show loading control
                loadingControl = new LoadingControl
                {
                    LoadingText = loadingMessage,
                    Dock = DockStyle.Fill
                };
                
                // Add to parent form
                parentForm.Controls.Add(loadingControl);
                loadingControl.BringToFront();
                loadingControl.StartLoading();
                
                // Disable parent form interaction
                DisableFormInteraction(parentForm, loadingControl);
                
                // Execute the operation
                await operation();
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clean up loading control
                if (loadingControl != null)
                {
                    loadingControl.StopLoading();
                    parentForm.Controls.Remove(loadingControl);
                    loadingControl.Dispose();
                }
                
                // Re-enable form interaction
                EnableFormInteraction(parentForm);
            }
        }

        /// <summary>
        /// Shows a loading indicator on a form and executes an async operation with return value
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="parentForm">The form to show loading on</param>
        /// <param name="operation">The async operation to execute</param>
        /// <param name="loadingMessage">Custom loading message</param>
        /// <returns>Result of the operation</returns>
        public static async Task<T> ExecuteWithLoadingAsync<T>(Control parentForm, Func<Task<T>> operation, string loadingMessage = "جاري التحميل...")
        {
            LoadingControl loadingControl = null;
            
            try
            {
                // Create and show loading control
                loadingControl = new LoadingControl
                {
                    LoadingText = loadingMessage,
                    Dock = DockStyle.Fill
                };
                
                // Add to parent form
                parentForm.Controls.Add(loadingControl);
                loadingControl.BringToFront();
                loadingControl.StartLoading();
                
                // Disable parent form interaction
                DisableFormInteraction(parentForm, loadingControl);
                
                // Execute the operation and return result
                return await operation();
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
            finally
            {
                // Clean up loading control
                if (loadingControl != null)
                {
                    loadingControl.StopLoading();
                    parentForm.Controls.Remove(loadingControl);
                    loadingControl.Dispose();
                }
                
                // Re-enable form interaction
                EnableFormInteraction(parentForm);
            }
        }

        /// <summary>
        /// Shows loading for form navigation between main form sections
        /// </summary>
        /// <param name="mainForm">The main form</param>
        /// <param name="formLoader">Function that loads the target form</param>
        /// <param name="sectionName">Name of the section being loaded</param>
        /// <returns>Task representing the navigation operation</returns>
        public static async Task ExecuteFormNavigationAsync(Control mainForm, Func<Task> formLoader, string sectionName)
        {
            string loadingMessage = $"جاري تحميل {sectionName}...";
            await ExecuteWithLoadingAsync(mainForm, formLoader, loadingMessage);
        }

        /// <summary>
        /// Shows loading for database operations
        /// </summary>
        /// <param name="parentForm">The parent form</param>
        /// <param name="operation">The database operation</param>
        /// <param name="operationType">Type of operation (Create, Update, Delete, Load)</param>
        /// <returns>Task representing the operation</returns>
        public static async Task ExecuteDatabaseOperationAsync(Control parentForm, Func<Task> operation, DatabaseOperationType operationType)
        {
            string loadingMessage = GetDatabaseOperationMessage(operationType);
            await ExecuteWithLoadingAsync(parentForm, operation, loadingMessage);
        }

        /// <summary>
        /// Shows loading for database operations with return value
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="parentForm">The parent form</param>
        /// <param name="operation">The database operation</param>
        /// <param name="operationType">Type of operation</param>
        /// <returns>Result of the operation</returns>
        public static async Task<T> ExecuteDatabaseOperationAsync<T>(Control parentForm, Func<Task<T>> operation, DatabaseOperationType operationType)
        {
            string loadingMessage = GetDatabaseOperationMessage(operationType);
            return await ExecuteWithLoadingAsync(parentForm, operation, loadingMessage);
        }

        private static void DisableFormInteraction(Control parentForm, Control excludeControl)
        {
            // Disable all controls except the loading control
            foreach (Control control in parentForm.Controls)
            {
                if (control != excludeControl)
                {
                    control.Enabled = false;
                }
            }
        }

        private static void EnableFormInteraction(Control parentForm)
        {
            // Re-enable all controls
            foreach (Control control in parentForm.Controls)
            {
                control.Enabled = true;
            }
        }

        private static string GetDatabaseOperationMessage(DatabaseOperationType operationType)
        {
            switch (operationType)
            {
                case DatabaseOperationType.Create:
                    return "جاري الحفظ...";
                case DatabaseOperationType.Update:
                    return "جاري التحديث...";
                case DatabaseOperationType.Delete:
                    return "جاري الحذف...";
                case DatabaseOperationType.Load:
                    return "جاري تحميل البيانات...";
                case DatabaseOperationType.Search:
                    return "جاري البحث...";
                default:
                    return "جاري المعالجة...";
            }
        }
    }

    /// <summary>
    /// Enumeration for different types of database operations
    /// </summary>
    public enum DatabaseOperationType
    {
        Create,
        Update,
        Delete,
        Load,
        Search
    }
}
