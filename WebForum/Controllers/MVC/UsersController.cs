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
		//private void SignIn(User user)
		//{
		//    this.HttpContext.Session.SetString("username", user.Username);
		//}

		public IActionResult Logout()
		{
			this.HttpContext.Session.Clear();
			return RedirectToAction("Login", "Users");
		}
	}
}
