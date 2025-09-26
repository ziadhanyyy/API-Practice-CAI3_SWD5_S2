using Shop_API.Models.Entities;

namespace Shop_API.Models.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Category> categories { get; }
        IGenericRepository<Product> products { get; }
        Task<int> SaveAsync();
    }
}
