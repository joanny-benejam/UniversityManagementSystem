using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Entities
{
    public class Course
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Code { get; set; }

        public int? Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
