namespace eCommerce.ProductMicroService.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
