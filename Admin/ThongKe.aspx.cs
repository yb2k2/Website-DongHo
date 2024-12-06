using System;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

public partial class Admin_ThongKe : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    public string chartDataJson; // Dữ liệu JSON cho biểu đồ

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadThongKeData();
        }
    }

    private void LoadThongKeData()
    {
        // Khởi tạo kết nối với cơ sở dữ liệu
        using (SqlConnection connect = new SqlConnection(strcn))
        {
            try
            {
                connect.Open();

                // Tính doanh thu theo ngày, tháng, năm
                decimal doanhThuNgay = GetDoanhThu(connect, "DAY");
                decimal doanhThuThang = GetDoanhThu(connect, "MONTH");
                decimal doanhThuNam = GetDoanhThu(connect, "YEAR");

                // Tổng doanh thu
                decimal tongDoanhThu = doanhThuNgay + doanhThuThang + doanhThuNam;

                // Hiển thị tổng doanh thu
                lblTongDoanhThu.Text = String.Format("Tổng doanh thu: {0:0,0} VNĐ", tongDoanhThu);

                // Dữ liệu cho biểu đồ
                var chartData = new
                {
                    labels = new[] { "Doanh thu ngày", "Doanh thu tháng", "Doanh thu năm" },
                    datasets = new[]
                    {
                        new
                        {
                            label = "Doanh thu (VNĐ)",
                            data = new[] { doanhThuNgay, doanhThuThang, doanhThuNam },
                            backgroundColor = new[] { "#4caf50", "#2196f3", "#ff9800" },
                            borderColor = new[] { "#388e3c", "#1976d2", "#f57c00" },
                            borderWidth = 1
                        }
                    }
                };

                // Chuyển dữ liệu thành JSON
                chartDataJson = JsonConvert.SerializeObject(chartData);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu có)
                lblTongDoanhThu.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
    }

    private decimal GetDoanhThu(SqlConnection connect, string type)
    {
        // Câu lệnh SQL tương ứng với từng loại (ngày, tháng, năm)
      string query = "";
switch (type)
{
    case "DAY":
        query = "SELECT SUM(ThanhTien) FROM HoaDon WHERE CAST(NgayDat AS DATE) = CAST(GETDATE() AS DATE)";
        break;
    case "MONTH":
        query = @"
            SELECT SUM(ThanhTien) 
            FROM HoaDon 
            WHERE MONTH(NgayDat) = MONTH(GETDATE()) 
              AND YEAR(NgayDat) = YEAR(GETDATE())";
        break;
    case "YEAR":
        query = @"
            SELECT SUM(ThanhTien) 
            FROM HoaDon 
            WHERE YEAR(NgayDat) = YEAR(GETDATE())";
        break;
    default:
        throw new ArgumentException("Invalid type");
}


        // Thực hiện truy vấn SQL và trả về kết quả
        using (SqlCommand cmd = new SqlCommand(query, connect))
        {
            var result = cmd.ExecuteScalar(); // Lấy kết quả trả về
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result); // Trả về giá trị (hoặc 0 nếu không có kết quả)
        }
    }
}
