using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TelnetMVC.DAL;
using TelnetMVC.Common;
using TelnetMVC.Entities;
using System.Data.Entity;
using System.Reflection;


namespace TelnetMVC.BLL
{
    public class BaseBLL<T> where T:class
    {
        #region 5才用的方式
        //public T GetEntity<T>(string id)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(id))
        //            return default(T);
        //        T Entity = default(T);
        //        using (TelnetContext context = new TelnetContext())
        //        {
        //            Entity=(from a in context.org_dict<T>
        //                    where a.Id==id
        //                    select (a)).FirstOrDefault();
        //        }
        //        return Entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(typeof(T), ex);
        //        return default(T);

        //    }
        //}

        //public static List<T> GetListOf<T>(Expression<Func<T, bool>> expression) where T : class
        //{
        //    TelnetContext _context = new TelnetContext();
            
        //    return _context.CreateObjectSet<T>().Where(expression).ToList();
        //}
        //public static void AddNewData<T>(T t) where T : class
        //{
        //    using (var ctx = new TelnetContext())
        //    {
        //        ctx.CreateObjectSet<T>().AddObject(t);
        //        ctx.SaveChanges();
        //    }
        //}
        #endregion

        TelnetContext dbContext = new TelnetContext();
        /// <summary>
        /// 实体新增
        /// </summary>
        /// <param name="model"></param>
        public bool add(params T[] paramList)
        {
            try
            {
                foreach (var model in paramList)
                {
                    dbContext.Entry<T>(model).State = EntityState.Added;
                }
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                return false;
            }
        }
        /// <summary>
        /// 实体查询
        /// </summary>
        public IEnumerable<T> getSearchList(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            try
            {
                return dbContext.Set<T>().Where(where);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(T), ex);
                return null;
            }
        }
        /// <summary>
        /// 实体分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">分页数</param>
        /// <param name="Total">总数</param>
        /// <returns></returns>
        public IEnumerable<T> getSearchListByPage(Expression<Func<T, bool>> where, int pageSize, int pageIndex, ref int Total)
        {
            IEnumerable<T> AllWhere = dbContext.Set<T>().Where(where);
            Total = AllWhere.Count<T>();
            return AllWhere.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// 实体分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">分页数</param>
        /// <param name="Total">总数</param>
        /// <returns></returns>
        public IEnumerable<T> getSearchListByPage<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderBy, int pageSize, int pageIndex,ref int Total)
        {
            IEnumerable<T> AllWhere = dbContext.Set<T>().Where(where);
            Total = AllWhere.Count<T>();
            return dbContext.Set<T>().Where(where).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// 实体删除
        /// </summary>
        /// <param name="model"></param>
        public void delete(params T[] paramList)
        {
            foreach (var model in paramList)
            {
                dbContext.Entry<T>(model).State = EntityState.Deleted;
            }
            dbContext.SaveChanges();
        }
        /// <summary>
        /// 按照条件修改数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        public void update(Expression<Func<T, bool>> where, Dictionary<string, object> dic)
        {
            IEnumerable<T> result = dbContext.Set<T>().Where(where).ToList();
            Type type = typeof(T);
            List<PropertyInfo> propertyList = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToList();
            //遍历结果集
            foreach (T entity in result)
            {
                foreach (PropertyInfo propertyInfo in propertyList)
                {
                    string propertyName = propertyInfo.Name;
                    if (dic.ContainsKey(propertyName))
                    {
                        //设置值
                        propertyInfo.SetValue(entity, dic[propertyName], null);
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}
