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
        private readonly IUserServices userServices;
        private readonly IPostServices postServices;
        private readonly CommentMapper commentMapper;

        public CommentsApiController(ICommentsServices commentServices, IUserServices userServices, CommentMapper commentMapper, IPostServices postServices)
        {
            this.commentServices = commentServices;
            this.userServices = userServices;
            this.commentMapper = commentMapper;
            this.postServices = postServices;
        }
        
        [HttpGet("")]

        public IActionResult GetComments([FromQuery] CommentQueryParameters filterParameters)
        {
            List<Comment> comments = commentServices.FilterBy(filterParameters);
            List<CommentsShowDTO> result = comments.Select(comment => new CommentsShowDTO(comment)).ToList();
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
                CommentsShowDTO result = new CommentsShowDTO(comment);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpGet("Post/{id}")]
        public IActionResult GetCommentsByPostId(int id)
        {
            try
            {
                List<CommentsShowDTO> result = commentServices.GetByPostId(id).Select(comment => new CommentsShowDTO(comment)).ToList();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpGet("Autor/{id}")]
        public IActionResult GetCommentsByAutorId(int id)
        {
            try
            {
                List<CommentsShowDTO> result = commentServices.GetByAuthorId(id).Select(comment => new CommentsShowDTO(comment)).ToList();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }


        [HttpPost("post/{postId}")]
        public IActionResult CreateComment([FromHeader] string username, int postId, [FromBody] CommentsCreateUpdateDTO commentDTO)
        {
            try
            {
                User user = userServices.GetByUsername(username);
                Post post = postServices.GetPostById(postId);
                Comment comment = commentMapper.Map(commentDTO);
                Comment createdComment = commentServices.CreateComment(comment, post, user);

                return StatusCode(StatusCodes.Status201Created, createdComment);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromHeader] string username, [FromBody] CommentsCreateUpdateDTO commentDTO)
        {
            try
            {
                User user = userServices.GetByUsername(username);
                Comment comment = commentMapper.Map(commentDTO);
                Comment updatedComment = commentServices.Update(id, comment, user);

                return StatusCode(StatusCodes.Status200OK, updatedComment);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id, [FromHeader] string username) 
        {
            try
            {
                User user = userServices.GetByUsername(username);
                Comment deletedComment = commentServices.Delete(id, user);

                return StatusCode(StatusCodes.Status200OK, deletedComment);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }
    }
}
