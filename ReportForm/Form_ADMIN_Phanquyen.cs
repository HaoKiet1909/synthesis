using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ReportForm
{
    public partial class Form_ADMIN_Phanquyen : Form
    {
        public Form_ADMIN_Phanquyen()
        {
            InitializeComponent();
           

        }
        SqlConnection con;
        private void FormPhanquyen_Load(object sender, EventArgs e)
        {
            string conString=@"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
            DataTable dt = new DataTable();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
           Load_data();
            cbbtaikhoan();
            Load_user();
            Load_user_menu();
            cbbquyen.SelectedItem = "0";
            cbbTentaikhoan.SelectedItem = "";
        }
        
        
        
        public void cbbtaikhoan()
        {
            
            cbbTentaikhoan.ValueMember = "";
            SqlCommand cmd2 = new SqlCommand("select TaiKhoan from ReportAcc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbTentaikhoan.DataSource = dt;
            cbbTentaikhoan.DisplayMember = "TaiKhoan";
            cbbTentaikhoan.ValueMember = "TaiKhoan";
            
        }
        private void Load_user_menu()
        {
            SqlCommand cmd = new SqlCommand("SELECT TaiKhoan,MenuCode FROM dbo.Report_Acc_Menus order by TaiKhoan ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtguser_menus.DataSource = dt;
            dtguser_menus.AllowUserToAddRows = false;
        }
        private void Load_user()
        {
            SqlCommand cmd = new SqlCommand("SELECT TaiKhoan,MatKhau,Quyen FROM dbo.ReportAcc ORDER BY TaiKhoan ASC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtguser.DataSource = dt;
            dtguser.AllowUserToAddRows = false;
        }
        private void Load_data()
        {
            SqlCommand cmd = new SqlCommand("select MenuCode,MenuName,Room from ReportMenus order by Room ASC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgMenus.DataSource = dt;
            dtgMenus.AllowUserToAddRows = false;
            DataGridViewCheckBoxColumn checkboxcol = new DataGridViewCheckBoxColumn();
            checkboxcol.Width = 40;
            checkboxcol.Name = "checkmenus";
            checkboxcol.HeaderText = "";
            dtgMenus.Columns.Insert(0, checkboxcol);
            dtgMenus.CellClick += DtgMenus_CellClick;
        }

        private void DtgMenus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấp vào cột checkbox không
            if (e.RowIndex >= 0 && dtgMenus.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Đảm bảo chỉ thay đổi giá trị của ô checkbox
                if (dtgMenus[e.ColumnIndex, e.RowIndex] is DataGridViewCheckBoxCell checkboxCell)
                {
                    checkboxCell.Value = !Convert.ToBoolean(checkboxCell.Value);
                    dtgMenus.EndEdit(); // Kết thúc chỉnh sửa ô
                }
            }
        }


        private void btnThemquyen_Click(object sender, EventArgs e)
        {
            try
            {
               
                foreach (DataGridViewRow row in dtgMenus.Rows)
                {

                    bool check = Convert.ToBoolean(row.Cells["checkmenus"].Value);
                    string menuCode = row.Cells["MenuCode"].Value.ToString();
                    if (check)
                    {
                        // Kiểm tra xem quyền đã tồn tại hay chưa
                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Report_Acc_Menus WHERE TaiKhoan = @TaiKhoan AND MenuCode = @MenuCode", con);
                        checkCmd.Parameters.AddWithValue("@TaiKhoan", cbbTentaikhoan.Text);
                        checkCmd.Parameters.AddWithValue("@MenuCode", menuCode);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0) // Nếu chưa tồn tại quyền này
                        {
                            SqlCommand cmd1 = new SqlCommand("Insert into Report_Acc_Menus(TaiKhoan, MenuCode)Values (@TaiKhoan,@MenuCode)", con);
                            cmd1.Parameters.AddWithValue("TaiKhoan", cbbTentaikhoan.Text);
                            cmd1.Parameters.AddWithValue("MenuCode", row.Cells["MenuCode"].Value);
                            
                            cmd1.ExecuteNonQuery();
                           
                        }
                    }
                    else
                    {
                        // Xóa quyền tương ứng
                        SqlCommand cmd = new SqlCommand("DELETE FROM Report_Acc_Menus WHERE TaiKhoan = @TaiKhoan AND MenuCode = @MenuCode", con);
                        cmd.Parameters.AddWithValue("@TaiKhoan", cbbTentaikhoan.Text);
                        cmd.Parameters.AddWithValue("@MenuCode", menuCode);
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void cbbTentaikhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string taikhoan = cbbTentaikhoan.Text;
            int columnIndex = 1; // Chỉ số cột bạn muốn lấy

            List<string> columnValues = new List<string>();

            foreach (DataGridViewRow row in dtgMenus.Rows)
            {
                if (!row.IsNewRow) // Đảm bảo không lấy giá trị từ dòng mới (nếu có)
                {
                    DataGridViewCell cell = row.Cells[columnIndex];
                    string cellValue = cell.Value != null ? cell.Value.ToString() : string.Empty;
                    columnValues.Add(cellValue);
                }
            }

            foreach (DataGridViewRow row in dtgMenus.Rows)
            {
                string menuCode = row.Cells["MenuCode"].Value.ToString(); // Thay "menuCodeColumn" bằng tên cột chứa MenuCode
                SqlCommand cmd = new SqlCommand("SELECT TaiKhoan, MenuCode FROM Report_Acc_Menus WHERE TaiKhoan = @taikhoan AND MenuCode = @menuCode", con);
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
                cmd.Parameters.AddWithValue("@menuCode", menuCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bool isChecked = dt.Rows.Count > 0;
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)row.Cells["checkmenus"]; // Thay "checkmenus" bằng tên cột chứa CheckBox

                checkboxCell.Value = isChecked;
            }

            dtgMenus.Refresh();
           

        }

        

        private void dtguser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtguser.Focus();
                DataGridViewRow row = this.dtguser.Rows[e.RowIndex];
               

                txttaikhoan.Text = row.Cells[0].Value.ToString();
                txtmatkhau.Text = row.Cells[1].Value.ToString();
                if (e.RowIndex >= 0)
                {
                    
                    DataGridViewCell cell = row.Cells[2];

                    if (cell.Value != null && cell.Value != DBNull.Value)
                    {
                        bool quyenValue = Convert.ToBoolean(cell.Value);
                        string quyenText = quyenValue ? "1" : "0";

                        // Gán giá trị chuỗi vào ComboBox
                        cbbquyen.Text = quyenText;
                    }
                }

            }
            catch
            {

            }
        }

        private void btnthemtaikhoan_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (txttaikhoan.Text != "" && txtmatkhau.Text != "" && cbbquyen.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into ReportAcc values (@TaiKhoan, @MatKhau, @Quyen)", con);
                    cmd.Parameters.AddWithValue("TaiKhoan", txttaikhoan.Text);
                    cmd.Parameters.AddWithValue("MatKhau", txtmatkhau.Text);
                    cmd.Parameters.AddWithValue("Quyen", cbbquyen.SelectedItem);
                    
                    cmd.ExecuteNonQuery();
                   
                    MessageBox.Show("Thêm thành công");
                    refresh();
                    cbbtaikhoan();
                    Load_user();
                    
               

                }
                else 
                {
                    MessageBox.Show("tài khoản, mật khẩu, quyền không được trống");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm không thành công "+ ex );
            } 
            
        }

        private void btnxoataikhoan_Click(object sender, EventArgs e)
        {
            try {
                if (txttaikhoan.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.ReportAcc WHERE TaiKhoan = @TaiKhoan", con);
                    cmd.Parameters.AddWithValue("TaiKhoan", txttaikhoan.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    cmd.ExecuteNonQuery();
                    cbbtaikhoan();
                    Load_user();
                    refresh();
                }
                else
                {
                    MessageBox.Show("Chưa chọn tài khoản để xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công "+ex);
            }

        }
        
        private void btnsuataikhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttaikhoan.Text != "")
                {
                    

                    
                    SqlCommand cmd = new SqlCommand("UPDATE ReportAcc SET MatKhau=@MatKhau, Quyen=@Quyen WHERE TaiKhoan=@TaiKhoan", con);
                    cmd.Parameters.AddWithValue("TaiKhoan", txttaikhoan.Text);
                    cmd.Parameters.AddWithValue("MatKhau", txtmatkhau.Text);
                    cmd.Parameters.AddWithValue("Quyen", cbbquyen.SelectedItem);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công");
                 
                    refresh();
                    Load_user();
                }

                else
                {
                    MessageBox.Show("Chưa chọn đối tượng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công " + ex);
            }

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string rowFilter = string.Format("{0} like '{1}'", "TaiKhoan", "*" + txttaikhoan.Text + "*");
                (dtguser.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Load_user();
            refresh();


        }
        private void refresh()
        {
            txttaikhoan.Text = "";
            txtmatkhau.Text = "";
            cbbquyen.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
