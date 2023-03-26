using DB.Interfaces;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class ViewRepository<T> : Repository<T>, IViewRepository<T> where T : View
    {
        public ViewRepository(ProductContext context) : base(context) { }

        public async Task<View> GetViewByProductId(string productId)
        {
            try
            {
                return await Task.Run(() => _dbSet.Where(p => p.ProductId == productId).First());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
