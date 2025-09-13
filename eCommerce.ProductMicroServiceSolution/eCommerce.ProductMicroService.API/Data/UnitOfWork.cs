
using eCommerce.ProductMicroService.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ProductMicroService.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
        
            cancellationToken = new CancellationToken(); 
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
