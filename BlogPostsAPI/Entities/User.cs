﻿using System.ComponentModel.DataAnnotations;

namespace BlogPostsAPI.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Location { get; set; }
    }
}