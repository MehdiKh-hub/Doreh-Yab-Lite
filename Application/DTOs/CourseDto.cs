using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int DurationInHours { get; set; }
        public int Rank { get; set; }
        public string SubjectTitle { get; set; }
        public string SourceTitle { get; set; }
        public string TeacherFullName { get; set; }
    }
}
