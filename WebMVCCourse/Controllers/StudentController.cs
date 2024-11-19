using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCCourse.Models;

namespace WebMVCCourse.Controllers
{
    [Route("person")]
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            return View(Student.All);
        }

        [Route("minage/{minAge:int}")]
        [Route("age/{minAge:int}")]  // person/age/20
        public IActionResult ByAge(int minAge)
        {
            return View("Index", Student.All.Where(s => s.Age >=minAge));
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = Student.All.Where(s=>s.Id == id).SingleOrDefault();
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: Student/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                Student.All.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
