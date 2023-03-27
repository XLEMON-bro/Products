using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IRatingRepository<T> : IRepository<T> where T : Rating
    {
        Task<IEnumerable<Rating>> GetRatingsByProductId(string productId);
    }
}
