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
            var comments = await _commentRepository.GetAllAsync();

            var commentsDTO = comments.Select(c => c.ToCommentDTO());

            return Ok(commentsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            return comment == null 
                ? NotFound() 
                : Ok(comment.ToCommentDTO());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequestDTO commentDTO)
        {
            if(!await _stockRepository.StockExists(stockId))
            {
                return BadRequest("Stock does not exists");
            }

            var commentModel = commentDTO.ToCommentFromCreateDTO(stockId);

            await _commentRepository.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel}, commentModel.ToCommentDTO());
        }
    }
}
