using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCCourse.Filters;
using WebMVCCourse.Models;

namespace WebMVCCourse.Controllers
{
    [TypeFilter(typeof(ExFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [ActionName("Abc")]
        public IActionResult Index()
        {
            return View("Index"); // ViewResult
            // Home/Index
            // Shared/Index
        }

        public IActionResult Privacy()
        {
            throw new Exception("My error");
            return View();
        }

        public IActionResult Abc()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorEx(int statuscode)
        {
            ViewBag.StatusCode = statuscode;
            return View();
        }
    }
}
