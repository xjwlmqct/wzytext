using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace webapi.Models
{
    public class ApiResultModel
    {
        /// <summary>
        /// 返回http状态
        /// </summary>
        public HttpStatusCode Status { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 信息提示
        /// </summary>
        public string Message { get; set; }
    }
}