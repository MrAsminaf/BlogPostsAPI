using AutoMapper;
using BlogPostsAPI.Data;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPostsAPI.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public BlogPostsController(IUserRepository userRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDTO>>> GetAllBlogs(int userId)
        {
            if (!(await userRepository.UserExistsAsync(userId)))
            {
                return BadRequest();
            }

            var blogs = await userRepository.GetBlogPostsByUserId(userId);

            if(blogs == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<BlogPostDTO>>(blogs));
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<BlogPostDTO>> GetBlog(int userId, int blogId)
        {
            if (!(await userRepository.UserExistsAsync(userId)))
            {
                return BadRequest();
            }

            var blog = await userRepository.GetBlogPostById(userId, blogId);

            if(blog == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BlogPostDTO>(blog));
        }

        //[HttpPost]
        //public async Task<IActionResult> AddBlogToUser(BlogPostForCreationDTO blogPost)
        //{
        //    var entity = mapper.Map<BlogPost>(blogPost);

        //}
    }
}
