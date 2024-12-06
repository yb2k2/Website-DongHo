<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/LayoutPageAdmin.master" AutoEventWireup="true" CodeFile="PhanHoi.aspx.cs" Inherits="Admin_PhanHoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <h3 class="title text-center animated zoomInUp">Thông tin phản hồi</h3>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
    </div>
</asp:Content>

