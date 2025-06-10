using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataLayer.DTOs
{
    public class CreateNewsArticleDto
    {
        [Required(ErrorMessage = "News title is required.")]
        [StringLength(200, ErrorMessage = "News title cannot exceed 200 characters.")]
        public string NewsTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "News content is required.")]
        public string NewsContent { get; set; } = string.Empty;

        public bool NewsStatus { get; set; } = true;

        [Required(ErrorMessage = "Category ID is required.")]
        public string CategoryId { get; set; } = string.Empty;

        public List<string> TagIds { get; set; } = new List<string>();
    }
}