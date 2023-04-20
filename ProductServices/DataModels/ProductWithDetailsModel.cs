using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class ProductWithDetailsModel
    {
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual List<RatingModel> Raiting { get; set; }
        public virtual ViewModel View { get; set; }
        public virtual LikeModel Like { get; set; }
    }
}
