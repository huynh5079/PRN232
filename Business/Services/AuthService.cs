using Business.DTOs.Auth;
using Business.Services.Interface;
using DataAccess.Entities;
using DataAccess.Repositories.Abstraction;
using DataAccess.Repositories;
using DataAccess.Enum;
using Business.Helper;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _userRepository;

        public AuthService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetAsync(u => u.Email == request.Email);

            if (user == null || !HashPassword.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            return new LoginResponseDto
            {
                UserId = user.UserId,
                Role = user.Role.ToString()
            };
        }

    }
}
