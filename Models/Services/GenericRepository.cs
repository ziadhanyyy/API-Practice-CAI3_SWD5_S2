using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_API.Data;
using Shop_API.Models.Interfaces;
using System.Threading.Tasks;

namespace Shop_API.Models.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbcontext _dbcontext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbcontext dbcontext)

        {
            _dbcontext = dbcontext;
            _dbSet = _dbcontext.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteAsync(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

       

        public void Update(T entity)
        {
            _dbSet.Attach(entity);              // Attach entity to context
            _dbcontext.Entry(entity).State = EntityState.Modified;  // Mark as modified
        }
    }
}
