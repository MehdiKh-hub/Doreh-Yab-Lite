using Application.DTOs;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Services
{
    public class CourseReadService(ApplicationDbContext context) : ICourseReadService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IReadOnlyList<CourseDto>> GetCourseAsync(string? search, string? sortBy)
        {
            var query = _context.Courses
                .AsNoTracking()
                .Include(c => c.Subject)
                .Include(c => c.Source)
                .Include(c => c.Teacher)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c =>
                    c.Title.Contains(search) ||
                    c.Description != null && c.Description.Contains(search));
            }

            query = sortBy?.ToLower() switch
            {
                "title" => query.OrderBy(c => c.Title),
                "duration" => query.OrderByDescending(c => c.DurationInHours),
                "rank" or _ => query.OrderByDescending(c => c.Rank),
            };

            return await query.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                DurationInHours = c.DurationInHours,
                Rank = c.Rank,
                SubjectTitle = c.Subject.Name,
                SourceTitle = c.Source.Name,
                TeacherFullName = c.Teacher.FullName
            }).ToListAsync();
        }
    }
}
    