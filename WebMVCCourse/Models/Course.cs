using System.ComponentModel.DataAnnotations;
using WebMVCCourse.Attributes;

namespace WebMVCCourse.Models
{
    public class Course : IValidatableObject
    {
        public static IList<Course> All { get; set; }

        static Course()
        {
            All = new List<Course>() {
                new Course(1, "C# Lang 13", 40),
                new Course(2, "ASP.NET Core MVC 9.0", 40),
                new Course(3, "JavaScript 1. Base", 24),
                new Course(4, "Pattern OOP", 24),
                new Course(5, "C# Client-Server",40),
                new Course(6, "Git",16)
            };

        }

        // [CustomValidationAttribute]
        public Course() { }

        public Course(int id, string title, int duration)
        {
            Id = id;
            Title = title;
            Duration = duration;
        }

        public int Id { get; set; }

        //[RegularExpression(pattern: "")]
        //[Compare(otherProperty:"confirm")]
        [Required(ErrorMessage = "Title should not be empty")]
        [StringLength(maximumLength:64, MinimumLength = 4, ErrorMessage = "Title length should be >= 4")]
        [FirstCharUpperCase(ErrorMessage = "First char of title should in upper case")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Durartion is empty")]
        [Range(8,48, ErrorMessage = "Course duration should in [8, 48]")]
        
        public int Duration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id < 0)
                yield return new ValidationResult("id < 0");
            if (Duration % 8 != 0)
                yield return new ValidationResult("duration % 8 != 0 invalid");
        }

        //[Phone]
        //[CreditCard]
        //[Url]
        //[EmailAddress]
        //public string Phone { get; set; }
    }
}
