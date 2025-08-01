using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Entities;
using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly UniversityManagementSystemDbContext _dbContext;

        public EnrollmentRepository(UniversityManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Enrollment> AddAsync(Enrollment enrollment)
        {
            if (enrollment.Id == Guid.Empty)
            {
                enrollment.Id = Guid.NewGuid();
            }
            
            if (enrollment.EnrollmentDate == default)
            {
                enrollment.EnrollmentDate = DateTime.UtcNow;
            }
            
            await _dbContext.Enrollments.AddAsync(enrollment);
            return enrollment;
        }

        public async Task<bool> ExistsAsync(Guid studentId, Guid courseId)
        {
            return await _dbContext.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }
    }
}