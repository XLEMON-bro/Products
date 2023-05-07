using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class PaginatedProductModel
    {
        public int Pages { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}
