using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html";
    await next(); //next.Invoke()

});

app.Map("/time", app2 =>
{
    app2.Use(async (context,next) =>
    {
        await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        await next.Invoke();
    });
});

app.Map("/date", app2 =>
{
    app2.Use(async (context, next) =>
    {
        await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
        await next.Invoke();
    });
});

app.MapWhen(context =>  context.Request.Path == PathString.FromUriComponent("/"), app2 => {
    app2.Run(async context => {
        await context.Response.WriteAsync("<h1>Main page</h1>");
    });
});

app.Run(async context =>
{
    context.Response.StatusCode = StatusCodes.Status404NotFound; 
    //(int)HttpStatusCode.NotFound;
    await context.Response.WriteAsync("Resource not found");
});

app.Run();
