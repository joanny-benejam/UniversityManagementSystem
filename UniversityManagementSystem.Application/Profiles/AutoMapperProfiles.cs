using AutoMapper;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>()
                .ReverseMap();

            CreateMap<Student, StudentWithCoursesDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Course)))
                .ReverseMap();

            CreateMap<CreateStudentDto, Student>();

            CreateMap<Course, CourseDto>()
                .ReverseMap();

            CreateMap<Course, CourseWithStudentsDto>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Student)))
                .ReverseMap();

            CreateMap<CreateCourseDto, Course>();

            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ReverseMap();

            CreateMap<CreateEnrollmentDto, Enrollment>()
                .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
