using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Services;

namespace WebForum.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsApiController : ControllerBase
    {
        private readonly IPostServices posts;
        private readonly PostCreatUpdateMapper postMapper;
        public PostsApiController(IPostServices posts, PostCreatUpdateMapper postMapper)
        {
            this.posts = posts;
            this.postMapper = postMapper;
        }

        [HttpGet("")]
        public IActionResult GetAllPosts()
        {
            var result = this.posts.GetAllPosts();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var post = this.posts.GetPost(id);
                return StatusCode(StatusCodes.Status200OK, post);
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Post with Id {id} does not exist.");
            }
        }

        [HttpGet("postbyuser/{userId}")]
        public IActionResult GetPostByUserId(int userId)
        {
            try
            {
                var post = this.posts.GetPostsByUserId(userId);
                return StatusCode(StatusCodes.Status200OK, post);
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Post from User with Id {userId} does not exist.");
            }
        }

        [HttpPost("")]
        public IActionResult CreatePost([FromHeader] string username, [FromBody] PostDtoCreateUpdate postDto)
        {
            try
            {
                User user = new User();
                Post post = postMapper.Map(postDto);
                Post createPost = posts.CreatePost(post, user);

                return StatusCode(StatusCodes.Status200OK, createPost);
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
