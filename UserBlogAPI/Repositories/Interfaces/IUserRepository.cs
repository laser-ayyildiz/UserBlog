using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Management.Buckets;
using UserBlogAPI.Data;

namespace UserBlogAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllAsync();
    }
}