using Lab6._1.HelloSrv.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHello, HelloImpl>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html;charset=utf8";
    await next();
});

app.Run(async (context) =>
{
    var helloSrv = context.RequestServices.GetRequiredService<IHello>();
    await context.Response.WriteAsync($"<h1>{helloSrv.GetHelloString()}</h1>");
});

app.Run();
