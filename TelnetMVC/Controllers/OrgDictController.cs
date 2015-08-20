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
    public class OrgDictController : BaseController
    {
        /// <summary>
        /// 缓存方式展现数据
        /// </summary>
        /// <returns></returns>
        [OutputCache(CacheProfile = "defauleCashe")]
        public ActionResult Index()
        {
            UserSession userSession = GetUserSession();
            List<OrgDict> orgDictList = SYSCacheDict.GetOrgDictList().FindAll(m => m.Id == userSession.orgDict.Id);
            return View(orgDictList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// 新增机构
        /// </summary>
        /// <param name="orgDict"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(OrgDict orgDict)
        {
            orgDict.Id = Guid.NewGuid().ToString();
            orgDict.CreateTime = DateTime.Now;
            BllFactory.orgDictBll.add(orgDict);
            SYSCacheDict.RefreshCache();
            return View();
        }
        public ActionResult setOrgName(string orgId)
        {
            List<OrgDict> orgDictList = BllFactory.orgDictBll.getSearchList(m => m.Id == orgId).ToList<OrgDict>();
            if (orgDictList.Count > 0)
            {
                return Content(orgDictList[0].OrgName);
            }
            else
            {
                return Content("");
            }
        }
    }
}
