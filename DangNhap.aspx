<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_custom">
        <div class="row my-5">
            <div class="col-md-3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="animated lightSpeedIn">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="LoaiSP" DataTextField="TenLoaiSP" HeaderText="Danh mục sản phẩm">
                            <HeaderStyle CssClass="headerGridViewStyle" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-9 rounded" style="border:3px dashed #808080;">
                <h2 class="text-center title-product animated fadeInDownBig">Đăng nhập</h2>
                <div class="formRegister">
                    <div class="form-group">
                        <label>Tài khoản</label>
                        <asp:TextBox ID="txtTaiKhoan" runat="server" CssClass="form-control w-100 px-3 py-2" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tài khoản không được bỏ trống" ControlToValidate="txtTaiKhoan" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Mật khẩu</label>
                        <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control px-3 py-2 w-100" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mật khẩu không được bỏ trống" ControlToValidate="txtMatKhau" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group text-center">
                        <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" CssClass="btn btn-success" OnClick="btnDangNhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

