using AutoMapper;
using eCommerce.ProductMicroService.API.Dtos.Product;
using eCommerce.ProductMicroService.API.Entities;

namespace eCommerce.ProductMicroService.API.Mappers
{
    public class ApplicationMappingProfile: Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
