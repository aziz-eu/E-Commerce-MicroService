using eCommerce.ProductMicroService.API.Entities;

namespace eCommerce.ProductMicroService.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IGenericRepository<Product>? _productRepository;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_db);

                return _productRepository;
            }
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
