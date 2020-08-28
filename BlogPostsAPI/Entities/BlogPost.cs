using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPostsAPI.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
