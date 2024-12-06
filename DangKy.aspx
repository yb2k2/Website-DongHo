<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DangKy.aspx.cs" Inherits="DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_custom">
        <div class="row my-5">
            <div class="col-3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="animated lightSpeedIn">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="LoaiSP" DataTextField="TenLoaiSP" HeaderText="Danh mục sản phẩm">
                            <HeaderStyle CssClass="headerGridViewStyle" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-9 rounded" style="border:3px dashed #808080;">
                <h2 class="text-center title-product animated fadeInDownBig">Đăng kí tài khoản</h2>
                <div class="formRegister">
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <h4 class="text-center step-by-step animated rollIn">Bước 1: Thông tin cá nhân</h4>
                            <div class="form-group">
                                <label>Họ và tên</label>
                                <asp:TextBox ID="txtHoVaTen" runat="server" CssClass="form-control w-100 py-2 px-3" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Họ và tên không được bỏ trống" ControlToValidate="txtHoVaTen" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group text-center">
                                <asp:Button ID="btnNextStep2" runat="server" Text="Bước 2 >>" CssClass="btn btn-success" OnClick="btnNextStep2_Click" />
                            </div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <h4 class="text-center step-by-step animated rollIn">Bước 2: Thông tin liên hệ</h4>
                            <div class="form-group">
                                <label>Địa chỉ</label>
                                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control w-100 py-2 px-3" TextMode="MultiLine" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Địa chỉ không được bỏ trống" ControlToValidate="txtDiaChi" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control w-100 py-2 px-3" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Email không được bỏ trống" ControlToValidate="txtEmail" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng" ControlToValidate="txtEmail" Font-Size="Small" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Số điện thoại</label>
                                <asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="form-control w-100 py-2 px-3" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Số điện thoại không được bỏ trống" ControlToValidate="txtSoDienThoai" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Số điện thoại không hợp lệ" ValidationExpression="^([0-0]{1})([0-9]{9})$" ControlToValidate="txtSoDienThoai" Font-Size="Small" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group d-flex justify-content-between">
                                <asp:Button ID="btnPreviousStep1" runat="server" Text="<< Bước 1" CssClass="btn btn-success" OnClick="btnPreviousStep1_Click" />
                                <asp:Button ID="btnNextStep3" runat="server" Text="Bước 3 >>" CssClass="btn btn-success" OnClick="btnNextStep3_Click" />
                            </div>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <h4 class="text-center step-by-step animated rollIn">Bước 3: Tạo tài khoản đăng nhập</h4>
                            <div class="form-group">
                                <label>Tài khoản</label>
                                <asp:TextBox ID="txtTaiKhoan" runat="server" CssClass="form-control w-100 py-2 px-3" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tài khoản không được bỏ trống" ControlToValidate="txtTaiKhoan" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Mật khẩu</label>
                                <asp:TextBox ID="txtMK" runat="server" CssClass="form-control w-100 py-2 px-3" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Mật khẩu không được để trống" ControlToValidate="txtMK" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Xác nhận mật khẩu</label>
                                <asp:TextBox ID="txtRetypeMK" runat="server" CssClass="form-control w-100 py-2 px-3" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vui lòng không để trống" ForeColor="Red" Font-Size="Small" ControlToValidate="txtRetypeMK"></asp:RequiredFieldValidator><br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không khớp" ControlToCompare="txtMK" ControlToValidate="txtRetypeMK" ForeColor="Red" Font-Size="Small"></asp:CompareValidator>
                            </div>
                            <div class="form-group text-center">
                                <asp:CheckBox ID="CheckBoxPolicy" runat="server" Text="Tôi đồng ý và chấp nhận điều khoản" />
                            </div>
                            <div class="form-group d-flex justify-content-between">
                                <asp:Button ID="btnPreviousStep2" runat="server" Text="<< Bước 2" CssClass="btn btn-success" OnClick="btnPreviousStep2_Click" />
                                <asp:Button ID="btnDangKy" runat="server" Text="Đăng ký" CssClass="btn btn-success" OnClick="btnDangKy_Click" />
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

