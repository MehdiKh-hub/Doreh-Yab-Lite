namespace Presentation_API.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Level { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
