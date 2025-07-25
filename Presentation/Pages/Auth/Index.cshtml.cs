using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Pages.Auth
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            using var client = new HttpClient();

            string apiBaseUrl = _configuration["ApiBaseUrl"];
            client.BaseAddress = new Uri(apiBaseUrl);

            var loginPayload = new { Email, Password };
            var response = await client.PostAsJsonAsync("/api/auth/login", loginPayload);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                // Gợi ý lưu vào TempData hoặc Session nếu cần:
                // TempData["User"] = json;

                return RedirectToPage("/Book/Index");
            }
            else
            {
                Message = "Login failed. Please check credentials.";
                return Page();
            }
        }
    }
}
