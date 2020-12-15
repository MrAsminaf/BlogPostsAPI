using BlogPostsAPI.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPostsAPI.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Location { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}