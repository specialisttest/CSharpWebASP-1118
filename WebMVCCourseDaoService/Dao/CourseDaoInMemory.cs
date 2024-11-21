using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Dao
{
    public class CourseDaoInMemory : ICourseDao
    {
        private IList<Course> All { get; set; } =  new List<Course>() {
                new Course(1, "C# Lang 13", 40),
                new Course(2, "ASP.NET Core MVC 9.0", 40),
                new Course(3, "JavaScript 1. Base", 24),
                new Course(4, "Pattern OOP", 24),
                new Course(5, "C# Client-Server",40),
                new Course(6, "Git",16)
            };

        public Course Add(Course course)
        {
            course.Id = All.Select(x => x.Id).Max() + 1;
            All.Add(course);
            return course;
        }

        public IEnumerable<Course> Get()
        {
            return All;
        }

        public Course Get(int id)
        {
            return All.Where(c => c.Id == id).SingleOrDefault();
        }

        public Course Merge(Course course)
        {
            var c = Get(course.Id);
            if (c != null)
            {
                c.Title = course.Title;
                c.Duration = course.Duration;
            }
            else throw new Exception($"Merge course by ID {course.Id} not found");
            return c;
        }

        public void Remove(int id)
        {
            All.Remove(Get(id));
        }
    
    }
}
