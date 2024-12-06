using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class XemGioHang : System.Web.UI.Page {
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        string queryGridView = "select TenLoaiSP, 'LocLoaiSanPham.aspx?maLoaiSP='+cast(MaLoaiSP as nvarchar(10)) as LoaiSP from LoaiSanPham";
        SqlDataAdapter sqldaGridView = new SqlDataAdapter(queryGridView, connect);
        DataSet dsGridView = new DataSet();
        sqldaGridView.Fill(dsGridView, "LoaiSanPham");
        GridView1.DataSource = dsGridView.Tables["LoaiSanPham"];
        GridView1.DataBind();

        if (Session["GioHang"] != null) {
            loadData();
        }
        else {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Swal.fire('Thông báo','Bạn chưa thêm sản phẩm nào!','error').then((value) => { window.location = 'DongHoNam.aspx';});", true);
        }
    }

    public void loadData() {
        double tongThanhTien = 0;
        DataTable dtGioHang = (DataTable)Session["GioHang"];
        for (int i = 0; i < dtGioHang.Rows.Count; i++) {
            tongThanhTien += double.Parse(dtGioHang.Rows[i]["ThanhTien"].ToString());
        }
        GridView2.DataSource = dtGioHang;
        GridView2.DataBind();
        txtTongThanhTien.Text = "Tổng thành tiền: " + String.Format("{0:0,0}", tongThanhTien) + " VNĐ";
    }

    public DataTable getData() {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();
        DataTable dtGioHang = (DataTable)Session["GioHang"];
        DataTable data = new DataTable();
        foreach (DataRow dr in dtGioHang.Rows) {
            string maSPDat = dr["MaSP"].ToString();
            string tenSP = dr["TenSP"].ToString();
            string soLuongDat = dr["SoLuong"].ToString();
            string queryHangTonKho = "select TenSP, SoLuongTon from SanPham where SoLuongTon < " + soLuongDat + "and MaSP = '" + maSPDat + "'";
            SqlDataAdapter checkHangTonKho = new SqlDataAdapter(queryHangTonKho, connect);
            checkHangTonKho.Fill(data);
        }
        return data;
    }

    public void giamSoLuongTon() {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();
        DataTable dtGioHang = (DataTable)Session["GioHang"];
        DataTable data = new DataTable();
        data.Columns.Add("SoLuongTon", typeof(int));
        foreach (DataRow dr in dtGioHang.Rows) {
            string maSPDat = dr["MaSP"].ToString();
            int soLuongDat = int.Parse(dr["SoLuong"].ToString());
            string querySoLuongTon = "select SoLuongTon from SanPham where MaSP = " + maSPDat;
            SqlDataAdapter sqlda = new SqlDataAdapter(querySoLuongTon, connect);
            sqlda.Fill(data);
            int soLuongTon = int.Parse(data.Rows[0]["SoLuongTon"].ToString());
            int sltUpdate = soLuongTon - soLuongDat;
            string queryUpdateSoLuongTon = "Update SanPham set SoLuongTon = '" + sltUpdate + "' where MaSP = '" + maSPDat + "'";
            SqlCommand cmdUpdate = new SqlCommand(queryUpdateSoLuongTon, connect);
            cmdUpdate.ExecuteNonQuery();
        }
    }

    protected void btnDatHang_Click(object sender, EventArgs e) {

        if (Session["User"] == null) {
            Response.Redirect("DangNhap.aspx");
        }
        else {
            SqlConnection connect = new SqlConnection(strcn);
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            DataTable dt = (DataTable)getData();
            DataTable dtGioHang = (DataTable)Session["GioHang"];
            for (int i = 0; i < dt.Rows.Count; i++) {
                DataRow dr = dt.Rows[i];
                if (dt.Rows.Count > 0) {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Swal.fire({title: 'Thông báo',icon: 'error',html: 'Số lượng sản phẩm ' + '<b>" + dr["TenSP"].ToString() + "</b>' + ' chỉ còn ' + '<b>" + dr["SoLuongTon"].ToString() + "</b>' + ' sản phẩm' + '<br />' + 'Xin quý khách thông cảm ☹️'})", true);
                    return;
                }
                else {
                    continue;
                }
            }
            foreach (DataRow dr in dtGioHang.Rows) {
                string ngayDat = DateTime.Now.ToString();
                string tinhTrang = "Chưa thanh toán";
                DataTable dataKhachHang = (DataTable)Session["User"];
                string tenKhachHang = dataKhachHang.Rows[0]["TenKH"].ToString().Substring(0, 1);
                string maKH = dataKhachHang.Rows[0]["MaKH"].ToString();
                string maSP = dr["MaSP"].ToString();
                string tenSP = dr["TenSP"].ToString();
                string soLuong = dr["SoLuong"].ToString();
                string thanhTien = dr["ThanhTien"].ToString();
                cmd.CommandText = "insert into HoaDon values('" + ngayDat + "','" + tinhTrang + "','" + maSP + "','" + tenSP + "','" + soLuong + "','" + thanhTien + "','" + maKH + "')";
                int resultInsertHoaDon = cmd.ExecuteNonQuery();
                if (resultInsertHoaDon == 1) {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertSuccess", "Swal.fire('Thành công!','Cảm ơn bạn đã đặt hàng','success').then((value) => { window.location = 'TrangChu.aspx'; });", true);
                }
            }
            giamSoLuongTon();
        }
        Session["GioHang"] = null;
    }
    protected void btnThanhToan_Click(object sender, EventArgs e)
    {
        Response.Redirect("ThanhToan.aspx");
    }

    protected void btnUpdateSoLuong_Click(object sender, EventArgs e) {
        DataTable dt = (DataTable)Session["GioHang"];
        for (int i = 0; i < dt.Rows.Count; i++) {
            DataRow dr = dt.Rows[i];
            if (dr["MaSP"].ToString() == txtMaSPUpdateSoLuong.Text) {
                if (txtUpdateSoLuong.Text != "") {
                    int soLuong = int.Parse(txtUpdateSoLuong.Text);
                    if (soLuong == 0) {
                        dr.Delete();
                        if (dt.Rows.Count == 0) {
                            Session["GioHang"] = null;
                            Response.Redirect("DongHoNam.aspx");
                        }
                    }
                    else {
                        txtMaSPUpdateSoLuong.Text = "";
                        txtUpdateSoLuong.Text = "";
                        dr["SoLuong"] = soLuong;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "updateSuccess", "Swal.fire('Thông báo','Cập nhật số lượng sản phẩm thành công','success')", true);
                        loadData();
                    }
                }
                else {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertErrorMessage", "Swal.fire('Thông báo','Vui lòng nhập số lượng cần cập nhật','error')", true);
                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertErrorMessage", "Swal.fire('Thông báo','Không có mã sản phẩm này trong giỏ hàng','error')", true);
            }
        }
        DataTable newUpdate = (DataTable)Session["GioHang"];
        GridView2.DataSource = newUpdate;
        GridView2.DataBind();
    }
    protected void btnHuySP_Click(object sender, EventArgs e) {
        Session["GioHang"] = null;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Swal.fire('Thông báo','Đã huỷ toàn bộ sản phẩm trong giỏ','success').then((value) => { window.location = 'DongHoNam.aspx';});", true);
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e) {
        int index = e.RowIndex;

        DataTable dt = (DataTable)Session["GioHang"];

        for (int i = 0; i < dt.Rows.Count; i++) {
            if (dt.Rows[i] == dt.Rows[index]) {
                dt.Rows[i].Delete();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "deleteSuccess", "Swal.fire('Thông báo','Đã huỷ 1 sản phẩm','success')", true);
            }
            if (dt.Rows.Count == 0) {
                Session["GioHang"] = null;
                Response.Redirect("DongHoNam.aspx");
            }
        }
        DataTable dtUpdate = (DataTable)Session["GioHang"];
        GridView2.DataSource = dtUpdate;
        GridView2.DataBind();
    }
}