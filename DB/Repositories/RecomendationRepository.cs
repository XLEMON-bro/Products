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
    public class RecomendationRepository : IRecomendationRepository
    {
        protected readonly ProductContext _context;
        //TODO : Add loggs of errors
        public RecomendationRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetMostLikedTodayProducts() // 9
        {
            try
            {
                return await _context.Likes
                    .OrderByDescending(l => l.TodayLikes)
                    .Include(p => p.Product)
                    .Take(9)
                    .Select(p => p.Product)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<Product>();
            }
        }

        public async Task<IEnumerable<Product>> GetMostLikedTodayProductsByCategory(string categoryId) // 6
        {
            try
            {
                return await _context.Likes
                    .OrderByDescending(l => l.TodayLikes)
                    .Include(p => p.Product)
                    .Where(p => p.Product.CategoryId == categoryId)
                    .Take(6)
                    .Select(p => p.Product)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Product>();
            }
        }

        public async Task<IEnumerable<Product>> GetMostViewedTodayProducts() // 9
        {
            try
            {
                return await _context.Views
                    .OrderByDescending(l => l.TodayViews)
                    .Include(p => p.Product)
                    .Take(9)
                    .Select(p => p.Product)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Product>();
            }
        }

        public async Task<IEnumerable<Product>> GetMostViewedTodayProductsByCategory(string categoryId) // 6
        {
            try
            {
                return await _context.Views
                    .OrderByDescending(l => l.TodayViews)
                    .Include(p => p.Product)
                    .Where(p => p.Product.CategoryId == categoryId)
                    .Take(6)
                    .Select(p => p.Product)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Product>();
            }
        }
    }
}
