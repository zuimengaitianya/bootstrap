using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;
using Newtonsoft.Json;

namespace TelnetMVC.Controllers
{
    public class DeptDictController : BaseController
    {
        DeptDictBLL deptDictBll = new DeptDictBLL();
        public ActionResult Index()
        {
            UserSession userSession = GetUserSession();
            List<DeptDict> deptDictList = BllFactory.deptDictBll.getSearchList(o => o.OrgCode == userSession.orgDict.Id).ToList<DeptDict>();
            return View(deptDictList);
        }
        //
        // GET: /DeptDict/
        /// <summary>
        /// 缓存方式展现数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [OutputCache(CacheProfile = "defauleCashe")]
        public ActionResult Index(string orgId)
        {
            List<DeptDict> deptDictList = deptDictBll.getSearchList(m => m.OrgCode==orgId).ToList<DeptDict>();
            
            ViewData["OrgId"] = orgId;
            return View(deptDictList);
        }
        public ActionResult Create(string orgId)
        {
            ViewData["OrgId"] = orgId;
            return View();
        }
        public ActionResult NewCreate(DeptDict deptDict)
        {
            deptDict.Id = Guid.NewGuid().ToString();
            deptDict.CreateTime = DateTime.Now;
            deptDictBll.add(deptDict);
            return Content("Success");
        }
        public ActionResult setDeptName(string deptId)
        {
            List<DeptDict> deptDictList = BllFactory.deptDictBll.getSearchList(m => m.Id == deptId).ToList<DeptDict>();
            if (deptDictList.Count > 0)
            {
                return Content(deptDictList[0].DeptName);
            }
            else
            {
                return Content("");
            }
        }
        public ActionResult GetDictAllRows(string dictConfig)
        {
            if (string.IsNullOrEmpty(dictConfig))
                return Content("");
            string[] dictList = dictConfig.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (string dict in dictList)
            {
                string[] configList = dict.Split(';');
                List<DeptDict> deptDictList = BllFactory.deptDictBll.getSearchList(m => m.Id == configList[0]).ToList<DeptDict>();
                sb.Append("var "+configList[0]+"="+JsonConvert.SerializeObject(deptDictList)+";");
            }
            return Content(sb.ToString());
        }
        public ActionResult EFsearchList()
        {
            string str = BllFactory.deptDictBll.seachList();
            return Content(str);
        }
        public ActionResult EFSQLsearchList()
        {
            string str = BllFactory.deptDictBll.seachDeptList();
            return Content(str);
        }
    }
}
