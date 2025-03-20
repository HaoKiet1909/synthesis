using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Npgsql;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ReportForm
{
    public partial class Form_DT_TongHopDichVu : Form
    {
        public Form_DT_TongHopDichVu()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlConnection con1;
        SqlConnection con2;
        private void Form_DT_TongHopDichVu_Load(object sender, EventArgs e)
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

        private async void btntimkiemngay_Click(object sender, EventArgs e)
        {
            DataTable dtMerged = new DataTable();
            try
            {
                if (cbbchinhanh.SelectedItem == "9-15")
                {

                    //SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    //cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    ////con.Close();


                    //cmd.CommandTimeout = 0;
                    //DataSet ds = new DataSet();
                    //SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    //dap.Fill(ds);

                    //reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    ////reportsoluotkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_TongHopDichVu_915.rdlc";
                    //reportsoluotkham.LocalReport.ReportPath = "Rp_DT_TongHopDichVu_915.rdlc";
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ReportDataSource rds = new ReportDataSource();
                    //    rds.Name = "DataSetdoanhthutonghop9152";
                    //    rds.Value = ds.Tables[0];
                    //    reportsoluotkham.LocalReport.DataSources.Clear();
                    //    reportsoluotkham.LocalReport.DataSources.Add(rds);
                    //    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    //    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    //    reportsoluotkham.RefreshReport();
                    //}
                    // DataTable hợp nhất cho PostgreSQL và SQL Server


                    // Lấy dữ liệu từ PostgreSQL
                    //                    try
                    //                    {
                    //                        dtMerged.Clear();
                    //                        string connString = "Host=192.168.90.117;Port=38529;Database=phuongdong;Username=kiethh;Password=ZLP4k2AAty35;SslMode=Disable;Client Encoding=UTF8;Include Error Detail=true;TrustServerCertificate=true";
                    //                        DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                    //                        DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                    //                        string facility = "00000000-0000-0000-0000-000000000105";

                    //                        using (var connpg = new NpgsqlConnection(connString))
                    //                        {
                    //                            connpg.Open();
                    //                            using (var cmds = new NpgsqlCommand("SELECT * FROM get_doanhthu_tonghopdichvu_2024(@start_date, @end_date, @facility)", connpg))
                    //                            {
                    //                                cmds.Parameters.AddWithValue("start_date", NpgsqlTypes.NpgsqlDbType.Timestamp, startDateTime);
                    //                                cmds.Parameters.AddWithValue("end_date", NpgsqlTypes.NpgsqlDbType.Timestamp, endDateTime);
                    //                                cmds.Parameters.AddWithValue("facility", NpgsqlTypes.NpgsqlDbType.Uuid, Guid.Parse(facility));

                    //                                using (var adapter = new NpgsqlDataAdapter(cmds))
                    //                                {
                    //                                    DataTable dtPostgreSQL = new DataTable();
                    //                                    adapter.Fill(dtPostgreSQL);

                    //                                    // Danh sách các cột cần chuyển đổi sang kiểu float
                    //                                    List<string> columnsToConvert = new List<string>
                    //            {
                    //                "soluong_khammois",
                    //                "doanhthu_khammois",
                    //                "soluong_khambenhs",
                    //                "doanhthu_khambenhs",
                    //                "soluong_taikhams",
                    //                "doanhthu_taikhams",
                    //                "tongsoluongs",
                    //                "tongdoanhthus"
                    //            };

                    //                                    // Sao chép cấu trúc DataTable
                    //                                    DataTable dtPostgreSQLCorrected = dtPostgreSQL.Clone();

                    //                                    // Cập nhật kiểu dữ liệu của các cột trong danh sách columnsToConvert
                    //                                    foreach (string columnName in columnsToConvert)
                    //                                    {
                    //                                        if (dtPostgreSQLCorrected.Columns.Contains(columnName))
                    //                                        {
                    //                                            dtPostgreSQLCorrected.Columns[columnName].DataType = typeof(float);
                    //                                        }
                    //                                    }

                    //                                    // Sao chép dữ liệu và chuyển đổi kiểu dữ liệu cho các cột cần thiết
                    //                                    foreach (DataRow row in dtPostgreSQL.Rows)
                    //                                    {
                    //                                        DataRow newRow = dtPostgreSQLCorrected.NewRow();

                    //                                        foreach (DataColumn column in dtPostgreSQL.Columns)
                    //                                        {
                    //                                            // Chuyển đổi các cột trong danh sách columnsToConvert
                    //                                            if (columnsToConvert.Contains(column.ColumnName) && row[column] != DBNull.Value)
                    //                                            {
                    //                                                newRow[column.ColumnName] = Convert.ToSingle(row[column]);
                    //                                            }
                    //                                            else
                    //                                            {
                    //                                                // Giữ nguyên giá trị của các cột khác
                    //                                                newRow[column.ColumnName] = row[column];
                    //                                            }
                    //                                        }

                    //                                        // Thêm hàng mới vào DataTable
                    //                                        dtPostgreSQLCorrected.Rows.Add(newRow);
                    //                                    }

                    //                                    // Merge dữ liệu đã được chuyển đổi
                    //                                    dtMerged.Merge(dtPostgreSQLCorrected);
                    //                                }
                    //                            }
                    //                        }

                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        MessageBox.Show("Lỗi khi kết nối PostgreSQL: " + ex.Message);
                    //                        return;
                    //                    }


                    //                    // Lấy dữ liệu từ SQL Server
                    //                    DataTable dtSQLServer = new DataTable();
                    //                    try
                    //                    {
                    //                        SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con);
                    //                        cmd.CommandType = CommandType.StoredProcedure;
                    //                        cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    //                        cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    //                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    //                        dap.Fill(dtSQLServer);

                    //                        // Tạo DataTable mới với kiểu dữ liệu float cho các cột
                    //                        // Sao chép cấu trúc của DataTable từ SQL Server
                    //                        DataTable dtSQLServerCorrected = dtSQLServer.Clone();

                    //                        // Danh sách các cột cần chuyển đổi sang kiểu float
                    //                        List<string> columnsToConvert = new List<string>
                    //{
                    //    "soluong_khammois",
                    //    "doanhthu_khammois",
                    //    "soluong_khambenhs",
                    //    "doanhthu_khambenhs",
                    //    "soluong_taikhams",
                    //    "doanhthu_taikhams",
                    //    "tongsoluongs",
                    //    "tongdoanhthus"
                    //};

                    //                        // Cập nhật kiểu dữ liệu cho các cột nằm trong danh sách
                    //                        foreach (string columnName in columnsToConvert)
                    //                        {
                    //                            if (dtSQLServerCorrected.Columns.Contains(columnName))
                    //                            {
                    //                                dtSQLServerCorrected.Columns[columnName].DataType = typeof(float);
                    //                            }
                    //                        }

                    //                        // Sao chép dữ liệu sang DataTable mới và chuyển đổi các cột cần thiết
                    //                        foreach (DataRow row in dtSQLServer.Rows)
                    //                        {
                    //                            DataRow newRow = dtSQLServerCorrected.NewRow();

                    //                            foreach (DataColumn column in dtSQLServer.Columns)
                    //                            {
                    //                                if (columnsToConvert.Contains(column.ColumnName) && row[column] != DBNull.Value)
                    //                                {
                    //                                    // Chuyển đổi các cột trong danh sách sang kiểu float
                    //                                    newRow[column.ColumnName] = Convert.ToSingle(row[column]);
                    //                                }
                    //                                else
                    //                                {
                    //                                    // Giữ nguyên giá trị cho các cột không cần chuyển đổi
                    //                                    newRow[column.ColumnName] = row[column];
                    //                                }
                    //                            }

                    //                            // Thêm hàng mới vào DataTable đã chuyển đổi
                    //                            dtSQLServerCorrected.Rows.Add(newRow);
                    //                        }

                    //                        // Merge dữ liệu đã được chuyển đổi vào dtMerged
                    //                        dtMerged.Merge(dtSQLServerCorrected);

                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        MessageBox.Show("Lỗi khi kết nối SQL Server: " + ex.Message);
                    //                        return;
                    //                    }

                    //                    // Kiểm tra xem DataTable có dữ liệu hay không
                    //                    if (dtMerged.Rows.Count == 0)
                    //                    {
                    //                        MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.");
                    //                        return;
                    //                    }

                    //                    // Hiển thị báo cáo RDLC với dữ liệu từ DataTable hợp nhất
                    //                    reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    //                    reportsoluotkham.LocalReport.ReportPath = "Rp_DT_TongHopDichVu_915.rdlc";
                    //                    reportsoluotkham.LocalReport.DataSources.Clear();

                    //                    // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                    //                    ReportDataSource rdsMerged = new ReportDataSource("DataSetdoanhthutonghop9152", dtMerged);
                    //                    reportsoluotkham.LocalReport.DataSources.Add(rdsMerged);

                    //                    // Thiết lập tham số cho báo cáo
                    //                    ReportParameterCollection reportParameters = new ReportParameterCollection
                    //{
                    //    new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                    //    new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    //};
                    //                    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    //                    reportsoluotkham.RefreshReport();
                    try
                    {
                        dtMerged.Clear();

                        DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                        DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                        string facility = "00000000-0000-0000-0000-000000000105";

                        using (var httpClient = new HttpClient())
                        {
                            // URL của Node.js API
                            string url = $"http://synthesisreport.tmhsg.com/get_doanhthu_tonghopdichvu_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={facility}";

                            HttpResponseMessage response = await httpClient.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                                string jsonResponse = await response.Content.ReadAsStringAsync();
                                DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                                // Danh sách các cột cần chuyển đổi sang kiểu float
                                List<string> columnsToConvert = new List<string>
            {
                "soluong_khammois",
                "doanhthu_khammois",
                "soluong_khambenhs",
                "doanhthu_khambenhs",
                "soluong_taikhams",
                "doanhthu_taikhams",
                "tongsoluongs",
                "tongdoanhthus"
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
                        SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con);
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
                        "soluong_khammois",
                        "doanhthu_khammois",
                        "soluong_khambenhs",
                        "doanhthu_khambenhs",
                        "soluong_taikhams",
                        "doanhthu_taikhams",
                        "tongsoluongs",
                        "tongdoanhthus"
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
                    reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    reportsoluotkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_TongHopDichVu_915.rdlc";
                    reportsoluotkham.LocalReport.DataSources.Clear();

                    // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                    ReportDataSource rdsMerged = new ReportDataSource("DataSetdoanhthutonghop9152", dtMerged);
                    reportsoluotkham.LocalReport.DataSources.Add(rdsMerged);

                    // Thiết lập tham số cho báo cáo
                    ReportParameterCollection reportParameters = new ReportParameterCollection
                    {
                        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    };
                    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    reportsoluotkham.RefreshReport();

                }

                else if (cbbchinhanh.SelectedItem == "Q7")
                {
                    //SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con1);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    //cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    ////con.Close();


                    //cmd.CommandTimeout = 0;
                    //DataSet ds = new DataSet();
                    //SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    //dap.Fill(ds);

                    //reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    //reportsoluotkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_TongHopDichVu_Q7.rdlc";
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ReportDataSource rds = new ReportDataSource();
                    //    rds.Name = "DataSetTonghopdvq7";
                    //    rds.Value = ds.Tables[0];
                    //    reportsoluotkham.LocalReport.DataSources.Clear();
                    //    reportsoluotkham.LocalReport.DataSources.Add(rds);
                    //    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    //    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    //    reportsoluotkham.RefreshReport();
                    //}
                    try
                    {
                        dtMerged.Clear();
                        //string connString = "Host=192.168.90.117;Port=38529;Database=phuongdong;Username=kiethh;Password=ZLP4k2AAty35;SslMode=Disable;Client Encoding=UTF8;Include Error Detail=true;TrustServerCertificate=true";
                        DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                        DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                        string facility = "00000000-0000-0000-0000-000000000106";

                        using (var httpClient = new HttpClient())
                        {
                            // URL của Node.js API
                            string url = $"http://synthesisreport.tmhsg.com/get_doanhthu_tonghopdichvu_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={facility}";
                           
                            HttpResponseMessage response = await httpClient.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                
                                // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                                string jsonResponse = await response.Content.ReadAsStringAsync();
                                DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                                // Danh sách các cột cần chuyển đổi sang kiểu float
                                List<string> columnsToConvert = new List<string>
            {
                "soluong_khammois",
                "doanhthu_khammois",
                "soluong_khambenhs",
                "doanhthu_khambenhs",
                "soluong_taikhams",
                "doanhthu_taikhams",
                "tongsoluongs",
                "tongdoanhthus"
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
                        SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con1);
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
    "soluong_khammois",
    "doanhthu_khammois",
    "soluong_khambenhs",
    "doanhthu_khambenhs",
    "soluong_taikhams",
    "doanhthu_taikhams",
    "tongsoluongs",
    "tongdoanhthus"
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
                    reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    reportsoluotkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_TongHopDichVu_Q7.rdlc";
                    reportsoluotkham.LocalReport.DataSources.Clear();

                    // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                    ReportDataSource rdsMerged = new ReportDataSource("DataSetTonghopdvq72", dtMerged);
                    reportsoluotkham.LocalReport.DataSources.Add(rdsMerged);

                    // Thiết lập tham số cho báo cáo
                    ReportParameterCollection reportParameters = new ReportParameterCollection
{
    new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
    new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
};
                    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    reportsoluotkham.RefreshReport();
                }
            
                else if (cbbchinhanh.SelectedItem == "BV")
                {
                    //SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con2);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                    //cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));

                    ////con.Close();


                    //cmd.CommandTimeout = 0;
                    //DataSet ds = new DataSet();
                    //SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    //dap.Fill(ds);

                    //reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    //reportsoluotkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_TongHopDichVu.rdlc";
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ReportDataSource rds = new ReportDataSource();
                    //    rds.Name = "DataSetdttonghopdichvu";
                    //    rds.Value = ds.Tables[0];
                    //    reportsoluotkham.LocalReport.DataSources.Clear();
                    //    reportsoluotkham.LocalReport.DataSources.Add(rds);
                    //    ReportParameterCollection reportParameters = new ReportParameterCollection();
                    //    reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                    //    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    //    reportsoluotkham.RefreshReport();
                    //}
                    try
                    {
                        dtMerged.Clear();
                        //string connString = "Host=192.168.90.117;Port=38529;Database=phuongdong;Username=kiethh;Password=ZLP4k2AAty35;SslMode=Disable;Client Encoding=UTF8;Include Error Detail=true;TrustServerCertificate=true";
                        DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                        DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                        string facility = "00000000-0000-4000-0000-000000000000";

                        using (var httpClient = new HttpClient())
                        {
                            // URL của Node.js API
                            string url = $"http://synthesisreport.tmhsg.com/get_doanhthu_tonghopdichvu_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={facility}";

                            HttpResponseMessage response = await httpClient.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {

                                // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                                string jsonResponse = await response.Content.ReadAsStringAsync();
                                DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                                // Danh sách các cột cần chuyển đổi sang kiểu float
                                List<string> columnsToConvert = new List<string>
            {
                "soluong_khammois",
                "doanhthu_khammois",
                "soluong_khambenhs",
                "doanhthu_khambenhs",
                "soluong_taikhams",
                "doanhthu_taikhams",
                "tongsoluongs",
                "tongdoanhthus"
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
                        SqlCommand cmd = new SqlCommand("DT_TongHopDichVu_2023", con2);
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
    "soluong_khammois",
    "doanhthu_khammois",
    "soluong_khambenhs",
    "doanhthu_khambenhs",
    "soluong_taikhams",
    "doanhthu_taikhams",
    "tongsoluongs",
    "tongdoanhthus"
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
                    reportsoluotkham.ProcessingMode = ProcessingMode.Local;
                    reportsoluotkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_TongHopDichVu.rdlc";
                    ///reportsoluotkham.LocalReport.ReportPath = "Rp_DT_TongHopDichVu.rdlc";
                    reportsoluotkham.LocalReport.DataSources.Clear();

                    // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                    ReportDataSource rdsMerged = new ReportDataSource("DataSetdttonghopdichvu", dtMerged);
                    reportsoluotkham.LocalReport.DataSources.Add(rdsMerged);

                    // Thiết lập tham số cho báo cáo
                    ReportParameterCollection reportParameters = new ReportParameterCollection
{
    new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
    new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
};
                    reportsoluotkham.LocalReport.SetParameters(reportParameters);
                    reportsoluotkham.RefreshReport();
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
