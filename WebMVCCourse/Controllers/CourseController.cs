using Microsoft.AspNetCore.Mvc;
using WebMVCCourse.Filters;
using WebMVCCourse.Models;

namespace WebMVCCourse.Controllers
{
    //[MyActionFilter] // controller filter
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View(Course.All);
        }

        [Route("search/{search:minlength(3)}")]
        public IActionResult Search(string search)
        {
            return View("Index", Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        public IActionResult ListJSON()
        {
            return new JsonResult(Course.All);
        }
    }
}
