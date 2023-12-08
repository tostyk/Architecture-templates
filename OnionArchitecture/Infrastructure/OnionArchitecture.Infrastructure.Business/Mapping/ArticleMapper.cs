using AutoMapper;
using OnionArchitecture.Domain.Core;
using OnionArchitecture.Services.Interfaces.DTO;

namespace OnionArchitecture.Infrastructure.Business.Mapping
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
