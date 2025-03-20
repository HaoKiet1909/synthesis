using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ReportForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
        }


        SqlConnection con;
        private void Login_Load(object sender, EventArgs e)
        {
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("select * from ReportAcc where TaiKhoan = '" + txttaikhoan.Text + "' and MatKhau = '" + txtmatkhau.Text + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            Account acc = new Account();

            if (dt.Rows.Count > 0)
            {
                bool  check = (bool)dt.Rows[0][2];

              
                acc = (from DataRow dr in dt.Rows where (bool)dr[2] == check select new Account() { TaiKhoan = dr[0].ToString(), MatKhau = dr[1].ToString(),Quyen = (bool)dr[2] }).First();
               
                this.Hide();
                Main frm = new Main(acc);  
                frm.Show();
                

            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập");
            }

            
        }






        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
