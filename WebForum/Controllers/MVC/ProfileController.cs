using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models.ViewModels;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class ProfilesController : Controller
    {
        private readonly IUserServices userService;

        public ProfilesController(IUserServices userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            try
            {
                string username = HttpContext.Session.GetString("LoggedUser");
                User user = userService.GetByUsername(username);

                if (user == null)
                {
                    throw new EntityNotFoundException($"User with username {username} not found");
                }

                var model = new EditProfileViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                return View(model);
            }
            catch (EntityNotFoundException ex)
            {
                return RedirectToAction("Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userService.GetByUsername(this.HttpContext.Session.GetString("LoggedUser"));
            if (user == null)
            {
                return NotFound($"Unable to locate user with username {User.Identity.Name}");
            }

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                try
                {
                    userService.UpdatePassword(user.Id, model.Password);
                }
                catch (EntityNotFoundException ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the password");
                    return View(model);
                }
            }

            if (!string.IsNullOrWhiteSpace(model.FirstName))
            {
                user.FirstName = model.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(model.LastName))
            {
                user.LastName = model.LastName;
            }

            try
            {
                userService.UpdateProfile(user);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the profile");
                return View(model);
            }

            return RedirectToAction("Profile", new { username = user.Username });
        }
        [HttpGet]
        public IActionResult Profile()
        {
            try
            {
                var user = userService.GetByUsername(this.HttpContext.Session.GetString("LoggedUser"));
                if (user == null)
                {

                    return RedirectToAction("Login");
                }

                var userProfileViewModel = new ProfileViewModel
                {

                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                return View(userProfileViewModel);

            }
            catch (EntityNotFoundException ex)
            {
                return View("Error");
            }
        }
    }
}
