using Microsoft.AspNetCore.Identity;
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
using DesktopApp.Utilities;

namespace DesktopApp
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetLoadingState(true);
            try
            {
                if (!ValidateInputs())
                    return;

                var loginResult = TryLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (loginResult)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }
            return true;
        }

        private bool TryLogin(string username, string password)
        {
            if (!NetworkHelper.IsInternetAvailable())
            {
                MessageBox.Show("لا يوجد اتصال بالإنترنت. يرجى التأكد من الاتصال قبل المتابعة.", "تنبيه الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                using (var db = new ShoppingDBEntities())
                {
                    var user = db.AspNetUsers.FirstOrDefault(u => u.UserName == username);
                    if (user == null)
                    {
                        MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة.", "فشل تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    var hasher = new PasswordHasher<object>();
                    string hashed = hasher.HashPassword(null, password);
                    var result = hasher.VerifyHashedPassword(null, user.PasswordHash, password);
                    if (result == PasswordVerificationResult.Success)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة.", "فشل تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تسجيل الدخول:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
            btnLogin.Enabled = !isLoading;
        }
    }
}