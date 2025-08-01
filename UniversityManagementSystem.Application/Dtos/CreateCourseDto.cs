using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Dtos
{
    public class CreateCourseDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code is required.")]
        public string Code { get; set; }
        public int? Credits { get; set; }
    }
}