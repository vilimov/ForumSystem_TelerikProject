using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsApiController : ControllerBase
    {
        private readonly ICommentsServices commentServices;

        public CommentsApiController(ICommentsServices commentServices)
        {
            this.commentServices = commentServices;
        }

        [HttpGet("")]
        public IActionResult GetComments([FromQuery] CommentQueryParameters filterParameters)
        {
            List<Comment> comments = commentServices.GetAll();
            if (comments.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, comments);
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
/*
        [HttpGet("PostId}")]
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
    }    
}
