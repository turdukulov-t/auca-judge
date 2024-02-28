using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Response;
using BusinessBanking.Interface.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BusinessBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto)
        {
            var token = await _authService.GenerateToken(loginDto.Login, loginDto.Password);

            if (token == null)
            {
                return BadRequest("Invalid credentials");
            }

            var response = new LoginResponse()
            {
                Token = token
            };

            return Ok(response);
        }
    }
}
