using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;

namespace TelnetMVC.BLL
{
    public class UserBLL : BaseBLL<User>
    {
        /// <summary>
        /// 查询员工
        /// </summary>
        /// <param name="skey"></param>
        /// <returns></returns>
        public string GetUserSingle(string skey)
        {
            StringBuilder result = new StringBuilder();
            List<User> UserList = getSearchList(m => m.TrueName.Contains(skey)).ToList<User>();
            if (UserList.Count > 0)
            {
                result.Append("[");
                int i = 0;
                string adAccount = "";
                foreach (User e in UserList)
                {
                    if (i > 0)
                        result.Append(",{");
                    else
                        result.Append("{");

                    adAccount = e.TrueName;
                    if (adAccount.IndexOf("\\") > 0)
                    {
                        adAccount = adAccount.Substring(adAccount.IndexOf("\\") + 1, adAccount.Length - adAccount.IndexOf("\\") - 1);
                        adAccount += "(" + e.TrueName+ ")";
                    }

                    result.AppendFormat("\"label\":\"{0}\",\"value\":\"{1}\"", adAccount, e.Id);
                    result.Append("}");
                    i++;
                }
                result.Append("]");
            }
            return result.ToString();
        }
        /// <summary>
        /// 查询当前登录角色缓存
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserSession GetUserSession(User user, UserRoleAllot userRoleAllot)
        {
            UserSession userSession = new UserSession();
            userSession.user = user;

            userSession.orgDict = BllFactory.orgDictBll.getSearchList(o => o.Id == userRoleAllot.OrgId).FirstOrDefault();//当前登录机构
            userSession.deptDict = BllFactory.deptDictBll.getSearchList(o => o.Id == userRoleAllot.DeptId).FirstOrDefault();//当前登录科室
            userSession.roleDict = BllFactory.roleDictBll.getSearchList(o => o.Id == userRoleAllot.RoleId).FirstOrDefault();//当前登录角色
            userSession.powers = BllFactory.powerAllotBll.GetUserRolePower(userRoleAllot.RoleId);//当前登录角色权限
            userSession.resourcess = BllFactory.resourceAllotBll.GetUserRoleResources(userRoleAllot.RoleId);//当前登录角色资源

            return userSession;
        }
    }
}
