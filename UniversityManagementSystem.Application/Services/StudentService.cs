using AutoMapper;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }
    }
}
