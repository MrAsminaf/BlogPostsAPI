using BlogPostsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostsAPI.Data
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogPostsDbContext db;

        public BlogPostRepository(BlogPostsDbContext db)
        {
            this.db = db;
        }

        public async void AddBlogPost(BlogPost blogPost)
        {
            await db.BlogPosts.AddAsync(blogPost);

            return;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
