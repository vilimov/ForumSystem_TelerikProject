using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Controllers.Api
{
    [ApiController]
    [Route("api/tags")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;
        private readonly AuthManager authManager;

        public TagsController(ITagService tagService, AuthManager authManager)
        {
            this.tagService = tagService;
            this.authManager = authManager;
        }

        [HttpGet("")]
        public IActionResult GetAllTags()
        {
            var tags = tagService.GetAllTags();
            return Ok(tags);
        }
        [HttpGet("{id}")]
        public IActionResult GetTagById(int id)
        {
            try
            {
                var tag = tagService.GetTagById(id);
                return Ok(tag);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("")]
        public IActionResult CreateTag([FromHeader] string credentials, [FromBody] Tag newTag)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                var tag = tagService.CreateTag(newTag);
                return Created($"/api/tags/{tag.Id}", tag);
            }
            catch (DuplicateEntityException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTag([FromHeader] string credentials, int id, [FromBody] string newTagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                var updatedTag = tagService.UpdateTag(id, newTagName);
                return Ok(updatedTag);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTag([FromHeader] string credentials, int id)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.DeleteTag(id, user);
                return Ok("Tag deleted successfully");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthenticatedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPost("posts/{postId}")]
        public IActionResult AddTagToPost([FromHeader] string credentials, int postId, [FromBody] string tagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.AddTagToPost(postId, tagName, user.Id);
                return Ok("Tag Added");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UnauthenticatedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpDelete("posts/{postId}/{tagName}")]
        public IActionResult RemoveTagFromPost([FromHeader] string credentials, int postId, string tagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.RemoveTagFromPost(postId, tagName, user.Id);
                return Ok("Tag removed successfully");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthenticatedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }

        }
        [HttpPost("admin/posts/{postId}")]
        public IActionResult AdminAddTagToPost([FromHeader] string credentials, int postId, [FromBody] string tagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.AdminAddTagToPost(postId, tagName, user.Id);
                return Ok("tag added successfully");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UnauthenticatedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpDelete("admin/posts/{postId}/{tagName}")]
        public IActionResult AdminRemoveTagFromPost([FromHeader] string credentials, int postId, string tagName)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                tagService.AdminRemoveTagFromPost(postId, tagName, user.Id);
                return Ok("Tag removed successfully");
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
