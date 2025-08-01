using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("withstudents")]
        public async Task<ActionResult<IEnumerable<CourseWithStudentsDto>>> GetAllWithStudents()
        {
            var courses = await _courseService.GetAllCoursesWithStudentsAsync();
            return Ok(courses);
        }
        
        [HttpGet("student/{email}")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetByStudentEmail(string email)
        {
            var courses = await _courseService.GetCoursesByStudentEmailAsync(email);
            return Ok(courses);
        }
        
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Create([FromBody] CreateCourseDto createCourseDto)
        {
            var course = await _courseService.CreateCourseAsync(createCourseDto);
            
            return CreatedAtAction(
                nameof(Create),
                new { id = course.Id },
                course);
        }
    }
}