document.addEventListener("DOMContentLoaded", function () {
    // Lấy các phần tử DOM
    const chatboxBtns = document.querySelectorAll('.chatbox-btn');
    const chatboxMessages = document.querySelector('.chatbox-messages');
    const chatboxClose = document.querySelector('.chatbox-close');
    const chatboxContainer = document.querySelector('.chatbox-container');

    // Tạo nút thu nhỏ và hiển thị lại chatbox
    const chatboxMinimized = document.createElement('div');
    chatboxMinimized.classList.add('chatbox-minimized');
    chatboxMinimized.textContent = "Chat với nhân viên";
    chatboxMinimized.style.display = "none"; // Ẩn nút thu nhỏ ban đầu
    document.body.appendChild(chatboxMinimized);

    // Mẫu câu trả lời tự động
    const autoReplies = {
        "Mua Hàng Trả Góp": "Chúng tôi cung cấp dịch vụ mua hàng trả góp với lãi suất hấp dẫn. Bạn cần thêm thông tin gì?",
        "Thẩm Định Đồng Hồ Thật Giả": "Chúng tôi có chuyên gia để thẩm định đồng hồ thật giả. Bạn có muốn gửi mẫu để kiểm tra không?",
        "Hệ Thống Cửa Hàng": "Chúng tôi có hệ thống cửa hàng tại nhiều khu vực. Bạn cần tìm cửa hàng gần nhất?",
        "Tư Vấn Đồng Hồ Nam": "Chúng tôi có nhiều mẫu đồng hồ nam đa dạng. Bạn có nhu cầu tìm mẫu nào cụ thể không?",
        "Tư Vấn Đồng Hồ Nữ": "Chúng tôi cung cấp nhiều mẫu đồng hồ nữ phù hợp với mọi phong cách. Bạn muốn biết thêm chi tiết không?",
        "Tham Khảo Chương Trình Khuyến Mại": "Hiện tại chúng tôi có chương trình khuyến mãi đặc biệt cho các mẫu đồng hồ. Bạn muốn tham khảo không?",
        "Định Giá và Thu Mua Đồng Hồ Cũ": "Chúng tôi cung cấp dịch vụ định giá và thu mua đồng hồ cũ. Bạn có muốn gửi thông tin về chiếc đồng hồ của mình?"
    };

    // Khi người dùng nhấn vào các nút, gửi tin nhắn và trả lời tự động
    chatboxBtns.forEach(btn => {
        btn.addEventListener('click', function (event) {
            event.preventDefault(); // Ngừng hành động mặc định (reload trang)
            const message = this.innerText; // Lấy tên của nút
            sendMessage(message, 'user'); // Gửi tin nhắn của người dùng
            autoReply(message); // Gửi phản hồi tự động
        });
    });

    // Gửi tin nhắn từ người dùng
    function sendMessage(message, sender) {
        const newMessage = document.createElement('div');
        newMessage.classList.add('message', sender); // Thêm lớp 'user' hoặc 'chatbot'
        newMessage.innerHTML = `<strong>${sender === 'user' ? 'Bạn' : 'Chatbot'}:</strong> ${message}`;
        chatboxMessages.appendChild(newMessage);
        chatboxMessages.scrollTop = chatboxMessages.scrollHeight; // Cuộn xuống cuối
    }

    // Phản hồi tự động
    function autoReply(message) {
        setTimeout(() => {
            const replyMessage = autoReplies[message] || "Chúng tôi sẽ liên hệ với bạn sớm!";
            sendMessage(replyMessage, 'chatbot'); // Gửi tin nhắn chatbot
        }, 500); // Đợi 500ms trước khi gửi phản hồi
    }

    // Đóng chatbox và hiện tab thu nhỏ
    chatboxClose.addEventListener('click', function (event) {
        event.preventDefault(); // Ngăn trình duyệt thực hiện hành động mặc định
        chatboxContainer.style.display = "none"; // Ẩn chatbox
        chatboxMinimized.style.display = "block"; // Hiện nút thu nhỏ
    });

    // Mở lại chatbox từ tab thu nhỏ
    chatboxMinimized.addEventListener('click', function (event) {
        event.preventDefault(); // Ngăn trình duyệt thực hiện hành động mặc định
        chatboxContainer.style.display = "block"; // Hiển thị lại chatbox
        chatboxMinimized.style.display = "none"; // Ẩn nút thu nhỏ
    });
});
