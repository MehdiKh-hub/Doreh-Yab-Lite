namespace Domain.Entities
{
    public class Source
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Rank { get; private set; }
        public string? WebsiteUrl { get; private set; }

        private readonly List<Course> _courses = new();
        public IReadOnlyCollection<Course> Courses => _courses;

        private Source() { }

        public Source(string name, int rank, string? websiteUrl = null)
        {
            Name = name;
            Rank = rank;
            WebsiteUrl = websiteUrl;
        }

        public void Update(string name, int rank, string? websiteUrl = null)
        {
            Name = name;
            Rank = rank;
            WebsiteUrl = websiteUrl;
        }
    }
}