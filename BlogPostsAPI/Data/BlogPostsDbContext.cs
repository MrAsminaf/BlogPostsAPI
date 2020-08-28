using BlogPostsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsAPI.Data
{
    public class BlogPostsDbContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public BlogPostsDbContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
