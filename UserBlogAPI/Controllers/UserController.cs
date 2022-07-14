using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserBlogAPI.Models;
using UserBlogAPI.Services.Interfaces;

namespace UserBlogAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            var user = await _userService.CreateAsync(userCreateDto);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.DeleteAsync(id);
            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, UserUpdateDto userDto)
        {
            var user = await _userService.UpdateAsync(id, userDto);
            return Ok(user);
        }
    }
}