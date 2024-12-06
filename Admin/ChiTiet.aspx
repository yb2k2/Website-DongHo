<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/LayoutPageAdmin.master" AutoEventWireup="true" CodeFile="ChiTiet.aspx.cs" Inherits="Admin_ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h3 class="text-center title" data-aos="fade-left">Chi tiết sản phẩm</h3>
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-6" data-aos="flip-right" data-aos-duration="1000">
                            <asp:HyperLink ID="HyperLink2" runat="server" href='<%# "Images/"+Eval("Anh") %>' data-lightbox="listImg">
                                <asp:Image ID="Image1" runat="server" Width="100%" ImageUrl='<%# "Images/"+Eval("Anh") %>' />
                            </asp:HyperLink>
                        </div>
                        <div class="col-6" data-aos="fade-left" data-aos-duration="1500">
                            <h3 class="font-weight-bold detail-product">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSP") %>'></asp:Label></h3>
                            <h3 class="detail-product mt-3">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaBan") %>'></asp:Label>
                                <span>VNĐ</span></h3>
                            <hr />
                            <h4 class="font-weight-bold detail-product">Mô tả</h4>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Mota") %>'></asp:Label><br /><br />
                            <span class="font-weight-bold">Sản phẩm dành cho: </span>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("GioiTinh") %>' CssClass="font-weight-bold"></asp:Label><br /><br />
                            <span class="font-weight-bold">Giá nhập: </span>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("GiaNhap") %>' CssClass="font-weight-bold"></asp:Label><br /><br />
                            <span class="font-weight-bold">Số lượng tồn: </span>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("SoLuongTon") %>' CssClass="font-weight-bold"></asp:Label>
                            <div class="form-group my-4">
                                <asp:Button ID="btnSua" runat="server" Text="Sửa sản phẩm" CssClass="btn btn-info" CommandArgument='<%# Eval("MaSP") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>

