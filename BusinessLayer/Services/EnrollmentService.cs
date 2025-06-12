using AutoMapper;
using BusinessLayer.Repositories;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IGenericRepository<Enrollments> _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IGenericRepository<Enrollments> enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<EnrollmentDto> EnrollUserInCourseAsync(EnrollmentCreateDto enrollmentDto)
        {
            // Kiểm tra xem user đã đăng ký khóa học này chưa
            var existingEnrollment = await _enrollmentRepository.GetAsync(e => e.UserId == enrollmentDto.UserId && e.CourseId == enrollmentDto.CourseId);
            if (existingEnrollment != null)
            {
                throw new InvalidOperationException("User is already enrolled in this course.");
            }

            var enrollmentEntity = _mapper.Map<Enrollments>(enrollmentDto);
            enrollmentEntity.EnrollmentDate = DateTime.UtcNow;

            await _enrollmentRepository.CreateAsync(enrollmentEntity);
            await _enrollmentRepository.SaveAsync();

            // Lấy lại dữ liệu vừa tạo với thông tin chi tiết để trả về
            var createdEnrollment = await _enrollmentRepository.GetAsync(
                filter: e => e.EnrollmentId == enrollmentEntity.EnrollmentId,
                includes: q => q.Include(e => e.User).Include(e => e.Course)
            );

            return _mapper.Map<EnrollmentDto>(createdEnrollment);
        }

        public async Task UnenrollUserFromCourseAsync(int userId, int courseId)
        {
            var enrollment = await _enrollmentRepository.GetAsync(e => e.UserId == userId && e.CourseId == courseId);
            if (enrollment != null)
            {
                await _enrollmentRepository.RemoveAsync(enrollment);
                await _enrollmentRepository.SaveAsync();
            }
        }

        public async Task<IEnumerable<EnrollmentDto>> GetUserEnrollmentsAsync(int userId)
        {
            var enrollments = await _enrollmentRepository.GetAllAsync(
                filter: e => e.UserId == userId,
                includes: q => q.Include(e => e.Course) // Chỉ cần lấy thông tin khóa học
            );

            // Cần map thủ công một chút ở đây nếu không muốn include quá nhiều
            // Hoặc đơn giản là include tất cả
            var enrollmentsWithDetails = await _enrollmentRepository.GetAllAsync(
                filter: e => e.UserId == userId,
                includes: q => q.Include(e => e.Course).Include(e => e.User)
            );
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollmentsWithDetails);
        }
    }
}