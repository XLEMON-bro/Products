using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
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
        [Route("mostlikedtoday")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetMostLikedProducts()
        {
            var products = await _recomendationService.GetMostLikedTodayProducts();

            if(products == null)
            {
                return BadRequest($"Unable to get most liked products.");
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("mostlikedtoday/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetMostLikedByCategotyProducts(string categoryId)
        {
            var products = await _recomendationService.GetMostLikedTodayProductsByCategory(categoryId);

            if (products == null)
            {
                return BadRequest($"Unable to get most liked products by category.");
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("mostviewed")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetMostViewedProducts()
        {
            var products = await _recomendationService.GetMostViewedTodayProducts();

            if (products == null)
            {
                return BadRequest($"Unable to get most viewed products.");
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("mostviewed/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetMostViewedByCategoryProducts(string categoryId)
        {
            var products = await _recomendationService.GetMostViewedTodayProductsByCategory(categoryId);

            if (products == null)
            {
                return BadRequest($"Unable to get most viewed products by category.");
            }

            return Ok(products);
        }
    }
}
