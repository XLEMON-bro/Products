using DB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProductContext _context;
        protected readonly DbSet<T> _dbSet;
        //TODO : Add loggs of errors
        public Repository(ProductContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                if(_context.SaveChanges() > 0)
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

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
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

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                T entity = await _dbSet.FindAsync(id);
                _dbSet.Remove(entity);
                if(await _context.SaveChangesAsync() > 0)
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
