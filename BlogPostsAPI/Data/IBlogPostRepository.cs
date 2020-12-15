using BlogPostsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostsAPI.Data
{
    public interface IBlogPostRepository
    {
        public void AddBlogPost(BlogPost blogPost);
        public Task<int> SaveChangesAsync();
    }
}
