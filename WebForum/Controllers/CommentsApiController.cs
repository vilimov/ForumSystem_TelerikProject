using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Services;

namespace WebForum.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsApiController : ControllerBase
    {
        private readonly ICommentsServices commentServices;
        private readonly CommentMapper commentMapper;

        public CommentsApiController(ICommentsServices commentServices, CommentMapper commentMapper)
        {
            this.commentServices = commentServices;
            this.commentMapper = commentMapper;
        }

        [HttpGet("")]
        public IActionResult GetComments([FromQuery] CommentQueryParameters filterParameters)
        {
            List<CommentsShowDTO> result = commentServices.GetAll().Select(comment => new CommentsShowDTO(comment)).ToList();
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            try
            {
                Comment comment = commentServices.GetCommentById(id);

                return StatusCode(StatusCodes.Status200OK, comment);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        /*[HttpGet("PostId}")]
        public IActionResult GetCommentsById(int id)
        {
            try
            {
                Comment comment = CommentsService.GetById(id);

                return StatusCode(StatusCodes.Status200OK, comment);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }*/

        [HttpPost("")]
        public IActionResult CreateComment([FromBody] CommentsCreateUpdateDTO commentDTO)
        {
            try
            {
                Comment comment = this.commentMapper.Map(commentDTO);
                Comment createdComment = this.commentServices.CreateComment(comment, commentDTO.PostId);
                return StatusCode(StatusCodes.Status201Created, createdComment);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }
            
    }    
}
