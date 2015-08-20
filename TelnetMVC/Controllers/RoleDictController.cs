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
    public class RoleDictController : BaseController
    {
        //
        // GET: /RoleDict/
        [HttpGet]
        public ActionResult Index()
        {
            UserSession userSession = GetUserSession();
            List<RoleDict> RoleDictList = BllFactory.roleDictBll.getSearchList(m => m.DeptCode == userSession.roleDict.DeptCode).ToList<RoleDict>();
            ViewData["DeptId"] = userSession.deptDict.Id;
            ViewData["OrgId"] = userSession.orgDict.Id;
            return View(RoleDictList);
        }
        [HttpPost]
        public ActionResult Index(string deptId )
        {
            DeptDict deptDict = BllFactory.deptDictBll.getSearchList(m => m.Id == deptId).FirstOrDefault();
            List<RoleDict> RoleDictList = BllFactory.roleDictBll.getSearchList(m => m.DeptCode == deptId).ToList<RoleDict>();
            ViewData["DeptId"] = deptId;
            ViewData["OrgId"] = deptDict.OrgCode;
            return View(RoleDictList);
        }
        public ActionResult Create()
        {
            ViewData["DeptId"] = Request["deptId"].ToString();
            return View();
        }
        public ActionResult NewCreate(RoleDict roleDict)
        {
            roleDict.Id = Guid.NewGuid().ToString();
            roleDict.CreateTime = DateTime.Now;
            BllFactory.roleDictBll.add(roleDict);
            return Content("Success");
        }
        public ActionResult RoleAllotUser(string userId)
        {
            string str = BllFactory.roleDictBll.GetUserRoleAllot(userId);
            return Content(str);
        }

        public ActionResult GetRoleName(string roleId)
        {
            RoleDict roleDict = SYSCacheDict.GetRoleDictList().Where(o => o.Id == roleId).FirstOrDefault();
            if (roleDict == null)
            {
                return Content("");
            }
            else {
                return Content(roleDict.RoleName);
            }
        }
        
    }
}
