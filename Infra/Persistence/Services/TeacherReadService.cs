namespace Infra.Persistence.Services
{
    public class TeacherReadService(ApplicationDbContext context) : ITeacherReadService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IReadOnlyList<TeacherDTo>> GetTeacherAsync(string? search, string? sortBy)
        {
            var query = _context.Teachers
                .AsNoTracking()
                .Include(t => t.Courses)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(t =>
                    t.FullName.ToLower().Contains(search) ||
                    (t.Bio != null && t.Bio.ToLower().Contains(search)));
            }

            query = sortBy?.ToLower() switch
            {
                "fullname" => query.OrderBy(t => t.FullName),
                "email" => query.OrderBy(t => t.Email),
                "rank" => query.OrderByDescending(t => t.Rank),
                _ => query.OrderByDescending(t => t.Rank),
            };

            return await query.Select(t => new TeacherDTo
            {
                Id = t.Id,
                FullName = t.FullName,
                Bio = t.Bio,
                Email = t.Email,
                Rank = t.Rank,
                CoursesCount = t.Courses.Count,
                CourseTitles = t.Courses.Select(c => c.Title).ToList()
            }).ToListAsync();
        }
    }
}
