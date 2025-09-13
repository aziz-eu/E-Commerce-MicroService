using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Threading.Tasks;
using eCommerce.Core.Validators;
//using FluentValidation.DependencyInjectionExtensions;


namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {           
            services.AddScoped<IUserService, UserService>();
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();

            return services;
        }
    }
}
