using System.ComponentModel.DataAnnotations;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.DTOs
{
    public class UpdateNewsArticleDto
    {
        
        [StringLength(200, ErrorMessage = "News title cannot exceed 200 characters.")]
        public string? NewsTitle { get; set; } // Nullable if optional update

        public string? NewsContent { get; set; } // same

        public bool? NewsStatus { get; set; } // same

        public string? CategoryId { get; set; } // same

        //public string? CreatedById { get; set; } 
        public List<string>? TagIds { get; set; }
    }
}