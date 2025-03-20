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
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;

namespace ReportForm
{
    public partial class Form_DT_Banthuoctieuhoa : Form
    {
        public Form_DT_Banthuoctieuhoa()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlConnection con1;
        SqlConnection con2;

        private void FormBanthuoctieuhoa_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString1 = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_PKQ7;User ID=admin;Password=fpt@entent123";
            con1 = new SqlConnection(conString1);
            
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            
            string conString2 = @"Data Source=server-one\mssql2012;Initial Catalog=eHospital_TMH;User ID=admin;Password=fpt@entent123";
            con2 = new SqlConnection(conString2);

            con.Open();
        }

        private void btntimkiemngay_Click(object sender, EventArgs e)
        {

            // Khai báo biến @Chon và khởi tạo giá trị mặc định
            string chontieuhoa = null;
            string chontimmach = null;
            string chontongquat = null;
            string chonsanphu = null;
            string chonranghammat = null;
            string chonmat = null;
            string chongannhiem = null;
            string chondalieu = null;
            string chontaimuihong = null;
            string chonkhtumuabv = null;
            string chonkhtumuadakhoa = null;



            // Kiểm tra trạng thái của các checkbox và cập nhật biến @Chon tùy thuộc vào checkbox nào đã được chọn
            if (chktieuhoa.Checked)
            {
                chontieuhoa = "Tiêu hóa";
            }
            if (chktimmach.Checked)
            {
                chontimmach = "Tim mạch";
            }
            if (chktongquat.Checked)
            {
                chontongquat = "Tổng quát";
            }
            if (chksanphu.Checked)
            {
                chonsanphu = "Sản phụ";
            }
            if (chkranghammat.Checked)
            {
                chonranghammat = "Răng hàm mặt";
            }
            if (chkmat.Checked)
            {
                chonmat = "Mắt";
            }
            if (chkgannhiem.Checked)
            {
                chongannhiem = "Gan - nhiễm";
            }
            if (chkdalieu.Checked)
            {
                chondalieu = "Da liễu";
            }
            if (chktaimuihong.Checked)
            {
                chontaimuihong = "Tai mũi họng";
            }
            if (chkkhtumuabv.Checked)
            {
                chonkhtumuabv = "KH tự mua - Bệnh viện";
            }
            if (chkkhtumuadakhoa.Checked)
            {
                chonkhtumuadakhoa = "KH tự mua - Đa khoa";
            }




            if (cbbchinhanh.SelectedItem == "9-15")
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("DoanhThuBanThuocTieuHoa_2023", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@Chontieuhoa", chontieuhoa);
                    cmd.Parameters.AddWithValue("@Chontimmach", chontimmach);
                    cmd.Parameters.AddWithValue("@chontongquat", chontongquat);
                    cmd.Parameters.AddWithValue("@chonsanphu", chonsanphu);
                    cmd.Parameters.AddWithValue("@chonranghammat", chonranghammat);
                    cmd.Parameters.AddWithValue("@chonmat", chonmat);
                    cmd.Parameters.AddWithValue("@chongannhiem", chongannhiem);
                    cmd.Parameters.AddWithValue("@chondalieu", chondalieu);
                  

                    cmd.Parameters.AddWithValue("@chonkhtumuadakhoa", chonkhtumuadakhoa);
                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportBanthuoctieuhoa.ProcessingMode = ProcessingMode.Local;
                    reportBanthuoctieuhoa.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\RpBanthuoctieuhoa.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetBanthuoctieuhoa";
                        rds.Value = ds.Tables[0];
                        reportBanthuoctieuhoa.LocalReport.DataSources.Clear();
                        reportBanthuoctieuhoa.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportBanthuoctieuhoa.LocalReport.SetParameters(reportParameters);
                        reportBanthuoctieuhoa.RefreshReport();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            } else if (cbbchinhanh.SelectedItem == "BV")
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("DoanhThuBanThuocTieuHoa_2023", con2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@chontaimuihong", chontaimuihong);
                    cmd.Parameters.AddWithValue("@chonkhtumuabv", chonkhtumuabv);
                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportBanthuoctieuhoa.ProcessingMode = ProcessingMode.Local;
                    reportBanthuoctieuhoa.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\RpBanthuoctieuhoaBv.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetBanthuoctieuhoaBv";
                        rds.Value = ds.Tables[0];
                        reportBanthuoctieuhoa.LocalReport.DataSources.Clear();
                        reportBanthuoctieuhoa.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportBanthuoctieuhoa.LocalReport.SetParameters(reportParameters);
                        reportBanthuoctieuhoa.RefreshReport();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            } else if (cbbchinhanh.SelectedItem == "Q7")
            {
                try
                {


                    SqlCommand cmd = new SqlCommand("DoanhThuBanThuocTieuHoa_2023", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    cmd.Parameters.AddWithValue("@Chontieuhoa", chontieuhoa);
                    cmd.Parameters.AddWithValue("@Chontimmach", chontimmach);
                    cmd.Parameters.AddWithValue("@chontongquat", chontongquat);
                    cmd.Parameters.AddWithValue("@chonsanphu", chonsanphu);
                    cmd.Parameters.AddWithValue("@chonranghammat", chonranghammat);
                    cmd.Parameters.AddWithValue("@chonmat", chonmat);
                    cmd.Parameters.AddWithValue("@chongannhiem", chongannhiem);
                    cmd.Parameters.AddWithValue("@chondalieu", chondalieu);
                    cmd.Parameters.AddWithValue("@chontaimuihong", chontaimuihong);
     
                    cmd.Parameters.AddWithValue("@chonkhtumuadakhoa", chonkhtumuadakhoa);
                    //cmd.Parameters.AddWithValue("@Chon", chon);
                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportBanthuoctieuhoa.ProcessingMode = ProcessingMode.Local;
                    reportBanthuoctieuhoa.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\RpBanthuoctieuhoaQ7.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetBanthuoctieuhoaQ7";
                        rds.Value = ds.Tables[0];
                        reportBanthuoctieuhoa.LocalReport.DataSources.Clear();
                        reportBanthuoctieuhoa.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportBanthuoctieuhoa.LocalReport.SetParameters(reportParameters);
                        reportBanthuoctieuhoa.RefreshReport();
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            } else
            {
               
                try
                {
                 
                    SqlCommand cmd = new SqlCommand("DoanhThuBanThuocTieuHoa3ChiNhanh_2023", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@Chontieuhoa", chontieuhoa);
                    cmd.Parameters.AddWithValue("@Chontimmach", chontimmach);
                    cmd.Parameters.AddWithValue("@chontongquat", chontongquat);
                    cmd.Parameters.AddWithValue("@chonsanphu", chonsanphu);
                    cmd.Parameters.AddWithValue("@chonranghammat", chonranghammat);
                    cmd.Parameters.AddWithValue("@chonmat", chonmat);
                    cmd.Parameters.AddWithValue("@chongannhiem", chongannhiem);
                    cmd.Parameters.AddWithValue("@chondalieu", chondalieu);
                    cmd.Parameters.AddWithValue("@chontaimuihong", chontaimuihong);
                    cmd.Parameters.AddWithValue("@chonkhtumuabv", chonkhtumuabv);
                    cmd.Parameters.AddWithValue("@chonkhtumuadakhoa", chonkhtumuadakhoa);   

                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportBanthuoctieuhoa.ProcessingMode = ProcessingMode.Local;
                    reportBanthuoctieuhoa.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\RpBanthuoctieuhoa3Chinhanh.rdlc";

                    // Gán dữ liệu cho các DataSet trong báo cáo
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetBanthuoctieuhoa3Chinhanh";
                        rds.Value = ds.Tables[0];
                        reportBanthuoctieuhoa.LocalReport.DataSources.Clear();
                        reportBanthuoctieuhoa.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportBanthuoctieuhoa.LocalReport.SetParameters(reportParameters);
                        reportBanthuoctieuhoa.RefreshReport();
                    }
                    con.Close();
                }

                
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            if(chkall.Checked)
            {
                chktieuhoa.Checked = true;
                chktimmach.Checked = true;
                chktongquat.Checked = true;
                chksanphu.Checked = true;
                chkranghammat.Checked = true;
                chkmat.Checked = true;
                chkdalieu.Checked = true;
                chktaimuihong.Checked = true;
                chkkhtumuabv.Checked = true;
                chkkhtumuadakhoa.Checked = true;
                chkgannhiem.Checked = true;
            }
            else
            {
                chktieuhoa.Checked = false;
                chktimmach.Checked = false;
                chktongquat.Checked = false;
                chksanphu.Checked = false;
                chkranghammat.Checked = false;
                chkmat.Checked = false;
                chkdalieu.Checked = false;
                chktaimuihong.Checked = false;
                chkkhtumuabv.Checked = false;
                chkkhtumuadakhoa.Checked = false;
                chkgannhiem.Checked = false;
            }
        }
    }
}
