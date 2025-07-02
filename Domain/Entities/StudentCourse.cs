namespace Domain.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; private set; }
        public Student Student { get; private set; }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }

        public DateTime EnrollmentDate { get; private set; }
        public bool IsCompleted { get; private set; }

        private StudentCourse() { }

        public StudentCourse(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
            EnrollmentDate = DateTime.UtcNow;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}
