using Business.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Presentation.Models;

namespace Presentation.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public List<BookDto> Books { get; set; } = new();

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGetAsync()
        {
            var baseUrl = _configuration["ApiBaseUrl"];

            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            var response = await client.GetFromJsonAsync<PaginatedResponse<BookDto>>("/api/book");
            Books = response?.Data ?? new List<BookDto>();
        }

    }
}
