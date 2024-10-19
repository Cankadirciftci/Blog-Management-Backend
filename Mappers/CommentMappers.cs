using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Dtos;
using BlogManagement.Models;

namespace BlogManagement.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel){
            return new CommentDto{

                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt,
                BlogPostId = commentModel.BlogPostId,
                BlogPost = commentModel.BlogPost,
                UserId = commentModel.UserId
            };
        }
        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto commentdto){
           return new Comment{
            Content = commentdto.Content,
            CreatedAt = commentdto.CreatedAt,
            BlogPost = commentdto.BlogPost,
            BlogPostId = commentdto.BlogPostId,
            UserId = commentdto.UserId
           };
        }
    }
}