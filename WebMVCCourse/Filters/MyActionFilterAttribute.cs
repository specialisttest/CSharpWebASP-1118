using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVCCourse.Filters
{
    //public class MyActionFilterAttribute : Attribute, IActionFilter
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"AFTER CALL Controller {context.Controller} Action {context.ActionDescriptor} Result {context.Result}");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("BEFORE CALL");
            foreach (var key in context.ActionArguments.Keys)
                Console.WriteLine($"    {key}  = {context.ActionArguments[key]}");
        }
    }
}
