using Api_NET8.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_NET8.DTOs.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}
