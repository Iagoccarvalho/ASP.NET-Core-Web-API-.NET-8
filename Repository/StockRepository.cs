using Api_NET8.Data;
using Api_NET8.DTOs.Stock;
using Api_NET8.Interfaces;
using Api_NET8.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_NET8.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);

            if (stockModel == null)
                return null;

            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;

        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.Include(s => s.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDTO stockDTO)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);

            if (existingStock == null)
                return null;

            existingStock.Symbol = stockDTO.Symbol;
            existingStock.CompanyName = stockDTO.CompanyName;
            existingStock.Purchase = stockDTO.Purchase;
            existingStock.LastDiv = stockDTO.LastDiv;
            existingStock.Industry = stockDTO.Industry;
            existingStock.MarketCap = stockDTO.MarketCap;

            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}
