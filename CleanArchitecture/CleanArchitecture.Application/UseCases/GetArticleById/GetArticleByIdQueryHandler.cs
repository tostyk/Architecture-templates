using AutoMapper;
using MediatR;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Application.Exceptions;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class GetArticleByIdQueryHandler(IArticleRepository articleRepository, IMapper mapping)
        : IRequestHandler<GetArticleByIdQuery, ArticleResponseDTO>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IMapper _mapping = mapping;

        public async Task<ArticleResponseDTO> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            Article? article = await _articleRepository.GetByIdAsync(request.ArticleId);

            if (article == null)
            {
                throw new NotFoundException("Article");
            }

            ArticleResponseDTO response = _mapping.Map<ArticleResponseDTO>(article);

            return response;
        }
    }
}
