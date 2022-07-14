using System;
using UserBlogAPI.Data;

namespace UserBlogAPI.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedAt { get; set; }

        public static UserDto Of(User user)
        {
            return new UserDto
            {
                Username = user.Username,
                Name = user.Name,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt
            };
        }
    }
}