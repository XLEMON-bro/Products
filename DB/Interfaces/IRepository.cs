using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(string id);
    }
}
