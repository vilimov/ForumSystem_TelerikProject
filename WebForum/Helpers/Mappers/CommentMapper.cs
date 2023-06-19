using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Services;

namespace WebForum.Helpers.Mappers
{
    public class CommentMapper
    {
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;

        public CommentMapper(IPostServices postServices, IUserServices userServices)
        {
            this.postServices = postServices;
            this.userServices = userServices;
        }

        public Comment Map(CommentsCreateUpdateDTO dto)
        {
            return new Comment
            {
                Content = dto.Content
                //PostId = postServices.GetPostById(dto.PostId).Id,
                //AutorId = userServices.GetUserById(dto.AutorId).Id
            };
        }
    }
}
