using Shop_API.Data;
using Shop_API.Models.Entities;
using Shop_API.Models.Interfaces;

namespace Shop_API.Models.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbcontext _context;

        // ✅ Expose repositories as properties
        public IGenericRepository<Product> products { get; private set; }
        public IGenericRepository<Category> categories { get; private set; }

        public UnitOfWork(AppDbcontext context)
        {
            _context = context;

            // ✅ Assign repositories to properties (not local variables!)
            products = new GenericRepository<Product>(_context);
            categories = new GenericRepository<Category>(_context);
        }

        // ✅ Commit all changes to DB
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // ✅ Dispose DbContext properly
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
