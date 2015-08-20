using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;
using System.Linq.Expressions;

namespace TelnetMVC.UIControl
{
    public static class DictExtensions
    {
        /// <summary>
        /// 机构字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TDict">字典</param>
        /// <returns></returns>
        public static MvcHtmlString GetOrgDictList(this HtmlHelper helper, string TKey)
        {
            List<OrgDict> orgDictList = SYSCacheDict.GetOrgDictList();
            StringBuilder sb = new StringBuilder();

            sb.Append("<select>");
            foreach (OrgDict model in orgDictList)
            {
                if (model.Id == TKey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\">" + model.OrgName + "</option>");
                }
                sb.Append("<option value=\"" + model.Id + "\">" + model.OrgName + "</option>");
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 机构字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static MvcHtmlString GetOrgDictList(this HtmlHelper helper, string TKey, Func<OrgDict, bool> where)
        {
            IEnumerable<OrgDict> orgDictList = SYSCacheDict.GetOrgDictList().Where(where);
            StringBuilder sb = new StringBuilder();

            sb.Append("<select>");
            foreach (OrgDict model in orgDictList)
            {
                if (model.Id == TKey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\">" + model.OrgName + "</option>");
                }
                sb.Append("<option value=\"" + model.Id + "\">" + model.OrgName + "</option>");
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 机构字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TDict">字典</param>
        /// <param name="TOther">其他属性</param>
        /// <returns></returns>
        public static MvcHtmlString GetOrgDictList(this HtmlHelper helper, string TKey,object TOther)
        {
            List<OrgDict> orgDictList = SYSCacheDict.GetOrgDictList();
            StringBuilder sb = new StringBuilder();

            string tempstr = TOther.ToString().Remove(0, 1);
            tempstr = tempstr.Remove(tempstr.Length - 1, 1);

            sb.Append("<select " + tempstr + " >");
            sb.Append("<option></option>");
            foreach (OrgDict model in orgDictList)
            {
                if (model.Id == TKey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\">" + model.OrgName + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.Id + "\">" + model.OrgName + "</option>");
                }
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 机构字典名称
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetOrgDictName(this HtmlHelper helper, string TKey)
        {
            if (TKey != null)
            {
                List<OrgDict> orgDictList = SYSCacheDict.GetOrgDictList().FindAll(m=>m.Id==TKey);
                StringBuilder sb = new StringBuilder();

                sb.Append("");
                if (orgDictList.Count > 0)
                {
                    sb.Append(orgDictList[0].OrgName);
                }

                return new MvcHtmlString(sb.ToString());
            }
            else
            {
                return new MvcHtmlString("");
            }
        }
        /// <summary>
        /// 科室字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TDict">字典</param>
        /// <returns></returns>
        public static MvcHtmlString GetDeptDictList(this HtmlHelper helper, string TKey)
        {
            List<DeptDict> deptDictList = SYSCacheDict.GetDeptDictList();
            StringBuilder sb = new StringBuilder();

            sb.Append("<select class=\"form-control\" >");
            foreach (DeptDict model in deptDictList)
            {
                if (model.Id == TKey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\" >" + model.DeptName + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.Id + "\">" + model.DeptName + "</option>");
                }
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 科室字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TOther">其他属性</param>
        /// <returns></returns>
        public static MvcHtmlString GetDeptDictList(this HtmlHelper helper, string TKey,object TOther)
        {
            List<DeptDict> deptDictList = SYSCacheDict.GetDeptDictList();
            StringBuilder sb = new StringBuilder();

            sb.Append("<select "+TOther.ToString()+" class=\"form-control\" >");
            foreach (DeptDict model in deptDictList)
            {
                if (model.Id == TKey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\" >" + model.DeptName + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.Id + "\">" + model.DeptName + "</option>");
                }
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 科室用户字典
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="deptDictList"></param>
        /// <returns></returns>
        public static MvcHtmlString GetDeptDictList(this HtmlHelper helper, List<DeptDict> deptDictList)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<select class=\"form-control\" >");
            foreach (DeptDict model in deptDictList)
            {
                sb.Append("<option value=\"" + model.Id + "\">" + model.DeptName + "</option>");
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 科室字典名称
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetDeptDictName(this HtmlHelper helper, string TKey)
        {
            List<DeptDict> deptDictList = SYSCacheDict.GetDeptDictList().FindAll(m=>m.Id==TKey);
            StringBuilder sb = new StringBuilder();

            if (deptDictList.Count > 0)
            {
                sb.Append(deptDictList[0].DeptName);
            }

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 角色字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="Tkey">键</param>
        /// <returns></returns>
        public static MvcHtmlString GetRoleDictList(this HtmlHelper helper, string Tkey)
        {
            List<RoleDict> roleDictList = SYSCacheDict.GetRoleDictList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<select  class=\"form-control\" >");
            foreach (RoleDict model in roleDictList)
            {
                if (model.Id == Tkey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\" >" + model.RoleName + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.Id + "\" >" + model.RoleName + "</option>");
                }
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 角色字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="Tkey"></param>
        /// <param name="TOther"></param>
        /// <returns></returns>
        public static MvcHtmlString GetRoleDictList(this HtmlHelper helper, string Tkey,object TOther)
        {
            List<RoleDict> roleDictList = SYSCacheDict.GetRoleDictList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<select " + TOther.ToString()+ " class=\"form-control\" >");
            foreach (RoleDict model in roleDictList)
            {
                if (model.Id == Tkey)
                {
                    sb.Append("<option value=\"" + model.Id + "\" selected=\"selected\">" + model.RoleName + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.Id + "\">" + model.RoleName + "</option>");
                }
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 角色字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="userRoleAllt"></param>
        /// <returns></returns>
        public static MvcHtmlString GetRoleDictList(this HtmlHelper helper, List<RoleDict> userRoleAllt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class=\"form-control\" >");
            foreach (RoleDict model in userRoleAllt)
            {
                sb.Append("<option value=\"" + model.Id + "\">" + model.RoleName + "</option>");
            }
            sb.Append("</select>");

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 角色字典名称
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetRoleDictName(this HtmlHelper helper, string TKey)
        {
            List<RoleDict> roleDictList = SYSCacheDict.GetRoleDictList().FindAll(m=>m.Id==TKey);
            StringBuilder sb = new StringBuilder();
            if (roleDictList.Count > 0)
            {
                sb.Append(roleDictList[0].RoleName);
            }

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 用户字典名称
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey"></param>
        /// <returns></returns>
        public static MvcHtmlString GetUserName(this HtmlHelper helper, string TKey)
        {
            List<User> userList = SYSCacheDict.GetUserList().FindAll(m => m.Id == TKey);
            StringBuilder sb = new StringBuilder();
            if (userList.Count > 0)
            {
                sb.Append(userList[0].UserName);
            }
            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 基本字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TDictName">字典名称</param>
        /// <returns></returns>
        public static MvcHtmlString GetBaseDictList(this HtmlHelper helper, string TKey,string TDictName)
        {
            List<BaseDict> baseDictList = SYSCacheDict.GetBaseDictList().FindAll(m => m.DictName == TDictName);

            StringBuilder sb = new StringBuilder();
            sb.Append("<select class=\"form-control\" >");
            foreach (BaseDict model in baseDictList)
            {
                if (model.DictKey == TKey)
                {
                    sb.Append("<option value=\"" + model.DictKey + "\" selected=\"selected\" >" + model.DictValue + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.DictKey + "\">" + model.DictValue + "</option>");
                }
            }
            sb.Append("</select>");
            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 基本字典用户控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TDictName">字典名称</param>
        /// <param name="TOther">其他属性</param>
        /// <returns></returns>
        public static MvcHtmlString GetBaseDictList(this HtmlHelper helper, string TKey, string TDictName,object TOther)
        {
            List<BaseDict> baseDictList = SYSCacheDict.GetBaseDictList().FindAll(m => m.DictName == TDictName);
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class=\"form-control\" "+TOther.ToString()+" >");
            foreach (BaseDict model in baseDictList)
            {
                if (model.DictKey == TKey)
                {
                    sb.Append("<option value=\"" + model.DictKey + "\" selected=\"selected\" >" + model.DictValue + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + model.DictKey + "\">" + model.DictValue + "</option>");
                }
            }
            sb.Append("</select>");
            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 基本字典名称
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="TKey">键</param>
        /// <param name="TDictName">字典名称</param>
        /// <returns></returns>
        public static MvcHtmlString GetBaseDictName(this HtmlHelper helper, string TKey,string TDictName)
        {
            List<BaseDict> baseDictList = SYSCacheDict.GetBaseDictList().FindAll(m => m.DictName == TDictName && m.DictKey==TKey);
            StringBuilder sb = new StringBuilder();
            if (baseDictList.Count > 0)
            {
                sb.Append(baseDictList[0].DictValue);
            }

            return new MvcHtmlString(sb.ToString());
        }
        /// <summary>
        /// 权限验证方式
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="authorization"></param>
        /// <returns></returns>
        public static MvcHtmlString AuthButton(this HtmlHelper helper, string authorization)
        {
            string sessionId = HttpContext.Current.Request["sessionId"];
            UserSession userSession = MemcacheHelper.Get(sessionId) as UserSession;
            if (userSession.powers.Select(m=>m.PowerName==authorization).Count()>0)
            {
                return new MvcHtmlString("");
            }
            else
            {
                return new MvcHtmlString("");
            }
        }
    }
}