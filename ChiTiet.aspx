<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTiet.aspx.cs" Inherits="ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_custom">
        <div class="text-right">
            <asp:Button ID="btnXemGiohang" runat="server" Text="Giỏ Hàng" CssClass="btn btn-danger" OnClick="btnXemGiohang_Click" />
        </div>
        <div class="row">
            <div class="col-3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="animated flash">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="LoaiSP" DataTextField="TenLoaiSP" HeaderText="Danh mục sản phẩm">
                            <HeaderStyle CssClass="headerGridViewStyle" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-9">
                <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-6">
                                    <asp:HyperLink ID="HyperLink2" runat="server" href='<%# "Images/"+Eval("Anh") %>' data-lightbox="listImg">
                                        <asp:Image ID="Image1" runat="server" Width="100%" ImageUrl='<%# "Images/"+Eval("Anh") %>' CssClass="animated rubberBand" />
                                    </asp:HyperLink>
                                </div>
                                <div class="col-6">
                                    <h3 class="font-weight-bold detail-product animated shake">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSP") %>'></asp:Label></h3>
                                    <h3 class="detail-product mt-3">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaBan") %>'></asp:Label>
                                        <span>VNĐ</span></h3>
                                    <hr />
                                    <h4 class="font-weight-bold detail-product">Mô tả</h4>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Mota") %>'></asp:Label><br />
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/ChonMua.jpg" CommandArgument='<%# Eval("MaSP") %>' CssClass="mt-3" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <hr />
            </div>
        </div>
    </div>
</asp:Content>

