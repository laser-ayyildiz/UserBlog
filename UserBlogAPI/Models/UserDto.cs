using System.ComponentModel.DataAnnotations;

namespace UserBlogAPI.Models
{
    public class UserDto
    {
        [Key] public string Id { get; set; }
        public string Name { get; set; }
    }
}