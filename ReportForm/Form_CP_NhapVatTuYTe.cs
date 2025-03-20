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
    public partial class Form_CP_NhapVatTuYTe : Form
    {
        public Form_CP_NhapVatTuYTe()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlConnection con2;
        private void Form_CP_NhapVatTuYTe_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);

            string conString2 = @"Data Source=server-one\mssql2012;Initial Catalog=eHospital_TMH;User ID=admin;Password=fpt@entent123";
            con2 = new SqlConnection(conString2);

            con.Open();
        }
        private void btntimkiemngay_Click(object sender, EventArgs e)
        {
            if (cbbcongty.SelectedItem == "Đa khoa")
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("CP_NhapVatTu_2023", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@NhaCungCap_ID", cbbnhacungcap.SelectedValue);

                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                    reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapvatu.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetNhapvattu";
                        rds.Value = ds.Tables[0];
                        reportChiphinhapthuoc.LocalReport.DataSources.Clear();
                        reportChiphinhapthuoc.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                        reportChiphinhapthuoc.RefreshReport();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            else if (cbbcongty.SelectedItem == "Tai mũi họng")
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("CP_NhapVatTu_2023", con2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@NhaCungCap_ID", cbbnhacungcap.SelectedValue);

                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                    reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapvatubenhvien.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetNhapvattubenhvien";
                        rds.Value = ds.Tables[0];
                        reportChiphinhapthuoc.LocalReport.DataSources.Clear();
                        reportChiphinhapthuoc.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                        reportChiphinhapthuoc.RefreshReport();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("CP_NhapVatTu2CN_2023", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@NhaCungCap_ID", cbbnhacungcap.SelectedValue);

                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);
                    reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                    reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapvatu2cn.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetNhapvattu2cn";
                        rds.Value = ds.Tables[0];
                        reportChiphinhapthuoc.LocalReport.DataSources.Clear();
                        reportChiphinhapthuoc.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                        reportChiphinhapthuoc.RefreshReport();
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

        private void cbbnhacungcap_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbbcongty.SelectedItem == "Đa khoa")
            {
                cbbnhacungcap.ValueMember = "";
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM dbo.DM_NhaCungCap WHERE TamNgung = 0 ORDER BY TenNhaCungCap ASC", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbbnhacungcap.DataSource = dt;
                cbbnhacungcap.DisplayMember = "TenNhaCungCap";
                cbbnhacungcap.ValueMember = "NhaCungCap_Id";
            }
            else if (cbbcongty.SelectedItem == "Tai mũi họng")
            {
                cbbnhacungcap.ValueMember = "";
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DM_NhaCungCap WHERE TamNgung = 0 ORDER BY TenNhaCungCap ASC", con2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbbnhacungcap.DataSource = dt;
                cbbnhacungcap.DisplayMember = "TenNhaCungCap";
                cbbnhacungcap.ValueMember = "NhaCungCap_Id";
            }
        }
    }
}
