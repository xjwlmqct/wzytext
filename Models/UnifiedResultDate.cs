using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace webapi.Models
{
    public class UnifiedResultDate
    {
        public object Date { set; get; }
        public string Code { set; get; }
        public string Msg { set; get; }
        public UnifiedResultDate(object data,string code,string msg)
        {
            Date = data;
            Code = code;
            Msg = msg;
        }
        public UnifiedResultDate(object data)
        {
            Date = data;
            if(Date==null) 
            {
                Code=((int)HttpStatusCode.NotFound).ToString();
                Msg = "未没有找到数据";
            }
            else
            {
                Code = ((int)HttpStatusCode.OK).ToString();
                Msg = "成功";
            }
        }
    }
}