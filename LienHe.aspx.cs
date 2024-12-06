using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class LienHe : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        string queryGridView = "select TenLoaiSP, 'LocLoaiSanPham.aspx?maLoaiSP='+cast(MaLoaiSP as nvarchar(10)) as LoaiSP from LoaiSanPham";
        SqlDataAdapter sqldaGridView = new SqlDataAdapter(queryGridView, connect);
        DataSet dsGridView = new DataSet();
        sqldaGridView.Fill(dsGridView, "LoaiSanPham");
        GridView1.DataSource = dsGridView.Tables["LoaiSanPham"];
        GridView1.DataBind();
    }
    protected void txtSubmit_Click(object sender, EventArgs e) {
        if (Session["User"] == null) {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Swal.fire('Thông báo','Vui lòng đăng nhập trước khi liên hệ','error').then((value) => { window.location = 'DangNhap.aspx';});", true);
        }
        else {
            DataTable dataKhachHang = (DataTable)Session["User"];
            SqlConnection connect = new SqlConnection(strcn);
            connect.Open();
            string maKH = dataKhachHang.Rows[0]["MaKH"].ToString();
            string tenKH = dataKhachHang.Rows[0]["TenKH"].ToString();
            string time = DateTime.Now.ToString();
            string submit = "insert into LienHe values('" + maKH + "',N'" + tenKH + "',N'" + txtTieuDe.Text + "',N'" + txtNoiDung.Text + "', '" + time + "')";
            SqlCommand cmd = new SqlCommand(submit, connect);
            int result = cmd.ExecuteNonQuery();
            if (result == 1) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "submitSuccess", "Swal.fire('Thông báo','Cảm ơn bạn đã phản hồi','success').then((value) => { window.location = 'TrangChu.aspx';});", true);
            }
        }
    }
}