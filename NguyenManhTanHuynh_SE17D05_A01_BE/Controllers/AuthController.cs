using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataLayer.Entities;
using NguyenManhTanHuynh_SE17D05_A01_BE.Repositories;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{

    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<SystemAccount> _accountRepository;

        public AuthController(IConfiguration configuration, IGenericRepository<SystemAccount> accountRepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var account = await _accountRepository.GetAsync(a => a.AccountEmail == model.Email && a.AccountPassword == model.Password);
            if (account == null)
                return Unauthorized("Invalid email or password");

            var token = GenerateJwtToken(account);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(SystemAccount account)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, account.Id),
            new Claim(ClaimTypes.Role, account.AccountRole == 1 ? "Staff" : account.AccountRole == 2 ? "Lecturer" : "Admin")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
