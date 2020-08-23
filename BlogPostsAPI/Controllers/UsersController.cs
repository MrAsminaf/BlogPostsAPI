﻿using BlogPostsAPI.Data;
using BlogPostsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace BlogPostsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly LinkGenerator linkGenerator;

        public UsersController(IUserRepository userRepository, LinkGenerator linkGenerator)
        {
            this.userRepository = userRepository;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await userRepository.GetAllUsersAsync();
                return Ok(results);
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
                return Ok(result);
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

                userRepository.AddUser(user);
                await userRepository.SaveChangesAsync();
                return Created($"/api/Users/{user.Id}", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = await userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return BadRequest();
                }
                return Ok(userRepository.DeleteUserById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
