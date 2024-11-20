using lab4.StudentList.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.StudentList.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(Student.All);
        }

        public IActionResult Details(int id)
        {
            var student = Student.All.Where(x => x.Id == id).SingleOrDefault();
            if (student == null) { return NotFound(); }
            return View(student);
        }
    }
}
