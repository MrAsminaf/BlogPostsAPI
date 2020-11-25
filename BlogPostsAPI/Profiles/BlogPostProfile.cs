using AutoMapper;
using BlogPostsAPI.Entities;
using BlogPostsAPI.Models;

namespace BlogPostsAPI.Profiles
{
    public class BlogPostProfile : Profile
    {
        public BlogPostProfile()
        {
            CreateMap<BlogPost, BlogPostDTO>();
            CreateMap<BlogPostDTO, BlogPost>();
            CreateMap<BlogPostForCreationDTO, BlogPost>();
        }
    }
}
