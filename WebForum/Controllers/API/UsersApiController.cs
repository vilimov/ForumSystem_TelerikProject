using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Services;

namespace WebForum.Controllers.Api
{
    [ApiController]
    [Route("api/users")]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly AuthManager authManager;

        public UsersApiController(IUserServices userServices, AuthManager authManager)
        {
            this.userServices = userServices;
            this.authManager = authManager;
        }


        [HttpGet("")]
        public IActionResult GetUsers()
        {
            List<User> users = userServices.GetAllUsers();
            if (users.Count == 0)
            {
                return NoContent();
            }

            var usersPublicDataDtos = users.Select(UserMappers.ToUserPublicDataDto).ToList();

            return Ok(usersPublicDataDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                User user = userServices.GetUserById(id);
                var userPublicDataDto = user.ToUserPublicDataDto();
                return Ok(userPublicDataDto);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                User user = userServices.GetByEmail(email);
                var userPublicDataDto = user.ToUserPublicDataDto();
                return Ok(userPublicDataDto);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("username/{username}")]
        public IActionResult GetByUsername(string username)
        {
            try
            {
                User user = userServices.GetByUsername(username);
                var userPublicDataDto = user.ToUserPublicDataDto();
                return Ok(userPublicDataDto);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto newUserDto)
        {
            try
            {
                var newUser = UserMappers.ToEntity(newUserDto);
                var registeredUser = userServices.Register(newUser);
                //Hack Mila User Register
                //return CreatedAtAction("GetUserById", new { id = registeredUser.Id }, registeredUser);
                return Ok(registeredUser);
            }
            catch (DuplicateEntityException)
            {
                return BadRequest(new { message = "User already exists" });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto loginDto)
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
        public IActionResult UpdateProfile(UserUpdateDto userUpdateDto)
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
                return Ok(updatedUser);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromHeader] string credentials, int id)
        {
            try
            {
                User authenticatedUser = authManager.TryGetUser(credentials);

                // Unauthorized access if the authenticated user is null or not an admin and trying to delete another user
                if (authenticatedUser == null || authenticatedUser.Id != id && !authenticatedUser.IsAdmin)
                {
                    return Forbid();
                }

                userServices.DeleteUser(id);
                return Ok(new { message = "User deleted successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedOperationException)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
            catch (InvalidPasswordException)
            {
                return BadRequest(new { message = "Invalid password" });
            }
        }
    }
}
