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
        private List<User> GenerateListOfUsers(int size)
        {
            var users = new List<User>();
            for (int i = 0; i < size; ++i)
            {
                users.Add(new User()
                {
                    UserId = 0,
                    Name = $"Name{i}",
                    Surname = $"SecondName{i}",
                    Age = i,
                    Location = "Unknown",
                    BlogPosts = new List<BlogPost>()
                });
            }
            return users;
        }

        [Fact]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var users = GenerateListOfUsers(2);
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
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            // Arrange
            var users = GenerateListOfUsers(3);
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
            Assert.Equal(3, viewResult.Count);
        }
    }
}
