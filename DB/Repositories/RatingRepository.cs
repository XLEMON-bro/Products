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
    public class RatingRepository<T> : Repository<T>, IRatingRepository<T> where T : Rating
    {
        public RatingRepository(ProductContext context) : base(context) {}

        public async Task<IEnumerable<Rating>> GetRatingsByProductId(string productId)
        {
            try
            {
                return await Task.Run(() => _dbSet.Where(p => p.ProductId == productId).ToListAsync());
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
