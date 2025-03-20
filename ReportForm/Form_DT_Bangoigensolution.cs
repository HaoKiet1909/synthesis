using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using Npgsql;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ReportForm
{
    public partial class Form_DT_Bangoigensolution : Form
    {
        public Form_DT_Bangoigensolution()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlConnection con1;
  
        private void Form_DT_Bangoigensolution_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            this.FormBorderStyle = FormBorderStyle.None;
            string conString1 = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_PKQ7;User ID=admin;Password=fpt@entent123";
            con1 = new SqlConnection(conString1);

            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);

            con.Open();
        }

        private async void btntimkiemngay_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbchinhanh.SelectedItem == "9-15")
                {

                    SqlCommand cmd = new SqlCommand("DT_BanGenSolution_2023", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    //con.Close();


                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);

                    reportbangoigensolution.ProcessingMode = ProcessingMode.Local;
                    reportbangoigensolution.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_bangoigensolution.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetBangoigensolution";
                        rds.Value = ds.Tables[0];
                        reportbangoigensolution.LocalReport.DataSources.Clear();
                        reportbangoigensolution.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportbangoigensolution.LocalReport.SetParameters(reportParameters);
                        reportbangoigensolution.RefreshReport();
                    }
                }
                else if (cbbchinhanh.SelectedItem == "Q7")
                {
                    SqlCommand cmd = new SqlCommand("DT_BanGenSolution_2023", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    //con.Close();


                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(ds);

                    reportbangoigensolution.ProcessingMode = ProcessingMode.Local;
                    reportbangoigensolution.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_bangoigensolutionQ7.rdlc";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "DataSetbangoigensolutionq7";
                        rds.Value = ds.Tables[0];
                        reportbangoigensolution.LocalReport.DataSources.Clear();
                        reportbangoigensolution.LocalReport.DataSources.Add(rds);
                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                        reportbangoigensolution.LocalReport.SetParameters(reportParameters);
                        reportbangoigensolution.RefreshReport();
                    }
                }
                else
                {
                    //SqlCommand cmd = new SqlCommand("DT_BanGenSolution2CN_2023", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    //cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    ////con.Close();


                    //cmd.CommandTimeout = 0;
                    //DataSet ds = new DataSet();
                    //SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    //dap.Fill(ds);

                    //reportbangoigensolution.ProcessingMode = ProcessingMode.Local;
                    //reportbangoigensolution.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_Bangoigensolution2cn.rdlc";
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ReportDataSource rds = new ReportDataSource();
                    //    rds.Name = "DataSetbangoigensolution2cn";
                    //    rds.Value = ds.Tables[0];
                    //    reportbangoigensolution.LocalReport.DataSources.Clear();
                    //    reportbangoigensolution.LocalReport.DataSources.Add(rds);
                    //    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    //    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportbangoigensolution.LocalReport.SetParameters(reportParameters);
                    //    reportbangoigensolution.RefreshReport();
                    //}
                    // DataTable hợp nhất cho PostgreSQL và SQL Server
                    DataTable dtMerged = new DataTable();

                    // Lấy dữ liệu từ PostgreSQL
                    try
                    {
                        //string connString = "Host=192.168.90.117;Port=38529;Database=phuongdong;Username=kiethh;Password=ZLP4k2AAty35;SslMode=Disable;Client Encoding=UTF8;Include Error Detail=true;TrustServerCertificate=true";
                        DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                        DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);


                        using (var httpClient = new HttpClient())
                        {
                            // URL của Node.js API
                            string url = $"http://synthesisreport.tmhsg.com/get_gen_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}";

                            HttpResponseMessage response = await httpClient.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                                string jsonResponse = await response.Content.ReadAsStringAsync();
                                DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                                // Danh sách các cột cần chuyển đổi sang kiểu float
                                List<string> columnsToConvert = new List<string>
{

    "dongiathanhtoan"
};

                                // Sao chép cấu trúc DataTable và cập nhật kiểu dữ liệu các cột
                                DataTable dtPostgreSQLCorrected = dtPostgreSQL.Clone();
                                if (dtPostgreSQLCorrected.Columns.Contains("stt"))
                                {
                                    dtPostgreSQLCorrected.Columns["stt"].DataType = typeof(int);
                                }
                                foreach (string columnName in columnsToConvert)
                                {
                                    if (dtPostgreSQLCorrected.Columns.Contains(columnName))
                                    {
                                        dtPostgreSQLCorrected.Columns[columnName].DataType = typeof(float);
                                    }
                                }

                                // Sao chép dữ liệu và chuyển đổi kiểu dữ liệu
                                foreach (DataRow row in dtPostgreSQL.Rows)
                                {
                                    DataRow newRow = dtPostgreSQLCorrected.NewRow();

                                    foreach (DataColumn column in dtPostgreSQL.Columns)
                                    {
                                        if (columnsToConvert.Contains(column.ColumnName) && row[column] != DBNull.Value)
                                        {
                                            newRow[column.ColumnName] = Convert.ToSingle(row[column]);
                                        }
                                        else
                                        {
                                            newRow[column.ColumnName] = row[column];
                                        }
                                    }

                                    dtPostgreSQLCorrected.Rows.Add(newRow);
                                }

                                // Merge dữ liệu đã chuyển đổi
                                dtMerged.Merge(dtPostgreSQLCorrected);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi gọi API Node.js: " + response.ReasonPhrase);
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi gọi API Node.js: " + ex.Message);
                        return;
                    }

                    // Lấy dữ liệu từ SQL Server
                    DataTable dtSQLServer = new DataTable();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("DT_BanGenSolution2CN_2023", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                        cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        dap.Fill(dtSQLServer);

                        // Tạo DataTable mới với kiểu dữ liệu float cho cột 'tongdoanhthu'
                        DataTable dtSQLServerCorrected = dtSQLServer.Clone();
                        if (dtSQLServerCorrected.Columns.Contains("dongiathanhtoan"))
                        {
                            dtSQLServerCorrected.Columns["dongiathanhtoan"].DataType = typeof(float);
                        }
                        if (dtSQLServerCorrected.Columns.Contains("stt"))
                        {
                            dtSQLServerCorrected.Columns["stt"].DataType = typeof(int);
                        }
                        // Copy dữ liệu sang DataTable mới
                        foreach (DataRow row in dtSQLServer.Rows)
                        {
                            DataRow newRow = dtSQLServerCorrected.NewRow();
                            newRow.ItemArray = row.ItemArray;
                            if (newRow["dongiathanhtoan"] != DBNull.Value)
                            {
                                newRow["dongiathanhtoan"] = Convert.ToSingle(row["dongiathanhtoan"]);
                            }
                            dtSQLServerCorrected.Rows.Add(newRow);
                        }

                        dtMerged.Merge(dtSQLServerCorrected);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi kết nối SQL Server: " + ex.Message);
                        return;
                    }

                    // Kiểm tra xem DataTable có dữ liệu hay không
                    if (dtMerged.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.");
                        return;
                    }

                    // Hiển thị báo cáo RDLC với dữ liệu từ DataTable hợp nhất
                    reportbangoigensolution.ProcessingMode = ProcessingMode.Local;
                    reportbangoigensolution.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_Bangoigensolution2cn.rdlc";

                    // Gán dữ liệu vào report
                    reportbangoigensolution.LocalReport.DataSources.Clear();

                    // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                    ReportDataSource rdsMerged = new ReportDataSource("DataSetbangoigen2cn", dtMerged);
                    reportbangoigensolution.LocalReport.DataSources.Add(rdsMerged);

                    // Thiết lập tham số cho báo cáo
                    ReportParameterCollection reportParameters = new ReportParameterCollection
                    {
                        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    };
                    reportbangoigensolution.LocalReport.SetParameters(reportParameters);
                    reportbangoigensolution.RefreshReport();
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
