using System;
using System.Windows.Forms;
using System.Drawing;

namespace DesktopApp
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.DeleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.EditBtn = new DevExpress.XtraEditors.SimpleButton();
            this.NewBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SilentPrintBtn = new DevExpress.XtraEditors.SimpleButton();
            this.InvoiceBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1031, 481);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.DeleteBtn);
            this.panelControl1.Controls.Add(this.EditBtn);
            this.panelControl1.Controls.Add(this.NewBtn);
            this.panelControl1.Controls.Add(this.SilentPrintBtn);
            this.panelControl1.Controls.Add(this.InvoiceBtn);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1031, 50);
            this.panelControl1.TabIndex = 1;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Appearance.BackColor = System.Drawing.Color.Red;
            this.DeleteBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Appearance.Options.UseBackColor = true;
            this.DeleteBtn.Appearance.Options.UseFont = true;
            this.DeleteBtn.Location = new System.Drawing.Point(161, 10);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(70, 30);
            this.DeleteBtn.TabIndex = 7;
            this.DeleteBtn.Text = "حذف";
            // 
            // EditBtn
            // 
            this.EditBtn.Appearance.BackColor = System.Drawing.Color.Blue;
            this.EditBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.Appearance.Options.UseBackColor = true;
            this.EditBtn.Appearance.Options.UseFont = true;
            this.EditBtn.Location = new System.Drawing.Point(85, 10);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(70, 30);
            this.EditBtn.TabIndex = 6;
            this.EditBtn.Text = "تعديل";
            // 
            // NewBtn
            // 
            this.NewBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.NewBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBtn.Appearance.Options.UseBackColor = true;
            this.NewBtn.Appearance.Options.UseFont = true;
            this.NewBtn.Location = new System.Drawing.Point(10, 10);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(70, 30);
            this.NewBtn.TabIndex = 5;
            this.NewBtn.Text = "جديد";
            // 
            // SilentPrintBtn
            // 
            this.SilentPrintBtn.Appearance.BackColor = System.Drawing.Color.Teal;
            this.SilentPrintBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SilentPrintBtn.Appearance.Options.UseBackColor = true;
            this.SilentPrintBtn.Appearance.Options.UseFont = true;
            this.SilentPrintBtn.Location = new System.Drawing.Point(281, 10);
            this.SilentPrintBtn.Name = "SilentPrintBtn";
            this.SilentPrintBtn.Size = new System.Drawing.Size(70, 30);
            this.SilentPrintBtn.TabIndex = 1;
            this.SilentPrintBtn.Text = "طباعة";
            this.SilentPrintBtn.Click += new System.EventHandler(this.SilentPrintBtn_Click);
            // 
            // InvoiceBtn
            // 
            this.InvoiceBtn.Appearance.BackColor = System.Drawing.Color.Teal;
            this.InvoiceBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceBtn.Appearance.Options.UseBackColor = true;
            this.InvoiceBtn.Appearance.Options.UseFont = true;
            this.InvoiceBtn.Location = new System.Drawing.Point(357, 10);
            this.InvoiceBtn.Name = "InvoiceBtn";
            this.InvoiceBtn.Size = new System.Drawing.Size(85, 30);
            this.InvoiceBtn.TabIndex = 0;
            this.InvoiceBtn.Text = "معاينة";
            this.InvoiceBtn.Click += new System.EventHandler(this.InvoiceBtn_Click);
            // 
            // InvoiceForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 533);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InvoiceForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الفواتير";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InvoiceForm_FormClosed);
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton InvoiceBtn;
        private DevExpress.XtraEditors.SimpleButton SilentPrintBtn;
        private DevExpress.XtraEditors.SimpleButton DeleteBtn;
        private DevExpress.XtraEditors.SimpleButton EditBtn;
        private DevExpress.XtraEditors.SimpleButton NewBtn;
    }
}