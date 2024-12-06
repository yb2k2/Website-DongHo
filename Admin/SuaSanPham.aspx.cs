using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_SuaSanPham : System.Web.UI.Page
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
            txtTenSanPham.Text = Session["tenSP"].ToString();
            txtMoTa.Text = Session["moTa"].ToString();
            DropDownList2.Items.FindByValue(Session["gioiTinh"].ToString()).Selected = true;
            txtGiaBan.Text = Session["giaBan"].ToString();
            txtGiaNhap.Text = Session["giaNhap"].ToString();
            txtSoLuongTon.Text = Session["soLuongTon"].ToString();
        }
    }
    protected void btnSuaSanPham_Click(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        string maspUpdate = Session["MaSPUpdate"].ToString();
        string maLoaiSP = DropDownList1.SelectedValue.ToString().Substring(0,1);

        string queryUpdate = "Update SanPham set TenSP = N'" + txtTenSanPham.Text + "',MoTa = N'" + txtMoTa.Text + "',GioiTinh = N'" + DropDownList2.SelectedValue + "',GiaBan = '" + txtGiaBan.Text + "',GiaNhap = '" + txtGiaNhap.Text + "',Anh = N'" + FileUpload1.FileName + "',MaLoaiSP = '" + maLoaiSP + "',SoLuongTon = '" + txtSoLuongTon.Text + "' where MaSP = '" + maspUpdate + "'";
        SqlCommand cmd = new SqlCommand(queryUpdate, connect);
        int result = cmd.ExecuteNonQuery();
        if (result == 1) {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "UpdateSuccess", "Swal.fire('Thông báo','Cập nhật sản phẩm thành công','success').then((value) => { window.location = 'Admin.aspx';});", true);
        }

    }
}