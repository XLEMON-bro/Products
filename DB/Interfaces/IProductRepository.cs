using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IProductRepository<T> : IRepository<T> where T : Product
    {
        Task<IEnumerable<T>> GetPaginatedAsync(int pageIndex, int pageSize);
    }
}
