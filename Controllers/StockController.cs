using Api_NET8.DTOs.Stock;
using Api_NET8.Helper;
using Api_NET8.Interfaces;
using Api_NET8.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api_NET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _repository;
        public StockController(IStockRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stocks = await _repository.GetAllAsync(query);

            var stockDTO = stocks.Select(s => s.ToStockDTO());

            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _repository.GetByIdAsync(id);

            if (stock == null)
                return NotFound();

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = stockDTO.ToStockFromCreatedDTO();
            await _repository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO stockDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _repository.UpdateAsync(id, stockDTO);

            if (stockModel == null)
                return NotFound();

            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _repository.DeleteAsync(id);

            if (stockModel == null) 
                return NotFound();

            return NoContent();
        }
    }
}
