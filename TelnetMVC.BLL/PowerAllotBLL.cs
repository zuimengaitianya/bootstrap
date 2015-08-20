using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;

namespace TelnetMVC.BLL
{
    public class PowerAllotBLL:BaseBLL<PowerAllot>
    {
        /// <summary>
        /// 根据用户Id获取权限
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<Power> GetUserPowerAllot(string userId)
        {
            List<Power> allPower = new List<Power>();
            List<PowerAllot> allPowerAllot = new List<PowerAllot>();
            List<UserRoleAllot> userRoleAllotList = BllFactory.userRoleAllotBll.getSearchList(m => m.UserId == userId).ToList<UserRoleAllot>();

            foreach (UserRoleAllot userRoleAllot in userRoleAllotList)
            {
                List<PowerAllot> powerAllotList = BllFactory.powerAllotBll.getSearchList(m => m.RoleId == userRoleAllot.Id).ToList<PowerAllot>();
                foreach (PowerAllot powerAllot in powerAllotList)
                {
                    if (allPowerAllot.Contains(powerAllot))
                    {
                    }
                    else
                    {
                        allPowerAllot.Add(powerAllot);
                        allPower.Add(BllFactory.powerBll.getSearchList(a => a.Id == powerAllot.PowerId).ToList<Power>().FirstOrDefault());
                    }
                }
            }
            return allPower;
        }

        /// <summary>
        /// 根据角色ID获取角色权限
        /// </summary>
        /// <param name="userRoleId">角色ID</param>
        /// <returns></returns>
        public List<Power> GetUserRolePower(string userRoleId)
        {
            List<Power> allPower = new List<Power>();
            List<PowerAllot> allPowerAllot = BllFactory.powerAllotBll.getSearchList(m => m.RoleId == userRoleId).ToList<PowerAllot>();
            foreach (PowerAllot Items in allPowerAllot)
            {
                Power tempPower = BllFactory.powerBll.getSearchList(m => m.Id == Items.PowerId).FirstOrDefault();
                allPower.Add(tempPower);
            }
            return null;
        }

    }
}
