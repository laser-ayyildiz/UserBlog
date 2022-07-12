using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogAPI.Models;
using UserBlogAPI.Repositories.Interfaces;
using UserBlogAPI.Services.Interfaces;

namespace UserBlogAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(UserDto.Of).ToList();
        }
    }
}