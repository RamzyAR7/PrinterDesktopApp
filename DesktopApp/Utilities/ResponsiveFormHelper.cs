using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Utilities
{
    /// <summary>
    /// Utility class to make forms responsive across different screen resolutions
    /// Implements dynamic form sizing with DPI scaling support
    /// </summary>
    public static class ResponsiveFormHelper
    {
        /// <summary>
        /// Makes a form responsive with dynamic sizing based on screen resolution
        /// </summary>
        /// <param name="form">The form to make responsive</param>
        /// <param name="minimumWidthPercent">Minimum width as percentage of screen (default: 60%)</param>
        /// <param name="preferredWidthPercent">Preferred width as percentage of screen (default: 85%)</param>
        /// <param name="minimumHeightPercent">Minimum height as percentage of screen (default: 60%)</param>
        /// <param name="preferredHeightPercent">Preferred height as percentage of screen (default: 85%)</param>
        /// <param name="absoluteMinWidth">Absolute minimum width in pixels (default: 800)</param>
        /// <param name="absoluteMinHeight">Absolute minimum height in pixels (default: 600)</param>
        public static void MakeFormResponsive(
            XtraForm form,
            double minimumWidthPercent = 0.6,
            double preferredWidthPercent = 0.85,
            double minimumHeightPercent = 0.6,
            double preferredHeightPercent = 0.85,
            int absoluteMinWidth = 800,
            int absoluteMinHeight = 600)
        {
            if (form == null) return;

            // Get the working area of the primary screen (excluding taskbar)
            var screenBounds = Screen.PrimaryScreen.WorkingArea;

            // Calculate responsive sizing based on screen resolution
            int formWidth = Math.Max(absoluteMinWidth, (int)(screenBounds.Width * preferredWidthPercent));
            int formHeight = Math.Max(absoluteMinHeight, (int)(screenBounds.Height * preferredHeightPercent));

            // Ensure form doesn't exceed screen boundaries
            formWidth = Math.Min(formWidth, screenBounds.Width - 100);
            formHeight = Math.Min(formHeight, screenBounds.Height - 100);

            // Set responsive minimum size based on screen resolution
            int minWidth = Math.Max(absoluteMinWidth, (int)(screenBounds.Width * minimumWidthPercent));
            int minHeight = Math.Max(absoluteMinHeight, (int)(screenBounds.Height * minimumHeightPercent));

            // Apply sizing
            form.Size = new Size(formWidth, formHeight);
            form.MinimumSize = new Size(minWidth, minHeight);

            // Enable DPI scaling for high-resolution displays
            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.AutoScaleDimensions = new SizeF(96F, 96F);

            // Set form properties for better responsive behavior
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.MaximizeBox = true;
            form.MinimizeBox = true;
            form.StartPosition = FormStartPosition.CenterScreen;

            // Handle form resize event to maintain proper layout
            form.Resize += (s, e) => EnsureFormStaysOnScreen(form);

            // Initial positioning
            EnsureFormStaysOnScreen(form);
        }

        /// <summary>
        /// Ensures the form stays within screen boundaries
        /// </summary>
        /// <param name="form">The form to check</param>
        public static void EnsureFormStaysOnScreen(XtraForm form)
        {
            if (form == null) return;

            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            if (form.WindowState == FormWindowState.Normal)
            {
                // Keep form within screen bounds
                if (form.Right > workingArea.Right)
                    form.Left = workingArea.Right - form.Width;
                if (form.Bottom > workingArea.Bottom)
                    form.Top = workingArea.Bottom - form.Height;
                if (form.Left < workingArea.Left)
                    form.Left = workingArea.Left;
                if (form.Top < workingArea.Top)
                    form.Top = workingArea.Top;
            }
        }

        /// <summary>
        /// Applies enhanced fonts and styling for better visibility on different screen sizes
        /// </summary>
        /// <param name="form">The form to enhance</param>
        public static void ApplyEnhancedFonts(XtraForm form)
        {
            if (form == null) return;

            // Enhanced fonts with larger sizes for better visibility
            Font headerFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            Font labelFont = new Font("Segoe UI", 14F, FontStyle.Regular);
            Font inputFont = new Font("Segoe UI", 13F, FontStyle.Regular);
            Font buttonFont = new Font("Segoe UI", 14F, FontStyle.Bold);

            // Apply to form itself
            form.Appearance.Font = labelFont;
            form.Appearance.Options.UseFont = true;

            // Apply fonts to all controls recursively
            ApplyFontsToControls(form.Controls, headerFont, labelFont, inputFont, buttonFont);
        }

        /// <summary>
        /// Recursively applies fonts to controls
        /// </summary>
        private static void ApplyFontsToControls(Control.ControlCollection controls, Font headerFont, Font labelFont, Font inputFont, Font buttonFont)
        {
            foreach (Control control in controls)
            {
                // Apply appropriate font based on control type
                if (control is DevExpress.XtraEditors.GroupControl groupControl)
                {
                    groupControl.Appearance.Font = headerFont;
                    groupControl.Appearance.Options.UseFont = true;
                    groupControl.AppearanceCaption.Font = headerFont;
                    groupControl.AppearanceCaption.Options.UseFont = true;
                }
                else if (control is DevExpress.XtraEditors.LabelControl labelControl)
                {
                    labelControl.Appearance.Font = labelFont;
                    labelControl.Appearance.Options.UseFont = true;
                }
                else if (control is DevExpress.XtraEditors.TextEdit textEdit)
                {
                    textEdit.Properties.Appearance.Font = inputFont;
                    textEdit.Properties.Appearance.Options.UseFont = true;
                    textEdit.Height = 40; // Increased height for better visibility
                }
                else if (control is DevExpress.XtraEditors.LookUpEdit lookUpEdit)
                {
                    lookUpEdit.Properties.Appearance.Font = inputFont;
                    lookUpEdit.Properties.Appearance.Options.UseFont = true;
                    lookUpEdit.Properties.AppearanceDropDown.Font = inputFont;
                    lookUpEdit.Properties.AppearanceDropDown.Options.UseFont = true;
                    lookUpEdit.Height = 40;
                }
                else if (control is DevExpress.XtraEditors.SpinEdit spinEdit)
                {
                    spinEdit.Properties.Appearance.Font = inputFont;
                    spinEdit.Properties.Appearance.Options.UseFont = true;
                    spinEdit.Height = 40;
                }
                else if (control is DevExpress.XtraEditors.DateEdit dateEdit)
                {
                    dateEdit.Properties.Appearance.Font = inputFont;
                    dateEdit.Properties.Appearance.Options.UseFont = true;
                    dateEdit.Height = 40;
                }
                else if (control is DevExpress.XtraEditors.SimpleButton button)
                {
                    button.Appearance.Font = buttonFont;
                    button.Appearance.Options.UseFont = true;
                    button.Height = 50; // Increased height for better visibility
                }

                // Recursively apply to child controls
                if (control.HasChildren)
                {
                    ApplyFontsToControls(control.Controls, headerFont, labelFont, inputFont, buttonFont);
                }
            }
        }

        /// <summary>
        /// Configures adaptive layout for small screens
        /// </summary>
        /// <param name="form">The form to configure</param>
        public static void ConfigureAdaptiveLayout(XtraForm form)
        {
            if (form == null) return;

            form.Resize += (s, e) =>
            {
                AdjustControlsForScreenSize(form);
            };

            // Initial adjustment
            AdjustControlsForScreenSize(form);
        }

        /// <summary>
        /// Adjusts controls based on current form size
        /// </summary>
        private static void AdjustControlsForScreenSize(XtraForm form)
        {
            if (form == null) return;

            bool isSmallScreen = form.Width < 1200 || form.Height < 800;

            // Find layout controls and adjust spacing
            foreach (Control control in form.Controls)
            {
                if (control is DevExpress.XtraLayout.LayoutControl layoutControl)
                {
                    if (isSmallScreen)
                    {
                        layoutControl.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(10);
                        layoutControl.Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(5);
                    }
                    else
                    {
                        layoutControl.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(15);
                        layoutControl.Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(8);
                    }
                }

                // Adjust panel heights for buttons
                if (control is DevExpress.XtraEditors.PanelControl panelControl && 
                    control.Dock == DockStyle.Bottom)
                {
                    panelControl.Height = isSmallScreen ? 60 : 80;
                }
            }
        }

        /// <summary>
        /// Gets the recommended sizing percentages based on screen resolution
        /// </summary>
        /// <returns>Tuple with (widthPercent, heightPercent)</returns>
        public static (double width, double height) GetRecommendedSizing()
        {
            var screenBounds = Screen.PrimaryScreen.WorkingArea;
            
            // Adjust sizing based on screen resolution
            if (screenBounds.Width <= 1024) // Small screens
            {
                return (0.95, 0.90); // Use most of the screen
            }
            else if (screenBounds.Width <= 1366) // Medium screens
            {
                return (0.85, 0.85);
            }
            else if (screenBounds.Width <= 1920) // Large screens
            {
                return (0.75, 0.80);
            }
            else // Ultra-high resolution
            {
                return (0.65, 0.70); // Don't make forms too large on very big screens
            }
        }
    }
}
