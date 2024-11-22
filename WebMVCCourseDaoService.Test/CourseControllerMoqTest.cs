using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCCourseDaoService.Controllers;
using WebMVCCourseDaoService.Dao;
using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Test
{
    

    public class CourseControllerMoqTest
    {
        public IEnumerable<Course> Courses
        {
            get
            {
                yield return new Course() { Id = 1, Title = "C# 12 web", Duration = 40};
                yield return new Course() { Id = 2, Title = "C# Client-Server", Duration = 40};
                yield return new Course() { Id = 3, Title = "JavaScript", Duration = 24};
                yield return new Course() { Id = 4, Title = "Java 1", Duration = 40 };
            }
        }
        [Fact]
        public void SearchTest2()
        {
            // Arange
            var moq = new Mock<ICourseDao>();
            moq.SetupGet(m => m.All).Returns(Courses);

            var c = new CourseController( moq.Object );

            //Act
            ViewResult vr = c.Search("jAvA") as ViewResult;
            var r = (IEnumerable<Course>)vr.ViewData.Model;

            // Assert
            //Assert.Equal(2, r.Count());

            Assert.IsType<Course[]>(r);
        }
    }
}
