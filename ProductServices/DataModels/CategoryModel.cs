using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class CategoryModel //can be many
    {
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
