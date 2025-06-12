using DataLayer.DTOs; // Thêm using
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> EnrollUserInCourseAsync(EnrollmentCreateDto enrollmentDto);
        Task UnenrollUserFromCourseAsync(int userId, int courseId);
        Task<IEnumerable<EnrollmentDto>> GetUserEnrollmentsAsync(int userId);
    }
}