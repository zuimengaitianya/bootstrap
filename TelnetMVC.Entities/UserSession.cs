using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelnetMVC.Entities
{
    /// <summary>
    /// 当前登录用户信息
    /// </summary>
    [Serializable]
    public class UserSession
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 当前登录机构
        /// </summary>
        public OrgDict orgDict { get; set; }
        /// <summary>
        /// 当前登录科室
        /// </summary>
        public DeptDict deptDict { get; set; }
        /// <summary>
        /// 当前登录角色
        /// </summary>
        public RoleDict roleDict { get; set; }
        /// <summary>
        /// 当前登录角色的权限
        /// </summary>
        public List<Power> powers { get; set; }
        /// <summary>
        /// 当前登录角色的资源
        /// </summary>
        public List<Resources> resourcess { get; set; }
    }
}
