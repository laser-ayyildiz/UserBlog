using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Couchbase.Linq;
using Microsoft.AspNetCore.Routing.Template;
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

        private async Task<ICouchbaseCollection> GetCollectionAsync()
        {
            return (await _bucketProvider.GetBucketAsync()).DefaultCollection();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var bucketContext = new BucketContext(await _bucketProvider.GetBucketAsync());
            var users = bucketContext
                .Query<User>()
                .ToList();

            return users;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var collection = await GetCollectionAsync();
            var user = collection.GetAsync(id);
            return user.Result.ContentAs<User>();
        }

        public async Task CreateAsync(UserCreateDto user)
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var collection = await GetCollectionAsync();
            await collection.InsertAsync(user.Username, user);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var collection = await GetCollectionAsync();
            try
            {
                var user = GetByIdAsync(id).Result;
                user.IsDeleted = true;
                user.DeletedAt = new DateTime();
                await collection.UpsertAsync(id, user);
            }
            catch (CouchbaseException e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(string id, UserUpdateDto userDto)
        {
            var collection = await GetCollectionAsync();
            try
            {
                var user = GetByIdAsync(id).Result;
                user.UpdatedAt = new DateTime();
                user.Name = userDto.Name;
                await collection.UpsertAsync(id, user);
            }
            catch (CouchbaseException e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}