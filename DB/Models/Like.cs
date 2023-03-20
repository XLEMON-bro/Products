using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    public class Like
    {
        [Key]
        [MaxLength(100)]
        public string Id { get; set; }

        [ForeignKey("Product")]
        [MaxLength(100)]
        [Required]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
        public int TodayLikes { get; set; }
        public int TodayDislikes { get; set; }
    }
}