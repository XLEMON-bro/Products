using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IRecomendationRepository
    {
        Task<IEnumerable<Product>> GetMostViewedTodayProducts();
        Task<IEnumerable<Product>> GetMostViewedTodayProductsByCategory(string categoryId);
        Task<IEnumerable<Product>> GetMostLikedTodayProducts();
        Task<IEnumerable<Product>> GetMostLikedTodayProductsByCategory(string categoryId);
    }
}
