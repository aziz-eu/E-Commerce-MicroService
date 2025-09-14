using eCommerce.ProductMicroService.API.Entities;

namespace eCommerce.ProductMicroService.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
    }
}
