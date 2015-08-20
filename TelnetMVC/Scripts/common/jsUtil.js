
function autocomplate(txt, name, type) {
    //var outerid = txt.attr("outerid");
    var outervalue = "";
    var key = "";
    if (type)
        key = type;
    else if (txt.attr("title"))
        key = txt.attr("title");
    if (key == "")
        return;
    txt.autocomplete({
        minLength: 1,//开始查询的最少字数
        delay: 200,//延迟
        source: function (request, response) {
            var url = "/AutoComplete/Users?userName=" + escape(request.term);
            //if (outerid) {
            //    if ($("#" + outerid).val().length < 1) {
            //        alert("请录入" + $("#txt_" + outerid).attr("title"));
            //        return;
            //    }
            //    url += "&outer=" + escape($("#" + outerid).val());
            //}
            $.ajax({
                url: url,
                dataType: "json",
                cache: false,
                error: function (e) {
                },
                success: function (data) {
                    response(data);
                }
            });
        },
        focus: function (event, ui) {
            txt.val(ui.item.label);
            return false;
        },
        select: function (event, ui) {
            txt.val(ui.item.label);
            txt.attr('data-val', ui.item.label);
            $(name).val(ui.item.value);
            isChangeLeave = true;
            return false;
        }
    });
    txt.blur(function () {
        var last = txt.attr('data-val');
        var data = txt.val();
        if (data != last) {
            $(name).val('');
            isChangeLeave = true;
        }
        //改变人员后更换信息
        //loadInfo();

    });
}

