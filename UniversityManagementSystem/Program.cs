using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Interfaces;
using UniversityManagementSystem.Profiles;
using UniversityManagementSystem.Repositories;
using UniversityManagementSystem.Services;
using UniversityManagementSystem.Utils;

var builder = WebApplication.CreateBuilder(args);

// Load configuration based on the environment
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

//Configure DbContext
string databaseDriver = builder.Configuration["Database:Provider"];
switch (databaseDriver)
{
    case Constants.DatabaseDriver.Sqlite: { builder.Services.AddDbContext<UniversityManagementSystemDbContext, UniversityManagementSystemSqLiteDbContext>(); } break;
    case Constants.DatabaseDriver.SqlServer: { builder.Services.AddDbContext<UniversityManagementSystemDbContext, UniversityManagementSystemSqlDbContext>(); } break;
    default: { throw new Exception("Database driver not supported"); } break;
}

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Añadir registros
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; // Optional: to format the JSON
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UniversityManagementSystemDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCorsPolicy");

app.MapControllers();

app.Run();
