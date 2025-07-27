using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CourseRankingDto
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string TeacherName { get; set; }
        public string SourceName { get; set; }
        public int CourseRank { get; set; }
        public int TeacherRank { get; set; }
        public int SourceRank { get; set; }
        public int TotalRank { get; set; }
        public int DurationInHours { get; set; }
        public string? Description { get; set; }
    }
}
