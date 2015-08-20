using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Entities;

namespace TelnetMVC.Common
{
    /// <summary>
    /// 缓存数据
    /// </summary>
    public static class CacheHelper
    {
        ///// <summary>
        ///// 获取机构
        ///// </summary>
        ///// <returns></returns>
        //public static List<OrgDict> GetOrgDictList()
        //{
        //    var temp = MemcacheHelper.Get("OrgDict");
        //    if (temp == null)
        //    {
        //        List<OrgDict> OrgDictTemp = BllFactory.orgDictBll.getSearchList(o => o.Id != null).ToList<OrgDict>();
        //        MemcacheHelper.Set("OrgDict", OrgDictTemp);
        //        return OrgDictTemp;
        //    }
        //    else
        //    {
        //        return temp as List<OrgDict>;
        //    }
        //}
    }
}
