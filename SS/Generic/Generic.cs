
using Microsoft.EntityFrameworkCore;
using SS.Models;

namespace SS.Generic
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        protected readonly AppDbContext _context;
        public Generic(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
}
