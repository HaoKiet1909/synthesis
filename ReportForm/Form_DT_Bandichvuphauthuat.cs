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
    public partial class Form_DT_Bandichvuphauthuat : Form
    {
        public Form_DT_Bandichvuphauthuat()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void Form_DT_Bandichvuphauthuat_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=eHospital_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);
            con.Open();
        }

        private async void btntimkiemngay_Click(object sender, EventArgs e)
        {

            //try
            //{

            //SqlCommand cmd = new SqlCommand("DT_BanDichVuPhauThuat_2023", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
            //cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
            //cmd.CommandTimeout = 0;
            //DataSet ds = new DataSet();
            //SqlDataAdapter dap = new SqlDataAdapter(cmd);
            //dap.Fill(ds);
            //reportBandichvuphauthuat.ProcessingMode = ProcessingMode.Local;
            //reportBandichvuphauthuat.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_Bandichvuphauthuat.rdlc";
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ReportDataSource rds = new ReportDataSource();
            //    rds.Name = "DataSetBandichvuphauthuat";
            //    rds.Value = ds.Tables[0];
            //    reportBandichvuphauthuat.LocalReport.DataSources.Clear();
            //    reportBandichvuphauthuat.LocalReport.DataSources.Add(rds);
            //    ReportParameterCollection reportParameters = new ReportParameterCollection();
            //    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
            //    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
            //    reportBandichvuphauthuat.LocalReport.SetParameters(reportParameters);
            //    reportBandichvuphauthuat.RefreshReport();
            //}
            //con.Close();

            //            }
            DataTable dtMerged = new DataTable();
            try
            {
                dtMerged.Clear();

                DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                

                using (var httpClient = new HttpClient())
                {
                    // URL của Node.js API
                    string url = $"http://synthesisreport.tmhsg.com/get_bandichvu_phauthuat_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}";

                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                        // Danh sách các cột cần chuyển đổi sang kiểu float
                        List<string> columnsToConvert = new List<string>
            {
                "dongiadoanhthu",
                        "dongiahotro",
                        "dongiathanhtoan"
            };

                        // Sao chép cấu trúc DataTable và cập nhật kiểu dữ liệu các cột
                        DataTable dtPostgreSQLCorrected = dtPostgreSQL.Clone();
                        if (dtPostgreSQLCorrected.Columns.Contains("stts"))
                        {
                            dtPostgreSQLCorrected.Columns["stts"].DataType = typeof(int);
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
                SqlCommand cmd = new SqlCommand("DT_BanDichVuPhauThuat_2023", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(dtSQLServer);

                // Tạo DataTable mới với kiểu dữ liệu float cho các cột
                // Sao chép cấu trúc của DataTable từ SQL Server
                DataTable dtSQLServerCorrected = dtSQLServer.Clone();

                // Danh sách các cột cần chuyển đổi sang kiểu float
                List<string> columnsToConvert = new List<string>
                    {
                        "dongiadoanhthu",
                        "dongiahotro",
                        "dongiathanhtoan"
                        
                    };

                // Cập nhật kiểu dữ liệu cho các cột nằm trong danh sách
                foreach (string columnName in columnsToConvert)
                {
                    if (dtSQLServerCorrected.Columns.Contains(columnName))
                    {
                        dtSQLServerCorrected.Columns[columnName].DataType = typeof(float);
                    }
                }

                // Sao chép dữ liệu sang DataTable mới và chuyển đổi các cột cần thiết
                foreach (DataRow row in dtSQLServer.Rows)
                {
                    DataRow newRow = dtSQLServerCorrected.NewRow();

                    foreach (DataColumn column in dtSQLServer.Columns)
                    {
                        if (columnsToConvert.Contains(column.ColumnName) && row[column] != DBNull.Value)
                        {
                            // Chuyển đổi các cột trong danh sách sang kiểu float
                            newRow[column.ColumnName] = Convert.ToSingle(row[column]);
                        }
                        else
                        {
                            // Giữ nguyên giá trị cho các cột không cần chuyển đổi
                            newRow[column.ColumnName] = row[column];
                        }
                    }

                    // Thêm hàng mới vào DataTable đã chuyển đổi
                    dtSQLServerCorrected.Rows.Add(newRow);
                }

                // Merge dữ liệu đã được chuyển đổi vào dtMerged
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
            reportBandichvuphauthuat.ProcessingMode = ProcessingMode.Local;
            reportBandichvuphauthuat.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_Bandichvuphauthuat.rdlc";
            reportBandichvuphauthuat.LocalReport.DataSources.Clear();

            // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
            ReportDataSource rdsMerged = new ReportDataSource("DataSetBandichvuphauthuat", dtMerged);
            reportBandichvuphauthuat.LocalReport.DataSources.Add(rdsMerged);

            // Thiết lập tham số cho báo cáo
            ReportParameterCollection reportParameters = new ReportParameterCollection
                    {
                        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    };
            reportBandichvuphauthuat.LocalReport.SetParameters(reportParameters);
            reportBandichvuphauthuat.RefreshReport();

        }
    



        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
