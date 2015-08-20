using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelnetMVC.Filters;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;

namespace TelnetMVC.Controllers
{
    //[AuthorizeTelnet]
    /// <summary>
    /// 基础控制器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public UserSession GetUserSession()
        {
            UserSession userSession = (UserSession)MemcacheHelper.Get(Request.Cookies["sessionId"].Value);
            return userSession;
        }
        

    }
}
