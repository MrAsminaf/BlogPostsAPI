using AutoMapper;
using BlogPostsAPI.Data;
using BlogPostsAPI.Helpers;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        }
    }
}
