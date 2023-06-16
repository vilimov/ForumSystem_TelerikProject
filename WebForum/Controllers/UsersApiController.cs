using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserServices userServices;

        public UsersApiController(IUserServices userServices)
        {
            this.userServices = userServices;
        }
        

        [HttpGet("")]
        public IActionResult GetUsers([FromQuery] CommentQueryParameters filterParameters)
        {
            List<User> users = userServices.GetAllUsers();
            if (users.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                User user = userServices.GetUserById(id);

                return StatusCode(StatusCodes.Status200OK, user);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
