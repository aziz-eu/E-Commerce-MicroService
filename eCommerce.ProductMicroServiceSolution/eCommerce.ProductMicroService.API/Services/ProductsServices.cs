using eCommerce.ProductMicroService.API.Data;
using eCommerce.ProductMicroService.API.Entities;
using eCommerce.ProductMicroService.API.Services.Interfaces;

namespace eCommerce.ProductMicroService.API.Services
{
    public class ProductsServices:IProductService
    {
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsServices(IGenericRepository<Product> productsRepository, IUnitOfWork unitOfWork)
        {
            _productsRepository = productsRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAll();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productsRepository.Get(id);
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            var newProduct = await _productsRepository.Add(product);
            await _unitOfWork.SaveAsync();
            return newProduct;
        }
        public async Task UpdateProductAsync(Product product)
        {
            await _productsRepository.Update(product);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await _productsRepository.Get(id);
            if (product != null)
            {
                await _productsRepository.Delete(product);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
