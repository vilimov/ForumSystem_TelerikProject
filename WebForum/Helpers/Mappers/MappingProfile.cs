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
            CreateMap<Post, PostDtoCreateUpdate>();
            CreateMap<Post, PostShowDto>()
                                        .ForMember(dto => dto.AutorName, post => post.MapFrom(user => user.Autor.Username))
                                        .ForMember(d=>d.Comments, post => post.MapFrom(src => MapComments(src))
                                        );
        }

        private Dictionary<string, string> MapComments(Post post)
        {
            var comments = new Dictionary<string, string>();

            foreach (var comment in post.Comments)
            {
                comments.Add(comment.Content, comment.Autor.Username);
            }

            return comments;
        }
    }
}

