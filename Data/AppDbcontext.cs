using Microsoft.EntityFrameworkCore;
using Shop_API.Models.Entities;

namespace Shop_API.Data
{
    public class AppDbcontext:DbContext

    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbcontext( DbContextOptions<AppDbcontext> dbContextOptions ):base( dbContextOptions )
        {
           
            
        }
       
        }
}
