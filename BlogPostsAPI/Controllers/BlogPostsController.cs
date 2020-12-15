using AutoMapper;
using BlogPostsAPI.Authentication;
using BlogPostsAPI.Data;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogPostsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogPostsController(
            IUserRepository userRepository,
            IBlogPostRepository blogPostRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
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

        [HttpGet("{blogId}", Name = "GetBlog")]
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

        [HttpPost]
        public async Task<IActionResult> AddBlogToUser(BlogPostForCreationDTO blogPost)
        {
            var entity = mapper.Map<BlogPost>(blogPost);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.UserId;
            entity.UserId = userId;

            blogPostRepository.AddBlogPost(entity);
            await blogPostRepository.SaveChangesAsync();

            return CreatedAtRoute("GetBlog", new { userId = userId, blogId = entity.Id }, entity);
        }
    }
}
