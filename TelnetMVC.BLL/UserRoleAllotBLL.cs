using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;

namespace TelnetMVC.BLL
{
    public class UserRoleAllotBLL:BaseBLL<UserRoleAllot>
    {
        /// <summary>
        /// 根据用户ID获取用户分发科室
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<DeptDict> GetUserDeptDict(string userId)
        {
            List<DeptDict> deptDictList = new List<DeptDict>();
            List<UserRoleAllot> userRoleAllotList = getSearchList(o => o.UserId == userId).ToList<UserRoleAllot>();
            foreach (UserRoleAllot Item in userRoleAllotList)
            {
                deptDictList.Add(BllFactory.deptDictBll.getSearchList(o => o.Id == Item.DeptId).FirstOrDefault());
            }
            return deptDictList;
        }
        /// <summary>
        /// 根据分发角色获取分发科室
        /// </summary>
        /// <param name="userRoleAllotList"></param>
        /// <returns></returns>
        public List<DeptDict> GetUserDeptDict(List<UserRoleAllot> userRoleAllotList)
        {
            List<DeptDict> deptDictList = new List<DeptDict>();
            foreach (UserRoleAllot Item in userRoleAllotList)
            {
                deptDictList.Add(BllFactory.deptDictBll.getSearchList(o => o.Id == Item.DeptId).FirstOrDefault());
            }
            return deptDictList;
        }
        /// <summary>
        /// 根据用户ID获取用户分发角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<RoleDict> GetUserRoleDict(string userId)
        {
            List<RoleDict> roleDictList = new List<RoleDict>();
            List<UserRoleAllot> userRoleAllotList = getSearchList(o => o.UserId == userId).ToList<UserRoleAllot>();
            foreach (UserRoleAllot Item in userRoleAllotList)
            {
                roleDictList.Add(BllFactory.roleDictBll.getSearchList(o => o.Id == Item.RoleId).FirstOrDefault());
            }
            return roleDictList;
        }
        /// <summary>
        /// 根据分发角色获取角色
        /// </summary>
        /// <param name="userRoleAllotList"></param>
        /// <returns></returns>
        public List<RoleDict> GetUserRoleDict(List<UserRoleAllot> userRoleAllotList)
        {
            List<RoleDict> roleDictList = new List<RoleDict>();
            foreach (UserRoleAllot Item in userRoleAllotList)
            {
                roleDictList.Add(BllFactory.roleDictBll.getSearchList(o => o.Id == Item.RoleId).FirstOrDefault());
            }
            return roleDictList;
        }
        /// <summary>
        /// 根据角色获取分发用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<User> GetUserAllotByRole(string roleId)
        {
            List<UserRoleAllot> userRoleAllotList = BllFactory.userRoleAllotBll.getSearchList(o => o.RoleId == roleId).ToList<UserRoleAllot>();
            List<User> userList = new List<User>();
            foreach (var Item in userRoleAllotList)
            {
                userList.Add(SYSCacheDict.GetUserList().Where(o => o.Id == Item.UserId).FirstOrDefault());
            }
            return userList;
        }
        /// <summary>
        /// 根据角色获取未分发用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<User> GetUserNoAllotByRole(string roleId)
        {
            List<UserRoleAllot> userRoleAllotList = BllFactory.userRoleAllotBll.getSearchList(o => o.RoleId == roleId).ToList<UserRoleAllot>();
            RoleDict roleDict = SYSCacheDict.GetRoleDictList().Where(o => o.Id == roleId).FirstOrDefault();
            List<User> userList = SYSCacheDict.GetUserList().Where(o=>o.OrgId==roleDict.OrgCode ).ToList<User>();
            foreach (var Item in userRoleAllotList)
            {
                bool isRemove = userList.Remove(userList.Where(o=>o.Id==Item.UserId).FirstOrDefault());
            }
            return userList;
        }
    }
}
