using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class LikeModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
        public int TodayLikes { get; set; }
        public int TodayDislikes { get; set; }
    }
}
