var builder = WebApplication.CreateBuilder(args);

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
