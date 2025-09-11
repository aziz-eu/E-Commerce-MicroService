using eCommerce.Core.Dtos;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<AuthenticationResponse?> Login(LoginDto loginDto)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginDto.Email, loginDto.Password);
            if (user == null)
            {
                return null;
            }
            return new AuthenticationResponse(user.UserId, user.Email, user.Name, user.Gender, true, "Token");

        }

        public async Task<AuthenticationResponse?> RegistrationRequest(RegisterRequestDto registerRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = registerRequestDto.Email,
                Password = registerRequestDto.Password,
                Name = registerRequestDto.Name,
                Gender = registerRequestDto.Gender.ToString(),
            };

            ApplicationUser? applicationUser = await _usersRepository.AddUser(user);
            if (applicationUser == null)
            {
                return null;
            }
            return new AuthenticationResponse(applicationUser.UserId, applicationUser.Email, applicationUser.Name, applicationUser.Gender, IsAuthenticated: true, "token");
        }
    }
}