using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.ViewModels;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class PostsController : Controller
    {
        private readonly IPostServices postService;
        private readonly AuthManager authManager;
		private readonly IMapper mapper;
		public PostsController(IPostServices postService,AuthManager authManager, IMapper mapper)
        {
            this.postService = postService;
            this.authManager = authManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Post> posts = this.postService.GetAllPosts().ToList();

            return View(posts);
        }

		[HttpGet]
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

		[HttpGet]
        public IActionResult Create() 
        {
            var postViewModel = new PostViewModel();
            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult Create(PostViewModel postViewModel)
        {
            if(!this.ModelState.IsValid)
            {
                
                return View(postViewModel);
            }
            try
            {
				//TODO change to real user
				var user = authManager.TryGetUser("JuliusCaesar:Cleopatra");
				var newPost = mapper.Map<Post>(postViewModel);
				var createdPost = postService.CreatePost(newPost, user);

				this.HttpContext.Response.StatusCode = StatusCodes.Status201Created;
				//return RedirectToAction("Index", "Posts");
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
                return View("Erorr");
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
				//TODO change to real user
				var user = authManager.TryGetUser("JuliusCaesar:Cleopatra");
				var newPost = mapper.Map<Post>(postViewModel);
				var createdPost = postService.UpdatePost(id, newPost, user);

				this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
				//return RedirectToAction("Index", "Posts");
				return RedirectToAction("Details", "Posts", new { id = createdPost.Id });
			}
			catch (DuplicateEntityException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View(postViewModel);      // this will retur the same object and keep us on the same page
			}

		}
        [HttpGet]
        public IActionResult Delete([FromRoute]int id)
        {
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
				return View("Erorr");
			}

		}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
			
            try
            {
				//TODO change to real user
				var user = authManager.TryGetUser("PubliusOvidiusNaso:Metamorphoses");
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

	}
}
