using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Linq;
using UserBlogAPI.Data;
using UserBlogAPI.Models;
using UserBlogAPI.Repositories.Interfaces;

namespace UserBlogAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly INamedBucketProvider _bucketProvider;

        public UserRepository(INamedBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var bucketContext = new BucketContext(await _bucketProvider.GetBucketAsync());
            var users = bucketContext
                .Query<User>()
                .Select(x => new User()
                {
                    Id = N1QlFunctions.Meta(x).Id,
                    Name = x.Name,
                })
                .ToList();

            return users;
        }
    }
}