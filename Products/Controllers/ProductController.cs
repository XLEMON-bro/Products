using Microsoft.AspNetCore.Http;
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
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProductById(string id)
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllProducts()
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpGet]
        [Route("paginated")]
        public async Task<ActionResult> GetPaginatedProducts(int? pageIndex = 1, int? pageSize = 10)
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateProduct(ProductWithDetailsModel productWithDetails)
        {

            
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddProducts(List<ProductWithDetailsModel> productsWithDetails)
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProductById(string id)
        {
            return new JsonResult("mostpopularproducts");
        }
    }
}
