using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using WebMiddleware.Services;

namespace WebMiddleware.Test
{
    public class FakeCounter : ICounter
    {
        public int Get() => 0;

        public void Increment()
        {
           
        }
    }

    public class MiddlerwareTest
    {
        [Fact]
        public async Task SecondMiddlewareResponseTest()
        {
            // Arrange
            using var host = await new HostBuilder()
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseTestServer()
                    .ConfigureServices(services=> services.AddSingleton<ICounter, FakeCounter>())
                    .Configure(app => app.UseMiddleware<SecondMiddleware>());
                }).StartAsync();

            // Act
            var response = await host.GetTestClient().GetAsync("/");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Status code = ", await response.Content.ReadAsStringAsync());


        }
    }
}
