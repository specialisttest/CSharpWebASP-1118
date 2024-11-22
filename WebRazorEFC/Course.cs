using System.ComponentModel.DataAnnotations;

namespace WebRazorEFC
{
    //[Table("courses")]
    public class Course
    {
        public Course() { }
        public Course(int id, string title, int duration, string description)
        {
            Id = id;
            Title = title;
            Duration = duration;
            Description = description;
        }

        // Primary key by default - Id, EntityName+Id (CourseId)
        //[Key]
        public int Id { get; set; }

        public string Title { get; set; }

        //[Column("Length")]
        [Range(8, 48, ErrorMessage = "Duration out of [8,48]")]
        public int Duration { get; set; }

        //[NotMapped]
        public string Description { get; set; }
    }
}
