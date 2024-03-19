namespace Api_NET8.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now.ToUniversalTime();
        public int? StockId { get; set; }
        public Stock? Stock { get; set; } //Propriedade de navegação 
        }
}
