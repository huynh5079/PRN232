using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryDescription { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
