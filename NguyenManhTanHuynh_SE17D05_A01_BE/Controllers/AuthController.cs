using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataLayer.Entities;
using BusinessLayer.Repositories; 
using BusinessLayer.Services;  
using DataLayer.Utilities; 
using DataLayer.DTOs; 

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<SystemAccount> _accountRepository; 
        private readonly IAccountService _accountService; 

        public AuthController(IConfiguration configuration,
                              IGenericRepository<SystemAccount> accountRepository,
                              IAccountService accountService)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _accountRepository.GetAsync(a => a.AccountEmail == model.Email);
            if (account == null)
            {
                return Unauthorized("Invalid credentials."); // Generic message for security
            }

            if (!PasswordHasher.VerifyPassword(model.Password, account.AccountPassword))
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = GenerateJwtToken(account);
            return Ok(new AuthResponseDto
            {
                Token = token,
                AccountName = account.AccountName,
                AccountEmail = account.AccountEmail,
                AccountRole = account.AccountRole
            });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto model)         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAccount = new SystemAccount
            {
                AccountName = model.AccountName,
                AccountEmail = model.AccountEmail,
                AccountRole = model.AccountRole,
                AccountPassword = PasswordHasher.HashPassword(model.Password) 
            };

            try
            {
                await _accountService.CreateAsync(newAccount); 

                var token = GenerateJwtToken(newAccount);
                return StatusCode(201, new AuthResponseDto
                {
                    Token = token,
                    AccountName = newAccount.AccountName,
                    AccountEmail = newAccount.AccountEmail,
                    AccountRole = newAccount.AccountRole
                });
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return BadRequest(ex.Message); 
            }
        }

        private string GenerateJwtToken(SystemAccount account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id),
                new Claim(ClaimTypes.Email, account.AccountEmail),
                new Claim(ClaimTypes.Role, GetRoleString(account.AccountRole))
            };

            // Use the null-coalescing operator with throw for config values
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured in appsettings.")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer not configured in appsettings."),
                audience: _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience not configured in appsettings."),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Use UtcNow for consistency
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetRoleString(int role)
        {
            return role switch
            {
                0 => "Admin",
                1 => "Staff",
                2 => "Lecturer",
                _ => "User" // Default role if unexpected value
            };
        }
    }
}