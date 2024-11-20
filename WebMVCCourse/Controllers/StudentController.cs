using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCCourse.Filters;
using WebMVCCourse.Models;

namespace WebMVCCourse.Controllers
{
    [Route("person")]
    public class StudentController : Controller
    {
        // GET: StudentController
        
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            /*string message = this.HttpContext.Session.GetString("message");
            this.ViewBag.message = message;
            if (!string.IsNullOrEmpty(message)) this.HttpContext.Session.Remove("message");*/ 
            return View(Student.All);
        }

        [Route("minage/{minAge:int}")]
        [Route("age/{minAge:int}")]  // person/age/20
        public IActionResult ByAge(int minAge)
        {
            return View("Index", Student.All.Where(s => s.Age >=minAge));
        }

        [MyActionFilter] // action filter
        [Route("age/{minAge:int}/{maxAge:int}")]  // person/age/20/30
        public IActionResult ByAge(int minAge, int maxAge)
        {
            return View("Index", Student.All.Where(s => s.Age >= minAge && s.Age <= maxAge));
        }

        [Route("search/{search}")]
        public IActionResult Search(string search)
        {
            return View("Index", Student.All.Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        // GET: Student/Details/5
        [Route("details/{id:int}")]
        public ActionResult Details(int id)
        {
            var student = Student.All.Where(s=>s.Id == id).SingleOrDefault();
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: Student/Create
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // Источники данных для Model Binding
        // URL (URI) GET : student/create?name=Sergey&age=34  // query path this.HttpContext.Request.Query
        // forms data (request body, POST) : name=Sergey&age=34 // this.HttpContext.Request.Form
        // Routed Data: "age/{minAge:int}/{maxAge:int}" // this.RouteData
        // <input type=file> File



        // POST: StudentController/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            
            try
            {
                Student.All.Add(student);
                //string message = $"New Student added: {student.Name}";
                //this.ViewBag.message = message;
                //this.HttpContext.Session.SetString("message", message);
                this.TempData["message"] = $"New Student added: {student.Name}";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var student = Student.All.Where(s => s.Id == id).SingleOrDefault();
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [Route("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                var oldStudent = Student.All.Where(s => s.Id == id).SingleOrDefault();
                if (oldStudent == null) return NotFound();
                oldStudent.Name = student.Name;
                oldStudent.Age  = student.Age;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [Route("delete/{id:int}")]
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
