namespace UniversityManagementSystem.Dtos
{
    public class CourseWithStudentsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Credits { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
