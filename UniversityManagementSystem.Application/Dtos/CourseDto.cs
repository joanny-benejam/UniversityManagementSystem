﻿namespace UniversityManagementSystem.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Credits { get; set; }
    }
}
