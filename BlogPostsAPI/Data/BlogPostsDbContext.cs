using BlogPostsAPI.Authentication;
using BlogPostsAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsAPI.Data
{
    public class BlogPostsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }

        public BlogPostsDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
