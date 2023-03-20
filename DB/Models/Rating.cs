using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    public class Rating
    {
        [Key]
        [MaxLength(100)]
        public string Id { get; set; }

        [ForeignKey("Product")]
        [MaxLength(100)]
        [Required]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int RatingValue { get; set; }
        public string UserId { get; set; }
    }
}