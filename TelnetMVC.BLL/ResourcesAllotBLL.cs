using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelnetMVC.Common;
using TelnetMVC.DAL;
using TelnetMVC.Entities;

namespace TelnetMVC.BLL
{
    public class ResourcesAllotBLL:BaseBLL<ResourcesAllot>
    {
        /// <summary>
        /// 根据用户Id获取资源
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<Resources> GetUserResourcesAllot(string userId)
        {
            List<ResourcesAllot> allResourcesAllot = new List<ResourcesAllot>();
            List<Resources> allResource = new List<Resources>();
            List<UserRoleAllot> userRoleAllotList = BllFactory.userRoleAllotBll.getSearchList(m => m.UserId == userId).ToList<UserRoleAllot>();

            foreach (UserRoleAllot userRoleAllot in userRoleAllotList)
            {
                List<ResourcesAllot> resourcesAllotList = BllFactory.resourceAllotBll.getSearchList(o => o.RoleId == userId).ToList<ResourcesAllot>();
                foreach (ResourcesAllot resourcesAllot in resourcesAllotList)
                {
                    if (allResourcesAllot.Contains(resourcesAllot))
                    {
                    }
                    else
                    {
                        allResourcesAllot.Add(resourcesAllot);
                        allResource.Add(BllFactory.resourcesBll.getSearchList(a => a.Id == resourcesAllot.ResourcesId).ToList<Resources>().FirstOrDefault());
                    }
                }
            }
            return allResource;
        }
        /// <summary>
        /// 根据角色ID获取资源
        /// </summary>
        /// <param name="userRoleId">角色ID</param>
        /// <returns></returns>
        public List<Resources> GetUserRoleResources(string userRoleId)
        {
            List<Resources> RoleResourcess = new List<Resources>();
            List<ResourcesAllot> userRoleResourcesAllot = BllFactory.resourceAllotBll.getSearchList(o => o.RoleId == userRoleId).ToList<ResourcesAllot>();
            foreach (ResourcesAllot Items in userRoleResourcesAllot)
            {
                Resources tempResources = BllFactory.resourcesBll.getSearchList(o => o.Id == Items.ResourcesId).FirstOrDefault();
                RoleResourcess.Add(tempResources);
            }
            return RoleResourcess;
        }
    }
}
