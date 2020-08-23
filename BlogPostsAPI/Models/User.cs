using System.ComponentModel.DataAnnotations;

namespace BlogPostsAPI.Models
{
    public class User
    {
        //[Required]
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        public string SecondName { get; set; }

        //[Required]
        public int Age { get; set; }
    }
}
