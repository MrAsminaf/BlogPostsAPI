using AutoMapper;
using BlogPostsAPI.Data;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPostsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [EnableCors("AngularPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository,
            LinkGenerator linkGenerator,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await userRepository.GetAllUsersAsync();
                return Ok(mapper.Map<IEnumerable<UserDTO>>(results));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await userRepository.GetUserByIdAsync(id);
                return Ok(mapper.Map<UserDTO>(result));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                var location = linkGenerator.GetPathByAction("Get", "Users", new { id = user.Id });
                if (string.IsNullOrEmpty(location))
                {
                    return BadRequest();
                }

                userRepository.AddUser(mapper.Map<User>(user));
                await userRepository.SaveChangesAsync();
                return Created($"/api/Users/{user.Id}", mapper.Map<UserDTO>(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await userRepository.DeleteUserByIdAsync(id);
            await userRepository.SaveChangesAsync();

            return Ok(mapper.Map<UserDTO>(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var oldUser = await userRepository.GetUserByIdAsync(user.Id);

            if (oldUser == null)
            {
                return NotFound();
            }

            oldUser.Name = user.Name;
            oldUser.SecondName = user.SecondName;
            oldUser.Age = user.Age;
            await userRepository.SaveChangesAsync();

            return Ok(mapper.Map<UserDTO>(oldUser));
        }

    }
}
