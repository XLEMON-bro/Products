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

        public Task<bool> DeleteProductAsync(string id);

        public Task<ProductModel> GetProductByIdAsync(string id);

        public bool UpdateProduct(ProductModel product);

        public Task<IEnumerable<ProductModel>> GetAllProductsAsync();

        public Task<bool> AddProductsAsync(IEnumerable<ProductModel> products);

        public Task<IEnumerable<ProductModel>> GetPaginatedProductsAsync(int pageIndex, int pageSize);
    }
}
