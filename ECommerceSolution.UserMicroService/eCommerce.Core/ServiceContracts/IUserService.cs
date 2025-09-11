using eCommerce.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Login(LoginDto loginDto);
        Task<AuthenticationResponse?> RegistrationRequest(RegisterRequestDto registerRequestDto);
    }
}
