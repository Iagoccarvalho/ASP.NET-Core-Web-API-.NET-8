namespace Api_NET8.DTOs.Comment
{
    public class CreateCommentRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
