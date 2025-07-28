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
        public DbSet<Student> Students { get; set; }
    }
}
