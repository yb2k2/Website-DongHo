using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class TrangChu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Lấy chuỗi kết nối từ web.config
        string strcn = ConfigurationManager.ConnectionStrings["qlBanDongHo"].ConnectionString;

        // Câu lệnh truy vấn cho Nam và Nữ
        string queryClothesMen = "select * from SanPham where GioiTinh = 'Nam' and MaSP >= 1 and MaSP <= 11 and SoLuongTon > 1";
        string queryClothesWomen = "select * from SanPham where GioiTinh = N'Nữ' and MaSP >= 1 and MaSP <= 20 and SoLuongTon > 1";

        // Câu lệnh truy vấn cho đồng hồ cặp đôi và đồng hồ treo tường (giả sử MaLoaiSP là số)
        string queryCoupleWatches = "select * from SanPham where GioiTinh = 'UN'";  // 1 cho đồng hồ cặp đôi
        string queryWallClocks = "SELECT * FROM SanPham WHERE GioiTinh = 'TT'"; // Truy vấn đồng hồ treo tường

        // Sử dụng using để quản lý kết nối
        using (SqlConnection connect = new SqlConnection(strcn))
        {
            try
            {
                connect.Open();

                // Dữ liệu cho Nam
                SqlDataAdapter sqldaForMen = new SqlDataAdapter(queryClothesMen, connect);
                DataSet dsMen = new DataSet();
                sqldaForMen.Fill(dsMen, "ClothesForMen");
                if (dsMen.Tables["ClothesForMen"].Rows.Count > 0)
                {
                    DataList1.DataSource = dsMen.Tables["ClothesForMen"];
                    DataList1.DataBind();
                }

                // Dữ liệu cho Nữ
                SqlDataAdapter sqldaForWomen = new SqlDataAdapter(queryClothesWomen, connect);
                DataSet dsWomen = new DataSet();
                sqldaForWomen.Fill(dsWomen, "ClothesForWomen");
                if (dsWomen.Tables["ClothesForWomen"].Rows.Count > 0)
                {
                    DataList2.DataSource = dsWomen.Tables["ClothesForWomen"];
                    DataList2.DataBind();
                }

                // Dữ liệu cho đồng hồ cặp đôi
                SqlDataAdapter sqldaForCoupleWatches = new SqlDataAdapter(queryCoupleWatches, connect);
                DataSet dsCoupleWatches = new DataSet();
                sqldaForCoupleWatches.Fill(dsCoupleWatches, "CoupleWatches");
                if (dsCoupleWatches.Tables["CoupleWatches"].Rows.Count > 0)
                {
                    DataList3.DataSource = dsCoupleWatches.Tables["CoupleWatches"];
                    DataList3.DataBind();
                }

                // Dữ liệu cho đồng hồ treo tường
                SqlDataAdapter sqldaForWallClocks = new SqlDataAdapter(queryWallClocks, connect);
                DataSet dsWallClocks = new DataSet();
                sqldaForWallClocks.Fill(dsWallClocks, "WallClocks");
                if (dsWallClocks.Tables["WallClocks"].Rows.Count > 0)
                {
                    DataList4.DataSource = dsWallClocks.Tables["WallClocks"];
                    DataList4.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
