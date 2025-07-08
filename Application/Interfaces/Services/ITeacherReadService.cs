using Application.DTOs;

namespace Application.Interfaces.Services
{
    public interface ITeacherReadService
    {
        Task<IReadOnlyList<TeacherDTo>> GetTeacherAsync(string? search, string? sortBy);
    }
}
    