namespace DesktopApp
{
    partial class ProductCUForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose dbContext from code-behind
                var form = this as ProductCUForm;
                form?.dbContext?.Dispose();

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.CreateBtn = new DevExpress.XtraEditors.SimpleButton();
            this.EditBtn = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.cmbCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtSellingPrice = new DevExpress.XtraEditors.SpinEdit();
            this.txtPurchasingPrice = new DevExpress.XtraEditors.SpinEdit();
            this.txtGomlaPrice = new DevExpress.XtraEditors.SpinEdit();
            this.txtNosGomlaPrice = new DevExpress.XtraEditors.SpinEdit();
            this.chkOptional = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.scrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellingPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasingPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGomlaPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNosGomlaPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOptional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // scrollableControl1
            // 
            this.scrollableControl1.Controls.Add(this.panelControl1);
            this.scrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.scrollableControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollableControl1.Name = "scrollableControl1";
            this.scrollableControl1.Size = new System.Drawing.Size(789, 541);
            this.scrollableControl1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(768, 600);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Location = new System.Drawing.Point(23, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(721, 575);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "بيانات المنتج";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtProductName);
            this.layoutControl1.Controls.Add(this.cmbCompany);
            this.layoutControl1.Controls.Add(this.cmbCategory);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.txtSellingPrice);
            this.layoutControl1.Controls.Add(this.txtPurchasingPrice);
            this.layoutControl1.Controls.Add(this.txtGomlaPrice);
            this.layoutControl1.Controls.Add(this.txtNosGomlaPrice);
            this.layoutControl1.Controls.Add(this.chkOptional);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 28);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(717, 545);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(717, 545);
            this.Root.TextVisible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.CreateBtn);
            this.panelControl2.Controls.Add(this.EditBtn);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 541);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(789, 62);
            this.panelControl2.TabIndex = 1;
            // 
            // CreateBtn
            // 
            this.CreateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.CreateBtn.Appearance.Options.UseFont = true;
            this.CreateBtn.Location = new System.Drawing.Point(649, 12);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(117, 37);
            this.CreateBtn.TabIndex = 0;
            this.CreateBtn.Text = "إنشاء";
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.EditBtn.Appearance.Options.UseFont = true;
            this.EditBtn.Location = new System.Drawing.Point(521, 12);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(117, 37);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "تعديل";
            this.EditBtn.Visible = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(23, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "إلغاء";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(14, 34);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(689, 22);
            this.txtProductName.StyleController = this.layoutControl1;
            this.txtProductName.TabIndex = 0;
            // 
            // cmbCompany
            // 
            this.cmbCompany.Location = new System.Drawing.Point(14, 80);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCompany.Properties.NullText = "اختر الشركة...";
            this.cmbCompany.Size = new System.Drawing.Size(689, 22);
            this.cmbCompany.StyleController = this.layoutControl1;
            this.cmbCompany.TabIndex = 2;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(14, 126);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCategory.Properties.NullText = "اختر الصنف...";
            this.cmbCategory.Size = new System.Drawing.Size(689, 22);
            this.cmbCategory.StyleController = this.layoutControl1;
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.EditValueChanged += new System.EventHandler(this.cmbCategory_EditValueChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(14, 172);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(689, 99);
            this.txtDescription.StyleController = this.layoutControl1;
            this.txtDescription.TabIndex = 4;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSellingPrice.Location = new System.Drawing.Point(14, 295);
            this.txtSellingPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSellingPrice.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtSellingPrice.Size = new System.Drawing.Size(689, 24);
            this.txtSellingPrice.StyleController = this.layoutControl1;
            this.txtSellingPrice.TabIndex = 5;
            // 
            // txtPurchasingPrice
            // 
            this.txtPurchasingPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPurchasingPrice.Location = new System.Drawing.Point(14, 343);
            this.txtPurchasingPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchasingPrice.Name = "txtPurchasingPrice";
            this.txtPurchasingPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPurchasingPrice.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtPurchasingPrice.Size = new System.Drawing.Size(689, 24);
            this.txtPurchasingPrice.StyleController = this.layoutControl1;
            this.txtPurchasingPrice.TabIndex = 6;
            // 
            // txtGomlaPrice
            // 
            this.txtGomlaPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGomlaPrice.Location = new System.Drawing.Point(14, 391);
            this.txtGomlaPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtGomlaPrice.Name = "txtGomlaPrice";
            this.txtGomlaPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtGomlaPrice.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtGomlaPrice.Size = new System.Drawing.Size(689, 24);
            this.txtGomlaPrice.StyleController = this.layoutControl1;
            this.txtGomlaPrice.TabIndex = 7;
            // 
            // txtNosGomlaPrice
            // 
            this.txtNosGomlaPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNosGomlaPrice.Location = new System.Drawing.Point(14, 439);
            this.txtNosGomlaPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtNosGomlaPrice.Name = "txtNosGomlaPrice";
            this.txtNosGomlaPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNosGomlaPrice.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtNosGomlaPrice.Size = new System.Drawing.Size(689, 24);
            this.txtNosGomlaPrice.StyleController = this.layoutControl1;
            this.txtNosGomlaPrice.TabIndex = 8;
            // 
            // chkOptional
            // 
            this.chkOptional.Location = new System.Drawing.Point(14, 467);
            this.chkOptional.Margin = new System.Windows.Forms.Padding(4);
            this.chkOptional.Name = "chkOptional";
            this.chkOptional.Properties.Caption = "منتج اختياري";
            this.chkOptional.Size = new System.Drawing.Size(689, 24);
            this.chkOptional.StyleController = this.layoutControl1;
            this.chkOptional.TabIndex = 9;
            this.chkOptional.CheckedChanged += new System.EventHandler(this.chkOptional_CheckedChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtProductName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(693, 46);
            this.layoutControlItem1.Text = "اسم المنتج";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmbCompany;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(693, 46);
            this.layoutControlItem3.Text = "الشركة";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cmbCategory;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(693, 46);
            this.layoutControlItem4.Text = "الصنف";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtDescription;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(693, 123);
            this.layoutControlItem5.Text = "الوصف";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtSellingPrice;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 261);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(693, 48);
            this.layoutControlItem6.Text = "سعر البيع";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtPurchasingPrice;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 309);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(693, 48);
            this.layoutControlItem7.Text = "سعر الشراء";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtGomlaPrice;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 357);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(693, 48);
            this.layoutControlItem8.Text = "سعر الجملة";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtNosGomlaPrice;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 405);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(693, 48);
            this.layoutControlItem9.Text = "سعر نص الجملة";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.chkOptional;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 453);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(693, 72);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // ProductCUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 603);
            this.Controls.Add(this.scrollableControl1);
            this.Controls.Add(this.panelControl2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductCUForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إدارة المنتجات";
            this.Load += new System.EventHandler(this.ProductCUForm_Load);
            this.scrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellingPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchasingPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGomlaPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNosGomlaPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOptional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl scrollableControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraEditors.LookUpEdit cmbCompany;
        private DevExpress.XtraEditors.LookUpEdit cmbCategory;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SpinEdit txtSellingPrice;
        private DevExpress.XtraEditors.SpinEdit txtPurchasingPrice;
        private DevExpress.XtraEditors.SpinEdit txtGomlaPrice;
        private DevExpress.XtraEditors.SpinEdit txtNosGomlaPrice;
        private DevExpress.XtraEditors.CheckEdit chkOptional;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton CreateBtn;
        public DevExpress.XtraEditors.SimpleButton EditBtn;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}