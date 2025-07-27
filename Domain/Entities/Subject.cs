namespace Domain.Entities
{
    public class Subject
    {
        private readonly List<Course> _courses = new();

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Rank { get; private set; }
        public string? Description { get; private set; }
        public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();
        private Subject() { }

        public Subject(string name, int rank, string? description = null)
        {
            Name = name;
            Rank = rank;
            Description = description;
        }

        public void Update(string name, int rank, string? description = null)
        {
            Name = name;
            Rank = rank;
            Description = description;
        }

    }
}
