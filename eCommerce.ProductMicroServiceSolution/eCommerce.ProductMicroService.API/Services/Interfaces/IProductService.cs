using eCommerce.ProductMicroService.API.Entities;

namespace eCommerce.ProductMicroService.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
    }
}
