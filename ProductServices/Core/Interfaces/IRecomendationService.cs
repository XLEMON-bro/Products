using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Interfaces
{
    public interface IRecomendationService
    {
        Task<IEnumerable<ProductModel>> GetMostViewedTodayProducts();
        Task<IEnumerable<ProductModel>> GetMostViewedTodayProductsByCategory(string categoryId);
        Task<IEnumerable<ProductModel>> GetMostLikedTodayProducts();
        Task<IEnumerable<ProductModel>> GetMostLikedTodayProductsByCategory(string categoryId);
    }
}
