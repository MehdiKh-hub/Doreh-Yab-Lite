using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class CourseRankingService(ICourseQueryRepository repository) : ICourseRankingService
    {
        private readonly ICourseQueryRepository _repository = repository;

        public async Task<IReadOnlyList<CourseRankingDto>> GetTopRankedCoursesAsync()
        {
            var courses = await _repository.GetAllCoursesWithRelatedDataAsync();

            var courseRankings = courses.Select(course => new CourseRankingDto
            {
                CourseId = course.Id,
                CourseTitle = course.Title,
                TeacherName = course.Teacher.FullName,
                SourceName = course.Source.Name,
                CourseRank = course.Rank,
                TeacherRank = course.Teacher.Rank,
                SourceRank = course.Source.Rank,
                TotalRank = course.Rank + course.Teacher.Rank + course.Source.Rank,
                DurationInHours = course.DurationInHours,
                Description = course.Description
            })
            .OrderByDescending(x => x.TotalRank)
            .ToList()
            .AsReadOnly();

            return courseRankings;
        }
    }
}
