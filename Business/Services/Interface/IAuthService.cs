using Business.DTOs.Auth;

namespace Business.Services.Interface
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
