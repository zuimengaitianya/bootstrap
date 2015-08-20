using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Configuration;
/** ==============================================================================
    *  
    *  文件名：AsyncHttpClient
    *  
    *  描述：异步访问web资源
    *  
    *  创建时间：2014/12/18 14:33:24
    *  
    *  作者：hao.liang
    * 
    *  ==============================================================================*/
namespace TelnetMVC.Common
{
    /// <summary>
    /// 异步访问web资源
    /// </summary>
    public class AsyncHttpClient
    {
        HttpClient m_client = null;

        private static object m_lock = new object();
        private static AsyncHttpClient m_instance;
        /// <summary>单例
        /// </summary>
        public static AsyncHttpClient Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_lock)
                    {
                        if (m_instance == null)
                        {
                            m_instance = new AsyncHttpClient();
                        }
                    }
                }
                return m_instance;
            }
        }

        /// <summary>构造函数
        /// </summary>
        public AsyncHttpClient()
        {
            string url = ConfigurationManager.AppSettings["BaseURL"];
            m_client = new HttpClient();
            m_client.BaseAddress = new Uri(url);
        }

        /// <summary>POST访问
        /// </summary>
        /// <param name="relDic"></param>
        /// <param name="param"></param>
        public string Post(string relDic, string param)
        {
            try
            {
                HttpContent context = new StringContent(param);
                var result = m_client.PostAsync(relDic, context).Result;
                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return SystemConfig.Error;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AsyncHttpClient), ex);
                return SystemConfig.Exception;
            }
        }
    }
}
