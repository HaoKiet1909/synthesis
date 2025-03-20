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
    public partial class Form_CSKH_Canhbaotiemchuan : Form
    {
        public Form_CSKH_Canhbaotiemchuan()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void Form_CSKH_Canhbaotiemchuan_Load(object sender, EventArgs e)
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

                SqlCommand cmd = new SqlCommand("CanhBaoTiemChuan_2023", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                cmd.CommandTimeout = 0;
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                reportCanhbaotiemchuan.ProcessingMode = ProcessingMode.Local;
                reportCanhbaotiemchuan.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CSKH_Canhbaotiemchuan.rdlc";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSetCanhbaotiemchuan";
                    rds.Value = ds.Tables[0];
                    reportCanhbaotiemchuan.LocalReport.DataSources.Clear();
                    reportCanhbaotiemchuan.LocalReport.DataSources.Add(rds);
                    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    reportCanhbaotiemchuan.LocalReport.SetParameters(reportParameters);
                    reportCanhbaotiemchuan.RefreshReport();
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

        private void TuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reportCanhbaotiemchuan_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clinicTMHDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
