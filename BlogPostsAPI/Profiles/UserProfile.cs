using AutoMapper;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Models;

namespace BlogPostsAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserForCreation, User>();
        }
    }
}
