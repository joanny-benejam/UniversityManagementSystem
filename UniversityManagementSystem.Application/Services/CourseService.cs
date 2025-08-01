using AutoMapper;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Entities;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> CreateCourseAsync(CreateCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<IEnumerable<CourseWithStudentsDto>> GetAllCoursesWithStudentsAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllWithStudentsAsync();
            return _mapper.Map<IEnumerable<CourseWithStudentsDto>>(courses);
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByStudentEmailAsync(string email)
        {
            var courses = await _unitOfWork.Courses.GetCoursesByStudentEmailAsync(email);
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }
    }
}