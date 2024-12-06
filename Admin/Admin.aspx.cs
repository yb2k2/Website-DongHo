using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Admin : System.Web.UI.Page
{
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        string query = "";

        if (Request.QueryString["masp"] == null) {
            query = "select * from SanPham";
        }
        else {
            string masp = Request.QueryString["masp"];
            query = "select * from SanPham where MaSP = " + masp + "and SoLuongTon > 1";
        }
        if (!IsPostBack) {
            SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "DanhSachCacSanPham");
            DataList1.DataSource = ds.Tables["DanhSachCacSanPham"];
            DataList1.DataBind();
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        string query = "select * from SanPham where SoLuongTon > 1";
        
        int maSP = int.Parse((e.CommandArgument.ToString()));

        string queryDeleteMaSPHD = "delete from HoaDon where MaSP = " + maSP;
        SqlCommand cmdDeleteMaSPHD = new SqlCommand(queryDeleteMaSPHD, connect);
        int resultDelete2 = cmdDeleteMaSPHD.ExecuteNonQuery();

        string queryDelete = "delete from SanPham where MaSP = " + maSP;
        SqlCommand cmd = new SqlCommand(queryDelete, connect);
        int resultDelete1 = cmd.ExecuteNonQuery();
        
        if (resultDelete2 == 1 || resultDelete1 == 1) {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertSuccess", "Swal.fire('Thông báo','Xoá sản phẩm thành công','success')", true);
            SqlDataAdapter sqlda = new SqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "DanhSachCacSanPham");
            DataList1.DataSource = ds.Tables["DanhSachCacSanPham"];
            DataList1.DataBind();
        }
    }
    protected void btnTimKiemTheoGia_Click(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();

        if (txtMinValue.Text == "" && txtMaxValue.Text == "") {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertError", "Swal.fire('Thông báo','Không tìm thấy sản phẩm','error')", true);
        }

        if (txtMinValue.Text != "" && txtMaxValue.Text == "") {
            string queryMinValue = "select * from SanPham where GiaBan >= " + txtMinValue.Text + " and SoLuongTon > 1";
            SqlDataAdapter sqlda1 = new SqlDataAdapter(queryMinValue, connect);
            DataSet ds1 = new DataSet();
            sqlda1.Fill(ds1, "MinValue");
            DataList1.DataSource = ds1.Tables["MinValue"];
            DataList1.DataBind();
        }
        if (txtMinValue.Text == "" && txtMaxValue.Text != "") {
            string queryMaxValue = "select * from SanPham where GiaBan <= " + txtMaxValue.Text + " and SoLuongTon > 1";
            SqlDataAdapter sqlda2 = new SqlDataAdapter(queryMaxValue, connect);
            DataSet ds2 = new DataSet();
            sqlda2.Fill(ds2, "MaxValue");
            DataList1.DataSource = ds2.Tables["MaxValue"];
            DataList1.DataBind();
        }
        if (txtMinValue.Text != "" && txtMaxValue.Text != "") {
            string query = "select * from SanPham where GiaBan >= '" + txtMinValue.Text + "' and GiaBan <= '" + txtMaxValue.Text + "' and SoLuongTon > 1";
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