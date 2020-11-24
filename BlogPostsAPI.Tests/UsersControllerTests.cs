using Xunit;
using Moq;
using BlogPostsAPI.Data;
using System.Collections.Generic;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Controllers;
using AutoMapper;
using BlogPostsAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using BlogPostsAPI.Models;

namespace BlogPostsAPI.Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public void Get_ReturnsAllUsers()
        {
            // Arrange
            var users = new List<User>();
            users.Add(new User()
            {
                Id = 0,
                Name = "Name0",
                SecondName = "SecondName0",
                Age = 0,
                Location = "Unknown",
                BlogPosts = new List<BlogPost>()
            });

            users.Add(new User()
            {
                Id = 1,
                Name = "Name1",
                SecondName = "SecondName1",
                Age = 1,
                Location = "Unknown",
                BlogPosts = new List<BlogPost>()
            });

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(users);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            var controller = new UsersController(mockRepo.Object, mapper);

            // Act
            var result = controller.Get().Result as OkObjectResult;

            // Assert
            var viewResult = Assert.IsType<List<UserDTO>>(result.Value);
        }
    }
}
