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

namespace WebForum.Controllers
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
                var userPublicDataDto = UserMappers.ToUserPublicDataDto(user);
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
                var userPublicDataDto = UserMappers.ToUserPublicDataDto(user);
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
                var userPublicDataDto = UserMappers.ToUserPublicDataDto(user);
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
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                //User user = this.authManager.TryGetUser(credentials);
                var authenticatedUser = userServices.GetByUsername(User.Identity.Name);

                if (authenticatedUser.Id != id && !User.IsInRole("Admin"))
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
        }
    }
}
