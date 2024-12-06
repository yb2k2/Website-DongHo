using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ChiTiet : System.Web.UI.Page {
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        string query = "";
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();
        if (Request.QueryString["masp"] == null) {
            Response.Redirect("TrangChu.aspx");
        }
        else {
            string queryGridView = "select TenLoaiSP, 'LocLoaiSanPham.aspx?maLoaiSP='+cast(MaLoaiSP as nvarchar(10)) as LoaiSP from LoaiSanPham";
            SqlDataAdapter sqldaGridView = new SqlDataAdapter(queryGridView, connect);
            DataSet dsGridView = new DataSet();
            sqldaGridView.Fill(dsGridView, "LoaiSanPham");
            GridView1.DataSource = dsGridView.Tables["LoaiSanPham"];
            GridView1.DataBind();

            string maSP = Request.QueryString["masp"];
            query = "select * from SanPham where MaSP = " + maSP;

        }
        if (!IsPostBack) {
            SqlDataAdapter sqldaChiTietSanPham = new SqlDataAdapter(query, connect);
            DataSet dsChiTietSP = new DataSet();
            sqldaChiTietSanPham.Fill(dsChiTietSP, "ChiTietSanPham");
            DataList1.DataSource = dsChiTietSP.Tables["ChiTietSanPham"];
            DataList1.DataBind();
        }

    }
    public void tongSoLuongSPTrongGio() {
        DataTable updateDt = (DataTable)Session["GioHang"];
        int tongSoLuongSanPham = 0;
        for (int i = 0; i < updateDt.Rows.Count; i++) {
            tongSoLuongSanPham += int.Parse(updateDt.Rows[i]["SoLuong"].ToString());
        }
        btnXemGiohang.Text = "Giỏ Hàng ('" + tongSoLuongSanPham.ToString() + "')";
    }
    int findIndexSP(DataTable dt, int masp) {
        for (int i = 0; i < dt.Rows.Count; i++) {
            if (dt.Rows[i]["MaSP"].ToString() == masp.ToString()) {
                return i;
            }
        }
        return -1;
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
        int masp = int.Parse((e.CommandArgument.ToString()));
        string tenSP = (((Label)e.Item.FindControl("Label1")).Text);
        int gia = int.Parse(((Label)e.Item.FindControl("Label2")).Text);

        // Kiểm tra đã thêm sản phẩm nào vào giỏ hàng chưa?. Nếu chưa thì khởi tạo giỏ hàng
        if (Session["GioHang"] == null) {

            //Khởi tạo DataTable
            DataTable tbGioHang = new DataTable();
            tbGioHang.Columns.Add("MaSP", typeof(int));
            tbGioHang.Columns.Add("TenSP", typeof(string));
            tbGioHang.Columns.Add("GiaBan", typeof(int));
            tbGioHang.Columns.Add("SoLuong", typeof(int));
            tbGioHang.Columns.Add("ThanhTien", typeof(int), "SoLuong * GiaBan");

            // Sau khi khởi tạo các column rồi. Tiến hành thêm vào 1 dòng (row)
            tbGioHang.Rows.Add(masp, tenSP, gia, 1); // Thông tin lấy từ sản phẩm được chọn

            // Lưu vào session
            Session["GioHang"] = tbGioHang;

        }
        else { // Đã có sản phẩm trong giỏ hàng rồi 
            DataTable dtGioHang = (DataTable)Session["GioHang"];
            // Kiểm tra sản phẩm có trong giỏ hàng chưa. Nếu chưa có thì thêm mới vào, ngược lại thì tăng số lượng sản phẩm đó lên
            int index = findIndexSP(dtGioHang, masp);
            if (index == -1) {
                dtGioHang.Rows.Add(masp, tenSP, gia, 1);
            }
            else {
                dtGioHang.Rows[index]["SoLuong"] = (int)dtGioHang.Rows[index]["SoLuong"] + 1;
            }
        }
        DataTable updateDt = (DataTable)Session["GioHang"];
        int tongSoLuongSanPham = 0;
        for (int i = 0; i < updateDt.Rows.Count; i++) {
            tongSoLuongSanPham += int.Parse(updateDt.Rows[i]["SoLuong"].ToString());
        }
        btnXemGiohang.Text = "Giỏ Hàng ('" + tongSoLuongSanPham.ToString() + "')";
    }
    protected void btnXemGiohang_Click(object sender, EventArgs e) {
        if (Session["GioHang"] == null) {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "updateSuccess", "Swal.fire('Thông báo','Bạn chưa thêm sản phẩm nào!','info')", true);
        }
        else {
            Response.Redirect("XemGioHang.aspx");
        }
    }
}