using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class BarcodeCopyForm : XtraForm
    {
        public int NumberOfCopies { get; private set; } = 1;

        public BarcodeCopyForm()
        {
            InitializeComponent();
            
            // Set form properties
            this.Text = "عدد النسخ للطباعة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            
            // Remove fixed size - let it auto-size to content
            // The form will now automatically size to fit its components
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(spinEditCopies.Text, out int copies) && copies > 0)
            {
                NumberOfCopies = copies;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("الرجاء إدخال عدد صحيح أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}