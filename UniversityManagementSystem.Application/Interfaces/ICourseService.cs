using UniversityManagementSystem.Dtos;

namespace UniversityManagementSystem.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(Guid id);
        Task<CourseDto> CreateCourseAsync(CreateCourseDto courseDto);
        Task<IEnumerable<CourseWithStudentsDto>> GetAllCoursesWithStudentsAsync();
        Task<IEnumerable<CourseDto>> GetCoursesByStudentEmailAsync(string email);
    }
}