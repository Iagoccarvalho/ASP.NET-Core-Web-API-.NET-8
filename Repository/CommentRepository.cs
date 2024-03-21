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
    }
}
