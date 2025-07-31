using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("withcourses")]
        public async Task<ActionResult<IEnumerable<StudentWithCoursesDto>>> GetAllWithCourses()
        {
            var students = await _studentService.GetAllStudentsWithCoursesAsync();
            return Ok(students);
        }
        
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create([FromBody] CreateStudentDto createStudentDto)
        {
            var student = await _studentService.CreateStudentAsync(createStudentDto);
            
            return CreatedAtAction(
                nameof(Create),
                new { id = student.Id },
                student);
        }
    }
}
