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
using Microsoft.Reporting.WinForms;


namespace ReportForm
{
    public partial class Form_CSKH_Bangkethutientheonoidung : Form
    {
        public Form_CSKH_Bangkethutientheonoidung()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void Form_CSKH_Bangkethutientheonoidung_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
            //loadten();
        }

        private void cbbtennv_MouseClick(object sender, MouseEventArgs e)
        {
            cbbtennv.ValueMember = "";
            SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT nv.TenNhanVien,nv.NhanVien_Id FROM dbo.NhanVien nv JOIN dbo.HoaDon hd ON hd.NguoiThuTien_Id = nv.NhanVien_Id WHERE nv.TamNgung = 0 ORDER BY nv.TenNhanVien ASC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbtennv.DataSource = dt;
            cbbtennv.DisplayMember = "TenNhanVien";
            cbbtennv.ValueMember = "NhanVien_Id";
        }

        //private void loadten()
        //{
        //    cbbtennv.ValueMember = "";
        //    SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT nv.TenNhanVien,nv.NhanVien_Id FROM dbo.NhanVien nv JOIN dbo.HoaDon hd ON hd.NguoiThuTien_Id = nv.NhanVien_Id WHERE nv.TamNgung = 0 ORDER BY nv.TenNhanVien ASC", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd2);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    cbbtennv.DataSource = dt;
        //    cbbtennv.DisplayMember = "TenNhanVien";
        //    cbbtennv.ValueMember = "NhanVien_Id";
        //}
        private void btntimkiemngay_Click(object sender, EventArgs e)
        {
            
                try
                {

                    SqlCommand cmd = new SqlCommand("CSKH_BangKeThuTienTheoNoiDung_2023", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@NguoiThuTien_Id", cbbtennv.SelectedValue);

                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportbangkethutientheonoidung.ProcessingMode = ProcessingMode.Local;
                    reportbangkethutientheonoidung.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CSKH_Bangkethutientheonoidung.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetBangkeuthutientheonoidung";
                        rds.Value = ds.Tables[0];
                        reportbangkethutientheonoidung.LocalReport.DataSources.Clear();
                        reportbangkethutientheonoidung.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportbangkethutientheonoidung.LocalReport.SetParameters(reportParameters);
                        reportbangkethutientheonoidung.RefreshReport();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            
           
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
