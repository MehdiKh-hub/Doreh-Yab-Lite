using Application.DTOs;

namespace Application.Interfaces.Services
{
    public interface ITeacherReadService
    {
        Task<IReadOnlyList<TeacherDTo>> GetCourseAsync(string? search, string? sortBy);
    }
}
    