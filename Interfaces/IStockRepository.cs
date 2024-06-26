﻿using Api_NET8.DTOs.Stock;
using Api_NET8.Helper;
using Api_NET8.Models;

namespace Api_NET8.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id); //FirstOrDefault PODE SER NULO
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDTO stockDTO);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);

    }
}
