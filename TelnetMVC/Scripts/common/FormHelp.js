$(function () {
    var dict = "";
    $(".WcHis_Form input:text[dict] , .WcHis_Form textarea[dict]").each(function () {
        if (isEmpty($(this).attr("dictmode")) || $(this).attr("dictmode") == "local") {
            var dictname = $(this).attr("dict");
            if (dict.indexOf() < 0) {
                dict += dictname + ",";
            }
        }
    });
    if (dict.length > 0) {
        dict = dict.substr(0, dict.length - 1);
        $.ajax({
            url: '/WcHisForm/GetDictAllRows', //后台处理程序 
            type: 'POST', //数据发送方式 
            dataType: 'text', //接受数据格式 
            data: { "orgID": ParentObj.JsHelper.GetUserInfo().OrgId, "dictConfig": dict }, //要传递的数据 
            success: function (dictjson) {
                if (dictjson != null && typeof (dictjson) != "undefined" && dictjson != "") {
                    var oHead = document.getElementsByTagName('HEAD').item(0);
                    var oScript = document.createElement("script");
                    oScript.language = "javascript";
                    oScript.type = "text/javascript";
                    oScript.id = 'DictScript';
                    oScript.defer = true;
                    oScript.text = dictjson;
                    oHead.appendChild(oScript);
                }
            }
        });
    }
})