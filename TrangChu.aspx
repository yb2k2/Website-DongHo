    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="TrangChu" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <!-- Carousel -->
        <div id="carouselExampleControls" class="carousel slide animated bounce" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="d-block w-100" src="Images/slide1.jpg" alt="First slide" />
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="Images/slide2.jpg" alt="Second slide" />
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="Images/slide3.jpg" alt="Third slide" />
                </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>

        <!-- Product Sections: Đồng hồ nam, nữ, đôi, treo tường -->
        <div class="container_custom pb-5">
            <h2 class="text-center title-product" data-aos="fade-down-left">Đồng hồ nam</h2>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" data-aos="flip-left" data-aos-easing="ease-out-cubic" data-aos-duration="2000">
                <ItemTemplate>
                    <div class="product text-center">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "ChiTiet.aspx?masp="+Eval("MaSP") %>'>
                            <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%# "Images/"+Eval("Anh") %>' /><br />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSP") %>' CssClass="fs-18 text-color"></asp:Label><br />
                            <span>Giá: </span>
                            <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:0,0}",Eval("GiaBan")) %>'></asp:Label>
                            <span>VNĐ</span>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

        <!-- đồng hồ nữ -->
        <div class="container_custom py-5">
            <h2 class="text-center title-product" data-aos="fade-down-left">Đồng hồ nữ</h2>
            <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" data-aos="flip-left" data-aos-easing="ease-out-cubic" data-aos-duration="2000">
                <ItemTemplate>
                    <div class="product text-center">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "ChiTiet.aspx?masp="+Eval("MaSP") %>'>
                            <asp:Image ID="Image2" runat="server" Height="300px" Width="300px" ImageUrl='<%# "Images/"+Eval("Anh") %>' /><br />
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("TenSP") %>' CssClass="fs-18 text-color"></asp:Label><br />
                            <span>Giá: </span>
                            <asp:Label ID="Label4" runat="server" Text='<%# String.Format("{0:0,0}",Eval("GiaBan")) %>'></asp:Label>
                            <span>VNĐ</span>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

        <!-- đồng hồ cặp đôi -->
        <div class="container_custom">
            <h2 class="text-center title-product" data-aos="fade-down-left">Đồng hồ đôi</h2>
            <asp:DataList ID="DataList3" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <div class="product text-center">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "ChiTiet.aspx?masp="+Eval("MaSP") %>'>
                            <asp:Image ID="Image3" runat="server" Height="300px" Width="300px" ImageUrl='<%# "Images/"+Eval("Anh") %>' /><br />
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("TenSP") %>' CssClass="fs-18 text-color"></asp:Label><br />
                            <span>Giá: </span>
                            <asp:Label ID="Label6" runat="server" Text='<%# String.Format("{0:0,0}",Eval("GiaBan")) %>'></asp:Label>
                            <span>VNĐ</span>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

        <!-- đồng hồ treo tường -->
        <div class="container_custom">
            <h2 class="text-center title-product" data-aos="fade-down-left">Đồng hồ treo tường</h2>
            <asp:DataList ID="DataList4" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <div class="product text-center">
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# "ChiTiet.aspx?masp="+Eval("MaSP") %>'>
                            <asp:Image ID="Image4" runat="server" Height="300px" Width="300px" ImageUrl='<%# "Images/"+Eval("Anh") %>' /><br />
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("TenSP") %>' CssClass="fs-18 text-color"></asp:Label><br />
                            <span>Giá: </span>
                            <asp:Label ID="Label8" runat="server" Text='<%# String.Format("{0:0,0}",Eval("GiaBan")) %>'></asp:Label>
                            <span>VNĐ</span>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
     <div class="chatbox-container">
    <div class="chatbox-header">
        <div class="chatbox-logo">
            <img src="Images/logo.jpg" alt="Logo" />
        </div>
        <div class="chatbox-title">
            <h3>Đồng Hồ Duy Bình</h3>
            <p>Chúng tôi sẵn sàng trợ giúp. Vui lòng chọn một chủ đề bên dưới!</p>
        </div>
        <button class="chatbox-close">×</button> <!-- Nút đóng -->
    </div>
    <div class="chatbox-body">
        <div class="chatbox-messages"></div>
        <button class="chatbox-btn">Mua Hàng Trả Góp</button>
        <button class="chatbox-btn">Thẩm Định Đồng Hồ Thật Giả</button>
        <button class="chatbox-btn">Hệ Thống Cửa Hàng</button>
        <button class="chatbox-btn">Tư Vấn Đồng Hồ Nam</button>
        <button class="chatbox-btn">Tư Vấn Đồng Hồ Nữ</button>
        <button class="chatbox-btn">Tham Khảo Chương Trình Khuyến Mại</button>
        <button class="chatbox-btn">Định Giá và Thu Mua Đồng Hồ Cũ</button>
    </div>
    <div class="chatbox-footer">
        <input type="text" placeholder="Nhập tin nhắn..." class="chatbox-input" />
        <button class="chatbox-send">➤</button>
    </div>

<script src="JS/chatbox.js"></script>

 </div>
    <div class="banner">
        <div class="row w-100 m-0">
            <div class="col-md-6 px-0 container-banner" data-aos="flip-left">
                <div class="banner1">
                    <div class="title-banner" data-aos="fade-up">
                        <h3>Romance in the air</h3>
                        <h4>Wear your style with verve & attitude</h4>
                        <button type="button">Detail</button>
                    </div>
                </div>
            </div>
            <div class="col-md-6 px-0 container-banner" data-aos="flip-right">
                <div class="banner2">
                    <div class="title-banner" data-aos="fade-up">
                        <h3>Analog & Digital</h3>
                        <h4>Smart watches latest fashion statement</h4>
                        <button type="button">Detail</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container_custom py-5">
        <div class="more_infomation">
            <h2 class="text-center title-product" data-aos="fade-up-left">Thông tin hữu ích</h2>
            <div class="row">
                <div class="col-md-4" data-aos="flip-right" data-aos-duration="500">
                    <div class="container-info">
                        <div class="img-info">
                            <img src="Images/slide1.jpg" class="img-fluid" />
                        </div>
                        <h4 class="font-weight-bold title-information py-3">Ưu điểm nổi bật của sản phẩm:.</h4>
                        <p>Chất liệu cao cấp, bền bỉ</p>
                                                <p>Thiết kế thời trang, sang trọng</p>
                        <p>Bảo hành lâu dài</p>

                    </div>

                </div>
                <div class="col-md-4" data-aos="flip-right" data-aos-duration="600">
                    <div class="container-info">
                        <div class="img-info">
                            <img src="Images/slide2.jpg" class="img-fluid" />
                        </div>
                        <h4 class="font-weight-bold title-information py-3">Công nghệ.</h4>
                        <p>Sử dụng máy quartz hoặc máy cơ</p>
                        <p>Mặt kính sapphire chống xước</p>
                        <p>Dây đeo da thật hoặc kim loại</p>
                    </div>
                </div>
                <div class="col-md-4" data-aos="flip-right" data-aos-duration="700">
                    <div class="container-info">
                        <div class="img-info">
                            <img src="Images/slide3.jpg" class="img-fluid" />
                        </div>
                        <h4 class="font-weight-bold title-information py-3">Tính năng đặc biệt:.</h4>
                <p>Lịch ngày, lịch thứ</p>
                        <p>Đèn led tự động</p>
                        <p> Hiệu suất cao</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

