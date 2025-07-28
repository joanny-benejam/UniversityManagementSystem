using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Entities
{
    public class Student
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
