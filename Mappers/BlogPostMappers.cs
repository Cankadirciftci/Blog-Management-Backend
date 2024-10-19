using System;
using BlogManagement.Dtos;
using BlogManagement.Models;

namespace BlogManagement.Mappers
{
    public static class BlogPostMappers
    {
        public static BlogPostDto ToBlogPostDto(this BlogPost blogPostModel)
        {
            return new BlogPostDto
            {
                Id = blogPostModel.Id,
                Title = blogPostModel.Title,
                Content = blogPostModel.Content,
                CreatedAt = blogPostModel.CreatedAt,
                UserId = blogPostModel.UserId
            };
        }

        public static BlogPost ToBlogPostFromCreateDto(this CreateBlogPostRequestDto blogpostDto) // Renamed method
        {
            return new BlogPost
            {
                Title = blogpostDto.Title,
                Content = blogpostDto.Content,
                CreatedAt = blogpostDto.CreatedAt,
                UserId = blogpostDto.UserId
            };
        }
    }
}
