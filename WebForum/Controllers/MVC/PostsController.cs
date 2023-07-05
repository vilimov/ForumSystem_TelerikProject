using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class PostsController : Controller
    {
        private readonly IPostServices postService;

        public PostsController(IPostServices postService)
        {
            this.postService = postService;
        }


        public IActionResult Index()
        {
            List<Post> posts = this.postService.GetAllPosts().ToList();

            return View(posts);
        }

        public IActionResult Details(int id) 
        {
            try
            {
				var post = postService.GetPostById(id);
				return View(post);
			}
            catch (EntityNotFoundException ex)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;
                //this.ViewBag.ErrorMessage = ex.Message;

                return View("Error");               
            }
           
        }
    }
}
