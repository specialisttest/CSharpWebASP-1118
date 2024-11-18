namespace WebMiddleware
{
    public class SecondMiddleware
    {
        private RequestDelegate next;
        public SecondMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Status code = {context.Response.StatusCode}<br>");
            // if ...
            await next(context);

        }
    }
}
