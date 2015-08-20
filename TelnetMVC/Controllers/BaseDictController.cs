using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;
using System.Text;
using Newtonsoft.Json.Converters;

namespace TelnetMVC.Controllers
{
    public class BaseDictController : BaseController
    {
        //
        // GET: /BaseDict/

        public ActionResult Index()
        {
            UserSession userSession = GetUserSession();
            //List<BaseDict> baseDictList = BllFactory.baseDictBll.getSearchList(o => o.OrgCode ==userSession.orgDict.Id).ToList<BaseDict>();
            List<BaseDict> baseDictList = SYSCacheDict.GetBaseDictList().FindAll(o=>o.OrgCode==userSession.orgDict.Id);
            return View(baseDictList);
        }

        public ActionResult IndexList()
        {
            return View();
        }

        public ActionResult Create(BaseDict basedict)
        {
            UserSession userSession = GetUserSession();
            basedict.Id = Guid.NewGuid().ToString();
            basedict.OrgCode = userSession.orgDict.Id;
            basedict.CreateTime = DateTime.Now;
            basedict.Creator = userSession.user.Id;
            if (BllFactory.baseDictBll.add(basedict))
            {
                SYSCacheDict.RefreshCache();
            }
            return View();
        }
        public ActionResult GetBaseDict()
        {
            List<BaseDict> baseDictList = SYSCacheDict.GetBaseDictList();
            return Content(JsonHelper.Serialize(baseDictList));
        }
        /// <summary> 分页查询
        /// </summary>
        /// <param name="pageSave"></param>
        /// <returns></returns>
        public JsonResult GetBaseDictByPage(string pageIndex)
        {
            int total=0;
            List<BaseDict> baseDictList = BllFactory.baseDictBll.getSearchListByPage(o => o.Id != null, 3, Convert.ToInt32(pageIndex), ref total).ToList<BaseDict>();

            

            ResultJson resultJson = new ResultJson();
            resultJson.Success = true;
            resultJson.Data = baseDictList;
            resultJson.Total = total;

            return Json(resultJson, JsonRequestBehavior.AllowGet);
        }
        /// <summary>字典翻译 
        /// </summary>
        /// <param name="dictKey"></param>
        /// <param name="dictName"></param>
        /// <returns></returns>
        public JsonResult GetDictValue(string dictKey,string dictName)
        {
            BaseDict baseDict = BllFactory.baseDictBll.getSearchList(o => o.DictName == dictName && o.DictKey == dictKey).FirstOrDefault();
            ResultJson resultJson = new ResultJson();

            if (baseDict == null)
            {
                resultJson.Success = false;
                resultJson.ErrorMsg = "未找到字典值";
            }
            else
            {
                resultJson.Data = baseDict;
            }

            return Json(resultJson, JsonRequestBehavior.AllowGet);
        }

        /// <summary> 字典返回结果集
        /// </summary>
        /// <param name="dictConfig"></param>
        /// <returns></returns>
        public ActionResult GetDictAllRows(string dictConfig)
        {
            UserSession userSession = GetUserSession();
            StringBuilder sb = new StringBuilder();

            string[] dictList = dictConfig.Split(',');
            foreach (string dict in dictList)
            {
                string[] configList = dict.Split(';');

                List<BaseDict> baseDictList = SYSCacheDict.GetBaseDictList().FindAll(o => o.OrgCode == userSession.orgDict.Id && o.DictName == configList[0]);
                
                sb.Append("var " + configList[0] + "=" + JsonHelper.SerializeObject(baseDictList) + ";");
            }
            return Content(sb.ToString());
        }
    }
}
