using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.ViewModels;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
	public class TagController : Controller
	{
		private readonly ITagService tagService;
		private readonly AuthManager authManager;
		private readonly IPostServices postService;
		public TagController(ITagService tagService, AuthManager authManager, IPostServices postServices)
        {
            this.tagService = tagService;
			this.authManager = authManager;
			this.postService = postServices;
        }
        public IActionResult Index()
		{
			List<Tag> tags = this.tagService.GetAllTags().ToList();
			return View(tags);
		}


		[HttpGet]
		public IActionResult CreateTag()
		{
			var newTag = new Tag();
			return View(newTag);
		}

		[HttpPost]
		public IActionResult CreateTag(Tag newTag)
		{
			if (!this.ModelState.IsValid)
			{
				return View(newTag);
			}
			try
			{
				var createTag = this.tagService.CreateTag(newTag);

				this.HttpContext.Response.StatusCode = StatusCodes.Status201Created;
				//return RedirectToAction("Index", "Posts");
				return RedirectToAction("Index", "Tag");
			}
			catch (DuplicateEntityException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View(newTag);      // this will retur the same object and keep us on the same page
			}
		}




		[HttpGet]
		public IActionResult Edit([FromRoute] int id)
		{
			try
			{
				var tag = tagService.GetTagById(id);
				return View(tag);
			}
			catch (EntityNotFoundException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Erorr");
			}
		}
		[HttpPost]
		public IActionResult Edit([FromRoute] int id, Tag tagname)
		{
			if (!this.ModelState.IsValid)
			{

				return View(tagname);
			}
			try
			{

				var editedTag = tagService.UpdateTag(id, tagname.Name);

				this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
				//return RedirectToAction("Index", "Posts");
				return RedirectToAction("Index", "Tag");
			}
			catch (DuplicateEntityException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View(tagname);      // this will retur the same object and keep us on the same page
			}

		}
		[HttpGet]
		public IActionResult Delete([FromRoute] int id)
		{
			try
			{
				var deletedTag = tagService.GetTagById(id);
				return View(deletedTag);
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
				var user = authManager.TryGetUser("JuliusCaesar:Cleopatra");
				this.tagService.DeleteTag(id,user);
				return RedirectToAction("Index", "Tag");
			}
			catch (UnauthorizedOperationException e)
			{

				this.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View("Error");      // this will retur the same object and keep us on the same page
			}
		}

        public IActionResult SelectTags(int postId)
        {
            try
            {
                var allTags = tagService.GetAllTags().ToList();
                var postTags = postService.GetPostById(postId).PostTags.Select(pt => pt.TagId).ToList();

                var availableTags = allTags.Where(tag => !postTags.Contains(tag.Id)).ToList();


                var viewModel = new SelectTagsViewModel { PostId = postId, Tags = availableTags };
                return View(viewModel);
            }
            catch (DuplicateEntityException e)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = e.Message;
                var viewModel = new SelectTagsViewModel { PostId = postId, Tags = new List<Tag>() }; // Empty tag list
                
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult AddTagToPost(int postId, List<string> tagIds)
        {
            //TODO change to real user
            var user = authManager.TryGetUser("JuliusCaesar:Cleopatra");
            // Perform logic to associate the tags with the post in your data layer
            foreach (var tagId in tagIds)
			{
				int tagTempId = int.Parse(tagId);

				var tagText = tagService.GetTagById(tagTempId).Name;
				this.tagService.AddTagToPost(postId, tagText, user.Id);
			}
            // Redirect back to the Edit action of the Posts controller
            return RedirectToAction("Edit", "Posts", new { id = postId });
        }


        public IActionResult ListTags(int postId)
        {
            try
            {
				var postTags = postService.GetPostById(postId).PostTags.ToList();
                var tagsOfThePost = postTags.Select(t => t.Tag).ToList();
                var viewModel = new SelectTagsViewModel { PostId = postId, Tags = tagsOfThePost };
                return View(viewModel);
            }
            catch (DuplicateEntityException e)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = e.Message;
                var viewModel = new SelectTagsViewModel { PostId = postId, Tags = new List<Tag>() }; // Empty tag list

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult RemoveTagFromPost(int postId, List<string> tagIds)
        {
            //TODO change to real user
            var user = authManager.TryGetUser("JuliusCaesar:Cleopatra");
            // Perform logic to associate the tags with the post in your data layer
            foreach (var tagId in tagIds)
            {
                int tagTempId = int.Parse(tagId);

                var tagText = tagService.GetTagById(tagTempId).Name;
                this.tagService.RemoveTagFromPost(postId, tagText, user.Id);
            }
            // Redirect back to the Edit action of the Posts controller
            return RedirectToAction("Edit", "Posts", new { id = postId });
        }

    }
}


