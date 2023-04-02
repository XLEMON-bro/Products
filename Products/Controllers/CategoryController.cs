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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound($"There is no View with ID: {id}");

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            if (categories == null)
                return BadRequest($"Unable to get all gategories.");

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategories(List<CategoryModel> categoriesModel)
        {
            var added = await _categoryService.AddCategoriesAsync(categoriesModel);

            if (added)
            {
                return Ok();
            }
            return BadRequest("Unable to add View");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCategoryById(string id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound($"There is no View with ID: {id}");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(CategoryModel categoryModel)
        {
            var updated = await _categoryService.UpdateCategory(categoryModel);

            if (updated)
            {
                return Ok();
            }

            return BadRequest($"Unable to update view with Id: {categoryModel.CategoryId}");
        }
    }
}
