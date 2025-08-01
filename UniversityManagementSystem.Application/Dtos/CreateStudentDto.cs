using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Dtos
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}