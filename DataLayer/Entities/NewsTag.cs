using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class NewsTag
    {
        [Required]
        public string NewsArticleId { get; set; }

        [Required]
        public string TagId { get; set; }

        public NewsArticle NewsArticle { get; set; }
        public Tag Tag { get; set; }
    }
}
