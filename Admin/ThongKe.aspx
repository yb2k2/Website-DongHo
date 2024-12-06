<%@ Page Title="Thống kê doanh thu" Language="C#" MasterPageFile="~/Admin/LayoutPageAdmin.master" AutoEventWireup="true" CodeFile="ThongKe.aspx.cs" Inherits="Admin_ThongKe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="text-center title">Thống kê doanh thu</h2>

    <!-- Biểu đồ -->
    <canvas id="revenueChart" width="400" height="200"></canvas>

    <!-- Tổng doanh thu -->
    <div class="text-right mt-3">
<asp:Label ID="lblTongDoanhThu" runat="server" CssClass="font-weight-bold" Font-Size="X-Large" style="display:block; text-align:center;"></asp:Label>
    </div>

    <!-- Chú thích -->
    <div id="chartLegend" class="mt-3">
<h3 font-weight: bold;">&nbsp;	&nbsp;	&nbsp;	 Chi tiết</h3>
        <!-- Đây là nơi sẽ hiển thị chú thích dưới biểu đồ -->
        <div>
           
            <span style="color:#4caf50;">●</span> Doanh thu theo ngày: <span id="revenueDay">VNĐ</span>
        </div>
        <div>
            <span style="color:#2196f3;">●</span> Doanh thu theo tháng: <span id="revenueMonth">VNĐ</span>
        </div>
        <div>
            <span style="color:#ff9800;">●</span> Doanh thu theo năm: <span id="revenueYear">VNĐ</span>
        </div>
    </div>

    <!-- Script tạo biểu đồ -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            // Dữ liệu từ server (C#)
            var chartData = <%= chartDataJson %>;

            // Tạo biểu đồ doanh thu
            var ctx = document.getElementById('revenueChart').getContext('2d');
            var revenueChart = new Chart(ctx, {
                type: 'bar', // Biểu đồ cột
                data: chartData,
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            display: false // Tắt legend mặc định của Chart.js
                        },
                        title: {
                            display: true,
                            text: 'Doanh thu theo ngày, tháng, năm'
                        }
                    },
                    onClick: function (event, elements) {
                        // Khi click vào biểu đồ
                        if (elements.length > 0) {
                            var index = elements[0]._index; // Lấy chỉ mục phần được click
                            updateLegend(index); // Cập nhật chú thích tương ứng
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            ticks: {
                                callback: function (value) {
                                    return value.toLocaleString() + ' VNĐ'; // Định dạng tiền VNĐ
                                }
                            }
                        }
                    }
                }
            });

            // Hàm cập nhật chú thích tương ứng với màu sắc và cột
            function updateLegend(index) {
                var colors = ['#4caf50', '#2196f3', '#ff9800']; // Màu sắc của các cột
                var labels = ['Doanh thu ngày', 'Doanh thu tháng', 'Doanh thu năm']; // Tên các cột tương ứng

                // Cập nhật giá trị doanh thu theo ngày, tháng, năm
                if (index === 0) {
                    document.getElementById('revenueDay').innerText = chartData.datasets[0].data[index].toLocaleString() + ' VNĐ';
                } else if (index === 1) {
                    document.getElementById('revenueMonth').innerText = chartData.datasets[0].data[index].toLocaleString() + ' VNĐ';
                } else if (index === 2) {
                    document.getElementById('revenueYear').innerText = chartData.datasets[0].data[index].toLocaleString() + ' VNĐ';
                }
            }
        });
    </script>
</asp:Content>
