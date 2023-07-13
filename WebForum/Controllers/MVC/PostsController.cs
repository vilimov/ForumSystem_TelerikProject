using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.LikesModels;
using WebForum.Models.QueryParameters;
using WebForum.Models.ViewModels;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class PostsController : Controller
    {
        private readonly IPostServices postService;
        private readonly AuthManager authManager;
		private readonly IMapper mapper;
		private readonly ITagService tagService;
		private readonly IUserServices userService;
		public PostsController(IPostServices postService,AuthManager authManager, IMapper mapper, ITagService tagService, IUserServices userService)
        {
            this.postService = postService;
            this.authManager = authManager;
            this.mapper = mapper;
			this.tagService = tagService;
			this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
			if (!IsUserLogged())
 			{
				return RedirectToAction("Login", "Users");
			}
			List<Post> posts = this.postService.GetAllPosts().ToList();
			posts.Reverse();

			return View(posts);
        }

		[HttpGet]
		public IActionResult Searches(PostFilterQueryParameters searchFor)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			List<Post> posts = this.postService.FilterPostsBy(searchFor).ToList();
			posts.Reverse();
			return View(posts);
			//return RedirectToAction("Index", "Posts");
		}

		[HttpGet]
		public IActionResult Details(int id) 
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
            {
				var post = postService.GetPostById(id);
				return View(post);
			}
            catch (EntityNotFoundException ex)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return View("Error");               
            }
           
        }

		[HttpGet]
        public IActionResult Create() 
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			var postViewModel = new PostViewModel();
            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult Create(PostViewModel postViewModel)
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			if (!this.ModelState.IsValid)
            {
                
                return View(postViewModel);
            }
            try
            {
				var user = GetLoggedUser();
				var newPost = mapper.Map<Post>(postViewModel);
				var createdPost = postService.CreatePost(newPost, user);

				this.HttpContext.Response.StatusCode = StatusCodes.Status201Created;

				return RedirectToAction("Details", "Posts", new { id = createdPost.Id });
			}
            catch (DuplicateEntityException e)
            {
                this.HttpContext.Response.StatusCode= StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View(postViewModel);      // this will retur the same object and keep us on the same page
            }
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id)
        {
			if (!IsUserLogged())
			{
                return RedirectToAction("Login", "Users");
            }
			
			try
            {
				var post = postService.GetPostById(id);
				var postViewModel = mapper.Map<PostViewModel>(post);

				return View(postViewModel);
			}
            catch (EntityNotFoundException e)
            {
                this.HttpContext.Response.StatusCode=StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, PostViewModel postViewModel)
        {
			if (!this.ModelState.IsValid)
			{

				return View(postViewModel);
			}
			try
			{
				var user = GetLoggedUser();
				var newPost = mapper.Map<Post>(postViewModel);
				var createdPost = postService.UpdatePost(id, newPost, user);
				var alltags = tagService.GetAllTags();
				this.ViewData["postId"] = id;

				this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

				return RedirectToAction("Details", "Posts", new { id = createdPost.Id });
			}
			catch (InvalidOperationException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View(postViewModel);      // this will retur the same object and keep us on the same page
			}
			catch (UnauthorizedOperationException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Error");
			}
			

		}
        [HttpGet]
        public IActionResult Delete([FromRoute]int id)
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				var post = postService.GetPostById(id);
				var newPost = mapper.Map<PostViewModel>(post);
				return View(newPost);
			}
			catch (EntityNotFoundException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Error");
			}

		}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
			
            try
            {
				var user = GetLoggedUser();
				this.postService.DeletePost(id, user);
				return RedirectToAction("Index", "Posts");
			}
            catch (UnauthorizedOperationException e)
            {

				this.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View("Error");      // this will retur the same object and keep us on the same page
			}
		}

		[HttpPost]
		public IActionResult ToggleLike([FromRoute] int id)
		{
			try
			{
				var user = GetLoggedUser();
				var post = postService.GetPostById(id);

				var likePost = post.LikePosts.FirstOrDefault(lp => lp.UserId == user.Id);
				if (likePost == null)
				{
					this.postService.AddLikePost(post, user);
				}
				else
				{
					this.postService.RemoveLikePost(post, user);
				}

				return Ok();
			}
			catch (UnauthorizedOperationException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Error");
			}
			catch (EntityNotFoundException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Error");
			}
		}

		private bool IsUserLogged()
		{
			if (this.HttpContext.Session.GetString("LoggedUser") == null)
			{
				return false;
			}
			return true;
		}
		
		private User GetLoggedUser()
		{
			IsUserLogged();
			var getUserName = this.HttpContext.Session.GetString("LoggedUser");
			var loggedUser = userService.GetByUsername(getUserName);
			return loggedUser;
		}
		private bool IsUserAuthor(User user, Post post)
		{
			var loggedUser = GetLoggedUser();
			if (user.Username == post.Autor.Username)
			{
				return true;
			}
			return false;
		}
	}
}
