namespace Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }

        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Level { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private readonly List<StudentCourse> _enrollments = new();
        public IReadOnlyCollection<StudentCourse> Enrollments => _enrollments;

        private Student() { }

        public Student(string fullName, int age, string level)
        {
            FullName = fullName;
            Age = age;
            Level = level;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string fullName, int age, string level)
        {
            FullName = fullName;
            Age = age;
            Level = level;
        }
    }
}
