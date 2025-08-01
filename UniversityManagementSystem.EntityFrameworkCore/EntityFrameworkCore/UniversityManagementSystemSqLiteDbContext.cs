using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.EntityFrameworkCore
{
    public class UniversityManagementSystemSqLiteDbContext : UniversityManagementSystemDbContext
    {
        public UniversityManagementSystemSqLiteDbContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration["Database:SqliteConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasConversion(
                    v => v.ToString(), 
                    v => Guid.Parse(v) 
                );

            modelBuilder.Entity<Course>()
                .Property(s => s.Id)
                .HasConversion(
                    v => v.ToString(),
                    v => Guid.Parse(v)
                );

            modelBuilder.Entity<Enrollment>()
                .Property(s => s.Id)
                .HasConversion(
                    v => v.ToString(),
                    v => Guid.Parse(v)
                );
        }
    }
}
