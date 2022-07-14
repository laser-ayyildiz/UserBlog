using System.Collections.Generic;
using System.Threading.Tasks;
using UserBlogAPI.Data;
using UserBlogAPI.Models;

namespace UserBlogAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(string id);

        Task CreateAsync(UserCreateDto user);

        Task<bool> DeleteAsync(string id);

        Task<bool> UpdateAsync(string id, UserUpdateDto userDto);
    }
}