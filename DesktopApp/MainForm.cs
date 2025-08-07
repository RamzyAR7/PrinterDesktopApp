using DevExpress.XtraEditors;
using DesktopApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private XtraForm activeForm = null;
        private ToolTip toolTip;
        private string currentActiveSection = ""; // Track which section is active
        
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
            // Initialize tooltip
            toolTip = new ToolTip();
            toolTip.SetToolTip(simpleButton1, "الاعدادات");
            
            // Handle form closing to dispose tooltip
            this.FormClosed += (s, e) => toolTip?.Dispose();
            
            // Initialize button styles
            InitializeButtonStyles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize the main form
            // No need to load any form here as the user will select which form to load
        }

        private void LoadForm(XtraForm form)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelMainContainer.Controls.Clear();
            panelMainContainer.Controls.Add(form);
            form.Show();
        }

        private async void btnProduct_Click(object sender, EventArgs e)
        {
            await LoadingManager.ExecuteFormNavigationAsync(this, async () =>
            {
                var productForm = new ProductForm();
                LoadForm(productForm);
                await Task.Delay(100); // Small delay to show loading
            }, "المنتجات");
            
            SetActiveSection("product");
        }

        private async void btnInvoice_Click(object sender, EventArgs e)
        {
            await LoadingManager.ExecuteFormNavigationAsync(this, async () =>
            {
                var invoiceForm = new InvoiceForm();
                LoadForm(invoiceForm);
                await Task.Delay(100); // Small delay to show loading
            }, "الفواتير");
            
            SetActiveSection("invoice");
        }

        /// <summary>
        /// Initialize button styles to default state
        /// </summary>
        private void InitializeButtonStyles()
        {
            // Set both buttons to inactive state initially
            SetButtonInactive(btnProduct);
            SetButtonInactive(btnInvoice);
        }

        /// <summary>
        /// Set the active section and update button indicators
        /// </summary>
        /// <param name="section">The section to activate ("product" or "invoice")</param>
        private void SetActiveSection(string section)
        {
            currentActiveSection = section;
            
            // Reset both buttons to inactive state
            SetButtonInactive(btnProduct);
            SetButtonInactive(btnInvoice);
            
            // Set the active button
            switch (section.ToLower())
            {
                case "product":
                    SetButtonActive(btnProduct);
                    break;
                case "invoice":
                    SetButtonActive(btnInvoice);
                    break;
            }
        }

        /// <summary>
        /// Set button to active state with enhanced visual indicators
        /// </summary>
        /// <param name="button">The button to activate</param>
        private void SetButtonActive(DevExpress.XtraEditors.SimpleButton button)
        {
            // Active button styling - Green with white text and border indicator
            button.Appearance.BackColor = System.Drawing.Color.FromArgb(40, 167, 69); // Success green
            button.Appearance.ForeColor = System.Drawing.Color.White;
            button.Appearance.BorderColor = System.Drawing.Color.FromArgb(255, 193, 7); // Warning yellow border for indicator
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseBorderColor = true;
            
            // Add active indicator text
            if (button == btnProduct)
                button.Text = "● المنتجات"; // Bullet indicator + text
            else if (button == btnInvoice)
                button.Text = "● الفواتير"; // Bullet indicator + text
            
            // Enhanced border for active state
            button.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            
            // Hover effects for active button
            button.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(52, 181, 85);
            button.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            button.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(255, 193, 7);
            button.AppearanceHovered.Options.UseBackColor = true;
            button.AppearanceHovered.Options.UseForeColor = true;
            button.AppearanceHovered.Options.UseBorderColor = true;
        }

        /// <summary>
        /// Set button to inactive state
        /// </summary>
        /// <param name="button">The button to deactivate</param>
        private void SetButtonInactive(DevExpress.XtraEditors.SimpleButton button)
        {
            // Inactive button styling - Original blue with no special indicators
            button.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            button.Appearance.ForeColor = System.Drawing.Color.White;
            button.Appearance.BorderColor = System.Drawing.Color.RoyalBlue;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseBorderColor = true;
            
            // Remove active indicator text
            if (button == btnProduct)
                button.Text = "المنتجات"; // Original text without indicator
            else if (button == btnInvoice)
                button.Text = "الفواتير"; // Original text without indicator
            
            // Standard border for inactive state
            button.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            
            // Hover effects for inactive button
            button.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(100, 149, 237); // Lighter blue
            button.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            button.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(100, 149, 237);
            button.AppearanceHovered.Options.UseBackColor = true;
            button.AppearanceHovered.Options.UseForeColor = true;
            button.AppearanceHovered.Options.UseBorderColor = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var settingsForm = new PrinterSettingForm();
            settingsForm.ShowDialog();
        }

        /// <summary>
        /// Get the currently active section
        /// </summary>
        /// <returns>Current active section name</returns>
        public string GetCurrentActiveSection()
        {
            return currentActiveSection;
        }

        /// <summary>
        /// Check if a specific section is currently active
        /// </summary>
        /// <param name="section">Section to check</param>
        /// <returns>True if the section is active</returns>
        public bool IsSectionActive(string section)
        {
            return currentActiveSection.Equals(section, StringComparison.OrdinalIgnoreCase);
        }
    }
}
