namespace eCommerce.ProductMicroService.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveAsync(CancellationToken cancellationToken = default);
    }
}
