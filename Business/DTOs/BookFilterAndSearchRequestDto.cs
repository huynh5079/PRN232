using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BookFilterAndSearchRequestDto
    {
        public string? SearchTerm { get; set; }
        public string? TitleStartsWith { get; set; }
        public string? SortBy { get; set; } = "Author"; // Default sort
        public bool SortAsc { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
