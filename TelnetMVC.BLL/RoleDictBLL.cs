using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;

namespace TelnetMVC.BLL
{
    public class RoleDictBLL : BaseBLL<RoleDict>
    {
        /// <summary>
        /// 获取用户角色分发
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserRoleAllot(string userId)
        {
            User user=SYSCacheDict.GetUserList().Where(o=>o.Id==userId).FirstOrDefault();
            //List<RoleDict> roleDictList = getSearchList(o => o.OrgCode == user.OrgId).ToList<RoleDict>();
            //List<UserRoleAllot> userRoleAllotList = BllFactory.userRoleAllotBll.getSearchList(o => o.UserId == userId).ToList<UserRoleAllot>();


            //var paramList;
            using (TelnetContext context = new TelnetContext())
            {
               var  paramList = (from roleDictList in context.RoleDicts.Where(o=>o.OrgCode==user.OrgId)
                                 join userRoleAllotList in context.UserRoleAllots.Where(o=>o.UserId==userId) on roleDictList.Id equals userRoleAllotList.RoleId
                                 //where roleDictList.OrgCode == user.OrgId
                                 select new
                                 {
                                     roleDict = roleDictList,
                                     userAllotId = userRoleAllotList.Id
                                 });
                if (paramList == null)
                    return null;
                return JsonHelper.SerializeObject(paramList); 
            }
            
        }
    }
}
