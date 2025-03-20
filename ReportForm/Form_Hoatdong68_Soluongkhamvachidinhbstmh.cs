using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;

namespace ReportForm
{
    public partial class Form_Hoatdong68_Soluongkhamvachidinhbstmh : Form
    {
        public Form_Hoatdong68_Soluongkhamvachidinhbstmh()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Form_Hoatdong68_Soluongkhamvachidinhbstmh_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString2 = @"Data Source=server-one\mssql2012;Initial Catalog=eHospital_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString2);

            con.Open();
        }

        private void btntimkiemngay_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SoLuotKham_BS_TMH_2023", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                //con.Close();


                cmd.CommandTimeout = 0;
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);

                reportkhachkhamtmh.ProcessingMode = ProcessingMode.Local;
                reportkhachkhamtmh.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_Hoatdong68_Soluongkhamvachidinhbstmh.rdlc";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSetSoluongkhamvachidinhbstmh";
                    rds.Value = ds.Tables[0];
                    reportkhachkhamtmh.LocalReport.DataSources.Clear();
                    reportkhachkhamtmh.LocalReport.DataSources.Add(rds);
                    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    reportkhachkhamtmh.LocalReport.SetParameters(reportParameters);
                    reportkhachkhamtmh.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Dong_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
