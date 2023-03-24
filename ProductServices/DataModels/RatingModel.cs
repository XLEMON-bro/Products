using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class RatingModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int RatingValue { get; set; }
        public string UserId { get; set; }
    }
}
