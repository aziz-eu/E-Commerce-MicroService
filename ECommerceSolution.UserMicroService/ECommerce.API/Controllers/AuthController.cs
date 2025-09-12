using eCommerce.Core.Dtos;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("user-rigistration")]
        public async Task<IActionResult> UserRegistration(RegisterRequestDto registerRequest)
        {
            if(registerRequest == null)
            {
                return BadRequest("Invalid user Info");
            }

       
            AuthenticationResponse? authenticationResponse =  await _userService.RegistrationRequest(registerRequest);

            if(authenticationResponse == null || authenticationResponse.IsAuthenticated == false)
            {
                return BadRequest("User registration failed");
            }
            return Ok(authenticationResponse);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto login) { 

            if(login == null)
            {
                return BadRequest("Invalid Login Info");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(login);
            if(authenticationResponse == null || authenticationResponse.IsAuthenticated == false)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);

        }
    }
}
