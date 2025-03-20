namespace ReportForm
{
    partial class Form_DT_Doanhthutheochuyenkhoa
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportdoanhthutheochuyenkhoa = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkkhtumuadakhoa = new System.Windows.Forms.CheckBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.chkkhtumuabv = new System.Windows.Forms.CheckBox();
            this.chktaimuihong = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkdalieu = new System.Windows.Forms.CheckBox();
            this.chkgannhiem = new System.Windows.Forms.CheckBox();
            this.chkmat = new System.Windows.Forms.CheckBox();
            this.chksanphu = new System.Windows.Forms.CheckBox();
            this.chktongquat = new System.Windows.Forms.CheckBox();
            this.chktimmach = new System.Windows.Forms.CheckBox();
            this.chkranghammat = new System.Windows.Forms.CheckBox();
            this.chktieuhoa = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbchinhanh = new System.Windows.Forms.ComboBox();
            this.Dong = new System.Windows.Forms.Label();
            this.TuNgay = new System.Windows.Forms.DateTimePicker();
            this.btntimkiemngay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DenNgay = new System.Windows.Forms.DateTimePicker();
            this.clinicTMHDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportdoanhthutheochuyenkhoa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1392, 497);
            this.panel1.TabIndex = 19;
            // 
            // reportdoanhthutheochuyenkhoa
            // 
            this.reportdoanhthutheochuyenkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.clinicTMHDataSetBindingSource;
            this.reportdoanhthutheochuyenkhoa.LocalReport.DataSources.Add(reportDataSource2);
            this.reportdoanhthutheochuyenkhoa.LocalReport.ReportEmbeddedResource = "ReportForm.RpDoanhThuThamMy.rdlc";
            this.reportdoanhthutheochuyenkhoa.Location = new System.Drawing.Point(0, 3);
            this.reportdoanhthutheochuyenkhoa.Name = "reportdoanhthutheochuyenkhoa";
            this.reportdoanhthutheochuyenkhoa.ServerReport.BearerToken = null;
            this.reportdoanhthutheochuyenkhoa.Size = new System.Drawing.Size(1386, 528);
            this.reportdoanhthutheochuyenkhoa.TabIndex = 0;
            // 
            // chkkhtumuadakhoa
            // 
            this.chkkhtumuadakhoa.AutoSize = true;
            this.chkkhtumuadakhoa.Location = new System.Drawing.Point(1049, 45);
            this.chkkhtumuadakhoa.Name = "chkkhtumuadakhoa";
            this.chkkhtumuadakhoa.Size = new System.Drawing.Size(149, 20);
            this.chkkhtumuadakhoa.TabIndex = 29;
            this.chkkhtumuadakhoa.Text = "KH tự mua - Đa khoa";
            this.chkkhtumuadakhoa.UseVisualStyleBackColor = true;
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Location = new System.Drawing.Point(651, 7);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(100, 20);
            this.chkall.TabIndex = 28;
            this.chkall.Text = "CHECK ALL";
            this.chkall.UseVisualStyleBackColor = true;
            // 
            // chkkhtumuabv
            // 
            this.chkkhtumuabv.AutoSize = true;
            this.chkkhtumuabv.Location = new System.Drawing.Point(885, 45);
            this.chkkhtumuabv.Name = "chkkhtumuabv";
            this.chkkhtumuabv.Size = new System.Drawing.Size(158, 20);
            this.chkkhtumuabv.TabIndex = 27;
            this.chkkhtumuabv.Text = "KH tự mua - Bệnh viện";
            this.chkkhtumuabv.UseVisualStyleBackColor = true;
            // 
            // chktaimuihong
            // 
            this.chktaimuihong.AutoSize = true;
            this.chktaimuihong.Location = new System.Drawing.Point(773, 45);
            this.chktaimuihong.Name = "chktaimuihong";
            this.chktaimuihong.Size = new System.Drawing.Size(106, 20);
            this.chktaimuihong.TabIndex = 26;
            this.chktaimuihong.Text = "Tai mũi họng";
            this.chktaimuihong.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkkhtumuadakhoa);
            this.panel2.Controls.Add(this.chkall);
            this.panel2.Controls.Add(this.chkkhtumuabv);
            this.panel2.Controls.Add(this.chktaimuihong);
            this.panel2.Controls.Add(this.chkdalieu);
            this.panel2.Controls.Add(this.chkgannhiem);
            this.panel2.Controls.Add(this.chkmat);
            this.panel2.Controls.Add(this.chksanphu);
            this.panel2.Controls.Add(this.chktongquat);
            this.panel2.Controls.Add(this.chktimmach);
            this.panel2.Controls.Add(this.chkranghammat);
            this.panel2.Controls.Add(this.chktieuhoa);
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
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1392, 81);
            this.panel2.TabIndex = 20;
            // 
            // chkdalieu
            // 
            this.chkdalieu.AutoSize = true;
            this.chkdalieu.Location = new System.Drawing.Point(696, 45);
            this.chkdalieu.Name = "chkdalieu";
            this.chkdalieu.Size = new System.Drawing.Size(71, 20);
            this.chkdalieu.TabIndex = 25;
            this.chkdalieu.Text = "Da liễu";
            this.chkdalieu.UseVisualStyleBackColor = true;
            // 
            // chkgannhiem
            // 
            this.chkgannhiem.AutoSize = true;
            this.chkgannhiem.Location = new System.Drawing.Point(590, 45);
            this.chkgannhiem.Name = "chkgannhiem";
            this.chkgannhiem.Size = new System.Drawing.Size(100, 20);
            this.chkgannhiem.TabIndex = 24;
            this.chkgannhiem.Text = "Gan - nhiễm";
            this.chkgannhiem.UseVisualStyleBackColor = true;
            // 
            // chkmat
            // 
            this.chkmat.AutoSize = true;
            this.chkmat.Location = new System.Drawing.Point(533, 45);
            this.chkmat.Name = "chkmat";
            this.chkmat.Size = new System.Drawing.Size(51, 20);
            this.chkmat.TabIndex = 23;
            this.chkmat.Text = "Mắt";
            this.chkmat.UseVisualStyleBackColor = true;
            // 
            // chksanphu
            // 
            this.chksanphu.AutoSize = true;
            this.chksanphu.Location = new System.Drawing.Point(323, 45);
            this.chksanphu.Name = "chksanphu";
            this.chksanphu.Size = new System.Drawing.Size(78, 20);
            this.chksanphu.TabIndex = 22;
            this.chksanphu.Text = "Sản phụ";
            this.chksanphu.UseVisualStyleBackColor = true;
            // 
            // chktongquat
            // 
            this.chktongquat.AutoSize = true;
            this.chktongquat.Location = new System.Drawing.Point(227, 45);
            this.chktongquat.Name = "chktongquat";
            this.chktongquat.Size = new System.Drawing.Size(90, 20);
            this.chktongquat.TabIndex = 21;
            this.chktongquat.Text = "Tổng quát";
            this.chktongquat.UseVisualStyleBackColor = true;
            // 
            // chktimmach
            // 
            this.chktimmach.AutoSize = true;
            this.chktimmach.Location = new System.Drawing.Point(133, 45);
            this.chktimmach.Name = "chktimmach";
            this.chktimmach.Size = new System.Drawing.Size(88, 20);
            this.chktimmach.TabIndex = 20;
            this.chktimmach.Text = "Tim mạch";
            this.chktimmach.UseVisualStyleBackColor = true;
            // 
            // chkranghammat
            // 
            this.chkranghammat.AutoSize = true;
            this.chkranghammat.Location = new System.Drawing.Point(411, 45);
            this.chkranghammat.Name = "chkranghammat";
            this.chkranghammat.Size = new System.Drawing.Size(116, 20);
            this.chkranghammat.TabIndex = 19;
            this.chkranghammat.Text = "Răng hàm mặt";
            this.chkranghammat.UseVisualStyleBackColor = true;
            // 
            // chktieuhoa
            // 
            this.chktieuhoa.AutoSize = true;
            this.chktieuhoa.Location = new System.Drawing.Point(45, 45);
            this.chktieuhoa.Name = "chktieuhoa";
            this.chktieuhoa.Size = new System.Drawing.Size(82, 20);
            this.chktieuhoa.TabIndex = 18;
            this.chktieuhoa.Text = "Tiêu hóa";
            this.chktieuhoa.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Chi nhánh";
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
            this.cbbchinhanh.Location = new System.Drawing.Point(410, 4);
            this.cbbchinhanh.Name = "cbbchinhanh";
            this.cbbchinhanh.Size = new System.Drawing.Size(121, 24);
            this.cbbchinhanh.TabIndex = 16;
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
            this.btntimkiemngay.Location = new System.Drawing.Point(537, 3);
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
            // Form_DT_Doanhthutheochuyenkhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 578);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form_DT_Doanhthutheochuyenkhoa";
            this.Text = "Doanh thu theo chuyên khoa";
            this.Load += new System.EventHandler(this.Form_DT_Doanhthutheochuyenkhoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicTMHDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportdoanhthutheochuyenkhoa;
        private System.Windows.Forms.BindingSource clinicTMHDataSetBindingSource;
        private System.Windows.Forms.CheckBox chkkhtumuadakhoa;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.CheckBox chkkhtumuabv;
        private System.Windows.Forms.CheckBox chktaimuihong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkdalieu;
        private System.Windows.Forms.CheckBox chkgannhiem;
        private System.Windows.Forms.CheckBox chkmat;
        private System.Windows.Forms.CheckBox chksanphu;
        private System.Windows.Forms.CheckBox chktongquat;
        private System.Windows.Forms.CheckBox chktimmach;
        private System.Windows.Forms.CheckBox chkranghammat;
        private System.Windows.Forms.CheckBox chktieuhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbchinhanh;
        private System.Windows.Forms.Label Dong;
        private System.Windows.Forms.DateTimePicker TuNgay;
        private System.Windows.Forms.Button btntimkiemngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DenNgay;
    }
}