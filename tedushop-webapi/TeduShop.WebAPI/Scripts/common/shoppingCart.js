var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
        
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
            cart.getLoginUser();
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
                    $('#txtName').val(user.Address);
                    $('#txtName').val(user.Email);
                    $('#txtName').val(user.PhoneNumber);
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
    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    alert('Thêm sản phẩm thành công.');
                }
            }
        });
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