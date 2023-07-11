using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebForum.Models;
using WebForum.Models.QueryParameters;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class HomeController : Controller
    {
        private readonly IPostServices postService;
        public HomeController(IPostServices postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            PostFilterQueryParameters filterQueryParameters = new PostFilterQueryParameters() { OrderByDate = "lalal" };
            List<Post> postsRecent = this.postService.FilterPostsBy(filterQueryParameters).ToList();
			PostFilterQueryParameters filterQueryParameters2 = new PostFilterQueryParameters() { OrderByComments = "lalal" };
			List<Post> postsCommeted = this.postService.FilterPostsBy(filterQueryParameters2).ToList();
            List<Post> posts = postsRecent;
			posts.AddRange(postsCommeted);
			return View(posts);
        }

        public IActionResult About ()
        {
            return View();
        }
    }
}
