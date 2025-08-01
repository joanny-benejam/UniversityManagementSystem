using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.EntityFrameworkCore
{
    public class UniversityManagementSystemSqlDbContext : UniversityManagementSystemDbContext
    {
        public UniversityManagementSystemSqlDbContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration["Database:SqlServerConnection"]);
        }
    }
}
