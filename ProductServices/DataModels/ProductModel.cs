using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class ProductModel
    {
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string CategoryId { get; set; }
    }
}
