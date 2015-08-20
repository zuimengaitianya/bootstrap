using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelnetMVC.BLL
{
    /// <summary>
    /// 业务处理层工厂类
    /// </summary>
    public static class BllFactory
    {
        /// <summary>
        /// 机构
        /// </summary>
        public static readonly OrgDictBLL orgDictBll = new OrgDictBLL();
        /// <summary>
        /// 科室
        /// </summary>
        public static readonly DeptDictBLL deptDictBll = new DeptDictBLL();
        /// <summary>
        /// 角色
        /// </summary>
        public static readonly RoleDictBLL roleDictBll = new RoleDictBLL();
        /// <summary>
        /// 用户
        /// </summary>
        public static readonly UserBLL userBll = new UserBLL();
        /// <summary>
        /// 用户角色分发
        /// </summary>
        public static readonly UserRoleAllotBLL userRoleAllotBll = new UserRoleAllotBLL();
        /// <summary>
        /// 权限
        /// </summary>
        public static readonly PowerBLL powerBll = new PowerBLL();
        /// <summary>
        /// 权限分发
        /// </summary>
        public static readonly PowerAllotBLL powerAllotBll = new PowerAllotBLL();
        /// <summary>
        /// 资源
        /// </summary>
        public static readonly ResourcesBLL resourcesBll = new ResourcesBLL();
        /// <summary>
        /// 资源分发
        /// </summary>
        public static readonly ResourcesAllotBLL resourceAllotBll = new ResourcesAllotBLL();
        /// <summary>
        /// 基本字典
        /// </summary>
        public static readonly BaseDictBLL baseDictBll = new BaseDictBLL();

    }
}
