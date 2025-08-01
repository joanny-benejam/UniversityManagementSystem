using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityManagementSystemDbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        public IStudentRepository Students { get; }
        public ICourseRepository Courses { get; }
        public IEnrollmentRepository Enrollments { get; }

        public UnitOfWork(
            UniversityManagementSystemDbContext context,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IEnrollmentRepository enrollmentRepository)
        {
            _context = context;
            Students = studentRepository;
            Courses = courseRepository;
            Enrollments = enrollmentRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _transaction?.Dispose();
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}