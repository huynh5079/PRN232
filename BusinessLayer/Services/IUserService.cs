using DataLayer.DTOs; // Thêm using
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto?> GetUserByIdAsync(int id);

        /// <summary>
        /// Xử lý đăng ký người dùng mới
        /// </summary>
        /// <param name="registerDto">Thông tin đăng ký từ client</param>
        /// <returns>Thông tin user vừa tạo (không bao gồm mật khẩu)</returns>
        Task<UserDto> RegisterUserAsync(UserRegisterDto registerDto);

        // Trong phạm vi bài thi, chúng ta không cần đến Update/Delete User phức tạp.
        // Các hành động này thường liên quan đến đổi mật khẩu, xác thực, v.v.
    }
}