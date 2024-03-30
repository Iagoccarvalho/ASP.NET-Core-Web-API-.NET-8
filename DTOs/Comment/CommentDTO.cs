using System.ComponentModel.DataAnnotations;

namespace Api_NET8.DTOs.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now.ToUniversalTime();
        public int? StockId { get; set; }
    }
}
