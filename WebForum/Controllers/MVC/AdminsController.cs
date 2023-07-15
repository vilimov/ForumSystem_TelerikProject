using Microsoft.AspNetCore.Mvc;
using WebForum.Models;
using WebForum.Models.ViewModels;
using WebForum.Repository;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class AdminsController : Controller
    {
        private readonly IUserServices userServices;

        public AdminsController(IUserServices userServices)
        {
            this.userServices = userServices;
        }
        public IActionResult Index()
        {
			var users = userServices.GetAllUserViewModels();
            ViewBag.CurrentUserRole = User.IsInRole("Admin") ? "Admin" : "User";
            return View(users);
        }
		[HttpGet]
		public IActionResult AllUsers([FromQuery] string username)
		{
			var users = userServices.GetAllUserViewModels();
			var userViewModels = userServices.GetAllUserViewModels();
			if (!string.IsNullOrEmpty(username))
			{
				userViewModels = users.Where(u => u.Username.Contains(username)).ToList();
			}
			return View(userViewModels);
		}


		[HttpPost]
        public IActionResult PromoteUser(int id)
        {
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userServices.GetByUsername(loggedInUserName);

                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));
                if (currentUser == null || !isAdmin)
                {
                    return Unauthorized();
                }

                userServices.PromoteToAdmin(id, currentUser);
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DemoteUser(int id)
        {
            try
            {
                User currentUser = userServices.GetUserById(id);
                userServices.DemoteFromAdmin(id, currentUser);
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                User currentUser = userServices.GetUserById(id);
                userServices.DeleteUser(id);
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
