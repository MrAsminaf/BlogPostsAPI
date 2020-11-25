using BlogPostsAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPostsAPI.Data
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> DeleteUserByIdAsync(int id);
        public Task<bool> UserExistsAsync(int id);
        public void AddUser(User user);
        public Task<IEnumerable<BlogPost>> GetBlogPostsByUserId(int id);
        public void AddBlogToUser(int id, BlogPost blogPost);
        public Task<BlogPost> GetBlogPostById(int userId, int blogId);
        public Task<int> SaveChangesAsync();
    }
}
