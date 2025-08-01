using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Dtos
{
    public class CreateEnrollmentDto
    {
        [Required(ErrorMessage = "StudentId is required.")]
        [NotEmptyGuid(ErrorMessage = "StudentId cannot be an empty GUID.")]
        public Guid StudentId { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        [NotEmptyGuid(ErrorMessage = "CourseId cannot be an empty GUID.")]
        public Guid CourseId { get; set; }
    }
}