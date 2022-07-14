using System.Collections.Generic;
using System.Threading.Tasks;
using UserBlogAPI.Models;

namespace UserBlogAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> GetByIdAsync(string id);

        Task<UserDto> CreateAsync(UserCreateDto userCreateDto);

        Task<bool> DeleteAsync(string id);

        Task<bool> UpdateAsync(string id, UserUpdateDto userDto);
    }
}