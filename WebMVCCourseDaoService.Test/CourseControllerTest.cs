using Microsoft.AspNetCore.Mvc;
using WebMVCCourseDaoService.Controllers;
using WebMVCCourseDaoService.Dao;
using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Test
{
    class FakeCourseData : ICourseDao
    {
        private IEnumerable<Course> courses = new List<Course>()
        {
            new Course() { Id = 1, Title = "C# 12 web", Duration = 4 },
            new Course() { Id = 2, Title = "C# Client-Server", Duration = 40 },
            new Course() { Id = 3, Title = "JavaScript", Duration = 24 },
            new Course() { Id = 4, Title = "Java 1", Duration = 40 }
        };
        public IEnumerable<Course> All => courses;

        public Course Add(Course course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> Get()=>  courses;
        

        public Course Get(int id)
        {
            throw new NotImplementedException();
        }

        public Course Merge(Course course)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CourseControllerTest
    {
        [Fact]
        public void SearchTest()
        {
            // Arange
            var c = new CourseController(new FakeCourseData());

            //Act
            ViewResult vr = c.Search("jAvA") as ViewResult;
            var r = (IEnumerable<Course>)vr.ViewData.Model;

            // Assert
            Assert.Equal(2, r.Count());
        }
    }
}
