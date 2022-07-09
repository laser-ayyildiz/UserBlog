using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Linq;
using Microsoft.AspNetCore.Mvc;
using UserBlogAPI.Data;
using UserBlogAPI.Models;

namespace UserBlogAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly INamedBucketProvider _bucketProvider;

        public UserController(INamedBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bucketContext = new BucketContext(await _bucketProvider.GetBucketAsync());
            var users = bucketContext
                .Query<User>()
                .Select(x => new UserDto()
                {
                    Id = N1QlFunctions.Meta(x).Id,
                    Name = x.Name,
                })
                .ToList();

            return Ok(users);
        }
    }
}