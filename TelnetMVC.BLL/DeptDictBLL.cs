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
    public class DeptDictBLL : BaseBLL<DeptDict>
    {
        /// <summary>
        /// EF查询方式查询翻译数据
        /// </summary>
        /// <returns></returns>
        public string seachList()
        {
            using (TelnetContext context = new TelnetContext())
            {
                var deptDicts = (from deptdict in context.DeptDicts
                                 join orgdict in context.OrgDicts
                                 on deptdict.OrgCode equals orgdict.Id
                                 select new
                                 {
                                     deptdict.DeptName,
                                     orgdict.OrgName
                                 });
                return JsonConvert.SerializeObject(deptDicts);
            }
        }
        /// <summary>
        /// EF使用SQL方式查询结果。
        /// </summary>
        /// <returns></returns>
        public string seachDeptList()
        {
            using (TelnetContext context = new TelnetContext())
            {
                //context.Database.ExecuteSqlCommand("update DeptDict set CreateTime=GETDATE() where Id='2ca63b4e-9e32-418e-a366-3f20afa378da'");
                //return null;

                var deptDicts=context.Database.SqlQuery<string>("select Id,DeptName,OrgCode,(select OrgName from OrgDict a where a.Id=OrgCode) OrgName from DeptDict").ToList();
                return JsonConvert.SerializeObject(deptDicts);


            }
        }
    }
}
