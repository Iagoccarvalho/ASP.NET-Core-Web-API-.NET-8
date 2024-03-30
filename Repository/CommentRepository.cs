using Api_NET8.Data;
using Api_NET8.DTOs.Comment;
using Api_NET8.Interfaces;
using Api_NET8.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_NET8.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.AddAsync(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);

            if(comment == null)
            {
                return null;
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);

            return comment == null 
                ? null 
                : comment;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comment.FindAsync(id);

            if (existingComment == null)
                return null;

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}
