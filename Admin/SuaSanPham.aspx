<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/LayoutPageAdmin.master" AutoEventWireup="true" CodeFile="SuaSanPham.aspx.cs" Inherits="Admin_SuaSanPham" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <h3 class="title text-center" data-aos="flip-left" data-aos-duration="1500">Sửa thông tin sản phẩm</h3>
        <div class="form-group">
            <label>Tên sản phẩm</label>
            <asp:TextBox ID="txtTenSanPham" runat="server" CssClass="form-control w-100 py-2 px-3" ValidateRequestMode="Disabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tên sản phẩm không được để trống" ControlToValidate="txtTenSanPham" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Mô tả</label>
            <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control w-100 py-2 px-3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mô tả không được để trống" ControlToValidate="txtMoTa" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Giới tính</label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control w-100 py-2 px-3">
                <asp:ListItem>Nam</asp:ListItem>
                <asp:ListItem>Nữ</asp:ListItem>
                                <asp:ListItem>UN</asp:ListItem>
                                                <asp:ListItem>TT</asp:ListItem>


            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Giá bán</label>
            <asp:TextBox ID="txtGiaBan" runat="server" CssClass="form-control w-100 py-2 px-3" min="1" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Giá bán không được để trống" ControlToValidate="txtGiaBan" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Giá nhập</label>
            <asp:TextBox ID="txtGiaNhap" runat="server" CssClass="form-control w-100 py-2 px-3" min="1" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Giá nhập không được để trống" ControlToValidate="txtGiaNhap" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Hình ảnh</label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control w-100 py-2 px-3" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Vui lòng thêm ảnh sản phẩm" ControlToValidate="FileUpload1" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Loại sản phẩm</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control w-100 py-2 px-3"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Số lượng tồn</label>
            <asp:TextBox ID="txtSoLuongTon" runat="server" CssClass="form-control w-100 py-2 px-3" min="1" AutoCompleteType="Disabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Số lượng tồn không được để trống" ForeColor="Red" Font-Size="Small" ControlToValidate="txtSoLuongTon"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group text-center">
            <asp:Button ID="btnSuaSanPham" runat="server" Text="Sửa sản phẩm" CssClass="btn btn-danger" OnClick="btnSuaSanPham_Click" />
        </div>
    </div>
</asp:Content>

