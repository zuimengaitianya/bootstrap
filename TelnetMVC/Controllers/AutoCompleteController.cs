using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;
using System.Text;
using Newtonsoft.Json;

namespace TelnetMVC.Controllers
{
    public class AutoCompleteController : BaseController
    {
        //
        // GET: /AutoComplete/

        public ActionResult Index()
        {
            string stype = Request["stype"];

            return View();
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public JsonResult Users(string userName)
        {
            StringBuilder result = new StringBuilder();
            List<User> userList = SYSCacheDict.GetUserList().Where(o => o.UserName.Contains(userName)).ToList<User>();
            List<AutoCompleteUserResult> autoCompleteUserResultList = new List<AutoCompleteUserResult>();
            if (userList.Count > 0)
            {
                foreach (var Item in userList)
                {
                    AutoCompleteUserResult autoCompleteUserResult = new AutoCompleteUserResult();
                    autoCompleteUserResult.label = Item.UserName;
                    autoCompleteUserResult.value = Item.Id;
                    autoCompleteUserResultList.Add(autoCompleteUserResult);
                }

            }

            var res = new JsonResult();
            res.Data = autoCompleteUserResultList;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return res;
        }

    }
    public class AutoCompleteUserResult
    {
        public string label { get; set; }
        public string value { get; set; }
    }
}
