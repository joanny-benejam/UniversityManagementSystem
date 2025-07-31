using AutoMapper;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Entities;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(Guid id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateStudentAsync(CreateStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<IEnumerable<StudentWithCoursesDto>> GetAllStudentsWithCoursesAsync()
        {
            var students = await _unitOfWork.Students.GetAllWithCoursesAsync();
            return _mapper.Map<IEnumerable<StudentWithCoursesDto>>(students);
        }
    }
}
