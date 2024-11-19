using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVCCourse.Filters
{
    public class CustomHeaderResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
           
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Custom-Header", "this is custom header value");
        }
    }
}
