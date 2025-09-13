using eCommerce.ProductMicroService.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ProductMicroService.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
   
}
