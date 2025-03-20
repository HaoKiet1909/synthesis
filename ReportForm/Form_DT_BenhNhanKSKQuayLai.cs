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
    public partial class Form_DT_BenhNhanKSKQuayLai : Form
    {
        private SqlConnection con;
        private DataTable dt;
        private bool userTyping;

        public Form_DT_BenhNhanKSKQuayLai()
        {
            InitializeComponent();
        }

        private void Form_DT_BenhNhanKSKQuayLai_Load(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;

            string conString = @"Data Source=server-one\mssql2012;Initial Catalog=Clinic_TMH;User ID=admin;Password=fpt@entent123";
            con = new SqlConnection(conString);

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
            LoadAllData();
        }

        //private async void txSearch_TextChanged(object sender, EventArgs e)
        //{
        //    DataTable dtMergedDVCT = new DataTable();
        //    string keyword = txSearch.Text.Trim();

        //    if (keyword.Length > 1)
        //    {
        //        try
        //        {
        //            dtMergedDVCT.Clear();
        //            SqlCommand cmd = new SqlCommand("SELECT DonViCongTac_Id, TenDonViCongTac FROM dbo.DM_DonViCongTac WHERE TamNgung = 0 AND TenDonViCongTac LIKE @TenDonViCongTac ORDER BY TenDonViCongTac ASC", con);
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("@TenDonViCongTac", "%" + keyword + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            dt = new DataTable();
        //            da.Fill(dt);

        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                searchResult.DataSource = dt;
        //                searchResult.Height = searchResult.Rows.Count * 30;
        //            }
        //            else
        //            {
        //                searchResult.Height = 0;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
        //        }
        //    }
        //    else if (txSearch.Text.Length <= 0)
        //    {
        //        searchResult.Height = 0;
        //    }
        //}
        private DataTable _cachedData = new DataTable(); // Biến lưu trữ dữ liệu đã tải

        // Tải toàn bộ dữ liệu từ SQL và API khi khởi động ứng dụng
        private async void LoadAllData()
        {
            try
            {
                DataTable dtSQL = new DataTable();
                DataTable dtAPI = new DataTable();

                // 1. Truy vấn SQL Server
                SqlCommand cmd = new SqlCommand(
                    "SELECT CAST(DonViCongTac_Id AS VARCHAR) AS DonViCongTac_Id, TenDonViCongTac FROM dbo.DM_DonViCongTac WHERE TamNgung = 0 ORDER BY TenDonViCongTac ASC",
                    con
                );

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSQL);

                // 2. Gọi API và chuyển dữ liệu thành DataTable
                string url = $"http://synthesisreport.tmhsg.com/get_doanhthu_kskquaylaikham_2024_call_health_contract";
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        dtAPI = JsonConvert.DeserializeObject<DataTable>(jsonResponse);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi gọi API: " + response.ReasonPhrase);
                    }
                }

                // 3. Chuẩn hóa kiểu dữ liệu cho việc gộp bảng
                NormalizeColumnTypes(dtSQL, "DonViCongTac_Id", typeof(string));
                NormalizeColumnTypes(dtAPI, "DonViCongTac_Id", typeof(string));

                // 4. Gộp dữ liệu từ SQL và API
                _cachedData.Merge(dtSQL);
                _cachedData.Merge(dtAPI);

                //MessageBox.Show("Dữ liệu đã tải xong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Lọc dữ liệu dựa trên từ khóa từ ô tìm kiếm
        private void txSearch_TextChanged(object sender, EventArgs e)
        {

            string keyword = txSearch.Text.Trim().ToLower();

            if (keyword.Length > 1)
            {
                // 5. Lọc dữ liệu từ _cachedData dựa trên từ khóa
                DataView dv = _cachedData.DefaultView;
                dv.RowFilter = $"TenDonViCongTac LIKE '%{keyword}%'";

                DataTable filteredData = dv.ToTable();

                // 6. Hiển thị dữ liệu đã lọc
                if (filteredData.Rows.Count > 0)
                {
                    searchResult.DataSource = filteredData;
                    searchResult.Height = searchResult.Rows.Count * 30;
                }
                else
                {
                    searchResult.Height = 0;
                }
            }
            else if (txSearch.Text.Length <= 0)
            {
                searchResult.Height = 0;
            }
        }

        // Hàm chuẩn hóa kiểu dữ liệu của cột trong DataTable
        private void NormalizeColumnTypes(DataTable table, string columnName, Type targetType)
        {
            if (table.Columns.Contains(columnName) && table.Columns[columnName].DataType != targetType)
            {
                // Tạo cột tạm với kiểu dữ liệu mới
                DataColumn newColumn = new DataColumn(columnName + "_temp", targetType);

                // Thêm cột tạm vào DataTable
                table.Columns.Add(newColumn);

                // Sao chép dữ liệu từ cột cũ sang cột tạm
                foreach (DataRow row in table.Rows)
                {
                    row[newColumn] = row[columnName].ToString();
                }

                // Xóa cột cũ và đổi tên cột tạm
                table.Columns.Remove(columnName);
                newColumn.ColumnName = columnName;
            }
        }



        private void searchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < searchResult.Rows.Count)
            {
                DataGridViewRow row = searchResult.Rows[e.RowIndex];
                txSearch.Text = row.Cells["DonViCongTac_Id"].Value.ToString();
            }
            searchResult.Height = 0;
        }

        private void btntimkiemngay_Click(object sender, EventArgs e)
        {
            try
            {
                int? phamVi = GetPhamViFromComboBox(cbbchinhanh.SelectedItem?.ToString());
                
                string fac = GetFacFromComboBox(cbbchinhanh.SelectedItem?.ToString());
                ExecuteReport(phamVi,fac);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private int? GetPhamViFromComboBox(string selectedItem)
        {
            switch (selectedItem)
            {
                case "9-15":
                    return 1;
                case "Q7":
                    return 2;
                case "BV":
                    return 3;
                default:
                    return null; // null indicates all branches
            }
        }
        private string GetFacFromComboBox(string selectedItem)
        {
            switch (selectedItem)
            {
                case "9-15":
                    return "00000000-0000-0000-0000-000000000105";
                case "Q7":
                    return "00000000-0000-0000-0000-000000000106";
                case "BV":
                    return "00000000-0000-4000-0000-000000000000";
                default:
                    return null; // null indicates all branches
            }
        }

        private async void ExecuteReport(int? phamVi, string fac)
        {
            DataTable dtMerged = new DataTable();
            try
            {
                //using (SqlCommand cmd = new SqlCommand("BaoCaoThongKeBenhNhanKSKQuayLaiKham", con))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.CommandTimeout = 0;

                //    cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                //    cmd.Parameters.AddWithValue("@PhamVi", phamVi.HasValue ? (object)phamVi.Value : DBNull.Value);
                //    cmd.Parameters.AddWithValue("@DonViCongTac_ID", string.IsNullOrEmpty(txSearch.Text) ? (object)DBNull.Value : txSearch.Text);

                //    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    dap.Fill(ds);

                //    reporthinhthucdenkham.ProcessingMode = ProcessingMode.Local;
                //    reporthinhthucdenkham.LocalReport.ReportPath = @"\\server-one\synthesisreports$\Rp_DT_BenhNhanKSKQuayLaiKham.rdlc";

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        ReportDataSource rds = new ReportDataSource
                //        {
                //            Name = "DataSetbenhnhankskquaylaikham",
                //            Value = ds.Tables[0]
                //        };

                //        reporthinhthucdenkham.LocalReport.DataSources.Clear();
                //        reporthinhthucdenkham.LocalReport.DataSources.Add(rds);

                //        ReportParameterCollection reportParameters = new ReportParameterCollection
                //{
                //    new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
                //    new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
                //};
                //        reporthinhthucdenkham.LocalReport.SetParameters(reportParameters);
                //        reporthinhthucdenkham.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Không có dữ liệu để hiển thị.");
                //    }
                //}
                try
                {
                    dtMerged.Clear();

                    DateTime startDateTime = TuNgay.Value.Date; // Chỉ giữ phần ngày, bỏ phần giờ phút giây
                    DateTime endDateTime = DenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                    string txSearchValue = txSearch.Text.Trim(); // Lưu giá trị của txSearch.Text

                    // Kiểm tra xem txSearch.Text có phải là UUID hay không
                    bool isUUID = Guid.TryParse(txSearchValue, out Guid facilityId);

                    if (!string.IsNullOrEmpty(txSearchValue) && isUUID)
                    {
                        // Nếu là UUID, chỉ gọi API
                        using (var httpClient = new HttpClient())
                        {
                            // URL của Node.js API
                            string url = $"http://synthesisreport.tmhsg.com/get_doanhthu_kskquaylaikham_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={fac}";
                            if (!string.IsNullOrEmpty(txSearch.Text))
                            {
                                url += $"&congty={Uri.EscapeDataString(txSearch.Text)}";
                            }
                            HttpResponseMessage response = await httpClient.GetAsync(url);
                            MessageBox.Show(url);
                            if (response.IsSuccessStatusCode)
                            {
                                // Lấy dữ liệu JSON từ Node.js API và chuyển đổi thành DataTable
                                string jsonResponse = await response.Content.ReadAsStringAsync();
                                DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                                // Danh sách các cột cần chuyển đổi sang kiểu float
                                List<string> columnsToConvert = new List<string> { "sotien", "namhd" };

                                // Sao chép cấu trúc DataTable và cập nhật kiểu dữ liệu các cột
                                DataTable dtPostgreSQLCorrected = dtPostgreSQL.Clone();
                                if (dtPostgreSQLCorrected.Columns.Contains("stt"))
                                {
                                    dtPostgreSQLCorrected.Columns["stt"].DataType = typeof(Int64);
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
                    else if (!string.IsNullOrEmpty(txSearchValue) && int.TryParse(txSearchValue, out int donViCongTacId))
                    {
                        // Nếu là số nguyên, chỉ gọi SQL Server
                        DataTable dtSQLServer = new DataTable();
                        try
                        {
                            SqlCommand cmd = new SqlCommand("BaoCaoThongKeBenhNhanKSKQuayLaiKham", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                            cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                            cmd.Parameters.AddWithValue("@PhamVi", phamVi.HasValue ? (object)phamVi.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@DonViCongTac_ID", donViCongTacId);

                            SqlDataAdapter dap = new SqlDataAdapter(cmd);
                            dap.Fill(dtSQLServer);

                            // Tạo DataTable mới với kiểu dữ liệu float cho các cột
                            DataTable dtSQLServerCorrected = dtSQLServer.Clone();

                            // Danh sách các cột cần chuyển đổi sang kiểu float
                            List<string> columnsToConvert = new List<string> { "sotien", "namhd" };

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
                                        newRow[column.ColumnName] = Convert.ToSingle(row[column]);
                                    }
                                    else
                                    {
                                        newRow[column.ColumnName] = row[column];
                                    }
                                }
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
                    }
                    else if (string.IsNullOrEmpty(txSearchValue))
                    {
                        // Nếu rỗng, gọi cả hai API và SQL Server
                        // Gọi Node.js API
                        using (var httpClient = new HttpClient())
                        {
                            string url = $"http://synthesisreport.tmhsg.com/get_doanhthu_kskquaylaikham_2024?startDate={startDateTime:yyyy-MM-ddTHH:mm:ss}&endDate={endDateTime:yyyy-MM-ddTHH:mm:ss}&facility={fac}";
                            HttpResponseMessage response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                string jsonResponse = await response.Content.ReadAsStringAsync();
                                DataTable dtPostgreSQL = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                                List<string> columnsToConvert = new List<string> { "sotien", "namhd" };
                                DataTable dtPostgreSQLCorrected = dtPostgreSQL.Clone();
                                if (dtPostgreSQLCorrected.Columns.Contains("stt"))
                                {
                                    dtPostgreSQLCorrected.Columns["stt"].DataType = typeof(Int64);
                                }
                                foreach (string columnName in columnsToConvert)
                                {
                                    if (dtPostgreSQLCorrected.Columns.Contains(columnName))
                                    {
                                        dtPostgreSQLCorrected.Columns[columnName].DataType = typeof(float);
                                    }
                                }

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
                                dtMerged.Merge(dtPostgreSQLCorrected);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi gọi API Node.js: " + response.ReasonPhrase);
                                return;
                            }
                        }

                        // Gọi SQL Server
                        DataTable dtSQLServer = new DataTable();
                        try
                        {
                            SqlCommand cmd = new SqlCommand("BaoCaoThongKeBenhNhanKSKQuayLaiKham", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TuNgay", TuNgay.Value.ToString("yyyy/MM/dd"));
                            cmd.Parameters.AddWithValue("@DenNgay", DenNgay.Value.ToString("yyyy/MM/dd"));
                            cmd.Parameters.AddWithValue("@PhamVi", phamVi.HasValue ? (object)phamVi.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@DonViCongTac_ID", (object)DBNull.Value); // Gán DBNull.Value cho tham số DonViCongTac_ID

                            SqlDataAdapter dap = new SqlDataAdapter(cmd);
                            dap.Fill(dtSQLServer);

                            DataTable dtSQLServerCorrected = dtSQLServer.Clone();
                            List<string> columnsToConvert = new List<string> { "sotien", "namhd" };

                            foreach (string columnName in columnsToConvert)
                            {
                                if (dtSQLServerCorrected.Columns.Contains(columnName))
                                {
                                    dtSQLServerCorrected.Columns[columnName].DataType = typeof(float);
                                }
                            }

                            foreach (DataRow row in dtSQLServer.Rows)
                            {
                                DataRow newRow = dtSQLServerCorrected.NewRow();
                                foreach (DataColumn column in dtSQLServer.Columns)
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
                                dtSQLServerCorrected.Rows.Add(newRow);
                            }
                            dtMerged.Merge(dtSQLServerCorrected);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi kết nối SQL Server: " + ex.Message);
                            return;
                        }
                    }

                    // Kiểm tra xem DataTable có dữ liệu hay không
                    if (dtMerged.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.");
                        return;
                    }

                    // Hiển thị báo cáo RDLC với dữ liệu từ DataTable hợp nhất
                    reporthinhthucdenkham.ProcessingMode = ProcessingMode.Local;
                    reporthinhthucdenkham.LocalReport.ReportPath = @"\\server-one\SynthesisReports$\Rp_DT_BenhNhanKSKQuayLaiKham.rdlc";
                    //reporthinhthucdenkham.LocalReport.ReportPath = "Rp_DT_BenhNhanKSKQuayLaiKham.rdlc";
                    reporthinhthucdenkham.LocalReport.DataSources.Clear();

                    // Thêm dữ liệu từ DataTable hợp nhất (PostgreSQL và SQL Server)
                    ReportDataSource rdsMerged = new ReportDataSource("DataSetbenhnhankskquaylaikham", dtMerged);
                    reporthinhthucdenkham.LocalReport.DataSources.Add(rdsMerged);

                    // Thiết lập tham số cho báo cáo
                    ReportParameterCollection reportParameters = new ReportParameterCollection
    {
        new ReportParameter("TuNgayPara", TuNgay.Value.ToString("dd/MM/yyyy")),
        new ReportParameter("DenNgayPara", DenNgay.Value.ToString("dd/MM/yyyy"))
    };
                    reporthinhthucdenkham.LocalReport.SetParameters(reportParameters);
                    reporthinhthucdenkham.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
            }
        }

        private void Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
