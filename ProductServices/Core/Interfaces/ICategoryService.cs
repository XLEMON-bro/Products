using DB.Models;
using ProductServices.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> AddCategoryAsync(CategoryModel category);

        public Task<bool> DeleteCategoryAsync(string id);

        public Task<CategoryModel> GetCategoryByIdAsync(string id);

        public Task<bool> UpdateCategory(CategoryModel category);

        public Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();

        public Task<bool> AddCategoriesAsync(IEnumerable<CategoryModel> categories);
    }
}
