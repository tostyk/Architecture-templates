using AutoMapper;
using MediatR;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class GetAllArticlesQueryHandler(IArticleRepository articleRepository, IMapper mapping)
        : IRequestHandler<GetAllArticlesQuery, List<ArticleResponseDTO>>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IMapper _mapping = mapping;

        public async Task<List<ArticleResponseDTO>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            List<Article> articles = await _articleRepository.GetAllAsync(request.Offset, request.Count);
            List<ArticleResponseDTO> response = _mapping.Map<List<Article>, List<ArticleResponseDTO>>(articles);

            return response;
        }
    }
}
