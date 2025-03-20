using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;



namespace ReportForm
{
    public partial class Main : Form
    {
        Account acc = null;
        public Main()
        {
            InitializeComponent();
        }
        Form_DT_Thammy formThamMy;
        Form_DT_Banthuoctieuhoa formbanthuoctieuhoa;
        Form_MKT_Soluotkham formSoluotkham;
        Form_MKT_Tongdoanhthumotkhach formTongdoanhthumotkhach;
        Form_DT_Banmypham formBanmypham;
        Form_ADMIN_Phanquyen formPhanquyen;
        Form_ADMIN_doimatkhau formdoimatkhau;
        Form_CSKH_Hoatdongbaocaokhoakhambenh formHoatdongbaocaokhoakhambenh;
        Form_CSKH_Bangkethutientheonoidung form_CSKH_Bangkethutientheonoidung;
        Form_CSKH_Listbenhnhantheongaysinh form_CSKH_Listbenhnhantheongaysinh;
        Form_CSKH_Canhbaotiemchuan form_CSKH_Canhbaotiemchuan;
        Form_CSKH_Hinhthucdenkham form_CSKH_hinhthucdenkham;
        Form_CSKH_Hoatdonghangngayphongkham form_CSKH_Hoatdonghangngayphongkham;
        Form_CSKH_Thongkegoikhamtoandienvachuyenkhoa form_CSKH_Thongkegoikhamtoandienvachuyenkhoa;
        Form_CSKH_Danhsachchamsoctieuhoa form_CSKH_Danhsachchamsoctieuhoa;
        Form_DT_Doanhthuksktoandien form_DT_Doanhthuksktoandien;
        Form_TNIEN_Danhsachkhamrhm form_TNIEN_Danhsachkhamrhm;
        Form_DT_Bandichvuphauthuat form_DT_Bandichvuphauthuat;
        Form_CP_ChiPhiNhapVPP form_CP_ChiPhiNhapVPP;
        
        SqlConnection con;
        private void Main_Load(object sender, EventArgs e)
        {
            
        }
        public Main(Account acc) // no doc acc o day
        {
            InitializeComponent();
            this.acc = acc;
            HideMenu(false);
            ShowMenu(acc);
            // if o day

        }
        /// <summary>
        /// Ẩn/Hiện hết Menu
        /// </summary>
        void HideMenu(bool b)
        {
         
            // nếu tạo  1 báo csao 2 có con là kinh doanh thì vẫn dùng cái foreach ở dưới được
            // Ẩn hiện menu con của Doanh thu
            foreach (ToolStripItem item in Menudoanhthu.DropDownItems)
            {
                item.Visible = b;
            }
            // Ẩn hiện Menu con của Marketing
            foreach (ToolStripItem item in Menumarketing.DropDownItems)
            {
                item.Visible = b;
            }

            // Ẩn hiện Menu con của CSKH
            foreach (ToolStripItem item in MenuCskh.DropDownItems)
            {
                item.Visible = b;
            }

            foreach (ToolStripItem item in MenuChiphi.DropDownItems)
            {
                item.Visible = b;
            }
            foreach (ToolStripItem item in MenuThuongnien.DropDownItems)
            {
                item.Visible = b;
            }
            foreach (ToolStripItem item in Menutinhhinhhoatdongpktmh68.DropDownItems)
            {
                item.Visible = b;
            }

            foreach (ToolStripItem item in Menukhth.DropDownItems)
            {
                item.Visible = b;
            }



        }
        /// <summary>
        /// Hiện Menu theo Account
        /// </summary>
        /// <param name="acc"></param>
        void ShowMenu(Account acc)
        {
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
            bool isAdmin = acc.Quyen;
            
            if (isAdmin)//admin
            {
                HideMenu(true);
                Menuadmin.Visible = true;   
            }
            else
            { 
                Menuadmin.Visible = false;      

                // chay vong lap kiem tra hien menu
                string tk = acc.TaiKhoan;

                // select * from acc_menu where taikhoan=tk => list 

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Report_Acc_Menus where TaiKhoan = '" + tk + "'", con);
                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        string menu = row["MenuCode"].ToString();
                      
                        // Dò trong danh sách menu cái nào có thì visible 



                        foreach (ToolStripItem item in Menudoanhthu.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                              
                                break;
                            }
                        }
                       
                        foreach (ToolStripItem item in Menumarketing.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                              break ;
                               
                            }
                        }
                        foreach (ToolStripItem item in MenuCskh.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                                break;

                            }
                        }
                        foreach (ToolStripItem item in MenuChiphi.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                                break;

                            }
                        }
                        foreach (ToolStripItem item in MenuThuongnien.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                                break;

                            }
                        }
                        foreach (ToolStripItem item in Menutinhhinhhoatdongpktmh68.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                                break;

                            }
                        }
                        foreach (ToolStripItem item in Menukhth.DropDownItems)
                        {
                            if (item.Name == menu)
                            {
                                item.Visible = true;
                                break;

                            }
                        }


                    }
                }
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab != null && this.tabMain.SelectedTab.Tag != null)
            {
                (this.tabMain.SelectedTab.Tag as Form).Select();
            }
        }

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            if (this.ActiveMdiChild.Tag == null)
            {
                TabPage tm = new TabPage(this.ActiveMdiChild.Text);
                tm.Tag = this.ActiveMdiChild;
                tm.Parent = this.tabMain;
                this.tabMain.SelectedTab = tm;
                this.ActiveMdiChild.Tag = tm;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }
        private void bánThuốcTiêuHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formbanthuoctieuhoa is null || this.formbanthuoctieuhoa.IsDisposed)
            {
                this.formbanthuoctieuhoa = new Form_DT_Banthuoctieuhoa();
                this.formbanthuoctieuhoa.MdiParent = this;
                formbanthuoctieuhoa.Dock = DockStyle.Fill;
                this.formbanthuoctieuhoa.Show();
            }
            else
            {
                this.formbanthuoctieuhoa.MdiParent = this;
                this.formbanthuoctieuhoa.Select();
            }
        }
        private void thẩmMỹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formThamMy is null || this.formThamMy.IsDisposed)
            {
                this.formThamMy = new Form_DT_Thammy();
                this.formThamMy.MdiParent = this;
                formThamMy.Dock = DockStyle.Fill;
                this.formThamMy.Show();
            }
            else
            {
                this.formThamMy.MdiParent = this;
                this.formThamMy.Select();
            }
        }

        private void sốLầnKhámTrênMộtKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formSoluotkham is null || this.formSoluotkham.IsDisposed)
            {
                this.formSoluotkham = new Form_MKT_Soluotkham();
                this.formSoluotkham.MdiParent = this;
                formSoluotkham.Dock = DockStyle.Fill;
                this.formSoluotkham.Show();
            }
            else
            {
                this.formSoluotkham.MdiParent = this;
                this.formSoluotkham.Select();
            }
        }

        private void doanhThuTrênMộtKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formTongdoanhthumotkhach is null || this.formTongdoanhthumotkhach.IsDisposed)
            {
                this.formTongdoanhthumotkhach = new Form_MKT_Tongdoanhthumotkhach();
                this.formTongdoanhthumotkhach.MdiParent = this;
                formTongdoanhthumotkhach.Dock = DockStyle.Fill;
                this.formTongdoanhthumotkhach.Show();
            }
            else
            {
                this.formTongdoanhthumotkhach.MdiParent = this;
                this.formTongdoanhthumotkhach.Select();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Ngăn Form đóng nếu người dùng chọn "No"
                }
                else
                {
                    Application.Exit(); // Thoát chương trình hoàn toàn
                }
            }

        }

        private void bánMỹPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formBanmypham is null || this.formBanmypham.IsDisposed)
            {
                this.formBanmypham = new Form_DT_Banmypham();
                this.formBanmypham.MdiParent = this;
                formBanmypham.Dock = DockStyle.Fill;
                this.formBanmypham.Show();
            }
            else
            {
                this.formBanmypham.MdiParent = this;
                this.formBanmypham.Select();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formPhanquyen is null || this.formPhanquyen.IsDisposed)
            {
                this.formPhanquyen = new Form_ADMIN_Phanquyen();
                this.formPhanquyen.MdiParent = this;
                formPhanquyen.Dock = DockStyle.Fill;
                this.formPhanquyen.Show();
            }
            else
            {
                this.formPhanquyen.MdiParent = this;
                this.formPhanquyen.Select();
            }
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login formlogin = new Login();
            formlogin.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formdoimatkhau is null || this.formdoimatkhau.IsDisposed)
            {
                this.formdoimatkhau = new Form_ADMIN_doimatkhau(acc);
                this.formdoimatkhau.MdiParent = this;
                formdoimatkhau.Dock = DockStyle.Fill;
                this.formdoimatkhau.Show();
            }
            else
            {
                this.formdoimatkhau.MdiParent = this;
                this.formdoimatkhau.Select();
            }
        }

        private void MenuHoatdongkhambenh_Click(object sender, EventArgs e)
        {
            if (this.formHoatdongbaocaokhoakhambenh is null || this.formHoatdongbaocaokhoakhambenh.IsDisposed)
            {
                this.formHoatdongbaocaokhoakhambenh = new Form_CSKH_Hoatdongbaocaokhoakhambenh();
                this.formHoatdongbaocaokhoakhambenh.MdiParent = this;
                formHoatdongbaocaokhoakhambenh.Dock = DockStyle.Fill;
                this.formHoatdongbaocaokhoakhambenh.Show();
            }
            else
            {
                this.formHoatdongbaocaokhoakhambenh.MdiParent = this;
                this.formHoatdongbaocaokhoakhambenh.Select();
            }
        }

        private void bảngKêThuTiềnKhámBệnhClsTheoNộiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_Bangkethutientheonoidung is null || this.form_CSKH_Bangkethutientheonoidung.IsDisposed)
            {
                this.form_CSKH_Bangkethutientheonoidung = new Form_CSKH_Bangkethutientheonoidung();
                this.form_CSKH_Bangkethutientheonoidung.MdiParent = this;
                form_CSKH_Bangkethutientheonoidung.Dock = DockStyle.Fill;
                this.form_CSKH_Bangkethutientheonoidung.Show();
            }
            else
            {
                this.form_CSKH_Bangkethutientheonoidung.MdiParent = this;
                this.form_CSKH_Bangkethutientheonoidung.Select();
            }
        }

        private void danhSáchBệnhNhânTheoNgàySinhNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_Listbenhnhantheongaysinh is null || this.form_CSKH_Listbenhnhantheongaysinh.IsDisposed)
            {
                this.form_CSKH_Listbenhnhantheongaysinh = new Form_CSKH_Listbenhnhantheongaysinh();
                this.form_CSKH_Listbenhnhantheongaysinh.MdiParent = this;
                form_CSKH_Listbenhnhantheongaysinh.Dock = DockStyle.Fill;
                this.form_CSKH_Listbenhnhantheongaysinh.Show();
            }
            else
            {
                this.form_CSKH_Listbenhnhantheongaysinh.MdiParent = this;
                this.form_CSKH_Listbenhnhantheongaysinh.Select();
            }
        }

        private void cảnhBáoTiêmChủngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_Canhbaotiemchuan is null || this.form_CSKH_Canhbaotiemchuan.IsDisposed)
            {
                this.form_CSKH_Canhbaotiemchuan = new Form_CSKH_Canhbaotiemchuan();
                this.form_CSKH_Canhbaotiemchuan.MdiParent = this;
                form_CSKH_Canhbaotiemchuan.Dock = DockStyle.Fill;
                this.form_CSKH_Canhbaotiemchuan.Show();
            }
            else
            {
                this.form_CSKH_Canhbaotiemchuan.MdiParent = this;
                this.form_CSKH_Canhbaotiemchuan.Select();
            }
        }

        private void danhSáchBệnhNhânTheoHìnhThứcĐếnKhámToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_hinhthucdenkham is null || this.form_CSKH_hinhthucdenkham.IsDisposed)
            {
                this.form_CSKH_hinhthucdenkham = new Form_CSKH_Hinhthucdenkham();
                this.form_CSKH_hinhthucdenkham.MdiParent = this;
                form_CSKH_hinhthucdenkham.Dock = DockStyle.Fill;
                this.form_CSKH_hinhthucdenkham.Show();
            }
            else
            {
                this.form_CSKH_hinhthucdenkham.MdiParent = this;
                this.form_CSKH_hinhthucdenkham.Select();
            }
        }

        private void Menuhoatdonghangngayphongkham_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_Hoatdonghangngayphongkham is null || this.form_CSKH_Hoatdonghangngayphongkham.IsDisposed)
            {
                this.form_CSKH_Hoatdonghangngayphongkham = new Form_CSKH_Hoatdonghangngayphongkham();
                this.form_CSKH_Hoatdonghangngayphongkham.MdiParent = this;
                form_CSKH_Hoatdonghangngayphongkham.Dock = DockStyle.Fill;
                this.form_CSKH_Hoatdonghangngayphongkham.Show();
            }
            else
            {
                this.form_CSKH_Hoatdonghangngayphongkham.MdiParent = this;
                this.form_CSKH_Hoatdonghangngayphongkham.Select();
            }
        }

        private void thốngKêGóiKhámToànnDiệnVàChuyênKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa is null || this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa.IsDisposed)
            {
                this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa = new Form_CSKH_Thongkegoikhamtoandienvachuyenkhoa();
                this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa.MdiParent = this;
                form_CSKH_Thongkegoikhamtoandienvachuyenkhoa.Dock = DockStyle.Fill;
                this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa.Show();
            }
            else
            {
                this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa.MdiParent = this;
                this.form_CSKH_Thongkegoikhamtoandienvachuyenkhoa.Select();
            }
        }

        private void danhSáchChămSócTiêuHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_CSKH_Danhsachchamsoctieuhoa is null || this.form_CSKH_Danhsachchamsoctieuhoa.IsDisposed)
            {
                this.form_CSKH_Danhsachchamsoctieuhoa = new Form_CSKH_Danhsachchamsoctieuhoa();
                this.form_CSKH_Danhsachchamsoctieuhoa.MdiParent = this;
                form_CSKH_Danhsachchamsoctieuhoa.Dock = DockStyle.Fill;
                this.form_CSKH_Danhsachchamsoctieuhoa.Show();
            }
            else
            {
                this.form_CSKH_Danhsachchamsoctieuhoa.MdiParent = this;
                this.form_CSKH_Danhsachchamsoctieuhoa.Select();
            }
        }

        private void bánGóiKskToànDiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_Doanhthuksktoandien is null || this.form_DT_Doanhthuksktoandien.IsDisposed)
            {
                this.form_DT_Doanhthuksktoandien = new Form_DT_Doanhthuksktoandien();
                this.form_DT_Doanhthuksktoandien.MdiParent = this;
                form_DT_Doanhthuksktoandien.Dock = DockStyle.Fill;
                this.form_DT_Doanhthuksktoandien.Show();
            }
            else
            {
                this.form_DT_Doanhthuksktoandien.MdiParent = this;
                this.form_DT_Doanhthuksktoandien.Select();
            }
        }

        private void danhSáchKhámRăngHàmMặtQ7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_TNIEN_Danhsachkhamrhm is null || this.form_TNIEN_Danhsachkhamrhm.IsDisposed)
            {
                this.form_TNIEN_Danhsachkhamrhm = new Form_TNIEN_Danhsachkhamrhm();
                this.form_TNIEN_Danhsachkhamrhm.MdiParent = this;
                form_TNIEN_Danhsachkhamrhm.Dock = DockStyle.Fill;
                this.form_TNIEN_Danhsachkhamrhm.Show();
            }
            else
            {
                this.form_TNIEN_Danhsachkhamrhm.MdiParent = this;
                this.form_TNIEN_Danhsachkhamrhm.Select();
            }
        }

        private void bánDịchVụPhẫuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_Bandichvuphauthuat is null || this.form_DT_Bandichvuphauthuat.IsDisposed)
            {
                this.form_DT_Bandichvuphauthuat = new Form_DT_Bandichvuphauthuat();
                this.form_DT_Bandichvuphauthuat.MdiParent = this;
                form_DT_Bandichvuphauthuat.Dock = DockStyle.Fill;
                this.form_DT_Bandichvuphauthuat.Show();
            }
            else
            {
                this.form_DT_Bandichvuphauthuat.MdiParent = this;
                this.form_DT_Bandichvuphauthuat.Select();
            }
        }

        private void MenuNhapvanphongpham_Click(object sender, EventArgs e)
        {
            if (this.form_CP_ChiPhiNhapVPP is null || this.form_CP_ChiPhiNhapVPP.IsDisposed)
            {
                this.form_CP_ChiPhiNhapVPP = new Form_CP_ChiPhiNhapVPP();
                this.form_CP_ChiPhiNhapVPP.MdiParent = this;
                form_CP_ChiPhiNhapVPP.Dock = DockStyle.Fill;
                this.form_CP_ChiPhiNhapVPP.Show();
            }
            else
            {
                this.form_CP_ChiPhiNhapVPP.MdiParent = this;
                this.form_CP_ChiPhiNhapVPP.Select();
            }
        }
        Form_CP_Nhapthuoc form_CP_Nhapthuoc;
        private void MenuNhapthuoc_Click(object sender, EventArgs e)
        {
            if (this.form_CP_Nhapthuoc is null || this.form_CP_Nhapthuoc.IsDisposed)
            {
                this.form_CP_Nhapthuoc = new Form_CP_Nhapthuoc();
                this.form_CP_Nhapthuoc.MdiParent = this;
                form_CP_Nhapthuoc.Dock = DockStyle.Fill;
                this.form_CP_Nhapthuoc.Show();
            }
            else
            {
                this.form_CP_Nhapthuoc.MdiParent = this;
                this.form_CP_Nhapthuoc.Select();
            }
        }
        Form_CP_NhapVatTuYTe form_CP_NhapVatTuYTe;
        private void MenuNhapvattuyte_Click(object sender, EventArgs e)
        {
            if (this.form_CP_NhapVatTuYTe is null || this.form_CP_NhapVatTuYTe.IsDisposed)
            {
                this.form_CP_NhapVatTuYTe = new Form_CP_NhapVatTuYTe();
                this.form_CP_NhapVatTuYTe.MdiParent = this;
                form_CP_NhapVatTuYTe.Dock = DockStyle.Fill;
                this.form_CP_NhapVatTuYTe.Show();
            }
            else
            {
                this.form_CP_NhapVatTuYTe.MdiParent = this;
                this.form_CP_NhapVatTuYTe.Select();
            }
        }
        Form_CP_Nhaphoachatxn form_CP_Nhaphoachatxn;
        private void MenuNhaphoachatxn_Click(object sender, EventArgs e)
        {

            if (this.form_CP_Nhaphoachatxn is null || this.form_CP_Nhaphoachatxn.IsDisposed)
            {
                this.form_CP_Nhaphoachatxn = new Form_CP_Nhaphoachatxn();
                this.form_CP_Nhaphoachatxn.MdiParent = this;
                form_CP_Nhaphoachatxn.Dock = DockStyle.Fill;
                this.form_CP_Nhaphoachatxn.Show();
            }
            else
            {
                this.form_CP_Nhaphoachatxn.MdiParent = this;
                this.form_CP_Nhaphoachatxn.Select();
            }
        }
        Form_MKT_Khachtmh form_MKT_Khachtmh;
        private void Menudanhsachkhachkhamtmh_Click(object sender, EventArgs e)
        {
            if (this.form_MKT_Khachtmh is null || this.form_MKT_Khachtmh.IsDisposed)
            {
                this.form_MKT_Khachtmh = new Form_MKT_Khachtmh();
                this.form_MKT_Khachtmh.MdiParent = this;
                form_MKT_Khachtmh.Dock = DockStyle.Fill;
                this.form_MKT_Khachtmh.Show();
            }
            else
            {
                this.form_MKT_Khachtmh.MdiParent = this;
                this.form_MKT_Khachtmh.Select();
            }
        }
        Form_Hoatdong68_Tinhhinhkcbtmh form_Hoatdong68_Tinhhinhkcbtmh;
        private void Menutinhhinhkcbtmh_Click(object sender, EventArgs e)
        {
            if (this.form_Hoatdong68_Tinhhinhkcbtmh is null || this.form_MKT_Khachtmh.IsDisposed)
            {
                this.form_Hoatdong68_Tinhhinhkcbtmh = new Form_Hoatdong68_Tinhhinhkcbtmh();
                this.form_Hoatdong68_Tinhhinhkcbtmh.MdiParent = this;
                form_Hoatdong68_Tinhhinhkcbtmh.Dock = DockStyle.Fill;
                this.form_Hoatdong68_Tinhhinhkcbtmh.Show();
            }
            else
            {
                this.form_Hoatdong68_Tinhhinhkcbtmh.MdiParent = this;
                this.form_Hoatdong68_Tinhhinhkcbtmh.Select();
            }
        }
        Form_Hoatdong68_KhachKhamhTMH form_Hoatdong68_KhachKhamhTMH;
        private void Menukhachkhamtmh_Click(object sender, EventArgs e)
        {
            if (this.form_Hoatdong68_KhachKhamhTMH is null || this.form_Hoatdong68_KhachKhamhTMH.IsDisposed)
            {
                this.form_Hoatdong68_KhachKhamhTMH = new Form_Hoatdong68_KhachKhamhTMH();
                this.form_Hoatdong68_KhachKhamhTMH.MdiParent = this;
                form_Hoatdong68_KhachKhamhTMH.Dock = DockStyle.Fill;
                this.form_Hoatdong68_KhachKhamhTMH.Show();
            }
            else
            {
                this.form_Hoatdong68_KhachKhamhTMH.MdiParent = this;
                this.form_Hoatdong68_KhachKhamhTMH.Select();
            }
        }
        Form_MKT_PhanTich3ChiNhanh form_MKT_PhanTich3ChiNhanh;
        private void phânTích3ChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_MKT_PhanTich3ChiNhanh is null || this.form_MKT_PhanTich3ChiNhanh.IsDisposed)
            {
                this.form_MKT_PhanTich3ChiNhanh = new Form_MKT_PhanTich3ChiNhanh();
                this.form_MKT_PhanTich3ChiNhanh.MdiParent = this;
                form_MKT_PhanTich3ChiNhanh.Dock = DockStyle.Fill;
                this.form_MKT_PhanTich3ChiNhanh.Show();
            }
            else
            {
                this.form_MKT_PhanTich3ChiNhanh.MdiParent = this;
                this.form_MKT_PhanTich3ChiNhanh.Select();
            }
        }
        Form_MKT_Thoigiankhamdautien form_MKT_Thoigiankhamdautien;
        private void thờiGianKhámĐầuTiênCủaKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_MKT_Thoigiankhamdautien is null || this.form_MKT_Thoigiankhamdautien.IsDisposed)
            {
                this.form_MKT_Thoigiankhamdautien = new Form_MKT_Thoigiankhamdautien();
                this.form_MKT_Thoigiankhamdautien.MdiParent = this;
                form_MKT_Thoigiankhamdautien.Dock = DockStyle.Fill;
                this.form_MKT_Thoigiankhamdautien.Show();
            }
            else
            {
                this.form_MKT_Thoigiankhamdautien.MdiParent = this;
                this.form_MKT_Thoigiankhamdautien.Select();
            }
        }
        Form_MKT_Khamsuckhoecongty form_MKT_Khamsuckhoecongty;
        private void khámSứcKhỏeCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_MKT_Khamsuckhoecongty is null || this.form_MKT_Khamsuckhoecongty.IsDisposed)
            {
                this.form_MKT_Khamsuckhoecongty = new Form_MKT_Khamsuckhoecongty();
                this.form_MKT_Khamsuckhoecongty.MdiParent = this;
                form_MKT_Khamsuckhoecongty.Dock = DockStyle.Fill;
                this.form_MKT_Khamsuckhoecongty.Show();
            }
            else
            {
                this.form_MKT_Khamsuckhoecongty.MdiParent = this;
                this.form_MKT_Khamsuckhoecongty.Select();
            }
        }
        Form_DT_Goikhamconlai form_DT_Goikhamconlai;
        private void bánGóiKhámCònLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_Goikhamconlai is null || this.form_DT_Goikhamconlai.IsDisposed)
            {
                this.form_DT_Goikhamconlai = new Form_DT_Goikhamconlai();
                this.form_DT_Goikhamconlai.MdiParent = this;
                form_DT_Goikhamconlai.Dock = DockStyle.Fill;
                this.form_DT_Goikhamconlai.Show();
            }
            else
            {
                this.form_DT_Goikhamconlai.MdiParent = this;
                this.form_DT_Goikhamconlai.Select();
            }
        }
        Form_DT_Thuoc form_DT_Thuoc;
        private void Menubanthuoc_Click(object sender, EventArgs e)
        {
            if (this.form_DT_Thuoc is null || this.form_DT_Thuoc.IsDisposed)
            {
                this.form_DT_Thuoc = new Form_DT_Thuoc();
                this.form_DT_Thuoc.MdiParent = this;
                form_DT_Thuoc.Dock = DockStyle.Fill;
                this.form_DT_Thuoc.Show();
            }
            else
            {
                this.form_DT_Thuoc.MdiParent = this;
                this.form_DT_Thuoc.Select();
            }
        }
        Form_DT_Bangoigensolution form_DT_Bangoigensolution;
        private void bánGóiGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_Bangoigensolution is null || this.form_DT_Bangoigensolution.IsDisposed)
            {
                this.form_DT_Bangoigensolution = new Form_DT_Bangoigensolution();
                this.form_DT_Bangoigensolution.MdiParent = this;
                form_DT_Bangoigensolution.Dock = DockStyle.Fill;
                this.form_DT_Bangoigensolution.Show();
            }
            else
            {
                this.form_DT_Bangoigensolution.MdiParent = this;
                this.form_DT_Bangoigensolution.Select();
            }
        }
        Form_DT_TongHopDichVu form_DT_TongHopDichVu;
        private void tổngHợpDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_TongHopDichVu is null || this.form_DT_TongHopDichVu.IsDisposed)
            {
                this.form_DT_TongHopDichVu = new Form_DT_TongHopDichVu();
                this.form_DT_TongHopDichVu.MdiParent = this;
                form_DT_TongHopDichVu.Dock = DockStyle.Fill;
                this.form_DT_TongHopDichVu.Show();
            }
            else
            {
                this.form_DT_TongHopDichVu.MdiParent = this;
                this.form_DT_TongHopDichVu.Select();
            }
        }
        Form_DT_TongHopDichVuChiTiet form_DT_TongHopDichVuChiTiet;
        private void tổngHợpDịchVụChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_TongHopDichVuChiTiet is null || this.form_DT_TongHopDichVuChiTiet.IsDisposed)
            {
                this.form_DT_TongHopDichVuChiTiet = new Form_DT_TongHopDichVuChiTiet();
                this.form_DT_TongHopDichVuChiTiet.MdiParent = this;
                form_DT_TongHopDichVuChiTiet.Dock = DockStyle.Fill;
                this.form_DT_TongHopDichVuChiTiet.Show();
            }
            else
            {
                this.form_DT_TongHopDichVuChiTiet.MdiParent = this;
                this.form_DT_TongHopDichVuChiTiet.Select();
            }
        }
        Form_DT_BenhNhanKSKQuayLai form_DT_BenhNhanKSKQuayLai;
        private void Menubenhnhankskquaylaikham_Click(object sender, EventArgs e)
        {
            if (this.form_DT_BenhNhanKSKQuayLai is null || this.form_DT_BenhNhanKSKQuayLai.IsDisposed)
            {
                this.form_DT_BenhNhanKSKQuayLai = new Form_DT_BenhNhanKSKQuayLai();
                this.form_DT_BenhNhanKSKQuayLai.MdiParent = this;
                form_DT_BenhNhanKSKQuayLai.Dock = DockStyle.Fill;
                this.form_DT_BenhNhanKSKQuayLai.Show();
            }
            else
            {
                this.form_DT_BenhNhanKSKQuayLai.MdiParent = this;
                this.form_DT_BenhNhanKSKQuayLai.Select();
            }
        }
        Form_Hoatdong68_Soluongkhamvachidinhbstmh form_Hoatdong68_Soluongkhamvachidinhbstmh;
        private void Menusoluongkhamvachidinhbstmh_Click(object sender, EventArgs e)
        {

            if (this.form_Hoatdong68_Soluongkhamvachidinhbstmh is null || this.form_Hoatdong68_Soluongkhamvachidinhbstmh.IsDisposed)
            {
                this.form_Hoatdong68_Soluongkhamvachidinhbstmh = new Form_Hoatdong68_Soluongkhamvachidinhbstmh();
                this.form_Hoatdong68_Soluongkhamvachidinhbstmh.MdiParent = this;
                form_Hoatdong68_Soluongkhamvachidinhbstmh.Dock = DockStyle.Fill;
                this.form_Hoatdong68_Soluongkhamvachidinhbstmh.Show();
            }
            else
            {
                this.form_Hoatdong68_Soluongkhamvachidinhbstmh.MdiParent = this;
                this.form_Hoatdong68_Soluongkhamvachidinhbstmh.Select();
            }
        }
        Form_DT_TongHopDichVuChiTietDongTien form_DT_TongHopDichVuChiTietDongTien;
        private void tổngHợpDịchVụChiTiếtdòngTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_DT_TongHopDichVuChiTietDongTien is null || this.form_DT_TongHopDichVuChiTietDongTien.IsDisposed)
            {
                this.form_DT_TongHopDichVuChiTietDongTien = new Form_DT_TongHopDichVuChiTietDongTien();
                this.form_DT_TongHopDichVuChiTietDongTien.MdiParent = this;
                form_DT_TongHopDichVuChiTietDongTien.Dock = DockStyle.Fill;
                this.form_DT_TongHopDichVuChiTietDongTien.Show();
            }
            else
            {
                this.form_DT_TongHopDichVuChiTietDongTien.MdiParent = this;
                this.form_DT_TongHopDichVuChiTietDongTien.Select();
            }
        }
        Form_Hoatdong68_Tyledonthuoc form_Hoatdong68_Tyledonthuoc;
        private void tỷLệĐơnThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_Hoatdong68_Tyledonthuoc is null || this.form_Hoatdong68_Tyledonthuoc.IsDisposed)
            {
                this.form_Hoatdong68_Tyledonthuoc = new Form_Hoatdong68_Tyledonthuoc();
                this.form_Hoatdong68_Tyledonthuoc.MdiParent = this;
                form_Hoatdong68_Tyledonthuoc.Dock = DockStyle.Fill;
                this.form_Hoatdong68_Tyledonthuoc.Show();
            }
            else
            {
                this.form_Hoatdong68_Tyledonthuoc.MdiParent = this;
                this.form_Hoatdong68_Tyledonthuoc.Select();
            }
        }
        Form_Hoatdong68_banthuoctheobacsi form_Hoatdong68_Banthuoctheobacsi;
        private void Menuthuoctheobacsi_Click(object sender, EventArgs e)
        {
            if (this.form_Hoatdong68_Banthuoctheobacsi is null || this.form_Hoatdong68_Banthuoctheobacsi.IsDisposed)
            {
                this.form_Hoatdong68_Banthuoctheobacsi = new Form_Hoatdong68_banthuoctheobacsi();
                this.form_Hoatdong68_Banthuoctheobacsi.MdiParent = this;
                form_Hoatdong68_Banthuoctheobacsi.Dock = DockStyle.Fill;
                this.form_Hoatdong68_Banthuoctheobacsi.Show();
            }
            else
            {
                this.form_Hoatdong68_Banthuoctheobacsi.MdiParent = this;
                this.form_Hoatdong68_Banthuoctheobacsi.Select();
            }
        }
        Form_Hoatdong68_chidinhpt form_Hoatdong68_Chidinhpt;
        private void chỉĐịnhPhẫuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_Hoatdong68_Chidinhpt is null || this.form_Hoatdong68_Chidinhpt.IsDisposed)
            {
                this.form_Hoatdong68_Chidinhpt = new Form_Hoatdong68_chidinhpt();
                this.form_Hoatdong68_Chidinhpt.MdiParent = this;
                form_Hoatdong68_Chidinhpt.Dock = DockStyle.Fill;
                this.form_Hoatdong68_Chidinhpt.Show();
            }
            else
            {
                this.form_Hoatdong68_Chidinhpt.MdiParent = this;
                this.form_Hoatdong68_Chidinhpt.Select();
            }
        }
        Form_KHTH_maubaocaopkdk form_KHTH_Maubaocaopkdk;
        private void Menumaubaocaopkdk_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Maubaocaopkdk is null || this.form_KHTH_Maubaocaopkdk.IsDisposed)
            {
                this.form_KHTH_Maubaocaopkdk = new Form_KHTH_maubaocaopkdk();
                this.form_KHTH_Maubaocaopkdk.MdiParent = this;
                form_KHTH_Maubaocaopkdk.Dock = DockStyle.Fill;
                this.form_KHTH_Maubaocaopkdk.Show();
            }
            else
            {
                this.form_KHTH_Maubaocaopkdk.MdiParent = this;
                this.form_KHTH_Maubaocaopkdk.Select();
            }
        }
        Form_KHTH_hoatdongkham form_KHTH_Hoatdongkham;
        private void hoạtĐộngKhámToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Hoatdongkham is null || this.form_KHTH_Hoatdongkham.IsDisposed)
            {
                this.form_KHTH_Hoatdongkham = new Form_KHTH_hoatdongkham();
                this.form_KHTH_Hoatdongkham.MdiParent = this;
                form_KHTH_Hoatdongkham.Dock = DockStyle.Fill;
                this.form_KHTH_Hoatdongkham.Show();
            }
            else
            {
                this.form_KHTH_Hoatdongkham.MdiParent = this;
                this.form_KHTH_Hoatdongkham.Select();
            }
        }
        Form_KHTH_hoatdongkhambenh form_KHTH_Hoatdongkhambenh;
        private void hoạtĐộngKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Hoatdongkhambenh is null || this.form_KHTH_Hoatdongkhambenh.IsDisposed)
            {
                this.form_KHTH_Hoatdongkhambenh = new Form_KHTH_hoatdongkhambenh();
                this.form_KHTH_Hoatdongkhambenh.MdiParent = this;
                form_KHTH_Hoatdongkhambenh.Dock = DockStyle.Fill;
                this.form_KHTH_Hoatdongkhambenh.Show();
            }
            else
            {
                this.form_KHTH_Hoatdongkhambenh.MdiParent = this;
                this.form_KHTH_Hoatdongkhambenh.Select();
            }
        }
        Form_KHTH_hoatdongcls form_KHTH_Hoatdongcls;
        private void hoạtĐộngCLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Hoatdongcls is null || this.form_KHTH_Hoatdongcls.IsDisposed)
            {
                this.form_KHTH_Hoatdongcls = new Form_KHTH_hoatdongcls();
                this.form_KHTH_Hoatdongcls.MdiParent = this;
                form_KHTH_Hoatdongcls.Dock = DockStyle.Fill;
                this.form_KHTH_Hoatdongcls.Show();
            }
            else
            {
                this.form_KHTH_Hoatdongcls.MdiParent = this;
                this.form_KHTH_Hoatdongcls.Select();
            }
        }
        Form_KHTH_hoatdongdieutri form_KHTH_Hoatdongdieutri;
        private void Menuhoatdongdieutri_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Hoatdongdieutri is null || this.form_KHTH_Hoatdongdieutri.IsDisposed)
            {
                this.form_KHTH_Hoatdongdieutri = new Form_KHTH_hoatdongdieutri();
                this.form_KHTH_Hoatdongdieutri.MdiParent = this;
                form_KHTH_Hoatdongdieutri.Dock = DockStyle.Fill;
                this.form_KHTH_Hoatdongdieutri.Show();
            }
            else
            {
                this.form_KHTH_Hoatdongdieutri.MdiParent = this;
                this.form_KHTH_Hoatdongdieutri.Select();
            }
        }
        Form_KHTH_tinhhinhhoatdongcls form_KHTH_Tinhhinhhoatdongcls;
        private void Menutinhhinhhoatdongcls_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Tinhhinhhoatdongcls is null || this.form_KHTH_Tinhhinhhoatdongcls.IsDisposed)
            {
                this.form_KHTH_Tinhhinhhoatdongcls = new Form_KHTH_tinhhinhhoatdongcls();
                this.form_KHTH_Tinhhinhhoatdongcls.MdiParent = this;
                form_KHTH_Tinhhinhhoatdongcls.Dock = DockStyle.Fill;
                this.form_KHTH_Tinhhinhhoatdongcls.Show();
            }
            else
            {
                this.form_KHTH_Tinhhinhhoatdongcls.MdiParent = this;
                this.form_KHTH_Tinhhinhhoatdongcls.Select();
            }
        }
        Form_KHTH_soravaochuyenvien form_KHTH_Soravaochuyenvien;
        private void sốVàoraViệnChuyểnViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Soravaochuyenvien is null || this.form_KHTH_Soravaochuyenvien.IsDisposed)
            {
                this.form_KHTH_Soravaochuyenvien = new Form_KHTH_soravaochuyenvien();
                this.form_KHTH_Soravaochuyenvien.MdiParent = this;
                form_KHTH_Soravaochuyenvien.Dock = DockStyle.Fill;
                this.form_KHTH_Soravaochuyenvien.Show();
            }
            else
            {
                this.form_KHTH_Soravaochuyenvien.MdiParent = this;
                this.form_KHTH_Soravaochuyenvien.Select();
            }
        }
        Form_KHTH_thongkesoravaochuyenvien form_KHTH_Thongkesoravaochuyenvien;
        private void thốngKêSốLượngNxChuyểnViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Thongkesoravaochuyenvien is null || this.form_KHTH_Thongkesoravaochuyenvien.IsDisposed)
            {
                this.form_KHTH_Thongkesoravaochuyenvien = new Form_KHTH_thongkesoravaochuyenvien();
                this.form_KHTH_Thongkesoravaochuyenvien.MdiParent = this;
                form_KHTH_Thongkesoravaochuyenvien.Dock = DockStyle.Fill;
                this.form_KHTH_Thongkesoravaochuyenvien.Show();
            }
            else
            {
                this.form_KHTH_Thongkesoravaochuyenvien.MdiParent = this;
                this.form_KHTH_Thongkesoravaochuyenvien.Select();
            }
        }
        Form_KHTH_thongketinhhinhphauthuat form_KHTH_Thongketinhhinhphauthuat;
        private void Menuthongketinhhinhpt_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Thongketinhhinhphauthuat is null || this.form_KHTH_Thongketinhhinhphauthuat.IsDisposed)
            {
                this.form_KHTH_Thongketinhhinhphauthuat = new Form_KHTH_thongketinhhinhphauthuat();
                this.form_KHTH_Thongketinhhinhphauthuat.MdiParent = this;
                form_KHTH_Thongketinhhinhphauthuat.Dock = DockStyle.Fill;
                this.form_KHTH_Thongketinhhinhphauthuat.Show();
            }
            else
            {
                this.form_KHTH_Thongketinhhinhphauthuat.MdiParent = this;
                this.form_KHTH_Thongketinhhinhphauthuat.Select();
            }
        }
        Form_KHTH_thongketinhhinhhoatdongkhambenh form_KHTH_Thongketinhhinhhoatdongkhambenh;
        private void Menuthongketinhhinhhoatdongkhambenh_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Thongketinhhinhhoatdongkhambenh is null || this.form_KHTH_Thongketinhhinhhoatdongkhambenh.IsDisposed)
            {
                this.form_KHTH_Thongketinhhinhhoatdongkhambenh = new Form_KHTH_thongketinhhinhhoatdongkhambenh();
                this.form_KHTH_Thongketinhhinhhoatdongkhambenh.MdiParent = this;
                form_KHTH_Thongketinhhinhhoatdongkhambenh.Dock = DockStyle.Fill;
                this.form_KHTH_Thongketinhhinhhoatdongkhambenh.Show();
            }
            else
            {
                this.form_KHTH_Thongketinhhinhhoatdongkhambenh.MdiParent = this;
                this.form_KHTH_Thongketinhhinhhoatdongkhambenh.Select();
            }
        }
        Form_KHTH_danhsachbenhnhanxuatvien form_KHTH_Danhsachbenhnhanxuatvien;
        private void Menudanhsachbenhnhanxuatvien_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Danhsachbenhnhanxuatvien is null || this.form_KHTH_Danhsachbenhnhanxuatvien.IsDisposed)
            {
                this.form_KHTH_Danhsachbenhnhanxuatvien = new Form_KHTH_danhsachbenhnhanxuatvien();
                this.form_KHTH_Danhsachbenhnhanxuatvien.MdiParent = this;
                form_KHTH_Danhsachbenhnhanxuatvien.Dock = DockStyle.Fill;
                this.form_KHTH_Danhsachbenhnhanxuatvien.Show();
            }
            else
            {
                this.form_KHTH_Danhsachbenhnhanxuatvien.MdiParent = this;
                this.form_KHTH_Danhsachbenhnhanxuatvien.Select();
            }
        }
        Form_KHTH_tinhhinhsudungthuoctheobacsi form_KHTH_Tinhhinhsudungthuoctheobacsi;
        private void Menutinhhinhsudungthuoctheobs_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Tinhhinhsudungthuoctheobacsi is null || this.form_KHTH_Tinhhinhsudungthuoctheobacsi.IsDisposed)
            {
                this.form_KHTH_Tinhhinhsudungthuoctheobacsi = new Form_KHTH_tinhhinhsudungthuoctheobacsi();
                this.form_KHTH_Tinhhinhsudungthuoctheobacsi.MdiParent = this;
                form_KHTH_Tinhhinhsudungthuoctheobacsi.Dock = DockStyle.Fill;
                this.form_KHTH_Tinhhinhsudungthuoctheobacsi.Show();
            }
            else
            {
                this.form_KHTH_Tinhhinhsudungthuoctheobacsi.MdiParent = this;
                this.form_KHTH_Tinhhinhsudungthuoctheobacsi.Select();
            }
        }
        Form_KHTH_thongkebenhtattheobenhnhankhambenh form_KHTH_Thongkebenhtattheobenhnhankhambenh;
        private void MenuForm_KHTH_thongkebenhtattheobenhnhankhambenh_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Thongkebenhtattheobenhnhankhambenh is null || this.form_KHTH_Thongkebenhtattheobenhnhankhambenh.IsDisposed)
            {
                this.form_KHTH_Thongkebenhtattheobenhnhankhambenh = new Form_KHTH_thongkebenhtattheobenhnhankhambenh();
                this.form_KHTH_Thongkebenhtattheobenhnhankhambenh.MdiParent = this;
                form_KHTH_Thongkebenhtattheobenhnhankhambenh.Dock = DockStyle.Fill;
                this.form_KHTH_Thongkebenhtattheobenhnhankhambenh.Show();
            }
            else
            {
                this.form_KHTH_Thongkebenhtattheobenhnhankhambenh.MdiParent = this;
                this.form_KHTH_Thongkebenhtattheobenhnhankhambenh.Select();
            }
        }
        Form_KHTH_sophauthuat form_KHTH_Sophauthuat;
        private void sổPhẫuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Sophauthuat is null || this.form_KHTH_Soravaochuyenvien.IsDisposed)
            {
                this.form_KHTH_Sophauthuat = new Form_KHTH_sophauthuat();
                this.form_KHTH_Sophauthuat.MdiParent = this;
                form_KHTH_Sophauthuat.Dock = DockStyle.Fill;
                this.form_KHTH_Sophauthuat.Show();
            }
            else
            {
                this.form_KHTH_Sophauthuat.MdiParent = this;
                this.form_KHTH_Sophauthuat.Select();
            }
        }
        Form_KHTH_sokhambenh form_KHTH_Sokhambenh;
        private void Menusokhambenh_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Sokhambenh is null || this.form_KHTH_Sokhambenh.IsDisposed)
            {
                this.form_KHTH_Sokhambenh = new Form_KHTH_sokhambenh();
                this.form_KHTH_Sokhambenh.MdiParent = this;
                form_KHTH_Sokhambenh.Dock = DockStyle.Fill;
                this.form_KHTH_Sokhambenh.Show();
            }
            else
            {
                this.form_KHTH_Sokhambenh.MdiParent = this;
                this.form_KHTH_Sokhambenh.Select();
            }
        }
        Form_KHTH_danhsachbnpt form_KHTH_Danhsachbnpt;
        private void Menudanhsachbnphauthuat_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Danhsachbnpt is null || this.form_KHTH_Danhsachbnpt.IsDisposed)
            {
                this.form_KHTH_Danhsachbnpt = new Form_KHTH_danhsachbnpt();
                this.form_KHTH_Danhsachbnpt.MdiParent = this;
                form_KHTH_Danhsachbnpt.Dock = DockStyle.Fill;
                this.form_KHTH_Danhsachbnpt.Show();
            }
            else
            {
                this.form_KHTH_Danhsachbnpt.MdiParent = this;
                this.form_KHTH_Danhsachbnpt.Select();
            }
        }
        Form_KHTH_danhsachbnnn form_KHTH_Danhsachbnnn;
        private void Menudanhsachbnnn_Click(object sender, EventArgs e)
        {
            if (this.form_KHTH_Danhsachbnnn is null || this.form_KHTH_Danhsachbnnn.IsDisposed)
            {
                this.form_KHTH_Danhsachbnnn = new Form_KHTH_danhsachbnnn();
                this.form_KHTH_Danhsachbnnn.MdiParent = this;
                form_KHTH_Danhsachbnnn.Dock = DockStyle.Fill;
                this.form_KHTH_Danhsachbnnn.Show();
            }
            else
            {
                this.form_KHTH_Danhsachbnnn.MdiParent = this;
                this.form_KHTH_Danhsachbnnn.Select();
            }
        }
    }
}
