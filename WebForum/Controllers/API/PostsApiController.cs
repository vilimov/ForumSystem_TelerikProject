﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Models.QueryParameters;
using WebForum.Services;

namespace WebForum.Controllers.Api
{

    [ApiController]
    [Route("api/posts")]
    public class PostsApiController : ControllerBase
    {
        private readonly IPostServices posts;
        private readonly IUserServices users;
        private readonly IMapper mapper;
        private readonly AuthManager authManager;

        // Tag new
        private readonly ITagService tagService;

        public PostsApiController(IPostServices posts, IUserServices users, IMapper mapper, AuthManager authManager, ITagService tagService)
        {
            this.posts = posts;
            this.mapper = mapper;
            this.users = users;
            this.authManager = authManager;

            // Tag new
            this.tagService = tagService;
        }

        //Todo - Posts when user is not logged???


        [HttpGet("")]
        public IActionResult GetAllPosts([FromQuery] PostFilterQueryParameters filterQueryParameters)
        {
            //var posts = this.posts.GetAllPosts();
            var posts = this.posts.FilterPostsBy(filterQueryParameters);
            var postShowDtos = mapper.Map<List<PostShowDto>>(posts);

            if (postShowDtos.Count != 0)
            {
                return StatusCode(StatusCodes.Status200OK, postShowDtos);
            }
            return StatusCode(StatusCodes.Status404NotFound, $"No posts to show");
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var post = posts.GetPostById(id);
                var postShowDto = mapper.Map<PostShowDto>(post);
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
                var post = posts.GetPostsByUserId(userId);
                var postShowDto = mapper.Map<List<PostShowDto>>(post);
                return StatusCode(StatusCodes.Status200OK, postShowDto);
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Post from User with Id {userId} does not exist.");
            }
        }

        [HttpPost("")]
        public IActionResult CreatePost([FromHeader] string credentials, [FromBody] PostDtoCreateUpdate postDto)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Post post = mapper.Map<Post>(postDto);
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
            catch (InvalidPasswordException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePost([FromHeader] string credentials, [FromBody] PostDtoCreateUpdate updateDto, int id)
        {
            //UpdatePost(int id, Post post)
            try
            {
                User user = authManager.TryGetUser(credentials);
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
            catch (InvalidPasswordException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromHeader] string credentials, int id)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Post postToDelete = posts.DeletePost(id, user);
                return StatusCode(StatusCodes.Status200OK, postToDelete);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (UnauthenticatedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpPost("{postId}/likes")]
        public IActionResult AddLike([FromHeader] string credentials, int postId)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Post postToBeLiked = posts.GetPostById(postId);
                Post likedPost = posts.AddLikePost(postToBeLiked, user);
                return StatusCode(StatusCodes.Status200OK, likedPost);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (UnauthenticatedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpDelete("{postId}/likes")]
        public IActionResult RemoveLike([FromHeader] string credentials, int postId)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Post postToRemoveLikeFrom = posts.GetPostById(postId);
                Post dislikedPost = posts.RemoveLikePost(postToRemoveLikeFrom, user);
                return StatusCode(StatusCodes.Status200OK, dislikedPost);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (UnauthenticatedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        // Tags new
        [HttpPost("{postId}/tags")]
        public IActionResult AdminAddTagToPost([FromHeader] string credentials, int postId, string tagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.AdminAddTagToPost(postId, tagName, user.Id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpDelete("{postId}/tags/{tagName}")]
        public IActionResult AdminRemoveTagFromPost([FromHeader] string credentials, int postId, string tagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.AdminRemoveTagFromPost(postId, tagName, user.Id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

    }
}
