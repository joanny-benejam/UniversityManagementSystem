using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(Guid id);
        Task<IEnumerable<Course>> GetAllWithStudentsAsync();
        Task<IEnumerable<Course>> GetCoursesByStudentEmailAsync(string email);
        Task<Course> AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Guid id);
    }
}