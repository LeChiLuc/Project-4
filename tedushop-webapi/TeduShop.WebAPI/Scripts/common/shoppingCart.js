var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
        $('#frmPayment').validate({
            rules: {
                name: "required",
                address: "required",
                email: {
                    required: true,
                    email: true
                },
                phone: {
                    required: true,
                    number: true
                }
            },
            messages: {
                name: "Yêu cầu nhập tên",
                address: "Yêu cầu nhập địa chỉ",
                email: {
                    required: "Bạn cần nhập email",
                    email: "Định dạng email chưa đúng"
                },
                phone: {
                    required: "Số điện thoại được yêu cầu",
                    number: "Số điện thoại phải là số"
                }
            }
        });
        $('.btnDeleteItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.deleteItem(productId);
        });
        $('.txtQuantity').off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            var productid = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {
                var dolor = '$'
                var amount = quantity * price;
                $('#amount_' + productid).text(dolor + amount);
            }
            else {
                $('#amount_' + productid).text(0);
            }
            $('#lblTotalOrder').text(dolor + cart.getTotalOrder());
            cart.UpdateAll();
        });
        $('#btnContinue').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = '/';
        });
        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            cart.DeleteAll();
        });
        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#divCheckout').toggle();
        });
        $('#chkUserLoginInfo').off('click').on('click', function () {
            if ($(this).prop('checked')) {
                cart.getLoginUser();
            }
            else {
                $('#txtName').val('');
                $('#txtAddress').val('');
                $('#txtEmail').val('');
                $('#txtPhone').val('');
            }
        });
        $('#btnCreateOrder').off('click').on('click', function () {           
            var isvalid = $('#frmPayment').valid();
            if (isvalid) {
                cart.createOrder();
            }
        });
    },
    getLoginUser: function(){
        $.ajax({
            url: '/ShoppingCart/GetUser',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var user = response.data;
                    $('#txtName').val(user.FullName);
                    $('#txtAddress').val(user.Address);
                    $('#txtEmail').val(user.Email);
                    $('#txtPhone').val(user.PhoneNumber);
                }
            }
        });
    },
    createOrder: function () {
        var order ={
            CustomerName : $('#txtName').val(),
            CustomerAddress : $('#txtAddress').val(),
            CustomerEmail : $('#txtEmail').val(),
            CustomerMobile : $('#txtPhone').val(),
            CustomerMessage : $('#txtMessage').val(),
            PaymentMethod : "Thanh toán tiền mặt",
            Status : false
        }
        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            type: 'POST',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    console.log('Create Order OK');
                    $('#divCheckout').hide();
                    cart.DeleteAll();
                    setTimeout(function () {
                        $('#cartContent').html('Cảm ơn bạn đã đặt hàng thành công. Chúng tôi sẽ liên hệ với bạn sớm nhất.');
                    },2000);                    
                }
            }
        });
    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html();
                    var dolor = '$';
                    var html = '';
                    var data = res.data;
                    $.each(res.data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.ThumbnailImage,
                            Price: item.Product.Price,
                            Quantity: item.Quantity,
                            Amount: item.Quantity * item.Product.Price
                        });
                    });
                    $('#cartBody').html(html);
                    if(html==''){
                        $('#cartContent').html('Không có sản phẩm nào trong giỏ hàng');
                    }
                    $('#lblTotalOrder').text(dolor + cart.getTotalOrder());
                    cart.registerEvent();
                }
            }
        });
    },
    getTotalOrder: function(){
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseInt($(item).val()) * parseFloat($(item).data('price'));;
        });
        return total;
    },
    UpdateAll: function () {
        cartList = [];
        $.each($('.txtQuantity'), function (i,item) {
            cartList.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            })
        });
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data:{
                cartData: JSON.stringify(cartList)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                    console.log('Update Ok');
                }
            }
        });
    },
    DeleteAll: function () {
        $.ajax({
            url: '/ShoppingCart/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                }
            }
        });
    },
    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                }
            }
        });
    }
}
cart.init();