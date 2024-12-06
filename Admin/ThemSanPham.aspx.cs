using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_ThemSanPham : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        SqlDataAdapter sqlda = new SqlDataAdapter("select TenLoaiSP from LoaiSanPham", connect);
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (!IsPostBack) {
            for (int i = 0; i < dt.Rows.Count; i++) {
                DataRow dr = dt.Rows[i];
                DropDownList1.Items.Add(i + 1 + "." + " " + dr["TenLoaiSP"].ToString());
            }
        }
    }
    protected void btnThemSanPham_Click(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        string maLoaiSP = DropDownList1.SelectedValue.ToString().Substring(0,1);

        string queryInsert = "insert into SanPham values(N'" + txtTenSanPham.Text + "',N'" + txtMoTa.Text + "',N'" + DropDownList2.SelectedValue + "','" + txtGiaBan.Text + "','" + txtGiaNhap.Text + "','"+FileUpload1.FileName+"','" + maLoaiSP + "','" + txtSoLuongTon.Text + "')";
        SqlCommand cmd = new SqlCommand(queryInsert, connect);
        int result = cmd.ExecuteNonQuery();
        if (result == 1) {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "insertSuccess", "Swal.fire('Thông báo','Thêm sản phẩm thành công','success')", true);
        }
    }
}