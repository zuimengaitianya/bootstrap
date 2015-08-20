function mypostion(o) {
    var width = $(window).width();
    var height = $(window).height();
    var divW = $(o).outerWidth();
    var divH = $(o).outerHeight();
    var left = (width - divW) / 2 + $(window).scrollLeft();
    var top = (height - divH) / 2 + $(window).scrollTop();
    return { "left": left, "top": top };
};

function myTips(msg, status) {
    var language = $.cookie('language');
    if (language == "English") {
        msg = msg.Translate();
    }
    if (status != "success" && status != "error") {
        status = "error";
    };
    if (status == "success") {
        $("body").append('<div class="ui-mask" id="ui-mask"></div><div class="change_success" id="change_success"><i></i>' + msg + '</div>');
        var my = mypostion("#change_success");
        $("#change_success").css({ "position": "absolute", "z-index": "9999999", "top": my.top + "px", "left": my.left + "px" });
        $("#ui-mask").show();
        $("#change_success").show();
        setTimeout(function () {
            $("#change_success,#ui-mask").fadeOut("slow", function () {
                $("#ui-mask").remove();
                $("#change_success").remove();
            });
        }, 1000);
    } else {
        $("body").append('<div class="ui-mask" id="ui-mask"></div><div class="change_error" id="change_error"><i></i>' + msg + '</div>');
        var my = mypostion("#change_error");
        $("#change_error").css({ "position": "absolute", "z-index": "9999999", "top": my.top + "px", "left": my.left + "px" });
        $("#ui-mask").show();
        $("#change_error").show();
        setTimeout(function () {
            $("#change_error,#ui-mask").fadeOut("slow", function () {
                $("#ui-mask").remove();
                $("#change_error").remove();
            });
        }, 1000);
    };
};

function myTips(msg, status, timeout) {
    var language = $.cookie('language');
    if (language == "English") {
        msg = msg.Translate();
    }
    if (status != "success" && status != "error") {
        status = "error";
    };
    if (status == "success") {
        $("body").append('<div class="ui-mask" id="ui-mask"></div><div class="change_success" id="change_success"><i></i>' + msg + '</div>');
        var my = mypostion("#change_success");
        $("#change_success").css({ "position": "absolute", "z-index": "9999999", "top": my.top + "px", "left": my.left + "px" });
        $("#ui-mask").show();
        $("#change_success").show();
        setTimeout(function () {
            $("#change_success,#ui-mask").fadeOut("slow", function () {
                $("#ui-mask").remove();
                $("#change_success").remove();
            });
        }, timeout);
    } else {
        $("body").append('<div class="ui-mask" id="ui-mask"></div><div class="change_error" id="change_error"><i></i>' + msg + '</div>');
        var my = mypostion("#change_error");
        $("#change_error").css({ "position": "absolute", "z-index": "9999999", "top": my.top + "px", "left": my.left + "px" });
        $("#ui-mask").show();
        $("#change_error").show();
        setTimeout(function () {
            $("#change_error,#ui-mask").fadeOut("slow", function () {
                $("#ui-mask").remove();
                $("#change_error").remove();
            });
        }, timeout);
    };
};