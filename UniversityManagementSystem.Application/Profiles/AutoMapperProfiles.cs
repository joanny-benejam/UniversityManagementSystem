using AutoMapper;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Entities;

namespace UniversityManagementSystem.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
