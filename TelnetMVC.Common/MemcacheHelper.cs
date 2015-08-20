using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Memcached.ClientLibrary;
using System.Configuration;

namespace TelnetMVC.Common
{
    /// <summary>
    /// 分布式缓存MemcacheHelper
    /// </summary>
    public static class MemcacheHelper
    {
        private static MemcachedClient mc;
        /// <summary>
        /// 缓存默认时间0为永久保存
        /// </summary>
        static string MemcacheMins = ConfigurationManager.AppSettings["MemcacheMins"];
        static string[] MemacheServerAdd = ConfigurationManager.AppSettings["MemacheServerAdd"].Split(',');

        static MemcacheHelper()
        {
            //String[] serverlist = { "127.0.0.1:11211" };

            // initialize the pool for memcache servers
            SockIOPool pool = SockIOPool.GetInstance("test");
            //pool.SetServers(serverlist);
            pool.SetServers(MemacheServerAdd);
            pool.Initialize();
            mc = new MemcachedClient();
            mc.PoolName = "test";
            mc.EnableCompression = false;

        }
        /// <summary>
        /// 设置分布式缓存的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool Set(string key, object value)
        {
            return mc.Set(key, value, DateTime.Now.AddMinutes(Convert.ToInt64(MemcacheMins)));
        }

        /// <summary>
        /// 设置分布式缓存的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expiry">缓存时间</param>
        /// <returns></returns>
        public static bool Set(string key, object value, DateTime expiry)
        {
            return mc.Set(key, value, expiry);
        }
        
        /// <summary>
        /// 获取分布式缓存的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            //先设置为滑动时间
            var obj = mc.Get(key);
            if (obj != null && MemcacheMins != "0")
                mc.Set(key, obj, DateTime.Now.AddMinutes(Convert.ToInt64(MemcacheMins)));
            return mc.Get(key);
        }

        /// <summary>
        ///移除缓存 
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            mc.Delete(key);
        }
    }
}
