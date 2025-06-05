using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class NewsArticle : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string NewsTitle { get; set; }

        [Required]
        public string NewsContent { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool NewsStatus { get; set; } // true: Active, false: Inactive

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string CreatedById { get; set; }

        public Category Category { get; set; }
        public SystemAccount CreatedBy { get; set; }
        public List<NewsTag> NewsTags { get; set; }
    }
}
