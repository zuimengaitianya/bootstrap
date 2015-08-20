using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;
using Newtonsoft.Json;

namespace TelnetMVC.BLL
{
    /// <summary>
    /// 系统缓存
    /// </summary>
    public static class SYSCacheDict
    {
        /// <summary>
        /// 获取机构缓存
        /// </summary>
        /// <returns></returns>
        public static List<OrgDict> GetOrgDictList()
        {
            var temp = MemcacheHelper.Get("OrgDict");
            if (temp == null)
            {
                List<OrgDict> OrgDictTemp = BllFactory.orgDictBll.getSearchList(o => o.Id != null).ToList<OrgDict>();
                MemcacheHelper.Set("OrgDict", OrgDictTemp);
                return OrgDictTemp;
            }
            else
            {
                return temp as List<OrgDict>;
            }
        }
        /// <summary>
        /// 获取科室缓存
        /// </summary>
        /// <returns></returns>
        public static List<DeptDict> GetDeptDictList()
        {
            var temp = MemcacheHelper.Get("DeptDict");
            if (temp == null)
            {
                List<DeptDict> deptDictTemp = BllFactory.deptDictBll.getSearchList(o => o.Id != null).ToList<DeptDict>();
                MemcacheHelper.Set("DeptDict", deptDictTemp);
                return deptDictTemp;
            }
            else
            {
                return temp as List<DeptDict>;
            }
        }
        /// <summary>
        /// 获取角色缓存
        /// </summary>
        /// <returns></returns>
        public static List<RoleDict> GetRoleDictList()
        {
            var temp = MemcacheHelper.Get("RoleDict");
            if (temp == null)
            {
                List<RoleDict> roleDictTemp = BllFactory.roleDictBll.getSearchList(o => o.Id != null).ToList<RoleDict>();
                MemcacheHelper.Set("RoleDict", roleDictTemp);
                return roleDictTemp;
            }
            else
            {
                return temp as List<RoleDict>;
            }
        }
        /// <summary>
        /// 获取基础字典缓存
        /// </summary>
        /// <returns></returns>
        public static List<BaseDict> GetBaseDictList()
        {
            var temp = MemcacheHelper.Get("BaseDict");
            if (temp == null)
            {
                List<BaseDict> baseDictTemp = BllFactory.baseDictBll.getSearchList(o => o.Id != null).ToList<BaseDict>();
                MemcacheHelper.Set("BaseDict", baseDictTemp);
                return baseDictTemp;
            }
            else
            {
                return temp as List<BaseDict>;
            }
        }
        /// <summary>
        /// 获取用户缓存
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUserList()
        {
            var temp = MemcacheHelper.Get("User");
            if (temp == null)
            {
                List<User> userTemp = BllFactory.userBll.getSearchList(o => o.Id != null).ToList<User>();
                MemcacheHelper.Set("User", userTemp);
                return userTemp;
            }
            else
            {
                return temp as List<User>;
            }
        }
        /// <summary>
        /// 缓存刷新
        /// </summary>
        /// <returns></returns>
        public static bool RefreshCache()
        {
            List<OrgDict> OrgDictTemp = BllFactory.orgDictBll.getSearchList(o => o.Id != null).ToList<OrgDict>();
            MemcacheHelper.Set("OrgDict", OrgDictTemp);
            List<DeptDict> deptDictTemp = BllFactory.deptDictBll.getSearchList(o => o.Id != null).ToList<DeptDict>();
            MemcacheHelper.Set("DeptDict", deptDictTemp);
            List<RoleDict> roleDictTemp = BllFactory.roleDictBll.getSearchList(o => o.Id != null).ToList<RoleDict>();
            MemcacheHelper.Set("RoleDict", roleDictTemp);
            List<User> userTemp = BllFactory.userBll.getSearchList(o => o.Id != null).ToList<User>();
            MemcacheHelper.Set("User", userTemp);
            List<BaseDict> baseDictTemp = BllFactory.baseDictBll.getSearchList(o => o.Id != null).ToList<BaseDict>();
            MemcacheHelper.Set("BaseDict", baseDictTemp);
            return true;
        }
        /// <summary>
        /// 刷新机构字典缓存
        /// </summary>
        /// <returns></returns>
        public static bool RefreshOrgDictCache()
        {
            List<OrgDict> OrgDictTemp = BllFactory.orgDictBll.getSearchList(o => o.Id != null).ToList<OrgDict>();
            MemcacheHelper.Set("OrgDict", OrgDictTemp);
            return true;
        }
    }
}
