using AutoMapper;
using UniversityManagementSystem.Dtos;
using UniversityManagementSystem.Entities;
using UniversityManagementSystem.Interfaces;

namespace UniversityManagementSystem.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EnrollmentDto> CreateEnrollmentAsync(CreateEnrollmentDto enrollmentDto)
        {
            bool enrollmentExists = await EnrollmentExistsAsync(enrollmentDto.StudentId, enrollmentDto.CourseId);
            if (enrollmentExists)
            {
                throw new InvalidOperationException("The student is already enrolled in this course");
            }

            var student = await _unitOfWork.Students.GetByIdAsync(enrollmentDto.StudentId);
            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            var course = await _unitOfWork.Courses.GetByIdAsync(enrollmentDto.CourseId);
            if (course == null)
            {
                throw new ArgumentException("Course not found");
            }

            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            enrollment.EnrollmentDate = DateTime.UtcNow;
            
            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<EnrollmentDto>(enrollment);
        }

        public async Task<bool> EnrollmentExistsAsync(Guid studentId, Guid courseId)
        {
            return await _unitOfWork.Enrollments.ExistsAsync(studentId, courseId);
        }
    }
}