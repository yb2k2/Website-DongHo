using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage {
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        if (Session["User"] != null) {
            DataTable user = (DataTable)Session["User"];
            txtTenKhachHang.Text = "Xin chào: " + user.Rows[0]["TenKH"].ToString();
            Label1.Text = "Xin chào: " + user.Rows[0]["TenKH"].ToString();
        }
        
    }
    protected void btnDangXuat_Click1(object sender, EventArgs e) {
        // Đăng xuất tài khoản
        Session["User"] = null;
        Response.Redirect("TrangChu.aspx");
    }
}
