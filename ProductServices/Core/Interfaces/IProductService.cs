using DB.Models;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Interfaces
{
    public interface IProductService
    {
        public Task<bool> AddProductAsync(ProductModel product);

        public Task<bool> DeleteProductCascadeAsync(string id);

        public Task<ProductModel> GetProductByIdAsync(string id);

        public Task<bool> UpdateProduct(ProductWithDetailsModel product);

        public Task<IEnumerable<ProductModel>> GetAllProductsAsync();

        public Task<bool> AddProductsAsync(IEnumerable<ProductModel> products);

        public Task<IEnumerable<ProductModel>> GetPaginatedProductsByCategoryAsync(int pageIndex, int pageSize, string categoryId);

        public Task<ProductWithDetailsModel> GetProductWithDetailsById(string id);

        public Task<bool> AddProductsWithDetailsAsync(List<ProductWithDetailsModel> product);

        public Task<IEnumerable<ProductModel>> GetProductsByCategory(int Size, string categoryId);
    }
}
