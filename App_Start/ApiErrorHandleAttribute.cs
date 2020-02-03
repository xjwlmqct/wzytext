using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace webapi.App_Start
{
    public class ApiErrorHandleAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            // 取得发生例外时的错误讯息
            var errorMessage = actionExecutedContext.Exception.Message;
            
            var result = new ApiResultEntity()
            {
                Status = HttpStatusCode.BadRequest,
                ErrorMessage = errorMessage 
            };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result.Status, result);
        }

    }
}