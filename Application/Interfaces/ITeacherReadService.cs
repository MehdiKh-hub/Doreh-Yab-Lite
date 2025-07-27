using Application.DTOs;

namespace Application.Interfaces
{
    public interface ITeacherReadService
    {
        Task<IReadOnlyList<TeacherDTo>> GetTeacherAsync(string? search, string? sortBy);
    }
}
    