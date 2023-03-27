using DB.Interfaces;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class LikeRepository<T> : Repository<T>, ILikeRepository<T> where T : Like
    {
        public LikeRepository(ProductContext context) : base(context) { }

        public async Task<Like> GetLikeByProductId(string productId)
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
