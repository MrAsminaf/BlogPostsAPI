using AutoMapper;
using BlogPostsAPI.Data;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPostsAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    [EnableCors("LocalhostPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
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

        [HttpGet("{id}", Name = "GetAuthor")]
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
        public async Task<IActionResult> Post(UserForCreation user)
        {
            var entity = mapper.Map<User>(user);
            userRepository.AddUser(entity);
            await userRepository.SaveChangesAsync();

            var userReturn = mapper.Map<User, UserDTO>(entity);
            return CreatedAtRoute("GetAuthor", new { id = userReturn.Id }, userReturn);
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
            if (id != user.UserId)
            {
                return BadRequest();
            }

            var oldUser = await userRepository.GetUserByIdAsync(user.UserId);

            if (oldUser == null)
            {
                return NotFound();
            }

            oldUser.Name = user.Name;
            oldUser.Surname = user.Surname;
            oldUser.Age = user.Age;
            await userRepository.SaveChangesAsync();

            return Ok(mapper.Map<UserDTO>(oldUser));
        }

    }
}
