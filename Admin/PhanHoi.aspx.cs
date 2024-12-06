using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_PhanHoi : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        string query = "select MaKH, TenKhachHang as N'Tên khách hàng', TieuDe as N'Tiêu đề', NoiDung as N'Nội dung phản hồi', thoiGianPhanHoi as N'Thời gian phản hồi' from LienHe";
        SqlCommand cmd = new SqlCommand(query, connect);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (!sdr.HasRows) {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Swal.fire('Thông báo','Chưa có sự phản hồi nào từ khách hàng 😊','success').then((value) => { window.location = 'Admin.aspx';});", true);
        }
        else {
            loadData();
        }
    }

    public void loadData() {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();
        DataTable data = new DataTable();
        string query = "select MaKH, TenKhachHang as N'Tên KH', TieuDe as N'Tiêu đề', NoiDung as N'Nội dung phản hồi', thoiGianPhanHoi as N'Thời gian phản hồi' from LienHe";
        SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
        sqlda.Fill(data);
        GridView1.DataSource = data;
        GridView1.DataBind();
    }
}