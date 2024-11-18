namespace WebEnpoints
{
    public class Course
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

        public Course(int id, string title, int duration)
        {
            Id = id;
            Title = title;
            Duration = duration;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
    }
}
