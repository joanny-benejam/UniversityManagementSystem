using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(Guid id);
        Task<Student> GetByEmailAsync(string email);
        Task<IEnumerable<Student>> GetAllWithCoursesAsync();
        Task<Student> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Guid id);
    }
}
