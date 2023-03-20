using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.JsonModels
{
    public class ProductsRecomentadionJsonModel
    {
        [JsonProperty("recomendations")]
        public List<ProductRecomendationJsonModel> RecomendedProducts { get; set; }
    }
}
