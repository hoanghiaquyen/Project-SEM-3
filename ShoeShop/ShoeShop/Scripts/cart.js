var cart =
{
    init: function () {
        cart.registerEvent();
    },
    registerEvent: function () {
        $("#btnContinue").off("click").on("click", function () {
            window.location.href = "/";
        });

        $("#btnPayment").off("click").on("click", function () {
            window.location.href = "/payment";
        });

        $("#btnUpdate").off("click").on("click", function () {
            var listProduct = $(".txtquantity");
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        Id: $(item).data("id")
                    }
                });
            });
            $.ajax({
                url: "/ShoppingCart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: "json",
                type: "POST",
                success: function(res) {
                    if (res.status === true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });
        
        $("#btnDeleteAll").off("click").on("click", function () {
            $.ajax({
                url: "/ShoppingCart/DeleteAll",
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status === true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });

        $(".btn-delete").off("click").on("click", function (e) {
            e.preventDefault(),
            $.ajax({
                data:{id: $(this).data("id")},
                url: "/ShoppingCart/Delete",
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status === true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });
    }
}
cart.init();