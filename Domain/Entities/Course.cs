namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; private set; }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int DurationInHours { get; private set; }
        public int Rank { get; private set; }

        public int SubjectId { get; private set; }
        public Subject Subject { get; private set; }

        public int SourceId { get; private set; }
        public Source Source { get; private set; }

        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }

        private readonly List<StudentCourse> _studentCourses = new();
        public IReadOnlyCollection<StudentCourse> StudentCourses => _studentCourses;

        private Course() { }

        public Course(string title, int duration, int rank, int subjectId, int sourceId, int teacherId, string? description = null)
        {
            Title = title;
            DurationInHours = duration;
            Rank = rank;
            SubjectId = subjectId;
            SourceId = sourceId;
            TeacherId = teacherId;
            Description = description;
        }

        public void Update(string title, int duration, int rank, string? description = null)
        {
            Title = title;
            DurationInHours = duration;
            Rank = rank;
            Description = description;
        }
    }
}