using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelnetMVC.UIControl
{
    public static class LabelExtensions
    {
        public static MvcHtmlString LKLabel(this HtmlHelper helper, string fortarget, string text)
        {
            string str = String.Format("<label for='{0}'>{1}</label>", fortarget, text);
            return new MvcHtmlString(str);
        }
    }
}