using Microsoft.AspNetCore.Mvc;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Services;

namespace WebForum.Controllers.MVC
{
    public class CommentsController : Controller
    {
        private readonly CommentsServices commentService;
        private readonly IPostServices postService;
        private readonly AuthManager authManager;
        private readonly CommentMapper commentMapper;

        public CommentsController(CommentsServices commentServices, IPostServices postServices, AuthManager authManager, CommentMapper commentMapper)
        {
            this.commentService = commentService;
            this.postService = postService;
            this.authManager = authManager;
            this.commentMapper = commentMapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Comment> comments = this.commentService.GetAll().ToList();

            return View(comments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var commentViewModel = new CommentsCreateUpdateDTO();

            return View(commentViewModel);
        }

        [HttpPost]
        public IActionResult Create(CommentsCreateUpdateDTO commentViewModel) 
        {
            return View();
        }
    }
}
