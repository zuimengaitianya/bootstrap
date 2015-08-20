using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelnetMVC.Entities
{
    public class ResultJson
    {
        /// <summary>
        /// 返回判断值（判断该操作是否正确）,默认返回true
        /// </summary>
        public bool Success = true;

        /// <summary>
        /// 如果success为false，请把错误信息填写在该字段上面
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 如果success为true，并且没有返回对象，请将需要返回的描述语填写在该字段
        /// </summary>
        public string SuccessMsg { get; set; }

        /// <summary>
        /// 返回的结果集
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
    }
}
