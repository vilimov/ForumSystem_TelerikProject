using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.ViewModels;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
	public class UsersController : Controller
	{
		private readonly IUserServices userService;
		private readonly AuthManager authManager;
		private readonly IHttpContextAccessor httpContextAccessor;

		public UsersController(IUserServices userService, AuthManager authManager, IHttpContextAccessor httpContextAccessor)
		{
			this.userService = userService;
			this.authManager = authManager;
			this.httpContextAccessor = httpContextAccessor;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var salt = AuthManager.GenerateSalt();
				var hashedPassword = AuthManager.HashPassword(model.Password, salt);

				var user = new User
				{
					Username = model.Username,
					Password = hashedPassword,
					Salt = salt,
					Email = model.Email,
					FirstName = model.FirstName,
					LastName = model.LastName,
					// ProfileImage = model.ProfileImage
				};

				userService.Register(user);

				return RedirectToAction("Login");
			}
			catch (DuplicateEntityException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var user = authManager.TryGetUser($"{model.Username}:{model.Password}");
                this.HttpContext.Session.SetString("LoggedUser", user.Username);
                this.HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "True" : "False");

                return RedirectToAction("Index", "Home");
			}
			catch (InvalidPasswordException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
			catch (EntityNotFoundException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
			catch (UnauthenticatedOperationException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
			catch (UnauthorizedOperationException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}
		public IActionResult Logout()
		{
			this.HttpContext.Session.Clear();
			return RedirectToAction("Login", "Users");
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
				//Console.WriteLine("ModelState Invalid");
				return View(model);
			}

			var user = userService.GetByUsername(this.HttpContext.Session.GetString("LoggedUser"));
			//Console.WriteLine("UserName: {0}", this.HttpContext.Session.GetString("LoggedUser"));
			if (user == null)
			{
				return NotFound($"Unable to locate user with username {User.Identity.Name}");
			}

			if (!string.IsNullOrWhiteSpace(model.Password))
			{
				try
				{
					userService.UpdatePassword(user.Id, model.Password);
					//Console.WriteLine("Updated password.");
					//Console.WriteLine("Model Value: {0}", model.Password);
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
