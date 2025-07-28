using UniversityManagementSystem.EntityFrameworkCore;
using UniversityManagementSystem.Utils;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//Configure DbContext
string databaseDriver = builder.Configuration["Database:Provider"];
switch (databaseDriver)
{
    case Constants.DatabaseDriver.Sqlite: { builder.Services.AddDbContext<UniversityManagementSystemDbContext, UniversityManagementSystemSqLiteDbContext>(); } break;
    case Constants.DatabaseDriver.SqlServer: { builder.Services.AddDbContext<UniversityManagementSystemDbContext, UniversityManagementSystemSqlDbContext>(); } break;
    default: { throw new Exception("Database driver not supported"); } break;
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
