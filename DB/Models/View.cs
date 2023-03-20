using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    public class View
    {
        [Key]
        [MaxLength(100)]
        public string Id { get; set; }

        [ForeignKey("Product")]
        [MaxLength(100)]
        [Required]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TotalViews { get; set; }
        public int TodayViews { get; set; }
    }
}