using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLayer.Repositories;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Courses> _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(IGenericRepository<Courses> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public IQueryable<CourseDto> GetAllAsQueryable()
        {
            // 1. Lấy IQueryable<Courses> từ Repository
            var coursesQuery = _courseRepository.GetAllAsQueryable(
                includes: query => query.Include(c => c.Category).Include(c => c.User)
            );

            // 2. Dùng ProjectTo của AutoMapper để tạo ra IQueryable<CourseDto>
            return coursesQuery.ProjectTo<CourseDto>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync(
                includes: query => query.Include(c => c.Category).Include(c => c.User)
            );
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto?> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetAsync(
                filter: c => c.CoursesId == id,
                includes: query => query.Include(c => c.Category).Include(c => c.User)
            );
            return _mapper.Map<CourseDto?>(course);
        }

        public async Task<CourseDto> CreateCourseAsync(CourseCreateDto courseDto)
        {
            // Dùng AutoMapper để chuyển từ DTO sang Entity
            var courseEntity = _mapper.Map<Courses>(courseDto);

            // Xử lý logic nghiệp vụ
            courseEntity.CreatedAt = DateTime.UtcNow;

            await _courseRepository.CreateAsync(courseEntity);
            await _courseRepository.SaveAsync();

            // Lấy lại entity vừa tạo với đầy đủ thông tin để map sang DTO trả về
            var createdCourse = await GetCourseByIdAsync(courseEntity.CoursesId);
            return createdCourse;
        }

        public async Task UpdateCourseAsync(int id, CourseUpdateDto courseDto)
        {
            var existingCourse = await _courseRepository.GetAsync(c => c.CoursesId == id);
            if (existingCourse == null)
            {
                // Hoặc throw một exception NotFound
                return;
            }

            // Dùng AutoMapper để cập nhật các thuộc tính từ DTO vào entity đã có
            _mapper.Map(courseDto, existingCourse);

            await _courseRepository.UpdateAsync(existingCourse);
            await _courseRepository.SaveAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetAsync(c => c.CoursesId == id);
            if (course != null)
            {
                await _courseRepository.RemoveAsync(course);
                await _courseRepository.SaveAsync();
            }
        }
    }
}