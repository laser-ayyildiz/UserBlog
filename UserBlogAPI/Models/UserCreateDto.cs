using System;

namespace UserBlogAPI.Models
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        
        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}