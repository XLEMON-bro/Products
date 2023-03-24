using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Core.Interfaces;
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
        [Route("get/{id}")]
        public async Task<JsonResult> GetProductById(string id)
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpGet]
        [Route("getall")]
        public async Task<JsonResult> GetAllProducts()
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpGet]
        [Route("getpaginated/{pageIndex}{pageSize}")]
        public async Task<JsonResult> GetPaginatedProducts(int? pageIndex, int? pageSize)
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public async Task<JsonResult> AddProduct()
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpPost]
        [Route("addrange")]
        public async Task<JsonResult> AddProducts()
        {
            return new JsonResult("mostpopularproducts");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<JsonResult> DeleteProductById(string id)
        {
            return new JsonResult("mostpopularproducts");
        }
    }
}
