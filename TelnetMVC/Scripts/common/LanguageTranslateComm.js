var dict = [
    { Key: '下班时间比上班时间早', Velue: 'Start Time is bigger then End Time', Order: "1" },
	{ Key: '未选中任何数据', Velue: 'NO Data', Order: "1" },
	{ Key: '上下班时间未更改', Velue: 'Time No Change', Order: "1" },
	{ Key: '请输入补卡人', Velue: 'Please Input a  Punch Name', Order: "1" },
	{ Key: '加载数据失败', Velue: 'Load Data failure', Order: "1" },
	{ Key: '请重新刷新页面', Velue: 'Please Reflash Web', Order: "1" }
]
//html翻译，完全匹配才翻译，可添加Order排序查找翻译内容。
function TranslateA(languageDict) {
    var language = $.cookie('language');
    if (language == "English") {
        if (languageDict == undefined) {
            languageDict = dict;
        }
        //$("[placeholder]").each(function (k, v) {
        //	var Skey = $(v).attr("placeholder");
        //	var Tvalue = "";
        //	var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
        //	$.each(languageDict, function (a, b) {
        //		if (b.Key.indexOf(Skey) >= 0) {
        //			Tvalue = b.Value;
        //			return false;
        //		}
        //	})
        //	if (Tvalue != "") {
        //	    $(v).attr("placeholder", Tvalue);
        //	}
        //})
        $("[Translate]").each(function (k, v) {
            var Skey = v.textContent;
            var Sorder = $(v).attr("Translate");
            var Tvalue = v.textContent;
            var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
            $.each(languageDict, function (a, b) {
                if (Sorder == "") {
                    if (b.Key == Skey) {
                        Tvalue = b.Value;
                        return false;
                    }
                }
                else {
                    if (b.Key == Skey && b.Order == Sorder) {
                        Tvalue = b.Value;
                        return false;
                    }
                }
            })
            v.textContent = Tvalue;
        })
        $("[RegTranslate]").each(function (k, v) {
            if (v.tagName == "INPUT") {//输入框的Value替换掉
                var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
                var Sval = v.value;
                var TempVal = "";
                var TempStr = "";
                for (var i = 0; i < Sval.length; i++) {
                    if (myReg.test(Sval[i])) {
                        TempStr = TempStr + Sval[i];
                    }
                    else {
                        var isTanslate = false;
                        $.each(languageDict, function (a, b) {
                            if (b.Key == TempStr) {
                                TempVal = TempVal + b.Value;
                                TempStr = "";//还原临时字符串
                                isTanslate = true;
                                return false;
                            }
                        })
                        if (!isTanslate) {
                            TempVal = TempVal + TempStr;
                            TempVal = TempVal + Sval[i];
                            TempStr = "";//还原临时字符串
                        }
                        else {
                            TempVal = TempVal + Sval[i];
                        }
                    }
                }
                if (TempStr != "") {
                    var isTanslate = false;
                    $.each(languageDict, function (a, b) {
                        if (b.Key == TempStr) {
                            TempVal = TempVal + b.Value;
                            isTanslate = true;
                            TempStr = "";
                        }
                    })
                    if (!isTanslate) {
                        TempVal = TempVal + TempStr;
                        TempStr = "";
                    }
                }

                v.value = TempVal;
            }
            else {
                var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
                var Sval = v.textContent;
                var TempVal = "";
                var TempStr = "";
                for (var i = 0; i < Sval.length; i++) {
                    if (myReg.test(Sval[i])) {
                        TempStr = TempStr + Sval[i];
                    }
                    else {
                        var isTanslate = false;
                        $.each(languageDict, function (a, b) {
                            if (b.Key == TempStr) {
                                TempVal = TempVal + b.Value;
                                TempStr = "";//还原临时字符串
                                isTanslate = true;
                                return false;
                            }
                        })
                        if (!isTanslate) {
                            TempVal = TempVal + TempStr;
                            TempVal = TempVal + Sval[i];
                            TempStr = "";//还原临时字符串
                        }
                        else {
                            TempVal = TempVal + Sval[i];
                        }
                    }
                }
                if (TempStr != "") {
                    var isTanslate = false;
                    $.each(languageDict, function (a, b) {
                        if (b.Key == TempStr) {
                            TempVal = TempVal + b.Value;
                            isTanslate = true;
                            TempStr = "";
                        }
                    })
                    if (!isTanslate) {
                        TempVal = TempVal + TempStr;
                        TempStr = "";
                    }
                }

                v.textContent = TempVal;
            }
        })
        $("[DeptTranslate]").each(function (k, v) {
            if (v.tagName == "INPUT") {
                var Sval = v.value;
                if (Sval != "") {
                    $.ajax({
                        type: "post",
                        async: false,
                        url: '/Handle/PunchHandler.ashx',
                        data: { 'type': 'GetDeptNameEN', 'deptName': Sval },
                        dataType: "text",
                        error: function (result) {
                            console.log(v.value + '部门翻译失败');
                        },
                        success: function (result) {
                            if (result != "" && result != undefined) {
                                v.value = result;
                            }
                        }
                    });
                }
            }
        })
    }
}
function TranslateChine() {
    $("[Translate]").each(function (k, v) {
        var Skey = v.textContent;
        var Sorder = $(v).attr("Translate");
        var Tvalue = v.textContent;
        var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
        $.each(dict, function (a, b) {
            if (Sorder == "") {
                if (b.Value.indexOf(Skey) >= 0) {
                    Tvalue = b.Key;
                    return false;
                }
            }
            else {
                if (b.Value.indexOf(Skey) >= 0 && b.Order == Sorder) {
                    Tvalue = b.Key;
                    return false;
                }
            }
        })
        v.textContent = Tvalue;
    })
    $("[placeholder]").each(function (k, v) {
        var Skey = $(v).attr("placeholder");
        var Tvalue = v.textContent;
        var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
        $.each(dict, function (a, b) {

            if (b.Value.indexOf(Skey) >= 0) {
                Tvalue = b.Key;
                return false;
            }

        })
        $(v).attr("placeholder", Tvalue);
    })
}

function TranslateB(lang) {
    var language = $.cookie('language');
    if (language == "English") {
        $("[TranslateB]").each(function (k, v) {
            TranslateVersion(v, lang);
        })
    }
}


//html翻译，递归遍历子元素方式（只匹配中文，不匹配标点符号、数字等符号，不能翻译字符保留不变）
function TranslateVersion(o, languageDict) {
    if (languageDict == undefined) {
        languageDict = dict;
    }
    $.each(o.childNodes, function (a, b) {
        if (b.childNodes != undefined) {
            if (b.childNodes.length == 0) {//最末节点没有子元素了
                if (b.tagName == "INPUT" || b.tagName == "TEXTAREA" || b.tagName == "BUTTON") {//如果为Input元素则不翻译Value

                    if (b.tagName == "BUTTON") {
                        $.each(languageDict, function (a5, b5) {
                            if (b5.Key == b.textContent) {
                                b.textContent = b5.Value;
                                return false;
                            }
                        })
                    }
                    else {
                        if (b.type == "button") {

                            $.each(languageDict, function (a4, b4) {
                                if (b4.Key == b.value) {
                                    b.value = b4.Value;
                                    return false;
                                }
                            })
                        }
                        if (b.placeholder != undefined && b.placeholder != "") {

                            $.each(languageDict, function (a3, b3) {
                                if (b3.Key == b.placeholder) {
                                    b.placeholder = b3.Value;
                                    return false;
                                }
                            })
                        }
                    }
                }
                else {
                    var myReg = /^[\u4e00-\u9fa5]+$/;//中文验证
                    var TempVal = "";
                    var TempStr = "";
                    var Sval = "";
                    if (b.innerHTML == undefined) {//没有InnerHTML只有TextContent的元素。
                        Sval = b.textContent;
                    }
                    else {
                        Sval = b.innerHTML;
                    }

                    for (var i = 0; i < Sval.length; i++) {
                        if (myReg.test(Sval[i])) {
                            TempStr = TempStr + Sval[i];
                        }
                        else {

                            var isTanslate = false;
                            $.each(languageDict, function (a1, b1) {
                                if (b1.Key == TempStr) {
                                    TempVal = TempVal + b1.Value;
                                    TempStr = "";//还原临时字符串
                                    isTanslate = true;
                                    return false;
                                }
                            })
                            if (!isTanslate) {
                                TempVal = TempVal + TempStr;
                                if (Sval[i] == "，") {//标点符号转换
                                    TempVal = TempVal + ',';
                                }
                                else if (Sval[i] == "。") {
                                    TempVal = TempVal + '.';
                                }
                                else {
                                    TempVal = TempVal + Sval[i];
                                }
                                TempStr = "";//还原临时字符串
                            }
                            else {
                                TempVal = TempVal + Sval[i];
                            }
                        }
                    }
                    if (TempStr != "") {//处理最后一个字符串
                        var isTanslate = false;
                        $.each(languageDict, function (a2, b2) {
                            if (b2.Key == TempStr) {
                                TempVal = TempVal + b2.Value;
                                isTanslate = true;
                                TempStr = "";
                                return false;
                            }
                        })
                        if (!isTanslate) {
                            if (TempStr == "，") {//标点符号转换
                                TempVal = TempVal + ',';
                            }
                            else if (TempStr == "。") {
                                TempVal = TempVal + '.';
                            }
                            else {
                                TempVal = TempVal + TempStr;
                            }
                            TempStr = "";
                        }
                    }
                    if (b.innerHTML == undefined) {
                        b.textContent = TempVal;
                    }
                    else {
                        b.innerHTML = TempVal;//更换
                    }
                }
            }
            else {
                TranslateVersion(b, languageDict);//递归
            }
        }
    })

}
//脚本字符串翻译（只匹配中文，不匹配标点符号、数字等符号，不能翻译字符保留不变）
String.prototype.Translate = function (Sorder) {

    var me = this;
    if (me != undefined) {
        var language = $.cookie('language');
        if (language == "English") {

            var myReg = /^[\u4e00-\u9fa5]+$/;//中文字符验证(不包括标点符号、数字、特殊字符)
            var TempVal = "";
            var TempStr = "";
            var Sval = me.toString();


            for (var i = 0; i < Sval.length; i++) {
                if (myReg.test(Sval[i])) {
                    TempStr = TempStr + Sval[i];
                }
                else {
                    var isTanslate = false;
                    $.each(dict, function (a1, b1) {
                        if (b1.Key == TempStr) {
                            TempVal = TempVal + b1.Value;
                            TempStr = "";//还原临时字符串
                            isTanslate = true;
                            return false;
                        }
                    })
                    if (!isTanslate) {
                        TempVal = TempVal + TempStr;
                        if (Sval[i] == "，") {//标点符号转换
                            TempVal = TempVal + ',';
                        }
                        else if (Sval[i] == "。") {
                            TempVal = TempVal + '.';
                        }
                        else {
                            TempVal = TempVal + Sval[i];
                        }
                        TempStr = "";//还原临时字符串
                    }
                    else {
                        if (Sval[i] == "，") {//标点符号转换
                            TempVal = TempVal + ',';
                        }
                        else if (Sval[i] == "。") {
                            TempVal = TempVal + '.';
                        }
                        else {
                            TempVal = TempVal + Sval[i];
                        }
                    }
                }
            }
            if (TempStr != "") {//处理最后一个字符串
                var isTanslate = false;
                $.each(dict, function (a2, b2) {
                    if (b2.Key == TempStr) {
                        TempVal = TempVal + b2.Value;
                        isTanslate = true;
                        TempStr = "";
                        return false;
                    }
                })
                if (!isTanslate) {
                    if (TempStr == "，") {//标点符号转换
                        TempVal = TempVal + ',';
                    }
                    else if (TempStr == "。") {
                        TempVal = TempVal + '.';
                    }
                    else {
                        TempVal = TempVal + TempStr;
                    }
                    TempStr = "";
                }
            }
            return TempVal;
        }
        else {
            return me.toString();
        }
    }
}

String.prototype.TranslateAll = function (Sorder) {
    var me = this;
    if (me != undefined) {
        var language = $.cookie('language');
        if (language == "English") {

            var TempVal = "";
            var TempStr = "";
            var Sval = me.toString();
            var isTanslate = false;
            $.each(dict, function (a1, b1) {
                if (b1.Key == Sval) {
                    TempVal = b1.Value;
                    isTanslate = true;
                    return false;
                }
            })
            if (isTanslate) {
                return TempVal;
            }
            else {
                return me.toString();
            }
        }
        else {
            return me.toString();
        }
    }
}