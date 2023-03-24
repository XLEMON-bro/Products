using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.JsonModels
{
    public class ProductRecomendationJsonModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categoryid")]
        public string CategoryID { get; set; }

        [JsonProperty("categoryname")]
        public string CategoryName { get; set; }

        [JsonProperty("imageurl")]
        public string ImageURL { get; set; }

        [JsonProperty("totalviews")]
        public int TotalViews { get; set; }
    }
}
