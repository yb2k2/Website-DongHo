<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThanhToan.aspx.cs" Inherits="ThanhToan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_custom">
        <h2 class="text-center">Thông tin thanh toán</h2>
        <div class="form-group">
            <label for="txtHoTen">Họ và tên</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" placeholder="Nhập họ tên"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtDiaChi">Địa chỉ</label>
            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" placeholder="Nhập địa chỉ"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Phương thức thanh toán</label><br/>
            <asp:RadioButton ID="rbtnMomo" runat="server" Text="Momo" GroupName="ThanhToan" />
            <asp:RadioButton ID="rbtnVNPay" runat="server" Text="VNPay" GroupName="ThanhToan" />
        </div>
        <asp:Button ID="btnThanhToan" runat="server" Text="Thanh toán" CssClass="btn btn-success" OnClick="btnThanhToan_Click" />
    </div>
</asp:Content>
