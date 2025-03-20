namespace ReportForm
{
    partial class Form_DT_BenhNhanKSKQuayLai
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
            this.clinicTMHDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporthinhthucdenkham = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TuNgay = new System.Windows.Forms.DateTimePicker();
            this.btntimkiemngay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DenNgay = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbchinhanh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Dong = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.searchResult = new System.Windows.Forms.DataGridView();
            this.DonViCongTac_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDonViCongTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // reporthinhthucdenkham
            // 
            this.reporthinhthucdenkham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reporthinhthucdenkham.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.clinicTMHDataSetBindingSource;
            this.reporthinhthucdenkham.LocalReport.DataSources.Add(reportDataSource3);
            this.reporthinhthucdenkham.LocalReport.ReportEmbeddedResource = "ReportForm.RpDoanhThuThamMy.rdlc";
            this.reporthinhthucdenkham.Location = new System.Drawing.Point(0, 80);
            this.reporthinhthucdenkham.Name = "reporthinhthucdenkham";
            this.reporthinhthucdenkham.ServerReport.BearerToken = null;
            this.reporthinhthucdenkham.Size = new System.Drawing.Size(1386, 505);
            this.reporthinhthucdenkham.TabIndex = 0;
            // 
            // TuNgay
            // 
            this.TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TuNgay.Location = new System.Drawing.Point(45, 3);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Size = new System.Drawing.Size(111, 22);
            this.TuNgay.TabIndex = 9;
            // 
            // btntimkiemngay
            // 
            this.btntimkiemngay.BackColor = System.Drawing.Color.Turquoise;
            this.btntimkiemngay.Location = new System.Drawing.Point(606, 3);
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
            this.label2.Location = new System.Drawing.Point(162, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đến";
            // 
            // DenNgay
            // 
            this.DenNgay.CalendarTitleBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DenNgay.Location = new System.Drawing.Point(199, 3);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Size = new System.Drawing.Size(111, 22);
            this.DenNgay.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txSearch);
            this.panel2.Controls.Add(this.cbbchinhanh);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.Dong);
            this.panel2.Controls.Add(this.TuNgay);
            this.panel2.Controls.Add(this.btntimkiemngay);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DenNgay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1392, 58);
            this.panel2.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Chi nhánh";
            // 
            // cbbchinhanh
            // 
            this.cbbchinhanh.BackColor = System.Drawing.SystemColors.Window;
            this.cbbchinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbchinhanh.FormattingEnabled = true;
            this.cbbchinhanh.Items.AddRange(new object[] {
            "",
            "9-15",
            "Q7",
            "BV"});
            this.cbbchinhanh.Location = new System.Drawing.Point(395, 3);
            this.cbbchinhanh.Name = "cbbchinhanh";
            this.cbbchinhanh.Size = new System.Drawing.Size(121, 24);
            this.cbbchinhanh.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Công ty:";
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
            this.Dong.Click += new System.EventHandler(this.Dong_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchResult);
            this.panel1.Controls.Add(this.reporthinhthucdenkham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1392, 578);
            this.panel1.TabIndex = 21;
            // 
            // txSearch
            // 
            this.txSearch.Location = new System.Drawing.Point(77, 31);
            this.txSearch.Name = "txSearch";
            this.txSearch.Size = new System.Drawing.Size(625, 22);
            this.txSearch.TabIndex = 1;
            this.txSearch.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            // 
            // searchResult
            // 
            this.searchResult.AllowUserToAddRows = false;
            this.searchResult.AllowUserToDeleteRows = false;
            this.searchResult.AllowUserToResizeColumns = false;
            this.searchResult.AllowUserToResizeRows = false;
            this.searchResult.BackgroundColor = System.Drawing.Color.White;
            this.searchResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.searchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResult.ColumnHeadersVisible = false;
            this.searchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DonViCongTac_Id,
            this.TenDonViCongTac});
            this.searchResult.Location = new System.Drawing.Point(77, 64);
            this.searchResult.Name = "searchResult";
            this.searchResult.RowHeadersWidth = 51;
            this.searchResult.RowTemplate.Height = 30;
            this.searchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchResult.Size = new System.Drawing.Size(625, 10);
            this.searchResult.TabIndex = 2;
            this.searchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchResult_CellClick);
            // 
            // DonViCongTac_Id
            // 
            this.DonViCongTac_Id.DataPropertyName = "DonViCongTac_Id";
            this.DonViCongTac_Id.HeaderText = "ID";
            this.DonViCongTac_Id.MinimumWidth = 6;
            this.DonViCongTac_Id.Name = "DonViCongTac_Id";
            this.DonViCongTac_Id.ReadOnly = true;
            this.DonViCongTac_Id.Width = 50;
            // 
            // TenDonViCongTac
            // 
            this.TenDonViCongTac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenDonViCongTac.DataPropertyName = "TenDonViCongTac";
            this.TenDonViCongTac.HeaderText = "Tên công ty";
            this.TenDonViCongTac.MinimumWidth = 6;
            this.TenDonViCongTac.Name = "TenDonViCongTac";
            this.TenDonViCongTac.ReadOnly = true;
            // 
            // Form_DT_BenhNhanKSKQuayLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_DT_BenhNhanKSKQuayLai";
            this.Text = "Bệnh nhân ksk quay lại khám";
            this.Load += new System.EventHandler(this.Form_DT_BenhNhanKSKQuayLai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reporthinhthucdenkham;
        private System.Windows.Forms.BindingSource clinicTMHDataSetBindingSource;
        private System.Windows.Forms.DateTimePicker TuNgay;
        private System.Windows.Forms.Button btntimkiemngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DenNgay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Dong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbchinhanh;
        private System.Windows.Forms.DataGridView searchResult;
        private System.Windows.Forms.TextBox txSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViCongTac_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDonViCongTac;
    }
}