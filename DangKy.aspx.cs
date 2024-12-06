using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DangKy : System.Web.UI.Page {
    string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e) {
        SqlConnection connect = new SqlConnection(strcn);
        string queryGridView = "select TenLoaiSP, 'LocLoaiSanPham.aspx?maLoaiSP='+cast(MaLoaiSP as nvarchar(10)) as LoaiSP from LoaiSanPham";
        SqlDataAdapter sqldaGridView = new SqlDataAdapter(queryGridView, connect);
        DataSet dsGridView = new DataSet();
        sqldaGridView.Fill(dsGridView, "LoaiSanPham");
        GridView1.DataSource = dsGridView.Tables["LoaiSanPham"];
        GridView1.DataBind();

        MultiView1.ActiveViewIndex = 0;

    }

    public int CheckEmailTrung(string email) {
        SqlConnection connect = new SqlConnection(strcn);
        connect.Open();
        string queryFindEmail = "select count(*) from KhachHang where Email = '"+email+"'";
        SqlCommand cmd = new SqlCommand(queryFindEmail, connect);
        int result = (int)cmd.ExecuteScalar();
        connect.Close();
        return result;
    }

    public int checkPolicy() {
        if (!CheckBoxPolicy.Checked) {
            return 0;
        }
        return 1;
    }

    protected void btnNextStep3_Click(object sender, EventArgs e) {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void btnNextStep2_Click(object sender, EventArgs e) {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnPreviousStep1_Click(object sender, EventArgs e) {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnPreviousStep2_Click(object sender, EventArgs e) {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btnDangKy_Click(object sender, EventArgs e) {
        if (CheckEmailTrung(txtEmail.Text) == 1) {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alertErrorMessage", "errorEmailValidation()", true);
            MultiView1.ActiveViewIndex = 1;
            txtEmail.Focus();
        }
        else if (checkPolicy() == 0) {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alertErrorMessage", "doNotcheckPolicy()", true);
            MultiView1.ActiveViewIndex = 2;
        }
        else {
            SqlConnection connect = new SqlConnection(strcn);
            connect.Open();

            string query = "insert into KhachHang values('" + txtTaiKhoan.Text + "','" + txtMK.Text + "',N'" + txtHoVaTen.Text + "',N'" + txtDiaChi.Text + "','" + txtEmail.Text + "','" + txtSoDienThoai.Text + "')";
            SqlCommand cmd = new SqlCommand(query,connect);
            int result = cmd.ExecuteNonQuery();
            if (result == 1) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " Swal.fire('Thành công', 'Chức mừng bạn đã đăng kí thành công', 'success').then((value) => { window.location = 'DangNhap.aspx'; });", true);
            }
        }
        
    }
}