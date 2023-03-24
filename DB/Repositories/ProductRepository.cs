using DB.Interfaces;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class ProductRepository<T> : Repository<T>, IProductRepository<T> where T : Product
    {
        public ProductRepository(ProductContext context) : base(context) { }

        public async Task<IEnumerable<T>> GetPaginatedAsync(int pageIndex, int pageSize)
        {
            try
            {
                return await _dbSet.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
