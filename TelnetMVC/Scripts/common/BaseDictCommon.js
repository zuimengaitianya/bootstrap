//字典翻译
String.prototype.DictTranslate = function (dictName)
{
    var me = this;
    var data = "";
    if (dictName == "OrgDict") {
        $.ajax({
            type: "post",
            url: "/OrgDict/setOrgName",
            data: { "orgId": me },
            async: false,//注意，设置为同步false 才能返回值。
            dataType: "text",
            error: function (ee) {
                $("#Loading").hide();
            },
            success: function (result) {
                $("#Loading").hide();
                data = result;
            }
        });
    }
    else if (dictName == "User") {
        $.ajax({
            type: "post",
            url: "/User/GetUserName",
            data: { "userId": me },
            async: false,
            dataType: "text",
            error: function (ee) {
                $("#Loading").hide();
            },
            success: function (result) {
                $("#Loading").hide();
                data = result;
            }
        });
    }
    else if (dictName == "DeptDict") {
        $.ajax({
            type: "post",
            url: "/DeptDict/setDeptName",
            data: { "deptId": me },
            async: false,
            dataType: "text",
            error: function (ee) {
                $("#Loading").hide();
            },
            success: function (result) {
                $("#Loading").hide();
                data = result;
            }
        });
    }
    else if (dictName == "RoleDict") {
        $.ajax({
            type: "post",
            url: "/RoleDict/GetRoleName",
            data: { "roleId": me },
            async: false,
            dataType: "text",
            error: function (ee) {
                $("#Loading").hide();
            },
            success: function (result) {
                $("#Loading").hide();
                data = result;
            }
        });
    }
    else {
        $.ajax({
            type: "post",
            url: "/BaseDict/GetDictValue",
            data: { "dictKey": me, "dictName": dictName },
            async: false,
            dataType: "json",
            error: function (ee) {
                $("#Loading").hide();
            },
            success: function (result) {
                $("#Loading").hide();
                if (result.Success) {
                    data = result.Data.DictValue;
                }
            }
        });
    }
    return data;
}

//字典数据
$(function () {
    var dict = "";
    $("input:text[dict] ,textarea[dict]").each(function () {
        if (isEmpty($(this).attr("dictmode")) || $(this).attr("dictmode") == "local") {
            var dictname = $(this).attr("dict");
            if (dict.indexOf() < 0) {
                dict += dictname + ",";
            }
        }
    })
    if (dict.length > 0) {
        $.ajax({
            type: "post",
            url: "/BaseDict/GetDictAllRows",
            data: { "dictConfig": dict },
            dataType: "text",
            error: function (ee) {
                $("#Loading").hide();
            },
            success: function (dictjson) {
                $("#Loading").hide();
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