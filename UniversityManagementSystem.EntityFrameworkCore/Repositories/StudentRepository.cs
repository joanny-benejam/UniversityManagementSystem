using UniversityManagementSystem.Entities;
using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace UniversityManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityManagementSystemDbContext _dbContext;

        public StudentRepository(UniversityManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
