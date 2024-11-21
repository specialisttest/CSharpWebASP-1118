using WebMiddleware.Services;

namespace WebMiddleware
{
    public class SecondMiddleware
    {
        private RequestDelegate next;
        private ICounter counterSrv;
        public SecondMiddleware(RequestDelegate next, ICounter counterSrv /* only Singleton or Transient*/)
        {
            this.next = next;
            this.counterSrv = counterSrv;
        }

        public async Task Invoke(HttpContext context/*, ICounter counterSrv*/)
        {

            //var counterSrv = context.RequestServices.GetRequiredService<ICounter>();

            await context.Response.WriteAsync($"Status code = {context.Response.StatusCode}<br>");
            await context.Response.WriteAsync($"Counter SRV = {counterSrv.Get()}<br>");
            // if ...
            await next(context);

        }
    }
}
