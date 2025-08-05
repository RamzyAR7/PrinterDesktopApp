using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private XtraForm activeForm = null;
        private ToolTip toolTip;
        
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
            // Initialize tooltip
            toolTip = new ToolTip();
            toolTip.SetToolTip(simpleButton1, "الاعدادات");
            
            // Make the settings button circular
            MakeButtonCircular(simpleButton1);
            
            // Handle size changes to maintain circular shape
            simpleButton1.SizeChanged += (s, e) => MakeButtonCircular(simpleButton1);
            
            // Handle form closing to dispose tooltip
            this.FormClosed += (s, e) => toolTip?.Dispose();
        }

        private void MakeButtonCircular(SimpleButton button)
        {
            // Create a circular region for the button
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, button.Width, button.Height);
            Region oldRegion = button.Region;
            button.Region = new Region(path);
            oldRegion?.Dispose();
            path.Dispose();
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

        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new ProductForm());
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            LoadForm(new InvoiceForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var settingsForm = new PrinterSettingForm();
            settingsForm.ShowDialog();
        }
    }
}
