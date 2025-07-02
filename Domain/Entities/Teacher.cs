namespace Domain.Entities
{
    public class Teacher
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string? Bio { get; private set; }
        public string? Email { get; private set; }
        public int Rank { get; private set; }

        private readonly List<Course> _courses = new();
        public IReadOnlyCollection<Course> Courses => _courses;

        private Teacher() { }

        public Teacher(string fullName, int rank, string? bio = null, string? email = null)
        {
            FullName = fullName;
            Rank = rank;
            Bio = bio;
            Email = email;
        }

        public void Update(string fullName, int rank, string? bio = null, string? email = null)
        {
            FullName = fullName;
            Rank = rank;
            Bio = bio;
            Email = email;
        }
    }
}
