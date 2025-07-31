using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Entities;
using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Interfaces;

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
            return await _dbContext.Students
                .AsNoTracking()
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Course)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _dbContext.Students
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> GetByEmailAsync(string email)
        {
            return await _dbContext.Students
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<IEnumerable<Student>> GetAllWithCoursesAsync()
        {
            return await _dbContext.Students
                .AsNoTracking()
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Course)
                .ToListAsync();
        }

        public async Task<Student> AddAsync(Student student)
        {
            student.Id = Guid.NewGuid();
            await _dbContext.Students.AddAsync(student);
            return student;
        }

        public async Task UpdateAsync(Student student)
        {
            _dbContext.Students.Update(student);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
            }
        }
    }
}
