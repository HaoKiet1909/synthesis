﻿namespace ReportForm
{
    partial class Form_KHTH_sokhambenh
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reporttinhhinhkcbtmh = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbchinhanh = new System.Windows.Forms.ComboBox();
            this.Dong = new System.Windows.Forms.Label();
            this.TuNgay = new System.Windows.Forms.DateTimePicker();
            this.btntimkiemngay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DenNgay = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clinicTMHDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reporttinhhinhkcbtmh
            // 
            this.reporttinhhinhkcbtmh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.clinicTMHDataSetBindingSource;
            this.reporttinhhinhkcbtmh.LocalReport.DataSources.Add(reportDataSource3);
            this.reporttinhhinhkcbtmh.LocalReport.ReportEmbeddedResource = "ReportForm.RpDoanhThuThamMy.rdlc";
            this.reporttinhhinhkcbtmh.Location = new System.Drawing.Point(0, 32);
            this.reporttinhhinhkcbtmh.Margin = new System.Windows.Forms.Padding(2);
            this.reporttinhhinhkcbtmh.Name = "reporttinhhinhkcbtmh";
            this.reporttinhhinhkcbtmh.ServerReport.BearerToken = null;
            this.reporttinhhinhkcbtmh.Size = new System.Drawing.Size(1287, 554);
            this.reporttinhhinhkcbtmh.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbbchinhanh);
            this.panel2.Controls.Add(this.Dong);
            this.panel2.Controls.Add(this.TuNgay);
            this.panel2.Controls.Add(this.btntimkiemngay);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DenNgay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1291, 35);
            this.panel2.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Chi nhánh";
            // 
            // cbbchinhanh
            // 
            this.cbbchinhanh.BackColor = System.Drawing.SystemColors.Window;
            this.cbbchinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbchinhanh.FormattingEnabled = true;
            this.cbbchinhanh.Items.AddRange(new object[] {
            "BV"});
            this.cbbchinhanh.Location = new System.Drawing.Point(306, 3);
            this.cbbchinhanh.Margin = new System.Windows.Forms.Padding(2);
            this.cbbchinhanh.Name = "cbbchinhanh";
            this.cbbchinhanh.Size = new System.Drawing.Size(92, 21);
            this.cbbchinhanh.TabIndex = 22;
            // 
            // Dong
            // 
            this.Dong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dong.AutoSize = true;
            this.Dong.BackColor = System.Drawing.Color.Red;
            this.Dong.Location = new System.Drawing.Point(1275, 5);
            this.Dong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dong.Name = "Dong";
            this.Dong.Size = new System.Drawing.Size(14, 13);
            this.Dong.TabIndex = 15;
            this.Dong.Text = "X";
            this.Dong.Click += new System.EventHandler(this.Dong_Click);
            // 
            // TuNgay
            // 
            this.TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TuNgay.Location = new System.Drawing.Point(34, 2);
            this.TuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Size = new System.Drawing.Size(92, 20);
            this.TuNgay.TabIndex = 9;
            // 
            // btntimkiemngay
            // 
            this.btntimkiemngay.BackColor = System.Drawing.Color.Turquoise;
            this.btntimkiemngay.Location = new System.Drawing.Point(400, 2);
            this.btntimkiemngay.Margin = new System.Windows.Forms.Padding(2);
            this.btntimkiemngay.Name = "btntimkiemngay";
            this.btntimkiemngay.Size = new System.Drawing.Size(72, 20);
            this.btntimkiemngay.TabIndex = 11;
            this.btntimkiemngay.Text = "Tìm kiếm";
            this.btntimkiemngay.UseVisualStyleBackColor = false;
            this.btntimkiemngay.Click += new System.EventHandler(this.btntimkiemngay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đến";
            // 
            // DenNgay
            // 
            this.DenNgay.CalendarTitleBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DenNgay.Location = new System.Drawing.Point(157, 2);
            this.DenNgay.Margin = new System.Windows.Forms.Padding(2);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Size = new System.Drawing.Size(92, 20);
            this.DenNgay.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reporttinhhinhkcbtmh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 556);
            this.panel1.TabIndex = 41;
            // 
            // Form_KHTH_sokhambenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 556);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_KHTH_sokhambenh";
            this.Text = "Sổ khám bệnh";
            this.Load += new System.EventHandler(this.Form_KHTH_sokhambenh_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reporttinhhinhkcbtmh;
        private System.Windows.Forms.BindingSource clinicTMHDataSetBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbchinhanh;
        private System.Windows.Forms.Label Dong;
        private System.Windows.Forms.DateTimePicker TuNgay;
        private System.Windows.Forms.Button btntimkiemngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DenNgay;
        private System.Windows.Forms.Panel panel1;
    }
}