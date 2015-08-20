using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;

namespace TelnetMVC.Controllers
{
    public class UserAllotController : BaseController
    {
        //
        // GET: /UserAllot/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据角色获取分发用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult GetUserAllotByRole(string roleId)
        {
            List<User> userList = BllFactory.userRoleAllotBll.GetUserAllotByRole(roleId);

            return Content(JsonHelper.SerializeObject(userList));
        }
        public ActionResult GetUserNoAllotByRole(string roleId)
        {
            List<User> userList = BllFactory.userRoleAllotBll.GetUserNoAllotByRole(roleId);
            return Content(JsonHelper.SerializeObject(userList));
        }

    }
}
