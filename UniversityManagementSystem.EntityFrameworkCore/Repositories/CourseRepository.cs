using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Entities;
using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityManagementSystemDbContext _dbContext;

        public CourseRepository(UniversityManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await _dbContext.Courses
                .FindAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllWithStudentsAsync()
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentEmailAsync(string email)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Where(c => c.Enrollments.Any(e => e.Student.Email == email))
                .ToListAsync();
        }

        public async Task<Course> AddAsync(Course course)
        {
            course.Id = Guid.NewGuid();
            await _dbContext.Courses.AddAsync(course);
            return course;
        }

        public async Task UpdateAsync(Course course)
        {
            _dbContext.Courses.Update(course);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course != null)
            {
                _dbContext.Courses.Remove(course);
            }
        }
    }
}