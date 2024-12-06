<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="LienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container_custom">
        <div class="row my-5">
            <div class="col-md-3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="LoaiSP" DataTextField="TenLoaiSP" HeaderText="Danh mục sản phẩm">
                            <HeaderStyle CssClass="headerGridViewStyle" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-9 rounded" style="border:3px dashed #808080;">
                <h2 class="text-center title-product">Thông tin liên hệ</h2>
                <div class="formLienHe">
                    <div class="form-group">
                        <label>Tiêu đề</label>
                        <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control w-100 py-2 px-3" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tên tiêu đề không được bỏ trống" ForeColor="Red" Font-Size="Small" ControlToValidate="txtTieuDe"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Nội dung</label>
                        <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control w-100 py-2 px-3" TextMode="MultiLine" Height="119px" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nội dung không được bỏ trống" ForeColor="Red" Font-Size="Small" ControlToValidate="txtNoiDung"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group text-center">
                        <asp:Button ID="txtSubmit" runat="server" Text="Gửi" CssClass="btn btn-danger py-2 px-5" OnClick="txtSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

