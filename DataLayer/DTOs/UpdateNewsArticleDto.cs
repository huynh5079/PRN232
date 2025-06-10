using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataLayer.DTOs
{
    public class UpdateNewsArticleDto
    {
        [StringLength(200, ErrorMessage = "News title cannot exceed 200 characters.")]
        public string? NewsTitle { get; set; }

        public string? NewsContent { get; set; }

        public bool? NewsStatus { get; set; }

        public string? CategoryId { get; set; }

        public string? CreatedById { get; set; }

        public List<string>? TagIds { get; set; }
    }
}