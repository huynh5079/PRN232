using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class CourseDto
    {
        public int CoursesId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        // Flattened data from related entities
        public string CategoryName { get; set; }
        public string AuthorEmail { get; set; } // Lấy email của tác giả
    }
}
