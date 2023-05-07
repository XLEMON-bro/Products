using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IProductRepository<T> : IRepository<T> where T : Product
    {
        Task<IEnumerable<T>> GetPaginatedAsync(int pageIndex, int pageSize, string categoryId);

        Task<int> GetAmountOfPagesForCategoryAsync(int pageSize, string categoryId);

        Task<Product> GetProductWithDetails(string id);

        Task<IEnumerable<Product>> GetProductsByCategory(int Size, string categoryId);

        Task<bool> DeleteOnCascadeByID(string id);
    }
}
