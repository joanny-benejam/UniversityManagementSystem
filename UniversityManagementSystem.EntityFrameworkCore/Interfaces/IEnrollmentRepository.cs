using System;
using System.Threading.Tasks;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> AddAsync(Enrollment enrollment);
        Task<bool> ExistsAsync(Guid studentId, Guid courseId);
    }
}