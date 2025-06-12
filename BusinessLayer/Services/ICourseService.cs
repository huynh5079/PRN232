using DataLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICourseService
    {
        IQueryable<CourseDto> GetAllAsQueryable();
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();

        Task<CourseDto?> GetCourseByIdAsync(int id);

        Task<CourseDto> CreateCourseAsync(CourseCreateDto courseDto);

        Task UpdateCourseAsync(int id, CourseUpdateDto courseDto);

        Task DeleteCourseAsync(int id);
    }
}