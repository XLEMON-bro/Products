using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}