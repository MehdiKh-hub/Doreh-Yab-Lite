using Application.Interfaces.Ripository;
using Application.Interfaces.Services;
using Domain.Entities;
using Presentation_API.DTOs;


namespace Application.Services
{
    public class StudentService(IStudentRepository repository) : IStudentService
    {
        private readonly IStudentRepository _repository = repository;

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Age = s.Age,
                Level = s.Level,
                CreatedAt = s.CreatedAt
            });
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var s = await _repository.GetByIdAsync(id);
            if (s == null) return null;

            return new StudentDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Age = s.Age,
                Level = s.Level,
                CreatedAt = s.CreatedAt
            };
        }

        public async Task<Student> CreateAsync(string fullName, int age, string level)
        {
            var student = new Student(fullName, age, level);
            await _repository.AddAsync(student);
            return student;
        }

        public async Task<bool> UpdateAsync(int id, string fullName, int age, string level)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            student.Update(fullName, age, level);
            await _repository.UpdateAsync(student);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }


    }
}
