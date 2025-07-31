using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.Dtos;

namespace UniversityManagementSystem.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(Guid id);
        Task<StudentDto> CreateStudentAsync(CreateStudentDto studentDto);
        Task<IEnumerable<StudentWithCoursesDto>> GetAllStudentsWithCoursesAsync();
    }
}
