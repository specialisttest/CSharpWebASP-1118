using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using WebMVCCourse.Models;

namespace WebMVCCours.Test
{
    public class CourseTest
    {
        [Fact]
        public void  DurationValidTest()
        {
            // Arrange
            Course c = new Course(1, "Java 1", 40);

            // Act
            c.Duration = 32;
            int errorCount = ((IValidatableObject)c).Validate(new ValidationContext(c)).Count();

            // Assert
            Assert.Equal(0, errorCount);

            c.Duration = 33;
            var result = ((IValidatableObject)c).Validate(new ValidationContext(c));
            var r = result.Where(vr => vr.ErrorMessage.Contains("duration") && vr.ErrorMessage.Contains("invalid")).Count();
            Assert.Equal(1, r);        



        }
    }
}
