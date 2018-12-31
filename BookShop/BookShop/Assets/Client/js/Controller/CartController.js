var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('.btn-Edit').off('click').on('click', function () {
            var listbook = $('.txtQuantity');// lấy listbook từ lớp txtQuantity, đẻ lấy một tập phần tử cùng lớp Quantity
            var cartList = [];// chưa các danh sách , là mảng có các thuộc tính của CartItem
            $.each(listbook, function (i, item) {// lọc qua các list đã lọc, vòng lặp x của jequeryy
                cartList.push({ // push từng đối tượng vào mảng
                    Quantity: $(item).val(),//lấy ra giá trị hiện tại của textbox đó
                    Book: {
                        ID: $(item).data('id')// ID = thuộc tính data-id  lấy ra từ đối tượng
                    }
                });
            });
            // Gọi Ajax
            //Phương thức Ajax dùng để đẩy lên Controller
            $.ajax({
                url: '/Cart/Edit',//chuois chứa đườn dẫn tới file cần lấy và trả về dữ liệu
                data: { cartModel: JSON.stringify(cartList) },//tên  biến là: CarModel, tên của đối tượng JSON , để tải đối tuwongnj Json sang một chuỗi, truyền dữ liệu san đường dẫn chỉ định để thực hiện xử lý dữ liệu
                dataType: 'Json',//
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            });
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            var conf = confirm("Bạn có muốn xóa giỏ hàng??");
            if (conf == true) {
                $.ajax({
                    url: '/Cart/DeleteAll',
                    dataType: 'Json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/Cart";
                        }
                    }
                });
            }

        });

        $('.btn-Delete').off('click').on('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'Json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            });
        });


    }

}

cart.init();