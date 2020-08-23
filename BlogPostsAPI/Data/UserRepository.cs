using BlogPostsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostsAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogPostsDbContext db;

        public UserRepository(BlogPostsDbContext blogPostsDbContext)
        {
            this.db = blogPostsDbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await db.users.ToArrayAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }
    }
}
