﻿using DB.Interfaces;
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
        private Random _random = new Random();

        public ProductRepository(ProductContext context) : base(context) { }

        public async Task<IEnumerable<T>> GetPaginatedAsync(int pageIndex, int pageSize, string categoryId)
        {
            try
            {
                return await _dbSet.Where(p => p.CategoryId == categoryId)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<int> GetAmountOfPagesForCategoryAsync(int pageSize, string categoryId)
        {
            try
            {
                var products = await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
                return (int)Math.Ceiling((double)products.Count() / pageSize);

            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public async Task<Product> GetProductWithDetails(string id)
        {
            try
            {
                return await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Like)
                    .Include(p => p.Raiting)
                    .FirstOrDefaultAsync(p => p.ProductId == id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int Size, string categoryId)
        {
            try
            {
                var count = _context.Products.Count();

                return await _dbSet.Where(p => p.CategoryId == categoryId)
                    .Skip(_random.Next(0, count - Size))
                    .Take(Size)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<bool> DeleteOnCascadeByID(string id)
        {
            try
            {
                var productWithDetails = await GetProductWithDetails(id);

                if (productWithDetails == null)
                {
                    return false;
                }

                _context.Remove(productWithDetails);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
