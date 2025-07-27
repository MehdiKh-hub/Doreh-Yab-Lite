using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICourseReadService
    {
        Task<IReadOnlyList<CourseDto>> GetCourseAsync(string? search, string? sortBy);
    }
}
