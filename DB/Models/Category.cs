using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Category
    {
        [Key]
        [MaxLength(100)]
        public string CategoryId { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        [Required]
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}