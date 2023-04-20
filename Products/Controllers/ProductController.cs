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
        public async Task<ActionResult<ProductWithDetailsModel>> GetProductWithDetailsById(string id)
        {
            var product = await _productService.GetProductWithDetailsById(id);

            if(product == null)
            {
                return BadRequest($"Failed to find product with ID: {id}");
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("paginated/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetPaginatedProductsByCategory(string categoryId, int? pageIndex = 1, int? pageSize = 10)
        {
            var paginatedProducts = await _productService.GetPaginatedProductsByCategoryAsync((int)pageIndex, (int)pageSize, categoryId);

            return Ok(paginatedProducts);
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByCategory(string categoryId, int? size = 3)
        {
            var products = await _productService.GetProductsByCategory((int)size, categoryId);

            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductWithDetailsModel productWithDetails)
        {
            var updated = await _productService.UpdateProduct(productWithDetails);

            if (updated)
            {
                return Ok();
            }

            return BadRequest($"Failed to update product with Id: {productWithDetails.ProductId}");
        }

        [HttpPost]
        public async Task<ActionResult> AddProducts(List<ProductWithDetailsModel> productsWithDetails)
        {
            var added = await _productService.AddProductsWithDetailsAsync(productsWithDetails);

            if (added)
            {
                return Ok();
            }

            return BadRequest($"Failed to add Products.");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProductById(string id)
        {
            var deleted = await _productService.DeleteProductCascadeAsync(id);

            if (deleted)
            {
                return Ok();
            }

            return BadRequest($"Failed to Delete Product : {id}");
        }
    }
}
