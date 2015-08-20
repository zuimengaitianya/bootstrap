using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;
using Newtonsoft.Json;

namespace TelnetMVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            UserSession userSession=(UserSession)MemcacheHelper.Get(Request.Cookies["sessionId"].Value);
            List<User> userList = BllFactory.userBll.getSearchList(o => o.OrgId == userSession.orgDict.Id).ToList<User>();
            //List<User> userList = BllFactory.userBll.getSearchList(o => o.Id != null).ToList<User>();
            return View(userList);
        }
        public ActionResult GetUserSingle(string term)
        {
            return Content(BllFactory.userBll.GetUserSingle(term));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult NewCreate(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid().ToString();
                user.CreateTime = DateTime.Now;
                BllFactory.userBll.add(user);
                return Content("Success");
            }
            else
            {
                return Content("Error");
            }
        }
        public JsonResult ValidateUserName(string userName)
        {
            bool result = true;
            if (userName == "admin")
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SelectUser()
        {
            return View();
        }
        public ActionResult GetUserName(string userId)
        {
            User user = SYSCacheDict.GetUserList().Where(o => o.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return Content("");
            }
            else
            {
                return Content(user.UserName);
            }
        }
    }
}
