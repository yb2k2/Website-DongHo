using System;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class ThanhToan : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GioHang"] == null)
        {
            Response.Redirect("XemGioHang.aspx");
        }
    }

    protected void btnThanhToan_Click(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("DangNhap.aspx");
        }
        else
        {
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string phuongThucThanhToan = rbtnMomo.Checked ? "Momo" : "VNPay";

            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Swal.fire('Thông báo','Vui lòng nhập đầy đủ thông tin.','error')", true);
                return;
            }

            // Thực hiện xử lý thanh toán
            if (PhuongThucThanhToan(phuongThucThanhToan))
            {
                // Lưu thông tin vào hóa đơn sau khi thanh toán thành công
                SqlConnection connect = new SqlConnection(strcn);
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                DataTable dtGioHang = (DataTable)Session["GioHang"];
                DataTable dataKhachHang = (DataTable)Session["User"];
                string maKH = dataKhachHang.Rows[0]["MaKH"].ToString();

                foreach (DataRow dr in dtGioHang.Rows)
                {
                    string ngayDat = DateTime.Now.ToString();
                    string tinhTrang = "Đã thanh toán";
                    string maSP = dr["MaSP"].ToString();
                    string tenSP = dr["TenSP"].ToString();
                    string soLuong = dr["SoLuong"].ToString();
                    string thanhTien = dr["ThanhTien"].ToString();
                    cmd.CommandText = "insert into HoaDon values('" + ngayDat + "', '" + tinhTrang + "', '" + maSP + "', '" + tenSP + "', '" + soLuong + "', '" + thanhTien + "', '" + maKH + "')";
                    cmd.ExecuteNonQuery();
                }

                // Cập nhật trạng thái thanh toán và thông báo cho người dùng
                Session["GioHang"] = null; // Xóa giỏ hàng sau khi thanh toán
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertSuccess", "Swal.fire('Thành công!','Thanh toán thành công. Cảm ơn bạn!','success').then((value) => { window.location = 'TrangChu.aspx'; });", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertError", "Swal.fire('Thông báo','Thanh toán không thành công. Vui lòng thử lại.','error')", true);
            }
        }
    }

    // Hàm giả lập thanh toán
    private bool PhuongThucThanhToan(string phuongThuc)
    {
        // Giả lập thanh toán thành công với mỗi phương thức
        if (phuongThuc == "Momo" || phuongThuc == "VNPay")
        {
            return true; // Giả sử giao dịch thành công
        }
        return false;
    }
}
