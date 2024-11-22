using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Dao
{
    public interface ICourseDao
    {
        public IEnumerable<Course> All { get;  }
        public IEnumerable<Course> Get();
        public Course Get(int id);
        // public IEnumerable<Course> GetByTitle(string title);
        public Course Add(Course course);
        public Course Merge(Course course);
        public void Remove(int id);
    }
}
