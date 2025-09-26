using Microsoft.AspNetCore.Mvc;

namespace Shop_API.Models.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>GetByIdAsync(int id);    
        Task AddAsync(T entity);
        void Update(T entity);
        void DeleteAsync(int id);

        
    }
}
