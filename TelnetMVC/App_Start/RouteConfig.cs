using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TelnetMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.asmx/{*pathInfo}");//webservice地址不用mvc路由寻址方式

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "Default", // 路由名称
            //    url: "{controller}/{action}/{id}", // 带有参数的 URL
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }, // 参数默认值
            //                //设置匹配约束
            //    new
            //    {
            //        controller = "^H.*",
            //        action = "^Index$|^About&", 　　　　//必须要被正则表达式成功匹配，才使用该路由
            //        httpMethod = new HttpMethodConstrain("Get")
            //    } 　　//指定只使用Get方法的请求才会被匹配
            //);
        }
    }
}