using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class SystemAccount : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string AccountEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountPassword { get; set; }

        [Required]
        public int AccountRole { get; set; } // 1: Staff, 2: Lecturer
    }
}
