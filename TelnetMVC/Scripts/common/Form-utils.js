var StringUtils = StringUtils || {};

/**
 * 转为 Json
 */
StringUtils.toJson = function (jsonString) {
    if (StringUtils.isNotEmpty(jsonString)) {
        return eval('(' + jsonString + ')');
    }
    return null;
};

StringUtils.toJsonString = function (jsonObject) {
    if (!StringUtils.isEmptyJson(jsonObject)) {
        return JSON.stringify(jsonObject);
    }
    return "{}";
};
/**
 * 非空?
 */
StringUtils.isNotEmpty = function (obj) {
    return !StringUtils.isEmpty(obj);

};

/**
 * 空?
 */
StringUtils.isEmpty = function (obj) {
    return (typeof obj == "undefined" || obj == null || obj == "");

};

StringUtils.isEmptyJson = function (json) {
    return StringUtils.isEmpty(json) || jQuery.isEmptyObject(json);
};

StringUtils.isAlphabets = function (s) {
    var regu = "^[A-Z]+$";
    var re = new RegExp(regu);
    if (s.toUpperCase().search(re) != -1) {
        return true;
    }
    return false;
};

StringUtils.isValidEmail = function (email) {
    var emailReg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
    return emailReg.test(email);
};


var FormUtils = FormUtils || {};

//Post方式提交表单  
FormUtils.postSubmit = function (url, data, newWindow) {

    if (StringUtils.isNotEmpty(url) && !StringUtils.isEmptyJson(data)) {

        if (newWindow) {

            var www = window.open("", "_blank", "");
            //console.log(www);

            www.document.write("<html>");
            www.document.write("<head>");
            www.document.write("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />");
            www.document.write("<meta http-equiv='X-UA-Compatible' content='IE=edge' />");

            www.document.write("<meta http-equiv='pragma' content='no-cache' />");
            www.document.write("<meta http-equiv='Cache-Control' content='no-cache, must-revalidate' />");
            www.document.write("<meta http-equiv='Expires' content='0' />");

            www.document.write("<meta charset='utf-8'>");

            www.document.write("<style>");
            www.document.write("body{TEXT-ALIGN: center;}");
            www.document.write("#center{");
            www.document.write("MARGIN-RIGHT: auto; ");
            www.document.write("MARGIN-LEFT: auto; ");
            www.document.write("height: 600px;");
            www.document.write("background: #fafafa;");
            www.document.write("width: 1000px;");
            www.document.write("vertical-align:middle;");
            www.document.write("line-height:600px;");
            www.document.write("</style>");

            www.document.write("<script type='text/javascript'>");

            www.document.write("function doSubmit(){");

            //www.document.write("alert('oye!');");

            www.document.write("var ExportForm = document.createElement('FORM');");
            www.document.write("ExportForm.method = 'POST';");
            www.document.write("var newElement = document.createElement('input');");
            www.document.write("newElement.setAttribute('name', 'p');");
            www.document.write("newElement.setAttribute('type', 'hidden');");
            www.document.write("newElement.value = '" + encodeURI(data) + "';");
            //www.document.write("newElement.value = '" + data + "';");
            www.document.write("ExportForm.action = '" + url + "';");
            www.document.write("ExportForm.appendChild(newElement);");
            www.document.write("document.body.appendChild(ExportForm);");
            www.document.write("ExportForm.submit();");//提交

            www.document.write("};");
            www.document.write("</script>");

            www.document.write("</head>");

            www.document.write("<body style='background-color: #fafafa;'>");

            www.document.write("<div id='center'><h3>正在加载 ...</h3></div>");

            www.document.write("<script>doSubmit();</script>");//调用JS

            www.document.write("</body>");
            www.document.write("</html>");

        } else {

            var ExportForm = document.createElement("FORM");

            ExportForm.method = "POST";

            //var newElement = document.createElement("input");
            //newElement.setAttribute("name", "p");
            //newElement.setAttribute("type", "hidden");

            //newElement.value = data;
            $.each(data, function (k, v) {
                var newParamElement = document.createElement("input");
                newParamElement.setAttribute("name", k);
                newParamElement.value = v;
                newParamElement.setAttribute("type", "hidden");
                ExportForm.appendChild(newParamElement);
            })
            ExportForm.action = url;

            //ExportForm.appendChild(newElement);
            document.body.appendChild(ExportForm);

            ExportForm.submit();

        }

    } else {
        console.log("参数不完整 --> url = " + url + "; data = " + data);
    }





};
