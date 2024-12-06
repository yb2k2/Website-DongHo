using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class LocLoaiSanPham : System.Web.UI.Page {
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        string queryLocLoaiSanPham = "";
        SqlConnection connect = new SqlConnection(strcn);
        if (Request.QueryString["maLoaiSP"] == null) {
            Response.Redirect("TrangChu.aspx");
        }
        else {
            string maLoaiSP = Request.QueryString["maLoaiSP"];
            queryLocLoaiSanPham = "select * from SanPham where MaLoaiSP = " + maLoaiSP + "and SoLuongTon > 0";
            string queryGridView = "select TenLoaiSP, 'LocLoaiSanPham.aspx?maLoaiSP='+cast(MaLoaiSP as nvarchar(10)) as LoaiSP from LoaiSanPham";
            SqlDataAdapter sqldaGridView = new SqlDataAdapter(queryGridView, connect);
            DataSet dsGridView = new DataSet();
            sqldaGridView.Fill(dsGridView, "LoaiSanPham");
            GridView1.DataSource = dsGridView.Tables["LoaiSanPham"];
            GridView1.DataBind();
        }
        if (!IsPostBack) {
            connect.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(queryLocLoaiSanPham, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "LoaiSanPhamDaLoc");
            DataList1.DataSource = ds.Tables["LoaiSanPhamDaLoc"];
            DataList1.DataBind();
        }

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
    protected void btnTimKiemTheoGia_Click(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        if (txtMinValue.Text == "" && txtMaxValue.Text == "") {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertError", "Swal.fire('Thông báo','Không tìm thấy sản phẩm','error')", true);
        }

        if (txtMinValue.Text != "" && txtMaxValue.Text == "") {
            string queryMinValue = "select * from SanPham where GiaBan >= " + txtMinValue.Text + " and SoLuongTon > 0";
            SqlDataAdapter sqlda1 = new SqlDataAdapter(queryMinValue, connect);
            DataSet ds1 = new DataSet();
            sqlda1.Fill(ds1, "MinValue");
            DataList1.DataSource = ds1.Tables["MinValue"];
            DataList1.DataBind();
        }
        if (txtMinValue.Text == "" && txtMaxValue.Text != "") {
            string queryMaxValue = "select * from SanPham where GiaBan <= " + txtMaxValue.Text + " and SoLuongTon > 0";
            SqlDataAdapter sqlda2 = new SqlDataAdapter(queryMaxValue, connect);
            DataSet ds2 = new DataSet();
            sqlda2.Fill(ds2, "MaxValue");
            DataList1.DataSource = ds2.Tables["MaxValue"];
            DataList1.DataBind();
        }
        if (txtMinValue.Text != "" && txtMaxValue.Text != "") {
            string query = "select * from SanPham where GiaBan >= '" + txtMinValue.Text + "' and GiaBan <= '" + txtMaxValue.Text + "' and SoLuongTon > 0";
            SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "TimKiemTheoSP");
            DataList1.DataSource = ds.Tables["TimKiemTheoSP"];
            DataList1.DataBind();
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (!sdr.HasRows) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertError", "Swal.fire('Thông báo','Không tìm thấy sản phẩm','error')", true);
                connect.Close();
            }
        }
    }
    protected void btnTimTheoTen_Click(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        if (txtTimKiem.Text == "") {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "Swal.fire('Thông báo','Không tìm thấy sản phẩm','error')", true);
        }
        else {
            string query = "select * from SanPham where TenSP like N'%" + txtTimKiem.Text + "%' and SoLuongTon > 0";
            SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "TimKiemTheoSP");
            DataList1.DataSource = ds.Tables["TimKiemTheoSP"];
            DataList1.DataBind();

            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (!sdr.HasRows) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "Swal.fire('Thông báo','Không tìm thấy sản phẩm','error')", true);
            }
            connect.Close();
        }
    }
}