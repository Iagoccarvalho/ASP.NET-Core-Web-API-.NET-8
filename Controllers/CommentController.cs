using Api_NET8.Interfaces;
using Api_NET8.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api_NET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;

        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _repository.GetAllAsync();

            var commentsDTO = comments.Select(c => c.ToCommentDTO());

            return Ok(commentsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _repository.GetByIdAsync(id);

            return comment == null 
                ? NotFound() 
                : Ok(comment.ToCommentDTO());
        }
    }
}
