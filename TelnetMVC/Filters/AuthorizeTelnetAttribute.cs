using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Specialized;
using TelnetMVC.Entities;
using TelnetMVC.Common;
using TelnetMVC.BLL;

namespace TelnetMVC.Filters
{
    public class AuthorizeTelnetAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 验证授权。
        /// </summary>
        /// <param name="httpContext">HTTP 上下文，它封装有关单个 HTTP 请求的所有 HTTP 特定的信息。</param>
        /// <returns>如果用户已经过授权，则为 true；否则为 false。</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                return false;
            }
            else
            {
                string targetUrl = httpContext.Request.Path.ToLower();
                string seisionId = httpContext.Request["sessionId"] == null ? "" : httpContext.Request["sessionId"];
                if (seisionId == "")
                {
                    httpContext.Response.StatusCode = 403;
                    return false;
                }
                else
                {
                    //查找资源
                    List<Resources> ResourceAllots = (List<Resources>)MemcacheHelper.Get(seisionId + "Resources");
                    // 匹配资源
                    foreach (Resources urlPatten in ResourceAllots)
                    {
                        if (PathMatcher.Match(urlPatten, targetUrl))
                        {
                            return true;
                        }
                    }
                    //// 匹配权限
                    //foreach (String urlPatten in loginInformation.AuthUrl)
                    //{
                    //    if (PathMatcher.Match(urlPatten.ToLower(), targetUrl))
                    //    {
                    //        return true;
                    //    }
                    //}
                    //httpContext.Response.StatusCode = 600;
                    //return false;
                    httpContext.Response.StatusCode = 600;
                    return false;
                }
            }
        }

        /// <summary>
        /// 重写验证。
        /// </summary>
        /// <param name="filterContext">验证信息上下文。</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //从cookie中获取咱们的 登录的sessionId
            string sessionId = filterContext.HttpContext.Request["sessionId"];
            if (string.IsNullOrEmpty(sessionId))
            {
                //return RedirectToAction("Login", "Logon");
                filterContext.HttpContext.Response.Redirect("/Logon/Index");
            }

            object obj = MemcacheHelper.Get(sessionId);
            User user = obj as User;
            if (user == null)
            {
                filterContext.HttpContext.Response.Redirect("/Logon/Index");
            }

            MemcacheHelper.Set(sessionId, user);

            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {

                    ResultJson result = new ResultJson();
                    result.Success = false;
                    result.ErrorMsg = "登陆超时，请重新登陆！";

                    JsonResult json = new JsonResult();
                    json.Data = result;
                    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = json;
                }
                else
                {
                    //// 获取当前登录的种类
                    //LoginType loginType = BLLFactory.LoginTypeBLL.GetEntityBySessionID(filterContext.RequestContext.HttpContext.Session.SessionID);
                    //string loginUrl = "~/Login/Index";
                    //if (loginType != null)
                    //{
                    //    if (!string.IsNullOrEmpty(loginType.SessionLoginType))
                    //    {
                    //        loginUrl = "~/Login/" + loginType.SessionLoginType + "Login";
                    //    }
                    //}

                    //filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.ToString()));
                }
            }
            else if (filterContext.HttpContext.Response.StatusCode == 600)
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {

                    ResultJson result = new ResultJson();
                    result.Success = false;
                    result.ErrorMsg = "未进行授权，不允许操作！";

                    JsonResult json = new JsonResult();
                    json.Data = result;
                    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = json;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login/AccessError" + "?returnUrl=" + HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.ToString()));
                }
            }
        }
    }
    /// <summary>
    /// 资源匹配
    /// </summary>
    public static class PathMatcher
    {
        public static bool Match(Resources urlPatten, string targetUrl)
        {
            if (targetUrl == urlPatten.ResourcesController + urlPatten.ResourcesName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}