using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;
using WebForum.Helpers.Authentication;
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
        private readonly AuthManager authManager;

        public CommentsApiController(ICommentsServices commentServices, AuthManager authManager, IUserServices userServices, CommentMapper commentMapper, IPostServices postServices)
        {
            this.commentServices = commentServices;
            this.userServices = userServices;
            this.commentMapper = commentMapper;
            this.postServices = postServices;
            this.authManager = authManager;
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
        


        [HttpPost("post/{postId}")]
        public IActionResult CreateComment([FromHeader] string credentials, int postId, [FromBody] CommentsCreateUpdateDTO commentDTO)
        {
            try
            {
                //User user = userServices.GetByUsername(username);
                User user = authManager.TryGetUser(credentials);
                Post post = postServices.GetPostById(postId);
                Comment comment = commentMapper.Map(commentDTO);
                Comment createdComment = commentServices.CreateComment(comment, post, user);
                CommentsShowDTO result = new CommentsShowDTO(createdComment);

                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (InvalidPasswordException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
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
