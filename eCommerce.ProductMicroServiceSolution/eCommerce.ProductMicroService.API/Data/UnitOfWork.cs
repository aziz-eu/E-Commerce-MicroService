
using eCommerce.ProductMicroService.API.Entities;

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
            throw new NotImplementedException();
        }



        //public IOrderDetailRepository OrderDetail { get; private set; }



        public void SaveAsync()
        {
            _db.SaveChanges();
        }

        public void SaveAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
