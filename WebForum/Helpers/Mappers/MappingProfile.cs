using AutoMapper;
using WebForum.Models;
using WebForum.Models.Dtos;

namespace WebForum.Helpers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<SourceClass1, DestinationClass1>();
            CreateMap<PostDtoCreateUpdate, Post>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<Post, PostShowDto>()
                        .ForMember(dto => dto.AutorName, post => post.MapFrom(user => user.Autor.Username))
                        .ForMember(dto => dto.Comments, post => post.MapFrom(src => MapComments(src)));

            CreateMap<Comment, CommentsShowDTO>()
                .ForMember(dto => dto.AutorName, opt => opt.MapFrom(comment => comment.Autor.Username))
                .ForMember(dto => dto.PostTitle, opt => opt.MapFrom(comment => comment.Post.Title))
                .ForMember(dto => dto.CreatedAt, opt => opt.MapFrom(comment => comment.CreatedAt));

        }

        private List<CommentsShowDTO> MapComments(Post post)
        {
            var comments = new List<CommentsShowDTO>();
            List<Comment> listComments = post.Comments;
            foreach (var comment in listComments)
            {
                comments.Add(new CommentsShowDTO
                {
                    Content = comment.Content,
                    AutorName = comment.Autor.Username,
                    PostTitle = comment.Post.Title,
                    CreatedAt = comment.CreatedAt
                });
            }

            return comments;
        }

    }
}

