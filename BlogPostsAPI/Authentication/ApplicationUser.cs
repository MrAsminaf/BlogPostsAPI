using BlogPostsAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogPostsAPI.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
