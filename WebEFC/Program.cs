using Microsoft.Extensions.ObjectPool;
using System.Text;
using WebEFC.Models;

namespace WebEFC
{
    public class Program
    {
        internal static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddMemoryCache();

            builder.Services.AddOutputCache();

            builder.Services.AddSingleton<ObjectPool<StringBuilder>>(serviceProvider =>
            {
                var provider =serviceProvider.GetService<ObjectPoolProvider>();
                var policy = new StringBuilderPooledObjectPolicy();
                Console.WriteLine(policy.InitialCapacity);
                Console.WriteLine(policy.MaximumRetainedCapacity);
                return provider.Create(policy);
            });

            //builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSqlServer<ApplicationContext>(
                config.GetConnectionString("DefaultConnection"));
            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseOutputCache();

            app.UseRouting();

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.Run();
        }
    }
}




