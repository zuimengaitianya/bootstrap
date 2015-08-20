using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;

namespace TelnetMVC.BLL
{
    public class BaseDictBLL:BaseBLL<BaseDict>
    {
        public static List<BaseDict> baseDictList;
        /// <summary>
        /// 获取静态基础字典数据
        /// </summary>
        /// <returns></returns>
        public static List<BaseDict> GetBaseDictAll()
        {
            if (baseDictList == null)
            {
                baseDictList = BllFactory.baseDictBll.getSearchList(m => m.Id != null).ToList<BaseDict>();
                return baseDictList;
            }
            else
            {
                return baseDictList;
            }
        }
        /// <summary>
        /// 获取静态基础字典数据.(机构)
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public static List<BaseDict> GetBaseDictOrg(string orgId)
        {
            if (baseDictList == null)
            {
                baseDictList = BllFactory.baseDictBll.getSearchList(m => m.OrgCode==orgId).ToList<BaseDict>();
                return baseDictList;
            }
            else
            {
                return baseDictList;
            }
        }
    }
}
