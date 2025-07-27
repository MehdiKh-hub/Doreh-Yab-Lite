using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.Ripositories
{
    public class CourseRepository(ApplicationDbContext context) : ICourseQueryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IReadOnlyList<Course>> GetAllCoursesWithRelatedDataAsync()
        {
            var courses = await _context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Source)
                .Include(c => c.Subject)
                .ToListAsync();

            return courses.AsReadOnly();
        }
    }
}
