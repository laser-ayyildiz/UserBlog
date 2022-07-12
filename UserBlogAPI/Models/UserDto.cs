using System;
using System.ComponentModel.DataAnnotations;
using UserBlogAPI.Data;

namespace UserBlogAPI.Models
{
    public class UserDto
    {
        [Key] public string Id { get; set; }
        public string Name { get; set; }

        public static UserDto Of(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}