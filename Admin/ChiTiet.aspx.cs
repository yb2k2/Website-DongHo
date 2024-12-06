using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin_ChiTiet : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        string query = "";
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();
        if (Request.QueryString["masp"] == null) {
            Response.Redirect("TrangChu.aspx");
        }
        else {
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
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
        int maSPUpdate = int.Parse((e.CommandArgument.ToString()));
        string tenSP = ((Label)e.Item.FindControl("Label1")).Text;
        string moTa = ((Label)e.Item.FindControl("Label3")).Text;
        int giaBan = int.Parse(((Label)e.Item.FindControl("Label2")).Text);
        int giaNhap = int.Parse(((Label)e.Item.FindControl("Label5")).Text);
        string gioiTinh = ((Label)e.Item.FindControl("Label4")).Text;
        int soLuongTon = int.Parse(((Label)e.Item.FindControl("Label6")).Text);

        Session["tenSP"] = tenSP;
        Session["moTa"] = moTa;
        Session["giaBan"] = giaBan;
        Session["MaSPUpdate"] = maSPUpdate;
        Session["giaNhap"] = giaNhap;
        Session["gioiTinh"] = gioiTinh;
        Session["soLuongTon"] = soLuongTon;
        Response.Redirect("SuaSanPham.aspx");
    }
}