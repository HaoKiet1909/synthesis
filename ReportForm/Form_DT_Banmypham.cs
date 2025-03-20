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
    public partial class Form_DT_Banmypham : Form
    {
        public Form_DT_Banmypham()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void FormBanmypham_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Data_System;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
        }
        private void btntimkiemngay_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("DoanhThuBanMyPham_2023", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                cmd.CommandTimeout = 0;
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                reportBanmypham.ProcessingMode = ProcessingMode.Local;
                reportBanmypham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\RpBanmypham.rdlc";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSetBanmypham";
                    rds.Value = ds.Tables[0];
                    reportBanmypham.LocalReport.DataSources.Clear();
                    reportBanmypham.LocalReport.DataSources.Add(rds);
                    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    reportBanmypham.LocalReport.SetParameters(reportParameters);
                    reportBanmypham.RefreshReport();
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
