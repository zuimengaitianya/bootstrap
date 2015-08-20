using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace TelnetMVC.Common
{
    public static partial class JsonHelper
    {
        /// <summary>对象转字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetJsonString<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return "";
            }
        }

        /// <summary>把字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonValue"></param>
        /// <returns></returns>
        public static T GetObjFromJson<T>(string jsonValue)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonValue);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return default(T);
            }
        }

        /// <summary>把字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonValue"></param>
        /// <returns></returns>
        public static T GetObjFromJson<T>(string jsonValue, T obj)
        {
            try
            {
                return JsonConvert.DeserializeAnonymousType(jsonValue, obj);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return default(T);
            }
        }

        #region <<  Extended By JOJO  >>

        /// <summary>
        /// The json serializer
        /// </summary>
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer();
        /// <summary>
        /// 将一个对象序列化JSON字符串
        /// </summary>
        /// <remarks>
        ///  2013-11-18 18:56 Created By jojo.zhu
        /// </remarks>
        /// <param name="obj">待序列化的对象</param>
        /// <returns>JSON字符串</returns>
        public static string Serialize(object obj)
        {
            var sw = new StringWriter();
            JsonSerializer.Serialize(new JsonTextWriter(sw), obj);
            return sw.GetStringBuilder().ToString();
        }
        /// <summary>
        /// 对象序列化JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            var sw = new StringBuilder();
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'/'MM'/'dd' 'HH':'mm':'ss";
            sw.Append(JsonConvert.SerializeObject(obj, Formatting.Indented, timeConverter));
            return sw.ToString();
        }
        /// <summary>
        /// 将JSON字符串反序列化为一个Object对象
        /// </summary>
        /// <remarks>
        ///  2013-11-18 18:56 Created By jojo.zhu
        /// </remarks>
        /// <param name="json">JSON字符串</param>
        /// <returns>Object对象</returns>
        public static object Deserialize(string json)
        {
            var sr = new StringReader(json);
            return JsonSerializer.Deserialize(new JsonTextReader(sr));
        }
        /// <summary>
        /// 将JSON字符串反序列化为一个指定类型对象
        /// </summary>
        /// <remarks>
        ///  2013-11-18 18:56 Created By jojo.zhu
        /// </remarks>
        /// <typeparam name="TObj">对象类型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns>指定类型对象</returns>
        public static TObj Deserialize<TObj>(string json) where TObj : class
        {
            var sr = new StringReader(json);
            return JsonSerializer.Deserialize(new JsonTextReader(sr), typeof(TObj)) as TObj;
        }
        /// <summary>
        /// 将JSON字符串反序列化为一个JObject对象
        /// </summary>
        /// <remarks>
        ///  2013-11-18 18:56 Created By jojo.zhu
        /// </remarks>
        /// <param name="json">JSON字符串</param>
        /// <returns>JObject对象</returns>
        public static JObject DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject(json) as JObject;
        }
        /// <summary>
        /// 将JSON字符串反序列化为一个JArray数组
        /// </summary>
        /// <remarks>
        ///  2013-11-18 18:56 Created By jojo.zhu
        /// </remarks>
        /// <param name="json">JSON字符串</param>
        /// <returns>JArray对象</returns>
        public static JArray DeserializeArray(string json)
        {
            return JsonConvert.DeserializeObject(json) as JArray;
        }
        #endregion
    }
}
