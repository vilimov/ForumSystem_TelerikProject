using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Models.ViewModels;
using WebForum.Controllers.MVC;

using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class CommentsController : Controller
    {
        private readonly ICommentsServices commentService;
        private readonly IPostServices postService;
        private readonly AuthManager authManager;
        private readonly CommentMapper commentMapper;
		private readonly IMapper mapper;
		private readonly IUserServices userService;

		public CommentsController(ICommentsServices commentServices, IPostServices postServices, AuthManager authManager, CommentMapper commentMapper, IMapper mapper, IUserServices userService)
        {
            this.commentService = commentServices;
            this.postService = postServices;
            this.authManager = authManager;
            this.commentMapper = commentMapper;
			this.mapper = mapper;
			this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			List<Comment> comments = this.commentService.GetAll();
            return View(comments);
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
                Comment comment = this.commentService.GetCommentById(id);
                return View(comment);
            }
            catch (EntityNotFoundException ex)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpGet]public IActionResult Create([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			var commentViewModel = new CommentViewModel();
            return View(commentViewModel);
        }
        

        [HttpPost]
        public IActionResult Create([FromRoute]int id, CommentViewModel commentViewModel)
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			if (!this.ModelState.IsValid)
			{
				return View(commentViewModel);
			}
			try
            {
                var user = GetLoggedUser();
				var post = postService.GetPostById(id);
                Comment newComment = mapper.Map<Comment>(commentViewModel);
                var createdComment = commentService.CreateComment(newComment, post, user);

                this.HttpContext.Response.StatusCode = StatusCodes.Status201Created;
                //return RedirectToAction("Index", "Posts");
                return RedirectToAction("Details", "Comments", new { id = createdComment.Id });
            }
            catch (DuplicateEntityException e)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = e.Message;
                //return View("Error");             this will return the Error page
                return View(commentViewModel);      // this will retur the same object and keep us on the same page
            }
        }

		[HttpGet]
		public IActionResult Edit([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				var comment = commentService.GetCommentById(id);
				var commentViewModel = mapper.Map<CommentViewModel>(comment);

				return View(commentViewModel);
			}
			catch (EntityNotFoundException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Erorr");
			}
		}

		[HttpPost]
		public IActionResult Edit([FromRoute] int id, CommentViewModel commentViewModel)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			if (!this.ModelState.IsValid)
			{
				return View(commentViewModel);
			}
			try
			{
				var user = GetLoggedUser();
				var newComment = mapper.Map<Comment>(commentViewModel);
				var createdComment = commentService.Update(id, newComment, user);
				this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
				return RedirectToAction("Details", "Comments", new { id = createdComment.Id });
			}
			catch (DuplicateEntityException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				return View(commentViewModel);
			}
		}

		[HttpGet]
		public IActionResult Delete([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				var comment = commentService.GetCommentById(id);
				var newComment = mapper.Map<CommentViewModel>(comment);
				return View(newComment);
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
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				Comment currentComment = commentService.GetCommentById(id);
				var postId = commentService.GetCommentById(id).PostId;
				var user = GetLoggedUser();
				this.commentService.Delete(id, user);
				return RedirectToAction("Details", "Posts", new { id = postId});
			}
			catch (UnauthorizedOperationException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Error");
			}
		}

		[HttpPost]
		public IActionResult ToggleLike([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				var user = GetLoggedUser();
				var comment = commentService.GetCommentById(id);
				var likeComment = comment.CommentLikes.FirstOrDefault(lp => lp.UserId == user.Id);
				if (likeComment == null)
				{
					this.commentService.AddLikeComment(comment, user);
				}
				else
				{
					this.commentService.RemoveLikeComment(comment, user);
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
	}
}
