using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebMVCCourse.Filters;
using WebMVCCourse.Models;

namespace WebMVCCourse.Controllers
{
    //[MyActionFilter] // controller filter
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            string search = this.HttpContext.Session.GetString("courseSearchPattern");
            this.ViewBag.CourseSearchPattern = search ?? "";
            ViewData["Year"] = DateTime.Now.Year;
            return View(String.IsNullOrEmpty(search)?Course.All : Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        [Route("search/{search:minlength(3)}")]
        public IActionResult Search(string search)
        {
            this.HttpContext.Session.SetString("courseSearchPattern", search);
            this.ViewBag.CourseSearchPattern = search ?? "";
            ViewBag.Year = DateTime.Now.Year;
            return View("Index", Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        [HttpPost]
        public IActionResult Filter(string search)
        {
            this.HttpContext.Session.SetString("courseSearchPattern", search);
            this.ViewBag.CourseSearchPattern = search??"";
            ViewBag.Year = DateTime.Now.Year;
            return View("Index", Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));

        }

        public IActionResult ListJSON()
        {
            return new JsonResult(Course.All);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {

            try
            {
                if (course.Id <= Course.All.Select(c => c.Id).Max())
                    ModelState.AddModelError("Id", "Id less or eqaul then max id");
                
                if (this.ModelState.IsValid)
                {
                    Course.All.Add(course);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    /*ViewBag.ErrorMessage = "Data error";
                    foreach (var err in ModelState)
                        if (err.Value.ValidationState == ModelValidationState.Invalid)
                        {
                            ViewBag.ErrorMessage += $"<br> Invalid property: {err.Key}";
                            foreach (var error in err.Value.Errors)
                                ViewBag.ErrorMessage += $"<br>{error.ErrorMessage}";
                        }*/
                    return View(course);
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
