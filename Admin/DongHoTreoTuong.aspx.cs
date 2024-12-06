using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class Admin_DongHoTreoTuong : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;

    // Hàm Page_Load để hiển thị đồng hồ treo tường
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        if (!IsPostBack)
        {
            // Truy vấn để lấy các đồng hồ treo tường
            string queryCommand = "SELECT * FROM SanPham WHERE GioiTinh = 'TT'";
            SqlDataAdapter sqldaCapDoi = new SqlDataAdapter(queryCommand, connect);
            DataSet ds = new DataSet();
            sqldaCapDoi.Fill(ds, "WallClocks");

            // Bind dữ liệu vào DataList
            DataList1.DataSource = ds.Tables["WallClocks"];
            DataList1.DataBind();
        }
    }

    // Xử lý khi xóa sản phẩm
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        int maSP = int.Parse((e.CommandArgument.ToString()));

        // Xóa sản phẩm khỏi bảng HoaDon
        string queryDeleteMaSPHD = "DELETE FROM HoaDon WHERE MaSP = " + maSP;
        SqlCommand cmdDeleteMaSPHD = new SqlCommand(queryDeleteMaSPHD, connect);
        int resultDelete2 = cmdDeleteMaSPHD.ExecuteNonQuery();

        // Xóa sản phẩm khỏi bảng SanPham
        string queryDelete = "DELETE FROM SanPham WHERE MaSP = " + maSP;
        SqlCommand cmd = new SqlCommand(queryDelete, connect);
        int resultDelete1 = cmd.ExecuteNonQuery();

        // Kiểm tra kết quả xóa
        if (resultDelete2 == 1 || resultDelete1 == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertSuccess", "Swal.fire('Thông báo', 'Xoá sản phẩm thành công', 'success')", true);

            // Load lại danh sách sản phẩm sau khi xóa
            string query = "SELECT * FROM SanPham WHERE GioiTinh = 'TT'";
            SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "WallClocks");
            DataList1.DataSource = ds.Tables["WallClocks"];
            DataList1.DataBind();
        }
    }

    // Xử lý tìm kiếm theo tên sản phẩm
    protected void btnTimTheoTen_Click(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        if (txtTimKiem.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "Swal.fire('Thông báo', 'Không tìm thấy sản phẩm', 'error')", true);
        }
        else
        {
            // Truy vấn tìm kiếm sản phẩm theo tên
            string query = "SELECT * FROM SanPham WHERE TenSP LIKE N'%" + txtTimKiem.Text + "%' AND GioiTinh = 'TT' AND SoLuongTon > 0";
            SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "TimKiemTheoSP");

            // Bind kết quả tìm kiếm vào DataList
            DataList1.DataSource = ds.Tables["TimKiemTheoSP"];
            DataList1.DataBind();

            // Kiểm tra nếu không tìm thấy kết quả
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (!sdr.HasRows)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "Swal.fire('Thông báo', 'Không tìm thấy sản phẩm', 'error')", true);
            }
            connect.Close();
        }
    }

    // Xử lý tìm kiếm theo giá
    protected void btnTimKiemTheoGia_Click(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        // Lấy giá trị từ các ô nhập giá
        string minPrice = txtMinValue.Text;
        string maxPrice = txtMaxValue.Text;

        if (string.IsNullOrEmpty(minPrice) || string.IsNullOrEmpty(maxPrice))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "Swal.fire('Thông báo', 'Vui lòng nhập giá hợp lệ', 'error')", true);
            return;
        }

        // Truy vấn tìm kiếm theo giá
        string query = "SELECT * FROM SanPham WHERE GiaBan BETWEEN @MinPrice AND @MaxPrice AND GioiTinh = 'TT' AND SoLuongTon > 0";
        SqlCommand cmd = new SqlCommand(query, connect);
        cmd.Parameters.AddWithValue("@MinPrice", minPrice);
        cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);

        SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sqlda.Fill(ds, "TimKiemTheoGia");

        // Bind kết quả tìm kiếm vào DataList
        DataList1.DataSource = ds.Tables["TimKiemTheoGia"];
        DataList1.DataBind();

        // Kiểm tra nếu không có kết quả
        SqlDataReader sdr = cmd.ExecuteReader();
        if (!sdr.HasRows)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "Swal.fire('Thông báo', 'Không tìm thấy sản phẩm', 'error')", true);
        }

        connect.Close();
    }
}
