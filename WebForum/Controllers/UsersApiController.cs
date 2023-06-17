using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
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

        [HttpGet("email/{email}")]
        public ActionResult<UserPublicDataDto> GetByEmail(string email)
        {
            try
            {
                var user = userServices.GetByEmail(email);

                return StatusCode(StatusCodes.Status200OK, user);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpGet("username/{username}")]
        public ActionResult<UserPublicDataDto> GetByUsername(string username)
        {
            try
            {
                var user = userServices.GetByUsername(username);

                return Ok(user);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpPost("register")]
        public ActionResult<UserPublicDataDto> Register(UserRegisterDto newUserDto)
        {
            try
            {
                var newUser = UserMappers.ToEntity(newUserDto);
                var registeredUser = userServices.Register(newUser);
                return CreatedAtAction("GetById", new { id = registeredUser.Id }, registeredUser);
            }
            catch (DuplicateEntityException)
            {
                return BadRequest(new { message = "User already exists" });
            }
        }

        [HttpPost("login")]
        public ActionResult<UserPublicDataDto> Login(UserLoginDto loginDto)
        {
            try
            {
                var loggedUser = userServices.Login(loginDto.Username, loginDto.Password);
                return Ok(loggedUser);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidPasswordException)
            {
                return Unauthorized(new { message = "Invalid password." });
            }
        }

        [HttpPut("update")]
        public ActionResult<UserPublicDataDto> UpdateProfile(UserUpdateDto userUpdateDto)
        {
            try
            {
                var userToUpdate = userServices.GetUserById(userUpdateDto.Id);
                if (userToUpdate == null)
                {
                    return NotFound(new { message = "User not found." });
                }
                userToUpdate.ApplyUpdate(userUpdateDto);
                var updatedUser = userServices.UpdateProfile(userToUpdate);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
