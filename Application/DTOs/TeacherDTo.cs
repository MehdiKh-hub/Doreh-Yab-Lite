using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TeacherDTo
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public int Rank { get; set; }

        public int CoursesCount { get; set; }
        public List<string>? CourseTitles { get; set; }
    }
}
