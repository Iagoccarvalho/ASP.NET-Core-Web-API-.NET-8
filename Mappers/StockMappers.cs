using Api_NET8.DTOs.Stock;
using Api_NET8.Models;

namespace Api_NET8.Mappers
{
    public static class StockMappers
    {
        public static StockDTO ToStockDTO(this Stock stock)
            => new StockDTO
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
    }
}
