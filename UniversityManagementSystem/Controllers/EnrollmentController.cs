using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        
        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> Create([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            try
            {
                var enrollment = await _enrollmentService.CreateEnrollmentAsync(createEnrollmentDto);
                return CreatedAtAction(
                    nameof(Create), 
                    new { id = enrollment.Id },
                    enrollment);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        
        [HttpGet("exists")]
        public async Task<ActionResult<bool>> EnrollmentExists(Guid studentId, Guid courseId)
        {
            var exists = await _enrollmentService.EnrollmentExistsAsync(studentId, courseId);
            return Ok(exists);
        }
    }
}