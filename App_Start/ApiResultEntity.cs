using System.Net;

namespace webapi.App_Start
{
    internal class ApiResultEntity
    {
        public ApiResultEntity()
        {
        }

        public HttpStatusCode Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}