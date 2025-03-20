namespace ReportForm
{
    partial class Form_DT_Doanhthuksktoandien
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.clinicTMHDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportDoanhthuksktoandien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Dong = new System.Windows.Forms.Label();
            this.TuNgay = new System.Windows.Forms.DateTimePicker();
            this.btntimkiemngay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DenNgay = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportDoanhthuksktoandien
            // 
            this.reportDoanhthuksktoandien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.clinicTMHDataSetBindingSource;
            this.reportDoanhthuksktoandien.LocalReport.DataSources.Add(reportDataSource1);
            this.reportDoanhthuksktoandien.LocalReport.ReportEmbeddedResource = "ReportForm.RpDoanhThuThamMy.rdlc";
            this.reportDoanhthuksktoandien.Location = new System.Drawing.Point(0, 40);
            this.reportDoanhthuksktoandien.Name = "reportDoanhthuksktoandien";
            this.reportDoanhthuksktoandien.ServerReport.BearerToken = null;
            this.reportDoanhthuksktoandien.Size = new System.Drawing.Size(1386, 575);
            this.reportDoanhthuksktoandien.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Dong);
            this.panel2.Controls.Add(this.TuNgay);
            this.panel2.Controls.Add(this.btntimkiemngay);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DenNgay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1392, 34);
            this.panel2.TabIndex = 22;
            // 
            // Dong
            // 
            this.Dong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dong.AutoSize = true;
            this.Dong.BackColor = System.Drawing.Color.Red;
            this.Dong.Location = new System.Drawing.Point(1371, 6);
            this.Dong.Name = "Dong";
            this.Dong.Size = new System.Drawing.Size(15, 16);
            this.Dong.TabIndex = 15;
            this.Dong.Text = "X";
            this.Dong.Click += new System.EventHandler(this.Close_Click_1);
            // 
            // TuNgay
            // 
            this.TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TuNgay.Location = new System.Drawing.Point(45, 3);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Size = new System.Drawing.Size(121, 22);
            this.TuNgay.TabIndex = 9;
            // 
            // btntimkiemngay
            // 
            this.btntimkiemngay.BackColor = System.Drawing.Color.Turquoise;
            this.btntimkiemngay.Location = new System.Drawing.Point(336, 3);
            this.btntimkiemngay.Name = "btntimkiemngay";
            this.btntimkiemngay.Size = new System.Drawing.Size(96, 25);
            this.btntimkiemngay.TabIndex = 11;
            this.btntimkiemngay.Text = "Tìm kiếm";
            this.btntimkiemngay.UseVisualStyleBackColor = false;
            this.btntimkiemngay.Click += new System.EventHandler(this.btntimkiemngay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đến";
            // 
            // DenNgay
            // 
            this.DenNgay.CalendarTitleBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DenNgay.Location = new System.Drawing.Point(209, 3);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Size = new System.Drawing.Size(121, 22);
            this.DenNgay.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportDoanhthuksktoandien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1392, 578);
            this.panel1.TabIndex = 21;
            // 
            // Form_DT_Doanhthuksktoandien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_DT_Doanhthuksktoandien";
            this.Text = "Doanh thu ksk toàn diện";
            this.Load += new System.EventHandler(this.Form_DT_Doanhthuksktoandien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportDoanhthuksktoandien;
        private System.Windows.Forms.BindingSource clinicTMHDataSetBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Dong;
        private System.Windows.Forms.DateTimePicker TuNgay;
        private System.Windows.Forms.Button btntimkiemngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DenNgay;
        private System.Windows.Forms.Panel panel1;
    }
}