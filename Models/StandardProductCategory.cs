using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class StandardProductCategory
    {
        public DatabaseContext context;

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryDescription { get; set; }
    }
}
