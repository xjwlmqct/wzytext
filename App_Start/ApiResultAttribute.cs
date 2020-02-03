using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using webapi.Models;

namespace webapi.App_Start
{
    public class ApiResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                return;
            //else
            //{

                base.OnActionExecuted(actionExecutedContext);

                ApiResultModel result = new ApiResultModel();


            //if (actionExecutedContext.ActionContext.Response.Content == null)
            //{
            //    result.Data = null;
            //    result.Status = HttpStatusCode.NotFound;
            //}
            //else
            //{
            //    result.Data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;

            //    result.Status = actionExecutedContext.ActionContext.Response.StatusCode;
            //}

            result.Data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
            if(result.Data==null)
            {
                result.Status = HttpStatusCode.NotFound;
                result.Message = "未找到数据";
            }
            else
            {
                result.Status = actionExecutedContext.ActionContext.Response.StatusCode;
                result.Message = "成功";
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result.Status, result);
            //}
        }
    }
}