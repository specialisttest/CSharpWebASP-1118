using System.ComponentModel.DataAnnotations;

namespace WebMVCCourseDaoService.Models
{
    public class Course : IValidatableObject
    {

        public Course() { }

        public Course(int id, string title, int duration)
        {
            Id = id;
            Title = title;
            Duration = duration;
        }

        public int Id { get; set; }

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

    }
}
