using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string TagName { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public List<NewsTag> NewsTags { get; set; }
    }
}
