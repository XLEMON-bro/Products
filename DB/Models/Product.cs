using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string ImageURL { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Rating> Raiting { get; set; }
        public virtual View View { get; set; }
        public virtual Like Like { get; set; }
    }
}
