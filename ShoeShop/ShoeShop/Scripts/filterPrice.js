var filter = ({
    init: function () {
        filter.registerEvent();
    },
    registerEvent: function () {
        $(document).ready(function () {
            //var listPro = [];
            $(".checkbox input:checkbox").click(function () {
                $(".checkbox input:checkbox").not(this).prop("checked", false);
                if ($(this).is(":checked")) {
                    $.ajax({
                        url: "/Product/FilterPrice/" + $(this).attr("value"),
                        dataType: "json",
                        type: "POST",
                        success: function (res) {
                            //$.each(res, function(i,item) {
                            //    //console.log(res[i].Name);
                            //    //alert(res[i].Name +" "+res[i].Price);
                            //    listPro.push({Name: res[i].Name, Price: res[i].Price});
                            //});
                            if (res.status === true) {
                                window.location.href = "/filter-by-price/" + res.data;
                            } else {
                                window.location.href = "/filter-by-price/" + res.data;
                            }
                        }
                        //error: function (xhr, ajaxOption, throwError) {
                        //    alert(xhr.status);
                        //    alert(throwError);
                        //}
                    });
                }
            });
        });
    }
});
filter.init();