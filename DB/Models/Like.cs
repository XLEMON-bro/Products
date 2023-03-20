using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
        public int TodayLikes { get; set; }
        public int TodayDislikes { get; set; }
    }
}