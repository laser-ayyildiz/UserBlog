using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Management.Buckets;
using UserBlogAPI.Models;

namespace UserBlogAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
    }
}