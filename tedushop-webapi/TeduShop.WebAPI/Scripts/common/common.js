var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $('.btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var that = $(this);
            var parent = $(this).parents('.top_grid1-box1');
            var src = parent.find('img').attr('src');
            var cart = $('#cart-shop');
            var parentTop = parent.offset().top;
            var parentLeft = parent.offset().left;            
            
            var productId = parseInt($(this).data('id'));
            $.ajax({
                url: '/ShoppingCart/Add',
                data: {
                    productId: productId
                },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        //alert('Thêm sản phẩm thành công.');
                        if (that.hasClass('disable')) {
                            return false;
                        }
                        $('.btnAddToCart').addClass('disable');
                        var img = $('<img />', {
                            class: 'img-product-fly',
                            src: src,
                        });
                        img.appendTo($('body')).css({
                            'top': parentTop,
                            'left': parentLeft + parent.width() - 50
                        });
                        setTimeout(function () {
                            $('.img-product-fly').css({
                                'top': cart.offset().top,
                                'left': cart.offset().left
                            });
                            setTimeout(function () {
                                $('.img-product-fly').remove();
                                //var countItem = parseInt($('#count-item').data('count'))+1;
                                //$('#count-item').text(countItem + ' Sản phẩm').data('count', countItem);
                                $('#count-item').text(response.count.length + ' Sản phẩm');
                                $('.btnAddToCart').removeClass('disable');
                            },1000);
                        }, 500);
                    }
                }
            });
        });
        $('.btnAddToCartDetail').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            $.ajax({
                url: '/ShoppingCart/Add',
                data: {
                    productId: productId
                },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        $('#count-item').text(response.count.length + ' Sản phẩm');
                        alert('Thêm sản phẩm thành công.');
                        
                    }
                }
            });
        });
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Pro/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
              .append("<a>" + item.label + "</a>")
              .appendTo(ul);
        };
    }
}
common.init();