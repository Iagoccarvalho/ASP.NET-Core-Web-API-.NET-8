using Api_NET8.DTOs.Comment;
using Api_NET8.Models;

namespace Api_NET8.Mappers
{
    public static class CommentMappers
    {
        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId
            };
        }
    }
}
