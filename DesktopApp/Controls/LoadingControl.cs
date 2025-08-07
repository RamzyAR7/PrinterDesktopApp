using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp.Controls
{
    /// <summary>
    /// Reusable loading indicator control for showing progress during data operations
    /// </summary>
    public partial class LoadingControl : UserControl
    {
        private Timer animationTimer;
        private int rotationAngle = 0;
        private LabelControl loadingLabel;
        private PictureBox loadingPictureBox;
        private PanelControl containerPanel;

        public LoadingControl()
        {
            InitializeComponent();
            SetupLoadingControl();
        }

        /// <summary>
        /// Gets or sets the loading message text
        /// </summary>
        public string LoadingText
        {
            get { return loadingLabel?.Text ?? "جاري التحميل..."; }
            set { if (loadingLabel != null) loadingLabel.Text = value; }
        }

        /// <summary>
        /// Gets or sets whether the loading animation is active
        /// </summary>
        public bool IsLoading
        {
            get { return animationTimer?.Enabled ?? false; }
            set
            {
                if (value)
                    StartLoading();
                else
                    StopLoading();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Main container panel
            this.containerPanel = new PanelControl();
            this.loadingPictureBox = new PictureBox();
            this.loadingLabel = new LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.containerPanel)).BeginInit();
            this.containerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            
            // containerPanel
            this.containerPanel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.containerPanel.Appearance.Options.UseBackColor = true;
            this.containerPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.containerPanel.Controls.Add(this.loadingPictureBox);
            this.containerPanel.Controls.Add(this.loadingLabel);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(300, 100);
            this.containerPanel.TabIndex = 0;
            
            // loadingPictureBox
            this.loadingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.loadingPictureBox.Location = new System.Drawing.Point(135, 25);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(30, 30);
            this.loadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingPictureBox.TabIndex = 0;
            this.loadingPictureBox.TabStop = false;
            
            // loadingLabel
            this.loadingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadingLabel.Appearance.Options.UseFont = true;
            this.loadingLabel.Appearance.Options.UseForeColor = true;
            this.loadingLabel.Appearance.Options.UseTextOptions = true;
            this.loadingLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loadingLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.loadingLabel.Location = new System.Drawing.Point(50, 65);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(200, 20);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "جاري التحميل...";
            
            // LoadingControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.containerPanel);
            this.Name = "LoadingControl";
            this.Size = new System.Drawing.Size(300, 100);
            
            ((System.ComponentModel.ISupportInitialize)(this.containerPanel)).EndInit();
            this.containerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupLoadingControl()
        {
            // Set up the loading control
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(240, 240, 240, 240); // Semi-transparent
            
            // Initialize animation timer
            animationTimer = new Timer();
            animationTimer.Interval = 50; // Update every 50ms for smooth animation
            animationTimer.Tick += AnimationTimer_Tick;
            
            // Create loading spinner image
            CreateSpinnerImage();
            
            // Initially hide the control
            this.Visible = false;
            this.BringToFront();
        }

        private void CreateSpinnerImage()
        {
            // Create a simple spinner using graphics
            var bitmap = new Bitmap(30, 30);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.Clear(Color.Transparent);
                
                // Draw spinner dots
                var centerX = 15;
                var centerY = 15;
                var radius = 10;
                
                for (int i = 0; i < 8; i++)
                {
                    var angle = i * 45 * Math.PI / 180;
                    var x = centerX + radius * Math.Cos(angle) - 2;
                    var y = centerY + radius * Math.Sin(angle) - 2;
                    
                    var alpha = (int)(255 * (i + 1) / 8.0);
                    var color = Color.FromArgb(alpha, 0, 122, 255); // Blue spinner
                    
                    using (var brush = new SolidBrush(color))
                    {
                        graphics.FillEllipse(brush, (float)x, (float)y, 4, 4);
                    }
                }
            }
            
            loadingPictureBox.Image = bitmap;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            rotationAngle += 45;
            if (rotationAngle >= 360)
                rotationAngle = 0;
            
            UpdateSpinnerRotation();
        }

        private void UpdateSpinnerRotation()
        {
            if (loadingPictureBox.Image != null)
            {
                var bitmap = new Bitmap(30, 30);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.Clear(Color.Transparent);
                    
                    // Draw spinner dots with rotation
                    var centerX = 15;
                    var centerY = 15;
                    var radius = 10;
                    
                    for (int i = 0; i < 8; i++)
                    {
                        var angle = (i * 45 + rotationAngle) * Math.PI / 180;
                        var x = centerX + radius * Math.Cos(angle) - 2;
                        var y = centerY + radius * Math.Sin(angle) - 2;
                        
                        var alpha = (int)(255 * (i + 1) / 8.0);
                        var color = Color.FromArgb(alpha, 0, 122, 255); // Blue spinner
                        
                        using (var brush = new SolidBrush(color))
                        {
                            graphics.FillEllipse(brush, (float)x, (float)y, 4, 4);
                        }
                    }
                }
                
                loadingPictureBox.Image?.Dispose();
                loadingPictureBox.Image = bitmap;
            }
        }

        /// <summary>
        /// Start the loading animation
        /// </summary>
        public void StartLoading()
        {
            this.Visible = true;
            this.BringToFront();
            animationTimer.Start();
        }

        /// <summary>
        /// Stop the loading animation and hide the control
        /// </summary>
        public void StopLoading()
        {
            animationTimer.Stop();
            this.Visible = false;
        }

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animationTimer?.Stop();
                animationTimer?.Dispose();
                loadingPictureBox?.Image?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
