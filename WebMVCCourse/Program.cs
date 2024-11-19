using Microsoft.Extensions.FileProviders;
using WebMVCCourse.Filters;

var builder = WebApplication.CreateBuilder(args);

// add global filter

builder.Services.AddMvc(options => {
    options.Filters.Add(typeof(CustomHeaderResultFilterAttribute));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

/*app.UseStaticFiles(); // wwwroot

// MyStatic
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "MyStatic"))
});*/

app.MapStaticAssets(); // app.UseStaticFiles();


/*app.MapControllerRoute(
    name : "search",
    pattern : "search/{search:minlength(3)}",
    defaults: new { controller="Course", action="Search"}
    );*/

// /course/show/5   CourseController::Show(id=5)
// /course  CourseController::Index
// /  HomeController::Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllers();

app.Run();
