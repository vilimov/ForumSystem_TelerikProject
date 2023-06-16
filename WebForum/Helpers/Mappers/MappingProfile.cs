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

        }

        private List<CommentsShowDTO> MapComments(Post post)
        {
            var comments = new List<CommentsShowDTO>();
            var listComments = post.Comments;
            foreach (var comment in listComments)
            {
                comments.Add(new CommentsShowDTO(comment));
            }

            return comments;
        }
        /*private List<Comment> MapComments(Post post)
        {
            return post.Comments;
        }*/

    }
}

