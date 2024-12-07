using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tarifler.Data;
using Tarifler.Service.Abstract;

namespace Tarifler.Service.Concrete
{
        public class EfService<T> : IService<T> where T : class
        {
            private readonly TarifDbContext _context;
            private DbSet<T> _dbSet;

            public EfService(TarifDbContext context)
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }

            public void Add(T item)
            {
                _dbSet.Add(item);
                _context.SaveChanges();
            }

            public async Task AddAsync(T item)
            {
                await _dbSet.AddAsync(item);
                await _context.SaveChangesAsync();
            }

            public void Delete(T item)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }

            public async Task DeleteAsync(T item)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }

            public List<T> GetAll()
            {
                return _dbSet.ToList();
            }

            public async Task<List<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public List<T> GetAllWhere(Expression<Func<T, bool>> expression)
            {
                return _dbSet.Where(expression).ToList();
            }

            public async Task<List<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression)
            {
                return await _dbSet.Where(expression).ToListAsync();
            }

            public T GetFind(int id)
            {
                return _dbSet.Find(id);
            }

            public async Task<T> GetFindAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }

            public T GetFirst(Expression<Func<T, bool>> expression)
            {
                return _dbSet.FirstOrDefault(expression);
            }

            public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
            {
                return await _dbSet.FirstOrDefaultAsync(expression);
            }

            public IQueryable<T> GetQueryable()
            {
                return _dbSet;
            }

            public void Update(T item)
            {
                _dbSet.Update(item);
                _context.SaveChanges();
            }

            public async Task UpdateAsync(T item)
            {
                _dbSet.Update(item);
                await _context.SaveChangesAsync();
            }
        }
}
