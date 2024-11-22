using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System.Diagnostics;
using System.Text;
using WebEFC.Models;

namespace WebEFC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ObjectPool<StringBuilder> _pool;

        public HomeController(ILogger<HomeController> logger, ObjectPool<StringBuilder> pool)
        {
            _logger = logger;
            _pool = pool;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            StringBuilder sb = _pool.Get();
            sb.Append("String builder");
            ViewBag.ResultSB = sb.ToString();
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
