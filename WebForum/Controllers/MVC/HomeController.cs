using Microsoft.AspNetCore.Mvc;

namespace WebForum.Controllers.MVC
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
