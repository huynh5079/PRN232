using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string TagName { get; set; } = string.Empty;

        [Required] 
        [StringLength(255)] 
        public string Note { get; set; } = string.Empty;

        public List<NewsTag> NewsTags { get; set; } = new List<NewsTag>();
    }
}