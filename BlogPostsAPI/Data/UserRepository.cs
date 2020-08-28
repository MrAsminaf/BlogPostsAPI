using BlogPostsAPI.Entities;
using BlogPostsAPI.Migrations;
using Microsoft.EntityFrameworkCore;
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

        public void AddUser(User user)
        {
            db.Add(user);
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            var user = await db.users.FindAsync(id);

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<User> DeleteUserByIdAsync(int id)
        {
            var user = await db.users.FirstAsync(user => user.Id == id);
            db.users.Remove(user);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await db.users.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await db.users.FirstOrDefaultAsync(User => User.Id == id);
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsByUserId(int id)
        {
            var user = await db.users.FindAsync(id);
            return user.BlogPosts;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
