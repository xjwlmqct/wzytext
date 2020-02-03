### 项目简介

1. 建立一个Web API 应用

2. 测试了RESTFUL 结构

3. 设置了返回值的统一结构

   ```js 
   
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
   ```
   
 4. 练习了过滤器

    ```c#
    public class ApiResultAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                base.OnActionExecuted(actionExecutedContext);
                ApiResultModel result = new ApiResultModel();
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
            }
        }
    >注册过滤器：
        //注册apiResultFilter
        config.Filters.Add(new ApiResultAttribute());
        config.Filters.Add(new ApiErrorHandleAttribute());
    注册中webApiConfig.cs中
    ```

    