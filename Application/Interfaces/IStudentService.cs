using Domain.Entities;
using Presentation_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<Student> CreateAsync(string fullName, int age, string level);
        Task<bool> UpdateAsync(int id, string fullName, int age, string level);
        Task<bool> DeleteAsync(int id);
    }
}
