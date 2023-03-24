using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [ApiController]
    [Route("api/recomendations")]
    public class RecomendationsController : ControllerBase
    {
        private readonly ILogger<RecomendationsController> _logger;

        private IRecomendationService _recomendationService;

        public RecomendationsController(ILogger<RecomendationsController> logger, IRecomendationService recomendationService)
        {
            _logger = logger;
            _recomendationService = recomendationService;
        }

        [HttpGet]
        [Route("mostpopular")]
        public async Task<JsonResult> GetMostPopularProducts()
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpGet]
        [Route("bycategory")]
        public async Task<JsonResult> GetPopularProductsByCategory(string category)
        {
            return new JsonResult("popularbycategory");
        }
    }
}
