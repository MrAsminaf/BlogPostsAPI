using System.ComponentModel.DataAnnotations;

namespace BlogPostsAPI.Models
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
