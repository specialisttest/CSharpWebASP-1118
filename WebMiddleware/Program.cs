using WebMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Конфигурируем веб-сервер и сервисы


var app = builder.Build();

// Конфигурируем конвеер (Run, Use, Map)

// app.UseStaticFiles(); // wwwroot 
// app.MapStaticAssets(); // since 9.0
// app.UseStaticFiles(new StaticFileOptions)

app.Map("/test", app2 =>
{

    app2.Map("/json", app3 =>
    {
        // /test/json
        app3.Use(async (context, next) =>
        {
            context.Response.ContentType = "application/json";
            await next();
        });
        app3.Run(async context => {
            await context.Response.WriteAsJsonAsync(new { Title = "ASP.NET Core MVC 9.0", Duration = 40 });
        });
    });
    app2.Run(async context => {
        await context.Response.SendFileAsync(@"test.txt"); // copy if newer
    });
});

/*app.Map("/json", app3 =>
{
    app3.Use(async (context, next) =>
    {
        context.Response.ContentType = "application/json";
        await next();
    });
    app3.Run(async context => {
        await context.Response.WriteAsJsonAsync(new { Title="ASP.NET Core MVC 9.0", Duration = 40});
    });
});*/

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html";
    await next(); //next.Invoke()

});

app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get)
        await context.Response.WriteAsync("Start First Middleware<br>");
    //else
        await next();
    await context.Response.WriteAsync("End First Middleware<br>");
});

app.Map("/security", appBuilder =>
{
    // /security/login
    appBuilder.Map("/login", ab2 =>
    { ab2.Run(async context => await context.Response.WriteAsync("Login page.<br>")); });
    // /security/register
    appBuilder.Map("/register", ab2 =>
    { ab2.Run(async context => await context.Response.WriteAsync("Register page.<br>")); });



});
app.MapWhen(context => context.Request.Headers.ContainsKey("Time"),
    app2 => {
        app2.Use(async (context, next) => {
            await context.Response.WriteAsync("MapWhen() header contains Time");
            await next();
        });    
    }
);

app.UseMiddleware<SecondMiddleware>();


// терминальное middleware
app.Run(async context =>
{
    //context.Request
   
    await context.Response.WriteAsync("<h1>Hello from Run (....)</h1>");
});

// Запуск веб приложения
app.Run();

// app.Start()
//app.StartAsync
//await app.RunAsync()
//app.StopAsync()