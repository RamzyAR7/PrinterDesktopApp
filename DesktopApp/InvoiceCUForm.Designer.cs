namespace DesktopApp
{
    partial class InvoiceCUForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose dbContext from code-behind
                var form = this as InvoiceCUForm;
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
            this.groupControlClientData = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.dtInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerPhone = new DevExpress.XtraEditors.TextEdit();
            this.groupControlAddProduct = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.spinQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDiscount = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtNetAmount = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveAndPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAndPreview = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.EditBtn = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.scrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlClientData)).BeginInit();
            this.groupControlClientData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddProduct)).BeginInit();
            this.groupControlAddProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrollableControl1
            // 
            this.scrollableControl1.Controls.Add(this.panelControl1);
            this.scrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.scrollableControl1.Margin = new System.Windows.Forms.Padding(4);
            this.scrollableControl1.Name = "scrollableControl1";
            this.scrollableControl1.Size = new System.Drawing.Size(1000, 675);
            this.scrollableControl1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1000, 675);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupControl1.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.Appearance.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AutoSize = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.groupControlClientData);
            this.groupControl1.Controls.Add(this.groupControlAddProduct);
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(996, 669);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "بيانات الفاتورة";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // groupControlClientData
            // 
            this.groupControlClientData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlClientData.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControlClientData.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupControlClientData.Appearance.Options.UseFont = true;
            this.groupControlClientData.Appearance.Options.UseForeColor = true;
            this.groupControlClientData.AppearanceCaption.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlClientData.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.groupControlClientData.AppearanceCaption.ForeColor = System.Drawing.Color.Navy;
            this.groupControlClientData.AppearanceCaption.Options.UseBackColor = true;
            this.groupControlClientData.AppearanceCaption.Options.UseFont = true;
            this.groupControlClientData.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlClientData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControlClientData.Controls.Add(this.labelControl4);
            this.groupControlClientData.Controls.Add(this.labelControl3);
            this.groupControlClientData.Controls.Add(this.labelControl2);
            this.groupControlClientData.Controls.Add(this.labelControl1);
            this.groupControlClientData.Controls.Add(this.txtInvoiceNumber);
            this.groupControlClientData.Controls.Add(this.dtInvoiceDate);
            this.groupControlClientData.Controls.Add(this.txtCustomerName);
            this.groupControlClientData.Controls.Add(this.txtCustomerPhone);
            this.groupControlClientData.Location = new System.Drawing.Point(2, 29);
            this.groupControlClientData.Name = "groupControlClientData";
            this.groupControlClientData.Size = new System.Drawing.Size(983, 92);
            this.groupControlClientData.TabIndex = 0;
            this.groupControlClientData.Text = "بيانات العميل والفاتورة";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(158, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 21);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "رقم الهاتف:";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(457, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 21);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "اسم العميل:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(679, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 21);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "تاريخ الفاتورة";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(876, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "رقم الفاتورة";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(791, 56);
            this.txtInvoiceNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtInvoiceNumber.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtInvoiceNumber.Properties.Appearance.Options.UseFont = true;
            this.txtInvoiceNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtInvoiceNumber.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.LightGray;
            this.txtInvoiceNumber.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtInvoiceNumber.Properties.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(180, 28);
            this.txtInvoiceNumber.TabIndex = 0;
            this.txtInvoiceNumber.EditValueChanged += new System.EventHandler(this.txtInvoiceNumber_EditValueChanged);
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.EditValue = null;
            this.dtInvoiceDate.Location = new System.Drawing.Point(583, 56);
            this.dtInvoiceDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtInvoiceDate.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.dtInvoiceDate.Properties.Appearance.Options.UseFont = true;
            this.dtInvoiceDate.Properties.Appearance.Options.UseForeColor = true;
            this.dtInvoiceDate.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Blue;
            this.dtInvoiceDate.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.dtInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInvoiceDate.Size = new System.Drawing.Size(200, 28);
            this.dtInvoiceDate.TabIndex = 1;
            this.dtInvoiceDate.EditValueChanged += new System.EventHandler(this.dtInvoiceDate_EditValueChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(260, 56);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCustomerName.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.Properties.Appearance.Options.UseForeColor = true;
            this.txtCustomerName.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Blue;
            this.txtCustomerName.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtCustomerName.Size = new System.Drawing.Size(298, 28);
            this.txtCustomerName.TabIndex = 2;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(15, 56);
            this.txtCustomerPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCustomerPhone.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtCustomerPhone.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerPhone.Properties.Appearance.Options.UseForeColor = true;
            this.txtCustomerPhone.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Blue;
            this.txtCustomerPhone.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(235, 28);
            this.txtCustomerPhone.TabIndex = 3;
            this.txtCustomerPhone.EditValueChanged += new System.EventHandler(this.txtCustomerPhone_EditValueChanged);
            // 
            // groupControlAddProduct
            // 
            this.groupControlAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlAddProduct.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControlAddProduct.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupControlAddProduct.Appearance.Options.UseFont = true;
            this.groupControlAddProduct.Appearance.Options.UseForeColor = true;
            this.groupControlAddProduct.AppearanceCaption.BackColor = System.Drawing.Color.LightGreen;
            this.groupControlAddProduct.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.groupControlAddProduct.AppearanceCaption.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupControlAddProduct.AppearanceCaption.Options.UseBackColor = true;
            this.groupControlAddProduct.AppearanceCaption.Options.UseFont = true;
            this.groupControlAddProduct.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlAddProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControlAddProduct.Controls.Add(this.labelControl5);
            this.groupControlAddProduct.Controls.Add(this.cmbCompany);
            this.groupControlAddProduct.Controls.Add(this.cmbCategory);
            this.groupControlAddProduct.Controls.Add(this.cmbProduct);
            this.groupControlAddProduct.Controls.Add(this.spinQuantity);
            this.groupControlAddProduct.Controls.Add(this.btnAddItem);
            this.groupControlAddProduct.Location = new System.Drawing.Point(5, 120);
            this.groupControlAddProduct.Name = "groupControlAddProduct";
            this.groupControlAddProduct.Size = new System.Drawing.Size(981, 99);
            this.groupControlAddProduct.TabIndex = 1;
            this.groupControlAddProduct.Text = "إضافة منتج للفاتورة";
            this.groupControlAddProduct.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControlAddProduct_Paint);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(720, 70);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 24);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "الكمية:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Location = new System.Drawing.Point(730, 30);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbCompany.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmbCompany.Properties.Appearance.Options.UseFont = true;
            this.cmbCompany.Properties.Appearance.Options.UseForeColor = true;
            this.cmbCompany.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Green;
            this.cmbCompany.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.cmbCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCompany.Properties.ImmediatePopup = true;
            this.cmbCompany.Properties.NullText = "ابحث واختر الشركة...";
            this.cmbCompany.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbCompany.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbCompany.Size = new System.Drawing.Size(238, 28);
            this.cmbCompany.TabIndex = 4;
            this.cmbCompany.EditValueChanged += new System.EventHandler(this.cmbCompany_EditValueChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(450, 30);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbCategory.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmbCategory.Properties.Appearance.Options.UseFont = true;
            this.cmbCategory.Properties.Appearance.Options.UseForeColor = true;
            this.cmbCategory.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Green;
            this.cmbCategory.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.cmbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCategory.Properties.ImmediatePopup = true;
            this.cmbCategory.Properties.NullText = "ابحث واختر الصنف...";
            this.cmbCategory.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbCategory.Size = new System.Drawing.Size(270, 28);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.EditValueChanged += new System.EventHandler(this.cmbCategory_EditValueChanged);
            // 
            // cmbProduct
            // 
            this.cmbProduct.Location = new System.Drawing.Point(15, 30);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbProduct.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmbProduct.Properties.Appearance.Options.UseFont = true;
            this.cmbProduct.Properties.Appearance.Options.UseForeColor = true;
            this.cmbProduct.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Green;
            this.cmbProduct.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.cmbProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProduct.Properties.ImmediatePopup = true;
            this.cmbProduct.Properties.NullText = "ابحث واختر المنتج...";
            this.cmbProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProduct.Size = new System.Drawing.Size(425, 28);
            this.cmbProduct.TabIndex = 6;
            this.cmbProduct.EditValueChanged += new System.EventHandler(this.cmbProduct_EditValueChanged);
            // 
            // spinQuantity
            // 
            this.spinQuantity.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinQuantity.Location = new System.Drawing.Point(620, 67);
            this.spinQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.spinQuantity.Name = "spinQuantity";
            this.spinQuantity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.spinQuantity.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinQuantity.Properties.Appearance.Options.UseFont = true;
            this.spinQuantity.Properties.Appearance.Options.UseForeColor = true;
            this.spinQuantity.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Orange;
            this.spinQuantity.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.spinQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQuantity.Properties.IsFloatValue = false;
            this.spinQuantity.Properties.MaskSettings.Set("mask", "N00");
            this.spinQuantity.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.spinQuantity.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinQuantity.Size = new System.Drawing.Size(90, 28);
            this.spinQuantity.TabIndex = 7;
            this.spinQuantity.EditValueChanged += new System.EventHandler(this.spinQuantity_EditValueChanged);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddItem.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Appearance.Options.UseBackColor = true;
            this.btnAddItem.Appearance.Options.UseFont = true;
            this.btnAddItem.Appearance.Options.UseForeColor = true;
            this.btnAddItem.AppearanceHovered.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddItem.AppearanceHovered.Options.UseBackColor = true;
            this.btnAddItem.AppearancePressed.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAddItem.AppearancePressed.Options.UseBackColor = true;
            this.btnAddItem.Location = new System.Drawing.Point(300, 65);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(200, 30);
            this.btnAddItem.TabIndex = 8;
            this.btnAddItem.Text = "إضافة منتج للفاتورة";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlItems);
            this.layoutControl1.Controls.Add(this.txtDiscount);
            this.layoutControl1.Controls.Add(this.txtTotalAmount);
            this.layoutControl1.Controls.Add(this.txtNetAmount);
            this.layoutControl1.Location = new System.Drawing.Point(11, 227);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(984, 438);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlItems
            // 
            this.gridControlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlItems.Location = new System.Drawing.Point(12, 31);
            this.gridControlItems.MainView = this.gridViewItems;
            this.gridControlItems.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.Size = new System.Drawing.Size(960, 336);
            this.gridControlItems.TabIndex = 10;
            this.gridControlItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems,
            this.gridView1});
            // 
            // gridViewItems
            // 
            this.gridViewItems.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightBlue;
            this.gridViewItems.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewItems.Appearance.HeaderPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.gridViewItems.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridViewItems.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gridViewItems.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewItems.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewItems.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewItems.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridViewItems.Appearance.Row.Options.UseFont = true;
            this.gridViewItems.GridControl = this.gridControlItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlItems;
            this.gridView1.Name = "gridView1";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(360, 396);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Properties.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.txtDiscount.Properties.Appearance.Options.UseFont = true;
            this.txtDiscount.Properties.Appearance.Options.UseForeColor = true;
            this.txtDiscount.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Red;
            this.txtDiscount.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtDiscount.Properties.NullText = "أدخل قيمة الخصم";
            this.txtDiscount.Properties.NullValuePrompt = "أدخل قيمة الخصم";
            this.txtDiscount.Size = new System.Drawing.Size(287, 28);
            this.txtDiscount.StyleController = this.layoutControl1;
            this.txtDiscount.TabIndex = 11;
            this.txtDiscount.EditValueChanged += new System.EventHandler(this.txtDiscount_EditValueChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(651, 396);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtTotalAmount.Properties.Appearance.Options.UseFont = true;
            this.txtTotalAmount.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotalAmount.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.LightCyan;
            this.txtTotalAmount.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtTotalAmount.Properties.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(321, 28);
            this.txtTotalAmount.StyleController = this.layoutControl1;
            this.txtTotalAmount.TabIndex = 12;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(12, 396);
            this.txtNetAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtNetAmount.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtNetAmount.Properties.Appearance.Options.UseFont = true;
            this.txtNetAmount.Properties.Appearance.Options.UseForeColor = true;
            this.txtNetAmount.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.LightGreen;
            this.txtNetAmount.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtNetAmount.Properties.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(344, 30);
            this.txtNetAmount.StyleController = this.layoutControl1;
            this.txtNetAmount.TabIndex = 13;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.layoutControlItem13,
            this.layoutControlItem12,
            this.layoutControlItem14});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(984, 438);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.gridControlItems;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(964, 359);
            this.layoutControlItem11.Text = "المنتجات";
            this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(116, 16);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem13.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem13.Control = this.txtTotalAmount;
            this.layoutControlItem13.Location = new System.Drawing.Point(639, 359);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(325, 59);
            this.layoutControlItem13.Text = "المجموع";
            this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(116, 22);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.Control = this.txtDiscount;
            this.layoutControlItem12.Location = new System.Drawing.Point(348, 359);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(291, 59);
            this.layoutControlItem12.Text = "الخصم";
            this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(116, 22);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem14.Control = this.txtNetAmount;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 359);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(348, 59);
            this.layoutControlItem14.Text = "الاجمــــــــالى";
            this.layoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(116, 22);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSaveAndPrint);
            this.panelControl2.Controls.Add(this.btnSaveAndPreview);
            this.panelControl2.Controls.Add(this.BtnCreate);
            this.panelControl2.Controls.Add(this.EditBtn);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 675);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1000, 85);
            this.panelControl2.TabIndex = 1;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // btnSaveAndPrint
            // 
            this.btnSaveAndPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndPrint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSaveAndPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveAndPrint.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndPrint.Appearance.Options.UseBackColor = true;
            this.btnSaveAndPrint.Appearance.Options.UseFont = true;
            this.btnSaveAndPrint.Appearance.Options.UseForeColor = true;
            this.btnSaveAndPrint.Location = new System.Drawing.Point(457, 12);
            this.btnSaveAndPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAndPrint.Name = "btnSaveAndPrint";
            this.btnSaveAndPrint.Size = new System.Drawing.Size(156, 36);
            this.btnSaveAndPrint.TabIndex = 5;
            this.btnSaveAndPrint.Text = "حفظ وطباعة";
            this.btnSaveAndPrint.Click += new System.EventHandler(this.btnSaveAndPrint_Click);
            // 
            // btnSaveAndPreview
            // 
            this.btnSaveAndPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndPreview.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnSaveAndPreview.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveAndPreview.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndPreview.Appearance.Options.UseBackColor = true;
            this.btnSaveAndPreview.Appearance.Options.UseFont = true;
            this.btnSaveAndPreview.Appearance.Options.UseForeColor = true;
            this.btnSaveAndPreview.Location = new System.Drawing.Point(627, 12);
            this.btnSaveAndPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAndPreview.Name = "btnSaveAndPreview";
            this.btnSaveAndPreview.Size = new System.Drawing.Size(150, 36);
            this.btnSaveAndPreview.TabIndex = 6;
            this.btnSaveAndPreview.Text = "حفظ ومعاينة";
            this.btnSaveAndPreview.Click += new System.EventHandler(this.btnSaveAndPreview_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCreate.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.BtnCreate.Appearance.Options.UseFont = true;
            this.BtnCreate.Location = new System.Drawing.Point(795, 12);
            this.BtnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(155, 36);
            this.BtnCreate.TabIndex = 4;
            this.BtnCreate.Text = "حفظ";
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.EditBtn.Appearance.Options.UseFont = true;
            this.EditBtn.Location = new System.Drawing.Point(830, 12);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(4);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(120, 36);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "تعديل";
            this.EditBtn.Visible = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(20, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "إلغاء";
            // 
            // InvoiceCUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 760);
            this.Controls.Add(this.scrollableControl1);
            this.Controls.Add(this.panelControl2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 700);
            this.Name = "InvoiceCUForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة الفواتير";
            this.Load += new System.EventHandler(this.InvoiceCUForm_Load);
            this.scrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlClientData)).EndInit();
            this.groupControlClientData.ResumeLayout(false);
            this.groupControlClientData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddProduct)).EndInit();
            this.groupControlAddProduct.ResumeLayout(false);
            this.groupControlAddProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl scrollableControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControlClientData;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNumber;
        private DevExpress.XtraEditors.DateEdit dtInvoiceDate;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerPhone;
        private DevExpress.XtraEditors.GroupControl groupControlAddProduct;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit cmbCompany;
        private DevExpress.XtraEditors.LookUpEdit cmbCategory;
        private DevExpress.XtraEditors.LookUpEdit cmbProduct;
        private DevExpress.XtraEditors.SpinEdit spinQuantity;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControlItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraEditors.TextEdit txtDiscount;
        private DevExpress.XtraEditors.TextEdit txtTotalAmount;
        private DevExpress.XtraEditors.TextEdit txtNetAmount;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton BtnCreate;
        public DevExpress.XtraEditors.SimpleButton EditBtn;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndPrint;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
