using Api_NET8.DTOs.Comment;
using Api_NET8.Interfaces;
using Api_NET8.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api_NET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepository.GetAllAsync();

            var commentsDTO = comments.Select(c => c.ToCommentDTO());

            return Ok(commentsDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.GetByIdAsync(id);

            return comment == null 
                ? NotFound() 
                : Ok(comment.ToCommentDTO());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequestDTO commentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _stockRepository.StockExists(stockId))
            {
                return BadRequest("Stock does not exists");
            }

            var commentModel = commentDTO.ToCommentFromCreateDTO(stockId);

            await _commentRepository.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDTO commentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.UpdateAsync(id, commentDTO.ToCommentFromUpdateDTO());

            if(comment == null)
                return NotFound("Comment not found");

            return Ok(comment.ToCommentDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.DeleteAsync(id);

            return comment == null
                ? NotFound("Comment does not exists")
                : Ok(comment.ToCommentDTO());
        }
    }
}
