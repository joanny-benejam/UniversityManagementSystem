using UniversityManagementSystem.Dtos;

public class StudentWithCoursesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public IEnumerable<CourseDto> Courses { get; set; } 
    }