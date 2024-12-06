    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DongHoNam.aspx.cs" Inherits="DongHoNam" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container_custom">
            <div class="text-right mt-3">
                <asp:Button ID="btnXemGiohang" runat="server" Text="Giỏ Hàng" CssClass="btn btn-danger" OnClick="btnXemGiohang_Click" />
            </div>
            <div class="my-3 w-100">
                <div class="row">
    <div class="col-5">
        <div class="row">
            <div class="col-3 align-items-center d-flex px-0 text-center">
                <label class="timKiem mb-0" style="margin-left: 30px;">Tìm kiếm</label>
            </div>
            <div class="col-9 d-flex">
                <asp:TextBox ID="txtTimKiem" runat="server" AutoCompleteType="Disabled" CssClass="mr-3 form-control px-3 py-2"></asp:TextBox>
                <asp:Button ID="btnTimTheoTen" runat="server" Text="Tìm" CssClass="btn btn-info" OnClick="btnTimTheoTen_Click" />
            </div>
        </div>
    </div>
    <div class="col-7">
        <div class="row">
            <div class="col-1 align-items-center d-flex px-0">
                <span class="mb-0" style="margin-left: 20px;">Từ </span>
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtMinValue" runat="server" placeholder="Giá thấp nhất" AutoCompleteType="Disabled" CssClass="form-control px-1 py-2"></asp:TextBox>
            </div>
            <div class="col-1 align-items-center d-flex px-0">
                <span class="mb-0" style="margin-left: 20px;">đến </span>
            </div>
            <div class="col-6 d-flex">
                <div>
                    <asp:TextBox ID="txtMaxValue" runat="server" placeholder="Giá cao nhất" AutoCompleteType="Disabled" CssClass="form-control px-1 py-2"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnTimKiemTheoGia" runat="server" Text="Tìm" CssClass="btn btn-primary mx-3" OnClick="btnTimKiemTheoGia_Click" />
                </div>
            </div>
        </div>
    </div>
                    </div>
</div>

            <div class="row my-4">
    <div class="col-md-4">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="animated flash">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="LoaiSP" DataTextField="TenLoaiSP" HeaderText="Danh mục sản phẩm">
                    <HeaderStyle CssClass="headerGridViewStyle" />
                </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-8">
        <h2 class="text-center title-product animated fadeInDownBig">Đồng hồ nam</h2>
   <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
    <ItemTemplate>
        <div class="item text-center" style="margin-bottom: 30px; margin-right: 15px;">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "ChiTiet.aspx?masp="+Eval("MaSP") %>'>
                <!-- Fixed width and height for the image -->
                <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" ImageUrl='<%# "Images/"+Eval("Anh") %>' CssClass="animated rollIn" />
                <div class="styleText">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSP") %>'></asp:Label>
                </div>
                <span>Giá: </span>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaBan") %>'></asp:Label>
                <span> VNĐ</span><br />
            </asp:HyperLink>
            <!-- Align the "Chọn Mua" button correctly -->
            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("MaSP") %>' ImageUrl="~/Images/ChonMua.jpg" CssClass="mt-2" />
        </div>
    </ItemTemplate>
</asp:DataList>

    </div>
</div>
</div>
    </asp:Content>
