<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="XemGioHang.aspx.cs" Inherits="XemGioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_custom">
        <div class="row my-5">
            <div class="col-md-3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="animated jello">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="LoaiSP" DataTextField="TenLoaiSP" HeaderText="Danh mục sản phẩm">
                            <HeaderStyle CssClass="headerGridViewStyle" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-9 rounded" style="border: 3px dashed #808080;">
                <h2 class="text-center title-product animated fadeInDownBig">Giỏ hàng của bạn</h2>
                <div class="text-right mb-3">
                    <asp:Button ID="btnHuySP" runat="server" Text="Huỷ toàn bộ sản phẩm" OnClick="btnHuySP_Click" CssClass="btn btn-danger" />
                </div>
                <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover animated rotateInDownLeft" OnRowDeleting="GridView2_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <div class="row justify-content-between px-3">
                    <asp:Label ID="txtTongThanhTien" runat="server" CssClass="font-weight-bold"></asp:Label>
                    <asp:Button ID="btnDatHang" runat="server" Text="Xác nhận đặt hàng" CssClass="btn btn-danger" OnClick="btnDatHang_Click" />
                </div>
                <div class="row mt-3">
                    <div class="col-md-6">
                        <h3 class="title-product">Cập nhật số lượng</h3>
                        <div class="form-group">
                            <asp:TextBox ID="txtMaSPUpdateSoLuong" runat="server" CssClass="form-control py-2 px-4" AutoCompleteType="Disabled" placeholder="MaSP cần update"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtUpdateSoLuong" runat="server" CssClass="form-control py-2 px-4" AutoCompleteType="Disabled" placeholder="Số lượng cần update" TextMode="Number" min="1"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnUpdateSoLuong" runat="server" Text="Cập nhật" CssClass="btn btn-info" OnClick="btnUpdateSoLuong_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

