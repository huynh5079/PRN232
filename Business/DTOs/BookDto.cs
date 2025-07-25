using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int? AssignedTo { get; set; }
        public string? AssignedToEmail { get; set; }  // Optional: for include User.Email
    }
}
