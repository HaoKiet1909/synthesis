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
    public partial class Form_CP_Nhapthuoc : Form
    {
        public Form_CP_Nhapthuoc()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlConnection con2;
        private void Form_CP_Nhapthuoc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);

            string conString2 = @"Data Source=server-one\mssql2012;Initial Catalog=eHospital_TMH;User ID=admin;Password=fpt@entent123";
            con2 = new SqlConnection(conString2);

            con.Open();
        }


        private  void cbbnhacungcap_MouseClick(object sender, MouseEventArgs e)
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
        private async void btntimkiemngay_Click(object sender, EventArgs e)
        {
            DataTable dtMerged = new DataTable();
            if (cbbcongty.SelectedItem == "Đa khoa")
            {
                //try
                //{

                //    SqlCommand cmd = new SqlCommand("CP_NhapThuoc_2023", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@NhaCungCap_ID", cbbnhacungcap.SelectedValue);

                //    cmd.CommandTimeout = 0;
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                //    dap.Fill(ds);
                //    reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                //    reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapthuoc.rdlc";
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        ReportDataSource rds = new ReportDataSource();
                //        rds.Name = "DataSetChiphinhapthuoc";
                //        rds.Value = ds.Tables[0];
                //        reportChiphinhapthuoc.LocalReport.DataSources.Clear();
                //        reportChiphinhapthuoc.LocalReport.DataSources.Add(rds);
                //        ReportParameterCollection reportParameters = new ReportParameterCollection();
                //        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                //        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                //        reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                //        reportChiphinhapthuoc.RefreshReport();
                //    }
                //    con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("" + ex);
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
                        string url = $"http://synthesisreport.tmhsg.com/get_chiphi_nhapthuoc_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={facility}";
                        //string url = $"http://localhost:3000/get_chiphi_nhapthuoc_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={facility}";

                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {

                            // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                            // Danh sách các cột cần chuyển đổi sang kiểu float
                            List<string> columnsToConvert = new List<string>
            {
                "soluong",
                "dongia",
                "chiphi"
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
                    SqlCommand cmd = new SqlCommand("CP_NhapThuoc_2023", con2);
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
                "soluong",
                "dongia",
                "chiphi"
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
                reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                //   reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapthuoc.rdlc";
                reportChiphinhapthuoc.LocalReport.ReportPath = "Rp_CP_Nhapthuoc.rdlc";
                reportChiphinhapthuoc.LocalReport.DataSources.Clear();

                // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                ReportDataSource rdsMerged = new ReportDataSource("DataSetNhapthuocbenhvien", dtMerged);
                reportChiphinhapthuoc.LocalReport.DataSources.Add(rdsMerged);

                // Thiết lập tham số cho báo cáo
                ReportParameterCollection reportParameters = new ReportParameterCollection
                    {
                        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    };
                reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                reportChiphinhapthuoc.RefreshReport();
            }
            else if (cbbcongty.SelectedItem == "Tai mũi họng")
            {
                //try
                //{

                //    SqlCommand cmd = new SqlCommand("CP_NhapThuoc_2023", con2);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@NhaCungCap_ID", cbbnhacungcap.SelectedValue);

                //    cmd.CommandTimeout = 0;
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                //    dap.Fill(ds);
                //    reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                //    reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapthuocbenhvien.rdlc";
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        ReportDataSource rds = new ReportDataSource();
                //        rds.Name = "DataSetNhapthuocbenhvien";
                //        rds.Value = ds.Tables[0];
                //        reportChiphinhapthuoc.LocalReport.DataSources.Clear();
                //        reportChiphinhapthuoc.LocalReport.DataSources.Add(rds);
                //        ReportParameterCollection reportParameters = new ReportParameterCollection();
                //        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                //        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                //        reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                //        reportChiphinhapthuoc.RefreshReport();
                //    }
                //    con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("" + ex);
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
                        string url = $"http://synthesisreport.tmhsg.com/get_chiphi_nhapthuoc_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}";
                        //string url = $"http://localhost:3000/get_chiphi_nhapthuoc_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}";

                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {

                            // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                            // Danh sách các cột cần chuyển đổi sang kiểu float
                            List<string> columnsToConvert = new List<string>
            {
                "soluong",
                "dongia",
                "chiphi"
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
                    SqlCommand cmd = new SqlCommand("CP_NhapThuoc_2023", con2);
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
                "soluong",
                "dongia",
                "chiphi"
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
                reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                 reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapthuocbenhvien.rdlc";
                //reportChiphinhapthuoc.LocalReport.ReportPath = "Rp_CP_Nhapthuocbenhvien.rdlc";
                reportChiphinhapthuoc.LocalReport.DataSources.Clear();

                // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                ReportDataSource rdsMerged = new ReportDataSource("DataSetNhapthuocbenhvien", dtMerged);
                reportChiphinhapthuoc.LocalReport.DataSources.Add(rdsMerged);

                // Thiết lập tham số cho báo cáo
                ReportParameterCollection reportParameters = new ReportParameterCollection
                    {
                        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    };
                reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                reportChiphinhapthuoc.RefreshReport();
            }
            else
            {
                //try
                //{

                //    SqlCommand cmd = new SqlCommand("CP_NhapThuoc2CN_2023", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@NhaCungCap_ID", cbbnhacungcap.SelectedValue);

                //    cmd.CommandTimeout = 0;
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                //    dap.Fill(ds);
                //    reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                //    reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapthuoc2CN.rdlc";
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        ReportDataSource rds = new ReportDataSource();
                //        rds.Name = "DataSetNhapthuoc2cn";
                //        rds.Value = ds.Tables[0];
                //        reportChiphinhapthuoc.LocalReport.DataSources.Clear();
                //        reportChiphinhapthuoc.LocalReport.DataSources.Add(rds);
                //        ReportParameterCollection reportParameters = new ReportParameterCollection();
                //        reportParameters.Add(new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")));
                //        reportParameters.Add(new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy")));
                //        reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                //        reportChiphinhapthuoc.RefreshReport();
                //    }
                //    con.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("" + ex);
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
                        string url = $"http://synthesisreport.tmhsg.com/get_chiphi_nhapthuoc_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}";
                       // string url = $"http://localhost:3000/get_chiphi_nhapthuoc_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}";

                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {

                            // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                            // Danh sách các cột cần chuyển đổi sang kiểu float
                            List<string> columnsToConvert = new List<string>
            {
                "soluong",
                "dongia",
                "chiphi"
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
                    SqlCommand cmd = new SqlCommand("CP_NhapThuoc2CN_2023", con);
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
                "soluong",
                "dongia",
                "chiphi"
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
                reportChiphinhapthuoc.ProcessingMode = ProcessingMode.Local;
                reportChiphinhapthuoc.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_CP_Nhapthuoc2CN.rdlc";
                //reportChiphinhapthuoc.LocalReport.ReportPath = "Rp_CP_Nhapthuocbenhvien.rdlc";
                reportChiphinhapthuoc.LocalReport.DataSources.Clear();

                // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                ReportDataSource rdsMerged = new ReportDataSource("DataSetNhapthuoc2cn", dtMerged);
                reportChiphinhapthuoc.LocalReport.DataSources.Add(rdsMerged);

                // Thiết lập tham số cho báo cáo
                ReportParameterCollection reportParameters = new ReportParameterCollection
                    {
                        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                    };
                reportChiphinhapthuoc.LocalReport.SetParameters(reportParameters);
                reportChiphinhapthuoc.RefreshReport();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
