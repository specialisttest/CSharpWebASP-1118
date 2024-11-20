namespace lab4.StudentList.Models
{
    public class Student
    {
        
        public static IList<Student> All = new List<Student>() 
        { 
            new Student(1, "Sergey", 47),
            new Student(2, "Andrey", 35)
        };

        public Student() { }
        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
