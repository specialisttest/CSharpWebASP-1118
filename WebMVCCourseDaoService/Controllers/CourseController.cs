using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCCourseDaoService.Dao;
using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Controllers
{
    public class CourseController : Controller
    {
        private ICourseDao courseDao;

        public CourseController(ICourseDao courseDao)
        {
            this.courseDao = courseDao;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            return View(courseDao.Get());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View(courseDao.Get(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.SaveOperation = "Create";
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            ViewBag.SaveOperation = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    courseDao.Add(course);
                    return RedirectToAction(nameof(Index));
                }
                return View(course);
                
            }
            catch
            {
                ModelState.AddModelError("Save", "Error saving in db");
                return View(course);
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SaveOperation = "Edit";
            return View("Create", courseDao.Get(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            ViewBag.SaveOperation = "Edit";
            try
            {
                if (ModelState.IsValid) 
                {
                    course.Id = id;
                    courseDao.Merge(course);
                    return RedirectToAction(nameof(Index));
                }
                return View("Create", course);  
            }
            catch
            {
                ModelState.AddModelError("Save", "Error saving in db");
                return View("Create", course);
            }
        }

        // GET: CourseController/Delete/5
        [ActionName("Delete")]
        public ActionResult ShowDeleteConfirm(int id)
        {
            return View(courseDao.Get(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                courseDao.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(courseDao.Get(id));
            }
        }
    }
}
