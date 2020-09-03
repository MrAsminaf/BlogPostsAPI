using AutoMapper;
using BlogPostsAPI.Data;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Helpers;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogPostsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserCollectionsController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;

        public UserCollectionsController(UserRepository userRepository,
                IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet("({ids})")]
        public ActionResult<IEnumerable<UserDTO>> GetUsers(
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var blogs = userRepository.GetBlogPostsByIds(ids) as IEnumerable<BlogPost>;

            if (blogs.Count() != ids.Count())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<BlogPostDTO>>(blogs));
        }


    }
}
