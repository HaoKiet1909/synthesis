using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ReportForm
{
   
    public partial class Form_ADMIN_doimatkhau : Form
    {
        Account acc = null;
        public Form_ADMIN_doimatkhau()
        {
            InitializeComponent();
            

        }
        
        public Form_ADMIN_doimatkhau(Account acc)
        {
            InitializeComponent();
            this.acc = acc;
            
        }
        SqlConnection con;

        private void Formdoimatkhau_Load(object sender, EventArgs e)
        {
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
            DataTable dt = new DataTable();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
           
            load_tk();
           
        }
        private void load_tk()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select TaiKhoan FROM dbo.ReportAcc where TaiKhoan= '" + acc.TaiKhoan + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbbtaikhoan.DataSource = dt;
                cbbtaikhoan.DisplayMember = "TaiKhoan";
                cbbtaikhoan.ValueMember = "TaiKhoan";
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        
       

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmatkhaumoi.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Update ReportAcc set MatKhau='" + txtmatkhaumoi.Text + "' where TaiKhoan='" + cbbtaikhoan.Text + "' ", con);
                    cmd.Parameters.AddWithValue("@TaiKhoan", cbbtaikhoan.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtmatkhaumoi.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đổi mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Chưa nhập mật khẩu mới");
                }
               
            }catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpass.Checked)
            {
                txtmatkhaumoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtmatkhaumoi.UseSystemPasswordChar = true;
            }
        }
    }
}
