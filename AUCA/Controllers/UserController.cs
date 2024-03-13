using AUCA.Domain.DTO.Users;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BusinessBanking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userService.GetUsers();

            if (users == null)
            {
                return StatusCode(500);
            }

            return Ok(users);
        }

        [HttpGet("GetUserByLogin/{login}")]
        public async Task<ActionResult<User>> GetUserByLogin(string login)
        {
            var user = await _userService.GetUserByLogin(login);

            if (user == null)
            {
                return StatusCode(500);
            }

            return Ok(user);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<User>> Add(UserCreateDto dto)
        {
            var user = await _userService.CreateAsync(dto);

            if (user == null)
            {
                return StatusCode(500);
            }

            return Ok(user);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<User>> Update(UserUpdateDto dto)
        {
            var user = await _userService.UpdateAsync(dto);

            if (user == null)
            {
                return StatusCode(500);
            }

            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<HttpStatusCode>> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);

            return result;
        }
    }
}
