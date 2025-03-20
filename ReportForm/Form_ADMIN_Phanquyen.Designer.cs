namespace ReportForm
{
    partial class Form_ADMIN_Phanquyen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Dong = new System.Windows.Forms.Label();
            this.dtgMenus = new System.Windows.Forms.DataGridView();
            this.btnThemquyen = new System.Windows.Forms.Button();
            this.cbbTentaikhoan = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbbquyen = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txttaikhoan = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnxoataikhoan = new System.Windows.Forms.Button();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnthemtaikhoan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnsuataikhoan = new System.Windows.Forms.Button();
            this.dtguser = new System.Windows.Forms.DataGridView();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtguser_menus = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMenus)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtguser)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtguser_menus)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dong
            // 
            this.Dong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dong.AutoSize = true;
            this.Dong.BackColor = System.Drawing.Color.Red;
            this.Dong.Location = new System.Drawing.Point(1897, 9);
            this.Dong.Name = "Dong";
            this.Dong.Size = new System.Drawing.Size(15, 16);
            this.Dong.TabIndex = 16;
            this.Dong.Text = "X";
            // 
            // dtgMenus
            // 
            this.dtgMenus.AllowUserToAddRows = false;
            this.dtgMenus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan;
            this.dtgMenus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMenus.Location = new System.Drawing.Point(4, 102);
            this.dtgMenus.Name = "dtgMenus";
            this.dtgMenus.RowHeadersWidth = 51;
            this.dtgMenus.RowTemplate.Height = 24;
            this.dtgMenus.Size = new System.Drawing.Size(639, 740);
            this.dtgMenus.TabIndex = 17;
            // 
            // btnThemquyen
            // 
            this.btnThemquyen.BackColor = System.Drawing.Color.Tan;
            this.btnThemquyen.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnThemquyen.FlatAppearance.BorderSize = 2;
            this.btnThemquyen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnThemquyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemquyen.Location = new System.Drawing.Point(320, 51);
            this.btnThemquyen.Name = "btnThemquyen";
            this.btnThemquyen.Size = new System.Drawing.Size(130, 33);
            this.btnThemquyen.TabIndex = 18;
            this.btnThemquyen.Text = "Lưu quyền";
            this.btnThemquyen.UseVisualStyleBackColor = true;
            this.btnThemquyen.Click += new System.EventHandler(this.btnThemquyen_Click);
            // 
            // cbbTentaikhoan
            // 
            this.cbbTentaikhoan.BackColor = System.Drawing.Color.White;
            this.cbbTentaikhoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTentaikhoan.FormattingEnabled = true;
            this.cbbTentaikhoan.Location = new System.Drawing.Point(193, 51);
            this.cbbTentaikhoan.Name = "cbbTentaikhoan";
            this.cbbTentaikhoan.Size = new System.Drawing.Size(121, 24);
            this.cbbTentaikhoan.TabIndex = 19;
            this.cbbTentaikhoan.SelectedIndexChanged += new System.EventHandler(this.cbbTentaikhoan_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnThemquyen);
            this.panel1.Controls.Add(this.dtgMenus);
            this.panel1.Controls.Add(this.cbbTentaikhoan);
            this.panel1.Location = new System.Drawing.Point(15, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 849);
            this.panel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "User:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(640, 42);
            this.panel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(231, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm, xóa quyền user";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1924, 866);
            this.panel3.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(1900, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "X";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(1900, 836);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "R";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.cbbquyen);
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.txttaikhoan);
            this.panel7.Controls.Add(this.btntimkiem);
            this.panel7.Controls.Add(this.btnxoataikhoan);
            this.panel7.Controls.Add(this.txtmatkhau);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.btnthemtaikhoan);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.btnsuataikhoan);
            this.panel7.Controls.Add(this.dtguser);
            this.panel7.Location = new System.Drawing.Point(671, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(650, 849);
            this.panel7.TabIndex = 33;
            // 
            // cbbquyen
            // 
            this.cbbquyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbquyen.FormattingEnabled = true;
            this.cbbquyen.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbbquyen.Location = new System.Drawing.Point(230, 72);
            this.cbbquyen.Name = "cbbquyen";
            this.cbbquyen.Size = new System.Drawing.Size(78, 24);
            this.cbbquyen.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(640, 42);
            this.panel4.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(254, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thêm, xóa user";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Quyền:";
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.Location = new System.Drawing.Point(85, 48);
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(121, 22);
            this.txttaikhoan.TabIndex = 22;
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.Color.Aqua;
            this.btntimkiem.Location = new System.Drawing.Point(491, 47);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(72, 47);
            this.btntimkiem.TabIndex = 30;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnxoataikhoan
            // 
            this.btnxoataikhoan.BackColor = System.Drawing.Color.Red;
            this.btnxoataikhoan.Location = new System.Drawing.Point(569, 47);
            this.btnxoataikhoan.Name = "btnxoataikhoan";
            this.btnxoataikhoan.Size = new System.Drawing.Size(72, 47);
            this.btnxoataikhoan.TabIndex = 26;
            this.btnxoataikhoan.Text = "Xóa";
            this.btnxoataikhoan.UseVisualStyleBackColor = false;
            this.btnxoataikhoan.Click += new System.EventHandler(this.btnxoataikhoan_Click);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(85, 72);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(121, 22);
            this.txtmatkhau.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Mật khẩu:";
            // 
            // btnthemtaikhoan
            // 
            this.btnthemtaikhoan.BackColor = System.Drawing.Color.Lime;
            this.btnthemtaikhoan.Location = new System.Drawing.Point(335, 47);
            this.btnthemtaikhoan.Name = "btnthemtaikhoan";
            this.btnthemtaikhoan.Size = new System.Drawing.Size(72, 47);
            this.btnthemtaikhoan.TabIndex = 24;
            this.btnthemtaikhoan.Text = "Thêm";
            this.btnthemtaikhoan.UseVisualStyleBackColor = false;
            this.btnthemtaikhoan.Click += new System.EventHandler(this.btnthemtaikhoan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Tài khoản:";
            // 
            // btnsuataikhoan
            // 
            this.btnsuataikhoan.BackColor = System.Drawing.Color.Yellow;
            this.btnsuataikhoan.Location = new System.Drawing.Point(413, 47);
            this.btnsuataikhoan.Name = "btnsuataikhoan";
            this.btnsuataikhoan.Size = new System.Drawing.Size(72, 47);
            this.btnsuataikhoan.TabIndex = 25;
            this.btnsuataikhoan.Text = "Sửa";
            this.btnsuataikhoan.UseVisualStyleBackColor = false;
            this.btnsuataikhoan.Click += new System.EventHandler(this.btnsuataikhoan_Click);
            // 
            // dtguser
            // 
            this.dtguser.AllowUserToAddRows = false;
            this.dtguser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Tan;
            this.dtguser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtguser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtguser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtguser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaiKhoan,
            this.MatKhau,
            this.Quyen});
            this.dtguser.Location = new System.Drawing.Point(6, 102);
            this.dtguser.Name = "dtguser";
            this.dtguser.ReadOnly = true;
            this.dtguser.RowHeadersWidth = 51;
            this.dtguser.RowTemplate.Height = 24;
            this.dtguser.Size = new System.Drawing.Size(637, 740);
            this.dtguser.TabIndex = 27;
            this.dtguser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtguser_CellClick);
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DataPropertyName = "TaiKhoan";
            this.TaiKhoan.HeaderText = "Tài khoản";
            this.TaiKhoan.MinimumWidth = 6;
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.ReadOnly = true;
            this.TaiKhoan.Width = 125;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mặt khẩu";
            this.MatKhau.MinimumWidth = 6;
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.ReadOnly = true;
            this.MatKhau.Width = 125;
            // 
            // Quyen
            // 
            this.Quyen.DataPropertyName = "Quyen";
            this.Quyen.HeaderText = "Quyền";
            this.Quyen.MinimumWidth = 6;
            this.Quyen.Name = "Quyen";
            this.Quyen.ReadOnly = true;
            this.Quyen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Quyen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Quyen.Width = 125;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dtguser_menus);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(1327, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(650, 849);
            this.panel5.TabIndex = 22;
            // 
            // dtguser_menus
            // 
            this.dtguser_menus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtguser_menus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtguser_menus.Location = new System.Drawing.Point(3, 102);
            this.dtguser_menus.Name = "dtguser_menus";
            this.dtguser_menus.RowHeadersWidth = 51;
            this.dtguser_menus.RowTemplate.Height = 24;
            this.dtguser_menus.Size = new System.Drawing.Size(637, 740);
            this.dtguser_menus.TabIndex = 22;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(640, 42);
            this.panel6.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(276, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "User - Menus";
            // 
            // Form_ADMIN_Phanquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1924, 866);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Dong);
            this.Name = "Form_ADMIN_Phanquyen";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.FormPhanquyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMenus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtguser)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtguser_menus)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Dong;
        private System.Windows.Forms.DataGridView dtgMenus;
        private System.Windows.Forms.Button btnThemquyen;
        private System.Windows.Forms.ComboBox cbbTentaikhoan;
        private System.Windows.Forms.Panel panel1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.TextBox txttaikhoan;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtguser;
        private System.Windows.Forms.Button btnxoataikhoan;
        private System.Windows.Forms.Button btnsuataikhoan;
        private System.Windows.Forms.Button btnthemtaikhoan;
        private System.Windows.Forms.ComboBox cbbquyen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Quyen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dtguser_menus;
    }
}