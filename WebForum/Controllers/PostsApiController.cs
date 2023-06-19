using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        private readonly IUserServices users;
        private readonly IMapper mapper;

        
        public PostsApiController(IPostServices posts, IUserServices users, IMapper mapper)
        {
            this.posts = posts;
            this.mapper = mapper;
            this.users = users;
        }

        [HttpGet("")]
        public IActionResult GetAllPosts()
        {
            var posts = this.posts.GetAllPosts();
            var postShowDtos = this.mapper.Map<List<PostShowDto>>(posts);
            return StatusCode(StatusCodes.Status200OK, postShowDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var post = this.posts.GetPostById(id);
                var postShowDto = this.mapper.Map<PostShowDto>(post);
                return StatusCode(StatusCodes.Status200OK, postShowDto);
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
                var postShowDto = this.mapper.Map<List<PostShowDto>>(post);
                return StatusCode(StatusCodes.Status200OK, postShowDto);
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
                User user = users.GetByUsername(username);

                Post post = mapper.Map<Post>(postDto);
                //post.Autor = user; // Set the user as the author of the post
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


        [HttpPut("{id}")]
        public IActionResult UpdatePost([FromHeader] string username, [FromBody] PostDtoCreateUpdate updateDto, int id)
        {
            //UpdatePost(int id, Post post)
            try
            {
                User user = users.GetByUsername(username);
                Post post = mapper.Map<Post>(updateDto);
                Post createPost = posts.UpdatePost(id, post, user);

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

        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromHeader] string username, int id)
        {
            try
            {
                User user = users.GetByUsername(username);
                Post postToDelete = posts.DeletePost(id, user);
                return StatusCode(StatusCodes.Status200OK, postToDelete);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
