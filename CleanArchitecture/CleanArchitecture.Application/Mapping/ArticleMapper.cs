using AutoMapper;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Mapping
{
    public class ArticleMapper : Profile
    {
        public ArticleMapper()
        {
            CreateMap<ArticleRequestDTO, Article>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
            CreateMap<Article, ArticleResponseDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }

}
