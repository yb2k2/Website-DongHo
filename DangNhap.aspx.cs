using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DangNhap : System.Web.UI.Page {
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        string queryGridView = "select TenLoaiSP, 'LocLoaiSanPham.aspx?maLoaiSP='+cast(MaLoaiSP as nvarchar(10)) as LoaiSP from LoaiSanPham";
        SqlDataAdapter sqldaGridView = new SqlDataAdapter(queryGridView, connect);
        DataSet dsGridView = new DataSet();
        sqldaGridView.Fill(dsGridView, "LoaiSanPham");
        GridView1.DataSource = dsGridView.Tables["LoaiSanPham"];
        GridView1.DataBind();
    }
    protected void btnDangNhap_Click(object sender, EventArgs e) {


        /// Tuỳ chỉnh tài khoản admin tuỳ ý

        if (txtTaiKhoan.Text == "Duy" && txtMatKhau.Text == "Duy") {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertSuccess", "Swal.fire('Thông báo','Đăng nhập thành công','success').then((value) => { window.location = 'Admin/Admin.aspx';});", true);
        }
        else {
            SqlConnection connect = new SqlConnection(strcn);
            connect.Open();
            string checkUserCommand = "select * from KhachHang where TaiKhoan = '" + txtTaiKhoan.Text + "' and MatKhau = '" + txtMatKhau.Text + "'";
            SqlDataAdapter sqlda = new SqlDataAdapter(checkUserCommand, connect);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            if (dt.Rows.Count == 1) {
                Session["User"] = dt;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "loginSuccess", "Swal.fire('Đăng nhập thành công!','Chào mừng bạn đã comeback','success').then((value) => { window.location = 'DongHoNam.aspx'; });", true);
            }
            else {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "loginFail", "errorLogin();", true);
            }
        }

    }
}