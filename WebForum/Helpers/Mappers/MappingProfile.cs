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

            CreateMap<Comment, CommentToPostDto>()
                .ForMember(dto => dto.Content, opt => opt.MapFrom(comment => comment.Content))
                .ForMember(dto => dto.Likes, opt => opt.MapFrom(comment => comment.Likes))
                .ForMember(dto => dto.CreatedAt, opt => opt.MapFrom(comment => comment.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dto => dto.Autor, opt => opt.MapFrom(comment => comment.Autor.Username));

            CreateMap<Post, PostShowDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(post => post.Title))
                .ForMember(dto => dto.Content, opt => opt.MapFrom(post => post.Content))
                .ForMember(dto => dto.CreatedAt, opt => opt.MapFrom(post => post.CreatedAt))
                .ForMember(dto => dto.Likes, opt => opt.MapFrom(post => post.Likes))
                .ForMember(dto => dto.AutorName, opt => opt.MapFrom(post => post.Autor.Username))
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(post => post.Comments.Select(c => new CommentToPostDto
                {
                    Content = c.Content,
                    Likes = c.Likes,
                    CreatedAt = c.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    Autor = c.Autor.Username
                }).ToList()));
        }
    }
}
