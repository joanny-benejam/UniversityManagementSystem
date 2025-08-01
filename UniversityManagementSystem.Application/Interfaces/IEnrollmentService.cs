using UniversityManagementSystem.Dtos;

namespace UniversityManagementSystem.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> CreateEnrollmentAsync(CreateEnrollmentDto enrollmentDto);
        Task<bool> EnrollmentExistsAsync(Guid studentId, Guid courseId);
    }
}