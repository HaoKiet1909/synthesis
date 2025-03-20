using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;


namespace ReportForm
{
    public partial class Form_CSKH_Hoatdonghangngayphongkham : Form
    {
        public Form_CSKH_Hoatdonghangngayphongkham()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void Form_CSKH_Hoatdonghangngayphongkham_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
        }

        private void btntimkiemngay_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("DailyReport_PK_2023", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                cmd.CommandTimeout = 0;
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                reportHoatdonghangngayphongkham.ProcessingMode = ProcessingMode.Local;
                reportHoatdonghangngayphongkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CSKH_Hoatdonghangngayphongkham.rdlc";
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSetHoatdonghangngayphongkham";
                    rds.Value = ds.Tables[0];
                    reportHoatdonghangngayphongkham.LocalReport.DataSources.Clear();
                    reportHoatdonghangngayphongkham.LocalReport.DataSources.Add(rds);
                    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    reportHoatdonghangngayphongkham.LocalReport.SetParameters(reportParameters);
                    reportHoatdonghangngayphongkham.RefreshReport();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
