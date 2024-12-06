<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/LayoutPageAdmin.master" AutoEventWireup="true" CodeFile="DongHoTreoTuong.aspx.cs" Inherits="Admin_DongHoTreoTuong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h2 class="text-center title" data-aos="fade-left">Đồng hồ cặp đôi</h2>
        <div class="my-3 w-100">
            <div class="row">
                <div class="col-md-5">
                    <div class="row">
                        <div class="col-3 align-items-center d-flex px-0">
                            <label class="timKiem mb-0" style="margin-left: 30px;">Tìm kiếm</label>
                        </div>
                        <div class="col-8 d-flex">
                            <asp:TextBox ID="txtTimKiem" runat="server" AutoCompleteType="Disabled" CssClass="mr-3 form-control px-3 py-2"></asp:TextBox>
                            <asp:Button ID="btnTimTheoTen" runat="server" Text="Tìm" CssClass="btn btn-info" OnClick="btnTimTheoTen_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
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

        <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <div class="text-center item">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "ChiTiet.aspx?masp="+Eval("MaSP") %>'>
                        <asp:Image ID="Image1" runat="server" Width="80%" ImageUrl='<%# "Images/"+Eval("Anh") %>' />
                        <div class="styleText">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSP") %>'></asp:Label>
                        </div>
                        <span>Giá: </span>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaBan") %>'></asp:Label>
                        <span>VNĐ</span><br />
                        <div class="form-group text-center">
                            <asp:Button ID="btnXoa" runat="server" Text="Xoá" CssClass="btn btn-danger w-50" CommandArgument='<%# Eval("MaSP") %>' />
                        </div>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
